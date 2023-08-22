namespace CharacterManager
{
    partial class UserControlProficiency
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
            this.checkBoxProficiency = new System.Windows.Forms.CheckBox();
            this.textBoxModifier = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxProfSTR
            // 
            this.checkBoxProficiency.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxProficiency.AutoCheck = false;
            this.checkBoxProficiency.AutoSize = true;
            this.checkBoxProficiency.Location = new System.Drawing.Point(128, 2);
            this.checkBoxProficiency.Name = "checkBoxProfSTR";
            this.checkBoxProficiency.Size = new System.Drawing.Size(44, 17);
            this.checkBoxProficiency.TabIndex = 32;
            this.checkBoxProficiency.Text = "prof";
            this.checkBoxProficiency.UseVisualStyleBackColor = true;
            this.checkBoxProficiency.CheckedChanged += new System.EventHandler(this.checkBoxProficiency_CheckedChanged);
            // 
            // textBoxModifier
            // 
            this.textBoxModifier.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxModifier.Location = new System.Drawing.Point(65, 0);
            this.textBoxModifier.Name = "textBoxModifier";
            this.textBoxModifier.ReadOnly = true;
            this.textBoxModifier.Size = new System.Drawing.Size(52, 20);
            this.textBoxModifier.TabIndex = 31;
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Bold);
            this.labelDescription.Location = new System.Drawing.Point(6, 2);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(30, 16);
            this.labelDescription.TabIndex = 30;
            this.labelDescription.Text = "STR";
            // 
            // UserControlProficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxProficiency);
            this.Controls.Add(this.textBoxModifier);
            this.Controls.Add(this.labelDescription);
            this.Name = "UserControlProficiency";
            this.Size = new System.Drawing.Size(176, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        protected System.Windows.Forms.Label labelDescription;
        protected System.Windows.Forms.CheckBox checkBoxProficiency;
        protected System.Windows.Forms.TextBox textBoxModifier;
    }
}
