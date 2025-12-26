using Bit_RPG.Char;
using Bit_RPG.Jobs;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class JobsPopup : Popup
{
    private Player _player;

    public JobsPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        BindingContext = player;
        
        if (player.Jobb != null)
        {
            CurrentJobInfo.IsVisible = true;
            RankProgress.Text = $"Progress: {player.Jobb.GetRankProgressText()}\n{player.Jobb.GetRankUpRequirementsText(player.Skills)}";
        }
        else
        {
            CurrentJobInfo.IsVisible = false;
        }
    }

    private void OnAdventurersGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb != null && _player.Jobb.Name == "Adventurers Guild")
        {
            Application.Current.MainPage.DisplayAlert("Already Joined", 
                "You are already a member of the Adventurers Guild.", "OK");
            return;
        }

        _player.Jobb = new Job 
        { 
            Name = "Adventurers Guild",
            Description = "Take on quests and explore dangerous dungeons to earn rewards and fame."
        };
        Close();
    }

    private void OnBlacksmithsGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb != null && _player.Jobb.Name == "Blacksmiths Guild")
        {
            Application.Current.MainPage.DisplayAlert("Already Joined", 
                "You are already a member of the Blacksmiths Guild.", "OK");
            return;
        }

        _player.Jobb = new Job 
        { 
            Name = "Blacksmiths Guild",
            Description = "Craft and repair weapons and armor for adventurers and townsfolk."
        };
        Close();
    }

    private void OnMagesGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb != null && _player.Jobb.Name == "Mages Guild")
        {
            Application.Current.MainPage.DisplayAlert("Already Joined", 
                "You are already a member of the Mages Guild.", "OK");
            return;
        }

        _player.Jobb = new Job 
        { 
            Name = "Mages Guild",
            Description = "Study and practice the arcane arts, offering magical services to those in need."
        };
        Close();
    }

    private void OnThievesGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb != null && _player.Jobb.Name == "Thieves Guild")
        {
            Application.Current.MainPage.DisplayAlert("Already Joined", 
                "You are already a member of the Thieves Guild.", "OK");
            return;
        }

        _player.Jobb = new Job 
        { 
            Name = "Thieves Guild",
            Description = "Engage in stealthy activities, from pickpocketing to high-stakes heists."
        };
        Close();
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
