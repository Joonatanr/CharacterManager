
namespace CharacterManager.UserControls
{
    partial class FormUseAbility
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
            this.customRTBDescription = new CharacterManager.Spells.CustomRTB();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelAbilityName = new System.Windows.Forms.Label();
            this.dieRollTextBox1 = new CharacterManager.UserControls.DieRollTextBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.customRTB1 = new CharacterManager.Spells.CustomRTB();
            this.customRTBLog = new CharacterManager.Spells.CustomRTB();
            this.SuspendLayout();
            // 
            // customRTBDescription
            // 
            this.customRTBDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.customRTBDescription.Location = new System.Drawing.Point(12, 52);
            this.customRTBDescription.Name = "customRTBDescription";
            this.customRTBDescription.Size = new System.Drawing.Size(509, 209);
            this.customRTBDescription.TabIndex = 0;
            this.customRTBDescription.Text = "";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 392);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(93, 392);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelAbilityName
            // 
            this.labelAbilityName.AutoSize = true;
            this.labelAbilityName.BackColor = System.Drawing.Color.Transparent;
            this.labelAbilityName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelAbilityName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAbilityName.Location = new System.Drawing.Point(12, 9);
            this.labelAbilityName.Name = "labelAbilityName";
            this.labelAbilityName.Size = new System.Drawing.Size(176, 26);
            this.labelAbilityName.TabIndex = 3;
            this.labelAbilityName.Text = "<Ability Name>";
            // 
            // dieRollTextBox1
            // 
            this.dieRollTextBox1.DieRollObject = null;
            this.dieRollTextBox1.Location = new System.Drawing.Point(93, 270);
            this.dieRollTextBox1.Name = "dieRollTextBox1";
            this.dieRollTextBox1.Size = new System.Drawing.Size(178, 20);
            this.dieRollTextBox1.TabIndex = 4;
            // 
            // textBoxResult
            // 
            this.textBoxResult.Location = new System.Drawing.Point(421, 270);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(100, 20);
            this.textBoxResult.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label2.Location = new System.Drawing.Point(360, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Result";
            // 
            // buttonRoll
            // 
            this.buttonRoll.Location = new System.Drawing.Point(12, 268);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(75, 23);
            this.buttonRoll.TabIndex = 8;
            this.buttonRoll.Text = "Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // customRTB1
            // 
            this.customRTB1.Location = new System.Drawing.Point(-23, -46);
            this.customRTB1.Name = "customRTB1";
            this.customRTB1.Size = new System.Drawing.Size(100, 96);
            this.customRTB1.TabIndex = 9;
            this.customRTB1.Text = "";
            // 
            // customRTBLog
            // 
            this.customRTBLog.Location = new System.Drawing.Point(203, 319);
            this.customRTBLog.Name = "customRTBLog";
            this.customRTBLog.Size = new System.Drawing.Size(318, 96);
            this.customRTBLog.TabIndex = 10;
            this.customRTBLog.Text = "";
            // 
            // FormUseAbility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterManager.Properties.Resources.old_paper_texture;
            this.ClientSize = new System.Drawing.Size(533, 427);
            this.Controls.Add(this.customRTBLog);
            this.Controls.Add(this.customRTB1);
            this.Controls.Add(this.buttonRoll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.dieRollTextBox1);
            this.Controls.Add(this.labelAbilityName);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.customRTBDescription);
            this.Name = "FormUseAbility";
            this.Text = "FormUseAbility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Spells.CustomRTB customRTBDescription;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelAbilityName;
        private DieRollTextBox dieRollTextBox1;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRoll;
        private Spells.CustomRTB customRTB1;
        private Spells.CustomRTB customRTBLog;
    }
}