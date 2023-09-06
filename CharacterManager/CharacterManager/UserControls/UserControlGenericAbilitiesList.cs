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
    public partial class UserControlGenericAbilitiesList : UserControlGenericListBase<PlayerAbility>
    {
        private class AttributeControlData
        {
            private PlayerAbility _myAttribute;
            
            public PlayerAbility Attribute
            {
                get
                {
                    return _myAttribute;
                }

                set
                {
                    _myAttribute = value;
                    _myAttribute.RemainingChargesChanged += new PlayerAbility.PlayerAbilityValueChanged(HandleRemainingChargesChanged);
                    _myAttribute.IsActiveChanged += new PlayerAbility.PlayerAbilityIsActiveChanged(handleAbilityActiveChanged);
                }
            }
            public InfoButton ButtonInfo;
            public CustomButton UseButton;

            public delegate void ChangeAbilityChargesManuallyHandler(PlayerAbility ability, int numberOfActiveButtons);
            public ChangeAbilityChargesManuallyHandler changeAbilityChargesManually;

            public delegate void DisplayDataChangedHandler();
            public DisplayDataChangedHandler DisplayDataChanged;

            public UserControlSpellSlotIndicator [] slotArray;

            private int numberOfSpellSlots;


            public AttributeControlData(PlayerAbility _attribute)
            {
                Attribute = _attribute;
            }

            public void setUseButton(CustomButton btn)
            {
                this.UseButton = btn;
                btn.Click += Use_Click;
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
                if (Attribute.UseAbility())
                {
                     /* Should we do something here. */
                }
                else
                {
                    MessageBox.Show("No uses of ability remaining");
                }
            }

            private void handleAbilityActiveChanged(bool isActive)
            {
                if (Attribute.IsToggle)
                {
                    if (Attribute.IsActive)
                    {
                        if (this.UseButton != null)
                        {
                            this.UseButton.ButtonText = "Disable";
                        }
                        //Attribute.RemainingCharges--;
                    }
                    else
                    {
                        if (this.UseButton != null)
                        {
                            this.UseButton.ButtonText = "Activate";
                        }
                    }
                    
                    if(DisplayDataChanged != null)
                    {
                        DisplayDataChanged.Invoke();
                    }
                }
                else
                {
                    //Attribute.RemainingCharges--;
                }
            }
        }


        public String Title { get; set; } = "Abilities:";

        //private List<PlayerAbility> listOfAttributes = new List<PlayerAbility>();
        private List<AttributeControlData> listOfAttributeControls = new List<AttributeControlData>();

        public Boolean IsSlotsVisible { get; set; } = false;

        public UserControlGenericAbilitiesList() : base()
        {
            InitializeComponent();
        }

        public void setAttributeList(List<PlayerAbility> target)
        {
            SetListData(target);
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


            int y = 1;
            foreach (PlayerAbility attrib in myItemList)
            {
                AttributeControlData cData = new AttributeControlData(attrib);

                InfoButton myBtn = new InfoButton("InfoButton" + buttonNumber.ToString(), new EventHandler(attrib.HandleInfoButtonClicked));
                myBtn.Width = 35;
                buttonNumber++;
                AddButtonOnLine(myBtn, y, 0);
                cData.ButtonInfo = myBtn;

                if (IsSlotsVisible) 
                {
                    if (attrib.MaximumCharges > 0 || attrib.IsToggle)
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
                        cData.changeAbilityChargesManually = SpellSlotIndicatorChangedManuallyHandler;
                        cData.DisplayDataChanged = new AttributeControlData.DisplayDataChangedHandler(handleDisplayDataChanged);

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

        private void handleDisplayDataChanged()
        {
            this.Invalidate();
        }

        private void SpellSlotIndicatorChangedManuallyHandler(PlayerAbility ability, int cnt)
        {
            ability.RemainingCharges = cnt;
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, Title, 0, font);
            base.drawDisplayedData(gfx, font);
        }

        protected override void drawDisplayedDataSingleItem(Graphics gfx, Font font, int line, PlayerAbility item)
        {
            if (item.IsToggle)
            {
                if (item.IsActive)
                {
                    drawRectangleOnLine(gfx, line, Color.Orange);
                }
            }
            base.drawDisplayedDataSingleItem(gfx, font, line, item);
        }
    }
}
