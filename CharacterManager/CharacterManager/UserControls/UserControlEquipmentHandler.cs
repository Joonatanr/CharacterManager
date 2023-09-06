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
        /* TODO : Obviously we need to set up proper polymorphism to get this working in a good way. But let it be for now. */
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
                DropButton.ButtonText = "Drop";
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
        
            
        private List<PlayerItem> GeneralEquipmentList = new List<PlayerItem>();
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
            GeneralEquipmentList = eList;
            setupButtons();
            this.DoubleBuffered = true;
            this.Invalidate();
        }

        public void setupButtons()
        {
            int y = lineInterval;

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

            foreach (PlayerItem item in GeneralEquipmentList)
            {
                GeneralEquipmentControlData myData = new GeneralEquipmentControlData(item);
                
                /* 1. Set up the info button. */
                myData.infoBtn.Location = new Point(this.Right - (myData.infoBtn.Width + 2), y + 3);
                this.Controls.Add(myData.infoBtn);

                /* 2. Set up the Drop button. */
                myData.DropButton.Location = new Point(0, y + 3);
                myData.ItemDropClicked += HandleDrop;
                this.Controls.Add(myData.DropButton);

                /* Finish up.. */
                y += lineInterval;
                mainList.Add(myData);
            }
        }

        private void HandleDrop(PlayerItem i)
        {
            ItemDropEvent?.Invoke(i);
        }

        protected override void drawData(Graphics gfx, Font font)
        {
            int y = 0;

            //Lets draw a descriptive text.
            drawTextOnLine(gfx, "Inventory:", y, FontStyle.Bold);
            y++;

            foreach (PlayerItem i in GeneralEquipmentList)
            {
                drawTextOnLine(gfx, i.getDisplayedName(), 40, y,FontStyle.Regular, this.Width - 80);
                y++;
            }
        }
    }
}
