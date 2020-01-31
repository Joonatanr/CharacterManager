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
    public partial class FormChooseClassFeatures : Form
    {
        private PlayerClass _selectedClass = null;
        
        public FormChooseClassFeatures()
        {
            InitializeComponent();
        }

        public void setSelectedClass(PlayerClass c)
        {
            _selectedClass = c;

            groupBox1.Controls.Clear();

            int yloc = 15;

            foreach (PlayerClassAbilityChoice choice in _selectedClass.AvailableClassAbilities)
            {
                /* Lets create a user control for each.*/
                UserControlClassFeature ctrl = new UserControlClassFeature();
                ctrl.AbilityChoice = choice;
                ctrl.Location = new Point(5, yloc);
                groupBox1.Controls.Add(ctrl);

                yloc += ctrl.Height;
                yloc += 5;
            }
        }

        public List<PlayerAbility> getAllSelectedAbilities()
        {
            List<PlayerAbility> res = new List<PlayerAbility>();
            
            foreach(Control c in groupBox1.Controls)
            {
                if (c is UserControlClassFeature)
                {
                    UserControlClassFeature cast = (UserControlClassFeature)c;
                    PlayerAbility ability = cast.getSelectedAbility();
                    if (ability != null)
                    {
                        res.Add(ability);
                    }
                }
            }

            return res;
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
