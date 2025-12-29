using Bit_RPG.Char;
using Bit_RPG.Jobs;
using CommunityToolkit.Maui.Views;

namespace Bit_RPG;

public partial class JobsPopup : Popup
{
	private Player _player;

	public JobsPopup(Player player)
	{
		InitializeComponent();
		_player = player;
		BindingContext = player;

		UpdateUI();
	}

	private void UpdateUI()
	{
		if (_player.Jobb != null)
		{
			CurrentJobInfo.IsVisible = true;
			RankProgress.Text = $"Progress: {_player.Jobb.GetRankProgressText()}\n{_player.Jobb.GetRankUpRequirementsText(_player.Skills)}";

			// Update button text and visibility for current job
			if (_player.Jobb.Name == "Adventurers Guild")
			{
				AdventurersGuildButton.Text = "Quit Job";
				AdventurersGuildButton.BackgroundColor = Colors.Red;
				BlacksmithsGuildSection.IsVisible = false;
				MagesGuildSection.IsVisible = false;
				ThievesGuildSection.IsVisible = false;
			}
			else if (_player.Jobb.Name == "Blacksmiths Guild")
			{
				BlacksmithsGuildButton.Text = "Quit Job";
				BlacksmithsGuildButton.BackgroundColor = Colors.Red;
				AdventurersGuildSection.IsVisible = false;
				MagesGuildSection.IsVisible = false;
				ThievesGuildSection.IsVisible = false;
			}
			else if (_player.Jobb.Name == "Mages Guild")
			{
				MagesGuildButton.Text = "Quit Job";
				MagesGuildButton.BackgroundColor = Colors.Red;
				AdventurersGuildSection.IsVisible = false;
				BlacksmithsGuildSection.IsVisible = false;
				ThievesGuildSection.IsVisible = false;
			}
			else if (_player.Jobb.Name == "Thieves Guild")
			{
				ThievesGuildButton.Text = "Quit Job";
				ThievesGuildButton.BackgroundColor = Colors.Red;
				AdventurersGuildSection.IsVisible = false;
				BlacksmithsGuildSection.IsVisible = false;
				MagesGuildSection.IsVisible = false;
			}
		}
		else
		{
			CurrentJobInfo.IsVisible = false;

			// Reset all buttons to "Select Job" and show all sections
			AdventurersGuildButton.Text = "Select Job";
			AdventurersGuildButton.BackgroundColor = Colors.Green;
			AdventurersGuildSection.IsVisible = true;

			BlacksmithsGuildButton.Text = "Select Job";
			BlacksmithsGuildButton.BackgroundColor = Colors.Green;
			BlacksmithsGuildSection.IsVisible = true;

			MagesGuildButton.Text = "Select Job";
			MagesGuildButton.BackgroundColor = Colors.Green;
			MagesGuildSection.IsVisible = true;

			ThievesGuildButton.Text = "Select Job";
			ThievesGuildButton.BackgroundColor = Colors.Green;
			ThievesGuildSection.IsVisible = true;
		}
	}

	private async void OnAdventurersGuildClicked(object sender, EventArgs e)
	{
		if (_player.Jobb != null && _player.Jobb.Name == "Adventurers Guild")
		{
			// Quit current job
			bool confirm = await Application.Current.MainPage.DisplayAlert(
				"Quit Job",
				"Are you sure you want to quit the Adventurers Guild? You will lose all progress and rank!",
				"Yes",
				"No");

			if (confirm)
			{
				_player.Jobb = null;
				UpdateUI();
			}
		}
		else if (_player.Jobb != null)
		{
			await Application.Current.MainPage.DisplayAlert("Already Joined",
				$"You are already a member of {_player.Jobb.Name}. Quit your current job first.", "OK");
		}
		else
		{
			// Check if player has enough AP
			if (!_player.TrySpendActionPoints(1))
			{
				await Application.Current.MainPage.DisplayAlert("Insufficient Action Points", 
					_player.ActionPoints == 0 
						? "You have no Action Points remaining! Wait until next week to gain 2 more AP." 
						: "You need at least 1 AP to join a guild.", 
					"OK");
				return;
			}
			
			_player.Jobb = Job.CreateAdventurersGuild("Arn");
			Close();
		}
	}

