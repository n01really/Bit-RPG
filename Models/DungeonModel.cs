using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    internal class DungeonModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int FloorCount { get; set; }
    }
}
