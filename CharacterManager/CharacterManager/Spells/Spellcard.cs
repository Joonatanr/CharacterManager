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
            this.DoubleBuffered = true;
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

        private void updateSpellName()
        {
            labelSpellName.Text = mySpell.DisplayedName;
        }

        private void updateSpellTypeDescription()
        {
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
        }

        private void updateCastingTime()
        {
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
                    periodTxt += getDurationString(mySpell.CastingTimePeriod);
                    labelCastingTime.Text = periodTxt;
                    break;
                default:
                    labelCastingTime.Text = "UNKNOWN";
                    break;
            }
        }

        private void updateRange()
        {
            if (mySpell.SpellRange == 0) 
            {
                if(mySpell.RangeType == PlayerSpell.SpellRangeType.RANGE_TYPE_SELF)
                {
                    string txt = "Self";
                    
                    if (mySpell.AoeType == PlayerSpell.AreaOfEffectType.AOE_TYPE_CONE)
                    {
                        txt += "(" + mySpell.AoeSize.ToString() + "-ft cone)";
                    }
                    else if(mySpell.AoeType == PlayerSpell.AreaOfEffectType.AOE_TYPE_SPHERE)
                    {
                        txt += "(" + mySpell.AoeSize.ToString() + "-ft sphere)";
                    }
                    else if (mySpell.AoeType == PlayerSpell.AreaOfEffectType.AOE_TYPE_CUBE)
                    {
                        txt += "(" + mySpell.AoeSize.ToString() + "-ft cube)";
                    }

                    labelRange.Text = txt;
                }
                else if(mySpell.RangeType == PlayerSpell.SpellRangeType.RANGE_TYPE_TOUCH)
                {
                    labelRange.Text = "Touch";
                }
                else
                {
                    labelRange.Text = mySpell.SpellRange.ToString() + " feet";
                }
            }
            else
            {
                labelRange.Text = mySpell.SpellRange.ToString() + " feet";
            }
        }

        private void updateComponents()
        {
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
        }

        private void updateDuration()
        {
            String durString;

            if (mySpell.SpellDuration > 0)
            {
                if (mySpell.IsConcentration)
                {
                    durString = "Concentration, ";
                }
                durString = getDurationString(mySpell.SpellDuration);
            }
            else
            {
                durString = "Instantaneous";
            }

            labelDuration.Text = durString;
        }

        private void updateDescription()
        {
            richTextBoxDescription.Text = mySpell.Description;
            richTextBoxDescription.AppendText("\r\n\r\n");
            if (!string.IsNullOrEmpty(mySpell.AtHigherLevels)) 
            {
                string str = "At higher Levels:";
                string str1 = Environment.NewLine + mySpell.AtHigherLevels;
                int length = richTextBoxDescription.Text.Length;
                richTextBoxDescription.AppendText((Convert.ToString((str + str1) + "\r") + "\n"));
                richTextBoxDescription.Select(length, str.Length);
                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
            }
        }

        private void UpdateVisualComponents()
        {
            /* 1. Update spell name. */
            updateSpellName();

            /* 2. Update spell type description. */
            updateSpellTypeDescription();

            /*3. Update casting time. */
            updateCastingTime();

            /*4. Update Range */
            updateRange();

            /*5. Update Components. */
            updateComponents();

            /*6. Update duration. */
            updateDuration();

            /*7. Update description. */
            updateDescription();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private String getDurationString(int turns)
        {
            String res = "";
            if(turns < 10)
            {
                /* Not sure if this actually happens. */
                res = turns.ToString() + " turns";
            }
            else if(turns < 600)
            {
                int minutes = turns / 10;
                if (minutes > 1)
                {
                    res = minutes.ToString() + " minutes";
                }
                else
                {
                    res = "1 minute";
                }
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
