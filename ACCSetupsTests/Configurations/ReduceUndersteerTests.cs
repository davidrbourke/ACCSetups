using ACCSetups.Configurations;
using ACCSetupsTests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ACCSetupsTests.Configurations
{
    public class ReduceUndersteerTests
    {
        [Fact]
        public void GetUpdatedSetup_SafeAndAggressiveLoaded_BlendedSetupReturned()
        {
            // Arrange
            var aggressiveSetup = PreparedSetups.GetMaxSetup();

            // Act
            var blendSafeAndAggressive = new ReduceUndersteer(aggressiveSetup);
            var updatedSetup = blendSafeAndAggressive.GetUpdatedSetup();

            // Assert

        }
    }
}
