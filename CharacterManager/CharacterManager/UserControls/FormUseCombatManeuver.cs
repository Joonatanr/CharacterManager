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
    public partial class FormUseCombatManeuver : Form
    {

        private PlayerManeuverAbility _myManeuverAbility = null;
        
        public PlayerManeuverAbility ManeuverAbility
        {
            get { return _myManeuverAbility; }
            set
            {
                _myManeuverAbility = value;
                this.Text = "Use " + _myManeuverAbility.DisplayedName;
                userControlManeuverChoice1.TitleString = _myManeuverAbility.ManeuverListTitle;
                userControlSpellSlotRow1.LabelName = _myManeuverAbility.ChargesDisplayedName;

                if (string.IsNullOrEmpty(_myManeuverAbility.Dice))
                {
                    groupBoxDice.Visible = false;
                }
                else
                {
                    groupBoxDice.Visible = true;
                }

                _myManeuverAbility.RemainingChargesChanged += new PlayerAbility.PlayerAbilityValueChanged(HandleManeuverChargesChanged);
                updateDisplayedData();
            }
        }
        
        public FormUseCombatManeuver()
        {
            InitializeComponent();
        }

        private void updateDisplayedData()
        {
            if(_myManeuverAbility != null)
            {
                userControlManeuverChoice1.setAvailableManeuverChoices(_myManeuverAbility.GetAllChosenManeuvers());
                userControlSpellSlotRow1.NumberOfSlots = _myManeuverAbility.MaximumCharges;
                userControlSpellSlotRow1.NumberOfRemainingSlots = _myManeuverAbility.RemainingCharges;
                userControlSpellSlotRow1.ActiveSlotsChanged = new UserControlSpellSlotRow.ActiveSlotsChangedListener(HandleManeuverChargesChangedByUser);

                dieRollTextBox1.DieRollObject = _myManeuverAbility.DiceObject;

                List<BonusValueModifier> DifficultyClassModifiers = _myManeuverAbility.getDifficultyClass();
                userControlGenericValue1.setBonusValueModifiers(DifficultyClassModifiers);
            }
        }

        private void HandleManeuverChargesChangedByUser(int value)
        {
            _myManeuverAbility.RemainingCharges = value;
        }

        private void HandleManeuverChargesChanged(int value)
        {
            userControlSpellSlotRow1.NumberOfRemainingSlots = value;
        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            string rollResult;
            int result = dieRollTextBox1.Roll(out rollResult);
            textBox1.Text = result.ToString();
            richTextBox1.AppendText(rollResult + Environment.NewLine);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
