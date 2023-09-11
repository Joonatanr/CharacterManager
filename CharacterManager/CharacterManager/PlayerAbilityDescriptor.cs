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

        /* Some abilities have options that can be chosen. These need a storage variable. */
        public List<string> Options1 = new List<string>();

        /* We use this mostly for describing spellcasting abilities and in the future for differentiating between them if we
         ever begin to implement multiclassing. */
        public string SubType = "";

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
