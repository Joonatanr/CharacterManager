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

        /* TODO : This probably needs to be able to support multiple choices etc... Lets make a simple test for now. */
        /* Also note that for the time being this is only for level1, so we really need to expand this quite  alot. */
        public List<PlayerClassAbilityChoice> AvailableClassAbilities;

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
