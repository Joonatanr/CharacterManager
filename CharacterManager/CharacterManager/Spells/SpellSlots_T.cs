using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.Spells
{
    [Serializable]
    public class SpellSlots_T
    {
        public int NumberOfLev1SpellSlots = 0;
        public int NumberOfLev2SpellSlots = 0;
        public int NumberOfLev3SpellSlots = 0;
        public int NumberOfLev4SpellSlots = 0;
        public int NumberOfLev5SpellSlots = 0;
        public int NumberOfLev6SpellSlots = 0;
        public int NumberOfLev7SpellSlots = 0;
        public int NumberOfLev8SpellSlots = 0;
        public int NumberOfLev9SpellSlots = 0;

        public int getNumberOfSlotsPerLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return NumberOfLev1SpellSlots;
                case 2:
                    return NumberOfLev2SpellSlots;
                case 3:
                    return NumberOfLev3SpellSlots;
                case 4:
                    return NumberOfLev4SpellSlots;
                case 5:
                    return NumberOfLev5SpellSlots;
                case 6:
                    return NumberOfLev6SpellSlots;
                case 7:
                    return NumberOfLev7SpellSlots;
                case 8:
                    return NumberOfLev8SpellSlots;
                case 9:
                    return NumberOfLev9SpellSlots;
                default:
                    return 0;
            }
        }
    }
}
