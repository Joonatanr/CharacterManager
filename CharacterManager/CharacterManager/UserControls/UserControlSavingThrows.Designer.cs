namespace CharacterManager.UserControls
{
    partial class UserControlSavingThrows
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userControlProficiencyCHA = new CharacterManager.UserControlProficiency();
            this.userControlProficiencyDEX = new CharacterManager.UserControlProficiency();
            this.userControlProficiencyWIS = new CharacterManager.UserControlProficiency();
            this.userControlProficiencyINT = new CharacterManager.UserControlProficiency();
            this.userControlProficiencyCON = new CharacterManager.UserControlProficiency();
            this.userControlProficiencySTR = new CharacterManager.UserControlProficiency();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userControlProficiencyCHA);
            this.groupBox2.Controls.Add(this.userControlProficiencyDEX);
            this.groupBox2.Controls.Add(this.userControlProficiencyWIS);
            this.groupBox2.Controls.Add(this.userControlProficiencyINT);
            this.groupBox2.Controls.Add(this.userControlProficiencyCON);
            this.groupBox2.Controls.Add(this.userControlProficiencySTR);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(157, 185);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Saving throws";
            // 
            // userControlProficiencyCHA
            // 
            this.userControlProficiencyCHA.Location = new System.Drawing.Point(3, 152);
            this.userControlProficiencyCHA.Name = "userControlProficiencyCHA";
            this.userControlProficiencyCHA.ProficiencyBaseSkill = null;
            this.userControlProficiencyCHA.ProficiencyName = "CHA";
            this.userControlProficiencyCHA.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencyCHA.TabIndex = 3;
            // 
            // userControlProficiencyDEX
            // 
            this.userControlProficiencyDEX.Location = new System.Drawing.Point(3, 71);
            this.userControlProficiencyDEX.Name = "userControlProficiencyDEX";
            this.userControlProficiencyDEX.ProficiencyBaseSkill = null;
            this.userControlProficiencyDEX.ProficiencyName = "DEX";
            this.userControlProficiencyDEX.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencyDEX.TabIndex = 2;
            // 
            // userControlProficiencyWIS
            // 
            this.userControlProficiencyWIS.Location = new System.Drawing.Point(3, 125);
            this.userControlProficiencyWIS.Name = "userControlProficiencyWIS";
            this.userControlProficiencyWIS.ProficiencyBaseSkill = null;
            this.userControlProficiencyWIS.ProficiencyName = "WIS";
            this.userControlProficiencyWIS.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencyWIS.TabIndex = 4;
            // 
            // userControlProficiencyINT
            // 
            this.userControlProficiencyINT.Location = new System.Drawing.Point(3, 44);
            this.userControlProficiencyINT.Name = "userControlProficiencyINT";
            this.userControlProficiencyINT.ProficiencyBaseSkill = null;
            this.userControlProficiencyINT.ProficiencyName = "INT";
            this.userControlProficiencyINT.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencyINT.TabIndex = 1;
            // 
            // userControlProficiencyCON
            // 
            this.userControlProficiencyCON.Location = new System.Drawing.Point(3, 98);
            this.userControlProficiencyCON.Name = "userControlProficiencyCON";
            this.userControlProficiencyCON.ProficiencyBaseSkill = null;
            this.userControlProficiencyCON.ProficiencyName = "CON";
            this.userControlProficiencyCON.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencyCON.TabIndex = 5;
            // 
            // userControlProficiencySTR
            // 
            this.userControlProficiencySTR.Location = new System.Drawing.Point(3, 17);
            this.userControlProficiencySTR.Name = "userControlProficiencySTR";
            this.userControlProficiencySTR.ProficiencyBaseSkill = null;
            this.userControlProficiencySTR.ProficiencyName = "STR";
            this.userControlProficiencySTR.Size = new System.Drawing.Size(151, 26);
            this.userControlProficiencySTR.TabIndex = 0;
            // 
            // UserControlSavingThrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "UserControlSavingThrows";
            this.Size = new System.Drawing.Size(166, 193);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private UserControlProficiency userControlProficiencyCHA;
        private UserControlProficiency userControlProficiencyDEX;
        private UserControlProficiency userControlProficiencyWIS;
        private UserControlProficiency userControlProficiencyINT;
        private UserControlProficiency userControlProficiencyCON;
        private UserControlProficiency userControlProficiencySTR;
    }
}
