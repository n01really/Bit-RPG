using Bit_RPG.Char;
using Bit_RPG.Jobs;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Collections.Generic;
using System.Linq;

namespace Bit_RPG;

public partial class QuestsPopup : Popup
{
    public List<QuestModel> PlayerQuests { get; set; }
    private Player _player;

    public QuestsPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        
        // Get all quests and filter by player's job and rank
        var allQuests = Quests.GetAvailableQuests();
        
        if (player.Jobb != null && !string.IsNullOrEmpty(player.Jobb.Name))
        {
            var currentRank = player.Jobb.Rank;
            var nextRank = currentRank == JobRank.S ? JobRank.S : (JobRank)((int)currentRank + 1);
            
            // Filter quests: must match job name AND be current rank or one rank above
            PlayerQuests = allQuests
                .Where(q => q.JobName == player.Jobb.Name && 
                           (q.RequiredRank == currentRank || q.RequiredRank == nextRank))
                .ToList();
        }
        else
        {
            PlayerQuests = new List<QuestModel>();
        }
        
        BindingContext = this;
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
            _player.ActiveQuests.Add(quest);
            quest.IsAccepted = true;

            await Application.Current.MainPage.DisplayAlert("Quest Accepted!", 
                $"You have accepted: {quest.Name}", "OK");
        }
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
