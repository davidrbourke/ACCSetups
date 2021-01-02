using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Drivetrain
    {
        [JsonPropertyName("preload")]
        public int Preload { get; set; } 
    }
}