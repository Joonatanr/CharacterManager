using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class CharacterCreatorForm : Form
    {
        public PlayerCharacter CreatedCharacter { get; set; }
        private int StrBonus = 0;
        private int IntBonus = 0;
        private int DexBonus = 0;
        private int ChaBonus = 0;
        private int WisBonus = 0;
        private int ConBonus = 0;


        public CharacterCreatorForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxCharName.Text != String.Empty)
            {
                CreatedCharacter = new PlayerCharacter(textBoxCharName.Text);
                CreatedCharacter.StrengthAttribute = (int)numericUpDownSTR.Value + StrBonus;
                CreatedCharacter.WisAttribute = (int)numericUpDownWIS.Value + WisBonus;
                CreatedCharacter.IntAttribute = (int)numericUpDownINT.Value + IntBonus;
                CreatedCharacter.DexAttribute = (int)numericUpDownDEX.Value + DexBonus;
                CreatedCharacter.ConAttribute = (int)numericUpDownCON.Value + ConBonus;
                CreatedCharacter.CharAttribute = (int)numericUpDownCHA.Value + ChaBonus;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                handleErrorData();
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            /* TODO */

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void handleErrorData()
        {
            MessageBox.Show("Invalid data");
        }

        private void updateBaseAttributeFields()
        {
            textBoxSTRFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownSTR.Value + StrBonus);
            textBoxINTFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownINT.Value + IntBonus);
            textBoxWISFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownWIS.Value + WisBonus);
            textBoxCONFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownCON.Value + ConBonus);
            textBoxCHAFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownCHA.Value + ChaBonus);
            textBoxDEXFinal.Text = CharacterFactory.getAbilityWithModifierString(numericUpDownDEX.Value + DexBonus);
        }

        private void numericUpDownSTR_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownINT_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownDEX_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownCON_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownWIS_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }

        private void numericUpDownCHA_ValueChanged(object sender, EventArgs e)
        {
            updateBaseAttributeFields();
        }
    }
}
