using System;
using System.IO;
using System.Linq;

namespace OefeningFileIO
{
    class Program
    {
        /*
                Input: 
                    - locatie van zipbestand met daarin VS project
                    - locatie en naam van input folder
                    - locatie en naam van output folder
                Output
                    - analyse code
                Functionaliteit
                    - Maak folder aan waar resultaten in terrecht moeten komen
                    - unzip zipbestand in de input folder
                    - analyseer de code bestanden (.cs)
                        * Geef voor elk code bestand mee of het een class of interface is
                        * Geef de naam van de klasse of interface
                        * Geef de namespace mee
                        * Geef het aantal lijnen code mee (blaco lijnen tellen niet mee)
                        * Indien er meerdere klassen of interfaces gedefinieerd zijn in het bestand geef dan een foutmelding weer
                        * Schijf de resultaten weg in een tekstbestand ("Analyse<zipbestandsnaam>.txt")
                    - Analyseer de klassen
                        * Geef voor elke klasse de namespace + naam
                        * Lijst de constructors op
                        * Lijst de using statements op
                        * Lijst de properties op
                        * Lijst de variabelen op
                        * Geef de klassen weer waarvan wordt overgeërfd of de interface die word geïmplementeerd
                        * Schrijf de resultaten weg in een tekstbestand ("ClassInfo<zipbestandsnaam>.txt"
                 Opmerking
                     - Hou geen rekening met lambda-methodes
                
        */
        static void Main(string[] args)
        {
            Program program = new Program();
            Input input = new Input();
            /*
             
             
            //  C:\Users\RobinVW\Documents\FileIO
            // desktop:
            // C:\Users\robin\OneDrive\Documenten\FileIO
            Console.WriteLine("Geef het path naar de input folder:");
            var inputPath = Console.ReadLine();
            // InputFolder
            Console.WriteLine("Geef de naam van de input folder in:");
            var inputNaam = Console.ReadLine();
            input.InputFolder = input.MaakFolderAan(inputNaam, inputPath);

            Console.WriteLine("Geef het path naar de ouput folder:");
            var outputPath = Console.ReadLine();
            // InputFolder
            Console.WriteLine("Geef de naam van de ouput folder in:");
            var outputNaam = Console.ReadLine();
            input.OutputFolder = input.MaakFolderAan(outputNaam, outputPath);
            
            */

            //zip location:
            //  C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Animals.zip
            //unzip folder
            //  C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Unzip Folder
            //input.ExtractZipToFolder("C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Animals.zip", "C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Unzip Folder");
            string workFolderPathPC = @"C:\Users\robin\OneDrive\Documenten\FileIO\Work folder\Unzip Folder\";
            string zipFilePathPC = @"C:\Users\robin\OneDrive\Documenten\FileIO\Work folder\\Animals.zip";
            string workFolderPathLAPTOP = @"C:\Users\RobinVW\Documents\FileIO\Work folder\Unzip Folder";
            string zipFilePathLAPTOP = @"C:\Users\RobinVW\Documents\FileIO\Work folder\Animals.zip";
            input.ExtractZipToFolder(zipFilePathLAPTOP, workFolderPathLAPTOP);
            input.WorkFolder = new DirectoryInfo(workFolderPathLAPTOP);

            Folder fl = new Folder();
            fl.GetAllCSharpFiles(input.WorkFolder);


            foreach (FileInfo file in fl.Files)
            {
                Console.WriteLine(file.ToString());
                CodeFileInfo cfi = program.GetCodeFileInfo(file);
                //Console.WriteLine(cfi.ToString());
                Console.WriteLine(cfi.IsValid);
                if (cfi.IsValid) {
                    File f = new File();
                    f.maakFileString(file);
                    var FileString = f.FileString;
                    FileString = f.GetUsingStatements(FileString);
                    f.ClassInfo.Namespace = cfi.Namespace;
                    f.ClassInfo.Name = cfi.Name;
                    FileString = f.RemoveNamespace(FileString);
                    Console.WriteLine(FileString);
                    f.ClassInfo.Show();
                }
            }
        }

        private CodeFileInfo GetCodeFileInfo(FileInfo fi){
            using (StreamReader sr = fi.OpenText()) {
                CodeFileInfo cfi = new CodeFileInfo();
                cfi.FileInfo = fi;
                int lineCount = 0;
                string line;
                while ((line = sr.ReadLine()) != null) {
                    if (line.Trim().Length > 0) lineCount++;
                    if (line.Contains(" class ")) {
                        cfi.IsClass = true;
                        cfi.IsValid = true;
                        cfi.Name = line.Substring(line.IndexOf("class") + 6).Trim().Split(new char[] { ' ', ':', ';', '{' }, StringSplitOptions.None)[0];
                    }
                    if (line.Contains(" interface ")) {
                        cfi.IsInterface = true;
                        cfi.IsValid = true;
                        cfi.Name = line.Substring(line.IndexOf("class") + 10).Trim().Split(new char[] { ' ', ':', ';', '{' }, StringSplitOptions.None)[0];
                    }
                    if (line.Contains("namespace ")) {
                        if (line.IndexOf("namespace") != 0)
                        {
                            if (line.ElementAt(line.IndexOf("namespace") - 1) == ' ')
                            {
                                cfi.Namespace = line.Substring(line.IndexOf("namespace") + 10).Trim();
                            }
                        }
                        else {
                            cfi.Namespace = line.Substring(line.IndexOf("namespace") + 10).Trim();
                        }
                    }
                }
                cfi.LinesOfCode = lineCount;
                return cfi;
            }
        }
    }
}
