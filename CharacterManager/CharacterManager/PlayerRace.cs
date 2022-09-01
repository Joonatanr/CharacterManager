using CharacterManager.Spells;
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
        public String RaceName { get; set; }
        public PlayerCharacter.CharacterBaseAttributes BonusAttributes { get; set; }
        public int NumberOfGenericBonusAttributes { get; set; } = 0;    //Basically the number of "add N to attributes of your choice. "
        public int NumberOfGenericSkillProficiencies { get; set; } = 0; //Similarly, the number of "add N to skill proficiencies of your choice. "
        public int MaximumAge { get; set; }

        public PlayerCharacter.PlayerSize.SizeDescriptor Size { get; set; }
        public int BaseSpeed { get; set; } = 0;

        public List<String> ArmorProficiencies = new List<String>();
        public List<String> WeaponProficiencies = new List<String>();
        public List<String> SkillProficiencies = new List<String>();
        public List<String> ToolProficiencies = new List<String>();
        public List<String> Spells = new List<String>(); //These are spells and cantrips that are provided solely by the player race.
        public List<String> PlayerAttributes = new List<String>();

        public List<PlayerRace> SubRaces = new List<PlayerRace>();

        [XmlIgnore]
        private List<PlayerAbility> PlayerAttributeReferences = new List<PlayerAbility>(); /* This contains a list of references that need to be resolved. */

        [XmlIgnore]
        private List<PlayerSpell> PlayerSpellReferences = new List<PlayerSpell>(); /* This contains a list of spell references that need to be resolved. */

        private bool isInitialized = false;

        public PlayerRace()
        {
            this.RaceName = "UNKNOWN";
        }

        public PlayerRace(String Name)
        {
            RaceName = Name;
        }

        public List<PlayerAbility> getPlayerAttributes()
        {
            if (!isInitialized)
            {
                throw new Exception("Error : Player attribute list has not been initialized yet");
            }
            return PlayerAttributeReferences;
        }

        public List<PlayerSpell> getPlayerSpells()
        {
            if (!isInitialized)
            {
                throw new Exception("Error : Player spell list has not been initialized yet");
            }
            return PlayerSpellReferences;
        }

        public void Initialize(List<PlayerAbility> listOfAvailableAttributes, List<PlayerSpell> listOfAvailableSpells)
        {
            isInitialized = true;

            foreach (String attribStr in PlayerAttributes)
            {
                PlayerAbility attrib = listOfAvailableAttributes.Find(a => a.Name == attribStr);
                if (attrib != null)
                {
                    PlayerAttributeReferences.Add(attrib);
                }
                else
                {
                    throw new Exception("Error unknown attribute : " + attribStr);
                }
            }

            foreach(String spellStr in Spells)
            {
                PlayerSpell pSpell = listOfAvailableSpells.Find(s => s.SpellName == spellStr);
                if (pSpell != null)
                {
                    PlayerSpellReferences.Add(pSpell);
                }
                else
                {
                    throw new Exception("Error unknown spell : " + spellStr);
                }
            }

            foreach (PlayerRace sub in SubRaces)
            {
                sub.Initialize(listOfAvailableAttributes, listOfAvailableSpells);
            }
        }
    }
}
