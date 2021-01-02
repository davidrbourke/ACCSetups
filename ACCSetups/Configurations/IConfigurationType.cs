using ACCSetups.Models;
using ACCSetups.Models.AccSetup;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACCSetups.Configurations
{
    public interface IConfigurationType
    {
        BaseSetup GetUpdatedSetup();
    }
}
