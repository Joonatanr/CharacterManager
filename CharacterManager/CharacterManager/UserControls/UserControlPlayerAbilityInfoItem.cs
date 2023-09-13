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
    public class UserControlPlayerAbilityInfoItem : UserControlGenericListBase<PlayerAbilityInfoItem>
    {
        private PlayerAbility _connectedAbility = null;
        private List<ControlData> mainList = new List<ControlData>();
        private string _labelText = "Info:";

        public delegate void PlayerAbilityInfoItemUsedListener(PlayerAbilityInfoItem item);
        
        public void SetAbility(PlayerAbility ability)
        {
            _connectedAbility = ability;
            _labelText = _connectedAbility.GetInfoItemsLabel();
            SetListData(ability.GetInfoItems());
        }
        
        public override void SetListData(List<PlayerAbilityInfoItem> data)
        {
            base.SetListData(data);
            setupButtons();
            this.Invalidate();
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, _labelText, 0, FontStyle.Bold);
            base.drawDisplayedData(gfx, font);
        }

        private void setupButtons()
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
            mainList = new List<ControlData>();

            foreach (PlayerAbilityInfoItem item in myItemList)
            {
                if (item.IsUsable)
                {
                    ControlData myControData = new ControlData(item);
                    myControData.PlayerAbilityInfoItemUsed = handlePlayerAbilityInfoItemUsed;
                    AddControlOnLine(myControData.UseButton, y, 0, false);
                    mainList.Add(myControData);
                }
                y++;
            }
        }

        private void handlePlayerAbilityInfoItemUsed(PlayerAbilityInfoItem item)
        {
            if (_connectedAbility != null)
            {
                _connectedAbility.UseAbilityInfoItem(item);
                /* It is likely that using an item could remove it from the list. So lets update. */
                SetAbility(_connectedAbility);
            }
        }

        private class ControlData
        {
            private PlayerAbilityInfoItem myItem = null;

            public CustomButton UseButton;
            public PlayerAbilityInfoItemUsedListener PlayerAbilityInfoItemUsed;

            public ControlData(PlayerAbilityInfoItem item)
            {
                myItem = item;
                UseButton = new CustomButton();
                UseButton.Text = "Use";
                UseButton.Height = lineInterval;
                UseButton.Width = 40;
                UseButton.Click += UseButton_Click1;
            }

            private void UseButton_Click1(object sender, EventArgs e)
            {
                PlayerAbilityInfoItemUsed?.Invoke(myItem);
            }
        }
    }
}
