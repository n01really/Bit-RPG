namespace Bit_RPG;
using Bit_RPG.Char;
using Bit_RPG.Jobs;
using Bit_RPG.Events;
using CommunityToolkit.Maui.Views;
using System.Linq;
using Bit_RPG.Models;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Services;

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
    
    private int _year;
    public int Year
    {
        get => _year;
        set
        {
            _year = value;
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

    private CurrentEvents _currentEvents;
    private TownsModels _currentTown;
    private List<NpcData> _generatedNpcs = new List<NpcData>();

    public GamePage(Char.Player player)
    {
        InitializeComponent();
        BindingContext = this;
        Player = player;
        
        // Subscribe to level up event
        Player.LeveledUp += OnPlayerLeveledUp;
        
        Week = 1;
        Year = 301;
        
        _currentEvents = new CurrentEvents();
        ActiveWorldEvents.InitializeWorldEvents(_currentEvents);
        
        // Generate world population at game start
        System.Diagnostics.Debug.WriteLine("Generating world population...");
        WorldPopulation.GenerateWorldPopulation(1000);
        System.Diagnostics.Debug.WriteLine($"World population generated: {WorldPopulation.GetPopulationCount()} NPCs");
        
        HumanNpc humanNames = new HumanNpc();
        _currentTown = new TownsModels
        {
            Name = "Arn",
            Description = "A peaceful town along the Silver River, known for its fishing industry.",
            Mayor = humanNames.GetRandomRulerName(),
            Country = "Eldoria",
            NearbyVillages = new List<string> { "Riverside Hamlet" },
            NearbyCities = new List<string> { "Silverhold" }
        };

        NpcTracker.AddNpc(_generatedNpcs, _currentTown.Mayor, NpcType.Mayor, "Human", _currentTown.Name);
        
        Event = $"The year is {Year} ADE of the Bright Era. it has been 300 years since the death of the darklord." +
            $" You are {Player.PlayerName}, a {Player.Race} you studied to become a {Player.Class}. " +
            $"You have just come of age.At the age of {Player.Age}, you decided to move to a new Town to start a new life. " +
            $"What will you do now?  Will you become a Legendary Adventurer? a Master craftman, the best Mage in the land or a thief feard by the nobles" +
            $"\n\n to start earning money and exp join a guild and do quests" +
            $"\n\nYou have arrived at {_currentTown.Name}, {_currentTown.Description} " +
            $"The town is located in {_currentTown.Country} and is governed by {_currentTown.Mayor}. " +
            $"Nearby cities include: {string.Join(", ", _currentTown.NearbyCities)}. " +
            $"Nearby villages include: {string.Join(", ", _currentTown.NearbyVillages)}.";
        EventLog = Event;

        _ = SaveGameAsync();
    }

    public GamePage(GameSaveModel gameSave)
    {
        InitializeComponent();
        BindingContext = this;
        
        Player = gameSave.Player;
        
        
        Player.LeveledUp += OnPlayerLeveledUp;
        
        Week = gameSave.CurrentWeek;
        Year = gameSave.CurrentYear;
        EventLog = gameSave.EventLog;
        _generatedNpcs = gameSave.GeneratedNpcs ?? new List<NpcData>();
        _currentTown = gameSave.CurrentTown;
        
        // Load world population from save
        if (gameSave.WorldPopulation != null && gameSave.WorldPopulation.Count > 0)
        {
            WorldPopulation.InitializePopulation();
            foreach (var npc in gameSave.WorldPopulation)
            {
                WorldPopulation.AddNPC(npc.Name, npc.Age, npc.Gender, npc.Race, npc.Job, npc.Location);
            }
            System.Diagnostics.Debug.WriteLine($"Loaded world population: {WorldPopulation.GetPopulationCount()} NPCs");
        }
        else
        {
            // Generate if no population exists in save
            System.Diagnostics.Debug.WriteLine("No saved population found, generating new...");
            WorldPopulation.GenerateWorldPopulation(1000);
            System.Diagnostics.Debug.WriteLine($"World population generated: {WorldPopulation.GetPopulationCount()} NPCs");
        }
        
        _currentEvents = new CurrentEvents
        {
            IsWarActive = gameSave.CurrentEvents.IsWarActive,
            IsBorderClosed = gameSave.CurrentEvents.IsBorderClosed,
            IsPlagueActive = gameSave.CurrentEvents.IsPlagueActive,
            IsBanditRaidActive = gameSave.CurrentEvents.IsBanditRaidActive,
            IsFamineActive = gameSave.CurrentEvents.IsFamineActive,
            IsFireActive = gameSave.CurrentEvents.IsFireActive,
            IsEarthquakeActive = gameSave.CurrentEvents.IsEarthquakeActive,
            IsFloodActive = gameSave.CurrentEvents.IsFloodActive,
            isDroughtActive = gameSave.CurrentEvents.IsDroughtActive,
            IsStormActive = gameSave.CurrentEvents.IsStormActive,
            ClickedSinceLastEvent = gameSave.CurrentEvents.ClickedSinceLastEvent,
            ClicksRequiredForEvent = gameSave.CurrentEvents.ClicksRequiredForEvent,
            EventDurationRemaining = gameSave.CurrentEvents.EventDurationRemaining,
            WorldEventChancePercentage = gameSave.CurrentEvents.WorldEventChancePercentage,
            DefaultEventDuration = gameSave.CurrentEvents.DefaultEventDuration
        };

        Event = $"\n\nGame Loaded - Week {Week}, Year {Year} ADE";
    }

    // Handle when player levels up
    private async void OnPlayerLeveledUp(object sender, EventArgs e)
    {
        var popup = new LevelUpPopup(Player);
        await this.ShowPopupAsync(popup);
        
        Event = $"\n\n?? LEVEL UP! You are now level {Player.Level}! You gained 15 skill points!";
        EventLog += Event;
    }
    
    private async void OnForwardGameClicked(object sender, EventArgs e)
    {
        Week++;

        // Add 2 Action Points every week (max 12)
        Player.AddActionPoints(2);

        // Check if a year has passed (52 weeks)
        if (Week > 52)
        {
            Week = 1;
            Year++;
            Player.Age++;
            Event = $"\n\n=== Year {Year} ADE has begun! ===";
            EventLog += Event;
        }
        
        // Process world events and job events (these happen every 4 weeks)
        var events = ActiveWorldEvents.ProcessContinueClick(_currentEvents, Player);
        
        // Always get a weekly event (happens EVERY week)
        var weeklyEvent = WeeklyEvents.GetRandomWeeklyEvent(Player);
        
        if (Player.ActiveQuests != null && Player.ActiveQuests.Any())
        {
            // Copy to avoid modifying collection during iteration
            var questsCopy = Player.ActiveQuests.ToList();

            foreach (var quest in questsCopy)
            {
                // Decrement quest time limit
                quest.TickWeek();

                if (quest.IsCompleted)
                {
                    var completionMessage = Quests.CompleteQuest(quest, Player);
                    Event = completionMessage;
                    EventLog += Event;

                    Player.ActiveQuests.Remove(quest);
                }
                else if (quest.WeeksRemaining <= 0 && quest.IsAccepted && !quest.IsCompleted)
                {
                    // Quest expired
                    quest.IsAccepted = false;
                    Player.ActiveQuests.Remove(quest);

                    Event = $"\nQuest Failed: {quest.Name} has expired.";
                    EventLog += Event;
                }
            }
        }
        
        // Display world/job events if they occurred (excluding weekly events)
        if (events != null && (events.WorldEvent != null || events.JobEvent != null))
        {
            var eventTexts = new List<string>();
            
            if (events.WorldEvent != null)
            {
                eventTexts.Add(events.WorldEvent.GetFormattedText());
            }
            
            if (events.JobEvent != null)
            {
                eventTexts.Add(events.JobEvent.GetFormattedText());
            }
            
            if (eventTexts.Any())
            {
                Event = $"\n\n{string.Join("\n\n", eventTexts)}";
                EventLog += Event;
            }
        }
        
        // Always display the weekly event (without header formatting)
        if (weeklyEvent != null)
        {
            Event = $"\n\n{weeklyEvent.Description}";
            EventLog += Event;
        }
        
        // If no events at all occurred (not even weekly), show the "nothing happened" message
        if ((events == null || !events.HasAnyEvent) && weeklyEvent == null && (!Player.ActiveQuests?.Any() ?? true))
        {
            Event = $"\nWeek {Week}, Year {Year} ADE: Nothing eventful happened this week.";
            EventLog += Event;
        }
        
        if (_currentEvents.HasActiveEvent())
        {
            string eventSummary = EventPicker.GetEventSummary(_currentEvents);
            string weeksRemaining = _currentEvents.EventDurationRemaining > 0 
                ? $" ({_currentEvents.EventDurationRemaining} weeks remaining)" 
                : "";
            string activeEventStatus = $"\n[Active: {eventSummary}{weeksRemaining}]";
            EventLog += activeEventStatus;
        }
        
        ScrollToBottom();
        
        SemanticScreenReader.Announce($"Week {Week}, Year {Year} ADE");

        await SaveGameAsync();
    }

    private async Task SaveGameAsync()
    {
        try
        {
            var gameSave = new GameSaveModel
            {
                SaveDate = DateTime.Now,
                CurrentWeek = Week,
                CurrentYear = Year,
                EventLog = EventLog,
                Player = Player,
                GeneratedNpcs = _generatedNpcs,
                WorldPopulation = WorldPopulation.GetPopulation().ToList(),
                CurrentTown = _currentTown,
                CurrentEvents = new GameEventsData
                {
                    IsWarActive = _currentEvents.IsWarActive,
                    IsBorderClosed = _currentEvents.IsBorderClosed,
                    IsPlagueActive = _currentEvents.IsPlagueActive,
                    IsBanditRaidActive = _currentEvents.IsBanditRaidActive,
                    IsFamineActive = _currentEvents.IsFamineActive,
                    IsFireActive = _currentEvents.IsFireActive,
                    IsEarthquakeActive = _currentEvents.IsEarthquakeActive,
                    IsFloodActive = _currentEvents.IsFloodActive,
                    IsDroughtActive = _currentEvents.isDroughtActive,
                    IsStormActive = _currentEvents.IsStormActive,
                    ClickedSinceLastEvent = _currentEvents.ClickedSinceLastEvent,
                    ClicksRequiredForEvent = _currentEvents.ClicksRequiredForEvent,
                    EventDurationRemaining = _currentEvents.EventDurationRemaining,
                    WorldEventChancePercentage = _currentEvents.WorldEventChancePercentage,
                    DefaultEventDuration = _currentEvents.DefaultEventDuration
                }
            };

            bool success = await SaveService.SaveGameAsync(gameSave);
            if (success)
            {
                System.Diagnostics.Debug.WriteLine($"Game saved successfully at week {Week}, year {Year} ADE");
                System.Diagnostics.Debug.WriteLine($"Saved {gameSave.WorldPopulation.Count} NPCs in world population");
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error saving game: {ex.Message}");
        }
    }

    private async void ScrollToBottom()
    {
        await Task.Delay(100);
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

    private async void OnActivitiesClicked(object sender, EventArgs e)
    {
        var popup = new ActivitiesPopup(Player);
        await this.ShowPopupAsync(popup);
    }
}