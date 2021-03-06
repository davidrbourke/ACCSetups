﻿using ACCSetups.ACC2;
using FluentAssertions;
using System.IO;
using Xunit;

namespace ACCSetupsTests.ACC2
{
    public class CarSetupTests
    {
        [Fact]
        public void LoadCarConfigValues_Load_ValuesAreLoadedFromJson()
        {
            // Arrange
            var file = File.ReadAllText($"SetupsTests\\Safe.json");
            var carSetup = new CarSetup();

            // Act
            carSetup.LoadCarConfigValues(file);

            // Assert
            var components = carSetup.CarConfigComponents;
            components[0].ConfigValues.Should().Be("ferrari_488_gt3_evo");
            components[1].ConfigValues.Should().Be("0");
            components[2].ConfigValues.Should().Be("[\r\n  56,\r\n  56,\r\n  53,\r\n  53\r\n]");
        }

        [Fact]
        public void UpdateCarConfigValues_SingleUpdate_RawJsonObjectIsUpdated()
        {
            // Arrange
            var file = File.ReadAllText($"SetupsTests\\Safe.json");
            var carSetup = new CarSetup();
            carSetup.LoadCarConfigValues(file);

            // Act

            carSetup.UpdateCarSetupComponent("basicSetup.tyres.tyreCompound", "1");
            carSetup.UpdateCarConfigValues();

            // Assert
            var rawJsonObject = carSetup.RawJsonSetup;
            rawJsonObject["basicSetup"]["tyres"]["tyreCompound"].ToString().Should().Be("1");
        }
    }
}
