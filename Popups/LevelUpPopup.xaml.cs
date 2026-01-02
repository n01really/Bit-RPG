using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;
using System.Reflection;
using System.Collections.Generic;

namespace Bit_RPG;

public partial class LevelUpPopup : Popup
{
    private Player _player;
    private Dictionary<string, int> _initialAttributeValues;
    
    public LevelUpPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        BindingContext = _player;
        
        // Store initial attribute values to prevent decreasing below starting point
        _initialAttributeValues = new Dictionary<string, int>
        {
            { "MaxHealth", _player.MaxHealth },
            { "MaxMana", _player.MaxMana },
            { "Strength", _player.Strength },
            { "Agility", _player.Agility },
            { "Intelligence", _player.Intelligence }
        };
    }

    private async void OnIncreaseAttribute(object sender, EventArgs e)
    {
        if (sender is Border border && border.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is string attributeName)
        {
            // Check if player has attribute points available
            if (_player.SkillPoints <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("No Attribute Points", 
                    "You don't have any attribute points available!", "OK");
                return;
            }

            // Get the attribute property using reflection
            var attributeProperty = _player.GetType().GetProperty(attributeName);
            
            if (attributeProperty != null)
            {
                // Get current attribute value
                int currentValue = (int)attributeProperty.GetValue(_player);
                
                // Check if attribute is already at max (150)
                if (currentValue >= 150)
                {
                    await Application.Current.MainPage.DisplayAlert("Max Attribute Level", 
                        $"{attributeName} is already at maximum level (150)!", "OK");
                    return;
                }
                
                // Increase the attribute
                attributeProperty.SetValue(_player, currentValue + 1);
                
                // Decrease attribute points
                _player.SkillPoints--;
            }
        }
    }

    private async void OnDecreaseAttribute(object sender, EventArgs e)
    {
        if (sender is Border border && border.GestureRecognizers[0] is TapGestureRecognizer tap && tap.CommandParameter is string attributeName)
        {
            // Get the attribute property using reflection
            var attributeProperty = _player.GetType().GetProperty(attributeName);
            
            if (attributeProperty != null)
            {
                // Get current attribute value
                int currentValue = (int)attributeProperty.GetValue(_player);
                
                // Check if attribute is at or below initial value
                if (!_initialAttributeValues.ContainsKey(attributeName) || currentValue <= _initialAttributeValues[attributeName])
                {
                    await Application.Current.MainPage.DisplayAlert("Cannot Decrease", 
                        $"Cannot decrease {attributeName} below its starting value!", "OK");
                    return;
                }
                
                // Decrease the attribute
                attributeProperty.SetValue(_player, currentValue - 1);
                
                // Refund attribute point
                _player.SkillPoints++;
            }
        }
    }

    private void OnFinishClicked(object sender, EventArgs e)
    {
        Close();
    }
}
