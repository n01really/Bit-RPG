# Location-Based Activities & Population System

## Overview
The game now features location-specific activities and markets that vary based on where the player is located. Villages, Towns, and Cities each have different amenities available.

## Location Types & Available Activities

### Villages
**Available Activities:**
- ? **Market** - Limited selection (1 item per category)
- ? **Travel** - Journey to nearby locations
- ? Guild Hall (Not available)
- ? Crafters Guild (Not available)
- ? Apothecary (Not available)

**Description:** Villages are small settlements with basic amenities. Perfect for quick trades and starting adventures.

### Towns
**Available Activities:**
- ? **Market** - Moderate selection (2 items per category)
- ? **Crafters Guild** - Commission gear and train crafting skills
- ? **Travel** - Journey to nearby locations
- ? Guild Hall (Not available)
- ? Apothecary (Not available)

**Description:** Towns offer more services including skilled craftsmen. Good waypoints for adventurers.

### Cities
**Available Activities:**
- ? **Market** - Large selection (4 items per category)
- ? **Guild Hall** - Train skills and meet guild members
- ? **Crafters Guild** - Commission gear and train crafting skills
- ? **Apothecary** - Brew potions (requires Alchemy 10+)
- ? **Travel** - Journey to nearby locations

**Description:** Cities are major hubs with all amenities. Best places for comprehensive adventuring needs.

### Dungeons
**Available Activities:**
- ? **Travel** - Leave the dungeon
- ? All other activities unavailable

**Description:** Dungeons are dangerous locations. You can only travel to escape.

## Market Inventory System

### Location-Specific Inventory

Markets now generate inventory based on:

1. **Location Type** (Village/Town/City)
   - Villages: 1 item per category
   - Towns: 2 items per category
   - Cities: 4 items per category

2. **Location Name** (Specialty Items - Coming Soon)
   - Coastal locations: Fishing gear, salt, seafood
   - Forested locations: Wood, herbs, forest ingredients
   - Magical cities: Potions, scrolls, enchanted items
   - Military locations: Weapons, armor
   - Agricultural locations: Food, farming supplies
   - Trading hubs: Diverse selection

### Market Features

- **Dynamic Inventory**: Each location has its own market inventory
- **Location Label**: Market shows which location you're in
- **Buy/Sell System**: 
  - Buy items at full price
  - Sell items at 50% of base value
- **Real-time Updates**: Inventory updates as you buy/sell

## How It Works

### Opening Activities
1. Click "Activities" button in main game
2. See current location displayed at top
3. Only see activities available for your location type

### Market Shopping
1. Open Market from Activities
2. See location name in market title (e.g., "Arn Market")
3. Market inventory varies by location
4. Villages have fewer items, Cities have more

### Guild Hall Access
- Only available in **Cities**
- Must be a guild member to enter
- Costs 1 AP to visit

### Crafters Guild Access
- Available in **Towns** and **Cities**
- Costs 1 AP to visit

### Apothecary Access
- Only available in **Cities**
- Requires Alchemy skill level 10+
- Costs 1 AP to visit

## Code Architecture

### Files Modified

**Popups/ActivitiesPopup.xaml.cs**
- Added `ConfigureActivitiesForLocation()` method
- Shows/hides sections based on location type
- Displays current location in header

**Popups/ActivitiesPopup.xaml**
- Added location label
- All sections now use `x:Name` for visibility control

**Items/MarketInventory.cs**
- Added `PopulateMarketInventoryForLocation()` method
- Generates different inventory sizes per location type
- Prepared for specialty items per location

**Popups/MarketPopup.xaml.cs**
- Uses location-specific inventory generation
- Displays location name in header

**Popups/MarketPopup.xaml**
- Added location label under title

## Configuration Methods

