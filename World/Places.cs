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
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HunanCountry2 = new CountryModel
            {
                Name = "Valoria",
                Description = "A land of brave warriors and skilled artisans",
                Capital = "Ironpeak",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HumanCountry3 = new CountryModel
            {
                Name = "Nordheim",
                Description = "A rugged land of fierce warriors and harsh winters",
                Capital = "Frosthold",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HumanCountry4 = new CountryModel
            {
                Name = "Aranthia",
                Description = "A kingdom of scholars and mages, known for its grand libraries",
                Capital = "Starhaven",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
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
