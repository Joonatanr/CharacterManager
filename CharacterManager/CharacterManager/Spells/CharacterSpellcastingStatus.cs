using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Spells
{
    [Serializable]
    public class CharacterSpellcastingStatus
    {
        public List<string> KnownSpells;
        public List<string> PreparedSpells;
        public string SpellCastingAbility;
        public int SpellSaveDC;
        public int SpellAttackBonus;
        public int MaxNumberOfPreparedSpells;
        public int SpellAbilityModifier;

        public class SpellSlotData
        {
            public int MaximumCount;
            public int ActiveCount;


            public SpellSlotData()
            {
                this.MaximumCount = 0;
                this.ActiveCount = 0;
            }

            public SpellSlotData(int max, int active)
            {
                this.MaximumCount = max;
                this.ActiveCount = active;
            }
        }

        public SpellSlotData Level1SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level2SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level3SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level4SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level5SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level6SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level7SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level8SpellSlots = new SpellSlotData(0, 0);
        public SpellSlotData Level9SpellSlots = new SpellSlotData(0, 0);

        /// <summary>
        /// TODO
        /// </summary>
        /* This is a container class for the spellcasting status, spellslots, known spells, prepared spells, etc. Should be connected to a character.*/
        public CharacterSpellcastingStatus()
        {
            
        }

        public void setSpellSlotDataForLevel(int SpellLevel, SpellSlotData data)
        {
            switch (SpellLevel)
            {
                case 1:
                     Level1SpellSlots = data;
                     break;
                case 2:
                     Level2SpellSlots = data;
                    break;
                case 3:
                    Level3SpellSlots = data;
                    break;
                case 4:
                    Level4SpellSlots = data;
                    break;
                case 5:
                    Level5SpellSlots = data;
                    break;
                case 6:
                    Level6SpellSlots = data;
                    break;
                case 7:
                    Level7SpellSlots = data;
                    break;
                case 8:
                    Level8SpellSlots = data;
                    break;
                case 9:
                    Level9SpellSlots = data;
                    break;
                default:
                    break;
            }
        }

        public SpellSlotData getSpellSlotDataForLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return Level1SpellSlots;
                case 2:
                    return Level2SpellSlots;
                case 3:
                    return Level3SpellSlots;
                case 4:
                    return Level4SpellSlots;
                case 5:
                    return Level5SpellSlots;
                case 6:
                    return Level6SpellSlots;
                case 7:
                    return Level7SpellSlots;
                case 8:
                    return Level8SpellSlots;
                case 9:
                    return Level9SpellSlots;
                default: return new SpellSlotData(0, 0);
            }
        }

        public void RechargeAllSpellSlots()
        {
            for(int x = 1; x <= 9; x++)
            {
                SpellSlotData data = getSpellSlotDataForLevel(x);
                data.ActiveCount = data.MaximumCount;
            }
        }
    }
}
