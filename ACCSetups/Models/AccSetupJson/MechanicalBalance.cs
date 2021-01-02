using System.Text.Json.Serialization; 
using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class MechanicalBalance
    {
        [JsonPropertyName("aRBFront")]
        public int ARBFront { get; set; } 

        [JsonPropertyName("aRBRear")]
        public int ARBRear { get; set; } 

        [JsonPropertyName("wheelRate")]
        public List<int> WheelRate { get; set; } 

        [JsonPropertyName("bumpStopRateUp")]
        public List<int> BumpStopRateUp { get; set; } 

        [JsonPropertyName("bumpStopRateDn")]
        public List<int> BumpStopRateDn { get; set; } 

        [JsonPropertyName("bumpStopWindow")]
        public List<int> BumpStopWindow { get; set; } 

        [JsonPropertyName("brakeTorque")]
        public int BrakeTorque { get; set; } 

        [JsonPropertyName("brakeBias")]
        public int BrakeBias { get; set; } 
    }
}