using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    [Serializable]
    public class PlayerArmor : PlayerItem
    {
        public enum ArmorType
        {
            None,
            Light,
            Medium,
            Heavy,
            Shield
        }

        public int ArmorClass;
        public ArmorType Type;
        public Boolean IsShield;
        public int MinStrength;
        public Boolean IsStealthDisadvantage;
        public Boolean IsDexterityModifier;
        public int MaxDexModifier;
        public Boolean IsEquipped = false;
        public Boolean IsMagical = false;
        public int MagicalAcBonus = 0;

        /*
        public override string ToString()
        {
            return "Name : " + this.ItemName + "AC : " + this.ArmorClass.ToString();
        }
        */

        public PlayerArmor Clone()
        {
            return (PlayerArmor)this.MemberwiseClone();
        }

        public List<BonusValueModifier> GetAcModifiers(int DexModifier)
        {
            /* We are wearing armor. */
            List<BonusValueModifier> res = new List<BonusValueModifier>();
            res.Add(new BonusValueModifier(this.getDisplayedName(), this.ArmorClass));


            if (this.IsDexterityModifier)
            {
                int dexBonus = DexModifier;
                if (this.MaxDexModifier > 0)
                {
                    dexBonus = Math.Min(dexBonus, this.MaxDexModifier);
                }

                res.Add(new BonusValueModifier("DEX bonus", dexBonus));
            }

            if (this.MagicalAcBonus != 0)
            {
                res.Add(new BonusValueModifier("Magical", this.MagicalAcBonus));
            }

            return res;
        }
    }
}
