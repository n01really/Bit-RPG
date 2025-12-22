# Weekly Events System

## Overview
The Weekly Events system adds slice-of-life flavor events that occur every time you press the "Continue" button. These events are smaller, atmospheric moments that make the game world feel more alive and dynamic.

## Features

### 10 Weekly Event Types
1. **Market Day** - Bustling markets with merchants and shoppers
2. **Tavern Night** - Social evenings at the local tavern
3. **Traveling Merchant** - Merchants passing through town with exotic goods
4. **Local Festival** - Community celebrations and holidays
5. **Weather Changes** - Various weather conditions throughout the week
6. **Street Performer** - Bards, musicians, and actors entertaining the town
7. **Gossip** - Local rumors and whispers
8. **Wildlife Encounter** - Sightings of animals and nature
9. **Local News** - Town announcements and community events
10. **Random Encounter** - Meeting local NPCs and helping them

### How It Works

#### Automatic Triggering
- Weekly events trigger **automatically every time** you click the "Continue" button
- They occur alongside world events and job events (if applicable)
- No random chance - you're guaranteed to get a weekly event each week

#### NPC Integration
Some weekly events feature NPCs from the world population:
- **Traveling Merchant Event**: Features merchants, traders, or peddlers
- **Street Performer Event**: Features bards, musicians, or actors
- **Local News Event**: May mention the town's ruler (Mayor, Lord, etc.)
- **Random Encounter Event**: Features random townspeople in various jobs

## Code Structure

### WeeklyEvents.cs
Contains all weekly event logic:
- `GetRandomWeeklyEvent(Player player)` - Main method that picks a random event
- 10 private methods (one for each event type)
- Each method returns a `WeeklyEventModel`

### EventPicker.cs
Updated to include weekly events in the event system:
- `TryTriggerEvent()` - Now includes weekly event generation
- `PickRandomEvents()` - Can trigger world + job + weekly events
- Comprehensive comments explain how to modify event frequencies

### EventModel.cs
Contains the `WeeklyEventModel`:
```csharp
class WeeklyEventModel
{
    public int Id { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public WorldNPC InvolvedNPC { get; set; }
    public Player CurrentLocation { get; set; }
}
```

## Event Frequencies

### Current Setup
- **Weekly Events**: 100% chance every continue press (always triggers)
- **World Events**: 15% chance every 4 clicks
- **Job Events**: 33% chance every 4 clicks (only if player has a job)

### How to Modify Frequencies

#### Change Weekly Event Frequency
To make weekly events less frequent:

1. Open `Events/EventPicker.cs`
2. Find the `TryTriggerEvent()` method
3. Look for the weekly event section (around line 200)
4. Add a random chance check:

```csharp
// WEEKLY EVENTS - Currently 100% chance
// To make less frequent:
int weeklyEventChance = _random.Next(0, 100);
if (weeklyEventChance < 50)  // 50% chance
{
    var weeklyEventModel = WeeklyEvents.GetRandomWeeklyEvent(player);
    result.WeeklyEvent = new EventResult(
        "Weekly Event",
        weeklyEventModel.Description,
        "Weekly"
    )
    {
        WeeklyEvent = weeklyEventModel
    };
}
```

#### Change World Event Frequency
In `Events/EventPicker.cs`, find:
```csharp
if (worldEventChance < 15)  // Currently 15%
```
Change to:
```csharp
if (worldEventChance < 25)  // 25% chance
```

#### Change Job Event Frequency
In `Events/EventPicker.cs`, find:
```csharp
if (jobEventChance < 33)  // Currently 33%
```
Change to:
```csharp
if (jobEventChance < 50)  // 50% chance
```

#### Change Clicks Required for Events
In `Events/CurrentEvents.cs`, find:
```csharp
public int ClicksRequiredForEvent { get; set; } = 4;
```
Change to:
```csharp
public int ClicksRequiredForEvent { get; set; } = 10;  // Events every 10 weeks
```

## Adding New Weekly Events

### Step 1: Create the Event Method
Add a new private method in `WeeklyEvents.cs`:

