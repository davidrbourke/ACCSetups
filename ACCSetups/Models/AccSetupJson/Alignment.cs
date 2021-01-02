using System.Text.Json.Serialization; 
using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Alignment
    {
        [JsonPropertyName("camber")]
        public List<int> Camber { get; set; } 

        [JsonPropertyName("toe")]
        public List<int> Toe { get; set; } 

        [JsonPropertyName("staticCamber")]
        public List<double> StaticCamber { get; set; } 

        [JsonPropertyName("toeOutLinear")]
        public List<double> ToeOutLinear { get; set; } 

        [JsonPropertyName("casterLF")]
        public int CasterLF { get; set; } 

        [JsonPropertyName("casterRF")]
        public int CasterRF { get; set; } 

        [JsonPropertyName("steerRatio")]
        public int SteerRatio { get; set; } 
    }
}