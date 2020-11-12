using System;
using System.IO;

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
            Input input = new Input();
            //  C:\Users\RobinVW\Documents\FileIO
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

            //zip location:
            //  C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Animals.zip
            //unzip folder
            //  C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Unzip Folder
            input.ExtractZipToFolder("C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Animals.zip", "C:\\Users\\RobinVW\\Documents\\FileIO\\Work folder\\Unzip Folder");
        }

        public DirectoryInfo MaakFolderAan(string folderNaam, string folderPath) {

            return Directory.CreateDirectory(folderPath + "\\" + folderNaam);
        }
    }
}
