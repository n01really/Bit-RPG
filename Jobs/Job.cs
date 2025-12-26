using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;

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
        public JobRank Rank { get; set; }
        public int QuestsCompleted { get; set; }

        public Job()
        {
            Rank = JobRank.E;
            QuestsCompleted = 0;
        }

        public int GetQuestsRequiredForNextRank()
        {
            return Rank switch
            {
                JobRank.E => 10,
                JobRank.D => 30,   // 10 + 20 = 30 total
                JobRank.C => 70,   // 30 + 40 = 70 total
                JobRank.B => 150,  // 70 + 80 = 150 total
                JobRank.A => 310,  // 150 + 160 = 310 total
                JobRank.S => 0,
                _ => 0
            };
        }

        public bool CanRankUp(Skills skills = null)
        {
            if (Rank == JobRank.S)
                return false;

            if (QuestsCompleted < GetQuestsRequiredForNextRank())
                return false;

            // Check skill requirements for B to A rank up
            if (Rank == JobRank.B)
            {
                if (skills == null)
                    return false;

                if (!HasRequiredSkillForA(skills))
                    return false;
            }

            // Check skill requirements for A to S rank up
            if (Rank == JobRank.A)
            {
                if (skills == null)
                    return false;

                if (!HasRequiredSkillsForS(skills))
                    return false;
            }

            return true;
        }

        private bool HasRequiredSkillForA(Skills skills)
        {
            var relevantSkills = GetRelevantSkills(skills);
            return relevantSkills.Any(skillValue => skillValue >= 50);
        }

        private bool HasRequiredSkillsForS(Skills skills)
        {
            var relevantSkills = GetRelevantSkills(skills);
            return relevantSkills.Count(skillValue => skillValue >= 65) >= 5;
        }

        private List<int> GetRelevantSkills(Skills skills)
        {
            return Name switch
            {
                "Adventurers Guild" => new List<int>
                {
                    skills.Swordsmanship,
                    skills.LongWeapons,
                    skills.HeavyWeapons,
                    skills.Marksmanship,
                    skills.HeavyArmor,
                    skills.MediumArmor,
                    skills.LightArmor,
                    skills.FirstAid,
                    skills.Lockpicking,
                    skills.Alchemy
                },
                "Blacksmiths Guild" => new List<int>
                {
                    skills.Smithing,
                    skills.HeavyWeapons,
                    skills.LongWeapons,
                    skills.Swordsmanship,
                    skills.HeavyArmor,
                    skills.MediumArmor,
                    skills.Enchanting
                },
                "Mages Guild" => new List<int>
                {
                    skills.Conjuration,
                    skills.Destruction,
                    skills.Illusion,
                    skills.Restoration,
                    skills.Enchanting,
                    skills.Alchemy
                },
                "Thieves Guild" => new List<int>
                {
                    skills.Stealth,
                    skills.SlightofHand,
                    skills.Lockpicking,
                    skills.Marksmanship,
                    skills.LightArmor,
                    skills.Alchemy,
                    skills.Illusion
                },
                _ => new List<int>()
            };
        }

        public bool TryRankUp(Skills skills = null)
        {
            if (!CanRankUp(skills))
                return false;

            Rank = (JobRank)((int)Rank + 1);
            return true;
        }

        public string GetRankProgressText()
        {
            if (Rank == JobRank.S)
                return "Max Rank";

            int required = GetQuestsRequiredForNextRank();
            return $"{QuestsCompleted}/{required} quests";
        }

        public string GetRankUpRequirementsText(Skills skills = null)
        {
            if (Rank == JobRank.S)
                return "You have reached the maximum rank!";

            int required = GetQuestsRequiredForNextRank();
            int remaining = required - QuestsCompleted;
            
            string requirements = $"Quests needed: {remaining}";

            if (Rank == JobRank.B)
            {
                requirements += "\nSkill requirement: 1 relevant skill at level 50+";
                if (skills != null && HasRequiredSkillForA(skills))
                {
                    requirements += " ✓";
                }
            }
            else if (Rank == JobRank.A)
            {
                requirements += "\nSkill requirement: 5 relevant skills at level 65+";
                if (skills != null)
                {
                    int skillsMet = GetRelevantSkills(skills).Count(s => s >= 65);
                    requirements += $" ({skillsMet}/5)";
                }
            }

            return requirements;
        }

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
