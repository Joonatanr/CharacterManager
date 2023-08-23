using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class UserControlSavingThrows : UserControl
    {
        public UserControlSavingThrows()
        {
            InitializeComponent();
        }

        public void setValue(int value, bool isProficient, int proficiencyBonus, string type)
        {
            switch (type)
            {
                case ("STR"):
                    userControlProficiencySTR.setValueAndProficiency(new BonusValueModifier("STR", value), isProficient, proficiencyBonus);
                    break;
                case ("INT"):
                    userControlProficiencyINT.setValueAndProficiency(new BonusValueModifier("INT", value), isProficient, proficiencyBonus);
                    break;
                case ("DEX"):
                    userControlProficiencyDEX.setValueAndProficiency(new BonusValueModifier("DEX", value), isProficient, proficiencyBonus);
                    break;
                case ("CON"):
                    userControlProficiencyCON.setValueAndProficiency(new BonusValueModifier("CON", value), isProficient, proficiencyBonus);
                    break;
                case ("WIS"):
                    userControlProficiencyWIS.setValueAndProficiency(new BonusValueModifier("WIS", value), isProficient, proficiencyBonus);
                    break;
                case ("CHA"):
                    userControlProficiencyCHA.setValueAndProficiency(new BonusValueModifier("CHA", value), isProficient, proficiencyBonus);
                    break;
                default:
                    break;
            }
        }
    }
}
