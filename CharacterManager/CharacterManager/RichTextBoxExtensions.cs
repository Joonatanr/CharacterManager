﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterManager
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        /// <summary>
        /// Append formatted text to a Rich Text Box control 
        /// </summary>
        /// <param name="rtb">Rich Text Box to which horizontal bar is to be added</param>
        /// <param name="text">Text to be appended to Rich Text Box</param>
        /// <param name="textColour">Colour of text to be appended</param>
        /// <param name="isBold">Flag indicating whether appended text is bold</param>
        /// <param name="alignment">Horizontal alignment of appended text</param>
        public static void AppendFormattedText(RichTextBox rtb, string text, Color textColour, Boolean isBold, HorizontalAlignment alignment)
        {
            int start = rtb.TextLength;
            rtb.AppendText(text);
            int end = rtb.TextLength; // now longer by length of appended text

            // Select text that was appended
            rtb.Select(start, end - start);

            #region Apply Formatting
            rtb.SelectionColor = textColour;
            rtb.SelectionAlignment = alignment;
            rtb.SelectionFont = new Font(
                 rtb.SelectionFont.FontFamily,
                 rtb.SelectionFont.Size,
                 (isBold ? FontStyle.Bold : FontStyle.Regular));
            #endregion

            // Unselect text
            rtb.SelectionLength = 0;
        }
    }
}
