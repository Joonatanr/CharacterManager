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
    public partial class UserControlAttributeSetup : UserControl
    {
        public int TotalAttributeValue { get { return Math.Min((int)numericUpDownBaseValue.Value + _attributeBonus, 20); } }

        private int _attributeBonus = 0;
        public int AttributeBonus { get { return _attributeBonus; } set { _attributeBonus = value; updateBonusValue(); updateFinalValue(); } }

        private string _attributeName = "STR";
        public string AttributeName { get { return _attributeName; } set { _attributeName = value; labelDescription.Text = _attributeName; } }

        public event EventHandler ValueChanged;

        public UserControlAttributeSetup()
        {
            InitializeComponent();
        }

        public void setCustomBonusVisible(Boolean isVisible)
        {
            checkBoxExtraBonus.Checked = false; // If we are changing this, then by default should not be checked in any case.
            if (isVisible)
            {
                checkBoxExtraBonus.Visible = true;
            }
            else
            {
                checkBoxExtraBonus.Visible = false;
            }
        }

        private void updateFinalValue()
        {
            textBoxAttributeFinal.Text = TotalAttributeValue.ToString();
        }

        private void updateBonusValue()
        {
            if (_attributeBonus >= 0)
            {
                textBoxRacialBonus.Text = "+" + _attributeBonus.ToString();
            }
            else
            {
                textBoxRacialBonus.Text = _attributeBonus.ToString();
            }
        }

        private void numericUpDownBaseValue_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
            updateFinalValue();
        }
    }
}
