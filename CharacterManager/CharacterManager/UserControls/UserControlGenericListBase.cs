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
    public partial class UserControlGenericListBase : UserControl
    {
        public Boolean IsBorder { get; set; }
        protected const int lineInterval = 18; /* TODO : Make this into public property and test. */
        protected static int buttonNumber = 0;

        protected class InfoButton : Button
        {
            //private PlayerAttribute attribute;
            private String infoString;

            public InfoButton(string name, string info)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 7.5f);
                this.Text = "Info";
                this.Size = new Size(40, 18);
                this.TextAlign = ContentAlignment.TopCenter;
                this.infoString = info;
            }

            private void button_Click(object sender, EventArgs e)
            {
                if (infoString != null)
                {
                    MessageBox.Show(infoString);
                }
                /* Not sure why this is needed, but this makes the button be deselected after it is clicked. */
                this.Parent.Focus();
            }
        }


        public UserControlGenericListBase()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);

            //Lets use the panel for drawing.
            Graphics gfx = panel1.CreateGraphics();

            drawBackGround(gfx);
            //So lets draw the lines next.

            Pen myPen = new Pen(Color.LightGray);
            for (int x = lineInterval + 2; x < panel1.Size.Height; x += lineInterval)
            {
                gfx.DrawLine(myPen, new Point(2, x), new Point(panel1.Width - 2, x));
            }

            Font myFont = new Font("Arial", 14);

            drawData(gfx, myFont);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum)
        {
            drawTextOnLine(gfx, text, lineNum, FontStyle.Regular);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum, FontStyle style)
        {
            Font f = new Font("Arial", 12, style);
            Point sPoint = new Point(1, (lineInterval * (lineNum + 1)) + 3);
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);
        }

        protected virtual void drawData(Graphics gfx, Font font)
        {
            /* No data to draw in base class. */
        }

        private void drawBackGround(Graphics gfx)
        {
            //Lets try doing this in quite a simplistic way. Draw circles at the corners first.
            int diameter = 10;
            Brush b = new SolidBrush(Color.White);

            Rectangle rect = new Rectangle(1, 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(1, panel1.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(panel1.Size.Width - (2 + diameter), 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(panel1.Size.Width - (2 + diameter), panel1.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            //Draw white rectangles to fill..
            rect = new Rectangle(1 + (diameter / 2), 1, panel1.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
            }

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, panel1.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            }

            rect = new Rectangle(1 + (diameter / 2), panel1.Size.Height - (diameter + 2), panel1.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
            }

            rect = new Rectangle(panel1.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, panel1.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
            }

            //Draw internal rectangle.
            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), panel1.Size.Width - (3 + diameter), panel1.Size.Height - (3 + diameter));
            gfx.FillRectangle(b, rect);
        }
    }
}
