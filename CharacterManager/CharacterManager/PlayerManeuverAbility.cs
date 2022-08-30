using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager
{
    [Serializable]
    public class PlayerManeuverAbility : PlayerAbility
    {
        public List<string> AvailableManeuvers = new List<string>();
    }
}
