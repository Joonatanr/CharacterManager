using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    public abstract class PlayerItem
    {
        public String ItemName;
        public int Weight;
        public float Cost; //In Gold, smaller quantities in decimal places.

        public PlayerItem()
        {
            this.ItemName = "UNKNOWN";
        }
    }
}
