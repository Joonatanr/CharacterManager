﻿using System;
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
    public partial class UserControlGenericAbilitiesList : UserControlGenericListBase
    {
        private List<PlayerAbility> listOfAttributes = new List<PlayerAbility>();

        public UserControlGenericAbilitiesList() : base()
        {
            InitializeComponent();
        }

        public void setAttributeList(List<PlayerAbility> target)
        {
            listOfAttributes = target;
            List<Control> myListToRemove = new List<Control>();

            //Lets remove any old buttons.
            foreach (Control c in this.Controls)
            {
                if (c is InfoButton)
                {
                    myListToRemove.Add(c);
                }
            }

            foreach(Control c in myListToRemove)
            {
                this.Controls.Remove(c);
            }

            //Lets test adding a button for reach of the attributes.
            int y = 1;
            foreach (PlayerAbility attrib in listOfAttributes)
            {
                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), attrib.Description);
                buttonNumber++;
                AddButtonOnLine(myBtn, y);
                y++;
            }

            this.Invalidate();
        }


        protected override void drawData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            gfx.DrawString("Abilities:", font, new SolidBrush(Color.Black), new Point(1, 1));

            int y = 1;
            if (listOfAttributes != null)
            {
                foreach (PlayerAbility attrib in listOfAttributes)
                {
                    drawTextOnLine(gfx, attrib.DisplayedName, y);
                    y++;
                }
            }
        }
    }
}
