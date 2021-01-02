using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Electronics
    {
        [JsonPropertyName("tC1")]
        public int TC1 { get; set; } 

        [JsonPropertyName("tC2")]
        public int TC2 { get; set; } 

        [JsonPropertyName("abs")]
        public int Abs { get; set; } 

        [JsonPropertyName("eCUMap")]
        public int ECUMap { get; set; } 

        [JsonPropertyName("fuelMix")]
        public int FuelMix { get; set; } 

        [JsonPropertyName("telemetryLaps")]
        public int TelemetryLaps { get; set; } 
    }
}