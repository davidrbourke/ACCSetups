using ACCSetups.Models.Enums;

namespace ACCSetups.Models
{
    public class UpdatableSetupProperty
    {
        public string Name { get; set; }
        public double Value { get; set; }
        public string TextValue { get; set; }

        public LocationOnVehicle? LocationOnVehicle { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Value: {Value}, TextValue: {TextValue}, LocationOnVehicle: {LocationOnVehicle:G}";
        }
    }
}
