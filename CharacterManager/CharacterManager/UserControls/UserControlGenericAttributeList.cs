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
    public partial class UserControlGenericAttributeList : UserControl
    {
        private const int lineInterval = 18;
        private List<PlayerAttribute> listOfAttributes = new List<PlayerAttribute>();
        private static int buttonNumber = 0;

        protected class InfoButton : Button
        {
            private PlayerAttribute attribute;

            public InfoButton(string name, PlayerAttribute attribute)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 7.5f);
                this.Text = "Info";
                this.Size = new Size(40, 18);
                this.TextAlign = ContentAlignment.TopCenter;
                this.attribute = attribute;
            }

            private void button_Click(object sender, EventArgs e)
            {
                if (attribute != null)
                {
                    MessageBox.Show(attribute.Description);
                }
                /* Not sure why this is needed, but this makes the button be deselected after it is clicked. */
                this.Parent.Focus();
            }
        }

        public UserControlGenericAttributeList()
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
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), attrib);
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 40, y + 3);
                panel1.Controls.Add(myBtn);
            }

            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);

            //Lets use the panel for drawing.
            Graphics gfx = panel1.CreateGraphics();

            //Lets try doing this in quite a simplistic way. Draw circles at the corners first.
            int diameter = 10;
            Brush b = new SolidBrush(Color.White);

            Rectangle rect = new Rectangle(1, 1, diameter, diameter);
            gfx.FillEllipse(b, rect);

            rect = new Rectangle(1, panel1.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);

            rect = new Rectangle(panel1.Size.Width - (2 + diameter), 1, diameter, diameter);
            gfx.FillEllipse(b, rect);

            rect = new Rectangle(panel1.Size.Width - (2 + diameter), panel1.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);

            //Draw white rectangles to fill..
            rect = new Rectangle(1 + (diameter / 2), 1, panel1.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, panel1.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);

            rect = new Rectangle(1 + (diameter / 2), panel1.Size.Height - (diameter + 2), panel1.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);

            rect = new Rectangle(panel1.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, panel1.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);

            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), panel1.Size.Width - (3 + diameter), panel1.Size.Height - (3 + diameter));
            gfx.FillRectangle(b, rect);

            //So lets draw the lines next.
            
            Pen myPen = new Pen(Color.LightGray);
            for (int x = lineInterval + 2; x < panel1.Size.Height; x+=lineInterval)
            {
                gfx.DrawLine(myPen, new Point(1, x), new Point(panel1.Width - 1, x));
            }

            //Lets draw a descriptive text.
            gfx.DrawString("Abilities:", new Font("Arial", 14), new SolidBrush(Color.Black), new Point(1, 1));

            int y = 1;
            if (listOfAttributes != null)
            {
                foreach(PlayerAttribute attrib in listOfAttributes)
                {
                    drawTextOnLine(gfx, attrib.AttributeName, y);
                    y++;
                }
            }
            
        }

        private void drawTextOnLine(Graphics gfx, String text, int lineNum)
        {
            Font f = new Font("Arial", 12);
            Point sPoint = new Point(1, (lineInterval * (lineNum + 1)) + 3 );
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);
        }
    }
}
