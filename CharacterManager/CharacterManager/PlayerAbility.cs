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

        public string Description;
        public string Name;

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
        
        public Boolean IsToggle = false; /* Can the ability be toggled on or off. */
        public Boolean RechargeAtShortRest = false;
        public Boolean RechargeAtLongRest = false;
        public string Dice; /* A lot of playerabilities have some kind of diceroll associated with it. */

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

        [XmlIgnore]
        public Boolean IsActive = false;

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

        public event PlayerAbilityValueChanged MaximumChargesChanged;
        public event PlayerAbilityValueChanged RemainingChargesChanged;


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

        public virtual Boolean UseAbility(PlayerCharacter c)
        {
            /* This will be overwritten by special abilities. */
            if (this.IsToggle)
            {
                if (this.IsActive)
                {
                    this.IsActive = false;
                }
                else
                {
                    this.IsActive = true;
                }
            }

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

        protected virtual void ResolveOptions(List<string> options)
        {
            /* This can be overwritten by special abilities. */
        }
    }
}
