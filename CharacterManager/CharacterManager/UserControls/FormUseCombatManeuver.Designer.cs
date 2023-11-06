
namespace CharacterManager.UserControls
{
    partial class FormUseCombatManeuver
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxDice = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.userControlGenericValue1 = new CharacterManager.UserControls.UserControlGenericValue();
            this.dieRollTextBox1 = new CharacterManager.UserControls.DieRollTextBox();
            this.userControlSpellSlotRow1 = new CharacterManager.UserControls.UserControlSpellSlotRow();
            this.userControlManeuverChoice1 = new CharacterManager.UserControls.ChoiceList.UserControlManeuverChoice();
            this.panel1.SuspendLayout();
            this.groupBoxDice.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.userControlManeuverChoice1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 296);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxDice
            // 
            this.groupBoxDice.Controls.Add(this.textBox1);
            this.groupBoxDice.Controls.Add(this.richTextBox1);
            this.groupBoxDice.Controls.Add(this.buttonRoll);
            this.groupBoxDice.Controls.Add(this.dieRollTextBox1);
            this.groupBoxDice.Location = new System.Drawing.Point(293, 137);
            this.groupBoxDice.Name = "groupBoxDice";
            this.groupBoxDice.Size = new System.Drawing.Size(241, 171);
            this.groupBoxDice.TabIndex = 1;
            this.groupBoxDice.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(153, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 3;
            // 
            // buttonRoll
            // 
            this.buttonRoll.Location = new System.Drawing.Point(6, 19);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(75, 23);
            this.buttonRoll.TabIndex = 2;
            this.buttonRoll.Text = "Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 108);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // userControlGenericValue1
            // 
            this.userControlGenericValue1.IsBorder = true;
            this.userControlGenericValue1.Label = "Save DC";
            this.userControlGenericValue1.Location = new System.Drawing.Point(293, 15);
            this.userControlGenericValue1.Name = "userControlGenericValue1";
            this.userControlGenericValue1.Size = new System.Drawing.Size(241, 76);
            this.userControlGenericValue1.TabIndex = 3;
            this.userControlGenericValue1.Value = "0";
            // 
            // dieRollTextBox1
            // 
            this.dieRollTextBox1.DieRollObject = null;
            this.dieRollTextBox1.Location = new System.Drawing.Point(87, 22);
            this.dieRollTextBox1.Name = "dieRollTextBox1";
            this.dieRollTextBox1.Size = new System.Drawing.Size(60, 20);
            this.dieRollTextBox1.TabIndex = 1;
            // 
            // userControlSpellSlotRow1
            // 
            this.userControlSpellSlotRow1.LabelName = "Charges";
            this.userControlSpellSlotRow1.Location = new System.Drawing.Point(291, 97);
            this.userControlSpellSlotRow1.Name = "userControlSpellSlotRow1";
            this.userControlSpellSlotRow1.NumberOfRemainingSlots = 0;
            this.userControlSpellSlotRow1.NumberOfSlots = 0;
            this.userControlSpellSlotRow1.Size = new System.Drawing.Size(243, 34);
            this.userControlSpellSlotRow1.SpellSlots = spellSlotData1;
            this.userControlSpellSlotRow1.TabIndex = 0;
            // 
            // userControlManeuverChoice1
            // 
            this.userControlManeuverChoice1.IsAvailabilityCount = false;
            this.userControlManeuverChoice1.IsBorder = true;
            this.userControlManeuverChoice1.IsCheckBoxed = false;
            this.userControlManeuverChoice1.Location = new System.Drawing.Point(3, 3);
            this.userControlManeuverChoice1.MaximumAvailableChoices = 0;
            this.userControlManeuverChoice1.Name = "userControlManeuverChoice1";
            this.userControlManeuverChoice1.Size = new System.Drawing.Size(264, 290);
            this.userControlManeuverChoice1.TabIndex = 0;
            this.userControlManeuverChoice1.TitleString = "Maneuvers";
            // 
            // FormUseCombatManeuver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 320);
            this.Controls.Add(this.userControlGenericValue1);
            this.Controls.Add(this.groupBoxDice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControlSpellSlotRow1);
            this.Name = "FormUseCombatManeuver";
            this.Text = "FormUseCombatManeuver";
            this.panel1.ResumeLayout(false);
            this.groupBoxDice.ResumeLayout(false);
            this.groupBoxDice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ChoiceList.UserControlManeuverChoice userControlManeuverChoice1;
        private System.Windows.Forms.GroupBox groupBoxDice;
        private UserControlSpellSlotRow userControlSpellSlotRow1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonRoll;
        private DieRollTextBox dieRollTextBox1;
        private UserControlGenericValue userControlGenericValue1;
    }
}