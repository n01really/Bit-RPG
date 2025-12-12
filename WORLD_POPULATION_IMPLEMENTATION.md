# World Population Generation - Quick Start

## What Was Implemented

? **Random Population Generation**
- Generates ~1,188 NPCs at game start
- **188 Rulers** generated first with proper titles:
  - 4 Kings/Queens (country rulers)
  - 20 Lords/Ladies (city rulers)
  - 84 Mayors/Mayoresses (town rulers)
  - 80 Headmen/Headwomen (village leaders)
- ~1,000 regular NPCs using `HumanNpc`, `ElfNpc`, and `DwarvenNpc`
- Race distribution for regular population: 60% Humans, 25% Elves, 15% Dwarves

? **Ruler Integration**
- **All rulers are stored in the WorldPopulation array**
- Their title (King, Queen, Lord, Lady, Mayor, Mayoress, Headman, Headwoman) is their **Job** property
- Noble names for royalty and lords (includes houses/clans)
- Regular names for mayors and headmen
- Each ruler is assigned to their specific location

? **NPC Properties**
- Name (race-appropriate, noble names for rulers)
- Age (rulers are typically 30-65 years old)
- Gender (Male/Female)
- Race (Human/Elf/Dwarf, rulers can be any race)
- **Job** (includes ruler titles + 40+ regular occupations)
- Location (rulers assigned to specific locations they govern)

? **Job Categories**
**Ruler Jobs** (188 total):
- King, Queen, Lord, Lady, Mayor, Mayoress, Headman, Headwoman

**Regular Jobs** (~1,000 total):
- Common Jobs (50%): Farmers, fishermen, bakers, etc.
- Craft Jobs (20%): Blacksmiths, armorers, jewelers, etc.
- Merchant Jobs (15%): Traders, shopkeepers, merchants, etc.
- Service Jobs (10%): Healers, teachers, musicians, etc.
- Magical Jobs (5%): Wizards, enchanters, alchemists, etc.

? **JSON Save Integration**
- All NPCs (rulers + population) automatically saved to `gamesave.json`
- Population restored when loading a saved game
- No manual action required

## How It Works

### On New Game Start
1. Player creates character
2. GamePage initializes
3. `WorldPopulation.GenerateWorldPopulation(1000)` is called
4. **Rulers are generated FIRST** (188 NPCs)
   - 4 Kings/Queens for countries
   - 20 Lords/Ladies for cities
   - 84 Mayors for towns
   - 80 Headmen for villages
5. Regular population fills remaining ~1,000 slots
6. Game auto-saves all ~1,188 NPCs to JSON

### Ruler Generation Process
```csharp
// 1. Generate 4 Kings/Queens (one per country capital)
foreach country in ["Eldoria", "Valoria", "Nordheim", "Aranthia"]
    Generate King or Queen with noble name
    Job = "King" or "Queen"
    Location = country capital

// 2. Generate 20 Lords/Ladies (one per city)
foreach city in all 20 cities
    Generate Lord or Lady with noble name
    Job = "Lord" or "Lady"
    Location = city name

// 3. Generate 84 Mayors (one per town)
foreach town in all 84 towns
    Generate Mayor or Mayoress
    Job = "Mayor" or "Mayoress"
    Location = town name

// 4. Generate 80 Headmen (one per village)
foreach village in all 80 villages
    Generate Headman or Headwoman
    Job = "Headman" or "Headwoman"
    Location = village name
```

### On Game Load
1. Player loads saved game
2. GamePage reads save file
3. Population restored from JSON (includes all rulers)
4. NPCs maintain all their properties

### During Gameplay
- Population (with rulers) saved every time you click "Continue"
- Population persists between game sessions
- Can query by location, race, or job (including ruler jobs)

## Example Usage in Code

### Find a Specific Ruler
```csharp
// Get the ruler of a location
var arnMayor = WorldPopulation.GetRulerOfLocation("Arn");
Console.WriteLine($"{arnMayor.Name} is the {arnMayor.Job} of {arnMayor.Location}");
// Output: "Mayor Aldric Blackwood is the Mayor of Arn"

// Get all kings and queens
var monarchs = WorldPopulation.GetPopulation()
    .Where(npc => npc.Job == "King" || npc.Job == "Queen")
    .ToArray();
```

### Get Complete Location Information
```csharp
// Get everyone in a town (including the mayor)
var townNPCs = WorldPopulation.GetPopulationByLocation("Arn");
var mayor = WorldPopulation.GetRulerOfLocation("Arn");

Console.WriteLine($"Town: Arn");
Console.WriteLine($"Ruled by: {mayor.Name} ({mayor.Job})");
Console.WriteLine($"Total population: {townNPCs.Length}");
```

### Query by Ruler Type
```csharp
// Find all mayors
var mayors = WorldPopulation.GetPopulationByJob("Mayor");
var mayoresses = WorldPopulation.GetPopulationByJob("Mayoress");
var allMayors = mayors.Concat(mayoresses).ToArray();

// Find all nobility (Kings, Queens, Lords, Ladies)
var nobility = WorldPopulation.GetPopulation()
    .Where(npc => new[] { "King", "Queen", "Lord", "Lady" }.Contains(npc.Job))
    .ToArray();
```

