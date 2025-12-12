# World Population System

## Overview
The World Population system generates a diverse, realistic population for your game world at startup. NPCs are randomly generated using existing name generators (HumanNpc, ElfNpc, DwarvenNpc) and assigned random jobs, ages, and locations. **All rulers and leaders are now included in the population.**

## Features

### Automatic Generation
- **Generates ~1,000+ NPCs by default** when you start a new game
- **Includes all rulers and leaders first**:
  - 4 Kings/Queens (one per country)
  - 20 Lords/Ladies (one per city)
  - 84 Mayors/Mayoresses (one per town)
  - 80 Headmen/Headwomen (one per village)
- **Race Distribution for regular population**:
  - 60% Humans
  - 25% Elves
  - 15% Dwarves
- Each NPC has:
  - Name (using race-specific name generators)
  - Age (race-appropriate ranges)
  - Gender (Male/Female)
  - Race (Human/Elf/Dwarf)
  - Job/Occupation (including ruler titles)
  - Location (assigned to cities/towns across the world)

### Ruler Generation
**All rulers are now part of the world population with their titles as their job:**

#### Country Rulers
- **Job**: "King" or "Queen"
- **Locations**: Silverhold, Ironpeak, Frosthold, Starhaven
- **Names**: Full noble names (e.g., "King Aldric Blackwood of House Valerian")
- **Age Range**: 35-65 years
- **Race**: Human (currently)

#### City Lords
- **Job**: "Lord" or "Lady"
- **Locations**: All 20 major cities
- **Names**: Noble names with houses (e.g., "Lord Cedric Silverhand of House Drakemore")
- **Age Range**: 30-60 years
- **Race**: 70% Human, 15% Elf, 15% Dwarf

#### Town Mayors
- **Job**: "Mayor" or "Mayoress"
- **Locations**: All 84 towns
- **Names**: Regular names (e.g., "Mayor Thorne Ashford")
- **Age Range**: 30-55 years
- **Race**: 70% Human, 15% Elf, 15% Dwarf

#### Village Leaders
- **Job**: "Headman" or "Headwoman"
- **Locations**: All 80 villages
- **Names**: Regular names (e.g., "Headman Gareth Ravencrest")
- **Age Range**: 35-70 years
- **Race**: 70% Human, 15% Elf, 15% Dwarf

### Job Distribution (Regular Population)
NPCs are assigned jobs with realistic weighting:
- **50% Common Jobs**: Farmer, Fisherman, Carpenter, Baker, Butcher, Tailor, etc.
- **20% Craft Jobs**: Blacksmith, Armorer, Weaponsmith, Jeweler, Goldsmith, etc.
- **15% Merchant Jobs**: Merchant, Shopkeeper, Trader, Spice Trader, etc.
- **10% Service Jobs**: Barber, Healer, Teacher, Scribe, Musician, Bard, etc.
- **5% Magical Jobs**: Wizard, Enchanter, Alchemist, Sage, etc.

### Age Ranges
- **Humans**: 18-80 years (regular), 30-65 years (rulers)
- **Elves**: 100-500 years (long-lived)
- **Dwarves**: 40-250 years (longer than humans)

### Locations
NPCs are distributed across all major locations in the world:
- **Eldoria Kingdom**: Silverhold, Southhold, Arn, Oakvale, etc.
- **Valoria Kingdom**: Ironpeak, Wramham, Raso, Cadena, etc.
- **Nordheim Kingdom**: Frosthold, Aflemland, Vrostead, Hargen, etc.
- **Aranthia Kingdom**: Starhaven, Word, Xora, Starlight, Fladon, etc.

## Usage

### Generating Population
Population is automatically generated when you start a new game:
```csharp
// This happens automatically in GamePage constructor
WorldPopulation.GenerateWorldPopulation(1000);
// Note: This generates ~188 rulers first, then fills remaining slots with regular NPCs
```

### Querying Population
```csharp
// Get all NPCs
WorldNPC[] allNPCs = WorldPopulation.GetPopulation();

// Get total count (includes rulers)
int totalPopulation = WorldPopulation.GetPopulationCount();

// Get NPCs by location (includes the ruler of that location)
WorldNPC[] arnNPCs = WorldPopulation.GetPopulationByLocation("Arn");

// Get NPCs by race
WorldNPC[] elves = WorldPopulation.GetPopulationByRace("Elf");

// Get NPCs by job
WorldNPC[] blacksmiths = WorldPopulation.GetPopulationByJob("Blacksmith");

// NEW: Get the ruler of a specific location
WorldNPC ruler = WorldPopulation.GetRulerOfLocation("Arn");
// Returns the Mayor/Mayoress/Lord/Lady/King/Queen of that location
```

### Finding Rulers
```csharp
// Find all kings and queens
var monarchs = WorldPopulation.GetPopulation()
    .Where(npc => npc.Job == "King" || npc.Job == "Queen")
    .ToArray();

// Find all mayors
var mayors = WorldPopulation.GetPopulation()
    .Where(npc => npc.Job == "Mayor" || npc.Job == "Mayoress")
    .ToArray();

// Find the ruler of a specific town
var arnRuler = WorldPopulation.GetRulerOfLocation("Arn");
Console.WriteLine($"{arnRuler.Name} ({arnRuler.Job}) rules {arnRuler.Location}");
// Output: "Mayor Aldric Blackwood (Mayor) rules Arn"
```

