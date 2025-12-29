using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;
using System.Reflection;

namespace Bit_RPG;

public partial class TrainingPopup : Popup
{
    private Player _player;

    public TrainingPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        LoadSkills();
    }

    private void LoadSkills()
    {
        SkillPointsLabel.Text = $"Available Skill Points: {_player.SkillPoints}";

        var relevantSkills = GetRelevantSkills();

        foreach (var skillInfo in relevantSkills)
        {
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
                Text = $"Current Level: {skillInfo.CurrentValue}", 
                FontSize = 12, 
                TextColor = Colors.Gray 
            });

            var trainButton = new Button
            {
                Text = "Train (+1)",
                FontSize = 12,
                Padding = new Thickness(15, 5),
                IsEnabled = _player.SkillPoints > 0 && skillInfo.CurrentValue < 100
            };

            trainButton.Clicked += (s, e) => TrainSkill(skillInfo);

            Grid.SetColumn(skillInfoLayout, 0);
            Grid.SetColumn(trainButton, 1);

            skillLayout.Children.Add(skillInfoLayout);
            skillLayout.Children.Add(trainButton);

            skillBorder.Content = skillLayout;
            SkillsContainer.Children.Add(skillBorder);
        }
    }

    private List<SkillInfo> GetRelevantSkills()
    {
        var allSkills = new List<SkillInfo>
        {
            new SkillInfo { Name = "Stealth", PropertyName = nameof(_player.Skills.Stealth), CurrentValue = _player.Skills.Stealth },
            new SkillInfo { Name = "Marksmanship", PropertyName = nameof(_player.Skills.Marksmanship), CurrentValue = _player.Skills.Marksmanship },
            new SkillInfo { Name = "Slight of Hand", PropertyName = nameof(_player.Skills.SlightofHand), CurrentValue = _player.Skills.SlightofHand },
            new SkillInfo { Name = "Lockpicking", PropertyName = nameof(_player.Skills.Lockpicking), CurrentValue = _player.Skills.Lockpicking },
            new SkillInfo { Name = "Conjuration", PropertyName = nameof(_player.Skills.Conjuration), CurrentValue = _player.Skills.Conjuration },
            new SkillInfo { Name = "Destruction", PropertyName = nameof(_player.Skills.Destruction), CurrentValue = _player.Skills.Destruction },
            new SkillInfo { Name = "Illusion", PropertyName = nameof(_player.Skills.Illusion), CurrentValue = _player.Skills.Illusion },
            new SkillInfo { Name = "Restoration", PropertyName = nameof(_player.Skills.Restoration), CurrentValue = _player.Skills.Restoration },
            new SkillInfo { Name = "First Aid", PropertyName = nameof(_player.Skills.FirstAid), CurrentValue = _player.Skills.FirstAid },
            new SkillInfo { Name = "Swordsmanship", PropertyName = nameof(_player.Skills.Swordsmanship), CurrentValue = _player.Skills.Swordsmanship },
            new SkillInfo { Name = "Long Weapons", PropertyName = nameof(_player.Skills.LongWeapons), CurrentValue = _player.Skills.LongWeapons },
            new SkillInfo { Name = "Heavy Weapons", PropertyName = nameof(_player.Skills.HeavyWeapons), CurrentValue = _player.Skills.HeavyWeapons },
            new SkillInfo { Name = "Heavy Armor", PropertyName = nameof(_player.Skills.HeavyArmor), CurrentValue = _player.Skills.HeavyArmor },
            new SkillInfo { Name = "Medium Armor", PropertyName = nameof(_player.Skills.MediumArmor), CurrentValue = _player.Skills.MediumArmor },
            new SkillInfo { Name = "Light Armor", PropertyName = nameof(_player.Skills.LightArmor), CurrentValue = _player.Skills.LightArmor },
            new SkillInfo { Name = "Smithing", PropertyName = nameof(_player.Skills.Smithing), CurrentValue = _player.Skills.Smithing },
            new SkillInfo { Name = "Alchemy", PropertyName = nameof(_player.Skills.Alchemy), CurrentValue = _player.Skills.Alchemy },
            new SkillInfo { Name = "Enchanting", PropertyName = nameof(_player.Skills.Enchanting), CurrentValue = _player.Skills.Enchanting }
        };

        if (_player.Jobb == null)
            return allSkills;

        var relevantSkillNames = _player.Jobb.Name switch
        {
            "Adventurers Guild" => new[] { "Swordsmanship", "Long Weapons", "Heavy Weapons", "Marksmanship", 
                                          "Heavy Armor", "Medium Armor", "Light Armor", "First Aid", "Lockpicking", "Alchemy" },
            "Blacksmiths Guild" => new[] { "Smithing", "Heavy Weapons", "Long Weapons", "Swordsmanship", 
                                          "Heavy Armor", "Medium Armor", "Enchanting" },
            "Mages Guild" => new[] { "Conjuration", "Destruction", "Illusion", "Restoration", "Enchanting", "Alchemy" },
            "Thieves Guild" => new[] { "Stealth", "Slight of Hand", "Lockpicking", "Marksmanship", 
                                      "Light Armor", "Alchemy", "Illusion" },
            _ => Array.Empty<string>()
        };

        return allSkills.Where(s => relevantSkillNames.Contains(s.Name)).ToList();
    }

    private void TrainSkill(SkillInfo skillInfo)
    {
        if (_player.SkillPoints <= 0)
        {
            Application.Current.MainPage.DisplayAlert("No Skill Points", 
                "You don't have any skill points to spend.", "OK");
            return;
        }

        if (skillInfo.CurrentValue >= 100)
        {
            Application.Current.MainPage.DisplayAlert("Max Level", 
                $"{skillInfo.Name} is already at maximum level.", "OK");
            return;
        }

        var property = typeof(Skills).GetProperty(skillInfo.PropertyName);
        if (property != null)
        {
            int currentValue = (int)property.GetValue(_player.Skills);
            property.SetValue(_player.Skills, currentValue + 1);
            _player.SkillPoints--;

            SkillsContainer.Children.Clear();
            LoadSkills();
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }

    private class SkillInfo
    {
        public string Name { get; set; }
        public string PropertyName { get; set; }
        public int CurrentValue { get; set; }
    }
}
