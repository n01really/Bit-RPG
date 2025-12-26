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
        public WeeklyEventModel WeeklyEvent { get; set; }
        
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
        public EventResult WeeklyEvent { get; set; }

        public bool HasAnyEvent => WorldEvent != null || JobEvent != null || WeeklyEvent != null;

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

            if (WeeklyEvent != null)
            {
                eventTexts.Add(WeeklyEvent.GetFormattedText());
            }

            return string.Join("\n\n", eventTexts);
        }
    }
    
    /// <summary>
    /// EventPicker is responsible for determining which events trigger and when.
    /// 
    /// EVENT FREQUENCY GUIDE:
    /// =====================
    /// To change how often events occur, modify the following values in TryTriggerEvent():
    /// 
    /// 1. CLICKS REQUIRED FOR EVENT:
    ///    - Located in CurrentEvents.cs: ClicksRequiredForEvent = 4
    ///    - This is how many times you click "Continue" before an event CAN trigger
    ///    - Lower number = events can happen more frequently
    ///    - Higher number = events happen less frequently
    ///    - Example: Change to 10 for events every 10 weeks
    /// 
    /// 2. WORLD EVENT CHANCE:
    ///    - Current: if (worldEventChance < 15) // 15% chance
    ///    - Change the number to adjust probability:
    ///      - < 5 = 5% chance (rare)
    ///      - < 25 = 25% chance (common)
    ///      - < 50 = 50% chance (very common)
    ///    - These are major events like wars, disasters, famines
    /// 
    /// 3. JOB EVENT CHANCE:
    ///    - Current: if (jobEventChance < 33) // 33% chance
    ///    - Triggers only if player has a job
    ///    - Change number to adjust how often job events occur
    /// 
    /// 4. WEEKLY EVENT CHANCE:
    ///    - Current: Always triggers (100% chance) every continue press
    ///    - To make it less frequent, add a random check:
    ///      int weeklyEventChance = _random.Next(0, 100);
    ///      if (weeklyEventChance < 50) // 50% chance
    ///    - These are small, slice-of-life events
    /// 
    /// ADDING NEW EVENTS:
    /// ==================
    /// 
    /// FOR WORLD EVENTS (Wars, Disasters, etc.):
    /// -----------------------------------------
    /// 1. Go to Events/WorldEvents.cs
    /// 2. Add your event to the appropriate method:
    ///    - CountryEvent() for kingdom-wide events
    ///    - TownEvent() for local events
    ///    - DisasterEvent() for natural disasters
    /// 3. Add a new case to the switch statement
    /// 4. Update CurrentEvents.cs to add a new bool flag if needed
    /// 
    /// Example:
    ///   case 3:
    ///       events.IsVolcanoActive = true;
    ///       return new EventResult("Volcano Eruption", 
    ///           "A nearby volcano erupts!", "Disaster");
    /// 
    /// FOR JOB EVENTS:
    /// --------------
    /// 1. Go to Events/JobEvents.cs
    /// 2. Add your event to the appropriate guild method:
    ///    - AdventureGuildEvent()
    ///    - BlacksmithGuildEvent()
    ///    - MagesGuildEvent()
    ///    - ThievesGuildEvent()
    /// 3. OR create a new guild method for a new job type
    /// 4. Add the method call in PickJobEvent() below
    /// 
    /// FOR WEEKLY EVENTS:
    /// -----------------
    /// 1. Go to Events/WeeklyEvents.cs
    /// 2. Create a new private static method:
    ///    private static WeeklyEventModel YourNewEvent(Player player)
    /// 3. Add it to GetRandomWeeklyEvent() switch statement
    /// 4. Increment the random range (currently _random.Next(1, 11))
    ///    to include your new event ID
    /// 
    /// Example:
    ///   private static WeeklyEventModel CarnivalEvent(Player player)
    ///   {
    ///       return new WeeklyEventModel
    ///       {
    ///           Id = 11,
    ///           Description = "A traveling carnival arrives in town!",
    ///           Location = player.CurrentLocation,
    ///           CurrentLocation = player
    ///       };
    ///   }
    ///   
    ///   Then in GetRandomWeeklyEvent():
    ///   int eventId = _random.Next(1, 12); // Changed from 11 to 12
    ///   // ... add case 11 => CarnivalEvent(player),
    /// 
    /// FOR NEW EVENT CATEGORIES:
    /// ------------------------
    /// 1. Create a new file in Events folder (e.g., ReligiousEvents.cs)
    /// 2. Follow the pattern of WorldEvents.cs or JobEvents.cs
    /// 3. Add a call to your new event type in TryTriggerEvent() below
    /// 4. Add the new category to MultiEventResult if needed
    /// 
    /// </summary>
    internal class EventPicker
    {
        private static Random _random = new Random();

        /// <summary>
        /// Main event trigger method called when player clicks "Continue"
        /// Tracks clicks and decides when to trigger events based on thresholds
        /// </summary>
        public static MultiEventResult? TryTriggerEvent(CurrentEvents events, Player player = null)
        {
            // Track how many times continue has been clicked since last event check
            events.ClickedSinceLastEvent++;
            
            // Only check for events after required number of clicks (default: 4)
            // TO CHANGE: Modify ClicksRequiredForEvent in CurrentEvents.cs
            if (events.ClickedSinceLastEvent >= events.ClicksRequiredForEvent)
            { 
                events.ClickedSinceLastEvent = 0;
                
                var result = new MultiEventResult();
                
                // WORLD EVENTS - Major events like wars, disasters, etc.
                // TO CHANGE FREQUENCY: Modify the "< 15" to a different percentage
                int worldEventChance = _random.Next(0, 100);
                if (worldEventChance < 15)  // 15% chance
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
                
                // JOB EVENTS - Triggers if player has a job
                // TO CHANGE FREQUENCY: Modify the "< 33" to a different percentage
                if (player != null && player.Jobb != null)
                {
                    int jobEventChance = _random.Next(0, 100);
                    if (jobEventChance < 33)  // 33% chance
                    {
                        result.JobEvent = PickJobEvent(player);
                    }
                }
                
                // WEEKLY EVENTS - Small slice-of-life events
                // Currently: Always triggers (100% chance)
                // TO MAKE LESS FREQUENT: Add a random chance check here
                var weeklyEventModel = WeeklyEvents.GetRandomWeeklyEvent(player);
                result.WeeklyEvent = new EventResult(
                    "Weekly Event",
                    weeklyEventModel.Description,
                    "Weekly"
                )
                {
                    WeeklyEvent = weeklyEventModel
                };
                
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
                if (jobEventChance < 33)  // 33% chance
                {
                    result.JobEvent = PickJobEvent(player);
                }
            }

            // Always include a weekly event
            var weeklyEventModel = WeeklyEvents.GetRandomWeeklyEvent(player);
            result.WeeklyEvent = new EventResult(
                "Weekly Event",
                weeklyEventModel.Description,
                "Weekly"
            )
            {
                WeeklyEvent = weeklyEventModel
            };

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

        /// <summary>
        /// Picks a job-specific event based on the player's current job
        /// TO ADD NEW JOB TYPES: Add a new CanTrigger method and event method in JobEvents.cs,
        /// then add an else if block here following the existing pattern
        /// </summary>
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
