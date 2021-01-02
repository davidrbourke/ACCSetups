using System.Text.Json.Serialization; 
using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Strategy
    {
        [JsonPropertyName("fuel")]
        public int Fuel { get; set; } 

        [JsonPropertyName("nPitStops")]
        public int NPitStops { get; set; } 

        [JsonPropertyName("tyreSet")]
        public int TyreSet { get; set; } 

        [JsonPropertyName("frontBrakePadCompound")]
        public int FrontBrakePadCompound { get; set; } 

        [JsonPropertyName("rearBrakePadCompound")]
        public int RearBrakePadCompound { get; set; } 

        [JsonPropertyName("pitStrategy")]
        public List<PitStrategy> PitStrategy { get; set; } 

        [JsonPropertyName("fuelPerLap")]
        public double FuelPerLap { get; set; } 
    }
}