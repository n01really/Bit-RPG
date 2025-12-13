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

namespace Bit_RPG.Char
{

    public class Player : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
                }
            }
        }
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
        public int Strength { get; set; }
        public int Agility { get; set; }
        public int Intelligence { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxHealth { get; set; }
        public int Magic { get; set; }
        public int MaxMana { get; set; }
        public int MDefense { get; set; }
        public Location CurrentLocation { get; set; }
        public List<QuestModel> ActiveQuests { get; set; } = new List<QuestModel>();
    }
}
