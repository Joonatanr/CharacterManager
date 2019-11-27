using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterManager.UserControls
{
    class UserControlGenericEquipmentList : UserControlGenericListBase
    {
        private List<PlayerItem> equipmentList = new List<PlayerItem>();
        private List<PlayerToolKit> toolList = new List<PlayerToolKit>();

        public void setEquipmentList(List<PlayerItem> equipment)
        {
            equipmentList = equipment;

            //TODO : Add info buttons.


            this.Invalidate();
        }

        /* Separate function for updating the toolkit list. These can change independetly of the rest of the equipment. */
        public void setToolkitList(List<PlayerToolKit> toolsets)
        {
            this.toolList = toolsets;
            this.Invalidate();
        }


        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 1;
            
            //Lets draw a descriptive text.
            gfx.DrawString("Items:", font, new SolidBrush(Color.Black), new Point(1, 1));


            List<PlayerWeapon> wList = new List<PlayerWeapon>();
            List<PlayerArmor> aList = new List<PlayerArmor>();
            List<PlayerItem> eList = new List<PlayerItem>();

            if (equipmentList == null)
            {
                return;
            }

            foreach (PlayerItem item in equipmentList)
            {
                if (item is PlayerWeapon)
                {
                    wList.Add((PlayerWeapon)item);
                }
                else if (item is PlayerArmor)
                {
                    aList.Add((PlayerArmor)item);
                }
                else if(item is PlayerToolKit)
                {
                    toolList.Add((PlayerToolKit)item);
                }
                else
                {
                    eList.Add(item);
                }
            }

            y++;
            drawTextOnLine(gfx, "Weapons", y, FontStyle.Bold);
            y++;

            foreach (PlayerWeapon w in wList)
            {
                drawEquipmentString(gfx, w, y);
                y++;
            }

            y++;
            drawTextOnLine(gfx, "Armor", y, FontStyle.Bold);
            y++;

            foreach(PlayerArmor a in aList)
            {
                drawEquipmentString(gfx, a, y);
                y++;
            }

            y++;
            drawTextOnLine(gfx, "Equipment", y, FontStyle.Bold);
            y++;

            foreach(PlayerItem i in eList)
            {
                drawEquipmentString(gfx, i, y);
                y++;
            }

            foreach (PlayerToolKit tool in toolList)
            {
                drawEquipmentString(gfx, tool, y);
                y++;
            }
        }

        private void drawEquipmentString(Graphics gfx, PlayerItem item, int line)
        {
            String str = item.ItemName;

            if (item.Quantity > 1)
            {
                str = str + "(" + item.Quantity.ToString() + ")";
            }

            drawTextOnLine(gfx, str, line);
        }
    }
}
