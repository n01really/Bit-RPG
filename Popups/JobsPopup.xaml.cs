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
        UpdateJobVisibility();
    }

    private void UpdateJobVisibility()
    {
        if (_player.Jobb != null)
        {
            AdventurersGuildSection.IsVisible = _player.Jobb.Name == "Adventurers Guild";
            BlacksmithsGuildSection.IsVisible = _player.Jobb.Name == "Blacksmiths Guild";
            MagesGuildSection.IsVisible = _player.Jobb.Name == "Mages Guild";
            ThievesGuildSection.IsVisible = _player.Jobb.Name == "Thieves Guild";

            if (_player.Jobb.Name == "Adventurers Guild")
                AdventurersGuildButton.Text = "Quit Job";
            else if (_player.Jobb.Name == "Blacksmiths Guild")
                BlacksmithsGuildButton.Text = "Quit Job";
            else if (_player.Jobb.Name == "Mages Guild")
                MagesGuildButton.Text = "Quit Job";
            else if (_player.Jobb.Name == "Thieves Guild")
                ThievesGuildButton.Text = "Quit Job";
        }
        else
        {
            AdventurersGuildSection.IsVisible = true;
            BlacksmithsGuildSection.IsVisible = true;
            MagesGuildSection.IsVisible = true;
            ThievesGuildSection.IsVisible = true;
        }
    }

    private void OnAdventurersGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb?.Name == "Adventurers Guild")
        {
            _player.Jobb = null;
        }
        else
        {
            _player.Jobb = new Job 
            { 
                Name = "Adventurers Guild",
                Description = "Take on quests and explore dangerous dungeons to earn rewards and fame."
            };
        }
        Close();
    }

    private void OnBlacksmithsGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb?.Name == "Blacksmiths Guild")
        {
            _player.Jobb = null;
        }
        else
        {
            _player.Jobb = new Job 
            { 
                Name = "Blacksmiths Guild",
                Description = "Craft and repair weapons and armor for adventurers and townsfolk."
            };
        }
        Close();
    }

    private void OnMagesGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb?.Name == "Mages Guild")
        {
            _player.Jobb = null;
        }
        else
        {
            _player.Jobb = new Job 
            { 
                Name = "Mages Guild",
                Description = "Study and practice the arcane arts, offering magical services to those in need."
            };
        }
        Close();
    }

    private void OnThievesGuildClicked(object sender, EventArgs e)
    {
        if (_player.Jobb?.Name == "Thieves Guild")
        {
            _player.Jobb = null;
        }
        else
        {
            _player.Jobb = new Job 
            { 
                Name = "Thieves Guild",
                Description = "Engage in stealthy activities, from pickpocketing to high-stakes heists."
            };
        }
        Close();
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
