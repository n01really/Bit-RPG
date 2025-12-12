using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char.NPCs
{
    internal class HumanNpc
    {
        private static readonly Random random = new Random();
        public List<string> MaleNames = new List<string>()
        {
            "Aldric",
            "Cedric",
            "Thorne",
            "Gareth",
            "Varian",
            "Davian",
            "Loric",
            "Brennan",
            "Thaddeus",
            "Garry"
        };
        public List<string> FemaleNames = new List<string>()
        {
            "Elara",
            "Miriel",
            "Seraphina",
            "Rowena",
            "Celeste",
            "Rosalind",
            "Evadne",
            "Meredith",
            "Arabella",
            "Vivienne"
        };
        public List<string> Surnames = new List<string>()
        {
            "Blackwood",
            "Stormrider",
            "Silverhand",
            "Ironforge",
            "Ashford",
            "Ravencrest",
            "Thornhill",
            "Wolfheart",
            "Brightblade",
            "Crumplebottom"
        };
        public List<string> NobleHouses = new List<string>()
        {
            "House Valerian",
            "House Drakemore",
            "House Lionheart",
            "House Goldcrest",
            "House Wintermere",
            "House Starwind",
            "House Crimsonfall",
            "House Silvermoon",
            "House Ironvale",
            "House Evergreen"
        };


        public string GetRandomName()
        {
            bool isMale = random.Next(2) == 0;
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];

            return $"{firstName} {surname}";
        }

        public string GetRandomNobleName()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "Lord" : "Lady";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];
            string house = NobleHouses[random.Next(NobleHouses.Count)];

            return $"{title} {firstName} {surname} of {house}";
        }
        public string GetRandomNobleRulerName()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "King" : "Queen";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];
            string house = NobleHouses[random.Next(NobleHouses.Count)];

            return $"{title} {firstName} {surname} of {house}";
        }
    }
}
