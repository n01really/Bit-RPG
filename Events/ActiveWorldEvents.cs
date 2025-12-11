using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Events;

namespace Bit_RPG.Events
{
    internal class ActiveWorldEvents
    {
        public static void WorldEvents(CurrentEvents events)
        {
            events.IsEarthquakeActive = false;
            events.IsFloodActive = false;
            events.IsFireActive = false;
            events.IsBanditRaidActive = false;
            events.IsFamineActive = false;
            events.IsPlagueActive = false;
            events.IsWarActive = false;
            events.isDroughtActive = false;
            events.IsStormActive = false;
            events.IsBorderClosed = false;
        }
    }
}
