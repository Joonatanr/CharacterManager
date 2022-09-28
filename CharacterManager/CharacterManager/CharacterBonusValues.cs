using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    /* All bonuses that are determined by special abilities should be defined here. */
    public class CharacterBonusValues
    {
        public List<BonusValueModifier> AcBonusModifiers = new List<BonusValueModifier>();
        public List<BonusValueModifier> AttackRollBonusModifiers = new List<BonusValueModifier>();
        public List<BonusValueModifier> AttackDamageBonusModifiers = new List<BonusValueModifier>();

        public List<BonusValueModifier> SpeedModifiers = new List<BonusValueModifier>();

        public string AttackNoteString = string.Empty;
        public List<int> ExtraCritValues = new List<int>();

        /* Values that might be accessed during levelup. */
        public List<BonusValueModifier> HitPointLevelupModifiers = new List<BonusValueModifier>();

        public int AttackRollBonus
        {
            get
            {
                return getModifierTotalValue(AttackRollBonusModifiers);
            }
        }

        public int AttackDamageBonus
        {
            get
            {
                return getModifierTotalValue(AttackDamageBonusModifiers);
            }
        }

        public int AcBonus
        {
            get
            {
                return getModifierTotalValue(AcBonusModifiers);
            }
        }


        private int getModifierTotalValue(List<BonusValueModifier> modList)
        {
            int res = 0;

            foreach (BonusValueModifier mod in modList)
            {
                res += mod.modifierValue;
            }

            return res;
        }

        public CharacterBonusValues()
        {

        }

        internal void ResetAttackModifiers()
        {
            AttackNoteString = "";
            AttackRollBonusModifiers = new List<BonusValueModifier>();
            AttackDamageBonusModifiers = new List<BonusValueModifier>();
        }

        internal void ResetLevelUpModifiers()
        {
            HitPointLevelupModifiers = new List<BonusValueModifier>();
        }
    }
}
