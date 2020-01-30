namespace CharacterManager
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
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCHAFinal = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxWISFinal = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBoxChaBonus = new System.Windows.Forms.TextBox();
            this.textBoxWisBonus = new System.Windows.Forms.TextBox();
            this.textBoxCONFinal = new System.Windows.Forms.TextBox();
            this.textBoxConBonus = new System.Windows.Forms.TextBox();
            this.textBoxDexBonus = new System.Windows.Forms.TextBox();
            this.textBoxDEXFinal = new System.Windows.Forms.TextBox();
            this.textBoxIntBonus = new System.Windows.Forms.TextBox();
            this.textBoxStrBonus = new System.Windows.Forms.TextBox();
            this.textBoxINTFinal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxSTRFinal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownCHA = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownWIS = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownCON = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownDEX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownINT = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownSTR = new System.Windows.Forms.NumericUpDown();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.userControlGenericEquipmentList1 = new CharacterManager.UserControls.UserControlGenericEquipmentList();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonChooseEquipment = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.comboBoxPlayerClasses = new System.Windows.Forms.ComboBox();
            this.buttonChooseClassFeatures = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSTR)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxCHAFinal);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.textBoxWISFinal);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.textBoxChaBonus);
            this.groupBox1.Controls.Add(this.textBoxWisBonus);
            this.groupBox1.Controls.Add(this.textBoxCONFinal);
            this.groupBox1.Controls.Add(this.textBoxConBonus);
            this.groupBox1.Controls.Add(this.textBoxDexBonus);
            this.groupBox1.Controls.Add(this.textBoxDEXFinal);
            this.groupBox1.Controls.Add(this.textBoxIntBonus);
            this.groupBox1.Controls.Add(this.textBoxStrBonus);
            this.groupBox1.Controls.Add(this.textBoxINTFinal);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBoxSTRFinal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.numericUpDownCHA);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numericUpDownWIS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.numericUpDownCON);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDownDEX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownINT);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericUpDownSTR);
            this.groupBox1.Location = new System.Drawing.Point(5, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 238);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base attributes(without modifiers)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(190, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Total";
            // 
            // textBoxCHAFinal
            // 
            this.textBoxCHAFinal.Location = new System.Drawing.Point(179, 182);
            this.textBoxCHAFinal.Name = "textBoxCHAFinal";
            this.textBoxCHAFinal.ReadOnly = true;
            this.textBoxCHAFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxCHAFinal.TabIndex = 23;
            this.textBoxCHAFinal.TextChanged += new System.EventHandler(this.textBoxCHAFinal_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(134, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 26);
            this.label19.TabIndex = 19;
            this.label19.Text = "Racial\r\n bonus";
            // 
            // textBoxWISFinal
            // 
            this.textBoxWISFinal.Location = new System.Drawing.Point(179, 156);
            this.textBoxWISFinal.Name = "textBoxWISFinal";
            this.textBoxWISFinal.ReadOnly = true;
            this.textBoxWISFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxWISFinal.TabIndex = 22;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(59, 29);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 18;
            this.label18.Text = "BASE";
            // 
            // textBoxChaBonus
            // 
            this.textBoxChaBonus.Location = new System.Drawing.Point(134, 182);
            this.textBoxChaBonus.Name = "textBoxChaBonus";
            this.textBoxChaBonus.ReadOnly = true;
            this.textBoxChaBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxChaBonus.TabIndex = 17;
            // 
            // textBoxWisBonus
            // 
            this.textBoxWisBonus.Location = new System.Drawing.Point(134, 156);
            this.textBoxWisBonus.Name = "textBoxWisBonus";
            this.textBoxWisBonus.ReadOnly = true;
            this.textBoxWisBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxWisBonus.TabIndex = 16;
            // 
            // textBoxCONFinal
            // 
            this.textBoxCONFinal.Location = new System.Drawing.Point(179, 130);
            this.textBoxCONFinal.Name = "textBoxCONFinal";
            this.textBoxCONFinal.ReadOnly = true;
            this.textBoxCONFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxCONFinal.TabIndex = 21;
            // 
            // textBoxConBonus
            // 
            this.textBoxConBonus.Location = new System.Drawing.Point(134, 130);
            this.textBoxConBonus.Name = "textBoxConBonus";
            this.textBoxConBonus.ReadOnly = true;
            this.textBoxConBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxConBonus.TabIndex = 15;
            // 
            // textBoxDexBonus
            // 
            this.textBoxDexBonus.Location = new System.Drawing.Point(134, 104);
            this.textBoxDexBonus.Name = "textBoxDexBonus";
            this.textBoxDexBonus.ReadOnly = true;
            this.textBoxDexBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxDexBonus.TabIndex = 14;
            // 
            // textBoxDEXFinal
            // 
            this.textBoxDEXFinal.Location = new System.Drawing.Point(179, 104);
            this.textBoxDEXFinal.Name = "textBoxDEXFinal";
            this.textBoxDEXFinal.ReadOnly = true;
            this.textBoxDEXFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxDEXFinal.TabIndex = 20;
            // 
            // textBoxIntBonus
            // 
            this.textBoxIntBonus.Location = new System.Drawing.Point(134, 78);
            this.textBoxIntBonus.Name = "textBoxIntBonus";
            this.textBoxIntBonus.ReadOnly = true;
            this.textBoxIntBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxIntBonus.TabIndex = 13;
            // 
            // textBoxStrBonus
            // 
            this.textBoxStrBonus.Location = new System.Drawing.Point(134, 52);
            this.textBoxStrBonus.Name = "textBoxStrBonus";
            this.textBoxStrBonus.ReadOnly = true;
            this.textBoxStrBonus.Size = new System.Drawing.Size(39, 20);
            this.textBoxStrBonus.TabIndex = 11;
            // 
            // textBoxINTFinal
            // 
            this.textBoxINTFinal.Location = new System.Drawing.Point(179, 78);
            this.textBoxINTFinal.Name = "textBoxINTFinal";
            this.textBoxINTFinal.ReadOnly = true;
            this.textBoxINTFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxINTFinal.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 214);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Standard values : 15, 14, 13, 12, 10, 8";
            // 
            // textBoxSTRFinal
            // 
            this.textBoxSTRFinal.Location = new System.Drawing.Point(179, 52);
            this.textBoxSTRFinal.Name = "textBoxSTRFinal";
            this.textBoxSTRFinal.ReadOnly = true;
            this.textBoxSTRFinal.Size = new System.Drawing.Size(56, 20);
            this.textBoxSTRFinal.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "CHA";
            // 
            // numericUpDownCHA
            // 
            this.numericUpDownCHA.Location = new System.Drawing.Point(50, 182);
            this.numericUpDownCHA.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCHA.Name = "numericUpDownCHA";
            this.numericUpDownCHA.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownCHA.TabIndex = 10;
            this.numericUpDownCHA.ValueChanged += new System.EventHandler(this.numericUpDownCHA_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "WIS";
            // 
            // numericUpDownWIS
            // 
            this.numericUpDownWIS.Location = new System.Drawing.Point(50, 156);
            this.numericUpDownWIS.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownWIS.Name = "numericUpDownWIS";
            this.numericUpDownWIS.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownWIS.TabIndex = 8;
            this.numericUpDownWIS.ValueChanged += new System.EventHandler(this.numericUpDownWIS_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "CON";
            // 
            // numericUpDownCON
            // 
            this.numericUpDownCON.Location = new System.Drawing.Point(50, 130);
            this.numericUpDownCON.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCON.Name = "numericUpDownCON";
            this.numericUpDownCON.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownCON.TabIndex = 6;
            this.numericUpDownCON.ValueChanged += new System.EventHandler(this.numericUpDownCON_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "DEX";
            // 
            // numericUpDownDEX
            // 
            this.numericUpDownDEX.Location = new System.Drawing.Point(50, 104);
            this.numericUpDownDEX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownDEX.Name = "numericUpDownDEX";
            this.numericUpDownDEX.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownDEX.TabIndex = 4;
            this.numericUpDownDEX.ValueChanged += new System.EventHandler(this.numericUpDownDEX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "INT";
            // 
            // numericUpDownINT
            // 
            this.numericUpDownINT.Location = new System.Drawing.Point(50, 78);
            this.numericUpDownINT.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownINT.Name = "numericUpDownINT";
            this.numericUpDownINT.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownINT.TabIndex = 2;
            this.numericUpDownINT.ValueChanged += new System.EventHandler(this.numericUpDownINT_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "STR";
            // 
            // numericUpDownSTR
            // 
            this.numericUpDownSTR.Location = new System.Drawing.Point(50, 52);
            this.numericUpDownSTR.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSTR.Name = "numericUpDownSTR";
            this.numericUpDownSTR.Size = new System.Drawing.Size(78, 20);
            this.numericUpDownSTR.TabIndex = 0;
            this.numericUpDownSTR.ValueChanged += new System.EventHandler(this.numericUpDownSTR_ValueChanged);
            // 
            // groupBox3
            // 
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
            this.userControlToolProficiencyChoice1.Size = new System.Drawing.Size(271, 94);
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
            this.userControlGenericAttributeList1.IsBorder = true;
            this.userControlGenericAttributeList1.Location = new System.Drawing.Point(288, 385);
            this.userControlGenericAttributeList1.Name = "userControlGenericAttributeList1";
            this.userControlGenericAttributeList1.Size = new System.Drawing.Size(256, 433);
            this.userControlGenericAttributeList1.TabIndex = 20;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.userControlGenericEquipmentList1);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.buttonChooseEquipment);
            this.groupBox2.Location = new System.Drawing.Point(9, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 362);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Equipment and Spells";
            // 
            // userControlGenericEquipmentList1
            // 
            this.userControlGenericEquipmentList1.IsBorder = true;
            this.userControlGenericEquipmentList1.Location = new System.Drawing.Point(6, 46);
            this.userControlGenericEquipmentList1.Name = "userControlGenericEquipmentList1";
            this.userControlGenericEquipmentList1.Size = new System.Drawing.Size(228, 300);
            this.userControlGenericEquipmentList1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 21);
            this.button1.TabIndex = 1;
            this.button1.Text = "Choose Spells";
            this.button1.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDEX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownINT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSTR)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownSTR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownCHA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownWIS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownCON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownDEX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownINT;
        private System.Windows.Forms.TextBox textBoxCHAFinal;
        private System.Windows.Forms.TextBox textBoxWISFinal;
        private System.Windows.Forms.TextBox textBoxCONFinal;
        private System.Windows.Forms.TextBox textBoxDEXFinal;
        private System.Windows.Forms.TextBox textBoxINTFinal;
        private System.Windows.Forms.TextBox textBoxSTRFinal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox richTextBoxProficiencyTest;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxPlayerClasses;
        private System.Windows.Forms.TextBox textBoxChaBonus;
        private System.Windows.Forms.TextBox textBoxWisBonus;
        private System.Windows.Forms.TextBox textBoxConBonus;
        private System.Windows.Forms.TextBox textBoxDexBonus;
        private System.Windows.Forms.TextBox textBoxIntBonus;
        private System.Windows.Forms.TextBox textBoxStrBonus;
        private System.Windows.Forms.Label label19;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonChooseEquipment;
        private UserControls.UserControlGenericEquipmentList userControlGenericEquipmentList1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox textBoxBackGround;
        private System.Windows.Forms.Button buttonChooseBackGround;
        private System.Windows.Forms.Button buttonChooseClassFeatures;
    }
}