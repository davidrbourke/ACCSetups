using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace ACCSetups.ACC2
{
    public class CarSetup
    {
        private IList<CarConfigComponent> _carConfigComponents;
        public IList<CarConfigComponent> CarConfigComponents
        {
            get
            {
                return _carConfigComponents;
            }
        }

        public CarSetup()
        {
            SetupCarConfigComponents();
        }

        public void LoadCarConfigValues(string setupFileAsString)
        {
            JObject rawJsonSetup = JObject.Parse(setupFileAsString);

            foreach (var property in _carConfigComponents)
            {
                if (property.JsonPath.Contains("."))
                {
                    var levels = property.JsonPath.Split('.');
                    JObject element = rawJsonSetup;
                    for (var i = 0; i < levels.Length; i++)
                    {
                        var levelName = levels[i];

                        var elementBlock = element[levelName];
                        if (elementBlock is JObject)
                        {
                            element = (JObject)elementBlock;
                        }
                        else if (elementBlock is JToken)
                        {
                            if (i == levels.Length - 1)
                            {
                                property.ConfigValues = elementBlock.ToString();
                            }
                        }
                    }
                }
            }
        }

        public void SetupCarConfigComponents()
        {
            _carConfigComponents = new List<CarConfigComponent>
            {
                new CarConfigComponent
                {
                    JsonPath = "carName",
                    CarConfigDataType = CarConfigDataType.String
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.tyres.tyreCompound",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.tyres.tyrePressure",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.camber",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.toe",
                    CarConfigDataType = CarConfigDataType.IntegerArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.staticCamber",
                    CarConfigDataType = CarConfigDataType.FloatArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.toeOutLinear",
                    CarConfigDataType = CarConfigDataType.FloatArray
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.casterLF",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.casterRF",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.alignment.steerRatio",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.tC1",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.tC2",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.abs",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.eCUMap",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.fuelMix",
                    CarConfigDataType = CarConfigDataType.Integer
                },
                new CarConfigComponent
                {
                    JsonPath = "basicSetup.electronics.telemetryLaps",
                    CarConfigDataType = CarConfigDataType.Integer
                }
            };
        }
    }
}
