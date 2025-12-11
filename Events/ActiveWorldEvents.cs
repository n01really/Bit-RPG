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
        public static void InitializeWorldEvents(CurrentEvents events)
        {
            events.ClearAllEvents();
            events.ClickedSinceLastEvent = 0;
        }

        public static EventResult? ProcessContinueClick(CurrentEvents events)
        {
            return EventPicker.TryTriggerEvent(events);
        }

        public static EventResult TriggerRandomEvent(CurrentEvents events)
        {
            return EventPicker.PickRandomEvent(events);
        }

        public static EventResult TriggerSpecificEvent(CurrentEvents events, string category)
        {
            return EventPicker.PickSpecificEvent(events, category);
        }
    }
}
