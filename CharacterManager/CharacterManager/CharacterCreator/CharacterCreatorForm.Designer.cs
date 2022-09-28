namespace CharacterManager.CharacterCreator
{
    partial class CharacterCreatorForm
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
            this.textBoxCharName = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMainRace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSubRace = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelExtraBonus = new System.Windows.Forms.Label();
            this.userControlAttributeSetupCHA = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.userControlAttributeSetupWIS = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.userControlAttributeSetupCON = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.userControlAttributeSetupDEX = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.userControlAttributeSetupINT = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.userControlAttributeSetupSTR = new CharacterManager.UserControls.UserControlAttributeSetup();
            this.labelCustomRacialAttributeBonus = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.alignmentChoice1 = new CharacterManager.UserControls.AlignmentChoice();
            this.userControlToolProficiencyChoice1 = new CharacterManager.UserControls.UserControlToolProficiencyChoice();
            this.textBoxPassivePerception = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.userControlSkillProficiencies1 = new CharacterManager.UserControls.UserControlSkillProficiencies();
            this.userControlSavingThrows1 = new CharacterManager.UserControls.UserControlSavingThrows();
            this.userControlGenericAttributeList1 = new CharacterManager.UserControls.UserControlGenericAbilitiesList();
            this.textBoxHitPoints = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxHitDie = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSpeed = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.richTextBoxProficiencyTest = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBoxBackGround = new System.Windows.Forms.TextBox();
            this.buttonChooseBackGround = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.buttonChooseClassFeatures = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlGenericEquipmentList1 = new CharacterManager.UserControls.UserControlGenericEquipmentList();
            this.buttonChooseSpells = new System.Windows.Forms.Button();
            this.buttonChooseEquipment = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxPlayerClasses = new System.Windows.Forms.ComboBox();
            this.userControlKnownLanguages = new CharacterManager.UserControls.UserControlProficiencyList();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCharName
            // 
            this.textBoxCharName.Location = new System.Drawing.Point(96, 16);
            this.textBoxCharName.Name = "textBoxCharName";
            this.textBoxCharName.Size = new System.Drawing.Size(165, 20);
            this.textBoxCharName.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(17, 876);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(98, 876);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Character Name";
            // 
            // comboBoxMainRace
            // 
            this.comboBoxMainRace.FormattingEnabled = true;
            this.comboBoxMainRace.Location = new System.Drawing.Point(61, 19);
            this.comboBoxMainRace.Name = "comboBoxMainRace";
            this.comboBoxMainRace.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMainRace.TabIndex = 4;
            this.comboBoxMainRace.SelectedIndexChanged += new System.EventHandler(this.comboBoxMainRace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Race";
            // 
            // comboBoxSubRace
            // 
            this.comboBoxSubRace.FormattingEnabled = true;
            this.comboBoxSubRace.Location = new System.Drawing.Point(61, 46);
            this.comboBoxSubRace.Name = "comboBoxSubRace";
            this.comboBoxSubRace.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubRace.TabIndex = 6;
            this.comboBoxSubRace.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubRace_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subrace";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelExtraBonus);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupCHA);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupWIS);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupCON);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupDEX);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupINT);
            this.groupBox1.Controls.Add(this.userControlAttributeSetupSTR);
            this.groupBox1.Controls.Add(this.labelCustomRacialAttributeBonus);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Location = new System.Drawing.Point(5, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 238);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base attributes";
            // 
            // labelExtraBonus
            // 
            this.labelExtraBonus.AutoSize = true;
            this.labelExtraBonus.Location = new System.Drawing.Point(151, 12);
            this.labelExtraBonus.Name = "labelExtraBonus";
            this.labelExtraBonus.Size = new System.Drawing.Size(37, 26);
            this.labelExtraBonus.TabIndex = 35;
            this.labelExtraBonus.Text = "Extra\r\nBonus";
            this.labelExtraBonus.Visible = false;
            // 
            // userControlAttributeSetupCHA
            // 
            this.userControlAttributeSetupCHA.AttributeBonus = 0;
            this.userControlAttributeSetupCHA.AttributeName = "CHA";
            this.userControlAttributeSetupCHA.Location = new System.Drawing.Point(6, 167);
            this.userControlAttributeSetupCHA.Name = "userControlAttributeSetupCHA";
            this.userControlAttributeSetupCHA.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupCHA.TabIndex = 34;
            this.userControlAttributeSetupCHA.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // userControlAttributeSetupWIS
            // 
            this.userControlAttributeSetupWIS.AttributeBonus = 0;
            this.userControlAttributeSetupWIS.AttributeName = "WIS";
            this.userControlAttributeSetupWIS.Location = new System.Drawing.Point(6, 141);
            this.userControlAttributeSetupWIS.Name = "userControlAttributeSetupWIS";
            this.userControlAttributeSetupWIS.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupWIS.TabIndex = 33;
            this.userControlAttributeSetupWIS.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // userControlAttributeSetupCON
            // 
            this.userControlAttributeSetupCON.AttributeBonus = 0;
            this.userControlAttributeSetupCON.AttributeName = "CON";
            this.userControlAttributeSetupCON.Location = new System.Drawing.Point(6, 115);
            this.userControlAttributeSetupCON.Name = "userControlAttributeSetupCON";
            this.userControlAttributeSetupCON.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupCON.TabIndex = 32;
            this.userControlAttributeSetupCON.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // userControlAttributeSetupDEX
            // 
            this.userControlAttributeSetupDEX.AttributeBonus = 0;
            this.userControlAttributeSetupDEX.AttributeName = "DEX";
            this.userControlAttributeSetupDEX.Location = new System.Drawing.Point(6, 89);
            this.userControlAttributeSetupDEX.Name = "userControlAttributeSetupDEX";
            this.userControlAttributeSetupDEX.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupDEX.TabIndex = 31;
            this.userControlAttributeSetupDEX.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // userControlAttributeSetupINT
            // 
            this.userControlAttributeSetupINT.AttributeBonus = 0;
            this.userControlAttributeSetupINT.AttributeName = "INT";
            this.userControlAttributeSetupINT.Location = new System.Drawing.Point(6, 63);
            this.userControlAttributeSetupINT.Name = "userControlAttributeSetupINT";
            this.userControlAttributeSetupINT.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupINT.TabIndex = 30;
            this.userControlAttributeSetupINT.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // userControlAttributeSetupSTR
            // 
            this.userControlAttributeSetupSTR.AttributeBonus = 0;
            this.userControlAttributeSetupSTR.AttributeName = "STR";
            this.userControlAttributeSetupSTR.Location = new System.Drawing.Point(6, 37);
            this.userControlAttributeSetupSTR.Name = "userControlAttributeSetupSTR";
            this.userControlAttributeSetupSTR.Size = new System.Drawing.Size(248, 26);
            this.userControlAttributeSetupSTR.TabIndex = 29;
            this.userControlAttributeSetupSTR.ValueChanged += new System.EventHandler(this.baseAttribute_ValueChanged);
            // 
            // labelCustomRacialAttributeBonus
            // 
            this.labelCustomRacialAttributeBonus.AutoSize = true;
            this.labelCustomRacialAttributeBonus.Location = new System.Drawing.Point(120, 218);
            this.labelCustomRacialAttributeBonus.Name = "labelCustomRacialAttributeBonus";
            this.labelCustomRacialAttributeBonus.Size = new System.Drawing.Size(13, 13);
            this.labelCustomRacialAttributeBonus.TabIndex = 28;
            this.labelCustomRacialAttributeBonus.Text = "0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 217);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 13);
            this.label19.TabIndex = 27;
            this.label19.Text = "Custom Racial Bonus:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(107, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 26);
            this.label20.TabIndex = 26;
            this.label20.Text = "Racial \r\nBonus";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(193, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Total";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(53, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "BASE";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 201);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Standard values : 15, 14, 13, 12, 10, 8";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.userControlKnownLanguages);
            this.groupBox3.Controls.Add(this.alignmentChoice1);
            this.groupBox3.Controls.Add(this.userControlToolProficiencyChoice1);
            this.groupBox3.Controls.Add(this.textBoxPassivePerception);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.userControlSkillProficiencies1);
            this.groupBox3.Controls.Add(this.userControlSavingThrows1);
            this.groupBox3.Controls.Add(this.userControlGenericAttributeList1);
            this.groupBox3.Controls.Add(this.textBoxHitPoints);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.textBoxHitDie);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.textBoxSpeed);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.richTextBoxProficiencyTest);
            this.groupBox3.Location = new System.Drawing.Point(286, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(549, 857);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Player";
            // 
            // alignmentChoice1
            // 
            this.alignmentChoice1.Location = new System.Drawing.Point(372, 9);
            this.alignmentChoice1.Name = "alignmentChoice1";
            this.alignmentChoice1.Size = new System.Drawing.Size(171, 172);
            this.alignmentChoice1.TabIndex = 25;
            // 
            // userControlToolProficiencyChoice1
            // 
            this.userControlToolProficiencyChoice1.Location = new System.Drawing.Point(14, 723);
            this.userControlToolProficiencyChoice1.Name = "userControlToolProficiencyChoice1";
            this.userControlToolProficiencyChoice1.Size = new System.Drawing.Size(271, 122);
            this.userControlToolProficiencyChoice1.TabIndex = 2;
            // 
            // textBoxPassivePerception
            // 
            this.textBoxPassivePerception.Location = new System.Drawing.Point(300, 110);
            this.textBoxPassivePerception.Name = "textBoxPassivePerception";
            this.textBoxPassivePerception.ReadOnly = true;
            this.textBoxPassivePerception.Size = new System.Drawing.Size(59, 20);
            this.textBoxPassivePerception.TabIndex = 24;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(196, 113);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Passive Perception";
            // 
            // userControlSkillProficiencies1
            // 
            this.userControlSkillProficiencies1.isSetDataVisible = true;
            this.userControlSkillProficiencies1.Location = new System.Drawing.Point(10, 185);
            this.userControlSkillProficiencies1.Name = "userControlSkillProficiencies1";
            this.userControlSkillProficiencies1.Size = new System.Drawing.Size(276, 538);
            this.userControlSkillProficiencies1.TabIndex = 22;
            // 
            // userControlSavingThrows1
            // 
            this.userControlSavingThrows1.Location = new System.Drawing.Point(10, 12);
            this.userControlSavingThrows1.Name = "userControlSavingThrows1";
            this.userControlSavingThrows1.Size = new System.Drawing.Size(166, 177);
            this.userControlSavingThrows1.TabIndex = 21;
            // 
            // userControlGenericAttributeList1
            // 
            this.userControlGenericAttributeList1.AutoScroll = true;
            this.userControlGenericAttributeList1.AutoScrollMinSize = new System.Drawing.Size(256, 350);
            this.userControlGenericAttributeList1.IsBorder = true;
            this.userControlGenericAttributeList1.IsSlotsVisible = false;
            this.userControlGenericAttributeList1.Location = new System.Drawing.Point(288, 370);
            this.userControlGenericAttributeList1.Name = "userControlGenericAttributeList1";
            this.userControlGenericAttributeList1.Size = new System.Drawing.Size(256, 353);
            this.userControlGenericAttributeList1.TabIndex = 20;
            this.userControlGenericAttributeList1.Title = "Abilities:";
            // 
            // textBoxHitPoints
            // 
            this.textBoxHitPoints.Location = new System.Drawing.Point(300, 59);
            this.textBoxHitPoints.Name = "textBoxHitPoints";
            this.textBoxHitPoints.ReadOnly = true;
            this.textBoxHitPoints.Size = new System.Drawing.Size(59, 20);
            this.textBoxHitPoints.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(196, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Hit points:";
            // 
            // textBoxHitDie
            // 
            this.textBoxHitDie.Location = new System.Drawing.Point(300, 33);
            this.textBoxHitDie.Name = "textBoxHitDie";
            this.textBoxHitDie.ReadOnly = true;
            this.textBoxHitDie.Size = new System.Drawing.Size(59, 20);
            this.textBoxHitDie.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(196, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Hit die:";
            // 
            // textBoxSpeed
            // 
            this.textBoxSpeed.Location = new System.Drawing.Point(300, 85);
            this.textBoxSpeed.Name = "textBoxSpeed";
            this.textBoxSpeed.ReadOnly = true;
            this.textBoxSpeed.Size = new System.Drawing.Size(59, 20);
            this.textBoxSpeed.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(196, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Speed:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(288, 185);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Weapon and armor proficiencies:";
            // 
            // richTextBoxProficiencyTest
            // 
            this.richTextBoxProficiencyTest.Location = new System.Drawing.Point(288, 206);
            this.richTextBoxProficiencyTest.Name = "richTextBoxProficiencyTest";
            this.richTextBoxProficiencyTest.Size = new System.Drawing.Size(256, 162);
            this.richTextBoxProficiencyTest.TabIndex = 10;
            this.richTextBoxProficiencyTest.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxMainRace);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.comboBoxSubRace);
            this.groupBox4.Location = new System.Drawing.Point(6, 42);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(255, 75);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Player Race";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.groupBox4);
            this.groupBox5.Controls.Add(this.textBoxCharName);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Location = new System.Drawing.Point(13, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(267, 857);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBoxBackGround);
            this.groupBox7.Controls.Add(this.buttonChooseBackGround);
            this.groupBox7.Location = new System.Drawing.Point(5, 356);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(256, 50);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Character Background";
            // 
            // textBoxBackGround
            // 
            this.textBoxBackGround.Location = new System.Drawing.Point(150, 19);
            this.textBoxBackGround.Name = "textBoxBackGround";
            this.textBoxBackGround.ReadOnly = true;
            this.textBoxBackGround.Size = new System.Drawing.Size(100, 20);
            this.textBoxBackGround.TabIndex = 1;
            this.textBoxBackGround.Text = "None";
            // 
            // buttonChooseBackGround
            // 
            this.buttonChooseBackGround.Location = new System.Drawing.Point(14, 18);
            this.buttonChooseBackGround.Name = "buttonChooseBackGround";
            this.buttonChooseBackGround.Size = new System.Drawing.Size(130, 22);
            this.buttonChooseBackGround.TabIndex = 0;
            this.buttonChooseBackGround.Text = "Choose Background";
            this.buttonChooseBackGround.UseVisualStyleBackColor = true;
            this.buttonChooseBackGround.Click += new System.EventHandler(this.buttonChooseBackGround_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.buttonChooseClassFeatures);
            this.groupBox6.Controls.Add(this.groupBox2);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.comboBoxPlayerClasses);
            this.groupBox6.Location = new System.Drawing.Point(5, 407);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(256, 444);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Class";
            // 
            // buttonChooseClassFeatures
            // 
            this.buttonChooseClassFeatures.Location = new System.Drawing.Point(19, 47);
            this.buttonChooseClassFeatures.Name = "buttonChooseClassFeatures";
            this.buttonChooseClassFeatures.Size = new System.Drawing.Size(224, 23);
            this.buttonChooseClassFeatures.TabIndex = 4;
            this.buttonChooseClassFeatures.Text = "Choose Class Features";
            this.buttonChooseClassFeatures.UseVisualStyleBackColor = true;
            this.buttonChooseClassFeatures.Click += new System.EventHandler(this.buttonChooseClassFeatures_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.buttonChooseSpells);
            this.groupBox2.Controls.Add(this.buttonChooseEquipment);
            this.groupBox2.Location = new System.Drawing.Point(9, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 362);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equipment and Spells";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.userControlGenericEquipmentList1);
            this.panel1.Location = new System.Drawing.Point(4, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 310);
            this.panel1.TabIndex = 3;
            // 
            // userControlGenericEquipmentList1
            // 
            this.userControlGenericEquipmentList1.AutoScroll = true;
            this.userControlGenericEquipmentList1.AutoScrollMinSize = new System.Drawing.Size(228, 300);
            this.userControlGenericEquipmentList1.IsBorder = true;
            this.userControlGenericEquipmentList1.Location = new System.Drawing.Point(1, 3);
            this.userControlGenericEquipmentList1.Name = "userControlGenericEquipmentList1";
            this.userControlGenericEquipmentList1.Size = new System.Drawing.Size(228, 307);
            this.userControlGenericEquipmentList1.TabIndex = 2;
            // 
            // buttonChooseSpells
            // 
            this.buttonChooseSpells.Location = new System.Drawing.Point(125, 19);
            this.buttonChooseSpells.Name = "buttonChooseSpells";
            this.buttonChooseSpells.Size = new System.Drawing.Size(109, 21);
            this.buttonChooseSpells.TabIndex = 1;
            this.buttonChooseSpells.Text = "Choose Spells";
            this.buttonChooseSpells.UseVisualStyleBackColor = true;
            this.buttonChooseSpells.Click += new System.EventHandler(this.buttonChooseSpells_Click);
            // 
            // buttonChooseEquipment
            // 
            this.buttonChooseEquipment.Location = new System.Drawing.Point(10, 19);
            this.buttonChooseEquipment.Name = "buttonChooseEquipment";
            this.buttonChooseEquipment.Size = new System.Drawing.Size(109, 21);
            this.buttonChooseEquipment.TabIndex = 0;
            this.buttonChooseEquipment.Text = "Choose Equipment";
            this.buttonChooseEquipment.UseVisualStyleBackColor = true;
            this.buttonChooseEquipment.Click += new System.EventHandler(this.buttonChooseEquipment_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "Player class";
            // 
            // comboBoxPlayerClasses
            // 
            this.comboBoxPlayerClasses.FormattingEnabled = true;
            this.comboBoxPlayerClasses.Location = new System.Drawing.Point(80, 19);
            this.comboBoxPlayerClasses.Name = "comboBoxPlayerClasses";
            this.comboBoxPlayerClasses.Size = new System.Drawing.Size(163, 21);
            this.comboBoxPlayerClasses.TabIndex = 0;
            this.comboBoxPlayerClasses.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayerClasses_SelectedIndexChanged);
            // 
            // userControlKnownLanguages
            // 
            this.userControlKnownLanguages.IsBorder = true;
            this.userControlKnownLanguages.Location = new System.Drawing.Point(291, 729);
            this.userControlKnownLanguages.Name = "userControlKnownLanguages";
            this.userControlKnownLanguages.Size = new System.Drawing.Size(252, 110);
            this.userControlKnownLanguages.TabIndex = 26;
            this.userControlKnownLanguages.TitleString = "Known Languages";
            // 
            // CharacterCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 914);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Name = "CharacterCreatorForm";
            this.Text = "CharacterCreatorForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCharName;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMainRace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSubRace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBoxProficiencyTest;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxPlayerClasses;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSpeed;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxHitPoints;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxHitDie;
        private System.Windows.Forms.Label label13;
        private UserControls.UserControlGenericAbilitiesList userControlGenericAttributeList1;
        private UserControls.UserControlSavingThrows userControlSavingThrows1;
        private UserControls.UserControlSkillProficiencies userControlSkillProficiencies1;
        private System.Windows.Forms.TextBox textBoxPassivePerception;
        private System.Windows.Forms.Label label15;
        private UserControls.UserControlToolProficiencyChoice userControlToolProficiencyChoice1;
        private UserControls.AlignmentChoice alignmentChoice1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonChooseSpells;
        private System.Windows.Forms.Button buttonChooseEquipment;
        private UserControls.UserControlGenericEquipmentList userControlGenericEquipmentList1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBoxBackGround;
        private System.Windows.Forms.Button buttonChooseBackGround;
        private System.Windows.Forms.Button buttonChooseClassFeatures;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label labelCustomRacialAttributeBonus;
        private System.Windows.Forms.Label label19;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupSTR;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupINT;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupDEX;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupCHA;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupWIS;
        private UserControls.UserControlAttributeSetup userControlAttributeSetupCON;
        private System.Windows.Forms.Label labelExtraBonus;
        private UserControls.UserControlProficiencyList userControlKnownLanguages;
    }
}