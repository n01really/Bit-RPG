namespace Bit_RPG;
using Bit_RPG.Char;
using CommunityToolkit.Maui.Views;

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