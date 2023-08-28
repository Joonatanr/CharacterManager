using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.Items
{
    public partial class UserControlWeaponCustomizer : UserControl
    {
        private PlayerWeapon _connectedWeapon;
        
        public UserControlWeaponCustomizer()
        {
            InitializeComponent();

            /* Set up comboboxes. */
            comboBoxBaseDamageType.DataSource = Enum.GetValues(typeof(PlayerWeapon.DamageType));
            comboBox2HDamage.DataSource = Enum.GetValues(typeof(PlayerWeapon.DamageType));
            comboBoxExtraDamage.DataSource = Enum.GetValues(typeof(PlayerWeapon.DamageType));
        }

        public void setConnectedItem(PlayerWeapon w)
        {
            /* We do not want to modify the connected weapon itself. The original template should remain unchanged. */
            _connectedWeapon = w.Clone();

            /* Update all the controls. */
            updateDisplayedProperties();
        }


        public PlayerWeapon getConnectedItem()
        {
            return _connectedWeapon;
        }

        private void updateDisplayedProperties()
        {
            checkBoxIsAmmunition.Checked = _connectedWeapon.IsAmmunition;
            checkBoxIsFinesse.Checked = _connectedWeapon.IsFinesse;

            if (_connectedWeapon.IsHeavy)
            {
                radioButtonHeavy.Checked = true;
            }
            else if (_connectedWeapon.IsLight)
            {
                radioButtonLight.Checked = true;
            }
            else
            {
                radioButtonNormal.Checked = true;
            }

            checkBoxLoading.Checked = _connectedWeapon.IsLoading;
            checkBoxIsThrown.Checked = _connectedWeapon.IsThrown;
            checkBoxTwoHanded.Checked = _connectedWeapon.IsTwoHanded;
            checkBoxIsVersatile.Checked = _connectedWeapon.IsVersatile;
            checkBoxRanged.Checked = _connectedWeapon.IsRanged;
            
            if(_connectedWeapon.Type == PlayerWeapon.WeaponType.Martial)
            {
                radioButtonMartial.Checked = true;
            }
            else
            {
                radioButtonSimple.Checked = true;
            }

            textBoxNormalRange.Text = _connectedWeapon.Range.NormalRange.ToString();
            textBoxLongRange.Text = _connectedWeapon.Range.LongRange.ToString();
            textBoxReach.Text = _connectedWeapon.Reach.ToString();

            textBoxBaseDamage.Text = _connectedWeapon.Damage.DamageValue;
            comboBoxBaseDamageType.SelectedItem = _connectedWeapon.Damage.Type;

            textBox2HDamage.Text = _connectedWeapon.TwoHandedDamage.DamageValue;
            comboBox2HDamage.SelectedItem = _connectedWeapon.TwoHandedDamage.Type;

            /* TODO : Currently we only use the first extra damage modifier. However there could be more than one. */

            PlayerWeapon.WeaponDamage extra = _connectedWeapon.ExtraDamage;
            textBoxExtraDamage.Text = extra.DamageValue;
            comboBoxExtraDamage.SelectedItem = extra.Type;

            checkBoxIsMagical.Checked = _connectedWeapon.IsMagical;
            if (_connectedWeapon.IsMagical)
            {
                if (_connectedWeapon.MagicalBonus >= 0)
                {
                    textBoxMagicalBonus.Text = "+" + _connectedWeapon.MagicalBonus.ToString();
                }
                else
                {
                    textBoxMagicalBonus.Text = _connectedWeapon.MagicalBonus.ToString();

                }
            }
        }

        private void checkBoxIsFinesse_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedWeapon != null)
            {
                _connectedWeapon.IsFinesse = checkBoxIsFinesse.Checked;
            }
        }

        private void checkBoxTwoHanded_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedWeapon != null)
            {
                _connectedWeapon.IsTwoHanded = checkBoxTwoHanded.Checked;
            }
        }

        private void checkBoxIsVersatile_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsVersatile = checkBoxIsVersatile.Checked;
            }
        }

        private void checkBoxIsReach_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsReach = checkBoxIsReach.Checked;
            }
        }

        private void textBoxReach_TextChanged(object sender, EventArgs e)
        {
            int reachValue;
            if (_connectedWeapon != null)
            {
                if (int.TryParse(textBoxReach.Text, out reachValue) == true)
                {
                    _connectedWeapon.Reach = reachValue;
                }
                else
                {
                    textBoxReach.Text = _connectedWeapon.Reach.ToString();
                }
            }
        }

        private void checkBoxRanged_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsRanged = checkBoxRanged.Checked;
            }
        }

        private void checkBoxIsAmmunition_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsAmmunition = checkBoxIsAmmunition.Checked;
            }
        }

        private void checkBoxLoading_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsLoading = checkBoxLoading.Checked;
            }
        }

        private void checkBoxIsThrown_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.IsThrown = checkBoxIsThrown.Checked;
            }
        }

        private void textBoxNormalRange_TextChanged(object sender, EventArgs e)
        {
            int rangeValue;
            if (_connectedWeapon != null)
            {
                if (int.TryParse(textBoxNormalRange.Text, out rangeValue) == true)
                {
                    _connectedWeapon.Range.NormalRange = rangeValue;
                }
                else
                {
                    textBoxNormalRange.Text = _connectedWeapon.Range.NormalRange.ToString();
                }
            }
        }

        private void textBoxLongRange_TextChanged(object sender, EventArgs e)
        {
            int rangeValue;
            if (_connectedWeapon != null)
            {
                if (int.TryParse(textBoxLongRange.Text, out rangeValue) == true)
                {
                    _connectedWeapon.Range.LongRange = rangeValue;
                }
                else
                {
                    textBoxLongRange.Text = _connectedWeapon.Range.LongRange.ToString();
                }
            }
        }

        private void textBoxAmmoType_TextChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.AmmoType = textBoxAmmoType.Text;
            }
        }

        private void radioButtonSimple_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedWeapon != null)
            {
                if (radioButtonSimple.Checked)
                {
                    _connectedWeapon.Type = PlayerWeapon.WeaponType.Simple;
                }
                else
                {
                    _connectedWeapon.Type = PlayerWeapon.WeaponType.Martial;
                }
            }
        }

        private void radioButtonMartial_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                if (radioButtonSimple.Checked)
                {
                    _connectedWeapon.Type = PlayerWeapon.WeaponType.Simple;
                }
                else
                {
                    _connectedWeapon.Type = PlayerWeapon.WeaponType.Martial;
                }
            }
        }

        private void updateWeaponType()
        {
            if(_connectedWeapon != null)
            {
                if (radioButtonHeavy.Checked)
                {
                    _connectedWeapon.IsHeavy = true;
                    _connectedWeapon.IsLight = false;
                }
                else if (radioButtonNormal.Checked)
                {
                    _connectedWeapon.IsHeavy = false;
                    _connectedWeapon.IsLight = false;
                }
                else
                {
                    _connectedWeapon.IsHeavy = false;
                    _connectedWeapon.IsLight = true;
                }
            }
        }

        private void radioButtonHeavy_CheckedChanged(object sender, EventArgs e)
        {
            updateWeaponType();
        }

        private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
        {
            updateWeaponType();
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            updateWeaponType();
        }

        private void checkBoxIsMagical_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedWeapon != null)
            {
                _connectedWeapon.IsMagical = checkBoxIsMagical.Checked;
            }
        }

        private void textBoxMagicalBonus_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidateMagicalBonus()
        {
            if (_connectedWeapon != null)
            {
                String bonusText = textBoxMagicalBonus.Text;

                bonusText = bonusText.Replace("+", "");
                int bonusValue;

                if (int.TryParse(bonusText, out bonusValue) == true)
                {
                    _connectedWeapon.MagicalBonus = bonusValue;
                }
                else
                {
                    if (_connectedWeapon.MagicalBonus >= 0)
                    {
                        textBoxMagicalBonus.Text = "+" + _connectedWeapon.MagicalBonus.ToString();
                    }
                    else
                    {
                        textBoxMagicalBonus.Text = _connectedWeapon.MagicalBonus.ToString();
                    }
                }
            }
        }

        private void textBoxMagicalBonus_Leave(object sender, EventArgs e)
        {
            ValidateMagicalBonus();
        }

        private void textBoxMagicalBonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ValidateMagicalBonus();
            }
        }

        private void ValidateBaseDamage()
        {
            string damageString = textBoxBaseDamage.Text;
            try
            {
                DieRollEquation.parseComponentListFromString(damageString);
                if(_connectedWeapon != null)
                {
                    _connectedWeapon.Damage.DamageValue = damageString;
                }
            }
            catch (Exception)
            {
                textBoxBaseDamage.Text = _connectedWeapon.Damage.DamageValue;
            }
        }

        private void textBoxBaseDamage_Leave(object sender, EventArgs e)
        {
            ValidateBaseDamage();
        }

        private void textBoxBaseDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ValidateBaseDamage();
            }
        }

        private void comboBoxBaseDamageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.Damage.Type = (PlayerWeapon.DamageType)comboBoxBaseDamageType.SelectedItem;
            }
        }

        private void ValidateTwoHandedDamage()
        {
            string damageString = textBox2HDamage.Text;
            try
            {
                DieRollEquation.parseComponentListFromString(damageString);
                if (_connectedWeapon != null)
                {
                    _connectedWeapon.TwoHandedDamage.DamageValue = damageString;
                }
            }
            catch (Exception)
            {
                textBoxBaseDamage.Text = _connectedWeapon.TwoHandedDamage.DamageValue;
            }
        }

        private void textBox2HDamage_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2HDamage_Leave(object sender, EventArgs e)
        {
            ValidateTwoHandedDamage();
        }

        private void textBox2HDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ValidateTwoHandedDamage();
            }
        }

        private void comboBox2HDamage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.TwoHandedDamage.Type = (PlayerWeapon.DamageType)comboBox2HDamage.SelectedItem;
            }
        }

        private void ValidateExtraDamage()
        {
            string damageString = textBoxExtraDamage.Text;
            try
            {
                DieRollEquation.parseComponentListFromString(damageString);
                if (_connectedWeapon != null)
                {
                    _connectedWeapon.ExtraDamage.DamageValue = damageString;
                }
            }
            catch (Exception)
            {
                textBoxExtraDamage.Text = _connectedWeapon.ExtraDamage.DamageValue;
            }
        }


        private void textBoxExtraDamage_Leave(object sender, EventArgs e)
        {
            ValidateExtraDamage();
        }

        private void textBoxExtraDamage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                ValidateExtraDamage();
            }
        }

        private void comboBoxExtraDamage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_connectedWeapon != null)
            {
                _connectedWeapon.ExtraDamage.Type = (PlayerWeapon.DamageType)comboBoxExtraDamage.SelectedItem;
            }
        }
    }
}
