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
        

        public void connectToPlayerCharacter(PlayerCharacter c)
        {
            if (c != null)
            {
                userControlProficiencySTR.setValueAndProficiency(new BonusValueModifier("STR", c.getModifier("STR")), c.isSavingThrowProficientIn("STR"), c.ProficiencyBonus);
                userControlProficiencySTR.setExtraModifiers(c.GetSavingThrowExtraModifiers("STR"));
                
                userControlProficiencyINT.setValueAndProficiency(new BonusValueModifier("INT", c.getModifier("INT")), c.isSavingThrowProficientIn("INT"), c.ProficiencyBonus);
                userControlProficiencyINT.setExtraModifiers(c.GetSavingThrowExtraModifiers("INT"));

                userControlProficiencyDEX.setValueAndProficiency(new BonusValueModifier("DEX", c.getModifier("DEX")), c.isSavingThrowProficientIn("DEX"), c.ProficiencyBonus);
                userControlProficiencyDEX.setExtraModifiers(c.GetSavingThrowExtraModifiers("DEX"));

                userControlProficiencyCON.setValueAndProficiency(new BonusValueModifier("CON", c.getModifier("CON")), c.isSavingThrowProficientIn("CON"), c.ProficiencyBonus);
                userControlProficiencyCON.setExtraModifiers(c.GetSavingThrowExtraModifiers("CON"));

                userControlProficiencyWIS.setValueAndProficiency(new BonusValueModifier("WIS", c.getModifier("WIS")), c.isSavingThrowProficientIn("WIS"), c.ProficiencyBonus);
                userControlProficiencyWIS.setExtraModifiers(c.GetSavingThrowExtraModifiers("WIS"));

                userControlProficiencyCHA.setValueAndProficiency(new BonusValueModifier("CHA", c.getModifier("CHA")), c.isSavingThrowProficientIn("CHA"), c.ProficiencyBonus);
                userControlProficiencyCHA.setExtraModifiers(c.GetSavingThrowExtraModifiers("CHA"));
            }
        }


        public int RollSavingThrow(string type, out string log)
        {
            switch (type)
            {
                case ("STR"):
                    return userControlProficiencySTR.Roll(out log);
                case ("INT"):
                    return userControlProficiencyINT.Roll(out log);
                case ("DEX"):
                    return userControlProficiencyDEX.Roll(out log);
                case ("CON"):
                    return userControlProficiencyCON.Roll(out log);
                case ("WIS"):
                    return userControlProficiencyWIS.Roll(out log);
                case ("CHA"):
                    return userControlProficiencyCHA.Roll(out log);
                default:
                    log = "Error";
                    return 0;
            }
        }
    }
}
