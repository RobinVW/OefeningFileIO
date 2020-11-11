using System;

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
           
        }

        public void MaakInputFolderAan() { 
            
        }
    }
}
