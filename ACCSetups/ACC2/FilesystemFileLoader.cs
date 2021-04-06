using System.IO;

namespace ACCSetups.ACC2
{
    public class FilesystemFileLoader : ISetupLoader
    {
        public string LoadFileAsString(string filepathAndFilename)
        {
            return File.ReadAllText(filepathAndFilename);
        }
    }
}
