using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Models;
using CommunityToolkit.Maui.Views;

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

        TitleLabel.Text = $"{_player.Jobb.Name} Hall";

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

        GuildMembersContainer.Children.Clear();

        if (_player.Jobb.GuildMembers != null && _player.Jobb.GuildMembers.Count > 0)
        {
            foreach (var member in _player.Jobb.GuildMembers)
            {
                var memberBorder = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 1,
                    Padding = 10,
                    BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark 
                        ? Color.FromArgb("#2A2A2A") 
                        : Color.FromArgb("#F5F5F5"),
                    Margin = new Thickness(0, 0, 0, 5)
                };

                var memberLayout = new VerticalStackLayout { Spacing = 3 };
                
                memberLayout.Children.Add(new Label 
                { 
                    Text = member.Name, 
                    FontSize = 13, 
                    FontAttributes = FontAttributes.Bold 
                });
                
                memberLayout.Children.Add(new Label 
                { 
                    Text = $"{member.Gender}, {member.Age} years old", 
                    FontSize = 11, 
                    TextColor = Colors.Gray 
                });

                var talkButton = new Button
                {
                    Text = "Talk",
                    FontSize = 11,
                    Padding = new Thickness(10, 5),
                    Margin = new Thickness(0, 3, 0, 0)
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
            GuildMembersContainer.Children.Add(new Label 
            { 
                Text = "No guild members found.", 
                FontSize = 12, 
                TextColor = Colors.Gray 
            });
        }

        // Add active quest list for this guild (do quests here)
        var playerQuests = _player.ActiveQuests.Where(q => q.JobName == _player.Jobb.Name).ToList();
        var activeLabel = new Label { Text = "Active Quests", FontSize = 18, FontAttributes = FontAttributes.Bold };
        GuildMembersContainer.Children.Add(activeLabel);

        if (playerQuests.Count == 0)
        {
            GuildMembersContainer.Children.Add(new Label { Text = "No active quests for this guild.", FontSize = 12, TextColor = Colors.Gray });
        }
        else
        {
            foreach (var quest in playerQuests)
            {
                var qBorder = new Border
                {
                    Stroke = Colors.Gray,
                    StrokeThickness = 1,
                    Padding = 10,
                    Margin = new Thickness(0, 5, 0, 0),
                    BackgroundColor = Application.Current.RequestedTheme == AppTheme.Dark ? Color.FromArgb("#111111") : Colors.White
                };

                var qLayout = new VerticalStackLayout { Spacing = 5 };
                qLayout.Children.Add(new Label { Text = quest.Name, FontSize = 16, FontAttributes = FontAttributes.Bold });
                qLayout.Children.Add(new Label { Text = quest.Description, FontSize = 12 });
                qLayout.Children.Add(new Label { Text = $"Reward: {quest.Reward}", FontSize = 12, TextColor = Colors.Green });
                qLayout.Children.Add(new Label { Text = quest.WeeksRemaining > 0 ? $"Time remaining: {quest.WeeksRemaining} weeks" : "No time remaining", FontSize = 12, TextColor = Colors.Orange });

                var doButton = new Button { Text = "Set out to do Quest", HorizontalOptions = LayoutOptions.Fill };
                doButton.Clicked += async (s, e) =>
                {
                    // Spend AP
                    if (!_player.TrySpendActionPoints(1))
                    {
                        await Application.Current.MainPage.DisplayAlert("Insufficient Action Points",
                            _player.ActionPoints == 0 ? "You have no Action Points remaining! Wait until next week to gain 2 more AP." : "You need at least 1 AP to do a quest.",
                            "OK");
                        return;
                    }

                    // Complete quest
                    var message = Jobs.Quests.CompleteQuest(quest, _player);
                    quest.IsCompleted = true;

                    // Remove from active quests
                    _player.ActiveQuests.Remove(quest);

                    await Application.Current.MainPage.DisplayAlert("Quest Completed", message, "OK");

                    // Refresh popup UI
                    Close();
                };

                qLayout.Children.Add(doButton);
                qBorder.Content = qLayout;
                GuildMembersContainer.Children.Add(qBorder);
            }
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

    private string GetGuildMasterGreeting()
    {
        var greetings = _player.Jobb.Name switch
        {
            "Adventurers Guild" => new[]
            {
                $"Welcome, {_player.PlayerName}. Ready for your next adventure?",
                "The path of an adventurer is never easy, but it's always rewarding.",
                "I've heard good things about your work. Keep it up!",
                "Remember, teamwork makes the dream work. Don't be afraid to seek help from your fellow adventurers."
            },
            "Blacksmiths Guild" => new[]
            {
                $"Ah, {_player.PlayerName}. How goes the forge work?",
                "The strongest blade is forged through patience and skill.",
                "Your craftsmanship is improving. I'm impressed.",
                "Never forget: quality over quantity. A master smith takes their time."
            },
            "Mages Guild" => new[]
            {
                $"Greetings, {_player.PlayerName}. Your magical studies progress well?",
                "Magic is both an art and a science. Master both, and you'll go far.",
                "I sense great potential in you. Continue your studies diligently.",
                "The arcane arts require discipline and focus. Do not rush your learning."
            },
            "Thieves Guild" => new[]
            {
                $"{_player.PlayerName}, good to see you're still in one piece.",
                "Remember: a good thief is never seen, never heard.",
                "You're becoming quite skilled. Just don't get cocky.",
                "The shadows are your ally. Use them wisely."
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
            "Nice weather we're having, don't you think?"
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
