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
    public class UserControlWeaponsHandler : UserControlGenericListBase<PlayerWeapon>
    {
        private class WeaponControlData
        {
            public PlayerWeapon weapon;
            public InfoButton infoBtn;
            public CustomButton AttackBtn;
            public CustomButton EquipButton;
            public CustomButton DropButton;

            public delegate void WeaponButtonClickedHandler(PlayerWeapon w);
            public event WeaponButtonClickedHandler WeaponAttackClicked;
            public event WeaponButtonClickedHandler WeaponEquipClicked;
            public event WeaponButtonClickedHandler WeaponDroppedClicked;

            public WeaponControlData(PlayerWeapon w)
            {
                weapon = w;
                infoBtn = new InfoButton("Button " + buttonNumber++, w.getExtendedDescription());
                EquipButton = new CustomButton();
                EquipButton.Size = new Size(70, 16);
                EquipButton.ButtonText = "Equip";
                EquipButton.Font = new Font("Arial", 8.0f);
                EquipButton.Click += new System.EventHandler(EquipButton_Click);

                AttackBtn = new CustomButton();
                AttackBtn.Size = new Size(40, 17);
                AttackBtn.ButtonText = "Attack";
                AttackBtn.Click += new System.EventHandler(AttackBtn_Click);

                DropButton = new CustomButton();
                DropButton.Size = new Size(40, 16);
                DropButton.ButtonText = "Drop";
                DropButton.Font = new Font("Arial", 8.0f);
                DropButton.Click += DropButton_Click;
            }

            private void DropButton_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to drop " + weapon.DisplayedName, "Drop weapon", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    WeaponDroppedClicked?.Invoke(weapon);
                }
                else if (dialogResult == DialogResult.No)
                {
                    /* Do nothing */
                }
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

                WeaponEquipClicked?.Invoke(weapon);
            }
        }

        private List<WeaponControlData> mainList = new List<WeaponControlData>();

        public delegate void weaponEventHandler(PlayerWeapon w);
        public event weaponEventHandler WeaponAttackEvent;
        public event weaponEventHandler WeaponEquipEvent;
        public event weaponEventHandler WeaponDropEvent;


        public void setWeaponList(List<PlayerWeapon> wList)
        {
            SetListData(wList);
            setupButtons();
            this.DoubleBuffered = true;
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
            mainList = new List<WeaponControlData>();
            foreach (PlayerWeapon w in myItemList)
            {
                WeaponControlData myData = new WeaponControlData(w);

                /* 1. Set up the attack button. */
                myData.WeaponAttackClicked += HandleAttack;
                myData.WeaponEquipClicked += HandleEquip;
                AddControlOnLine(myData.AttackBtn, y, 0, false);

                /* 2. Set up the info button. */
                myData.infoBtn.Location = new Point((myData.AttackBtn.Left - 1) - myData.AttackBtn.Width, y + 3);
                AddControlOnLine(myData.infoBtn, y, 0, false);

                /* 3. Set up the Equip button. */
                myData.setEquipped(w.IsEquipped, w.IsEquippedTwoHanded);
                AddControlOnLine(myData.EquipButton, y, 0, false);

                /* 4. Set up the Drop button. */
                myData.WeaponDroppedClicked += HandleDrop;
                AddControlOnLine(myData.DropButton, y, 0, true);

                /* Finish up.. */
                y++;
                mainList.Add(myData);
            }

            this.Invalidate();
        }


        public void updateEquipStatus()
        {
            foreach(WeaponControlData wcdata in mainList)
            {
                wcdata.setEquipped(wcdata.weapon.IsEquipped, wcdata.weapon.IsEquippedTwoHanded);
            }
        }

        private void HandleAttack(PlayerWeapon w)
        {
            /* Pass the event outside of the control. */
            WeaponAttackEvent?.Invoke(w);
        }

        private void HandleDrop(PlayerWeapon w)
        {
            WeaponDropEvent?.Invoke(w);
        }


        private void HandleEquip(PlayerWeapon w)
        {
            WeaponEquipEvent?.Invoke(w);
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Weapons:", 0, FontStyle.Bold);
            base.drawDisplayedData(gfx, font);
        }
    }
}
