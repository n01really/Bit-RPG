using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Models;
using Bit_RPG.Char.NPCs;

namespace Bit_RPG.World
{
    internal class Countries
    {
        public static void HumanKingdoms()
        {
            HumanNpc humanNames = new HumanNpc();
            CountryModel HumanCountry1 = new CountryModel
            {
                Name = "Eldoria",
                Description = "A prosperous kingdom known for its rich culture",
                Capital = "Silverhold",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HunanCountry2 = new CountryModel
            {
                Name = "Valoria",
                Description = "A land of brave warriors and skilled artisans",
                Capital = "Ironpeak",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HumanCountry3 = new CountryModel
            {
                Name = "Nordheim",
                Description = "A rugged land of fierce warriors and harsh winters",
                Capital = "Frosthold",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
            CountryModel HumanCountry4 = new CountryModel
            {
                Name = "Aranthia",
                Description = "A kingdom of scholars and mages, known for its grand libraries",
                Capital = "Starhaven",
                Ruler = humanNames.GetRandomNobleRulerName(),
                MajorityRace = "Human"
            };
        }
    }
    internal class Cities
    {
        public static void HumanCities()
        {
            HumanNpc humanNames = new HumanNpc();
            CitiesModel Silverhold = new CitiesModel
            {
                Name = "Silverhold",
                Description = "The capital city of Eldoria, known for its silver mines and grand architecture.",
                Country = "Eldoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Rivertown", "Oakvale" },
                NearbyVillages = new List<string> { "Willowbrook", "Pinehill" },
                IsCapital = true
            };

            CitiesModel Southhold = new CitiesModel
            {
                Name = "Southhold",
                Description = "A major trade city in Eldoria, bustling with merchants and travelers.",
                Country = "Eldoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Rivertown", "Oakvale" },
                NearbyVillages = new List<string> { "Willowbrook", "Pinehill" },
                IsCapital = false
            };

            CitiesModel OldEldoria = new CitiesModel
            {
                Name = "Old Eldoria",
                Description = "The ancient Capital of Eldoria, now a popular site for adventurers.",
                Country = "Eldoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Rivertown", "Oakvale" },
                NearbyVillages = new List<string> { "Willowbrook", "Pinehill" },
                IsCapital = false
            };

            CitiesModel Antastead = new CitiesModel
            {
                Name = "Antastead",
                Description = "A coastal city known for its shipbuilding and trade.",
                Country = "Eldoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = false
            };

            CitiesModel Acornridge = new CitiesModel
            {
                Name = "Acornridge",
                Description = "A quaint village nestled in the hills, known for its acorn festival.",
                Country = "Eldoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Rivertown", "Oakvale" },
                NearbyVillages = new List<string> { "Willowbrook", "Pinehill" },
                IsCapital = false
            };

            CitiesModel Ironpeak = new CitiesModel
            {
                Name = "Ironpeak",
                Description = "The bustling capital of Valoria, famous for its blacksmiths and warriors.",
                Country = "Valoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = true
            };

            CitiesModel Wramham = new CitiesModel
            {
                Name = "Wramham",
                Description = "A small City known for its agriculture and friendly folk.",
                Country = "Valoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = false
            };

            CitiesModel Raso = new CitiesModel
            {
                Name = "Raso",
                Description = "A bustling trade city located at the crossroads of major trade routes.",
                Country = "Valoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = false
            };

            CitiesModel Cadena = new CitiesModel
            {
                Name = "Cadena",
                Description = "A vibrant city known for its cultural festivals and artistic community.",
                Country = "Valoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = false
            };

            CitiesModel Gruxmery = new CitiesModel
            {
                Name = "Gruxmery",
                Description = "A city known for its robust trade and diverse population.",
                Country = "Valoria",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Stonebridge", "Goldshire" },
                NearbyVillages = new List<string> { "Maplewood", "Cedarfield" },
                IsCapital = false
            };

            CitiesModel Frosthold = new CitiesModel
            {
                Name = "Frosthold",
                Description = "The icy capital of Nordheim, known for its hardy inhabitants and winter festivals.",
                Country = "Nordheim",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Icewind", "Snowpeak" },
                NearbyVillages = new List<string> { "Glacier Bay", "Wintervale" },
                IsCapital = true
            };

            CitiesModel Aflemland = new CitiesModel
            {
                Name = "Aflemland",
                Description = "A fortified city known for its military prowess and strategic location.",
                Country = "Nordheim",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Icewind", "Snowpeak" },
                NearbyVillages = new List<string> { "Glacier Bay", "Wintervale" },
                IsCapital = false
            };

            CitiesModel Vrostead = new CitiesModel
            {
                Name = "Vrostead",
                Description = "A bustling trade city located at the crossroads of major trade routes.",
                Country = "Nordheim",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Icewind", "Snowpeak" },
                NearbyVillages = new List<string> { "Glacier Bay", "Wintervale" },
                IsCapital = false
            };

            CitiesModel Hargen = new CitiesModel
            {
                Name = "Hargen",
                Description = "A cultural hub known for its festivals and artistic community.",
                Country = "Nordheim",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Icewind", "Snowpeak" },
                NearbyVillages = new List<string> { "Glacier Bay", "Wintervale" },
                IsCapital = false
            };

