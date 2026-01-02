# Skill and Level System Refactor

## Overview
The leveling and skill progression system has been completely refactored to provide a more meaningful progression experience. Players now allocate attribute points when leveling up, while skills can only be increased through quests and paid training.

## Key Changes

### 1. Level Up System Changes

#### Before:
- Leveling up gave 15 skill points
- All stats (Health, Mana, Strength, Agility, Intelligence, Attack, Defense, MDefense) automatically increased by 5 each level
- Players could freely distribute skill points to any skill

#### After:
- Leveling up gives **5 attribute points**
- **No automatic stat increases** - players must manually allocate points
- Players can only increase: **Strength, Agility, Intelligence, Max Health, and Max Mana**
- Skills can NO LONGER be increased with attribute points

### 2. Skill Training System

#### Guild Hall Training (Most Skills)
- **Location**: Guild Hall ? Training
- **Cost**: Gold (scales with skill level: 20 + (level × 2) gold)
- **Available Skills** (guild-specific):
  - **Adventurers Guild**: Swordsmanship, Long Weapons, Heavy Weapons, Marksmanship, Heavy Armor, Medium Armor, Light Armor, First Aid, Lockpicking
  - **Blacksmiths Guild**: Heavy Weapons, Long Weapons, Swordsmanship, Heavy Armor, Medium Armor
  - **Mages Guild**: Conjuration, Destruction, Illusion, Restoration
  - **Thieves Guild**: Stealth, Slight of Hand, Lockpicking, Marksmanship, Light Armor, Illusion

#### Crafters Guild Training (Crafting Skills)
- **Location**: Crafters Guild (renamed from "Smithy") ? Train Crafting Skills
- **Cost**: Gold (scales with skill level: 25 + (level × 3) gold)
- **Available Skills**:
  - **Smithing**: Craft weapons and armor
  - **Alchemy**: Brew potions and elixirs
  - **Enchanting**: Enchant items with magic

### 3. Quest Rewards
- Quests still reward skill increases as designed
- This is now the PRIMARY way to gain skills beyond training
- Training is expensive, so quests are valuable for skill progression

## Updated Popups

### LevelUpPopup
**File**: `Popups/LevelUpPopup.xaml` & `Popups/LevelUpPopup.xaml.cs`

**Changes**:
- Renamed "Skill Points" to "Attribute Points"
- Only displays 5 attributes: Max Health, Max Mana, Strength, Agility, Intelligence
- Removed all skill allocation options
- Added info text: "Skills can only be increased through quests and training"
- Players can increase/decrease attributes before finalizing
- Max attribute value: 150

**Usage**:
1. Player gains enough XP to level up
2. Popup appears automatically
3. Player distributes 5 attribute points among the 5 attributes
4. Click "Finish" to confirm

### TrainingPopup
**File**: `Popups/TrainingPopup.xaml` & `Popups/TrainingPopup.xaml.cs`

**Changes**:
- Changed from skill points to gold-based training
- Shows player's current gold
- Each skill displays:
  - Current level
  - Training cost (increases with level)
  - Train button (disabled if not enough gold or maxed out)
- **Removed** Smithing, Alchemy, and Enchanting (moved to Crafters)
- Only shows skills relevant to player's current guild
- Cost formula: 20 + (current_level × 2) gold

**Usage**:
1. Visit Guild Hall
2. Click "View Training Options"
3. Select a skill to train
4. Pay the gold cost to increase skill by 1

### CraftersPopup (Renamed from SmithyPopup)
**File**: `Popups/CraftersPopup.xaml` & `Popups/CraftersPopup.xaml.cs`

**Changes**:
- Renamed from "Smithy" to "Crafters Guild"
- Updated description to mention crafting skills
- Added new "Train Crafting Skills" button
- Removed the old "Train Smithing (1 Skill Point)" button
- Opens new CraftingTrainingPopup for skill training

**Usage**:
1. Visit Activities ? Crafters Guild
2. Choose to commission work, craft yourself, or train crafting skills

### CraftingTrainingPopup (New)
**File**: `Popups/CraftingTrainingPopup.xaml` & `Popups/CraftingTrainingPopup.xaml.cs`

**New Popup** for training crafting-specific skills:
- Displays all 3 crafting skills: Smithing, Alchemy, Enchanting
- Shows description for each skill
- Gold-based training system
- Cost formula: 25 + (current_level × 3) gold (more expensive than combat skills)

**Usage**:
1. Visit Crafters Guild
2. Click "Train Crafting Skills"
3. Select a crafting skill to train
4. Pay the gold cost to increase skill by 1

### ActivitiesPopup
**File**: `Popups/ActivitiesPopup.xaml` & `Popups/ActivitiesPopup.xaml.cs`

**Changes**:
- Renamed "Smithy" to "Crafters Guild"
- Updated button text: "Visit Smithy" ? "Visit Crafters"
- Updated method name: `OnSmithyClicked` ? `OnCraftersClicked`
- Now opens `CraftersPopup` instead of `SmithyPopup`