## Files Modified

1. **Char\NPCs\WorldPupulation.cs**
   - Added `GenerateRulers()` method
   - Added ruler-specific name generation methods
   - Added location data structures for rulers
   - Added `GetRulerOfLocation()` query method
   - Rulers generated before regular population

2. **Models\GameSaveModel.cs**
   - `WorldPopulation` property saves all NPCs (rulers included)

3. **GamePage.xaml.cs**
   - Population generation includes rulers automatically
   - All NPCs (rulers + regular) saved/loaded together

## Population Breakdown

**Total NPCs**: ~1,188
- **Rulers**: 188
  - 4 Kings/Queens
  - 20 Lords/Ladies
  - 84 Mayors/Mayoresses
  - 80 Headmen/Headwomen
- **Regular Population**: ~1,000
  - Farmers, merchants, blacksmiths, etc.

## JSON Save Example

Your save file now includes rulers:
```json
{
  "WorldPopulation": [
    {
      "Name": "King Aldric Blackwood of House Valerian",
      "Age": 52,
      "Gender": "Male",
      "Race": "Human",
      "Job": "King",
      "Location": "Silverhold"
    },
    {
      "Name": "Lord Cedric Silverhand of House Drakemore",
      "Age": 48,
      "Gender": "Male",
      "Race": "Human",
      "Job": "Lord",
      "Location": "Ironpeak"
    },
    {
      "Name": "Mayor Thorne Ashford",
      "Age": 45,
      "Gender": "Male",
      "Race": "Human",
      "Job": "Mayor",
      "Location": "Arn"
    },
    {
      "Name": "Headman Gareth Ravencrest",
      "Age": 58,
      "Gender": "Male",
      "Race": "Human",
      "Job": "Headman",
      "Location": "Riverside Hamlet"
    },
    {
      "Name": "Varian Thornhill",
      "Age": 35,
      "Gender": "Male",
      "Race": "Human",
      "Job": "Blacksmith",
      "Location": "Arn"
    }
    // ... ~1,183 more NPCs
  ]
}
```

## Testing

Run the game and verify:
1. Start a new game - rulers + population generate
2. Check debug output for count (~1,188 NPCs)
3. Save the game (happens automatically)
4. Open `gamesave.json` and search for:
   - "Job": "King"
   - "Job": "Mayor"
   - "Job": "Headman"
5. Load the game - all rulers restore correctly

## Debug Output Example

```
Generating world population...
Generated 4 country rulers (Kings/Queens)
Generated 20 city rulers (Lords/Ladies)
Generated 84 town rulers (Mayors/Mayoresses)
Generated 80 village rulers (Headmen/Headwomen)
Generated 1000 regular NPCs
World population generated: 1188 NPCs

Game saved successfully at week 1
Saved 1188 NPCs in world population (includes 188 rulers)
```

## New Features Enabled

With rulers in the population, you can now:
1. **Create ruler-specific quests** - Quest givers can be mayors, lords, kings
2. **Implement dialogue with rulers** - Each ruler is a fully tracked NPC
3. **Build reputation systems** - Track relationship with each ruler
4. **Create political events** - Wars between rulers, alliances, etc.
5. **Ruler succession** - When a ruler dies/is replaced, update the Job property
6. **Petition rulers** - Players can interact with the ruler of their location
7. **Track royal lineage** - Future: Add family relationships between rulers
8. **Economic systems** - Rulers can set taxes, trade agreements, etc.

## Example: Interactive Ruler System

```csharp
// Player wants to meet the ruler of their current location
public string MeetLocalRuler(string currentLocation)
{
    var ruler = WorldPopulation.GetRulerOfLocation(currentLocation);
    
    if (ruler == null)
        return $"No ruler found for {currentLocation}";
    
    string greeting = ruler.Job switch
    {
        "King" or "Queen" => $"You are granted an audience with {ruler.Name}. The {ruler.Job} sits upon the throne.",
        "Lord" or "Lady" => $"You enter the manor and meet {ruler.Name}, the {ruler.Job} of {currentLocation}.",
        "Mayor" or "Mayoress" => $"You visit the town hall where {ruler.Name}, the {ruler.Job}, greets you.",
        "Headman" or "Headwoman" => $"You meet {ruler.Name}, the {ruler.Job} of this village, at their cottage.",
        _ => $"You meet {ruler.Name}."
    };
    
    return greeting;
}
```

## Key Benefits

1. ? **Consistent Ruler Data** - Rulers are saved/loaded with all their properties
2. ? **Easy Queries** - Find rulers by location, job type, or other properties
3. ? **Integration Ready** - Rulers can be used in quests, dialogue, events
4. ? **Realistic World** - Every location has a named, tracked ruler
5. ? **Future-Proof** - Easy to expand with relationships, succession, etc.

Enjoy your fully populated and ruled world! ????
