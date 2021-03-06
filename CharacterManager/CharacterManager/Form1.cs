﻿using System;
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

namespace CharacterManager
{
    public partial class Form1 : Form
    {
        private PlayerCharacter activeCharacter = null;

        public Form1()
        {
            InitializeComponent();
            CharacterFactory.setErrorHandler(new TextBoxWriter(richTextBox1));
            CharacterFactory.Initialize();
        }


        /************* private methods*****************/


        private void updateCharacterAttributes()
        {
            if (this.activeCharacter != null)
            {
                //1. Update character name and other basic things.
                this.textBoxName.Text = activeCharacter.CharacterName;
                this.textBoxClass.Text = activeCharacter.ClassName;
                
                if (activeCharacter.SubRaceName == null)
                {
                    textBoxRace.Text = activeCharacter.MainRaceName;
                }
                else
                {
                    textBoxRace.Text = activeCharacter.SubRaceName;
                }

                this.textBoxClass.Text = activeCharacter.ClassName;
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
                userControlSkillProficiencies1.updateSkillProficiencyFields(activeCharacter.getModifier("STR"),
                                                                            activeCharacter.getModifier("DEX"),
                                                                            activeCharacter.getModifier("INT"),
                                                                            activeCharacter.getModifier("WIS"),
                                                                            activeCharacter.getModifier("CHA"),
                                                                            activeCharacter.getModifier("CON"),
                                                                            activeCharacter.ProficiencyBonus);

                foreach(string skill in activeCharacter.SkillProficiencies)
                {
                    userControlSkillProficiencies1.setProficientAtSkill(skill);
                }

                //5. Update passive perception.
                textBoxPerception.Text = activeCharacter.PassivePerception.ToString();

                //6. Update Player alignment.
                String alignmentString = activeCharacter.Alignment.ToString();
                for(int x = 1; x < alignmentString.Length; x++)
                {
                    if (char.IsUpper(alignmentString[x]))
                    {
                        alignmentString = alignmentString.Insert(x, " ");
                        break;
                    }
                }

                //7. Update Hit Points.
                UpdateHitPoints();

                //8. Update character alignment.
                textBoxAlignment.Text = alignmentString;

                //9. Update character abilities.
                UpdateCharacterAbilities();

                //10. Update weapons.
                userControlWeaponsHandler1.setWeaponList(activeCharacter.CharacterWeapons);

                //11. Update armors.
                userControlArmorHandler1.setArmorList(activeCharacter.CharacterArmors);
                userControlArmorHandler1.ArmorEquipChanged = updateArmorClass;
                updateArmorClass();

                //12. Update general inventory.
                userControlEquipmentHandler1.setGeneralEquipmentList(activeCharacter.CharacterGeneralEquipment);

                //13. Update initiative bonus.
                updateInitiativeBonus();
            }
        }

        private void UpdateHitPoints()
        {
            userControlHitPoints1.MaxHitPoints = activeCharacter.MaxHitPoints;
            userControlHitPoints1.CurrentHitPoints = activeCharacter.CurrentHitPoints;
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

        private void updateArmorClass()
        {
            int ac = activeCharacter.getCurrentArmorClass();
            userControlArmorClass.Value = ac.ToString();
        }

        private void LoadCharacter(PlayerCharacter c)
        {
            activeCharacter = c;
            c.CharacterHPChanged += characterHpChangedListener;
            updateCharacterAttributes();

            /* Set up listener functions */
            /* TODO */
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
            //MessageBox.Show("There are lines : " + userControlWeaponsHandler1.originalNumberOfLines);
        }

        private void userControlWeaponsHandler1_WeaponAttackEvent(Items.PlayerWeapon w)
        {
            /* TODO : This is a placeholder. */
            //MessageBox.Show("Attack made with : " + w.ItemName);
            if (activeCharacter != null)
            {
                /* TODO : We should probably have a separate form for making a weapon attack... */
                MessageBox.Show(activeCharacter.MakeWeaponAttack(w));
                //userControlEquipmentHandler1.Update();
                userControlEquipmentHandler1.setGeneralEquipmentList(activeCharacter.CharacterGeneralEquipment);
            }
        }

        private void buttonLongRest_Click(object sender, EventArgs e)
        {
            /* TODO */
            activeCharacter.PerformLongRest();
            /* TODO : Maybe we can do this with a listener function? */
            UpdateCharacterAbilities();
        }

        private void buttonShortRest_Click(object sender, EventArgs e)
        {
            /* TODO */
        }

        private void buttonRegisterDamage_Click(object sender, EventArgs e)
        {
            if (activeCharacter == null)
            {
                return;
            }

            FormDamageRegister myForm = new FormDamageRegister();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                activeCharacter.CurrentHitPoints -= myForm.Damage;
                if (activeCharacter.CurrentHitPoints < 0)
                {
                    activeCharacter.CurrentHitPoints = 0;
                    /* TODO : Might have to handle PC death at this point, but maybe it's actually not necessary. */
                }
            }
        }

        private void buttonHeal_Click(object sender, EventArgs e)
        {
            if (activeCharacter == null)
            {
                return;
            }

            FormDamageRegister myForm = new FormDamageRegister();
            myForm.LabelString = "Heal Amount:";
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                activeCharacter.CurrentHitPoints += myForm.Damage;
                if (activeCharacter.CurrentHitPoints > activeCharacter.MaxHitPoints)
                {
                    activeCharacter.CurrentHitPoints = activeCharacter.MaxHitPoints;
                }
            }
        }

        private bool userControlGenericAbilitiesList1_PlayerAbilityUsed(PlayerAbility ability)
        {
            /* TODO : This is a placeholder. */
            return ability.UseAbility(activeCharacter);
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
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
