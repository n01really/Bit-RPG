using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Events;
using Bit_RPG.Jobs;

namespace Bit_RPG.Events
{
    internal class EventResult
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventCategory { get; set; }
        public EventResult(string eventName, string eventDescription, string eventScope)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            EventCategory = eventScope;
        }

        public string GetFormattedText()
        {
            return $"=== {EventName} ===\n{EventDescription}";
        }
    }
    internal class EventPicker
    {
        private static Random _random = new Random();

        public static EventResult? TryTriggerEvent(CurrentEvents events)
        {
            events.ClickedSinceLastEvent++;
            if (events.ClickedSinceLastEvent >= events.ClicksRequiredForEvent)
            { 
                events.ClearAllEvents();
                events.ClickedSinceLastEvent = 0;
                return PickRandomEvent(events);
            }
            return null;
        }

        public static EventResult PickRandomEvent(CurrentEvents events)
        {
            int eventCategory = _random.Next(0, 3); 
            return eventCategory switch
            {
                0 => WorldEvents.CountryEvent(events),
                1 => WorldEvents.TownEvent(events),
                2 => WorldEvents.DisasterEvent(events),
                _ => new EventResult("Unknown Event", "Something strange has occurred.", "Unknown"),
            };
        }

        public static EventResult PickSpecificEvent(CurrentEvents events, string category)
        {
            events.ClearAllEvents();

            return category.ToLower() switch
            {
                "country" => WorldEvents.CountryEvent(events),
                "town" => WorldEvents.TownEvent(events),
                "disaster" => WorldEvents.DisasterEvent(events),
                _ => new EventResult("Invalid Event", "No such event category exists.", "None")
            };
        }

        public static string GetEventSummary(CurrentEvents events)
        {
            if (events.IsEarthquakeActive) return "Earthquake";
            if (events.IsFloodActive) return "Flood";
            if (events.IsFireActive) return "Fire";
            if (events.IsBanditRaidActive) return "Bandit Raid";
            if (events.IsFamineActive) return "Famine";
            if (events.IsPlagueActive) return "Plague";
            if (events.IsWarActive) return "War";
            if (events.isDroughtActive) return "Drought";
            if (events.IsStormActive) return "Storm";
            if (events.IsBorderClosed) return "Border Closure";

            return "No active events";
        }
    }
}
