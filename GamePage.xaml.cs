namespace Bit_RPG;
using Bit_RPG.Char;
using Bit_RPG.Jobs;
using Bit_RPG.Events;
using CommunityToolkit.Maui.Views;
using System.Linq;
using Bit_RPG.Models;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Services;
using System.Text;

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

    private const int MAX_EVENT_LINES = 100; // Begränsa till 100 rader för att spara minne

    private string _eventLog;
    public string EventLog
    {
        get => _eventLog;
        set
        {
            if (_eventLog != value)
            {
                _eventLog = value;
                
                // Trim by line count to keep memory usage low
                if (!string.IsNullOrEmpty(_eventLog))
                {
                    var lines = _eventLog.Split('\n');
                    if (lines.Length > MAX_EVENT_LINES)
                    {
                        // Keep only the last MAX_EVENT_LINES
                        var linesToKeep = lines.Skip(lines.Length - MAX_EVENT_LINES).ToArray();
                        _eventLog = "... [Earlier events removed]\n\n" + string.Join("\n", linesToKeep);
                    }
                }
                
                // Ensure UI update happens on main thread
                MainThread.BeginInvokeOnMainThread(() => 
                {
                    OnPropertyChanged();
                });
            }
        }
    }

    // Store only the latest event for saving
    private string _latestEvent;

    private Char.Player _player;
    public Char.Player Player
    {
        get => _player;
        set
        {
            _player = value;
            OnPropertyChanged();
            UpdateXpProgress();
        }
    }

    // XP Progress for progress bar (0.0 to 1.0)
    private double _xpProgress;
    public double XpProgress
    {
        get => _xpProgress;
        set
        {
            _xpProgress = value;
            OnPropertyChanged();
        }
    }

    private CurrentEvents _currentEvents;
    private TownsModels _currentTown;
    private List<NpcData> _generatedNpcs = new List<NpcData>();

    /// <summary>
    /// Constructor for starting a new game with a new player character.
    /// What it does: Initializes the game world, generates NPCs, creates the starting town, and displays the intro text.
    /// What you can change:
    /// - Starting week/year (Week = 1, Year = 301)
    /// - World population size (currently 1000 NPCs)
    /// - Starting town properties (Name, Description, Mayor, etc.)
    /// - Intro text for new games
    /// </summary>
    public GamePage(Char.Player player)
    {
        InitializeComponent();
        BindingContext = this;
        Player = player;
        
        // Subscribe to level up event
        Player.LeveledUp += OnPlayerLeveledUp;
        
        // Subscribe to property changes to update XP progress
        Player.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(Player.Experience) || 
                e.PropertyName == nameof(Player.Level))
            {
                UpdateXpProgress();
            }
        };
        
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
        _latestEvent = Event;

        _ = SaveGameAsync();
    }

    /// <summary>
    /// Constructor for loading a saved game.
    /// What it does: Restores all game state from a GameSaveModel including player, world events, NPCs, and town data.
    /// What you can change:
    /// - How the saved EventLog is displayed when loading (currently shows only the latest event)
    /// - World population generation fallback size (currently 1000 if no save data exists)
    /// - The "Game Loaded" message format
    /// </summary>
    public GamePage(GameSaveModel gameSave)
    {
        InitializeComponent();
        BindingContext = this;
        
        Player = gameSave.Player;
        
        Player.LeveledUp += OnPlayerLeveledUp;
        
        // Subscribe to property changes to update XP progress
        Player.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(Player.Experience) || 
                e.PropertyName == nameof(Player.Level))
            {
                UpdateXpProgress();
            }
        };
        
        Week = gameSave.CurrentWeek;
        Year = gameSave.CurrentYear;
        
        // Load only the latest event from save
        if (!string.IsNullOrEmpty(gameSave.EventLog))
        {
            EventLog = gameSave.EventLog;
            _latestEvent = gameSave.EventLog;
        }
        
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
        
        UpdateXpProgress();
    }

    /// <summary>
    /// Calculates and updates the XP progress bar value (0.0 to 1.0).
    /// What it does: Converts current XP and XP needed for next level into a percentage for the progress bar.
    /// What you can change:
    /// - Nothing really, this is simple math calculation
    /// - Could add validation or logging if needed
    /// </summary>
    private void UpdateXpProgress()
    {
        if (Player != null && Player.ExperienceForNextLevel > 0)
        {
            XpProgress = (double)Player.Experience / Player.ExperienceForNextLevel;
        }
        else
        {
            XpProgress = 0;
        }
    }

    /// <summary>
    /// Event handler triggered when player levels up.
    /// What it does: Shows a level up popup and adds a level up message to the event log.
    /// What you can change:
    /// - The level up message format (currently includes ? emoji and skill points)
    /// - Could add sound effects or animations
    /// - Could show different messages based on level reached
    /// </summary>
    private async void OnPlayerLeveledUp(object sender, EventArgs e)
    {
        var popup = new LevelUpPopup(Player);
        await this.ShowPopupAsync(popup);
        
        Event = $"\n\n? LEVEL UP! You are now level {Player.Level}! You gained 5 skill points!";
        _latestEvent = Event;
        
        // Null-safe EventLog update
        if (EventLog != null)
        {
            EventLog += Event;
        }
        else
        {
            EventLog = Event;
        }
        
        UpdateXpProgress();
    }
    
    /// <summary>
    /// Main game loop - advances the game by one week when Continue button is clicked.
    /// What it does: 
    /// - Increments week counter
    /// - Adds action points to player (2 per week, max 12)
    /// - Checks for year change (52 weeks = 1 year)
    /// - Processes active quests and checks for completion/expiration
    /// - Generates and displays world events, job events, and weekly events
    /// - Updates event log with all happenings
    /// - Saves the game automatically
    /// What you can change:
    /// - Action points per week (currently 2)
    /// - Weeks per year (currently 52)
    /// - How events are formatted and displayed
    /// - Event generation frequency (world/job events every 4 weeks, weekly events every week)
    /// - Quest expiration handling
    /// </summary>
    private async void OnForwardGameClicked(object sender, EventArgs e)
    {
        Week++;

        // Add 2 Action Points every week (max 12)
        Player.AddActionPoints(2);

        // Use StringBuilder to batch all event updates for THIS week only
        var eventBuilder = new StringBuilder();

        // Check if a year has passed (52 weeks)
        if (Week > 52)
        {
            Week = 1;
            Year++;
            
            // Increment player age properly
            Player.Age = Player.Age + 1;
            OnPropertyChanged(nameof(Player)); // Notify UI of player update
            
            Event = $"\n\n=== Year {Year} ADE has begun! You are now {Player.Age} years old ===";
            eventBuilder.AppendLine(Event);
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
                    eventBuilder.AppendLine(Event);

                    Player.ActiveQuests.Remove(quest);
                }
                else if (quest.WeeksRemaining <= 0 && quest.IsAccepted && !quest.IsCompleted)
                {
                    // Quest expired
                    quest.IsAccepted = false;
                    Player.ActiveQuests.Remove(quest);

                    Event = $"\nQuest Failed: {quest.Name} has expired.";
                    eventBuilder.AppendLine(Event);
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
                eventBuilder.AppendLine(Event);
            }
        }
        
        // Always display the weekly event (without header formatting)
        if (weeklyEvent != null)
        {
            Event = $"\n\n{weeklyEvent.Description}";
            eventBuilder.AppendLine(Event);
        }
        
        // If no events at all occurred (not even weekly), show the "nothing happened" message
        if ((events == null || !events.HasAnyEvent) && weeklyEvent == null && (!Player.ActiveQuests?.Any() ?? true))
        {
            Event = $"\nWeek {Week}, Year {Year} ADE: Nothing eventful happened this week.";
            eventBuilder.AppendLine(Event);
        }
        
        if (_currentEvents.HasActiveEvent())
        {
            string eventSummary = EventPicker.GetEventSummary(_currentEvents);
            string weeksRemaining = _currentEvents.EventDurationRemaining > 0 
                ? $" ({_currentEvents.EventDurationRemaining} weeks remaining)" 
                : "";
            string activeEventStatus = $"\n[Active: {eventSummary}{weeksRemaining}]";
            eventBuilder.AppendLine(activeEventStatus);
        }
        
        // Store this week's events as the latest event
        _latestEvent = eventBuilder.ToString();
        
        // Append to EventLog for display (will be trimmed automatically by property setter)
        EventLog += _latestEvent;
        
        // Update XP progress bar
        UpdateXpProgress();
        
        // Scroll to bottom after UI updates
        await ScrollToBottomAsync();
        
        SemanticScreenReader.Announce($"Week {Week}, Year {Year} ADE");

        await SaveGameAsync();
    }

    /// <summary>
    /// Saves the current game state to disk.
    /// What it does: Creates a GameSaveModel with all current game data and calls SaveService to persist it.
    /// What you can change:
    /// - What data gets saved (currently saves player, NPCs, world population, town, events)
    /// - EventLog saving strategy (currently saves only _latestEvent, not entire log)
    /// - Error handling behavior
    /// - Could add save confirmation messages to user
    /// - Could implement multiple save slots
    /// </summary>
    private async Task SaveGameAsync()
    {
        try
        {
            var gameSave = new GameSaveModel
            {
                SaveDate = DateTime.Now,
                CurrentWeek = Week,
                CurrentYear = Year,
                EventLog = _latestEvent, // Save only the latest event
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

    /// <summary>
    /// Scrolls the event log to the bottom to show the latest events.
    /// What it does: Waits for UI layout, then scrolls the EventScrollView to the bottom.
    /// What you can change:
    /// - Delay time before scrolling (currently 150ms)
    /// - Animation enabled/disabled (currently animated: true)
    /// - Could add option to disable auto-scroll
    /// - Error handling could show user message instead of just logging
    /// </summary>
    private async Task ScrollToBottomAsync()
    {
        // Wait for layout to complete
        await Task.Delay(150);
        
        // Ensure on main thread and handle potential null reference
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            try
            {
                if (EventScrollView != null)
                {
                    await EventScrollView.ScrollToAsync(0, double.MaxValue, animated: true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ScrollToBottom error: {ex.Message}");
            }
        });
    }

    /// <summary>
    /// Opens the character information popup.
    /// What it does: Shows a popup displaying player stats, skills, and attributes.
    /// What you can change:
    /// - The popup type/style (currently CharacterPopup)
    /// - Could add animation or transition effects
    /// </summary>
    private async void OnCharacterClicked(object sender, EventArgs e)
    {
        var popup = new CharacterPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    /// <summary>
    /// Opens the inventory popup.
    /// What it does: Shows a popup displaying player's items and equipment.
    /// What you can change:
    /// - The popup type/style (currently InventoryPopup)
    /// - Could add sorting or filtering options
    /// </summary>
    private async void OnInventoryClicked(object sender, EventArgs e)
    {
        var popup = new InventoryPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    /// <summary>
    /// Opens the jobs/quests popup.
    /// What it does: Shows available jobs and active quests for the player.
    /// What you can change:
    /// - The popup type/style (currently JobsPopup)
    /// - Could add quest filtering or categorization
    /// </summary>
    private async void OnJobsClicked(object sender, EventArgs e)
    {
        var popup = new JobsPopup(Player);
        await this.ShowPopupAsync(popup);
    }

    /// <summary>
    /// Opens the activities popup.
    /// What it does: Shows available activities the player can perform (training, crafting, etc.).
    /// What you can change:
    /// - The popup type/style (currently ActivitiesPopup)
    /// - Could add activity categories or requirements display
    /// </summary>
    private async void OnActivitiesClicked(object sender, EventArgs e)
    {
        var popup = new ActivitiesPopup(Player);
        await this.ShowPopupAsync(popup);
    }
}