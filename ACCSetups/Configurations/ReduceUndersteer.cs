using ACCSetups.Models.AccSetup;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ACCSetups.Configurations
{
    public class ReduceUndersteer : IConfigurationType
    {
        private BaseSetup _baseSetup;

        public ReduceUndersteer(BaseSetup baseSetup)
        {
            if (baseSetup == null)
            {
                throw new ArgumentNullException(nameof(baseSetup));
            }

            _baseSetup = baseSetup;
        }

        public BaseSetup GetUpdatedSetup()
        {
            var configurationProperties = new ConfigureSetupProperties();
            var setupProperties = configurationProperties.SetupProperties;

            var t = _baseSetup.GetType();
            var props = t.GetProperties();

            Dive(props, _baseSetup);

            return _baseSetup;
        }

        private void Dive(PropertyInfo[] props, object obj)
        {
            foreach (var prop in props)
            {

                var instance = prop.GetValue(obj, null);
                
                if (instance == null)
                {
                    continue;
                }

                if (instance is string || instance is int)
                {
                    Console.WriteLine($"{prop.Name}: {instance}");
                    continue;
                }

                if (instance is List<int>)
                {
                    var output = String.Join(",", (List<int>)instance);
                    Console.WriteLine($"{prop.Name}: {output}");
                    continue;
                }

                if (instance is List<double>)
                {
                    var output = String.Join(",", (List<double>)instance);
                    Console.WriteLine($"{prop.Name}: {output}");
                    continue;
                }

                var instanceProps = instance.GetType().GetProperties();

                if (instanceProps.Length >0)
                {
                    Dive(instanceProps, instance);
                }

            }
        }
    }
}
