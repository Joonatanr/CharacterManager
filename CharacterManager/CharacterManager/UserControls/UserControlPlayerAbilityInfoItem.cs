using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public class UserControlPlayerAbilityInfoItem : UserControlGenericListBase<PlayerAbilityInfoItem>
    {
        public string LabelText { get; set; } = "Ability Data";

        public override void SetListData(List<PlayerAbilityInfoItem> data)
        {
            base.SetListData(data);
            setupButtons();
            this.Invalidate();
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, LabelText, 0, FontStyle.Bold);
            base.drawDisplayedData(gfx, font);
        }

        private void setupButtons()
        {
            //Lets remove any old buttons.
            List<Control> myListToRemove = new List<Control>();
            foreach (Control c in this.Controls)
            {
                myListToRemove.Add(c);
            }

            foreach (Control c in myListToRemove)
            {
                this.Controls.Remove(c);
            }

            int y = 1;

            foreach (PlayerAbilityInfoItem item in myItemList)
            {
                if (item.IsUsable)
                {
                    /* TODO : Add functionality to button. */
                    Button UseButton = new Button();
                    UseButton.Text = "Use";
                    AddControlOnLine(UseButton, y, 0, false);
                }
                y++;
            }
        }
    }
}
