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
        
        public FormChooseClassFeatures()
        {
            InitializeComponent();
        }

        public void setSelectedClassAndLevel(PlayerClass c, int level)
        {
            _selectedClass = c;
            _currentLevel = level;

            groupBox1.Controls.Clear();

            int yloc = 15;

            List<PlayerClassAbilityChoice> choicesList = new List<PlayerClassAbilityChoice>();

            foreach (PlayerClassAbilityChoice choice in _selectedClass.getAvailableClassAbilities(level))
            {
                choicesList.Add(choice);
            }

            /* We want to display the spellcasting ability as a player ability in the form. */
            if (c.SpellCasting != null)
            {
                PlayerClassAbilityChoice spellCastingChoice = choicesList.Find(ch => ch.ClassAbilityName == "SpellCasting");
                
                if(spellCastingChoice != null)
                {
                    spellCastingChoice.Description = c.SpellCasting.Description;
                }
            }

            /* Check if we have the choice of a new Archetype. */
            PlayerClassAbilityChoice archetypeChoice = choicesList.Find(ch => ch.ClassAbilityName == "Archetype");
            
            if(archetypeChoice != null)
            {
                List<PlayerAbility> archeTypeList = new List<PlayerAbility>();

                /* Set up this choice. */
                List<PlayerAbility> choiceList = archetypeChoice.getAllClassAbilityChoices();
                
                foreach(PlayerAbility ability in choiceList)
                {
                    PlayerClassArchetype correspondingArchetype = c.ArcheTypes.Find(at => at.ArcheTypeName == ability.AttributeName);
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
                yloc = AddUserControlClassFeature(choice, yloc);
            }
        }


        /* Returns the next free Y position. */
        private int AddUserControlClassFeature(PlayerClassAbilityChoice choice, int yloc)
        {
            UserControlClassFeature ctrl = new UserControlClassFeature();
            ctrl.AbilityChoice = choice;
            ctrl.Location = new Point(5, yloc);
            ctrl.Anchor = (AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left);
            ctrl.Width = groupBox1.Width - 10;
            ctrl.SelectedArcheTypeChanged = new UserControlClassFeature.SelectedArchetypeChangedListener(SelectedArchetypeChanged);
            groupBox1.Controls.Add(ctrl);

            yloc += ctrl.Height;
            yloc += 5;

            return yloc;
        }

        private void SelectedArchetypeChanged(PlayerClassArchetype newArcheType)
        {
            /* TODO */
            /* First we need to get a new set of possible choices. */
            List<PlayerClassAbilityChoice> ArcheTypeChoices = newArcheType.getAbilityChoicesByLevel(_currentLevel);
            List<PlayerClassAbilityChoice> ExistingChoices =_selectedClass.getAvailableClassAbilities(_currentLevel);

            List<UserControlClassFeature> controlsToRemove = new List<UserControlClassFeature>();

            int LowerMostPosition = 0;

            foreach(UserControl ctrl in groupBox1.Controls)
            {
                if (ctrl is UserControlClassFeature)
                {
                    UserControlClassFeature cast = (UserControlClassFeature)ctrl;
                    if ((ArcheTypeChoices.Find(item => item.ClassAbilityName == cast.AbilityChoice.ClassAbilityName) == null) &&
                       (ExistingChoices.Find(item => item.ClassAbilityName == cast.AbilityChoice.ClassAbilityName) == null))
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
                groupBox1.Controls.Remove(ctrl);
            }

            /* 2. Add new controls. */
            /* Lets always add these to the end of the other controls. */
            int yloc = LowerMostPosition + 5;

            foreach(PlayerClassAbilityChoice choice in ArcheTypeChoices)
            {
                yloc = AddUserControlClassFeature(choice, yloc);
            }
        }


        public List<PlayerAbility> getAllSelectedAbilities()
        {
            List<PlayerAbility> res = new List<PlayerAbility>();
            
            foreach(Control c in groupBox1.Controls)
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
