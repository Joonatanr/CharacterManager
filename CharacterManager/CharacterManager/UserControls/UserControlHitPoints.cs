using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    class UserControlHitPoints : UserControl5eBase
    {

        private int _currHitPoints = 10;
        public int MaxHitPoints = 10;

        public int CurrentHitPoints
        {
            get
            {
                return _currHitPoints;
            }
            set
            {
                if (value < 0)
                {
                    _currHitPoints = 0;
                }
                else if(value < MaxHitPoints)
                {
                    _currHitPoints = value;
                }
                else
                {
                    _currHitPoints = MaxHitPoints;
                }
                this.Invalidate();
            }
        }
        

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

            gfx.DrawString(CurrentHitPoints.ToString() + "/" + MaxHitPoints.ToString(), font, new SolidBrush(Color.Black), new Rectangle(0, 5, Width, Height - 5), format);

            drawLabel(gfx, "Hit Points");

        }
    }
}
