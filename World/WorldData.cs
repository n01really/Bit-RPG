using System.Collections.Generic;
using System.Linq;
using Bit_RPG.Models;

namespace Bit_RPG.World
{
    public static class WorldData
    {
        private static Dictionary<string, CountryModel> _countries;
        private static Dictionary<string, CitiesModel> _cities;
        private static Dictionary<string, TownsModels> _towns;
        private static Dictionary<string, VillageModel> _villages;

        static WorldData()
        {
            InitializeData();
        }

        private static void InitializeData()
        {
            InitializeCountries();
            InitializeCities();
            InitializeTowns();
            InitializeVillages();
        }

        private static void InitializeCountries()
        {
            _countries = new Dictionary<string, CountryModel>
            {
                { "Eldoria", new CountryModel { Name = "Eldoria", Description = "A prosperous kingdom known for its rich culture", Capital = "Silverhold", MajorityRace = "Human" } },
                { "Valoria", new CountryModel { Name = "Valoria", Description = "A land of brave warriors and skilled artisans", Capital = "Ironpeak", MajorityRace = "Human" } },
                { "Nordheim", new CountryModel { Name = "Nordheim", Description = "A rugged land of fierce warriors and harsh winters", Capital = "Frosthold", MajorityRace = "Human" } },
                { "Aranthia", new CountryModel { Name = "Aranthia", Description = "A kingdom of scholars and mages, known for its grand libraries", Capital = "Starhaven", MajorityRace = "Human" } }
            };
        }

