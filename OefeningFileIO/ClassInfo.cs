using System;
using System.Collections.Generic;
using System.Text;

namespace OefeningFileIO
{
    public class ClassInfo
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public List<string> constructors { get; set; } = new List<string>();
        public List<string> methods { get; set; } = new List<string>();
        public List<string> inherits { get; set; } = new List<string>();
        public List<string> usings { get; set; } = new List<string>();
        public List<string> properties { get; set; } = new List<string>();
        public List<string> parameters { get; set; } = new List<string>();

        public void Show()
        {
            Console.WriteLine($"{Namespace},{Name}");
            foreach (string s in constructors) Console.WriteLine($"constructor : {s}");
            foreach (string s in methods) Console.WriteLine($"method : {s}");
            foreach (string s in inherits) Console.WriteLine($"inherit : {s}");
            foreach (string s in usings) Console.WriteLine($"using : {s}");
            foreach (string s in properties) Console.WriteLine($"property : {s}");
            foreach (string s in parameters) Console.WriteLine($"parameter : {s}");
            Console.WriteLine("_________________");
        }
    }

}
