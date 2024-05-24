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
        private int NumberOfSpellsOrCantripsToChoose = 0;

        private bool _isSpellCostDisplayed = false;
        private int _totalCopyCost = 0;

        public bool IsSpellCostDisplayed
        {
            get
            {
                return _isSpellCostDisplayed;
            }

            set
            {
                _isSpellCostDisplayed = value;
                if (_isSpellCostDisplayed)
                {
                    labelCostForCopying.Visible = true;
                    labelCostForCopying.Enabled = true;
                    textBoxCopyCost.Visible = true;
                    textBoxCopyCost.Enabled = true;
                    checkBoxAutoSpendGold.Visible = true;
                    checkBoxAutoSpendGold.Enabled = true;
                }
                else
                {
                    labelCostForCopying.Visible = false;
                    labelCostForCopying.Enabled = false;
                    textBoxCopyCost.Visible = false;
                    textBoxCopyCost.Enabled = false;
                    checkBoxAutoSpendGold.Visible = false;
                    checkBoxAutoSpendGold.Enabled = false;
                }
            }
        }

        public FormChooseSpells()
        {
            InitializeComponent();

            if (_isSpellCostDisplayed)
            {
                labelCostForCopying.Visible = true;
                labelCostForCopying.Enabled = true;
                textBoxCopyCost.Visible = true;
                textBoxCopyCost.Enabled = true;
                checkBoxAutoSpendGold.Visible = true;
                checkBoxAutoSpendGold.Enabled = true;
            }
            else
            {
                labelCostForCopying.Visible = false;
                labelCostForCopying.Enabled = false;
                textBoxCopyCost.Visible = false;
                textBoxCopyCost.Enabled = false;
                checkBoxAutoSpendGold.Visible = false;
                checkBoxAutoSpendGold.Enabled = false;
            }
        }

        public void setSpellChoices(List<PlayerSpell> spells, int numberOfCantripsToChoose, int numberOfSpellsToChoose, int numberOfEitherSpellsOrCantripsToChoose)
        {
            NumberOfCantripsToChoose = numberOfCantripsToChoose;
            NumberOfSpellsToChoose = numberOfSpellsToChoose;

            /* Note that this is a special case. */
            NumberOfSpellsOrCantripsToChoose = numberOfEitherSpellsOrCantripsToChoose;

            _myCantripList = new List<PlayerSpell>();
            _mySpellList = new List<PlayerSpell>();
            
            foreach(PlayerSpell spell in spells)
            {
                if (spell.SpellLevel == 0)
                {
                    _myCantripList.Add(spell);
                }
                else
                {
                    _mySpellList.Add(spell);
                }
            }

            updateVisualControlData();
            updateNumberOfChoices();
        }


        public void setFixedSpells(List<PlayerSpell> spells, int number_of_spells_replaced)
        {
            _myLockedCantripList = new List<PlayerSpell>();
            _myLockedSpellList = new List<PlayerSpell>();

            foreach (PlayerSpell spell in spells)
            {
                if (spell.SpellLevel == 0)
                {
                    _myLockedCantripList.Add(spell);
                }
                else 
                {
                    _myLockedSpellList.Add(spell);
                }
            }

            userControlSpellChoice1.setFixedSpellListList(_myLockedCantripList, 0);
            userControlSpellChoice2.setFixedSpellListList(_myLockedSpellList, number_of_spells_replaced);

            /* TODO : Somehow take into account that sometimes we may be able to replace a number of spells in our fixed spell list. */
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

        public bool IsAllSpellsChosen()
        {
            if (userControlSpellChoice1.RemainingAvailableChoices > 0 || userControlSpellChoice2.RemainingAvailableChoices > 0)
            {
                return false;
            }

            return true;
        }

        private void updateNumberOfChoices()
        {
            if (NumberOfSpellsOrCantripsToChoose > 0)
            {
                /* Special case. */
                userControlSpellChoice1.MaximumAvailableChoices = NumberOfSpellsOrCantripsToChoose;
                userControlSpellChoice2.MaximumAvailableChoices = NumberOfSpellsOrCantripsToChoose;
            }
            else 
            {
                userControlSpellChoice1.MaximumAvailableChoices = NumberOfCantripsToChoose;
                userControlSpellChoice2.MaximumAvailableChoices = NumberOfSpellsToChoose;

                /* We lock the choices here if the number of available choices are 0. */
                if (NumberOfCantripsToChoose == 0)
                {
                    userControlSpellChoice1.setSelectionsLocked(true);
                }

                if (NumberOfSpellsToChoose == 0)
                {
                    userControlSpellChoice2.setSelectionsLocked(true);
                }
            }
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

            List<PlayerSpell> newSpells = new List<PlayerSpell>();
            foreach(PlayerSpell spell in selectedSpells)
            {
                if (!_myLockedSpellList.Contains(spell))
                {
                    newSpells.Add(spell);
                }
            }

            _totalCopyCost = GlobalEvents.getTotalCostOfCopyingSpells(newSpells);
            textBoxCopyCost.Text = _totalCopyCost.ToString();
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (_isSpellCostDisplayed)
            {
                /* Special case. */
                /* First we try to pay the cost if applicable. */
                if (checkBoxAutoSpendGold.Checked)
                {
                    if (GlobalEvents.SpendGoldGlobal(_totalCopyCost) == false)
                    {
                        if (MessageBox.Show("Not enough gold. Ignore cost?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            // user clicked no
                        }
                    }
                    else
                    {
                        /* Gold has been spent.*/
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                if (userControlSpellChoice1.RemainingAvailableChoices > 0 || userControlSpellChoice2.RemainingAvailableChoices > 0)
                {
                    MessageBox.Show("Not all spells have been selected!");
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void userControlSpellChoice1_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            if (NumberOfSpellsOrCantripsToChoose > 0)
            {
                /* TODO : Special case. */
               userControlSpellChoice2.MaximumAvailableChoices = userControlSpellChoice1.RemainingAvailableChoices;
            }
            
            updateSelectedSpellData();
        }

        private void userControlSpellChoice2_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            if (NumberOfSpellsOrCantripsToChoose > 0)
            {
                /* TODO : Special case */
                userControlSpellChoice1.MaximumAvailableChoices = userControlSpellChoice2.RemainingAvailableChoices;
            }

            updateSelectedSpellData();
        }

        private void FormChooseSpells_Load(object sender, EventArgs e)
        {

        }
    }
}
