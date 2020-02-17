using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;

namespace CharacterManager.UserControls
{
    public class UserControlEquipmentHandler : UserControlGenericListBase
    {
        private List<PlayerItem> GeneralEquipmentList = new List<PlayerItem>();
        private List<InfoButton> buttonList;
        
        public UserControlEquipmentHandler() : base()
        {
            /* Constructor. */
        }

        public void setGeneralEquipmentList(List<PlayerItem> eList)
        {
            GeneralEquipmentList = eList;
            setupButtons();
            this.Invalidate();
        }

        public void setupButtons()
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


            int y = 0;
            buttonList = new List<InfoButton>();
            
            foreach (PlayerItem i in GeneralEquipmentList)
            {
                InfoButton eqButton = new InfoButton(i.ItemName, i.Description);
                AddButtonOnLine(eqButton, y, 0);
                y++;
            }
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 0;

            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Inventory:", y, FontStyle.Bold);
            y++;

            foreach (PlayerItem i in GeneralEquipmentList)
            {
                drawTextOnLine(gfx, i.getDisplayedName(), y);
                y++;
            }
        }
    }
}
