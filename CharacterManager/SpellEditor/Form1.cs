﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using CharacterManager.Spells;
using static CharacterManager.Spells.PlayerSpell;

namespace SpellEditor
{
    public partial class Form1 : Form
    {
        private static List<PlayerSpell> SpellList = new List<PlayerSpell>();
        private PlayerSpell selectedSpell;
        private String LoadedFilePath = "";

        
        public Form1()
        {
            InitializeComponent();

            comboBoxAoeType.DataSource = Enum.GetValues(typeof(AreaOfEffectType));
            comboBoxRangeType.DataSource = Enum.GetValues(typeof(SpellRangeType));
            comboBoxCastingTimeType.DataSource = Enum.GetValues(typeof(CastingTimeEnum));
        }

        private void parseSpellsFromXml(String filepath)
        {
            try
            {
                XmlSerializer reader = new XmlSerializer(typeof(List<PlayerSpell>));
                StreamReader file = new System.IO.StreamReader(filepath);
                SpellList = (List<PlayerSpell>)reader.Deserialize(file);

                if (SpellList.Count == 0)
                {
                    MessageBox.Show("No spells found in file");
                    return;
                }

                updateDisplayedSpells();

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open file : " + ex.Message);
            }
        }


        private void updateDisplayedSpells()
        {
            int currentSelection = listBox1.SelectedIndex;
            listBox1.Items.Clear();

            foreach (PlayerSpell spell in SpellList)
            {
                listBox1.Items.Add(spell.ListNameForEditor);
            }
            listBox1.SelectedIndex = currentSelection;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadedFilePath = openFileDialog1.FileName;
                parseSpellsFromXml(LoadedFilePath);
            }
        }


        private void loadSpellData(PlayerSpell spell)
        {
            textBoxSpellName.Text = spell.SpellName;
            richTextBoxSpellDescription.Text = spell.Description;
            richTextBoxAtHigherLevels.Text = spell.AtHigherLevels;
           
            try
            {
                comboBoxSpellSchool.SelectedIndex = comboBoxSpellSchool.FindStringExact(spell.School);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not resolve spell school : " + spell.School.ToString());
            }

            try
            {
                numericUpDownLevel.Value = spell.SpellLevel;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell level");
            }

            try
            {
                numericUpDownSpellRange.Value = spell.SpellRange;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell range");
            }

            try
            {
                numericUpDownSpellDuration.Value = spell.SpellDuration;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell duration");
            }

            /// AOE values
            try
            {
                numericUpDownAoeSize.Value = spell.AoeSize;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell AOE size");
            }

            try
            {
                comboBoxAoeType.SelectedIndex = comboBoxAoeType.FindStringExact(spell.AoeType.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell AOE type : " + spell.AoeType.ToString());
            }

            try
            {
                comboBoxRangeType.SelectedIndex = comboBoxRangeType.FindStringExact(spell.RangeType.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell range type : " + spell.RangeType.ToString());
            }

            try
            {
                comboBoxCastingTimeType.SelectedIndex = comboBoxCastingTimeType.FindStringExact(spell.CastingTime.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell casting type : " + spell.CastingTime.ToString());
            }

            try
            {
                numericUpDownCastingTime.Value = spell.CastingTimePeriod;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not resolve spell casting time interval");
            }

            try
            {
                numericUpDownMaterialCost.Value = spell.MaterialCost;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not resolve spell material cost");
            }

            checkBoxVerbalComponent.Checked = spell.IsVerbalComponent;
            checkBoxSomaticComponent.Checked = spell.IsSomaticComponent;
            checkBoxMaterialComponent.Checked = spell.IsMaterialComponent;

            if (spell.IsMaterialComponent)
            {
                textBoxMaterialComponent.Text = spell.MaterialComponent;
            }
            else
            {
                textBoxMaterialComponent.Text = "";
            }

            checkBoxConcentration.Checked = spell.IsConcentration;
            checkBoxRitual.Checked = spell.IsRitual;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            string curItem = listBox1.SelectedItem.ToString();

            /* Hack, but it works. */
            curItem = curItem.Replace("*", "");

            selectedSpell = SpellList.Find(sp => sp.SpellName == curItem);

            if(selectedSpell != null)
            {
                loadSpellData(selectedSpell);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(LoadedFilePath))
            {
                /* Keep it simple for now. */
                try
                {
                    XmlSerializer writer = new XmlSerializer(typeof(List<PlayerSpell>));
                    StreamWriter sw = new System.IO.StreamWriter(LoadedFilePath);
                    writer.Serialize(sw, SpellList);
                    sw.Flush();
                    sw.Close();

                    foreach(PlayerSpell sp in SpellList)
                    {
                        sp.IsModified = false;
                        updateDisplayedSpells();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save file " + LoadedFilePath + " Exception : " + ex.Message);
                }
            }
        }


        private void setSpellDataAsModified()
        {
            if (selectedSpell.IsModified)
            {
                /* Should already be marked as modified, so no changes to be made. */
                return;
            }
            else
            {
                selectedSpell.IsModified = true;
                updateDisplayedSpells();                
            }
        }

        private void numericUpDownLevel_ValueChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                if (this.selectedSpell.SpellLevel != (int)numericUpDownLevel.Value)
                {
                    this.selectedSpell.SpellLevel = (int)numericUpDownLevel.Value;
                    setSpellDataAsModified();
                }
            }
        }

        private void comboBoxSpellSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(selectedSpell.School != comboBoxSpellSchool.SelectedItem.ToString())
                {
                    selectedSpell.School = comboBoxSpellSchool.SelectedItem.ToString();
                    setSpellDataAsModified();
                }
            }
        }

