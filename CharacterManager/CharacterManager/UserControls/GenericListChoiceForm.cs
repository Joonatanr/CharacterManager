using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class GenericListChoiceForm : Form
    {   
        public GenericListChoiceForm()
        {
            InitializeComponent();
        }

        public void setChoiceList(List<string> choices)
        {
            comboBox1.Items.Clear();
            
            foreach(string item in choices)
            {
                comboBox1.Items.Add(item);
            }
        }

        public string getSelectedItem()
        {
            string res = "";

            try
            {
                res = comboBox1.Items[comboBox1.SelectedIndex].ToString();
            }
            catch (Exception)
            {

            }

            return res;
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
    }
}
