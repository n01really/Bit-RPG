using Bit_RPG.Char;
using Bit_RPG.Crafting;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Collections.Generic;
using System.Linq;

namespace Bit_RPG.Popups;

public partial class CraftingPopup : Popup
{
    private Player _player;
    private string _craftingType; // "Alchemy" or "Smithing"
    private RecipeType? _currentFilter = null;

    public CraftingPopup(Player player, string craftingType)
    {
        InitializeComponent();
        _player = player;
        _craftingType = craftingType;

        SetupUI();
        LoadRecipes();
    }

    private void SetupUI()
    {
        if (_craftingType == "Alchemy")
        {
            TitleLabel.Text = "Alchemy Crafting";
            SkillLevelLabel.Text = $"Alchemy Level: {_player.Skills.Alchemy}";
            
            // Only show potion tab for alchemy
            AllTab.IsVisible = false;
            PotionTab.IsVisible = true;
            WeaponTab.IsVisible = false;
            ArmorTab.IsVisible = false;
            
            _currentFilter = RecipeType.Potion;
            UpdateTabColors();
        }
        else if (_craftingType == "Smithing")
        {
            TitleLabel.Text = "Smithing Crafting";
            SkillLevelLabel.Text = $"Smithing Level: {_player.Skills.Smithing}";
            
            // Show weapon and armor tabs for smithing
            AllTab.IsVisible = true;
            PotionTab.IsVisible = false;
            WeaponTab.IsVisible = true;
            ArmorTab.IsVisible = true;
        }
    }

    private void LoadRecipes()
    {
        RecipesContainer.Children.Clear();

        List<CraftingRecipe> recipes;

        if (_currentFilter.HasValue)
        {
            recipes = CraftingRecipes.GetRecipesByType(_currentFilter.Value)
                .Where(r => r.RequiredSkill == _craftingType)
                .OrderBy(r => r.RequiredSkillLevel)
                .ToList();
        }
        else
        {
            int playerSkillLevel = _craftingType == "Alchemy" ? _player.Skills.Alchemy : _player.Skills.Smithing;
            recipes = CraftingRecipes.GetRecipesBySkill(_craftingType, 100) // Get all recipes for this skill
                .OrderBy(r => r.RequiredSkillLevel)
                .ToList();
        }

        if (!recipes.Any())
        {
            RecipesContainer.Children.Add(new Label
            {
                Text = $"No recipes available. Train your {_craftingType} skill to unlock recipes!",
                FontSize = 14,
                TextColor = Colors.Gray,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20)
            });
            return;
        }

