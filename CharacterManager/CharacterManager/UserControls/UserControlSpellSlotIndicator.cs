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
    public partial class UserControlSpellSlotIndicator : UserControl
    {
        private Boolean isActive = true; /* Usually when a slot is added then in the beginning it is active and available. */
        private Boolean isMouseSelecting = false;

        public delegate void SpellSlotCheckedChanged();

        public event SpellSlotCheckedChanged SpellSlotCheckedChangedByUser;

        public Boolean IsActive
        {
            set 
            { 
                isActive = value;
                this.Invalidate();
            }
            
            get { return isActive;  }
        }
        
        public UserControlSpellSlotIndicator()
        {
            InitializeComponent();

            /* Fixed size for this control. */
            this.Size = new Size(15, 15);
            this.BackColor = Color.Transparent;
        }

        private void UserControlSpellSlotIndicator_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            /* Draw the border. */
            gfx.FillEllipse(new SolidBrush(Color.DarkBlue), new Rectangle(new Point(0,0), new Size(this.Width - 1, this.Height - 1)));

            Rectangle contentRect = new Rectangle(new Point(2,2), new Size(this.Width - 5, this.Height - 5));

            if (!isMouseSelecting)
            {
                if (isActive)
                {
                    gfx.FillEllipse(new SolidBrush(Color.Green), contentRect);
                }
                else
                {
                    gfx.FillEllipse(new SolidBrush(Color.DarkRed), contentRect);
                }
            }
            else
            {
                if (isActive)
                {
                    gfx.FillEllipse(new SolidBrush(Color.LightGreen), contentRect);
                }
                else
                {
                    gfx.FillEllipse(new SolidBrush(Color.Red), contentRect);
                }
            }
        }

        private void UserControlSpellSlotIndicator_Load(object sender, EventArgs e)
        {

        }

        private void UserControlSpellSlotIndicator_MouseClick(object sender, MouseEventArgs e)
        {
            IsActive = !isActive;
            if (SpellSlotCheckedChangedByUser!= null)
            {
                SpellSlotCheckedChangedByUser.Invoke();
            }
        }

        private void UserControlSpellSlotIndicator_MouseEnter(object sender, EventArgs e)
        {
            isMouseSelecting = true;
            this.Invalidate();
        }

        private void UserControlSpellSlotIndicator_MouseLeave(object sender, EventArgs e)
        {
            isMouseSelecting = false;
            this.Invalidate();
        }
    }
}
