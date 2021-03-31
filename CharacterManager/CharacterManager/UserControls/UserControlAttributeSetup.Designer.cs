
namespace CharacterManager.UserControls
{
    partial class UserControlAttributeSetup
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
            this.textBoxRacialBonus = new System.Windows.Forms.TextBox();
            this.textBoxAttributeFinal = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.numericUpDownBaseValue = new System.Windows.Forms.NumericUpDown();
            this.checkBoxExtraBonus = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseValue)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxRacialBonus
            // 
            this.textBoxRacialBonus.Location = new System.Drawing.Point(97, 3);
            this.textBoxRacialBonus.Name = "textBoxRacialBonus";
            this.textBoxRacialBonus.ReadOnly = true;
            this.textBoxRacialBonus.Size = new System.Drawing.Size(50, 20);
            this.textBoxRacialBonus.TabIndex = 21;
            this.textBoxRacialBonus.Text = "+0";
            // 
            // textBoxAttributeFinal
            // 
            this.textBoxAttributeFinal.Location = new System.Drawing.Point(179, 3);
            this.textBoxAttributeFinal.Name = "textBoxAttributeFinal";
            this.textBoxAttributeFinal.ReadOnly = true;
            this.textBoxAttributeFinal.Size = new System.Drawing.Size(54, 20);
            this.textBoxAttributeFinal.TabIndex = 22;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(2, 5);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(31, 16);
            this.labelDescription.TabIndex = 20;
            this.labelDescription.Text = "STR";
            // 
            // numericUpDownBaseValue
            // 
            this.numericUpDownBaseValue.Location = new System.Drawing.Point(40, 3);
            this.numericUpDownBaseValue.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownBaseValue.Name = "numericUpDownBaseValue";
            this.numericUpDownBaseValue.Size = new System.Drawing.Size(52, 20);
            this.numericUpDownBaseValue.TabIndex = 19;
            this.numericUpDownBaseValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBaseValue.ValueChanged += new System.EventHandler(this.numericUpDownBaseValue_ValueChanged);
            // 
            // checkBoxExtraBonus
            // 
            this.checkBoxExtraBonus.AutoSize = true;
            this.checkBoxExtraBonus.Location = new System.Drawing.Point(155, 6);
            this.checkBoxExtraBonus.Name = "checkBoxExtraBonus";
            this.checkBoxExtraBonus.Size = new System.Drawing.Size(15, 14);
            this.checkBoxExtraBonus.TabIndex = 23;
            this.checkBoxExtraBonus.UseVisualStyleBackColor = true;
            this.checkBoxExtraBonus.Visible = false;
            // 
            // UserControlAttributeSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxExtraBonus);
            this.Controls.Add(this.textBoxRacialBonus);
            this.Controls.Add(this.textBoxAttributeFinal);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.numericUpDownBaseValue);
            this.Name = "UserControlAttributeSetup";
            this.Size = new System.Drawing.Size(248, 26);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaseValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRacialBonus;
        private System.Windows.Forms.TextBox textBoxAttributeFinal;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.NumericUpDown numericUpDownBaseValue;
        private System.Windows.Forms.CheckBox checkBoxExtraBonus;
    }
}
