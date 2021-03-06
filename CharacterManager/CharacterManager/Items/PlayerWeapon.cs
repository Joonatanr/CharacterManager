﻿using System;
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
            Bludgeoning,
            Piercing,
            Slashing,
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
        public Boolean      IsEquipped = false;
        public Boolean IsEquippedTwoHanded = false;
        public String AmmoType = string.Empty;

        public int rollDamage(out String log)
        {
            DieRollValue value = new DieRollValue(Damage.DamageValue);
            return value.RollValue(out log);
        }

        public override string getExtendedDescription()
        {
            String res = ItemName + ":\n";
            res += "Base damage : " + Damage.DamageValue + " " + Damage.Type + " damage\n";

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

        public PlayerWeapon Clone()
        {
            return (PlayerWeapon)this.MemberwiseClone();
        }
    }
}
