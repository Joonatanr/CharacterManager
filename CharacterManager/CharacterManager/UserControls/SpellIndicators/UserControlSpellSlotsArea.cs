using CharacterManager.Spells;
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
    public partial class UserControlSpellSlotsArea : UserControl
    {
        public UserControlSpellSlotsArea()
        {
            InitializeComponent();
        }

        public void updateSpellSlotDisplay()
        {
            /* TODO : Placeholder. */
            userControlSpellSlotRow1.UpdateSpellSlotRowData();
        }

        public void setSpellSlotData(int level, SpellSlotData data)
        {
            switch (level)
            {
                case 1:
                    userControlSpellSlotRow1.SpellSlots = data;
                    break;
                case 2:
                    userControlSpellSlotRow2.SpellSlots = data;
                    break;
                case 3:
                    userControlSpellSlotRow3.SpellSlots = data;
                    break;
                case 4:
                    userControlSpellSlotRow4.SpellSlots = data;
                    break;
                case 5:
                    userControlSpellSlotRow5.SpellSlots = data;
                    break;
                case 6:
                    userControlSpellSlotRow6.SpellSlots = data;
                    break;
                case 7:
                    userControlSpellSlotRow7.SpellSlots = data;
                    break;
                case 8:
                    userControlSpellSlotRow8.SpellSlots = data;
                    break;
                case 9:
                    userControlSpellSlotRow9.SpellSlots = data;
                    break;
                default:
                    break;
            }
        }

        /* TODO : Should create proper connections, such as listeners etc... Should switch over to using this function entirely. */
        public void setSpellSlotData(CharacterSpellcastingStatus stat)
        {
            userControlSpellSlotRow1.SpellSlots = stat.Level1SpellSlots;
            userControlSpellSlotRow2.SpellSlots = stat.Level2SpellSlots;
            userControlSpellSlotRow3.SpellSlots = stat.Level3SpellSlots;
            userControlSpellSlotRow4.SpellSlots = stat.Level4SpellSlots;
            userControlSpellSlotRow5.SpellSlots = stat.Level5SpellSlots;
            userControlSpellSlotRow6.SpellSlots = stat.Level6SpellSlots;
            userControlSpellSlotRow7.SpellSlots = stat.Level7SpellSlots;
            userControlSpellSlotRow8.SpellSlots = stat.Level8SpellSlots;
            userControlSpellSlotRow9.SpellSlots = stat.Level9SpellSlots;

            userControlSpellSlotRow1.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow2.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow3.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow4.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow5.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow6.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow7.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow8.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
            userControlSpellSlotRow9.ActiveSlotsChanged += new UserControlSpellSlotRow.ActiveSlotsChangedListener(activeSpellSlotsChanged);
        }


        /* TODO : Implement this. */
        private void activeSpellSlotsChanged(int active_cnt)
        {
            /* TODO : Placeholder. */
        }
    }
}
