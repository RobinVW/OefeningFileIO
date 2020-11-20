using System.IO;
using System.IO.Compression;

namespace OefeningFileIO
{
    public class Input
    {
        public DirectoryInfo InputFolder { get; set; }
        public DirectoryInfo OutputFolder { get; set; }

        public Input() { 
        }
        public DirectoryInfo MaakFolderAan(string folderNaam, string folderPath)
        { 
            return Directory.CreateDirectory(folderPath + "\\" + folderNaam);
        }

        public void ExtractZipToFolder(string zipPath, string extractiePath) {
            ZipFile.ExtractToDirectory(zipPath, extractiePath);
        }
    }
}
