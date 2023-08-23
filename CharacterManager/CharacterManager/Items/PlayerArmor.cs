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
            Light,
            Medium,
            Heavy,
        }

        public int ArmorClass;
        public ArmorType Type;
        public Boolean IsShield;
        public int MinStrength;
        public Boolean IsStealthDisadvantage;
        public Boolean IsDexterityModifier;
        public int MaxDexModifier;
        public Boolean IsEquipped = false;

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
    }
}
