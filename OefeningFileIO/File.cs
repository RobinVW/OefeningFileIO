using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace OefeningFileIO
{
    public class File
    {
        public string FileString { get; set; }
        public ClassInfo ClassInfo{ get; set; }

        public File()
        {
            ClassInfo = new ClassInfo();
        }

        public void maakFileString ( FileInfo fi ){
            using(StreamReader sr = fi.OpenText())
            {
                FileString = sr.ReadToEnd().Replace('\r', ' ').Replace('\n', ' ');
            }
        }

        public string GetUsingStatements(string str)
        {
            while (str.Contains("using ")) {
                if (str.IndexOf("using") != 0) {
                    if(str.ElementAt(str.IndexOf("using") - 1) ==' ') {
                        ClassInfo.usings.Add(str.Substring(str.IndexOf("using") + 6).Trim().Split(';')[0]);
                        str = str.Remove(str.IndexOf("using"), str.IndexOf(';') - str.IndexOf("usings"));
                    }
                }
                else
                {
                    ClassInfo.usings.Add(str.Substring(str.IndexOf("using") + 6).Trim().Split(';')[0]);
                    str = str.Remove(str.IndexOf("using"), str.IndexOf(';') - str.IndexOf("usings"));
                }
                
            }
            return str;
        }

        public string RemoveNamespace(string str)
        {
            if (str.Contains("namespace ")) {
                str = str.Remove(str.IndexOf("namespace"), str.IndexOf('{') - str.IndexOf("namespace") + 1);
            }
            return str;
        }

        public string RemoveClassOrInterfaceName(string str) {
            if (str.Contains(" class ")) {
                GetInherit(str);
                //+1 toevoegen aangezien anders { in de string blijft
                str = str.Remove(0, str.IndexOf('{')+1);
            }
            if (str.Contains(" interface "))
            {
                GetInherit(str);
                str = str.Remove(0, str.IndexOf('{')+1);
            }
            return str.Trim();
        }

        public void GetInherit(string str)
        {
            char[] chars = { ':','{' };
            int index = str.IndexOfAny(chars);
            if (str.ElementAt(index) == ':') {
                ClassInfo.inherits.Add(str.Substring(str.IndexOf(':') + 1).Trim().Split('{')[0]);
            }
        }

        public string GetParameterPropertyOrMethod(string str)
        {
            char[] chars = { ';', '{', '(', '}' };
            var index = str.IndexOfAny(chars);
            switch(str[index]){
                case ';':
                    var paraLength = str.Trim().Substring(0).Split(';')[0].Length;
                    ClassInfo.parameters.Add(str.Substring((paraLength/2)+1).Split(';')[0]);
                    str = str.Remove(0, str.IndexOf(';') + 1);
                    break;
                case '(':
                    if (str.Contains(" " + ClassInfo.Name)) {
                        ClassInfo.constructors.Add(str.Substring(str.IndexOf(ClassInfo.Name)).Trim().Split(')')[0] + ')');
                        str = ReadUntilNextMatchingBrace(str);
                    }
                    else
                    {
                        var indexFirstCapital = str.Where(c => char.IsUpper(c)).Select(c => c).First();
                        ClassInfo.methods.Add(str.Substring(str.IndexOf(indexFirstCapital)).Trim().Split(')')[0] + ')');
                        str = ReadUntilNextMatchingBrace(str);
                    }
                    break;
                case '{':
                    var propertyString = str.Substring(0, str.IndexOf('{'));
                    var items = propertyString.Trim().Split(' ');
                    ClassInfo.properties.Add(items[items.Length - 1]);
                    str = ReadUntilNextMatchingBrace(str);
                    break;
                case '}':
                    str = str.Substring(str.IndexOf('}')+1);
                    break;
            }

            return str.Trim();
        }

        private string ReadUntilNextMatchingBrace(string code)
        {
            int nOpen = 0;
            int indexOpen;
            int indexClose;

            do
            {
                indexOpen = code.IndexOf('{');
                if (indexOpen == -1)
                    indexOpen = code.Length;
                indexClose = code.IndexOf('}');
                if(indexOpen < indexClose)
                {
                    nOpen++;
                    code = code.Substring(indexOpen + 1);
                }
                if(indexOpen > indexClose)
                {
                    nOpen--;
                    code = code.Substring(indexClose + 1);
                }
            }
            while (nOpen > 0);
            return code;
        }

        
    }
}
