namespace Bit_RPG;
using Bit_RPG.Char;
using Bit_RPG.Jobs;
using Bit_RPG.Events;
using CommunityToolkit.Maui.Views;
using System.Linq;

public partial class GamePage : ContentPage
{
    private int _week;
    public int Week
    {
        get => _week;
        set
        {
            _week = value;
            OnPropertyChanged();
        }
    }
    
    private string _event;
    public string Event
    {
        get => _event;
        set
        {
            _event = value;
            OnPropertyChanged();
        }
    }

    private string _eventLog;
    public string EventLog
    {
        get => _eventLog;
        set
        {
            _eventLog = value;
            OnPropertyChanged();
        }
    }

    private Char.Player _player;
    public Char.Player Player
    {
        get => _player;
        set
        {
            _player = value;
            OnPropertyChanged();
        }
    }

    // Add CurrentEvents instance
    private CurrentEvents _currentEvents;

    public GamePage(Char.Player player)
    {
        InitializeComponent();
        BindingContext = this;
        Player = player;
        Week = 1;
        
        // Initialize event system
        _currentEvents = new CurrentEvents();
        ActiveWorldEvents.InitializeWorldEvents(_currentEvents);
        
        Event = $"Welcome {player.PlayerName}! Your adventure begins...";
        EventLog = Event;
    }
    
    private void OnForwardGameClicked(object sender, EventArgs e)
    {
        Week++;
        
        // Check for world events every click (will only trigger every 4 clicks)
        var worldEvent = ActiveWorldEvents.ProcessContinueClick(_currentEvents);
        
        // Complete active quests
        if (Player.ActiveQuests != null && Player.ActiveQuests.Any())
        {
            var completedQuests = Player.ActiveQuests.ToList();
            
            foreach (var quest in completedQuests)
            {
                Quests.CompleteQuest(quest, Player);
                Event = $"\nQuest Completed: {quest.Name}!\nRewards: {quest.Reward}";
                EventLog += $"\n{Event}";
            }
            
            // Clear completed quests
            Player.ActiveQuests.Clear();
        }
        
        // Display world event if one was triggered
        if (worldEvent != null)
        {
            Event = $"\n\n{worldEvent.GetFormattedText()}";
            EventLog += Event;
        }
        else if (!Player.ActiveQuests?.Any() ?? true)
        {
            // Only show "nothing happened" if no quests and no world event
            Event = $"\nWeek {Week}: Nothing eventful happened this week.";
            EventLog += Event;
        }
        
        // Display active event status if there is one
        if (_currentEvents.HasActiveEvent())
        {
            string activeEventStatus = $"\n[Active: {EventPicker.GetEventSummary(_currentEvents)}]";
            EventLog += activeEventStatus;
        }
        
        // Scroll to bottom to show latest events
        ScrollToBottom();
        
        SemanticScreenReader.Announce($"Week {Week}");
    }

    private async void ScrollToBottom()
    {
        await Task.Delay(100); // Small delay to ensure UI has updated
        await EventScrollView.ScrollToAsync(0, double.MaxValue, true);
    }

    private async void OnCharacterClicked(object sender, EventArgs e)
    {
        var popup = new CharacterPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        var popup = new InventoryPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    private async void OnJobsClicked(object sender, EventArgs e)
    {
        var popup = new JobsPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    private async void OnQuestsClicked(object sender, EventArgs e)
    {
        var popup = new QuestsPopup(Player);
        await this.ShowPopupAsync(popup);
    }
}