using CharacterManager.SpecialAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls.ChoiceList
{
    public class UserControlManeuverChoice : UserControlBaseChoice<CombatManeuver>
    {
        public UserControlManeuverChoice() : base()
        {

        }
        
        public void setAvailableManeuverChoices(List<CombatManeuver> maneuvers)
        {
            this.setItemList(maneuvers);
        }
    }
}
