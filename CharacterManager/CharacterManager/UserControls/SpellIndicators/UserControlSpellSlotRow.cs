using CharacterManager.UserControls.SpellIndicators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CharacterManager.Spells.CharacterSpellcastingStatus;

namespace CharacterManager.UserControls
{
    public partial class UserControlSpellSlotRow : UserControl
    {
        //private int number_of_slots = 3; /* Set some sane default value */
        private SpellSlotData mySpellSlotData = new SpellSlotData(3, 3);
        private List<UserControlSpellSlotIndicator> mySpellSlotIndicators = new List<UserControlSpellSlotIndicator>();
        private UserControlChargeIndicatorLarge myLargeIndicator;

        public delegate void ActiveSlotsChangedListener(int active_cnt);
        public ActiveSlotsChangedListener ActiveSlotsChanged;

        public SpellSlotData SpellSlots
        {
            get
            {
                return mySpellSlotData;
            }

            set
            {
                mySpellSlotData = value;
                updateNumberOfSlots();
            }
        }

        public int NumberOfSlots
        {
            get { return mySpellSlotData.MaximumCount; }
            
            set
            {
                mySpellSlotData.MaximumCount = value;
                updateNumberOfSlots();
            }
        }

        public int NumberOfRemainingSlots
        {
            get
            {
                return mySpellSlotData.ActiveCount;
            }

            set
            {
                mySpellSlotData.ActiveCount = value;
                UpdateSpellSlotRowData();
            }
        }


        public string LabelName
        {
            get { return label1.Text; }
            set
            {
                label1.Text = value;
            }
        }
        
        
        public UserControlSpellSlotRow()
        {
            InitializeComponent();
        }

        public void UpdateSpellSlotRowData()
        {
            if (myLargeIndicator != null)
            {
                myLargeIndicator.Value = mySpellSlotData.ActiveCount;
            }
            else
            {
                /* Lets check if we actually need to update anything... */
                int currentActive = 0;

                for (int x = 0; x < mySpellSlotData.MaximumCount; x++)
                {
                    try
                    {
                        if (mySpellSlotIndicators[x].IsActive)
                        {
                            currentActive++;
                        }
                    }
                    catch (Exception)
                    {
                        /* Oh dear... */
                    }
                }

                if (currentActive != mySpellSlotData.ActiveCount)
                {
                    for (int x = 0; x < mySpellSlotData.MaximumCount; x++)
                    {
                        try
                        {
                            if (x < (mySpellSlotData.ActiveCount))
                            {
                                mySpellSlotIndicators[x].IsActive = true;
                            }
                            else
                            {
                                mySpellSlotIndicators[x].IsActive = false;
                            }
                        }
                        catch (Exception)
                        {
                            /* Lets hope this does not happen... */
                        }
                    }
                }
            }
        }

        private void HandleUserChangedSpellSlot(bool isChecked)
        {
            if (isChecked)
            {
                mySpellSlotData.ActiveCount++;
            }
            else
            {
                mySpellSlotData.ActiveCount--;
            }

            if (ActiveSlotsChanged != null)
            {
                ActiveSlotsChanged.Invoke(mySpellSlotData.ActiveCount);
            }
        }

        private void updateNumberOfSlots()
        {
            /* First clear any existing indicators. */

            foreach (Control item in groupBox1.Controls.OfType<UserControlSpellSlotIndicator>().ToList())
            {
                groupBox1.Controls.Remove(item);
            }

            int activeCount = mySpellSlotData.ActiveCount;

            /* Next lets set up some indicators. */

            if (mySpellSlotData.MaximumCount > 5)
            {
                mySpellSlotIndicators = null;
                myLargeIndicator = new UserControlChargeIndicatorLarge();
                myLargeIndicator.Maximum = mySpellSlotData.MaximumCount;
                myLargeIndicator.Minimum = 0;
                myLargeIndicator.Value = activeCount;

                myLargeIndicator.Width = 50;
                myLargeIndicator.Height = 20;

                myLargeIndicator.ValueChanged += MyLargeIndicator_ValueChanged;
                myLargeIndicator.Left = label1.Right + 4;
                myLargeIndicator.Top = (this.Height / 2) - (myLargeIndicator.Height / 2);

                groupBox1.Controls.Add(myLargeIndicator);
            }
            else
            {
                mySpellSlotIndicators = new List<UserControlSpellSlotIndicator>();
                myLargeIndicator = null;

                for (int x = 0; x < mySpellSlotData.MaximumCount; x++)
                {
                    UserControlSpellSlotIndicator indicator = new UserControlSpellSlotIndicator();
                    
                    indicator.Left = (x * 20) + label1.Right + 4;
                    indicator.Top = (this.Height / 2) - (indicator.Height / 2);

                    if (activeCount > 0)
                    {
                        indicator.IsActive = true;
                        activeCount--;
                    }
                    else
                    {
                        indicator.IsActive = false;
                    }

                    indicator.SpellSlotCheckedChangedByUser += new UserControlSpellSlotIndicator.SpellSlotCheckedChanged(HandleUserChangedSpellSlot);

                    groupBox1.Controls.Add(indicator);
                    this.mySpellSlotIndicators.Add(indicator);
                }
            }
        }

        private void MyLargeIndicator_ValueChanged(object sender, EventArgs e)
        {
            mySpellSlotData.ActiveCount = myLargeIndicator.Value;

            if (ActiveSlotsChanged != null)
            {
                ActiveSlotsChanged.Invoke(mySpellSlotData.ActiveCount);
            }
        }
    }
}
