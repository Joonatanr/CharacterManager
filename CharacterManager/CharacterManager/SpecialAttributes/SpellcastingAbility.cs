using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.SpecialAttributes
{
    [Serializable]
    public class SpellcastingAbility : PlayerAbility
    {
        /* This is basically a container class for the spellcasting ability of a PC. */
        public string SpellCastingAttribute; /* STR, WIS, DEX, CON, CHA or INT */

        public SpellcastingAbility()
        {
            this.AttributeName = "Spellcasting";
            this.IsToggle = false;
        }
    }
}
