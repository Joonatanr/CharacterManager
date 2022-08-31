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
        
        public FormChooseCombatManeuvers()
        {
            InitializeComponent();
        }

        private void updateAvailableManeuvers()
        {
            userControlManeuverChoiceAvailableManeuvers.setAvailableManeuverChoices(_myAbility.AvailableManeuverObjects);
        }
    }
}
