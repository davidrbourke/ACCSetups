using System.Collections.Generic; 

namespace ACCSetups.Models.AccSetup
{ 
    public class Tyre
    {
        public int TyreSet { get; set; }
        public int TyreCompound { get; set; }
        public List<int> TyrePressure { get; set; }
    }
}