### Example Population Data
```csharp
// A King
{
  "Name": "King Aldric Blackwood of House Valerian",
  "Age": 52,
  "Gender": "Male",
  "Race": "Human",
  "Job": "King",
  "Location": "Silverhold"
}

// A Mayor
{
  "Name": "Mayor Thorne Ashford",
  "Age": 45,
  "Gender": "Male",
  "Race": "Human",
  "Job": "Mayor",
  "Location": "Arn"
}

// An Elf Wizard
{
  "Name": "Legolas Starweaver",
  "Age": 342,
  "Gender": "Male",
  "Race": "Elf",
  "Job": "Wizard",
  "Location": "Starhaven"
}

// A Dwarf Lord
{
  "Name": "Lord Thorin Ironforge of Clan Fireforge",
  "Age": 156,
  "Gender": "Male",
  "Race": "Dwarf",
  "Job": "Lord",
  "Location": "Ironpeak"
}
```

## Save System Integration

### Automatic Saving
The entire world population (including all rulers) is automatically saved to JSON when you:
1. Start a new game
2. Click the Continue button (advances week)
3. Game auto-saves

### Save File Structure
```json
{
  "SaveDate": "2024-01-15T14:30:00",
  "CurrentWeek": 5,
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
      "Name": "Mayor Thorne Ashford",
      "Age": 45,
      "Gender": "Male",
      "Race": "Human",
      "Job": "Mayor",
      "Location": "Arn"
    }
    // ... ~1,000+ NPCs including all rulers
  ]
}
```

### Loading Population
When you load a saved game:
- The population is restored from the JSON save file
- All NPCs (including rulers) maintain their original properties
- If no population exists in the save file, a new one is generated

## Code Structure

### WorldNPC Class
```csharp
public class WorldNPC
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Race { get; set; }
    public string Job { get; set; }  // Can be "King", "Mayor", "Blacksmith", etc.
    public string Location { get; set; }
}
```

### WorldPopulation Class
Static class managing the world population:
- `GenerateWorldPopulation(int count)` - Generates rulers + NPCs
- `AddNPC(...)` - Manually add an NPC
- `GetPopulation()` - Get all NPCs (including rulers)
- `GetPopulationCount()` - Get total count
- `GetPopulationByLocation(string)` - Filter by location
- `GetPopulationByRace(string)` - Filter by race
- `GetPopulationByJob(string)` - Filter by job
- `GetRulerOfLocation(string)` - **NEW**: Get the ruler of a location
- `ClearPopulation()` - Clear all NPCs

## Performance

- **Maximum Capacity**: 10,000 NPCs
- **Default Generation**: ~1,188 NPCs (188 rulers + 1,000 regular)
- **Rulers Generated**: 188 (4 kings + 20 lords + 84 mayors + 80 headmen)
- **Memory Efficient**: Uses array-based storage
- **Fast Queries**: LINQ-based filtering

## Ruler Jobs

You can now query for specific ruler types:
- `"King"` - Male country ruler
- `"Queen"` - Female country ruler
- `"Lord"` - Male city ruler
- `"Lady"` - Female city ruler
- `"Mayor"` - Male town ruler
- `"Mayoress"` - Female town ruler
- `"Headman"` - Male village leader
- `"Headwoman"` - Female village leader

## Future Enhancements
Consider adding:
1. Royal families and succession
2. Council members and advisors
3. NPC relationships between rulers and subjects
4. Political events and intrigue
5. Ruler-specific quests and dialogue
6. Reputation system with rulers
7. Trade agreements between ruled locations
8. Wars between rulers
9. Ruler aging and succession mechanics
10. Player ability to influence or overthrow rulers

## Debug Output
The system provides debug output when generating/loading population:
```
Generating world population...
World population generated: 1188 NPCs (includes all rulers)

// On save:
Game saved successfully at week 5
Saved 1188 NPCs in world population

// On load:
Loaded world population: 1188 NPCs
```

## Example: Complete Location Query
```csharp
// Get complete information about a town including its ruler
var location = "Arn";
var allInLocation = WorldPopulation.GetPopulationByLocation(location);
var ruler = WorldPopulation.GetRulerOfLocation(location);
var populace = allInLocation.Where(npc => !new[] { "King", "Queen", "Lord", "Lady", "Mayor", "Mayoress", "Headman", "Headwoman" }.Contains(npc.Job)).ToArray();

Console.WriteLine($"Location: {location}");
Console.WriteLine($"Ruler: {ruler.Name} ({ruler.Job})");
Console.WriteLine($"Total Population: {allInLocation.Length}");
Console.WriteLine($"Regular Citizens: {populace.Length}");

// Find service providers
var blacksmith = populace.FirstOrDefault(npc => npc.Job == "Blacksmith");
if (blacksmith != null)
{
    Console.WriteLine($"Blacksmith: {blacksmith.Name}, {blacksmith.Age} years old");
}
