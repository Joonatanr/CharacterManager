using CharacterManager.Items;
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
    public partial class FormWeaponAttack : Form
    {
        private PlayerWeapon _weapon;

        public PlayerWeapon Weapon
        {
            get
            {
                return _weapon;
            }

            set
            {
                _weapon = value;
                string weaponName = _weapon.ItemName;
               
                if (_weapon.IsVersatile)
                {
                    if (_weapon.IsEquippedTwoHanded)
                    {
                        weaponName += "(2H)";
                    }
                    else
                    {
                        weaponName += "(1H)";
                    }
                }

                if (_weapon.IsRanged)
                {
                    textBoxRange.Text = _weapon.Range.NormalRange.ToString() + " / " + _weapon.Range.LongRange.ToString();
                }
                else
                {
                    textBoxRange.Text = "Melee";
                }

                labelWeaponName.Text = weaponName;

                
            }
        }

        public List<BonusValueModifier> AttackModifiers
        {
            get
            {
                return userControlAttackDieRolls.Modifiers;
            }

            set
            {
                userControlAttackDieRolls.Modifiers = value;
            }
        }

        public List<BonusValueModifier> DamageModifiers
        {
            get
            {
                return userControlDamageDieRoll.Modifiers;
            }

            set
            {
                userControlDamageDieRoll.Modifiers = value;
            }
        }
        
        
        public FormWeaponAttack()
        {
            InitializeComponent();

            userControlAttackDieRolls.rollListener = new UserControlDieRollBonusValuesHandler.logRoll(logReport);
            userControlDamageDieRoll.rollListener = new UserControlDieRollBonusValuesHandler.logRoll(logReport);
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWeaponAttack_Load(object sender, EventArgs e)
        {

        }

        private void logReport(string msg, object sender)
        {
            /* TODO : Might need to make this more complex. */
            if (sender == userControlAttackDieRolls)
            {
                msg = "Attack Roll : " + msg; 
            }

            if(sender == userControlDamageDieRoll)
            {
                msg = "Damage Roll: " + msg;
            }

            /* TODO : Might have to handle crits separately. */
            if (msg.Contains("(D20)20"))
            {
                //richTextBoxRolls.AppendText(msg + Environment.NewLine, Color.Green);
                AppendFormattedText(richTextBoxRolls, msg + Environment.NewLine, Color.Green, true, HorizontalAlignment.Left);
            }
            else if (msg.Contains("(D20)1 "))
            {
                AppendFormattedText(richTextBoxRolls, msg + Environment.NewLine, Color.Red, true, HorizontalAlignment.Left);
            }
            else
            {
                richTextBoxRolls.AppendText(msg + Environment.NewLine);
            }
            richTextBoxRolls.ScrollToCaret();
        }


        /// <summary>
        /// Append formatted text to a Rich Text Box control 
        /// </summary>
        /// <param name="rtb">Rich Text Box to which horizontal bar is to be added</param>
        /// <param name="text">Text to be appended to Rich Text Box</param>
        /// <param name="textColour">Colour of text to be appended</param>
        /// <param name="isBold">Flag indicating whether appended text is bold</param>
        /// <param name="alignment">Horizontal alignment of appended text</param>
        private void AppendFormattedText(RichTextBox rtb, string text, Color textColour, Boolean isBold, HorizontalAlignment alignment)
        {
            int start = rtb.TextLength;
            rtb.AppendText(text);
            int end = rtb.TextLength; // now longer by length of appended text

            // Select text that was appended
            rtb.Select(start, end - start);

            #region Apply Formatting
            rtb.SelectionColor = textColour;
            rtb.SelectionAlignment = alignment;
            rtb.SelectionFont = new Font(
                 rtb.SelectionFont.FontFamily,
                 rtb.SelectionFont.Size,
                 (isBold ? FontStyle.Bold : FontStyle.Regular));
            #endregion

            // Unselect text
            rtb.SelectionLength = 0;
        }
    }
}
