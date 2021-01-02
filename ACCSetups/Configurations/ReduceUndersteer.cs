using ACCSetups.Models.AccSetup;
using System;
using System.Linq;
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




            return _baseSetup;
        }
    }
}
