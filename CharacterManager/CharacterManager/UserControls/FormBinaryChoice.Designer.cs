
namespace CharacterManager.UserControls
{
    partial class FormBinaryChoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonMakeChoice = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.radioButtonChoiceOne = new System.Windows.Forms.RadioButton();
            this.radioButtonChoiceTwo = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // buttonMakeChoice
            // 
            this.buttonMakeChoice.Location = new System.Drawing.Point(12, 12);
            this.buttonMakeChoice.Name = "buttonMakeChoice";
            this.buttonMakeChoice.Size = new System.Drawing.Size(75, 76);
            this.buttonMakeChoice.TabIndex = 0;
            this.buttonMakeChoice.Text = "Choose";
            this.buttonMakeChoice.UseVisualStyleBackColor = true;
            this.buttonMakeChoice.Click += new System.EventHandler(this.buttonMakeChoice_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(298, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(171, 99);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // radioButtonChoiceOne
            // 
            this.radioButtonChoiceOne.AutoSize = true;
            this.radioButtonChoiceOne.Location = new System.Drawing.Point(93, 23);
            this.radioButtonChoiceOne.Name = "radioButtonChoiceOne";
            this.radioButtonChoiceOne.Size = new System.Drawing.Size(67, 17);
            this.radioButtonChoiceOne.TabIndex = 2;
            this.radioButtonChoiceOne.TabStop = true;
            this.radioButtonChoiceOne.Text = "Choice 1";
            this.radioButtonChoiceOne.UseVisualStyleBackColor = true;
            // 
            // radioButtonChoiceTwo
            // 
            this.radioButtonChoiceTwo.AutoSize = true;
            this.radioButtonChoiceTwo.Location = new System.Drawing.Point(93, 57);
            this.radioButtonChoiceTwo.Name = "radioButtonChoiceTwo";
            this.radioButtonChoiceTwo.Size = new System.Drawing.Size(67, 17);
            this.radioButtonChoiceTwo.TabIndex = 3;
            this.radioButtonChoiceTwo.TabStop = true;
            this.radioButtonChoiceTwo.Text = "Choice 2";
            this.radioButtonChoiceTwo.UseVisualStyleBackColor = true;
            // 
            // FormBinaryChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 123);
            this.Controls.Add(this.radioButtonChoiceTwo);
            this.Controls.Add(this.radioButtonChoiceOne);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonMakeChoice);
            this.Name = "FormBinaryChoice";
            this.Text = "FormBinaryChoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMakeChoice;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton radioButtonChoiceOne;
        private System.Windows.Forms.RadioButton radioButtonChoiceTwo;
    }
}