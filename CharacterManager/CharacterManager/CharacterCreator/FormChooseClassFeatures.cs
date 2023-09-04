using CharacterManager.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.CharacterCreator
{
    public partial class FormChooseClassFeatures : Form
    {
        private PlayerClass _selectedClass = null;
        private int _currentLevel;
        private PlayerCharacter _currentCharacter = null;

        public FormChooseClassFeatures()
        {
            InitializeComponent();
        }


        public void setPlayerCharacter(PlayerCharacter Character)
        {
            _currentCharacter = Character;
            _currentLevel = Character.Level;
            _selectedClass = Character.GetPlayerClass();
            setupChoices();   
        }


        public void setSelectedClassAndLevel(PlayerClass c, int level)
        {
            _selectedClass = c;
            _currentLevel = level;
            _currentCharacter = null;
            setupChoices();
        }

        private void setupChoices()
        {
            groupBoxClassAbilities.Controls.Clear();

            int yloc = 15;

            List<PlayerClassAbilityChoice> choicesList = new List<PlayerClassAbilityChoice>();

            foreach (PlayerClassAbilityChoice choice in _selectedClass.getAvailableClassAbilities(_currentLevel))
            {
                choicesList.Add(choice);
            }

            /* We want to display the spellcasting ability as a player ability in the form. */
            if (_selectedClass.SpellCasting != null)
            {
                PlayerClassAbilityChoice spellCastingChoice = choicesList.Find(ch => ch.ClassAbilityName.ToLower() == "spellcasting");

                if (spellCastingChoice != null)
                {
                    spellCastingChoice.Description = _selectedClass.SpellCasting.Description;
                }
            }

            /* Check if we have the choice of a new Archetype. */
            PlayerClassAbilityChoice archetypeChoice = choicesList.Find(ch => ch.ClassAbilityName.ToLower() == "archetype");

            if (archetypeChoice != null)
            {
                List<PlayerAbility> archeTypeList = new List<PlayerAbility>();

                /* Set up this choice. */
                List<PlayerAbility> choiceList = archetypeChoice.getAllClassAbilityChoices();

                foreach (PlayerAbility ability in choiceList)
                {
                    PlayerClassArchetype correspondingArchetype = _selectedClass.ArcheTypes.Find(at => at.ArcheTypeName == ability.Name);
                    if (correspondingArchetype != null)
                    {
                        archeTypeList.Add(correspondingArchetype);
                    }
                }

                archetypeChoice.setAbilityChoices(archeTypeList);
            }

            /* Adding the actual user controls. */
            foreach (PlayerClassAbilityChoice choice in choicesList)
            {

                /* Lets create a user control for each.*/
                yloc = AddUserControlClassFeature(choice, yloc, _currentCharacter);
            }

            /* Now lets set up tool proficiencies if any... */
            if(_currentLevel == 1)
            {
                List<ToolProficiencyChoice> toolChoices = _selectedClass.AvailableToolProficiencies;
                setupToolProficiencyChoices(toolChoices);
            }

            /* TODO : We might have abilities that could give us tool proficiencies... */
            /* TODO : Maybe find a way to hide the tool proficiencies groupbox if there are none available? */
        }


        public List<string> getChosenToolProficiencies()
        {
            List<string> res = new List<string>();

            foreach(Control c in groupBoxToolProficiencies.Controls)
            {
                if(c is UserControlToolProficiencyChoiceVer2)
                {
                    UserControlToolProficiencyChoiceVer2 cast = c as UserControlToolProficiencyChoiceVer2;
                    res.Add(cast.getSelectedToolProficiency());
                }
            }

            return res;
        }

        private void setupToolProficiencyChoices(List<ToolProficiencyChoice> toolChoices)
        {
            groupBoxToolProficiencies.Controls.Clear();
            int y = 15;

            foreach(ToolProficiencyChoice choice in toolChoices)
            {
                UserControlToolProficiencyChoiceVer2 myControl = new UserControlToolProficiencyChoiceVer2();
                myControl.setToolProficiencyChoice(choice);
                myControl.Location = new Point(5, y);
                y += myControl.Height;
                y += 5;

                groupBoxToolProficiencies.Controls.Add(myControl);
            }
        }

        /* Returns the next free Y position. */
        private int AddUserControlClassFeature(PlayerClassAbilityChoice choice, int yloc, PlayerCharacter Character)
        {
            UserControlClassFeature ctrl = new UserControlClassFeature();
            ctrl.AbilityChoice = choice;
            ctrl.Character = Character;
            ctrl.Location = new Point(5, yloc);
            ctrl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            ctrl.Width = groupBoxClassAbilities.Width - 10;
            ctrl.SelectedArcheTypeChanged = new UserControlClassFeature.SelectedArchetypeChangedListener(SelectedArchetypeChanged);
            groupBoxClassAbilities.Controls.Add(ctrl);

            yloc += ctrl.Height;
            yloc += 5;

            return yloc;
        }

        private PlayerClassArchetype currArchetype = null;

        private void SelectedArchetypeChanged(PlayerClassArchetype newArcheType)
        {   
            /* Lets first check if we have not already selected this archetype. Combobox will fire even if same value is retained...*/
            if (newArcheType == currArchetype)
            {
                return;
            }

            /* First we need to get a new set of possible choices. */
            List<PlayerClassAbilityChoice> ArcheTypeChoices = newArcheType.getAbilityChoicesByLevel(_currentLevel);
            List<PlayerClassAbilityChoice> ExistingChoices =_selectedClass.getAvailableClassAbilities(_currentLevel);

            List<UserControlClassFeature> controlsToRemove = new List<UserControlClassFeature>();

            int LowerMostPosition = 0;

            foreach (UserControl ctrl in groupBoxClassAbilities.Controls)
            {
                if (ctrl is UserControlClassFeature)
                {
                    UserControlClassFeature cast = (UserControlClassFeature)ctrl;
                    if  (ExistingChoices.Find(item => item.ClassAbilityName == cast.AbilityChoice.ClassAbilityName) == null)
                    {
                        /* We assume this control belongs to a previously selected Archetype and is no longer valid. */
                        controlsToRemove.Add(cast);
                    }
                    else
                    {
                        LowerMostPosition = Math.Max(LowerMostPosition, ctrl.Bottom);
                    }
                }
            }

            foreach(UserControlClassFeature ctrl in controlsToRemove)
            {
                groupBoxClassAbilities.Controls.Remove(ctrl);
            }

            /* 2. Add new controls. */
            /* Lets always add these to the end of the other controls. */
            int yloc = LowerMostPosition + 5;

            foreach (PlayerClassAbilityChoice choice in ArcheTypeChoices)
            {
                yloc = AddUserControlClassFeature(choice, yloc, _currentCharacter);
            }

            currArchetype = newArcheType;
        }


        public List<PlayerAbility> getAllSelectedAbilities()
        {
            List<PlayerAbility> res = new List<PlayerAbility>();
            
            foreach(Control c in groupBoxClassAbilities.Controls)
            {
                if (c is UserControlClassFeature)
                {
                    UserControlClassFeature cast = (UserControlClassFeature)c;
                    PlayerAbility ability = cast.getSelectedAbility();
                    if (ability != null)
                    {
                        if(ability.MaximumCharges > 0)
                        {
                            ability.RemainingCharges = ability.MaximumCharges;
                        }

                        res.Add(ability);
                    }
                }
            }

            return res;
        }


        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
