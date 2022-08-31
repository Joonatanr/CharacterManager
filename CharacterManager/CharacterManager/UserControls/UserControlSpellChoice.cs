using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using CharacterManager.Spells;

namespace CharacterManager.UserControls
{
    public class UserControlSpellChoice : UserControlBaseChoice<PlayerSpell>
    {        

        /* TODO : Reimplement this property. */
        public bool IsMultipleLevel { get; set; } = false;


        /* Keeping this delegate to preserve the API */
        public delegate void SpellChoiceChangedListener(PlayerSpell Spell, bool isChosen);
        public event SpellChoiceChangedListener SpellSelectionChanged;

        /* Keeping these public functions to keep external API mostly intact. */
        public void setSpellList(List<PlayerSpell> spells)
        {
            setItemList(spells);
        }

     
        /* We add a fixed spell to the list that is always selected. */
        public void setFixedSpellListList(List<PlayerSpell> spellList)
        {
            setFixedItemList(spellList);
        }


        public bool removeSpellFromList(PlayerSpell spell)
        {
            return removeItemFromList(spell);
        }

        public List<PlayerSpell> getSelectedSpells()
        {
            return getSelectedItems();
        }

        
        internal void setSpellSelection(string spell, bool isSelected)
        {
            setItemSelection(spell, isSelected);
        }

        public UserControlSpellChoice() : base()
        {
            ItemSelectionChanged += new ItemChoiceChangedListener(SpellSelectionChangedHandler);
        }

        private void SpellSelectionChangedHandler(PlayerSpell spell, bool isChosen)
        {
            if(SpellSelectionChanged != null)
            {
                SpellSelectionChanged.Invoke(spell, isChosen);
            }
        }
    }
}
