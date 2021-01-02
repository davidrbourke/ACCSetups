using ACCSetups;
using ACCSetupsTests.Helpers;
using Xunit;

namespace ACCSetupsTests
{
    public class SetupTests
    {
        [Fact]
        public void ApplySetup_TwoSourceSetups_AddedToSourceSetups()
        {
            // Arrange
            var setup = new Setup();
            setup.AddSourceSetup(PreparedSetups.GetSafeSetup());
            setup.AddSourceSetup(PreparedSetups.GetAggressiveSetup());

            // Act
            var sourceSetups = setup.GetSourceSetups();

            // Assert
            Assert.Equal(2, sourceSetups.Count);
        }
    }
}
