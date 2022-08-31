using CharacterManager.SpecialAttributes;
using CharacterManager.UserControls.Levelup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace CharacterManager
{
    [Serializable]
    public class PlayerManeuverAbility : PlayerAbility
    {
        public List<string> AvailableManeuvers = new List<string>();

        [XmlIgnore]
        private List<CombatManeuver> _availableManeuverObjects = null;

        [XmlIgnore]
        private Boolean isListResolved = false;

        /* TODO : We should notifiy if the user has not selected all available maneuvers. */

        public override bool ExtraChoiceOptions(out string btnText, out EventHandler clickHandler)
        {
            btnText = "Choose Maneuvers";
            clickHandler = new EventHandler(handleManeuverChoice);
            return true;
        }

        private void handleManeuverChoice(object sender, System.EventArgs e)
        {
            FormChooseCombatManeuvers myForm = new FormChooseCombatManeuvers();
            resolveManeuverList();
            myForm.AvailableManeuvers = this._availableManeuverObjects;
            myForm.Show();

            /* TODO : This is a placeholder. */
        }

        private void resolveManeuverList()
        {
            _availableManeuverObjects = new List<CombatManeuver>();
            List<CombatManeuver> definedManeuvers = CharacterFactory.getAllCombatManeuvers();
            
            foreach (string maneuever in AvailableManeuvers)
            {
                CombatManeuver resolvedManeuver = definedManeuvers.Find(m => m.ManeuverName == maneuever);
                
                if(resolvedManeuver != null)
                {
                    _availableManeuverObjects.Add(resolvedManeuver);
                }
            }
        }
    }
}
