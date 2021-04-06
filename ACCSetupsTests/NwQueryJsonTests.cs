using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ACCSetupsTests
{
    public class NwQueryJsonTests
    {
        [Fact]
        public void QueryJson_Experiment()
        {
            var file = File.ReadAllText($"SetupsTests\\Safe.json");

            JObject rawJsonSetup = JObject.Parse(file);


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
                "basicSetup.electronics.telemetryLaps"
            };

            
            foreach (var property in propertyList)
            {
                if (property.Contains("."))
                {
                    var levels = property.Split('.');
                    JObject element = rawJsonSetup;
                    for(var i = 0; i < levels.Length; i++)
                    {
                        var levelName = levels[i];

                        var elementBlock = element[levelName];
                        if (elementBlock is JObject)
                        {
                            element = (JObject)elementBlock;
                        } 
                        else if (elementBlock is JToken)
                        {
                            if (i == levels.Length-1)
                                setupDictionary.Add(property, elementBlock.ToString());
                        }
                    }
                }
            }
        }
    }
}
