using CharacterManager.CharacterCreator;
using CharacterManager.Spells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class FormLevelup : Form
    {
        private PlayerCharacter _myCharacter;
        private int prevMaxHp;

        private List<PlayerAbility> SelectedPlayerAbilities = new List<PlayerAbility>();

        public PlayerCharacter Character
        {
            set
            {
                _myCharacter = value;
                setupLevelUp();
            }

            get
            {
                return _myCharacter;
            }
        }
        
        public FormLevelup()
        {
            InitializeComponent();
        }

        public FormLevelup(PlayerCharacter character) : this()
        {
            _myCharacter = character;
            setupLevelUp();
        }

        private void setupLevelUp()
        {
            /* 1. Set up hit points */
            setupHitpoints();

            /* 2. Set up new player abilities. */
            setupNewPlayerAbilities();
        }


        private void setupHitpoints()
        {
            prevMaxHp = _myCharacter.MaxHitPoints;
            labelNewMaxHP.Text = prevMaxHp.ToString();

            PlayerClass myClass = _myCharacter.GetPlayerClass();
            int hitDie = myClass.HitDie;

            DieRoll hitDieRoll = new DieRoll(1, hitDie);
            _myCharacter.BonusValues.HitPointLevelupModifiers.Add(new BonusValueModifier("Hit die", hitDieRoll));
            _myCharacter.BonusValues.HitPointLevelupModifiers.Add(new BonusValueModifier("CON bonus", _myCharacter.getModifier("CON")));

            DieRollEquation equation = BonusValueModifier.GetEquationFromList(_myCharacter.BonusValues.HitPointLevelupModifiers);
            equation.ReduceConstants();

            dieRollHitPointsRoll.DieRollObject = equation;
        }

        private void setupNewPlayerAbilities()
        {
            int newLevel = _myCharacter.Level;
            List<PlayerClassAbilityChoice> abilityChoices = _myCharacter.GetPlayerClass().getAvailableClassAbilities(newLevel);

            if (abilityChoices.Count > 0)
            {
                /* We set up the current abilities. */
                /* TODO : Add a way to visually distinguish between current and new abilities. */

                userControlGenericAbilitiesList1.setAttributeList(_myCharacter.CharacterAbilitiesObjectList);

                /* Lets add all abilities for which there is only a single choice already to the list. */
                SelectedPlayerAbilities = new List<PlayerAbility>();

                foreach(PlayerClassAbilityChoice choice in abilityChoices)
                {
                    if(choice.AvailableChoices.Count == 1)
                    {
                        SelectedPlayerAbilities.Add(choice.getAllClassAbilityChoices()[0]);
                    }
                }
                setCombinedAbilitiesDisplay();
            } 
            else
            {
                /* TODO : Placeholder. */
                //groupBoxAbilities.Visible = false;
                buttonSelectNewAbilities.Enabled = false;
            }
        }

        private void setCombinedAbilitiesDisplay()
        {
            List<PlayerAbility> combinedList = new List<PlayerAbility>();
            combinedList.AddRange(SelectedPlayerAbilities);
            combinedList.AddRange(_myCharacter.CharacterAbilitiesObjectList);
            userControlGenericAbilitiesList1.setAttributeList(combinedList);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            /* TODO  : Here we finalize the character. */

            
            _myCharacter.CharacterAbilitiesObjectList.AddRange(SelectedPlayerAbilities);
            _myCharacter.CurrentHitPoints += (_myCharacter.MaxHitPoints - prevMaxHp);

            _myCharacter.UpdateAbilityConnections();

            foreach(PlayerAbility ability in _myCharacter.CharacterAbilitiesObjectList)
            {
                ability.RemainingCharges = ability.MaximumCharges;
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string dummy;
            textBoxHPResult.Text = dieRollHitPointsRoll.Roll(out dummy).ToString();
        }

        private void textBoxHPResult_TextChanged(object sender, EventArgs e)
        {
            int val;
            
            if(int.TryParse(textBoxHPResult.Text, out val))
            {
                _myCharacter.MaxHitPoints = val + prevMaxHp;
                labelNewMaxHP.Text = _myCharacter.MaxHitPoints.ToString();
            }
        }

        private void buttonSelectNewAbilities_Click(object sender, EventArgs e)
        {
            /* TODO : Decide on this -> If there are no choices, then is a form really necessary??? 
             Perhaps in this case, we should simply add the new abilities anyway. */
            
            FormChooseClassFeatures myForm = new FormChooseClassFeatures();
            myForm.setPlayerCharacter(_myCharacter);

            myForm.ShowDialog();
            if(myForm.DialogResult == DialogResult.OK)
            {
                /* We don't add the new abilities to the character yet. This we will do when levelup is finalized. */
                SelectedPlayerAbilities = myForm.getAllSelectedAbilities();
                setCombinedAbilitiesDisplay();
            }
        }

        private void buttonSelectNewSpells_Click(object sender, EventArgs e)
        {
            /* TODO - First we do a naive implementation. Not taking into account that selected abilities might give the PC a spellcasting ability.  */
            if (_myCharacter.IsCharacterSpellCasting())
            {
                FormChooseSpells myForm = new FormChooseSpells();

                /* First lets get a list of spells that are already known. */
                List<PlayerSpell> KnownSpells = _myCharacter.GetKnownSpells();

                /* TODO : We might have classes where spells can be switched when leveling up. */
                myForm.setFixedSpells(KnownSpells);

                PlayerClass _myClass = _myCharacter.GetPlayerClass();

                List<PlayerSpell> SpellsAvailableForLearning = _myClass.GetSpellsThatCanBeLearnedAtLevel(_myCharacter.Level);
                
                /* Add spells */
                myForm.setSpellChoices(SpellsAvailableForLearning, _myClass.SpellCasting.GetNewCantripsLearnedAtLevel(_myCharacter.Level), _myClass.SpellCasting.GetNewSpellsLearnedAtLevel(_myCharacter.Level));

                myForm.ShowDialog();

                /* TODO : Handle result. */

            }
            else
            {
                MessageBox.Show("No spellcasting for this character");
            }
        }
    }
}
