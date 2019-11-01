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

        public UserControlGenericAttributeList()
        {
            InitializeComponent();
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

            drawTextOnLine(gfx, "Test1", 3);
            drawTextOnLine(gfx, "Test2", 4);
            drawTextOnLine(gfx, "Test3", 6);
        }

        private void drawTextOnLine(Graphics gfx, String text, int lineNum)
        {
            Font f = new Font("Arial", 12);
            Point sPoint = new Point(1, (lineInterval * (lineNum + 1)) + 3 );
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);
        }
    }
}
