using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;

namespace CharacterManager.UserControls
{
    public partial class UserControlChoiceBoxSingle : UserControl
    {
        /* This is mainly intended as a base class for any multiple choices. */
        
        public UserControlChoiceBoxSingle()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            //this.BackColor = Color.Red;
        }


        public void setActive(Boolean isActive)
        {
            if (isActive)
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }
        }

        public String getSelectedValueAsString()
        {
            if (comboBox1.SelectedItem != null)
            {
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                return null;
            }
        }
    }

    public class UserControlLanguageChoice : UserControlChoiceBoxSingle
    {
        private List<Language> allLanguages;
        
        public UserControlLanguageChoice() : base()
        {
            allLanguages = CharacterFactory.getAllLanguages();
            comboBox1.Items.Clear();
            comboBox1.Visible = true;

            this.label1.Text = "Choose Language";

            foreach (Language lang in allLanguages)
            {
                comboBox1.Items.Add(lang.LanguageName);
            }
        }

        public Language getSelectedLanguage()
        {
            String langString = comboBox1.SelectedItem.ToString();

            return (allLanguages.Find(l => l.LanguageName == langString));
        }
    }


    public class UserControlToolProficiencyChoiceVer2 : UserControlChoiceBoxSingle
    {

        private ToolProficiencyChoice _myChoice = null;

        public UserControlToolProficiencyChoiceVer2() : base()
        {
            comboBox1.Items.Clear();
            comboBox1.Visible = true;

            this.label1.Text = "Tool Proficiency";
        }

        public void setToolProficiencyChoice(ToolProficiencyChoice choice)
        {
            _myChoice = choice;
            comboBox1.Items.Clear();
            comboBox1.Enabled = true;
            List<Items.PlayerToolKit> existingToolProficiencies = CharacterFactory.getAllToolSets();

            switch (_myChoice.ChoiceType)
            {
                case ToolProficiencyChoice.ToolProficiencyChoiceType.TYPE_LIST:
                    List<string> choices = _myChoice.getAllAvailableChoices();
                    if (choices.Count == 1)
                    {
                        comboBox1.Items.Add(choices[0]);
                        comboBox1.SelectedIndex = 0;
                        comboBox1.Enabled = false;
                    }
                    else
                    {
                        foreach (string c in choices)
                        {
                            comboBox1.Items.Add(c);
                        }
                    }
                    this.label1.Text = "Tool Proficiency";
                    break;
                case ToolProficiencyChoice.ToolProficiencyChoiceType.TYPE_MUSICAL_INSTRUMENT:
                    foreach (Items.PlayerToolKit toolkit in existingToolProficiencies)
                    {
                        if (toolkit.ToolType == Items.PlayerToolKit.PlayerToolType.TYPE_MUSICAL)
                        {
                            comboBox1.Items.Add(toolkit.Name);
                        }
                    }
                    this.label1.Text = "Any Musical instrument proficiency.";
                    break;
                case ToolProficiencyChoice.ToolProficiencyChoiceType.TYPE_ARTISAN_TOOL:
                    foreach (Items.PlayerToolKit toolkit in existingToolProficiencies)
                    {
                        if (toolkit.ToolType == Items.PlayerToolKit.PlayerToolType.TYPE_ARTISAN)
                        {
                            comboBox1.Items.Add(toolkit.Name);
                        }
                    }
                    this.label1.Text = "Any Artisan tool proficiency.";
                    break;
                case ToolProficiencyChoice.ToolProficiencyChoiceType.TYPE_ARTISAN_OR_MUSICAL:
                    foreach (Items.PlayerToolKit toolkit in existingToolProficiencies)
                    {
                        if (toolkit.ToolType == Items.PlayerToolKit.PlayerToolType.TYPE_MUSICAL ||
                            toolkit.ToolType == Items.PlayerToolKit.PlayerToolType.TYPE_ARTISAN)
                        {
                            comboBox1.Items.Add(toolkit.Name);
                        }
                    }
                    this.label1.Text = "Any Artisan or Musical Proficiency";
                    break;
                case ToolProficiencyChoice.ToolProficiencyChoiceType.TYPE_GAMING:
                    foreach (Items.PlayerToolKit toolkit in existingToolProficiencies)
                    {
                        if (toolkit.ToolType == Items.PlayerToolKit.PlayerToolType.TYPE_GAMING)
                        {
                            comboBox1.Items.Add(toolkit.Name);
                        }
                    }
                    this.label1.Text = "Any Gaming Set Proficiency";
                    break;
                default:
                    break;
            }
        }

        public string getSelectedToolProficiency()
        {
            if (comboBox1.SelectedIndex > -1)
            {
                return comboBox1.SelectedItem.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
