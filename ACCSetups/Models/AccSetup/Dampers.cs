using System.Collections.Generic;

namespace ACCSetups.Models.AccSetup
{ 
    public class Dampers
    {
        public List<int> BumpSlow { get; set; } 
        public List<int> BumpFast { get; set; } 
        public List<int> ReboundSlow { get; set; } 
        public List<int> ReboundFast { get; set; } 
    }
}