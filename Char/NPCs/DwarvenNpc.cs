using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char.NPCs
{
    internal class DwarvenNpc
    {
        private static readonly Random random = new Random();

        public List<string> MaleNames = new List<string>()
        {
            "Thorin",
            "Balin",
            "Dwalin",
            "Gimli",
            "Borin",
            "Thrain",
            "Durin",
            "Thror",
            "Groin",
            "Oin"
        };

        public List<string> FemaleNames = new List<string>()
        {
            "Katrin",
            "Myrna",
            "Helga",
            "Brunhild",
            "Gretta",
            "Hilda",
            "Thora",
            "Astrid",
            "Freya",
            "Bergit"
        };

        public List<string> Surnames = new List<string>()
        {
            "Ironforge",
            "Stonebreaker",
            "Hammerfall",
            "Goldbeard",
            "Steelheart",
            "Rockfist",
            "Bronzehammer",
            "Deepdelver",
            "Mountainshield",
            "Oreseeker"
        };

        public List<string> Clans = new List<string>()
        {
            "Clan Ironpeak",
            "Clan Stonefist",
            "Clan Fireforge",
            "Clan Deephelm",
            "Clan Goldhammer",
            "Clan Grimstone",
            "Clan Steelbeard",
            "Clan Thunderaxe",
            "Clan Earthshaker",
            "Clan Silvervein"
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

        public string GetRandomClanName()
        {
            bool isMale = random.Next(2) == 0;
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];
            string clan = Clans[random.Next(Clans.Count)];

            return $"{firstName} {surname} of {clan}";
        }

        public string GetRandomRulerName()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "Thane" : "Thaness";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];

            return $"{title} {firstName} {surname}";
        }

        public string GetRandomHeadman()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "Elder" : "Elderess";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];

            return $"{title} {firstName} {surname}";
        }

        public string GetRandomHighKing()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "High King" : "High Queen";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];
            string clan = Clans[random.Next(Clans.Count)];

            return $"{title} {firstName} {surname} of {clan}";
        }
    }
}
