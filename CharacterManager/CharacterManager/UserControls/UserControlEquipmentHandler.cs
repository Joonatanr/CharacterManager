﻿using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            int y = lineInterval;


            buttonList = new List<InfoButton>();

            foreach (PlayerItem i in GeneralEquipmentList)
            {
                //InfoButton eqButton = new InfoButton(i.ItemName, i.Description);
                /* TODO */
            }
        }
    }
}
