using CharacterManager.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Spells
{
    public static class GlobalEvents
    {
        /* The idea is that instead of a million callbacks we would have one global instance of a class that handles
         spell casting between different form instances. Lets experiment with this a little. */

        public static DieRollTextBox.RollResultHandler MagicDiceRolledListener = null;
        
        public delegate bool IsSpellSlotWithLevelAvailable(int level);
        public static IsSpellSlotWithLevelAvailable SpellSlotLevelAvailableChecker = null;

        public delegate void SpendSpellSlotListener(PlayerSpell spell, int level);
        public static SpendSpellSlotListener CastSpellExternal = null;

        public delegate PlayerCharacter GetSpellCasterDataDelegate();
        public static GetSpellCasterDataDelegate GetActiveCharacterExternal;

        public static void ReportMagicRoll(string rollresult)
        {
            if (MagicDiceRolledListener != null)
            {
                MagicDiceRolledListener.Invoke(rollresult + Environment.NewLine, Color.Blue, false, System.Windows.Forms.HorizontalAlignment.Left);
            }
        }

        public static int GetSpellAttackBonus()
        {
            if (GetActiveCharacterExternal == null)
            {
                return 0;
            }
            else
            {
                PlayerCharacter c = GetActiveCharacterExternal();
                return c.CharacterSpellCastingStatus.SpellAttackBonus;
            }
        }

        public static int GetSpellcastingAbilityModifier()
        {
            if (GetActiveCharacterExternal == null)
            {
                return 0;
            }
            else
            {
                PlayerCharacter c = GetActiveCharacterExternal();
                
                if (c == null)
                {
                    return 0;
                }

                return c.CharacterSpellCastingStatus.SpellAbilityModifier;
            }
        }

        public static bool CastSpell(PlayerSpell spell)
        {
            return CastSpell(spell, spell.SpellLevel);
        }

        public static bool CastSpell(PlayerSpell spell, int level)
        {
            if(spell.SpellLevel == 0)
            {
                CastSpellExternal.Invoke(spell, 0);
                return true;
            }
            
            if (SpellSlotLevelAvailableChecker != null)
            {
                if (SpellSlotLevelAvailableChecker(level) == true)
                {
                    if (CastSpellExternal != null)
                    {
                        CastSpellExternal.Invoke(spell, level);
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static int GetSpellCasterLevel()
        {
            if (GetActiveCharacterExternal == null)
            {
                return 0;
            }
            else
            {
                PlayerCharacter c = GetActiveCharacterExternal();
                
                if(c == null)
                {
                    return 0;
                }
                
                return c.Level;
            }

            return 0;
        }
    }
}
