using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls.Levelup
{
    public partial class FormChooseSkillProfs : Form
    {
        private PlayerCharacter connectedCharacter = null;
        private int NumberOfNewSkillProficiencies = 0;

        public String LabelText
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public FormChooseSkillProfs()
        {
            InitializeComponent();
        }

        public void setCharacter(PlayerCharacter c)
        {
            connectedCharacter = c;
            if(connectedCharacter != null)
            {
                updateDisplayedData();
            }
        }

        public void setupProficiencyChoices(int numberOfNewSkills)
        {
            NumberOfNewSkillProficiencies = numberOfNewSkills;

            List<string> dummy = new List<string>();

            userControlSkillProficiencies1.setUpChoiceProficiencies(0, dummy, NumberOfNewSkillProficiencies);
        }

        public void setupProficiencyChoices(int numberOfNewSkills, List<string> AvailableSkills)
        {
            userControlSkillProficiencies1.setUpChoiceProficiencies(numberOfNewSkills, AvailableSkills, 0);
        }

        public void setupExpertiseChoices(int numberOfNewExpertiseChoices)
        {
            userControlSkillProficiencies1.setUpChoiceExpertise(numberOfNewExpertiseChoices);
        }


        private void updateDisplayedData()
        {
            userControlSkillProficiencies1.updateSkillProficiencyFields(connectedCharacter.getModifier("STR"),
                                                            connectedCharacter.getModifier("DEX"),
                                                            connectedCharacter.getModifier("INT"),
                                                            connectedCharacter.getModifier("WIS"),
                                                            connectedCharacter.getModifier("CHA"),
                                                            connectedCharacter.getModifier("CON"),
                                                            connectedCharacter.ProficiencyBonus);

            foreach (string skill in connectedCharacter.SkillProficiencies)
            {
                userControlSkillProficiencies1.setProficientAtSkill(skill);
            }

            foreach(string skill in connectedCharacter.SkillExpertise)
            {
                userControlSkillProficiencies1.setExpertiseAtSkill(skill);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
