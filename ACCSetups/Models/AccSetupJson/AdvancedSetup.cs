using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class AdvancedSetup
    {
        [JsonPropertyName("mechanicalBalance")]
        public MechanicalBalance MechanicalBalance { get; set; } 

        [JsonPropertyName("dampers")]
        public Dampers Dampers { get; set; } 

        [JsonPropertyName("aeroBalance")]
        public AeroBalance AeroBalance { get; set; } 

        [JsonPropertyName("drivetrain")]
        public Drivetrain Drivetrain { get; set; } 
    }
}