using ACCSetups;
using ACCSetups.Models.AccSetup;

namespace ACCSetupsTests.Helpers
{
    public static class PreparedSetups
    {
        public static BaseSetup GetSafeSetup()
        {
            var setupFile = GetSetupFile("Safe.json");
            
            return setupFile.LoadedSetup;
        }

        public static BaseSetup GetAggressiveSetup()
        {
            var setupFile = GetSetupFile("Aggressive.json");
            
            return setupFile.LoadedSetup;
        }

        public static BaseSetup GetMinSetup()
        {
            var setupFile = GetSetupFile("Min.json");

            return setupFile.LoadedSetup;
        }

        public static BaseSetup GetMaxSetup()
        {
            var setupFile = GetSetupFile("Max.json");

            return setupFile.LoadedSetup;
        }

        private static SetupFile GetSetupFile(string filename)
        {
            var filepath = "SetupsTests";
            var setupFile = new SetupFile(filepath, filename);
            setupFile.Load();
            
            return setupFile;
        }
    }
}
