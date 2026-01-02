using System;
using System.Collections.Generic;
using System.Linq;
using Bit_RPG.Char;
using Bit_RPG.Models;

namespace Bit_RPG.Crafting
{
    public static class CraftingSystem
    {
        public static bool CanCraft(Player player, CraftingRecipe recipe)
        {
            // Check skill level
            int playerSkillLevel = GetPlayerSkillLevel(player, recipe.RequiredSkill);
            if (playerSkillLevel < recipe.RequiredSkillLevel)
            {
                return false;
            }

            // Check if player has all required ingredients
            return HasRequiredIngredients(player, recipe);
        }

        public static bool HasRequiredIngredients(Player player, CraftingRecipe recipe)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                int playerCount = player.Inventory.Count(item => item.Id == ingredient.ItemId);
                if (playerCount < ingredient.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<RecipeIngredient> GetMissingIngredients(Player player, CraftingRecipe recipe)
        {
            var missing = new List<RecipeIngredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                int playerCount = player.Inventory.Count(item => item.Id == ingredient.ItemId);
                int needed = ingredient.Quantity - playerCount;

                if (needed > 0)
                {
                    missing.Add(new RecipeIngredient
                    {
                        ItemId = ingredient.ItemId,
                        ItemName = ingredient.ItemName,
                        Quantity = needed
                    });
                }
            }

            return missing;
        }

        public static CraftResult CraftItem(Player player, CraftingRecipe recipe)
        {
            var result = new CraftResult();

            // Validate skill level
            int playerSkillLevel = GetPlayerSkillLevel(player, recipe.RequiredSkill);
            if (playerSkillLevel < recipe.RequiredSkillLevel)
            {
                result.Success = false;
                result.Message = $"You need {recipe.RequiredSkill} level {recipe.RequiredSkillLevel} to craft this. Your level: {playerSkillLevel}";
                return result;
            }

            // Validate ingredients
            var missingIngredients = GetMissingIngredients(player, recipe);
            if (missingIngredients.Any())
            {
                result.Success = false;
                result.Message = $"Missing ingredients: {string.Join(", ", missingIngredients.Select(i => $"{i.ItemName} x{i.Quantity}"))}";
                return result;
            }

            // Consume ingredients
            foreach (var ingredient in recipe.Ingredients)
            {
                int removed = 0;
                while (removed < ingredient.Quantity)
                {
                    var item = player.Inventory.FirstOrDefault(i => i.Id == ingredient.ItemId);
                    if (item != null)
                    {
                        player.Inventory.Remove(item);
                        removed++;
                    }
                    else
                    {
                        // This shouldn't happen if validation worked correctly
                        result.Success = false;
                        result.Message = "Error: Failed to remove ingredients";
                        return result;
                    }
                }
            }

            // Add crafted item to inventory
            player.Inventory.Add(recipe.ResultItem);

            // Grant experience
            IncreaseSkill(player, recipe.RequiredSkill, recipe.ExperienceGain);

            result.Success = true;
            result.CraftedItem = recipe.ResultItem;
            result.SkillGain = recipe.ExperienceGain;
            result.Message = $"Successfully crafted {recipe.Name}! +{recipe.ExperienceGain} {recipe.RequiredSkill} experience";

            return result;
        }

        private static int GetPlayerSkillLevel(Player player, string skillName)
        {
            return skillName switch
            {
                "Alchemy" => player.Skills.Alchemy,
                "Smithing" => player.Skills.Smithing,
                "Enchanting" => player.Skills.Enchanting,
                _ => 0
            };
        }

        private static void IncreaseSkill(Player player, string skillName, int amount)
        {
            switch (skillName)
            {
                case "Alchemy":
                    player.Skills.Alchemy = Math.Min(player.Skills.Alchemy + amount, 100);
                    break;
                case "Smithing":
                    player.Skills.Smithing = Math.Min(player.Skills.Smithing + amount, 100);
                    break;
                case "Enchanting":
                    player.Skills.Enchanting = Math.Min(player.Skills.Enchanting + amount, 100);
                    break;
            }
        }
    }

    public class CraftResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ItemModel CraftedItem { get; set; }
        public int SkillGain { get; set; }
    }
}
