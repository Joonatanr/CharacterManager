
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.userControlKnownSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.userControlPreparedSpells = new CharacterManager.UserControls.UserControlSpellChoice();
            this.userControlSpellSlotsArea1 = new CharacterManager.UserControls.UserControlSpellSlotsArea();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlCantripList = new CharacterManager.UserControls.UserControlSpellChoice();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userControlMaxPreparedSpells = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlSpellAttackBonus = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlSpellsaveDc = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlSpellcastingAbility = new CharacterManager.UserControls.UserControlGenericValue();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.userControlSpellSlotsArea1);
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(259, 119);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.userControlKnownSpells);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.userControlPreparedSpells);
            this.splitContainer1.Size = new System.Drawing.Size(600, 588);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 5;
            // 
            // userControlKnownSpells
            // 
            this.userControlKnownSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlKnownSpells.IsAvailabilityCount = true;
            this.userControlKnownSpells.IsBorder = true;
            this.userControlKnownSpells.IsCastingInfoEnabled = true;
            this.userControlKnownSpells.IsCheckBoxed = true;
            this.userControlKnownSpells.IsMultipleLevel = true;
            this.userControlKnownSpells.Location = new System.Drawing.Point(3, 3);
            this.userControlKnownSpells.MaximumAvailableChoices = 0;
            this.userControlKnownSpells.Name = "userControlKnownSpells";
            this.userControlKnownSpells.Size = new System.Drawing.Size(294, 582);
            this.userControlKnownSpells.TabIndex = 0;
            this.userControlKnownSpells.TitleString = "Known Spells";
            this.userControlKnownSpells.SpellSelectionChanged += new CharacterManager.UserControls.UserControlSpellChoice.SpellChoiceChangedListener(this.userControlKnownSpells_SpellSelectionChanged);
            // 
            // userControlPreparedSpells
            // 
            this.userControlPreparedSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPreparedSpells.IsAvailabilityCount = false;
            this.userControlPreparedSpells.IsBorder = true;
            this.userControlPreparedSpells.IsCastingInfoEnabled = false;
            this.userControlPreparedSpells.IsCheckBoxed = false;
            this.userControlPreparedSpells.IsMultipleLevel = false;
            this.userControlPreparedSpells.Location = new System.Drawing.Point(3, 3);
            this.userControlPreparedSpells.MaximumAvailableChoices = 0;
            this.userControlPreparedSpells.Name = "userControlPreparedSpells";
            this.userControlPreparedSpells.Size = new System.Drawing.Size(290, 582);
            this.userControlPreparedSpells.TabIndex = 1;
            this.userControlPreparedSpells.TitleString = "Prepared Spells";
            // 
            // userControlSpellSlotsArea1
            // 
            this.userControlSpellSlotsArea1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlSpellSlotsArea1.Location = new System.Drawing.Point(6, 355);
            this.userControlSpellSlotsArea1.Name = "userControlSpellSlotsArea1";
            this.userControlSpellSlotsArea1.Size = new System.Drawing.Size(244, 352);
            this.userControlSpellSlotsArea1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userControlCantripList);
            this.panel1.Location = new System.Drawing.Point(6, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(247, 230);
            this.panel1.TabIndex = 1;
            // 
            // userControlCantripList
            // 
            this.userControlCantripList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlCantripList.IsAvailabilityCount = false;
            this.userControlCantripList.IsBorder = true;
            this.userControlCantripList.IsCastingInfoEnabled = false;
            this.userControlCantripList.IsCheckBoxed = false;
            this.userControlCantripList.IsMultipleLevel = false;
            this.userControlCantripList.Location = new System.Drawing.Point(5, 3);
            this.userControlCantripList.MaximumAvailableChoices = 0;
            this.userControlCantripList.Name = "userControlCantripList";
            this.userControlCantripList.Size = new System.Drawing.Size(239, 224);
            this.userControlCantripList.TabIndex = 0;
            this.userControlCantripList.TitleString = "Cantrips";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.userControlMaxPreparedSpells);
            this.groupBox2.Controls.Add(this.userControlSpellAttackBonus);
            this.groupBox2.Controls.Add(this.userControlSpellsaveDc);
            this.groupBox2.Controls.Add(this.userControlSpellcastingAbility);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(848, 94);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // userControlMaxPreparedSpells
            // 
            this.userControlMaxPreparedSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlMaxPreparedSpells.IsBorder = true;
            this.userControlMaxPreparedSpells.Label = "Maximum Prepared Spells";
            this.userControlMaxPreparedSpells.Location = new System.Drawing.Point(681, 10);
            this.userControlMaxPreparedSpells.Name = "userControlMaxPreparedSpells";
            this.userControlMaxPreparedSpells.Size = new System.Drawing.Size(161, 78);
            this.userControlMaxPreparedSpells.TabIndex = 4;
            this.userControlMaxPreparedSpells.Value = "0";
            // 
            // userControlSpellAttackBonus
            // 
            this.userControlSpellAttackBonus.IsBorder = true;
            this.userControlSpellAttackBonus.Label = "Spell Attack Bonus";
            this.userControlSpellAttackBonus.Location = new System.Drawing.Point(296, 10);
            this.userControlSpellAttackBonus.Name = "userControlSpellAttackBonus";
            this.userControlSpellAttackBonus.Size = new System.Drawing.Size(132, 78);
            this.userControlSpellAttackBonus.TabIndex = 3;
            this.userControlSpellAttackBonus.Value = "+0";
            // 
            // userControlSpellsaveDc
            // 
            this.userControlSpellsaveDc.IsBorder = true;
            this.userControlSpellsaveDc.Label = "Spell DC";
            this.userControlSpellsaveDc.Location = new System.Drawing.Point(160, 10);
            this.userControlSpellsaveDc.Name = "userControlSpellsaveDc";
            this.userControlSpellsaveDc.Size = new System.Drawing.Size(130, 78);
            this.userControlSpellsaveDc.TabIndex = 2;
            this.userControlSpellsaveDc.Value = "8";
            // 
            // userControlSpellcastingAbility
            // 
            this.userControlSpellcastingAbility.IsBorder = true;
            this.userControlSpellcastingAbility.Label = "Spellcasting Ability";
            this.userControlSpellcastingAbility.Location = new System.Drawing.Point(6, 10);
            this.userControlSpellcastingAbility.Name = "userControlSpellcastingAbility";
            this.userControlSpellcastingAbility.Size = new System.Drawing.Size(148, 78);
            this.userControlSpellcastingAbility.TabIndex = 1;
            this.userControlSpellcastingAbility.Value = "INT";
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
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
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
        private UserControlSpellChoice userControlKnownSpells;
        private UserControlSpellChoice userControlPreparedSpells;
        private UserControlGenericValue userControlMaxPreparedSpells;
        private UserControlSpellSlotsArea userControlSpellSlotsArea1;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
