using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerRace
    {
        /* Lets test some very basic stuff first. */
        public String RaceName { get; set; }
        public PlayerCharacter.CharacterBaseAttributes BonusAttributes { get; set; }
        public int NumberOfGenericBonusAttributes { get; set; } //Basically the number of "add N to attributes of your choice. "
        public int MaximumAge { get; set; }

        public PlayerCharacter.PlayerSize.SizeDescriptor Size { get; set; }
        public int BaseSpeed { get; set; } = 0;

        public List<String> ArmorProficiencies = new List<String>();
        public List<String> WeaponProficiencies = new List<String>();
        public List<String> SkillProficiencies = new List<String>();
        public List<String> PlayerAttributes = new List<String>();

        public List<PlayerRace> SubRaces = new List<PlayerRace>();

        [XmlIgnore]
        private List<PlayerAttribute> PlayerAttributeReferences = new List<PlayerAttribute>(); /* This contains a list of references that need to be resolved. */


        private bool isInitialized = false;

        public PlayerRace()
        {
            this.RaceName = "UNKNOWN";
        }

        public PlayerRace(String Name)
        {
            RaceName = Name;
        }

        public List<PlayerAttribute> getPlayerAttributes()
        {
            if (!isInitialized)
            {
                throw new Exception("Error : Player attribute list has not been initialized yet");
            }
            return PlayerAttributeReferences;
        }

        public void Initialize(List<PlayerAttribute> listOfAvailableAttributes)
        {
            isInitialized = true;

            foreach (String attribStr in PlayerAttributes)
            {
                PlayerAttribute attrib = listOfAvailableAttributes.Find(a => a.AttributeName == attribStr);
                if (attrib != null)
                {
                    PlayerAttributeReferences.Add(attrib);
                }
                else
                {
                    throw new Exception("Error unknown attribute : " + attribStr);
                }
            }

            foreach (PlayerRace sub in SubRaces)
            {
                sub.Initialize(listOfAvailableAttributes);
            }
        }
    }
}
