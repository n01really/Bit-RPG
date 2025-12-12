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
        Week = 1;
        
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
        
        Event = $"it has been 300 Years Since the Dark Lord Death, You are {Player.PlayerName}, a {Player.Race} you studied to become a {Player.Class}. " +
            $"At the age of {Player.Age}, you decided to move to a new Town to start a new life. " +
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
        Week = gameSave.CurrentWeek;
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
            IsStormActive = gameSave.CurrentEvents.IsStormActive
        };

        Event = $"\n\nGame Loaded - Week {Week}";
    }
    
    private async void OnForwardGameClicked(object sender, EventArgs e)
    {
        Week++;
        
        var worldEvent = ActiveWorldEvents.ProcessContinueClick(_currentEvents);
        
        if (Player.ActiveQuests != null && Player.ActiveQuests.Any())
        {
            var completedQuests = Player.ActiveQuests.ToList();
            
            foreach (var quest in completedQuests)
            {
                Quests.CompleteQuest(quest, Player);
                Event = $"\nQuest Completed: {quest.Name}!\nRewards: {quest.Reward}";
                EventLog += $"\n{Event}";
            }
            
            Player.ActiveQuests.Clear();
        }
        
        if (worldEvent != null)
        {
            Event = $"\n\n{worldEvent.GetFormattedText()}";
            EventLog += Event;
        }
        else if (!Player.ActiveQuests?.Any() ?? true)
        {
            Event = $"\nWeek {Week}: Nothing eventful happened this week.";
            EventLog += Event;
        }
        
        if (_currentEvents.HasActiveEvent())
        {
            string activeEventStatus = $"\n[Active: {EventPicker.GetEventSummary(_currentEvents)}]";
            EventLog += activeEventStatus;
        }
        
        ScrollToBottom();
        
        SemanticScreenReader.Announce($"Week {Week}");

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
                    IsStormActive = _currentEvents.IsStormActive
                }
            };

            bool success = await SaveService.SaveGameAsync(gameSave);
            if (success)
            {
                System.Diagnostics.Debug.WriteLine($"Game saved successfully at week {Week}");
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
}