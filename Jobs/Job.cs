using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;

namespace Bit_RPG.Jobs
{
    public class Job
    {
        public static void AdventurersGuild()
        {
            string name = "Adventurers Guild";
            string description = "Take on quests and explore dangerous dungeons to earn rewards and fame.";
        }
        public static void BlacksmithsGuild(Skills skills)
        {
            string name = "Blacksmiths Guild";
            string description = "Craft and repair weapons and armor for adventurers and townsfolk.";
            skills.Smithing++;
        }
        public static void MagesGuild(Skills skills)
        {
            string name = "Mages Guild";
            string description = "Study and practice the arcane arts, offering magical services to those in need.";
            skills.Enchanting++;
        }
        public static void ThievesGuild(Skills skills)
        {
            string name = "Thieves Guild";
            string description = "Engage in stealthy activities, from pickpocketing to high-stakes heists.";
            skills.Lockpicking++;
        }
    }
}
