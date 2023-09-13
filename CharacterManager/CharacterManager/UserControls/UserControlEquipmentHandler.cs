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
    public class UserControlEquipmentHandler : UserControlGenericListBase<PlayerItem>
    {
        private class GeneralEquipmentControlData
        {
            public PlayerItem item;
            public InfoButton infoBtn;
            public CustomButton DropButton;

            
            public ItemButtonClickedHandler ItemDropClicked;

            public GeneralEquipmentControlData(PlayerItem item)
            {
                this.item = item;

                infoBtn = new InfoButton("Button " + buttonNumber++, item.getExtendedDescription());

                DropButton = new CustomButton();
                DropButton.Size = new Size(40, 16);
                DropButton.Text = "Drop";
                DropButton.Font = new Font("Arial", 8.0f);
                DropButton.Click += DropButton_Click;
            }

            private void DropButton_Click(object sender, EventArgs e)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to drop " + item.DisplayedName, "Drop item", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    ItemDropClicked?.Invoke(item);
                }
                else if (dialogResult == DialogResult.No)
                {
                    /* Do nothing */
                }
            }
        }
        
        private List<GeneralEquipmentControlData> mainList = new List<GeneralEquipmentControlData>();

        public delegate void ItemButtonClickedHandler(PlayerItem i);
        public ItemButtonClickedHandler ItemDropEvent;

        //private List<InfoButton> buttonList;

        public UserControlEquipmentHandler() : base()
        {
            /* Constructor. */
        }

        public void setGeneralEquipmentList(List<PlayerItem> eList)
        {
            SetListData(eList);
            setupButtons();
            this.DoubleBuffered = true;
            this.Invalidate();
        }

        public void setupButtons()
        {
            int y = 1;

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

            foreach (PlayerItem item in myItemList)
            {
                GeneralEquipmentControlData myData = new GeneralEquipmentControlData(item);

                /* 1. Set up the info button. */
                AddControlOnLine(myData.infoBtn, y, 0, false);

                /* 2. Set up the Drop button. */
                myData.ItemDropClicked += HandleDrop;
                AddControlOnLine(myData.DropButton, y, 0, true);

                /* Finish up.. */
                y++;
                mainList.Add(myData);
            }
        }

        private void HandleDrop(PlayerItem i)
        {
            ItemDropEvent?.Invoke(i);
        }

        protected override void drawDisplayedData(Graphics gfx, Font font)
        {
            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Inventory:", 0, FontStyle.Bold);
            base.drawDisplayedData(gfx, font);
        }
    }
}
