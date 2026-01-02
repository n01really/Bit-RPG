using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;
using System.Linq;
using Microsoft.Maui.Controls.Shapes;

namespace Bit_RPG;

public partial class GuildHallPopup : Popup
{
    private Player _player;

    public GuildHallPopup(Player player)
    {
        InitializeComponent();
        _player = player;
        LoadGuildInfo();
    }

    private void LoadGuildInfo()
    {
        if (_player.Jobb == null)
        {
            TitleLabel.Text = "No Guild";
            return;
        }

        TitleLabel.Text = $"??? {_player.Jobb.Name} Hall";

        if (_player.Jobb.GuildMaster != null)
        {
            GuildMasterName.Text = _player.Jobb.GuildMaster.Name;
            GuildMasterInfo.Text = $"{_player.Jobb.GuildMaster.Gender}, {_player.Jobb.GuildMaster.Age} years old, {_player.Jobb.GuildMaster.Race}";
        }
        else
        {
            GuildMasterName.Text = "Unknown";
            GuildMasterInfo.Text = "No information available";
        }

        LoadGuildMembers();
    }

    private void LoadGuildMembers()
    {
        GuildMembersContainer.Children.Clear();

        if (_player.Jobb.GuildMembers != null && _player.Jobb.GuildMembers.Count > 0)
        {
            foreach (var member in _player.Jobb.GuildMembers)
            {
                var memberBorder = new Border
                {
                    Stroke = Color.FromArgb("#E0E0E0"),
                    StrokeThickness = 1,
                    Padding = 12,
                    BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark 
                        ? Color.FromArgb("#2A2A2A") 
                        : Color.FromArgb("#F9F9F9"),
                    Margin = new Thickness(0, 0, 0, 8),
                    StrokeShape = new RoundRectangle { CornerRadius = 8 }
                };

                var memberLayout = new VerticalStackLayout { Spacing = 6 };
                
                memberLayout.Children.Add(new Label 
                { 
                    Text = member.Name, 
                    FontSize = 14, 
                    FontAttributes = FontAttributes.Bold 
                });
                
                memberLayout.Children.Add(new Label 
                { 
                    Text = $"{member.Gender}, {member.Age} years old, {member.Race}", 
                    FontSize = 12, 
                    TextColor = Colors.Gray 
                });

                var talkButton = new Button
                {
                    Text = "Talk",
                    FontSize = 13,
                    HeightRequest = 40,
                    CornerRadius = 6,
                    Margin = new Thickness(0, 6, 0, 0)
                };
                
                var currentMember = member;
                talkButton.Clicked += (s, e) => OnTalkToMemberClicked(currentMember);

                memberLayout.Children.Add(talkButton);
                memberBorder.Content = memberLayout;
                GuildMembersContainer.Children.Add(memberBorder);
            }
        }
        else
        {
            var emptyBorder = new Border
            {
                Stroke = Color.FromArgb("#E0E0E0"),
                StrokeThickness = 1,
                Padding = 20,
                Margin = new Thickness(0, 0, 0, 8),
                BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark 
                    ? Color.FromArgb("#2A2A2A") 
                    : Color.FromArgb("#F9F9F9"),
                StrokeShape = new RoundRectangle { CornerRadius = 8 }
            };
            
            emptyBorder.Content = new Label 
            { 
                Text = "The guild hall seems quiet today. No other members are around.", 
                FontSize = 13, 
                TextColor = Colors.Gray,
                HorizontalOptions = LayoutOptions.Center
            };
            
            GuildMembersContainer.Children.Add(emptyBorder);
        }
    }

    private async void OnTalkToGuildMasterClicked(object sender, EventArgs e)
    {
        if (_player.Jobb?.GuildMaster != null)
        {
            string greeting = GetGuildMasterGreeting();
            await Application.Current.MainPage.DisplayAlert(
                $"Guild Master {_player.Jobb.GuildMaster.Name}",
                greeting,
                "OK");
        }
    }

    private async void OnTalkToMemberClicked(WorldNPC member)
    {
        string greeting = GetMemberGreeting(member);
        await Application.Current.MainPage.DisplayAlert(
            member.Name,
            greeting,
            "OK");
    }

    private async void OnViewQuestsClicked(object sender, EventArgs e)
    {
        // Close this popup and open the Quests popup
        Close();
        var questsPopup = new QuestsPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(questsPopup);
    }

    private string GetGuildMasterGreeting()
    {
        var greetings = _player.Jobb.Name switch
        {
            "Adventurers Guild" => new[]
            {
                $"Welcome, {_player.PlayerName}. Ready for your next adventure?",
                "The path of an adventurer is never easy, but it's always rewarding.",
                "I've heard good things about your work. Keep it up!",
                "Remember, teamwork makes the dream work. Don't be afraid to seek help from your fellow adventurers.",
                "There are always new quests on the board. Check them out when you have time."
            },
            "Blacksmiths Guild" => new[]
            {
                $"Ah, {_player.PlayerName}. How goes the forge work?",
                "The strongest blade is forged through patience and skill.",
                "Your craftsmanship is improving. I'm impressed.",
                "Never forget: quality over quantity. A master smith takes their time.",
                "We have orders coming in. Check the quest board for commissioned work."
            },
            "Mages Guild" => new[]
            {
                $"Greetings, {_player.PlayerName}. Your magical studies progress well?",
                "Magic is both an art and a science. Master both, and you'll go far.",
                "I sense great potential in you. Continue your studies diligently.",
                "The arcane arts require discipline and focus. Do not rush your learning.",
                "There are magical tasks that need attending to. Visit the quest board."
            },
            "Thieves Guild" => new[]
            {
                $"{_player.PlayerName}, good to see you're still in one piece.",
                "Remember: a good thief is never seen, never heard.",
                "You're becoming quite skilled. Just don't get cocky.",
                "The shadows are your ally. Use them wisely.",
                "I've got some... opportunities... posted on the board. Interested?"
            },
            _ => new[] { "Hello there." }
        };

        var random = new Random();
        return greetings[random.Next(greetings.Length)];
    }

    private string GetMemberGreeting(WorldNPC member)
    {
        var greetings = new[]
        {
            $"Hey {_player.PlayerName}! How's it going?",
            "Good to see a friendly face around here.",
            "Want to team up sometime?",
            "I've been working hard lately. How about you?",
            "The guild master has been pushing us pretty hard, hasn't he?",
            "Nice weather we're having, don't you think?",
            "Have you checked the quest board? Some interesting work there.",
            "I just finished a tough quest. The reward was worth it though!",
            "Training has been intense, but I can feel myself getting stronger.",
            "This guild is really helping me improve my skills."
        };

        var random = new Random();
        return greetings[random.Next(greetings.Length)];
    }

    private async void OnTrainingClicked(object sender, EventArgs e)
    {
        Close();
        var trainingPopup = new TrainingPopup(_player);
        await Application.Current.MainPage.ShowPopupAsync(trainingPopup);
    }

    private void OnCloseClicked(object sender, EventArgs e)
    {
        Close();
    }
}
