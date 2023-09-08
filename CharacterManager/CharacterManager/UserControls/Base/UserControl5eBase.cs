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
    public partial class UserControl5eBase : UserControl
    {
        public Boolean IsBorder { get; set; } = true;

        public UserControl5eBase()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public void setTooltipString(string str)
        {
            toolTip1.SetToolTip(this, str);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics gfx = e.Graphics;
            drawBackGround(gfx);
            drawData(gfx);
        }

        protected void drawLabel(Graphics gfx, String text)
        {

            FontFamily fontFamily = new FontFamily("Arial");
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            //Draw the info label.
            Rectangle labelRect = new Rectangle(0, this.Height - 20, Width, 20);
            Font font = new Font(
                fontFamily,
                12,
                FontStyle.Bold,
                GraphicsUnit.Pixel);
            gfx.DrawString(text, font, new SolidBrush(Color.Black), labelRect, format);
        }

        protected void drawDataStringInCenter(Graphics gfx, string str, int FontSize)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               FontSize,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            gfx.DrawString(str, font, new SolidBrush(Color.Black), new Rectangle(0, 0, Width, Height), format);
        }

        protected virtual void drawData(Graphics gfx)
        {

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

            rect = new Rectangle(1, this.Height - (2 + diameter), diameter, diameter);
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

            rect = new Rectangle(this.Size.Width - (2 + diameter), this.Height - (2 + diameter), diameter, diameter);
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

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, this.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            }

            rect = new Rectangle(1 + (diameter / 2), this.Height - (diameter + 2), this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
            }

            rect = new Rectangle(this.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, this.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
            }

            //Draw internal rectangle.
            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), this.Size.Width - (3 + diameter), this.Height - (3 + diameter));
            gfx.FillRectangle(b, rect);
        }

        private void UserControl5eBase_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
