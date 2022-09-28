
namespace CharacterManager.CharacterCreator
{
    partial class FormChooseRaceFeatures
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
            this.groupBoxLanguageOptions = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelNoLanguages = new System.Windows.Forms.Label();
            this.groupBoxToolProficiencies = new System.Windows.Forms.GroupBox();
            this.groupBoxLanguageOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxLanguageOptions
            // 
            this.groupBoxLanguageOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLanguageOptions.Controls.Add(this.labelNoLanguages);
            this.groupBoxLanguageOptions.Location = new System.Drawing.Point(12, 12);
            this.groupBoxLanguageOptions.Name = "groupBoxLanguageOptions";
            this.groupBoxLanguageOptions.Size = new System.Drawing.Size(263, 89);
            this.groupBoxLanguageOptions.TabIndex = 0;
            this.groupBoxLanguageOptions.TabStop = false;
            this.groupBoxLanguageOptions.Text = "Extra Languages";
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOK.Location = new System.Drawing.Point(12, 240);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(93, 240);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelNoLanguages
            // 
            this.labelNoLanguages.AutoSize = true;
            this.labelNoLanguages.Location = new System.Drawing.Point(20, 38);
            this.labelNoLanguages.Name = "labelNoLanguages";
            this.labelNoLanguages.Size = new System.Drawing.Size(196, 13);
            this.labelNoLanguages.TabIndex = 0;
            this.labelNoLanguages.Text = "No Extra Language Options for this race";
            // 
            // groupBoxToolProficiencies
            // 
            this.groupBoxToolProficiencies.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxToolProficiencies.Location = new System.Drawing.Point(12, 108);
            this.groupBoxToolProficiencies.Name = "groupBoxToolProficiencies";
            this.groupBoxToolProficiencies.Size = new System.Drawing.Size(260, 126);
            this.groupBoxToolProficiencies.TabIndex = 3;
            this.groupBoxToolProficiencies.TabStop = false;
            this.groupBoxToolProficiencies.Text = "Tool Proficiencies";
            // 
            // FormChooseRaceFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 275);
            this.Controls.Add(this.groupBoxToolProficiencies);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxLanguageOptions);
            this.MinimumSize = new System.Drawing.Size(300, 314);
            this.Name = "FormChooseRaceFeatures";
            this.Text = "FormChooseRaceFeatures";
            this.groupBoxLanguageOptions.ResumeLayout(false);
            this.groupBoxLanguageOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxLanguageOptions;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelNoLanguages;
        private System.Windows.Forms.GroupBox groupBoxToolProficiencies;
    }
}