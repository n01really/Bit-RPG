using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    public class CountryModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ruler { get; set; }
        public string? Consort { get; set; }
        public string Capital { get; set; }
        public string MajorityRace { get; set; }

    }
}
