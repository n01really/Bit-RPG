using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bit_RPG.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Weight { get; set; }
        public int BaseValue { get; set; }
    }
    public class WeaponModel : ItemModel
    {
        public int Damage { get; set; }
        public float AttackSpeed { get; set; }

        [Flags]
        public enum WeaponType
        {
            None = 0,
            Blade = 1 << 0,        // 1
            HeavyWeapon = 1 << 1,  // 2
            RangedWeapon = 1 << 2, // 4
            LongWeapon = 1 << 3    // 8
        }
        public WeaponType Type { get; set; }
    }
    public class ArmorModel : ItemModel
    {
        public int Defense { get; set; }
        
        public ArmorType Type { get; set; }
        public enum ArmorType
        {
            Light,
            Medium,
            Heavy
        }
    }
    public class IngredientModel : ItemModel
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
