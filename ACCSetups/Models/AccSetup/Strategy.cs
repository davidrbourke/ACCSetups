using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetup
{ 
    public class Strategy
    {
        public int Fuel { get; set; } 
        public int NPitStops { get; set; } 
        public int TyreSet { get; set; } 
        public int FrontBrakePadCompound { get; set; } 
        public int RearBrakePadCompound { get; set; } 
        public List<PitStrategy> PitStrategy { get; set; } 
        public double FuelPerLap { get; set; } 
    }
}