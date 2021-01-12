using ACCSetups.Models;
using ACCSetups.Models.AccSetup;
using ACCSetups.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ACCSetups.Configurations
{
    public class ReduceUndersteer : IConfigurationType
    {
        private BaseSetup _baseSetup;
        private IList<UpdatableSetupProperty> _updatableSetupProperties;

        public ReduceUndersteer(BaseSetup baseSetup)
        {
            if (baseSetup == null)
            {
                throw new ArgumentNullException(nameof(baseSetup));
            }

            _baseSetup = baseSetup;
            _updatableSetupProperties = new List<UpdatableSetupProperty>();
        }

        public BaseSetup GetUpdatedSetup()
        {
            var configurationProperties = new ConfigureSetupProperties();
            var setupProperties = configurationProperties.SetupProperties;

            var t = _baseSetup.GetType();
            var props = t.GetProperties();

            Dive(props, _baseSetup);

            foreach(var setting in _updatableSetupProperties)
            {
                Console.WriteLine(setting.ToString());
            }

            return _baseSetup;
        }

        private void Dive(PropertyInfo[] props, object obj)
        {
            foreach (var prop in props)
             {

                var instance = prop.GetValue(obj, null);

                 var realObj = Convert.ChangeType(instance, prop.PropertyType);

                if (instance == null)
                {
                    continue;
                }

                if (instance is string)
                {
                    _updatableSetupProperties.Add(new UpdatableSetupProperty { Name = prop.Name, TextValue = instance.ToString() });
                    continue;
                }

                if (instance is int)
                {
                    _updatableSetupProperties.Add(new UpdatableSetupProperty { Name = prop.Name, Value = Convert.ToDouble(instance) });
                    continue;
                }

                if (instance is List<int> intList)
                {
                    AddArrayToProperties(prop, intList.Select(i => Convert.ToDouble(i)).ToList());
                    continue;
                }

                if (instance is List<double> doubleList)
                {
                    AddArrayToProperties(prop, doubleList);
                    continue;
                }

                var instanceProps = instance.GetType().GetProperties();

                if (instanceProps.Length >0)
                {
                    Dive(instanceProps, instance);
                }

            }
        }

        private void AddArrayToProperties(PropertyInfo prop, List<double> list)
        {
            var fourPos = new LocationOnVehicle[]
            {
                LocationOnVehicle.LEFT_FRONT,
                LocationOnVehicle.RIGHT_FRONT,
                LocationOnVehicle.LEFT_REAR,
                LocationOnVehicle.RIGHT_REAR
            };
            var twoPos = new LocationOnVehicle[]
            {
                LocationOnVehicle.FRONT,
                LocationOnVehicle.REAR
            };

            if (list.Count == 4)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    _updatableSetupProperties.Add(new UpdatableSetupProperty
                    {
                        Name = $"{prop.Name}", Value = Convert.ToDouble(list[i]), LocationOnVehicle = fourPos[i]
                    });
                }
            }
            if (list.Count == 2)
            {
                for (var i = 0; i < list.Count; i++)
                {
                    _updatableSetupProperties.Add(new UpdatableSetupProperty
                    {
                        Name = $"{prop.Name}", Value = Convert.ToDouble(list[i]), LocationOnVehicle = twoPos[i]
                    });
                }
            }
        }
    }
}
