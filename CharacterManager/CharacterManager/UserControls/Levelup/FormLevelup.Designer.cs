
namespace CharacterManager.UserControls
{
    partial class FormLevelup
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBoxHitPoints = new System.Windows.Forms.GroupBox();
            this.labelNewMaxHP = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHPResult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dieRollHitPointsRoll = new CharacterManager.UserControls.DieRollTextBox();
            this.groupBoxAbilities = new System.Windows.Forms.GroupBox();
            this.buttonSelectNewSpells = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlGenericAbilitiesList1 = new CharacterManager.UserControls.UserControlGenericAbilitiesList();
            this.buttonSelectNewAbilities = new System.Windows.Forms.Button();
            this.groupBoxAbilityScoreImprovement = new System.Windows.Forms.GroupBox();
            this.labelRemainingAttributePoints = new System.Windows.Forms.Label();
            this.numericUpDownCHA = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownINT = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownWIS = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCON = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDEX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownSTR = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLearnSkillProfs = new System.Windows.Forms.Button();
            this.groupBoxHitPoints.SuspendLayout();
            this.groupBoxAbilities.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxAbilityScoreImprovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSTR)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Next Level : 2";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(16, 645);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBoxHitPoints
            // 
            this.groupBoxHitPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxHitPoints.Controls.Add(this.labelNewMaxHP);
            this.groupBoxHitPoints.Controls.Add(this.label3);
            this.groupBoxHitPoints.Controls.Add(this.label2);
            this.groupBoxHitPoints.Controls.Add(this.textBoxHPResult);
            this.groupBoxHitPoints.Controls.Add(this.button1);
            this.groupBoxHitPoints.Controls.Add(this.dieRollHitPointsRoll);
            this.groupBoxHitPoints.Location = new System.Drawing.Point(12, 32);
            this.groupBoxHitPoints.Name = "groupBoxHitPoints";
            this.groupBoxHitPoints.Size = new System.Drawing.Size(600, 59);
            this.groupBoxHitPoints.TabIndex = 2;
            this.groupBoxHitPoints.TabStop = false;
            this.groupBoxHitPoints.Text = "Hit Points";
            // 
            // labelNewMaxHP
            // 
            this.labelNewMaxHP.AutoSize = true;
            this.labelNewMaxHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewMaxHP.Location = new System.Drawing.Point(389, 22);
            this.labelNewMaxHP.Name = "labelNewMaxHP";
            this.labelNewMaxHP.Size = new System.Drawing.Size(27, 20);
            this.labelNewMaxHP.TabIndex = 5;
            this.labelNewMaxHP.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max HP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // textBoxHPResult
            // 
            this.textBoxHPResult.Location = new System.Drawing.Point(242, 23);
            this.textBoxHPResult.Name = "textBoxHPResult";
            this.textBoxHPResult.Size = new System.Drawing.Size(71, 20);
            this.textBoxHPResult.TabIndex = 2;
            this.textBoxHPResult.TextChanged += new System.EventHandler(this.textBoxHPResult_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Roll HP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dieRollHitPointsRoll
            // 
            this.dieRollHitPointsRoll.DieRollObject = null;
            this.dieRollHitPointsRoll.Location = new System.Drawing.Point(72, 22);
            this.dieRollHitPointsRoll.Name = "dieRollHitPointsRoll";
            this.dieRollHitPointsRoll.ReadOnly = true;
            this.dieRollHitPointsRoll.Size = new System.Drawing.Size(100, 20);
            this.dieRollHitPointsRoll.TabIndex = 0;
            // 
            // groupBoxAbilities
            // 
            this.groupBoxAbilities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAbilities.Controls.Add(this.buttonLearnSkillProfs);
            this.groupBoxAbilities.Controls.Add(this.buttonSelectNewSpells);
            this.groupBoxAbilities.Controls.Add(this.panel1);
            this.groupBoxAbilities.Controls.Add(this.buttonSelectNewAbilities);
            this.groupBoxAbilities.Location = new System.Drawing.Point(12, 97);
            this.groupBoxAbilities.Name = "groupBoxAbilities";
            this.groupBoxAbilities.Size = new System.Drawing.Size(600, 194);
            this.groupBoxAbilities.TabIndex = 3;
            this.groupBoxAbilities.TabStop = false;
            this.groupBoxAbilities.Text = "Select new Features";
            // 
            // buttonSelectNewSpells
            // 
            this.buttonSelectNewSpells.Location = new System.Drawing.Point(7, 77);
            this.buttonSelectNewSpells.Name = "buttonSelectNewSpells";
            this.buttonSelectNewSpells.Size = new System.Drawing.Size(165, 52);
            this.buttonSelectNewSpells.TabIndex = 3;
            this.buttonSelectNewSpells.Text = "Learn new Spells";
            this.buttonSelectNewSpells.UseVisualStyleBackColor = true;
            this.buttonSelectNewSpells.Click += new System.EventHandler(this.buttonSelectNewSpells_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.userControlGenericAbilitiesList1);
            this.panel1.Location = new System.Drawing.Point(178, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(416, 173);
            this.panel1.TabIndex = 2;
            // 
            // userControlGenericAbilitiesList1
            // 
            this.userControlGenericAbilitiesList1.IsBorder = true;
            this.userControlGenericAbilitiesList1.IsSlotsVisible = false;
            this.userControlGenericAbilitiesList1.Location = new System.Drawing.Point(3, 3);
            this.userControlGenericAbilitiesList1.Name = "userControlGenericAbilitiesList1";
            this.userControlGenericAbilitiesList1.Size = new System.Drawing.Size(410, 167);
            this.userControlGenericAbilitiesList1.TabIndex = 1;
            this.userControlGenericAbilitiesList1.Title = "Abilities:";
            // 
            // buttonSelectNewAbilities
            // 
            this.buttonSelectNewAbilities.Location = new System.Drawing.Point(7, 19);
            this.buttonSelectNewAbilities.Name = "buttonSelectNewAbilities";
            this.buttonSelectNewAbilities.Size = new System.Drawing.Size(165, 52);
            this.buttonSelectNewAbilities.TabIndex = 0;
            this.buttonSelectNewAbilities.Text = "Select New Abilities";
            this.buttonSelectNewAbilities.UseVisualStyleBackColor = true;
            this.buttonSelectNewAbilities.Click += new System.EventHandler(this.buttonSelectNewAbilities_Click);
            // 
            // groupBoxAbilityScoreImprovement
            // 
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.labelRemainingAttributePoints);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownCHA);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label9);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownINT);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label8);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownWIS);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label7);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownCON);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label6);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownDEX);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label5);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.numericUpDownSTR);
            this.groupBoxAbilityScoreImprovement.Controls.Add(this.label4);
            this.groupBoxAbilityScoreImprovement.Location = new System.Drawing.Point(12, 297);
            this.groupBoxAbilityScoreImprovement.Name = "groupBoxAbilityScoreImprovement";
            this.groupBoxAbilityScoreImprovement.Size = new System.Drawing.Size(297, 209);
            this.groupBoxAbilityScoreImprovement.TabIndex = 4;
            this.groupBoxAbilityScoreImprovement.TabStop = false;
            this.groupBoxAbilityScoreImprovement.Text = "Ability Score Improvement";
            // 
            // labelRemainingAttributePoints
            // 
            this.labelRemainingAttributePoints.AutoSize = true;
            this.labelRemainingAttributePoints.Location = new System.Drawing.Point(8, 181);
            this.labelRemainingAttributePoints.Name = "labelRemainingAttributePoints";
            this.labelRemainingAttributePoints.Size = new System.Drawing.Size(104, 13);
            this.labelRemainingAttributePoints.TabIndex = 12;
            this.labelRemainingAttributePoints.Text = "Remaining Points : 0";
            // 
            // numericUpDownCHA
            // 
            this.numericUpDownCHA.Location = new System.Drawing.Point(50, 154);
            this.numericUpDownCHA.Name = "numericUpDownCHA";
            this.numericUpDownCHA.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCHA.TabIndex = 11;
            this.numericUpDownCHA.ValueChanged += new System.EventHandler(this.numericUpDownCHA_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label9.Location = new System.Drawing.Point(6, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "CHA";
            // 
            // numericUpDownINT
            // 
            this.numericUpDownINT.Location = new System.Drawing.Point(50, 128);
            this.numericUpDownINT.Name = "numericUpDownINT";
            this.numericUpDownINT.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownINT.TabIndex = 9;
            this.numericUpDownINT.ValueChanged += new System.EventHandler(this.numericUpDownINT_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label8.Location = new System.Drawing.Point(6, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "INT";
            // 
            // numericUpDownWIS
            // 
            this.numericUpDownWIS.Location = new System.Drawing.Point(50, 102);
            this.numericUpDownWIS.Name = "numericUpDownWIS";
            this.numericUpDownWIS.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWIS.TabIndex = 7;
            this.numericUpDownWIS.ValueChanged += new System.EventHandler(this.numericUpDownWIS_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label7.Location = new System.Drawing.Point(6, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "WIS";
            // 
            // numericUpDownCON
            // 
            this.numericUpDownCON.Location = new System.Drawing.Point(50, 76);
            this.numericUpDownCON.Name = "numericUpDownCON";
            this.numericUpDownCON.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCON.TabIndex = 5;
            this.numericUpDownCON.ValueChanged += new System.EventHandler(this.numericUpDownCON_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.Location = new System.Drawing.Point(6, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "CON";
            // 
            // numericUpDownDEX
            // 
            this.numericUpDownDEX.Location = new System.Drawing.Point(50, 50);
            this.numericUpDownDEX.Name = "numericUpDownDEX";
            this.numericUpDownDEX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDEX.TabIndex = 3;
            this.numericUpDownDEX.ValueChanged += new System.EventHandler(this.numericUpDownDEX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label5.Location = new System.Drawing.Point(6, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "DEX";
            // 
            // numericUpDownSTR
            // 
            this.numericUpDownSTR.Location = new System.Drawing.Point(50, 24);
            this.numericUpDownSTR.Name = "numericUpDownSTR";
            this.numericUpDownSTR.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSTR.TabIndex = 1;
            this.numericUpDownSTR.ValueChanged += new System.EventHandler(this.numericUpDownSTR_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "STR";
            // 
            // buttonLearnSkillProfs
            // 
            this.buttonLearnSkillProfs.Location = new System.Drawing.Point(7, 134);
            this.buttonLearnSkillProfs.Name = "buttonLearnSkillProfs";
            this.buttonLearnSkillProfs.Size = new System.Drawing.Size(165, 52);
            this.buttonLearnSkillProfs.TabIndex = 4;
            this.buttonLearnSkillProfs.Text = "Learn new Skill Proficiencies";
            this.buttonLearnSkillProfs.UseVisualStyleBackColor = true;
            this.buttonLearnSkillProfs.Click += new System.EventHandler(this.buttonLearnSkillProfs_Click);
            // 
            // FormLevelup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 680);
            this.Controls.Add(this.groupBoxAbilityScoreImprovement);
            this.Controls.Add(this.groupBoxAbilities);
            this.Controls.Add(this.groupBoxHitPoints);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Name = "FormLevelup";
            this.Text = "FormLevelup";
            this.groupBoxHitPoints.ResumeLayout(false);
            this.groupBoxHitPoints.PerformLayout();
            this.groupBoxAbilities.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBoxAbilityScoreImprovement.ResumeLayout(false);
            this.groupBoxAbilityScoreImprovement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownINT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSTR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBoxHitPoints;
        private DieRollTextBox dieRollHitPointsRoll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHPResult;
        private System.Windows.Forms.Label labelNewMaxHP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxAbilities;
        private System.Windows.Forms.Button buttonSelectNewAbilities;
        private UserControlGenericAbilitiesList userControlGenericAbilitiesList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSelectNewSpells;
        private System.Windows.Forms.GroupBox groupBoxAbilityScoreImprovement;
        private System.Windows.Forms.NumericUpDown numericUpDownCHA;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownINT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownWIS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDEX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownSTR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelRemainingAttributePoints;
        private System.Windows.Forms.Button buttonLearnSkillProfs;
    }
}