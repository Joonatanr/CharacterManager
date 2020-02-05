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
        
        public enum CastingTimeEnum
        {
            CASTING_TIME_ACTION,
            CASTING_TIME_BONUS_ACTION,
            CASTING_TIME_PERIOD
        }
        
        public String SpellName;
        public String Description;
        public String School;
        public int SpellLevel;
        public int SpellRange;
        public int SpellDuration; /* In turns, 0 means instantaneous effect. */

        public CastingTimeEnum CastingTime;
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
