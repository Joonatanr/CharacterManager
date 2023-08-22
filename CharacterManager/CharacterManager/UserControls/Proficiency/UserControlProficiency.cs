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
                    this.labelDescription.Text = _proficiencyName;
                }
                else
                {
                    this.labelDescription.Text = _proficiencyName + "("+ _proficiencyBase + ")";
                }
            }
        }
        public String ProficiencyBaseSkill
        {
            get { return _proficiencyBase; }
            set
            {
                _proficiencyBase = value;
                this.labelDescription.Text = _proficiencyName + "(" + _proficiencyBase + ")";
            }
        }

        protected Color originalColor;

        public delegate void ManuallyCheckedChangedListener(UserControlProficiency ctrl);
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

            if (isProficient)
            {
                checkBoxProficiency.Checked = true;
            }
            else
            {
                checkBoxProficiency.Checked = false;
            }

            int displayedValue = getBonusValue();
            string modifierText;
            
            if (displayedValue >= 0)
            {
                modifierText = "+" + displayedValue.ToString();
            }
            else
            {
                modifierText = displayedValue.ToString();
            }

            textBoxModifier.Text = modifierText;
        }

        public void setValue(int baseValue)
        {
            setValueAndProficiency(baseValue, checkBoxProficiency.Checked, _proficiencyBonus);
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
                this.checkBoxProficiency.AutoCheck = true;
            }
            else
            {
                this.BackColor = originalColor;
                this.checkBoxProficiency.AutoCheck = false;
            }
        }

        public bool IsProficient()
        {
            return this.checkBoxProficiency.Checked;
        }


        public int getTotalProficiencyBonus()
        {
            return getBonusValue();
        }

        protected virtual int getBonusValue()
        {
            int res = _baseValue;

            if (IsProficient())
            {
                res += _proficiencyBonus;
            }

            return res;
        }


        protected virtual void checkBoxProficiency_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxProficiency.AutoCheck)
            {
                //Was changed manually.
                setValue(_baseValue);
                ChangeListener?.Invoke(this);
            }
        }
    }
}
