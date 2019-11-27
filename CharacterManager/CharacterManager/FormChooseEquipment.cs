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
    public partial class FormChooseEquipment : Form
    {

        private PlayerClass _selectedClass;
        private List<UserControls.UserControlEquipmentChoice> myControls = new List<UserControls.UserControlEquipmentChoice>();

        public PlayerClass SelectedClass { get { return _selectedClass; } set { _selectedClass = value; textBoxClass.Text = _selectedClass.PlayerClassName; updateUserControls(); } }
        public List<Items.PlayerItem> SelectedItems = new List<Items.PlayerItem>();

        public FormChooseEquipment()
        {
            InitializeComponent();
        }

        private void updateUserControls()
        {
            int yOffset = 15;
            
            foreach (EquipmentChoiceList baseList in _selectedClass.AvailableEquipment)
            {
                UserControls.UserControlEquipmentChoice myChoiceControl = new UserControls.UserControlEquipmentChoice();
                myChoiceControl.EqChoice = baseList;
                myChoiceControl.Location = new Point(10, yOffset);
                groupBox1.Controls.Add(myChoiceControl);
                myControls.Add(myChoiceControl);

                yOffset += myChoiceControl.Size.Height;
                yOffset += 15;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            /* Comprise a list of chosen equipment. */
            List<EquipmentChoice> myChoiceList = new List<EquipmentChoice>();
            SelectedItems = new List<Items.PlayerItem>();

            /* Check which items were selected. */
            foreach (UserControlEquipmentChoice eqChoice in myControls)
            {
                myChoiceList = eqChoice.getSelectedEquipmentList();

                if (myChoiceList == null)
                {
                    MessageBox.Show("Not all selections have been made");
                    return;
                }

                foreach(EquipmentChoice choice in myChoiceList)
                {
                    Items.PlayerItem item = choice.getObjectReference();
                    item.Quantity = choice.Quantity;

                    if (item == null)
                    {
                        MessageBox.Show("Error finding reference for" + choice.Equipment);
                    }
                    else
                    {
                        if (item.ItemName == "AnyMartialMelee")
                        {
                            /* TODO : Handle special case. */
                        }
                        else if (item.ItemName == "AnyMartial")
                        {
                            /* TODO : Handle special case. */
                        }
                        else
                        {
                            SelectedItems.Add(item);
                        }
                    }
                }
            }


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
