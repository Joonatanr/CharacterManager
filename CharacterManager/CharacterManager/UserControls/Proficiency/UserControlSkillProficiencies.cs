using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.UserControls.Proficiency;

namespace CharacterManager.UserControls
{
    public partial class UserControlSkillProficiencies : UserControl
    {
        private List<UserControlSkillProficiency> skillProficiencyControlList = new List<UserControlSkillProficiency>();
        private int numberOfSkillsToChooseMax = 0;
        private int numberOfSkillsToChooseAnyMax = 0; //The number of skills proficiencies that can be any skill. This is rarely used, mostly only half-elves have this feature.

        private int numberOfSkillsToChooseRemaining = 0;
        private int numberOfSkillsToChooseAnyRemaining = 0;
        
        private List<String> AvailableSkillsToChooseList = new List<String>();
        private List<String> LockedSkillProficiencies = new List<String>(); //These proficiencies come from either background or directly from race so they cannot be deselected.

        private int currentProfBonus = 2;

        private int currentStrBonus = 0;
        private int currentDexBonus = 0;
        private int currentChaBonus = 0;
        private int currentIntBonus = 0;
        private int currentWisBonus = 0;
        private int currentConBonus = 0;

        public delegate void UpdatedProficiencyValuesListener();
        public UpdatedProficiencyValuesListener checkedChangedListener = null;

        public Boolean isSetDataVisible
        {
            get
            {
                return labelNumberOfProficienciesToChoose.Visible;
            }
            set
            {
                labelNumberOfProficienciesToChoose.Visible = value;
                label15.Visible = false;
            }
        }

        public UserControlSkillProficiencies()
        {
            InitializeComponent();

            //Lets populate our list so we don't have to do this every time.
            foreach (Control c in groupBoxSkillProfs.Controls)
            {
                if (c is UserControlSkillProficiency)
                {
                    UserControlSkillProficiency profControl = (UserControlSkillProficiency)c;
                    skillProficiencyControlList.Add(profControl);
                    profControl.ChangeListener = SkillProfCheckedChanged;
                }
            }
        }

