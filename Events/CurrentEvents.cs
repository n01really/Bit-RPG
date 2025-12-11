using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Events
{
    internal class CurrentEvents
    {
        public bool IsEarthquakeActive { get; set; }
        public bool IsFloodActive { get; set; }
        public bool IsFireActive { get; set; }
        public bool IsBanditRaidActive { get; set; }
        public bool IsFamineActive { get; set; }
        public bool IsPlagueActive { get; set; }
        public bool IsWarActive { get; set; }
        public bool isDroughtActive { get; set; }
        public bool IsStormActive { get; set; }
        public bool IsBorderClosed { get; set; }
        
        public int ClickedSinceLastEvent { get; set; }
        public int ClicksRequiredForEvent { get; set; } = 4;

        public bool HasActiveEvent()
        {
            return IsEarthquakeActive || IsFloodActive || IsFireActive || IsBanditRaidActive ||
                   IsFamineActive || IsPlagueActive || IsWarActive || isDroughtActive || IsStormActive ||
                   IsBorderClosed;
        }

        public void ClearAllEvents()
        {
            IsEarthquakeActive = false;
            IsFloodActive = false;
            IsFireActive = false;
            IsBanditRaidActive = false;
            IsFamineActive = false;
            IsPlagueActive = false;
            IsWarActive = false;
            isDroughtActive = false;
            IsStormActive = false;
            IsBorderClosed = false;
        }
    }
}
