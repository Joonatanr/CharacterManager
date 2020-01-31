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
    class UserControlGenericEquipmentList : UserControlGenericListBase
    {
        /* This one might be updated separately... */
        private List<PlayerToolKit> toolList = new List<PlayerToolKit>();
        private List<PlayerWeapon> wList = new List<PlayerWeapon>();
        private List<PlayerArmor> aList = new List<PlayerArmor>();
        private List<PlayerItem> eList = new List<PlayerItem>();

        /* Updates all items. */
        public void setEquipmentList(List<PlayerItem> equipment)
        {
            updateLists(equipment);
            updateInfoButtons();

            this.Invalidate();
        }

        /* TODO : Returns all items regardless of type. */
        public List<PlayerItem> getEquipmentList()
        {
            List<PlayerItem> res = new List<PlayerItem>();

            /* TODO : This is a bit of a mess, maybe we should keep all items separately??? */

            return res;
        }

        public List<PlayerWeapon> getWeaponList()
        {
            return wList;
        }

        public List<PlayerArmor> getArmorList()
        {
            return aList;
        }

        public List<PlayerItem> getAllGeneralEquipment()
        {
            /* We return everything that is not a weapon or an armor. */
            List<PlayerItem> res = new List<PlayerItem>();

            foreach (PlayerToolKit tool in toolList)
            {
                res.Add(tool);
            }

            foreach (PlayerItem equipment in eList)
            {
                res.Add(equipment);
            }

            return res;
        }

        /* Separate function for updating the toolkit list. These can change independetly of the rest of the equipment. */
        /* TODO : We may need to handle this in a different manner... */
        public void setToolkitList(List<PlayerToolKit> toolsets)
        {
            this.toolList = toolsets;

            toolList = toolsets;
            updateInfoButtons();
            this.Invalidate();
        }

        private void updateInfoButtons()
        {
            /* TODO : This obviously isn't a very good solution, but maybe it will be OK??? */
            //Lets remove any old buttons.
            List<Control> myListToRemove = new List<Control>();
            foreach (Control c in this.Controls)
            {
                if (c is InfoButton)
                {
                    myListToRemove.Add(c);
                }
            }

            foreach (Control c in myListToRemove)
            {
                this.Controls.Remove(c);
            }

            //Lets test adding a button for each piece of equipment.
            int y = 2;

            foreach (PlayerWeapon w in wList)
            {
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), w.getExtendedDescription());
                buttonNumber++;
                AddButtonOnLine(myBtn, y);
                y++;
            }

            y += 2;

            foreach (PlayerArmor a in aList)
            {
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), a.getExtendedDescription()); 
                buttonNumber++;
                AddButtonOnLine(myBtn, y);
                y++;
            }

            y += 2;

            foreach (PlayerItem e in eList)
            {                
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), e.getExtendedDescription()); 
                buttonNumber++;
                AddButtonOnLine(myBtn, y);
                y++;
            }

            foreach (PlayerToolKit t in toolList)
            {
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), t.getExtendedDescription()); 
                buttonNumber++;
                AddButtonOnLine(myBtn, y);
                y++;
            }
        }


        private void updateLists(List<PlayerItem> allItemsList)
        {
            wList = new List<PlayerWeapon>();
            aList = new List<PlayerArmor>();
            eList = new List<PlayerItem>();
            toolList = new List<PlayerToolKit>();

            if (allItemsList == null)
            {
                return;
            }

            foreach (PlayerItem item in allItemsList)
            {
                if (item is PlayerWeapon)
                {
                    wList.Add((PlayerWeapon)item);
                }
                else if (item is PlayerArmor)
                {
                    aList.Add((PlayerArmor)item);
                }
                else if (item is PlayerToolKit)
                {
                    /* Shouldn't normally happen. */
                    toolList.Add((PlayerToolKit)item);
                }
                else
                {
                    eList.Add(item);
                }
            }
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 0;
            
            //Lets draw a descriptive text.
            gfx.DrawString("Items:", font, new SolidBrush(Color.Black), new Point(1, 1));

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
