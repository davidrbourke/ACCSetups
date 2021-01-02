using System.Collections.Generic;
using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class PitStrategy    
    {
        [JsonPropertyName("fuelToAdd")]
        public int FuelToAdd { get; set; }

        [JsonPropertyName("tyres")]
        public List<Tyre> Tyres { get; set; }

        [JsonPropertyName("frontBrakePadCompound")]
        public int FrontBrakePadCompound { get; set; } 

        [JsonPropertyName("rearBrakePadCompound")]
        public int RearBrakePadCompound { get; set; } 
    }
}