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
        
        public int AvailableManeuversAtLevel1 = 0;
        public int AvailableManeuversAtLevel2 = 0;
        public int AvailableManeuversAtLevel3 = 0;
        public int AvailableManeuversAtLevel4 = 0;
        public int AvailableManeuversAtLevel5 = 0;
        public int AvailableManeuversAtLevel6 = 0;
        public int AvailableManeuversAtLevel7 = 0;
        public int AvailableManeuversAtLevel8 = 0;
        public int AvailableManeuversAtLevel9 = 0;
        public int AvailableManeuversAtLevel10 = 0;
        public int AvailableManeuversAtLevel11 = 0;
        public int AvailableManeuversAtLevel12 = 0;
        public int AvailableManeuversAtLevel13 = 0;
        public int AvailableManeuversAtLevel14 = 0;
        public int AvailableManeuversAtLevel15 = 0;
        public int AvailableManeuversAtLevel16 = 0;
        public int AvailableManeuversAtLevel17 = 0;
        public int AvailableManeuversAtLevel18 = 0;
        public int AvailableManeuversAtLevel19 = 0;
        public int AvailableManeuversAtLevel20 = 0;

        private List<CombatManeuver> _availableManeuverAbilities = null;
        [XmlIgnore]
        public List<CombatManeuver> AvailableManeuverObjects
        {
            get
            {
                if (!isListResolved)
                {
                    resolveManeuverList();
                    isListResolved = true;
                }
                return _availableManeuverAbilities;
            }

            set
            {
                _availableManeuverAbilities = value;
            }
        }

        [XmlIgnore]
        private Boolean isListResolved = false;

        /* TODO : We should notifiy if the user has not selected all available maneuvers. */

        public override bool ExtraChoiceOptions(out string btnText, out EventHandler clickHandler)
        {
            btnText = "Choose Maneuvers";
            clickHandler = new EventHandler(handleManeuverChoice);
            return true;
        }

        
        public int getAvailableChoicesAtLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return AvailableManeuversAtLevel1;
                case 2:
                    return AvailableManeuversAtLevel2;
                case 3:
                    return AvailableManeuversAtLevel3;
                case 4:
                    return AvailableManeuversAtLevel4;
                case 5:
                    return AvailableManeuversAtLevel5;
                case 6:
                    return AvailableManeuversAtLevel6;
                case 7:
                    return AvailableManeuversAtLevel7;
                case 8:
                    return AvailableManeuversAtLevel8;
                case 9:
                    return AvailableManeuversAtLevel9;
                case 10:
                    return AvailableManeuversAtLevel10;
                case 11:
                    return AvailableManeuversAtLevel11;
                case 12:
                    return AvailableManeuversAtLevel12;
                case 13:
                    return AvailableManeuversAtLevel13;
                case 14:
                    return AvailableManeuversAtLevel14;
                case 15:
                    return AvailableManeuversAtLevel15;
                case 16:
                    return AvailableManeuversAtLevel16;
                case 17:
                    return AvailableManeuversAtLevel17;
                case 18:
                    return AvailableManeuversAtLevel18;
                case 19:
                    return AvailableManeuversAtLevel19;
                case 20:
                    return AvailableManeuversAtLevel20;
                default:
                    return 0;
            }
        }


        private void handleManeuverChoice(object sender, System.EventArgs e)
        {
            FormChooseCombatManeuvers myForm = new FormChooseCombatManeuvers();
            resolveManeuverList();
            myForm.ManeuverAbility = this;
            myForm.Show();

            /* TODO : This is a placeholder. */
        }


        private void resolveManeuverList()
        {
            _availableManeuverAbilities = new List<CombatManeuver>();
            List<CombatManeuver> definedManeuvers = CharacterFactory.getAllCombatManeuvers();
            
            foreach (string maneuever in AvailableManeuvers)
            {
                CombatManeuver resolvedManeuver = definedManeuvers.Find(m => m.ManeuverName == maneuever);
                
                if(resolvedManeuver != null)
                {
                    AvailableManeuverObjects.Add(resolvedManeuver);
                }
            }
        }
    }
}
