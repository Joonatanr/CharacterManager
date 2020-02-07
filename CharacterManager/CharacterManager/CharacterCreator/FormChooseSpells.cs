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
            //checkedListBoxCantrips.Items.Clear();
            //checkedListBoxCantrips.DataSource = _myCantripList;
            //checkedListBoxCantrips.DisplayMember = "DisplayedName";

            checkedListBoxLevel1Spells.Items.Clear();
            checkedListBoxLevel1Spells.DataSource = _mySpellList;
            checkedListBoxLevel1Spells.DisplayMember = "DisplayedName";

            //listView1.DataSource = _myCantripList;
            dataGridView1.DataSource = _myCantripList;

            DataGridViewCheckBoxColumn dgvCmb = new DataGridViewCheckBoxColumn();
            dgvCmb.ValueType = typeof(bool);
            dgvCmb.Name = "Chk";
            dgvCmb.HeaderText = "Chosen";
            dgvCmb.FillWeight = 20;
            


            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.FillWeight = 30;
            buttonColumn.Name = "Button Column";
            buttonColumn.Text = "Info";
            buttonColumn.UseColumnTextForButtonValue = true;

            dataGridView1.Columns["DisplayedName"].HeaderText = "Cantrip";
            dataGridView1.Columns["DisplayedName"].FillWeight = 50;
            dataGridView1.Columns.Add(dgvCmb);
            dataGridView1.Columns.Add(buttonColumn);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks that are not on button cells. 
            if (e.RowIndex < 0 || e.ColumnIndex !=
                dataGridView1.Columns["Button Column"].Index) return;

            PlayerSpell selectedSpell = dataGridView1.Rows[e.RowIndex].DataBoundItem as PlayerSpell;

            /* TODO : This is a placeholder. */
            //MessageBox.Show(selectedSpell.Description);

            Spellcard myCard = new Spellcard();
            myCard.setSpell(selectedSpell);
            myCard.ShowDialog();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /* Note to self -> datagridview is a horrible control... */
            /* hmm.... Doing this with datagridview is quite tricky apparently, but we can manage. */
            if(e.ColumnIndex != 1)
            {
                return;
            }
            
            int totalNumberOfCantripsSelected = 0;

            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["Chk"];
                if (cell.Value == cell.TrueValue)
                {
                    totalNumberOfCantripsSelected++;
                }
            }

            if (totalNumberOfCantripsSelected >= NumberOfCantripsToChoose)
            {
                /* Lets just try locking all the rows up for now just to see if this approach even works. */
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells["Chk"];
                    if (cell.Value != cell.TrueValue)
                    {
                        row.ReadOnly = true;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.ReadOnly = false;
                }
            }
        }

        private void checkedListBoxLevel1Spells_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /* This seems to work surprisingly well compared to all the datagridview madness. */
            if (checkedListBoxLevel1Spells.SelectedItem != null)
            {
                Spellcard.ShowSpellCard((PlayerSpell)checkedListBoxLevel1Spells.SelectedItem);
            }
        }
    }
}
