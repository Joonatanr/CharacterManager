using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    class UserControlGenericValue : UserControl5eBase
    {
        private int _value;
        private string _label;

        public int Value { get { return _value; } set { _value = value; this.Invalidate(); } }
        public string Label { get { return _label; } set { _label = value; this.Invalidate(); } }

        protected override void drawData(Graphics gfx)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               32,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            //gfx.DrawString(_attributeValue.ToString(), font, new SolidBrush(Color.Black), new PointF(panel1.Left, panel1.Top));
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            gfx.DrawString(_value.ToString(), font, new SolidBrush(Color.Black), new Rectangle(0, 5, Width, Height - 5), format);

            drawLabel(gfx, _label);

        }
    }
}
