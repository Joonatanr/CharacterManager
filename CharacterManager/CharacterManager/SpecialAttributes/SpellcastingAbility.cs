using CharacterManager.Spells;
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

        public int[] NewSpellsLearnedAtLevelup = new int[20];
        public int[] NewCantripsLearnedAtLevelup = new int[20];
        public int[] SpellsReplacedAtLevelup = new int[20];
        public List<String> AvailableSpells = new List<String>();

        public SpellSlots_T[] SpellslotPerLevel = new SpellSlots_T[20]
        {
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
        };

        public enum SpellPreparationType
        {
            PREPARATION_NONE,   //No spell preparation is required, all spells are available all the time.
            PREPARATION_HALF,   //Maximum number of prepared spells is spellcasting modifier + playerlevel/2.  (minimum 1)
            PREPARATION_FULL    //Maximum number of prepared spells is spellcasting modifer + playerlevel.     (minimum 1)
        }

        public SpellPreparationType SpellPreparation = SpellPreparationType.PREPARATION_NONE;

        /* Some classes, like the paladin and cleric do not learn spells, but they have their whole spell list always available. */
        public bool IsAllSpellsAvailable = false;

        public SpellcastingAbility()
        {
            this.Name = "Spellcasting";
            this.IsToggle = false;
        }

        public List<PlayerSpell> GetSpellsThatCanBeLearnedAtLevel(int playerLevel)
        {
            List<PlayerSpell> res = new List<PlayerSpell>();

            int MaxLevelSpellSlot = 0;
            SpellSlots_T slots = SpellslotPerLevel[playerLevel - 1];
            for (int x = 0; x <= 9; x++)
            {
                if (slots.getNumberOfSlotsPerLevel(x) > 0)
                {
                    MaxLevelSpellSlot = Math.Max(MaxLevelSpellSlot, x);
                }
            }

            for (int x = 0; x <= MaxLevelSpellSlot; x++)
            {
                List<PlayerSpell> spellsOfLevel = GetAvailableSpells(x);
                res.AddRange(spellsOfLevel);
            }

            return res;
        }

        public List<BonusValueModifier> GetMaximumNumberOfPreparedSpells(int spellcasting_ability_modifier, int level)
        {
            List<BonusValueModifier> res = new List<BonusValueModifier>();
            int total = 0;

            switch (SpellPreparation) 
            {
                case SpellPreparationType.PREPARATION_NONE:
                    /* Special case, all are allowed. */
                    res.Add(new BonusValueModifier("No preparation needed", 0));
                    break;
                case SpellPreparationType.PREPARATION_HALF:
                    res.Add(new BonusValueModifier("Ability modifier", spellcasting_ability_modifier));
                    res.Add(new BonusValueModifier("Level / 2", level / 2));

                    total = 0;
                    foreach (BonusValueModifier mod in res)
                    {
                        total += mod.modifierValue;
                    }

                    if(total == 0)
                    {
                        /* Minimum of one spell can be prepared */
                        res.Add(new BonusValueModifier("Minimum of 1", 1));
                    }
                     
                    break;

                case SpellPreparationType.PREPARATION_FULL:
                    res.Add(new BonusValueModifier("Ability modifier", spellcasting_ability_modifier));
                    res.Add(new BonusValueModifier("Level", level));

                    total = 0;
                    foreach (BonusValueModifier mod in res)
                    {
                        total += mod.modifierValue;
                    }

                    if (total == 0)
                    {
                        /* Minimum of one spell can be prepared */
                        res.Add(new BonusValueModifier("Minimum of 1", 1));
                    }

                    break;
                default:
                    return null;
            }

            return res;
        }

        public int GetNewSpellsLearnedAtLevel(int PlayerLevel)
        {
            if(PlayerLevel <= 0)
            {
                return 0;
            }

            if(PlayerLevel > 20)
            {
                return 0;
            }

            return NewSpellsLearnedAtLevelup[PlayerLevel - 1];
        }

        public int GetNewCantripsLearnedAtLevel(int PlayerLevel)
        {
            if (PlayerLevel <= 0)
            {
                return 0;
            }

            if (PlayerLevel > 20)
            {
                return 0;
            }

            return NewCantripsLearnedAtLevelup[PlayerLevel - 1];
        }

        public SpellSlots_T getSpellSlotDataForLevel(int PlayerLevel)
        {
            if (PlayerLevel < 1 || PlayerLevel > 20)
            {
                return null;
            }

            return SpellslotPerLevel[PlayerLevel - 1];
        }

        public List<PlayerSpell> GetAvailableSpells(int SpellLevel)
        {
            List<PlayerSpell> res = new List<PlayerSpell>();

            foreach (string s in AvailableSpells)
            {
                PlayerSpell sp = PlayerSpell.resolveFromString(s);
                if (sp.SpellLevel == SpellLevel)
                {
                    res.Add(sp);
                }
            }

            return res;
        }
    }
}
