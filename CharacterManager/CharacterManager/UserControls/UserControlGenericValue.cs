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

        public UserControlGenericValue() : base()
        {
            InitializeComponent();
        }

        public void setBonusValueModifiers(List<BonusValueModifier> modifiers)
        {
            _myBonusValues = modifiers;
            this.Value = BonusValueModifier.getTotalValueFromList(_myBonusValues).ToString();
            this.setTooltipString(BonusValueModifier.getToolTipStringFromList(_myBonusValues));
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
            drawDataStringInCenter(gfx, _value, 32);
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
