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
        private List<PlayerSpell> myPreparedSpells = new List<PlayerSpell>();
        private List<PlayerSpell> myKnownCantrips = new List<PlayerSpell>();
        
        public UserControlMagicHandler()
        {
            InitializeComponent();
        }

        public void setCharSpellcastingStatus(CharacterSpellcastingStatus stat)
        {
            myStat = stat;

            myPreparedSpells = new List<PlayerSpell>();
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
            userControlSpellcastingAbility.Value = myStat.SpellCastingAbility;

            string atckBonus = "";
            if(myStat.SpellAttackBonus >= 0) 
            {
                atckBonus += "+";
            }

            atckBonus+= myStat.SpellAttackBonus.ToString();
            userControlSpellAttackBonus.Value = atckBonus;
            userControlSpellsaveDc.Value = myStat.SpellSaveDC.ToString();
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
    }
}
