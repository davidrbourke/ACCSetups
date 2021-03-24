using ACCSetups;
using ACCSetups.Models.AccSetup;
using System.Text.Json;

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

        public static JsonDocument GetSafeSetupJsonDocument()
        {
            var setupFile = GetSetupFile("Max.json");

            return setupFile.JsonSetup;
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
