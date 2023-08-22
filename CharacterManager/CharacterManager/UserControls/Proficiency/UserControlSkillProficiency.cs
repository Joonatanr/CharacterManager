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
                    checkBoxExpertise.Visible = true;
                }
                else
                {
                    checkBoxExpertise.Visible = false;
                }
            }
        }

        public ManuallyCheckedChangedListener ExpertiseCheckedChanged = null;

        private bool _isExpertiseVisible = false;
        private bool _isExpertiseEditable = false;

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

        public void setExpertiseStatus(bool isExpertise)
        {
            this.checkBoxExpertise.Checked = isExpertise;
        }

        public void setExpertiseEditable(bool isEditable)
        {
            _isExpertiseEditable = isEditable;

            if (isEditable && checkBoxProficiency.Checked)
            {
                checkBoxExpertise.Enabled = true;
            }
            else
            {
                checkBoxExpertise.Enabled = false;
            }
        }

        private void checkBoxExpertise_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxExpertise.AutoCheck)
            {
                if (ExpertiseCheckedChanged != null)
                {
                    ExpertiseCheckedChanged.Invoke(this);
                }
                setValue(_baseValue);
            }
        }
        protected override void checkBoxProficiency_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxExpertise.Checked && !checkBoxProficiency.Checked)
            {
                checkBoxExpertise.Checked = false;
                checkBoxExpertise.Enabled = false;
            }
            else if(checkBoxProficiency.Checked && _isExpertiseEditable)
            {
                checkBoxExpertise.Enabled = true;
            }

            base.checkBoxProficiency_CheckedChanged(sender, e);
        }

        protected override int getBonusValue()
        {
            int res = base.getBonusValue();
            if (IsExpertise())
            {
                /* We give double proficiency bonus here. */
                res += _proficiencyBonus;
            }
            return res;
        }
    }
}
