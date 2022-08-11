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
        }

        private void updateNumberOfSlots()
        {
            /* First clear any existing indicators. */
            foreach(Control ctrl in this.Controls)
            {
                if (ctrl is UserControlSpellSlotIndicator)
                {
                    this.Controls.Remove(ctrl);
                }
            }

            int activeCount = mySpellSlotData.ActiveCount;

            /* Next lets set up some indicators. */
            for (int x = 0; x < mySpellSlotData.MaximumCount; x++)
            {
                UserControlSpellSlotIndicator indicator = new UserControlSpellSlotIndicator();
                indicator.Left = (x * 20) + label1.Right + 4;
                
                indicator.Top = (this.Height / 2) - (indicator.Height / 2);

                if(activeCount > 0)
                {
                    indicator.IsActive = true;
                    activeCount--;
                }
                else
                {
                    indicator.IsActive = false;
                }

                indicator.SpellSlotCheckedChangedByUser += new UserControlSpellSlotIndicator.SpellSlotCheckedChanged(HandleUserChangedSpellSlot);

                this.Controls.Add(indicator);
            }
        }
    }
}
