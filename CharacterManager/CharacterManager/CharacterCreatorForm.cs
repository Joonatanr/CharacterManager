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
        private CharacterFactory myFactory;

        private PlayerRace SelectedMainRace;
        private PlayerRace SelectedSubRace;

        public CharacterCreatorForm(CharacterFactory factory)
        {
            InitializeComponent();
            myFactory = factory;

            if (myFactory.Initialize() == false)
            {
                throw new Exception("Error : Failed to initialize Character Factory");
            }

            List<String> mainRaceNameList = myFactory.getMainRacesList();

            foreach(String str in mainRaceNameList)
            {
                comboBoxMainRace.Items.Add(str);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (textBoxCharName.Text != String.Empty)
            {
                //Set player name.
                CreatedCharacter = new PlayerCharacter(textBoxCharName.Text);

                //Set base attributes.
                CreatedCharacter.StrengthAttribute = (int)numericUpDownSTR.Value + StrBonus;
                CreatedCharacter.WisAttribute = (int)numericUpDownWIS.Value + WisBonus;
                CreatedCharacter.IntAttribute = (int)numericUpDownINT.Value + IntBonus;
                CreatedCharacter.DexAttribute = (int)numericUpDownDEX.Value + DexBonus;
                CreatedCharacter.ConAttribute = (int)numericUpDownCON.Value + ConBonus;
                CreatedCharacter.CharAttribute = (int)numericUpDownCHA.Value + ChaBonus;

                //Set race and subrace.
                if (SelectedMainRace == null)
                {
                    MessageBox.Show("Error : No race is selected.");
                }
                else
                {
                    CreatedCharacter.MainRaceName = SelectedMainRace.RaceName;
                    CreatedCharacter.SubRaceName = SelectedSubRace.RaceName;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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

        private void updateAllDisplayedData()
        {
            //1. Lets begin with the selected race and subrace
            if (SelectedMainRace != null)
            {
                StrBonus = SelectedMainRace.BonusAttributes.STR;
                IntBonus = SelectedMainRace.BonusAttributes.INT;
                WisBonus = SelectedMainRace.BonusAttributes.WIS;
                ConBonus = SelectedMainRace.BonusAttributes.CON;
                ChaBonus = SelectedMainRace.BonusAttributes.CHA;
                DexBonus = SelectedMainRace.BonusAttributes.DEX;
            }

            if (SelectedSubRace != null)
            {
                StrBonus += SelectedSubRace.BonusAttributes.STR;
                IntBonus += SelectedSubRace.BonusAttributes.INT;
                WisBonus += SelectedSubRace.BonusAttributes.WIS;
                ConBonus += SelectedSubRace.BonusAttributes.CON;
                ChaBonus += SelectedSubRace.BonusAttributes.CHA;
                DexBonus += SelectedSubRace.BonusAttributes.DEX;
            }

            updateBaseAttributeFields();
            //TODO : We want to show where the bonuses come from.

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

        private void comboBoxMainRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMainRace.Items.Count > 0)
            {
                String selectedItem = comboBoxMainRace.SelectedItem.ToString();
                comboBoxSubRace.Items.Clear();
                List<String> subRaceNames = myFactory.getSubRaceList(selectedItem);

                foreach (String str in subRaceNames)
                {
                    comboBoxSubRace.Items.Add(str);
                }

                SelectedMainRace = myFactory.getRaceByName(comboBoxMainRace.SelectedItem.ToString());
                updateAllDisplayedData();
            }
        }

        private void comboBoxSubRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSubRace.Items.Count > 0)
            {
                String selectedItem = comboBoxSubRace.SelectedItem.ToString();
                String mainRace = comboBoxMainRace.SelectedItem.ToString();
                if (mainRace != null && selectedItem != null)
                {
                    SelectedSubRace = myFactory.getSubRaceByName(mainRace, selectedItem);
                    updateAllDisplayedData();
                }
            }
        }
    }
}
