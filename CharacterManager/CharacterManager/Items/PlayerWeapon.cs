using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    [Serializable]
    public class PlayerWeapon : PlayerItem
    {
        public struct WeaponRange
        {
            public int NormalRange;
            public int LongRange;


            public WeaponRange(int v1, int v2) : this()
            {
                this.NormalRange = v1;
                this.LongRange = v2;
            }
        }

        public enum WeaponType
        {
            Simple,
            Martial,
        };

        public enum DamageType
        {
            None,
            Bludgeoning,
            Piercing,
            Slashing,
            Acid,
            Cold,
            Fire,
            Force,
            Lightning,
            Necrotic,
            Poison,
            Psychic,
            Radiant,
            Thunder
        };

        public struct WeaponDamage
        {
            public String DamageValue;
            public DamageType Type;
        }

        public Boolean      IsAmmunition = false;
        public Boolean      IsFinesse = false;
        public Boolean      IsHeavy = false;
        public Boolean      IsLight = false;
        public Boolean      IsLoading = false;
        public Boolean      IsThrown = false;
        public Boolean      IsTwoHanded = false;
        public Boolean      IsVersatile = false;
        public Boolean      IsRanged = false; //This applies only to purposefully ranged weapons such as bows and crossbows...
        public Boolean      IsReach = false;

        public WeaponType Type;
        public WeaponRange  Range = new WeaponRange(0,0);
        public int          Reach = 5;
        public String       SpecialRules;

        public WeaponDamage Damage;
        public WeaponDamage TwoHandedDamage;
        //public List<WeaponDamage> ExtraDamage = new List<WeaponDamage>(); /* Some weapons can do an extra 1d4 radiant/fire/cold damage etc. */
        public WeaponDamage ExtraDamage;
        public Boolean      IsEquipped = false;
        public Boolean IsEquippedTwoHanded = false;
        public String AmmoType = string.Empty;

        /* For +X weapons */
        public Boolean IsMagical = false;
        public int MagicalBonus = 0;

        public override string getExtendedDescription()
        {
            String res = Name + ":\n";
            if (IsMagical)
            {
                res += "Base damage : " + Damage.DamageValue + " " + " + " + MagicalBonus.ToString() + " " + Damage.Type + " damage\n";
            }
            else
            {
                res += "Base damage : " + Damage.DamageValue + " " + Damage.Type + " damage\n";
            }
            return res;
        }

        public void setEquipped(Boolean IsEquipped, Boolean isTwoHanded)
        {
            if (IsEquipped)
            {
                if (this.IsTwoHanded)
                {
                    /* We don't really have any other options in this case. */
                    this.IsEquippedTwoHanded = true;
                }
                else
                {
                    this.IsEquippedTwoHanded = isTwoHanded;
                }
                this.IsEquipped = true;
            }
            else
            {
                this.IsEquipped = false;
                this.IsEquippedTwoHanded = false;
            }
        }


        public List<BonusValueModifier> getBaseDamageModifiers()
        {
            /* Here we return all the base damage modifiers that are derived from the weapon itself, but not things like STR and DEX bonus etc. */
            List<BonusValueModifier> res = new List<BonusValueModifier>();
            
            if (IsVersatile && IsEquippedTwoHanded)
            {
                res.Add(new BonusValueModifier("Base Damage (2H)" , TwoHandedDamage.DamageValue));
            }
            else
            {
                res.Add(new BonusValueModifier("Base Damage", Damage.DamageValue));
            }

            if (IsMagical)
            {
                res.Add(new BonusValueModifier("Magical", MagicalBonus));
            }

            if (!string.IsNullOrEmpty(ExtraDamage.DamageValue))
            {
                res.Add(new BonusValueModifier(ExtraDamage.Type.ToString(), ExtraDamage.DamageValue));
            }

            return res;
        }

        public BonusValueModifier getMagicalAttackBonus()
        {
            if (IsMagical)
            {
                return new BonusValueModifier("Magical Bonus", MagicalBonus);
            }
            else
            {
                return null;
            }
        }

        public PlayerWeapon Clone()
        {
            return (PlayerWeapon)this.MemberwiseClone();
        }
    }
}
