using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class SmithyPopup : Popup
{
    private Player _player;

    public SmithyPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        PlayerGoldLabel.Text = $"Gold: {_player.Money}";
        SmithingSkillLabel.Text = $"Smithing Skill: {_player.Skills.Smithing}/100";
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
        string craftingOptions = "Crafting Options:\n\n";
        
        if (_player.Skills.Smithing >= 10)
            craftingOptions += "• Iron Dagger (Smithing 10) - Cost: 20 gold\n";
        if (_player.Skills.Smithing >= 25)
            craftingOptions += "• Iron Sword (Smithing 25) - Cost: 30 gold\n";
        if (_player.Skills.Smithing >= 40)
            craftingOptions += "• Steel Sword (Smithing 40) - Cost: 60 gold\n";
        if (_player.Skills.Smithing >= 30)
            craftingOptions += "• Iron Armor (Smithing 30) - Cost: 50 gold\n";
        if (_player.Skills.Smithing >= 50)
            craftingOptions += "• Steel Armor (Smithing 50) - Cost: 100 gold\n";

        if (craftingOptions == "Crafting Options:\n\n")
            craftingOptions += "Your smithing skill is too low. Train more to unlock crafting recipes!";

        await Application.Current.MainPage.DisplayAlert(
            "Crafting",
            craftingOptions + "\n(Full crafting system coming in a future update)",
            "OK");
    }

    private async void OnTrainSmithingClicked(object sender, EventArgs e)
    {
        if (_player.SkillPoints <= 0)
        {
            await Application.Current.MainPage.DisplayAlert(
                "No Skill Points",
                "You don't have any skill points to spend. Level up to gain more skill points!",
                "OK");
            return;
        }

        if (_player.Skills.Smithing >= 100)
        {
            await Application.Current.MainPage.DisplayAlert(
                "Max Level",
                "Your Smithing skill is already at maximum level!",
                "OK");
            return;
        }

        bool confirm = await Application.Current.MainPage.DisplayAlert(
            "Train Smithing",
            $"Spend 1 skill point to increase Smithing from {_player.Skills.Smithing} to {_player.Skills.Smithing + 1}?",
            "Yes",
            "No");

        if (confirm)
        {
            _player.Skills.Smithing++;
            _player.SkillPoints--;
            UpdateInfo();
            
            await Application.Current.MainPage.DisplayAlert(
                "Training Complete",
                $"Your Smithing skill increased to {_player.Skills.Smithing}!",
                "OK");
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
