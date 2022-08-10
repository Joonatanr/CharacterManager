
namespace CharacterManager.UserControls
{
    partial class UserControlMagicHandler
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userControlSpellcastingAbility = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlSpellsaveDc = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlSpellAttackBonus = new CharacterManager.UserControls.UserControlGenericValue();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlCantripList = new CharacterManager.UserControls.UserControlSpellChoice();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.userControlKnownSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.userControlPreparedSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(860, 726);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SpellCasting";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.userControlSpellAttackBonus);
            this.groupBox2.Controls.Add(this.userControlSpellsaveDc);
            this.groupBox2.Controls.Add(this.userControlSpellcastingAbility);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // userControlSpellcastingAbility
            // 
            this.userControlSpellcastingAbility.IsBorder = true;
            this.userControlSpellcastingAbility.Label = "Spellcasting Ability";
            this.userControlSpellcastingAbility.Location = new System.Drawing.Point(6, 10);
            this.userControlSpellcastingAbility.Name = "userControlSpellcastingAbility";
            this.userControlSpellcastingAbility.Size = new System.Drawing.Size(128, 78);
            this.userControlSpellcastingAbility.TabIndex = 1;
            this.userControlSpellcastingAbility.Value = "INT";
            // 
            // userControlSpellsaveDc
            // 
            this.userControlSpellsaveDc.IsBorder = true;
            this.userControlSpellsaveDc.Label = "Spell DC";
            this.userControlSpellsaveDc.Location = new System.Drawing.Point(140, 10);
            this.userControlSpellsaveDc.Name = "userControlSpellsaveDc";
            this.userControlSpellsaveDc.Size = new System.Drawing.Size(128, 78);
            this.userControlSpellsaveDc.TabIndex = 2;
            this.userControlSpellsaveDc.Value = "8";
            // 
            // userControlSpellAttackBonus
            // 
            this.userControlSpellAttackBonus.IsBorder = true;
            this.userControlSpellAttackBonus.Label = "Spell Attack Bonus";
            this.userControlSpellAttackBonus.Location = new System.Drawing.Point(274, 10);
            this.userControlSpellAttackBonus.Name = "userControlSpellAttackBonus";
            this.userControlSpellAttackBonus.Size = new System.Drawing.Size(128, 78);
            this.userControlSpellAttackBonus.TabIndex = 3;
            this.userControlSpellAttackBonus.Value = "+0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlCantripList);
            this.panel1.Location = new System.Drawing.Point(6, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 192);
            this.panel1.TabIndex = 1;
            // 
            // userControlCantripList
            // 
            this.userControlCantripList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlCantripList.IsAvailabilityCount = false;
            this.userControlCantripList.IsBorder = true;
            this.userControlCantripList.IsCheckBoxed = false;
            this.userControlCantripList.IsMultipleLevel = false;
            this.userControlCantripList.Location = new System.Drawing.Point(5, 3);
            this.userControlCantripList.MaximumAvailableChoices = 0;
            this.userControlCantripList.Name = "userControlCantripList";
            this.userControlCantripList.Size = new System.Drawing.Size(239, 186);
            this.userControlCantripList.TabIndex = 0;
            this.userControlCantripList.TitleString = "Cantrips";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.userControlKnownSpells);
            this.panel2.Location = new System.Drawing.Point(256, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 528);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.userControlPreparedSpells);
            this.panel3.Location = new System.Drawing.Point(558, 119);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 528);
            this.panel3.TabIndex = 3;
            // 
            // userControlKnownSpells
            // 
            this.userControlKnownSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlKnownSpells.IsAvailabilityCount = false;
            this.userControlKnownSpells.IsBorder = true;
            this.userControlKnownSpells.IsCheckBoxed = true;
            this.userControlKnownSpells.IsMultipleLevel = true;
            this.userControlKnownSpells.Location = new System.Drawing.Point(3, 3);
            this.userControlKnownSpells.MaximumAvailableChoices = 0;
            this.userControlKnownSpells.Name = "userControlKnownSpells";
            this.userControlKnownSpells.Size = new System.Drawing.Size(290, 522);
            this.userControlKnownSpells.TabIndex = 0;
            this.userControlKnownSpells.TitleString = "Known Spells";
            // 
            // userControlPreparedSpells
            // 
            this.userControlPreparedSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPreparedSpells.IsAvailabilityCount = true;
            this.userControlPreparedSpells.IsBorder = true;
            this.userControlPreparedSpells.IsCheckBoxed = true;
            this.userControlPreparedSpells.IsMultipleLevel = false;
            this.userControlPreparedSpells.Location = new System.Drawing.Point(3, 3);
            this.userControlPreparedSpells.MaximumAvailableChoices = 0;
            this.userControlPreparedSpells.Name = "userControlPreparedSpells";
            this.userControlPreparedSpells.Size = new System.Drawing.Size(293, 522);
            this.userControlPreparedSpells.TabIndex = 1;
            this.userControlPreparedSpells.TitleString = "Prepared Spells";
            // 
            // UserControlMagicHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlMagicHandler";
            this.Size = new System.Drawing.Size(866, 732);
            this.Load += new System.EventHandler(this.UserControlMagicHandler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private UserControlGenericValue userControlSpellAttackBonus;
        private UserControlGenericValue userControlSpellsaveDc;
        private UserControlGenericValue userControlSpellcastingAbility;
        private System.Windows.Forms.Panel panel1;
        private UserControlSpellChoice userControlCantripList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private UserControlSpellChoice userControlKnownSpells;
        private UserControlSpellChoice userControlPreparedSpells;
    }
}
