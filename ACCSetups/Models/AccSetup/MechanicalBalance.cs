using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetup
{ 
    public class MechanicalBalance
    {
        public int ARBFront { get; set; } 
        public int ARBRear { get; set; } 
        public List<int> WheelRate { get; set; } 
        public List<int> BumpStopRateUp { get; set; } 
        public List<int> BumpStopRateDn { get; set; } 
        public List<int> BumpStopWindow { get; set; } 
        public int BrakeTorque { get; set; } 
        public int BrakeBias { get; set; } 
    }
}