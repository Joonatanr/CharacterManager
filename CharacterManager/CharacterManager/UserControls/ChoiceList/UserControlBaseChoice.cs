﻿using CharacterManager.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager.UserControls
{
    public abstract class UserControlBaseChoice <ItemType> : UserControlGenericListBase<ItemType> where ItemType : PlayerBaseItem
    {
        /* Properties */
        private String _titleString = "Items:";
        public String TitleString
        {
            get { return _titleString; }
            set { _titleString = value; this.updateBackgroundImage(); this.Invalidate(); }
        }

        public bool IsAvailabilityCount { get; set; } = true;

        public bool IsCheckBoxed { get; set; } = false;

        private int _maximumAvailableChoices = 0;
        public int MaximumAvailableChoices
        {
            get { return _maximumAvailableChoices;  }
            set 
            { 
                _maximumAvailableChoices = value;
                _remainingAvailableChoices = value;
                this.Invalidate();

                if (value == 0)
                {
                    setSelectionsLocked(true);
                }
                else
                {
                    setSelectionsLocked(false);
                }
            }
        }

        protected List<ItemHandleControl<ItemType>> myControlList = new List<ItemHandleControl<ItemType>>();
        protected List<ItemType> myLockedItemList = new List<ItemType>(); /* These are spells that are already chosen because they come from racial abilities etc... */
        protected int number_of_fixed_replacements = 0;
        protected int number_of_remaining_fixed_replacements = 0;

        public object[] ItemDescriptionArgs = null;

        public int RemainingAvailableChoices
        {
            get { return _remainingAvailableChoices; }
        }

        private int _remainingAvailableChoices = 0;

        protected class StringContainer
        {
            public string str;
            public Font font = new Font("Arial", 12, FontStyle.Regular);

            public StringContainer()
            {
                str = "";
            }

            public StringContainer(string str)
            {
                this.str = str;
            }

            public StringContainer(string str, Font font)
            {
                this.str = str;
                this.font = font;
            }
        }


        /* This dictionary should contain the line number for each spell... Needed to sync visual data. Might not be the perfect solution, but maybe this will work. */
        protected Dictionary<int, ItemType> myItemDictionary = new Dictionary<int, ItemType>();
        protected Dictionary<int, StringContainer> myTextDictionary = new Dictionary<int, StringContainer>();

        /* Delegates. */
        public delegate void ItemChoiceChangedListener(ItemType Item, bool isChosen);
        public event ItemChoiceChangedListener ItemSelectionChanged;

        public void setItemList(List<ItemType> items)
        {
            myItemList = items;
            UpdateValues();
        }

        public void setFixedItemList(List<ItemType> itemList, int number_of_replacements)
        {
            myLockedItemList = itemList;
            number_of_fixed_replacements = number_of_replacements;
            number_of_remaining_fixed_replacements = number_of_replacements;
            UpdateValues();
        }


        public void setItemSelection(string item, bool isSelected, bool isLocked)
        {
            foreach (ItemHandleControl<ItemType> ctrl in myControlList)
            {
                if (ctrl.Item.Name == item)
                {
                    ctrl.isChecked = isSelected;
                    ctrl.isEnabled = !isLocked;
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

        private void setFixedSelectionsLocked(Boolean isLock)
        {
            foreach (ItemHandleControl<ItemType> control in myControlList)
            {
                if(myLockedItemList.Contains(control.Item) && control.isChecked)
                {
                    control.isEnabled = !isLock;
                }
            }
        }

        public bool removeItemFromList(ItemType item)
        {
            bool res;
            ItemType toRemove = myItemList.Find(s => s.Name == item.Name);

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

        protected virtual string getInfoButtonLabel()
        {
            return "Info";
        }

        protected void UpdateValues()
        {
            this.SuspendLayout();
            this.Controls.Clear(); /* Remove any existing controls. */
            myControlList = new List<ItemHandleControl<ItemType>>();
            LeftMargin = new Dictionary<int, int>();
            RightMargin = new Dictionary<int, int>();

            List<ItemType> combinedItemList = myItemList.Union(myLockedItemList).ToList();
            setItemPositions(combinedItemList, out myItemDictionary, out myTextDictionary);

            foreach (int index in myItemDictionary.Keys)
            {
                CustomButton iBtn = new CustomButton();
                iBtn.Size = new Size(40, 18);
                iBtn.Text = getInfoButtonLabel();
                iBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                ItemHandleControl<ItemType> ctrl = new ItemHandleControl<ItemType>(myItemDictionary[index], iBtn);
                ctrl.ItemDescriptionArgs = this.ItemDescriptionArgs;
                myControlList.Add(ctrl);

                AddButtonOnLine(iBtn, index, 3);

                if (IsCheckBoxed)
                {
                    CheckBox myCheckBox = new CheckBox();
                    myCheckBox.Size = new Size(16, 16);
                    myCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;

                    ctrl.setCheckBox(myCheckBox);

                    if (myLockedItemList.Find(lockedItem => lockedItem.Name == myItemDictionary[index].Name) != null)
                    {
                        /* Item such as a spell has already been learned. */
                        /* Now things become more complex, because we might be able to replace some of these... */
                        if (number_of_fixed_replacements == 0)
                        {
                            ctrl.IsLocked = true;
                        }
                        else
                        {
                            ctrl.ItemCheckedChanged += Ctrl_ItemCheckedChangedFromFixedlist;
                            ctrl.isChecked = true;
                        }
                    }
                    else
                    {
                        //We only add the external listener if this control is going to be modified by the user.
                        ctrl.ItemCheckedChanged += Ctrl_ItemCheckedChanged;
                    }
                    AddControlOnLine(myCheckBox, index, 3, false);
                }
            }

            if (_maximumAvailableChoices == 0 && IsCheckBoxed)
            {
                setSelectionsLocked(true);
            }

            this.ResumeLayout();

            this.updateBackgroundImage();
            this.Invalidate();
        }


        protected virtual void setItemPositions(List<ItemType> items, out Dictionary<int, ItemType> itemDictionary, out Dictionary<int, StringContainer> textDictionary)
        {
            Dictionary<int, ItemType> itemLocations = new Dictionary<int, ItemType>();
            Dictionary<int, StringContainer> textLocations = new Dictionary<int, StringContainer>();

            int y = 1;

            foreach (ItemType s in items)
            {
                itemLocations.Add(y, s);
                StringContainer nameStr = new StringContainer(s.DisplayedName);
                textLocations.Add(y, nameStr);
                y++;
            }

            itemDictionary = itemLocations;
            textDictionary = textLocations;
        }


        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            drawTextOnLine(gfx, _titleString, 0, FontStyle.Bold);

            foreach (int index in myTextDictionary.Keys)
            {
                drawTextOnLine(gfx, myTextDictionary[index].str, index, myTextDictionary[index].font);
            }

            int lastLine = getNumberOfVisibleLines() - 2;
            if (IsAvailabilityCount)
            {
                string finalString = "Available : " + _remainingAvailableChoices.ToString();
                if (number_of_fixed_replacements > 0)
                {
                    finalString += "(Can Replace " + number_of_remaining_fixed_replacements + ")";
                }
                
                drawTextOnLine(gfx, finalString, lastLine);
            }
        }

        private void Ctrl_ItemCheckedChanged(ItemType item, bool isChecked)
        {
            if (isChecked)
            {
                _remainingAvailableChoices--;

                if (_remainingAvailableChoices == 0)
                {
                    //We lock the ability to choose more spells...
                    setSelectionsLocked(true);
                }
            }
            else
            {
                _remainingAvailableChoices++;
                if (_remainingAvailableChoices == 1)
                {
                    //We unlock the ability to choose more spells.
                    setSelectionsLocked(false);
                }
            }

            this.Invalidate();

            if (ItemSelectionChanged != null)
            {
                ItemSelectionChanged(item, isChecked);
            }
        }

        private void Ctrl_ItemCheckedChangedFromFixedlist(ItemType item, bool isChecked)
        {
            if (isChecked)
            {
                /* This is a little problematic. This means that the spell has been chosen to be replaced, but now we are selecting
                 it again. We don't really have a way of determining which spell has been chosen instead of the replaced spell. 
                Therefore we will have to reset the current choices. */

                _remainingAvailableChoices--;

                if (_remainingAvailableChoices == 0)
                {
                    //We lock the ability to choose more spells...
                    setSelectionsLocked(true);
                }

                if(number_of_fixed_replacements > 0)
                {
                    if (number_of_remaining_fixed_replacements < number_of_fixed_replacements)
                    {
                        number_of_remaining_fixed_replacements++;
                        setFixedSelectionsLocked(false);
                    }
                }
            }
            else
            {
                if (number_of_remaining_fixed_replacements > 0)
                {
                    _remainingAvailableChoices++;
                    if (_remainingAvailableChoices == 1)
                    {
                        //We unlock the ability to choose more spells.
                        setSelectionsLocked(false);
                    }
                }

                number_of_remaining_fixed_replacements--;

                if (number_of_remaining_fixed_replacements == 0)
                {
                    /* No more spells can be replaced... */
                    setFixedSelectionsLocked(true);
                }
            }

            this.Invalidate();

            if (ItemSelectionChanged != null)
            {
                ItemSelectionChanged(item, isChecked);
            }
        }
    }
}
