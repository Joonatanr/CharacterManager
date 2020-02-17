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
    public partial class FormDamageRegister : Form
    {
        public int Damage;

        public FormDamageRegister()
        {
            this.InitializeComponent();
        }

        public String LabelString
        { 
            get 
            { 
                return label1.Text; 
            } 
            set 
            { 
                this.label1.Text = value;
                if (this.Width < this.label1.Width)
                {
                    this.Width = this.label1.Width + this.label1.Left + 10;
                }
            } 
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Damage = (int)numericUpDown1.Value;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
