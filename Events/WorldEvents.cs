using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Events
{
    internal class WorldEvents
    {
        private static Random _random = new Random();

        public static EventResult CountryEvent(CurrentEvents events)
        {
            // Events already cleared by EventPicker, just set the new one
            int eventType = _random.Next(0, 3);
            switch (eventType)
            {
                case 0:
                    events.IsWarActive = true;
                    return new EventResult(
                        "War Declared",
                        "The drums of war echo across the land. Neighboring kingdoms have declared war, and soldiers march to the borders. Trade routes are disrupted and prices soar.",
                        "Country"
                    );
                case 1:
                    events.IsBorderClosed = true;
                    return new EventResult(
                        "Borders Closed",
                        "By royal decree, the borders have been sealed. No travelers may enter or leave the kingdom. Merchants grumble as caravans are turned away at checkpoints.",
                        "Country"
                    );
                case 2:
                    events.IsPlagueActive = true;
                    return new EventResult(
                        "Plague Outbreak",
                        "A terrible sickness spreads through the kingdom. Healers work tirelessly, but the death toll rises. People wear masks and avoid crowded places.",
                        "Country"
                    );
                default:
                    return new EventResult("Unknown Event", "Something strange has occurred.", "Country");
            }
        }

        public static EventResult TownEvent(CurrentEvents events)
        {
            // Events already cleared by EventPicker, just set the new one
            int eventType = _random.Next(0, 3);
            switch (eventType)
            {
                case 0:
                    events.IsBanditRaidActive = true;
                    return new EventResult(
                        "Bandit Raid",
                        "A band of ruthless bandits has been spotted near the town. Merchants hire extra guards, and citizens bar their doors at night. The town guard patrols with increased vigilance.",
                        "Town"
                    );
                case 1:
                    events.IsFamineActive = true;
                    return new EventResult(
                        "Famine",
                        "The harvest has failed. Grain stores run dangerously low, and bread prices triple. Hungry citizens queue at soup kitchens while the wealthy hoard supplies.",
                        "Town"
                    );
                case 2:
                    events.IsFireActive = true;
                    return new EventResult(
                        "Town Fire",
                        "Flames engulf several buildings in the market district. Citizens form bucket brigades as the fire brigade struggles to contain the blaze. Smoke fills the air.",
                        "Town"
                    );
                default:
                    return new EventResult("Unknown Event", "Something strange has occurred.", "Town");
            }
        }

        public static EventResult DisasterEvent(CurrentEvents events)
        {
            // Events already cleared by EventPicker, just set the new one
            int eventType = _random.Next(0, 4);
            switch (eventType)
            {
                case 0:
                    events.IsEarthquakeActive = true;
                    return new EventResult(
                        "Earthquake",
                        "The ground shakes violently beneath your feet. Buildings crack and crumble, and dust fills the air. Aftershocks continue for hours as people flee to open spaces.",
                        "Disaster"
                    );
                case 1:
                    events.IsFloodActive = true;
                    return new EventResult(
                        "Flood",
                        "Heavy rains have caused the river to overflow its banks. Water rushes through the lower districts, forcing families to evacuate to higher ground. Belongings float away in the current.",
                        "Disaster"
                    );
                case 2:
                    events.isDroughtActive = true;
                    return new EventResult(
                        "Drought",
                        "The sun beats down mercilessly. Crops wither in the fields, and wells run dry. Farmers watch helplessly as their livelihood turns to dust.",
                        "Disaster"
                    );
                case 3:
                    events.IsStormActive = true;
                    return new EventResult(
                        "Severe Storm",
                        "Dark clouds gather and lightning splits the sky. Howling winds tear at roofs and knock down trees. Thunder crashes like the anger of the gods themselves.",
                        "Disaster"
                    );
                default:
                    return new EventResult("Unknown Event", "Something strange has occurred.", "Disaster");
            }
        }
    }
}
