using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;
using System.Reflection;
using System.Collections.Generic;

namespace Bit_RPG;

public partial class LevelUpPopup : Popup
{
    private Player _player;
    private Dictionary<string, int> _initialSkillValues;
    
    public LevelUpPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        BindingContext = _player;
        
        // Store initial skill values to prevent decreasing below starting point
        _initialSkillValues = new Dictionary<string, int>();
        var skillProperties = _player.Skills.GetType().GetProperties();
        foreach (var prop in skillProperties)
        {
            if (prop.PropertyType == typeof(int))
            {
                _initialSkillValues[prop.Name] = (int)prop.GetValue(_player.Skills);
            }
        }
    }

    private async void OnIncreaseSkill(object sender, EventArgs e)
    {
        if (sender is Border border && border.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is string skillName)
        {
            // Check if player has skill points available
            if (_player.SkillPoints <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("No Skill Points", 
                    "You don't have any skill points available!", "OK");
                return;
            }

            // Get the Skills property using reflection
            var skillProperty = _player.Skills.GetType().GetProperty(skillName);
            
            if (skillProperty != null)
            {
                // Get current skill value
                int currentValue = (int)skillProperty.GetValue(_player.Skills);
                
                // Check if skill is already at max (100)
                if (currentValue >= 100)
                {
                    await Application.Current.MainPage.DisplayAlert("Max Skill Level", 
                        $"{skillName} is already at maximum level (100)!", "OK");
                    return;
                }
                
                // Increase the skill - this will automatically trigger OnPropertyChanged in the Skills class
                skillProperty.SetValue(_player.Skills, currentValue + 1);
                
                // Decrease skill points - this will automatically trigger OnPropertyChanged in the Player class
                _player.SkillPoints--;
            }
        }
    }

    private async void OnDecreaseSkill(object sender, EventArgs e)
    {
        if (sender is Border border && border.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is string skillName)
        {
            // Get the Skills property using reflection
            var skillProperty = _player.Skills.GetType().GetProperty(skillName);
            
            if (skillProperty != null)
            {
                // Get current skill value
                int currentValue = (int)skillProperty.GetValue(_player.Skills);
                
                // Check if skill is at or below initial value
                if (!_initialSkillValues.ContainsKey(skillName) || currentValue <= _initialSkillValues[skillName])
                {
                    await Application.Current.MainPage.DisplayAlert("Cannot Decrease", 
                        $"Cannot decrease {skillName} below its starting value!", "OK");
                    return;
                }
                
                // Decrease the skill - this will automatically trigger OnPropertyChanged in the Skills class
                skillProperty.SetValue(_player.Skills, currentValue - 1);
                
                // Refund skill point - this will automatically trigger OnPropertyChanged in the Player class
                _player.SkillPoints++;
            }
        }
    }

    private void OnFinishClicked(object sender, EventArgs e)
    {
        Close();
    }
}
