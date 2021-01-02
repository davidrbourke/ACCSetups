using System.Text.Json.Serialization; 

namespace ACCSetups.Models.AccSetup
{ 
    public class BasicSetup
    {
        public Tyre Tyres { get; set; } 
        public Alignment Alignment { get; set; } 
        public Electronics Electronics { get; set; } 
        public Strategy Strategy { get; set; } 
    }
}