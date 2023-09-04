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

        protected int originalHeight;
        protected int maxLine;

        protected class InfoButton : CustomButton
        {
            private String infoString;
            private EventHandler showInfo = null;

            public InfoButton(string name, string info)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 8.0f);
                this.ButtonText = "Info";
                this.Size = new Size(40, 17);
                this.infoString = info;
            }

            public InfoButton(string name, EventHandler clickHandler)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 8.0f);
                this.ButtonText = "Info";
                this.Size = new Size(40, 17);
                this.showInfo = clickHandler;
            }

            private void button_Click(object sender, EventArgs e)
            {
                if(showInfo != null)
                {
                    showInfo.Invoke(this, e);
                }
                else if (infoString != null)
                {
                
                    MessageBox.Show(infoString);

                    /* Not sure why this is needed, but this makes the button be deselected after it is clicked. */
                    this.Parent.Focus();
                }
            }
        }


        public UserControlGenericListBase()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            originalHeight = this.Height;
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);

            pea.Graphics.TranslateTransform(this.AutoScrollPosition.X,
                                this.AutoScrollPosition.Y);

            //Lets use the panel for drawing.
            Graphics gfx = pea.Graphics;

            maxLine = 0;

            drawBackGround(gfx);
            //So lets draw the lines next.

            Pen myPen = new Pen(Color.LightGray);
            for (int x = lineInterval + 2; x < this.Size.Height; x += lineInterval)
            {
                gfx.DrawLine(myPen, new Point(2, x), new Point(this.Width - 2, x));
            }

            Font myFont = new Font("Arial", 14);

            drawData(gfx, myFont);

            /* A crude automatic resizing mechanism... */
            if (getNumberOfLines() < maxLine) 
            {
                this.Height = ((maxLine + 1) * lineInterval) + 4;
            }
        }

       
        protected void drawRectangleOnLine(Graphics gfx, int lineNum, Color rectColor)
        {
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + 3);
            Rectangle rect = new Rectangle(sPoint, new Size(this.Width - 1, lineInterval));
            gfx.FillRectangle(new SolidBrush(rectColor), rect);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum)
        {
            Font f = new Font("Arial", 12, FontStyle.Regular);
            drawTextOnLine(gfx, text, lineNum, f);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum, FontStyle style)
        {
            Font f = new Font("Arial", 12, style);
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + 3);
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }


        protected void drawTextOnLine(Graphics gfx, String text, int xOffset, int lineNum, FontStyle style, int MaxStringWidth)
        {
            float FontSize = 12;

            Font f;
            /* Lets try to dynamically reduce the size of the font if it is too large for the area.*/
            SizeF textSize;

            do
            {
                f = new Font("Arial", FontSize, style);
                /* Lets try to dynamically reduce the size of the font if it is too large for the area.*/
                textSize = gfx.MeasureString(text, f);
                FontSize-= 0.25f;
            } while (textSize.Width > MaxStringWidth && FontSize > 2);

            Point sPoint = new Point(1 + xOffset, (lineInterval * (lineNum)) + 3);
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum, Font font)
        {
            int margin;
            if (font.Height > (lineInterval - 3))
            {
                margin = 1;
            }
            else
            {
                margin = 3;
            }
            
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + margin);
            gfx.DrawString(text, font, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }

        protected void AddControlOnLine(Control c, int lineNum, int xOffset)
        {
            int y = lineInterval;
            y += lineNum * lineInterval;

            c.Location = new Point((this.Width - (3 + c.Width)) - xOffset, y + 3);
            this.Controls.Add(c);
        }

        protected void AddSpellSlotOnLine(UserControlSpellSlotIndicator slot, int lineNum, int xloc)
        {
            int y = lineInterval;
            y += lineNum * lineInterval;

            slot.Location = new Point(xloc, y + 4);
            this.Controls.Add(slot);
        }


        protected void AddButtonOnLine(CustomButton btn, int lineNum, int xOffset)
        {
            int y = lineInterval;
            y += lineNum * lineInterval;          
  
            btn.Location = new Point((this.Width - (3 + btn.Width)) - xOffset, y + 3);
            this.Controls.Add(btn);
        }


        protected virtual void drawData(Graphics gfx, Font font)
        {
            /* No data to draw in base class. */
        }

        protected int getNumberOfLines()
        {
            return this.Height / (lineInterval);
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

            rect = new Rectangle(1, this.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(this.Size.Width - (2 + diameter), 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(this.Size.Width - (2 + diameter), this.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            //Draw white rectangles to fill..
            rect = new Rectangle(1 + (diameter / 2), 1, this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
            }

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, this.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            }

            rect = new Rectangle(1 + (diameter / 2), this.Size.Height - (diameter + 2), this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
            }

            rect = new Rectangle(this.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, this.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
            }

            //Draw internal rectangle.
            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), this.Size.Width - (3 + diameter), this.Size.Height - (3 + diameter));
            gfx.FillRectangle(b, rect);
        }

        private void UserControlGenericListBase_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
