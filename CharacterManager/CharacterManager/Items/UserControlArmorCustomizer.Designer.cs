
namespace CharacterManager.Items
{
    partial class UserControlArmorCustomizer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxBaseArmorClass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxIsStealthDisadv = new System.Windows.Forms.CheckBox();
            this.textBoxMinStrengthScore = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMagicalAcBonus = new System.Windows.Forms.TextBox();
            this.checkBoxIsMagical = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxDexModifier = new System.Windows.Forms.TextBox();
            this.checkBoxIsDexModifier = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonShield = new System.Windows.Forms.RadioButton();
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonHeavy = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(366, 188);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBoxBaseArmorClass);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.checkBoxIsStealthDisadv);
            this.groupBox4.Controls.Add(this.textBoxMinStrengthScore);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(233, 94);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // textBoxBaseArmorClass
            // 
            this.textBoxBaseArmorClass.Location = new System.Drawing.Point(118, 19);
            this.textBoxBaseArmorClass.Name = "textBoxBaseArmorClass";
            this.textBoxBaseArmorClass.Size = new System.Drawing.Size(109, 20);
            this.textBoxBaseArmorClass.TabIndex = 2;
            this.textBoxBaseArmorClass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaseArmorClass_KeyPress);
            this.textBoxBaseArmorClass.Leave += new System.EventHandler(this.textBoxBaseArmorClass_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Base Armor Class";
            // 
            // checkBoxIsStealthDisadv
            // 
            this.checkBoxIsStealthDisadv.AutoSize = true;
            this.checkBoxIsStealthDisadv.Location = new System.Drawing.Point(91, 71);
            this.checkBoxIsStealthDisadv.Name = "checkBoxIsStealthDisadv";
            this.checkBoxIsStealthDisadv.Size = new System.Drawing.Size(136, 17);
            this.checkBoxIsStealthDisadv.TabIndex = 5;
            this.checkBoxIsStealthDisadv.Text = "Causes Stealth Disadv.";
            this.checkBoxIsStealthDisadv.UseVisualStyleBackColor = true;
            this.checkBoxIsStealthDisadv.CheckedChanged += new System.EventHandler(this.checkBoxIsStealthDisadv_CheckedChanged);
            // 
            // textBoxMinStrengthScore
            // 
            this.textBoxMinStrengthScore.Location = new System.Drawing.Point(118, 45);
            this.textBoxMinStrengthScore.Name = "textBoxMinStrengthScore";
            this.textBoxMinStrengthScore.Size = new System.Drawing.Size(109, 20);
            this.textBoxMinStrengthScore.TabIndex = 3;
            this.textBoxMinStrengthScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMinStrengthScore_KeyPress);
            this.textBoxMinStrengthScore.Leave += new System.EventHandler(this.textBoxMinStrengthScore_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Minimum STR score";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxMagicalAcBonus);
            this.groupBox3.Controls.Add(this.checkBoxIsMagical);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxMaxDexModifier);
            this.groupBox3.Controls.Add(this.checkBoxIsDexModifier);
            this.groupBox3.Location = new System.Drawing.Point(6, 107);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(354, 75);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modifiers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Magic AC Bonus";
            // 
            // textBoxMagicalAcBonus
            // 
            this.textBoxMagicalAcBonus.Location = new System.Drawing.Point(288, 36);
            this.textBoxMagicalAcBonus.Name = "textBoxMagicalAcBonus";
            this.textBoxMagicalAcBonus.Size = new System.Drawing.Size(60, 20);
            this.textBoxMagicalAcBonus.TabIndex = 4;
            this.textBoxMagicalAcBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMagicalAcBonus_KeyPress);
            this.textBoxMagicalAcBonus.Leave += new System.EventHandler(this.textBoxMagicalAcBonus_Leave);
            // 
            // checkBoxIsMagical
            // 
            this.checkBoxIsMagical.AutoSize = true;
            this.checkBoxIsMagical.Location = new System.Drawing.Point(199, 19);
            this.checkBoxIsMagical.Name = "checkBoxIsMagical";
            this.checkBoxIsMagical.Size = new System.Drawing.Size(63, 17);
            this.checkBoxIsMagical.TabIndex = 3;
            this.checkBoxIsMagical.Text = "Magical";
            this.checkBoxIsMagical.UseVisualStyleBackColor = true;
            this.checkBoxIsMagical.CheckedChanged += new System.EventHandler(this.checkBoxIsMagical_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Max DEX modifier";
            // 
            // textBoxMaxDexModifier
            // 
            this.textBoxMaxDexModifier.Location = new System.Drawing.Point(118, 36);
            this.textBoxMaxDexModifier.Name = "textBoxMaxDexModifier";
            this.textBoxMaxDexModifier.Size = new System.Drawing.Size(64, 20);
            this.textBoxMaxDexModifier.TabIndex = 1;
            this.textBoxMaxDexModifier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMaxDexModifier_KeyPress);
            this.textBoxMaxDexModifier.Leave += new System.EventHandler(this.textBoxMaxDexModifier_Leave);
            // 
            // checkBoxIsDexModifier
            // 
            this.checkBoxIsDexModifier.AutoSize = true;
            this.checkBoxIsDexModifier.Location = new System.Drawing.Point(9, 19);
            this.checkBoxIsDexModifier.Name = "checkBoxIsDexModifier";
            this.checkBoxIsDexModifier.Size = new System.Drawing.Size(114, 17);
            this.checkBoxIsDexModifier.TabIndex = 0;
            this.checkBoxIsDexModifier.Text = "Uses DEX modifier";
            this.checkBoxIsDexModifier.UseVisualStyleBackColor = true;
            this.checkBoxIsDexModifier.CheckedChanged += new System.EventHandler(this.checkBoxIsDexModifier_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonShield);
            this.groupBox2.Controls.Add(this.radioButtonLight);
            this.groupBox2.Controls.Add(this.radioButtonMedium);
            this.groupBox2.Controls.Add(this.radioButtonHeavy);
            this.groupBox2.Location = new System.Drawing.Point(245, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(115, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Armor Type";
            // 
            // radioButtonShield
            // 
            this.radioButtonShield.AutoSize = true;
            this.radioButtonShield.Location = new System.Drawing.Point(6, 68);
            this.radioButtonShield.Name = "radioButtonShield";
            this.radioButtonShield.Size = new System.Drawing.Size(54, 17);
            this.radioButtonShield.TabIndex = 3;
            this.radioButtonShield.TabStop = true;
            this.radioButtonShield.Text = "Shield";
            this.radioButtonShield.UseVisualStyleBackColor = true;
            this.radioButtonShield.CheckedChanged += new System.EventHandler(this.radioButtonShield_CheckedChanged);
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Location = new System.Drawing.Point(6, 49);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(48, 17);
            this.radioButtonLight.TabIndex = 2;
            this.radioButtonLight.TabStop = true;
            this.radioButtonLight.Text = "Light";
            this.radioButtonLight.UseVisualStyleBackColor = true;
            this.radioButtonLight.CheckedChanged += new System.EventHandler(this.radioButtonLight_CheckedChanged);
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(6, 31);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(62, 17);
            this.radioButtonMedium.TabIndex = 1;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(this.radioButtonMedium_CheckedChanged);
            // 
            // radioButtonHeavy
            // 
            this.radioButtonHeavy.AutoSize = true;
            this.radioButtonHeavy.Location = new System.Drawing.Point(6, 13);
            this.radioButtonHeavy.Name = "radioButtonHeavy";
            this.radioButtonHeavy.Size = new System.Drawing.Size(56, 17);
            this.radioButtonHeavy.TabIndex = 0;
            this.radioButtonHeavy.TabStop = true;
            this.radioButtonHeavy.Text = "Heavy";
            this.radioButtonHeavy.UseVisualStyleBackColor = true;
            this.radioButtonHeavy.CheckedChanged += new System.EventHandler(this.radioButtonHeavy_CheckedChanged);
            // 
            // UserControlArmorCustomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlArmorCustomizer";
            this.Size = new System.Drawing.Size(372, 191);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonShield;
        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonHeavy;
        private System.Windows.Forms.TextBox textBoxBaseArmorClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox checkBoxIsStealthDisadv;
        private System.Windows.Forms.TextBox textBoxMinStrengthScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMaxDexModifier;
        private System.Windows.Forms.CheckBox checkBoxIsDexModifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMagicalAcBonus;
        private System.Windows.Forms.CheckBox checkBoxIsMagical;
    }
}
