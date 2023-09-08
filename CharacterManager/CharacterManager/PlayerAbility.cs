using CharacterManager.Items;
using CharacterManager.UserControls;
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
    public class PlayerAbility : PlayerBaseItem
    {
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
        public Boolean IsUsable { get; set; } = false; /* Can the ability be used? (as opposed to a passive ability) */
        public Boolean RechargeAtShortRest { get; set; } = false;
        public Boolean RechargeAtLongRest { get; set; } = false;
        public string Dice { get; set; } /* A lot of playerabilities have some kind of diceroll associated with it. */

        public Boolean IsHidden { get; set; } = false; /* If true, then this ability should not be displayed in a list. In fact it will be applied once and then "forgotten". */
        public List<PlayerAbilityUpgrade> Upgrades { get; set; }

        [XmlIgnore]
        public List<string> UpgradeDescriptions = new List<string>();

        /* TODO : Implement this part. */
        public List<string> SpellsAddedByAbility = new List<string>();

        /* Often abilities have charges that are equal to an attribute modifier (such as charges based on CHA mod) */
        public string ChargesBasedOnAbilityModifier = "NONE";
        /* Some abilities have charges that are equal to an attribute modifier +1, (such as charges equal to CHA mod +1 ) */
        public bool IsPlusOneAddedToChargeBasedOnModifier = false;

        public bool ChargesBasedOnLevel = false;
        public int ChargesBasedOnLevelMultiplies = 1;


        /* Some abilities gain extra skill proficiencies or even expertise */
        public int AdditionalProficiencyChoices { get; set; } = 0;
        public int AdditionalExpertiseChoices { get; set; } = 0;

        /* Some abilities might increase base attributes. */
        public int StrIncrease = 0;
        public int DexIncrease = 0;
        public int WisIncrease = 0;
        public int ConIncrease = 0;
        public int ChaIncrease = 0;
        public int IntIncrease = 0;


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

            /* Here we can resolve all possible upgrades. */
            resolveUpgrades();

            /* Here we can also resolve cases where the total number of charges depend on player attributes. */
            if (this.ChargesBasedOnAbilityModifier != "NONE")
            {
                int totalCharges = c.getModifier(ChargesBasedOnAbilityModifier);
                
                if (IsPlusOneAddedToChargeBasedOnModifier)
                {
                    totalCharges++;
                }

                this.MaximumCharges = totalCharges;
            }
            else if (ChargesBasedOnLevel)
            {
                int totalCharges = c.Level;
                totalCharges *= ChargesBasedOnLevelMultiplies;
                this.MaximumCharges = totalCharges;
            }
        }

        public string GetExtendedDescription()
        {
            string res = string.Copy(Description);

            foreach(string upgrade in UpgradeDescriptions)
            {
                res += upgrade;
            }

            return res;
        }

        private void resolveUpgrades()
        {
            if (_connectedCharacter != null)
            {
                int level = _connectedCharacter.Level;

                /* There is a problem here.. Some upgrades might already have been applied (such as during levelling up. 
So we get to an issue where upgrades to the description are added multiple times. */
                UpgradeDescriptions = new List<string>();

                if (Upgrades != null)
                {
                    List<PlayerAbilityUpgrade> myUpgrades = Upgrades.OrderBy(u => u.Level).ToList();

                    foreach (PlayerAbilityUpgrade upgrade in myUpgrades)
                    {
                        if (upgrade.Level <= level)
                        {
                            applyUpgrade(upgrade);
                        }
                    }
                }
            }
        }

        private void applyUpgrade(PlayerAbilityUpgrade upgrade)
        {
            /* TODO : There should be a better way to do this. */
            if (upgrade.Dice != null)
            {
                this.Dice = upgrade.Dice;
            }
            if (upgrade.MaximumCharges > 0)
            {
                this.MaximumCharges = upgrade.MaximumCharges;
            }

            if (!string.IsNullOrEmpty(upgrade.AdditionalDescription))
            {
                string fullString = "";
                
                fullString += Environment.NewLine;
                fullString += Environment.NewLine;
                fullString += upgrade.AdditionalDescription;
                UpgradeDescriptions.Add(fullString);
            }
        }

        /// <summary>
        /// This should be accessed if the ability will return some situational attack modifiers immediately after it is used.
        /// Basically this is used for an ability that gives bonuses for a single attack. An ability that can provide bonuses
        /// consistently while active, such as Rage should modify the attack bonuses through the PlayerCharacter event handlers.
        /// </summary>
        /// <returns></returns>
        public virtual List<BonusValueModifier> getSituationalAttackModifiers()
        {
            /* Here we just return an empty list. Subclasses can return something interesting. */
            return new List<BonusValueModifier>();
        }

        /// <summary>
        /// This should be accessed if the ability will return some situational damage modifiers immediately after it is used.
        /// Basically this is used for an ability that gives bonuses for a single attack. An ability that can provide bonuses
        /// consistently while active, such as Rage should modify the attack bonuses through the PlayerCharacter event handlers.
        /// </summary>
        /// <returns></returns>
        public virtual List<BonusValueModifier> getSituationalDamageModifiers()
        {
            /* Here we just return an empty list. Subclasses can return something interesting. */
            return new List<BonusValueModifier>();
        }


        public virtual List<PlayerClassAbilityChoice> GetUpgradeChoicesForLevel(int level)
        {
            /* The idea is that some abilities might present choices when upgrading them. For example the selection
            of new combat maneuvers, replacing some thing etc. 
            By default we return an empty list. */
            List<PlayerClassAbilityChoice> res = new List<PlayerClassAbilityChoice>();
            return res;
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

        /// <summary>
        /// This is fired when an ability is selected. It can be used by special abilities, that add or change something
        /// to the character, such as weapon, tool, language proficiencies, skills, expertise etc.
        /// </summary>
        /// <param name="c"></param>
        public virtual void HandleAbilitySelected(PlayerCharacter c)
        {
            /* Can be overridden by abilities. */
            c.StrengthAttribute += StrIncrease;
            c.DexAttribute += DexIncrease;
            c.ConAttribute += ConIncrease;
            c.CharAttribute += ChaIncrease;
            c.IntAttribute += IntIncrease;
            c.WisAttribute += WisIncrease;
        }

        public virtual void HandleInfoButtonClicked(object sender, EventArgs e)
        {
            //MessageBox.Show(this.Description);
            AbilityCard card = new AbilityCard();
            card.setAbility(this);
            card.Show();
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
