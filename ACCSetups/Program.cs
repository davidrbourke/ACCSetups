using System;

namespace ACCSetups
{
    class Program
    {
        static void Main(string[] args)
        {
            var filepath = "C:\\Users\\david\\OneDrive\\Documents\\Assetto Corsa Competizione\\Setups\\ferrari_488_gt3_evo\\nurburgring";
            var filename = "Safe default.json";
            var altFilename = "Aggressive default.json";
            var setupFile = new SetupFile(filepath, filename);
            var altSetupFile = new SetupFile(filepath, altFilename);

            // Act
            setupFile.Load();
            altSetupFile.Load();
            
            var setup = new Setup();
            setup.AddSourceSetup(setupFile.LoadedSetup);
            setup.AddSourceSetup(altSetupFile.LoadedSetup);

            setup.ApplySetup(Models.Enums.ConfigurationType.REDUCE_UNDERSTEER);

            var updatedSetup = setup.GetUpdatedSetup();

            var updatedFileName = $"{filename.Replace(".json", "")}_merged_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.json";
            setupFile.Save(updatedSetup, filepath, updatedFileName);
        }
    }
}
