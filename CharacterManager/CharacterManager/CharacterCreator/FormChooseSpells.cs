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
        

        private int NumberOfCantripsToChoose = 0;
        private int NumberOfSpellsToChoose = 0;

        public FormChooseSpells()
        {
            InitializeComponent();
        }

        public void setSpellChoices(List<PlayerSpell> spells, int numberOfCantripsToChoose, int numberOfSpellsToChoose)
        {
            NumberOfCantripsToChoose = numberOfCantripsToChoose;
            NumberOfSpellsToChoose = numberOfSpellsToChoose;

            updateNumberOfChoices();

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

        public List<PlayerSpell> getChosenPlayerSpells()
        {
            List<PlayerSpell> res = new List<PlayerSpell>();

            List<PlayerSpell> cantrips = userControlSpellChoice1.getSelectedSpells();
            List<PlayerSpell> level1spells = userControlSpellChoice2.getSelectedSpells();

            res.AddRange(cantrips);
            res.AddRange(level1spells);

            return res;
        }

        private void updateNumberOfChoices()
        {
            userControlSpellChoice1.MaximumAvailableChoices = NumberOfCantripsToChoose;
            userControlSpellChoice2.MaximumAvailableChoices = NumberOfSpellsToChoose;
        }

        private void updateVisualControlData()
        {
            userControlSpellChoice1.setSpellList(_myCantripList);
            userControlSpellChoice2.setSpellList(_mySpellList);

            updateSelectedSpellData();
        }

        private void updateSelectedSpellData()
        {
            List<PlayerSpell> cantrips = userControlSpellChoice1.getSelectedSpells();
            List<PlayerSpell> level1spells = userControlSpellChoice2.getSelectedSpells();

            List<PlayerSpell> selectedSpells = new List<PlayerSpell>();
            selectedSpells.AddRange(cantrips);
            selectedSpells.AddRange(level1spells);

            userControlChosenSpells.setSpellList(selectedSpells);
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (userControlSpellChoice1.MaximumAvailableChoices > 0 || userControlSpellChoice2.MaximumAvailableChoices > 0)
            {
                MessageBox.Show("Not all spells have been selected!");
            }
            
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
            updateSelectedSpellData();
        }

        private void userControlSpellChoice2_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            updateSelectedSpellData();
        }

        private void FormChooseSpells_Load(object sender, EventArgs e)
        {

        }
    }
}
