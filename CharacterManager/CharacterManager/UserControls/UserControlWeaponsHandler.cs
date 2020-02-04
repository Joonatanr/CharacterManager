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
        private class WeaponControlData
        {
            public PlayerWeapon weapon;
            public InfoButton infoBtn;
            public CustomButton AttackBtn;
            public CustomButton EquipButton;

            public delegate void WeaponAtckButtonClickedHandler(PlayerWeapon w);
            public event WeaponAtckButtonClickedHandler WeaponAttackClicked;

            public WeaponControlData(PlayerWeapon w)
            {
                weapon = w;
                infoBtn = new InfoButton("Button " + buttonNumber++, w.getExtendedDescription());
                EquipButton = new CustomButton();
                EquipButton.Size = new Size(70, 16);
                EquipButton.ButtonText = "Equip";
                EquipButton.Font = new Font("Arial", 8.0f);
                EquipButton.Click += new System.EventHandler(EquipButton_Click);

                /* TODO : Set up attack button. */
                AttackBtn = new CustomButton();
                AttackBtn.Size = new Size(40, 17);
                AttackBtn.ButtonText = "Attack";
                AttackBtn.Click += new System.EventHandler(AttackBtn_Click);
            }


            public void setEquipped(Boolean isEquipped, Boolean isTwoHanded)
            {
                if (isEquipped)
                {
                    if (isTwoHanded)
                    {
                        EquipButton.BackGroundColor = Color.LightYellow;
                        EquipButton.HoverColor = Color.Orange;
                        EquipButton.ButtonText = "Equipped 2H";
                    }
                    else
                    {
                        EquipButton.BackGroundColor = Color.LightGreen;
                        EquipButton.HoverColor = Color.Green;
                        EquipButton.ButtonText = "Equipped";
                    }
                }
                else
                {
                    EquipButton.ButtonText = "Equip";
                    EquipButton.BackGroundColor = Color.LightGray;
                    EquipButton.HoverColor = Color.DarkGray;
                }
            }

            private void AttackBtn_Click(object sender, EventArgs e)
            {
                WeaponAttackClicked?.Invoke(weapon);
            }

            private void EquipButton_Click(object sender, EventArgs e)
            {
                /* TODO : This is a placeholder. */
                if (weapon.IsVersatile)
                {
                    if (weapon.IsEquipped && !weapon.IsEquippedTwoHanded)
                    {
                        setEquipped(true, true);
                        weapon.setEquipped(true, true);
                    }
                    else if (weapon.IsEquipped && weapon.IsEquippedTwoHanded)
                    {
                        setEquipped(false, false);
                        weapon.setEquipped(false, false);
                    }
                    else
                    {
                        setEquipped(true, false);
                        weapon.setEquipped(true, false);
                    }
                }
                else
                {
                    if (weapon.IsEquipped)
                    {
                        setEquipped(false, weapon.IsTwoHanded);
                        weapon.setEquipped(false, false);
                    }
                    else
                    {
                        setEquipped(true, weapon.IsTwoHanded);
                        weapon.setEquipped(true, false);
                    }
                }
            }
        }

        private List<PlayerWeapon> weaponList = new List<PlayerWeapon>();
        private List<WeaponControlData> mainList = new List<WeaponControlData>();

        public delegate void weaponAttackHandler(PlayerWeapon w);
        public event weaponAttackHandler WeaponAttackEvent;


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
                myListToRemove.Add(c);
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

                /* 1. Set up the attack button. */
                myData.AttackBtn.Location = new Point(this.Width - 43, y + 3);
                myData.WeaponAttackClicked += HandleAttack;
                this.Controls.Add(myData.AttackBtn);


                /* 2. Set up the info button. */
                myData.infoBtn.Location = new Point((myData.AttackBtn.Left - 1) - myData.AttackBtn.Width, y + 3);
                this.Controls.Add(myData.infoBtn);

                /* 3. Set up the Equip button. */
                myData.EquipButton.Location = new Point((myData.infoBtn.Left - 1) - myData.EquipButton.Width, y + 3);
                myData.setEquipped(w.IsEquipped, w.IsEquippedTwoHanded);
                this.Controls.Add(myData.EquipButton);

                /* Finish up.. */
                y += lineInterval;
                mainList.Add(myData);
            }
        }

        private void HandleAttack(PlayerWeapon w)
        {
            /* Pass the event outside of the control. */
            WeaponAttackEvent?.Invoke(w);
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
