
namespace CharacterManager.UserControls.MainForm
{
    partial class UserControlCurrency
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
            // UserControlCurrency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.IsBorder = false;
            this.Name = "UserControlCurrency";
            this.Size = new System.Drawing.Size(64, 60);
            this.DoubleClick += new System.EventHandler(this.UserControlCurrency_DoubleClick);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserControlCurrency_KeyPress);
            this.Leave += new System.EventHandler(this.UserControlCurrency_Leave);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
