
namespace CharacterManager.UserControls
{
    partial class FormWeaponAttack
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelWeaponName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBoxRolls = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.userControlDamageDieRoll = new CharacterManager.UserControls.UserControlDieRollBonusValuesHandler();
            this.userControlAttackDieRolls = new CharacterManager.UserControls.UserControlDieRollBonusValuesHandler();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Weapon:";
            // 
            // labelWeaponName
            // 
            this.labelWeaponName.AutoSize = true;
            this.labelWeaponName.BackColor = System.Drawing.Color.Transparent;
            this.labelWeaponName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWeaponName.Location = new System.Drawing.Point(91, 9);
            this.labelWeaponName.Name = "labelWeaponName";
            this.labelWeaponName.Size = new System.Drawing.Size(85, 20);
            this.labelWeaponName.TabIndex = 1;
            this.labelWeaponName.Text = "Sword(1H)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Range:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(283, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Situational Bonus";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(451, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Total";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(641, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Result";
            // 
            // richTextBoxRolls
            // 
            this.richTextBoxRolls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxRolls.Location = new System.Drawing.Point(191, 132);
            this.richTextBoxRolls.Name = "richTextBoxRolls";
            this.richTextBoxRolls.Size = new System.Drawing.Size(530, 148);
            this.richTextBoxRolls.TabIndex = 19;
            this.richTextBoxRolls.Text = "";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(10, 250);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 30);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // userControlDamageDieRoll
            // 
            this.userControlDamageDieRoll.BackColor = System.Drawing.Color.Transparent;
            this.userControlDamageDieRoll.Location = new System.Drawing.Point(-1, 78);
            this.userControlDamageDieRoll.Modifiers = null;
            this.userControlDamageDieRoll.Name = "userControlDamageDieRoll";
            this.userControlDamageDieRoll.Size = new System.Drawing.Size(722, 27);
            this.userControlDamageDieRoll.TabIndex = 21;
            this.userControlDamageDieRoll.UserControlName = "Damage Roll:";
            // 
            // userControlAttackDieRolls
            // 
            this.userControlAttackDieRolls.BackColor = System.Drawing.Color.Transparent;
            this.userControlAttackDieRolls.Location = new System.Drawing.Point(-1, 45);
            this.userControlAttackDieRolls.Modifiers = null;
            this.userControlAttackDieRolls.Name = "userControlAttackDieRolls";
            this.userControlAttackDieRolls.Size = new System.Drawing.Size(722, 27);
            this.userControlAttackDieRolls.TabIndex = 22;
            this.userControlAttackDieRolls.UserControlName = "Attack Roll:";
            // 
            // FormWeaponAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterManager.Properties.Resources.old_paper_texture;
            this.ClientSize = new System.Drawing.Size(742, 292);
            this.Controls.Add(this.userControlAttackDieRolls);
            this.Controls.Add(this.userControlDamageDieRoll);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.richTextBoxRolls);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelWeaponName);
            this.Controls.Add(this.label1);
            this.Name = "FormWeaponAttack";
            this.Text = "Weapon Attack";
            this.Load += new System.EventHandler(this.FormWeaponAttack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelWeaponName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBoxRolls;
        private System.Windows.Forms.Button buttonClose;
        private UserControlDieRollBonusValuesHandler userControlDamageDieRoll;
        private UserControlDieRollBonusValuesHandler userControlAttackDieRolls;
    }
}