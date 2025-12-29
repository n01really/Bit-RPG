using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class ActivitiesPopup : Popup
{
    private Player _player;

    public ActivitiesPopup(Player player)
    {
        InitializeComponent();
        _player = player;
    }

    private async void OnMarketClicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.DisplayAlert(
            "Market", 
            "The market feature is coming soon!", 
            "OK");
    }

    private async void OnGuildHallClicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.DisplayAlert(
            "Guild Hall", 
            "The guild hall feature is coming soon! You'll be able to meet guildmates, talk to the guild master, and train your skills.", 
            "OK");
    }

    private async void OnSmithyClicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.DisplayAlert(
            "Smithy", 
            "The smithy feature is coming soon! You'll be able to commission armor and weapons, craft them yourself, and train your smithing skill.", 
            "OK");
    }

    private async void OnTravelClicked(object sender, EventArgs e)
    {
        await Application.Current.MainPage.DisplayAlert(
            "Travel", 
            "The travel feature is coming soon!", 
            "OK");
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
