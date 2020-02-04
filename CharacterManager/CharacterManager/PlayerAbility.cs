using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAbility
    {

        public string Description;
        public string AttributeName;
        public int MaximumCharges = 0; /* Maximum uses 0 indicates a passive ability. */ /* TODO : Should take levels etc. into account. */

        [XmlIgnore]
        public virtual string DisplayedName { get { return AttributeName; } } /* This should be used instead of the AttributeName*/

        [XmlIgnore]
        public int RemainingCharges = 0;

        public PlayerAbility()
        {
            AttributeName = "UNKNOWN";
            Description = "<BLANK>";
        }

        public PlayerAbility(String name)
        {
            AttributeName = name;
        }

        internal static PlayerAbility resolveFromString(string s)
        {
            return CharacterFactory.getPlayerAbilityFromString(s);
        }

        public virtual void InitializeSubscriptions(PlayerCharacter c)
        {
            /* TODO - This will be overwritten by special abilities. */
        }
    }
}
