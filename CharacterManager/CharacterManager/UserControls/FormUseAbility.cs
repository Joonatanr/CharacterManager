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
    public partial class FormUseAbility : Form
    {
        private PlayerAbility _myAbility;
        
        public PlayerAbility Ability
        {
            get
            {
                return _myAbility;
            }
            set
            {
                _myAbility = value;
                labelAbilityName.Text = _myAbility.AttributeName;
                customRTBDescription.Text = _myAbility.Description;
            }
        }
        
        
        public string Description
        {
            get
            {
                return customRTBDescription.Text;
            }
            set
            {
                customRTBDescription.Text = value;
            }
        }

        public string AbilityName
        {
            get
            {
                return labelAbilityName.Text;
            }

            set
            {
                labelAbilityName.Text = value;
            }
        }

        private List<BonusValueModifier> _myRollModifiers = null;

        public List<BonusValueModifier> DieRollModifiers
        {
            get
            {
                return _myRollModifiers;
            }
            set
            {
                _myRollModifiers = value;
                updateDieRollValue();

            }
        }

        public int RollResult = 0;


        public FormUseAbility()
        {
            InitializeComponent();
        }

        private void updateDieRollValue()
        {
            if(_myRollModifiers == null)
            {
                dieRollTextBox1.DieRollObject = null;
            }
            else
            {
                /* TODO : Should also set up a tooltip. */
                //dieRollTextBox1.Text = BonusValueModifier.getStringFromList(_myRollModifiers);
                List<DieRollComponent> components = new List<DieRollComponent>();
                foreach(BonusValueModifier mod in _myRollModifiers)
                {
                    components.Add(mod.modifierDieRoll);
                }
                DieRollEquation rollValue = new DieRollEquation(components);

                dieRollTextBox1.DieRollObject = rollValue;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            /* TODO : Lets validate the result before. */
            /* TODO : Maybe we do not need a result sometimes??? Should take this into account with a property. */
            int result;
            if(int.TryParse(textBoxResult.Text, out result))
            {
                this.RollResult = result;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid roll result of " + textBoxResult.Text);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            string rollString;
            textBoxResult.Text = dieRollTextBox1.Roll(out rollString).ToString();
            customRTBLog.AppendText(rollString + Environment.NewLine);
        }
    }
}
