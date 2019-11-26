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
    public class PlayerItem
    {
        public String ItemName;
        public String Description;
        public float Weight;
        public float Cost; //In Gold, smaller quantities in decimal places.
        public int Quantity = 1;
        public Boolean IsAmmo;
        public Boolean IsTool;
        public String ToolType;
        

        public PlayerItem()
        {
            this.ItemName = "UNKNOWN";
        }
    }
}
