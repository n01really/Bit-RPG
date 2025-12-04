using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;

namespace Bit_RPG.Char
{
    internal class PlayerClass
    {
        public static void Warrior()
        {
            string name = "Warrior";
            string description = "A strong and resilient fighter, excelling in melee combat and heavy armor.";
            Skills skills = new Skills
            {
                Stealth = 1,
                Marksmanship = 2,
                SlightofHand = 1,
                Lockpicking = 1,
                Conjuration = 1,
                Destruction = 1,
                Illusion = 1,
                Restoration = 2,
                FirstAid = 5,
                Swordsmanship = 5,
                LongWeapons = 4,
                HeavyWeapons = 3,
                HeavyArmor = 5,
                MediumArmor = 2,
                LightArmor = 2,
                Smithing = 2,
                Alchemy = 1,
                Enchanting = 1
            };
        }
        public static void Mage()
        {
            string name = "Mage";
            string description = "A master of arcane arts, wielding powerful spells to devastate enemies from afar.";
            Skills skills = new Skills
            {
                Stealth = 1,
                Marksmanship = 2,
                SlightofHand = 1,
                Lockpicking = 1,
                Conjuration = 5,
                Destruction = 5,
                Illusion = 4,
                Restoration = 3,
                FirstAid = 2,
                Swordsmanship = 1,
                LongWeapons = 1,
                HeavyWeapons = 1,
                HeavyArmor = 1,
                MediumArmor = 1,
                LightArmor = 2,
                Smithing = 2,
                Alchemy = 2,
                Enchanting = 5
            };
        }
        public static void Rogue()
        {
            string name = "Rogue";
            string description = "A stealthy and agile character, skilled in sneaking, lockpicking, and critical strikes.";
            Skills skills = new Skills
            {
                Stealth = 5,
                Marksmanship = 3,
                SlightofHand = 5,
                Lockpicking = 5,
                Conjuration = 1,
                Destruction = 1,
                Illusion = 4,
                Restoration = 2,
                FirstAid = 5,
                Swordsmanship = 5,
                LongWeapons = 4,
                HeavyWeapons = 3,
                HeavyArmor = 5,
                MediumArmor = 2,
                LightArmor = 2,
                Smithing = 2,
                Alchemy = 5,
                Enchanting = 1
            };
        }
    }
}
