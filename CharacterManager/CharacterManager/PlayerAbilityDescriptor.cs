using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAbilityDescriptor
    {
        public string AbilityName;
        public int RemainingCharges = 0;
        public Boolean IsActive = false;

        [XmlIgnore]
        public PlayerAbility ConnectedObject = null;

        public PlayerAbilityDescriptor()
        {
            AbilityName = "UNKNOWN";
        }

        public PlayerAbilityDescriptor(String name)
        {
            AbilityName = name;
        }
    }
}
