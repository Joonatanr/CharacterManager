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
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            /* TODO */
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
    }
}
