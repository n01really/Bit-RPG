using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char
{
    public class PlayableRaces
    {
        public static void Human(Player player)
        {
            player.MaxHealth += 100;
            player.MaxMana += 5;
            player.Strength += 5;
            player.Agility += 5;
            player.Intelligence += 5;
            player.Attack += 10;
            player.Defense += 10;
            player.MDefense += 5;
        }
        
        public static void Elf(Player player)
        {
            player.MaxHealth += 90;
            player.MaxMana += 10;
            player.Strength += 4;
            player.Agility += 6;
            player.Intelligence += 6;
            player.Attack += 3;
            player.Defense += 2;
            player.MDefense += 4;
        }
        
        public static void Dwarf(Player player)
        {
            player.MaxHealth += 120;
            player.MaxMana += 0;
            player.Strength += 6;
            player.Agility += 4;
            player.Intelligence += 4;
            player.Attack += 10;
            player.Defense += 8;
            player.MDefense += 10;
        }
    }
}