## Player Class Changes

**File**: `Char/Player.cs`

**Changes**:
1. `LevelUp()` method:
   - Now gives 5 attribute points instead of 15 skill points
   - Removed automatic stat increases
   - Only increments level and carries over excess XP

2. Added INotifyPropertyChanged to:
   - `Agility` - was auto-property, now notifies UI
   - `Intelligence` - was auto-property, now notifies UI
   - `MaxHealth` - was auto-property, now notifies UI
   - `MaxMana` - was auto-property, now notifies UI

These changes ensure the UI updates correctly when stats change.

## Progression Flow

### Character Progression Path:
1. **Gain XP** ? Level up
2. **Allocate 5 attribute points** to core stats (Str, Agi, Int, HP, Mana)
3. **Complete quests** to gain skill increases (free)
4. **Pay for training** at Guild Hall or Crafters to increase specific skills
5. **Skills enable new abilities**:
   - Higher Smithing unlocks better crafting recipes
   - Combat skills improve effectiveness in battle
   - Magic skills unlock more powerful spells

### Economy Impact:
- Training creates a gold sink
- Players must balance spending on:
  - Market items (equipment, consumables)
  - Skill training
  - Commissions (crafted equipment)
- Higher-level skills cost more to train
- Encourages doing quests (free skill gains)

## Skill Categories

### Combat Skills (Guild Hall Training):
- **Weapon Skills**: Swordsmanship, Long Weapons, Heavy Weapons, Marksmanship
- **Armor Skills**: Light Armor, Medium Armor, Heavy Armor
- **Magic Schools**: Conjuration, Destruction, Illusion, Restoration
- **Utility**: First Aid, Stealth, Lockpicking, Slight of Hand

### Crafting Skills (Crafters Training):
- **Smithing**: Create weapons and armor
- **Alchemy**: Brew potions and elixirs
- **Enchanting**: Add magical properties to items

## Files Modified

### Modified Files:
1. `Char/Player.cs` - Updated LevelUp method, added property notifications
2. `Popups/LevelUpPopup.xaml` - Changed to attribute allocation
3. `Popups/LevelUpPopup.xaml.cs` - Implemented attribute allocation logic
4. `Popups/TrainingPopup.xaml` - Changed to gold-based system
5. `Popups/TrainingPopup.xaml.cs` - Implemented gold-based training
6. `Popups/ActivitiesPopup.xaml` - Renamed Smithy to Crafters
7. `Popups/ActivitiesPopup.xaml.cs` - Updated to open CraftersPopup

### New Files:
1. `Popups/CraftersPopup.xaml` - Renamed Smithy popup
2. `Popups/CraftersPopup.xaml.cs` - Updated smithy logic
3. `Popups/CraftingTrainingPopup.xaml` - New crafting skill training
4. `Popups/CraftingTrainingPopup.xaml.cs` - Crafting training logic

### Deprecated (Still in project but replaced):
- `Popups/SmithyPopup.xaml` - Replaced by CraftersPopup
- `Popups/SmithyPopup.xaml.cs` - Replaced by CraftersPopup

## Training Cost Examples

### Guild Hall Skills:
- Level 0 ? 1: 20 gold
- Level 10 ? 11: 40 gold
- Level 25 ? 26: 70 gold
- Level 50 ? 51: 120 gold
- Level 99 ? 100: 218 gold

### Crafting Skills:
- Level 0 ? 1: 25 gold
- Level 10 ? 11: 55 gold
- Level 25 ? 26: 100 gold
- Level 50 ? 51: 175 gold
- Level 99 ? 100: 322 gold

## Balance Considerations

### Advantages:
- **More meaningful leveling**: Players actively choose their build
- **Economic integration**: Skills cost gold, creating resource management
- **Quest value**: Free skill gains from quests are more valuable
- **Specialization**: Expensive training encourages focusing on specific skills
- **Guild relevance**: Each guild offers different training options

### Potential Issues to Monitor:
- Gold scarcity might make training too expensive
- Players might not have enough gold for both equipment and training
- May need to adjust training costs or quest gold rewards

## Testing Recommendations

1. **Level up**: Verify attribute allocation works correctly
2. **Guild Training**: Test training different skills at various levels
3. **Crafters Training**: Test all 3 crafting skills
4. **Gold costs**: Ensure costs scale appropriately
5. **Quest rewards**: Verify quests still grant skill increases
6. **UI updates**: Confirm all stat changes reflect in UI immediately
7. **Validation**: Test edge cases (max level, no gold, etc.)

## Future Enhancements

Potential additions to this system:
- **Training discounts** for high guild rank
- **Group training sessions** at reduced cost
- **Skill books** as rare quest rewards
- **Master trainers** who can train skills beyond 100
- **Skill respec** option (for gold)
- **Training mini-games** to reduce cost
- **Crafting stations** that boost training effectiveness

---

**Migration Note**: Old save files with allocated skill points will still work, but players won't be able to allocate skill points from level-ups anymore. This is intentional and maintains backward compatibility.
