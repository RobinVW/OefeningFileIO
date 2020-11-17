using System;
using System.Collections.Generic;
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

        
    }
}
