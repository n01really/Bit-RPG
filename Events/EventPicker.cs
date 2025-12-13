using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Events;
using Bit_RPG.Jobs;
using Bit_RPG.Models;

namespace Bit_RPG.Events
{
    internal class EventResult
    {
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventCategory { get; set; }
        public JobEventModel JobEvent { get; set; }
        
        public EventResult(string eventName, string eventDescription, string eventScope)
        {
            EventName = eventName;
            EventDescription = eventDescription;
            EventCategory = eventScope;
        }

        public string GetFormattedText()
        {
            if (JobEvent != null)
            {
                return $"{EventDescription}\n+{JobEvent.JobExperience} Job Experience";
            }
            return $"=== {EventName} ===\n{EventDescription}";
        }
    }

    internal class MultiEventResult
    {
        public EventResult WorldEvent { get; set; }
        public EventResult JobEvent { get; set; }

        public bool HasAnyEvent => WorldEvent != null || JobEvent != null;

        public string GetFormattedText()
        {
            var eventTexts = new List<string>();
            
            if (WorldEvent != null)
            {
                eventTexts.Add(WorldEvent.GetFormattedText());
            }
            
            if (JobEvent != null)
            {
                eventTexts.Add(JobEvent.GetFormattedText());
            }

            return string.Join("\n\n", eventTexts);
        }
    }
    
    internal class EventPicker
    {
        private static Random _random = new Random();

        public static MultiEventResult? TryTriggerEvent(CurrentEvents events, Player player = null)
        {
            events.ClickedSinceLastEvent++;
            if (events.ClickedSinceLastEvent >= events.ClicksRequiredForEvent)
            { 
                events.ClickedSinceLastEvent = 0;
                
                var result = new MultiEventResult();
                
                // 15% chance to trigger a world event
                int worldEventChance = _random.Next(0, 100);
                if (worldEventChance < 15)
                {
                    events.ClearAllEvents();
                    int eventCategory = _random.Next(0, 3);
                    result.WorldEvent = eventCategory switch
                    {
                        0 => WorldEvents.CountryEvent(events),
                        1 => WorldEvents.TownEvent(events),
                        2 => WorldEvents.DisasterEvent(events),
                        _ => new EventResult("Unknown Event", "Something strange has occurred.", "Unknown"),
                    };
                }
                
                // If player has a job, 1/3 chance to also trigger a job event
                if (player != null && player.Jobb != null)
                {
                    int jobEventChance = _random.Next(0, 100);
                    if (jobEventChance < 33)  // 33% chans
                    {
                        result.JobEvent = PickJobEvent(player);
                    }
                }
                
                // Only return result if at least one event occurred
                if (result.HasAnyEvent)
                {
                    return result;
                }
            }
            return null;
        }

        public static MultiEventResult PickRandomEvents(CurrentEvents events, Player player = null)
        {
            var result = new MultiEventResult();

            // 15% chance to trigger a world event
            int worldEventChance = _random.Next(0, 100);
            if (worldEventChance < 15)
            {
                events.ClearAllEvents();
                int eventCategory = _random.Next(0, 3);
                result.WorldEvent = eventCategory switch
                {
                    0 => WorldEvents.CountryEvent(events),
                    1 => WorldEvents.TownEvent(events),
                    2 => WorldEvents.DisasterEvent(events),
                    _ => new EventResult("Unknown Event", "Something strange has occurred.", "Unknown"),
                };
            }

            // If player has a job, 1/3 chance to also trigger a job event
            if (player != null && player.Jobb != null)
            {
                int jobEventChance = _random.Next(0, 100);
                if (jobEventChance < 33)  // 33% chans
                {
                    result.JobEvent = PickJobEvent(player);
                }
            }

            return result;
        }

        public static EventResult PickRandomEvent(CurrentEvents events, Player player = null)
        {
            if (player != null && player.Jobb != null)
            {
                int eventCategory = _random.Next(0, 4);
                return eventCategory switch
                {
                    0 => WorldEvents.CountryEvent(events),
                    1 => WorldEvents.TownEvent(events),
                    2 => WorldEvents.DisasterEvent(events),
                    3 => PickJobEvent(player),
                    _ => new EventResult("Unknown Event", "Something strange has occurred.", "Unknown"),
                };
            }
            else
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
        }

        public static EventResult PickJobEvent(Player player)
        {
            if (player?.Jobb == null)
            {
                return new EventResult("No Job", "You don't have a job to trigger events from.", "Job");
            }

            JobEventModel jobEventModel = null;
            string eventName = "Guild Event";

            if (JobEvents.CanTriggerAdventureGuildEvent(player))
            {
                jobEventModel = JobEvents.AdventureGuildEvent(player);
                eventName = "Adventurers Guild Event";
            }
            else if (JobEvents.CanTriggerBlacksmithGuildEvent(player))
            {
                jobEventModel = JobEvents.BlacksmithGuildEvent(player);
                eventName = "Blacksmiths Guild Event";
            }
            else if (JobEvents.CanTriggerMagesGuildEvent(player))
            {
                jobEventModel = JobEvents.MagesGuildEvent(player);
                eventName = "Mages Guild Event";
            }
            else if (JobEvents.CanTriggerThievesGuildEvent(player))
            {
                jobEventModel = JobEvents.ThievesGuildEvent(player);
                eventName = "Thieves Guild Event";
            }

            if (jobEventModel != null)
            {
                return new EventResult(eventName, jobEventModel.Description, "Job")
                {
                    JobEvent = jobEventModel
                };
            }

            return new EventResult("No Job Event", "No job event could be triggered.", "Job");
        }

        public static EventResult PickJobEventById(Player player, int eventId)
        {
            if (player?.Jobb == null)
            {
                return new EventResult("No Job", "You don't have a job to trigger events from.", "Job");
            }

            JobEventModel jobEventModel = JobEvents.GetJobEventById(eventId, player);
            
            if (jobEventModel != null)
            {
                string eventName = player.Jobb.Name + " Event";
                return new EventResult(eventName, jobEventModel.Description, "Job")
                {
                    JobEvent = jobEventModel
                };
            }

            return new EventResult("Invalid Event ID", "No job event with that ID exists.", "Job");
        }

        public static EventResult PickSpecificEvent(CurrentEvents events, string category, Player player = null)
        {
            events.ClearAllEvents();

            return category.ToLower() switch
            {
                "country" => WorldEvents.CountryEvent(events),
                "town" => WorldEvents.TownEvent(events),
                "disaster" => WorldEvents.DisasterEvent(events),
                "job" => PickJobEvent(player),
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