        private static void InitializeCities()
        {
            _cities = new Dictionary<string, CitiesModel>
            {
                // Eldoria Cities
                { "Silverhold", new CitiesModel { Name = "Silverhold", Description = "The capital city of Eldoria, known for its silver mines and grand architecture.", Country = "Eldoria", IsCapital = true, NearbyTowns = new List<string> { "Arn", "Oakvale", "Silverbridge", "Meadowbrook" }, NearbyVillages = new List<string> { "Riverside Hamlet", "Oakshire", "Bridgeview", "Greenfield" } } },
                { "Southhold", new CitiesModel { Name = "Southhold", Description = "A major trade city in Eldoria, bustling with merchants and travelers.", Country = "Eldoria", IsCapital = false, NearbyTowns = new List<string> { "Merchants Rest", "Crossroads", "Goldshire", "Fairmarket" }, NearbyVillages = new List<string> { "Trader's End", "Waypoint", "Goldleaf", "Fairhaven" } } },
                { "Old Eldoria", new CitiesModel { Name = "Old Eldoria", Description = "The ancient Capital of Eldoria, now a popular site for adventurers.", Country = "Eldoria", IsCapital = false, NearbyTowns = new List<string> { "Ruinwatch", "Stonehaven", "Ancestral Keep", "Lorestead" }, NearbyVillages = new List<string> { "Ruins Edge", "Stonegate", "Heritage Hollow", "Scholarsrest" } } },
                { "Antastead", new CitiesModel { Name = "Antastead", Description = "A coastal city known for its shipbuilding and trade.", Country = "Eldoria", IsCapital = false, NearbyTowns = new List<string> { "Harbor Point", "Saltmere", "Seabreeze", "Tidewater" }, NearbyVillages = new List<string> { "Sailors Cove", "Saltwater", "Windshore", "Tidemark" } } },
                { "Acornridge", new CitiesModel { Name = "Acornridge", Description = "A quaint village nestled in the hills, known for its acorn festival.", Country = "Eldoria", IsCapital = false, NearbyTowns = new List<string> { "Hillcrest", "Pinehill", "Willowbrook", "Maplewood" }, NearbyVillages = new List<string> { "Valley View", "Pinewood", "Willowdale", "Maplegrove" } } },
                
                // Valoria Cities
                { "Ironpeak", new CitiesModel { Name = "Ironpeak", Description = "The bustling capital of Valoria, famous for its blacksmiths and warriors.", Country = "Valoria", IsCapital = true, NearbyTowns = new List<string> { "Forge Town", "Warriors Rest", "Stonebridge", "Steelwater" }, NearbyVillages = new List<string> { "Anvil Creek", "Blade's Edge", "Stonecross", "Ironspring" } } },
                { "Wramham", new CitiesModel { Name = "Wramham", Description = "A small City known for its agriculture and friendly folk.", Country = "Valoria", IsCapital = false, NearbyTowns = new List<string> { "Harvest Home", "Farmstead", "Granary", "Orchard Vale" }, NearbyVillages = new List<string> { "Wheatfield", "Croplands", "Barleybrook", "Applewood" } } },
                { "Raso", new CitiesModel { Name = "Raso", Description = "A bustling trade city located at the crossroads of major trade routes.", Country = "Valoria", IsCapital = false, NearbyTowns = new List<string> { "Merchants Gate", "Caravan Stop", "Tradeway", "Silk Road" }, NearbyVillages = new List<string> { "Gateway", "Rest Haven", "Pathside", "Weavers Den" } } },
                { "Cadena", new CitiesModel { Name = "Cadena", Description = "A vibrant city known for its cultural festivals and artistic community.", Country = "Valoria", IsCapital = false, NearbyTowns = new List<string> { "Artists Quarter", "Festival Grounds", "Minstrel's Haven", "Theater Town" }, NearbyVillages = new List<string> { "Canvas Corner", "Celebration", "Songbird", "Stage's End" } } },
                { "Gruxmery", new CitiesModel { Name = "Gruxmery", Description = "A city known for its robust trade and diverse population.", Country = "Valoria", IsCapital = false, NearbyTowns = new List<string> { "Crossculture", "Trade Hub", "Melting Pot", "Harbor District" }, NearbyVillages = new List<string> { "Unity", "Commerce Corner", "Spice Row", "Dockside" } } },
                
                // Nordheim Cities
                { "Frosthold", new CitiesModel { Name = "Frosthold", Description = "The icy capital of Nordheim, known for its hardy inhabitants and winter festivals.", Country = "Nordheim", IsCapital = true, NearbyTowns = new List<string> { "Icewind", "Snowpeak", "Glacier Bay", "Wintervale" }, NearbyVillages = new List<string> { "Frostbite", "Avalanche Point", "Ice Flow", "Frozen Dale" } } },
                { "Aflemland", new CitiesModel { Name = "Aflemland", Description = "A fortified city known for its military prowess and strategic location.", Country = "Nordheim", IsCapital = false, NearbyTowns = new List<string> { "Garrison Post", "Strongwall", "Watchtower", "Battleborn" }, NearbyVillages = new List<string> { "Sentry Ridge", "Wallside", "Tower's Shadow", "Warrior's Cradle" } } },
                { "Vrostead", new CitiesModel { Name = "Vrostead", Description = "A bustling trade city located at the crossroads of major trade routes.", Country = "Nordheim", IsCapital = false, NearbyTowns = new List<string> { "Market Cross", "Fur Trade", "Merchant's Walk", "Cold Market" }, NearbyVillages = new List<string> { "Four Ways", "Trappers End", "Coinside", "Ice Stall" } } },
                { "Hargen", new CitiesModel { Name = "Hargen", Description = "A cultural hub known for its festivals and artistic community.", Country = "Nordheim", IsCapital = false, NearbyTowns = new List<string> { "Festival Hall", "Skald's Rest", "Artisan's Forge", "Mead Hall" }, NearbyVillages = new List<string> { "Yule Village", "Song's End", "Craft Corner", "Honey Brook" } } },
                { "Orkstin", new CitiesModel { Name = "Orkstin", Description = "The oldest city in Nordheim", Country = "Nordheim", IsCapital = false, NearbyTowns = new List<string> { "Ancient Gate", "Elder's Watch", "Runestone", "First Settlement" }, NearbyVillages = new List<string> { "Old Passage", "Heritage Hill", "Rune Creek", "Founders Rest" } } },
                
                // Aranthia Cities
                { "Starhaven", new CitiesModel { Name = "Starhaven", Description = "The magical capital of Aranthia, renowned for its academies and libraries.", Country = "Aranthia", IsCapital = true, NearbyTowns = new List<string> { "Moonlight", "Sunspire", "Starglen", "Lunaris" }, NearbyVillages = new List<string> { "Lunar Hollow", "Solar Ridge", "Starfall", "Moonwell" } } },
                { "Word", new CitiesModel { Name = "Word", Description = "A city known for its scholars and libraries.", Country = "Aranthia", IsCapital = false, NearbyTowns = new List<string> { "Scroll Town", "Library Square", "Sage's Rest", "Archive Vale" }, NearbyVillages = new List<string> { "Inkwell", "Book's End", "Wisdom Grove", "Record Keep" } } },
                { "Xora", new CitiesModel { Name = "Xora", Description = "A mystical city renowned for its enchantments and magical artifacts.", Country = "Aranthia", IsCapital = false, NearbyTowns = new List<string> { "Enchanter's Grove", "Rune Market", "Crystal Point", "Mystic Falls" }, NearbyVillages = new List<string> { "Spell Brook", "Glyph Gate", "Prism Valley", "Mana Pool" } } },
                { "Starlight", new CitiesModel { Name = "Starlight", Description = "A luminous city known for its astronomical observatories and celestial festivals.", Country = "Aranthia", IsCapital = false, NearbyTowns = new List<string> { "Observatory Hill", "Comet's Trail", "Constellation", "Celestial Gate" }, NearbyVillages = new List<string> { "Telescope Ridge", "Tail's End", "Star Cluster", "Heaven's Door" } } },
                { "Fladon", new CitiesModel { Name = "Fladon", Description = "A city of arcane research and alchemical innovation.", Country = "Aranthia", IsCapital = false, NearbyTowns = new List<string> { "Alchemist's Quarter", "Arcane Lab", "Transmutation", "Elixir Springs" }, NearbyVillages = new List<string> { "Potion Brook", "Test Site", "Change's Edge", "Remedy Well" } } }
            };
        }