### ConfigureActivitiesForLocation()
```csharp
private void ConfigureActivitiesForLocation()
{
    switch (_player.CurrentLocation.Type)
    {
        case LocationType.Village:
            GuildHallSection.IsVisible = false;
            CraftersSection.IsVisible = false;
            ApothecarySection.IsVisible = false;
            break;
        case LocationType.Town:
            GuildHallSection.IsVisible = false;
            CraftersSection.IsVisible = true;
            ApothecarySection.IsVisible = false;
            break;
        case LocationType.City:
            GuildHallSection.IsVisible = true;
            CraftersSection.IsVisible = true;
            ApothecarySection.IsVisible = true;
            break;
        case LocationType.Dungeon:
            MarketSection.IsVisible = false;
            GuildHallSection.IsVisible = false;
            CraftersSection.IsVisible = false;
            ApothecarySection.IsVisible = false;
            break;
    }
}
```

### PopulateMarketInventoryForLocation()
```csharp
public void PopulateMarketInventoryForLocation(string locationName, LocationType locationType)
{
    int itemsPerCategory = locationType switch
    {
        LocationType.Village => 1,
        LocationType.Town => 2,
        LocationType.City => 4,
        _ => 2
    };
    
    // Generate inventory with location-specific count
    // Future: Add specialty items based on locationName
}
```

## Example Gameplay

### In a Village (e.g., Riverside Hamlet)
**Activities Menu shows:**
- Current Location: Riverside Hamlet (Village)
- ? Market (limited stock)
- ? Travel

**Market shows:**
- "Riverside Hamlet Market"
- 1 item per category (weapons, armor, ingredients, etc.)

### In a Town (e.g., Arn)
**Activities Menu shows:**
- Current Location: Arn (Town)
- ? Market (moderate stock)
- ? Crafters Guild
- ? Travel

**Market shows:**
- "Arn Market"
- 2 items per category

### In a City (e.g., Silverhold)
**Activities Menu shows:**
- Current Location: Silverhold (City)
- ? Market (large stock)
- ? Guild Hall
- ? Crafters Guild
- ? Apothecary
- ? Travel

**Market shows:**
- "Silverhold Market"
- 4 items per category

## Future Enhancements

### Planned Features

1. **Specialty Items by Location**
   - Coastal: Fish, salt, ships, navigation tools
   - Forest: Lumber, herbs, hunting gear
   - Mountain: Ore, gems, mining tools
   - Magical: Scrolls, potions, enchantments
   - Military: Advanced weapons and armor

2. **Location-Specific NPCs**
   - Each city/town/village has its own population
   - Merchants specific to location
   - Quest givers based on location

3. **Unique Markets**
   - Black markets in certain cities
   - Special vendors in capital cities
   - Traveling merchants between locations

4. **Guild Hall Variations**
   - Different guilds in different cities
   - Guild-specific quests per location
   - Regional guild halls

5. **Seasonal/Event Markets**
   - Festival markets with unique items
   - Seasonal goods availability
   - Holiday-specific vendors

## Integration with Existing Systems

### Travel System
- When you travel to a new location, activities update automatically
- Market inventory refreshes for the new location
- Location label updates everywhere

### Action Points
- All activities still cost appropriate AP
- No AP cost to open the Activities menu
- No AP cost to browse the market (only to visit)

### Save/Load
- Current location persists
- Market inventory generates fresh on each visit
- Activities availability determined by saved location

## Testing Checklist

- [x] Villages show only Market and Travel
- [x] Towns show Market, Crafters, and Travel
- [x] Cities show all activities
- [x] Location label displays correctly
- [x] Market inventory varies by location type
- [x] Guild Hall requires city location
- [x] Apothecary requires city location
- [x] All activities still cost correct AP
- [x] Location persists on save/load

## Summary

The location-based system creates a more immersive and realistic world where:
- **Villages** are small and limited but accessible
- **Towns** are moderate hubs with crafting services
- **Cities** are major centers with all amenities
- **Markets** vary in size and selection
- **Travel** becomes meaningful as different locations offer different services

Players must now consider location when planning their activities, adding strategic depth to the game!