            CitiesModel Orkstin = new CitiesModel
            {
                Name = "Orkstin",
                Description = "The oldest city in Nordheim",
                Country = "Nordheim",
                Lord = humanNames.GetRandomNobleName(),
                NearbyTowns = new List<string> { },
                NearbyVillages = new List<string> { },
                IsCapital = false
            };

            CitiesModel Starhaven = new CitiesModel
            {
                Name = "Starhaven",
                Description = "The magical capital of Aranthia, renowned for its academies and libraries.",
                Country = "Aranthia",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Moonlight", "Sunspire" },
                NearbyVillages = new List<string> { "Starglen", "Lunaris" },
                IsCapital = true
            };

            CitiesModel Word = new CitiesModel
            {
                Name = "Word",
                Description = "A city known for its scholars and libraries.",
                Country = "Aranthia",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Moonlight", "Sunspire" },
                NearbyVillages = new List<string> { "Starglen", "Lunaris" },
                IsCapital = false
            };

            CitiesModel Xora = new CitiesModel
            {
                Name = "Xora",
                Description = "A mystical city renowned for its enchantments and magical artifacts.",
                Country = "Aranthia",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Moonlight", "Sunspire" },
                NearbyVillages = new List<string> { "Starglen", "Lunaris" },
                IsCapital = false
            };

            CitiesModel Starlight = new CitiesModel
            {
                Name = "Starlight",
                Description = "A luminous city known for its astronomical observatories and celestial festivals.",
                Country = "Aranthia",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Moonlight", "Sunspire" },
                NearbyVillages = new List<string> { "Starglen", "Lunaris" },
                IsCapital = false
            };

