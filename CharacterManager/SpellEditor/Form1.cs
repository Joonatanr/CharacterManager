using System;
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

                foreach(PlayerSpell spell in SpellList)
                {
                    listBox1.Items.Add(spell.SpellName);
                    //listView1.Items.Add(spell.SpellName);
                }

                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open file : " + ex.Message);
            }
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to save file " + LoadedFilePath + " Exception : " + ex.Message);
                }
            }
        }


        private void numericUpDownLevel_ValueChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                this.selectedSpell.SpellLevel = (int)numericUpDownLevel.Value;
            }
        }

        private void comboBoxSpellSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.School = comboBoxSpellSchool.SelectedItem.ToString();
            }
        }

        private void numericUpDownSpellDuration_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.SpellDuration = (int)numericUpDownSpellDuration.Value;
            }
        }

        private void numericUpDownSpellRange_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.SpellRange = (int)numericUpDownSpellRange.Value;
            }
        }

        private void comboBoxRangeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxRangeType.SelectedItem.ToString();
                selectedSpell.RangeType = (SpellRangeType)Enum.Parse(typeof(SpellRangeType), selectedValue);
            }
        }

        private void comboBoxAoeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxAoeType.SelectedItem.ToString();
                selectedSpell.AoeType = (AreaOfEffectType)Enum.Parse(typeof(AreaOfEffectType), selectedValue);
            }
        }

        private void numericUpDownAoeSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.AoeSize = (int)numericUpDownAoeSize.Value;
            }
        }

        private void comboBoxCastingTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                string selectedValue = comboBoxCastingTimeType.SelectedItem.ToString();
                selectedSpell.CastingTime = (CastingTimeEnum)Enum.Parse(typeof(CastingTimeEnum), selectedValue);
            }
        }

        private void numericUpDownCastingTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.CastingTimePeriod = (int)numericUpDownCastingTime.Value;
            }
        }

        private void checkBoxConcentration_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                selectedSpell.IsConcentration = checkBoxConcentration.Checked;
            }
        }

        private void checkBoxRitual_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.IsRitual = checkBoxRitual.Checked;
            }
        }

        private void checkBoxVerbalComponent_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                selectedSpell.IsVerbalComponent = checkBoxVerbalComponent.Checked;
            }
        }

        private void checkBoxSomaticComponent_CheckedChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                selectedSpell.IsSomaticComponent = checkBoxSomaticComponent.Checked;
            }
        }

        private void checkBoxMaterialComponent_CheckedChanged(object sender, EventArgs e)
        {
            if(this.selectedSpell != null)
            {
                selectedSpell.IsMaterialComponent = true;
            }
        }

        private void textBoxMaterialComponent_TextChanged(object sender, EventArgs e)
        {
            if (this.selectedSpell != null)
            {
                this.selectedSpell.MaterialComponent = textBoxMaterialComponent.Text;
            }
        }
    }
}
