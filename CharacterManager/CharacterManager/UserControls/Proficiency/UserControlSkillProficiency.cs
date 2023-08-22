using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls.Proficiency
{
    public partial class UserControlSkillProficiency : UserControlProficiency
    {
        public bool IsExpertiseVisible
        {
            get
            {
                return _isExpertiseVisible;
            }

            set
            {
                _isExpertiseVisible = value;
                if (_isExpertiseVisible == true)
                {
                    checkBoxExpertise.Enabled = true;
                    checkBoxExpertise.Visible = true;
                }
                else
                {

                    checkBoxExpertise.Checked = false;
                    checkBoxExpertise.Enabled = false;
                    checkBoxExpertise.Visible = false;
                }
            }
        }


        private bool _isExpertiseVisible = false;

        public UserControlSkillProficiency() : base()
        {
            InitializeComponent();
            /* By default the expertise box is not supposed to be visible. */
            IsExpertiseVisible = false;
        }

        public bool IsExpertise()
        {
            return this.checkBoxExpertise.Checked;
        }
    }
}
