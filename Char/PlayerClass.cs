using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;

namespace Bit_RPG.Char
{
    public class PlayerClass
    {
        // keep skills under 50 att level 1 max skill level should not exceed 100
        // 3 skills per class should be at 25
        public static void Warrior(Player player)
        {
            player.Skills = new Skills
            {
                Stealth = 1,
                Marksmanship = 12,
                SlightofHand = 1,
                Lockpicking = 1,
                Conjuration = 1,
                Destruction = 1,
                Illusion = 1,
                Restoration = 2,
                FirstAid = 15,
                Swordsmanship = 25,
                LongWeapons = 15,
                HeavyWeapons = 20,
                HeavyArmor = 25,
                MediumArmor = 15,
                LightArmor = 10,
                Smithing = 25,
                Alchemy = 1,
                Enchanting = 1
            };
            
            // Set base stats for Warrior
            player.Strength = 8;
            player.Agility = 5;
            player.Intelligence = 3;
            player.Attack = 12;
            player.Defense = 10;
            player.MaxHealth = 120;
            player.MaxMana = 20;
            player.MDefense = 5;
        }
        
        public static void Mage(Player player)
        {
            player.Skills = new Skills
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
            
            // Set base stats for Mage
            player.Strength = 3;
            player.Agility = 5;
            player.Intelligence = 10;
            player.Attack = 5;
            player.Defense = 5;
            player.MaxHealth = 80;
            player.MaxMana = 150;
            player.MDefense = 12;
        }
        
        public static void Rogue(Player player)
        {
            player.Skills = new Skills
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
            
            // Set base stats for Rogue
            player.Strength = 5;
            player.Agility = 9;
            player.Intelligence = 6;
            player.Attack = 8;
            player.Defense = 6;
            player.MaxHealth = 100;
            player.MaxMana = 50;
            player.MDefense = 7;
        }
    }
}
