using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.Spells
{
    public partial class Spellcard : Form
    {
        private PlayerSpell mySpell;

        private readonly string[] numberStrings =
        {
            "Cantrip",
            "1st level",
            "2nd level",
            "3rd level",
            "4th level",
            "5th level",
            "6th level",
            "7th level",
            "8th level",
            "9th level",
        };


        public Spellcard()
        {
            InitializeComponent();
        }
        
        public void setSpell(PlayerSpell spell)
        {
            mySpell = spell;
            UpdateVisualComponents();
        }

        public static void ShowSpellCard(PlayerSpell spell)
        {
            Spellcard card = new Spellcard();
            card.setSpell(spell);
            card.ShowDialog();
        }

        private void UpdateVisualComponents()
        {
            /* 1. Update spell name. */
            labelSpellName.Text = mySpell.DisplayedName;

            /* 2. Update spell type description. */
            String txt;
            if (mySpell.SpellLevel <= 9)
            {
                txt = numberStrings[mySpell.SpellLevel];
            }
            else
            {
                txt = "Unknown";
            }

            txt += " " + mySpell.School;
            labelSpellType.Text = txt;

            /*3. Update casting time. */
            switch (mySpell.CastingTime)
            {
                case PlayerSpell.CastingTimeEnum.CASTING_TIME_ACTION:
                    labelCastingTime.Text = "1 action";
                    break;
                case PlayerSpell.CastingTimeEnum.CASTING_TIME_BONUS_ACTION:
                    labelCastingTime.Text = "1 bonus action";
                    break;
                case PlayerSpell.CastingTimeEnum.CASTING_TIME_PERIOD:
                    String periodTxt = "";
                    if (mySpell.IsConcentration)
                    {
                        periodTxt = "Concentration, ";
                    }
                    periodTxt += getDurationString(mySpell.CastingTimePeriod);
                    labelCastingTime.Text = periodTxt; 
                    break;
                default:
                    labelCastingTime.Text = "UNKNOWN";
                    break;
            }

            /*4. Update Range */
            labelRange.Text = mySpell.SpellRange.ToString() + " feet";


            /*5. Update Components. */
            String compString = "";
            if (mySpell.IsVerbalComponent)
            {
                compString += "V ";
            }

            if (mySpell.IsSomaticComponent)
            {
                compString += " S";
            }

            if (mySpell.IsMaterialComponent)
            {
                compString += " M";
            }
            labelComponents.Text = compString;

            /*6. Update duration. */
            String durString;

            if(mySpell.SpellDuration > 0)
            {
                durString = getDurationString(mySpell.SpellDuration);
            }
            else 
            {
                durString = "Instantaneous";
            }

            labelDuration.Text = durString;

            /*7. Update description. */
            richtTextBoxDescription.Text = mySpell.Description;


            /* TODO : Separate AT Higher Levels text. - This should be done before we add a lot of spells, etc. */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String getDurationString(int turns)
        {
            String res = "";
            if(turns <= 10)
            {
                /* Not sure if this actually happens. */
                res = turns.ToString() + " turns";
            }
            else if(turns < 600)
            {
                int minutes = turns / 10;
                res = minutes.ToString() + " minutes";
            }
            else
            {
                int hours = turns / 600;
                res = hours.ToString() + " hours";
            }

            return res;
        }
    }

    public partial class CustomRTB : RichTextBox
    {
        public CustomRTB() : base()
        {
            //InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //This makes the control's background transparent
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}
