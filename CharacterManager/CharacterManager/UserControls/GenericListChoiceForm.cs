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
        
        public string ChoiceDescriptionText 
        { 
            get
            {
                return label1.Text;
            }
            set 
            {
                label1.Text = value;
            }
        }
        
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

    public class GenericMultipleListChoiceForm : GenericListChoiceForm
    {
        private List<ComboBox> myComboBoxList = new List<ComboBox>();
        
        public GenericMultipleListChoiceForm() : base() 
        {
            myComboBoxList.Add(comboBox1);
        }

        public GenericMultipleListChoiceForm(int numberOfLists) : this()
        {
            int yOffset = comboBox1.Bottom;
            yOffset += 10;
            
            for (int i = 1; i < numberOfLists; i++)
            {
                this.Height += 40;
                ComboBox cBox = new ComboBox
                {
                    Size = comboBox1.Size,
                    Location = new Point(comboBox1.Location.X, yOffset)
                };

                this.Controls.Add(cBox);
                myComboBoxList.Add(cBox);

                yOffset = cBox.Bottom + 10; 
            }
        }


        public void setChoiceList(List<string> choices, int n)
        {
            try
            {
                ComboBox cBox = myComboBoxList[n];
                cBox.Items.Clear();

                foreach (string item in choices)
                {
                    cBox.Items.Add(item);
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        public string getSelectedItem(int n)
        {
            string res = "";

            try
            {
                ComboBox cBox = myComboBoxList[n];
                res = cBox.Items[cBox.SelectedIndex].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }

            return res;
        }
    }
}
