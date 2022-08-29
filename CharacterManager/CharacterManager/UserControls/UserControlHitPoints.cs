using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    class UserControlHitPoints : UserControl5eBase
    {

        private int _currHitPoints = 10;
        public int MaxHitPoints = 10;
        private bool isEditing = false;
        private System.ComponentModel.IContainer components;
        private string EditingText = "";

        public UserControlHitPoints() : base()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        /* Note that this is automatically generated. */
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // UserControlHitPoints
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Name = "UserControlHitPoints";
            this.DoubleClick += new System.EventHandler(this.UserControlHitPoints_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserControlHitPoints_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserControlHitPoints_KeyPress);
            this.Leave += new System.EventHandler(this.UserControlHitPoints_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControlHitPoints_MouseDown);
            this.ResumeLayout(false);

        }

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
                    //_currHitPoints = MaxHitPoints;
                    /* Sometimes there can be more HP than max */
                    _currHitPoints = value;
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

            string CursorString = "_";

            if (isEditing)
            {
                gfx.DrawString(" " + EditingText + CursorString, font, new SolidBrush(Color.Black), new Rectangle(0, 5, Width, Height - 5), format);
            }
            else
            {
                gfx.DrawString(CurrentHitPoints.ToString() + "/" + MaxHitPoints.ToString(), font, new SolidBrush(Color.Black), new Rectangle(0, 5, Width, Height - 5), format);
            }

            
            drawLabel(gfx, "Hit Points");

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
                    if(int.TryParse(valueString, out subtraction))
                    {
                        CurrentHitPoints -= subtraction;
                    }
                }
                else if(EditingText[0] == '+')
                {
                    /* Add to HP */
                    string valueString = EditingText.Substring(1);
                    int addition;
                    if (int.TryParse(valueString, out addition))
                    {
                        CurrentHitPoints += addition;
                    }
                }
                else
                {
                    /* Replace HP value. */
                    int value;
                    if (int.TryParse(EditingText, out value))
                    {
                        CurrentHitPoints = value;
                    }
                }
            }
            
            isEditing = false;
            this.Invalidate();
        }


        private void UserControlHitPoints_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        private void UserControlHitPoints_DoubleClick(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                startEditing();
            }
        }

        private void UserControlHitPoints_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void UserControlHitPoints_KeyPress(object sender, KeyPressEventArgs e)
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

            if(e.KeyChar == (char)Keys.Back)
            {
                if(EditingText.Length > 0)
                {
                    EditingText = EditingText.Substring(0, EditingText.Length - 1);
                    this.Invalidate();
                }
            }
        }

        private void UserControlHitPoints_Leave(object sender, EventArgs e)
        {
            if (isEditing)
            {
                stopEditing();
            }
        }
    }
}
