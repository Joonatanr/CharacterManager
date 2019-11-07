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
        public PlayerClass SelectedClass { get { return _selectedClass; } set { _selectedClass = value; textBoxClass.Text = _selectedClass.PlayerClassName; updateUserControls(); } }
        
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

                yOffset += myChoiceControl.Size.Height;
                yOffset += 15;
            }
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
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
