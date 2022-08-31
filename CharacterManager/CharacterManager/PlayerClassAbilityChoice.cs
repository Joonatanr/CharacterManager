using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClassAbilityChoice
    {
        public string Description;
        public string ClassAbilityName
        {
            get
            {
                if (this.AvailableChoices.Count == 1)
                {
                    /* We use the name of the first choice in this case. */
                    return this.AvailableChoices[0];
                }
                else
                {
                    return _classAbilityName;
                }
            }

            set
            {
                _classAbilityName = value;
            }
        }
        public List<string> AvailableChoices { get; set; }

        /* This part is basically defined in C#, so no way to really parse. */
        [XmlIgnore]
        private List<PlayerAbility> resolvedAbilities;

        private Boolean isListResolved = false;
        private string _classAbilityName; /* Name for a list of choices */


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

        public void setAbilityChoices(List<PlayerAbility> choices)
        {
            this.resolvedAbilities = choices;
            List<string> abilityNames = new List<string>();

            foreach (PlayerAbility ability in choices)
            {
                abilityNames.Add(ability.DisplayedName);
            }

            AvailableChoices = abilityNames;
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
