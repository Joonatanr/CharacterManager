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
            this.buttonShortRest = new System.Windows.Forms.Button();
            this.buttonLongRest = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonHeal = new System.Windows.Forms.Button();
            this.buttonRegisterDamage = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBoxPerception = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxProfBonus = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabPageMagic = new System.Windows.Forms.TabPage();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoad = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.userControlEquipmentHandler1 = new CharacterManager.UserControls.UserControlEquipmentHandler();
            this.userControlArmorHandler1 = new CharacterManager.UserControls.UserControlArmorHandler();
            this.userControlWeaponsHandler1 = new CharacterManager.UserControls.UserControlWeaponsHandler();
            this.userControlGenericAbilitiesList1 = new CharacterManager.UserControls.UserControlGenericAbilitiesList();
            this.userControlSpeed = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlInitiative = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlArmorClass = new CharacterManager.UserControls.UserControlGenericValue();
            this.userControlHitPoints1 = new CharacterManager.UserControls.UserControlHitPoints();
            this.userControlSkillProficiencies1 = new CharacterManager.UserControls.UserControlSkillProficiencies();
            this.userControlSavingThrows1 = new CharacterManager.UserControls.UserControlSavingThrows();
            this.AttributeDisplayCHA = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplaySTR = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayINT = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayWIS = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayDEX = new CharacterManager.UserControlAttributeDisplay();
            this.AttributeDisplayCON = new CharacterManager.UserControlAttributeDisplay();
            this.userControlMagicHandler1 = new CharacterManager.UserControls.UserControlMagicHandler();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageCharacter.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageMagic.SuspendLayout();
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
            this.toolStripContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.groupBox1);
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageCharacter);
            this.tabControl1.Controls.Add(this.tabPageMagic);
            this.tabControl1.Location = new System.Drawing.Point(3, 94);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 830);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPageCharacter
            // 
            this.tabPageCharacter.BackColor = System.Drawing.Color.White;
            this.tabPageCharacter.Controls.Add(this.buttonShortRest);
            this.tabPageCharacter.Controls.Add(this.buttonLongRest);
            this.tabPageCharacter.Controls.Add(this.userControlEquipmentHandler1);
            this.tabPageCharacter.Controls.Add(this.userControlArmorHandler1);
            this.tabPageCharacter.Controls.Add(this.userControlWeaponsHandler1);
            this.tabPageCharacter.Controls.Add(this.userControlGenericAbilitiesList1);
            this.tabPageCharacter.Controls.Add(this.groupBox4);
            this.tabPageCharacter.Controls.Add(this.richTextBox1);
            this.tabPageCharacter.Controls.Add(this.textBoxPerception);
            this.tabPageCharacter.Controls.Add(this.label8);
            this.tabPageCharacter.Controls.Add(this.userControlSkillProficiencies1);
            this.tabPageCharacter.Controls.Add(this.textBoxProfBonus);
            this.tabPageCharacter.Controls.Add(this.label6);
            this.tabPageCharacter.Controls.Add(this.userControlSavingThrows1);
            this.tabPageCharacter.Controls.Add(this.groupBox3);
            this.tabPageCharacter.Location = new System.Drawing.Point(4, 4);
            this.tabPageCharacter.Name = "tabPageCharacter";
            this.tabPageCharacter.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCharacter.Size = new System.Drawing.Size(1034, 804);
            this.tabPageCharacter.TabIndex = 0;
            this.tabPageCharacter.Text = "Character";
            // 
            // buttonShortRest
            // 
            this.buttonShortRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonShortRest.Location = new System.Drawing.Point(734, 494);
            this.buttonShortRest.Name = "buttonShortRest";
            this.buttonShortRest.Size = new System.Drawing.Size(100, 39);
            this.buttonShortRest.TabIndex = 35;
            this.buttonShortRest.Text = "Short Rest";
            this.buttonShortRest.UseVisualStyleBackColor = true;
            this.buttonShortRest.Click += new System.EventHandler(this.buttonShortRest_Click);
            // 
            // buttonLongRest
            // 
            this.buttonLongRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonLongRest.Location = new System.Drawing.Point(734, 449);
            this.buttonLongRest.Name = "buttonLongRest";
            this.buttonLongRest.Size = new System.Drawing.Size(100, 39);
            this.buttonLongRest.TabIndex = 34;
            this.buttonLongRest.Text = "Long Rest";
            this.buttonLongRest.UseVisualStyleBackColor = true;
            this.buttonLongRest.Click += new System.EventHandler(this.buttonLongRest_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonHeal);
            this.groupBox4.Controls.Add(this.buttonRegisterDamage);
            this.groupBox4.Controls.Add(this.userControlSpeed);
            this.groupBox4.Controls.Add(this.userControlInitiative);
            this.groupBox4.Controls.Add(this.userControlArmorClass);
            this.groupBox4.Controls.Add(this.userControlHitPoints1);
            this.groupBox4.Location = new System.Drawing.Point(417, 29);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(311, 172);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            // 
            // buttonHeal
            // 
            this.buttonHeal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonHeal.Location = new System.Drawing.Point(184, 127);
            this.buttonHeal.Name = "buttonHeal";
            this.buttonHeal.Size = new System.Drawing.Size(80, 35);
            this.buttonHeal.TabIndex = 33;
            this.buttonHeal.Text = "Heal";
            this.buttonHeal.UseVisualStyleBackColor = true;
            this.buttonHeal.Click += new System.EventHandler(this.buttonHeal_Click);
            // 
            // buttonRegisterDamage
            // 
            this.buttonRegisterDamage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.buttonRegisterDamage.Location = new System.Drawing.Point(184, 83);
            this.buttonRegisterDamage.Name = "buttonRegisterDamage";
            this.buttonRegisterDamage.Size = new System.Drawing.Size(80, 42);
            this.buttonRegisterDamage.TabIndex = 32;
            this.buttonRegisterDamage.Text = "Register Damage";
            this.buttonRegisterDamage.UseVisualStyleBackColor = true;
            this.buttonRegisterDamage.Click += new System.EventHandler(this.buttonRegisterDamage_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(742, 633);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(268, 142);
            this.richTextBox1.TabIndex = 27;
            this.richTextBox1.Text = "";
            // 
            // textBoxPerception
            // 
            this.textBoxPerception.Location = new System.Drawing.Point(216, 722);
            this.textBoxPerception.Name = "textBoxPerception";
            this.textBoxPerception.ReadOnly = true;
            this.textBoxPerception.Size = new System.Drawing.Size(61, 20);
            this.textBoxPerception.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(13, 724);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(190, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Passive Wisdom(Perception)";
            // 
            // textBoxProfBonus
            // 
            this.textBoxProfBonus.Location = new System.Drawing.Point(279, 10);
            this.textBoxProfBonus.Name = "textBoxProfBonus";
            this.textBoxProfBonus.ReadOnly = true;
            this.textBoxProfBonus.Size = new System.Drawing.Size(32, 20);
            this.textBoxProfBonus.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(156, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Proficiency Bonus";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AttributeDisplayCHA);
            this.groupBox3.Controls.Add(this.AttributeDisplaySTR);
            this.groupBox3.Controls.Add(this.AttributeDisplayINT);
            this.groupBox3.Controls.Add(this.AttributeDisplayWIS);
            this.groupBox3.Controls.Add(this.AttributeDisplayDEX);
            this.groupBox3.Controls.Add(this.AttributeDisplayCON);
            this.groupBox3.Location = new System.Drawing.Point(9, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(140, 715);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Base attributes";
            // 
            // tabPageMagic
            // 
            this.tabPageMagic.Controls.Add(this.userControlMagicHandler1);
            this.tabPageMagic.Location = new System.Drawing.Point(4, 4);
            this.tabPageMagic.Name = "tabPageMagic";
            this.tabPageMagic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMagic.Size = new System.Drawing.Size(1034, 804);
            this.tabPageMagic.TabIndex = 1;
            this.tabPageMagic.Text = "Magic";
            this.tabPageMagic.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1022, 86);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Character Data";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.buttonAddXp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddXp.Location = new System.Drawing.Point(782, 37);
            this.buttonAddXp.Name = "buttonAddXp";
            this.buttonAddXp.Size = new System.Drawing.Size(58, 23);
            this.buttonAddXp.TabIndex = 22;
            this.buttonAddXp.Text = "Add XP";
            this.buttonAddXp.UseVisualStyleBackColor = true;
            // 
            // textBoxXP
            // 
            this.textBoxXP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxXP.Location = new System.Drawing.Point(675, 40);
            this.textBoxXP.Name = "textBoxXP";
            this.textBoxXP.ReadOnly = true;
            this.textBoxXP.Size = new System.Drawing.Size(101, 20);
            this.textBoxXP.TabIndex = 21;
            // 
            // textBoxAlignment
            // 
            this.textBoxAlignment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAlignment.Location = new System.Drawing.Point(675, 15);
            this.textBoxAlignment.Name = "textBoxAlignment";
            this.textBoxAlignment.ReadOnly = true;
            this.textBoxAlignment.Size = new System.Drawing.Size(101, 20);
            this.textBoxAlignment.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            // userControlEquipmentHandler1
            // 
            this.userControlEquipmentHandler1.IsBorder = true;
            this.userControlEquipmentHandler1.Location = new System.Drawing.Point(417, 519);
            this.userControlEquipmentHandler1.Name = "userControlEquipmentHandler1";
            this.userControlEquipmentHandler1.Size = new System.Drawing.Size(311, 279);
            this.userControlEquipmentHandler1.TabIndex = 33;
            // 
            // userControlArmorHandler1
            // 
            this.userControlArmorHandler1.IsBorder = true;
            this.userControlArmorHandler1.Location = new System.Drawing.Point(417, 387);
            this.userControlArmorHandler1.Name = "userControlArmorHandler1";
            this.userControlArmorHandler1.Size = new System.Drawing.Size(311, 128);
            this.userControlArmorHandler1.TabIndex = 32;
            // 
            // userControlWeaponsHandler1
            // 
            this.userControlWeaponsHandler1.IsBorder = true;
            this.userControlWeaponsHandler1.Location = new System.Drawing.Point(417, 207);
            this.userControlWeaponsHandler1.Name = "userControlWeaponsHandler1";
            this.userControlWeaponsHandler1.Size = new System.Drawing.Size(311, 174);
            this.userControlWeaponsHandler1.TabIndex = 31;
            this.userControlWeaponsHandler1.WeaponAttackEvent += new CharacterManager.UserControls.UserControlWeaponsHandler.weaponEventHandler(this.userControlWeaponsHandler1_WeaponAttackEvent);
            this.userControlWeaponsHandler1.WeaponEquipEvent += new CharacterManager.UserControls.UserControlWeaponsHandler.weaponEventHandler(this.userControlWeaponsHandler1_WeaponEquipEvent);
            // 
            // userControlGenericAbilitiesList1
            // 
            this.userControlGenericAbilitiesList1.IsBorder = true;
            this.userControlGenericAbilitiesList1.IsSlotsVisible = true;
            this.userControlGenericAbilitiesList1.Location = new System.Drawing.Point(734, 29);
            this.userControlGenericAbilitiesList1.Name = "userControlGenericAbilitiesList1";
            this.userControlGenericAbilitiesList1.Size = new System.Drawing.Size(288, 409);
            this.userControlGenericAbilitiesList1.TabIndex = 30;
            this.userControlGenericAbilitiesList1.PlayerAbilityUsed += new CharacterManager.UserControls.UserControlGenericAbilitiesList.PlayerAbilityUseHandler(this.userControlGenericAbilitiesList1_PlayerAbilityUsed);
            // 
            // userControlSpeed
            // 
            this.userControlSpeed.IsBorder = true;
            this.userControlSpeed.Label = "Speed";
            this.userControlSpeed.Location = new System.Drawing.Point(184, 19);
            this.userControlSpeed.Name = "userControlSpeed";
            this.userControlSpeed.Size = new System.Drawing.Size(80, 58);
            this.userControlSpeed.TabIndex = 31;
            this.userControlSpeed.Value = "0";
            // 
            // userControlInitiative
            // 
            this.userControlInitiative.IsBorder = true;
            this.userControlInitiative.Label = "Initiative";
            this.userControlInitiative.Location = new System.Drawing.Point(99, 19);
            this.userControlInitiative.Name = "userControlInitiative";
            this.userControlInitiative.Size = new System.Drawing.Size(80, 58);
            this.userControlInitiative.TabIndex = 30;
            this.userControlInitiative.Value = "0";
            // 
            // userControlArmorClass
            // 
            this.userControlArmorClass.IsBorder = true;
            this.userControlArmorClass.Label = "Armor Class";
            this.userControlArmorClass.Location = new System.Drawing.Point(14, 19);
            this.userControlArmorClass.Name = "userControlArmorClass";
            this.userControlArmorClass.Size = new System.Drawing.Size(80, 58);
            this.userControlArmorClass.TabIndex = 29;
            this.userControlArmorClass.Value = "0";
            // 
            // userControlHitPoints1
            // 
            this.userControlHitPoints1.CurrentHitPoints = 10;
            this.userControlHitPoints1.IsBorder = true;
            this.userControlHitPoints1.Location = new System.Drawing.Point(14, 83);
            this.userControlHitPoints1.Name = "userControlHitPoints1";
            this.userControlHitPoints1.Size = new System.Drawing.Size(156, 83);
            this.userControlHitPoints1.TabIndex = 28;
            // 
            // userControlSkillProficiencies1
            // 
            this.userControlSkillProficiencies1.isSetDataVisible = false;
            this.userControlSkillProficiencies1.Location = new System.Drawing.Point(153, 201);
            this.userControlSkillProficiencies1.Name = "userControlSkillProficiencies1";
            this.userControlSkillProficiencies1.Size = new System.Drawing.Size(261, 515);
            this.userControlSkillProficiencies1.TabIndex = 25;
            // 
            // userControlSavingThrows1
            // 
            this.userControlSavingThrows1.Location = new System.Drawing.Point(154, 26);
            this.userControlSavingThrows1.Name = "userControlSavingThrows1";
            this.userControlSavingThrows1.Size = new System.Drawing.Size(262, 178);
            this.userControlSavingThrows1.TabIndex = 16;
            // 
            // AttributeDisplayCHA
            // 
            this.AttributeDisplayCHA.AttributeName = "CHARISMA";
            this.AttributeDisplayCHA.AttributeValue = 0;
            this.AttributeDisplayCHA.Location = new System.Drawing.Point(12, 596);
            this.AttributeDisplayCHA.Name = "AttributeDisplayCHA";
            this.AttributeDisplayCHA.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplayCHA.TabIndex = 13;
            // 
            // AttributeDisplaySTR
            // 
            this.AttributeDisplaySTR.AttributeName = "STRENGTH";
            this.AttributeDisplaySTR.AttributeValue = 0;
            this.AttributeDisplaySTR.Location = new System.Drawing.Point(12, 16);
            this.AttributeDisplaySTR.Name = "AttributeDisplaySTR";
            this.AttributeDisplaySTR.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplaySTR.TabIndex = 8;
            // 
            // AttributeDisplayINT
            // 
            this.AttributeDisplayINT.AttributeName = "INTELLIGENCE";
            this.AttributeDisplayINT.AttributeValue = 0;
            this.AttributeDisplayINT.Location = new System.Drawing.Point(12, 132);
            this.AttributeDisplayINT.Name = "AttributeDisplayINT";
            this.AttributeDisplayINT.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplayINT.TabIndex = 9;
            this.AttributeDisplayINT.Load += new System.EventHandler(this.AttributeDisplayINT_Load);
            // 
            // AttributeDisplayWIS
            // 
            this.AttributeDisplayWIS.AttributeName = "WISDOM";
            this.AttributeDisplayWIS.AttributeValue = 0;
            this.AttributeDisplayWIS.Location = new System.Drawing.Point(12, 480);
            this.AttributeDisplayWIS.Name = "AttributeDisplayWIS";
            this.AttributeDisplayWIS.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplayWIS.TabIndex = 12;
            // 
            // AttributeDisplayDEX
            // 
            this.AttributeDisplayDEX.AttributeName = "DEXTERITY";
            this.AttributeDisplayDEX.AttributeValue = 0;
            this.AttributeDisplayDEX.Location = new System.Drawing.Point(12, 248);
            this.AttributeDisplayDEX.Name = "AttributeDisplayDEX";
            this.AttributeDisplayDEX.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplayDEX.TabIndex = 10;
            // 
            // AttributeDisplayCON
            // 
            this.AttributeDisplayCON.AttributeName = "CONSTITUTION";
            this.AttributeDisplayCON.AttributeValue = 0;
            this.AttributeDisplayCON.Location = new System.Drawing.Point(12, 364);
            this.AttributeDisplayCON.Name = "AttributeDisplayCON";
            this.AttributeDisplayCON.Size = new System.Drawing.Size(109, 116);
            this.AttributeDisplayCON.TabIndex = 11;
            // 
            // userControlMagicHandler1
            // 
            this.userControlMagicHandler1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlMagicHandler1.Location = new System.Drawing.Point(0, 6);
            this.userControlMagicHandler1.Name = "userControlMagicHandler1";
            this.userControlMagicHandler1.Size = new System.Drawing.Size(1034, 798);
            this.userControlMagicHandler1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 976);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Form1";
            this.Text = "Character Manager - 5e";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageCharacter.ResumeLayout(false);
            this.tabPageCharacter.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPageMagic.ResumeLayout(false);
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
        private UserControls.UserControlHitPoints userControlHitPoints1;
        private System.Windows.Forms.GroupBox groupBox4;
        private UserControls.UserControlGenericValue userControlArmorClass;
        private UserControls.UserControlGenericValue userControlSpeed;
        private UserControls.UserControlGenericValue userControlInitiative;
        private UserControls.UserControlGenericAbilitiesList userControlGenericAbilitiesList1;
        private UserControls.UserControlWeaponsHandler userControlWeaponsHandler1;
        private UserControls.UserControlArmorHandler userControlArmorHandler1;
        private UserControls.UserControlEquipmentHandler userControlEquipmentHandler1;
        private System.Windows.Forms.Button buttonShortRest;
        private System.Windows.Forms.Button buttonLongRest;
        private System.Windows.Forms.Button buttonRegisterDamage;
        private System.Windows.Forms.Button buttonHeal;
        private UserControls.UserControlMagicHandler userControlMagicHandler1;
    }
}

