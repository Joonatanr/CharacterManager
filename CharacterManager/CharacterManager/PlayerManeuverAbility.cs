using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    [Serializable]
    public class PlayerManeuverAbility : PlayerAbility
    {
        public List<string> AvailableManeuvers = new List<string>();

        /* TODO : We should notifiy if the user has not selected all available maneuvers. */

        public override bool ExtraChoiceOptions(out string btnText, out EventHandler clickHandler)
        {
            btnText = "Choose Maneuvers";
            clickHandler = new EventHandler(handleManeuverChoice);
            return true;
        }

        private void handleManeuverChoice(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }
    }
}
