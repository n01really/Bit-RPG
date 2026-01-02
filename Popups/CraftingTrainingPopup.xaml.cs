using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;
using System.Reflection;

namespace Bit_RPG;

public partial class CraftingTrainingPopup : Popup
{
    private Player _player;
    private const int TRAINING_COST_BASE = 25;

    public CraftingTrainingPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        LoadSkills();
    }

    private void LoadSkills()
    {
        PlayerGoldLabel.Text = $"Your Gold: {_player.Money}";

        var craftingSkills = new List<SkillInfo>
        {
            new SkillInfo { Name = "Smithing", PropertyName = nameof(_player.Skills.Smithing), CurrentValue = _player.Skills.Smithing, Description = "Craft weapons and armor" },
            new SkillInfo { Name = "Alchemy", PropertyName = nameof(_player.Skills.Alchemy), CurrentValue = _player.Skills.Alchemy, Description = "Brew potions and elixirs" },
            new SkillInfo { Name = "Enchanting", PropertyName = nameof(_player.Skills.Enchanting), CurrentValue = _player.Skills.Enchanting, Description = "Enchant items with magic" }
        };

        SkillsContainer.Children.Clear();

        foreach (var skillInfo in craftingSkills)
        {
            int trainingCost = CalculateTrainingCost(skillInfo.CurrentValue);

            var skillBorder = new Border
            {
                Stroke = Colors.Gray,
                StrokeThickness = 1,
                Padding = 10,
                BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark 
                    ? Color.FromArgb("#2A2A2A") 
                    : Color.FromArgb("#F5F5F5"),
                Margin = new Thickness(0, 0, 0, 5)
            };

            var skillLayout = new Grid
            {
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                ColumnSpacing = 10
            };

            var skillInfoLayout = new VerticalStackLayout { Spacing = 3 };
            skillInfoLayout.Children.Add(new Label 
            { 
                Text = skillInfo.Name, 
                FontSize = 14, 
                FontAttributes = FontAttributes.Bold 
            });
            skillInfoLayout.Children.Add(new Label 
            { 
                Text = skillInfo.Description, 
                FontSize = 11, 
                TextColor = Colors.Gray 
            });
            skillInfoLayout.Children.Add(new Label 
            { 
                Text = $"Current Level: {skillInfo.CurrentValue}", 
                FontSize = 12, 
                TextColor = Colors.Gray 
            });
            skillInfoLayout.Children.Add(new Label 
            { 
                Text = $"Training Cost: {trainingCost} gold", 
                FontSize = 11, 
                TextColor = Colors.Gold 
            });

            var trainButton = new Button
            {
                Text = "Train (+1)",
                FontSize = 12,
                Padding = new Thickness(15, 5),
                IsEnabled = _player.Money >= trainingCost && skillInfo.CurrentValue < 100
            };

            trainButton.Clicked += (s, e) => TrainSkill(skillInfo, trainingCost);

            Grid.SetColumn(skillInfoLayout, 0);
            Grid.SetColumn(trainButton, 1);

            skillLayout.Children.Add(skillInfoLayout);
            skillLayout.Children.Add(trainButton);

            skillBorder.Content = skillLayout;
            SkillsContainer.Children.Add(skillBorder);
        }
    }

    private int CalculateTrainingCost(int currentLevel)
    {
        return TRAINING_COST_BASE + (currentLevel * 3);
    }

    private async void TrainSkill(SkillInfo skillInfo, int cost)
    {
        if (_player.Money < cost)
        {
            await Application.Current.MainPage.DisplayAlert("Insufficient Gold", 
                $"You need {cost} gold to train {skillInfo.Name}. You have {_player.Money} gold.", "OK");
            return;
        }

        if (skillInfo.CurrentValue >= 100)
        {
            await Application.Current.MainPage.DisplayAlert("Max Level", 
                $"{skillInfo.Name} is already at maximum level.", "OK");
            return;
        }

        var property = typeof(Char.Skills).GetProperty(skillInfo.PropertyName);
        if (property != null)
        {
            int currentValue = (int)property.GetValue(_player.Skills);
            property.SetValue(_player.Skills, currentValue + 1);
            _player.Money -= cost;

            await Application.Current.MainPage.DisplayAlert("Training Complete", 
                $"Your {skillInfo.Name} increased to {currentValue + 1}!", "OK");

            LoadSkills();
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }

    private class SkillInfo
    {
        public string Name { get; set; } = "";
        public string PropertyName { get; set; } = "";
        public int CurrentValue { get; set; }
        public string Description { get; set; } = "";
    }
}
