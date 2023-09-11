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

        public PlayerCharacter Character { get; set; }

        private PlayerClassAbilityChoice _abilityChoice;
        private List<PlayerAbility> _abilitiesList;
        private PlayerAbility selectedAbility;

        public delegate void SelectedArchetypeChangedListener(PlayerClassArchetype archetype);
        public SelectedArchetypeChangedListener SelectedArcheTypeChanged;

        public delegate void ExtraChoiceEventHandler(PlayerCharacter c);
        private ExtraChoiceEventHandler ExtraChoiceClicked = null;

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
            if (Character != null)
            {
                List<PlayerAbility> allAbilities = _abilityChoice.getAllClassAbilityChoices();
                _abilitiesList = new List<PlayerAbility>();

                /* Check that we don't add options for things that already exist, such as fighting styles etc. */
                foreach (PlayerAbility ability in allAbilities)
                {
                    if (Character.CharacterAbilities.Find(a => (a.AbilityName == ability.Name) && (a.SubType == ability.SubType)) == null)
                    {
                        _abilitiesList.Add(ability);
                    }
                }
            }
            else
            {
                _abilitiesList = _abilityChoice.getAllClassAbilityChoices();
            }

            /* Update the ability choice visual data. */
            /* 1. Update the description of the ability. */
            if (_abilitiesList.Count > 1)
            {
                labelTitle.Text = _abilityChoice.ClassAbilityName;
                richTextBoxAbilityDescription.Text = _abilityChoice.Description;
            }
            else
            {
                labelTitle.Text = _abilitiesList[0].Name;
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

                /* For a single choice ability, we might still have some extra choices that need to be made. */
                string btnText;
                ExtraChoiceEventHandler eventHandler;

                if (selectedAbility.ExtraChoiceOptions(out btnText, out eventHandler) == true)
                {
                    this.buttonExtraChoices.Text = btnText;
                    this.buttonExtraChoices.Visible = true;
                    this.ExtraChoiceClicked = eventHandler;
                }
                else
                {
                    this.buttonExtraChoices.Visible = false;
                }

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

        private void buttonExtraChoices_Click(object sender, EventArgs e)
        {
            /* Placeholder. This should be replaced if the button is actually used. */
            if(this.ExtraChoiceClicked != null)
            {
                ExtraChoiceClicked.Invoke(Character);
            }
        }
    }
}
