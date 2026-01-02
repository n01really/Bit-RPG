using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Items;
using Bit_RPG.Models;

namespace Bit_RPG.Items
{
    internal class MarketInventory
    {
        private List<ItemModel> marketItems = new List<ItemModel>();
        private Random random = new Random();

        public List<ItemModel> MarketItems => marketItems;

        public void PopulateMarketInventory()
        {
            marketItems.Clear();
            Items items = new Items();
            ItemModel[][] allItems = (ItemModel[][])items.GetAllItems();

            foreach (var row in allItems)
            {
                if (row.Length > 0)
                {
                    var randomItems = row.OrderBy(x => random.Next()).Take(3);
                    marketItems.AddRange(randomItems);
                }
            }
        }

        public void PopulateMarketInventoryForLocation(string locationName, LocationType locationType)
        {
            marketItems.Clear();
            Items items = new Items();
            ItemModel[][] allItems = (ItemModel[][])items.GetAllItems();

            // Base number of items varies by location type
            int itemsPerCategory = locationType switch
            {
                LocationType.Village => 1,  // Villages have limited selection
                LocationType.Town => 2,     // Towns have moderate selection
                LocationType.City => 4,     // Cities have large selection
                _ => 2
            };

            // Get specialty items based on location name
            var specialtyItems = GetSpecialtyItemsForLocation(locationName, items);
            marketItems.AddRange(specialtyItems);

            // Add random items from each category
            foreach (var row in allItems)
            {
                if (row.Length > 0)
                {
                    var randomItems = row.OrderBy(x => random.Next()).Take(itemsPerCategory);
                    marketItems.AddRange(randomItems);
                }
            }
        }

        private List<ItemModel> GetSpecialtyItemsForLocation(string locationName, Items items)
        {
            var specialties = new List<ItemModel>();

            // Location-specific items
            switch (locationName)
            {
                // Coastal/Maritime locations - fishing gear, salt, etc.
                case "Antastead":
                case "Harbor Point":
                case "Saltmere":
                case "Seabreeze":
                case "Tidewater":
                case "Sailors Cove":
                case "Saltwater":
                case "Windshore":
                case "Tidemark":
                    // Add fishing-related items, salt, seafood ingredients
                    break;

                // Forested locations - wood, herbs
                case "Oakvale":
                case "Pinehill":
                case "Willowbrook":
                case "Maplewood":
                case "Oakshire":
                case "Pinewood":
                case "Willowdale":
                case "Maplegrove":
                    // Add wood, herbs, forest ingredients
                    break;

                // Magical cities - potions, scrolls
                case "Starhaven":
                case "Word":
                case "Xora":
                case "Starlight":
                case "Fladon":
                    // Add magical items, potions, scrolls
                    break;

                // Military/Warrior locations - weapons, armor
                case "Ironpeak":
                case "Forge Town":
                case "Warriors Rest":
                case "Aflemland":
                case "Garrison Post":
                case "Strongwall":
                case "Watchtower":
                case "Battleborn":
                    // Add weapons and armor
                    break;

                // Agricultural locations - food, farming supplies
                case "Wramham":
                case "Harvest Home":
                case "Farmstead":
                case "Granary":
                case "Orchard Vale":
                case "Wheatfield":
                case "Croplands":
                case "Barleybrook":
                case "Applewood":
                    // Add food items, farming ingredients
                    break;

                // Trading hubs - variety
                case "Southhold":
                case "Raso":
                case "Merchants Rest":
                case "Merchants Gate":
                case "Caravan Stop":
                case "Tradeway":
                case "Silk Road":
                    // Add diverse items
                    break;

                default:
                    // Standard selection
                    break;
            }

            return specialties;
        }
    }
}
