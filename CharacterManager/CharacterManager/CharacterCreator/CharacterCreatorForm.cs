using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using CharacterManager.Spells;
using CharacterManager.UserControls;

namespace CharacterManager.CharacterCreator
{
    public partial class CharacterCreatorForm : Form
    {
        public PlayerCharacter CreatedCharacter { get; set; }

        private PlayerRace SelectedMainRace;
        private PlayerRace SelectedSubRace;
        private PlayerClass SelectedClass;
        private int currentPassivePerception = 0;
        private int currentMaxHp = 0;

        private int currentExtraAttributes = 0;
        private int maxExtraAttributes = 0;

        private List<PlayerAbility> myAttributeList = new List<PlayerAbility>();
        private List<Items.PlayerItem> myItemList = new List<Items.PlayerItem>();


        /* Subforms */
        FormChooseBackGround myChooseBackGroundForm = new FormChooseBackGround();
        FormChooseEquipment myChooseEquipmentForm = new FormChooseEquipment();
        FormChooseClassFeatures myChooseClassFeaturesForm = new FormChooseClassFeatures();
        FormChooseSpells myChooseSpellsForm = new FormChooseSpells();

        public CharacterCreatorForm()
        {
            InitializeComponent();

            if (CharacterFactory.Initialize() == false)
            {
                throw new Exception("Error : Failed to initialize Character Factory");
            }

            List<string> mainRaceNameList = CharacterFactory.getMainRacesList();

            foreach (string str in mainRaceNameList)
            {
                this.comboBoxMainRace.Items.Add(str);
            }

            List<String> classNameList = CharacterFactory.getClassList();

            foreach (string str in classNameList)
            {
                this.comboBoxPlayerClasses.Items.Add(str);
            }

            this.userControlSkillProficiencies1.checkedChangedListener = this.proficienciesChanged;
        }

