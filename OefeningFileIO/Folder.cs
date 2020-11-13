using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OefeningFileIO
{

    
    public class Folder
    {
        public FileInfo[] Files { get; set; }

        public Folder() { }

        public void GetAllCSharpFiles(DirectoryInfo directory) {
            Files = directory.GetFiles("*.cs", SearchOption.AllDirectories);
        }
    }
}
