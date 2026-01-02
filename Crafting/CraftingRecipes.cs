using System;
using System.Collections.Generic;
using System.Linq;
using Bit_RPG.Models;

namespace Bit_RPG.Crafting
{
    public class CraftingRecipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public RecipeType Type { get; set; }
        public int RequiredSkillLevel { get; set; }
        public string RequiredSkill { get; set; } // "Alchemy", "Smithing", "Enchanting"
        public List<RecipeIngredient> Ingredients { get; set; } = new List<RecipeIngredient>();
        public ItemModel ResultItem { get; set; }
        public int ExperienceGain { get; set; }
    }

    public class RecipeIngredient
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
    }

    public enum RecipeType
    {
        Potion,
        Weapon,
        Armor
    }

    public static class CraftingRecipes
    {
        private static List<CraftingRecipe> _recipes = new List<CraftingRecipe>();
        private static bool _initialized = false;
        private static readonly object _initLock = new object();

        private static void EnsureInitialized()
        {
            if (_initialized) return;

            lock (_initLock)
            {
                if (_initialized) return;
                InitializeRecipes();
                _initialized = true;
            }
        }

        private static void InitializeRecipes()
        {
            _recipes.Clear();

            // ========== ALCHEMY RECIPES (Potions) ==========

            // Level 10: Minor Health Potion
            _recipes.Add(new CraftingRecipe
            {
                Id = 1,
                Name = "Minor Health Potion",
                Description = "Restores 25 HP",
                Type = RecipeType.Potion,
                RequiredSkillLevel = 10,
                RequiredSkill = "Alchemy",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 31, ItemName = "Herth Herb", Quantity = 2 },
                    new RecipeIngredient { ItemId = 33, ItemName = "Red Mushroom", Quantity = 1 }
                },
                ResultItem = new PotionModel
                {
                    Id = 61,
                    Name = "Minor Health Potion",
                    Weight = 0.2f,
                    BaseValue = 15,
                    Effect = "Restores 25 HP",
                    HealthRestore = 25,
                    ManaRestore = 0,
                    Duration = 0
                },
                ExperienceGain = 5
            });

            // Level 10: Minor Mana Potion
            _recipes.Add(new CraftingRecipe
            {
                Id = 2,
                Name = "Minor Mana Potion",
                Description = "Restores 25 MP",
                Type = RecipeType.Potion,
                RequiredSkillLevel = 10,
                RequiredSkill = "Alchemy",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 32, ItemName = "Mort Wood", Quantity = 2 },
                    new RecipeIngredient { ItemId = 34, ItemName = "Blue Flower", Quantity = 1 }
                },
                ResultItem = new PotionModel
                {
                    Id = 62,
                    Name = "Minor Mana Potion",
                    Weight = 0.2f,
                    BaseValue = 15,
                    Effect = "Restores 25 MP",
                    HealthRestore = 0,
                    ManaRestore = 25,
                    Duration = 0
                },
                ExperienceGain = 5
            });

            // Level 25: Health Potion
            _recipes.Add(new CraftingRecipe
            {
                Id = 3,
                Name = "Health Potion",
                Description = "Restores 50 HP",
                Type = RecipeType.Potion,
                RequiredSkillLevel = 25,
                RequiredSkill = "Alchemy",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 31, ItemName = "Herth Herb", Quantity = 3 },
                    new RecipeIngredient { ItemId = 33, ItemName = "Red Mushroom", Quantity = 2 },
                    new RecipeIngredient { ItemId = 35, ItemName = "Dragon Scale", Quantity = 1 }
                },
                ResultItem = new PotionModel
                {
                    Id = 63,
                    Name = "Health Potion",
                    Weight = 0.3f,
                    BaseValue = 35,
                    Effect = "Restores 50 HP",
                    HealthRestore = 50,
                    ManaRestore = 0,
                    Duration = 0
                },
                ExperienceGain = 10
            });

            // Level 25: Mana Potion
            _recipes.Add(new CraftingRecipe
            {
                Id = 4,
                Name = "Mana Potion",
                Description = "Restores 50 MP",
                Type = RecipeType.Potion,
                RequiredSkillLevel = 25,
                RequiredSkill = "Alchemy",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 32, ItemName = "Mort Wood", Quantity = 3 },
                    new RecipeIngredient { ItemId = 34, ItemName = "Blue Flower", Quantity = 2 },
                    new RecipeIngredient { ItemId = 45, ItemName = "Magic Crystal", Quantity = 1 }
                },
                ResultItem = new PotionModel
                {
                    Id = 64,
                    Name = "Mana Potion",
                    Weight = 0.3f,
                    BaseValue = 35,
                    Effect = "Restores 50 MP",
                    HealthRestore = 0,
                    ManaRestore = 50,
                    Duration = 0
                },
                ExperienceGain = 10
            });

            // Level 40: Greater Health Potion
            _recipes.Add(new CraftingRecipe
            {
                Id = 5,
                Name = "Greater Health Potion",
                Description = "Restores 100 HP",
                Type = RecipeType.Potion,
                RequiredSkillLevel = 40,
                RequiredSkill = "Alchemy",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 31, ItemName = "Herth Herb", Quantity = 5 },
                    new RecipeIngredient { ItemId = 33, ItemName = "Red Mushroom", Quantity = 3 },
                    new RecipeIngredient { ItemId = 35, ItemName = "Dragon Scale", Quantity = 2 }
                },
                ResultItem = new PotionModel
                {
                    Id = 65,
                    Name = "Greater Health Potion",
                    Weight = 0.4f,
                    BaseValue = 70,
                    Effect = "Restores 100 HP",
                    HealthRestore = 100,
                    ManaRestore = 0,
                    Duration = 0
                },
                ExperienceGain = 15
            });

            // ========== SMITHING RECIPES (Weapons & Armor) ==========

            // Level 10: Iron Dagger
            _recipes.Add(new CraftingRecipe
            {
                Id = 6,
                Name = "Iron Dagger",
                Description = "A simple iron dagger",
                Type = RecipeType.Weapon,
                RequiredSkillLevel = 10,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 41, ItemName = "Iron Ore", Quantity = 2 },
                    new RecipeIngredient { ItemId = 43, ItemName = "Wood Plank", Quantity = 1 }
                },
                ResultItem = new WeaponModel
                {
                    Id = 201,
                    Name = "Crafted Iron Dagger",
                    Weight = 1.5f,
                    BaseValue = 35,
                    Damage = 10,
                    AttackSpeed = 1.8f,
                    Type = WeaponModel.WeaponType.Blade
                },
                ExperienceGain = 8
            });

            // Level 15: Leather Armor
            _recipes.Add(new CraftingRecipe
            {
                Id = 7,
                Name = "Leather Armor",
                Description = "Basic protective leather armor",
                Type = RecipeType.Armor,
                RequiredSkillLevel = 15,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 42, ItemName = "Leather Strip", Quantity = 5 },
                    new RecipeIngredient { ItemId = 43, ItemName = "Wood Plank", Quantity = 2 }
                },
                ResultItem = new ArmorModel
                {
                    Id = 202,
                    Name = "Crafted Leather Armor",
                    Weight = 4.5f,
                    BaseValue = 30,
                    Defense = 4,
                    Type = ArmorModel.ArmorType.Light
                },
                ExperienceGain = 8
            });

            // Level 25: Iron Sword
            _recipes.Add(new CraftingRecipe
            {
                Id = 8,
                Name = "Iron Sword",
                Description = "A reliable iron sword",
                Type = RecipeType.Weapon,
                RequiredSkillLevel = 25,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 41, ItemName = "Iron Ore", Quantity = 4 },
                    new RecipeIngredient { ItemId = 43, ItemName = "Wood Plank", Quantity = 2 },
                    new RecipeIngredient { ItemId = 42, ItemName = "Leather Strip", Quantity = 1 }
                },
                ResultItem = new WeaponModel
                {
                    Id = 203,
                    Name = "Crafted Iron Sword",
                    Weight = 3.0f,
                    BaseValue = 50,
                    Damage = 14,
                    AttackSpeed = 1.5f,
                    Type = WeaponModel.WeaponType.Blade
                },
                ExperienceGain = 12
            });

            // Level 30: Chainmail Armor
            _recipes.Add(new CraftingRecipe
            {
                Id = 9,
                Name = "Chainmail Armor",
                Description = "Interlocking iron rings provide good protection",
                Type = RecipeType.Armor,
                RequiredSkillLevel = 30,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 41, ItemName = "Iron Ore", Quantity = 6 },
                    new RecipeIngredient { ItemId = 42, ItemName = "Leather Strip", Quantity = 3 }
                },
                ResultItem = new ArmorModel
                {
                    Id = 204,
                    Name = "Crafted Chainmail Armor",
                    Weight = 14.0f,
                    BaseValue = 80,
                    Defense = 9,
                    Type = ArmorModel.ArmorType.Medium
                },
                ExperienceGain = 15
            });

            // Level 40: Steel Sword
            _recipes.Add(new CraftingRecipe
            {
                Id = 10,
                Name = "Steel Sword",
                Description = "A superior steel blade",
                Type = RecipeType.Weapon,
                RequiredSkillLevel = 40,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 44, ItemName = "Steel Ingot", Quantity = 3 },
                    new RecipeIngredient { ItemId = 43, ItemName = "Wood Plank", Quantity = 2 },
                    new RecipeIngredient { ItemId = 42, ItemName = "Leather Strip", Quantity = 2 }
                },
                ResultItem = new WeaponModel
                {
                    Id = 205,
                    Name = "Crafted Steel Sword",
                    Weight = 3.5f,
                    BaseValue = 90,
                    Damage = 20,
                    AttackSpeed = 1.6f,
                    Type = WeaponModel.WeaponType.Blade
                },
                ExperienceGain = 18
            });

            // Level 50: Steel Plate Armor
            _recipes.Add(new CraftingRecipe
            {
                Id = 11,
                Name = "Steel Plate Armor",
                Description = "Heavy plate armor offering maximum protection",
                Type = RecipeType.Armor,
                RequiredSkillLevel = 50,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 44, ItemName = "Steel Ingot", Quantity = 8 },
                    new RecipeIngredient { ItemId = 42, ItemName = "Leather Strip", Quantity = 5 }
                },
                ResultItem = new ArmorModel
                {
                    Id = 206,
                    Name = "Crafted Steel Plate Armor",
                    Weight = 32.0f,
                    BaseValue = 220,
                    Defense = 22,
                    Type = ArmorModel.ArmorType.Heavy
                },
                ExperienceGain = 25
            });

            // Level 20: Iron Spear
            _recipes.Add(new CraftingRecipe
            {
                Id = 12,
                Name = "Iron Spear",
                Description = "A long-reaching iron spear",
                Type = RecipeType.Weapon,
                RequiredSkillLevel = 20,
                RequiredSkill = "Smithing",
                Ingredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { ItemId = 41, ItemName = "Iron Ore", Quantity = 3 },
                    new RecipeIngredient { ItemId = 43, ItemName = "Wood Plank", Quantity = 3 }
                },
                ResultItem = new WeaponModel
                {
                    Id = 207,
                    Name = "Crafted Iron Spear",
                    Weight = 4.5f,
                    BaseValue = 40,
                    Damage = 11,
                    AttackSpeed = 0.9f,
                    Type = WeaponModel.WeaponType.LongWeapon
                },
                ExperienceGain = 10
            });
        }

        public static List<CraftingRecipe> GetAllRecipes()
        {
            EnsureInitialized();
            return _recipes;
        }

        public static List<CraftingRecipe> GetRecipesByType(RecipeType type)
        {
            EnsureInitialized();
            return _recipes.Where(r => r.Type == type).ToList();
        }

        public static List<CraftingRecipe> GetRecipesBySkill(string skill, int playerSkillLevel)
        {
            EnsureInitialized();
            return _recipes
                .Where(r => r.RequiredSkill == skill && r.RequiredSkillLevel <= playerSkillLevel)
                .OrderBy(r => r.RequiredSkillLevel)
                .ToList();
        }

        public static CraftingRecipe GetRecipeById(int id)
        {
            EnsureInitialized();
            return _recipes.FirstOrDefault(r => r.Id == id);
        }

        public static List<CraftingRecipe> GetAvailableRecipes(string skill, int playerSkillLevel)
        {
            EnsureInitialized();
            // Returns recipes the player can craft (has required skill level)
            return _recipes
                .Where(r => r.RequiredSkill == skill && r.RequiredSkillLevel <= playerSkillLevel)
                .OrderBy(r => r.RequiredSkillLevel)
                .ToList();
        }
    }
}
