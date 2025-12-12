using System;
using System.Linq;
using Bit_RPG.Char.NPCs;

namespace Bit_RPG.Examples
{
    /// <summary>
    /// Examples of how to use the WorldPopulation system (including rulers)
    /// </summary>
    public static class PopulationExamples
    {
        /// <summary>
        /// Find a blacksmith in a specific town
        /// </summary>
        public static WorldNPC FindBlacksmithInTown(string townName)
        {
            var townNPCs = WorldPopulation.GetPopulationByLocation(townName);
            return townNPCs.FirstOrDefault(npc => npc.Job == "Blacksmith");
        }

        /// <summary>
        /// Get all merchants in the world
        /// </summary>
        public static WorldNPC[] GetAllMerchants()
        {
            return WorldPopulation.GetPopulationByJob("Merchant");
        }

        /// <summary>
        /// Get the ruler of a specific location
        /// </summary>
        public static WorldNPC GetRuler(string location)
        {
            return WorldPopulation.GetRulerOfLocation(location);
        }

        /// <summary>
        /// Get all kings and queens in the world
        /// </summary>
        public static WorldNPC[] GetAllMonarchs()
        {
            var kings = WorldPopulation.GetPopulationByJob("King");
            var queens = WorldPopulation.GetPopulationByJob("Queen");
            return kings.Concat(queens).ToArray();
        }

        /// <summary>
        /// Get all nobility (Kings, Queens, Lords, Ladies)
        /// </summary>
        public static WorldNPC[] GetAllNobility()
        {
            return WorldPopulation.GetPopulation()
                .Where(npc => new[] { "King", "Queen", "Lord", "Lady" }.Contains(npc.Job))
                .ToArray();
        }

        /// <summary>
        /// Get all local leaders (Mayors, Headmen)
        /// </summary>
        public static WorldNPC[] GetAllLocalLeaders()
        {
            return WorldPopulation.GetPopulation()
                .Where(npc => new[] { "Mayor", "Mayoress", "Headman", "Headwoman" }.Contains(npc.Job))
                .ToArray();
        }

        /// <summary>
        /// Get population statistics for a town (including ruler)
        /// </summary>
        public static string GetTownStatistics(string townName)
        {
            var townPop = WorldPopulation.GetPopulationByLocation(townName);
            
            if (townPop.Length == 0)
                return $"No population data for {townName}";

            var ruler = WorldPopulation.GetRulerOfLocation(townName);
            var humanCount = townPop.Count(npc => npc.Race == "Human");
            var elfCount = townPop.Count(npc => npc.Race == "Elf");
            var dwarfCount = townPop.Count(npc => npc.Race == "Dwarf");
            var avgAge = (int)townPop.Average(npc => npc.Age);

            string rulerInfo = ruler != null 
                ? $"Ruler: {ruler.Name} ({ruler.Job})\n" 
                : "Ruler: Unknown\n";

            return $"{townName} Population Statistics:\n" +
                   rulerInfo +
                   $"Total: {townPop.Length}\n" +
                   $"Humans: {humanCount}\n" +
                   $"Elves: {elfCount}\n" +
                   $"Dwarves: {dwarfCount}\n" +
                   $"Average Age: {avgAge} years";
        }

        /// <summary>
        /// Find the oldest NPC in the world
        /// </summary>
        public static WorldNPC GetOldestNPC()
        {
            var population = WorldPopulation.GetPopulation();
            return population.OrderByDescending(npc => npc.Age).FirstOrDefault();
        }

        /// <summary>
        /// Find the youngest ruler
        /// </summary>
        public static WorldNPC GetYoungestRuler()
        {
            string[] rulerJobs = { "King", "Queen", "Lord", "Lady", "Mayor", "Mayoress", "Headman", "Headwoman" };
            
            return WorldPopulation.GetPopulation()
                .Where(npc => rulerJobs.Contains(npc.Job))
                .OrderBy(npc => npc.Age)
                .FirstOrDefault();
        }

        /// <summary>
        /// Find all wizards in magical cities
        /// </summary>
        public static WorldNPC[] GetWizardsInMagicalCities()
        {
            string[] magicalCities = { "Starhaven", "Xora", "Starlight", "Fladon" };
            
            return WorldPopulation.GetPopulation()
                .Where(npc => npc.Job == "Wizard" && magicalCities.Contains(npc.Location))
                .ToArray();
        }

