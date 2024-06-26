﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CharacterManager.Items;
using System.Drawing.Drawing2D;

namespace CharacterManager.UserControls
{
    public partial class UserControlGenericListBase<ListItemType> : UserControl where ListItemType : PlayerBaseItem
    {
        public Boolean IsBorder { get; set; }
        protected const int lineInterval = 18;
        protected static int buttonNumber = 0;

        protected int originalHeight;
        protected int maxLine;

        protected Dictionary<int, int> LeftMargin = new Dictionary<int, int>();
        protected Dictionary<int, int> RightMargin = new Dictionary<int, int>();

        protected List<ListItemType> myItemList = new List<ListItemType>();

        protected class InfoButton : CustomButton
        {
            private String infoString;
            private EventHandler showInfo = null;

            public InfoButton(string name, string info)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 8.0f);
                this.Text = "Info";
                this.Size = new Size(40, 17);
                this.infoString = info;
            }

            public InfoButton(string name, EventHandler clickHandler)
            {
                this.Click += new System.EventHandler(button_Click);
                this.Name = name;
                this.Font = new Font("Arial", 8.0f);
                this.Text = "Info";
                this.Size = new Size(40, 17);
                this.showInfo = clickHandler;
            }

            private void button_Click(object sender, EventArgs e)
            {
                if(showInfo != null)
                {
                    showInfo.Invoke(this, e);
                }
                else if (infoString != null)
                {
                
                    MessageBox.Show(infoString);

                    /* Not sure why this is needed, but this makes the button be deselected after it is clicked. */
                    this.Parent.Focus();
                }
            }
        }


        private Bitmap background_bitmap;

        public UserControlGenericListBase()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            originalHeight = this.Height;

            updateBackgroundImage();
        }

        public virtual void SetListData(List<ListItemType> data)
        {
            myItemList = data;

            /* We reset any previous margin data. */
            LeftMargin = new Dictionary<int, int>();
            RightMargin = new Dictionary<int, int>();

            updateBackgroundImage();
        }

        /// <summary>
        /// This is the primary function for adding controls on a linge. The function is automatically designed
        /// to take care of the margins for any given line. This should make sure that the inner text of any line
        /// does not overlap with any controls.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lineNum"></param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="isLeftSide"></param>
        protected void AddControlOnLine(Control c, int lineNum, int xOffset, int yOffset, bool isLeftSide)
        {
            int y = 0;
            y += lineNum * lineInterval;

            int leftLineMargin;
            int rightLineMargin;

            if (LeftMargin.TryGetValue(lineNum, out leftLineMargin) == false)
            {
                leftLineMargin = 0;
            }

            if (RightMargin.TryGetValue(lineNum, out rightLineMargin) == false)
            {
                rightLineMargin = 0;
            }

            if (isLeftSide)
            {
                leftLineMargin += xOffset;
                c.Location = new Point(leftLineMargin, y + 3);
                leftLineMargin += c.Width + 1;
            }
            else
            {
                /* By default we add controls on the right side. */
                rightLineMargin += c.Width + 1;
                rightLineMargin += xOffset;
                c.Location = new Point(this.Width - rightLineMargin, y + yOffset);
            }

            LeftMargin[lineNum] = leftLineMargin;
            RightMargin[lineNum] = rightLineMargin;

            this.Controls.Add(c);
        }

        /// <summary>
        /// This overload only takes the xOffset. Default y offset is set to 3. 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="lineNum"></param>
        /// <param name="xOffset"></param>
        /// <param name="isLeftSide"></param>
        protected void AddControlOnLine(Control c, int lineNum, int xOffset, bool isLeftSide)
        {
            AddControlOnLine(c, lineNum, xOffset, 3, isLeftSide);
        }

        protected void AddSpellSlotOnLine(UserControlSpellSlotIndicator slot, int lineNum, int xOffset)
        {
            AddControlOnLine(slot, lineNum, xOffset, 4 ,false);
        }


        protected void AddButtonOnLine(CustomButton btn, int lineNum, int xOffset)
        {
            AddControlOnLine(btn, lineNum, xOffset, false);
        }

        protected int getNumberOfVisibleLines()
        {
            return this.Height / (lineInterval);
        }

        protected virtual void drawDisplayedData(Graphics gfx, Font font)
        {
            int y = 1;

            foreach (ListItemType i in myItemList)
            {
                drawDisplayedDataSingleItem(gfx, font, y, i);
                y++;
            }
        }

        protected virtual void drawDisplayedDataSingleItem(Graphics gfx, Font font, int line, ListItemType item)
        {
            int leftLineMargin;
            int rightLineMargin;

            if (LeftMargin.TryGetValue(line, out leftLineMargin) == false)
            {
                leftLineMargin = 0;
            }

            if (RightMargin.TryGetValue(line, out rightLineMargin) == false)
            {
                rightLineMargin = 0;
            }

            drawTextOnLine(gfx, item.getDisplayedName(), leftLineMargin + 1, line, FontStyle.Regular, this.Width - (rightLineMargin + 1));
        }

        /****************************************************************/
        /* Graphical Functions */
        /****************************************************************/
        protected override void OnPaint(PaintEventArgs pea)
        {
            base.OnPaint(pea);

            //pea.Graphics.TranslateTransform(this.AutoScrollPosition.X,
            //                    this.AutoScrollPosition.Y);

            //Lets use the panel for drawing.
            Graphics gfx = pea.Graphics;

            /* Beginning test. */
            gfx.DrawImage(background_bitmap, 0, 0);
        }

       
        protected void drawRectangleOnLine(Graphics gfx, int lineNum, Color rectColor)
        {
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + 3);
            Rectangle rect = new Rectangle(sPoint, new Size(this.Width - 1, lineInterval));
            gfx.FillRectangle(new SolidBrush(rectColor), rect);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum)
        {
            Font f = new Font("Arial", 12, FontStyle.Regular);
            drawTextOnLine(gfx, text, lineNum, f);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum, FontStyle style)
        {
            Font f = new Font("Arial", 12, style);
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + 3);
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }


        protected void drawTextOnLine(Graphics gfx, String text, int xOffset, int lineNum, FontStyle style, int MaxStringWidth)
        {
            float FontSize = 12;

            Font f;
            /* Lets try to dynamically reduce the size of the font if it is too large for the area.*/
            SizeF textSize;

            do
            {
                f = new Font("Arial", FontSize, style);
                /* Lets try to dynamically reduce the size of the font if it is too large for the area.*/
                textSize = gfx.MeasureString(text, f);
                FontSize-= 0.25f;
            } while (textSize.Width > MaxStringWidth && FontSize > 2);

            Point sPoint = new Point(1 + xOffset, (lineInterval * (lineNum)) + 3);
            gfx.DrawString(text, f, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }

        protected void drawTextOnLine(Graphics gfx, String text, int lineNum, Font font)
        {
            int margin;
            if (font.Height > (lineInterval - 3))
            {
                margin = 1;
            }
            else
            {
                margin = 3;
            }
            
            Point sPoint = new Point(1, (lineInterval * (lineNum)) + margin);
            gfx.DrawString(text, font, new SolidBrush(Color.Black), sPoint);

            maxLine = Math.Max(maxLine, lineNum + 2);
        }

        private void drawBackGround(Graphics gfx)
        {
            //Lets try doing this in quite a simplistic way. Draw circles at the corners first.
            int diameter = 10;
            Brush b = new SolidBrush(Color.White);

            Rectangle rect = new Rectangle(1, 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(1, this.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(this.Size.Width - (2 + diameter), 1, diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            rect = new Rectangle(this.Size.Width - (2 + diameter), this.Size.Height - (2 + diameter), diameter, diameter);
            gfx.FillEllipse(b, rect);
            if (IsBorder)
            {
                gfx.DrawEllipse(new Pen(Color.Black), rect);
            }

            //Draw white rectangles to fill..
            rect = new Rectangle(1 + (diameter / 2), 1, this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Right, rect.Top));
            }

            rect = new Rectangle(1, 1 + (diameter / 2), diameter, this.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Top), new Point(rect.Left, rect.Bottom));
            }

            rect = new Rectangle(1 + (diameter / 2), this.Size.Height - (diameter + 2), this.Size.Width - (diameter + 2), diameter);
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Left, rect.Bottom), new Point(rect.Right, rect.Bottom));
            }

            rect = new Rectangle(this.Size.Width - (1 + diameter), 1 + (diameter / 2), diameter, this.Size.Height - (diameter + 2));
            gfx.FillRectangle(b, rect);
            if (IsBorder)
            {
                gfx.DrawLine(new Pen(Color.Black), new Point(rect.Right, rect.Bottom), new Point(rect.Right, rect.Top));
            }

            //Draw internal rectangle.
            rect = new Rectangle(1 + (diameter / 2), 1 + (diameter / 2), this.Size.Width - (3 + diameter), this.Size.Height - (3 + diameter));
            gfx.FillRectangle(b, rect);
        }

        private void drawLines(Graphics gfx) 
        {
            Pen myPen = new Pen(Color.LightGray);
            for (int x = lineInterval + 2; x < this.Size.Height; x += lineInterval)
            {
                gfx.DrawLine(myPen, new Point(2, x), new Point(this.Width - 2, x));
            }
        }

        private void UserControlGenericListBase_SizeChanged(object sender, EventArgs e)
        {
            updateBackgroundImage();
            this.Invalidate();
        }

        protected void updateBackgroundImage()
        {
#if true
            background_bitmap = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(background_bitmap);
            drawBackGround(g);

            maxLine = 0;
            //So lets draw the lines next.

            drawLines(g);

            Font myFont = new Font("Arial", 14);
            drawDisplayedData(g, myFont);

            /* A crude automatic resizing mechanism... */
            if (getNumberOfVisibleLines() < maxLine) 
            {
                this.Height = ((maxLine + 1) * lineInterval) + 4;
            }

#else
            /* Test with a gradient bitmap */
            background_bitmap = new Bitmap(Width, Height);
            Graphics g = Graphics.FromImage(background_bitmap);
            LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(Width, Height), Color.Black, Color.Red);
            g.FillRectangle(lgb, 0, 0, Width, Height);
            /* End of test. */
#endif
        }
    }
}
