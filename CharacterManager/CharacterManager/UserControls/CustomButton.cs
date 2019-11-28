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
    public partial class CustomButton : UserControl
    {
        public Color BackGroundColor { get
            {
                return _defaultBackGroundColor;
            }
            set
            {
                _defaultBackGroundColor = value;
                if (!isMouseInControl)
                {
                    _backgroundColor = _defaultBackGroundColor;
                }
                this.Invalidate();
            }
        }
        
        public Color BorderColor { get; set; } = Color.DarkGray;
        public Color ClickColor { get; set; } = Color.Crimson; /* TODO : Change default to something more neutral. */
        public Color HoverColor { get; set; } = Color.DarkGray;

        public String ButtonText { get; set; } = "Text";
        public event EventHandler Click;

        private Color _defaultBackGroundColor = Color.LightGray; /* The color to be used if button is not selected or pressed, etc. */
        private Color _backgroundColor;
        private Boolean isMouseInControl = false;

        public CustomButton()
        {
            InitializeComponent();
            _backgroundColor = BackGroundColor;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /* Not sure if this is necessary. */
            base.OnPaint(e);

            Graphics gfx = e.Graphics;

            /* Draw the background. */
            gfx.FillRectangle(new SolidBrush(_backgroundColor), this.ClientRectangle);

            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;

            /* Draw the text centered. */
            gfx.DrawString(ButtonText, Font, new SolidBrush(Color.Black), this.ClientRectangle, sf);

            /* Draw the border of the button. */
            gfx.DrawRectangle(new Pen(BorderColor), new Rectangle(0,0,Width - 1, Height - 1));
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _backgroundColor = HoverColor;
            isMouseInControl = true;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _backgroundColor = BackGroundColor;
            isMouseInControl = false;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            _backgroundColor = ClickColor;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (!isMouseInControl)
            {
                _backgroundColor = BackGroundColor;
            }
            else
            {
                _backgroundColor = HoverColor;
            }
            this.Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Click(this, new EventArgs());
        }
    }
}
