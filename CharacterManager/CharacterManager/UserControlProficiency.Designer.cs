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
            this.checkBoxProfSTR = new System.Windows.Forms.CheckBox();
            this.textBoxStrSave = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBoxProfSTR
            // 
            this.checkBoxProfSTR.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.checkBoxProfSTR.AutoCheck = false;
            this.checkBoxProfSTR.AutoSize = true;
            this.checkBoxProfSTR.Location = new System.Drawing.Point(128, 3);
            this.checkBoxProfSTR.Name = "checkBoxProfSTR";
            this.checkBoxProfSTR.Size = new System.Drawing.Size(44, 17);
            this.checkBoxProfSTR.TabIndex = 32;
            this.checkBoxProfSTR.Text = "prof";
            this.checkBoxProfSTR.UseVisualStyleBackColor = true;
            // 
            // textBoxStrSave
            // 
            this.textBoxStrSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textBoxStrSave.Location = new System.Drawing.Point(65, 0);
            this.textBoxStrSave.Name = "textBoxStrSave";
            this.textBoxStrSave.ReadOnly = true;
            this.textBoxStrSave.Size = new System.Drawing.Size(52, 20);
            this.textBoxStrSave.TabIndex = 31;
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 16);
            this.label24.TabIndex = 30;
            this.label24.Text = "STR";
            // 
            // UserControlProficiency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxProfSTR);
            this.Controls.Add(this.textBoxStrSave);
            this.Controls.Add(this.label24);
            this.Name = "UserControlProficiency";
            this.Size = new System.Drawing.Size(176, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxProfSTR;
        private System.Windows.Forms.TextBox textBoxStrSave;
        private System.Windows.Forms.Label label24;
    }
}
