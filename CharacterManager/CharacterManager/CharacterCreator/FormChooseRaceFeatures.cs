using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.CharacterCreator
{
    public partial class FormChooseRaceFeatures : Form
    {
        public PlayerRace MainRace { get { return _mainRace; } set { _mainRace = value; UpdateChoices(); } }
        public PlayerRace SubRace { get { return _subRace; } set { _subRace = value; UpdateChoices(); } }

        private PlayerRace _mainRace;
        private PlayerRace _subRace;

        public FormChooseRaceFeatures()
        {
            InitializeComponent();
        }
        
        public List<string> GetSelectedLanguages()
        {
            List<string> res = new List<string>();

            foreach(Control c in groupBoxLanguageOptions.Controls)
            {
                if(c is ComboBox)
                {
                    ComboBox cBox = (ComboBox)c;
                    if (cBox.SelectedIndex > -1)
                    {
                        string selectedItem = cBox.Items[cBox.SelectedIndex].ToString();
                        res.Add(selectedItem);
                    }
                }
            }

            return res;
        }

        public List<string> GetSelectedToolProficiencies()
        {
            return userControlToolProficiencyChoice1.getChosenToolProficiencies();
        }

        private void UpdateChoices()
        {
            if (_mainRace == null)
            {
                return;
            }

            /* Remove any existing combo boxes... */
            List<Control> ControlsToRemove = new List<Control>();
            foreach(Control c in groupBoxLanguageOptions.Controls)
            {
                if (c is ComboBox)
                {
                    ControlsToRemove.Add(c);
                }
            }

            foreach(Control c in ControlsToRemove)
            {
                groupBoxLanguageOptions.Controls.Remove(c);
            }

            /* Lets check first if there are any language choices.... */
            if (_mainRace.KnownLanguages.Contains("ChooseAny"))
            {
                labelNoLanguages.Visible = false;
                int cnt = 0;
                foreach(string lang in _mainRace.KnownLanguages)
                {
                    if (lang == "ChooseAny")
                    {
                        cnt++;
                    }
                }

                List<Language> definedLanguages = CharacterFactory.getAllLanguages();
                int yLoc = 20;

                for (int x = 0; x < cnt; x++)
                {
                    ComboBox myComboBox = new ComboBox();
                    myComboBox.Location = new Point(10, yLoc);
                    foreach (Language lang in definedLanguages)
                    {
                        myComboBox.Items.Add(lang.LanguageName);
                    }
                    
                    groupBoxLanguageOptions.Controls.Add(myComboBox);

                    yLoc += myComboBox.Height;
                }
            }
            else
            {
                /* TODO : Make it visible that there are no languages to choose... */
                labelNoLanguages.Visible = true;
            } 

            /* Now lets check for any tool proficiency options... */
            List<String> myChoices = new List<String>();

            foreach (string str in _mainRace.ToolProficiencies)
            {
                myChoices.Add(str);
            }

            //Not sure if this part is actually needed...
            if (_subRace != null)
            {
                foreach (string str in _subRace.ToolProficiencies)
                {
                    myChoices.Add(str);
                }
            }

            userControlToolProficiencyChoice1.setChoices(myChoices);
        }


        private void buttonOK_Click(object sender, EventArgs e)
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
