using Bit_RPG.Char;
using Bit_RPG.Models;
using Bit_RPG.World;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG.Popups;

public partial class TravelPopup : Popup
{
    private Player _player;

    public TravelPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        LoadDestinations();
        UpdateCurrentLocationDisplay();
    }

    private void LoadDestinations()
    {
        var destinations = TravelSystem.GetAvailableDestinations(_player);
        DestinationsCollection.ItemsSource = destinations;
    }

    private void UpdateCurrentLocationDisplay()
    {
        if (_player.CurrentLocation != null)
        {
            string locationType = _player.CurrentLocation.Type.ToString();
            string locationName = _player.CurrentLocation.Name;
            string country = string.IsNullOrEmpty(_player.CurrentLocation.Country) ? "" : $" in {_player.CurrentLocation.Country}";
            
            CurrentLocationLabel.Text = $"{locationName}, {locationType}{country}";
        }
        else
        {
            CurrentLocationLabel.Text = "Unknown Location";
        }

        APLabel.Text = $"Action Points: {_player.ActionPoints}/{Player.MaxActionPoints}";
    }

    private async void OnDestinationTapped(object sender, EventArgs e)
    {
        if (sender is Border border && border.BindingContext is TravelDestination destination)
        {
            // Check if player has enough AP
            if (_player.ActionPoints < destination.APCost)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Insufficient Action Points",
                    $"You need {destination.APCost} AP to travel to {destination.Name}, but you only have {_player.ActionPoints} AP.",
                    "OK");
                return;
            }

            // Confirm travel
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Confirm Travel",
                $"Travel to {destination.Name}?\n\nCost: {destination.APCost} AP\nRemaining AP: {_player.ActionPoints - destination.APCost}",
                "Travel",
                "Cancel");

            if (confirm)
            {
                bool success = TravelSystem.TravelTo(_player, destination);
                
                if (success)
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Travel Complete",
                        $"You have arrived at {destination.Name}!",
                        "OK");
                    
                    UpdateCurrentLocationDisplay();
                    LoadDestinations();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(
                        "Travel Failed",
                        "Unable to complete travel. Please try again.",
                        "OK");
                }
            }
        }
    }

    private void OnRefreshClicked(object sender, EventArgs e)
    {
        LoadDestinations();
        UpdateCurrentLocationDisplay();
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
