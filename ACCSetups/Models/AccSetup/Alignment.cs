using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetup
{ 
    public class Alignment
    {
        public List<int> Camber { get; set; } 
        public List<int> Toe { get; set; } 
        public List<double> StaticCamber { get; set; } 
        public List<double> ToeOutLinear { get; set; } 
        public int CasterLF { get; set; } 
        public int CasterRF { get; set; } 
        public int SteerRatio { get; set; } 
    }
}