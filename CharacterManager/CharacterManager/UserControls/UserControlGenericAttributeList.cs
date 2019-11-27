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
    public partial class UserControlGenericAttributeList : UserControlGenericListBase
    {
        private List<PlayerAttribute> listOfAttributes = new List<PlayerAttribute>();

        public UserControlGenericAttributeList() : base()
        {
            InitializeComponent();
        }

        public void setAttributeList(List<PlayerAttribute> target)
        {
            listOfAttributes = target;
            List<Control> myListToRemove = new List<Control>();

            //Lets remove any old buttons.
            foreach (Control c in panel1.Controls)
            {
                if (c is InfoButton)
                {
                    myListToRemove.Add(c);
                }
            }

            foreach(Control c in myListToRemove)
            {
                panel1.Controls.Remove(c);
            }

            //Lets test adding a button for reach of the attributes.
            int y = lineInterval;
            foreach (PlayerAttribute attrib in listOfAttributes)
            {
                y += lineInterval;
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), attrib.Description);
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 43, y + 3);
                panel1.Controls.Add(myBtn);
            }

            this.Invalidate();
        }


        protected override void drawData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            gfx.DrawString("Abilities:", font, new SolidBrush(Color.Black), new Point(1, 1));

            int y = 1;
            if (listOfAttributes != null)
            {
                foreach (PlayerAttribute attrib in listOfAttributes)
                {
                    drawTextOnLine(gfx, attrib.AttributeName, y);
                    y++;
                }
            }
        }
    }
}
