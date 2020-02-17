using CharacterManager.Spells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.CharacterCreator
{
    public partial class FormChooseSpells : Form
    {
        private List<PlayerSpell> _myCantripList = new List<PlayerSpell>(); /* Cantrips go here. */
        private List<PlayerSpell> _mySpellList = new List<PlayerSpell>();   /* Level 1 spells go here, no higher level spells right now... This is probably major TODO. */
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

        private void updateNumberOfChoices()
        {
            labelNumberOfCantripsToChoose.Text = NumberOfCantripsToChoose.ToString();
        }

        private void updateVisualControlData()
        {
            /* TODO */
            userControlSpellChoice1.SpellList = _myCantripList;
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
    }
}
