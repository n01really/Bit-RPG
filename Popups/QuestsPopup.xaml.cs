using Bit_RPG.Char;
using Bit_RPG.Jobs;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bit_RPG;

public partial class QuestsPopup : Popup, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private ObservableCollection<QuestModel> _availableQuests;
    public ObservableCollection<QuestModel> AvailableQuests
    {
        get => _availableQuests;
        set
        {
            _availableQuests = value;
            OnPropertyChanged();
        }
    }

    private ObservableCollection<QuestModel> _acceptedQuests;
    public ObservableCollection<QuestModel> AcceptedQuests
    {
        get => _acceptedQuests;
        set
        {
            _acceptedQuests = value;
            OnPropertyChanged();
        }
    }

    private Player _player;

    public QuestsPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        
        LoadQuests();
        
        BindingContext = this;
    }

    private void LoadQuests()
    {
        // Get all quests and filter by player's job
        var allQuests = Quests.GetAvailableQuests();
        
        List<QuestModel> playerJobQuests;
        if (_player.Jobb != null && !string.IsNullOrEmpty(_player.Jobb.Name))
        {
            playerJobQuests = allQuests.Where(q => q.JobName == _player.Jobb.Name).ToList();
        }
        else
        {
            playerJobQuests = new List<QuestModel>();
        }

        // Separate into available and accepted quests
        var acceptedQuestNames = _player.ActiveQuests.Select(q => q.Name).ToHashSet();
        
        AvailableQuests = new ObservableCollection<QuestModel>(
            playerJobQuests.Where(q => !acceptedQuestNames.Contains(q.Name)).ToList()
        );
        
        AcceptedQuests = new ObservableCollection<QuestModel>(_player.ActiveQuests);
    }

    private async void OnAcceptQuestClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is QuestModel quest)
        {
            // Check if quest is already accepted
            if (_player.ActiveQuests.Any(q => q.Name == quest.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Quest Already Accepted", 
                    $"You have already accepted the quest: {quest.Name}", "OK");
                return;
            }

            // Add quest to player's active quests
            _player.ActiveQuests.Add(quest);
            quest.IsAccepted = true;

            // Update the UI
            AvailableQuests.Remove(quest);
            AcceptedQuests.Add(quest);

            await Application.Current.MainPage.DisplayAlert("Quest Accepted!", 
                $"You have accepted: {quest.Name}", "OK");
        }
    }

    private async void OnCancelQuestClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is QuestModel quest)
        {
            bool confirm = await Application.Current.MainPage.DisplayAlert(
                "Cancel Quest", 
                $"Are you sure you want to cancel: {quest.Name}?", 
                "Yes", 
                "No");

            if (confirm)
            {
                // Remove quest from player's active quests
                _player.ActiveQuests.Remove(quest);
                quest.IsAccepted = false;

                // Update the UI
                AcceptedQuests.Remove(quest);
                AvailableQuests.Add(quest);

                await Application.Current.MainPage.DisplayAlert("Quest Cancelled", 
                    $"You have cancelled: {quest.Name}", "OK");
            }
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
