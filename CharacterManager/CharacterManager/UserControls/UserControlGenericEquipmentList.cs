﻿using CharacterManager.Items;
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
        private List<PlayerItem> allItemsList = new List<PlayerItem>();

        /* This one might be updated separately... */
        private List<PlayerToolKit> toolList = new List<PlayerToolKit>();

        private List<PlayerWeapon> wList = new List<PlayerWeapon>();
        private List<PlayerArmor> aList = new List<PlayerArmor>();
        private List<PlayerItem> eList = new List<PlayerItem>();

        /* Updates all items. */
        public void setEquipmentList(List<PlayerItem> equipment)
        {
            allItemsList = equipment;
            updateLists();
            updateInfoButtons();
            //TODO : Add info buttons.


            this.Invalidate();
        }

        /* Separate function for updating the toolkit list. These can change independetly of the rest of the equipment. */
        public void setToolkitList(List<PlayerToolKit> toolsets)
        {
            this.toolList = toolsets;

            updateLists();
            updateInfoButtons();
            this.Invalidate();
        }

        private void updateInfoButtons()
        {
            /* TODO : This obviously isn't a very good solution, but maybe it will be OK??? */
            //Lets remove any old buttons.
            List<Control> myListToRemove = new List<Control>();
            foreach (Control c in panel1.Controls)
            {
                if (c is InfoButton)
                {
                    myListToRemove.Add(c);
                }
            }

            foreach (Control c in myListToRemove)
            {
                panel1.Controls.Remove(c);
            }

            //Lets test adding a button for each piece of equipment.
            int y = lineInterval * 2;



            foreach (PlayerWeapon w in wList)
            {
                y += lineInterval;
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), w.Description); /* TODO : Most weapons do not have descriptions, need extended description to detail damage, etc. */
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 43, y + 3);
                panel1.Controls.Add(myBtn);
            }

            y += lineInterval * 2;

            foreach (PlayerArmor a in aList)
            {
                y += lineInterval;
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), a.Description); /* TODO : Most weapons do not have descriptions, need extended description to detail damage, etc. */
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 43, y + 3);
                panel1.Controls.Add(myBtn);
            }

            y += lineInterval * 2;

            foreach (PlayerItem e in eList)
            {
                y += lineInterval;
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), e.Description); /* TODO : Most weapons do not have descriptions, need extended description to detail damage, etc. */
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 43, y + 3);
                panel1.Controls.Add(myBtn);
            }

            y += lineInterval * 2;

            foreach (PlayerToolKit t in toolList)
            {
                y += lineInterval;
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), t.Description); /* TODO : Most weapons do not have descriptions, need extended description to detail damage, etc. */
                buttonNumber++;
                myBtn.Location = new Point(this.panel1.Width - 43, y + 3);
                panel1.Controls.Add(myBtn);
            }
        }


        private void updateLists()
        {
            wList = new List<PlayerWeapon>();
            aList = new List<PlayerArmor>();
            eList = new List<PlayerItem>();

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

            if (allItemsList == null)
            {
                return;
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