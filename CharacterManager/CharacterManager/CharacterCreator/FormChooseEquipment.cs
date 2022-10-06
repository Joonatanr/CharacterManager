using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using CharacterManager.UserControls;

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
                myChoiceControl.Width = groupBox1.Width - 20;
                myChoiceControl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);

                groupBox1.Controls.Add(myChoiceControl);
                myControls.Add(myChoiceControl);

                yOffset += myChoiceControl.Size.Height;
                yOffset += 15;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            /* Comprise a list of chosen equipment. */
            SelectedItems = new List<Items.PlayerItem>();

            /* Check which items were selected. */
            foreach (UserControlEquipmentChoice eqChoice in myControls)
            {
                List<PlayerItem> myItemList = null;

                try
                {
                    myItemList = eqChoice.getSelectedEquipmentList();
                }
                catch (UserControlEquipmentChoiceSingle.EquipmentNotSelectedException)
                {
                    myItemList = null;
                }

                if (myItemList == null)
                {
                    MessageBox.Show("Not all selections have been made");
                    return;
                }

                foreach (PlayerItem item in myItemList)
                {
                    SelectedItems.Add(item);
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
