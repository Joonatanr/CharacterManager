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
        private List<CombatManeuver> _availableManeuvers = new List<CombatManeuver>();
        
        public List<CombatManeuver> AvailableManeuvers
        {
            get
            {
                return _availableManeuvers;
            }

            set
            {
                _availableManeuvers = value;
                updateAvailableManeuvers();
            }
        }
        
        public FormChooseCombatManeuvers()
        {
            InitializeComponent();
        }

        private void updateAvailableManeuvers()
        {
            userControlManeuverChoiceAvailableManeuvers.setAvailableManeuverChoices(_availableManeuvers);
        }
    }
}
