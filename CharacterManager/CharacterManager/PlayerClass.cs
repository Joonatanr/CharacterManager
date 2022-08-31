using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using CharacterManager.SpecialAttributes;
using CharacterManager.Spells;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClass
    {
        [Serializable]
        public class SpellSlots_T
        {
            public int NumberOfLev1SpellSlots = 0;
            public int NumberOfLev2SpellSlots = 0;
            public int NumberOfLev3SpellSlots = 0;
            public int NumberOfLev4SpellSlots = 0;
            public int NumberOfLev5SpellSlots = 0;
            public int NumberOfLev6SpellSlots = 0;
            public int NumberOfLev7SpellSlots = 0;
            public int NumberOfLev8SpellSlots = 0;
            public int NumberOfLev9SpellSlots = 0;

            public int getNumberOfSlotsPerLevel(int level)
            {
                switch (level)
                {
                    case 1:
                        return NumberOfLev1SpellSlots;
                    case 2 :
                        return NumberOfLev2SpellSlots;
                    case 3:
                        return NumberOfLev3SpellSlots;
                    case 4:
                        return NumberOfLev4SpellSlots;
                    case 5:
                        return NumberOfLev5SpellSlots;
                    case 6:
                        return NumberOfLev6SpellSlots;
                    case 7:
                        return NumberOfLev7SpellSlots;
                    case 8:
                        return NumberOfLev8SpellSlots;
                    case 9:
                        return NumberOfLev9SpellSlots;
                    default:
                        return 0;
                }
            }
        }

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
        public SpellSlots_T[] SpellslotPerLevel = new SpellSlots_T[20]
        {
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
            new SpellSlots_T(),
        };

        /* Looks like we need to use this crude implementation because dotnet cannot serialize an array of lists... */

        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel1 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel2 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel3 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel4 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel5 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel6 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel7 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel8 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel9 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel10 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel11 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel12 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel13 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel14 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel15 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel16 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel17 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel18 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel19 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableClassAbilitiesLevel20 = new List<PlayerClassAbilityChoice>();

        public List<PlayerClassArchetype> ArcheTypes = new List<PlayerClassArchetype>();


        public PlayerClass()
        {
            PlayerClassName = "UNKNOWN";
        }

        public List<PlayerSpell> GetAvailableSpells()
        {
            List<PlayerSpell> res = new List<PlayerSpell>();
            foreach(string s in AvailableSpells)
            {
                res.Add(PlayerSpell.resolveFromString(s));
            }

            return res;
        }

        public List<PlayerClassAbilityChoice> getAvailableClassAbilities(int level)
        {
            switch (level)
            {
                case 1:
                    return AvailableClassAbilitiesLevel1;
                case 2:
                    return AvailableClassAbilitiesLevel2;
                case 3:
                    return AvailableClassAbilitiesLevel3;
                case 4:
                    return AvailableClassAbilitiesLevel4;
                case 5:
                    return AvailableClassAbilitiesLevel5;
                case 6:
                    return AvailableClassAbilitiesLevel6;
                case 7:
                    return AvailableClassAbilitiesLevel7;
                case 8:
                    return AvailableClassAbilitiesLevel8;
                case 9:
                    return AvailableClassAbilitiesLevel9;
                case 10:
                    return AvailableClassAbilitiesLevel10;
                case 11:
                    return AvailableClassAbilitiesLevel11;
                case 12:
                    return AvailableClassAbilitiesLevel12;
                case 13:
                    return AvailableClassAbilitiesLevel13;
                case 14:
                    return AvailableClassAbilitiesLevel14;
                case 15:
                    return AvailableClassAbilitiesLevel15;
                case 16:
                    return AvailableClassAbilitiesLevel16;
                case 17:
                    return AvailableClassAbilitiesLevel17;
                case 18:
                    return AvailableClassAbilitiesLevel18;
                case 19:
                    return AvailableClassAbilitiesLevel19;
                case 20:
                    return AvailableClassAbilitiesLevel20;
                default:
                    return null;
            }
        }
    }

    [Serializable]
    public class PlayerClassAbilityChoice
    {   
        public string Description;
        public string ClassAbilityName
        {
            get
            {
                if(this.AvailableChoices.Count == 1)
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

            foreach(PlayerAbility ability in choices)
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
