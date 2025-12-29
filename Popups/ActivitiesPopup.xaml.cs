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
        if (_player.Jobb == null)
        {
            await Application.Current.MainPage.DisplayAlert(
                "No Guild Membership", 
                "You must join a guild before you can visit the guild hall. Visit the Jobs menu to join a guild.", 
                "OK");
            return;
        }

        Close();
        var guildHallPopup = new GuildHallPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(guildHallPopup);
    }

    private async void OnSmithyClicked(object sender, EventArgs e)
    {
        Close();
        var smithyPopup = new SmithyPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(smithyPopup);
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
