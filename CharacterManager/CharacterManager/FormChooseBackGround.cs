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

namespace CharacterManager
{
    public partial class FormChooseBackGround : Form
    {
        private List<CharacterBackGround> mainList;
        private CharacterBackGround _selectedBackGround = null;
        private List<UserControlEquipmentChoiceSingle> myOptionsList;
        public FormChooseBackGround()
        {
            InitializeComponent();
            mainList = CharacterFactory.getAllBackGrounds();

            foreach(CharacterBackGround bg in mainList)
            {
                comboBox1.Items.Add(bg.BackGroundName);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void updateOptions()
        {
            groupBoxOptions.Controls.Clear();
            int yloc = 20;
            int xloc = 10;


            foreach(UserControlEquipmentChoiceSingle c in myOptionsList)
            {
                c.Location = new Point(xloc, yloc);
                c.Width = 300;
                groupBoxOptions.Controls.Add(c);
                yloc += c.Height;
                yloc += 2;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = comboBox1.SelectedItem.ToString();
            _selectedBackGround = mainList.Find(bg => bg.BackGroundName == selectedItem);

            if(_selectedBackGround != null)
            {
                myOptionsList = new List<UserControlEquipmentChoiceSingle>();

                richTextBoxDescription.Clear();
                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
                richTextBoxDescription.AppendText("Description : \n");
                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Regular);
                richTextBoxDescription.AppendText(_selectedBackGround.Description);

                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
                richTextBoxDescription.AppendText("\n\nSkill Proficiencies:\n");
                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Regular);

                foreach(String proficiency in _selectedBackGround.SkillProficiencies)
                {
                    richTextBoxDescription.AppendText(proficiency + "\n");
                }

                if(_selectedBackGround.CustomLanguages > 0)
                {
                    richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
                    richTextBoxDescription.AppendText("\n\nLanguages:\n");
                    richTextBoxDescription.AppendText("Choose " + _selectedBackGround.CustomLanguages.ToString() + " languages of your choice.");

                    for (int x = 0; x < _selectedBackGround.CustomLanguages; x++)
                    {
                        /* TODO */
                    }
                }



                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
                richTextBoxDescription.AppendText("\n\nEquipment:\n");
                richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Regular);

                foreach (Items.ItemContainer.ContainerContent con in _selectedBackGround.Equipment)
                {
                    //richTextBoxDescription.AppendText(con.ToString() + "\n");

                    /* We might have multiple options. */
                    UserControlEquipmentChoiceSingle choiceControl = new UserControlEquipmentChoiceSingle();
                    EquipmentChoice choiceObject = new EquipmentChoice();
                    choiceObject.Equipment = con.Name;
                    choiceObject.Quantity = con.Quantity;
                    choiceControl.Choice = choiceObject;

                    richTextBoxDescription.AppendText(choiceObject.getObjectReference().ToString() + "\n"); 
                    if (choiceControl.isMultipleChoice)
                    {
                        myOptionsList.Add(choiceControl);
                    }

                }

                richTextBoxDescription.AppendText("\n\n");

                if (_selectedBackGround.Features.Count > 0)
                {

                    foreach (CharacterBackGround.BackGroundFeature feature in _selectedBackGround.Features)
                    {
                        richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Bold);
                        richTextBoxDescription.AppendText("\nFeature:");
                        richTextBoxDescription.SelectionFont = new Font(richTextBoxDescription.Font, FontStyle.Regular);
                        richTextBoxDescription.AppendText(feature.ToString() + "\n\n");
                    }
                }

                updateOptions();
            }
        }
    }
}
