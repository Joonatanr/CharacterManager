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
        public String PlayerClassName;
        public int HitDie;

        public List<String> WeaponProficiencies = new List<String>();
        public List<String> ArmorProficiencies = new List<String>();
        public List<String> SavingThrowProficiencies = new List<String>();
        public List<String> AvailableSkillProficiencies = new List<String>();
        public int NumberOfSkillsToChoose;
        public List<EquipmentChoiceList> AvailableEquipment = new List<EquipmentChoiceList>();

        public SpellcastingAbility SpellCasting = null;


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

        public List<int> AbilityScoreImprovementsAtLevels = new List<int>();

        public PlayerClass()
        {
            PlayerClassName = "UNKNOWN";
        }

        public int getSpellSlotsForLevel(int playerLevel, int spellSlotLevel)
        {
            if(this.SpellCasting != null)
            {
                if(playerLevel < 1 || playerLevel > 20) 
                {
                    return 0;
                }

                if(spellSlotLevel < 0 || spellSlotLevel > 9)
                {
                    return 0;
                }

                return this.SpellCasting.SpellslotPerLevel[playerLevel - 1].getNumberOfSlotsPerLevel(spellSlotLevel);
            }
            else
            {
                return 0;
            }
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

        public Boolean IsAbilityScoreImprovementAtLevel(int level)
        {
            if (AbilityScoreImprovementsAtLevels.Contains(level))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    
}
