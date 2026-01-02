using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class CraftersPopup : Popup
{
    private Player _player;

    public CraftersPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        PlayerGoldLabel.Text = $"Gold: {_player.Money}";
        SkillsLabel.Text = $"Smithing: {_player.Skills.Smithing} | Alchemy: {_player.Skills.Alchemy} | Enchanting: {_player.Skills.Enchanting}";
    }

    private async void OnCommissionIronSwordClicked(object sender, EventArgs e)
    {
        int cost = 50;
        
        if (_player.Money < cost)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Funds",
                $"You need {cost} gold to commission an Iron Sword. You have {_player.Money} gold.",
                "OK");
            return;
        }

        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Commission Iron Sword",
            $"Commission an Iron Sword for {cost} gold?",
            "Yes",
            "No");

        if (confirm)
        {
            _player.Money -= cost;
            UpdateInfo();
            await Application.Current.MainPage.DisplayAlert(
                "Commission Complete",
                "The blacksmith has crafted an Iron Sword for you! (This item will be added to your inventory in a future update)",
                "OK");
        }
    }

    private async void OnCommissionIronArmorClicked(object sender, EventArgs e)
    {
        int cost = 80;
        
        if (_player.Money < cost)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Insufficient Funds",
                $"You need {cost} gold to commission Iron Armor. You have {_player.Money} gold.",
                "OK");
            return;
        }

        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Commission Iron Armor",
            $"Commission Iron Armor for {cost} gold?",
            "Yes",
            "No");

        if (confirm)
        {
            _player.Money -= cost;
            UpdateInfo();
            await Application.Current.MainPage.DisplayAlert(
                "Commission Complete",
                "The blacksmith has crafted Iron Armor for you! (This item will be added to your inventory in a future update)",
                "OK");
        }
    }

    private async void OnCraftingClicked(object sender, EventArgs e)
    {
        if (_player.Skills.Smithing < 10)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Skill Too Low",
                "You need Smithing level 10 to start crafting. Train your Smithing skill first!",
                "OK");
            return;
        }

        Close();
        var craftingPopup = new Popups.CraftingPopup(_player, "Smithing");
        await Application.Current.MainPage.ShowPopupAsync(craftingPopup);
    }

    private async void OnTrainCraftingSkillsClicked(object sender, EventArgs e)
    {
        Close();
        var craftingTrainingPopup = new CraftingTrainingPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(craftingTrainingPopup);
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
