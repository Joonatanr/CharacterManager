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

        protected BonusValueModifier _baseValue = new BonusValueModifier("None", 0);
        protected int _proficiencyBonus = 0;

        private List<BonusValueModifier> _extraModifiers = new List<BonusValueModifier>();
        public List<BonusValueModifier> ExtraModifiers
        {
            get
            {
                return _extraModifiers;
            }
            set
            {
                _extraModifiers = value;
                UpdateDisplayedData();
            }
        }

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

        //public void setValueAndProficiency(int baseValue, bool isProficient, int proficiencyBonus)
        public void setValueAndProficiency(BonusValueModifier baseValue, bool isProficient, int proficiencyBonus)
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

            UpdateDisplayedData();
        }

        private void UpdateDisplayedData()
        {
            List<BonusValueModifier> modifiers = getBonusValueModifiers();
            int displayedValue = BonusValueModifier.getTotalValueFromList(modifiers);
            toolTip1.SetToolTip(textBoxModifier, BonusValueModifier.getToolTipStringFromList(modifiers));

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

        public void setValue(BonusValueModifier baseValue)
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


        public List<BonusValueModifier> getTotalModifiers()
        {
            return getBonusValueModifiers();
        }

        public int Roll(out string log)
        {
            List<BonusValueModifier> myRollModifiers = new List<BonusValueModifier>();
            BonusValueModifier baseDieModifier = new BonusValueModifier("base", "d20");
            myRollModifiers.Add(baseDieModifier);
            myRollModifiers.AddRange(getBonusValueModifiers());
            DieRollEquation myRoll = BonusValueModifier.GetEquationFromList(myRollModifiers);
            return myRoll.RollValue(out log);
        }

        protected virtual List<BonusValueModifier> getBonusValueModifiers()
        {
            List<BonusValueModifier> res = new List<BonusValueModifier>();
                
            res.Add(_baseValue);

            if (IsProficient())
            {
                res.Add(new BonusValueModifier("Prof. bonus", _proficiencyBonus));
            }

            foreach (BonusValueModifier modifier in _extraModifiers)
            {
                res.Add(modifier);
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
