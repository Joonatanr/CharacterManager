using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    public class PlayerAbilityInfoItem : PlayerBaseItem
    {
        public bool IsUsable = false;
        
        public PlayerAbilityInfoItem(string name)
        {
            this.Name = name;
        }
    }
}
