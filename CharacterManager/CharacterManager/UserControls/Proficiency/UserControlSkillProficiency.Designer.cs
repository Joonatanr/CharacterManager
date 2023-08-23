
namespace CharacterManager.UserControls.Proficiency
{
    partial class UserControlSkillProficiency
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
            this.checkBoxExpertise = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.Location = new System.Drawing.Point(0, 2);
            this.labelDescription.Size = new System.Drawing.Size(57, 16);
            this.labelDescription.Text = "Athletics";
            // 
            // checkBoxProficiency
            // 
            this.checkBoxProficiency.Location = new System.Drawing.Point(146, 2);
            // 
            // textBoxModifier
            // 
            this.textBoxModifier.Location = new System.Drawing.Point(104, 0);
            this.textBoxModifier.Size = new System.Drawing.Size(40, 20);
            // 
            // checkBoxExpertise
            // 
            this.checkBoxExpertise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxExpertise.AutoSize = true;
            this.checkBoxExpertise.Enabled = false;
            this.checkBoxExpertise.Location = new System.Drawing.Point(187, 2);
            this.checkBoxExpertise.Name = "checkBoxExpertise";
            this.checkBoxExpertise.Size = new System.Drawing.Size(49, 17);
            this.checkBoxExpertise.TabIndex = 33;
            this.checkBoxExpertise.Text = "exprt";
            this.checkBoxExpertise.UseVisualStyleBackColor = true;
            this.checkBoxExpertise.CheckedChanged += new System.EventHandler(this.checkBoxExpertise_CheckedChanged);
            // 
            // UserControlSkillProficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxExpertise);
            this.Name = "UserControlSkillProficiency";
            this.Size = new System.Drawing.Size(233, 20);
            this.Controls.SetChildIndex(this.labelDescription, 0);
            this.Controls.SetChildIndex(this.textBoxModifier, 0);
            this.Controls.SetChildIndex(this.checkBoxProficiency, 0);
            this.Controls.SetChildIndex(this.checkBoxExpertise, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxExpertise;
    }
}
