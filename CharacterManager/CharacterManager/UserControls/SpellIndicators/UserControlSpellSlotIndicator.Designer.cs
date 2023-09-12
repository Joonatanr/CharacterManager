namespace CharacterManager.UserControls
{
    partial class UserControlSpellSlotIndicator
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
            this.SuspendLayout();
            // 
            // UserControlSpellSlotIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Name = "UserControlSpellSlotIndicator";
            this.Size = new System.Drawing.Size(24, 25);
            this.Load += new System.EventHandler(this.UserControlSpellSlotIndicator_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserControlSpellSlotIndicator_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserControlSpellSlotIndicator_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UserControlSpellSlotIndicator_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UserControlSpellSlotIndicator_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
