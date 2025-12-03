using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char
{
    internal class PlayableRaces
    {
        public static void Human()
        {
            int Health = 100;
            int Magic = 5;
            int Strength = 5;
            int Agility = 5;
            int Intelligence = 5;
            int Attack = 10;
            int Defense = 10;
            int MDefense = 5;
        }
        public static void Elf()
        {
            int Health = 100;
            int Magic = 10;
            int Strength = 4;
            int Agility = 6;
            int Intelligence = 6;
            int Attack = 3;
            int Defense = 2;
            int MDefense = 4;
        }
        public static void Dwarf()
        {
            int Health = 120;
            int Magic = 0;
            int Strength = 6;
            int Agility = 4;
            int Intelligence = 4;
            int Attack = 10;
            int Defense = 8;
            int MDefense = 10;
        }
    }
}
