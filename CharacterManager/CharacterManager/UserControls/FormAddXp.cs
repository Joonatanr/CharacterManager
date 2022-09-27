using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class FormAddXp : Form
    {
        public int CurrentXp
        {
            set
            {
                numericUpDown1.Value = value;
                if (getLevelThreshold(_myLevel + 1) <= value)
                {
                    /* We are going to level up, but we will not do it on this form. */
                    CurrentLevel = _myLevel + 1;
                }
                updateCounters();
            }

            get
            {
                return (int)numericUpDown1.Value;
            }
        }

        private int _myLevel;

        public int CurrentLevel
        {
            set
            {
                _myLevel = value;
                labelCurrentLevel.Text = _myLevel.ToString();
                if(CurrentXp < getLevelThreshold(_myLevel))
                {
                    CurrentXp = getLevelThreshold(_myLevel);
                }
                updateCounters();
            }

            get
            {
                return _myLevel;
            }
        }


        public static readonly int[] LevelThresholds = 
        { 
            0,      /* Level 1  */
            300,    /* Level 2  */
            900,    /* Level 3  */
            2700,   /* Level 4  */
            6500,   /* Level 5  */

            14000,  /* Level 6  */
            23000,  /* Level 7  */
            34000,  /* Level 8  */
            48000,  /* Level 9  */
            64000,  /* Level 10 */

            85000,  /* Level 11 */
            100000, /* Level 12 */
            120000, /* Level 13 */
            140000, /* Level 14 */
            165000, /* Level 15 */

            195000, /* Level 16 */
            225000, /* Level 17 */
            265000, /* Level 18 */
            305000, /* Level 19 */
            355000, /* Level 20 */
        };

        public FormAddXp()
        {
            InitializeComponent();
        }


        private int getLevelThreshold(int level)
        {
            if(level < 1 || level > 20)
            {
                return 0;
            }

            return LevelThresholds[level - 1];
        }

        private void updateCounters()
        {
            int nextLevelAt = getLevelThreshold(_myLevel + 1);
            labelNextLevelAt.Text = nextLevelAt.ToString();

            int remainingXp = getLevelThreshold(_myLevel + 1) - CurrentXp;
            labelXpRemaining.Text = remainingXp.ToString();
        }

        private void AddXpAmount()
        {
            int amountToBeAdded;

            if (int.TryParse(textBoxAmountAdd.Text.ToString(), out amountToBeAdded))
            {
                numericUpDown1.Value += amountToBeAdded;
                CurrentXp = (int)numericUpDown1.Value;
            }
            else
            {
                MessageBox.Show("Incorrect amount : " + textBoxAmountAdd.Text.ToString());
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddXpAmount();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CurrentXp = (int)numericUpDown1.Value;
        }

        private void textBoxAmountAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                AddXpAmount();
            }
        }
    }
}
