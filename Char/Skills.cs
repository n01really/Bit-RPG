using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char
{
    public class Skills : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Stealth { get; set; } 
        public int Marksmanship { get; set; }

        private int _slightofHand;
        public int SlightofHand
        {
            get => _slightofHand;
            set
            {
                if (_slightofHand != value)
                {
                    _slightofHand = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Lockpicking { get; set; }
        public int Conjuration { get; set; }
        public int Destruction { get; set; }
        public int Illusion { get; set; }
        public int Restoration { get; set; }
        public int FirstAid { get; set; }
        public int Swordsmanship { get; set; }
        public int LongWeapons { get; set; }
        public int HeavyWeapons { get; set; }
        public int HeavyArmor { get; set; }
        public int MediumArmor { get; set; }
        public int LightArmor { get; set; }

        private int _smithing;
        public int Smithing
        {
            get => _smithing;
            set
            {
                if (_smithing != value)
                {
                    _smithing = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _alchemy;
        public int Alchemy
        {
            get => _alchemy;
            set
            {
                if (_alchemy != value)
                {
                    _alchemy = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _enchanting;
        public int Enchanting
        {
            get => _enchanting;
            set
            {
                if (_enchanting != value)
                {
                    _enchanting = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
