using Bit_RPG.Services;
using Bit_RPG.Models;
using Bit_RPG.Events;

namespace Bit_RPG
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CheckSaveFile();
        }

        private void CheckSaveFile()
        {
            LoadGameBtn.IsEnabled = SaveService.SaveFileExists();
        }

        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CharacterCreationPage());
        }

        private async void OnLoadGameClicked(object sender, EventArgs e)
        {
            try
            {
                var gameSave = await SaveService.LoadGameAsync();
                
                if (gameSave == null)
                {
                    await DisplayAlert("Error", "Failed to load save file", "OK");
                    return;
                }

                var loadedGamePage = new GamePage(gameSave);
                await Navigation.PushAsync(loadedGamePage);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load game: {ex.Message}", "OK");
            }
        }
    }
}
