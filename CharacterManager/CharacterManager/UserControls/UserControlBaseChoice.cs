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
    public abstract class UserControlBaseChoice <ItemType> : UserControlGenericListBase where ItemType : PlayerBaseItem 
    {
        /* Properties */
        private String _titleString = "Items:";
        public String TitleString
        {
            get { return _titleString; }
            set { _titleString = value; this.Invalidate(); }
        }

        public bool IsAvailabilityCount { get; set; } = true;

        public bool IsCheckBoxed { get; set; } = false;
        public int MaximumAvailableChoices { get; set; } = 0;

        protected List<ItemHandleControl<ItemType>> myControlList = new List<ItemHandleControl<ItemType>>();
        protected List<ItemType> myItemList = new List<ItemType>();
        protected List<ItemType> myLockedItemList = new List<ItemType>(); /* These are spells that are already chosen because they come from racial abilities etc... */

        /* This dictionary should contain the line number for each spell... Needed to sync visual data. Might not be the perfect solution, but maybe this will work. */
        protected Dictionary<ItemType, int> myItemDictionary = new Dictionary<ItemType, int>();

        /* Delegates. */
        public delegate void ItemChoiceChangedListener(ItemType Item, bool isChosen);
        public event ItemChoiceChangedListener ItemSelectionChanged;

        public void setItemList(List<ItemType> items)
        {
            myItemList = items;
            UpdateValues();
        }

        public void setFixedItemList(List<ItemType> itemList)
        {
            myLockedItemList = itemList;
            UpdateValues();
        }


        public void setItemSelection(string item, bool isSelected)
        {
            foreach (ItemHandleControl<ItemType> ctrl in myControlList)
            {
                if (ctrl.Item.ItemName == item)
                {
                    ctrl.isChecked = isSelected;
                    break;
                }
            }
        }

        public List<ItemType> getSelectedItems()
        {
            List<ItemType> selectedItems = new List<ItemType>();

            foreach (ItemHandleControl<ItemType> ctrl in myControlList)
            {
                if (ctrl.isChecked)
                {
                    selectedItems.Add(ctrl.Item);
                }
            }

            return selectedItems;
        }

        public void setSelectionsLocked(Boolean isLock)
        {
            foreach (ItemHandleControl<ItemType> control in myControlList)
            {
                if (!control.isChecked)
                {
                    control.isEnabled = !isLock;
                }
            }
        }

        public bool removeItemFromList(ItemType item)
        {
            bool res;
            ItemType toRemove = myItemList.Find(s => s.ItemName == item.ItemName);

            if (toRemove == null)
            {
                /* Spell does not exist soo nothing to remove? */
                res = false;
            }
            else
            {
                myItemList.Remove(toRemove);
                UpdateValues();
                res = true;
            }

            return res;
        }

        /* TODO : Reimplement the multilevel spell stuff. This has been poorly implemented anyway, so it should be redone. */
        protected void UpdateValues()
        {
            this.Controls.Clear(); /* Remove any existing controls. */
            myControlList = new List<ItemHandleControl<ItemType>>();

            int y = 1;

            List<ItemType> combinedItemList = myItemList.Union(myLockedItemList).ToList(); /* TODO : Use this list. */
            myItemDictionary = new Dictionary<ItemType, int>();

            foreach (ItemType s in combinedItemList)
            {
                myItemDictionary.Add(s, y);
                y++;
            }

            foreach (ItemType s in myItemDictionary.Keys)
            {
                CustomButton iBtn = new CustomButton();
                iBtn.Size = new Size(40, 18);
                iBtn.ButtonText = "Info";
                ItemHandleControl<ItemType> ctrl = new ItemHandleControl<ItemType>(s, iBtn);
                myControlList.Add(ctrl);

                AddButtonOnLine(iBtn, myItemDictionary[s] - 1, 3); /*TODO : Looks like adding controls begins with line index 1, but text uses index 0... <sigh>*/

                if (IsCheckBoxed)
                {
                    CheckBox myCheckBox = new CheckBox();
                    myCheckBox.Size = new Size(16, 16);
                    ctrl.setCheckBox(myCheckBox);

                    if (myLockedItemList.Find(lockedItem => lockedItem.ItemName == s.ItemName) != null)
                    {
                        //Spell is already learned because of racial attributes or otherwise.
                        ctrl.IsLocked = true;
                    }
                    else
                    {
                        //We only add the external listener if this control is going to be modified by the user.
                        ctrl.ItemCheckedChanged += Ctrl_ItemCheckedChanged;
                    }
                    AddControlOnLine(myCheckBox, myItemDictionary[s] - 1, 3 + iBtn.Width);
                }
            }

            this.Invalidate();
        }


        /* TODO : Reimplement the multilevel stuff. This was badly implemented in the first place. */
        protected override void drawData(Graphics gfx, Font font)
        {
            drawTextOnLine(gfx, _titleString, 0, FontStyle.Bold);

            foreach (ItemType sp in myItemDictionary.Keys)
            {
                    drawTextOnLine(gfx, sp.DisplayedName, myItemDictionary[sp]);
            }
            

            if (IsAvailabilityCount)
            {
                int lastLine = getNumberOfLines() - 2;
                drawTextOnLine(gfx, "Available : " + MaximumAvailableChoices.ToString(), lastLine);
            }
        }

        private void Ctrl_ItemCheckedChanged(ItemType spell, bool isChecked)
        {
            if (isChecked)
            {
                MaximumAvailableChoices--;

                if (MaximumAvailableChoices == 0)
                {
                    //We lock the ability to choose more spells...
                    setSelectionsLocked(true);
                }
            }
            else
            {
                MaximumAvailableChoices++;
                if (MaximumAvailableChoices == 1)
                {
                    //We unlock the ability to choose more spells.
                    setSelectionsLocked(false);
                }
            }

            this.Invalidate();

            if (ItemSelectionChanged != null)
            {
                ItemSelectionChanged(spell, isChecked);
            }
        }
    }
}
