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
    public partial class UserControlArmorCustomizer : UserControl
    {
        private PlayerArmor _connectedArmor = null;

        public UserControlArmorCustomizer()
        {
            InitializeComponent();
        }

        public void setConnectedItem(PlayerArmor a)
        {
            /* We do not want to modify the original object. */
            _connectedArmor = a.Clone();
            updateDisplayedProperties();
        }

        public PlayerArmor getConnectedItem()
        {
            return _connectedArmor;
        }

        private void updateDisplayedProperties()
        {
            if (_connectedArmor != null)
            {
                textBoxBaseArmorClass.Text = _connectedArmor.ArmorClass.ToString();
                textBoxMinStrengthScore.Text = _connectedArmor.MinStrength.ToString();
                checkBoxIsStealthDisadv.Checked = _connectedArmor.IsStealthDisadvantage;

                if (_connectedArmor.IsShield)
                {
                    radioButtonShield.Checked = true;
                }
                else
                {
                    switch (_connectedArmor.Type)
                    {
                        case (PlayerArmor.ArmorType.Heavy):
                            radioButtonHeavy.Checked = true;
                            break;
                        case (PlayerArmor.ArmorType.Medium):
                            radioButtonMedium.Checked = true;
                            break;
                        case (PlayerArmor.ArmorType.Light):
                            radioButtonLight.Checked = true;
                            break;
                        default:
                            radioButtonMedium.Checked = true;
                            break;

                    }
                }

                if (_connectedArmor.IsDexterityModifier)
                {
                    checkBoxIsDexModifier.Checked = true;
                    textBoxMaxDexModifier.Text = _connectedArmor.MaxDexModifier.ToString();
                }
                else
                {
                    checkBoxIsDexModifier.Checked = false;
                }

                if (_connectedArmor.IsMagical)
                {
                    checkBoxIsMagical.Checked = true;
                    textBoxMagicalAcBonus.Text = _connectedArmor.MagicalAcBonus.ToString();
                }
                else
                {
                    checkBoxIsMagical.Checked = false;
                }
            }
        }

        private void updateBaseArmorClass()
        {
            int baseAcValue;
            if (_connectedArmor != null)
            {
                if (int.TryParse(textBoxBaseArmorClass.Text, out baseAcValue) == true)
                {
                    _connectedArmor.ArmorClass = baseAcValue;
                }
                else
                {
                    textBoxBaseArmorClass.Text = _connectedArmor.ArmorClass.ToString();
                }
            }
        }

        private void textBoxBaseArmorClass_Leave(object sender, EventArgs e)
        {
            updateBaseArmorClass();
        }

        private void textBoxBaseArmorClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                updateBaseArmorClass();
            }
        }

        private void updateMinStrScore()
        {
            int baseMinStrValue;
            if (_connectedArmor != null)
            {
                if (int.TryParse(textBoxMinStrengthScore.Text, out baseMinStrValue) == true)
                {
                    _connectedArmor.MinStrength = baseMinStrValue;
                }
                else
                {
                    textBoxMinStrengthScore.Text = _connectedArmor.MinStrength.ToString();
                }
            }
        }

        private void textBoxMinStrengthScore_Leave(object sender, EventArgs e)
        {
            updateMinStrScore();
        }

        private void textBoxMinStrengthScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                updateMinStrScore();
            }
        }

        private void checkBoxIsStealthDisadv_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedArmor != null)
            {
                _connectedArmor.IsStealthDisadvantage = checkBoxIsStealthDisadv.Checked;
            }
        }

        private void updateArmorType()
        {
            if (_connectedArmor != null)
            {
                if (radioButtonShield.Checked)
                {
                    _connectedArmor.Type = PlayerArmor.ArmorType.Shield;
                    _connectedArmor.IsShield = true;
                }
                else if(radioButtonHeavy.Checked)
                {
                    _connectedArmor.Type = PlayerArmor.ArmorType.Heavy;
                    _connectedArmor.IsShield = false;
                }
                else if (radioButtonMedium.Checked)
                {
                    _connectedArmor.Type = PlayerArmor.ArmorType.Medium;
                    _connectedArmor.IsShield = false;
                }
                else if (radioButtonLight.Checked)
                {
                    _connectedArmor.Type = PlayerArmor.ArmorType.Light;
                    _connectedArmor.IsShield = false;
                }
            }
        }

        private void radioButtonHeavy_CheckedChanged(object sender, EventArgs e)
        {
            updateArmorType();
        }

        private void radioButtonMedium_CheckedChanged(object sender, EventArgs e)
        {
            updateArmorType();
        }

        private void radioButtonLight_CheckedChanged(object sender, EventArgs e)
        {
            updateArmorType();
        }

        private void radioButtonShield_CheckedChanged(object sender, EventArgs e)
        {
            updateArmorType();
        }

        private void checkBoxIsDexModifier_CheckedChanged(object sender, EventArgs e)
        {
            if(_connectedArmor != null)
            {
                _connectedArmor.IsDexterityModifier = checkBoxIsDexModifier.Checked;
            }
        }

        private void updateMaxDexModifier()
        {
            int baseMaxDexModifier;
            if (_connectedArmor != null)
            {
                if (int.TryParse(textBoxMaxDexModifier.Text, out baseMaxDexModifier) == true)
                {
                    _connectedArmor.MaxDexModifier = baseMaxDexModifier;
                }
                else
                {
                    textBoxMaxDexModifier.Text = _connectedArmor.MaxDexModifier.ToString();
                }
            }
        }

        private void textBoxMaxDexModifier_Leave(object sender, EventArgs e)
        {
            updateMaxDexModifier();
        }

        private void textBoxMaxDexModifier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                updateMaxDexModifier();
            }
        }

        private void checkBoxIsMagical_CheckedChanged(object sender, EventArgs e)
        {
            if (_connectedArmor != null)
            {
                _connectedArmor.IsMagical = checkBoxIsMagical.Checked;
            }
        }


        private void updateMagicalAcBonus()
        {
            int magicAcModifier;
            if (_connectedArmor != null)
            {
                if (int.TryParse(textBoxMagicalAcBonus.Text, out magicAcModifier) == true)
                {
                    _connectedArmor.MagicalAcBonus = magicAcModifier;
                }
                else
                {
                    textBoxMagicalAcBonus.Text = _connectedArmor.MagicalAcBonus.ToString();
                }
            }
        }

        private void textBoxMagicalAcBonus_Leave(object sender, EventArgs e)
        {
            updateMagicalAcBonus();
        }

        private void textBoxMagicalAcBonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                updateMagicalAcBonus();
            }
        }
    }
}
