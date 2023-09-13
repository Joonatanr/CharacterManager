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
    public partial class AbilityCard : Form
    {
        private PlayerAbility _myAbility = null;
        
        public AbilityCard()
        {
            InitializeComponent();
        }

        public void setAbility(PlayerAbility ability)
        {
            _myAbility = ability;
            updateDisplayedData();
        }

        private void updateDisplayedData()
        {
            customRTBDescription.Text = _myAbility.GetExtendedDescription();
            if (!string.IsNullOrEmpty(_myAbility.Dice))
            {
                dieRollTextBox1.DieRollObject = new DieRollEquation(_myAbility.Dice);
                buttonRoll.Enabled = true;
                dieRollTextBox1.Enabled = true;
            }
            else
            {
                buttonRoll.Enabled = false;
                dieRollTextBox1.Enabled = false;
                buttonRoll.Visible = false;
                dieRollTextBox1.Visible = false;
                richTextBoxDieRollResult.Visible = false;
                labelDice.Visible = false;
            }

            labelAbilityName.Text = _myAbility.DisplayedName;

            if (_myAbility.MaximumCharges > 0)
            {
                userControlRemainingCharges.NumberOfSlots = _myAbility.MaximumCharges;
                userControlRemainingCharges.NumberOfRemainingSlots = _myAbility.RemainingCharges;
                _myAbility.IsActiveChanged += _myAbility_IsActiveChanged;
                _myAbility.AbilityUsed += _myAbility_AbilityUsed;

                userControlRemainingCharges.ActiveSlotsChanged = new UserControlSpellSlotRow.ActiveSlotsChangedListener(_abilityChargesUsedManually);
            }
            else
            {
                userControlRemainingCharges.Visible = false;
            }

            /* TODO : Might hide this if it is not relevant. Usually there will not be anything listed here... */
            userControlPlayerAbilityInfoItem1.SetListData(_myAbility.GetInfoItems());
        }

        private void _abilityChargesUsedManually(int amount)
        {
            _myAbility.RemainingCharges = amount;
        }

        private void _myAbility_AbilityUsed(PlayerAbility ability)
        {
            userControlRemainingCharges.NumberOfSlots = _myAbility.MaximumCharges;
            userControlRemainingCharges.NumberOfRemainingSlots = _myAbility.RemainingCharges;
        }

        private void _myAbility_IsActiveChanged(bool isActive)
        {
            /* Should we display if the ability is active somehow? */
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            string rollResult;
            dieRollTextBox1.Roll(out rollResult);
            richTextBoxDieRollResult.AppendText(rollResult + Environment.NewLine);
        }
    }
}
