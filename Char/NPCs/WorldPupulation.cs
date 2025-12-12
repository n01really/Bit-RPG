using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Char.NPCs
{
    public class WorldNPC
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public string Job { get; set; }
        public string Location { get; set; }
    }

    public class WorldPopulation
    {
        private static WorldNPC[] _population;
        private static int _populationCount = 0;
        private const int MAX_POPULATION = 10000;
        private static readonly Random _random = new Random();

        private static readonly string[] _commonJobs = new[]
        {
            "Farmer", "Fisherman", "Carpenter", "Baker", "Butcher", "Tailor", "Weaver",
            "Potter", "Miller", "Cobbler", "Tanner", "Cooper", "Chandler", "Herbalist",
            "Innkeeper", "Stable Hand", "Guard", "Hunter", "Trapper", "Woodcutter",
            "Miner", "Stonemason", "Roofer", "Shepherd", "Dairy Worker", "Beekeeper"
        };

        private static readonly string[] _craftJobs = new[]
        {
            "Blacksmith", "Armorer", "Weaponsmith", "Jeweler", "Goldsmith", "Silversmith",
            "Locksmith", "Glazier", "Leatherworker", "Saddler", "Bowyer", "Fletcher"
        };

        private static readonly string[] _merchantJobs = new[]
        {
            "Merchant", "Shopkeeper", "Trader", "Peddler", "Cloth Merchant", "Spice Trader",
            "Wine Merchant", "Grain Merchant", "Livestock Trader"
        };

        private static readonly string[] _serviceJobs = new[]
        {
            "Barber", "Healer", "Midwife", "Teacher", "Scribe", "Librarian", "Artist",
            "Musician", "Bard", "Actor", "Storyteller", "Town Crier"
        };

        private static readonly string[] _magicalJobs = new[]
        {
            "Wizard", "Enchanter", "Alchemist", "Sage", "Astrologer", "Diviner"
        };

        // Location data structures for rulers
        private static readonly Dictionary<string, string> _countryCapitals = new Dictionary<string, string>
        {
            { "Eldoria", "Silverhold" },
            { "Valoria", "Ironpeak" },
            { "Nordheim", "Frosthold" },
            { "Aranthia", "Starhaven" }
        };

        private static readonly string[] _cities = new[]
        {
            "Silverhold", "Southhold", "Old Eldoria", "Antastead", "Acornridge",
            "Ironpeak", "Wramham", "Raso", "Cadena", "Gruxmery",
            "Frosthold", "Aflemland", "Vrostead", "Hargen", "Orkstin",
            "Starhaven", "Word", "Xora", "Starlight", "Fladon"
        };

        private static readonly string[] _towns = new[]
        {
            "Arn", "Oakvale", "Silverbridge", "Meadowbrook", "Merchants Rest",
            "Crossroads", "Goldshire", "Fairmarket", "Ruinwatch", "Stonehaven",
            "Ancestral Keep", "Lorestead", "Harbor Point", "Saltmere", "Seabreeze",
            "Tidewater", "Hillcrest", "Pinehill", "Willowbrook", "Maplewood",
            "Forge Town", "Warriors Rest", "Stonebridge", "Steelwater",
            "Harvest Home", "Farmstead", "Granary", "Orchard Vale",
            "Merchants Gate", "Caravan Stop", "Tradeway", "Silk Road",
            "Artists Quarter", "Festival Grounds", "Minstrel's Haven", "Theater Town",
            "Crossculture", "Trade Hub", "Melting Pot", "Harbor District",
            "Icewind", "Snowpeak", "Glacier Bay", "Wintervale",
            "Garrison Post", "Strongwall", "Watchtower", "Battleborn",
            "Market Cross", "Fur Trade", "Merchant's Walk", "Cold Market",
            "Festival Hall", "Skald's Rest", "Artisan's Forge", "Mead Hall",
            "Ancient Gate", "Elder's Watch", "Runestone", "First Settlement",
            "Moonlight", "Sunspire", "Starglen", "Lunaris",
            "Scroll Town", "Library Square", "Sage's Rest", "Archive Vale",
            "Enchanter's Grove", "Rune Market", "Crystal Point", "Mystic Falls",
            "Observatory Hill", "Comet's Trail", "Constellation", "Celestial Gate",
            "Alchemist's Quarter", "Arcane Lab", "Transmutation", "Elixir Springs"
        };

        private static readonly string[] _villages = new[]
        {
            "Riverside Hamlet", "Oakshire", "Bridgeview", "Greenfield",
            "Trader's End", "Waypoint", "Goldleaf", "Fairhaven",
            "Ruins Edge", "Stonegate", "Heritage Hollow", "Scholarsrest",
            "Sailors Cove", "Saltwater", "Windshore", "Tidemark",
            "Valley View", "Pinewood", "Willowdale", "Maplegrove",
            "Anvil Creek", "Blade's Edge", "Stonecross", "Ironspring",
            "Wheatfield", "Croplands", "Barleybrook", "Applewood",
            "Gateway", "Rest Haven", "Pathside", "Weavers Den",
            "Canvas Corner", "Celebration", "Songbird", "Stage's End",
            "Unity", "Commerce Corner", "Spice Row", "Dockside",
            "Frostbite", "Avalanche Point", "Ice Flow", "Frozen Dale",
            "Sentry Ridge", "Wallside", "Tower's Shadow", "Warrior's Cradle",
            "Four Ways", "Trappers End", "Coinside", "Ice Stall",
            "Yule Village", "Song's End", "Craft Corner", "Honey Brook",
            "Old Passage", "Heritage Hill", "Rune Creek", "Founders Rest",
            "Lunar Hollow", "Solar Ridge", "Starfall", "Moonwell",
            "Inkwell", "Book's End", "Wisdom Grove", "Record Keep",
            "Spell Brook", "Glyph Gate", "Prism Valley", "Mana Pool",
            "Telescope Ridge", "Tail's End", "Star Cluster", "Heaven's Door",
            "Potion Brook", "Test Site", "Change's Edge", "Remedy Well"
        };

        public static void InitializePopulation()
        {
            _population = new WorldNPC[MAX_POPULATION];
            _populationCount = 0;
        }

        public static void GenerateWorldPopulation(int totalCount = 1000)
        {
            InitializePopulation();

            HumanNpc humanGen = new HumanNpc();
            ElfNpc elfGen = new ElfNpc();
            DwarvenNpc dwarfGen = new DwarvenNpc();

            // First, generate all rulers
            GenerateRulers(humanGen, elfGen, dwarfGen);

            // Calculate remaining population to generate
            int rulersGenerated = _populationCount;
            int remainingCount = totalCount - rulersGenerated;

            if (remainingCount > 0)
            {
                // 60% Human, 25% Elf, 15% Dwarf for regular population
                int humanCount = (int)(remainingCount * 0.6);
                int elfCount = (int)(remainingCount * 0.25);
                int dwarfCount = remainingCount - humanCount - elfCount;

                // Generate Humans
                for (int i = 0; i < humanCount; i++)
                {
                    bool isMale = _random.Next(2) == 0;
                    AddNPC(
                        GetRandomHumanName(humanGen, isMale),
                        GetRandomAge(18, 80),
                        isMale ? "Male" : "Female",
                        "Human",
                        GetRandomJob(),
                        GetRandomLocation()
                    );
                }

                // Generate Elves
                for (int i = 0; i < elfCount; i++)
                {
                    bool isMale = _random.Next(2) == 0;
                    AddNPC(
                        GetRandomElfName(elfGen, isMale),
                        GetRandomAge(100, 500),
                        isMale ? "Male" : "Female",
                        "Elf",
                        GetRandomJob(),
                        GetRandomLocation()
                    );
                }

                // Generate Dwarves
                for (int i = 0; i < dwarfCount; i++)
                {
                    bool isMale = _random.Next(2) == 0;
                    AddNPC(
                        GetRandomDwarfName(dwarfGen, isMale),
                        GetRandomAge(40, 250),
                        isMale ? "Male" : "Female",
                        "Dwarf",
                        GetRandomJob(),
                        GetRandomLocation()
                    );
                }
            }
        }

        private static void GenerateRulers(HumanNpc humanGen, ElfNpc elfGen, DwarvenNpc dwarfGen)
        {
            // Generate Country Rulers (Kings/Queens)
            foreach (var countryCapital in _countryCapitals)
            {
                bool isMale = _random.Next(2) == 0;
                string rulerName = GetRulerName(humanGen, isMale, true); // noble ruler
                string job = isMale ? "King" : "Queen";
                
                AddNPC(
                    rulerName,
                    GetRandomAge(35, 65), // Rulers are typically middle-aged
                    isMale ? "Male" : "Female",
                    "Human",
                    job,
                    countryCapital.Value
                );
            }

            // Generate City Lords/Ladies
            foreach (var city in _cities)
            {
                bool isMale = _random.Next(2) == 0;
                string lordName = GetLordName(humanGen, elfGen, dwarfGen, isMale, city);
                string job = isMale ? "Lord" : "Lady";
                
                AddNPC(
                    lordName,
                    GetRandomAge(30, 60),
                    isMale ? "Male" : "Female",
                    DetermineRaceForLocation(city),
                    job,
                    city
                );
            }

            // Generate Town Mayors/Mayoresses
            foreach (var town in _towns)
            {
                bool isMale = _random.Next(2) == 0;
                string mayorName = GetMayorName(humanGen, elfGen, dwarfGen, isMale, town);
                string job = isMale ? "Mayor" : "Mayoress";
                
                AddNPC(
                    mayorName,
                    GetRandomAge(30, 55),
                    isMale ? "Male" : "Female",
                    DetermineRaceForLocation(town),
                    job,
                    town
                );
            }

            // Generate Village Headmen/Headwomen
            foreach (var village in _villages)
            {
                bool isMale = _random.Next(2) == 0;
                string headmanName = GetHeadmanName(humanGen, elfGen, dwarfGen, isMale, village);
                string job = isMale ? "Headman" : "Headwoman";
                
                AddNPC(
                    headmanName,
                    GetRandomAge(35, 70),
                    isMale ? "Male" : "Female",
                    DetermineRaceForLocation(village),
                    job,
                    village
                );
            }
        }

        private static string GetRulerName(HumanNpc humanGen, bool isMale, bool isNoble)
        {
            // For now, all country rulers are human
            return isNoble ? GetRandomHumanNobleName(humanGen, isMale) : GetRandomHumanName(humanGen, isMale);
        }

        private static string GetLordName(HumanNpc humanGen, ElfNpc elfGen, DwarvenNpc dwarfGen, bool isMale, string location)
        {
            string race = DetermineRaceForLocation(location);
            return race switch
            {
                "Elf" => GetRandomElfNobleName(elfGen, isMale),
                "Dwarf" => GetRandomDwarfNobleName(dwarfGen, isMale),
                _ => GetRandomHumanNobleName(humanGen, isMale)
            };
        }

        private static string GetMayorName(HumanNpc humanGen, ElfNpc elfGen, DwarvenNpc dwarfGen, bool isMale, string location)
        {
            string race = DetermineRaceForLocation(location);
            return race switch
            {
                "Elf" => GetRandomElfName(elfGen, isMale),
                "Dwarf" => GetRandomDwarfName(dwarfGen, isMale),
                _ => GetRandomHumanName(humanGen, isMale)
            };
        }

        private static string GetHeadmanName(HumanNpc humanGen, ElfNpc elfGen, DwarvenNpc dwarfGen, bool isMale, string location)
        {
            string race = DetermineRaceForLocation(location);
            return race switch
            {
                "Elf" => GetRandomElfName(elfGen, isMale),
                "Dwarf" => GetRandomDwarfName(dwarfGen, isMale),
                _ => GetRandomHumanName(humanGen, isMale)
            };
        }

        private static string DetermineRaceForLocation(string location)
        {
            // Majority of locations are human
            // Could be enhanced to assign specific races to certain locations
            int raceRoll = _random.Next(100);
            
            if (raceRoll < 70) return "Human";
            else if (raceRoll < 85) return "Elf";
            else return "Dwarf";
        }

        private static string GetRandomHumanNobleName(HumanNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            string house = gen.NobleHouses[_random.Next(gen.NobleHouses.Count)];
            return $"{firstName} {surname} of {house}";
        }

        private static string GetRandomElfNobleName(ElfNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            string house = gen.Houses[_random.Next(gen.Houses.Count)];
            return $"{firstName} {surname} of the {house}";
        }

        private static string GetRandomDwarfNobleName(DwarvenNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            string clan = gen.Clans[_random.Next(gen.Clans.Count)];
            return $"{firstName} {surname} of {clan}";
        }

        private static string GetRandomHumanName(HumanNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            return $"{firstName} {surname}";
        }

        private static string GetRandomElfName(ElfNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            return $"{firstName} {surname}";
        }

        private static string GetRandomDwarfName(DwarvenNpc gen, bool isMale)
        {
            string firstName = isMale
                ? gen.MaleNames[_random.Next(gen.MaleNames.Count)]
                : gen.FemaleNames[_random.Next(gen.FemaleNames.Count)];
            string surname = gen.Surnames[_random.Next(gen.Surnames.Count)];
            return $"{firstName} {surname}";
        }

        private static int GetRandomAge(int min, int max)
        {
            return _random.Next(min, max + 1);
        }

        private static string GetRandomJob()
        {
            // Weight the job selection
            int jobCategory = _random.Next(100);

            if (jobCategory < 50) // 50% common jobs
                return _commonJobs[_random.Next(_commonJobs.Length)];
            else if (jobCategory < 70) // 20% craft jobs
                return _craftJobs[_random.Next(_craftJobs.Length)];
            else if (jobCategory < 85) // 15% merchant jobs
                return _merchantJobs[_random.Next(_merchantJobs.Length)];
            else if (jobCategory < 95) // 10% service jobs
                return _serviceJobs[_random.Next(_serviceJobs.Length)];
            else // 5% magical jobs
                return _magicalJobs[_random.Next(_magicalJobs.Length)];
        }

        private static string GetRandomLocation()
        {
            string[] locations = new[]
            {
                // Human Kingdoms - Eldoria
                "Silverhold", "Southhold", "Old Eldoria", "Antastead", "Acornridge",
                "Arn", "Oakvale", "Silverbridge", "Meadowbrook", "Merchants Rest",
                "Crossroads", "Goldshire", "Fairmarket", "Ruinwatch", "Stonehaven",
                "Ancestral Keep", "Lorestead", "Harbor Point", "Saltmere", "Seabreeze",
                "Tidewater", "Hillcrest", "Pinehill", "Willowbrook", "Maplewood",
                
                // Valoria
                "Ironpeak", "Wramham", "Raso", "Cadena", "Gruxmery",
                "Forge Town", "Warriors Rest", "Stonebridge", "Steelwater",
                "Harvest Home", "Farmstead", "Granary", "Orchard Vale",
                "Merchants Gate", "Caravan Stop", "Tradeway", "Silk Road",
                "Artists Quarter", "Festival Grounds", "Minstrel's Haven", "Theater Town",
                "Crossculture", "Trade Hub", "Melting Pot", "Harbor District",
                
                // Nordheim
                "Frosthold", "Aflemland", "Vrostead", "Hargen", "Orkstin",
                "Icewind", "Snowpeak", "Glacier Bay", "Wintervale",
                "Garrison Post", "Strongwall", "Watchtower", "Battleborn",
                "Market Cross", "Fur Trade", "Merchant's Walk", "Cold Market",
                "Festival Hall", "Skald's Rest", "Artisan's Forge", "Mead Hall",
                
                // Aranthia
                "Starhaven", "Word", "Xora", "Starlight", "Fladon",
                "Moonlight", "Sunspire", "Starglen", "Lunaris",
                "Scroll Town", "Library Square", "Sage's Rest", "Archive Vale",
                "Enchanter's Grove", "Rune Market", "Crystal Point", "Mystic Falls",
                "Observatory Hill", "Comet's Trail", "Constellation", "Celestial Gate",
                "Alchemist's Quarter", "Arcane Lab", "Transmutation", "Elixir Springs"
            };

            return locations[_random.Next(locations.Length)];
        }

        public static void AddNPC(string name, int age, string gender, string race, string job, string location = "")
        {
            if (_population == null)
            {
                InitializePopulation();
            }

            if (_populationCount < MAX_POPULATION)
            {
                _population[_populationCount] = new WorldNPC
                {
                    Name = name,
                    Age = age,
                    Gender = gender,
                    Race = race,
                    Job = job,
                    Location = location
                };
                _populationCount++;
            }
        }

        public static WorldNPC[] GetPopulation()
        {
            if (_population == null)
            {
                return Array.Empty<WorldNPC>();
            }
            return _population.Take(_populationCount).ToArray();
        }

        public static int GetPopulationCount()
        {
            return _populationCount;
        }

        public static WorldNPC[] GetPopulationByLocation(string location)
        {
            if (_population == null)
            {
                return Array.Empty<WorldNPC>();
            }
            return _population.Take(_populationCount)
                              .Where(npc => npc.Location == location)
                              .ToArray();
        }

        public static WorldNPC[] GetPopulationByRace(string race)
        {
            if (_population == null)
            {
                return Array.Empty<WorldNPC>();
            }
            return _population.Take(_populationCount)
                              .Where(npc => npc.Race == race)
                              .ToArray();
        }

        public static WorldNPC[] GetPopulationByJob(string job)
        {
            if (_population == null)
            {
                return Array.Empty<WorldNPC>();
            }
            return _population.Take(_populationCount)
                              .Where(npc => npc.Job == job)
                              .ToArray();
        }

        public static WorldNPC GetRulerOfLocation(string location)
        {
            if (_population == null)
            {
                return null;
            }

            string[] rulerJobs = { "King", "Queen", "Lord", "Lady", "Mayor", "Mayoress", "Headman", "Headwoman" };
            
            return _population.Take(_populationCount)
                              .FirstOrDefault(npc => npc.Location == location && rulerJobs.Contains(npc.Job));
        }

        public static void ClearPopulation()
        {
            _populationCount = 0;
            if (_population != null)
            {
                Array.Clear(_population, 0, _population.Length);
            }
        }
    }
}
