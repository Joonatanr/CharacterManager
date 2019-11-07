using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    public class PlayerItem
    {
        public String ItemName;
        public String Description;
        public float Weight;
        public float Cost; //In Gold, smaller quantities in decimal places.
        public int Quantity = 1;
        public Boolean IsAmmo;
        

        public PlayerItem()
        {
            this.ItemName = "UNKNOWN";
        }
    }
}
