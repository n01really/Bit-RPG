# Crafting System Implementation Guide

## Overview
A complete crafting system has been implemented for **Alchemy** (potions) and **Smithing** (weapons & armor). Players can craft items once they reach level 10 in the respective skills.

## System Requirements
- **Alchemy Level 10+**: Required to brew potions
- **Smithing Level 10+**: Required to craft weapons and armor

## Files Created

### Core System Files
1. **`Crafting/CraftingRecipes.cs`** - Recipe definitions and management
2. **`Crafting/CraftingSystem.cs`** - Crafting logic and validation
3. **`Popups/CraftingPopup.xaml`** - Crafting UI
4. **`Popups/CraftingPopup.xaml.cs`** - Crafting UI logic

### Updated Files
- **`Popups/CraftersPopup.xaml.cs`** - Opens smithing crafting
- **`Popups/ActivitiesPopup.xaml`** - Added Apothecary section
- **`Popups/ActivitiesPopup.xaml.cs`** - Opens alchemy crafting

## How to Access Crafting

### Smithing (Weapons & Armor)
1. Visit **Activities** ? **Crafters Guild** (costs 1 AP)
2. Must have **Smithing Level 10+**
3. Click **"View Crafting Options"**
4. Select a recipe and click **"Craft"**

### Alchemy (Potions)
1. Visit **Activities** ? **Apothecary** (costs 1 AP)
2. Must have **Alchemy Level 10+**
3. Select a potion recipe and click **"Craft"**

## Available Recipes

### Alchemy Recipes (Potions)

#### Level 10
- **Minor Health Potion** (Restores 25 HP)
  - 2x Herth Herb
  - 1x Red Mushroom
  - Grants: +5 Alchemy XP
  
- **Minor Mana Potion** (Restores 25 MP)
  - 2x Mort Wood
  - 1x Blue Flower
  - Grants: +5 Alchemy XP

#### Level 25
- **Health Potion** (Restores 50 HP)
  - 3x Herth Herb
  - 2x Red Mushroom
  - 1x Dragon Scale
  - Grants: +10 Alchemy XP
  
- **Mana Potion** (Restores 50 MP)
  - 3x Mort Wood
  - 2x Blue Flower
  - 1x Magic Crystal
  - Grants: +10 Alchemy XP

#### Level 40
- **Greater Health Potion** (Restores 100 HP)
  - 5x Herth Herb
  - 3x Red Mushroom
  - 2x Dragon Scale
  - Grants: +15 Alchemy XP

### Smithing Recipes (Weapons & Armor)

#### Level 10 - Weapons
- **Iron Dagger** (Damage: 10, Speed: 1.8)
  - 2x Iron Ore
  - 1x Wood Plank
  - Grants: +8 Smithing XP

#### Level 15 - Armor
- **Leather Armor** (Defense: 4, Light)
  - 5x Leather Strip
  - 2x Wood Plank
  - Grants: +8 Smithing XP

#### Level 20 - Weapons
- **Iron Spear** (Damage: 11, Speed: 0.9, Long Weapon)
  - 3x Iron Ore
  - 3x Wood Plank
  - Grants: +10 Smithing XP

#### Level 25 - Weapons
- **Iron Sword** (Damage: 14, Speed: 1.5)
  - 4x Iron Ore
  - 2x Wood Plank
  - 1x Leather Strip
  - Grants: +12 Smithing XP

#### Level 30 - Armor
- **Chainmail Armor** (Defense: 9, Medium)
  - 6x Iron Ore
  - 3x Leather Strip
  - Grants: +15 Smithing XP

#### Level 40 - Weapons
- **Steel Sword** (Damage: 20, Speed: 1.6)
  - 3x Steel Ingot
  - 2x Wood Plank
  - 2x Leather Strip
  - Grants: +18 Smithing XP

#### Level 50 - Armor
- **Steel Plate Armor** (Defense: 22, Heavy)
  - 8x Steel Ingot
  - 5x Leather Strip
  - Grants: +25 Smithing XP

## Crafting Materials

### Ingredients (For Alchemy)
- **Herth Herb** (ID: 31) - Restores 10 HP
- **Mort Wood** (ID: 32) - Restores 10 MP
- **Red Mushroom** (ID: 33) - Restores 15 HP
- **Blue Flower** (ID: 34) - Restores 20 MP
- **Dragon Scale** (ID: 35) - Fire Resistance

### Crafting Items (For Smithing)
- **Iron Ore** (ID: 41) - 15g
- **Leather Strip** (ID: 42) - 5g
- **Wood Plank** (ID: 43) - 3g
- **Steel Ingot** (ID: 44) - 30g
- **Magic Crystal** (ID: 45) - 100g

## Crafting Process

### Step 1: Gather Materials
- Buy from Market
- Collect from quests
- Gather from world events

### Step 2: Check Requirements
- Open crafting menu
- Recipes display:
  - ? **Green border** = Can craft (all materials available)
  - ?? **Orange border** = Missing ingredients
  - ? **Gray border** = Skill level too low

### Step 3: Craft Item
- Click **"Craft"** button
- Ingredients are consumed
- Crafted item added to inventory
- Skill experience gained

