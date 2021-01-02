using System.Text.Json.Serialization; 
using System.Collections.Generic;

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Dampers
    {
        [JsonPropertyName("bumpSlow")]
        public List<int> BumpSlow { get; set; } 

        [JsonPropertyName("bumpFast")]
        public List<int> BumpFast { get; set; } 

        [JsonPropertyName("reboundSlow")]
        public List<int> ReboundSlow { get; set; } 

        [JsonPropertyName("reboundFast")]
        public List<int> ReboundFast { get; set; } 
    }
}