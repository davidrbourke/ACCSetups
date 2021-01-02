using ACCSetups.Models.AccSetup;
using ACCSetups.Models.Enums;
using System.Collections.Generic;

namespace ACCSetups
{
    public interface ISetup
    {
        void AddSourceSetup(BaseSetup sourceBaseSetup);
        void ApplySetup(ConfigurationType configurationType);
        IReadOnlyList<BaseSetup> GetSourceSetups();
        BaseSetup GetUpdatedSetup();
    }
}
