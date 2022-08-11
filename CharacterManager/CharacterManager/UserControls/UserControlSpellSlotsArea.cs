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

        public void setSpellSlotData(int level, SpellSlotData data)
        {
            /* TODO : Placeholder. */
            
            switch (level)
            {
                case 1:
                    //userControlSpellSlotRow1.NumberOfSlots = data.MaximumCount;
                    //userControlSpellSlotRow1.NumberOfSlots = data.ActiveCount;
                    userControlSpellSlotRow1.SpellSlots = data;
                    break;
                default:
                    break;
            }
        }
    }
}