        foreach (var recipe in recipes)
        {
            int playerSkillLevel = _craftingType == "Alchemy" ? _player.Skills.Alchemy : _player.Skills.Smithing;
            bool canCraft = CraftingSystem.CanCraft(_player, recipe);
            bool skillTooLow = playerSkillLevel < recipe.RequiredSkillLevel;
            var missingIngredients = CraftingSystem.GetMissingIngredients(_player, recipe);

            var recipeBorder = new Border
            {
                Stroke = canCraft ? Colors.Green : (skillTooLow ? Colors.Gray : Colors.Orange),
                StrokeThickness = 2,
                Padding = 12,
                Margin = new Thickness(0, 0, 0, 10),
                BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark
                    ? Color.FromArgb("#2A2A2A")
                    : Color.FromArgb("#F5F5F5")
            };

            var recipeLayout = new VerticalStackLayout { Spacing = 8 };

            // Recipe Name and Level
            var headerLayout = new HorizontalStackLayout { Spacing = 10 };
            headerLayout.Children.Add(new Label
            {
                Text = recipe.Name,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center
            });
            headerLayout.Children.Add(new Label
            {
                Text = $"(Level {recipe.RequiredSkillLevel})",
                FontSize = 12,
                TextColor = skillTooLow ? Colors.Red : Colors.Gray,
                VerticalOptions = LayoutOptions.Center
            });
            recipeLayout.Children.Add(headerLayout);

            // Description
            recipeLayout.Children.Add(new Label
            {
                Text = recipe.Description,
                FontSize = 12,
                TextColor = Colors.Gray
            });

            // Result Item Stats
            string resultStats = GetItemStats(recipe.ResultItem);
            if (!string.IsNullOrEmpty(resultStats))
            {
                recipeLayout.Children.Add(new Label
                {
                    Text = resultStats,
                    FontSize = 11,
                    TextColor = Colors.LightBlue
                });
            }

            // Required Ingredients
            var ingredientsLabel = new Label
            {
                Text = "Required Ingredients:",
                FontSize = 12,
                FontAttributes = FontAttributes.Bold,
                Margin = new Thickness(0, 5, 0, 0)
            };
            recipeLayout.Children.Add(ingredientsLabel);

            foreach (var ingredient in recipe.Ingredients)
            {
                int playerCount = _player.Inventory.Count(item => item.Id == ingredient.ItemId);
                bool hasEnough = playerCount >= ingredient.Quantity;

                var ingredientLayout = new HorizontalStackLayout { Spacing = 5 };
                ingredientLayout.Children.Add(new Label
                {
                    Text = "•",
                    FontSize = 12,
                    TextColor = hasEnough ? Colors.Green : Colors.Red
                });
                ingredientLayout.Children.Add(new Label
                {
                    Text = $"{ingredient.ItemName} ({playerCount}/{ingredient.Quantity})",
                    FontSize = 11,
                    TextColor = hasEnough ? Colors.LightGreen : Colors.Orange
                });
                recipeLayout.Children.Add(ingredientLayout);
            }

            // Experience Gain
            recipeLayout.Children.Add(new Label
            {
                Text = $"+{recipe.ExperienceGain} {_craftingType} XP",
                FontSize = 11,
                TextColor = Colors.Gold,
                Margin = new Thickness(0, 5, 0, 0)
            });

            // Craft Button or Status Message
            if (skillTooLow)
            {
                recipeLayout.Children.Add(new Label
                {
                    Text = $"Requires {_craftingType} Level {recipe.RequiredSkillLevel}",
                    FontSize = 11,
                    TextColor = Colors.Red,
                    FontAttributes = FontAttributes.Italic,
                    Margin = new Thickness(0, 5, 0, 0)
                });
            }
            else if (!canCraft)
            {
                recipeLayout.Children.Add(new Label
                {
                    Text = $"Missing: {string.Join(", ", missingIngredients.Select(i => $"{i.ItemName} x{i.Quantity}"))}",
                    FontSize = 11,
                    TextColor = Colors.Orange,
                    FontAttributes = FontAttributes.Italic,
                    Margin = new Thickness(0, 5, 0, 0)
                });
            }
            else
            {
                var craftButton = new Button
                {
                    Text = "Craft",
                    BackgroundColor = Colors.Green,
                    TextColor = Colors.White,
                    Margin = new Thickness(0, 5, 0, 0),
                    HorizontalOptions = LayoutOptions.End
                };
                craftButton.Clicked += (s, e) => OnCraftClicked(recipe);
                recipeLayout.Children.Add(craftButton);
            }

            recipeBorder.Content = recipeLayout;
            RecipesContainer.Children.Add(recipeBorder);
        }
    }

    private string GetItemStats(ItemModel item)
    {
        return item switch
        {
            WeaponModel weapon => $"? Damage: {weapon.Damage} | Attack Speed: {weapon.AttackSpeed:F1} | Value: {weapon.BaseValue}g",
            ArmorModel armor => $"? Defense: {armor.Defense} | Type: {armor.Type} | Value: {armor.BaseValue}g",
            PotionModel potion => $"? {potion.Effect} | Value: {potion.BaseValue}g",
            IngredientModel ingredient => $"? {ingredient.Effect} | Value: {ingredient.BaseValue}g",
            _ => $"? Value: {item.BaseValue}g"
        };
    }

    private async void OnCraftClicked(CraftingRecipe recipe)
    {
        var result = CraftingSystem.CraftItem(_player, recipe);

        if (result.Success)
        {
            await DisplayAlert("Crafting Success!", result.Message, "OK");
            
            // Refresh the skill level label
            if (_craftingType == "Alchemy")
            {
                SkillLevelLabel.Text = $"Alchemy Level: {_player.Skills.Alchemy}";
            }
            else if (_craftingType == "Smithing")
            {
                SkillLevelLabel.Text = $"Smithing Level: {_player.Skills.Smithing}";
            }
            
            // Reload recipes to update ingredient counts
            LoadRecipes();
        }
        else
        {
            await DisplayAlert("Cannot Craft", result.Message, "OK");
        }
    }

    private void OnAllTabClicked(object sender, EventArgs e)
    {
        _currentFilter = null;
        UpdateTabColors();
        LoadRecipes();
    }

    private void OnPotionTabClicked(object sender, EventArgs e)
    {
        _currentFilter = RecipeType.Potion;
        UpdateTabColors();
        LoadRecipes();
    }

    private void OnWeaponTabClicked(object sender, EventArgs e)
    {
        _currentFilter = RecipeType.Weapon;
        UpdateTabColors();
        LoadRecipes();
    }

    private void OnArmorTabClicked(object sender, EventArgs e)
    {
        _currentFilter = RecipeType.Armor;
        UpdateTabColors();
        LoadRecipes();
    }

    private void UpdateTabColors()
    {
        var activeColor = Application.Current.RequestedTheme == AppTheme.Dark
            ? (Color)Application.Current.Resources["Primary"]
            : (Color)Application.Current.Resources["Primary"];
        var inactiveColor = Application.Current.RequestedTheme == AppTheme.Dark
            ? Color.FromArgb("#2A2A2A")
            : Colors.LightGray;

        var activeTextColor = Colors.White;
        var inactiveTextColor = Application.Current.RequestedTheme == AppTheme.Dark
            ? Colors.White
            : Colors.Black;

        // Reset all tabs
        if (AllTab.IsVisible)
        {
            AllTab.BackgroundColor = _currentFilter == null ? activeColor : inactiveColor;
            ((Label)AllTab.Content).TextColor = _currentFilter == null ? activeTextColor : inactiveTextColor;
            ((Label)AllTab.Content).FontAttributes = _currentFilter == null ? FontAttributes.Bold : FontAttributes.None;
        }

        if (PotionTab.IsVisible)
        {
            PotionTab.BackgroundColor = _currentFilter == RecipeType.Potion ? activeColor : inactiveColor;
            ((Label)PotionTab.Content).TextColor = _currentFilter == RecipeType.Potion ? activeTextColor : inactiveTextColor;
            ((Label)PotionTab.Content).FontAttributes = _currentFilter == RecipeType.Potion ? FontAttributes.Bold : FontAttributes.None;
        }

        if (WeaponTab.IsVisible)
        {
            WeaponTab.BackgroundColor = _currentFilter == RecipeType.Weapon ? activeColor : inactiveColor;
            ((Label)WeaponTab.Content).TextColor = _currentFilter == RecipeType.Weapon ? activeTextColor : inactiveTextColor;
            ((Label)WeaponTab.Content).FontAttributes = _currentFilter == RecipeType.Weapon ? FontAttributes.Bold : FontAttributes.None;
        }

        if (ArmorTab.IsVisible)
        {
            ArmorTab.BackgroundColor = _currentFilter == RecipeType.Armor ? activeColor : inactiveColor;
            ((Label)ArmorTab.Content).TextColor = _currentFilter == RecipeType.Armor ? activeTextColor : inactiveTextColor;
            ((Label)ArmorTab.Content).FontAttributes = _currentFilter == RecipeType.Armor ? FontAttributes.Bold : FontAttributes.None;
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }

    private async Task DisplayAlert(string title, string message, string cancel)
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
