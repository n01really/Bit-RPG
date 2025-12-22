using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Events;
using Bit_RPG.Jobs;
using Bit_RPG.Models;

namespace Bit_RPG.Char
{

    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler LeveledUp; // Add this event

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string PlayerName { get; set; }
        public int Age { get; set; }
        public bool Male { get; set; }
        public bool Female { get; set; }
        public string Pronouns { get; set; }
        public int Level { get; set; }

        private int _money;
        public int Money
        {
            get => _money;
            set
            {
                if (_money != value)
                {
                    _money = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _experience;
        public int Experience
        {
            get => _experience;
            set
            {
                if (_experience != value)
                {
                    _experience = value;
                    OnPropertyChanged();
                    CheckLevelUp();
                }
            }
        }

        private int _skillPoints;
        public int SkillPoints
        {
            get => _skillPoints;
            set
            {
                if (_skillPoints != value)
                {
                    _skillPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        public int JobExperience { get; set; }
        public Job Jobb { get; set; }
        public int JobRank { get; set; }
        public RaceType Race { get; set; }
        public ClassType Class { get; set; }
        public Skills Skills { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int Magic { get; set; }
        public int MaxMana { get; set; }
        public int MDefense { get; set; }
        public List<QuestModel> ActiveQuests { get; set; } = new List<QuestModel>();

        // Constants
        public const int MaxLevel = 100;

        // Experience required for next level (scales with level)
        public int ExperienceForNextLevel => Level * 100;

        // Check if player should level up
        private void CheckLevelUp()
        {
            while (Experience >= ExperienceForNextLevel && Level < MaxLevel)
            {
                LevelUp();
            }
        }

        // Handle level up
        public void LevelUp()
        {
            if (Level >= MaxLevel)
                return;

            Level++;
            SkillPoints += 15; // Add 15 skill points per level
            Experience -= ExperienceForNextLevel; // Carry over excess XP
            
            // Increase stats by 5 each level (max 150)
            MaxHealth = Math.Min(MaxHealth + 5, 150);
            MaxMana = Math.Min(MaxMana + 5, 150);
            Strength = Math.Min(Strength + 5, 150);
            Agility = Math.Min(Agility + 5, 150);
            Intelligence = Math.Min(Intelligence + 5, 150);
            Attack = Math.Min(Attack + 5, 150);
            Defense = Math.Min(Defense + 5, 150);
            MDefense = Math.Min(MDefense + 5, 150);
            
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(ExperienceForNextLevel));
            OnPropertyChanged(nameof(MaxHealth));
            OnPropertyChanged(nameof(MaxMana));
            OnPropertyChanged(nameof(Strength));
            OnPropertyChanged(nameof(Agility));
            OnPropertyChanged(nameof(Intelligence));
            OnPropertyChanged(nameof(Attack));
            OnPropertyChanged(nameof(Defense));
            OnPropertyChanged(nameof(MDefense));

            // Raise the LeveledUp event
            LeveledUp?.Invoke(this, EventArgs.Empty);
        }
    }
}
