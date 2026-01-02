using Bit_RPG.Char;
using Bit_RPG.Popups;
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
        if (!_player.TrySpendActionPoints(1))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Action Points", 
                _player.ActionPoints == 0 ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." : "You need at least 1 AP to visit the market.",
                "OK");
            return;
        }

        Close();
        var marketPopup = new Popups.MarketPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(marketPopup);
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

        if (!_player.TrySpendActionPoints(1))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Action Points", 
                _player.ActionPoints == 0 ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." : "You need at least 1 AP to visit the guild hall.",
                "OK");
            return;
        }

        Close();
        var guildHallPopup = new GuildHallPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(guildHallPopup);
    }

    private async void OnCraftersClicked(object sender, EventArgs e)
    {
        if (!_player.TrySpendActionPoints(1))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Action Points", 
                _player.ActionPoints == 0 ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." : "You need at least 1 AP to visit the crafters.",
                "OK");
            return;
        }

        Close();
        var craftersPopup = new SmithyPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(craftersPopup);
    }

    private async void OnTravelClicked(object sender, EventArgs e)
    {
        Close();
        var travelPopup = new TravelPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(travelPopup);
    }

    private async void OnApothecaryClicked(object sender, EventArgs e)
    {
        if (!_player.TrySpendActionPoints(1))
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Action Points", 
                _player.ActionPoints == 0 ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." : "You need at least 1 AP to visit the apothecary.",
                "OK");
            return;
        }

        if (_player.Skills.Alchemy < 10)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Skill Too Low",
                "You need Alchemy level 10 to brew potions. Train your Alchemy skill at the Crafters Guild first!",
                "OK");
            return;
        }

        Close();
        var craftingPopup = new Popups.CraftingPopup(_player, "Alchemy");
        await Application.Current.MainPage.ShowPopupAsync(craftingPopup);
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
