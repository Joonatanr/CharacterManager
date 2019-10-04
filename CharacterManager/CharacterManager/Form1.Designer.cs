namespace CharacterManager
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.AttributeDisplaySTR = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayINT = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayDEX = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayCON = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayWIS = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayCHA = new CharacterManager.UserControlAttributeDisplay();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "NEW";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "LOAD";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 342);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 96);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(212, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(122, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Character Name";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(13, 72);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AttributeDisplaySTR
            // 
            this.AttributeDisplaySTR.AttributeName = "STR";
            this.AttributeDisplaySTR.AttributeValue = 0;
            this.AttributeDisplaySTR.Location = new System.Drawing.Point(112, 47);
            this.AttributeDisplaySTR.Name = "AttributeDisplaySTR";
            this.AttributeDisplaySTR.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplaySTR.TabIndex = 8;
            // 
            // AttributeDisplayINT
            // 
            this.AttributeDisplayINT.AttributeName = "INT";
            this.AttributeDisplayINT.AttributeValue = 0;
            this.AttributeDisplayINT.Location = new System.Drawing.Point(112, 81);
            this.AttributeDisplayINT.Name = "AttributeDisplayINT";
            this.AttributeDisplayINT.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplayINT.TabIndex = 9;
            // 
            // AttributeDisplayDEX
            // 
            this.AttributeDisplayDEX.AttributeName = "DEX";
            this.AttributeDisplayDEX.AttributeValue = 0;
            this.AttributeDisplayDEX.Location = new System.Drawing.Point(112, 115);
            this.AttributeDisplayDEX.Name = "AttributeDisplayDEX";
            this.AttributeDisplayDEX.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplayDEX.TabIndex = 10;
            // 
            // AttributeDisplayCON
            // 
            this.AttributeDisplayCON.AttributeName = "CON";
            this.AttributeDisplayCON.AttributeValue = 0;
            this.AttributeDisplayCON.Location = new System.Drawing.Point(112, 149);
            this.AttributeDisplayCON.Name = "AttributeDisplayCON";
            this.AttributeDisplayCON.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplayCON.TabIndex = 11;
            // 
            // AttributeDisplayWIS
            // 
            this.AttributeDisplayWIS.AttributeName = "WIS";
            this.AttributeDisplayWIS.AttributeValue = 0;
            this.AttributeDisplayWIS.Location = new System.Drawing.Point(112, 183);
            this.AttributeDisplayWIS.Name = "AttributeDisplayWIS";
            this.AttributeDisplayWIS.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplayWIS.TabIndex = 12;
            // 
            // AttributeDisplayCHA
            // 
            this.AttributeDisplayCHA.AttributeName = "CHA";
            this.AttributeDisplayCHA.AttributeValue = 0;
            this.AttributeDisplayCHA.Location = new System.Drawing.Point(112, 217);
            this.AttributeDisplayCHA.Name = "AttributeDisplayCHA";
            this.AttributeDisplayCHA.Size = new System.Drawing.Size(168, 34);
            this.AttributeDisplayCHA.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AttributeDisplayCHA);
            this.Controls.Add(this.AttributeDisplayWIS);
            this.Controls.Add(this.AttributeDisplayCON);
            this.Controls.Add(this.AttributeDisplayDEX);
            this.Controls.Add(this.AttributeDisplayINT);
            this.Controls.Add(this.AttributeDisplaySTR);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private UserControlAttributeDisplay AttributeDisplaySTR;
        private UserControlAttributeDisplay AttributeDisplayINT;
        private UserControlAttributeDisplay AttributeDisplayDEX;
        private UserControlAttributeDisplay AttributeDisplayCON;
        private UserControlAttributeDisplay AttributeDisplayWIS;
        private UserControlAttributeDisplay AttributeDisplayCHA;
    }
}

