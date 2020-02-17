using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public partial class UserControlAttributeDisplay : UserControl
    {

        private const Boolean IsBorder = true;

        public String AttributeName
        {
            set
            {
                this.label2.Text = value;
            }

            get
            {
                return this.label2.Text;
            }
        }

        private int _attributeValue;
        private int _modifierValue;
        private RectangleF EllipseRectangle;

        public int AttributeValue
        {
            get
            {
                return _attributeValue;
            }
            set
            {
                updateDisplayedValue(value);
            }
        }

        public UserControlAttributeDisplay()
        {
            InitializeComponent();
        }

        private void updateDisplayedValue(int value)
        {
            /* TODO : Move this modifier elsewhere. */
            Decimal modifier = Math.Floor(((Decimal)value - 10) / 2);

            _modifierValue = (int)modifier;
            _attributeValue = value;
            this.Invalidate();
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics gfx = e.Graphics;
            drawBackGround(gfx);

            //Draw the number and the modifier.
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               32,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            gfx.DrawString(_attributeValue.ToString(), font, new SolidBrush(Color.Black), this.ClientRectangle, format);

            font = new Font(
                fontFamily,
                16,
                FontStyle.Regular,
                GraphicsUnit.Pixel);

            String bonusString = _modifierValue.ToString();
            if(_modifierValue >= 0)
            {
                bonusString = "+" + bonusString;
            }
            gfx.DrawString(bonusString, font, new SolidBrush(Color.Black), EllipseRectangle, format);
        }

        //This is currently copied.
        private void drawBackGround(Graphics gfx)
        {
            //Lets try doing this in quite a simplistic way. Draw circles at the corners first.
            int diameter = 10;
            Brush b = new SolidBrush(Color.White);

            int ellipseWidth = 32;
            int ellipseHeight = 24;
            int bottomEmptyHeight = ellipseHeight / 2;
            int mainHeight = this.Height - bottomEmptyHeight;

            Rectangle rect = new Rectangle(1, 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(1, mainHeight - (2 + diameter), diameter, diameter);
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

            rect = new Rectangle(this.Size.Width - (2 + diameter), mainHeight - (2 + diameter), diameter, diameter);
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

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, mainHeight - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            }

            rect = new Rectangle(1 + (diameter / 2), mainHeight - (diameter + 2), this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
            }

            rect = new Rectangle(this.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, mainHeight - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
            }

            // Draw internal rectangle.
            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), this.Size.Width - (3 + diameter), mainHeight - (3 + diameter));
            gfx.FillRectangle(b, rect);

            // Lets draw the circle below.

            int ellipseLeft = (this.Width / 2) - (ellipseWidth / 2);
            int ellipseTop = this.Height - (ellipseHeight + 1);
        
            this.EllipseRectangle = new RectangleF(new PointF(ellipseLeft, ellipseTop),new SizeF(ellipseWidth, ellipseHeight ));
            gfx.FillEllipse(new SolidBrush(Color.White), EllipseRectangle);
            gfx.DrawEllipse(new Pen(Color.Black), EllipseRectangle);
        }

        private void label2_SizeChanged(object sender, EventArgs e)
        {

        }

        private void UserControlAttributeDisplay_SizeChanged(object sender, EventArgs e)
        {
            //Lets center out label...
            Size s = label2.Size;
            int x = (this.Width / 2) - (label2.Width / 2);
            x++;
            //int y = (this.Height / 2) - (label2.Height / 2);
            int y = 5;

            label2.Location = new Point(x, y);
        }
    }
}
