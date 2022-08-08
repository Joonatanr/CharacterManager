using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

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
            CASTING_TIME_PERIOD,
        }

        public enum AreaOfEffectType
        {
            AOE_TYPE_NONE,
            AOE_TYPE_CONE,
            AOE_TYPE_SPHERE,
            AOE_TYPE_CUBE,
            AOE_TYPE_LINE
        }
        
        public enum SpellRangeType
        {
            RANGE_TYPE_SELF,
            RANGE_TYPE_TOUCH,
            RANGE_TYPE_RANGED,
            RANGE_TYPE_NONE
        }


        public String SpellName;
        public String Description;
        public String AtHigherLevels;
        public String School;
        public int SpellLevel;
        public int SpellRange;
        public int SpellDuration; /* In turns, 0 means instantaneous effect. */
        public int AoeSize = 0;
        public AreaOfEffectType AoeType = AreaOfEffectType.AOE_TYPE_NONE;
        public SpellRangeType RangeType = SpellRangeType.RANGE_TYPE_NONE;

        public CastingTimeEnum CastingTime;
        public int CastingTimePeriod; /* In number of turns, so 1 minute is 10 turns. */
        public Boolean IsVerbalComponent = false;
        public Boolean IsSomaticComponent = false;
        public Boolean IsMaterialComponent = false;

        public Boolean IsConcentration;

        public String MaterialComponent = "";
       
        [XmlIgnore]
        public string DisplayedName
        {
            get
            {
                return SpellName;
            }
        }

        public int MaterialCost = 0;

        public PlayerSpell()
        {
            this.SpellName = "UNKNOWN";
            this.SpellLevel = 0;
        }

        public static PlayerSpell resolveFromString(string str)
        {
            /* Return a playerspell object from a string. */
            PlayerSpell res = CharacterFactory.getPlayerSpellFromString(str);
            
            if (res == null)
            {
                /* This should normally not happen. */
                res = new PlayerSpell();
                res.SpellName = str;
                res.SpellLevel = 1;
            }

            return res;
        }
    }
}
