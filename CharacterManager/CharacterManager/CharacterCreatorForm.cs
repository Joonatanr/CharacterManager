using CharacterManager.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class CharacterCreatorForm : Form
    {
        public PlayerCharacter CreatedCharacter { get; set; }

        private int StrBonus = 0;
        private int IntBonus = 0;
        private int DexBonus = 0;
        private int ChaBonus = 0;
        private int WisBonus = 0;
        private int ConBonus = 0;

        private CharacterFactory myFactory;

        private PlayerRace SelectedMainRace;
        private PlayerRace SelectedSubRace;
        private PlayerClass SelectedClass;

        private List<PlayerAttribute> myAttributeList = new List<PlayerAttribute>();

        public CharacterCreatorForm(CharacterFactory factory)
        {
            InitializeComponent();
            myFactory = factory;

            if (myFactory.Initialize() == false)
            {
                throw new Exception("Error : Failed to initialize Character Factory");
            }

            List<String> mainRaceNameList = myFactory.getMainRacesList();

            foreach(String str in mainRaceNameList)
            {
                comboBoxMainRace.Items.Add(str);
            }

            List<String> ClassNameList = myFactory.getClassList();

            foreach(String str in ClassNameList)
            {
                comboBoxPlayerClasses.Items.Add(str);
            }
        }

        private bool CreateCharacter()
        {
            bool res = true;

            if (textBoxCharName.Text != String.Empty && SelectedClass != null && SelectedMainRace != null)
            {
                //1. Set player name.
                CreatedCharacter = new PlayerCharacter(textBoxCharName.Text);
                CreatedCharacter.ClassName = SelectedClass.PlayerClassName;

                //2. Set base attributes.
                CreatedCharacter.StrengthAttribute = (int)numericUpDownSTR.Value + StrBonus;
                CreatedCharacter.WisAttribute = (int)numericUpDownWIS.Value + WisBonus;
                CreatedCharacter.IntAttribute = (int)numericUpDownINT.Value + IntBonus;
                CreatedCharacter.DexAttribute = (int)numericUpDownDEX.Value + DexBonus;
                CreatedCharacter.ConAttribute = (int)numericUpDownCON.Value + ConBonus;
                CreatedCharacter.CharAttribute = (int)numericUpDownCHA.Value + ChaBonus;

                CreatedCharacter.Level = 1;
                CreatedCharacter.ProficiencyBonus = 2;
                CreatedCharacter.ExperiencePoints = 0;

                //3. Set race and subrace.
                if (SelectedMainRace == null)
                {
                    MessageBox.Show("Error : No race is selected.");
                    res = false;
                }
                else
                {
                    //CreatedCharacter.MainRaceName = SelectedMainRace.RaceName;
                    //CreatedCharacter.SubRaceName = SelectedSubRace.RaceName;
                    CreatedCharacter.setMainAndSubrace(SelectedMainRace, SelectedSubRace);
                }

                //4. Set weapon and armor proficiencies.
                CreatedCharacter.WeaponProficiencies = getAllWeaponProficiencies();
                CreatedCharacter.ArmorProficiencies = getAllArmorProficiencies();

                //5. Set saving throw proficiencies.
                CreatedCharacter.SavingThrowProficiencies = SelectedClass.SavingThrowProficiencies;
            }

            return res;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (CreateCharacter())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                handleErrorData();
            }   
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            /* TODO */

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void handleErrorData()
        {
            MessageBox.Show("Invalid data");
        }


        private List<String> getAllArmorProficiencies()
        {
            List<String> res = new List<String>();

            foreach (String aProf in SelectedMainRace.ArmorProficiencies)
            {
                res.Add(aProf);
            }

            if (SelectedSubRace != null)
            {
                foreach (String aProf in SelectedSubRace.ArmorProficiencies)
                {
                    res.Add(aProf);
                }
            }

            if (SelectedClass != null)
            {
                foreach (String aProf in SelectedClass.ArmorProficiencies)
                {
                    if (!res.Contains(aProf))
                    {
                        res.Add(aProf);
                    };
                }
            }

            return res;
        }

        private List<String> getAllWeaponProficiencies()
        {
            List<String> res = new List<String>();

            foreach (String wProf in SelectedMainRace.WeaponProficiencies)
            {
                res.Add(wProf);
            }

            if (SelectedSubRace != null)
            {
                foreach (String wProf in SelectedSubRace.WeaponProficiencies)
                {
                    res.Add(wProf);
                }
            }

            if (SelectedClass != null)
            {
                foreach(String wProf in SelectedClass.WeaponProficiencies)
                {
                    if (!res.Contains(wProf))
                    {
                        res.Add(wProf);
                    };
                }
            }

            return res;
        }


        private int getSpeedValue()
        {
            int res = 0;

            if (SelectedMainRace != null)
            {
                res = SelectedMainRace.BaseSpeed;
            }

            if (SelectedSubRace != null)
            {
                if(SelectedSubRace.BaseSpeed != 0)
                {
                    //We override with subrace speed. 
                    res = SelectedSubRace.BaseSpeed;
                } 
            }

            return res;
        }

        private void updateAllDisplayedData()
        {
            //TODO : Create a base attribute display class. 
            //1. Lets begin with the selected race and subrace
            if (SelectedMainRace != null)
            {
                StrBonus = SelectedMainRace.BonusAttributes.STR;
                IntBonus = SelectedMainRace.BonusAttributes.INT;
                WisBonus = SelectedMainRace.BonusAttributes.WIS;
                ConBonus = SelectedMainRace.BonusAttributes.CON;
                ChaBonus = SelectedMainRace.BonusAttributes.CHA;
                DexBonus = SelectedMainRace.BonusAttributes.DEX;
            }

            if (SelectedSubRace != null)
            {
                StrBonus += SelectedSubRace.BonusAttributes.STR;
                IntBonus += SelectedSubRace.BonusAttributes.INT;
                WisBonus += SelectedSubRace.BonusAttributes.WIS;
                ConBonus += SelectedSubRace.BonusAttributes.CON;
                ChaBonus += SelectedSubRace.BonusAttributes.CHA;
                DexBonus += SelectedSubRace.BonusAttributes.DEX;
            }

            updateBaseAttributeFields();
            //TODO : We want to show where the bonuses come from.

            //2. Lets next try showing weapon and armor proficiencies...
            //TODO : This is just a test, we really should make the proficiency and attribute displays into a separate class.
            richTextBoxProficiencyTest.Clear();
            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Bold);
            richTextBoxProficiencyTest.AppendText("Weapon Proficiencies:\n");
            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Regular);

            List<String> wProfList = getAllWeaponProficiencies();

            foreach (String wProf in wProfList)
            {
                richTextBoxProficiencyTest.AppendText(wProf + "\n");
            }


            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Bold);
            richTextBoxProficiencyTest.AppendText("\nArmorProficiencies:\n");
            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Regular);

            List<String> aProfList = getAllArmorProficiencies();
            foreach (String aProf in aProfList)
            {
                richTextBoxProficiencyTest.AppendText(aProf + "\n");
            }

            //3. Update the speed of the character.
            textBoxSpeed.Text = getSpeedValue().ToString() + " ft";

            //4. Update hit point values.
            if (SelectedClass != null)
            {
                textBoxHitDie.Text = "1d" + SelectedClass.HitDie;
                int constitution = (int)numericUpDownCON.Value + ConBonus;
                int bonus = CharacterFactory.getAbilityModifierValue(constitution);
                int hp = bonus + SelectedClass.HitDie;
                textBoxHitPoints.Text = hp.ToString();
            }

            //5. Update saving throw values.
            updateSavingThrowFields();

            //6. Update skill proficiency values.
            updateSkillProficiencyFields();

            //7. Update the generic abilities list.
            updateGenericAbilitiesField();
        }

        private void updateGenericAbilitiesField()
        {
            //Lets just test with the race abilities first.
            myAttributeList.Clear();

            if (SelectedMainRace == null)
            {
                return;
            }

            foreach (PlayerAttribute attrib in SelectedMainRace.getPlayerAttributes())
            {
                myAttributeList.Add(attrib);
            }

            if (SelectedSubRace != null)
            {
                foreach (PlayerAttribute attrib in SelectedSubRace.getPlayerAttributes())
                {
                    myAttributeList.Add(attrib);
                }
            }

            userControlGenericAttributeList1.setAttributeList(myAttributeList);
        }

        private void updateBaseAttributeFields()
        {
            //Update the bonus fields.
            textBoxStrBonus.Text = "+" + StrBonus.ToString();
            textBoxIntBonus.Text = "+" + IntBonus.ToString();
            textBoxWisBonus.Text = "+" + WisBonus.ToString();
            textBoxConBonus.Text = "+" + ConBonus.ToString();
            textBoxChaBonus.Text = "+" + ChaBonus.ToString();
            textBoxDexBonus.Text = "+" + DexBonus.ToString();

            textBoxSTRFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownSTR.Value + StrBonus);
            textBoxINTFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownINT.Value + IntBonus);
            textBoxWISFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownWIS.Value + WisBonus);
            textBoxCONFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownCON.Value + ConBonus);
            textBoxCHAFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownCHA.Value + ChaBonus);
            textBoxDEXFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownDEX.Value + DexBonus);

            //These also need to be updated here.. 
            updateSavingThrowFields();
            updateSkillProficiencyFields();
        }


        private void updateSkillProficiencyFields()
        {
            userControlSkillProficiencies1.updateSkillProficiencyFields(getCurrentAttributeBonus("STR"),
                                                     getCurrentAttributeBonus("DEX"),
                                                     getCurrentAttributeBonus("INT"),
                                                     getCurrentAttributeBonus("WIS"),
                                                     getCurrentAttributeBonus("CHA"),
                                                     getCurrentAttributeBonus("CON"),
                                                     2);
        }

        private int getCurrentAttributeBonus(String attrib)
        {
            int res = -1;

            switch (attrib)
            {
                case "STR":
                    res = (int)numericUpDownSTR.Value + StrBonus;
                    break;
                case "CHA":
                    res = (int)numericUpDownCHA.Value + ChaBonus;
                    break;
                case "DEX":
                    res = (int)numericUpDownDEX.Value + DexBonus;
                    break;
                case "CON":
                    res = (int)numericUpDownCON.Value + ConBonus;
                    break;
                case "WIS":
                    res = (int)numericUpDownWIS.Value + WisBonus;
                    break;
                case "INT":
                    res = (int)numericUpDownINT.Value + IntBonus;
                    break;
                default:
                    break;
            }

            if (res >= 0)
            {
                res = CharacterFactory.getAbilityModifierValue(res);
            }

            return res;
        }


        private void updateSavingThrowFields()
        {
            // TODO : Should make the saving throw display into a separate class altogether.
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("STR"), isCharacterSaveProfIn("STR"), 2, "STR");
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("INT"), isCharacterSaveProfIn("INT"), 2, "INT");
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("DEX"), isCharacterSaveProfIn("DEX"), 2, "DEX");
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("CON"), isCharacterSaveProfIn("CON"), 2, "CON");
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("WIS"), isCharacterSaveProfIn("WIS"), 2, "WIS");
            userControlSavingThrows1.setValue(getCurrentAttributeBonus("CHA"), isCharacterSaveProfIn("CHA"), 2, "CHA");
        }




        private bool isCharacterSaveProfIn(String attribute)
        {
            bool result = false;
            if (SelectedClass != null)
            {
                if (SelectedClass.SavingThrowProficiencies.Contains(attribute))
                {
                    result = true;
                }
            }

            return result;
        }

        private void resetSkillProficiencies()
        {
            //1. Reset the controls
            userControlSkillProficiencies1.resetControls();

            List<String> racialProficiencies = new List<string>();

            foreach (String prof in SelectedMainRace.SkillProficiencies)
            {
                racialProficiencies.Add(prof);
            }

            if (SelectedSubRace != null)
            {
                foreach (String prof in SelectedSubRace.SkillProficiencies)
                {
                    racialProficiencies.Add(prof);
                }
            }

            //2. Lets get the skill proficiencies from race first.
            foreach (String prof in racialProficiencies)
            {
                if (!userControlSkillProficiencies1.setProficientAtSkill(prof))
                { 
                    MessageBox.Show("Incorrect skill proficiency : " + prof + ", failed to parse");
                }
            }

            //3. Set up choosing new skill proficiencies.
            //TODO : This is unfinished.
            int numberOfSkillsToChoose = SelectedClass.NumberOfSkillsToChoose;
            List<string> AvailableSkillsToChoose = new List<string>();

            foreach (string skill in SelectedClass.AvailableSkillProficiencies)
            {
                if (!racialProficiencies.Contains(skill))
                {
                    AvailableSkillsToChoose.Add(skill);
                }
            }

            userControlSkillProficiencies1.setUpChoiceProficiencies(numberOfSkillsToChoose, AvailableSkillsToChoose);
        }


        private void numericUpDownSTR_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownINT_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownDEX_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownCON_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownWIS_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownCHA_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void comboBoxMainRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainRace.Items.Count > 0)
            {
                String selectedItem = comboBoxMainRace.SelectedItem.ToString();
                comboBoxSubRace.Items.Clear();
                comboBoxSubRace.SelectedIndex = -1;
                comboBoxSubRace.Text = "";
                SelectedSubRace = null;

                List<String> subRaceNames = myFactory.getSubRaceList(selectedItem);

                foreach (String str in subRaceNames)
                {
                    comboBoxSubRace.Items.Add(str);
                }

                SelectedMainRace = myFactory.getRaceByName(comboBoxMainRace.SelectedItem.ToString());
                updateAllDisplayedData();
            }
        }

        private void comboBoxSubRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubRace.Items.Count > 0)
            {
                String selectedItem = comboBoxSubRace.SelectedItem.ToString();
                String mainRace = comboBoxMainRace.SelectedItem.ToString();
                if (mainRace != null && selectedItem != null)
                {
                    SelectedSubRace = myFactory.getSubRaceByName(mainRace, selectedItem);
                    updateAllDisplayedData();
                }
            }
        }

        private void textBoxCHAFinal_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxPlayerClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxPlayerClasses.Items.Count > 0)
            {
                String selectedItem = comboBoxPlayerClasses.SelectedItem.ToString();

                if (selectedItem != null)
                {
                    SelectedClass = myFactory.getPlayerClassByName(selectedItem);
                    updateAllDisplayedData();
                    /* There is a difference between resetting and updating these values. Update should be done elsewhere... */
                    resetSkillProficiencies();
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
