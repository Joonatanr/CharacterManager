﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClass
    {
        public String PlayerClassName;
        public int HitDie;

        public List<String> WeaponProficiencies = new List<String>();
        public List<String> ArmorProficiencies = new List<String>();
        public List<String> SavingThrowProficiencies = new List<String>();
        public List<String> AvailableSkillProficiencies = new List<String>();
        public int NumberOfSkillsToChoose;
        public List<EquipmentChoiceList> AvailableEquipment = new List<EquipmentChoiceList>();

        /* TODO : This probably needs to be able to support multiple choices etc... Lets make a simple test for now. */
        /* Also note that for the time being this is only for level1, so we really need to expand this quite  alot. */
        public List<PlayerClassAbilityChoice> AvailableClassAbilities;

        public PlayerClass()
        {
            PlayerClassName = "UNKNOWN";
        }
    }

    [Serializable]
    public class PlayerClassAbilityChoice
    {
        [Serializable]
        public struct PlayerClassAbilityDescription
        {
            public string AbilityName;
            public string AbilityDescription;
        };
        
        public string Description;
        public string ClassAbilityName;
        public List<PlayerClassAbilityDescription> AvailableChoices { get; set; }

        /* This part is basically defined in C#, so no way to really parse. */
        [XmlIgnore]
        private List<PlayerClassAbility> resolvedAbilities;

        private Boolean isListResolved = false;

        public PlayerClassAbilityChoice()
        {
            this.Description = "UNKNOWN";
        }

        public List<PlayerClassAbility> getAllClassAbilityChoices()
        {
            if (isListResolved == false)
            {
                resolveAbilities();
                isListResolved = true;
            }

            return resolvedAbilities;
        }

        private void resolveAbilities()
        {
            resolvedAbilities = new List<PlayerClassAbility>();
            if (AvailableChoices != null)
            {
                if (AvailableChoices.Count != 0)
                {
                    foreach (PlayerClassAbilityDescription choice in AvailableChoices) 
                    {
                        PlayerClassAbility ability = PlayerClassAbility.resolveFromString(choice.AbilityName, choice.AbilityDescription);
                        if (ability != null)
                        {
                            resolvedAbilities.Add(ability);
                        }
                    }
                }
            }
        }
    }
}
