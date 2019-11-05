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
        public int ArmorClass;

        public override string ToString()
        {
            return "Name : " + this.ItemName + "AC : " + this.ArmorClass.ToString();
        }
    }
}
