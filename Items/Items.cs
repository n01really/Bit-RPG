using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Models;

namespace Bit_RPG.Items
{
    internal class Items
    {
        //The first number in the id represents the Row of the Category in the Array the second number represents the position in the Row.
        public static void Weapons() 
        { 
            WeaponModel Blade1 = new WeaponModel 
            {
                Id = 11,
                Name = "Wooden Sword",
                Weight = 3.5f,
                BaseValue = 10,
                Damage = 5,
                AttackSpeed = 1.2f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade2 = new WeaponModel
            {
                Id = 12,
                Name = "Iron Short Sword",
                Weight = 1.5f,
                BaseValue = 25,
                Damage = 8,
                AttackSpeed = 1.8f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade3 = new WeaponModel
            {
                Id = 13,
                Name = "Iron Dagger",
                Weight = 2.0f,
                BaseValue = 40,
                Damage = 12,
                AttackSpeed = 1.6f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade4 = new WeaponModel
            {
                Id = 14,
                Name = "Iron Longsword",
                Weight = 4.0f,
                BaseValue = 60,
                Damage = 15,
                AttackSpeed = 1.4f,
                Type = WeaponModel.WeaponType.Blade| WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Ranged1 = new WeaponModel
            {
                Id = 15,
                Name = "Short Bow",
                Weight = 2.0f,
                BaseValue = 15,
                Damage = 4,
                AttackSpeed = 1.5f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged2 = new WeaponModel
            {
                Id = 16,
                Name = "Long Bow",
                Weight = 3.0f,
                BaseValue = 30,
                Damage = 7,
                AttackSpeed = 1.3f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged3 = new WeaponModel
            {
                Id = 17,
                Name = "Hunting bow",
                Weight = 4.5f,
                BaseValue = 50,
                Damage = 10,
                AttackSpeed = 1.1f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged4 = new WeaponModel
            {
                Id = 18,
                Name = "Iron Crossbow",
                Weight = 6.0f,
                BaseValue = 80,
                Damage = 14,
                AttackSpeed = 0.9f,
                Type = WeaponModel.WeaponType.RangedWeapon| WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Long1 = new WeaponModel
            {
                Id = 19,
                Name = "Wooden Staff",
                Weight = 4.0f,
                BaseValue = 20,
                Damage = 6,
                AttackSpeed = 1.0f
            };
            WeaponModel Long2 = new WeaponModel
            {
                Id = 110,
                Name = "Iron Spear",
                Weight = 5.0f,
                BaseValue = 35,
                Damage = 9,
                AttackSpeed = 0.8f,
                Type = WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Long3 = new WeaponModel
            {
                Id = 111,
                Name = "Iron glaive",
                Weight = 7.0f,
                BaseValue = 55,
                Damage = 13,
                AttackSpeed = 0.7f,
                Type = WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Long4 = new WeaponModel
            {
                Id = 112,
                Name = "Iron Halberd",
                Weight = 10.0f,
                BaseValue = 90,
                Damage = 17,
                AttackSpeed = 0.6f,
                Type = WeaponModel.WeaponType.LongWeapon| WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy1 = new WeaponModel
            {
                Id = 113,
                Name = "Stone Axe",
                Weight = 5.0f,
                BaseValue = 12,
                Damage = 7,
                AttackSpeed = 0.9f,
                Type = WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy2 = new WeaponModel
            {
                Id = 114,
                Name = "Iron Warhammer",
                Weight = 8.0f,
                BaseValue = 40,
                Damage = 11,
                AttackSpeed = 0.6f,
                Type = WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy3 = new WeaponModel
            {
                Id = 115,
                Name = "Iron Battleaxe",
                Weight = 9.0f,
                BaseValue = 70,
                Damage = 16,
                AttackSpeed = 0.5f,
                Type = WeaponModel.WeaponType.HeavyWeapon
            };
        }
        public static void Armors(ArmorModel Armor)
        {
            ArmorModel Light1 = new ArmorModel
            {
                Id = 21,
                Name = "Leather Armor",
                Weight = 5.0f,
                BaseValue = 25,
                Defense = 3,
                Type = ArmorModel.ArmorType.Light
            };
            ArmorModel Light2 = new ArmorModel
            {
                Id = 22,
                Name = "Elven Armor",
                Weight = 7.0f,
                BaseValue = 50,
                Defense = 5,
                Type = ArmorModel.ArmorType.Light
            };
            ArmorModel Medium1 = new ArmorModel
            {
                Id = 23,
                Name = "Chainmail Armor",
                Weight = 15.0f,
                BaseValue = 75,
                Defense = 8,
                Type = ArmorModel.ArmorType.Medium
            };
            ArmorModel Medium2 = new ArmorModel
            {
                Id = 24,
                Name = "Dwarven Armor",
                Weight = 20.0f,
                BaseValue = 100,
                Defense = 10,
                Type = ArmorModel.ArmorType.Medium
            };
            ArmorModel Heavy1 = new ArmorModel
            {
                Id = 25,
                Name = "Iron Armor",
                Weight = 30.0f,
                BaseValue = 150,
                Defense = 15,
                Type = ArmorModel.ArmorType.Heavy
            };
            ArmorModel Heavy2 = new ArmorModel
            {
                Id = 26,
                Name = "Steel Plate Armor",
                Weight = 35.0f,
                BaseValue = 200,
                Defense = 20,
                Type = ArmorModel.ArmorType.Heavy
            };
        }
        public static void Ingredients(IngredientModel Ingredient)
        {
            IngredientModel Herb1 = new IngredientModel
            {
                Id = 31,
                Name = "Herth Herb",
                Weight = 0.1f,
                BaseValue = 5,
                Effect = "Restores 10 HP",
                Duration = 0
            };
            IngredientModel Herb2 = new IngredientModel
            {
                Id = 32,
                Name = "Mort Wood",
                Weight = 0.1f,
                BaseValue = 5,
                Effect = "Restores 10 MP",
                Duration = 0
            };
        }
        public static void CraftingItems(CraftingItemModel CraftingItem)
        {

        }
        public static void Miscs(MiscItemModel Misc)
        {

        }
    }
}