```csharp
private static WeeklyEventModel YourNewEvent(Player player)
{
    var descriptions = new[]
    {
        "Description variant 1",
        "Description variant 2",
        "Description variant 3"
    };

    return new WeeklyEventModel
    {
        Id = 11,  // Next available ID
        Description = descriptions[_random.Next(descriptions.Length)],
        CurrentLocation = player
    };
}
```

### Step 2: Add to Random Selection
In the `GetRandomWeeklyEvent()` method:

1. Change the random range:
```csharp
int eventId = _random.Next(1, 12);  // Changed from 11 to 12
```

2. Add your event to the switch:
```csharp
return eventId switch
{
    // ...existing events...
    11 => YourNewEvent(player),
    _ => MarketDayEvent(player)
};
```

### Step 3: (Optional) Add NPC Involvement
To include NPCs:

```csharp
private static WeeklyEventModel YourNewEvent(Player player)
{
    // Get NPCs by job type
    var npcPool = WorldPopulation.GetPopulation()
        .Where(npc => npc.Job == "Blacksmith")
        .ToArray();
    
    var selectedNPC = npcPool.Length > 0 
        ? npcPool[_random.Next(npcPool.Length)]
        : null;

    string description = selectedNPC != null
        ? $"You meet {selectedNPC.Name}, the local blacksmith."
        : "You visit the local blacksmith's shop.";

    return new WeeklyEventModel
    {
        Id = 11,
        Description = description,
        InvolvedNPC = selectedNPC,
        CurrentLocation = player
    };
}
```

## Example Output

When you press "Continue", you might see:

```
Week 5, Year 301 ADE

=== Weekly Event ===
The weekly market is bustling with activity. Merchants hawk their wares as shoppers haggle over prices.
```

Or with multiple events:

```
Week 6, Year 301 ADE

=== Adventurers Guild Event ===
The guild master Aldric Stormwind gives you praise for your work ethic
+10 Job Experience

=== Weekly Event ===
You spend the evening at the local tavern. The atmosphere is lively with music and laughter.
```

## NPC Job Types Available

For filtering NPCs in your events:

**Common Jobs**: Farmer, Fisherman, Carpenter, Baker, Butcher, Tailor, etc.
**Craft Jobs**: Blacksmith, Armorer, Weaponsmith, Jeweler, Goldsmith, etc.
**Merchant Jobs**: Merchant, Shopkeeper, Trader, Peddler, etc.
**Service Jobs**: Barber, Healer, Teacher, Scribe, Musician, Bard, Actor, etc.
**Magical Jobs**: Wizard, Enchanter, Alchemist, Sage, etc.
**Ruler Jobs**: King, Queen, Lord, Lady, Mayor, Mayoress, Headman, Headwoman

## Tips

1. **Variety**: Each event type has multiple description variants to keep things fresh
2. **NPC Integration**: Some events pull from the world population for realistic interactions
3. **Location-Based**: Events reference "Arn" by default (the starting town)
4. **Seasonal Flavor**: Weather events can reflect different seasons
5. **Community Feel**: Many events emphasize community and social interaction

## Future Enhancements

Consider adding:
1. **Location-Specific Events**: Different events based on where the player is
2. **Seasonal Events**: Events that only trigger in certain seasons/months
3. **Player Choice Events**: Events that give the player options
4. **Consequences**: Events that affect stats, money, or relationships
5. **Chain Events**: Events that lead to follow-up events
6. **Rare Events**: Very low chance special events
7. **Player Action Events**: Events based on player's recent activities

## Debugging

To test specific weekly events:

```csharp
// In WeeklyEvents.cs, temporarily change GetRandomWeeklyEvent:
public static WeeklyEventModel GetRandomWeeklyEvent(Player player)
{
    // Force a specific event for testing
    return MarketDayEvent(player);  // Test market event
    
    // Or use a specific ID:
    return eventId switch
    {
        _ => TavernNightEvent(player)  // Test tavern event
    };
}
```

Remember to remove test code before committing!

## Integration with Existing Systems

Weekly events work seamlessly with:
- **World Events**: Major events like wars, disasters, etc.
- **Job Events**: Guild-specific events for players with jobs
- **Quest System**: Quests can complete on the same turn as weekly events
- **Save System**: Weekly events don't persist (they're generated fresh each week)

The system is designed to be non-intrusive and additive - it enhances the game without interfering with existing mechanics.
