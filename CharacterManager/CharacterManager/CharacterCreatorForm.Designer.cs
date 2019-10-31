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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxCHAFinal = new System.Windows.Forms.TextBox();
            this.textBoxWISFinal = new System.Windows.Forms.TextBox();
            this.textBoxCONFinal = new System.Windows.Forms.TextBox();
            this.textBoxDEXFinal = new System.Windows.Forms.TextBox();
            this.textBoxINTFinal = new System.Windows.Forms.TextBox();
            this.textBoxSTRFinal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCHA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWIS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDEX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownINT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSTR)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxCharName
            // 
            this.textBoxCharName.Location = new System.Drawing.Point(105, 13);
            this.textBoxCharName.Name = "textBoxCharName";
            this.textBoxCharName.Size = new System.Drawing.Size(100, 20);
            this.textBoxCharName.TabIndex = 0;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(13, 599);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(94, 599);
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
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Character Name";
            // 
            // comboBoxMainRace
            // 
            this.comboBoxMainRace.FormattingEnabled = true;
            this.comboBoxMainRace.Location = new System.Drawing.Point(105, 40);
            this.comboBoxMainRace.Name = "comboBoxMainRace";
            this.comboBoxMainRace.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMainRace.TabIndex = 4;
            this.comboBoxMainRace.SelectedIndexChanged += new System.EventHandler(this.comboBoxMainRace_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Race";
            // 
            // comboBoxSubRace
            // 
            this.comboBoxSubRace.FormattingEnabled = true;
            this.comboBoxSubRace.Location = new System.Drawing.Point(105, 67);
            this.comboBoxSubRace.Name = "comboBoxSubRace";
            this.comboBoxSubRace.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSubRace.TabIndex = 6;
            this.comboBoxSubRace.SelectedIndexChanged += new System.EventHandler(this.comboBoxSubRace_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Subrace";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label16);
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
            this.groupBox1.Location = new System.Drawing.Point(18, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 238);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base attributes(without modifiers)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "CHA";
            // 
            // numericUpDownCHA
            // 
            this.numericUpDownCHA.Location = new System.Drawing.Point(67, 149);
            this.numericUpDownCHA.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCHA.Name = "numericUpDownCHA";
            this.numericUpDownCHA.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCHA.TabIndex = 10;
            this.numericUpDownCHA.ValueChanged += new System.EventHandler(this.numericUpDownCHA_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "WIS";
            // 
            // numericUpDownWIS
            // 
            this.numericUpDownWIS.Location = new System.Drawing.Point(67, 123);
            this.numericUpDownWIS.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownWIS.Name = "numericUpDownWIS";
            this.numericUpDownWIS.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownWIS.TabIndex = 8;
            this.numericUpDownWIS.ValueChanged += new System.EventHandler(this.numericUpDownWIS_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "CON";
            // 
            // numericUpDownCON
            // 
            this.numericUpDownCON.Location = new System.Drawing.Point(67, 97);
            this.numericUpDownCON.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownCON.Name = "numericUpDownCON";
            this.numericUpDownCON.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCON.TabIndex = 6;
            this.numericUpDownCON.ValueChanged += new System.EventHandler(this.numericUpDownCON_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "DEX";
            // 
            // numericUpDownDEX
            // 
            this.numericUpDownDEX.Location = new System.Drawing.Point(67, 71);
            this.numericUpDownDEX.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownDEX.Name = "numericUpDownDEX";
            this.numericUpDownDEX.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownDEX.TabIndex = 4;
            this.numericUpDownDEX.ValueChanged += new System.EventHandler(this.numericUpDownDEX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "INT";
            // 
            // numericUpDownINT
            // 
            this.numericUpDownINT.Location = new System.Drawing.Point(67, 45);
            this.numericUpDownINT.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownINT.Name = "numericUpDownINT";
            this.numericUpDownINT.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownINT.TabIndex = 2;
            this.numericUpDownINT.ValueChanged += new System.EventHandler(this.numericUpDownINT_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "STR";
            // 
            // numericUpDownSTR
            // 
            this.numericUpDownSTR.Location = new System.Drawing.Point(67, 19);
            this.numericUpDownSTR.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownSTR.Name = "numericUpDownSTR";
            this.numericUpDownSTR.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSTR.TabIndex = 0;
            this.numericUpDownSTR.ValueChanged += new System.EventHandler(this.numericUpDownSTR_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxCHAFinal);
            this.groupBox2.Controls.Add(this.textBoxWISFinal);
            this.groupBox2.Controls.Add(this.textBoxCONFinal);
            this.groupBox2.Controls.Add(this.textBoxDEXFinal);
            this.groupBox2.Controls.Add(this.textBoxINTFinal);
            this.groupBox2.Controls.Add(this.textBoxSTRFinal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 186);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Base Attributes";
            // 
            // textBoxCHAFinal
            // 
            this.textBoxCHAFinal.Location = new System.Drawing.Point(54, 154);
            this.textBoxCHAFinal.Name = "textBoxCHAFinal";
            this.textBoxCHAFinal.ReadOnly = true;
            this.textBoxCHAFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxCHAFinal.TabIndex = 23;
            // 
            // textBoxWISFinal
            // 
            this.textBoxWISFinal.Location = new System.Drawing.Point(54, 130);
            this.textBoxWISFinal.Name = "textBoxWISFinal";
            this.textBoxWISFinal.ReadOnly = true;
            this.textBoxWISFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxWISFinal.TabIndex = 22;
            // 
            // textBoxCONFinal
            // 
            this.textBoxCONFinal.Location = new System.Drawing.Point(54, 104);
            this.textBoxCONFinal.Name = "textBoxCONFinal";
            this.textBoxCONFinal.ReadOnly = true;
            this.textBoxCONFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxCONFinal.TabIndex = 21;
            // 
            // textBoxDEXFinal
            // 
            this.textBoxDEXFinal.Location = new System.Drawing.Point(54, 78);
            this.textBoxDEXFinal.Name = "textBoxDEXFinal";
            this.textBoxDEXFinal.ReadOnly = true;
            this.textBoxDEXFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxDEXFinal.TabIndex = 20;
            // 
            // textBoxINTFinal
            // 
            this.textBoxINTFinal.Location = new System.Drawing.Point(54, 52);
            this.textBoxINTFinal.Name = "textBoxINTFinal";
            this.textBoxINTFinal.ReadOnly = true;
            this.textBoxINTFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxINTFinal.TabIndex = 19;
            // 
            // textBoxSTRFinal
            // 
            this.textBoxSTRFinal.Location = new System.Drawing.Point(54, 26);
            this.textBoxSTRFinal.Name = "textBoxSTRFinal";
            this.textBoxSTRFinal.ReadOnly = true;
            this.textBoxSTRFinal.Size = new System.Drawing.Size(100, 20);
            this.textBoxSTRFinal.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "CHA";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "STR";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "WIS";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(25, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "INT";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 15;
            this.label12.Text = "CON";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "DEX";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Location = new System.Drawing.Point(232, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(485, 610);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Standard values : 15, 14, 13, 12, 10, 8";
            // 
            // CharacterCreatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 634);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxSubRace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMainRace);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.textBoxCharName);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxCHAFinal;
        private System.Windows.Forms.TextBox textBoxWISFinal;
        private System.Windows.Forms.TextBox textBoxCONFinal;
        private System.Windows.Forms.TextBox textBoxDEXFinal;
        private System.Windows.Forms.TextBox textBoxINTFinal;
        private System.Windows.Forms.TextBox textBoxSTRFinal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label16;
    }
}