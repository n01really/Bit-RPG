namespace Bit_RPG;
using Bit_RPG.Char;

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

    public GamePage(Char.Player player)
    {
        InitializeComponent();
        BindingContext = this;
        Player = player;
        Week = 1;
        Event = $"Welcome {player.PlayerName}! Your adventure begins this is a placeholder until n01really makes an event handler";
        EventLog = Event;
    }
    
    private void OnForwardGameClicked(object sender, EventArgs e)
    {
        Week++;
        EventLog += $"\n{Event}";
        SemanticScreenReader.Announce($"Week {Week}");
    }

    private void OnCharacterClicked(object sender, EventArgs e)
    {
        // Placeholder for character page navigation
    }

    private void OnInventoryClicked(object sender, EventArgs e)
    {
        // Placeholder for inventory page navigation
    }

    private void OnJobsClicked(object sender, EventArgs e)
    {
        // Placeholder for jobs page navigation
    }

    private void OnQuestsClicked(object sender, EventArgs e)
    {
        // Placeholder for quests page navigation
    }
}