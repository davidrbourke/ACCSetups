using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetup
{ 
    public class AeroBalance
    {
        public List<int> RideHeight { get; set; } 
        public List<double> RodLength { get; set; } 
        public int Splitter { get; set; } 
        public int RearWing { get; set; } 
        public List<int> BrakeDuct { get; set; } 
    }
}