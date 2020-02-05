using CharacterManager.SpecialAttributes;
using System;
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

        public SpellcastingAbility SpellCasting = null;
        public List<String> AvailableSpells = new List<String>();

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
        public string Description;
        public string ClassAbilityName;
        public List<string> AvailableChoices { get; set; }

        /* This part is basically defined in C#, so no way to really parse. */
        [XmlIgnore]
        private List<PlayerAbility> resolvedAbilities;

        private Boolean isListResolved = false;

        public PlayerClassAbilityChoice()
        {
            this.Description = "UNKNOWN";
        }

        public List<PlayerAbility> getAllClassAbilityChoices()
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
            resolvedAbilities = new List<PlayerAbility>();
            if (AvailableChoices != null)
            {
                if (AvailableChoices.Count != 0)
                {
                    foreach (string choice in AvailableChoices) 
                    {
                        PlayerAbility ability = PlayerAbility.resolveFromString(choice);
                        if (ability != null)
                        {
                            resolvedAbilities.Add(ability);
                        }
                        else
                        {
                            PlayerAbility obj = new PlayerAbility(choice);
                            obj.Description = this.Description;
                            resolvedAbilities.Add(obj);
                        }
                    }
                }
            }
        }
    }
}
