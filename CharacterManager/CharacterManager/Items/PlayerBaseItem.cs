using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Items
{
    
    /* Idea is that this should be the topmost class of any spell, maneuver, even weapon, armor, and other item. 
     Basically it just contains  a displayed name and a Description */

    public abstract class PlayerBaseItem
    {
        public virtual string Description { get; set; }
        public virtual string ItemName { get; set; }
    }
}
