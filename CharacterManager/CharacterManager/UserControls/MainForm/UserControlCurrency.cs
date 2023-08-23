using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls.MainForm
{
    public partial class UserControlCurrency : UserControl5eBase
    {
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
                this.Invalidate();
            }
        }
        private string _title = "GP";

        public int CurrencyAmount
        {
            get
            {
                return _CurrencyAmount;
            }

            set
            {
                _CurrencyAmount = value;
                this.Invalidate();
            }
        }
        private int _CurrencyAmount = 0;

        private bool isEditing = false;
        private string EditingText = "";

        public UserControlCurrency() : base()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        protected override void drawData(Graphics gfx)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(
               fontFamily,
               16,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Center;

            string CursorString = "_";

            gfx.DrawString(_title, font, new SolidBrush(Color.Black), new Rectangle(0, 2, Width, Height - 5), format);
            format.Alignment = StringAlignment.Center;

            font = new Font(
               fontFamily,
               12,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            if (isEditing)
            {
                gfx.DrawString(" " + EditingText + CursorString, font, new SolidBrush(Color.Black), new Rectangle(13, 2, Width, Height - 5), format);
            }
            else
            {
                gfx.DrawString(CurrencyAmount.ToString(), font, new SolidBrush(Color.Black), new Rectangle(13, 2, Width, Height - 5), format);
            }

            gfx.DrawRectangle(new Pen(Color.Black), new Rectangle(27, 0, this.Width - 28, this.Height - 1));
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
                        CurrencyAmount -= subtraction;
                    }
                }
                else if (EditingText[0] == '+')
                {
                    /* Add to HP */
                    string valueString = EditingText.Substring(1);
                    int addition;
                    if (int.TryParse(valueString, out addition))
                    {
                        CurrencyAmount += addition;
                    }
                }
                else
                {
                    /* Replace HP value. */
                    int value;
                    if (int.TryParse(EditingText, out value))
                    {
                        CurrencyAmount = value;
                    }
                }
            }

            isEditing = false;
            this.Invalidate();
        }

        private void UserControlCurrency_KeyPress(object sender, KeyPressEventArgs e)
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
                //EditingText = e.KeyChar.ToString(); /* Placeholder for teting. */
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
  

        private void UserControlCurrency_DoubleClick(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                startEditing();
            }
        }

        private void UserControlCurrency_Leave(object sender, EventArgs e)
        {
            if (isEditing)
            {
                stopEditing();
            }
        }
    }
}
