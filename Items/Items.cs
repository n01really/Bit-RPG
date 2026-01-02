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
        private static List<WeaponModel> weaponsList = new List<WeaponModel>();
        private static List<ArmorModel> armorsList = new List<ArmorModel>();
        private static List<IngredientModel> ingredientsList = new List<IngredientModel>();
        private static List<CraftingItemModel> craftingItemsList = new List<CraftingItemModel>();
        private static List<MiscItemModel> miscItemsList = new List<MiscItemModel>();
        private static List<PotionModel> potionsList = new List<PotionModel>();

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
            weaponsList.Add(Blade1);

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
            weaponsList.Add(blade2);

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
            weaponsList.Add(blade3);

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
            weaponsList.Add(blade4);

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
            weaponsList.Add(Ranged1);

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
            weaponsList.Add(Ranged2);

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
            weaponsList.Add(Ranged3);

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
            weaponsList.Add(Ranged4);

            WeaponModel Long1 = new WeaponModel
            {
                Id = 19,
                Name = "Wooden Staff",
                Weight = 4.0f,
                BaseValue = 20,
                Damage = 6,
                AttackSpeed = 1.0f,
                Type = WeaponModel.WeaponType.LongWeapon
            };
            weaponsList.Add(Long1);

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
            weaponsList.Add(Long2);

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
            weaponsList.Add(Long3);

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
            weaponsList.Add(Long4);

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
            weaponsList.Add(Heavy1);

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
            weaponsList.Add(Heavy2);

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
            weaponsList.Add(Heavy3);
        }

        public static void Armors()
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
            armorsList.Add(Light1);

            ArmorModel Light2 = new ArmorModel
            {
                Id = 22,
                Name = "Elven Armor",
                Weight = 7.0f,
                BaseValue = 50,
                Defense = 5,
                Type = ArmorModel.ArmorType.Light
            };
            armorsList.Add(Light2);

            ArmorModel Medium1 = new ArmorModel
            {
                Id = 23,
                Name = "Chainmail Armor",
                Weight = 15.0f,
                BaseValue = 75,
                Defense = 8,
                Type = ArmorModel.ArmorType.Medium
            };
            armorsList.Add(Medium1);

            ArmorModel Medium2 = new ArmorModel
            {
                Id = 24,
                Name = "Dwarven Armor",
                Weight = 20.0f,
                BaseValue = 100,
                Defense = 10,
                Type = ArmorModel.ArmorType.Medium
            };
            armorsList.Add(Medium2);

            ArmorModel Heavy1 = new ArmorModel
            {
                Id = 25,
                Name = "Iron Armor",
                Weight = 30.0f,
                BaseValue = 150,
                Defense = 15,
                Type = ArmorModel.ArmorType.Heavy
            };
            armorsList.Add(Heavy1);

            ArmorModel Heavy2 = new ArmorModel
            {
                Id = 26,
                Name = "Steel Plate Armor",
                Weight = 35.0f,
                BaseValue = 200,
                Defense = 20,
                Type = ArmorModel.ArmorType.Heavy
            };
            armorsList.Add(Heavy2);
        }

        public static void Ingredients()
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
            ingredientsList.Add(Herb1);

            IngredientModel Herb2 = new IngredientModel
            {
                Id = 32,
                Name = "Mort Wood",
                Weight = 0.1f,
                BaseValue = 5,
                Effect = "Restores 10 MP",
                Duration = 0
            };
            ingredientsList.Add(Herb2);

            IngredientModel Herb3 = new IngredientModel
            {
                Id = 33,
                Name = "Red Mushroom",
                Weight = 0.2f,
                BaseValue = 8,
                Effect = "Restores 15 HP",
                Duration = 0
            };
            ingredientsList.Add(Herb3);

            IngredientModel Herb4 = new IngredientModel
            {
                Id = 34,
                Name = "Blue Flower",
                Weight = 0.1f,
                BaseValue = 10,
                Effect = "Restores 20 MP",
                Duration = 0
            };
            ingredientsList.Add(Herb4);

            IngredientModel Herb5 = new IngredientModel
            {
                Id = 35,
                Name = "Dragon Scale",
                Weight = 0.5f,
                BaseValue = 50,
                Effect = "Increases Fire Resistance",
                Duration = 300
            };
            ingredientsList.Add(Herb5);
        }

        public static void CraftingItems()
        {
            CraftingItemModel Craft1 = new CraftingItemModel
            {
                Id = 41,
                Name = "Iron Ore",
                Weight = 2.0f,
                BaseValue = 15
            };
            craftingItemsList.Add(Craft1);

            CraftingItemModel Craft2 = new CraftingItemModel
            {
                Id = 42,
                Name = "Leather Strip",
                Weight = 0.5f,
                BaseValue = 5
            };
            craftingItemsList.Add(Craft2);

            CraftingItemModel Craft3 = new CraftingItemModel
            {
                Id = 43,
                Name = "Wood Plank",
                Weight = 1.0f,
                BaseValue = 3
            };
            craftingItemsList.Add(Craft3);

            CraftingItemModel Craft4 = new CraftingItemModel
            {
                Id = 44,
                Name = "Steel Ingot",
                Weight = 3.0f,
                BaseValue = 30
            };
            craftingItemsList.Add(Craft4);

            CraftingItemModel Craft5 = new CraftingItemModel
            {
                Id = 45,
                Name = "Magic Crystal",
                Weight = 0.3f,
                BaseValue = 100
            };
            craftingItemsList.Add(Craft5);
        }

        public static void Miscs()
        {
            MiscItemModel Misc1 = new MiscItemModel
            {
                Id = 51,
                Name = "Old Key",
                Weight = 0.1f,
                BaseValue = 10,
                Description = "A rusty old key, might open something"
            };
            miscItemsList.Add(Misc1);

            MiscItemModel Misc2 = new MiscItemModel
            {
                Id = 52,
                Name = "Ancient Coin",
                Weight = 0.1f,
                BaseValue = 25,
                Description = "A valuable coin from a bygone era"
            };
            miscItemsList.Add(Misc2);

            MiscItemModel Misc3 = new MiscItemModel
            {
                Id = 53,
                Name = "Gemstone",
                Weight = 0.2f,
                BaseValue = 75,
                Description = "A beautiful gemstone that sparkles in the light"
            };
            miscItemsList.Add(Misc3);

            MiscItemModel Misc4 = new MiscItemModel
            {
                Id = 54,
                Name = "Quest Letter",
                Weight = 0.1f,
                BaseValue = 0,
                Description = "An important letter for a quest"
            };
            miscItemsList.Add(Misc4);

            MiscItemModel Misc5 = new MiscItemModel
            {
                Id = 55,
                Name = "Lucky Charm",
                Weight = 0.1f,
                BaseValue = 50,
                Description = "A charm said to bring good fortune"
            };
            miscItemsList.Add(Misc5);
        }

        public static void Potions()
        {
            PotionModel Potion1 = new PotionModel
            {
                Id = 61,
                Name = "Minor Health Potion",
                Weight = 0.2f,
                BaseValue = 15,
                Effect = "Restores 25 HP",
                HealthRestore = 25,
                ManaRestore = 0,
                Duration = 0
            };
            potionsList.Add(Potion1);

            PotionModel Potion2 = new PotionModel
            {
                Id = 62,
                Name = "Minor Mana Potion",
                Weight = 0.2f,
                BaseValue = 15,
                Effect = "Restores 25 MP",
                HealthRestore = 0,
                ManaRestore = 25,
                Duration = 0
            };
            potionsList.Add(Potion2);

            PotionModel Potion3 = new PotionModel
            {
                Id = 63,
                Name = "Health Potion",
                Weight = 0.3f,
                BaseValue = 35,
                Effect = "Restores 50 HP",
                HealthRestore = 50,
                ManaRestore = 0,
                Duration = 0
            };
            potionsList.Add(Potion3);

            PotionModel Potion4 = new PotionModel
            {
                Id = 64,
                Name = "Mana Potion",
                Weight = 0.3f,
                BaseValue = 35,
                Effect = "Restores 50 MP",
                HealthRestore = 0,
                ManaRestore = 50,
                Duration = 0
            };
            potionsList.Add(Potion4);

            PotionModel Potion5 = new PotionModel
            {
                Id = 65,
                Name = "Greater Health Potion",
                Weight = 0.4f,
                BaseValue = 70,
                Effect = "Restores 100 HP",
                HealthRestore = 100,
                ManaRestore = 0,
                Duration = 0
            };
            potionsList.Add(Potion5);

            PotionModel Potion6 = new PotionModel
            {
                Id = 66,
                Name = "Greater Mana Potion",
                Weight = 0.4f,
                BaseValue = 70,
                Effect = "Restores 100 MP",
                HealthRestore = 0,
                ManaRestore = 100,
                Duration = 0
            };
            potionsList.Add(Potion6);

            PotionModel Potion7 = new PotionModel
            {
                Id = 67,
                Name = "Rejuvenation Potion",
                Weight = 0.5f,
                BaseValue = 100,
                Effect = "Restores 50 HP and 50 MP",
                HealthRestore = 50,
                ManaRestore = 50,
                Duration = 0
            };
            potionsList.Add(Potion7);

            PotionModel Potion8 = new PotionModel
            {
                Id = 68,
                Name = "Strength Elixir",
                Weight = 0.3f,
                BaseValue = 80,
                Effect = "Increases Strength by 5 for 5 minutes",
                HealthRestore = 0,
                ManaRestore = 0,
                Duration = 300
            };
            potionsList.Add(Potion8);

            PotionModel Potion9 = new PotionModel
            {
                Id = 69,
                Name = "Agility Elixir",
                Weight = 0.3f,
                BaseValue = 80,
                Effect = "Increases Agility by 5 for 5 minutes",
                HealthRestore = 0,
                ManaRestore = 0,
                Duration = 300
            };
            potionsList.Add(Potion9);

            PotionModel Potion10 = new PotionModel
            {
                Id = 610,
                Name = "Intelligence Elixir",
                Weight = 0.3f,
                BaseValue = 80,
                Effect = "Increases Intelligence by 5 for 5 minutes",
                HealthRestore = 0,
                ManaRestore = 0,
                Duration = 300
            };
            potionsList.Add(Potion10);
        }

        // Array containing all items
        // Row 1: Weapons (IDs 11-115)
        // Row 2: Armors (IDs 21-26)
        // Row 3: Ingredients (IDs 31-35)
        // Row 4: CraftingItems (IDs 41-45)
        // Row 5: Misc (IDs 51-55)
        // Row 6: Potions (IDs 61-610)
        public static void InitializeAllItems()
        {
            weaponsList.Clear();
            armorsList.Clear();
            ingredientsList.Clear();
            craftingItemsList.Clear();
            miscItemsList.Clear();
            potionsList.Clear();

            Weapons();
            Armors();
            Ingredients();
            CraftingItems();
            Miscs();
            Potions();
        }

        public Array GetAllItems()
        {
            InitializeAllItems();

            return new ItemModel[] []
            {
                weaponsList.ToArray(),
                armorsList.ToArray(),
                ingredientsList.ToArray(),
                craftingItemsList.ToArray(),
                miscItemsList.ToArray(),
                potionsList.ToArray()
            };
        }

        public static ItemModel GetItemById(int id)
        {
            if (weaponsList.Count == 0)
                InitializeAllItems();

            int row = id / 10;
            
            switch (row)
            {
                case 1: // Weapons
                    return weaponsList.FirstOrDefault(w => w.Id == id);
                case 2: // Armors
                    return armorsList.FirstOrDefault(a => a.Id == id);
                case 3: // Ingredients
                    return ingredientsList.FirstOrDefault(i => i.Id == id);
                case 4: // Crafting Items
                    return craftingItemsList.FirstOrDefault(c => c.Id == id);
                case 5: // Misc Items
                    return miscItemsList.FirstOrDefault(m => m.Id == id);
                case 6: // Potions
                    return potionsList.FirstOrDefault(p => p.Id == id);
                default:
                    return null;
            }
        }
    }
}
