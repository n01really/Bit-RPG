using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;

namespace Bit_RPG.Jobs
{
    public enum JobRank
    {
        E = 0,
        D = 1,
        C = 2,
        B = 3,
        A = 4,
        S = 5
    }

    public class Job
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public WorldNPC GuildMaster { get; set; }
        public List<WorldNPC> GuildMembers { get; set; }

        public static Job CreateAdventurersGuild(string location)
        {
            HumanNpc humanGen = new HumanNpc();
            Random random = new Random();
            
            WorldNPC guildMaster = new WorldNPC
            {
                Name = humanGen.GetRandomName(),
                Age = random.Next(40, 65),
                Gender = random.Next(2) == 0 ? "Male" : "Female",
                Race = "Human",
                Job = "Guild Master - Adventurers",
                Location = location
            };

            List<WorldNPC> members = new List<WorldNPC>();
            for (int i = 0; i < 3; i++)
            {
                members.Add(new WorldNPC
                {
                    Name = humanGen.GetRandomName(),
                    Age = random.Next(20, 50),
                    Gender = random.Next(2) == 0 ? "Male" : "Female",
                    Race = "Human",
                    Job = "Adventurer",
                    Location = location
                });
            }

            return new Job
            {
                Name = "Adventurers Guild",
                Description = "Take on quests and explore dangerous dungeons to earn rewards and fame.",
                GuildMaster = guildMaster,
                GuildMembers = members
            };
        }

        public static Job CreateBlacksmithsGuild(string location)
        {
            HumanNpc humanGen = new HumanNpc();
            Random random = new Random();
            
            WorldNPC guildMaster = new WorldNPC
            {
                Name = humanGen.GetRandomName(),
                Age = random.Next(40, 65),
                Gender = random.Next(2) == 0 ? "Male" : "Female",
                Race = "Human",
                Job = "Guild Master - Blacksmiths",
                Location = location
            };

            List<WorldNPC> members = new List<WorldNPC>();
            for (int i = 0; i < 3; i++)
            {
                members.Add(new WorldNPC
                {
                    Name = humanGen.GetRandomName(),
                    Age = random.Next(25, 55),
                    Gender = random.Next(2) == 0 ? "Male" : "Female",
                    Race = "Human",
                    Job = "Blacksmith",
                    Location = location
                });
            }

            return new Job
            {
                Name = "Blacksmiths Guild",
                Description = "Craft and repair weapons and armor for adventurers and townsfolk.",
                GuildMaster = guildMaster,
                GuildMembers = members
            };
        }

        public static Job CreateMagesGuild(string location)
        {
            HumanNpc humanGen = new HumanNpc();
            Random random = new Random();
            
            WorldNPC guildMaster = new WorldNPC
            {
                Name = humanGen.GetRandomName(),
                Age = random.Next(40, 65),
                Gender = random.Next(2) == 0 ? "Male" : "Female",
                Race = "Human",
                Job = "Guild Master - Mages",
                Location = location
            };

            List<WorldNPC> members = new List<WorldNPC>();
            for (int i = 0; i < 3; i++)
            {
                members.Add(new WorldNPC
                {
                    Name = humanGen.GetRandomName(),
                    Age = random.Next(25, 60),
                    Gender = random.Next(2) == 0 ? "Male" : "Female",
                    Race = "Human",
                    Job = "Mage",
                    Location = location
                });
            }

            return new Job
            {
                Name = "Mages Guild",
                Description = "Study and practice the arcane arts, offering magical services to those in need.",
                GuildMaster = guildMaster,
                GuildMembers = members
            };
        }

        public static Job CreateThievesGuild(string location)
        {
            HumanNpc humanGen = new HumanNpc();
            Random random = new Random();
            
            WorldNPC guildMaster = new WorldNPC
            {
                Name = humanGen.GetRandomName(),
                Age = random.Next(40, 65),
                Gender = random.Next(2) == 0 ? "Male" : "Female",
                Race = "Human",
                Job = "Guild Master - Thieves",
                Location = location
            };

            List<WorldNPC> members = new List<WorldNPC>();
            for (int i = 0; i < 3; i++)
            {
                members.Add(new WorldNPC
                {
                    Name = humanGen.GetRandomName(),
                    Age = random.Next(18, 45),
                    Gender = random.Next(2) == 0 ? "Male" : "Female",
                    Race = "Human",
                    Job = "Thief",
                    Location = location
                });
            }

            return new Job
            {
                Name = "Thieves Guild",
                Description = "Engage in stealthy activities, from pickpocketing to high-stakes heists.",
                GuildMaster = guildMaster,
                GuildMembers = members
            };
        }

        // Keep old methods for backward compatibility, but they don't do much now
        public static void AdventurersGuild()
        {
            string name = "Adventurers Guild";
            string description = "Take on quests and explore dangerous dungeons to earn rewards and fame.";
        }

        public static void BlacksmithsGuild(Skills skills, Player player)
        {
            string name = "Blacksmiths Guild";
            string description = "Craft and repair weapons and armor for adventurers and townsfolk.";
        }

        public static void MagesGuild(Skills skills, Player player)
        {
            string name = "Mages Guild";
            string description = "Study and practice the arcane arts, offering magical services to those in need.";
        }

        public static void ThievesGuild(Skills skills, Player player)
        {
            string name = "Thieves Guild";
            string description = "Engage in stealthy activities, from pickpocketing to high-stakes heists.";
        }
    }
}
