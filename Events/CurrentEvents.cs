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
        
        // Duration tracking (weeks remaining for active event)
        public int EventDurationRemaining { get; set; }
        
        public int ClickedSinceLastEvent { get; set; }
        
        // WORLD EVENT FREQUENCY SETTINGS
        public int ClicksRequiredForEvent { get; set; } = 8; // Check every 8 weeks
        public int WorldEventChancePercentage { get; set; } = 15; // 15% chance
        public int DefaultEventDuration { get; set; } = 2; // Events last 2 weeks

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
            EventDurationRemaining = 0;
        }
        
        public void DecrementEventDuration()
        {
            if (EventDurationRemaining > 0)
            {
                EventDurationRemaining--;
                
                // Clear events when duration expires
                if (EventDurationRemaining <= 0)
                {
                    ClearAllEvents();
                }
            }
        }
    }
}
