using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<PlayerRace> SubRaces = new List<PlayerRace>();

        public PlayerRace()
        {
            this.RaceName = "UNKNOWN";
        }

        public PlayerRace(String Name)
        {
            RaceName = Name;
        }
    }
}
