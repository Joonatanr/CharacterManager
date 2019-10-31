using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class UserControlProficiency : UserControl
    {
        public String ProficiencyName { get { return this.label24.Text; } set { this.label24.Text = value; } }


        public UserControlProficiency()
        {
            InitializeComponent();
        }

        public void setValue(int baseValue, bool isProficient, int proficiencyBonus)
        {
            int val = baseValue;

            if (isProficient)
            {
                checkBoxProfSTR.Checked = true;
                val += proficiencyBonus;
            }
            else
            {
                checkBoxProfSTR.Checked = false;
            }

            textBoxStrSave.Text = val.ToString();
        }
        
    }
}
