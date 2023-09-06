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

        public override string Name
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
        public Boolean IsAttackRoll = false;

        public String MaterialComponent = "";

        public string DiceAtLevel0 = "";
        public string DiceAtLevel1 = "";
        public string DiceAtLevel2 = "";
        public string DiceAtLevel3 = "";
        public string DiceAtLevel4 = "";
        public string DiceAtLevel5 = "";
        public string DiceAtLevel6 = "";
        public string DiceAtLevel7 = "";
        public string DiceAtLevel8 = "";
        public string DiceAtLevel9 = "";
        public bool IsSpellCastingModifierAddedToDice = false;

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

        private string getDiceForLevel(int spellLevel)
        {
            /* Const size arrays really are a pain in C# for some reason...*/
            switch (spellLevel)
            {
                case (0):
                    return DiceAtLevel0;
                case (1):
                    return DiceAtLevel1;
                case (2):
                    return DiceAtLevel2;
                case (3):
                    return DiceAtLevel3;
                case (4):
                    return DiceAtLevel4;
                case (5):
                    return DiceAtLevel5;
                case (6):
                    return DiceAtLevel6;
                case (7):
                    return DiceAtLevel7;
                case (8):
                    return DiceAtLevel8;
                case (9):
                    return DiceAtLevel9;
            }

            return null;
        }

        public List<DieRollComponent> getDiceForSpellLevel(int level)
        {
            string dice = "";
            string str;

            for (int x = 0; x <= level; x++)
            {
                str = getDiceForLevel(x);
                if (!string.IsNullOrEmpty(str))
                {
                    dice = str;
                }
            }

            if (string.IsNullOrEmpty(dice))
            {
                return null;
            }
            else
            {
                try
                {
                    List<DieRollComponent> res = DieRollEquation.parseComponentListFromString(dice);
                    return res;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string[] getDiceAsArray()
        {
            string[] res = new string[10];

            res[0] = DiceAtLevel0;
            res[1] = DiceAtLevel1;
            res[2] = DiceAtLevel2;
            res[3] = DiceAtLevel3;
            res[4] = DiceAtLevel4;
            res[5] = DiceAtLevel5;
            res[6] = DiceAtLevel6;
            res[7] = DiceAtLevel7;
            res[8] = DiceAtLevel8;
            res[9] = DiceAtLevel9;

            return res;
        }

        public override void ShowDescription(object [] args)
        {
            Spellcard card = new Spellcard();
            
            if(args.Length > 0)
            {
                if(args[0] is bool)
                {
                    card.IsCastingInfoVisible = (bool)args[0];
                }
            }
            
            card.setSpell(this);
            card.Show();
        }
    }
}
