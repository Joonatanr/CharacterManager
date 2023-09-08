using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using CharacterManager.CharacterCreator;
using CharacterManager.Items;
using CharacterManager.Spells;
using CharacterManager.UserControls;

namespace CharacterManager
{
    public partial class Form1 : Form
    {
        private PlayerCharacter activeCharacter = null;

        public Form1()
        {
            InitializeComponent();
            CharacterFactory.setErrorHandler(new TextBoxWriter(richTextBoxConsole));
            CharacterFactory.Initialize();

            userControlHitPoints1.HitPointsChangedListener = new UserControlHitPoints.HitPointsChanged(HitPointsChanged);
            
            userControlCurrencyCopper.CurrencyAmountChanged = new UserControls.MainForm.UserControlCurrency.CurrencyAmountChangedListener(GoldChanged);
            userControlCurrencySilver.CurrencyAmountChanged = new UserControls.MainForm.UserControlCurrency.CurrencyAmountChangedListener(GoldChanged);
            userControlCurrencyGold.CurrencyAmountChanged = new UserControls.MainForm.UserControlCurrency.CurrencyAmountChangedListener(GoldChanged);
            userControlCurrencyElectrum.CurrencyAmountChanged = new UserControls.MainForm.UserControlCurrency.CurrencyAmountChangedListener(GoldChanged);
            userControlCurrencyPlatinum.CurrencyAmountChanged = new UserControls.MainForm.UserControlCurrency.CurrencyAmountChangedListener(GoldChanged);
            
            GlobalEvents.MagicDiceRolledListener = handleRollReport;
            GlobalEvents.SpellSlotLevelAvailableChecker = isSpellSlotWithLevelAvailable;
            GlobalEvents.CastSpellExternal = handleCastSpell;
            GlobalEvents.GetActiveCharacterExternal = getActiveCharacter;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private bool isSpellSlotWithLevelAvailable(int level)
        {
            return userControlMagicHandler1.IsSpellSlotsAvailableOfLevel(level);
        }

        private void handleCastSpell(PlayerSpell spell, int level)
        {
            /* TODO : Might add some kind of spell effects etc.. For now we will just reduce the spell slots. */
            activeCharacter.CharacterSpellCastingStatus.SpendSpellSlot(level);
            userControlMagicHandler1.UpdateAllDisplayedData();
        }

        private PlayerCharacter getActiveCharacter()
        {
            return activeCharacter;
        }

        private void GoldChanged(int amount)
        {
            if(activeCharacter != null)
            {
                activeCharacter.CopperPieces = userControlCurrencyCopper.CurrencyAmount;
                activeCharacter.SilverPieces = userControlCurrencySilver.CurrencyAmount;
                activeCharacter.GoldPieces = userControlCurrencyGold.CurrencyAmount;
                activeCharacter.ElectrumPieces = userControlCurrencyElectrum.CurrencyAmount;
                activeCharacter.PlatinumPieces = userControlCurrencyPlatinum.CurrencyAmount;
            }
        }


        /************* private methods*****************/


        private void updateCharacterAttributes()
        {
            if (this.activeCharacter != null)
            {
                //1. Update character name and other basic things.
                this.textBoxName.Text = activeCharacter.CharacterName;

                if (string.IsNullOrEmpty(activeCharacter.SubClassName))
                {
                    this.textBoxClass.Text = activeCharacter.ClassName;
                }
                else
                {
                    this.textBoxClass.Text = activeCharacter.ClassName + "(" + activeCharacter.SubClassName + ")";
                }


                if (activeCharacter.SubRaceName == null)
                {
                    textBoxRace.Text = activeCharacter.MainRaceName;
                }
                else
                {
                    textBoxRace.Text = activeCharacter.SubRaceName;
                }

                this.textBoxXP.Text = activeCharacter.ExperiencePoints.ToString();
                this.textBoxLevel.Text = activeCharacter.Level.ToString();
                this.textBoxProfBonus.Text = activeCharacter.ProficiencyBonus.ToString();

                //2. Update base attributes
                this.AttributeDisplaySTR.AttributeValue = activeCharacter.StrengthAttribute;
                this.AttributeDisplayINT.AttributeValue = activeCharacter.IntAttribute;
                this.AttributeDisplayDEX.AttributeValue = activeCharacter.DexAttribute;
                this.AttributeDisplayCON.AttributeValue = activeCharacter.ConAttribute;
                this.AttributeDisplayWIS.AttributeValue = activeCharacter.WisAttribute;
                this.AttributeDisplayCHA.AttributeValue = activeCharacter.CharAttribute;

                //3. Update saving throws.
                userControlSavingThrows1.setValue(activeCharacter.getModifier("STR"), activeCharacter.isSavingThrowProficientIn("STR"), activeCharacter.ProficiencyBonus, "STR");
                userControlSavingThrows1.setValue(activeCharacter.getModifier("INT"), activeCharacter.isSavingThrowProficientIn("INT"), activeCharacter.ProficiencyBonus, "INT");
                userControlSavingThrows1.setValue(activeCharacter.getModifier("DEX"), activeCharacter.isSavingThrowProficientIn("DEX"), activeCharacter.ProficiencyBonus, "DEX");
                userControlSavingThrows1.setValue(activeCharacter.getModifier("CON"), activeCharacter.isSavingThrowProficientIn("CON"), activeCharacter.ProficiencyBonus, "CON");
                userControlSavingThrows1.setValue(activeCharacter.getModifier("WIS"), activeCharacter.isSavingThrowProficientIn("WIS"), activeCharacter.ProficiencyBonus, "WIS");
                userControlSavingThrows1.setValue(activeCharacter.getModifier("CHA"), activeCharacter.isSavingThrowProficientIn("CHA"), activeCharacter.ProficiencyBonus, "CHA");

                //4. Update skill bonuses.

                userControlSkillProficiencies1.ConnectToPlayerCharacter(activeCharacter);

                //5. Update Player alignment.
                String alignmentString = activeCharacter.Alignment.ToString();
                for(int x = 1; x < alignmentString.Length; x++)
                {
                    if (char.IsUpper(alignmentString[x]))
                    {
                        alignmentString = alignmentString.Insert(x, " ");
                        break;
                    }
                }

                //6. Update Hit Points.
                UpdateHitPoints();

                //7. Update character alignment.
                textBoxAlignment.Text = alignmentString;

                //8. Update character abilities.
                UpdateCharacterAbilities();

                //9.1 Update Weapon and armor Proficiencies.
                userControlWeaponProficiencylist.setProficiencylist(activeCharacter.getAllWeaponAndArmorProficiencies());

                //9.2 Update Tool Proficiencies.
                userControlToolProficiencies.setProficiencylist(activeCharacter.ToolProficiencies);

                //9.3 Update Language Proficiencies.
                userControlLanguageProficiencies.setProficiencylist(activeCharacter.Languages);

                //10. Update weapons.
                UpdateWeaponDisplay();

                //11. Update armors.
                UpdateArmorDisplay();

                //12. Update general inventory.
                UpdateGeneralEquipmentDisplay();


                //12.1 Update general currency.
                userControlCurrencyElectrum.CurrencyAmount = activeCharacter.ElectrumPieces;
                userControlCurrencyGold.CurrencyAmount = activeCharacter.GoldPieces;
                userControlCurrencyCopper.CurrencyAmount = activeCharacter.CopperPieces;
                userControlCurrencyPlatinum.CurrencyAmount = activeCharacter.PlatinumPieces;
                userControlCurrencySilver.CurrencyAmount = activeCharacter.SilverPieces;

                //13. Update initiative bonus.
                updateInitiativeBonus();

                //14. Update Magic and Spellcasting.
                if (activeCharacter.IsCharacterSpellCasting())
                {
                    userControlMagicHandler1.Visible = true;
                    this.activeCharacter.UpdateSpellModifiers();
                    userControlMagicHandler1.setCharSpellcastingStatus(this.activeCharacter.CharacterSpellCastingStatus);
                }
                else
                {
                    userControlMagicHandler1.Visible = false;
                    userControlMagicHandler1.setCharSpellcastingStatus(null);
                }

                //15. Update passive perception and speed.
                List<BonusValueModifier> PassivePerceptionModifiers = activeCharacter.PassivePerceptionModifiers;
                userControlPassivePerception.setBonusValueModifiers(PassivePerceptionModifiers);

                List<BonusValueModifier> totalSpeedModifiers = new List<BonusValueModifier>();
                totalSpeedModifiers.Add(new BonusValueModifier("base speed", activeCharacter.Speed));
                totalSpeedModifiers.AddRange(activeCharacter.BonusValues.SpeedModifiers);

                userControlSpeed.setBonusValueModifiers(totalSpeedModifiers);
            }
        }

        private void UpdateWeaponDisplay()
        {
            userControlWeaponsHandler1.setWeaponList(activeCharacter.CharacterWeapons);
        }

        private void UpdateArmorDisplay()
        {
            userControlArmorHandler1.setArmorList(activeCharacter.CharacterArmors);
            userControlArmorHandler1.ArmorEquipChanged = armorEquippedChanged;
            userControlArmorHandler1.ArmorDropped = armorDropped;
            updateArmorClass();
        }

        private void UpdateGeneralEquipmentDisplay()
        {
            userControlEquipmentHandler1.setGeneralEquipmentList(activeCharacter.CharacterGeneralEquipment);
            userControlEquipmentHandler1.ItemDropEvent = itemDropped;
        }

        private void UpdateHitPoints()
        {
            userControlHitPoints1.MaxHitPoints = activeCharacter.MaxHitPoints;
            userControlHitPoints1.CurrentHitPoints = activeCharacter.CurrentHitPoints;

            userControlhitDice1.RemainingHitDice = activeCharacter.CurrentHitDice;
            userControlhitDice1.MaxHitDice = activeCharacter.Level;
            userControlhitDice1.DieType = activeCharacter.GetPlayerClass().HitDie;
        }

        private void UpdateCharacterAbilities()
        {
            userControlGenericAbilitiesList1.setAttributeList(activeCharacter.CharacterAbilitiesObjectList);
        }

        private void updateInitiativeBonus()
        {
            int bonus = activeCharacter.getModifier("DEX");
            if (bonus >= 0)
            {
                userControlInitiative.Value = "+" + bonus.ToString();
            }
            else
            {
                userControlInitiative.Value = bonus.ToString();
            }
        }

        private void itemDropped(PlayerItem item)
        {
            activeCharacter.DropItem(item);
            userControlEquipmentHandler1.setGeneralEquipmentList(activeCharacter.CharacterGeneralEquipment);
        }

        private void armorDropped(PlayerArmor armor)
        {
            activeCharacter.DropArmor(armor);
            userControlArmorHandler1.setArmorList(activeCharacter.CharacterArmors);
            updateArmorClass();
        }

        private void armorEquippedChanged(PlayerArmor armor)
        {
            updateArmorClass();

            int hands = 2;

            if (armor.IsShield)
            {
                /* If we equipped a shield, then we will need to check if we are using 2H weapons */
                /* TODO */
                if (armor.IsEquipped)
                {
                    hands--;
                }

                foreach (Items.PlayerWeapon weapon in activeCharacter.CharacterWeapons)
                {
                    if (weapon.IsEquipped)
                    {
                        if (!weapon.IsEquippedTwoHanded)
                        {
                            if (hands > 0)
                            {
                                hands--;
                            }
                            else
                            {
                                weapon.setEquipped(false, false);
                            }
                        }
                        else
                        {
                            weapon.setEquipped(false, false);
                        }
                    }
                }

                userControlWeaponsHandler1.updateEquipStatus();
            }
        }

        private void updateArmorClass()
        {
            List<BonusValueModifier> acMods;
            int ac = activeCharacter.getCurrentArmorClassModifiers(out acMods);
            
            userControlArmorClass.Value = ac.ToString();
            userControlArmorClass.ToolTip = BonusValueModifier.getToolTipStringFromList(acMods);
        }

        private void LoadCharacter(PlayerCharacter c)
        {
            activeCharacter = c;
            c.CharacterHPChanged += characterHpChangedListener;
            c.CharacterHitDieChanged += C_CharacterHitDieChanged;
            updateCharacterAttributes();

            /* Set up listener functions */
            /* TODO */
        }

        private void C_CharacterHitDieChanged(PlayerCharacter c)
        {
            UpdateHitPoints();
        }

        /*********************** Listener functions ***********************/
        /* TODO : We should move everything that's possible to this logic here. */
        private void characterHpChangedListener(PlayerCharacter c)
        {
            UpdateHitPoints();
        }

        /*************** Button functions *************/

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            /* New character creation - TODO, this is only a placeholder. */
            CharacterCreatorForm f2 = new CharacterCreatorForm();

            if (f2.ShowDialog() == DialogResult.OK)
            {
                LoadCharacter(f2.CreatedCharacter);
                

            }
        }

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            if (activeCharacter != null)
            {
                activeCharacter.PrepareDataForSaving();

                /* We save the character into an XML format. */
                XmlSerializer xSubmit = new XmlSerializer(typeof(PlayerCharacter));
                saveFileDialog1.DefaultExt = ".character";
                saveFileDialog1.FileName = activeCharacter.CharacterName + ".character";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (var sww = new StreamWriter(saveFileDialog1.FileName))
                    {
                        XmlWriterSettings settings = new XmlWriterSettings();
                        settings.OmitXmlDeclaration = true;
                        settings.Indent = true;
                        settings.NewLineOnAttributes = true;

                        using (XmlWriter writer = XmlWriter.Create(sww, settings))
                        {
                            xSubmit.Serialize(writer, activeCharacter);
                            sww.Flush();
                        }
                    }
                }
            }
        }

        private void toolStripButtonLoad_Click(object sender, EventArgs e)
        {
            /** Load a file. */
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PlayerCharacter loadedCharacter = CharacterFactory.LoadFromXml(openFileDialog1.FileName);
                LoadCharacter(loadedCharacter);
            }
        }

        private void AttributeDisplayINT_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void userControlWeaponsHandler1_WeaponAttackEvent(Items.PlayerWeapon w)
        {
            if (activeCharacter != null)
            {
                FormWeaponAttack weaponForm = new FormWeaponAttack();

                List<BonusValueModifier> attackModifiers;
                List<BonusValueModifier> damageModifiers;

                bool isAttackOk = true;

                if (!w.IsEquipped)
                {
                    MessageBox.Show("Weapon not equipped.");
                    isAttackOk = false;
                }

                if (isAttackOk)
                {
                    activeCharacter.getWeaponAttackModifiers(w, out attackModifiers, out damageModifiers, false);
         
                    weaponForm.Weapon = w;
                    weaponForm.AttackModifiers = attackModifiers;
                    weaponForm.DamageModifiers = damageModifiers;
                    weaponForm.setCharacter(activeCharacter);
                    weaponForm.RollReporter = new DieRollTextBox.RollResultHandler(handleRollReport);

                    weaponForm.Show();
                    
                    userControlEquipmentHandler1.setGeneralEquipmentList(activeCharacter.CharacterGeneralEquipment);
                }
            }
        }


        private void userControlWeaponsHandler1_WeaponDropEvent(PlayerWeapon w)
        {
            activeCharacter.DropWeapon(w);
            userControlWeaponsHandler1.setWeaponList(activeCharacter.CharacterWeapons);
        }

        private void handleRollReport(string text, Color textColour, Boolean isBold, HorizontalAlignment alignment)
        {
            RichTextBoxExtensions.AppendFormattedText(richTextBoxConsole, text, textColour, isBold, alignment);
            richTextBoxConsole.ScrollToCaret();
        }

        private void userControlWeaponsHandler1_WeaponEquipEvent(Items.PlayerWeapon w)
        {
            int hands = 2;

            if (w.IsEquipped)
            {
                if (w.IsEquippedTwoHanded)
                {
                    hands -= 2;
                }
                else
                {
                    hands--;
                }
            }

            /* Lets first consider Shield */
            foreach (PlayerArmor armor in activeCharacter.CharacterArmors)
            {
                if (armor.IsShield && armor.IsEquipped)
                {
                    if (hands < 1)
                    {
                        armor.IsEquipped = false;
                        updateArmorClass();
                    }
                    else
                    {
                        hands--;
                    }
                }
            }

            foreach (Items.PlayerWeapon weapon in activeCharacter.CharacterWeapons)
            {
                if (weapon != w)
                {
                    if (weapon.IsEquipped)
                    {
                        if (!weapon.IsEquippedTwoHanded)
                        {
                            if(hands > 0)
                            {
                                hands--;
                            }
                            else
                            {
                                weapon.setEquipped(false, false);
                            }
                        }
                        else
                        {
                            weapon.setEquipped(false, false);
                        }
                    }
                }
            }

            userControlWeaponsHandler1.updateEquipStatus();
            userControlArmorHandler1.updateEquippedStatus();
        }

        private void buttonLongRest_Click(object sender, EventArgs e)
        {
            /* TODO */
            activeCharacter.PerformLongRest();
            /* TODO : Maybe we can do this with a listener function? */
            UpdateCharacterAbilities();
            userControlMagicHandler1.UpdateAllDisplayedData();
        }

        private void buttonShortRest_Click(object sender, EventArgs e)
        {
            activeCharacter.PerformShortRest();
            UpdateCharacterAbilities();
        }

        private void HitPointsChanged(int hp)
        {
            if (activeCharacter == null)
            {
                return;
            }

            activeCharacter.CurrentHitPoints = hp;
            if (activeCharacter.CurrentHitPoints < 0)
            {
                activeCharacter.CurrentHitPoints = 0;
                UpdateHitPoints();
                /* TODO : Might have to handle PC death at this point, but maybe it's actually not necessary. */
            }
        }

        private void buttonAddXp_Click(object sender, EventArgs e)
        {
            FormAddXp myXpForm = new FormAddXp();
            
            if(activeCharacter != null)
            {
                myXpForm.CurrentXp = activeCharacter.ExperiencePoints;
                myXpForm.CurrentLevel = activeCharacter.Level; 
            }
            
            myXpForm.ShowDialog();

            if (activeCharacter != null)
            {
                if (myXpForm.DialogResult == DialogResult.OK)
                {
                    activeCharacter.ExperiencePoints = myXpForm.CurrentXp;

                    if (myXpForm.CurrentLevel > activeCharacter.Level)
                    {
                        /* TODO : Handle case where we somehow level up several times. Could happen with a lot of XP. */
                        activeCharacter.Level = myXpForm.CurrentLevel;
                        activeCharacter.BonusValues.ResetLevelUpModifiers();
                        handleLevelUpCharacter();
                        updateCharacterAttributes();
                    }

                    this.textBoxXP.Text = activeCharacter.ExperiencePoints.ToString();
                    this.textBoxLevel.Text = activeCharacter.Level.ToString();
                }
            }
        }

        private void handleLevelUpCharacter()
        {
            /* TODO : Level up. */
            /* This is simply a placeholder. */
            /* Call this first to setup the level up process. */
            activeCharacter.setupCharacterLevelup();

            FormLevelup myForm = new FormLevelup(activeCharacter);
            myForm.ShowDialog();
        }

        private void makeSkillRoll(string skill)
        {
            string textResult;
            userControlSkillProficiencies1.RollSkill(skill, out textResult);
            string finalResult = skill + " : " + textResult;

            Color RollReportColor = Color.Black;
            bool isBold = false;

            if (finalResult.Contains("(D20)1 "))
            {
                isBold = true;
                RollReportColor = Color.Red;
            }
            else if (finalResult.Contains("(D20)20"))
            {
                isBold = true;
                RollReportColor = Color.Green;
            }

            handleRollReport(finalResult + Environment.NewLine, RollReportColor, isBold, HorizontalAlignment.Left);
        }

        /* Just for debugging. TODO : Remove this. */
        private void button1_Click(object sender, EventArgs e)
        {
            if (activeCharacter != null)
            {
                PlayerAbility myAbility = activeCharacter.CharacterAbilitiesObjectList.Find(ab => ab.Name == "Combat Superiority");
                if (myAbility != null)
                {
                    if (myAbility.RemainingCharges < myAbility.MaximumCharges)
                    {
                        myAbility.RemainingCharges++;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeCharacter != null)
            {
                PlayerAbility myAbility = activeCharacter.CharacterAbilitiesObjectList.Find(ab => ab.Name == "Combat Superiority");
                if (myAbility != null)
                {
                    if (myAbility.RemainingCharges > 0)
                    {
                        myAbility.RemainingCharges--;
                    }
                }
            }
        }

        private void buttonRollConsoleDice_Click(object sender, EventArgs e)
        {
            string rollResult;
            dieRollTextBox1.Roll(out rollResult);
            richTextBoxConsole.AppendText("Manual roll : " + rollResult + Environment.NewLine);
        }

        private void dieRollTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string rollResult;
                dieRollTextBox1.Roll(out rollResult);
                richTextBoxConsole.AppendText(rollResult + Environment.NewLine);
            }
        }

        private void buttonRollAcrobatics_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Acrobatics");
        }

        private void buttonRollAnimalHandling_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Animal Handling");
        }


        private void buttonRollArcana_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Arcana");
        }

        private void buttonRollAthletics_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Athletics");
        }

        private void buttonRollDeception_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Deception");
        }

        private void buttonRollHistory_Click(object sender, EventArgs e)
        {
            makeSkillRoll("History");
        }

        private void buttonRollInsight_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Insight");
        }

        private void buttonRollIntimidation_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Intimidation");
        }

        private void buttonRollInvestigation_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Investigation");
        }

        private void buttonRollMedicine_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Medicine");
        }

        private void buttonRollNature_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Nature");
        }

        private void buttonRollPerception_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Perception");
        }

        private void buttonRollPerformance_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Performance");
        }

        private void buttonRollPersuasion_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Persuasion");
        }

        private void buttonRollReligion_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Religion");
        }

        private void buttonRolSleightOfHand_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Sleight Of Hand");
        }

        private void buttonRollStealth_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Stealth");
        }

        private void buttonRollSurvival_Click(object sender, EventArgs e)
        {
            makeSkillRoll("Survival");
        }


        private void makeSavingThrowRoll(string save)
        {
            string textResult;
            userControlSavingThrows1.RollSavingThrow(save, out textResult);
            string finalResult = save + " save" + " : " + textResult;
            handleRollReport(finalResult + Environment.NewLine, Color.Black, false, HorizontalAlignment.Left);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            makeSavingThrowRoll("STR");
        }

        private void buttonRollDexSave_Click(object sender, EventArgs e)
        {
            makeSavingThrowRoll("DEX");
        }

        private void buttonIntSaveRoll_Click(object sender, EventArgs e)
        {
            makeSavingThrowRoll("INT");
        }

        private void buttonConSaveRoll_Click(object sender, EventArgs e)
        {
            makeSavingThrowRoll("CON");
        }

        private void buttonWisSaveRoll_Click(object sender, EventArgs e)
        {
            makeSavingThrowRoll("WIS");
        }

        private void buttonChaSaveRoll_Click(object sender, EventArgs e)
        {
            makeSavingThrowRoll("CHA");
        }

        private void handleAddItems()
        {
            FormAddItem myForm = new FormAddItem();
            myForm.ShowDialog();

            if (myForm.DialogResult == DialogResult.OK)
            {
                if (activeCharacter != null)
                {
                    PlayerItem addedItem = myForm.SelectedItem;

                    if (addedItem != null)
                    {
                        if (addedItem is PlayerWeapon)
                        {
                            activeCharacter.CharacterWeapons.Add((PlayerWeapon)addedItem);
                            UpdateWeaponDisplay();

                        }
                        else if (addedItem is PlayerArmor)
                        {
                            activeCharacter.CharacterArmors.Add((PlayerArmor)addedItem);
                            UpdateArmorDisplay();
                        }
                        else
                        {
                            activeCharacter.CharacterGeneralEquipment.Add(addedItem);
                            UpdateGeneralEquipmentDisplay();
                        }
                    }
                }
            }
        }

        private void buttonAddItems_Click(object sender, EventArgs e)
        {
            handleAddItems();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            handleAddItems();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            handleAddItems();
        }
        
        private void buttonRollInitiative_Click(object sender, EventArgs e)
        {
            if (activeCharacter != null)
            {
                List<BonusValueModifier> rollMods = activeCharacter.GetInitiativeRollModifiers();
                DieRollEquation myEquation = BonusValueModifier.GetEquationFromList(rollMods);
                string rollResult;
                myEquation.RollValue(out rollResult);

                handleRollReport("Initiative : " + rollResult + Environment.NewLine, Color.Black, false, HorizontalAlignment.Left);
            }
        }
    }

    /// <summary>
    /// Helper class for directing console output to the rich textbox.
    /// </summary>
    public class TextBoxWriter
    {
        RichTextBox _output = null;

        public TextBoxWriter(RichTextBox output)
        {
            _output = output;
        }

        public void WriteColoredLine(string str, ConsoleColor color)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<string, Color>(_output.AppendText), new object[] { str + Environment.NewLine, ConvertConsoleColorToColor(color) });
                return;
            }
            else
            {
                _output.AppendText(str, ConvertConsoleColorToColor(color));
            }
        }

        public void Write(char value)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<char>(Write), new object[] { value });
                return;
            }
            _output.AppendText(value.ToString());
        }

        public void WriteLine(String msg)
        {
            if (_output.InvokeRequired)
            {
                _output.Invoke(new Action<String>(WriteLine), new object[] { msg });
                return;
            }

            _output.AppendText(msg + Environment.NewLine);
        }

        public Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }


        private static Color ConvertConsoleColorToColor(ConsoleColor color)
        {
            switch (color)
            {
                case ConsoleColor.Black:
                    return Color.Black;
                case ConsoleColor.Blue:

                    return Color.Blue;
                case ConsoleColor.Cyan:

                    return Color.Cyan;
                case ConsoleColor.DarkBlue:

                    return Color.DarkBlue;
                case ConsoleColor.DarkGray:

                    return Color.DarkGray;
                case ConsoleColor.DarkGreen:

                    return Color.DarkGreen;
                case ConsoleColor.DarkMagenta:

                    return Color.DarkMagenta;
                case ConsoleColor.DarkRed:

                    return Color.DarkRed;
                case ConsoleColor.DarkYellow:

                    return Color.FromArgb(255, 128, 128, 0);
                case ConsoleColor.Gray:

                    return Color.Gray;
                case ConsoleColor.Green:

                    return Color.Green;
                case ConsoleColor.Magenta:

                    return Color.Magenta;
                case ConsoleColor.Red:

                    return Color.Red;
                case ConsoleColor.White:

                    return Color.White;
                default:
                    return Color.Yellow;
            }
        }
    }
}