        private static void InitializeTowns()
        {
            _towns = new Dictionary<string, TownsModels>();
            
            // This is a simplified version - you would add all towns here
            // Eldoria - Silverhold Region Towns
            _towns.Add("Arn", new TownsModels { Name = "Arn", Description = "A peaceful town along the Silver River, known for its fishing industry.", Country = "Eldoria", NearbyVillages = new List<string> { "Riverside Hamlet" }, NearbyCities = new List<string> { "Silverhold" } });
            _towns.Add("Oakvale", new TownsModels { Name = "Oakvale", Description = "A town surrounded by ancient oak forests, home to skilled woodworkers.", Country = "Eldoria", NearbyVillages = new List<string> { "Oakshire" }, NearbyCities = new List<string> { "Silverhold" } });
            _towns.Add("Silverbridge", new TownsModels { Name = "Silverbridge", Description = "A prosperous town known for its grand bridge spanning the river.", Country = "Eldoria", NearbyVillages = new List<string> { "Bridgeview" }, NearbyCities = new List<string> { "Silverhold" } });
            _towns.Add("Meadowbrook", new TownsModels { Name = "Meadowbrook", Description = "A serene town nestled in meadows, famous for its livestock.", Country = "Eldoria", NearbyVillages = new List<string> { "Greenfield" }, NearbyCities = new List<string> { "Silverhold" } });
            // Add more towns as needed...
        }

        private static void InitializeVillages()
        {
            _villages = new Dictionary<string, VillageModel>();
            
            // This is a simplified version - you would add all villages here
            // Eldoria - Silverhold Region Villages
            _villages.Add("Riverside Hamlet", new VillageModel { Name = "Riverside Hamlet", Description = "A tiny hamlet of fishermen along the riverbank.", Country = "Eldoria", NearbyTowns = new List<string> { "Arn" }, NearbyCities = new List<string> { "Silverhold" }, NearbyDungeons = new List<string> { "Caverns of Chaos", "Forest of Shadows", "Ruins of the Ancients", "Crystal Caves", "Abandoned Mine" } });
            _villages.Add("Oakshire", new VillageModel { Name = "Oakshire", Description = "A small village of woodcutters living among the oaks.", Country = "Eldoria", NearbyTowns = new List<string> { "Oakvale" }, NearbyCities = new List<string> { "Silverhold" } });
            _villages.Add("Bridgeview", new VillageModel { Name = "Bridgeview", Description = "A quaint village with views of the great bridge.", Country = "Eldoria", NearbyTowns = new List<string> { "Silverbridge" }, NearbyCities = new List<string> { "Silverhold" } });
            _villages.Add("Greenfield", new VillageModel { Name = "Greenfield", Description = "A pastoral village surrounded by green pastures.", Country = "Eldoria", NearbyTowns = new List<string> { "Meadowbrook" }, NearbyCities = new List<string> { "Silverhold" } });
            // Add more villages as needed...
        }

        public static CountryModel GetCountry(string name)
        {
            _countries.TryGetValue(name, out var country);
            return country;
        }

        public static CitiesModel GetCity(string name)
        {
            _cities.TryGetValue(name, out var city);
            return city;
        }

        public static TownsModels GetTown(string name)
        {
            _towns.TryGetValue(name, out var town);
            return town;
        }

        public static VillageModel GetVillage(string name)
        {
            _villages.TryGetValue(name, out var village);
            return village;
        }

        public static string GetCapitalOfCountry(string countryName)
        {
            var country = GetCountry(countryName);
            return country?.Capital ?? "";
        }

        public static List<VillageModel> GetVillagesWithDungeon(string dungeonName)
        {
            return _villages.Values
                .Where(v => v.NearbyDungeons != null && v.NearbyDungeons.Contains(dungeonName))
                .ToList();
        }

        public static IEnumerable<CountryModel> GetAllCountries() => _countries.Values;
        public static IEnumerable<CitiesModel> GetAllCities() => _cities.Values;
        public static IEnumerable<TownsModels> GetAllTowns() => _towns.Values;
        public static IEnumerable<VillageModel> GetAllVillages() => _villages.Values;
    }
}
