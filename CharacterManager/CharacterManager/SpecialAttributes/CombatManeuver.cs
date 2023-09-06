using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.SpecialAttributes
{
    [Serializable]
    public class CombatManeuver : PlayerBaseItem
    {
        public string ManeuverName;

        public override string Name { get => ManeuverName; set => ManeuverName = value; } 
    }
}