            CitiesModel Fladon = new CitiesModel
            {
                Name = "Fladon",
                Description = "A city of arcane research and alchemical innovation.",
                Country = "Aranthia",
                Lord = humanNames.GetRandomNobleRulerName(),
                NearbyTowns = new List<string> { "Moonlight", "Sunspire" },
                NearbyVillages = new List<string> { "Starglen", "Lunaris" },
                IsCapital = false
            };
        }
    }
    internal class Towns
    { 
        public static void HumanTowns()
        {
            HumanNpc humanNames = new HumanNpc();

            // Eldoria - Silverhold Towns
            TownsModels SilverholdTown1 = new TownsModels
            {
                Name = "Arn",
                Description = "A peaceful town along the Silver River, known for its fishing industry.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Riverside Hamlet" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            TownsModels SilverholdTown2 = new TownsModels
            {
                Name = "Oakvale",
                Description = "A town surrounded by ancient oak forests, home to skilled woodworkers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Oakshire" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            TownsModels SilverholdTown3 = new TownsModels
            {
                Name = "Silverbridge",
                Description = "A prosperous town known for its grand bridge spanning the river.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Bridgeview" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            TownsModels SilverholdTown4 = new TownsModels
            {
                Name = "Meadowbrook",
                Description = "A serene town nestled in meadows, famous for its livestock.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Greenfield" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            // Eldoria - Southhold Towns
            TownsModels SouthholdTown1 = new TownsModels
            {
                Name = "Merchants Rest",
                Description = "A bustling market town where traders gather.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Trader's End" },
                NearbyCities = new List<string> { "Southhold" }
            };

            TownsModels SouthholdTown2 = new TownsModels
            {
                Name = "Crossroads",
                Description = "A strategic town at the intersection of major trade routes.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Waypoint" },
                NearbyCities = new List<string> { "Southhold" }
            };

            TownsModels SouthholdTown3 = new TownsModels
            {
                Name = "Goldshire",
                Description = "A wealthy town known for its goldsmiths and jewelers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Goldleaf" },
                NearbyCities = new List<string> { "Southhold" }
            };

            TownsModels SouthholdTown4 = new TownsModels
            {
                Name = "Fairmarket",
                Description = "A town famous for its weekly markets and festivals.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Fairhaven" },
                NearbyCities = new List<string> { "Southhold" }
            };

            // Eldoria - Old Eldoria Towns
            TownsModels OldEldoriaTown1 = new TownsModels
            {
                Name = "Ruinwatch",
                Description = "A town built near ancient ruins, popular with adventurers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Ruins Edge" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            TownsModels OldEldoriaTown2 = new TownsModels
            {
                Name = "Stonehaven",
                Description = "A fortified town with ancient stone walls.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Stonegate" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            TownsModels OldEldoriaTown3 = new TownsModels
            {
                Name = "Ancestral Keep",
                Description = "A historic town preserving the heritage of old Eldoria.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Heritage Hollow" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            TownsModels OldEldoriaTown4 = new TownsModels
            {
                Name = "Lorestead",
                Description = "A scholarly town dedicated to preserving ancient knowledge.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Scholarsrest" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            // Eldoria - Antastead Towns
            TownsModels AntasteadTown1 = new TownsModels
            {
                Name = "Harbor Point",
                Description = "A coastal town with a busy harbor and shipyard.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Sailors Cove" },
                NearbyCities = new List<string> { "Antastead" }
            };

            TownsModels AntasteadTown2 = new TownsModels
            {
                Name = "Saltmere",
                Description = "A fishing town known for its salt production.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Saltwater" },
                NearbyCities = new List<string> { "Antastead" }
            };

            TownsModels AntasteadTown3 = new TownsModels
            {
                Name = "Seabreeze",
                Description = "A pleasant coastal town with refreshing sea winds.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Windshore" },
                NearbyCities = new List<string> { "Antastead" }
            };

            TownsModels AntasteadTown4 = new TownsModels
            {
                Name = "Tidewater",
                Description = "A maritime town dependent on the tides for trade.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Tidemark" },
                NearbyCities = new List<string> { "Antastead" }
            };

            // Eldoria - Acornridge Towns
            TownsModels AcornridgeTown1 = new TownsModels
            {
                Name = "Hillcrest",
                Description = "A hilltop town with stunning views of the surrounding valleys.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Valley View" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            TownsModels AcornridgeTown2 = new TownsModels
            {
                Name = "Pinehill",
                Description = "A forested town surrounded by pine trees.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Pinewood" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            TownsModels AcornridgeTown3 = new TownsModels
            {
                Name = "Willowbrook",
                Description = "A peaceful town by a babbling brook lined with willows.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Willowdale" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            TownsModels AcornridgeTown4 = new TownsModels
            {
                Name = "Maplewood",
                Description = "A town famous for its maple syrup production.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Eldoria",
                NearbyVillages = new List<string> { "Maplegrove" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            // Valoria - Ironpeak Towns
            TownsModels IronpeakTown1 = new TownsModels
            {
                Name = "Forge Town",
                Description = "A town of blacksmiths and metalworkers serving the capital.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Anvil Creek" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            TownsModels IronpeakTown2 = new TownsModels
            {
                Name = "Warriors Rest",
                Description = "A training town for Valoria's finest warriors.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Blade's Edge" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            TownsModels IronpeakTown3 = new TownsModels
            {
                Name = "Stonebridge",
                Description = "A sturdy town built around a massive stone bridge.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Stonecross" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            TownsModels IronpeakTown4 = new TownsModels
            {
                Name = "Steelwater",
                Description = "A town known for tempering steel in its mineral-rich waters.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Ironspring" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            // Valoria - Wramham Towns
            TownsModels WramhamTown1 = new TownsModels
            {
                Name = "Harvest Home",
                Description = "An agricultural town producing grain for the kingdom.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Wheatfield" },
                NearbyCities = new List<string> { "Wramham" }
            };

            TownsModels WramhamTown2 = new TownsModels
            {
                Name = "Farmstead",
                Description = "A quiet farming town with fertile lands.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Croplands" },
                NearbyCities = new List<string> { "Wramham" }
            };

            TownsModels WramhamTown3 = new TownsModels
            {
                Name = "Granary",
                Description = "A town centered around massive grain storage facilities.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Barleybrook" },
                NearbyCities = new List<string> { "Wramham" }
            };

            TownsModels WramhamTown4 = new TownsModels
            {
                Name = "Orchard Vale",
                Description = "A town surrounded by fruit orchards.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Applewood" },
                NearbyCities = new List<string> { "Wramham" }
            };

            // Valoria - Raso Towns
            TownsModels RasoTown1 = new TownsModels
            {
                Name = "Merchants Gate",
                Description = "The primary entry point for traders entering Raso.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Gateway" },
                NearbyCities = new List<string> { "Raso" }
            };

            TownsModels RasoTown2 = new TownsModels
            {
                Name = "Caravan Stop",
                Description = "A rest stop for traveling merchants and their caravans.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Rest Haven" },
                NearbyCities = new List<string> { "Raso" }
            };

            TownsModels RasoTown3 = new TownsModels
            {
                Name = "Tradeway",
                Description = "A town built along the main trade route.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Pathside" },
                NearbyCities = new List<string> { "Raso" }
            };

            TownsModels RasoTown4 = new TownsModels
            {
                Name = "Silk Road",
                Description = "A town famous for exotic silk and fabric trade.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Weavers Den" },
                NearbyCities = new List<string> { "Raso" }
            };

            // Valoria - Cadena Towns
            TownsModels CadenaTown1 = new TownsModels
            {
                Name = "Artists Quarter",
                Description = "A bohemian town filled with painters and sculptors.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Canvas Corner" },
                NearbyCities = new List<string> { "Cadena" }
            };

            TownsModels CadenaTown2 = new TownsModels
            {
                Name = "Festival Grounds",
                Description = "A town hosting year-round cultural celebrations.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Celebration" },
                NearbyCities = new List<string> { "Cadena" }
            };

            TownsModels CadenaTown3 = new TownsModels
            {
                Name = "Minstrel's Haven",
                Description = "A town where musicians and bards gather to perform.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Songbird" },
                NearbyCities = new List<string> { "Cadena" }
            };

            TownsModels CadenaTown4 = new TownsModels
            {
                Name = "Theater Town",
                Description = "A town with numerous theaters and performance halls.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Stage's End" },
                NearbyCities = new List<string> { "Cadena" }
            };

            // Valoria - Gruxmery Towns
            TownsModels GruxmeryTown1 = new TownsModels
            {
                Name = "Crossculture",
                Description = "A diverse town where many cultures blend together.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Unity" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            TownsModels GruxmeryTown2 = new TownsModels
            {
                Name = "Trade Hub",
                Description = "A commercial center with merchants from distant lands.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Commerce Corner" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            TownsModels GruxmeryTown3 = new TownsModels
            {
                Name = "Melting Pot",
                Description = "A town famous for its diverse cuisine and customs.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Spice Row" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            TownsModels GruxmeryTown4 = new TownsModels
            {
                Name = "Harbor District",
                Description = "A port town handling international trade.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Valoria",
                NearbyVillages = new List<string> { "Dockside" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            // Nordheim - Frosthold Towns
            TownsModels FrostholdTown1 = new TownsModels
            {
                Name = "Icewind",
                Description = "A frozen town enduring harsh northern winds.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Frostbite" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            TownsModels FrostholdTown2 = new TownsModels
            {
                Name = "Snowpeak",
                Description = "A mountain town perpetually covered in snow.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Avalanche Point" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            TownsModels FrostholdTown3 = new TownsModels
            {
                Name = "Glacier Bay",
                Description = "A town built near massive glaciers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Ice Flow" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            TownsModels FrostholdTown4 = new TownsModels
            {
                Name = "Wintervale",
                Description = "A valley town experiencing eternal winter.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Frozen Dale" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            // Nordheim - Aflemland Towns
            TownsModels AflemlandTown1 = new TownsModels
            {
                Name = "Garrison Post",
                Description = "A military outpost protecting Nordheim's borders.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Sentry Ridge" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            TownsModels AflemlandTown2 = new TownsModels
            {
                Name = "Strongwall",
                Description = "A fortified town with impenetrable walls.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Wallside" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            TownsModels AflemlandTown3 = new TownsModels
            {
                Name = "Watchtower",
                Description = "A strategic town built around ancient watchtowers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Tower's Shadow" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            TownsModels AflemlandTown4 = new TownsModels
            {
                Name = "Battleborn",
                Description = "A town where warriors are trained from birth.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Warrior's Cradle" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            // Nordheim - Vrostead Towns
            TownsModels VrosteadTown1 = new TownsModels
            {
                Name = "Market Cross",
                Description = "A trading town at the crossroads of northern routes.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Four Ways" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            TownsModels VrosteadTown2 = new TownsModels
            {
                Name = "Fur Trade",
                Description = "A town specializing in fur trading and trapping.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Trappers End" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            TownsModels VrosteadTown3 = new TownsModels
            {
                Name = "Merchant's Walk",
                Description = "A prosperous town along the merchant trail.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Coinside" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            TownsModels VrosteadTown4 = new TownsModels
            {
                Name = "Cold Market",
                Description = "A frozen marketplace town with unique goods.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Ice Stall" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            // Nordheim - Hargen Towns
            TownsModels HargenTown1 = new TownsModels
            {
                Name = "Festival Hall",
                Description = "A cultural town hosting Nordheim's winter festivals.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Yule Village" },
                NearbyCities = new List<string> { "Hargen" }
            };

            TownsModels HargenTown2 = new TownsModels
            {
                Name = "Skald's Rest",
                Description = "A town where northern bards preserve ancient sagas.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Song's End" },
                NearbyCities = new List<string> { "Hargen" }
            };

            TownsModels HargenTown3 = new TownsModels
            {
                Name = "Artisan's Forge",
                Description = "A town of skilled craftsmen creating northern art.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Craft Corner" },
                NearbyCities = new List<string> { "Hargen" }
            };

            TownsModels HargenTown4 = new TownsModels
            {
                Name = "Mead Hall",
                Description = "A festive town famous for its mead and feasting.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { "Honey Brook" },
                NearbyCities = new List<string> { "Hargen" }
            };

            // Nordheim - Orkstin Towns
            TownsModels OrkstinTown1 = new TownsModels
            {
                Name = "Ancient Gate",
                Description = "A historic town guarding the old entrance to Orkstin.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { },
                NearbyCities = new List<string> { "Orkstin" }
            };

            TownsModels OrkstinTown2 = new TownsModels
            {
                Name = "Elder's Watch",
                Description = "A town preserving the oldest traditions of Nordheim.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { },
                NearbyCities = new List<string> { "Orkstin" }
            };

            TownsModels OrkstinTown3 = new TownsModels
            {
                Name = "Runestone",
                Description = "A town built around mysterious ancient runestones.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { },
                NearbyCities = new List<string> { "Orkstin" }
            };

            TownsModels OrkstinTown4 = new TownsModels
            {
                Name = "First Settlement",
                Description = "The oldest continuously inhabited town in Nordheim.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Nordheim",
                NearbyVillages = new List<string> { },
                NearbyCities = new List<string> { "Orkstin" }
            };

            // Aranthia - Starhaven Towns
            TownsModels StarhavenTown1 = new TownsModels
            {
                Name = "Moonlight",
                Description = "A mystical town bathed in perpetual moonlight.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Lunar Hollow" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            TownsModels StarhavenTown2 = new TownsModels
            {
                Name = "Sunspire",
                Description = "A town with towers reaching toward the sun.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Solar Ridge" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            TownsModels StarhavenTown3 = new TownsModels
            {
                Name = "Starglen",
                Description = "A serene glen where stars seem to touch the earth.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Starfall" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            TownsModels StarhavenTown4 = new TownsModels
            {
                Name = "Lunaris",
                Description = "A town dedicated to lunar magic and astronomy.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Moonwell" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            // Aranthia - Word Towns
            TownsModels WordTown1 = new TownsModels
            {
                Name = "Scroll Town",
                Description = "A town of scribes and manuscript preservation.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Inkwell" },
                NearbyCities = new List<string> { "Word" }
            };

            TownsModels WordTown2 = new TownsModels
            {
                Name = "Library Square",
                Description = "A town built around numerous smaller libraries.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Book's End" },
                NearbyCities = new List<string> { "Word" }
            };

            TownsModels WordTown3 = new TownsModels
            {
                Name = "Sage's Rest",
                Description = "A quiet town where scholars retire to write.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Wisdom Grove" },
                NearbyCities = new List<string> { "Word" }
            };

            TownsModels WordTown4 = new TownsModels
            {
                Name = "Archive Vale",
                Description = "A valley town housing vast historical archives.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Record Keep" },
                NearbyCities = new List<string> { "Word" }
            };

            // Aranthia - Xora Towns
            TownsModels XoraTown1 = new TownsModels
            {
                Name = "Enchanter's Grove",
                Description = "A mystical grove where enchanters practice their craft.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Spell Brook" },
                NearbyCities = new List<string> { "Xora" }
            };

            TownsModels XoraTown2 = new TownsModels
            {
                Name = "Rune Market",
                Description = "A town where magical runes and artifacts are traded.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Glyph Gate" },
                NearbyCities = new List<string> { "Xora" }
            };

            TownsModels XoraTown3 = new TownsModels
            {
                Name = "Crystal Point",
                Description = "A town built around naturally occurring magic crystals.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Prism Valley" },
                NearbyCities = new List<string> { "Xora" }
            };

            TownsModels XoraTown4 = new TownsModels
            {
                Name = "Mystic Falls",
                Description = "A town near waterfalls imbued with magical properties.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Mana Pool" },
                NearbyCities = new List<string> { "Xora" }
            };

            // Aranthia - Starlight Towns
            TownsModels StarlightTown1 = new TownsModels
            {
                Name = "Observatory Hill",
                Description = "A town built around celestial observation towers.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Telescope Ridge" },
                NearbyCities = new List<string> { "Starlight" }
            };

            TownsModels StarlightTown2 = new TownsModels
            {
                Name = "Comet's Trail",
                Description = "A town named after a famous comet sighting.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Tail's End" },
                NearbyCities = new List<string> { "Starlight" }
            };

            TownsModels StarlightTown3 = new TownsModels
            {
                Name = "Constellation",
                Description = "A town where buildings mirror star patterns.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Star Cluster" },
                NearbyCities = new List<string> { "Starlight" }
            };

            TownsModels StarlightTown4 = new TownsModels
            {
                Name = "Celestial Gate",
                Description = "A town believed to be a gateway to the heavens.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Heaven's Door" },
                NearbyCities = new List<string> { "Starlight" }
            };

            // Aranthia - Fladon Towns
            TownsModels FladonTown1 = new TownsModels
            {
                Name = "Alchemist's Quarter",
                Description = "A town of alchemists creating potions and elixirs.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Potion Brook" },
                NearbyCities = new List<string> { "Fladon" }
            };

            TownsModels FladonTown2 = new TownsModels
            {
                Name = "Arcane Lab",
                Description = "A research town for experimental magic.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Test Site" },
                NearbyCities = new List<string> { "Fladon" }
            };

            TownsModels FladonTown3 = new TownsModels
            {
                Name = "Transmutation",
                Description = "A town specializing in transformative magic.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Change's Edge" },
                NearbyCities = new List<string> { "Fladon" }
            };

            TownsModels FladonTown4 = new TownsModels
            {
                Name = "Elixir Springs",
                Description = "A town built around springs with alchemical properties.",
                Mayor = humanNames.GetRandomRulerName(),
                Country = "Aranthia",
                NearbyVillages = new List<string> { "Remedy Well" },
                NearbyCities = new List<string> { "Fladon" }
            };
        }
    }
    internal class Villages
    {
        public static void HumanVillages()
        {
            HumanNpc humanNames = new HumanNpc();

            // Eldoria - Silverhold Region Villages
            VillageModel RiversideHamlet = new VillageModel
            {
                Name = "Riverside Hamlet",
                Description = "A tiny hamlet of fishermen along the riverbank.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Arn" },
                NearbyCities = new List<string> { "Silverhold" },
                NearbyDungeons = new List<string> { "Caverns of Chaos", "Forest of Shadows", "Ruins of the Ancients", "Crystal Caves", "Abandoned Mine" }
            };

            VillageModel Oakshire = new VillageModel
            {
                Name = "Oakshire",
                Description = "A small village of woodcutters living among the oaks.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Oakvale" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            VillageModel Bridgeview = new VillageModel
            {
                Name = "Bridgeview",
                Description = "A quaint village with views of the great bridge.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Silverbridge" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            VillageModel Greenfield = new VillageModel
            {
                Name = "Greenfield",
                Description = "A pastoral village surrounded by green pastures.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Meadowbrook" },
                NearbyCities = new List<string> { "Silverhold" }
            };

            // Eldoria - Southhold Region Villages
            VillageModel TradersEnd = new VillageModel
            {
                Name = "Trader's End",
                Description = "A rest stop for weary merchants.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Merchants Rest" },
                NearbyCities = new List<string> { "Southhold" }
            };

            VillageModel Waypoint = new VillageModel
            {
                Name = "Waypoint",
                Description = "A small waypoint village on the trade route.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Crossroads" },
                NearbyCities = new List<string> { "Southhold" }
            };

            VillageModel Goldleaf = new VillageModel
            {
                Name = "Goldleaf",
                Description = "A village where gold leaf is crafted.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Goldshire" },
                NearbyCities = new List<string> { "Southhold" }
            };

            VillageModel Fairhaven = new VillageModel
            {
                Name = "Fairhaven",
                Description = "A fair and welcoming village.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Fairmarket" },
                NearbyCities = new List<string> { "Southhold" }
            };

            // Eldoria - Old Eldoria Region Villages
            VillageModel RuinsEdge = new VillageModel
            {
                Name = "Ruins Edge",
                Description = "A village at the edge of ancient ruins.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Ruinwatch" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            VillageModel Stonegate = new VillageModel
            {
                Name = "Stonegate",
                Description = "A village near the old stone gates.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Stonehaven" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            VillageModel HeritageHollow = new VillageModel
            {
                Name = "Heritage Hollow",
                Description = "A village preserving ancient traditions.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Ancestral Keep" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            VillageModel Scholarsrest = new VillageModel
            {
                Name = "Scholarsrest",
                Description = "A quiet village where scholars find peace.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Lorestead" },
                NearbyCities = new List<string> { "Old Eldoria" }
            };

            // Eldoria - Antastead Region Villages
            VillageModel SailorsCove = new VillageModel
            {
                Name = "Sailors Cove",
                Description = "A small fishing cove for sailors.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Harbor Point" },
                NearbyCities = new List<string> { "Antastead" }
            };

            VillageModel Saltwater = new VillageModel
            {
                Name = "Saltwater",
                Description = "A coastal village specializing in salt harvesting.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Saltmere" },
                NearbyCities = new List<string> { "Antastead" }
            };

            VillageModel Windshore = new VillageModel
            {
                Name = "Windshore",
                Description = "A breezy shore village with windmills.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Seabreeze" },
                NearbyCities = new List<string> { "Antastead" }
            };

            VillageModel Tidemark = new VillageModel
            {
                Name = "Tidemark",
                Description = "A village that marks the high tide line.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Tidewater" },
                NearbyCities = new List<string> { "Antastead" }
            };

            // Eldoria - Acornridge Region Villages
            VillageModel ValleyView = new VillageModel
            {
                Name = "Valley View",
                Description = "A hilltop village overlooking the valley.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Hillcrest" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            VillageModel Pinewood = new VillageModel
            {
                Name = "Pinewood",
                Description = "A forest village deep in the pines.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Pinehill" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            VillageModel Willowdale = new VillageModel
            {
                Name = "Willowdale",
                Description = "A peaceful dale lined with weeping willows.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Willowbrook" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            VillageModel Maplegrove = new VillageModel
            {
                Name = "Maplegrove",
                Description = "A grove village known for maple trees.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Eldoria",
                NearbyTowns = new List<string> { "Maplewood" },
                NearbyCities = new List<string> { "Acornridge" }
            };

            // Valoria - Ironpeak Region Villages
            VillageModel AnvilCreek = new VillageModel
            {
                Name = "Anvil Creek",
                Description = "A village where apprentice smiths learn their trade.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Forge Town" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            VillageModel BladesEdge = new VillageModel
            {
                Name = "Blade's Edge",
                Description = "A village where young warriors begin training.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Warriors Rest" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            VillageModel Stonecross = new VillageModel
            {
                Name = "Stonecross",
                Description = "A crossroads village near the stone bridge.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Stonebridge" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            VillageModel Ironspring = new VillageModel
            {
                Name = "Ironspring",
                Description = "A village built around iron-rich springs.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Steelwater" },
                NearbyCities = new List<string> { "Ironpeak" }
            };

            // Valoria - Wramham Region Villages
            VillageModel Wheatfield = new VillageModel
            {
                Name = "Wheatfield",
                Description = "A village surrounded by golden wheat fields.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Harvest Home" },
                NearbyCities = new List<string> { "Wramham" }
            };

            VillageModel Croplands = new VillageModel
            {
                Name = "Croplands",
                Description = "A farming village with diverse crops.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Farmstead" },
                NearbyCities = new List<string> { "Wramham" }
            };

            VillageModel Barleybrook = new VillageModel
            {
                Name = "Barleybrook",
                Description = "A village known for its barley production.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Granary" },
                NearbyCities = new List<string> { "Wramham" }
            };

            VillageModel Applewood = new VillageModel
            {
                Name = "Applewood",
                Description = "A village nestled in apple orchards.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Orchard Vale" },
                NearbyCities = new List<string> { "Wramham" }
            };

            // Valoria - Raso Region Villages
            VillageModel Gateway = new VillageModel
            {
                Name = "Gateway",
                Description = "A gateway village at the border.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Merchants Gate" },
                NearbyCities = new List<string> { "Raso" }
            };

            VillageModel RestHaven = new VillageModel
            {
                Name = "Rest Haven",
                Description = "A haven for travelers to rest.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Caravan Stop" },
                NearbyCities = new List<string> { "Raso" }
            };

            VillageModel Pathside = new VillageModel
            {
                Name = "Pathside",
                Description = "A small village alongside the main path.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Tradeway" },
                NearbyCities = new List<string> { "Raso" }
            };

            VillageModel WeaversDen = new VillageModel
            {
                Name = "Weavers Den",
                Description = "A village where silk weavers practice their craft.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Silk Road" },
                NearbyCities = new List<string> { "Raso" }
            };

            // Valoria - Cadena Region Villages
            VillageModel CanvasCorner = new VillageModel
            {
                Name = "Canvas Corner",
                Description = "A village where canvas and paint are made.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Artists Quarter" },
                NearbyCities = new List<string> { "Cadena" }
            };

            VillageModel Celebration = new VillageModel
            {
                Name = "Celebration",
                Description = "A festive village always in celebration mode.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Festival Grounds" },
                NearbyCities = new List<string> { "Cadena" }
            };

            VillageModel Songbird = new VillageModel
            {
                Name = "Songbird",
                Description = "A village where birdsong fills the air.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Minstrel's Haven" },
                NearbyCities = new List<string> { "Cadena" }
            };

            VillageModel StagesEnd = new VillageModel
            {
                Name = "Stage's End",
                Description = "A village where traveling performers retire.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Theater Town" },
                NearbyCities = new List<string> { "Cadena" }
            };

            // Valoria - Gruxmery Region Villages
            VillageModel Unity = new VillageModel
            {
                Name = "Unity",
                Description = "A village symbolizing unity among diverse peoples.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Crossculture" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            VillageModel CommerceCorner = new VillageModel
            {
                Name = "Commerce Corner",
                Description = "A small commercial village for local trade.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Trade Hub" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            VillageModel SpiceRow = new VillageModel
            {
                Name = "Spice Row",
                Description = "A village famous for exotic spices.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Melting Pot" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            VillageModel Dockside = new VillageModel
            {
                Name = "Dockside",
                Description = "A dockside village for fishermen and sailors.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Valoria",
                NearbyTowns = new List<string> { "Harbor District" },
                NearbyCities = new List<string> { "Gruxmery" }
            };

            // Nordheim - Frosthold Region Villages
            VillageModel Frostbite = new VillageModel
            {
                Name = "Frostbite",
                Description = "The coldest village in all of Nordheim.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Icewind" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            VillageModel AvalanchePoint = new VillageModel
            {
                Name = "Avalanche Point",
                Description = "A village frequently threatened by avalanches.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Snowpeak" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            VillageModel IceFlow = new VillageModel
            {
                Name = "Ice Flow",
                Description = "A village built on frozen ice flows.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Glacier Bay" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            VillageModel FrozenDale = new VillageModel
            {
                Name = "Frozen Dale",
                Description = "A dale frozen year-round.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Wintervale" },
                NearbyCities = new List<string> { "Frosthold" }
            };

            // Nordheim - Aflemland Region Villages
            VillageModel SentryRidge = new VillageModel
            {
                Name = "Sentry Ridge",
                Description = "A ridge village where sentries keep watch.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Garrison Post" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            VillageModel Wallside = new VillageModel
            {
                Name = "Wallside",
                Description = "A village built alongside the great wall.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Strongwall" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            VillageModel TowersShadow = new VillageModel
            {
                Name = "Tower's Shadow",
                Description = "A village living in the shadow of watchtowers.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Watchtower" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            VillageModel WarriorsCradle = new VillageModel
            {
                Name = "Warrior's Cradle",
                Description = "A village where warriors are born and raised.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Battleborn" },
                NearbyCities = new List<string> { "Aflemland" }
            };

            // Nordheim - Vrostead Region Villages
            VillageModel FourWays = new VillageModel
            {
                Name = "Four Ways",
                Description = "A village at the intersection of four paths.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Market Cross" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            VillageModel TrappersEnd = new VillageModel
            {
                Name = "Trappers End",
                Description = "A village where trappers sell their furs.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Fur Trade" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            VillageModel Coinside = new VillageModel
            {
                Name = "Coinside",
                Description = "A prosperous village along the merchant route.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Merchant's Walk" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            VillageModel IceStall = new VillageModel
            {
                Name = "Ice Stall",
                Description = "A frozen market stall village.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Cold Market" },
                NearbyCities = new List<string> { "Vrostead" }
            };

            // Nordheim - Hargen Region Villages
            VillageModel YuleVillage = new VillageModel
            {
                Name = "Yule Village",
                Description = "A village that celebrates Yule all year long.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Festival Hall" },
                NearbyCities = new List<string> { "Hargen" }
            };

            VillageModel SongsEnd = new VillageModel
            {
                Name = "Song's End",
                Description = "A quiet village where songs come to rest.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Skald's Rest" },
                NearbyCities = new List<string> { "Hargen" }
            };

            VillageModel CraftCorner = new VillageModel
            {
                Name = "Craft Corner",
                Description = "A village dedicated to traditional crafts.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Artisan's Forge" },
                NearbyCities = new List<string> { "Hargen" }
            };

            VillageModel HoneyBrook = new VillageModel
            {
                Name = "Honey Brook",
                Description = "A village producing the finest mead honey.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Mead Hall" },
                NearbyCities = new List<string> { "Hargen" }
            };

            // Nordheim - Orkstin Region Villages
            VillageModel OldPassage = new VillageModel
            {
                Name = "Old Passage",
                Description = "An ancient passage village from old times.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Ancient Gate" },
                NearbyCities = new List<string> { "Orkstin" }
            };

            VillageModel HeritageHill = new VillageModel
            {
                Name = "Heritage Hill",
                Description = "A hill village preserving ancient heritage.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Elder's Watch" },
                NearbyCities = new List<string> { "Orkstin" }
            };

            VillageModel RuneCreek = new VillageModel
            {
                Name = "Rune Creek",
                Description = "A village near a creek with mysterious runes.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "Runestone" },
                NearbyCities = new List<string> { "Orkstin" }
            };

            VillageModel FoundersRest = new VillageModel
            {
                Name = "Founders Rest",
                Description = "A village where the first settlers are buried.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Nordheim",
                NearbyTowns = new List<string> { "First Settlement" },
                NearbyCities = new List<string> { "Orkstin" }
            };

            // Aranthia - Starhaven Region Villages
            VillageModel LunarHollow = new VillageModel
            {
                Name = "Lunar Hollow",
                Description = "A hollow bathed in perpetual moonlight.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Moonlight" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            VillageModel SolarRidge = new VillageModel
            {
                Name = "Solar Ridge",
                Description = "A ridge where the sun's rays are strongest.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Sunspire" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            VillageModel Starfall = new VillageModel
            {
                Name = "Starfall",
                Description = "A village where falling stars are often seen.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Starglen" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            VillageModel Moonwell = new VillageModel
            {
                Name = "Moonwell",
                Description = "A village built around a magical moon well.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Lunaris" },
                NearbyCities = new List<string> { "Starhaven" }
            };

            // Aranthia - Word Region Villages
            VillageModel Inkwell = new VillageModel
            {
                Name = "Inkwell",
                Description = "A village producing the finest inks.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Scroll Town" },
                NearbyCities = new List<string> { "Word" }
            };

            VillageModel BooksEnd = new VillageModel
            {
                Name = "Book's End",
                Description = "A village where old books come to rest.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Library Square" },
                NearbyCities = new List<string> { "Word" }
            };

            VillageModel WisdomGrove = new VillageModel
            {
                Name = "Wisdom Grove",
                Description = "A grove where wise ones gather.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Sage's Rest" },
                NearbyCities = new List<string> { "Word" }
            };

            VillageModel RecordKeep = new VillageModel
            {
                Name = "Record Keep",
                Description = "A village dedicated to record keeping.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Archive Vale" },
                NearbyCities = new List<string> { "Word" }
            };

            // Aranthia - Xora Region Villages
            VillageModel SpellBrook = new VillageModel
            {
                Name = "Spell Brook",
                Description = "A brook where magical spells are practiced.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Enchanter's Grove" },
                NearbyCities = new List<string> { "Xora" }
            };

            VillageModel GlyphGate = new VillageModel
            {
                Name = "Glyph Gate",
                Description = "A village gateway marked with magical glyphs.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Rune Market" },
                NearbyCities = new List<string> { "Xora" }
            };

            VillageModel PrismValley = new VillageModel
            {
                Name = "Prism Valley",
                Description = "A valley where light refracts into rainbows.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Crystal Point" },
                NearbyCities = new List<string> { "Xora" }
            };

            VillageModel ManaPool = new VillageModel
            {
                Name = "Mana Pool",
                Description = "A village built around a pool of pure mana.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Mystic Falls" },
                NearbyCities = new List<string> { "Xora" }
            };

            // Aranthia - Starlight Region Villages
            VillageModel TelescopeRidge = new VillageModel
            {
                Name = "Telescope Ridge",
                Description = "A ridge where amateur astronomers gather.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Observatory Hill" },
                NearbyCities = new List<string> { "Starlight" }
            };

            VillageModel TailsEnd = new VillageModel
            {
                Name = "Tail's End",
                Description = "A village marking where the comet's tail ended.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Comet's Trail" },
                NearbyCities = new List<string> { "Starlight" }
            };

            VillageModel StarCluster = new VillageModel
            {
                Name = "Star Cluster",
                Description = "A cluster of homes mirroring star patterns.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Constellation" },
                NearbyCities = new List<string> { "Starlight" }
            };

            VillageModel HeavensDoor = new VillageModel
            {
                Name = "Heaven's Door",
                Description = "A village at the gateway to the heavens.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Celestial Gate" },
                NearbyCities = new List<string> { "Starlight" }
            };

            // Aranthia - Fladon Region Villages
            VillageModel PotionBrook = new VillageModel
            {
                Name = "Potion Brook",
                Description = "A brook with waters perfect for potion making.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Alchemist's Quarter" },
                NearbyCities = new List<string> { "Fladon" }
            };

            VillageModel TestSite = new VillageModel
            {
                Name = "Test Site",
                Description = "A village serving as a testing ground for new magic.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Arcane Lab" },
                NearbyCities = new List<string> { "Fladon" }
            };

            VillageModel ChangesEdge = new VillageModel
            {
                Name = "Change's Edge",
                Description = "A village constantly transforming through magic.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Transmutation" },
                NearbyCities = new List<string> { "Fladon" }
            };

            VillageModel RemedyWell = new VillageModel
            {
                Name = "Remedy Well",
                Description = "A well producing waters with healing properties.",
                Headman = humanNames.GetRandomHeadman(),
                Country = "Aranthia",
                NearbyTowns = new List<string> { "Elixir Springs" },
                NearbyCities = new List<string> { "Fladon" }
            };
        }
    }
}
