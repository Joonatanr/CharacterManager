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
    }
}
