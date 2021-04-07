using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

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

        public JObject RawJsonSetup
        {
            get; private set;
        }

        public CarSetup()
        {
            _carConfigComponents = new CarConfigComponents().GetCarConfigComponents();
        }

        public void LoadCarConfigValues(string setupFileAsString)
        {
            RawJsonSetup = JObject.Parse(setupFileAsString);

            foreach (var property in _carConfigComponents)
            {
                if (property.JsonPath.Contains("."))
                {
                    var levels = property.JsonPath.Split('.');
                    JObject element = RawJsonSetup;
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
                else if(!string.IsNullOrWhiteSpace(property.JsonPath))
                {
                    JObject element = RawJsonSetup;
                    if (element is JToken)
                    {
                        property.ConfigValues = element[property.JsonPath].ToString();
                    }
                }
            }
        }

        public void UpdateCarConfigValues()
        {
            foreach (var property in _carConfigComponents)
            {
                if (property.JsonPath.Contains("."))
                {
                    var levels = property.JsonPath.Split('.');
                    JObject element = RawJsonSetup;
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
                                if (!string.IsNullOrWhiteSpace(property.UpdatedConfigValue))
                                {
                                    element[levelName] = property.UpdatedConfigValue;
                                }
                            }
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(property.JsonPath))
                {
                    JObject element = RawJsonSetup;
                    if (element is JToken)
                    {
                        if (!string.IsNullOrWhiteSpace(property.UpdatedConfigValue))
                        {
                            element[property.JsonPath] = property.UpdatedConfigValue;
                        }
                    }
                }
            }
        }

        public void UpdateCarSetupComponent(string path, string value)
        {
            _carConfigComponents = _carConfigComponents.Select(component =>
            {
                var updatedComponent = component;
                if(component.JsonPath == path)
                {
                    updatedComponent.UpdatedConfigValue = value;
                }
                return updatedComponent;
            }).ToList();
        }
    }
}
