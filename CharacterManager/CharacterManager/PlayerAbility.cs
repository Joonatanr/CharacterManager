using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static CharacterManager.CharacterCreator.UserControlClassFeature;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAbility
    {

        public string Description { get; set; }
        public string Name { get; set; }

        public bool IsCombatAbility { get; set; } = false;

        [XmlIgnore]
        private int _maximumCharges = 0; /* Maximum uses 0 indicates a passive ability. */
        public int MaximumCharges
        {
            get { return _maximumCharges;   }
            set 
            { 
                _maximumCharges = value;
                if (MaximumChargesChanged != null)
                {
                    MaximumChargesChanged.Invoke(_maximumCharges);
                }
            }
        }
        
        public Boolean IsToggle { get; set; } = false; /* Can the ability be toggled on or off. */
        public Boolean RechargeAtShortRest { get; set; } = false;
        public Boolean RechargeAtLongRest { get; set; } = false;
        public string Dice { get; set; } /* A lot of playerabilities have some kind of diceroll associated with it. */

        [XmlIgnore]
        public virtual string DisplayedName { get { return Name; } } /* This should be used instead of the AttributeName*/

        private int _remainingCharges = 0;
        [XmlIgnore]
        public int RemainingCharges
        {
            get { return _remainingCharges; }
            set
            {
                bool isChanged = false;

                if (value < 0)
                {
                    value = 0;
                }

                if(value != _remainingCharges)
                {
                    isChanged = true;
                }
                
                _remainingCharges = value;
                if ((RemainingChargesChanged != null) && isChanged)
                {
                    RemainingChargesChanged.Invoke(_remainingCharges);
                }
            }
        }

        private Boolean _isActive = false;
        [XmlIgnore]
        public Boolean IsActive
        {
            get
            {
                return _isActive;
            }

            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    if (IsActiveChanged != null)
                    {
                        IsActiveChanged.Invoke(_isActive);
                    }
                }
            }
        }

        [XmlIgnore]
        public DieRollEquation DiceObject
        {
            get
            {
                return new DieRollEquation(Dice);
            }

            set
            {
                this.Dice = value.DieRollString;
            }
        }

        /* TODO : We really need to get started with this. */
        public delegate void PlayerAbilityValueChanged(int value);
        public delegate void PlayerAbilityIsActiveChanged(bool isActive);
        public delegate void PlayerAbilityUsedListener(PlayerAbility ability);

        public event PlayerAbilityValueChanged MaximumChargesChanged;
        public event PlayerAbilityValueChanged RemainingChargesChanged;

        public event PlayerAbilityIsActiveChanged IsActiveChanged;
        public event PlayerAbilityUsedListener AbilityUsed;

        [XmlIgnore]
        protected PlayerCharacter _connectedCharacter;

        public PlayerAbility()
        {
            Name = "UNKNOWN";
            Description = "<BLANK>";
        }

        public PlayerAbility(String name)
        {
            Name = name;
        }

        internal static PlayerAbility resolveFromString(string s)
        {
            return CharacterFactory.getPlayerAbilityFromString(s);
        }

        public void connectToCharacter(PlayerCharacter c)
        {
            _connectedCharacter = c;
        }

        public Boolean UseAbility()
        {
            bool res = true;
            
            if(IsToggle && IsActive)
            {
                /* Special case, we are deactivating. */
                this.IsActive = false;
                res = true;
            }
            else 
            {
                if (MaximumCharges > 0)
                {
                    if (RemainingCharges > 0)
                    {
                        RemainingCharges--;
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }
                }
                else
                {
                    res = true;
                }

                if (IsToggle && res)
                {
                    this.IsActive = true;
                }
            }


            if (res)
            {
                res = UseAbilitySpecial();
            }

            if (res)
            {
                if(AbilityUsed != null)
                {
                    AbilityUsed.Invoke(this);
                }
            }
            /* TODO : Create another method for overwriting. This one should be universal for all abilities. */

            return res;
        }


        /* This will be overwritten by special abilities. */
        public virtual bool UseAbilitySpecial()
        {
            return true;
        }

        public virtual PlayerAbilityDescriptor ConvertToDescriptor()
        {
            PlayerAbilityDescriptor desc = new PlayerAbilityDescriptor();
            desc.AbilityName = this.Name;
            desc.RemainingCharges = this.RemainingCharges;
            desc.IsActive = this.IsActive;
            desc.ConnectedObject = this;

            return desc;
        }

        public virtual void ResolveFromDescriptor(PlayerAbilityDescriptor desc)
        {
            desc.ConnectedObject = this;
            this.RemainingCharges = desc.RemainingCharges;
            this.IsActive = desc.IsActive;
            this.ResolveOptions(desc.Options1);

        }

        public virtual void InitializeSubscriptions(PlayerCharacter c)
        {
            /* TODO - This will be overwritten by special abilities. */
        }

        public virtual bool ExtraChoiceOptions(out string btnText, out ExtraChoiceEventHandler clickHandler)
        {
            btnText = "None";
            clickHandler = null;
            /* Return false : No extra choice options are available. */
            return false;
        }

        public virtual void HandleInfoButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show(this.Description);
        }

        public virtual List<BonusValueModifier> getDifficultyClass()
        {
            /* This can be overridden by special abilities. */
            return new List<BonusValueModifier>();
        }

        protected virtual void ResolveOptions(List<string> options)
        {
            /* This can be overwritten by special abilities. */
        }
    }
}
