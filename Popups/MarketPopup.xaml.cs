using Bit_RPG.Char;
using Bit_RPG.Items;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bit_RPG.Popups;

public partial class MarketPopup : Popup
{
    private Player player;
    private MarketInventory marketInventory;
    private ObservableCollection<MarketItemViewModel> marketItems;
    private ObservableCollection<MarketItemViewModel> playerItems;

    public MarketPopup(Player player)
    {
        InitializeComponent();
        this.player = player;
        BindingContext = player;

        marketInventory = new MarketInventory();
        marketInventory.PopulateMarketInventory();

        marketItems = new ObservableCollection<MarketItemViewModel>();
        playerItems = new ObservableCollection<MarketItemViewModel>();

        LoadMarketItems();
        LoadPlayerItems();

        MarketItemsCollection.ItemsSource = marketItems;
        PlayerItemsCollection.ItemsSource = playerItems;
    }

    private void LoadMarketItems()
    {
        marketItems.Clear();
        foreach (var item in marketInventory.MarketItems)
        {
            marketItems.Add(new MarketItemViewModel(item));
        }
    }

    private void LoadPlayerItems()
    {
        playerItems.Clear();
        foreach (var item in player.Inventory)
        {
            playerItems.Add(new MarketItemViewModel(item));
        }
    }

    private async void OnBuyClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is MarketItemViewModel itemViewModel)
        {
            var item = itemViewModel.Item;
            
            if (player.Money >= item.BaseValue)
            {
                player.Money -= item.BaseValue;
                player.InventoryManager.AddItem(item);
                
                marketItems.Remove(itemViewModel);
                playerItems.Add(itemViewModel);

                await DisplayAlert("Purchase Successful", $"You bought {item.Name} for {item.BaseValue} gold!", "OK");
            }
            else
            {
                await DisplayAlert("Insufficient Funds", $"You need {item.BaseValue} gold to buy this item. You have {player.Money} gold.", "OK");
            }
        }
    }

    private async void OnSellClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is MarketItemViewModel itemViewModel)
        {
            var item = itemViewModel.Item;
            int sellPrice = player.InventoryManager.SellItem(item);
            
            if (sellPrice > 0)
            {
                playerItems.Remove(itemViewModel);
                await DisplayAlert("Item Sold", $"You sold {item.Name} for {sellPrice} gold!", "OK");
            }
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }

    private async Task DisplayAlert(string title, string message, string cancel)
    {
        if (Application.Current?.MainPage != null)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}

public class MarketItemViewModel : INotifyPropertyChanged
{
    public ItemModel Item { get; }

    public MarketItemViewModel(ItemModel item)
    {
        Item = item;
    }

    public string Name => Item.Name;
    public int BaseValue => Item.BaseValue;
    public int SellPrice => (int)(Item.BaseValue * 0.5f);

    public string ItemDetails
    {
        get
        {
            return Item switch
            {
                WeaponModel weapon => $"Weapon | Damage: {weapon.Damage} | Speed: {weapon.AttackSpeed:F1} | Weight: {weapon.Weight:F1}",
                ArmorModel armor => $"Armor ({armor.Type}) | Defense: {armor.Defense} | Weight: {armor.Weight:F1}",
                IngredientModel ingredient => $"Ingredient | {ingredient.Effect} | Weight: {ingredient.Weight:F1}",
                CraftingItemModel craft => $"Crafting Material | Weight: {craft.Weight:F1}",
                PotionModel potion => $"Potion | {potion.Effect} | Weight: {potion.Weight:F1}",
                MiscItemModel misc => $"Misc | {misc.Description}",
                _ => $"Weight: {Item.Weight:F1}"
            };
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
