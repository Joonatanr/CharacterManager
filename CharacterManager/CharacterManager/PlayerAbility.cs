using CharacterManager.Items;
using CharacterManager.Spells;
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
        /* We use this mostly for describing spellcasting abilities and in the future for differentiating between them if we
           ever begin to implement multiclassing. */
        public string SubType = "";
        public bool IsCombatAbility { get; set; } = false;

        /* Some abilities replace others completely. Usually this is the case with some specific upgrades.
         For example this is the case with multiattack x2 being replaced by multiattack x3. */
        public string ReplacesAbility = "";

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

        /* Some abilities can add new spells. */
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

        public List<String> AdditionalArmorProficiencies = new List<string>();

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
        public DieRollTextBox.RollResultHandler RollReporter = null;

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
            this.MaximumCharges = GetMaximumCharges(c);

            /* Here we add any new spells granted by the ability. */
            foreach(string spellName in SpellsAddedByAbility)
            {
                c.AddSpell(spellName);
            }
        }

        public virtual void HandleLongRest()
        {
            if (this.RechargeAtLongRest)
            {
                this.RemainingCharges = this.MaximumCharges;
            }
        }

        public virtual void HandleShortRest()
        {
            if (this.RechargeAtShortRest)
            {
                this.RemainingCharges = this.MaximumCharges;
            }
        }

        public virtual void HandleInit()
        {
            if (this.MaximumCharges > 0)
            {
                this.RemainingCharges = this.MaximumCharges;
            }
        }

        protected virtual int GetMaximumCharges(PlayerCharacter c)
        {
            /* Here we can also resolve cases where the total number of charges depend on player attributes. */
            if (this.ChargesBasedOnAbilityModifier != "NONE")
            {
                int totalCharges = c.getModifier(ChargesBasedOnAbilityModifier);

                if (IsPlusOneAddedToChargeBasedOnModifier)
                {
                    totalCharges++;
                }

                return totalCharges;
            }
            else if (ChargesBasedOnLevel)
            {
                int totalCharges = c.Level;
                totalCharges *= ChargesBasedOnLevelMultiplies;
                return totalCharges;
            }

            return this.MaximumCharges;
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

            SpellsAddedByAbility.AddRange(upgrade.AdditionalSpellsAddedByAbility);
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

        public void RechargeAbility()
        {
            this.RemainingCharges = this.MaximumCharges;
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
            desc.SubType = this.SubType;
            desc.ConnectedObject = this;

            return desc;
        }

        public virtual void ResolveFromDescriptor(PlayerAbilityDescriptor desc)
        {
            desc.ConnectedObject = this;
            this.RemainingCharges = desc.RemainingCharges;
            this.IsActive = desc.IsActive;
            this.SubType = desc.SubType;
            this.ResolveOptions(desc.Options1);
        }

        public virtual void InitializeSubscriptions(PlayerCharacter c)
        {
            /* This can be overwritten by special abilities. */
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
        public virtual void HandleAbilitySelected(PlayerCharacter c, out List<PlayerSpell> spellsAddedByAbility)
        {
            spellsAddedByAbility = new List<PlayerSpell>();
            
            /* Can be overridden by abilities. */
            c.StrengthAttribute += StrIncrease;
            c.DexAttribute += DexIncrease;
            c.ConAttribute += ConIncrease;
            c.CharAttribute += ChaIncrease;
            c.IntAttribute += IntIncrease;
            c.WisAttribute += WisIncrease;


            int numberOfAnySpells = 0;
            int numberOfAnySpellOrCantrip = 0;

            /* Some abilities might allow us to select new spells */
            foreach(string spellString in SpellsAddedByAbility)
            {
                /* TODO : Some abilities might give us new spells from another class spell list. That can also be handled here... */
                if (spellString.ToLower() == "anyspell")
                {
                    numberOfAnySpells++;
                }
                else if (spellString.ToLower() == "anyspellorcantrip")
                {
                    numberOfAnySpellOrCantrip++;
                }
                else
                {

                }
            }

            if (numberOfAnySpells > 0 || numberOfAnySpellOrCantrip > 0)
            {

                if (numberOfAnySpells > 0)
                {
                    MessageBox.Show("You can choose " + numberOfAnySpells + " spells from any class.");
                }

                if (numberOfAnySpellOrCantrip > 0)
                {
                    MessageBox.Show("You can choose " + numberOfAnySpellOrCantrip + " spells or cantrips from any class.");
                }

                CharacterCreator.FormChooseSpells myForm = new CharacterCreator.FormChooseSpells();

                myForm.setFixedSpells(c.GetKnownSpells(), 0);

                /* So in this case the only restriction for learning spells is their level. */
                List<PlayerSpell> SpellsAvailableForLearning = CharacterFactory.getSpellsOfLevelAndLower(c.SpellCasting.GetMaximumSpellSlotLevelAtLevel(c.Level));
                myForm.setSpellChoices(SpellsAvailableForLearning, 0, numberOfAnySpells, numberOfAnySpellOrCantrip);
                if (myForm.ShowDialog() == DialogResult.OK)
                {
                    spellsAddedByAbility.AddRange(myForm.getChosenPlayerSpells());                    
                }
                else
                {
                    /* TODO : What do we do if the selection is cancelled??? Should be possible perhaps to go back and modify all the choices? */
                }
            }

            /* We might get new armor proficiencies from abilities... */
            foreach(string armorProficiency in this.AdditionalArmorProficiencies)
            {
                if (!c.ArmorProficiencies.Contains(armorProficiency))
                {
                    c.ArmorProficiencies.Add(armorProficiency);
                }
            }
        }

        public virtual void HandleInfoButtonClicked(object sender, EventArgs e)
        {
            AbilityCard card = new AbilityCard();
            card.setAbility(this);
            card.RollReporter = this.RollReporter;
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

        /// <summary>
        /// Some abilities might have generic "options" or info items that can be returned here.
        /// Some of these might depend on player choices or dierolls, or the ability could be activated in
        /// a certain way... Lets try and handle these here.
        /// </summary>
        /// <returns></returns>
        public virtual List<PlayerAbilityInfoItem> GetInfoItems()
        {
            List<PlayerAbilityInfoItem> res = new List<PlayerAbilityInfoItem>();
            //By default we return an empty list.
            return res;
        }

        public virtual void UseAbilityInfoItem(PlayerAbilityInfoItem item)
        {
            /* By default we do not do anything here. */
        }

        public virtual String GetInfoItemsLabel()
        {
            return "Ability Data";
        }
    }
}
