using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Spells
{
    
    /* Lets do some magic. :) */
    [Serializable]
    public class PlayerSpell
    {
        public String SpellName;
        public String Description;
        public int SpellLevel;

        public PlayerSpell()
        {
            this.SpellName = "UNKNOWN";
            this.SpellLevel = 0;
        }
    }
}
