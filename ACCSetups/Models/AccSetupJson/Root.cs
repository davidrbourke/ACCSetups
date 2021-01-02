using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class Root
    {
        [JsonPropertyName("carName")]
        public string CarName { get; set; } 

        [JsonPropertyName("basicSetup")]
        public BasicSetup BasicSetup { get; set; } 

        [JsonPropertyName("advancedSetup")]
        public AdvancedSetup AdvancedSetup { get; set; } 

        [JsonPropertyName("trackBopType")]
        public int TrackBopType { get; set; } 
    }
}