        private bool CreateCharacter(out String msg)
        {
            bool res = true;
            msg = String.Empty;

            if (textBoxCharName.Text != String.Empty && SelectedClass != null && SelectedMainRace != null)
            {
                //1. Set player name.
                CreatedCharacter = new PlayerCharacter(textBoxCharName.Text);
                CreatedCharacter.ClassName = SelectedClass.PlayerClassName;

                //2. Set base attributes.
                CreatedCharacter.StrengthAttribute = userControlAttributeSetupSTR.TotalAttributeValue;
                CreatedCharacter.WisAttribute = userControlAttributeSetupWIS.TotalAttributeValue;
                CreatedCharacter.IntAttribute = userControlAttributeSetupINT.TotalAttributeValue;
                CreatedCharacter.DexAttribute = userControlAttributeSetupDEX.TotalAttributeValue;
                CreatedCharacter.ConAttribute = userControlAttributeSetupCON.TotalAttributeValue;
                CreatedCharacter.CharAttribute = userControlAttributeSetupCHA.TotalAttributeValue;

                CreatedCharacter.Level = 1;
                CreatedCharacter.ProficiencyBonus = 2;
                CreatedCharacter.ExperiencePoints = 0;

                //3. Set race and subrace.
                if (SelectedMainRace == null)
                {
                    msg = "Error : No race is selected.";
                    return false;
                }
                else
                {
                    CreatedCharacter.setMainAndSubrace(SelectedMainRace, SelectedSubRace);
                }

                //4. Set weapon and armor proficiencies.
                CreatedCharacter.WeaponProficiencies = getAllWeaponProficiencies();
                CreatedCharacter.ArmorProficiencies = getAllArmorProficiencies();

                //5. Set saving throw proficiencies.
                CreatedCharacter.SavingThrowProficiencies = SelectedClass.SavingThrowProficiencies;

                //6. Set skill proficiencies
                CreatedCharacter.SkillProficiencies = userControlSkillProficiencies1.getAllSkillProficiencies();

                //7. Set Player HitPoints.
                CreatedCharacter.MaxHitPoints = currentMaxHp;
                CreatedCharacter.CurrentHitPoints = currentMaxHp;

                //8. Set Player attributes.
                CreatedCharacter.setCharacterAbilitiesList(myAttributeList, true);

                //9. Set Player alignment.
                CreatedCharacter.Alignment = alignmentChoice1.getSelectedAlignment();

                //10. Set Player Equipment.

                /* Note that each armor or weapon can be separate, so we only use quantity 1 here. */
                /* 10.1 -> Add Weapons*/
                List<PlayerWeapon> wList = userControlGenericEquipmentList1.getWeaponList();
                List<PlayerWeapon> duplicatesList = new List<PlayerWeapon>();

                foreach(PlayerWeapon w in wList)
                {
                    if (w.Quantity > 1)
                    {
                        int total = w.Quantity;
                        for (int x = total; x > 1; x--)
                        {
                            PlayerWeapon duplicate = w.Clone();
                            duplicate.Quantity = 1;
                            duplicatesList.Add(duplicate);
                            w.Quantity--;
                        }                        
                    }
                }

                foreach(PlayerWeapon w in duplicatesList)
                {
                    wList.Add(w);
                }
                CreatedCharacter.CharacterWeapons = wList;

                /*10.2 -> Add Armor*/
                List<PlayerArmor> aList = userControlGenericEquipmentList1.getArmorList();
                List<PlayerArmor> duplicateArmorList = new List<PlayerArmor>();

                foreach (PlayerArmor a in aList)
                {
                    if (a.Quantity > 1)
                    {
                        int total = a.Quantity;
                        for (int x = total; x > 1; x--)
                        {
                            PlayerArmor duplicate = a.Clone();
                            duplicate.Quantity = 1;
                            duplicateArmorList.Add(duplicate);
                            a.Quantity--;
                        }
                    }
                }

                foreach (PlayerArmor a in duplicateArmorList)
                {
                    aList.Add(a);
                }
                CreatedCharacter.CharacterArmors = aList;

                /* 10.3 Add generic Equipment and tools. */
                CreatedCharacter.CharacterGeneralEquipment = userControlGenericEquipmentList1.getAllGeneralEquipment();
            }
            else
            {
                res = false;
            }

            return res;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            String msg;
            if (CreateCharacter(out msg))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(msg);
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

            if (SelectedMainRace != null)
            {
                foreach (String aProf in SelectedMainRace.ArmorProficiencies)
                {
                    res.Add(aProf);
                }
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

            if (SelectedMainRace != null) 
            { 
                foreach (String wProf in SelectedMainRace.WeaponProficiencies)
                {
                    res.Add(wProf);
                }
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

        private void updateCustomRacialBonusAttributes()
        {
            //Extra attribute points might be spent for half-elves and potentially other races. 
            maxExtraAttributes = SelectedMainRace.NumberOfGenericBonusAttributes;
            if (SelectedSubRace != null)
            {
                maxExtraAttributes += SelectedSubRace.NumberOfGenericBonusAttributes;
            }
            currentExtraAttributes = maxExtraAttributes;
            labelCustomRacialAttributeBonus.Text = currentExtraAttributes.ToString();

            if (maxExtraAttributes > 0)
            {
                labelExtraBonus.Visible = true;
                
                //Current rule is that only the attributes that have not already been increased by racial bonus can be increased in this way.
                if (SelectedMainRace.BonusAttributes.STR == 0 && ((SelectedSubRace?.BonusAttributes.STR == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupSTR.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupSTR.setCustomBonusVisible(false);
                }

                if (SelectedMainRace.BonusAttributes.DEX == 0 && ((SelectedSubRace?.BonusAttributes.DEX == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupDEX.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupDEX.setCustomBonusVisible(false);
                }

                if (SelectedMainRace.BonusAttributes.CON == 0 && ((SelectedSubRace?.BonusAttributes.CON == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupCON.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupCON.setCustomBonusVisible(false);
                }

                if (SelectedMainRace.BonusAttributes.INT == 0 && ((SelectedSubRace?.BonusAttributes.INT == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupINT.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupINT.setCustomBonusVisible(false);
                }

                if (SelectedMainRace.BonusAttributes.WIS == 0 && ((SelectedSubRace?.BonusAttributes.WIS == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupWIS.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupWIS.setCustomBonusVisible(false);
                }

                if (SelectedMainRace.BonusAttributes.CHA == 0 && ((SelectedSubRace?.BonusAttributes.CHA == 0) || SelectedSubRace == null))
                {
                    userControlAttributeSetupCHA.setCustomBonusVisible(true);
                }
                else
                {
                    userControlAttributeSetupCHA.setCustomBonusVisible(false);
                }
            }
            else
            {
                labelExtraBonus.Visible = false;
                userControlAttributeSetupSTR.setCustomBonusVisible(false);
                userControlAttributeSetupDEX.setCustomBonusVisible(false);
                userControlAttributeSetupINT.setCustomBonusVisible(false);
                userControlAttributeSetupCON.setCustomBonusVisible(false);
                userControlAttributeSetupWIS.setCustomBonusVisible(false);
                userControlAttributeSetupCHA.setCustomBonusVisible(false);
            }
        }

        private void updateAllDisplayedData()
        {
            //TODO : Create a base attribute display class. 
            //1. Lets begin with the selected race and subrace
            if (SelectedMainRace != null)
            {
                userControlAttributeSetupSTR.AttributeBonus = SelectedMainRace.BonusAttributes.STR;
                userControlAttributeSetupINT.AttributeBonus = SelectedMainRace.BonusAttributes.INT;
                userControlAttributeSetupWIS.AttributeBonus = SelectedMainRace.BonusAttributes.WIS;
                userControlAttributeSetupCON.AttributeBonus = SelectedMainRace.BonusAttributes.CON;
                userControlAttributeSetupCHA.AttributeBonus = SelectedMainRace.BonusAttributes.CHA;
                userControlAttributeSetupDEX.AttributeBonus = SelectedMainRace.BonusAttributes.DEX;
            }

            if (SelectedSubRace != null)
            {
                userControlAttributeSetupSTR.AttributeBonus += SelectedSubRace.BonusAttributes.STR;
                userControlAttributeSetupINT.AttributeBonus += SelectedSubRace.BonusAttributes.INT;
                userControlAttributeSetupINT.AttributeBonus += SelectedSubRace.BonusAttributes.WIS;
                userControlAttributeSetupINT.AttributeBonus += SelectedSubRace.BonusAttributes.CON;
                userControlAttributeSetupINT.AttributeBonus += SelectedSubRace.BonusAttributes.CHA;
                userControlAttributeSetupINT.AttributeBonus += SelectedSubRace.BonusAttributes.DEX;
            }

            //2. Lets next try showing weapon and armor proficiencies...
            //TODO : This is just a test, we really should make the proficiency and attribute displays into a separate class.
            richTextBoxProficiencyTest.Clear();
            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Bold);
            richTextBoxProficiencyTest.AppendText("Weapon Proficiencies:\n");
            richTextBoxProficiencyTest.SelectionFont = new Font(richTextBoxProficiencyTest.Font, FontStyle.Regular);

            List<String> wProfList = getAllWeaponProficiencies();

            if (wProfList != null)
            {
                foreach (String wProf in wProfList)
                {
                    richTextBoxProficiencyTest.AppendText(wProf + "\n");
                }
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
            UpdateHitPoints(true);

            //5. Update saving throw values.
            updateSavingThrowFields();

            //6. Update skill proficiency values.
            updateSkillProficiencyFields();

            //7. Update the generic abilities list.
            updateGenericAbilitiesField();

            //8. Update the passive perception
            UpdatePassivePerception(true);

            //TODO : Update other issues.
            String msg;
            //Final step, we resolve the special attributes. For this we need to try and create a test character.
            if (CreateCharacter(out msg) == true && CreatedCharacter != null)
            {
                CreatedCharacter.finalizeCharacterCreation();

                //So now we should have a proper character. But we might have changed some displayed data.
                /* TODO : A bit of a chicken and egg problem. Basically we should update all field that might be affected by the special abilities.*/
                currentMaxHp = CreatedCharacter.MaxHitPoints;
                
                /* These might have been changed by special attributes. TODO : Probably there are other special attributes to take into account.. */
                UpdateHitPoints(false);
            }
        }

        private void UpdateToolProficiencyChoices()
        {
            List<String> myChoices = new List<String>();

            if (SelectedMainRace == null)
            {
                return;
            }

            foreach (string str in SelectedMainRace.ToolProficiencies)
            {
                myChoices.Add(str);
            }

            //Not sure if this part is actually needed...
            if (SelectedSubRace != null)
            {
                foreach(string str in SelectedSubRace.ToolProficiencies)
                {
                    myChoices.Add(str);
                }
            }

            userControlToolProficiencyChoice1.setChoices(myChoices);
        }

        private void UpdateHitPoints(bool updateValue)
        {
            if (updateValue)
            {
                if (SelectedClass != null)
                {
                    textBoxHitDie.Text = "1d" + SelectedClass.HitDie;
                    int constitution = userControlAttributeSetupCON.TotalAttributeValue;
                    int bonus = CharacterFactory.getAbilityModifierValue(constitution);
                    currentMaxHp = bonus + SelectedClass.HitDie;
                }
            }
            textBoxHitPoints.Text = currentMaxHp.ToString();
        }


        private void UpdatePassivePerception(bool updateValue)
        {
            if (updateValue)
            {
                currentPassivePerception = 10 + userControlSkillProficiencies1.getTotalSkillBonus("Perception");
            }
            textBoxPassivePerception.Text = currentPassivePerception.ToString();
        }

        private void updateGenericAbilitiesField()
        {
            /*1. Add main race abilities. */
            myAttributeList.Clear();

            if (SelectedMainRace == null)
            {
                return;
            }

            foreach (PlayerAbility attrib in SelectedMainRace.getPlayerAttributes())
            {
                myAttributeList.Add(attrib);
            }

            /* 2. Add subrace abilities. */
            if (SelectedSubRace != null)
            {
                foreach (PlayerAbility attrib in SelectedSubRace.getPlayerAttributes())
                {
                    myAttributeList.Add(attrib);
                }
            }


            /* 3. Add class based abilities. */
            if (SelectedClass != null)
            {
                if (myChooseClassFeaturesForm != null)
                {
                    /* TODO */
                    List<PlayerAbility> classAbilities = myChooseClassFeaturesForm.getAllSelectedAbilities();
                    foreach(PlayerAbility ability in classAbilities)
                    {
                        myAttributeList.Add(ability);
                    }
                }
            }

            userControlGenericAttributeList1.setAttributeList(myAttributeList);
        }

        /* TODO : Rename this to prevent confusion. */
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
                    res = userControlAttributeSetupSTR.TotalAttributeValue;
                    break;
                case "CHA":
                    res = userControlAttributeSetupCHA.TotalAttributeValue;
                    break;
                case "DEX":
                    res = userControlAttributeSetupDEX.TotalAttributeValue;
                    break;
                case "CON":
                    res = userControlAttributeSetupCON.TotalAttributeValue;
                    break;
                case "WIS":
                    res = userControlAttributeSetupWIS.TotalAttributeValue;
                    break;
                case "INT":
                    res = userControlAttributeSetupINT.TotalAttributeValue;
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

        private void updateEquipmentList()
        {
            //richTextBoxEquipmentAndSpells.Clear();

            /* TODO : Consider making these lists global? */
            List<Items.PlayerWeapon> weaponList = new List<Items.PlayerWeapon>();
            List<Items.PlayerArmor> armorList = new List<Items.PlayerArmor>();
            List<Items.PlayerItem> equipmentList = new List<Items.PlayerItem>();


            /* 1. Get all equipment from the equipment selection form. */
            myItemList = new List<PlayerItem>();

            foreach(PlayerItem item in myChooseEquipmentForm.SelectedItems)
            {
                myItemList.Add(item);
            }

            /* 2. Get all the equipment from the background selection form. */
            /* TODO */
            List<PlayerItem> characterBackGroundItems = myChooseBackGroundForm.getAllBackGroundEquipment();
            foreach(PlayerItem item in characterBackGroundItems)
            {
                myItemList.Add(item);
            }

            /* Display weapons, armor and generic equipment separately. */
            foreach (Items.PlayerItem item in myItemList)
            {
                if (item is Items.PlayerWeapon)
                {
                    weaponList.Add((Items.PlayerWeapon)item);
                }
                else if(item is Items.PlayerArmor)
                {
                    armorList.Add((Items.PlayerArmor)item);
                }
                else
                {
                    equipmentList.Add(item);
                }
            }

            userControlGenericEquipmentList1.setEquipmentList(myItemList);

            /* 4. Add tools */
            /* TODO */
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

        private void updateFixedSpells()
        {
            List<PlayerSpell> fixedPlayerSpells = new List<PlayerSpell>();
            
            if (SelectedMainRace != null)
            {
                fixedPlayerSpells = fixedPlayerSpells.Union(SelectedMainRace.getPlayerSpells()).ToList();
            }

            if (SelectedSubRace != null)
            {
                fixedPlayerSpells = fixedPlayerSpells.Union(SelectedSubRace.getPlayerSpells()).ToList();
            }

            myChooseSpellsForm.setFixedSpells(fixedPlayerSpells);
        }

        private void updateSkillProficiencies()
        {
            //1. Reset the controls
            userControlSkillProficiencies1.resetControls();

            List<String> racialProficiencies = new List<string>();
            List<string> bgSkillProfs = myChooseBackGroundForm.getAllSkillProficiencies();

            if (SelectedMainRace != null)
            {
                foreach (String prof in SelectedMainRace.SkillProficiencies)
                {
                    racialProficiencies.Add(prof);
                }
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

            //3. Lets get the skill proficiencies from background.
            if (myChooseBackGroundForm != null)
            {
               

                foreach(String prof in bgSkillProfs)
                {
                    if (!userControlSkillProficiencies1.setProficientAtSkill(prof))
                    {
                        MessageBox.Show("Incorrect skill proficiency : " + prof + ", failed to parse");
                    }
                }
            }

            //4. Set up choosing new skill proficiencies.
            if (SelectedClass != null)
            {
                int numberOfSkillsToChoose = SelectedClass.NumberOfSkillsToChoose;
                int numberOfSkillsToChooseAny = 0; 
                
                if( SelectedMainRace != null)
                {
                    numberOfSkillsToChooseAny += SelectedMainRace.NumberOfGenericSkillProficiencies;
                }

                if (SelectedSubRace != null)
                {
                    numberOfSkillsToChooseAny += SelectedSubRace.NumberOfGenericSkillProficiencies;
                }

                List<string> availableSkillsToChoose = new List<string>();

                foreach (string skill in SelectedClass.AvailableSkillProficiencies)
                {
                    if (!racialProficiencies.Contains(skill) && !bgSkillProfs.Contains(skill))
                    {
                        availableSkillsToChoose.Add(skill);
                    }
                }

                userControlSkillProficiencies1.setUpChoiceProficiencies(numberOfSkillsToChoose, availableSkillsToChoose, numberOfSkillsToChooseAny);
            }
        }


        private void baseAttribute_ValueChanged(object sender, EventArgs e)
        {
            //Lets first handle the extra racial bonus attributes
            if (maxExtraAttributes > 0)
            {
                int usedExtraAttributes = 0;
                if (userControlAttributeSetupSTR.isCustomBonusSelected()) { usedExtraAttributes++; }
                if (userControlAttributeSetupDEX.isCustomBonusSelected()) { usedExtraAttributes++; }
                if (userControlAttributeSetupCON.isCustomBonusSelected()) { usedExtraAttributes++; }
                if (userControlAttributeSetupCHA.isCustomBonusSelected()) { usedExtraAttributes++; }
                if (userControlAttributeSetupWIS.isCustomBonusSelected()) { usedExtraAttributes++; }
                if (userControlAttributeSetupINT.isCustomBonusSelected()) { usedExtraAttributes++; }

                currentExtraAttributes = maxExtraAttributes - usedExtraAttributes;

                if (currentExtraAttributes == 0)
                {
                    //Lock the checkboxes.
                    if (!userControlAttributeSetupSTR.isCustomBonusSelected()) { userControlAttributeSetupSTR.setCustomBonusLock(true); }
                    if (!userControlAttributeSetupDEX.isCustomBonusSelected()) { userControlAttributeSetupDEX.setCustomBonusLock(true); }
                    if (!userControlAttributeSetupCON.isCustomBonusSelected()) { userControlAttributeSetupCON.setCustomBonusLock(true); }
                    if (!userControlAttributeSetupINT.isCustomBonusSelected()) { userControlAttributeSetupINT.setCustomBonusLock(true); }
                    if (!userControlAttributeSetupWIS.isCustomBonusSelected()) { userControlAttributeSetupWIS.setCustomBonusLock(true); }
                    if (!userControlAttributeSetupCHA.isCustomBonusSelected()) { userControlAttributeSetupCHA.setCustomBonusLock(true); }
                }
                else
                {
                    //Unlock the checkboxes.
                    userControlAttributeSetupSTR.setCustomBonusLock(false); 
                    userControlAttributeSetupDEX.setCustomBonusLock(false); 
                    userControlAttributeSetupCON.setCustomBonusLock(false); 
                    userControlAttributeSetupINT.setCustomBonusLock(false); 
                    userControlAttributeSetupWIS.setCustomBonusLock(false); 
                    userControlAttributeSetupCHA.setCustomBonusLock(false); 
                }

                labelCustomRacialAttributeBonus.Text = currentExtraAttributes.ToString();
                
            }
            
            updateAllDisplayedData();
        }

        private void comboBoxMainRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainRace.Items.Count > 0)
            {
                String selectedItem = comboBoxMainRace.SelectedItem.ToString();
                comboBoxSubRace.Items.Clear();
                comboBoxSubRace.SelectedIndex = -1;
                comboBoxSubRace.Text = String.Empty;
                SelectedSubRace = null;

                List<String> subRaceNames = CharacterFactory.getSubRaceList(selectedItem);

                foreach (String str in subRaceNames)
                {
                    comboBoxSubRace.Items.Add(str);
                }

                SelectedMainRace = CharacterFactory.getRaceByName(comboBoxMainRace.SelectedItem.ToString());
                UpdateToolProficiencyChoices();
                updateCustomRacialBonusAttributes();
                updateSkillProficiencies();
                updateFixedSpells();
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
                    SelectedSubRace = CharacterFactory.getSubRaceByName(mainRace, selectedItem);
                    UpdateToolProficiencyChoices();
                    updateFixedSpells();
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
                    SelectedClass = CharacterFactory.getPlayerClassByName(selectedItem);
                    updateAllDisplayedData();
                    /* There is a difference between resetting and updating these values. Update should be done elsewhere... */
                    updateSkillProficiencies();

                    /* Reset all equipment choices. */
                    myChooseEquipmentForm = new FormChooseEquipment();
                    updateEquipmentList();
                }
            }
        }

        //Called when a proficiency value is manually changed.
        private void proficienciesChanged()
        {
            UpdatePassivePerception(true);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonChooseEquipment_Click(object sender, EventArgs e)
        {
            if (SelectedClass == null)
            {
                MessageBox.Show("No class selected");
                return;
            }

            //FormChooseEquipment myForm = new FormChooseEquipment();
            if (myChooseEquipmentForm.SelectedClass != SelectedClass)
            {
                /* We reset the data in this case. */
                myChooseEquipmentForm = new FormChooseEquipment();
                myChooseEquipmentForm.SelectedClass = SelectedClass;
            }
            
            if (myChooseEquipmentForm.ShowDialog() == DialogResult.OK)
            {
                //myItemList = myChooseEquipmentForm.SelectedItems;

                /* Add the items to display. */
                updateEquipmentList();
            }
        }

        private void buttonChooseBackGround_Click(object sender, EventArgs e)
        { 
            if (myChooseBackGroundForm.ShowDialog() == DialogResult.OK)
            {
                updateEquipmentList();
                updateSkillProficiencies();

                if (myChooseBackGroundForm.SelectedBackGround != null) 
                {
                    textBoxBackGround.Text = myChooseBackGroundForm.SelectedBackGround.BackGroundName;
                }
                else
                {
                    textBoxBackGround.Text = "None";
                }
                /* TODO : Should also update the known languages, and well display them somewhere... */
            }
        }

        private void buttonChooseClassFeatures_Click(object sender, EventArgs e)
        {
            /* TODO */
            if (SelectedClass == null)
            {
                MessageBox.Show("No class selected");
                return;
            }

            myChooseClassFeaturesForm.setSelectedClass(SelectedClass);

            if (myChooseClassFeaturesForm.ShowDialog() == DialogResult.OK)
            {
                updateGenericAbilitiesField();
            }
        }

        private void buttonChooseSpells_Click(object sender, EventArgs e)
        {
            if (SelectedClass == null)
            {
                MessageBox.Show("No class selected");
                return;
            }

            if (SelectedClass.SpellCasting == null)
            {
                MessageBox.Show("No spellcasting for this class");
                return;
            }

            myChooseSpellsForm.setSpellChoices(SelectedClass);
            if (myChooseSpellsForm.ShowDialog() == DialogResult.OK)
            {
                /* TODO */
            }

        }
    }
}
