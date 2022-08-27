
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxAttackRollMods = new System.Windows.Forms.TextBox();
            this.textBoxAttackRollSit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTotalAttackRoll = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonRollAttack = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.buttonRollDamage = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBoxDamageRollModifiers = new System.Windows.Forms.TextBox();
            this.richTextBoxRolls = new System.Windows.Forms.RichTextBox();
            this.buttonClose = new System.Windows.Forms.Button();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Attack Roll:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Damage Roll:";
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
            // textBoxAttackRollMods
            // 
            this.textBoxAttackRollMods.Location = new System.Drawing.Point(130, 52);
            this.textBoxAttackRollMods.Name = "textBoxAttackRollMods";
            this.textBoxAttackRollMods.ReadOnly = true;
            this.textBoxAttackRollMods.Size = new System.Drawing.Size(147, 20);
            this.textBoxAttackRollMods.TabIndex = 6;
            this.textBoxAttackRollMods.Text = "1d20+3+2+1";
            // 
            // textBoxAttackRollSit
            // 
            this.textBoxAttackRollSit.Location = new System.Drawing.Point(283, 51);
            this.textBoxAttackRollSit.Name = "textBoxAttackRollSit";
            this.textBoxAttackRollSit.Size = new System.Drawing.Size(130, 20);
            this.textBoxAttackRollSit.TabIndex = 7;
            this.textBoxAttackRollSit.Text = "0";
            this.textBoxAttackRollSit.TextChanged += new System.EventHandler(this.textBoxAttackRollSit_TextChanged);
            this.textBoxAttackRollSit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxAttackRollSit_KeyDown);
            this.textBoxAttackRollSit.Leave += new System.EventHandler(this.textBoxAttackRollSit_Leave);
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
            // textBoxTotalAttackRoll
            // 
            this.textBoxTotalAttackRoll.Location = new System.Drawing.Point(419, 51);
            this.textBoxTotalAttackRoll.Name = "textBoxTotalAttackRoll";
            this.textBoxTotalAttackRoll.ReadOnly = true;
            this.textBoxTotalAttackRoll.Size = new System.Drawing.Size(119, 20);
            this.textBoxTotalAttackRoll.TabIndex = 9;
            this.textBoxTotalAttackRoll.Text = "1d20+8";
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
            // buttonRollAttack
            // 
            this.buttonRollAttack.Location = new System.Drawing.Point(544, 49);
            this.buttonRollAttack.Name = "buttonRollAttack";
            this.buttonRollAttack.Size = new System.Drawing.Size(75, 23);
            this.buttonRollAttack.TabIndex = 11;
            this.buttonRollAttack.Text = "Roll";
            this.buttonRollAttack.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(625, 49);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(96, 20);
            this.textBox3.TabIndex = 12;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(625, 88);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(96, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonRollDamage
            // 
            this.buttonRollDamage.Location = new System.Drawing.Point(544, 88);
            this.buttonRollDamage.Name = "buttonRollDamage";
            this.buttonRollDamage.Size = new System.Drawing.Size(75, 23);
            this.buttonRollDamage.TabIndex = 17;
            this.buttonRollDamage.Text = "Roll";
            this.buttonRollDamage.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(419, 91);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(119, 20);
            this.textBox5.TabIndex = 16;
            this.textBox5.Text = "1d8+4";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(283, 91);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(130, 20);
            this.textBox6.TabIndex = 15;
            this.textBox6.Text = "0";
            // 
            // textBoxDamageRollModifiers
            // 
            this.textBoxDamageRollModifiers.Location = new System.Drawing.Point(130, 91);
            this.textBoxDamageRollModifiers.Name = "textBoxDamageRollModifiers";
            this.textBoxDamageRollModifiers.ReadOnly = true;
            this.textBoxDamageRollModifiers.Size = new System.Drawing.Size(147, 20);
            this.textBoxDamageRollModifiers.TabIndex = 14;
            this.textBoxDamageRollModifiers.Text = "1d8+3+1";
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
            // FormWeaponAttack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterManager.Properties.Resources.old_paper_texture;
            this.ClientSize = new System.Drawing.Size(742, 292);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.richTextBoxRolls);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.buttonRollDamage);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBoxDamageRollModifiers);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonRollAttack);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTotalAttackRoll);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAttackRollSit);
            this.Controls.Add(this.textBoxAttackRollMods);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxAttackRollMods;
        private System.Windows.Forms.TextBox textBoxAttackRollSit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTotalAttackRoll;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRollAttack;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button buttonRollDamage;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBoxDamageRollModifiers;
        private System.Windows.Forms.RichTextBox richTextBoxRolls;
        private System.Windows.Forms.Button buttonClose;
    }
}