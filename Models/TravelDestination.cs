using System.Collections.Generic;

namespace Bit_RPG.Models
{
    public class TravelDestination
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public LocationType Type { get; set; }
        public int APCost { get; set; }
        public string Country { get; set; }
    }
}
