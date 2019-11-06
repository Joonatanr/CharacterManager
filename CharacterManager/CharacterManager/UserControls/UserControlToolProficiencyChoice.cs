using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public partial class UserControlToolProficiencyChoice : UserControl
    {
        private const int offset_x = 10;
        private const int offset_y = 15;
        private const int spacing = 5;

        private const int box_height = 20;
        private List<String> myMembers = new List<String>();

        public UserControlToolProficiencyChoice()
        {
            InitializeComponent();
        }

        public void setChoices(List<String> choices)
        {
            this.groupBox1.Controls.Clear(); //Remove all previous controls.
            int x = offset_x;
            int y = offset_y;

            if (choices.SequenceEqual(myMembers))
            {
                //Nothing to add if lists already match.
                return;
            }

            foreach (string choice in choices)
            {
                RadioButton box = new RadioButton();
                box.Text = choice;

                box.Location = new Point(x, y);
                box.Size = new Size(groupBox1.Width - 20, box_height);

                y += (spacing + box.Height);
                groupBox1.Controls.Add(box);
            }
        }
    }
}
