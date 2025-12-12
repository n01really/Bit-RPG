using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Models;
using Bit_RPG.Char.NPCs;

namespace Bit_RPG.World
{
    internal class Countries
    {
        public static void HumanKingdoms()
        {
            HumanNpc humanNames = new HumanNpc();
            CountryModel HumanCountry1 = new CountryModel
            {
                Name = "Eldoria",
                Description = "A prosperous kingdom known for its rich culture",
                Capital = "Silverhold",
                Ruler = humanNames.GetRandomNobleRulerName()

            };
            CountryModel HunanCountry2 = new CountryModel
            {
               

            };
            CountryModel HumanCountry3 = new CountryModel
            {
               

            };
        }
    }
    internal class Cities
    {

    }
    internal class Towns
    { 
    }
    internal class Villages
    {
    }
}
