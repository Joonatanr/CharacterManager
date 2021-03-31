using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Spells;

namespace CharacterManager.CharacterCreator
{
    public partial class FormChooseSpells : Form
    {
        private List<PlayerSpell> _myCantripList = new List<PlayerSpell>(); /* Cantrips go here. */
        private List<PlayerSpell> _mySpellList = new List<PlayerSpell>();   /* Level 1 spells go here, no higher level spells right now... This is probably major TODO. */

        private List<PlayerSpell> _myLockedCantripList = new List<PlayerSpell>(); //These are cantrips that are derived from race or background etc.
        private List<PlayerSpell> _myLockedSpellList = new List<PlayerSpell>();
        
        private PlayerClass _selectedClass;

        private int NumberOfCantripsToChoose = 0;
        private int NumberOfSpellsToChoose = 0;

        public FormChooseSpells()
        {
            InitializeComponent();
        }

        public void setSpellChoices(PlayerClass c)
        {
            //setSpellChoices(c.AvailableSpells);
            if (_selectedClass != c)
            {
                _selectedClass = c;
                NumberOfCantripsToChoose = c.SpellCasting.NumberOfInitialCantrips;
                NumberOfSpellsToChoose = c.SpellCasting.NumberOfInitialLev1Spells;
                updateNumberOfChoices();
                setSpellChoices(c.GetAvailableSpells());
            }
        }

        public void setSpellChoices(List<PlayerSpell> spells)
        {
            _myCantripList = new List<PlayerSpell>();
            _mySpellList = new List<PlayerSpell>();
            
            foreach(PlayerSpell spell in spells)
            {
                if (spell.SpellLevel == 0)
                {
                    _myCantripList.Add(spell);
                }
                else if(spell.SpellLevel == 1)
                {
                    _mySpellList.Add(spell);
                }
                else
                {
                    /* TODO For the future. */
                }
            }

            updateVisualControlData();
        }


        public void setFixedSpells(List<PlayerSpell> spells)
        {
            _myLockedCantripList = new List<PlayerSpell>();
            _myLockedSpellList = new List<PlayerSpell>();

            foreach (PlayerSpell spell in spells)
            {
                if (spell.SpellLevel == 0)
                {
                    _myLockedCantripList.Add(spell);
                }
                else if (spell.SpellLevel == 1)
                {
                    _myLockedSpellList.Add(spell);
                }
                else
                {
                    /* TODO For the future. */
                }
            }

            userControlSpellChoice1.setFixedSpellListList(_myLockedCantripList);
            userControlSpellChoice2.setFixedSpellListList(_myLockedSpellList);
        }

        private void updateNumberOfChoices()
        {
            labelNumberOfCantripsToChoose.Text = NumberOfCantripsToChoose.ToString();
        }

        private void updateVisualControlData()
        {
            /* TODO */
            userControlSpellChoice1.setSpellList(_myCantripList);
            userControlSpellChoice2.setSpellList(_mySpellList);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void userControlSpellChoice1_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            /* TODO : This is a placeholder. */
            if (isChosen)
            {
                NumberOfCantripsToChoose--;

                if (NumberOfCantripsToChoose == 0)
                {
                    //We lock the ability to choose more cantrips...
                    userControlSpellChoice1.setSelectionsLocked(true);
                }
            }
            else
            {
                NumberOfCantripsToChoose++;
                if (NumberOfCantripsToChoose == 1)
                {
                    //We unlock the ability to choose more cantrips.
                    userControlSpellChoice1.setSelectionsLocked(false);
                }
            }

            labelNumberOfCantripsToChoose.Text = NumberOfCantripsToChoose.ToString();
        }
    }
}
