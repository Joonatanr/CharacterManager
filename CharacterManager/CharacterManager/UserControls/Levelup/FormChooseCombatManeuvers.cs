using CharacterManager.SpecialAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls.Levelup
{
    public partial class FormChooseCombatManeuvers : Form
    {
        private PlayerManeuverAbility _myAbility;

        public PlayerManeuverAbility ManeuverAbility
        {
            get
            {
                return _myAbility;
            }

            set
            {
                _myAbility = value;
                updateAvailableManeuvers();
            }
        }

        private PlayerCharacter _myCharacter = null;

        public PlayerCharacter Character 
        {
            get { return _myCharacter; }
            set
            {
                _myCharacter = value;
                updateAvailableManeuvers();
                updateExistingManeuvers();
            }
        }
        
        public FormChooseCombatManeuvers()
        {
            InitializeComponent();
        }

        public List<CombatManeuver> GetChosenCombatManeuvers()
        {
            return userControlManeuverChoiceAvailableManeuvers.getSelectedItems();
        }

        private void updateAvailableManeuvers()
        {
            userControlManeuverChoiceAvailableManeuvers.setAvailableManeuverChoices(_myAbility.AvailableManeuverObjects);

            if (_myCharacter != null)
            {
                /* Lets see how many maneuvers we can choose at this level */
                int maxChoices = _myAbility.getAvailableChoicesAtLevel(_myCharacter.Level);
                userControlManeuverChoiceAvailableManeuvers.MaximumAvailableChoices = maxChoices;
            }

            userControlManeuverChoiceAvailableManeuvers.ItemSelectionChanged += new UserControlBaseChoice<CombatManeuver>.ItemChoiceChangedListener(ManeuverChoiceChanged);
        }

        private void ManeuverChoiceChanged(CombatManeuver maneuver, bool isSelected)
        {
            List<CombatManeuver> chosenManeuvers = userControlManeuverChoiceAvailableManeuvers.getSelectedItems();
            userControlManeuverChoiceChosenManeuvers.setItemList(chosenManeuvers);
        }

        private void updateExistingManeuvers()
        {
            /* TODO Implement this! */
            /* So it is possible that we are currently leveling up and there are already some existing maneuvers that the character knows. */
            if(_myCharacter != null)
            {
                List<PlayerAbility> abilitiesList = _myCharacter.CharacterAbilitiesObjectList;
                PlayerAbility existingAbility = abilitiesList.Find(a => a.AttributeName == this._myAbility.AttributeName);
                
                if (existingAbility != null) 
                {
                    if (existingAbility is PlayerManeuverAbility)
                    {
                        /* Simple sanity check */
                        PlayerManeuverAbility existingManeuverAbility = existingAbility as PlayerManeuverAbility;
                        List<CombatManeuver> existingManeuvers = existingManeuverAbility.ChosenManeuverObjects;
                        userControlManeuverChoiceAvailableManeuvers.setFixedItemList(existingManeuvers);
                    }
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this._myAbility.ChosenManeuverObjects = userControlManeuverChoiceAvailableManeuvers.getSelectedItems();
            this.Close();
        }
    }
}
