# Market System Implementation

## Overview
A complete marketplace system has been added to Bit_RPG that allows players to buy items from a randomly generated market inventory and sell items from their own inventory. The system includes equipment management with stat bonuses for weapons and armor.

## Features Implemented

### 1. Market Inventory (`MarketInventory.cs`)
- **Location**: `Items/MarketInventory.cs`
- **Purpose**: Manages the market's available items
- **Functionality**:
  - Randomly selects 3 items from each category (Weapons, Armor, Ingredients, Crafting Items, Misc)
  - Total of 15 random items available in the market
  - Can be repopulated to refresh the market inventory

### 2. Inventory Management (`Inventory.cs`)
- **Location**: `Char/Inventory.cs`
- **Purpose**: Manages player's inventory and equipment
- **Key Features**:
  - **Equipment System**:
    - `EquipWeapon()` - Equips a weapon and adds its damage to player's Attack stat
    - `UnequipWeapon()` - Removes weapon and reverts Attack stat
    - `EquipArmor()` - Equips armor and adds its defense to player's Defense stat
    - `UnequipArmor()` - Removes armor and reverts Defense stat
  - **Selling**:
    - `SellItem()` - Sells an item for 50% of its base value
    - Automatically unequips items before selling
  - **Filtering**:
    - `GetWeapons()` - Returns all weapons in inventory
    - `GetArmors()` - Returns all armors in inventory
    - `GetIngredients()` - Returns all ingredients
    - `GetCraftingItems()` - Returns all crafting materials
    - `GetMiscItems()` - Returns all miscellaneous items

### 3. Market Popup (`MarketPopup.xaml` & `MarketPopup.xaml.cs`)
- **Location**: `Popups/`
- **Purpose**: UI for buying and selling items
- **Layout**:
  - **Top Section**: Displays player's current gold
  - **Left Column**: Market Items (Buy)
    - Shows 15 randomly selected items from the market
    - Displays item name, stats, and price
    - Buy button for each item
  - **Right Column**: Player Inventory (Sell)
    - Shows all items in player's inventory
    - Displays item name, stats, and sell price (50% of base value)
    - Sell button for each item

### 4. Updated Inventory Popup (`InventoryPopup.xaml` & `InventoryPopup.xaml.cs`)
- **Location**: `Popups/`
- **Purpose**: Enhanced inventory management UI
- **Features**:
  - Displays currently equipped weapon and armor at the top
  - Shows Attack and Defense stats
  - **Item Actions**:
    - Weapons and Armor have "Equip" or "Unequip" buttons
    - Currently equipped items show "Equipped" status
    - Ingredients show their effects (for quests and potion crafting)
    - Crafting Items indicate they're "Used in smithy"
    - Misc Items show their descriptions

### 5. Player Class Updates
- **Location**: `Char/Player.cs`
- **Changes**:
  - Added `InventoryManager` property of type `Inventory`
  - Made `Attack`, `Defense`, and `Strength` properties raise `PropertyChanged` events
  - This allows the UI to automatically update when equipment changes stats

## Item Categories and Their Uses

### Weapons
- **Purpose**: Equippable items that increase Attack stat
- **Stats**: Damage, Attack Speed, Weight, Type
- **Usage**: Equip via Inventory Popup to boost combat effectiveness
- **Examples**: Wooden Sword, Iron Longsword, Long Bow, Iron Halberd

### Armor
- **Purpose**: Equippable items that increase Defense stat
- **Stats**: Defense, Weight, Type (Light/Medium/Heavy)
- **Usage**: Equip via Inventory Popup to boost survivability
- **Examples**: Leather Armor, Chainmail Armor, Steel Plate Armor

### Ingredients
- **Purpose**: Used in quests and potion crafting
- **Stats**: Effect, Duration, Weight
- **Usage**: Collected for future quest requirements and alchemy system
- **Examples**: Herth Herb, Mort Wood, Red Mushroom, Dragon Scale

### Crafting Items
- **Purpose**: Used for crafting in the smithy
- **Stats**: Weight
- **Usage**: Required materials for crafting weapons and armor at the Smithy
- **Examples**: Iron Ore, Leather Strip, Wood Plank, Steel Ingot, Magic Crystal

