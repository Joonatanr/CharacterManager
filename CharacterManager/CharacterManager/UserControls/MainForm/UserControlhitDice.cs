using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls.MainForm
{
    public class UserControlhitDice : UserControl5eBase
    {
        public int RemainingHitDice
        {
            get
            {
                return _remainingHitDice;
            }
            set
            {
                _remainingHitDice = value;
                this.Invalidate();
            }
        }

        public int DieType
        {
            get
            {
                return _dieType;
            }
            set
            {
                _dieType = value;
                this.Invalidate();
            }
        }

        public int MaxHitDice
        {
            get
            {
                return _maxHitDice;
            }
            set
            {
                _maxHitDice = value;
                this.Invalidate();
            }
        }

        private int _remainingHitDice = 0;
        private int _dieType = 10;
        private int _maxHitDice = 1;

        public UserControlhitDice() : base()
        {
            this.DoubleBuffered = true;
        }

        protected override void drawData(Graphics gfx)
        {
            drawLabel(gfx, "Hit Dice");
            drawDataStringInCenter(gfx, getHitDieString(RemainingHitDice, DieType), 24);

            /* Lets draw the total value. */
            gfx.DrawLine(new Pen(Color.Black), new Point(40, 20), new Point(Width - 10, 20));

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               12,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;
            string str = "Total: " + getHitDieString(MaxHitDice, DieType);

            gfx.DrawString(str, font, new SolidBrush(Color.Black), new Rectangle(5, 0, Width, 20), format);
        }

        private string getHitDieString(int remaining, int dieType)
        {
            string res = remaining.ToString();
            res += "d" + dieType.ToString();
            return res;
        }
    }
}
