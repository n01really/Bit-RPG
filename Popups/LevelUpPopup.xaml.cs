using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;
using System.Reflection;

namespace Bit_RPG;

public partial class LevelUpPopup : Popup
{
    private Player _player;
    
    public LevelUpPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        BindingContext = _player;
    }

    private async void OnIncreaseSkill(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is string skillName)
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
                
                // Increase the skill
                skillProperty.SetValue(_player.Skills, currentValue + 1);
                
                // Decrease skill points
                _player.SkillPoints--;
                
                // Refresh the UI
                OnPropertyChanged(nameof(_player.SkillPoints));
            }
        }
    }

    private void OnFinishClicked(object sender, EventArgs e)
    {
       
        Close();
    }
}
