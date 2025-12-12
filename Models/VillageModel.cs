using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    internal class VillageModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Headman { get; set; }
        public List<string> NearbyTowns { get; set; }
        public List<string> NearbyCities { get; set; }
        public List<string> NearbyDungeons { get; set; }
    }
}
