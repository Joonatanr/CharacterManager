using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class PlayerClass
    {
        public String PlayerClassName;

        public PlayerClass()
        {
            PlayerClassName = "UNKNOWN";
        }
    }
}
