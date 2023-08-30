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

        private bool _isCastingInfoVisible = false;
        public bool IsCastingInfoVisible
        {
            get
            {
                return _isCastingInfoVisible;
            }

            set
            {
                _isCastingInfoVisible = value;
                if (_isCastingInfoVisible)
                {
                    groupBoxCasting.Enabled = true;
                    groupBoxCasting.Visible = true;
                }
                else
                {
                    groupBoxCasting.Enabled = false;
                    groupBoxCasting.Visible = false;
                }
            }
        }

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

            if (mySpell.IsRitual)
            {
                txt += " (ritual)";
            }

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
                case PlayerSpell.CastingTimeEnum.CASTING_TIME_REACTION:
                    labelCastingTime.Text = "Reaction";
                    break;
                default:
                    labelCastingTime.Text = "UNKNOWN";
                    break;
            }
        }

        private string getRangeText(int range)
        {
            if(range < 5280)
            {
                return range.ToString() + " feet";
            }
            else
            {
                int milesRange = range / 5280;
                if(milesRange > 1)
                {
                    return milesRange.ToString() + " miles";
                }
                else
                {
                    return milesRange.ToString() + " mile";
                }
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
                else if(mySpell.RangeType == PlayerSpell.SpellRangeType.RANGE_TYPE_UNLIMITED)
                {
                    labelRange.Text = "Unlimited";
                }
                else if(mySpell.RangeType == PlayerSpell.SpellRangeType.RANGE_TYPE_SIGHT)
                {
                    labelRange.Text = "Sight";
                }
                else
                {
                    labelRange.Text = getRangeText(mySpell.SpellRange);
                }
            }
            else
            {
                labelRange.Text = getRangeText(mySpell.SpellRange);
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
                compString += "S ";
            }

            if (mySpell.IsMaterialComponent)
            {
                compString += "M ";
            }

            if(mySpell.IsMaterialComponent && !string.IsNullOrEmpty(mySpell.MaterialComponent))
            {
                compString += " (";
                compString += mySpell.MaterialComponent;
                compString += ")";
            }

            labelComponents.Text = compString;
        }

        private void updateDuration()
        {
            String durString;

            if (this.mySpell.IsUntilDispelled)
            {
                durString = "Until dispelled";
            }
            else 
            { 

                if (mySpell.SpellDuration > 0)
                {
                    durString = getDurationString(mySpell.SpellDuration);
                    if (mySpell.IsConcentration)
                    {
                        durString = "Concentration, up to " + durString;
                    }
                }
                else
                {
                    durString = "Instantaneous";
                }
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

            /*8. Update the Casting info. */
            if (this.IsCastingInfoVisible)
            {
                if (mySpell.SpellLevel == 0)
                {
                    numericUpDown1.Minimum = 0;
                    int spellcasterLevel = GlobalMagicEvents.GetSpellCasterLevel();
                    /* We do a hack for cantrips... */
                    if(spellcasterLevel < 5)
                    {
                        numericUpDown1.Maximum = 0;
                    }else if(spellcasterLevel < 11)
                    {
                        numericUpDown1.Maximum = 1;
                    }else if(spellcasterLevel < 17)
                    {
                        numericUpDown1.Maximum = 2;
                    }
                    else
                    {
                        numericUpDown1.Maximum = 3;
                    }


                    numericUpDown1.Value = numericUpDown1.Maximum;
                    numericUpDown1.Enabled = false;
                }
                else
                {
                    numericUpDown1.Minimum = this.mySpell.SpellLevel;
                    numericUpDown1.Maximum = 9; /* TODO : Placeholder. */
                    numericUpDown1.Value = numericUpDown1.Minimum;
                    numericUpDown1.Enabled = true;
                }
            }
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
            else if(turns <= 14400)
            {
                int hours = turns / 600;
                res = hours.ToString() + " hours";
            }
            else
            {
                int days = turns / 14400;
                res = days.ToString() + " days";
            }

            return res;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int selectedLevel = (int)numericUpDown1.Value;
            List<DieRollComponent> myComponents = mySpell.getDiceForSpellLevel(selectedLevel);

            if (mySpell.IsSpellCastingModifierAddedToDice)
            {
                myComponents.Add(new DieRollConstant(GlobalMagicEvents.GetSpellcastingAbilityModifier()));
            }
            
            if (myComponents != null)
            {
                dieRollTextBox1.Text = DieRollEquation.createStringFromDieRollComponents(myComponents, true); 
            }
            else
            {
                dieRollTextBox1.Text = "";    
            }
        }

        private void buttonRollDice_Click(object sender, EventArgs e)
        {
            rollDice();
        }

        private void rollDice()
        {
            try
            {
                string output;
                if (!string.IsNullOrEmpty(dieRollTextBox1.Text))
                {
                    dieRollTextBox1.Roll(out output);
                    richTextBox1.AppendText(output + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    GlobalMagicEvents.ReportMagicRoll(mySpell.SpellName + " : " + output);
                }
            }
            catch (Exception)
            {

            }
        }


        private void buttonCast_Click(object sender, EventArgs e)
        {
            if (GlobalMagicEvents.CastSpell(mySpell, (int)numericUpDown1.Value) == false)
            {
                MessageBox.Show("No level " + (int)numericUpDown1.Value + " spell slots remaining");
            }
            else
            {
                if (checkBoxCombinedCastRoll.Checked)
                {
                    if (mySpell.IsAttackRoll)
                    {
                        string output;

                        int attackBonus = GlobalMagicEvents.GetSpellAttackBonus();
                        DieRollComponent d20 = DieRollComponent.parseFromString("d20");
                        DieRollConstant bonus = new DieRollConstant(attackBonus);
                        DieRollEquation myEquation = new DieRollEquation();
                        myEquation.DieRollComponents.Add(d20);
                        myEquation.DieRollComponents.Add(bonus);
                        myEquation.RollValue(out output);
                        string report = "Spell Attack roll: " + output;
                        richTextBox1.AppendText(report + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                        GlobalMagicEvents.ReportMagicRoll(report);

                    }
                    rollDice();
                }
            }
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
