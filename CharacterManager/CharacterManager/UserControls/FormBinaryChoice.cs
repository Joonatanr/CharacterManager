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
    public partial class FormBinaryChoice : Form
    {

        public delegate bool ChoiceButtonHandler(int choice_index);
        public ChoiceButtonHandler ChoiceDialog = null;
        
        public string Desription
        {
            get { return richTextBox1.Text; }
            set
            {
                richTextBox1.Text = value;
            }
        }

        public string ChoiceOne
        {
            get { return radioButtonChoiceOne.Text; }
            set
            {
                radioButtonChoiceOne.Text = value;
            }
        }

        public string ChoiceTwo
        {
            get { return radioButtonChoiceTwo.Text; }
            set
            {
                radioButtonChoiceTwo.Text = value;
            }
        }
        
        public FormBinaryChoice()
        {
            InitializeComponent();
        }

        private void buttonMakeChoice_Click(object sender, EventArgs e)
        {
            if (ChoiceDialog == null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                int choice_ix = 0;
                if (radioButtonChoiceOne.Checked)
                {
                    choice_ix = 1;
                }
                else if (radioButtonChoiceTwo.Checked)
                {
                    choice_ix = 2;
                }
                if(ChoiceDialog.Invoke(choice_ix) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