        /// <summary>
        /// Get all NPCs of a specific race in a specific location
        /// </summary>
        public static WorldNPC[] GetRaceInLocation(string race, string location)
        {
            return WorldPopulation.GetPopulationByLocation(location)
                .Where(npc => npc.Race == race)
                .ToArray();
        }

        /// <summary>
        /// Find potential quest givers (specific jobs + rulers)
        /// </summary>
        public static WorldNPC[] GetPotentialQuestGivers(string location)
        {
            string[] questGiverJobs = { 
                "Mayor", "Mayoress", "Headman", "Headwoman", "Lord", "Lady", "King", "Queen",
                "Merchant", "Wizard", "Blacksmith", "Healer", 
                "Teacher", "Librarian", "Sage", "Town Crier" 
            };

            return WorldPopulation.GetPopulationByLocation(location)
                .Where(npc => questGiverJobs.Contains(npc.Job))
                .ToArray();
        }

        /// <summary>
        /// Get world-wide race distribution
        /// </summary>
        public static void PrintRaceDistribution()
        {
            var population = WorldPopulation.GetPopulation();
            var total = population.Length;

            var humans = population.Count(npc => npc.Race == "Human");
            var elves = population.Count(npc => npc.Race == "Elf");
            var dwarves = population.Count(npc => npc.Race == "Dwarf");

            Console.WriteLine("World Race Distribution:");
            Console.WriteLine($"Total Population: {total}");
            Console.WriteLine($"Humans: {humans} ({humans * 100 / total}%)");
            Console.WriteLine($"Elves: {elves} ({elves * 100 / total}%)");
            Console.WriteLine($"Dwarves: {dwarves} ({dwarves * 100 / total}%)");
        }

