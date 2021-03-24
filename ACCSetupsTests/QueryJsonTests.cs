using ACCSetupsTests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

namespace ACCSetupsTests
{
    public class QueryJsonTests
    {
        [Fact]
        public void QueryJson_Experiment()
        {
            var setup = PreparedSetups.GetSafeSetupJsonDocument();


            var setupDictionary = new Dictionary<string, string>();


            var propertyList = new List<string>
            {
                "carName",
                "basicSetup.tyres.tyreCompound",
                "basicSetup.tyres.tyrePressure",
                "basicSetup.alignment.camber",
                "basicSetup.alignment.toe",
                "basicSetup.alignment.staticCamber",
                "basicSetup.alignment.toeOutLinear",
                "basicSetup.alignment.casterLF",
                "basicSetup.alignment.casterRF",
                "basicSetup.alignment.steerRatio",
                "basicSetup.electronics.tC1",
                "basicSetup.electronics.tC2",
                "basicSetup.electronics.abs",
                "basicSetup.electronics.eCUMap",
                "basicSetup.electronics.fuelMix",
                "basicSetup.electronics.telemetryLaps",
            };

            
            foreach (var property in propertyList)
            {
                if (property.Contains("."))
                {
                    var levels = property.Split('.');
                    JsonElement element = setup.RootElement;
                    var i = 0;
                    foreach (var propertyLevel in levels)
                    {
                        element = element.GetProperty(propertyLevel);
                        i++;
                        if (i == levels.Length)
                        {
                            setupDictionary.Add(property, element.ToString());
                        }
                    }
                }
            
                

            }
            

        }

    }
}