### Misc Items
- **Purpose**: Quest items and collectibles
- **Stats**: Description, Weight
- **Usage**: Quest objectives, collectibles, and special items
- **Examples**: Old Key, Ancient Coin, Gemstone, Lucky Charm

## How to Use the Market

### Accessing the Market
1. Open the Activities menu from the main game page
2. Click the "Market" button (costs 1 Action Point)
3. The Market Popup will open with 15 random items

### Buying Items
1. Browse the left column showing Market Items
2. Each item shows:
   - Name and type
   - Relevant stats (Damage for weapons, Defense for armor, etc.)
   - Price in gold
3. Click "Buy" on an item you want
4. If you have enough gold, the item is added to your inventory
5. The item moves from the Market column to your Inventory column

### Selling Items
1. Browse the right column showing your Inventory
2. Each item shows:
   - Name and type
   - Relevant stats
   - Sell price (50% of base value)
3. Click "Sell" on an item you want to sell
4. The item is removed from your inventory
5. Gold is added to your account (shown at the top)
6. **Note**: Equipped items are automatically unequipped before selling

### Managing Equipment
1. Close the Market Popup
2. Access your Inventory from the main game page
3. Find weapons or armor in your inventory
4. Click "Equip" to wear the item
   - Weapons increase your Attack stat by their Damage value
   - Armor increases your Defense stat by their Defense value
5. Click "Unequip" to remove the item
   - Stats return to normal
6. Only one weapon and one armor can be equipped at a time
7. Equipping a new item automatically unequips the current one

## Economy System
- **Base Prices**: Set on each item (varies by item type and quality)
- **Sell Price**: Always 50% of base price
- **Player Gold**: Tracked in `Player.Money` property
- **Validation**: Can't buy items without sufficient gold
- **Equipment Check**: Prevents selling equipped items without unequipping first

## Technical Details

### Data Flow
1. `Items.cs` contains all item definitions
2. `MarketInventory.PopulateMarketInventory()` selects 3 random items from each category
3. Market displays these items with buy functionality
4. Player's `Inventory` list stores purchased items
5. `InventoryManager` handles equipment state and stat modifications
6. UI updates automatically through INotifyPropertyChanged events

### Item Type Detection
Items are categorized using C# pattern matching:
```csharp
item switch
{
    WeaponModel weapon => // Handle weapon
    ArmorModel armor => // Handle armor
    IngredientModel ingredient => // Handle ingredient
    CraftingItemModel craft => // Handle crafting item
    MiscItemModel misc => // Handle misc item
    _ => // Default case
}
```

### Future Integration Points
1. **Quests**: Ingredients can be required quest items
2. **Potion Crafting**: Ingredients will be used to brew potions
3. **Smithy**: Crafting Items will be used to forge equipment
4. **Item Rarity**: System can be extended to support rare/legendary items
5. **Market Refresh**: Can add time-based or event-based market refreshes
6. **NPC Merchants**: Can create specialized merchants with different inventories

## Files Modified/Created

### Created Files
- `Items/MarketInventory.cs` - Market inventory manager
- `Popups/MarketPopup.xaml` - Market UI
- `Popups/MarketPopup.xaml.cs` - Market logic and view model

### Modified Files
- `Char/Inventory.cs` - Changed from empty class to full inventory management system
- `Char/Player.cs` - Added InventoryManager and PropertyChanged events for stats
- `Popups/InventoryPopup.xaml` - Enhanced UI with equipment display and actions
- `Popups/InventoryPopup.xaml.cs` - Added equipment and item management logic
- `Popups/ActivitiesPopup.xaml.cs` - Connected Market button to MarketPopup

## Testing Recommendations
1. Test buying items with insufficient gold
2. Test equipping and unequipping weapons (verify Attack stat changes)
3. Test equipping and unequipping armor (verify Defense stat changes)
4. Test selling equipped items (should unequip first)
5. Test selling items for gold
6. Test the market refresh by closing and reopening (items stay the same session)
7. Verify all item types display correctly with appropriate stats
8. Test switching between multiple weapons/armors

## Known Considerations
- Market inventory persists for the current session only
- Currently no way to manually refresh the market (would require restarting or adding a refresh button)
- Equipped items cannot be sold without unequipping (this is by design for safety)
- Sell price is fixed at 50% of base value (no haggling system)

Enjoy your new marketplace!
