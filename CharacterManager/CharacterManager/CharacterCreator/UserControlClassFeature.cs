using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.CharacterCreator
{
    public partial class UserControlClassFeature : UserControl
    {
        public PlayerClassAbilityChoice AbilityChoice
        {
            get
            {
                return _abilityChoice;
            }

            set
            {
                _abilityChoice = value;
                updateAbilityChoice();
            }
        }

        private PlayerClassAbilityChoice _abilityChoice;
        private List<PlayerAbility> _abilitiesList;
        private PlayerAbility selectedAbility;

        public delegate void SelectedArchetypeChangedListener(PlayerClassArchetype archetype);
        public SelectedArchetypeChangedListener SelectedArcheTypeChanged;

        public UserControlClassFeature()
        {
            InitializeComponent();
        }

        public PlayerAbility getSelectedAbility()
        {
            return selectedAbility;
        }

        private void updateAbilityChoice()
        {
            /* First create an object list. */
            _abilitiesList =_abilityChoice.getAllClassAbilityChoices();

            /* Update the ability choice visual data. */
            /* 1. Update the description of the ability. */
            if (_abilitiesList.Count > 1)
            {
                labelTitle.Text = _abilityChoice.ClassAbilityName;
                richTextBoxAbilityDescription.Text = _abilityChoice.Description;
            }
            else
            {
                labelTitle.Text = _abilitiesList[0].AttributeName;
                richTextBoxAbilityDescription.Text = _abilitiesList[0].Description;
            }


            if (_abilitiesList.Count > 1)
            {

                comboBoxAbilitySelect.Items.Clear();
                richTextBoxAbilitySub.Clear();

                /* This is a multiple choice ability. */
                foreach (PlayerAbility ability in _abilitiesList)
                {
                    comboBoxAbilitySelect.Items.Add(ability.DisplayedName);
                }


                richTextBoxAbilitySub.Visible = true;
                comboBoxAbilitySelect.Visible = true;
            }
            else
            {
                selectedAbility = _abilitiesList[0];
                /* This is a single choice ability, so no choice really. */
                richTextBoxAbilitySub.Visible = false;
                comboBoxAbilitySelect.Visible = false;
            }
        }

        private void comboBoxAbilitySelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string abilityName = comboBoxAbilitySelect.SelectedItem.ToString();

            selectedAbility = _abilitiesList.Find(t => t.DisplayedName == abilityName);
            if (selectedAbility != null)
            {
                richTextBoxAbilitySub.Text = selectedAbility.Description;
            }

            /* Now it gets interesting. It is possible that we have selected a new archetype and therefore we have to show new things on the form. */
            if(selectedAbility is PlayerClassArchetype)
            {
                if (SelectedArcheTypeChanged != null)
                {
                    SelectedArcheTypeChanged.Invoke((PlayerClassArchetype)selectedAbility);
                }
            }
        }
    }
}
