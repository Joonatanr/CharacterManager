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
        private string _value;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolTip toolTip1;
        private string _label;

        public String Value { get { return _value; } set { _value = value; this.Invalidate(); } }
        public string Label { get { return _label; } set { _label = value; this.Invalidate(); } }

        private List<BonusValueModifier> _myBonusValues = new List<BonusValueModifier>();
        public List<BonusValueModifier> ValueModifiers
        {
            get
            {
                return _myBonusValues;
            }

            set
            {
                _myBonusValues = value;
                this.Value = BonusValueModifier.getTotalValueFromList(_myBonusValues).ToString();
                this.setTooltipString(BonusValueModifier.getToolTipStringFromList(_myBonusValues));
            }
        }

        public UserControlGenericValue() : base()
        {
            InitializeComponent();
        }

        public String ToolTip
        {
            set
            {
                toolTip1.SetToolTip(this, value);
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

            gfx.DrawString(_value, font, new SolidBrush(Color.Black), new Rectangle(0, 5, Width, Height - 5), format);

            drawLabel(gfx, _label);

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // UserControlGenericValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "UserControlGenericValue";
            this.ResumeLayout(false);

        }
    }
}
