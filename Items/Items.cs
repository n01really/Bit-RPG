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
        public static void Weapons() 
        { 
            WeaponModel Blade1 = new WeaponModel 
            {
                Id = 1,
                Name = "Wooden Sword",
                Weight = 3.5f,
                BaseValue = 10,
                Damage = 5,
                AttackSpeed = 1.2f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade2 = new WeaponModel
            {
                Id = 5,
                Name = "Iron Short Sword",
                Weight = 1.5f,
                BaseValue = 25,
                Damage = 8,
                AttackSpeed = 1.8f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade3 = new WeaponModel
            {
                Id = 6,
                Name = "Iron Dagger",
                Weight = 2.0f,
                BaseValue = 40,
                Damage = 12,
                AttackSpeed = 1.6f,
                Type = WeaponModel.WeaponType.Blade
            };
            WeaponModel blade4 = new WeaponModel
            {
                Id = 7,
                Name = "Iron Longsword",
                Weight = 4.0f,
                BaseValue = 60,
                Damage = 15,
                AttackSpeed = 1.4f,
                Type = WeaponModel.WeaponType.Blade| WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Ranged1 = new WeaponModel
            {
                Id = 2,
                Name = "Short Bow",
                Weight = 2.0f,
                BaseValue = 15,
                Damage = 4,
                AttackSpeed = 1.5f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged2 = new WeaponModel
            {
                Id = 8,
                Name = "Long Bow",
                Weight = 3.0f,
                BaseValue = 30,
                Damage = 7,
                AttackSpeed = 1.3f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged3 = new WeaponModel
            {
                Id = 9,
                Name = "Hunting bow",
                Weight = 4.5f,
                BaseValue = 50,
                Damage = 10,
                AttackSpeed = 1.1f,
                Type = WeaponModel.WeaponType.RangedWeapon
            };
            WeaponModel Ranged4 = new WeaponModel
            {
                Id = 10,
                Name = "Iron Crossbow",
                Weight = 6.0f,
                BaseValue = 80,
                Damage = 14,
                AttackSpeed = 0.9f,
                Type = WeaponModel.WeaponType.RangedWeapon| WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Long1 = new WeaponModel
            {
                Id = 3,
                Name = "Wooden Staff",
                Weight = 4.0f,
                BaseValue = 20,
                Damage = 6,
                AttackSpeed = 1.0f
            };
            WeaponModel Long2 = new WeaponModel
            {
                Id = 11,
                Name = "Iron Spear",
                Weight = 5.0f,
                BaseValue = 35,
                Damage = 9,
                AttackSpeed = 0.8f,
                Type = WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Long3 = new WeaponModel
            {
                Id = 12,
                Name = "Iron glaive",
                Weight = 7.0f,
                BaseValue = 55,
                Damage = 13,
                AttackSpeed = 0.7f,
                Type = WeaponModel.WeaponType.LongWeapon
            };
            WeaponModel Long4 = new WeaponModel
            {
                Id = 15,
                Name = "Iron Halberd",
                Weight = 10.0f,
                BaseValue = 90,
                Damage = 17,
                AttackSpeed = 0.6f,
                Type = WeaponModel.WeaponType.LongWeapon| WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy1 = new WeaponModel
            {
                Id = 4,
                Name = "Stone Axe",
                Weight = 5.0f,
                BaseValue = 12,
                Damage = 7,
                AttackSpeed = 0.9f,
                Type = WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy2 = new WeaponModel
            {
                Id = 13,
                Name = "Iron Warhammer",
                Weight = 8.0f,
                BaseValue = 40,
                Damage = 11,
                AttackSpeed = 0.6f,
                Type = WeaponModel.WeaponType.HeavyWeapon
            };
            WeaponModel Heavy3 = new WeaponModel
            {
                Id = 14,
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

        }
        public static void Ingredients(IngredientModel Ingredient)
        {

        }
        public static void CraftingItems(CraftingItemModel CraftingItem)
        {

        }
        public static void Miscs(MiscItemModel Misc)
        {

        }
    }
}
