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
    public class UserControlWeaponsHandler : UserControlGenericListBase
    {
        /* TODO */
        private class WeaponControlData
        {
            public PlayerWeapon weapon;
            public InfoButton infoBtn;

            public WeaponControlData(PlayerWeapon w)
            {
                weapon = w;
                infoBtn = new InfoButton("Button " + buttonNumber++, w.getExtendedDescription());
            }
        }

        private List<PlayerWeapon> weaponList = new List<PlayerWeapon>();
        private List<WeaponControlData> mainList = new List<WeaponControlData>();


        public void setWeaponList(List<PlayerWeapon> wList)
        {
            this.weaponList = wList;
            /* TODO : Infobuttons, equip and attack buttons. */
            setupButtons();
            this.Invalidate();
        }


        public void setupButtons()
        {
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


            int y = lineInterval;
            mainList = new List<WeaponControlData>();
            foreach (PlayerWeapon w in weaponList)
            {
                WeaponControlData myData = new WeaponControlData(w);

                /* 1. Set up the info button. */
                myData.infoBtn.Location = new Point(this.Width - 43, y + 3);
                this.Controls.Add(myData.infoBtn);

                /* 2. TODO */


                /* Finish up.. */
                y += lineInterval;
                mainList.Add(myData);
            }

        }

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = -1;

            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Weapons:", y, FontStyle.Bold);
            y++;

            foreach (PlayerWeapon w in weaponList)
            {
                drawTextOnLine(gfx, w.ItemName, y);
                y++;
            }

        }
    }
}
