using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Events;
using Bit_RPG.Jobs;

namespace Bit_RPG.Char
{

    public class Player
    {
        public string PlayerName { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public string Pronouns { get; set; }
        public int Level { get; set; }
        public int Money { get; set; }
        public int Experience { get; set; }
        public int JobExperience { get; set; }
        public Job Jobb { get; set; }
        public int JobRank { get; set; }
        public PlayableRaces Race { get; set; }
        public PlayerClass Class { get; set; }
        public Skills Skills { get; set; }
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
