using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OefeningFileIO
{
    public class Output
    {
        public StreamWriter Writer { get; set; }

        public void WriteClassInfoOutput(List<ClassInfo> classList, String outputFolder, string fileName)
        {
            using (Writer = new StreamWriter(Path.Combine(outputFolder, fileName))) {
                foreach (ClassInfo ci in classList)
                {
                    Writer.WriteLine($"{ci.Namespace},{ci.Name}");
                    Writer.Write(Writer.NewLine);
                    foreach (string s in ci.constructors)
                    {
                        Writer.WriteLine($"constructor : {s}");
                    }
                    foreach (string s in ci.methods)
                    {
                        Writer.WriteLine($"method : {s}");
                    }

                    foreach (string s in ci.inherits)
                    {
                        Writer.WriteLine($"inherit : {s}");
                    }

                    foreach (string s in ci.usings)
                    {
                        Writer.WriteLine($"using : {s}");
                    }

                    foreach (string s in ci.properties)
                    {
                        Writer.WriteLine($"property : {s}");
                    }

                    foreach (string s in ci.parameters)
                    {
                        Writer.WriteLine($"parameter : {s}");
                    }
                    Writer.Write(Writer.NewLine); 
                    Writer.Write(Writer.NewLine);
                }
                
            } 
        }

    }
}
