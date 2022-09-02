using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class FormWeaponAttack : Form
    {
        private PlayerWeapon _weapon;
        private PlayerCharacter _connectedCharacter = null;

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

                /* Lets see if a picture exists for our weapon */
                string fileName = _weapon.ItemName.Replace(",", "");
                string imgName = "Resources/Pictures/" + fileName + ".png";
                if (File.Exists(imgName))
                {
                    pictureBox1.Image = Image.FromFile(imgName);
                }
                else
                {
                    pictureBox1.Image = Image.FromFile("Resources/Pictures/Default.png");
                }
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

        public void setCharacter(PlayerCharacter character)
        {
            _connectedCharacter = character;
            setupCombatAbilitiesList();
        }


        private void setupCombatAbilitiesList()
        {
            if(_connectedCharacter != null)
            {
                List<PlayerAbility> combatAbilitiesList = _connectedCharacter.CharacterAbilitiesObjectList.FindAll(a => a.IsCombatAbility).ToList();
                userControlCombatAbilitiesList.setAttributeList(combatAbilitiesList);

                foreach(PlayerAbility combatAbility in combatAbilitiesList)
                {
                    combatAbility.IsActiveChanged += new PlayerAbility.PlayerAbilityIsActiveChanged(CombatAbilityActiveChangedHandler);
                    combatAbility.AbilityUsed += new PlayerAbility.PlayerAbilityUsedListener(CombatAbilityUsedHandler);
                }
            }
        }

        private void CombatAbilityActiveChangedHandler(bool isActive)
        {
            /* Lets refresh out attack modifiers then... */
            if (_connectedCharacter != null)
            {
                List<BonusValueModifier> attackModifiers;
                List<BonusValueModifier> damageModifiers;

                _connectedCharacter.getWeaponAttackModifiers(Weapon, out attackModifiers, out damageModifiers);
                AttackModifiers = attackModifiers;
                DamageModifiers = damageModifiers;
            }
        }

        private void CombatAbilityUsedHandler(PlayerAbility ability)
        {
            /* In case of a single use ability, we will update the situational bonus of said ability. */
            List<BonusValueModifier> situationalAttackBonusModifiers = ability.getSituationalAttackModifiers();
            List<BonusValueModifier> situationalDamageBonusModifiers = ability.getSituationalDamageModifiers();

            /* TODO : Perhaps a more complex solution could be implemented in the future. Maybe add a separate DieRollTextBox for
             ability modifiers. This will get its value incremented by each ability use. Such as using a Divine Smite, Combat Maneuver and
            some other ability at the same time... However for the time being, lets just overwrite the situational bonus. For a more
            complex situation manual editing will be required... */

            if(situationalAttackBonusModifiers.Count > 0)
            {
                userControlAttackDieRolls.setSituationalBonus(BonusValueModifier.GetEquationFromList(situationalAttackBonusModifiers));
            }

            if(situationalDamageBonusModifiers.Count > 0)
            {
                userControlDamageDieRoll.setSituationalBonus(BonusValueModifier.GetEquationFromList(situationalDamageBonusModifiers));
            }
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
