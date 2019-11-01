using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class PlayerAttribute
    {

        public string Description;
        public string AttributeName;

        public PlayerAttribute()
        {
            AttributeName = "UNKNOWN";
            Description = "<BLANK>";
        }

        public PlayerAttribute(String name)
        {
            AttributeName = name;
        }

    }
}
