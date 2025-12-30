using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    public class ItemModel
    {
    }
    public class WeponModel : ItemModel
    {
        public int Damage { get; set; }
        public float AttackSpeed { get; set; }
        public enum WeaponType
        {
            Blade,
            HeavyWeapon,
            RangedWeapon,
            LongWeapon
        }
    }
    public class ArmorModel : ItemModel
    {
        public int Defense { get; set; }
        
        public enum ArmorType
        {
            Light,
            Medium,
            Heavy
        }
    }
    public class ingredientModel : ItemModel
    {
        public string Effect { get; set; }
        public int Duration { get; set; } // Duration in seconds
    }
    public class  CraftingItemModel : ItemModel
    {
        
    }
    public class MiscItemModel : ItemModel
    {
        public string Description { get; set; }
    }
    public enum ItemType
    {
        Weapon,
        Armor,
        Ingredient,
        CraftingItem,
        Misc
    }
}
