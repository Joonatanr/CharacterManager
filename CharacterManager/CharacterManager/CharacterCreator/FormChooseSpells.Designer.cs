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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlSpellChoice1 = new CharacterManager.UserControls.UserControlSpellChoice();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userControlChosenSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userControlSpellChoice2 = new CharacterManager.UserControls.UserControlSpellChoice();
            this.labelCostForCopying = new System.Windows.Forms.Label();
            this.textBoxCopyCost = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSpendGold = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(672, 666);
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
            this.buttonCancel.Location = new System.Drawing.Point(753, 666);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.userControlSpellChoice1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 315);
            this.panel1.TabIndex = 13;
            // 
            // userControlSpellChoice1
            // 
            this.userControlSpellChoice1.IsAvailabilityCount = true;
            this.userControlSpellChoice1.IsBorder = true;
            this.userControlSpellChoice1.IsCastingInfoEnabled = false;
            this.userControlSpellChoice1.IsCheckBoxed = true;
            this.userControlSpellChoice1.IsMultipleLevel = false;
            this.userControlSpellChoice1.Location = new System.Drawing.Point(3, 13);
            this.userControlSpellChoice1.MaximumAvailableChoices = 0;
            this.userControlSpellChoice1.Name = "userControlSpellChoice1";
            this.userControlSpellChoice1.Size = new System.Drawing.Size(346, 290);
            this.userControlSpellChoice1.TabIndex = 8;
            this.userControlSpellChoice1.TitleString = "Cantrips:";
            this.userControlSpellChoice1.SpellSelectionChanged += new CharacterManager.UserControls.UserControlSpellChoice.SpellChoiceChangedListener(this.userControlSpellChoice1_SpellSelectionChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.userControlChosenSpells);
            this.panel2.Location = new System.Drawing.Point(392, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 644);
            this.panel2.TabIndex = 14;
            // 
            // userControlChosenSpells
            // 
            this.userControlChosenSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlChosenSpells.IsAvailabilityCount = false;
            this.userControlChosenSpells.IsBorder = true;
            this.userControlChosenSpells.IsCastingInfoEnabled = false;
            this.userControlChosenSpells.IsCheckBoxed = false;
            this.userControlChosenSpells.IsMultipleLevel = true;
            this.userControlChosenSpells.Location = new System.Drawing.Point(3, 3);
            this.userControlChosenSpells.MaximumAvailableChoices = 0;
            this.userControlChosenSpells.MinimumSize = new System.Drawing.Size(429, 585);
            this.userControlChosenSpells.Name = "userControlChosenSpells";
            this.userControlChosenSpells.Size = new System.Drawing.Size(437, 638);
            this.userControlChosenSpells.TabIndex = 12;
            this.userControlChosenSpells.TitleString = "Chosen Spells:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.userControlSpellChoice2);
            this.panel3.Location = new System.Drawing.Point(12, 333);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 323);
            this.panel3.TabIndex = 15;
            // 
            // userControlSpellChoice2
            // 
            this.userControlSpellChoice2.IsAvailabilityCount = true;
            this.userControlSpellChoice2.IsBorder = true;
            this.userControlSpellChoice2.IsCastingInfoEnabled = false;
            this.userControlSpellChoice2.IsCheckBoxed = true;
            this.userControlSpellChoice2.IsMultipleLevel = true;
            this.userControlSpellChoice2.Location = new System.Drawing.Point(3, 3);
            this.userControlSpellChoice2.MaximumAvailableChoices = 0;
            this.userControlSpellChoice2.MinimumSize = new System.Drawing.Size(346, 277);
            this.userControlSpellChoice2.Name = "userControlSpellChoice2";
            this.userControlSpellChoice2.Size = new System.Drawing.Size(346, 317);
            this.userControlSpellChoice2.TabIndex = 9;
            this.userControlSpellChoice2.TitleString = "Available spells:";
            this.userControlSpellChoice2.SpellSelectionChanged += new CharacterManager.UserControls.UserControlSpellChoice.SpellChoiceChangedListener(this.userControlSpellChoice2_SpellSelectionChanged);
            // 
            // labelCostForCopying
            // 
            this.labelCostForCopying.AutoSize = true;
            this.labelCostForCopying.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelCostForCopying.Location = new System.Drawing.Point(12, 670);
            this.labelCostForCopying.Name = "labelCostForCopying";
            this.labelCostForCopying.Size = new System.Drawing.Size(106, 16);
            this.labelCostForCopying.TabIndex = 16;
            this.labelCostForCopying.Text = "Cost for Copying";
            // 
            // textBoxCopyCost
            // 
            this.textBoxCopyCost.Location = new System.Drawing.Point(124, 669);
            this.textBoxCopyCost.Name = "textBoxCopyCost";
            this.textBoxCopyCost.Size = new System.Drawing.Size(108, 20);
            this.textBoxCopyCost.TabIndex = 17;
            // 
            // checkBoxAutoSpendGold
            // 
            this.checkBoxAutoSpendGold.AutoSize = true;
            this.checkBoxAutoSpendGold.Checked = true;
            this.checkBoxAutoSpendGold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSpendGold.Location = new System.Drawing.Point(239, 671);
            this.checkBoxAutoSpendGold.Name = "checkBoxAutoSpendGold";
            this.checkBoxAutoSpendGold.Size = new System.Drawing.Size(143, 17);
            this.checkBoxAutoSpendGold.TabIndex = 18;
            this.checkBoxAutoSpendGold.Text = "Automatically spend gold";
            this.checkBoxAutoSpendGold.UseVisualStyleBackColor = true;
            // 
            // FormChooseSpells
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 701);
            this.Controls.Add(this.checkBoxAutoSpendGold);
            this.Controls.Add(this.textBoxCopyCost);
            this.Controls.Add(this.labelCostForCopying);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.MinimumSize = new System.Drawing.Size(854, 707);
            this.Name = "FormChooseSpells";
            this.Text = "FormChooseSpells";
            this.Load += new System.EventHandler(this.FormChooseSpells_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private UserControls.UserControlSpellChoice userControlSpellChoice1;
        private UserControls.UserControlSpellChoice userControlSpellChoice2;
        private UserControls.UserControlSpellChoice userControlChosenSpells;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelCostForCopying;
        private System.Windows.Forms.TextBox textBoxCopyCost;
        private System.Windows.Forms.CheckBox checkBoxAutoSpendGold;
    }
}