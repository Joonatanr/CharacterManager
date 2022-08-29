using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{ 
    public partial class CustomRTB : RichTextBox
    {
        public CustomRTB() : base()
        {
            //InitializeComponent();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                //This makes the control's background transparent
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
    }
}
