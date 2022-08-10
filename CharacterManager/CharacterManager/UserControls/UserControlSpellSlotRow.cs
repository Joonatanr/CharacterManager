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
    public partial class UserControlSpellSlotRow : UserControl
    {
        private int number_of_slots = 3; /* Set some sane default value */
        
        public int NumberOfSlots
        {
            get { return number_of_slots; }
            
            set
            {
                number_of_slots = value;
                updateNumberOfSlots();
            }
        }

        public string LabelName
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
            }
        }
        
        
        public UserControlSpellSlotRow()
        {
            InitializeComponent();
        }

        private void updateNumberOfSlots()
        {
            /* First clear any existing indicators. */
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is UserControlSpellSlotIndicator)
                {
                    this.Controls.Remove(ctrl);
                }
            }

            /* Next lets set up some indicators. */
            for (int x = 0; x < number_of_slots; x++)
            {
                UserControlSpellSlotIndicator indicator = new UserControlSpellSlotIndicator();
                indicator.Left = (x * 20) + label1.Right + 4;
                
                indicator.Top = (this.Height / 2) - (indicator.Height / 2);


                this.Controls.Add(indicator);
            }
        }
    }
}
