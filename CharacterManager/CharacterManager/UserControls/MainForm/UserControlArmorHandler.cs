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
    class UserControlArmorHandler : UserControlGenericListBase<PlayerArmor>
    {
        private class ArmorControlData
        {
            public PlayerArmor armor;
            public InfoButton infoBtn;
            public CustomButton EquipButton;
            public CustomButton DropButton;

            public delegate void ArmorEquippedChangedHandler(PlayerArmor armor, Boolean updateOthers);
            public ArmorEquippedChangedHandler EquippedChangedHandler;
            public ArmorEquippedChangedHandler ArmorDroppedHandler;

            public ArmorControlData(PlayerArmor a)
            {
                armor = a;
                infoBtn = new InfoButton("Button " + buttonNumber++, a.getExtendedDescription());
                EquipButton = new CustomButton();
                EquipButton.Size = new Size(50, 16);
                EquipButton.ButtonText = "Equip";
                EquipButton.Font = new Font("Arial", 8.0f);
                EquipButton.Click += new System.EventHandler(EquipButton_Click);

                DropButton = new CustomButton();
                DropButton.Size = new Size(40, 16);
                DropButton.ButtonText = "Drop";
                DropButton.Font = new Font("Arial", 8.0f);
                DropButton.Click += DropButton_Click;
            }


            public void setEquippedVisualIndication(Boolean isEquipped)
            {
                if (isEquipped)
                {
                    EquipButton.ButtonText = "Unequip";
                    EquipButton.BackGroundColor = Color.LightGreen;
                    EquipButton.HoverColor = Color.Green;
                }
                else
                {
                    EquipButton.ButtonText = "Equip";
                    EquipButton.BackGroundColor = Color.LightGray;
                    EquipButton.HoverColor = Color.DarkGray;
                }
            }

            private void EquipButton_Click(object sender, EventArgs e)
            {
                if (armor.IsEquipped)
                {
                    setEquippedVisualIndication(false);
                    armor.IsEquipped = false;
                    EquippedChangedHandler?.Invoke(armor, false);
                    
                }
                else
                {
                    setEquippedVisualIndication(true);
                    armor.IsEquipped = true;
                    EquippedChangedHandler?.Invoke(armor, true);
                }
            }

            private void DropButton_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to drop " + armor.DisplayedName, "Drop armor", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    /* If we are currently equipping this armor, then first unequip. */
                    if (armor.IsEquipped)
                    {
                        setEquippedVisualIndication(false);
                        armor.IsEquipped = false;
                        EquippedChangedHandler?.Invoke(armor, false);
                        ArmorDroppedHandler?.Invoke(armor, false);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    /* Do nothing */
                }
            }
        }

        private List<ArmorControlData> mainList = new List<ArmorControlData>();

        public delegate void ArmorEquipChangedHandler(PlayerArmor armor);
        public ArmorEquipChangedHandler ArmorEquipChanged;
        public ArmorEquipChangedHandler ArmorDropped;

        public UserControlArmorHandler() : base()
        {
            
        }

        public void setArmorList(List<PlayerArmor> aList)
        {
            SetListData(aList);
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


            int y = 1;
            mainList = new List<ArmorControlData>();
            foreach (PlayerArmor a in myItemList)
            {
                ArmorControlData myData = new ArmorControlData(a);

                /* 1. Set up the info button. */
                this.Controls.Add(myData.infoBtn);
                AddControlOnLine(myData.infoBtn, y, 0, false);

                /* 2. Set up the Equip button. */
                myData.setEquippedVisualIndication(a.IsEquipped);
                myData.EquippedChangedHandler = ArmorEquippedChanged;
                AddControlOnLine(myData.EquipButton, y, 0, false);

                /* 3. Set up the Drop button. */
                myData.ArmorDroppedHandler += HandleDrop;
                AddControlOnLine(myData.DropButton, y, 0, true);

                /* Finish up.. */
                y++;
                mainList.Add(myData);
            }
        }

        public void updateEquippedStatus()
        {
            foreach(ArmorControlData acdata in mainList) 
            {
                acdata.setEquippedVisualIndication(acdata.armor.IsEquipped);
            }
        }

        private void ArmorEquippedChanged(PlayerArmor armor, Boolean updateOthers)
        {
            if (updateOthers)
            {
                if (armor.IsShield)
                {
                    /* I guess we might have 2 shields as well?? */
                }
                else
                {
                    foreach (ArmorControlData cData in mainList)
                    {
                        if ((cData.armor != armor) && (!cData.armor.IsShield))
                        {
                            cData.setEquippedVisualIndication(false);
                            cData.armor.IsEquipped = false;
                        }
                    }
                }
            }

            ArmorEquipChanged?.Invoke(armor);
        }

        private void HandleDrop(PlayerArmor armor, Boolean updateOthers)
        {
            ArmorDropped?.Invoke(armor);
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Armor:", 0, FontStyle.Bold);
            base.drawDisplayedData(gfx, font);
       }
    }
}
