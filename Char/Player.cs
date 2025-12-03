using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;

namespace Bit_RPG.Char
{

    internal class Player
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int JobRank { get; set; } = 0;


        public PlayableRaces Race { get; set; }
        public PlayerClass Class { get; set; }
        public Perks Perks { get; set; } = new Perks();
        public Skills Skills { get; set; } = new Skills();
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int Magic { get; set; }
        public int MaxMana { get; set; }
        public int MDefense { get; set; }
    }
}
