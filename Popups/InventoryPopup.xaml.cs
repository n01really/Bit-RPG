using Bit_RPG.Char;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Bit_RPG;

public partial class InventoryPopup : Popup
{
    private Player player;
    private ObservableCollection<InventoryItemViewModel> items;

    public InventoryPopup(Player player)
    {
        InitializeComponent();
        this.player = player;
        BindingContext = player;

        items = new ObservableCollection<InventoryItemViewModel>();
        LoadInventory();
        InventoryCollection.ItemsSource = items;
        UpdateEquippedLabels();
    }

    private void LoadInventory()
    {
        items.Clear();
        foreach (var item in player.Inventory)
        {
            items.Add(new InventoryItemViewModel(item, player.InventoryManager));
        }
    }

    private void UpdateEquippedLabels()
    {
        EquippedWeaponLabel.Text = player.InventoryManager.EquippedWeapon?.Name ?? "None";
        EquippedArmorLabel.Text = player.InventoryManager.EquippedArmor?.Name ?? "None";
    }

    private async void OnItemActionClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is InventoryItemViewModel itemViewModel)
        {
            var item = itemViewModel.Item;

            if (item is WeaponModel weapon)
            {
                if (player.InventoryManager.EquippedWeapon == weapon)
                {
                    player.InventoryManager.UnequipWeapon();
                    await DisplayAlert("Unequipped", $"You unequipped {weapon.Name}", "OK");
                }
                else
                {
                    player.InventoryManager.EquipWeapon(weapon);
                    await DisplayAlert("Equipped", $"You equipped {weapon.Name}!\nDamage: +{weapon.Damage}", "OK");
                }
            }
            else if (item is ArmorModel armor)
            {
                if (player.InventoryManager.EquippedArmor == armor)
                {
                    player.InventoryManager.UnequipArmor();
                    await DisplayAlert("Unequipped", $"You unequipped {armor.Name}", "OK");
                }
                else
                {
                    player.InventoryManager.EquipArmor(armor);
                    await DisplayAlert("Equipped", $"You equipped {armor.Name}!\nDefense: +{armor.Defense}", "OK");
                }
            }

            LoadInventory();
            UpdateEquippedLabels();
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

public class InventoryItemViewModel : INotifyPropertyChanged
{
    public ItemModel Item { get; }
    private Inventory inventory;

    public InventoryItemViewModel(ItemModel item, Inventory inventory)
    {
        Item = item;
        this.inventory = inventory;
    }

    public string Name => Item.Name;

    public string ItemDetails
    {
        get
        {
            return Item switch
            {
                WeaponModel weapon => $"Weapon | Damage: {weapon.Damage} | Speed: {weapon.AttackSpeed:F1} | Weight: {weapon.Weight:F1}",
                ArmorModel armor => $"Armor ({armor.Type}) | Defense: {armor.Defense} | Weight: {armor.Weight:F1}",
                IngredientModel ingredient => $"Ingredient | {ingredient.Effect}",
                CraftingItemModel craft => $"Crafting Material | Used in smithy",
                MiscItemModel misc => $"Misc | {misc.Description}",
                _ => $"Weight: {Item.Weight:F1}"
            };
        }
    }

    public bool ShowActionButton => Item is WeaponModel || Item is ArmorModel;

    public bool ShowStatus => Item is WeaponModel weapon && inventory.EquippedWeapon == weapon ||
                             Item is ArmorModel armor && inventory.EquippedArmor == armor;

    public string StatusText => "Equipped";

    public string ActionButtonText
    {
        get
        {
            if (Item is WeaponModel weapon && inventory.EquippedWeapon == weapon)
                return "Unequip";
            if (Item is ArmorModel armor && inventory.EquippedArmor == armor)
                return "Unequip";
            if (Item is WeaponModel || Item is ArmorModel)
                return "Equip";
            return "";
        }
    }

    public Color ActionButtonColor
    {
        get
        {
            if (Item is WeaponModel weapon && inventory.EquippedWeapon == weapon)
                return Colors.DarkGray;
            if (Item is ArmorModel armor && inventory.EquippedArmor == armor)
                return Colors.DarkGray;
            return Colors.Green;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}
