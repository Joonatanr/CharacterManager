using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class UserControlProficiency : UserControl
    {
        protected String _proficiencyName = "";
        protected String _proficiencyBase = null;

        protected int _baseValue = 0;
        protected int _proficiencyBonus = 0;

        public String ProficiencyName
        {
            get
            {
                return _proficiencyName;
            }
            set
            {   _proficiencyName = value;
                if (_proficiencyBase == null)
                {
                    this.label24.Text = _proficiencyName;
                }
                else
                {
                    this.label24.Text = _proficiencyName + "("+ _proficiencyBase + ")";
                }
            }
        }
        public String ProficiencyBaseSkill
        {
            get { return _proficiencyBase; }
            set
            {
                _proficiencyBase = value;
                this.label24.Text = _proficiencyName + "(" + _proficiencyBase + ")";
            }
        }

        protected Color originalColor;

        public delegate void ManuallyCheckedChangedListener(String name);
        public ManuallyCheckedChangedListener ChangeListener = null;

        public UserControlProficiency()
        {
            InitializeComponent();
            originalColor = this.BackColor;

        }

        public void setValueAndProficiency(int baseValue, bool isProficient, int proficiencyBonus)
        {
            _baseValue = baseValue;
            _proficiencyBonus = proficiencyBonus;
            int displayedValue = _baseValue;

            if (isProficient)
            {
                checkBoxProfSTR.Checked = true;
                displayedValue += proficiencyBonus;
            }
            else
            {
                checkBoxProfSTR.Checked = false;
            }

            textBoxStrSave.Text = displayedValue.ToString();
            
        }

        public void setValue(int baseValue)
        {
            setValueAndProficiency(baseValue, checkBoxProfSTR.Checked, _proficiencyBonus);
        }

        public void setProficiency(bool isProficient, int proficiencyBonus)
        {
            setValueAndProficiency(_baseValue, isProficient, proficiencyBonus);
        }

        public void setEditable(bool isEditable)
        {
            if (isEditable)
            {
                this.BackColor = Color.White;
                this.checkBoxProfSTR.AutoCheck = true;
            }
            else
            {
                this.BackColor = originalColor;
                this.checkBoxProfSTR.AutoCheck = false;
            }
        }

        public bool IsProficient()
        {
            return this.checkBoxProfSTR.Checked;
        }


        public int getTotalProficiencyBonus()
        {
            int res = _baseValue;
            if (IsProficient())
            {
                res += _proficiencyBonus;
            }

            return res;
        }

        private void checkBoxProfSTR_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxProfSTR.AutoCheck)
            {
                //Was changed manually.
                setValue(_baseValue);
                ChangeListener?.Invoke(ProficiencyName);
            }
        }
    }
}
