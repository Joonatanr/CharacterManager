﻿namespace CharacterManager.CharacterCreator
{
    partial class UserControlClassFeature
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxAbilityDescription = new System.Windows.Forms.RichTextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonExtraChoices = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxAbilitySelect = new System.Windows.Forms.ComboBox();
            this.richTextBoxAbilitySub = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxAbilityDescription
            // 
            this.richTextBoxAbilityDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAbilityDescription.Location = new System.Drawing.Point(6, 39);
            this.richTextBoxAbilityDescription.Name = "richTextBoxAbilityDescription";
            this.richTextBoxAbilityDescription.Size = new System.Drawing.Size(245, 78);
            this.richTextBoxAbilityDescription.TabIndex = 0;
            this.richTextBoxAbilityDescription.Text = "";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelTitle.Location = new System.Drawing.Point(6, 16);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(52, 20);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "TITLE";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonExtraChoices);
            this.groupBox1.Controls.Add(this.labelTitle);
            this.groupBox1.Controls.Add(this.richTextBoxAbilityDescription);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 123);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Feature";
            // 
            // buttonExtraChoices
            // 
            this.buttonExtraChoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExtraChoices.Location = new System.Drawing.Point(137, 10);
            this.buttonExtraChoices.Name = "buttonExtraChoices";
            this.buttonExtraChoices.Size = new System.Drawing.Size(114, 23);
            this.buttonExtraChoices.TabIndex = 2;
            this.buttonExtraChoices.Text = "Extra";
            this.buttonExtraChoices.UseVisualStyleBackColor = true;
            this.buttonExtraChoices.Visible = false;
            this.buttonExtraChoices.Click += new System.EventHandler(this.buttonExtraChoices_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.comboBoxAbilitySelect);
            this.groupBox2.Controls.Add(this.richTextBoxAbilitySub);
            this.groupBox2.Location = new System.Drawing.Point(266, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 123);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // comboBoxAbilitySelect
            // 
            this.comboBoxAbilitySelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAbilitySelect.FormattingEnabled = true;
            this.comboBoxAbilitySelect.Location = new System.Drawing.Point(6, 12);
            this.comboBoxAbilitySelect.Name = "comboBoxAbilitySelect";
            this.comboBoxAbilitySelect.Size = new System.Drawing.Size(216, 21);
            this.comboBoxAbilitySelect.TabIndex = 1;
            this.comboBoxAbilitySelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxAbilitySelect_SelectedIndexChanged);
            // 
            // richTextBoxAbilitySub
            // 
            this.richTextBoxAbilitySub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAbilitySub.Location = new System.Drawing.Point(6, 39);
            this.richTextBoxAbilitySub.Name = "richTextBoxAbilitySub";
            this.richTextBoxAbilitySub.Size = new System.Drawing.Size(216, 78);
            this.richTextBoxAbilitySub.TabIndex = 0;
            this.richTextBoxAbilitySub.Text = "";
            // 
            // UserControlClassFeature
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlClassFeature";
            this.Size = new System.Drawing.Size(497, 129);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxAbilityDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxAbilitySelect;
        private System.Windows.Forms.RichTextBox richTextBoxAbilitySub;
        private System.Windows.Forms.Button buttonExtraChoices;
    }
}
