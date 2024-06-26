﻿using CharacterManager.UserControls;
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
        public static DieRollTextBox.RollResultHandler GlobalRollListener = null;
        
        public delegate bool IsSpellSlotWithLevelAvailable(int level);
        public static IsSpellSlotWithLevelAvailable SpellSlotLevelAvailableChecker = null;

        public delegate void SpendSpellSlotListener(PlayerSpell spell, int level);
        public static SpendSpellSlotListener CastSpellExternal = null;

        public delegate PlayerCharacter GetSpellCasterDataDelegate();
        public static GetSpellCasterDataDelegate GetActiveCharacterExternal;

        public static void ReportMagicRoll(string rollresult)
        {
            if (GlobalRollListener != null)
            {
                GlobalRollListener.Invoke(rollresult + Environment.NewLine, Color.Blue, false, System.Windows.Forms.HorizontalAlignment.Left);
            }
        }

        public static void ReportRollGlobal(string rollresult, Color c, bool isBold)
        {
            if(GlobalRollListener!= null)
            {
                GlobalRollListener.Invoke(rollresult + Environment.NewLine, c, isBold, System.Windows.Forms.HorizontalAlignment.Left);
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

        public static List<BonusValueModifier> GetExtraDieRollModifiersForSpell(PlayerSpell spell, int level)
        {
            if (GetActiveCharacterExternal == null)
            {
                return null;
            }
            else
            {
                PlayerCharacter c = GetActiveCharacterExternal();
                return c.GetExtraDieRollModifiersForSpell(spell, level);
            }
        }

        public static int getTotalCostOfCopyingSpells(List<PlayerSpell> spells)
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

                return c.GetCostForCopyingSpells(spells);
            }
        }

        public static bool SpendGoldGlobal(double amount)
        {
            if (GetActiveCharacterExternal == null)
            {
                return false;
            }
            else
            {
                PlayerCharacter c = GetActiveCharacterExternal();

                if (c == null)
                {
                    return false;
                }

                return c.SpendGold(amount);
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

        public static List<DieRollComponent> GetBaseDiceForSpell(PlayerSpell spell, int level)
        {
            PlayerCharacter c = GetActiveCharacterExternal();
            if (c == null)
            {
                return spell.getDiceForSpellLevel(level);
            }
            else
            {
                /* Here we handle possible cases where this might be overridden by player attributes/abilities etc. */
                return c.GetBaseDiceForSpell(spell, level);
            }
        }
    }
}
