using System.Text.Json.Serialization; 
using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class AeroBalance
    {
        [JsonPropertyName("rideHeight")]
        public List<int> RideHeight { get; set; } 

        [JsonPropertyName("rodLength")]
        public List<double> RodLength { get; set; } 

        [JsonPropertyName("splitter")]
        public int Splitter { get; set; } 

        [JsonPropertyName("rearWing")]
        public int RearWing { get; set; } 

        [JsonPropertyName("brakeDuct")]
        public List<int> BrakeDuct { get; set; } 
    }
}