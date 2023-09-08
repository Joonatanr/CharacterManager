
namespace CharacterManager.UserControls
{
    partial class FormUseHitDice
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
            this.userControlhitDice1 = new CharacterManager.UserControls.MainForm.UserControlhitDice();
            this.buttonRollHitDice = new System.Windows.Forms.Button();
            this.userControlHitPoints1 = new CharacterManager.UserControls.UserControlHitPoints();
            this.textBoxRollResult = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userControlhitDice1
            // 
            this.userControlhitDice1.DieType = 10;
            this.userControlhitDice1.IsBorder = true;
            this.userControlhitDice1.Location = new System.Drawing.Point(157, 12);
            this.userControlhitDice1.MaxHitDice = 1;
            this.userControlhitDice1.Name = "userControlhitDice1";
            this.userControlhitDice1.RemainingHitDice = 0;
            this.userControlhitDice1.Size = new System.Drawing.Size(104, 94);
            this.userControlhitDice1.TabIndex = 0;
            // 
            // buttonRollHitDice
            // 
            this.buttonRollHitDice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonRollHitDice.Location = new System.Drawing.Point(12, 12);
            this.buttonRollHitDice.Name = "buttonRollHitDice";
            this.buttonRollHitDice.Size = new System.Drawing.Size(139, 68);
            this.buttonRollHitDice.TabIndex = 1;
            this.buttonRollHitDice.Text = "Roll Hit Dice";
            this.buttonRollHitDice.UseVisualStyleBackColor = true;
            this.buttonRollHitDice.Click += new System.EventHandler(this.buttonRollHitDice_Click);
            // 
            // userControlHitPoints1
            // 
            this.userControlHitPoints1.CurrentHitPoints = 10;
            this.userControlHitPoints1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userControlHitPoints1.IsBorder = true;
            this.userControlHitPoints1.Location = new System.Drawing.Point(267, 12);
            this.userControlHitPoints1.Name = "userControlHitPoints1";
            this.userControlHitPoints1.Size = new System.Drawing.Size(107, 94);
            this.userControlHitPoints1.TabIndex = 2;
            // 
            // textBoxRollResult
            // 
            this.textBoxRollResult.Location = new System.Drawing.Point(12, 86);
            this.textBoxRollResult.Name = "textBoxRollResult";
            this.textBoxRollResult.Size = new System.Drawing.Size(139, 20);
            this.textBoxRollResult.TabIndex = 3;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(12, 135);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormUseHitDice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 170);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxRollResult);
            this.Controls.Add(this.userControlHitPoints1);
            this.Controls.Add(this.buttonRollHitDice);
            this.Controls.Add(this.userControlhitDice1);
            this.Name = "FormUseHitDice";
            this.Text = "Short Rest - Hit Dice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainForm.UserControlhitDice userControlhitDice1;
        private System.Windows.Forms.Button buttonRollHitDice;
        private UserControlHitPoints userControlHitPoints1;
        private System.Windows.Forms.TextBox textBoxRollResult;
        private System.Windows.Forms.Button buttonOk;
    }
}