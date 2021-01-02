using ACCSetups.Models.AccSetup;

namespace ACCSetups
{
    public interface ISetupFile
    {
        BaseSetup LoadedSetup { get; }

        public void Load();

        public void Save(BaseSetup setup, string filepath, string filename);
    }
}
