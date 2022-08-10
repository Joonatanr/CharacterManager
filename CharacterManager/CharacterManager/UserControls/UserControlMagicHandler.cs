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
    public partial class UserControlMagicHandler : UserControl
    {
        private CharacterSpellcastingStatus myStat;
        private List<PlayerSpell> myKnownSpells = new List<PlayerSpell>();
        private List<PlayerSpell> myKnownCantrips = new List<PlayerSpell>();
        
        public UserControlMagicHandler()
        {
            InitializeComponent();
        }

        public void setCharSpellcastingStatus(CharacterSpellcastingStatus stat)
        {
            myStat = stat;

            myKnownSpells = new List<PlayerSpell>();
            myKnownCantrips = new List<PlayerSpell>();

            foreach(string sp in stat.KnownSpells)
            {
                PlayerSpell obj = CharacterFactory.getPlayerSpellFromString(sp);
                if (obj == null)
                {
                    /* TODO : Report error */
                    
                }
                else if(obj.SpellLevel == 0)
                {
                    myKnownCantrips.Add(obj);
                }
                else 
                {
                    myKnownSpells.Add(obj);
                }
            }

            userControlCantripList.setSpellList(myKnownCantrips);
            userControlKnownSpells.setSpellList(myKnownSpells);

            string abilityString = myStat.SpellCastingAbility + "(";

            if (myStat.SpellAbilityModifier > 0)
            {
                abilityString += "+";
            }
            abilityString += myStat.SpellAbilityModifier.ToString();
            abilityString += ")";

            userControlSpellcastingAbility.Value = abilityString;

            string atckBonus = "";
            if(myStat.SpellAttackBonus >= 0) 
            {
                atckBonus += "+";
            }

            atckBonus+= myStat.SpellAttackBonus.ToString();
            userControlSpellAttackBonus.Value = atckBonus;
            userControlSpellsaveDc.Value = myStat.SpellSaveDC.ToString();

            /* Simplistic approach first, TODO */
            int maxPreparedSpells = myStat.MaxNumberOfPreparedSpells;
            if (maxPreparedSpells > 0)
            {
                userControlMaxPreparedSpells.Value = myStat.MaxNumberOfPreparedSpells.ToString();
                userControlKnownSpells.MaximumAvailableChoices = myStat.MaxNumberOfPreparedSpells;

                if (myStat.PreparedSpells != null)
                {
                    foreach (string sp in myStat.PreparedSpells)
                    {
                        /* We must programmatically set the selected spells... */
                        userControlKnownSpells.setSpellSelection(sp, true);
                    }
                }
            }
            else
            {
                userControlMaxPreparedSpells.Value = "N/A";
                /* TODO : Should somehow hide or disable the user control for preparing spells. */
            }
        }

        private void userControlSpellChoice1_Load(object sender, EventArgs e)
        {

        }

        private void UserControlMagicHandler_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void userControlKnownSpells_SpellSelectionChanged(PlayerSpell Spell, bool isChosen)
        {
            List<PlayerSpell> preparedSpells = userControlKnownSpells.getSelectedSpells();
            myStat.PreparedSpells = getSpellNamesFromList(preparedSpells);
            userControlPreparedSpells.setSpellList(preparedSpells);
        }

        private static List<string> getSpellNamesFromList(List<PlayerSpell> spells)
        {
            List<String> res = new List<string>();

            foreach(PlayerSpell sp in spells)
            {
                res.Add(sp.SpellName);
            }

            return res;
        }
    }
}
