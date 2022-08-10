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

        /// <summary>
        /// TODO
        /// </summary>
        /* This is a container class for the spellcasting status, spellslots, known spells, prepared spells, etc. Should be connected to a character.*/
        public CharacterSpellcastingStatus()
        {
            
        }
    }
}