        private void SkillProfCheckedChanged(String name)
        {
            //So we have manually checked a proficiency.
            UserControlSkillProficiency selectedControl = null;

            foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
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
                //The user has added a proficiency.
                //Since we have two types of proficiencies that we can use, the extra and the class proficiencies then we have to decide which one was used.
                //Lets first prefer using the class proficiency.
                if (AvailableSkillsToChooseList.Contains(selectedControl.ProficiencyName) && (numberOfSkillsToChooseRemaining > 0))
                {
                    //We deduct one class proficiency...
                    numberOfSkillsToChooseRemaining--;

                    if (numberOfSkillsToChooseRemaining == 0 && (numberOfSkillsToChooseAnyRemaining == 0))
                    {
                        /* Make all choices that are NOT selected uneditable. */
                        foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
                        {
                            if (AvailableSkillsToChooseList.Contains(ctrl.ProficiencyName))
                            {
                                if (!ctrl.IsProficient())
                                {
                                    ctrl.setEditable(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //We deduct one extra (generic) proficiency...
                    numberOfSkillsToChooseAnyRemaining--;

                    if (numberOfSkillsToChooseAnyRemaining == 0)
                    {
                        //No more wildcards left...
                        foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
                        {
                            //This should not affect any controls that can still be chosen with a class-derived proficiency, or those from background etc...
                            if ((!AvailableSkillsToChooseList.Contains(ctrl.ProficiencyName) || numberOfSkillsToChooseRemaining == 0) && !ctrl.IsProficient())
                            {
                                ctrl.setEditable(false);
                            }
                        }
                    }
                }

            }
            else
            {
                //The user has removed a proficiency.
                //We have to decide which proficiency to refund, one derived from class or one wildcard.
                //By default we prefer refunding a class proficiency.
                /* TODO */

                //First lets check if there have been any extras provided in the first place
                if (numberOfSkillsToChooseAnyMax == 0)
                {
                    //This is the easy version, we just refund one class proficiency.
                    numberOfSkillsToChooseRemaining++;
                }
                else
                {
                    if (!AvailableSkillsToChooseList.Contains(selectedControl.ProficiencyName))
                    {
                        //Also easy -> Since this proficiency has been selected with a wildcard proficiency, then no other choice, but to return that.
                        numberOfSkillsToChooseAnyRemaining++;
                    }
                    else
                    {
                        //We prefer giving back a class proficiency.
                        //However we have to check if there are any remaining to refund.
                        if (numberOfSkillsToChooseRemaining < numberOfSkillsToChooseMax)
                        {
                            //Refund a class proficiency
                            numberOfSkillsToChooseRemaining++;
                        }
                        else
                        {
                            //Refund a wildcard
                            numberOfSkillsToChooseAnyRemaining++;
                        }
                    }
                }

                //Finally we update the controls based on what options we have left.
                foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
                {
                    if (AvailableSkillsToChooseList.Contains(ctrl.ProficiencyName) || (numberOfSkillsToChooseAnyRemaining > 0))
                    {
                        if (!LockedSkillProficiencies.Contains(ctrl.ProficiencyName))
                        {
                            ctrl.setEditable(true);
                        }
                    }
                }
            }

            updateLabelData();

            checkedChangedListener?.Invoke();
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

            foreach (UserControlSkillProficiency profControl in skillProficiencyControlList)
            {
                String baseSkill = profControl.ProficiencyBaseSkill.ToUpper();
                profControl.setValueAndProficiency(getCurrentAttributeBonus(baseSkill), profControl.IsProficient(), currentProfBonus);
            }
        }

        public void resetControls()
        {
            foreach (UserControlSkillProficiency profControl in skillProficiencyControlList)
            {
                profControl.setEditable(false);
                String baseSkill = profControl.ProficiencyBaseSkill.ToUpper();
                profControl.setValueAndProficiency(getCurrentAttributeBonus(baseSkill), false, currentProfBonus);
            }
            LockedSkillProficiencies = new List<string>();
        }

        public bool setProficientAtSkill(string skill)
        {
            UserControlSkillProficiency ctrl = skillProficiencyControlList.Find(c => c.ProficiencyName == skill);
            if (ctrl != null)
            {
                ctrl.setProficiency(true, 2);
                LockedSkillProficiencies.Add(skill); //This should not be deselectable by the user.
                return true;
            }

            return false;
        }

        
        public List<String> getAllSkillProficiencies()
        {
            List<String> res = new List<String>();

            foreach(UserControlSkillProficiency prof in skillProficiencyControlList)
            {
                if (prof.IsProficient())
                {
                    res.Add(prof.ProficiencyName);
                }
            }

            return res;
        }
        

        //This is the skill bonus that is currently being displayed.
        public int getTotalSkillBonus(string skill)
        {
            UserControlSkillProficiency ctrl = skillProficiencyControlList.Find(c => c.ProficiencyName == skill);
            if (ctrl != null)
            {
                return ctrl.getTotalProficiencyBonus();
            }

            return 0;
        }

        public void setUpChoiceProficiencies(int numberOfSkillsToChoose, List<string> AvailableSkillsToChoose, int numberOfAnySkills)
        {
            this.numberOfSkillsToChooseMax = numberOfSkillsToChoose;
            this.numberOfSkillsToChooseAnyMax = numberOfAnySkills;
            this.numberOfSkillsToChooseRemaining = numberOfSkillsToChoose;
            this.numberOfSkillsToChooseAnyRemaining = numberOfAnySkills;

            this.AvailableSkillsToChooseList = AvailableSkillsToChoose;


            updateLabelData();

            /* TODO : Might need to be in separate function. */
            foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
            {
                if (AvailableSkillsToChooseList.Contains(ctrl.ProficiencyName) || (numberOfSkillsToChooseAnyMax > 0))
                {
                    if (!LockedSkillProficiencies.Contains(ctrl.ProficiencyName))
                    {
                        ctrl.setEditable(true);
                    }
                }
            }
        }

        private void updateLabelData()
        {
            string profDescription = (numberOfSkillsToChooseRemaining + numberOfSkillsToChooseAnyRemaining).ToString();
            if (numberOfSkillsToChooseAnyRemaining > 0)
            {
                profDescription += " (" + numberOfSkillsToChooseAnyRemaining.ToString() + " can be ANY)";
            }

            labelNumberOfProficienciesToChoose.Text = profDescription;
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

        private void labelNumberOfProficienciesToChoose_Click(object sender, EventArgs e)
        {

        }
    }
}