        /* Guess there is no pretty way of syncing these values... */
        private Boolean SyncFromRoundsMinutes = false;
        private Boolean SyncFromRoundsHours = false;

        private void numericUpDownSpellDuration_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(selectedSpell.SpellDuration != (int)numericUpDownSpellDuration.Value)
                {
                    selectedSpell.SpellDuration = (int)numericUpDownSpellDuration.Value;
                    setSpellDataAsModified();
                }
            }

            if (SyncFromMinutesRounds)
            {
                SyncFromMinutesRounds = false;
                return;
            }

            if (SyncFromHoursRounds)
            {
                SyncFromHoursRounds = false;
                return;
            }

            SyncFromRoundsMinutes = true;
            SyncFromRoundsHours = true;

            /* Synchronise the other duration controls. */
            numericUpDownDurationMinutes.Value = (int)numericUpDownSpellDuration.Value / 10;
            numericUpDownDurationHours.Value = (int)numericUpDownSpellDuration.Value / 600;
        }

        private Boolean SyncFromMinutesRounds = false;
        private Boolean SyncFromMinutesHours = false;

        private void numericUpDownDurationMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (SyncFromRoundsMinutes)
            {
                SyncFromRoundsMinutes = false;
                return;
            }

            if (SyncFromHoursMinutes)
            {
                SyncFromHoursMinutes = false;
                return;
            }

            SyncFromMinutesRounds = true;
            SyncFromMinutesHours = true;

            numericUpDownSpellDuration.Value = numericUpDownDurationMinutes.Value * 10;
            numericUpDownDurationHours.Value = (int)numericUpDownDurationMinutes.Value / 60;
        }

        private Boolean SyncFromHoursMinutes = false;
        private Boolean SyncFromHoursRounds = false;

        private void numericUpDownDurationHours_ValueChanged(object sender, EventArgs e)
        {
            if (SyncFromRoundsHours)
            {
                SyncFromRoundsHours = false;
                return;
            }

            if (SyncFromMinutesHours)
            {
                SyncFromMinutesHours = false;
                return;
            }

            numericUpDownSpellDuration.Value = numericUpDownDurationHours.Value * 600;
            numericUpDownDurationMinutes.Value = numericUpDownDurationHours.Value * 60;

            SyncFromHoursMinutes = true;
            SyncFromHoursRounds = true;
        }

        private void numericUpDownSpellRange_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if (selectedSpell.SpellRange != (int)numericUpDownSpellRange.Value)
                {
                    selectedSpell.SpellRange = (int)numericUpDownSpellRange.Value;
                    setSpellDataAsModified();
                }
            }
        }

        private void comboBoxRangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxRangeType.SelectedItem.ToString();
                SpellRangeType value = (SpellRangeType)Enum.Parse(typeof(SpellRangeType), selectedValue);
                if (selectedSpell.RangeType != value)
                {
                    selectedSpell.RangeType = value;
                    setSpellDataAsModified();
                }
            }
        }

        private void comboBoxAoeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxAoeType.SelectedItem.ToString();
                AreaOfEffectType value = (AreaOfEffectType)Enum.Parse(typeof(AreaOfEffectType), selectedValue);
                
                if (selectedSpell.AoeType != value)
                {
                    selectedSpell.AoeType = value;
                    setSpellDataAsModified();
                }
            }
        }

        private void numericUpDownAoeSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(selectedSpell.AoeSize != (int)numericUpDownAoeSize.Value)
                {
                    selectedSpell.AoeSize = (int)numericUpDownAoeSize.Value;
                    setSpellDataAsModified();
                }
            }
        }

        private void comboBoxCastingTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxCastingTimeType.SelectedItem.ToString();
                CastingTimeEnum value = (CastingTimeEnum)Enum.Parse(typeof(CastingTimeEnum), selectedValue);
                if(selectedSpell.CastingTime != value)
                {
                    selectedSpell.CastingTime = value;
                    setSpellDataAsModified();
                }
            }
        }

        private void numericUpDownCastingTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(selectedSpell.CastingTimePeriod != (int)numericUpDownCastingTime.Value)
                {
                    selectedSpell.CastingTimePeriod = (int)numericUpDownCastingTime.Value;
                    setSpellDataAsModified();
                }
            }
        }

        private void checkBoxConcentration_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                if(selectedSpell.IsConcentration != checkBoxConcentration.Checked)
                {
                    selectedSpell.IsConcentration = checkBoxConcentration.Checked;
                    setSpellDataAsModified();
                }
            }
        }

        private void checkBoxRitual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if (selectedSpell.IsRitual != checkBoxRitual.Checked)
                {
                    selectedSpell.IsRitual = checkBoxRitual.Checked;
                    setSpellDataAsModified();
                }
            }
        }

        private void checkBoxVerbalComponent_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                if(selectedSpell.IsVerbalComponent != checkBoxVerbalComponent.Checked)
                {
                    selectedSpell.IsVerbalComponent = checkBoxVerbalComponent.Checked;
                    setSpellDataAsModified();
                }
            }
        }

        private void checkBoxSomaticComponent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(selectedSpell.IsSomaticComponent != checkBoxSomaticComponent.Checked)
                {
                    selectedSpell.IsSomaticComponent = checkBoxSomaticComponent.Checked;
                    setSpellDataAsModified();
                }
            }
        }

        private void checkBoxMaterialComponent_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                if (selectedSpell.IsMaterialComponent != checkBoxMaterialComponent.Checked)
                {
                    selectedSpell.IsMaterialComponent = checkBoxMaterialComponent.Checked;
                    setSpellDataAsModified();
                }
            }
        }

        private void textBoxMaterialComponent_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(this.selectedSpell.MaterialComponent != textBoxMaterialComponent.Text)
                {
                    this.selectedSpell.MaterialComponent = textBoxMaterialComponent.Text;
                    setSpellDataAsModified();
                }
            }
        }

        private void richTextBoxSpellDescription_TextChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                if (this.selectedSpell.Description != richTextBoxSpellDescription.Text)
                {
                    this.selectedSpell.Description = richTextBoxSpellDescription.Text;
                    setSpellDataAsModified();
                }
            }
        }

        private void richTextBoxAtHigherLevels_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if(this.selectedSpell.AtHigherLevels != richTextBoxAtHigherLevels.Text)
                {
                    selectedSpell.AtHigherLevels = richTextBoxAtHigherLevels.Text;
                    setSpellDataAsModified();
                }
            }
        }

        private void numericUpDownMaterialCost_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                if (this.selectedSpell.MaterialCost != (int)numericUpDownMaterialCost.Value)
                {
                    this.selectedSpell.MaterialCost = (int)numericUpDownMaterialCost.Value;
                    setSpellDataAsModified();
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddNewSpell myForm = new FormAddNewSpell();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(myForm.NewSpellName))
                {
                    PlayerSpell mySpell = new PlayerSpell(myForm.NewSpellName);
                    mySpell.IsModified = true;
                    /* Obvious check if we already have a spell with this name... */
                    foreach(PlayerSpell sp in SpellList)
                    {
                        if (sp.SpellName == mySpell.SpellName)
                        {
                            MessageBox.Show("Spell with name " + sp.SpellName + " already exists"); 
                            return;
                        }
                    }

                    SpellList.Add(mySpell);
                    updateDisplayedSpells();
                    listBox1.SelectedItem = mySpell.SpellName;
                }
            }
        }

        private void buttonSpellCard_Click(object sender, EventArgs e)
        {
            if(selectedSpell != null)
            {
                Spellcard card = new Spellcard();
                card.setSpell(selectedSpell);
                card.ShowDialog();
            }
        }
    }
}
