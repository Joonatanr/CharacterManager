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
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormWeaponAttack_Load(object sender, EventArgs e)
        {

        }
    }
}
