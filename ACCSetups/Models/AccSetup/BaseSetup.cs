namespace ACCSetups.Models.AccSetup
{ 
    public class BaseSetup
    {
        public string CarName { get; set; } 
        public BasicSetup BasicSetup { get; set; } 
        public AdvancedSetup AdvancedSetup { get; set; } 
        public int TrackBopType { get; set; } 
    }
}