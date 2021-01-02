using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetupJson
{ 
    public class BasicSetup
    {
        [JsonPropertyName("tyres")]
        public Tyre Tyres { get; set; } 

        [JsonPropertyName("alignment")]
        public Alignment Alignment { get; set; } 

        [JsonPropertyName("electronics")]
        public Electronics Electronics { get; set; } 

        //[JsonPropertyName("strategy")]
        //public Strategy Strategy { get; set; } 
    }
}