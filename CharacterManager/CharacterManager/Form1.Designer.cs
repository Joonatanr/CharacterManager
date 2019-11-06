namespace CharacterManager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageCharacter = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBoxPerception = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.userControlSkillProficiencies1 = new CharacterManager.UserControls.UserControlSkillProficiencies();
            this.textBoxProfBonus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userControlSavingThrows1 = new CharacterManager.UserControls.UserControlSavingThrows();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AttributeDisplayCHA = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayWIS = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayDEX = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayCON = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplaySTR = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayINT = new CharacterManager.UserControlAttributeDisplay();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxRace = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddXp = new System.Windows.Forms.Button();
            this.textBoxXP = new System.Windows.Forms.TextBox();
            this.textBoxAlignment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageMagic = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCharacter.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(10, 49);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(143, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Character Name";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1048, 927);
            this.toolStripContainer1.ContentPanel.Load += new System.EventHandler(this.toolStripContainer1_ContentPanel_Load);
            this.toolStripContainer1.Location = new System.Drawing.Point(12, 12);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1048, 952);
            this.toolStripContainer1.TabIndex = 14;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPageCharacter);
            this.tabControl1.Controls.Add(this.tabPageMagic);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 921);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPageCharacter
            // 
            this.tabPageCharacter.Controls.Add(this.richTextBox1);
            this.tabPageCharacter.Controls.Add(this.textBoxPerception);
            this.tabPageCharacter.Controls.Add(this.label8);
            this.tabPageCharacter.Controls.Add(this.userControlSkillProficiencies1);
            this.tabPageCharacter.Controls.Add(this.textBoxProfBonus);
            this.tabPageCharacter.Controls.Add(this.label6);
            this.tabPageCharacter.Controls.Add(this.userControlSavingThrows1);
            this.tabPageCharacter.Controls.Add(this.groupBox3);
            this.tabPageCharacter.Controls.Add(this.groupBox1);
            this.tabPageCharacter.Location = new System.Drawing.Point(4, 4);
            this.tabPageCharacter.Name = "tabPageCharacter";
            this.tabPageCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCharacter.Size = new System.Drawing.Size(1034, 895);
            this.tabPageCharacter.TabIndex = 0;
            this.tabPageCharacter.Text = "Character";
            this.tabPageCharacter.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(547, 729);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(469, 142);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            // 
            // textBoxPerception
            // 
            this.textBoxPerception.Location = new System.Drawing.Point(557, 628);
            this.textBoxPerception.Name = "textBoxPerception";
            this.textBoxPerception.ReadOnly = true;
            this.textBoxPerception.Size = new System.Drawing.Size(61, 20);
            this.textBoxPerception.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(354, 630);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Passive Wisdom(Perception)";
            // 
            // userControlSkillProficiencies1
            // 
            this.userControlSkillProficiencies1.isSetDataVisible = false;
            this.userControlSkillProficiencies1.Location = new System.Drawing.Point(357, 98);
            this.userControlSkillProficiencies1.Name = "userControlSkillProficiencies1";
            this.userControlSkillProficiencies1.Size = new System.Drawing.Size(276, 529);
            this.userControlSkillProficiencies1.TabIndex = 25;
            // 
            // textBoxProfBonus
            // 
            this.textBoxProfBonus.Location = new System.Drawing.Point(311, 107);
            this.textBoxProfBonus.Name = "textBoxProfBonus";
            this.textBoxProfBonus.ReadOnly = true;
            this.textBoxProfBonus.Size = new System.Drawing.Size(32, 20);
            this.textBoxProfBonus.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(188, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Proficiency Bonus";
            // 
            // userControlSavingThrows1
            // 
            this.userControlSavingThrows1.Location = new System.Drawing.Point(185, 128);
            this.userControlSavingThrows1.Name = "userControlSavingThrows1";
            this.userControlSavingThrows1.Size = new System.Drawing.Size(166, 193);
            this.userControlSavingThrows1.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AttributeDisplayCHA);
            this.groupBox3.Controls.Add(this.AttributeDisplaySTR);
            this.groupBox3.Controls.Add(this.AttributeDisplayINT);
            this.groupBox3.Controls.Add(this.AttributeDisplayWIS);
            this.groupBox3.Controls.Add(this.AttributeDisplayDEX);
            this.groupBox3.Controls.Add(this.AttributeDisplayCON);
            this.groupBox3.Location = new System.Drawing.Point(9, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 582);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base attributes";
            // 
            // AttributeDisplayCHA
            // 
            this.AttributeDisplayCHA.AttributeName = "CHARISMA";
            this.AttributeDisplayCHA.AttributeValue = 0;
            this.AttributeDisplayCHA.Location = new System.Drawing.Point(12, 486);
            this.AttributeDisplayCHA.Name = "AttributeDisplayCHA";
            this.AttributeDisplayCHA.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplayCHA.TabIndex = 13;
            // 
            // AttributeDisplayWIS
            // 
            this.AttributeDisplayWIS.AttributeName = "WISDOM";
            this.AttributeDisplayWIS.AttributeValue = 0;
            this.AttributeDisplayWIS.Location = new System.Drawing.Point(12, 392);
            this.AttributeDisplayWIS.Name = "AttributeDisplayWIS";
            this.AttributeDisplayWIS.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplayWIS.TabIndex = 12;
            // 
            // AttributeDisplayDEX
            // 
            this.AttributeDisplayDEX.AttributeName = "DEXTERITY";
            this.AttributeDisplayDEX.AttributeValue = 0;
            this.AttributeDisplayDEX.Location = new System.Drawing.Point(12, 204);
            this.AttributeDisplayDEX.Name = "AttributeDisplayDEX";
            this.AttributeDisplayDEX.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplayDEX.TabIndex = 10;
            // 
            // AttributeDisplayCON
            // 
            this.AttributeDisplayCON.AttributeName = "CONSTITUTION";
            this.AttributeDisplayCON.AttributeValue = 0;
            this.AttributeDisplayCON.Location = new System.Drawing.Point(12, 298);
            this.AttributeDisplayCON.Name = "AttributeDisplayCON";
            this.AttributeDisplayCON.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplayCON.TabIndex = 11;
            // 
            // AttributeDisplaySTR
            // 
            this.AttributeDisplaySTR.AttributeName = "STRENGTH";
            this.AttributeDisplaySTR.AttributeValue = 0;
            this.AttributeDisplaySTR.Location = new System.Drawing.Point(12, 16);
            this.AttributeDisplaySTR.Name = "AttributeDisplaySTR";
            this.AttributeDisplaySTR.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplaySTR.TabIndex = 8;
            // 
            // AttributeDisplayINT
            // 
            this.AttributeDisplayINT.AttributeName = "INTELLIGENCE";
            this.AttributeDisplayINT.AttributeValue = 0;
            this.AttributeDisplayINT.Location = new System.Drawing.Point(12, 110);
            this.AttributeDisplayINT.Name = "AttributeDisplayINT";
            this.AttributeDisplayINT.Size = new System.Drawing.Size(109, 90);
            this.AttributeDisplayINT.TabIndex = 9;
            this.AttributeDisplayINT.Load += new System.EventHandler(this.AttributeDisplayINT_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 86);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Character Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxRace);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.buttonAddXp);
            this.groupBox2.Controls.Add(this.textBoxXP);
            this.groupBox2.Controls.Add(this.textBoxAlignment);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxLevel);
            this.groupBox2.Controls.Add(this.textBoxClass);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(170, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(846, 69);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // textBoxRace
            // 
            this.textBoxRace.Location = new System.Drawing.Point(209, 15);
            this.textBoxRace.Name = "textBoxRace";
            this.textBoxRace.ReadOnly = true;
            this.textBoxRace.Size = new System.Drawing.Size(101, 20);
            this.textBoxRace.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(162, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Race";
            // 
            // buttonAddXp
            // 
            this.buttonAddXp.Location = new System.Drawing.Point(782, 37);
            this.buttonAddXp.Name = "buttonAddXp";
            this.buttonAddXp.Size = new System.Drawing.Size(58, 23);
            this.buttonAddXp.TabIndex = 22;
            this.buttonAddXp.Text = "Add XP";
            this.buttonAddXp.UseVisualStyleBackColor = true;
            // 
            // textBoxXP
            // 
            this.textBoxXP.Location = new System.Drawing.Point(675, 40);
            this.textBoxXP.Name = "textBoxXP";
            this.textBoxXP.ReadOnly = true;
            this.textBoxXP.Size = new System.Drawing.Size(101, 20);
            this.textBoxXP.TabIndex = 21;
            // 
            // textBoxAlignment
            // 
            this.textBoxAlignment.Location = new System.Drawing.Point(675, 15);
            this.textBoxAlignment.Name = "textBoxAlignment";
            this.textBoxAlignment.ReadOnly = true;
            this.textBoxAlignment.Size = new System.Drawing.Size(101, 20);
            this.textBoxAlignment.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(537, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Experience Points";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(537, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Alignment";
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.Location = new System.Drawing.Point(54, 40);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.ReadOnly = true;
            this.textBoxLevel.Size = new System.Drawing.Size(101, 20);
            this.textBoxLevel.TabIndex = 17;
            // 
            // textBoxClass
            // 
            this.textBoxClass.Location = new System.Drawing.Point(54, 15);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.ReadOnly = true;
            this.textBoxClass.Size = new System.Drawing.Size(101, 20);
            this.textBoxClass.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(6, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Class";
            // 
            // tabPageMagic
            // 
            this.tabPageMagic.Location = new System.Drawing.Point(4, 4);
            this.tabPageMagic.Name = "tabPageMagic";
            this.tabPageMagic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMagic.Size = new System.Drawing.Size(1034, 895);
            this.tabPageMagic.TabIndex = 1;
            this.tabPageMagic.Text = "Magic";
            this.tabPageMagic.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtonSave,
            this.toolStripButtonLoad});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(119, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonNew.Image")));
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonNew.Text = "New";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(35, 22);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.toolStripButtonSave_Click);
            // 
            // toolStripButtonLoad
            // 
            this.toolStripButtonLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoad.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoad.Image")));
            this.toolStripButtonLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoad.Name = "toolStripButtonLoad";
            this.toolStripButtonLoad.Size = new System.Drawing.Size(37, 22);
            this.toolStripButtonLoad.Text = "Load";
            this.toolStripButtonLoad.Click += new System.EventHandler(this.toolStripButtonLoad_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 976);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Character Manager - 5e";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCharacter.ResumeLayout(false);
            this.tabPageCharacter.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private UserControlAttributeDisplay AttributeDisplaySTR;
        private UserControlAttributeDisplay AttributeDisplayINT;
        private UserControlAttributeDisplay AttributeDisplayDEX;
        private UserControlAttributeDisplay AttributeDisplayCON;
        private UserControlAttributeDisplay AttributeDisplayWIS;
        private UserControlAttributeDisplay AttributeDisplayCHA;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCharacter;
        private System.Windows.Forms.TabPage tabPageMagic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.TextBox textBoxXP;
        private System.Windows.Forms.TextBox textBoxAlignment;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddXp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxProfBonus;
        private System.Windows.Forms.Label label6;
        private UserControls.UserControlSavingThrows userControlSavingThrows1;
        private System.Windows.Forms.TextBox textBoxRace;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private UserControls.UserControlSkillProficiencies userControlSkillProficiencies1;
        private System.Windows.Forms.TextBox textBoxPerception;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

