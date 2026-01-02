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
using Bit_RPG.World;
using PlayerLocation = Bit_RPG.Models.Location;

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
        
        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        
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
        
        private int _actionPoints = 5;
        public int ActionPoints
        {
            get => _actionPoints;
            set
            {
                var clampedValue = Math.Clamp(value, 0, MaxActionPoints);
                if (_actionPoints != clampedValue)
                {
                    _actionPoints = clampedValue;
                    System.Diagnostics.Debug.WriteLine($"[Player] ActionPoints set to {_actionPoints}");
                    OnPropertyChanged();
                }
            }
        }

        public const int MaxActionPoints = 12;
        
        private int _jobExperience;
        public int JobExperience
        {
            get => _jobExperience;
            set
            {
                if (_jobExperience != value)
                {
                    _jobExperience = value;
                    OnPropertyChanged();
                }
            }
        }
        public Job Jobb { get; set; }
        public int JobRank { get; set; }
        public RaceType Race { get; set; }
        public ClassType Class { get; set; }
        public Skills Skills { get; set; }
        
        private int _strength;
        public int Strength
        {
            get => _strength;
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _agility;
        public int Agility
        {
            get => _agility;
            set
            {
                if (_agility != value)
                {
                    _agility = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _intelligence;
        public int Intelligence
        {
            get => _intelligence;
            set
            {
                if (_intelligence != value)
                {
                    _intelligence = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _attack;
        public int Attack
        {
            get => _attack;
            set
            {
                if (_attack != value)
                {
                    _attack = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _defense;
        public int Defense
        {
            get => _defense;
            set
            {
                if (_defense != value)
                {
                    _defense = value;
                    OnPropertyChanged();
                }
            }
        }
        
        private int _maxHealth;
        public int MaxHealth
        {
            get => _maxHealth;
            set
            {
                if (_maxHealth != value)
                {
                    _maxHealth = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int Magic { get; set; }
        
        private int _maxMana;
        public int MaxMana
        {
            get => _maxMana;
            set
            {
                if (_maxMana != value)
                {
                    _maxMana = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public int MDefense { get; set; }
        public PlayerLocation CurrentLocation { get; set; }
        public List<QuestModel> ActiveQuests { get; set; } = new List<QuestModel>();
        public List<ItemModel> Inventory { get; set; } = new List<ItemModel>();
        public Inventory InventoryManager { get; private set; }

        public Player()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("[Player] Initializing Player...");
                InventoryManager = new Inventory(this);
                System.Diagnostics.Debug.WriteLine("[Player] Inventory created");
                
                CurrentLocation = TravelSystem.GetStartingLocation();
                System.Diagnostics.Debug.WriteLine($"[Player] Starting location set to: {CurrentLocation?.Name ?? "null"}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[Player] ERROR in constructor: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"[Player] Stack trace: {ex.StackTrace}");
                
                // Set fallback values to prevent null references
                InventoryManager = new Inventory(this);
                CurrentLocation = new PlayerLocation("Unknown", LocationType.Town, "Unknown");
                
                throw;
            }
        }

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
            SkillPoints += 5; // Give 5 attribute points per level for stats
            Experience -= ExperienceForNextLevel; // Carry over excess XP
            
            // Stats no longer auto-increase - player must allocate them manually
            
            OnPropertyChanged(nameof(Level));
            OnPropertyChanged(nameof(ExperienceForNextLevel));

            // Raise the LeveledUp event
            LeveledUp?.Invoke(this, EventArgs.Empty);
        }

        public bool TrySpendActionPoints(int amount)
        {
            if (amount <= 0) return true;
            if (ActionPoints < amount) return false;
            ActionPoints -= amount;
            System.Diagnostics.Debug.WriteLine($"[Player] Spent {amount} AP, remaining {ActionPoints}");
            return true;
        }

        public void AddActionPoints(int amount)
        {
            if (amount <= 0) return;
            ActionPoints = Math.Min(ActionPoints + amount, MaxActionPoints);
            System.Diagnostics.Debug.WriteLine($"[Player] Added {amount} AP, now {ActionPoints}");
        }
    }
}
