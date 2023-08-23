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

        private int numberOfExpertiseToChooseMax = 0;
        private int numberOfExpertiseToChooseRemaining = 0;
        
        private List<String> AvailableSkillsToChooseList = new List<String>();
        private List<String> LockedSkillProficiencies = new List<String>(); //These proficiencies come from either background or directly from race so they cannot be deselected.
        private List<String> LockedSkillExpertise = new List<String>(); // These are already existing expertise modifiers that should not be modifiable. There probably aren't any use cases where a character can "forget" expertise at sth.

        private int currentProfBonus = 2;

        private int currentStrBonus = 0;
        private int currentDexBonus = 0;
        private int currentChaBonus = 0;
        private int currentIntBonus = 0;
        private int currentWisBonus = 0;
        private int currentConBonus = 0;

        public delegate void UpdatedProficiencyValuesListener();
        public UpdatedProficiencyValuesListener checkedChangedListener = null;

        private PlayerCharacter _connectedCharacter = null;

        public Boolean isSetDataVisible
        {
            get
            {
                return labelNumberOfProficienciesToChoose.Visible;
            }
            set
            {
                labelNumberOfProficienciesToChoose.Visible = value;
                label15.Visible = value;
            }
        }

        public Boolean IsCombinedProfExpertiseDisplay
        {
            get
            {
                return _isCombinedProfExpertiseDisplay;
            }

            set
            {
                _isCombinedProfExpertiseDisplay = value;
                userControlProficiencyAcrobatics.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyAnimalHandling.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyArcana.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyAthletics.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyDeception.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyHistory.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyInsight.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyIntimidation.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyInvestigation.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyMedicine.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyNature.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyPerception.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyPerformance.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyPersuasion.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencyReligion.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencySleightOfHand.IsCombinedProfExpertiseDisplay = value;
                userControlProficiencySurvival.IsCombinedProfExpertiseDisplay = value;
            }
        }


        private bool _isCombinedProfExpertiseDisplay = false;

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
                    profControl.ExpertiseCheckedChanged = ExpertiseCheckedChanged;
                }
            }
        }

        private void ExpertiseCheckedChanged(UserControlProficiency sender)
        {
            //So we have manually checked or unchecked  an expertise.
            UserControlSkillProficiency selectedControl = (UserControlSkillProficiency)sender;

            if (selectedControl.IsExpertise())
            {
                numberOfExpertiseToChooseRemaining--;
                if (numberOfExpertiseToChooseRemaining == 0)
                {
                    foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
                    {
                        if (!ctrl.IsExpertise())
                        {
                            ctrl.setExpertiseEditable(false);
                        }
                    }
                }
            }
            else
            {
                numberOfExpertiseToChooseRemaining++;
                if (numberOfExpertiseToChooseRemaining == 1)
                {
                    foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
                    {
                        ctrl.setExpertiseEditable(true);
                    }
                }
            }

            updateExpertiseLabelData();
        }

        private void SkillProfCheckedChanged(UserControlProficiency sender)
        {
            //So we have manually checked a proficiency.
            UserControlSkillProficiency selectedControl = (UserControlSkillProficiency)sender;

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


        public void ConnectToPlayerCharacter(PlayerCharacter c)
        {
            _connectedCharacter = c;

            updateSkillProficiencyFields(_connectedCharacter.getModifier("STR"),
                                         _connectedCharacter.getModifier("DEX"),
                                         _connectedCharacter.getModifier("INT"),
                                         _connectedCharacter.getModifier("WIS"),
                                         _connectedCharacter.getModifier("CHA"),
                                         _connectedCharacter.getModifier("CON"),
                                         _connectedCharacter.ProficiencyBonus);

            foreach (string skill in _connectedCharacter.SkillProficiencies)
            {
                setProficientAtSkill(skill);
            }

            foreach (string skill in _connectedCharacter.SkillExpertise)
            {
                setExpertiseAtSkill(skill);
            }

            /* Handle any extra bonuses that might come from abilityies. */
            c.UpdateSkillBonusFromAbilities();

            /* Now lets add these extra modifiers... */
            foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
            {
                string skillName = ctrl.ProficiencyName;
                try
                {
                    List<BonusValueModifier> modifiers = c.BonusValues.CharacterSkillBonusesFromAbilities[skillName];
                    ctrl.ExtraModifiers = modifiers;
                }
                catch (Exception)
                {
                    /* Member does not exist, so no bonus values for this skill.  */
                }
            }
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

            updateControlInformation();
        }

        public void resetControls()
        {
            foreach (UserControlSkillProficiency profControl in skillProficiencyControlList)
            {
                profControl.setEditable(false);
            }

            updateControlInformation();
            LockedSkillProficiencies = new List<string>();
        }

        private void updateControlInformation()
        {
            foreach (UserControlSkillProficiency profControl in skillProficiencyControlList)
            {
                String baseSkill = profControl.ProficiencyBaseSkill.ToUpper();
                BonusValueModifier BaseSkillBonus = new BonusValueModifier(baseSkill, getCurrentAttributeBonus(baseSkill));
                profControl.setValueAndProficiency(BaseSkillBonus, profControl.IsProficient(), currentProfBonus);
            }
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

        public bool setExpertiseAtSkill(string skill)
        {
            UserControlSkillProficiency ctrl = skillProficiencyControlList.Find(c => c.ProficiencyName == skill);
            if (ctrl != null)
            {
                ctrl.setExpertiseStatus(true);
                ctrl.setEditable(false);
                ctrl.setExpertiseEditable(false);
                LockedSkillExpertise.Add(skill);
                /* Since we have at least one expertise available, then this should be made visible. */
                setExpertiseVisible(true);
                return true;
            }

            return false;
        }

        private void setExpertiseVisible(bool isVisible)
        {
            foreach (UserControlSkillProficiency prof in skillProficiencyControlList)
            {
                prof.IsExpertiseVisible = isVisible;
            }
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
                return BonusValueModifier.getTotalValueFromList(ctrl.getTotalModifiers());
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

        public void setUpChoiceExpertise(int numberOfExpertiseToChoose)
        {
            if (numberOfExpertiseToChoose > 0)
            {
                numberOfExpertiseToChooseMax = numberOfExpertiseToChoose;
                numberOfExpertiseToChooseRemaining = numberOfExpertiseToChoose;

                /* We have at least one expertise available, so lets set this column visible. */
                setExpertiseVisible(true);
                
            }
            updateExpertiseLabelData();

            foreach (UserControlSkillProficiency ctrl in skillProficiencyControlList)
            {
                if (!LockedSkillExpertise.Contains(ctrl.ProficiencyName))
                {
                    ctrl.setExpertiseEditable(true);
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

        private void updateExpertiseLabelData()
        {
            if (numberOfExpertiseToChooseMax > 0)
            {
                labelNumberOfExpertiseAvailable.Visible = true;
                labelNumberOfExpertiseAvailable.Text = numberOfExpertiseToChooseRemaining.ToString();
            }
            else
            {
                labelNumberOfExpertiseAvailable.Visible = false;
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

        private void labelNumberOfProficienciesToChoose_Click(object sender, EventArgs e)
        {

        }
    }
}
