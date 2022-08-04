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
            this.userControlChosenSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.userControlSpellChoice2 = new CharacterManager.UserControls.UserControlSpellChoice();
            this.userControlSpellChoice1 = new CharacterManager.UserControls.UserControlSpellChoice();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(670, 633);
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
            this.buttonCancel.Location = new System.Drawing.Point(751, 633);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // userControlChosenSpells
            // 
            this.userControlChosenSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlChosenSpells.AutoSize = true;
            this.userControlChosenSpells.IsBorder = true;
            this.userControlChosenSpells.IsCheckBoxed = false;
            this.userControlChosenSpells.IsMultipleLevel = false;
            this.userControlChosenSpells.Location = new System.Drawing.Point(392, 25);
            this.userControlChosenSpells.MinimumSize = new System.Drawing.Size(429, 585);
            this.userControlChosenSpells.Name = "userControlChosenSpells";
            this.userControlChosenSpells.Size = new System.Drawing.Size(430, 585);
            this.userControlChosenSpells.TabIndex = 12;
            this.userControlChosenSpells.TitleString = "Chosen Spells:";
            // 
            // userControlSpellChoice2
            // 
            this.userControlSpellChoice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlSpellChoice2.AutoSize = true;
            this.userControlSpellChoice2.IsBorder = true;
            this.userControlSpellChoice2.IsCheckBoxed = true;
            this.userControlSpellChoice2.IsMultipleLevel = false;
            this.userControlSpellChoice2.Location = new System.Drawing.Point(12, 321);
            this.userControlSpellChoice2.MinimumSize = new System.Drawing.Size(346, 277);
            this.userControlSpellChoice2.Name = "userControlSpellChoice2";
            this.userControlSpellChoice2.Size = new System.Drawing.Size(346, 289);
            this.userControlSpellChoice2.TabIndex = 9;
            this.userControlSpellChoice2.TitleString = "Level 1 Spells";
            this.userControlSpellChoice2.SpellSelectionChanged += new CharacterManager.UserControls.UserControlSpellChoice.SpellChoiceChangedListener(this.userControlSpellChoice2_SpellSelectionChanged);
            // 
            // userControlSpellChoice1
            // 
            this.userControlSpellChoice1.IsBorder = true;
            this.userControlSpellChoice1.IsCheckBoxed = true;
            this.userControlSpellChoice1.IsMultipleLevel = false;
            this.userControlSpellChoice1.Location = new System.Drawing.Point(12, 25);
            this.userControlSpellChoice1.Name = "userControlSpellChoice1";
            this.userControlSpellChoice1.Size = new System.Drawing.Size(346, 290);
            this.userControlSpellChoice1.TabIndex = 8;
            this.userControlSpellChoice1.TitleString = "Cantrips:";
            this.userControlSpellChoice1.SpellSelectionChanged += new CharacterManager.UserControls.UserControlSpellChoice.SpellChoiceChangedListener(this.userControlSpellChoice1_SpellSelectionChanged);
            // 
            // FormChooseSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 668);
            this.Controls.Add(this.userControlChosenSpells);
            this.Controls.Add(this.userControlSpellChoice2);
            this.Controls.Add(this.userControlSpellChoice1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MinimumSize = new System.Drawing.Size(854, 707);
            this.Name = "FormChooseSpells";
            this.Text = "FormChooseSpells";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private UserControls.UserControlSpellChoice userControlSpellChoice1;
        private UserControls.UserControlSpellChoice userControlSpellChoice2;
        private UserControls.UserControlSpellChoice userControlChosenSpells;
    }
}