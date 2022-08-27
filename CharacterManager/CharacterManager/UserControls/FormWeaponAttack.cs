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
        private List<BonusValueModifier> _attackModifiers;
        private List<BonusValueModifier> _damageModifiers;

        private List<BonusValueModifier> _totalAttackModifiers;
        private List<BonusValueModifier> _totalDamageModifiers;

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
                labelWeaponName.Text = weaponName;
            }
        }

        public List<BonusValueModifier> AttackModifiers
        {
            get
            {
                return _attackModifiers;
            }

            set
            {
                _attackModifiers = value;
                updateAttackModifiers();
            }
        }

        public List<BonusValueModifier> DamageModifiers
        {
            get
            {
                return _damageModifiers;
            }

            set
            {
                _damageModifiers = value;
                updateDamageModifiers();
            }
        }
        
        
        public FormWeaponAttack()
        {
            InitializeComponent();
        }

        private void updateTotalAttackModifiers()
        {
            int totalBonus = 0;
            string totalValueString = "";

            foreach (BonusValueModifier mod in _attackModifiers)
            {
                if (mod.modifierDieRoll is DieRoll)
                {
                    totalValueString += mod.getBonusValueString() + " + ";
                }
                else
                {
                    totalBonus += mod.modifierValue;
                }
            }

            /* Now lets go over situational bonus. First we need to resolve the string */
            string situationalBonus = textBoxAttackRollSit.Text;
            if (!string.IsNullOrEmpty(situationalBonus))
            {
                try
                {
                    DieRollValue parsedDieRoll = new DieRollValue(situationalBonus);
                    List<DieRollComponent> rollComponents = parsedDieRoll.DieRollComponents;
                    foreach(DieRollComponent component in rollComponents)
                    {
                        if (component is DieRoll)
                        {
                            totalValueString += component.ToString() + " + ";
                        }
                        else
                        {
                            string dummy; /* TODO : Log should be handled differently. */
                            totalBonus += component.getValue(out dummy);
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to parse situational bonus : " + situationalBonus);
                }
            }

            totalValueString += totalBonus.ToString();
            textBoxTotalAttackRoll.Text = totalValueString;
        }

        private void updateTotalDamageModifiers()
        {

        }

        private void updateAttackModifiers()
        {
            textBoxAttackRollMods.Text = BonusValueModifier.getStringFromList(_attackModifiers);
            updateTotalAttackModifiers();            
        }

        private void updateDamageModifiers()
        {
            textBoxDamageRollModifiers.Text = BonusValueModifier.getStringFromList(_damageModifiers);
            updateTotalDamageModifiers();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxAttackRollSit_TextChanged(object sender, EventArgs e)
        {
            /* TODO */
        }

        private void textBoxAttackRollSit_Leave(object sender, EventArgs e)
        {
            updateTotalAttackModifiers();
        }

        private void textBoxAttackRollSit_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                updateTotalAttackModifiers();
            }
        }

        private void FormWeaponAttack_Load(object sender, EventArgs e)
        {

        }
    }
}
