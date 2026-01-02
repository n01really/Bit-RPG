using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Models;

namespace Bit_RPG.Char
{
    public class Inventory
    {
        private Player player;

        public WeaponModel EquippedWeapon { get; private set; }
        public ArmorModel EquippedArmor { get; private set; }

        public Inventory(Player player)
        {
            this.player = player;
        }

        public void AddItem(ItemModel item)
        {
            player.Inventory.Add(item);
        }

        public bool RemoveItem(ItemModel item)
        {
            return player.Inventory.Remove(item);
        }

        public bool EquipWeapon(WeaponModel weapon)
        {
            if (!player.Inventory.Contains(weapon))
                return false;

            if (EquippedWeapon != null)
            {
                UnequipWeapon();
            }

            EquippedWeapon = weapon;
            player.Attack += weapon.Damage;
            return true;
        }

        public void UnequipWeapon()
        {
            if (EquippedWeapon != null)
            {
                player.Attack -= EquippedWeapon.Damage;
                EquippedWeapon = null;
            }
        }

        public bool EquipArmor(ArmorModel armor)
        {
            if (!player.Inventory.Contains(armor))
                return false;

            if (EquippedArmor != null)
            {
                UnequipArmor();
            }

            EquippedArmor = armor;
            player.Defense += armor.Defense;
            return true;
        }

        public void UnequipArmor()
        {
            if (EquippedArmor != null)
            {
                player.Defense -= EquippedArmor.Defense;
                EquippedArmor = null;
            }
        }

        public int SellItem(ItemModel item)
        {
            if (!player.Inventory.Contains(item))
                return 0;

            if (item == EquippedWeapon)
                UnequipWeapon();
            
            if (item == EquippedArmor)
                UnequipArmor();

            int sellPrice = (int)(item.BaseValue * 0.5f);
            player.Money += sellPrice;
            player.Inventory.Remove(item);
            return sellPrice;
        }

        public List<WeaponModel> GetWeapons()
        {
            return player.Inventory.OfType<WeaponModel>().ToList();
        }

        public List<ArmorModel> GetArmors()
        {
            return player.Inventory.OfType<ArmorModel>().ToList();
        }

        public List<IngredientModel> GetIngredients()
        {
            return player.Inventory.OfType<IngredientModel>().ToList();
        }

        public List<CraftingItemModel> GetCraftingItems()
        {
            return player.Inventory.OfType<CraftingItemModel>().ToList();
        }

        public List<MiscItemModel> GetMiscItems()
        {
            return player.Inventory.OfType<MiscItemModel>().ToList();
        }
    }
}
