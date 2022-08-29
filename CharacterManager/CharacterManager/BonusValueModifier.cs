using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    public class BonusValueModifier
    {
        public string modifierName; // Ala something like "Rage Bonus", "Defense fighting style" etc.
        
        public int modifierValue
        {
            get
            {
                string logString;
                /* Note that if the modifier is a dieroll then this getter will return a randomly rolled value...*/
                /* Should not really use this access function in case the modifier is a die. */
                return modifierDieRoll.getValue(out logString);
            }

            set
            {
                modifierDieRoll = new DieRollConstant(value);
            }
        }

        public DieRollComponent modifierDieRoll = new DieRollConstant(0);

        public BonusValueModifier()
        {
            modifierName = "";
            modifierValue = 0;
        }

        public BonusValueModifier(string desc, int value)
        {
            modifierName = desc;
            modifierValue = value;
        }

        public BonusValueModifier(string desc, string dieRoll)
        {
            modifierName = desc;
            modifierDieRoll = DieRoll.parseFromString(dieRoll);
        }

        public string getBonusValueString()
        {
            return modifierDieRoll.ToString();
        }

        public static string getToolTipStringFromList(List<BonusValueModifier> bonusValueList)
        {
            string modifierString = "";
            if (bonusValueList != null)
            {
                if (bonusValueList.Count > 0)
                {
                    foreach (BonusValueModifier mod in bonusValueList)
                    {
                        string modString = mod.getBonusValueString();
                        modString += " - " + mod.modifierName;
                        modifierString += modString;
                        modifierString += Environment.NewLine;
                    }
                }
            }

            return modifierString;
        }

        public static string getStringFromList(List<BonusValueModifier> bonusValueList)
        {
            string modifierString = "";
            if (bonusValueList != null)
            {
                if (bonusValueList.Count > 0)
                {
                    bool isFirst = true;
                    foreach (BonusValueModifier mod in bonusValueList)
                    {
                        if (isFirst)
                        {
                            modifierString += mod.getBonusValueString() + " ";
                        }
                        else
                        {
                            if (mod.modifierDieRoll is DieRollConstant)
                            {
                                if (mod.modifierValue >= 0)
                                {
                                    modifierString += "+ ";
                                }
                                modifierString += mod.getBonusValueString() + " ";
                            }else if(mod.modifierDieRoll is DieRoll)
                            {
                                modifierString += "+ ";
                                modifierString += mod.getBonusValueString() + " ";
                            }
                        }

                        isFirst = false;
                    }
                }
            }

            return modifierString;
        }
    };
}
