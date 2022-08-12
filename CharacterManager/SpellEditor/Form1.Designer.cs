
namespace SpellEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxMaterialComponent = new System.Windows.Forms.TextBox();
            this.checkBoxMaterialComponent = new System.Windows.Forms.CheckBox();
            this.checkBoxSomaticComponent = new System.Windows.Forms.CheckBox();
            this.checkBoxVerbalComponent = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxRitual = new System.Windows.Forms.CheckBox();
            this.checkBoxConcentration = new System.Windows.Forms.CheckBox();
            this.numericUpDownCastingTime = new System.Windows.Forms.NumericUpDown();
            this.comboBoxCastingTimeType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxRangeType = new System.Windows.Forms.ComboBox();
            this.numericUpDownSpellRange = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpDownAoeSize = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxAoeType = new System.Windows.Forms.ComboBox();
            this.numericUpDownSpellDuration = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxSpellSchool = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxAtHigherLevels = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxSpellDescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSpellName = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCastingTime)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpellRange)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAoeSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpellDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonLoad.Location = new System.Drawing.Point(12, 592);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 35);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(604, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(262, 574);
            this.listBox1.TabIndex = 2;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.numericUpDownLevel);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.numericUpDownSpellDuration);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBoxSpellSchool);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.richTextBoxAtHigherLevels);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.richTextBoxSpellDescription);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxSpellName);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 574);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spell Data";
            // 
            // numericUpDownLevel
            // 
            this.numericUpDownLevel.Location = new System.Drawing.Point(100, 85);
            this.numericUpDownLevel.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDownLevel.Name = "numericUpDownLevel";
            this.numericUpDownLevel.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownLevel.TabIndex = 18;
            this.numericUpDownLevel.ValueChanged += new System.EventHandler(this.numericUpDownLevel_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBoxMaterialComponent);
            this.groupBox5.Controls.Add(this.checkBoxMaterialComponent);
            this.groupBox5.Controls.Add(this.checkBoxSomaticComponent);
            this.groupBox5.Controls.Add(this.checkBoxVerbalComponent);
            this.groupBox5.Location = new System.Drawing.Point(6, 217);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(260, 116);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Components";
            // 
            // textBoxMaterialComponent
            // 
            this.textBoxMaterialComponent.Location = new System.Drawing.Point(81, 67);
            this.textBoxMaterialComponent.Name = "textBoxMaterialComponent";
            this.textBoxMaterialComponent.Size = new System.Drawing.Size(173, 23);
            this.textBoxMaterialComponent.TabIndex = 3;
            this.textBoxMaterialComponent.TextChanged += new System.EventHandler(this.textBoxMaterialComponent_TextChanged);
            // 
            // checkBoxMaterialComponent
            // 
            this.checkBoxMaterialComponent.AutoSize = true;
            this.checkBoxMaterialComponent.Location = new System.Drawing.Point(6, 71);
            this.checkBoxMaterialComponent.Name = "checkBoxMaterialComponent";
            this.checkBoxMaterialComponent.Size = new System.Drawing.Size(69, 19);
            this.checkBoxMaterialComponent.TabIndex = 2;
            this.checkBoxMaterialComponent.Text = "Material";
            this.checkBoxMaterialComponent.UseVisualStyleBackColor = true;
            this.checkBoxMaterialComponent.CheckedChanged += new System.EventHandler(this.checkBoxMaterialComponent_CheckedChanged);
            // 
            // checkBoxSomaticComponent
            // 
            this.checkBoxSomaticComponent.AutoSize = true;
            this.checkBoxSomaticComponent.Location = new System.Drawing.Point(6, 46);
            this.checkBoxSomaticComponent.Name = "checkBoxSomaticComponent";
            this.checkBoxSomaticComponent.Size = new System.Drawing.Size(69, 19);
            this.checkBoxSomaticComponent.TabIndex = 1;
            this.checkBoxSomaticComponent.Text = "Somatic";
            this.checkBoxSomaticComponent.UseVisualStyleBackColor = true;
            this.checkBoxSomaticComponent.CheckedChanged += new System.EventHandler(this.checkBoxSomaticComponent_CheckedChanged);
            // 
            // checkBoxVerbalComponent
            // 
            this.checkBoxVerbalComponent.AutoSize = true;
            this.checkBoxVerbalComponent.Location = new System.Drawing.Point(6, 21);
            this.checkBoxVerbalComponent.Name = "checkBoxVerbalComponent";
            this.checkBoxVerbalComponent.Size = new System.Drawing.Size(58, 19);
            this.checkBoxVerbalComponent.TabIndex = 0;
            this.checkBoxVerbalComponent.Text = "Verbal";
            this.checkBoxVerbalComponent.UseVisualStyleBackColor = true;
            this.checkBoxVerbalComponent.CheckedChanged += new System.EventHandler(this.checkBoxVerbalComponent_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxRitual);
            this.groupBox4.Controls.Add(this.checkBoxConcentration);
            this.groupBox4.Controls.Add(this.numericUpDownCastingTime);
            this.groupBox4.Controls.Add(this.comboBoxCastingTimeType);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Location = new System.Drawing.Point(272, 217);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(307, 116);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Casting Time";
            // 
            // checkBoxRitual
            // 
            this.checkBoxRitual.AutoSize = true;
            this.checkBoxRitual.Location = new System.Drawing.Point(199, 80);
            this.checkBoxRitual.Name = "checkBoxRitual";
            this.checkBoxRitual.Size = new System.Drawing.Size(56, 19);
            this.checkBoxRitual.TabIndex = 20;
            this.checkBoxRitual.Text = "Ritual";
            this.checkBoxRitual.UseVisualStyleBackColor = true;
            this.checkBoxRitual.CheckedChanged += new System.EventHandler(this.checkBoxRitual_CheckedChanged);
            // 
            // checkBoxConcentration
            // 
            this.checkBoxConcentration.AutoSize = true;
            this.checkBoxConcentration.Location = new System.Drawing.Point(12, 80);
            this.checkBoxConcentration.Name = "checkBoxConcentration";
            this.checkBoxConcentration.Size = new System.Drawing.Size(102, 19);
            this.checkBoxConcentration.TabIndex = 19;
            this.checkBoxConcentration.Text = "Concentration";
            this.checkBoxConcentration.UseVisualStyleBackColor = true;
            this.checkBoxConcentration.CheckedChanged += new System.EventHandler(this.checkBoxConcentration_CheckedChanged);
            // 
            // numericUpDownCastingTime
            // 
            this.numericUpDownCastingTime.Location = new System.Drawing.Point(103, 51);
            this.numericUpDownCastingTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCastingTime.Name = "numericUpDownCastingTime";
            this.numericUpDownCastingTime.Size = new System.Drawing.Size(198, 23);
            this.numericUpDownCastingTime.TabIndex = 19;
            this.numericUpDownCastingTime.ValueChanged += new System.EventHandler(this.numericUpDownCastingTime_ValueChanged);
            // 
            // comboBoxCastingTimeType
            // 
            this.comboBoxCastingTimeType.FormattingEnabled = true;
            this.comboBoxCastingTimeType.Location = new System.Drawing.Point(103, 22);
            this.comboBoxCastingTimeType.Name = "comboBoxCastingTimeType";
            this.comboBoxCastingTimeType.Size = new System.Drawing.Size(198, 23);
            this.comboBoxCastingTimeType.TabIndex = 16;
            this.comboBoxCastingTimeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCastingTimeType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 15);
            this.label11.TabIndex = 18;
            this.label11.Text = "Casting Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 15);
            this.label12.TabIndex = 17;
            this.label12.Text = "Casting Type";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBoxRangeType);
            this.groupBox3.Controls.Add(this.numericUpDownSpellRange);
            this.groupBox3.Location = new System.Drawing.Point(272, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 77);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Spell Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Range(ft)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Range Type";
            // 
            // comboBoxRangeType
            // 
            this.comboBoxRangeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxRangeType.FormattingEnabled = true;
            this.comboBoxRangeType.Location = new System.Drawing.Point(85, 48);
            this.comboBoxRangeType.Name = "comboBoxRangeType";
            this.comboBoxRangeType.Size = new System.Drawing.Size(216, 23);
            this.comboBoxRangeType.TabIndex = 12;
            this.comboBoxRangeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxRangeType_SelectedIndexChanged);
            // 
            // numericUpDownSpellRange
            // 
            this.numericUpDownSpellRange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSpellRange.Location = new System.Drawing.Point(85, 18);
            this.numericUpDownSpellRange.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSpellRange.Name = "numericUpDownSpellRange";
            this.numericUpDownSpellRange.Size = new System.Drawing.Size(216, 23);
            this.numericUpDownSpellRange.TabIndex = 11;
            this.numericUpDownSpellRange.ValueChanged += new System.EventHandler(this.numericUpDownSpellRange_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.numericUpDownAoeSize);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxAoeType);
            this.groupBox2.Location = new System.Drawing.Point(272, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(307, 83);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "AOE Effects";
            // 
            // numericUpDownAoeSize
            // 
            this.numericUpDownAoeSize.Location = new System.Drawing.Point(103, 51);
            this.numericUpDownAoeSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownAoeSize.Name = "numericUpDownAoeSize";
            this.numericUpDownAoeSize.Size = new System.Drawing.Size(198, 23);
            this.numericUpDownAoeSize.TabIndex = 15;
            this.numericUpDownAoeSize.ValueChanged += new System.EventHandler(this.numericUpDownAoeSize_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "AOE Size(ft)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "AOE Type";
            // 
            // comboBoxAoeType
            // 
            this.comboBoxAoeType.FormattingEnabled = true;
            this.comboBoxAoeType.Location = new System.Drawing.Point(103, 22);
            this.comboBoxAoeType.Name = "comboBoxAoeType";
            this.comboBoxAoeType.Size = new System.Drawing.Size(198, 23);
            this.comboBoxAoeType.TabIndex = 0;
            this.comboBoxAoeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxAoeType_SelectedIndexChanged);
            // 
            // numericUpDownSpellDuration
            // 
            this.numericUpDownSpellDuration.Location = new System.Drawing.Point(100, 114);
            this.numericUpDownSpellDuration.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownSpellDuration.Name = "numericUpDownSpellDuration";
            this.numericUpDownSpellDuration.Size = new System.Drawing.Size(120, 23);
            this.numericUpDownSpellDuration.TabIndex = 13;
            this.numericUpDownSpellDuration.ValueChanged += new System.EventHandler(this.numericUpDownSpellDuration_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Duration (rnd)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Level";
            // 
            // comboBoxSpellSchool
            // 
            this.comboBoxSpellSchool.FormattingEnabled = true;
            this.comboBoxSpellSchool.Items.AddRange(new object[] {
            "Abjuration",
            "Conjuration",
            "Enchantment",
            "Evocation",
            "Necromancy",
            "Divination",
            "Illusion",
            "Transmutation"});
            this.comboBoxSpellSchool.Location = new System.Drawing.Point(99, 56);
            this.comboBoxSpellSchool.Name = "comboBoxSpellSchool";
            this.comboBoxSpellSchool.Size = new System.Drawing.Size(121, 23);
            this.comboBoxSpellSchool.TabIndex = 7;
            this.comboBoxSpellSchool.SelectedIndexChanged += new System.EventHandler(this.comboBoxSpellSchool_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "School";
            // 
            // richTextBoxAtHigherLevels
            // 
            this.richTextBoxAtHigherLevels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAtHigherLevels.Location = new System.Drawing.Point(112, 475);
            this.richTextBoxAtHigherLevels.Name = "richTextBoxAtHigherLevels";
            this.richTextBoxAtHigherLevels.Size = new System.Drawing.Size(467, 81);
            this.richTextBoxAtHigherLevels.TabIndex = 5;
            this.richTextBoxAtHigherLevels.Text = "";
            this.richTextBoxAtHigherLevels.TextChanged += new System.EventHandler(this.richTextBoxAtHigherLevels_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "At Higher Levels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description";
            // 
            // richTextBoxSpellDescription
            // 
            this.richTextBoxSpellDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxSpellDescription.Location = new System.Drawing.Point(112, 339);
            this.richTextBoxSpellDescription.Name = "richTextBoxSpellDescription";
            this.richTextBoxSpellDescription.Size = new System.Drawing.Size(467, 127);
            this.richTextBoxSpellDescription.TabIndex = 2;
            this.richTextBoxSpellDescription.Text = "";
            this.richTextBoxSpellDescription.TextChanged += new System.EventHandler(this.richTextBoxSpellDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spell Name";
            // 
            // textBoxSpellName
            // 
            this.textBoxSpellName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSpellName.Location = new System.Drawing.Point(99, 16);
            this.textBoxSpellName.Name = "textBoxSpellName";
            this.textBoxSpellName.Size = new System.Drawing.Size(480, 23);
            this.textBoxSpellName.TabIndex = 0;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(100, 592);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 35);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 639);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonLoad);
            this.Name = "Form1";
            this.Text = "SpellEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLevel)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCastingTime)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpellRange)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAoeSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSpellDuration)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSpellName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxSpellDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBoxAtHigherLevels;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSpellSchool;
        private System.Windows.Forms.NumericUpDown numericUpDownSpellDuration;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownSpellRange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericUpDownAoeSize;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxAoeType;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxRangeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown numericUpDownCastingTime;
        private System.Windows.Forms.ComboBox comboBoxCastingTimeType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBoxMaterialComponent;
        private System.Windows.Forms.CheckBox checkBoxMaterialComponent;
        private System.Windows.Forms.CheckBox checkBoxSomaticComponent;
        private System.Windows.Forms.CheckBox checkBoxVerbalComponent;
        private System.Windows.Forms.NumericUpDown numericUpDownLevel;
        private System.Windows.Forms.CheckBox checkBoxRitual;
        private System.Windows.Forms.CheckBox checkBoxConcentration;
        private System.Windows.Forms.Button buttonSave;
    }
}

