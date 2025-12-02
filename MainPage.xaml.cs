namespace Bit_RPG
{
    public partial class MainPage : ContentPage
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

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            Week = 1;
            Event = "this is a placeholder until n01really creates a event backend";
            EventLog = Event;
        }


        private void OnForwardGameClicked(object sender, EventArgs e)
        {
            Week++;
            EventLog += $"\n{Event}";
            SemanticScreenReader.Announce($"Week {Week}");
        }
    }
}
