using Xunit;
using ACCSetups;

namespace ACCSetupsTests
{
    public class SetupFileTests
    {
        [Fact]
        public void Load_FileFound_FileLoaded()
        {
            // Arrange
            var filepath = "SetupsTests";
            var filename = "Imola.json";
            var setupFile = new SetupFile(filepath, filename);

            // Act
            setupFile.Load();

            // Assert
            Assert.NotNull(setupFile.LoadedSetup);
        }

        [Fact]
        public void Load_FileFound_AllPropertiesLoaded()
        {
            // Arrange
            var filepath = "SetupsTests";
            var filename = "Imola.json";
            var setupFile = new SetupFile(filepath, filename);

            // Act
            setupFile.Load();
            var loadedSetup = setupFile.LoadedSetup;

            // Assert
            Assert.Equal("ferrari_488_gt3", loadedSetup.CarName);
            Assert.Equal(0, loadedSetup.BasicSetup.Tyres.TyreCompound);
            Assert.Equal(new int[] { 61,60,60,58, }, loadedSetup.BasicSetup.Tyres.TyrePressure);
            // TODO: Complete the properties
        }
    }
}
