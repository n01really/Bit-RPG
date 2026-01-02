# Travel System Documentation

## Overview
The Travel System allows players to move between different locations in the game world: Countries, Cities, Towns, Villages, and Dungeons. Travel costs Action Points (AP), with 1 AP representing one day of travel time.

## Features Implemented

### 1. Location Tracking
- **Location Model** (`Models/Location.cs`): Tracks player's current location with Name, Type, and Country
- **LocationType Enum**: Country, City, Town, Village, Dungeon
- Player starts in **Arn** (a town in Eldoria)

### 2. Travel Rules

#### From Villages:
- **To Nearby Towns**: 1 AP
- **To Nearby Cities**: 2 AP  
- **To Nearby Dungeons**: 1 AP

#### From Towns:
- **To Nearby Villages**: 1 AP
- **To Nearby Cities**: 1 AP
- **To Nearby Dungeons**: 1 AP

#### From Cities:
- **To Capital** (if not already there): 2 AP
- **To Nearby Towns**: 1 AP
- **To Nearby Villages**: 1 AP
- **To Nearby Dungeons**: 2 AP

#### From Countries:
- **To Capital City**: 2 AP

#### From Dungeons:
- **Back to Nearby Villages**: 1 AP

### 3. World Data Structure
**WorldData.cs** contains all location information:
- 4 Countries (Eldoria, Valoria, Nordheim, Aranthia)
- 20 Cities (5 per country)
- 84 Towns
- 80 Villages
- Dungeons (linked to villages)

## Files Created

### Models
- `Models/Location.cs` - Location data model with Name, Type, Country
- `Models/TravelDestination.cs` - Travel destination with AP cost and description

### World Systems
- `World/TravelSystem.cs` - Core travel logic and destination calculations
- `World/WorldData.cs` - Static world location data repository

### UI
- `Popups/TravelPopup.xaml` - Travel interface with destination list
- `Popups/TravelPopup.xaml.cs` - Travel popup logic

## Files Modified

- `Char/Player.cs` - Added CurrentLocation property and initialization
- `Popups/ActivitiesPopup.xaml.cs` - Connected Travel button to TravelPopup

## How to Use

### For Players

1. **Open Activities Menu** in-game
2. **Click Travel Button**
3. **View Available Destinations**:
   - Destination name and description
   - Location type (City, Town, Village, Dungeon)
   - AP cost displayed prominently
4. **Tap a Destination** to travel:
   - Confirmation prompt shows AP cost
   - Travel deducts AP automatically
   - Updates current location
5. **Current Location** displayed at top of Travel UI

### For Developers

#### Check Available Destinations
```csharp
var destinations = TravelSystem.GetAvailableDestinations(player);
foreach (var dest in destinations)
{
    Console.WriteLine($"{dest.Name} - {dest.APCost} AP");
}
```

#### Travel to a Location
```csharp
var destination = new TravelDestination
{
    Name = "Silverhold",
    Type = LocationType.City,
    APCost = 2,
    Country = "Eldoria"
};

bool success = TravelSystem.TravelTo(player, destination);
if (success)
{
    Console.WriteLine($"Arrived at {player.CurrentLocation.Name}");
}
```

#### Get Location Data
```csharp
// Get specific locations
var city = WorldData.GetCity("Silverhold");
var town = WorldData.GetTown("Arn");
var village = WorldData.GetVillage("Riverside Hamlet");

// Get capital of country
var capital = WorldData.GetCapitalOfCountry("Eldoria"); // Returns "Silverhold"

// Get all locations of a type
var allCities = WorldData.GetAllCities();
var allTowns = WorldData.GetAllTowns();
```

## Example Travel Flow

### Starting Location: Arn (Town)
Player starts with 5 AP

**Available Destinations:**
1. Riverside Hamlet (Village) - 1 AP
2. Silverhold (City) - 1 AP

**Player travels to Silverhold (1 AP spent, 4 AP remaining)**

### Now at: Silverhold (City, Capital of Eldoria)
**Available Destinations:**
1. Arn (Town) - 1 AP
2. Oakvale (Town) - 1 AP
3. Silverbridge (Town) - 1 AP
4. Meadowbrook (Town) - 1 AP
5. Riverside Hamlet (Village) - 1 AP
6. Oakshire (Village) - 1 AP
7. Bridgeview (Village) - 1 AP
8. Greenfield (Village) - 1 AP

