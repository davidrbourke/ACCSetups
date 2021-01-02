using ACCSetups.Configurations;
using ACCSetups.Models.AccSetup;
using ACCSetups.Models.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ACCSetups
{
    public class Setup : ISetup
    {
        private IList<BaseSetup> _rootSetups;
        private IList<BaseSetup> _updatedSetups;

        public Setup()
        {
            _rootSetups = new List<BaseSetup>();
            _updatedSetups = new List<BaseSetup>();
        }

        public void AddSourceSetup(BaseSetup sourceBaseSetup)
        {
            _rootSetups.Add(sourceBaseSetup);
        }

        public void ApplySetup(ConfigurationType configurationType)
        {
            var setupType = ConfigurationTypesFactory.GetConfigurationType(_rootSetups.ToArray(), configurationType);
            _updatedSetups.Add(setupType.GetUpdatedSetup());
        }

        public IReadOnlyList<BaseSetup> GetSourceSetups()
        {
            return _rootSetups.ToList().AsReadOnly();
        }

        public BaseSetup GetUpdatedSetup()
        {
            return _updatedSetups[_updatedSetups.Count - 1];
        }
    }
}