        /// <summary>
        /// Get world-wide job distribution
        /// </summary>
        public static void PrintJobDistribution()
        {
            var population = WorldPopulation.GetPopulation();
            var jobGroups = population.GroupBy(npc => npc.Job)
                .OrderByDescending(g => g.Count())
                .Take(15);

            Console.WriteLine("Top 15 Most Common Jobs:");
            foreach (var group in jobGroups)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} NPCs");
            }
        }

        /// <summary>
        /// Get ruler statistics
        /// </summary>
        public static void PrintRulerStatistics()
        {
            var population = WorldPopulation.GetPopulation();
            
            var kings = population.Count(npc => npc.Job == "King");
            var queens = population.Count(npc => npc.Job == "Queen");
            var lords = population.Count(npc => npc.Job == "Lord");
            var ladies = population.Count(npc => npc.Job == "Lady");
            var mayors = population.Count(npc => npc.Job == "Mayor");
            var mayoresses = population.Count(npc => npc.Job == "Mayoress");
            var headmen = population.Count(npc => npc.Job == "Headman");
            var headwomen = population.Count(npc => npc.Job == "Headwoman");

            Console.WriteLine("Ruler Statistics:");
            Console.WriteLine($"Kings: {kings}");
            Console.WriteLine($"Queens: {queens}");
            Console.WriteLine($"Lords: {lords}");
            Console.WriteLine($"Ladies: {ladies}");
            Console.WriteLine($"Mayors: {mayors}");
            Console.WriteLine($"Mayoresses: {mayoresses}");
            Console.WriteLine($"Headmen: {headmen}");
            Console.WriteLine($"Headwomen: {headwomen}");
            Console.WriteLine($"Total Rulers: {kings + queens + lords + ladies + mayors + mayoresses + headmen + headwomen}");
        }

        /// <summary>
        /// Meet the ruler of a location - Interactive example
        /// </summary>
        public static string MeetLocalRuler(string location)
        {
            var ruler = WorldPopulation.GetRulerOfLocation(location);
            
            if (ruler == null)
                return $"No ruler found for {location}. It appears to be ungoverned.";
            
            string greeting = ruler.Job switch
            {
                "King" => $"You are granted an audience with {ruler.Name}. The King sits upon his throne, regarding you with regal authority.",
                "Queen" => $"You are granted an audience with {ruler.Name}. The Queen sits upon her throne, her presence commanding respect.",
                "Lord" => $"You enter the manor and meet {ruler.Name}, Lord of {location}. He welcomes you to his estate.",
                "Lady" => $"You enter the manor and meet {ruler.Name}, Lady of {location}. She greets you warmly in her estate.",
                "Mayor" => $"You visit the town hall where {ruler.Name}, the Mayor, greets you with a firm handshake.",
                "Mayoress" => $"You visit the town hall where {ruler.Name}, the Mayoress, greets you with a welcoming smile.",
                "Headman" => $"You meet {ruler.Name}, the Headman of this village. He invites you into his cottage for a chat.",
                "Headwoman" => $"You meet {ruler.Name}, the Headwoman of this village. She offers you a seat and some tea.",
                _ => $"You meet {ruler.Name}, a person of importance in {location}."
            };
            
            return greeting + $"\n({ruler.Age} year old {ruler.Gender} {ruler.Race})";
        }

        /// <summary>
        /// Example: Interactive NPC encounter
        /// </summary>
        public static string InteractWithRandomNPCInLocation(string location)
        {
            var npcs = WorldPopulation.GetPopulationByLocation(location);
            
            if (npcs.Length == 0)
                return $"No one is around in {location}...";

            var random = new Random();
            var npc = npcs[random.Next(npcs.Length)];

            return $"You encounter {npc.Name}, a {npc.Age} year old {npc.Gender} {npc.Race} working as a {npc.Job} in {location}.\n" +
                   GetNPCGreeting(npc);
        }

        private static string GetNPCGreeting(WorldNPC npc)
        {
            return npc.Job switch
            {
                "King" => $"{npc.Name} says: \"Welcome to my kingdom. State your business.\"",
                "Queen" => $"{npc.Name} says: \"Welcome. What brings you to our realm?\"",
                "Lord" => $"{npc.Name} says: \"Good day. What business do you have in my city?\"",
                "Lady" => $"{npc.Name} says: \"Welcome to my city. How may I assist you?\"",
                "Mayor" => $"{npc.Name} says: \"Welcome to our town! Is there something I can help you with?\"",
                "Mayoress" => $"{npc.Name} says: \"Hello there! Welcome to our town. What can I do for you?\"",
                "Headman" => $"{npc.Name} says: \"Greetings, traveler. Our village is small but welcoming.\"",
                "Headwoman" => $"{npc.Name} says: \"Welcome to our humble village. Make yourself at home.\"",
                "Blacksmith" => $"{npc.Name} says: \"Looking for quality weapons and armor? You've come to the right place!\"",
                "Merchant" => $"{npc.Name} says: \"Welcome! Browse my wares, finest in the land!\"",
                "Wizard" => $"{npc.Name} says: \"Ah, a visitor. Perhaps you seek arcane knowledge?\"",
                "Healer" => $"{npc.Name} says: \"Greetings, traveler. Are you in need of healing?\"",
                "Innkeeper" => $"{npc.Name} says: \"Welcome to the inn! Looking for a room or a meal?\"",
                "Guard" => $"{npc.Name} says: \"Move along, citizen. Keep the peace.\"",
                "Farmer" => $"{npc.Name} says: \"Hard work in the fields today. What brings you here?\"",
                "Bard" => $"{npc.Name} says: \"Ah! A new face! Care to hear a tale or song?\"",
                _ => $"{npc.Name} nods in greeting."
            };
        }

        /// <summary>
        /// Find all elven rulers
        /// </summary>
        public static WorldNPC[] GetElvenRulers()
        {
            string[] rulerJobs = { "King", "Queen", "Lord", "Lady", "Mayor", "Mayoress", "Headman", "Headwoman" };
            
            return WorldPopulation.GetPopulation()
                .Where(npc => npc.Race == "Elf" && rulerJobs.Contains(npc.Job))
                .ToArray();
        }

        /// <summary>
        /// Get a political overview of a region
        /// </summary>
        public static string GetPoliticalOverview(string country)
        {
            // This would need to be enhanced with actual country-to-location mapping
            // For now, it's a demonstration
            var allRulers = WorldPopulation.GetPopulation()
                .Where(npc => new[] { "King", "Queen", "Lord", "Lady" }.Contains(npc.Job))
                .ToArray();

            var king = allRulers.FirstOrDefault(r => r.Job == "King" || r.Job == "Queen");
            var lords = allRulers.Where(r => r.Job == "Lord" || r.Job == "Lady").Take(5).ToArray();

            string overview = $"Political Overview:\n";
            if (king != null)
            {
                overview += $"Monarch: {king.Name} ({king.Job})\n";
            }
            overview += $"Major Lords/Ladies: {lords.Length}\n";
            
            foreach (var lord in lords)
            {
                overview += $"  - {lord.Name} of {lord.Location}\n";
            }

            return overview;
        }
    }
}
