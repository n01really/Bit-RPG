using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Events;

namespace Bit_RPG.Events
{
    internal class ActiveWorldEvents
    {
        public static void InitializeWorldEvents(CurrentEvents events)
        {
            events.ClearAllEvents();
            events.ClickedSinceLastEvent = 0;
        }

        public static MultiEventResult? ProcessContinueClick(CurrentEvents events, Player player = null)
        {
            return EventPicker.TryTriggerEvent(events, player);
        }

        public static MultiEventResult TriggerRandomEvents(CurrentEvents events, Player player = null)
        {
            return EventPicker.PickRandomEvents(events, player);
        }

        public static EventResult TriggerRandomEvent(CurrentEvents events, Player player = null)
        {
            return EventPicker.PickRandomEvent(events, player);
        }

        public static EventResult TriggerSpecificEvent(CurrentEvents events, string category, Player player = null)
        {
            return EventPicker.PickSpecificEvent(events, category, player);
        }
    }
}
