
namespace CharacterManager.UserControls
{
    partial class AbilityCard
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
            CharacterManager.Spells.CharacterSpellcastingStatus.SpellSlotData spellSlotData1 = new CharacterManager.Spells.CharacterSpellcastingStatus.SpellSlotData();
            this.labelAbilityName = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelDice = new System.Windows.Forms.Label();
            this.richTextBoxDieRollResult = new System.Windows.Forms.RichTextBox();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.userControlRemainingCharges = new CharacterManager.UserControls.UserControlSpellSlotRow();
            this.dieRollTextBox1 = new CharacterManager.UserControls.DieRollTextBox();
            this.customRTBDescription = new CharacterManager.Spells.CustomRTB();
            this.SuspendLayout();
            // 
            // labelAbilityName
            // 
            this.labelAbilityName.AutoSize = true;
            this.labelAbilityName.BackColor = System.Drawing.Color.Transparent;
            this.labelAbilityName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.labelAbilityName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelAbilityName.Location = new System.Drawing.Point(12, 21);
            this.labelAbilityName.Name = "labelAbilityName";
            this.labelAbilityName.Size = new System.Drawing.Size(148, 26);
            this.labelAbilityName.TabIndex = 1;
            this.labelAbilityName.Text = "Ability Name";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(575, 325);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelDice
            // 
            this.labelDice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDice.AutoSize = true;
            this.labelDice.BackColor = System.Drawing.Color.Transparent;
            this.labelDice.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelDice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDice.Location = new System.Drawing.Point(395, 31);
            this.labelDice.Name = "labelDice";
            this.labelDice.Size = new System.Drawing.Size(40, 19);
            this.labelDice.TabIndex = 4;
            this.labelDice.Text = "Dice";
            // 
            // richTextBoxDieRollResult
            // 
            this.richTextBoxDieRollResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDieRollResult.Location = new System.Drawing.Point(399, 60);
            this.richTextBoxDieRollResult.Name = "richTextBoxDieRollResult";
            this.richTextBoxDieRollResult.ReadOnly = true;
            this.richTextBoxDieRollResult.Size = new System.Drawing.Size(251, 96);
            this.richTextBoxDieRollResult.TabIndex = 5;
            this.richTextBoxDieRollResult.Text = "";
            // 
            // buttonRoll
            // 
            this.buttonRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRoll.Location = new System.Drawing.Point(592, 30);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(58, 20);
            this.buttonRoll.TabIndex = 6;
            this.buttonRoll.Text = "Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // userControlRemainingCharges
            // 
            this.userControlRemainingCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlRemainingCharges.BackColor = System.Drawing.Color.Transparent;
            this.userControlRemainingCharges.LabelName = "Remaining Charges";
            this.userControlRemainingCharges.Location = new System.Drawing.Point(12, 321);
            this.userControlRemainingCharges.Name = "userControlRemainingCharges";
            this.userControlRemainingCharges.NumberOfRemainingSlots = 0;
            this.userControlRemainingCharges.NumberOfSlots = 0;
            this.userControlRemainingCharges.Size = new System.Drawing.Size(251, 34);
            this.userControlRemainingCharges.SpellSlots = spellSlotData1;
            this.userControlRemainingCharges.TabIndex = 7;
            // 
            // dieRollTextBox1
            // 
            this.dieRollTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dieRollTextBox1.DieRollObject = null;
            this.dieRollTextBox1.Location = new System.Drawing.Point(441, 30);
            this.dieRollTextBox1.Name = "dieRollTextBox1";
            this.dieRollTextBox1.Size = new System.Drawing.Size(143, 20);
            this.dieRollTextBox1.TabIndex = 3;
            // 
            // customRTBDescription
            // 
            this.customRTBDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customRTBDescription.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.customRTBDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.customRTBDescription.Location = new System.Drawing.Point(12, 63);
            this.customRTBDescription.Name = "customRTBDescription";
            this.customRTBDescription.Size = new System.Drawing.Size(365, 252);
            this.customRTBDescription.TabIndex = 0;
            this.customRTBDescription.Text = "<Description>";
            // 
            // AbilityCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterManager.Properties.Resources.old_paper_texture;
            this.ClientSize = new System.Drawing.Size(662, 360);
            this.Controls.Add(this.userControlRemainingCharges);
            this.Controls.Add(this.buttonRoll);
            this.Controls.Add(this.richTextBoxDieRollResult);
            this.Controls.Add(this.labelDice);
            this.Controls.Add(this.dieRollTextBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelAbilityName);
            this.Controls.Add(this.customRTBDescription);
            this.Name = "AbilityCard";
            this.Text = "AbilityCard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Spells.CustomRTB customRTBDescription;
        private System.Windows.Forms.Label labelAbilityName;
        private System.Windows.Forms.Button buttonClose;
        private DieRollTextBox dieRollTextBox1;
        private System.Windows.Forms.Label labelDice;
        private System.Windows.Forms.RichTextBox richTextBoxDieRollResult;
        private System.Windows.Forms.Button buttonRoll;
        private UserControlSpellSlotRow userControlRemainingCharges;
    }
}