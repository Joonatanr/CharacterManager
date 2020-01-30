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
}
