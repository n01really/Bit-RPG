using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char.NPCs
{
    internal class ElfNpc
    {
        private static readonly Random random = new Random();

        public List<string> MaleNames = new List<string>()
        {
            "Legolas",
            "Elrond",
            "Thranduil",
            "Celeborn",
            "Haldir",
            "Glorfindel",
            "Elladan",
            "Elrohir",
            "Lindir",
            "Aegnor"
        };

        public List<string> FemaleNames = new List<string>()
        {
            "Arwen",
            "Galadriel",
            "Luthien",
            "Idril",
            "Celebrian",
            "Tauriel",
            "Nimrodel",
            "Aredhel",
            "Finduilas",
            "Morwen"
        };

        public List<string> Surnames = new List<string>()
        {
            "Starweaver",
            "Moonwhisper",
            "Silverleaf",
            "Windrunner",
            "Dawnbringer",
            "Nightsong",
            "Sunstrider",
            "Forestwalker",
            "Stormbow",
            "Lightblade"
        };

        public List<string> Houses = new List<string>()
        {
            "House of the Golden Wood",
            "House of Rivendell",
            "House of the Silverlight",
            "House of the Moonshade",
            "House of the Starfire",
            "House of the Eternal Spring",
            "House of the Ancient Oak",
            "House of the Crystal Waters",
            "House of the Twilight Veil",
            "House of the Dawn's Promise"
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
            string house = Houses[random.Next(Houses.Count)];

            return $"{title} {firstName} {surname} of the {house}";
        }

        public string GetRandomRulerName()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "High Lord" : "High Lady";
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

        public string GetRandomKingName()
        {
            bool isMale = random.Next(2) == 0;
            string title = isMale ? "King" : "Queen";
            string firstName = isMale
                ? MaleNames[random.Next(MaleNames.Count)]
                : FemaleNames[random.Next(FemaleNames.Count)];
            string surname = Surnames[random.Next(Surnames.Count)];
            string house = Houses[random.Next(Houses.Count)];

            return $"{title} {firstName} {surname} of the {house}";
        }
    }
}
