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
    public partial class UserControlSkillProficiencies : UserControl
    {
        private List<UserControlProficiency> skillProficiencyControlList = new List<UserControlProficiency>();
        private int numberOfSkillsToChoose = 0;
        private List<String> AvailableSkillsToChoose = new List<String>();

        private int currentProfBonus = 2;

        private int currentStrBonus = 0;
        private int currentDexBonus = 0;
        private int currentChaBonus = 0;
        private int currentIntBonus = 0;
        private int currentWisBonus = 0;
        private int currentConBonus = 0;


        public UserControlSkillProficiencies()
        {
            InitializeComponent();

            //Lets populate our list so we don't have to do this every time.
            foreach (Control c in groupBoxSkillProfs.Controls)
            {
                if (c is UserControlProficiency)
                {
                    UserControlProficiency profControl = (UserControlProficiency)c;
                    skillProficiencyControlList.Add(profControl);
                    profControl.ChangeListener = SkillProfCheckedChanged;
                }
            }
        }

        private void SkillProfCheckedChanged(String name)
        {
            //So we have manually checked a proficiency.
            UserControlProficiency selectedControl = null;

            foreach (UserControlProficiency ctrl in skillProficiencyControlList)
            {
                if (ctrl.ProficiencyName == name)
                {
                    selectedControl = ctrl;
                    break;
                }
            }

            if (selectedControl == null)
            {
                //Something went really wrong...
                return;
            }

            if (selectedControl.IsProficient())
            {
                if (numberOfSkillsToChoose == 0)
                {
                    //Reset this control.
                    selectedControl.setProficiency(false, 2);
                }
                else
                {
                    numberOfSkillsToChoose--;
                }

            }
            else
            {
                numberOfSkillsToChoose++;
            }

            labelNumberOfProficienciesToChoose.Text = numberOfSkillsToChoose.ToString();
        }

        public void updateSkillProficiencyFields(int strBonus, int dexBonus, int IntBonus, int WisBonus, int ChaBonus, int ConBonus, int profBonus)
        {
            currentStrBonus = strBonus;
            currentIntBonus = IntBonus;
            currentDexBonus = dexBonus;
            currentWisBonus = WisBonus;
            currentChaBonus = ChaBonus;
            currentConBonus = ConBonus;
            currentProfBonus = profBonus;

            foreach (UserControlProficiency profControl in skillProficiencyControlList)
            {
                String baseSkill = profControl.ProficiencyBaseSkill.ToUpper();
                profControl.setValueAndProficiency(getCurrentAttributeBonus(baseSkill), profControl.IsProficient(), currentProfBonus);
            }
        }

        public void resetControls()
        {
            foreach (UserControlProficiency profControl in skillProficiencyControlList)
            {
                profControl.setEditable(false);
                String baseSkill = profControl.ProficiencyBaseSkill.ToUpper();
                profControl.setValueAndProficiency(getCurrentAttributeBonus(baseSkill), false, currentProfBonus);
            }
        }

        public bool setProficientAtSkill(string skill)
        {
            UserControlProficiency ctrl = skillProficiencyControlList.Find(c => c.ProficiencyName == skill);
            if (ctrl != null)
            {
                ctrl.setProficiency(true, 2);
                return true;
            }

            return false;
        }

        public void setUpChoiceProficiencies(int numberOfSkillsToChoose, List<string> AvailableSkillsToChoose)
        {
            labelNumberOfProficienciesToChoose.Text = numberOfSkillsToChoose.ToString();

            this.numberOfSkillsToChoose = numberOfSkillsToChoose;
            this.AvailableSkillsToChoose = AvailableSkillsToChoose;

            foreach (UserControlProficiency ctrl in skillProficiencyControlList)
            {
                if (AvailableSkillsToChoose.Contains(ctrl.ProficiencyName))
                {
                    ctrl.setEditable(true);
                }
            }
        }


        private int getCurrentAttributeBonus(String attrib)
        {
            int res = -1;

            switch (attrib)
            {
                case "STR":
                    res = currentStrBonus;
                    break;
                case "CHA":
                    res = currentChaBonus;
                    break;
                case "DEX":
                    res = currentDexBonus;
                    break;
                case "CON":
                    res = currentConBonus;
                    break;
                case "WIS":
                    res = currentWisBonus;
                    break;
                case "INT":
                    res = currentIntBonus;
                    break;
                default:
                    break;
            }

            return res;
        }
    }
}
