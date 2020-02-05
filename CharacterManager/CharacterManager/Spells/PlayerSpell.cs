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

        public Boolean IsVerbalComponent = false;
        public Boolean IsSomaticComponent = false;
        public Boolean IsMaterialComponent = false;

        public Boolean IsConcentration;

        public int MaterialCost = 0;

        public PlayerSpell()
        {
            this.SpellName = "UNKNOWN";
            this.SpellLevel = 0;
        }
    }
}
