using ACCSetups.Models.Enums;

namespace ACCSetups.Models
{
    public struct SetupProperty
    {
        public SetupProperty(string name, LocationOnVehicle locationOnVehicle, SetupPropertyCategory setupPropertyCategory, int minValue, int maxValue, bool isMaxToOversteer)
        {
            Name = name;
            LocationOnVehicle = locationOnVehicle;
            SetupPropertyCategory = setupPropertyCategory;
            MinValue = minValue;
            MaxValue = maxValue;
            IsMaxToOverSteer = isMaxToOversteer;
        }

        public string Name { get; }
        public LocationOnVehicle LocationOnVehicle { get; }
        public SetupPropertyCategory SetupPropertyCategory { get; }
        public int MinValue { get; }
        public int MaxValue { get; }
        public bool IsMaxToOverSteer { get; }
    }
}
