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
            int modifier = (value - 10) / 2;

            String txt = value + " " + "(";
            if(modifier >= 0)
            {
                txt += "+";
            }

            txt += modifier + ")";

            this.textBoxSTR.Text = txt;
            _attributeValue = value;
        }
    }
}
