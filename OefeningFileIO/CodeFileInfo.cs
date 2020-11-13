using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OefeningFileIO
{
    public class CodeFileInfo
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public int LinesOfCode { get; set; }
        public bool IsClass { get; set; }
        public bool IsInterface { get; set; }
        public FileInfo FileInfo { get; set; }

        public CodeFileInfo() {
            LinesOfCode = 0;
            IsClass = false;
            IsInterface = false;
        }
        public override string ToString()
        {
            string str = "";
            if (!IsClass && !IsInterface)
            {
                str += "This file does not contain code";
                return str;
            }
            if (IsClass) {
                str += "(Class)";
            }
            if (IsInterface) {
                str += "(Class)";
            }
            str += Namespace + "," + Name + "," + LinesOfCode.ToString();
            return str;
        }
    }
}
