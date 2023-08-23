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
    class UserControlArmorHandler : UserControlGenericListBase
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


            public void setEquipped(Boolean isEquipped)
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
                    setEquipped(false);
                    armor.IsEquipped = false;
                    EquippedChangedHandler?.Invoke(armor, false);
                    
                }
                else
                {
                    setEquipped(true);
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
                        setEquipped(false);
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


        private List<PlayerArmor> armorList = new List<PlayerArmor>();
        private List<ArmorControlData> mainList = new List<ArmorControlData>();

        public delegate void ArmorEquipChangedHandler(PlayerArmor armor);
        public ArmorEquipChangedHandler ArmorEquipChanged;
        public ArmorEquipChangedHandler ArmorDropped;

        public UserControlArmorHandler() : base()
        {
            
        }

        public void setArmorList(List<PlayerArmor> aList)
        {
            armorList = aList;
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
            mainList = new List<ArmorControlData>();
            foreach (PlayerArmor a in armorList)
            {
                ArmorControlData myData = new ArmorControlData(a);

                /* 1. Set up the info button. */
                myData.infoBtn.Location = new Point(this.Width - 43, y + 3);
                this.Controls.Add(myData.infoBtn);

                /* 2. Set up the Equip button. */
                myData.EquipButton.Location = new Point((myData.infoBtn.Left - 1) - myData.EquipButton.Width, y + 3);
                myData.setEquipped(a.IsEquipped);
                myData.EquippedChangedHandler = ArmorEquippedChanged;
                this.Controls.Add(myData.EquipButton);

                /* 3. Set up the Drop button. */
                myData.DropButton.Location = new Point(0, y + 3);
                myData.ArmorDroppedHandler += HandleDrop;
                this.Controls.Add(myData.DropButton);

                /* Finish up.. */
                y += lineInterval;
                mainList.Add(myData);
            }
        }

        public void updateEquippedStatus()
        {
            foreach(ArmorControlData acdata in mainList) 
            {
                acdata.setEquipped(acdata.armor.IsEquipped);
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
                            cData.setEquipped(false);
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

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 0;

            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Armor:", y, FontStyle.Bold);
            y++;

            foreach (PlayerArmor a in armorList)
            {
                drawTextOnLine(gfx, "        " + a.ItemName, y);
                y++;
            }
        }
    }
}
