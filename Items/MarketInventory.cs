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
    }
}