### Step 4: Automatic Skill Progression
- Crafting grants experience toward the skill
- Higher level recipes grant more experience
- Skills cap at 100

## UI Features

### Recipe Display
Each recipe shows:
- **Recipe Name** and required level
- **Description** of the item
- **Result Stats** (Damage, Defense, Effect)
- **Required Ingredients** with current/needed counts
  - ? Green = Have enough
  - ?? Orange = Need more
- **Experience Gain** in gold text
- **Craft Button** (if eligible)

### Filtering (Smithing Only)
- **All Recipes** - Shows everything
- **Weapons** - Shows only weapon recipes
- **Armor** - Shows only armor recipes

### Real-time Updates
- Ingredient counts update after crafting
- Skill level updates immediately
- Recipes become available as you level up

## Skill Progression

### How to Increase Crafting Skills
1. **Train at Crafters Guild** (costs gold, scales with level)
   - Formula: 25 + (current_level × 3) gold
   - Example: Level 0?1 costs 25g, Level 50?51 costs 175g
   
2. **Craft Items** (costs materials, grants XP)
   - More complex recipes = more XP
   - Level 10 recipes: 5-8 XP
   - Level 40+ recipes: 15-25 XP

3. **Complete Quests** (free skill increases)
   - Some quests reward crafting skill increases

## Example Crafting Workflow

### Making a Health Potion (Level 25 Alchemy)

1. **Check Requirements**
   ```
   Required: Alchemy Level 25
   Ingredients:
   - 3x Herth Herb
   - 2x Red Mushroom
   - 1x Dragon Scale
   ```

2. **Gather Materials**
   - Visit Market ? Buy Herth Herbs (5g each)
   - Complete quests for Red Mushrooms
   - Buy Dragon Scale (50g) from Market

3. **Craft the Potion**
   - Visit Apothecary
   - Select "Health Potion" recipe
   - Click "Craft"
   - Ingredients consumed
   - Health Potion added to inventory
   - +10 Alchemy XP

4. **Use or Sell**
   - Use in combat/quests
   - Sell at Market for profit

### Making a Steel Sword (Level 40 Smithing)

1. **Train to Level 40**
   - Visit Crafters Guild ? Train Crafting Skills
   - Pay gold to increase Smithing to 40

2. **Gather Materials**
   - 3x Steel Ingot (30g each = 90g)
   - 2x Wood Plank (3g each = 6g)
   - 2x Leather Strip (5g each = 10g)
   - Total cost: 106g

3. **Craft the Sword**
   - Visit Crafters ? View Crafting Options
   - Select "Steel Sword"
   - Click "Craft"
   - Receive: Crafted Steel Sword (Damage: 20)
   - +18 Smithing XP

4. **Equip or Sell**
   - Equip for +20 Attack
   - Sell for 45g (50% of 90g value)

## Economic Balance

### Profitability
- **Buying materials + crafting** usually costs more than buying finished items
- **Value**: Crafting gives you:
  - Exact items you need
  - Skill progression
  - Self-sufficiency
  
### Cost Examples
- **Minor Health Potion**
  - Materials: 2×5g + 1×8g = 18g
  - Result value: 15g
  - **Loss**: 3g (but +5 XP)
  
- **Steel Sword**
  - Materials: 106g
  - Result value: 90g
  - **Loss**: 16g (but +18 XP and powerful weapon)

### Best Strategy
1. **Train skills** at Crafters Guild when you have gold
2. **Gather ingredients** from quests (free)
3. **Craft what you need** rather than buying
4. **Sell excess** crafted items for profit

## Integration with Existing Systems

### Market System
- Buy crafting materials from Market
- Sell crafted items back to Market

### Inventory System
- Crafted items added automatically
- Can equip weapons/armor
- Can use potions (future feature)

### Skill System
- Crafting increases Alchemy/Smithing
- Skills cap at 100
- Higher skills unlock better recipes

### Training System
- Train at Crafters Guild for gold
- Crafting provides alternative XP source

## Future Enhancements

Potential additions:
- **Enchanting recipes** for magical items
- **Quality tiers** (Normal, Fine, Masterwork)
- **Critical success** chance for bonus stats
- **Bulk crafting** (craft multiple items)
- **Recipe discovery** from books/quests
- **Tool requirements** (better anvil = better results)
- **Crafting stations** in player home
- **Potion effects** in combat system

## Troubleshooting

### "Cannot Craft" Error
- **Check skill level**: Recipe may require higher level
- **Check materials**: Verify you have ALL ingredients
- **Check quantities**: Need exact amounts

### Recipes Not Showing
- **Train to level 10**: Must reach level 10 in Alchemy/Smithing
- **Visit correct location**: 
  - Smithing ? Crafters Guild
  - Alchemy ? Apothecary

### Ingredients Disappearing
- **This is normal**: Ingredients are consumed when crafting
- **Save first**: Consider saving before expensive crafts

## Build Instructions

If you encounter build errors:

```bash
# Clean the solution
dotnet clean

# Rebuild
dotnet build

# If XAML errors persist, restart Visual Studio
```

The crafting system is fully implemented and ready to use once the build completes successfully!

---

**Note**: The crafting system is designed to work seamlessly with the existing market, inventory, and skill systems. All recipes scale appropriately with player progression from level 10 to level 50+.
