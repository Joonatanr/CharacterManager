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
        /* This is basically a container class for the spellcasting ability of a player class. */
        public string SpellCastingAttribute; /* STR, WIS, DEX, CON, CHA or INT */
        public int NumberOfInitialCantrips = 0;
        public int NumberOfInitialLev1Spells = 0;

        public enum SpellPreparationType
        {
            PREPARATION_NONE,   //No spell preparation is required, all spells are available all the time.
            PREPARATION_HALF,   //Maximum number of prepared spells is spellcasting modifier + playerlevel/2.  (minimum 1)
            PREPARATION_FULL    //Maximum number of prepared spells is spellcasting modifer + playerlevel.     (minimum 1)
        }

        public SpellPreparationType SpellPreparation = SpellPreparationType.PREPARATION_NONE;

        public SpellcastingAbility()
        {
            this.AttributeName = "Spellcasting";
            this.IsToggle = false;
        }

        public int GetMaximumNumberOfPreparedSpells(int spellcasting_ability_modifier, int level)
        {
            switch (SpellPreparation) 
            {
                case SpellPreparationType.PREPARATION_NONE:
                    return 0; /* Special case, all are allowed. */
                case SpellPreparationType.PREPARATION_HALF:
                    return (Math.Max(1, spellcasting_ability_modifier + (level / 2)));
                case SpellPreparationType.PREPARATION_FULL:
                    return (Math.Max(1, spellcasting_ability_modifier + level));
                default:
                    return -1;
            }
        }
    }
}
