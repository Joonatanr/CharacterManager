using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClassArchetype : PlayerAbility
    {
        public string ArcheTypeName;

        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel1 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel2 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel3 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel4 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel5 = new List<PlayerClassAbilityChoice>();

        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel6 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel7 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel8 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel9 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel10 = new List<PlayerClassAbilityChoice>();

        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel11 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel12 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel13 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel14 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel15 = new List<PlayerClassAbilityChoice>();

        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel16 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel17 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel18 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel19 = new List<PlayerClassAbilityChoice>();
        public List<PlayerClassAbilityChoice> AvailableAbilitiesAtLevel20 = new List<PlayerClassAbilityChoice>();

        [XmlIgnore]
        public override string DisplayedName
        {
            get { return ArcheTypeName;  }
        }

        public List<PlayerClassAbilityChoice> getAbilityChoicesByLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return AvailableAbilitiesAtLevel1;
                case 2:
                    return AvailableAbilitiesAtLevel2;
                case 3:
                    return AvailableAbilitiesAtLevel3;
                case 4:
                    return AvailableAbilitiesAtLevel4;
                case 5:
                    return AvailableAbilitiesAtLevel5;
                case 6:
                    return AvailableAbilitiesAtLevel6;
                case 7:
                    return AvailableAbilitiesAtLevel7;
                case 8:
                    return AvailableAbilitiesAtLevel8;
                case 9:
                    return AvailableAbilitiesAtLevel9;
                case 10:
                    return AvailableAbilitiesAtLevel10;
                case 11:
                    return AvailableAbilitiesAtLevel11;
                case 12:
                    return AvailableAbilitiesAtLevel12;
                case 13:
                    return AvailableAbilitiesAtLevel13;
                case 14:
                    return AvailableAbilitiesAtLevel14;
                case 15:
                    return AvailableAbilitiesAtLevel15;
                case 16:
                    return AvailableAbilitiesAtLevel16;
                case 17:
                    return AvailableAbilitiesAtLevel17;
                case 18:
                    return AvailableAbilitiesAtLevel18;
                case 19:
                    return AvailableAbilitiesAtLevel19;
                case 20:
                    return AvailableAbilitiesAtLevel20;
                default:
                    return null;
            }
        }

    }
}
