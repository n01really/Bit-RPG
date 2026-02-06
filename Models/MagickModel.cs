using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bit_RPG.Char;
using Bit_RPG.SpellBook;

namespace Bit_RPG.Models
{
    internal class MagickModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ManaCost { get; set; }
        public int CostToLearn { get; set; }
        public MagickSchool MagickSchool { get; set; }
        public MagickTypes MagickType { get; set; }
        public int Power { get; set; }
        public int AreaRadius { get; set; }
        public TargetType TargetingType { get; set; }

        public void CastOnTarget(Player caster, Player target)
        {
            // Implement the logic for casting the magick on a single target
            // This could involve calculating damage, applying effects, etc.
            if (TargetingType != TargetType.SingleTarget)
            {
                throw new InvalidOperationException("This magick cannot be cast on a single target.");
            }
            if (caster.CurrentMana < ManaCost)
            {
                throw new InvalidOperationException("Not enough mana to cast this magick.");
            }
            // Deduct mana cost from the caster
            caster.CurrentMana -= ManaCost;
            // Apply the effects of the magick to the target
            ApplyEffects(target);
        }
        public void CastOnArea(Player caster, List<Player> targets)
        {
            // Implement the logic for casting the magick on an area of effect
            // This could involve calculating damage, applying effects to multiple targets, etc.
            if (TargetingType != TargetType.AreaOfEffect) 
            { 
                throw new InvalidOperationException("This magick cannot be cast on an area of effect.");
            }
            if (caster.CurrentMana < ManaCost)
            {
                throw new InvalidOperationException("Not enough mana to cast this magick.");
            }
            // Deduct mana cost from the caster
            caster.CurrentMana -= ManaCost;
            // Apply the effects of the magick to each target
            foreach (var target in targets)
            {
                ApplyEffects(target);
            }
        }
        public void CastOnSelf(Player caster)
        {
            // Implement the logic for casting the magick on oneself
            // This could involve applying buffs, healing, etc.
            if (TargetingType != TargetType.Self)
            {
                throw new InvalidOperationException("This magick cannot be cast on oneself.");
            }
            if (caster.CurrentMana < ManaCost)
            {
                throw new InvalidOperationException("Not enough mana to cast this magick.");
            }
            // Deduct mana cost from the caster
            caster.CurrentMana -= ManaCost;
            // Apply the effects of the magick to the caster
            ApplyEffects(caster);
        }
        private void ApplyEffects(Player target)
        {
            // Implement the logic for applying the effects of the magick to the target
            // This could involve calculating damage, applying status effects, etc.
            switch (MagickSchool)
            {
                case MagickSchool.Destruction:
                    target.TakeDamage(Power);
                    break;
                    
                case MagickSchool.Restoration:
                    target.RestoreHealth(Power);
                    break;

                case MagickSchool.Illusion:
                    // Apply illusion effects (confusion, charm, fear)
                    // Positive Power = buff/charm, Negative Power = debuff/confusion
                    if (Power > 0)
                    {
                        // Charm: Temporarily increase target's stats
                        target.Intelligence += Power / 2;
                        target.Agility += Power / 3;
                        System.Diagnostics.Debug.WriteLine($"[Illusion] Charmed {target.PlayerName}: +{Power/2} Int, +{Power/3} Agi");
                    }
                    else if (Power < 0)
                    {
                        // Confusion: Temporarily decrease target's accuracy and defense
                        int penalty = Math.Abs(Power);
                        target.Attack -= penalty;
                        target.Defense -= penalty / 2;
                        System.Diagnostics.Debug.WriteLine($"[Illusion] Confused {target.PlayerName}: -{penalty} Atk, -{penalty/2} Def");
                    }
                    break;

                case MagickSchool.Alteration:
                    // Apply stat buffs/debuffs
                    // Positive Power = buff, Negative Power = debuff
                    if (Power > 0)
                    {
                        // Buff all primary stats
                        target.Strength += Power / 2;
                        target.Agility += Power / 2;
                        target.Intelligence += Power / 2;
                        target.Defense += Power / 3;
                        target.Attack += Power / 3;
                        System.Diagnostics.Debug.WriteLine($"[Alteration] Buffed {target.PlayerName}: +{Power/2} Str/Agi/Int, +{Power/3} Def/Atk");
                    }
                    else if (Power < 0)
                    {
                        // Debuff all primary stats
                        int penalty = Math.Abs(Power);
                        target.Strength -= penalty / 2;
                        target.Agility -= penalty / 2;
                        target.Intelligence -= penalty / 2;
                        target.Defense -= penalty / 3;
                        target.Attack -= penalty / 3;
                        System.Diagnostics.Debug.WriteLine($"[Alteration] Debuffed {target.PlayerName}: -{penalty/2} Str/Agi/Int, -{penalty/3} Def/Atk");
                    }
                    break;

                case MagickSchool.Conjuration:
                    // Summon Creatures or objects to aid in battle
                    break;

                default:
                    throw new NotImplementedException($"Effect for {MagickType} not implemented");
            }
        }
        public enum TargetType
        {
            Self,
            SingleTarget,
            AreaOfEffect
        }

    }


}
