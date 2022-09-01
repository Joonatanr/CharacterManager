using System;
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
        private class AttributeControlData
        {
            public PlayerAbility Attribute;
            public InfoButton ButtonInfo;
            public CustomButton UseButton;

            public delegate Boolean UseAbilityButtonHandler(PlayerAbility ability);
            public UseAbilityButtonHandler UseAbilityButtonClicked;

            public delegate void ChangeAbilityChargesManuallyHandler(PlayerAbility ability, int numberOfActiveButtons);
            public ChangeAbilityChargesManuallyHandler changeAbilityChargesManually;

            /* TODO */
            public UserControlSpellSlotIndicator [] slotArray;

            private int numberOfSpellSlots;

            public AttributeControlData(PlayerAbility _attribute)
            {
                Attribute = _attribute;
                _attribute.RemainingChargesChanged += new PlayerAbility.PlayerAbilityValueChanged(HandleRemainingChargesChanged);
            }

            public void setUseButton(CustomButton btn)
            {
                this.UseButton = btn;
                btn.Click += Use_Click;
            }

            private void Btn_Click(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }

            private void HandleRemainingChargesChanged(int value)
            {
                int active_cnt = value;

                if (slotArray != null) 
                {
                    for (int x = 0; x < slotArray.Length; x++)
                    {
                        if (active_cnt > 0)
                        {
                            slotArray[x].IsActive = true;
                            active_cnt--;
                        }
                        else
                        {
                            slotArray[x].IsActive = false;
                        }
                    }
                }
            }

            public void setSpellSlots(UserControlSpellSlotIndicator[] slots, int cnt) 
            {
                numberOfSpellSlots = cnt;

                slotArray = new UserControlSpellSlotIndicator[cnt];
                
                for (int x = 0; x < cnt; x++)
                {
                    slotArray[x] = slots[x];
                    slotArray[x].SpellSlotCheckedChangedByUser = handleActiveSpellSlotsChangedByUser;
                }

                setNumberOfSpellSlotsActive(Attribute.RemainingCharges);
            }

            /// <summary>
            /// This is called if the user manually presses one of the spell slots and therefore spends or restores a charge.
            /// </summary>
            private void handleActiveSpellSlotsChangedByUser(bool IsChecked)
            {
                int cnt = 0;

                foreach (UserControlSpellSlotIndicator indicator in slotArray)
                {
                    if (indicator.IsActive)
                    {
                        cnt++;
                    }
                }
                
                if (changeAbilityChargesManually != null)
                {
                    changeAbilityChargesManually.Invoke(Attribute, cnt);
                }
            }

            private void setNumberOfSpellSlotsActive(int cnt)
            {
                if (cnt > numberOfSpellSlots)
                {
                    /* Should not really happen. */
                    cnt = numberOfSpellSlots;
                }

                for (int x = 0; x < numberOfSpellSlots; x++)
                {
                    if (x < cnt)
                    {
                        slotArray[x].IsActive = true;
                    }
                    else
                    {
                        slotArray[x].IsActive = false;
                    }
                }
            }

            private void Use_Click(object sender, EventArgs e)
            {
                if (Attribute.RemainingCharges > 0 ||(Attribute.IsToggle && Attribute.IsActive))
                {
                    if (UseAbilityButtonClicked != null)
                    {
                        if (UseAbilityButtonClicked.Invoke(Attribute))
                        {
                            if (Attribute.IsToggle)
                            {
                                if (Attribute.IsActive)
                                {
                                    this.UseButton.ButtonText = "Disable";
                                    Attribute.RemainingCharges--;
                                    setNumberOfSpellSlotsActive(Attribute.RemainingCharges);
                                }
                                else
                                {
                                    this.UseButton.ButtonText = "Activate";
                                }
                                UseButton.Parent.Invalidate();
                            }
                            else
                            {
                                Attribute.RemainingCharges--;
                                setNumberOfSpellSlotsActive(Attribute.RemainingCharges);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No uses of ability remaining");
                }
            }
        }

        private List<PlayerAbility> listOfAttributes = new List<PlayerAbility>();
        private List<AttributeControlData> listOfAttributeControls = new List<AttributeControlData>();


        public Boolean IsSlotsVisible { get; set; } = false;

        public delegate Boolean PlayerAbilityUseHandler(PlayerAbility ability);
        public event PlayerAbilityUseHandler PlayerAbilityUsed;

        public UserControlGenericAbilitiesList() : base()
        {
            InitializeComponent();
        }

        public void setAttributeList(List<PlayerAbility> target)
        {
            listOfAttributes = target;
            listOfAttributeControls = new List<AttributeControlData>();

            List<Control> myListToRemove = new List<Control>();

            //Lets remove any old buttons.
            foreach (Control c in this.Controls)
            {
                myListToRemove.Add(c);
            }

            foreach (Control c in myListToRemove)
            {
                this.Controls.Remove(c);
            }


            //Lets test adding a button for reach of the attributes.
            int y = 1;
            foreach (PlayerAbility attrib in listOfAttributes)
            {
                AttributeControlData cData = new AttributeControlData(attrib);
                

                /***YOLO****/


                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), new EventHandler(attrib.HandleInfoButtonClicked));
                myBtn.Width = 35;
                buttonNumber++;
                AddButtonOnLine(myBtn, y, 0);
                cData.ButtonInfo = myBtn;

                /* TODO : This part is unfinished and mostly a placeholder. */
                if (IsSlotsVisible) 
                {
                    if (attrib.MaximumCharges > 0)
                    {
                        /* Lets add the use button. */
                        CustomButton useButton = new CustomButton();
                        useButton.Size = new Size(45, 17);
                        if (attrib.IsToggle) 
                        {
                            if (attrib.IsActive) 
                            {
                                useButton.ButtonText = "Disable";
                            }
                            else
                            {
                                useButton.ButtonText = "Activate";
                            }
                        }
                        else
                        {
                            useButton.ButtonText = "Use";
                        }
                        AddButtonOnLine(useButton, y, myBtn.Width + 1);

                        cData.setUseButton(useButton);
                        cData.UseAbilityButtonClicked = handleUseAbilityButton;
                        cData.changeAbilityChargesManually = SpellSlotIndicatorChangedManuallyHandler;

                        UserControlSpellSlotIndicator [] arr = new UserControlSpellSlotIndicator[attrib.MaximumCharges];

                        for (int x = 0; x < attrib.MaximumCharges; x++)
                        {
                            UserControlSpellSlotIndicator slotIndicator = new UserControlSpellSlotIndicator();
                            AddSpellSlotOnLine(slotIndicator, y, useButton.Left - (((x + 1) * slotIndicator.Width) + 6));
                            arr[x] = slotIndicator;
                        }

                        cData.setSpellSlots(arr, attrib.MaximumCharges);
                    }
                }

                listOfAttributeControls.Add(cData);

                y++;
            }

            this.Invalidate();
        }

        private Boolean handleUseAbilityButton(PlayerAbility ability)
        {
            if (PlayerAbilityUsed == null)
            {
                return false;
            }
            else
            {
               return PlayerAbilityUsed.Invoke(ability);
            }
        }

        private void SpellSlotIndicatorChangedManuallyHandler(PlayerAbility ability, int cnt)
        {
            ability.RemainingCharges = cnt;
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Abilities:", 0, font);

            int y = 2;
            if (listOfAttributes != null)
            {
                foreach (PlayerAbility attrib in listOfAttributes)
                {
                    if (attrib.IsToggle)
                    {
                        if (attrib.IsActive)
                        {
                            drawRectangleOnLine(gfx, y, Color.Orange);
                        }
                    }
                    
                    drawTextOnLine(gfx, attrib.DisplayedName, y);
                    y++;
                }
            }
        }
    }
}
