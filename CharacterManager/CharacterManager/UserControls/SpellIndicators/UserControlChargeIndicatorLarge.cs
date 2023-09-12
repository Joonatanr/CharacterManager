using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls.SpellIndicators
{
    public class UserControlChargeIndicatorLarge : UserControl
    {

        private int _minimum = 0;

        public int Minimum
        {
            get
            {
                return _minimum;
            }

            set
            {
                _minimum = value;
                this.Invalidate();
            }
        }

        private int _maximum = 10;

        public int Maximum
        {
            get
            {
                return _maximum;
            }
            set
            {
                _maximum = value;
                this.Invalidate();
            }
        }

        private int _value = 0;

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (value < _minimum)
                {
                    _value = _minimum;
                }
                else if (value > _maximum)
                {
                    _value = _maximum;
                }
                else
                {
                    _value = value;
                }
                this.Invalidate();
            }
        }

        private Color _textColor = Color.LightBlue;

        public Color TextColor
        {
            get
            {
                return _textColor;
            }

            set
            {
                _textColor = value;
                this.Invalidate();
            }
        }

        public delegate void ValueChangedListener(object sender, EventArgs e);
        public event ValueChangedListener ValueChanged;

        private bool isEditing = false;
        private bool isMouseSelecting = false;
        private string EditingText = "";

        public UserControlChargeIndicatorLarge()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlChargeIndicatorLarge
            // 
            this.Name = "UserControlChargeIndicatorLarge";
            this.Size = new System.Drawing.Size(40, 17);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlChargeIndicatorLarge_Paint);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserControlChargeIndicatorLarge_KeyPress);
            this.Leave += new System.EventHandler(this.UserControlChargeIndicatorLarge_Leave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlChargeIndicatorLarge_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UserControlChargeIndicatorLarge_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControlChargeIndicatorLarge_MouseLeave);
            this.ResumeLayout(false);

        }

        private void UserControlChargeIndicatorLarge_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            /* Draw the Background*/

            float percentageRemaining = (float)this.Value / (float)this.Maximum;

            // Create the region using a rectangle.
            Region myGreenRegion = new Region(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));
            Region myRedRegion = new Region(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));

            // Create the GraphicsPath.
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            path.AddRectangle(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));
            path.AddEllipse(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));
            
            /* We only want to draw inside the ellipse.*/
            myGreenRegion.Exclude(path);
            myRedRegion.Exclude(path);

            myGreenRegion.Exclude(new RectangleF(new PointF((float)this.Width * percentageRemaining, 0), new SizeF(this.Width, this.Height - 1)));
            myRedRegion.Exclude(new RectangleF(new PointF(0, 0), new SizeF(this.Width * percentageRemaining, this.Height - 1)));
            
            if (isMouseSelecting)
            {
                gfx.FillRegion(Brushes.LightGreen, myGreenRegion);
                gfx.FillRegion(Brushes.Red, myRedRegion);
            }
            else
            {
                gfx.FillRegion(Brushes.Green, myGreenRegion);
                gfx.FillRegion(Brushes.DarkRed, myRedRegion);
            }

            /* Draw the border. */
            gfx.DrawEllipse(new Pen(Color.DarkBlue, 2.0f), new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)));

            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               12,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            /* Draw the value */
            string CursorString = "_";

            Color textColor;

            if (isMouseSelecting)
            {
                textColor = Color.DarkBlue;
            }
            else
            {
                textColor = _textColor;
            }

            if (isEditing)
            {
                gfx.DrawString(" " + EditingText + CursorString, font, new SolidBrush(textColor), new Rectangle(0, 0, Width, Height), format);

            }
            else 
            { 
                gfx.DrawString(_value.ToString() + "/" + _maximum.ToString(), font, new SolidBrush(textColor), new Rectangle(0, 0, Width, Height), format);
            }
        }

        private void startEditing()
        {
            isEditing = true;
            EditingText = "";
            this.Invalidate();
        }

        private void stopEditing()
        {
            /* Lets see if the string is valid */
            if (!string.IsNullOrEmpty(EditingText))
            {
                if (EditingText[0] == '-')
                {
                    /* Subtract from HP */
                    string valueString = EditingText.Substring(1);
                    int subtraction;
                    if (int.TryParse(valueString, out subtraction))
                    {
                        Value -= subtraction;
                    }
                }
                else if (EditingText[0] == '+')
                {
                    /* Add to HP */
                    string valueString = EditingText.Substring(1);
                    int addition;
                    if (int.TryParse(valueString, out addition))
                    {
                        Value += addition;
                    }
                }
                else
                {
                    /* Replace HP value. */
                    int value;
                    if (int.TryParse(EditingText, out value))
                    {
                        Value = value;
                    }
                }
            }

            isEditing = false;
            this.Invalidate();

            if (ValueChanged != null)
            {
                ValueChanged.Invoke(this, EventArgs.Empty);
            }
        }

        private void UserControlChargeIndicatorLarge_MouseClick(object sender, MouseEventArgs e)
        {
            if (!isEditing)
            {
                startEditing();
            }
        }

        private void UserControlChargeIndicatorLarge_MouseEnter(object sender, EventArgs e)
        {
            isMouseSelecting = true;
            this.Invalidate();
        }

        private void UserControlChargeIndicatorLarge_MouseLeave(object sender, EventArgs e)
        {
            isMouseSelecting = false;
            this.Invalidate();
        }

        private void UserControlChargeIndicatorLarge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (isEditing)
                {
                    stopEditing();
                }
            }

            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-' || e.KeyChar == '+')
            {
                EditingText += e.KeyChar;
                this.Invalidate();
            }

            if (e.KeyChar == (char)Keys.Back)
            {
                if (EditingText.Length > 0)
                {
                    EditingText = EditingText.Substring(0, EditingText.Length - 1);
                    this.Invalidate();
                }
            }
        }

        private void UserControlChargeIndicatorLarge_Leave(object sender, EventArgs e)
        {
            if (isEditing)
            {
                stopEditing();
            }
        }
    }
}
