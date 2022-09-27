using CharacterManager.Items;
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
    public class PlayerSpell : PlayerBaseItem
    {
        
        public enum CastingTimeEnum
        {
            CASTING_TIME_ACTION,
            CASTING_TIME_BONUS_ACTION,
            CASTING_TIME_PERIOD,
            CASTING_TIME_REACTION
        }

        public enum AreaOfEffectType
        {
            AOE_TYPE_NONE,
            AOE_TYPE_CONE,
            AOE_TYPE_SPHERE,
            AOE_TYPE_CUBE,
            AOE_TYPE_LINE,
            AOE_TYPE_SQUARE,
        }
        
        public enum SpellRangeType
        {
            RANGE_TYPE_SELF,
            RANGE_TYPE_TOUCH,
            RANGE_TYPE_RANGED,
            RANGE_TYPE_SIGHT,
            RANGE_TYPE_UNLIMITED,
            RANGE_TYPE_NONE
        }


        public String SpellName;

        public override string ItemName
        {
            get
            {
                return this.SpellName;
            }

            set
            {
                this.SpellName = value;
            }
        }

        public String AtHigherLevels;
        public String School;
        public int SpellLevel;
        public int SpellRange;
        public int SpellDuration; /* In turns, 0 means instantaneous effect. */
        public bool IsUntilDispelled = false;
        public int AoeSize = 0;
        public AreaOfEffectType AoeType = AreaOfEffectType.AOE_TYPE_NONE;
        public SpellRangeType RangeType = SpellRangeType.RANGE_TYPE_NONE;

        public CastingTimeEnum CastingTime;
        public int CastingTimePeriod; /* In number of turns, so 1 minute is 10 turns. */
        public Boolean IsVerbalComponent = false;
        public Boolean IsSomaticComponent = false;
        public Boolean IsMaterialComponent = false;

        public Boolean IsConcentration;
        public Boolean IsRitual = false;

        public String MaterialComponent = "";

        [XmlIgnore]
        public Boolean IsModified = false; /* Used only by the SpellEditor. */
        
        [XmlIgnore]
        public string ListNameForEditor
        {
            get
            {
                if (IsModified)
                {
                    return SpellName + "*";
                }
                else
                {
                    return SpellName;
                }
            }
        }

        public int MaterialCost = 0;

        public PlayerSpell()
        {
            this.SpellName = "UNKNOWN";
            this.SpellLevel = 0;
        }

        public PlayerSpell(string SpellName)
        {
            this.SpellName = SpellName;
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

        public override void ShowDescription()
        {
            Spellcard card = new Spellcard();
            card.setSpell(this);
            card.ShowDialog();
        }
    }
}
