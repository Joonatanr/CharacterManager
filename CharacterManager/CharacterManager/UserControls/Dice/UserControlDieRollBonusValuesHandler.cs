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
    public partial class UserControlDieRollBonusValuesHandler : UserControl
    {
        public string UserControlName
        {
            get
            {
                return labelControlName.Text;
            }

            set
            {
                labelControlName.Text = value;
            }
        }

        private List<BonusValueModifier> _modifiers;

        public List<BonusValueModifier> Modifiers
        {
            get
            {
                return _modifiers;
            }

            set
            {
                _modifiers = value;
                updateModifiers();
            }
        }

        public delegate void logRoll(string str, object sender);
        public logRoll rollListener;

        public UserControlDieRollBonusValuesHandler()
        {
            InitializeComponent();
        }

        public void updateModifiers()
        {
            textBoxRollMods.Text = BonusValueModifier.getStringFromList(_modifiers);
            toolTip1.SetToolTip(textBoxRollMods, BonusValueModifier.getToolTipStringFromList(_modifiers));
            updateTotalModifiers();
        }

        public void updateTotalModifiers()
        {

            if(_modifiers == null)
            {
                return;
            }

            List<DieRollComponent> myComponents = new List<DieRollComponent>();

            foreach(BonusValueModifier mod in _modifiers)
            {
                myComponents.Add(mod.modifierDieRoll);
            }

            /* Now lets go over the situational bonus... */
            string situationalBonus = textBoxRollSituational.Text;
            List<DieRollComponent> parsedComponents;

            if (!string.IsNullOrEmpty(situationalBonus))
            {
                try
                {
                    parsedComponents = DieRollEquation.parseComponentListFromString(situationalBonus);
                    myComponents.AddRange(parsedComponents);
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to parse situational bonus : " + situationalBonus);
                }
            }

            DieRollEquation myEquation = new DieRollEquation();
            myEquation.DieRollComponents = myComponents;
            myEquation.ReduceConstants(); /* Might not be the best way, but it will probably work. TODO : Maybe should return a new Equation object??? */
            

            dieRollTextBoxTotalRoll.DieRollObject = myEquation; /* This method is probably safer. */
        }

        private void textBoxRollSituational_Leave(object sender, EventArgs e)
        {
            updateTotalModifiers();
        }

        private void textBoxRollSituational_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                updateTotalModifiers();
            }
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            /* We should have the complete roll contained in the total textbox, so lets use that. */
            string logString;
            int result = dieRollTextBoxTotalRoll.Roll(out logString);

            if(rollListener != null)
            {
                rollListener(logString, this);
            }

            textBoxRollTotalResult.Text = result.ToString();
        }

        private void textBoxRollSituational_TextChanged(object sender, EventArgs e)
        {
            /* Might have been changed programmatically... We need to catch this somehow. */
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        internal void setSituationalBonus(DieRollEquation dieRollEquation)
        {
            /* We do this in a very simplified manner for now. */
            textBoxRollSituational.Text = dieRollEquation.ToString();
            updateTotalModifiers();
        }
    }
}
