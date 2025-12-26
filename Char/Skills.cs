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

        private int _stealth;
        public int Stealth
        {
            get => _stealth;
            set
            {
                if (_stealth != value)
                {
                    _stealth = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _marksmanship;
        public int Marksmanship
        {
            get => _marksmanship;
            set
            {
                if (_marksmanship != value)
                {
                    _marksmanship = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private int _lockpicking;
        public int Lockpicking
        {
            get => _lockpicking;
            set
            {
                if (_lockpicking != value)
                {
                    _lockpicking = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _conjuration;
        public int Conjuration
        {
            get => _conjuration;
            set
            {
                if (_conjuration != value)
                {
                    _conjuration = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _destruction;
        public int Destruction
        {
            get => _destruction;
            set
            {
                if (_destruction != value)
                {
                    _destruction = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _illusion;
        public int Illusion
        {
            get => _illusion;
            set
            {
                if (_illusion != value)
                {
                    _illusion = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _restoration;
        public int Restoration
        {
            get => _restoration;
            set
            {
                if (_restoration != value)
                {
                    _restoration = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _firstAid;
        public int FirstAid
        {
            get => _firstAid;
            set
            {
                if (_firstAid != value)
                {
                    _firstAid = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _swordsmanship;
        public int Swordsmanship
        {
            get => _swordsmanship;
            set
            {
                if (_swordsmanship != value)
                {
                    _swordsmanship = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _longWeapons;
        public int LongWeapons
        {
            get => _longWeapons;
            set
            {
                if (_longWeapons != value)
                {
                    _longWeapons = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _heavyWeapons;
        public int HeavyWeapons
        {
            get => _heavyWeapons;
            set
            {
                if (_heavyWeapons != value)
                {
                    _heavyWeapons = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _heavyArmor;
        public int HeavyArmor
        {
            get => _heavyArmor;
            set
            {
                if (_heavyArmor != value)
                {
                    _heavyArmor = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _mediumArmor;
        public int MediumArmor
        {
            get => _mediumArmor;
            set
            {
                if (_mediumArmor != value)
                {
                    _mediumArmor = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _lightArmor;
        public int LightArmor
        {
            get => _lightArmor;
            set
            {
                if (_lightArmor != value)
                {
                    _lightArmor = value;
                    OnPropertyChanged();
                }
            }
        }

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
