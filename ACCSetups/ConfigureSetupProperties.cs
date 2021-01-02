using ACCSetups.Models;
using System.Collections.Generic;

namespace ACCSetups
{
    public class ConfigureSetupProperties
    {
        public IList<SetupProperty> SetupProperties { get; private set; }
        public ConfigureSetupProperties()
        {
            CreateSetupProperties();
        }

        private void CreateSetupProperties()
        {
            SetupProperties = new List<SetupProperty>();

            SetupProperties.Add(new SetupProperty("rearWing", Models.Enums.LocationOnVehicle.REAR, Models.Enums.SetupPropertyCategory.AEROBALANCE, 0, 14, false));
            SetupProperties.Add(new SetupProperty("aRBFront", Models.Enums.LocationOnVehicle.FRONT, Models.Enums.SetupPropertyCategory.MECHANICAL_BALANCE, 0, 49, false));
            SetupProperties.Add(new SetupProperty("aRBRear", Models.Enums.LocationOnVehicle.REAR, Models.Enums.SetupPropertyCategory.MECHANICAL_BALANCE, 0, 49, true));
        }
    }
}
