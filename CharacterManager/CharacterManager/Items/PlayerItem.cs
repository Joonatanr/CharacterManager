using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager.Items
{
    [Serializable]
    [XmlInclude(typeof(ItemContainer))]
    [XmlInclude(typeof(PlayerToolKit))]
    [XmlInclude(typeof(PlayerArmor))]
    [XmlInclude(typeof(PlayerWeapon))]
    public class PlayerItem : PlayerBaseItem
    {
        public float Weight;
        public float Cost; //In Gold, smaller quantities in decimal places.
        public int Quantity = 1;
        public Boolean IsAmmo;

        [XmlIgnore]
        public Boolean IsMultipleChoice = false; /* Special case. */

        public PlayerItem()
        {
            this.Name = "UNKNOWN";
        }


        public virtual String getDisplayedName()
        {
            String res = Name;
            if(this.Quantity > 1)
            {
                res += "(" + Quantity.ToString() + ")";
            }

            return res;
        }

        public override string ToString()
        {
            String res;

            if (this.Name == "AnyMartialMelee")
            {
                res = "Any Martial Melee Weapon";
                IsMultipleChoice = true;
            }
            else if (this.Name == "AnyMartial")
            {
                res = "Any Martial Weapon";
                IsMultipleChoice = true;
            }
            else if (this.Name == "AnySimple")
            {
                List<PlayerWeapon> wList = CharacterFactory.getAllWeapons();
                res = "Any Simple Weapon";
                IsMultipleChoice = true;
            }
            else if (this.Name == "AnyArtisans")
            {
                res = "Any Artisan's Tool";
                IsMultipleChoice = true;
            }
            else if (this.Name == "AnyMusical")
            {
                List<PlayerToolKit> tools = CharacterFactory.getAllToolSets();
                res = "Any musical instrument";
                IsMultipleChoice = true;
            }
            else if (this.Name == "AnyGaming")
            {
                List<PlayerToolKit> tools = CharacterFactory.getAllToolSets();

                res = "Any gaming set";
                IsMultipleChoice = true;
            }
            else
            {
                res = Name;
                if(Quantity > 1)
                {
                    res += "(" + Quantity.ToString() + ")"; 
                }
            }

            return res;
        }

        public virtual String getExtendedDescription()
        {
            return Description;
        }
    }
}