	private async void OnBlacksmithsGuildClicked(object sender, EventArgs e)
	{
		if (_player.Jobb != null && _player.Jobb.Name == "Blacksmiths Guild")
		{
			// Quit current job
			bool confirm = await Application.Current.MainPage.DisplayAlert(
				"Quit Job",
				"Are you sure you want to quit the Blacksmiths Guild? You will lose all progress and rank!",
				"Yes",
				"No");
			
			if (confirm)
			{
				_player.Jobb = null;
				UpdateUI();
			}
		}
		else if (_player.Jobb != null)
		{
			await Application.Current.MainPage.DisplayAlert("Already Joined", 
				$"You are already a member of {_player.Jobb.Name}. Quit your current job first.", "OK");
		}
		else
		{
			// Check if player has enough AP
			if (!_player.TrySpendActionPoints(1))
			{
				await Application.Current.MainPage.DisplayAlert("Insufficient Action Points", 
					_player.ActionPoints == 0 
						? "You have no Action Points remaining! Wait until next week to gain 2 more AP." 
						: "You need at least 1 AP to join a guild.", 
					"OK");
				return;
			}
			
			_player.Jobb = Job.CreateBlacksmithsGuild("Arn");
			Close();
		}
	}

	private async void OnMagesGuildClicked(object sender, EventArgs e)
	{
		if (_player.Jobb != null && _player.Jobb.Name == "Mages Guild")
		{
			// Quit current job
			bool confirm = await Application.Current.MainPage.DisplayAlert(
				"Quit Job",
				"Are you sure you want to quit the Mages Guild? You will lose all progress and rank!",
				"Yes",
				"No");
			
			if (confirm)
			{
				_player.Jobb = null;
				UpdateUI();
			}
		}
		else if (_player.Jobb != null)
		{
			await Application.Current.MainPage.DisplayAlert("Already Joined", 
				$"You are already a member of {_player.Jobb.Name}. Quit your current job first.", "OK");
		}
		else
		{
			// Check if player has enough AP
			if (!_player.TrySpendActionPoints(1))
			{
				await Application.Current.MainPage.DisplayAlert("Insufficient Action Points", 
					_player.ActionPoints == 0 
						? "You have no Action Points remaining! Wait until next week to gain 2 more AP." 
						: "You need at least 1 AP to join a guild.", 
					"OK");
				return;
			}
			
			_player.Jobb = Job.CreateMagesGuild("Arn");
			Close();
		}
	}

	private async void OnThievesGuildClicked(object sender, EventArgs e)
	{
		if (_player.Jobb != null && _player.Jobb.Name == "Thieves Guild")
		{
			// Quit current job
			bool confirm = await Application.Current.MainPage.DisplayAlert(
				"Quit Job",
				"Are you sure you want to quit the Thieves Guild? You will lose all progress and rank!",
				"Yes",
				"No");
			
			if (confirm)
			{
				_player.Jobb = null;
				UpdateUI();
			}
		}
		else if (_player.Jobb != null)
		{
			await Application.Current.MainPage.DisplayAlert("Already Joined", 
				$"You are already a member of {_player.Jobb.Name}. Quit your current job first.", "OK");
		}
		else
		{
			// Check if player has enough AP
			if (!_player.TrySpendActionPoints(1))
			{
				await Application.Current.MainPage.DisplayAlert("Insufficient Action Points", 
					_player.ActionPoints == 0 
						? "You have no Action Points remaining! Wait until next week to gain 2 more AP." 
						: "You need at least 1 AP to join a guild.", 
					"OK");
				return;
			}
			
			_player.Jobb = Job.CreateThievesGuild("Arn");
			Close();
		}
	}

	private void OnCloseClicked(object sender, EventArgs e)
	{
		Close();
	}
}
