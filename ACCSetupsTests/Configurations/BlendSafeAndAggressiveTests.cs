using ACCSetups.Configurations;
using ACCSetupsTests.Helpers;
using Xunit;

namespace ACCSetupsTests.Configurations
{
    public class BlendSafeAndAggressiveTests
    {
        [Fact]
        public void GetUpdatedSetup_SafeAndAggressiveLoaded_BlendedSetupReturned()
        {
            // Arrange
            var safeSetup = PreparedSetups.GetMinSetup();
            var aggressiveSetup = PreparedSetups.GetMaxSetup();

            // Act
            var blendSafeAndAggressive = new BlendSafeAndAggressive(safeSetup, aggressiveSetup);
            var updatedSetup = blendSafeAndAggressive.GetUpdatedSetup();

            // Assert
            var tyres = updatedSetup.BasicSetup.Tyres;

            Assert.Equal(new int[] { 74, 74, 74, 74 }, tyres.TyrePressure.ToArray());

            var alignment = updatedSetup.BasicSetup.Alignment;
            Assert.Equal(new int[] { 25, 25, 25, 25 }, alignment.Camber.ToArray());
            Assert.Equal(new int[] { 40, 40, 40, 40 }, alignment.Toe.ToArray());
            Assert.Equal(49, alignment.CasterLF);
            Assert.Equal(49, alignment.CasterRF);

            var electronics = updatedSetup.BasicSetup.Electronics;
            Assert.Equal(6, electronics.TC1);
            Assert.Equal(6, electronics.TC2);
            Assert.Equal(6, electronics.Abs);
            Assert.Equal(6, electronics.ECUMap);

            var mechanicalBalance = updatedSetup.AdvancedSetup.MechanicalBalance;
            Assert.Equal(25, mechanicalBalance.ARBFront);
            Assert.Equal(25, mechanicalBalance.ARBRear);
            Assert.Equal(10, mechanicalBalance.BrakeTorque);
            Assert.Equal(53, mechanicalBalance.BrakeBias);
            Assert.Equal(new int[] { 5, 5, 5, 5 }, mechanicalBalance.WheelRate.ToArray());
            Assert.Equal(new int[] { 11, 11, 11, 11 }, mechanicalBalance.BumpStopRateUp.ToArray());
            Assert.Equal(new int[] { 5, 5, 5, 5 }, mechanicalBalance.BumpStopRateDn.ToArray());
            Assert.Equal(new int[] { 10, 10, 30, 30 }, mechanicalBalance.BumpStopWindow.ToArray());

            var dampers = updatedSetup.AdvancedSetup.Dampers;
            Assert.Equal(new int[] { 6, 6, 6, 6 }, dampers.BumpSlow.ToArray());
            Assert.Equal(new int[] { 6, 6, 6, 6 }, dampers.BumpFast.ToArray());
            Assert.Equal(new int[] { 6, 6, 6, 6 }, dampers.ReboundSlow.ToArray());
            Assert.Equal(new int[] { 6, 6, 6, 6 }, dampers.ReboundFast.ToArray());


            var aeroBalance = updatedSetup.AdvancedSetup.AeroBalance;
            Assert.Equal(new int[] { 13, 6, 13, 18 }, aeroBalance.RideHeight);
            Assert.Equal(6, aeroBalance.Splitter);
            Assert.Equal(7, aeroBalance.RearWing);
            Assert.Equal(new int[] { 3, 3 }, aeroBalance.BrakeDuct);

            var driveTrain = updatedSetup.AdvancedSetup.Drivetrain;
            Assert.Equal(14, driveTrain.Preload);
        }
    }
}