**Player travels to Riverside Hamlet (1 AP spent, 3 AP remaining)**

### Now at: Riverside Hamlet (Village)
**Available Destinations:**
1. Arn (Town) - 1 AP
2. Silverhold (City) - 2 AP
3. Caverns of Chaos (Dungeon) - 1 AP
4. Forest of Shadows (Dungeon) - 1 AP
5. Ruins of the Ancients (Dungeon) - 1 AP
6. Crystal Caves (Dungeon) - 1 AP
7. Abandoned Mine (Dungeon) - 1 AP

**Player ventures into Caverns of Chaos (1 AP spent, 2 AP remaining)**

### Now at: Caverns of Chaos (Dungeon)
**Available Destinations:**
1. Riverside Hamlet (Village) - 1 AP

## AP Cost Summary

| From ? To | AP Cost |
|-----------|---------|
| Village ? Town | 1 |
| Village ? City | 2 |
| Village ? Dungeon | 1 |
| Town ? Village | 1 |
| Town ? City | 1 |
| Town ? Dungeon | 1 |
| City ? Capital | 2 |
| City ? Town | 1 |
| City ? Village | 1 |
| City ? Dungeon | 2 |
| Dungeon ? Village | 1 |

## Integration with Game Systems

### Action Points
- Travel deducts AP using `player.TrySpendActionPoints()`
- Cannot travel without sufficient AP
- Player gains 2 AP per week (as per existing system)

### Save/Load
- Current location automatically saved with player data
- Location persists across game sessions

### Events
- Weekly events already use player location (see `WeeklyEvents.cs`)
- Future: Location-specific events and encounters

## Future Enhancements

### Potential Features
1. **Random Travel Encounters**
   - Bandits on roads
   - Helpful travelers
   - Weather delays

2. **Travel Speed Modifiers**
   - Horse/mount reduces AP cost
   - Fast travel between discovered cities
   - Weather affects travel time

3. **Location Discovery**
   - Unlock new destinations through exploration
   - Quest-gated locations
   - Hidden dungeons

4. **Location-Specific Features**
   - Markets vary by city/town
   - Guild halls in capital cities only
   - Village-specific resources

5. **Inter-Country Travel**
   - Travel between countries
   - Border crossings
   - Trade routes

6. **Dungeon Levels**
   - Multi-floor dungeons
   - Save progress in dungeons
   - Dungeon-specific loot

## Testing Checklist

- [x] Player starts at Arn
- [x] Can view available destinations
- [x] Travel costs correct AP
- [x] Cannot travel without sufficient AP
- [x] Current location updates after travel
- [x] Destinations update based on new location
- [x] Location persists on save/load
- [x] Villages can access dungeons
- [x] Cities can travel to capital
- [x] Dungeons allow return to villages

## Code Architecture

### Separation of Concerns
1. **Models** - Data structures (Location, TravelDestination)
2. **WorldData** - Static world information
3. **TravelSystem** - Business logic for travel rules
4. **TravelPopup** - UI for player interaction
5. **Player** - Location state tracking

### Data Flow
```
Player Clicks Travel Button
    ?
ActivitiesPopup opens TravelPopup
    ?
TravelPopup calls TravelSystem.GetAvailableDestinations()
    ?
TravelSystem queries WorldData for location info
    ?
TravelPopup displays destinations
    ?
Player selects destination
    ?
TravelPopup calls TravelSystem.TravelTo()
    ?
TravelSystem updates Player.CurrentLocation
    ?
TravelPopup refreshes display
```

## Troubleshooting

### "No destinations available"
- Check that location exists in WorldData
- Verify location type is correctly set
- Ensure nearby locations are properly configured

### "Location not saving"
- Player.CurrentLocation is part of Player object
- Player is saved in GameSaveModel
- No additional configuration needed

### "Wrong AP cost"
- Check travel rules in TravelSystem
- Verify LocationType of origin and destination
- Review GetDestinationsFrom[Type] methods

## Summary

The travel system is fully functional and integrated with:
- ? Action Point system
- ? Save/Load system  
- ? World population system
- ? UI framework (Popups)
- ? Location hierarchy (Countries ? Cities ? Towns ? Villages ? Dungeons)

Players can now explore the entire game world, with travel costs creating meaningful decisions about how to spend their limited Action Points each week!
