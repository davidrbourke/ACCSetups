using System.Text.Json.Serialization; 
using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetupJson
{
    public class Tyre
    {
        [JsonPropertyName("tyreSet")]
        public int TyreSet { get; set; }

        [JsonPropertyName("tyreCompound")]
        public int TyreCompound { get; set; }

        [JsonPropertyName("tyrePressure")]
        public List<int> TyrePressure { get; set; }
    }
}