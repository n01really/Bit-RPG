using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.Char.NPCs;
using Bit_RPG.Models;
using Bit_RPG.World;

namespace Bit_RPG.Events
{
    internal class WeeklyEvents
    {
        private static readonly Random _random = new Random();

        /// <summary>
        /// Gets a random weekly event. These events occur every week (on each continue button press).
        /// Weekly events are smaller, slice-of-life moments that add flavor to the game.
        /// </summary>
        public static WeeklyEventModel GetRandomWeeklyEvent(Player player)
        {
            int eventId = _random.Next(1, 11);
            
            return eventId switch
            {
                1 => MarketDayEvent(player),
                2 => TavernNightEvent(player),
                3 => TravelingMerchantEvent(player),
                4 => LocalFestivalEvent(player),
                5 => WeatherChangeEvent(player),
                6 => StreetPerformerEvent(player),
                7 => GossipEvent(player),
                8 => WildlifeEncounterEvent(player),
                9 => LocalNewsEvent(player),
                10 => RandomEncounterEvent(player),
                _ => MarketDayEvent(player)
            };
        }

        private static WeeklyEventModel MarketDayEvent(Player player)
        {
            int variant = _random.Next(1, 6);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "The weekly market is bustling with activity. Merchants hawk their wares as shoppers haggle over prices.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "Market day arrives with fresh produce from nearby farms. The smell of baked bread fills the air.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "A large caravan has arrived for market day, bringing exotic goods from distant lands.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "The market square is crowded today. Street vendors call out their best deals.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "You browse the market stalls, admiring the variety of goods on display.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 1,
                    Description = "The weekly market is bustling with activity. Merchants hawk their wares as shoppers haggle over prices.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel TavernNightEvent(Player player)
        {
            int variant = _random.Next(1, 6);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "You spend the evening at the local tavern. The atmosphere is lively with music and laughter.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "The tavern is quiet tonight. You enjoy a peaceful drink by the fireplace.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "A bard performs tales of ancient heroes at the tavern. The crowd is mesmerized.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "The tavern keeper shares local rumors over a mug of ale.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "You join a group of locals at the tavern for drinks and conversation.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 2,
                    Description = "You spend the evening at the local tavern. The atmosphere is lively with music and laughter.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel TravelingMerchantEvent(Player player)
        {
            var npcPool = WorldPopulation.GetPopulation()
                .Where(npc => npc.Job == "Merchant" || npc.Job == "Trader" || npc.Job == "Peddler")
                .ToArray();
            
            var merchant = npcPool.Length > 0 
                ? npcPool[_random.Next(npcPool.Length)]
                : null;

            return merchant != null
                ? new WeeklyEventModel
                {
                    Id = 3,
                    Description = $"A traveling merchant named {merchant.Name} arrives in town with rare goods and interesting tales from distant places.",
                    InvolvedNPC = merchant,
                    CurrentLocation = player
                }
                : new WeeklyEventModel
                {
                    Id = 3,
                    Description = "A traveling merchant passes through town with rare goods and interesting tales from distant places.",
                    CurrentLocation = player
                };
        }

        private static WeeklyEventModel LocalFestivalEvent(Player player)
        {
            int variant = _random.Next(1, 6);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "The town celebrates a harvest festival. Music, dancing, and food bring the community together.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "A religious holiday is observed with ceremonies at the local temple.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "The community gathers for a festival honoring the town's founding.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "A midsummer celebration fills the streets with joy and merriment.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "Local artisans display their crafts at a seasonal festival.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 4,
                    Description = "The town celebrates a harvest festival. Music, dancing, and food bring the community together.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel WeatherChangeEvent(Player player)
        {
            int variant = _random.Next(1, 9);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "The weather has been pleasant this week, with clear skies and gentle breezes.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "A light rain falls throughout the week, nourishing the crops and filling the wells.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "The week brings unseasonably cold weather. People bundle up and stay indoors.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "Hot, sunny days make everyone seek shade and cool drinks.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "Misty mornings give way to bright afternoons this week.",
                    CurrentLocation = player
                },
                6 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "A gentle snowfall blankets the area in white. Children play in the streets.",
                    CurrentLocation = player
                },
                7 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "Strong winds blow through the area all week, rattling shutters and bending trees.",
                    CurrentLocation = player
                },
                8 => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "The week is marked by beautiful sunsets that paint the sky in brilliant colors.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 5,
                    Description = "The weather has been pleasant this week, with clear skies and gentle breezes.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel StreetPerformerEvent(Player player)
        {
            var npcPool = WorldPopulation.GetPopulation()
                .Where(npc => npc.Job == "Bard" || npc.Job == "Musician" || npc.Job == "Actor")
                .ToArray();
            
            var performer = npcPool.Length > 0 
                ? npcPool[_random.Next(npcPool.Length)]
                : null;

            return performer != null
                ? new WeeklyEventModel
                {
                    Id = 6,
                    Description = $"{performer.Name}, a {performer.Job.ToLower()}, performs in the town square, entertaining passersby with their talent.",
                    InvolvedNPC = performer,
                    CurrentLocation = player
                }
                : new WeeklyEventModel
                {
                    Id = 6,
                    Description = "A street performer entertains passersby in the town square with music and stories.",
                    CurrentLocation = player
                };
        }

        private static WeeklyEventModel GossipEvent(Player player)
        {
            int variant = _random.Next(1, 9);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "Rumors circulate about a noble's scandalous affair in the capital.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "People whisper about mysterious lights seen in the forest at night.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "The town is abuzz with talk of a wealthy merchant who lost everything gambling.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "Gossip spreads about a local family's sudden wealth. Some claim they found treasure.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "Word travels of strange travelers asking questions about ancient ruins.",
                    CurrentLocation = player
                },
                6 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "The locals share tales of a hermit in the mountains with magical powers.",
                    CurrentLocation = player
                },
                7 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "Whispers suggest the mayor is planning to raise taxes again.",
                    CurrentLocation = player
                },
                8 => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "People discuss rumors of bandits setting up camp in the nearby hills.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 7,
                    Description = "Rumors circulate about a noble's scandalous affair in the capital.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel WildlifeEncounterEvent(Player player)
        {
            int variant = _random.Next(1, 9);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "You spot a majestic deer at the forest's edge during your morning walk.",
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "A family of foxes plays near the town outskirts. Children gather to watch.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "Birds of unusual plumage are seen migrating overhead this week.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "Fishermen report excellent catches this week, with schools of fish abundant in the river.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "A wolf's howl echoes from the distant hills at night, sending shivers down spines.",
                    CurrentLocation = player
                },
                6 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "Rabbits and other small game are plentiful. Hunters return with full bags.",
                    CurrentLocation = player
                },
                7 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "A rare white stag is spotted in the woods, considered a sign of good fortune.",
                    CurrentLocation = player
                },
                8 => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "Bears are seen preparing for winter, gathering food near the forest edge.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 8,
                    Description = "You spot a majestic deer at the forest's edge during your morning walk.",
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel LocalNewsEvent(Player player)
        {
            string locationName = "Arn";
            var ruler = WorldPopulation.GetRulerOfLocation(locationName);
            
            int variant = _random.Next(1, 9);
            
            return variant switch
            {
                1 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = $"The {ruler?.Job ?? "local leader"} announces plans for improvements to the town infrastructure.",
                    InvolvedNPC = ruler,
                    CurrentLocation = player
                },
                2 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "A local couple celebrates the birth of twins. The whole community rejoices with them.",
                    CurrentLocation = player
                },
                3 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "The town guard successfully apprehends a pickpocket who had been troubling merchants.",
                    CurrentLocation = player
                },
                4 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "A local farmer's prize-winning cow gives birth to a healthy calf.",
                    CurrentLocation = player
                },
                5 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "The town announces a new trade agreement with a neighboring settlement.",
                    CurrentLocation = player
                },
                6 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "A long-standing dispute between two families is finally settled peacefully.",
                    CurrentLocation = player
                },
                7 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "The community comes together to repair the roof of the local temple.",
                    CurrentLocation = player
                },
                8 => new WeeklyEventModel
                {
                    Id = 9,
                    Description = "A local youth leaves to pursue education in the capital. The family holds a farewell celebration.",
                    CurrentLocation = player
                },
                _ => new WeeklyEventModel
                {
                    Id = 9,
                    Description = $"The {ruler?.Job ?? "local leader"} announces plans for improvements to the town infrastructure.",
                    InvolvedNPC = ruler,
                    CurrentLocation = player
                }
            };
        }

        private static WeeklyEventModel RandomEncounterEvent(Player player)
        {
            string locationName = "Arn";
            var npcPool = WorldPopulation.GetPopulationByLocation(locationName)
                .Where(npc => !new[] { "King", "Queen", "Lord", "Lady", "Mayor", "Mayoress", "Headman", "Headwoman" }.Contains(npc.Job))
                .ToArray();
            
            var randomNPC = npcPool.Length > 0 
                ? npcPool[_random.Next(npcPool.Length)]
                : null;

            if (randomNPC != null)
            {
                int variant = _random.Next(1, 6);
                
                return variant switch
                {
                    1 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"You have a pleasant conversation with {randomNPC.Name}, a local {randomNPC.Job.ToLower()}.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    },
                    2 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"You help {randomNPC.Name}, a {randomNPC.Job.ToLower()}, carry some heavy supplies.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    },
                    3 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"You share a meal with {randomNPC.Name}, learning about their work as a {randomNPC.Job.ToLower()}.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    },
                    4 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"You encounter {randomNPC.Name} in the marketplace and exchange friendly greetings.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    },
                    5 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"{randomNPC.Name}, a {randomNPC.Job.ToLower()}, asks for your opinion on local matters.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    },
                    _ => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = $"You have a pleasant conversation with {randomNPC.Name}, a local {randomNPC.Job.ToLower()}.",
                        InvolvedNPC = randomNPC,
                        CurrentLocation = player
                    }
                };
            }
            else
            {
                int variant = _random.Next(1, 6);
                
                return variant switch
                {
                    1 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "You have a pleasant conversation with a local resident.",
                        CurrentLocation = player
                    },
                    2 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "You help a stranger carry some heavy supplies.",
                        CurrentLocation = player
                    },
                    3 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "You share a meal with someone from town.",
                        CurrentLocation = player
                    },
                    4 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "You encounter a friendly face in the marketplace.",
                        CurrentLocation = player
                    },
                    5 => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "A local resident asks for your opinion on town matters.",
                        CurrentLocation = player
                    },
                    _ => new WeeklyEventModel
                    {
                        Id = 10,
                        Description = "You have a pleasant conversation with a local resident.",
                        CurrentLocation = player
                    }
                };
            }
        }
    }
}
