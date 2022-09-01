﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static CharacterManager.CharacterCreator.UserControlClassFeature;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAbility
    {

        public string Description;
        public string AttributeName;
        public int MaximumCharges = 0; /* Maximum uses 0 indicates a passive ability. */ /* TODO : Should take levels etc. into account. */
        public Boolean IsToggle = false; /* Can the ability be toggled on or off. */
        public Boolean RechargeAtShortRest = false;
        public Boolean RechargeAtLongRest = false;

        [XmlIgnore]
        public virtual string DisplayedName { get { return AttributeName; } } /* This should be used instead of the AttributeName*/

        [XmlIgnore]
        public int RemainingCharges = 0;

        [XmlIgnore]
        public Boolean IsActive = false;

        public PlayerAbility()
        {
            AttributeName = "UNKNOWN";
            Description = "<BLANK>";
        }

        public PlayerAbility(String name)
        {
            AttributeName = name;
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
            desc.AbilityName = this.AttributeName;
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

        protected virtual void ResolveOptions(List<string> options)
        {
            /* This can be overwritten by special abilities. */
        }
    }
}
