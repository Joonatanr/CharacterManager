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
            int totalBonus = 0;
            string totalValueString = "";

            if(_modifiers == null)
            {
                return;
            }

            foreach (BonusValueModifier mod in _modifiers)
            {
                if (mod.modifierDieRoll is DieRoll)
                {
                    totalValueString += mod.getBonusValueString() + " + ";
                }
                else
                {
                    totalBonus += mod.modifierValue;
                }
            }

            /* Now lets go over situational bonus. First we need to resolve the string */
            string situationalBonus = textBoxRollSituational.Text;
            if (!string.IsNullOrEmpty(situationalBonus))
            {
                try
                {
                    DieRollEquation parsedDieRoll = new DieRollEquation(situationalBonus);
                    List<DieRollComponent> rollComponents = parsedDieRoll.DieRollComponents;
                    foreach (DieRollComponent component in rollComponents)
                    {
                        if (component is DieRoll)
                        {
                            totalValueString += component.ToString() + " + ";
                        }
                        else
                        {
                            string dummy; /* TODO : Log should be handled differently. */
                            totalBonus += component.getValue(out dummy);
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to parse situational bonus : " + situationalBonus);
                }
            }

            totalValueString += totalBonus.ToString();
            //dieRollTextBoxTotalRoll.Text = totalValueString;
            dieRollTextBoxTotalRoll.DieRollObject = new DieRollEquation(totalValueString); /* This method is probably safer. */
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

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
