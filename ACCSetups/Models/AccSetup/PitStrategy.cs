using System.Collections.Generic;

namespace ACCSetups.Models.AccSetup
{ 
    public class PitStrategy    
    {
        public int FuelToAdd { get; set; }
        public List<Tyre> Tyres { get; set; }
        public int FrontBrakePadCompound { get; set; } 
        public int RearBrakePadCompound { get; set; } 
    }
}