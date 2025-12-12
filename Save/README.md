# Save System Documentation

## Overview
The game now includes a JSON-based save system that automatically saves your progress when:
1. You first load into the GamePage (new game)
2. Every time you press the Continue button

## Save File Location
The save file is stored in:
- **Path**: `{AppDataDirectory}/Save/gamesave.json`
- **Format**: JSON (human-readable)

## What Gets Saved

### Player Data
- Character name, age, race, class
- Stats (Strength, Agility, Intelligence, etc.)
- Money and Experience
- Skills (all skill levels)
- Active quests
- Job information

### World State
- Current week number
- Event log (all events that have happened)
- Current town information
- Active world events (wars, plagues, disasters, etc.)

### NPCs
All generated NPCs are tracked including:
- NPC name
- Type (Mayor, Noble, Merchant, etc.)
- Race
- Location
- Title (if applicable)

## How to Use

### New Game
1. Click "New Game" from the main menu
2. Create your character
3. Game automatically saves when you arrive at your starting town

### Load Game
1. Click "Load Game" from the main menu (only enabled if a save file exists)
2. Your game state is restored exactly as it was saved
3. Continue playing from where you left off

### Save During Gameplay
- The game **automatically saves** every time you click the "Continue" button
- No manual save action is required
- The save file is updated instantly

## Technical Details

### Save Service (`Services/SaveService.cs`)
Handles all save/load operations:
- `SaveGameAsync(gameSave)` - Saves game state to JSON
- `LoadGameAsync()` - Loads game state from JSON
- `SaveFileExists()` - Checks if a save file exists
- `DeleteSave()` - Removes the save file

### Game Save Model (`Models/GameSaveModel.cs`)
Defines the structure of saved data:
```csharp
- SaveDate: When the game was last saved
- CurrentWeek: Game progression
- EventLog: All events that have occurred
- Player: Complete player character data
- GeneratedNpcs: List of all NPCs encountered
- CurrentTown: Where the player is located
- CurrentEvents: Active world events
```

### NPC Tracking (`Services/NpcTracker.cs`)
Helper methods to track NPCs:
- `AddNpc()` - Adds a single NPC to the tracking list
- `AddMultipleNpcs()` - Adds multiple NPCs at once
- Prevents duplicate NPCs in the same location

## Save File Example Structure
```json
{
  "SaveDate": "2024-01-15T14:30:00",
  "CurrentWeek": 5,
  "EventLog": "Week 1: ...",
  "Player": {
    "PlayerName": "Aragorn",
    "Age": 25,
    "Race": "Human",
    "Class": "Warrior",
    "Money": 150,
    "Experience": 25,
    ...
  },
  "GeneratedNpcs": [
    {
      "Name": "Mayor Aldric Blackwood",
      "Type": "Mayor",
      "Race": "Human",
      "Location": "Arn"
    }
  ],
  "CurrentTown": {
    "Name": "Arn",
    "Description": "A peaceful town...",
    "Mayor": "Mayor Aldric Blackwood",
    ...
  },
  "CurrentEvents": {
    "IsWarActive": false,
    "IsPlagueActive": false,
    ...
  }
}
```

## Future Enhancements
Consider adding:
1. Multiple save slots
2. Auto-save at regular intervals
3. Save file versioning for backward compatibility
4. Cloud save support
5. Export/import save files
6. NPC relationships and dialogue history
7. Inventory items tracking
