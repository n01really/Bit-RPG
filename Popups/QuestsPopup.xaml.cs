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
        
        // Get all quests and filter by player's job and rank
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
            var currentRank = _player.Jobb.Rank;
            var nextRank = currentRank == JobRank.S ? JobRank.S : (JobRank)((int)currentRank + 1);
            
            // Filter quests: must match job name AND be current rank or one rank above
            playerJobQuests = allQuests
                .Where(q => q.JobName == _player.Jobb.Name && 
                           (q.RequiredRank == currentRank || q.RequiredRank == nextRank))
                .ToList();
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
            // Check if player has enough AP
            if (!_player.TrySpendActionPoints(1))
            {
                await Application.Current.MainPage.DisplayAlert("Insufficient Action Points", 
                    _player.ActionPoints == 0 
                        ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." 
                        : "You need at least 1 AP to accept a quest.", 
                    "OK");
                return;
            }

            // Check if quest is already accepted
            if (_player.ActiveQuests.Any(q => q.Name == quest.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Quest Already Accepted", 
                    $"You have already accepted the quest: {quest.Name}", "OK");
                return;
            }

            // Check if player meets the rank requirement
            var currentRank = _player.Jobb.Rank;
            var nextRank = currentRank == JobRank.S ? JobRank.S : (JobRank)((int)currentRank + 1);
            
            if (quest.RequiredRank > nextRank)
            {
                await Application.Current.MainPage.DisplayAlert("Insufficient Rank", 
                    $"You need to be at least Rank {quest.RequiredRank} to accept this quest. Your current rank is {currentRank}.", "OK");
                return;
            }

            // Add quest to player's active quests
            var playerQuest = new QuestModel(quest.Name, quest.Description, quest.Reward, quest.JobName, quest.RequiredRank);
            playerQuest.IsAccepted = true;
            playerQuest.StartQuestTimer(4); // default 4 week time limit
            _player.ActiveQuests.Add(playerQuest);

            // Update the UI
            AvailableQuests.Remove(quest);
            AcceptedQuests.Add(playerQuest);

            await Application.Current.MainPage.DisplayAlert("Quest Accepted!", 
                $"You have accepted: {quest.Name}\nTime limit: {playerQuest.WeeksRemaining} weeks", "OK");
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
