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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String selectedItem = comboBox1.SelectedItem.ToString();
            _selectedBackGround = mainList.Find(bg => bg.BackGroundName == selectedItem);

            if(_selectedBackGround != null)
            {
                richTextBox1.Clear();
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                richTextBox1.AppendText("Description : \n");
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                richTextBox1.AppendText(_selectedBackGround.Description);
            }
        }
    }
}
