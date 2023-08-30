using CharacterManager.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Spells
{
    public static class GlobalMagicEvents
    {
        /* The idea is that instead of a million callbacks we would have one global instance of a class that handles
         spell casting between different form instances. Lets experiment with this a little. */

        public static DieRollTextBox.RollResultHandler MagicDiceRolledListener = null;
        
        public delegate bool IsSpellSlotWithLevelAvailable(int level);
        public static IsSpellSlotWithLevelAvailable SpellSlotLevelAvailableChecker = null;

        public static void ReportMagicRoll(string rollresult)
        {
            if (MagicDiceRolledListener != null)
            {
                MagicDiceRolledListener.Invoke(rollresult + Environment.NewLine, Color.Blue, true, System.Windows.Forms.HorizontalAlignment.Left);
            }
        }

        public static bool CastSpell(PlayerSpell spell)
        {
            return CastSpell(spell, spell.SpellLevel);
        }

        public static bool CastSpell(PlayerSpell spell, int level)
        {
            if (SpellSlotLevelAvailableChecker != null)
            {
                if (SpellSlotLevelAvailableChecker(level) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
