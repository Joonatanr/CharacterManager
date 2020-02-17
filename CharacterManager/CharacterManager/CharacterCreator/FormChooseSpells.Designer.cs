namespace CharacterManager.CharacterCreator
{
    partial class FormChooseSpells
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNumberOfCantripsToChoose = new System.Windows.Forms.Label();
            this.userControlSpellChoice1 = new CharacterManager.UserControls.UserControlSpellChoice();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(495, 504);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(576, 504);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cantrips:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Level1 Spells";
            // 
            // labelNumberOfCantripsToChoose
            // 
            this.labelNumberOfCantripsToChoose.AutoSize = true;
            this.labelNumberOfCantripsToChoose.Location = new System.Drawing.Point(73, 9);
            this.labelNumberOfCantripsToChoose.Name = "labelNumberOfCantripsToChoose";
            this.labelNumberOfCantripsToChoose.Size = new System.Drawing.Size(13, 13);
            this.labelNumberOfCantripsToChoose.TabIndex = 7;
            this.labelNumberOfCantripsToChoose.Text = "0";
            // 
            // userControlSpellChoice1
            // 
            this.userControlSpellChoice1.IsBorder = false;
            this.userControlSpellChoice1.Location = new System.Drawing.Point(12, 25);
            this.userControlSpellChoice1.Name = "userControlSpellChoice1";
            this.userControlSpellChoice1.Size = new System.Drawing.Size(262, 228);
            this.userControlSpellChoice1.TabIndex = 8;
            // 
            // FormChooseSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 539);
            this.Controls.Add(this.userControlSpellChoice1);
            this.Controls.Add(this.labelNumberOfCantripsToChoose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormChooseSpells";
            this.Text = "FormChooseSpells";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNumberOfCantripsToChoose;
        private UserControls.UserControlSpellChoice userControlSpellChoice1;
    }
}