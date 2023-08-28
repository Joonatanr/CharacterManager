
namespace CharacterManager.Items
{
    partial class UserControlWeaponCustomizer
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
            this.checkBoxIsAmmunition = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxIsFinesse = new System.Windows.Forms.CheckBox();
            this.groupBoxWeight = new System.Windows.Forms.GroupBox();
            this.radioButtonHeavy = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.radioButtonLight = new System.Windows.Forms.RadioButton();
            this.checkBoxLoading = new System.Windows.Forms.CheckBox();
            this.checkBoxIsThrown = new System.Windows.Forms.CheckBox();
            this.checkBoxTwoHanded = new System.Windows.Forms.CheckBox();
            this.checkBoxIsVersatile = new System.Windows.Forms.CheckBox();
            this.checkBoxIsReach = new System.Windows.Forms.CheckBox();
            this.groupBoxRanged = new System.Windows.Forms.GroupBox();
            this.checkBoxRanged = new System.Windows.Forms.CheckBox();
            this.textBoxNormalRange = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLongRange = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButtonMartial = new System.Windows.Forms.RadioButton();
            this.radioButtonSimple = new System.Windows.Forms.RadioButton();
            this.textBoxReach = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBaseDamage = new System.Windows.Forms.TextBox();
            this.comboBoxBaseDamageType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox2HDamage = new System.Windows.Forms.ComboBox();
            this.textBox2HDamage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAmmoType = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxExtraDamage = new System.Windows.Forms.ComboBox();
            this.textBoxExtraDamage = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxIsMagical = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxMagicalBonus = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxWeight.SuspendLayout();
            this.groupBoxRanged.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxIsAmmunition
            // 
            this.checkBoxIsAmmunition.AutoSize = true;
            this.checkBoxIsAmmunition.Location = new System.Drawing.Point(15, 39);
            this.checkBoxIsAmmunition.Name = "checkBoxIsAmmunition";
            this.checkBoxIsAmmunition.Size = new System.Drawing.Size(80, 17);
            this.checkBoxIsAmmunition.TabIndex = 0;
            this.checkBoxIsAmmunition.Text = "Ammunition";
            this.checkBoxIsAmmunition.UseVisualStyleBackColor = true;
            this.checkBoxIsAmmunition.CheckedChanged += new System.EventHandler(this.checkBoxIsAmmunition_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBoxRanged);
            this.groupBox1.Controls.Add(this.groupBoxWeight);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 257);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Weapon Specific Properties";
            // 
            // checkBoxIsFinesse
            // 
            this.checkBoxIsFinesse.AutoSize = true;
            this.checkBoxIsFinesse.Location = new System.Drawing.Point(6, 16);
            this.checkBoxIsFinesse.Name = "checkBoxIsFinesse";
            this.checkBoxIsFinesse.Size = new System.Drawing.Size(62, 17);
            this.checkBoxIsFinesse.TabIndex = 1;
            this.checkBoxIsFinesse.Text = "Finesse";
            this.checkBoxIsFinesse.UseVisualStyleBackColor = true;
            this.checkBoxIsFinesse.CheckedChanged += new System.EventHandler(this.checkBoxIsFinesse_CheckedChanged);
            // 
            // groupBoxWeight
            // 
            this.groupBoxWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWeight.Controls.Add(this.radioButtonLight);
            this.groupBoxWeight.Controls.Add(this.radioButtonNormal);
            this.groupBoxWeight.Controls.Add(this.radioButtonHeavy);
            this.groupBoxWeight.Location = new System.Drawing.Point(289, 121);
            this.groupBoxWeight.Name = "groupBoxWeight";
            this.groupBoxWeight.Size = new System.Drawing.Size(117, 130);
            this.groupBoxWeight.TabIndex = 2;
            this.groupBoxWeight.TabStop = false;
            this.groupBoxWeight.Text = "Weapon Size Type";
            // 
            // radioButtonHeavy
            // 
            this.radioButtonHeavy.AutoSize = true;
            this.radioButtonHeavy.Location = new System.Drawing.Point(6, 19);
            this.radioButtonHeavy.Name = "radioButtonHeavy";
            this.radioButtonHeavy.Size = new System.Drawing.Size(56, 17);
            this.radioButtonHeavy.TabIndex = 0;
            this.radioButtonHeavy.TabStop = true;
            this.radioButtonHeavy.Text = "Heavy";
            this.radioButtonHeavy.UseVisualStyleBackColor = true;
            this.radioButtonHeavy.CheckedChanged += new System.EventHandler(this.radioButtonHeavy_CheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(6, 42);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(58, 17);
            this.radioButtonNormal.TabIndex = 1;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.radioButtonNormal_CheckedChanged);
            // 
            // radioButtonLight
            // 
            this.radioButtonLight.AutoSize = true;
            this.radioButtonLight.Location = new System.Drawing.Point(6, 65);
            this.radioButtonLight.Name = "radioButtonLight";
            this.radioButtonLight.Size = new System.Drawing.Size(48, 17);
            this.radioButtonLight.TabIndex = 2;
            this.radioButtonLight.TabStop = true;
            this.radioButtonLight.Text = "Light";
            this.radioButtonLight.UseVisualStyleBackColor = true;
            this.radioButtonLight.CheckedChanged += new System.EventHandler(this.radioButtonLight_CheckedChanged);
            // 
            // checkBoxLoading
            // 
            this.checkBoxLoading.AutoSize = true;
            this.checkBoxLoading.Location = new System.Drawing.Point(15, 59);
            this.checkBoxLoading.Name = "checkBoxLoading";
            this.checkBoxLoading.Size = new System.Drawing.Size(64, 17);
            this.checkBoxLoading.TabIndex = 3;
            this.checkBoxLoading.Text = "Loading";
            this.checkBoxLoading.UseVisualStyleBackColor = true;
            this.checkBoxLoading.CheckedChanged += new System.EventHandler(this.checkBoxLoading_CheckedChanged);
            // 
            // checkBoxIsThrown
            // 
            this.checkBoxIsThrown.AutoSize = true;
            this.checkBoxIsThrown.Location = new System.Drawing.Point(15, 79);
            this.checkBoxIsThrown.Name = "checkBoxIsThrown";
            this.checkBoxIsThrown.Size = new System.Drawing.Size(62, 17);
            this.checkBoxIsThrown.TabIndex = 4;
            this.checkBoxIsThrown.Text = "Thrown";
            this.checkBoxIsThrown.UseVisualStyleBackColor = true;
            this.checkBoxIsThrown.CheckedChanged += new System.EventHandler(this.checkBoxIsThrown_CheckedChanged);
            // 
            // checkBoxTwoHanded
            // 
            this.checkBoxTwoHanded.AutoSize = true;
            this.checkBoxTwoHanded.Location = new System.Drawing.Point(6, 39);
            this.checkBoxTwoHanded.Name = "checkBoxTwoHanded";
            this.checkBoxTwoHanded.Size = new System.Drawing.Size(88, 17);
            this.checkBoxTwoHanded.TabIndex = 5;
            this.checkBoxTwoHanded.Text = "Two-Handed";
            this.checkBoxTwoHanded.UseVisualStyleBackColor = true;
            this.checkBoxTwoHanded.CheckedChanged += new System.EventHandler(this.checkBoxTwoHanded_CheckedChanged);
            // 
            // checkBoxIsVersatile
            // 
            this.checkBoxIsVersatile.AutoSize = true;
            this.checkBoxIsVersatile.Location = new System.Drawing.Point(6, 62);
            this.checkBoxIsVersatile.Name = "checkBoxIsVersatile";
            this.checkBoxIsVersatile.Size = new System.Drawing.Size(66, 17);
            this.checkBoxIsVersatile.TabIndex = 6;
            this.checkBoxIsVersatile.Text = "Versatile";
            this.checkBoxIsVersatile.UseVisualStyleBackColor = true;
            this.checkBoxIsVersatile.CheckedChanged += new System.EventHandler(this.checkBoxIsVersatile_CheckedChanged);
            // 
            // checkBoxIsReach
            // 
            this.checkBoxIsReach.AutoSize = true;
            this.checkBoxIsReach.Location = new System.Drawing.Point(6, 85);
            this.checkBoxIsReach.Name = "checkBoxIsReach";
            this.checkBoxIsReach.Size = new System.Drawing.Size(58, 17);
            this.checkBoxIsReach.TabIndex = 7;
            this.checkBoxIsReach.Text = "Reach";
            this.checkBoxIsReach.UseVisualStyleBackColor = true;
            this.checkBoxIsReach.CheckedChanged += new System.EventHandler(this.checkBoxIsReach_CheckedChanged);
            // 
            // groupBoxRanged
            // 
            this.groupBoxRanged.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxRanged.Controls.Add(this.label9);
            this.groupBoxRanged.Controls.Add(this.label8);
            this.groupBoxRanged.Controls.Add(this.textBoxAmmoType);
            this.groupBoxRanged.Controls.Add(this.label2);
            this.groupBoxRanged.Controls.Add(this.textBoxLongRange);
            this.groupBoxRanged.Controls.Add(this.label1);
            this.groupBoxRanged.Controls.Add(this.textBoxNormalRange);
            this.groupBoxRanged.Controls.Add(this.checkBoxRanged);
            this.groupBoxRanged.Controls.Add(this.checkBoxIsAmmunition);
            this.groupBoxRanged.Controls.Add(this.checkBoxIsThrown);
            this.groupBoxRanged.Controls.Add(this.checkBoxLoading);
            this.groupBoxRanged.Location = new System.Drawing.Point(289, 13);
            this.groupBoxRanged.Name = "groupBoxRanged";
            this.groupBoxRanged.Size = new System.Drawing.Size(244, 106);
            this.groupBoxRanged.TabIndex = 8;
            this.groupBoxRanged.TabStop = false;
            this.groupBoxRanged.Text = "Ranged Properties";
            // 
            // checkBoxRanged
            // 
            this.checkBoxRanged.AutoSize = true;
            this.checkBoxRanged.Location = new System.Drawing.Point(15, 19);
            this.checkBoxRanged.Name = "checkBoxRanged";
            this.checkBoxRanged.Size = new System.Drawing.Size(70, 17);
            this.checkBoxRanged.TabIndex = 5;
            this.checkBoxRanged.Text = "Ranged?";
            this.checkBoxRanged.UseVisualStyleBackColor = true;
            this.checkBoxRanged.CheckedChanged += new System.EventHandler(this.checkBoxRanged_CheckedChanged);
            // 
            // textBoxNormalRange
            // 
            this.textBoxNormalRange.Location = new System.Drawing.Point(185, 16);
            this.textBoxNormalRange.Name = "textBoxNormalRange";
            this.textBoxNormalRange.Size = new System.Drawing.Size(53, 20);
            this.textBoxNormalRange.TabIndex = 6;
            this.textBoxNormalRange.TextChanged += new System.EventHandler(this.textBoxNormalRange_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Normal Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Long Range";
            // 
            // textBoxLongRange
            // 
            this.textBoxLongRange.Location = new System.Drawing.Point(185, 42);
            this.textBoxLongRange.Name = "textBoxLongRange";
            this.textBoxLongRange.Size = new System.Drawing.Size(53, 20);
            this.textBoxLongRange.TabIndex = 8;
            this.textBoxLongRange.TextChanged += new System.EventHandler(this.textBoxLongRange_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBoxReach);
            this.groupBox2.Controls.Add(this.checkBoxIsFinesse);
            this.groupBox2.Controls.Add(this.checkBoxTwoHanded);
            this.groupBox2.Controls.Add(this.checkBoxIsVersatile);
            this.groupBox2.Controls.Add(this.checkBoxIsReach);
            this.groupBox2.Location = new System.Drawing.Point(6, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 106);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.comboBoxExtraDamage);
            this.groupBox3.Controls.Add(this.textBoxExtraDamage);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.comboBox2HDamage);
            this.groupBox3.Controls.Add(this.textBox2HDamage);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.comboBoxBaseDamageType);
            this.groupBox3.Controls.Add(this.textBoxBaseDamage);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(6, 121);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(277, 130);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Weapon Damage";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.radioButtonMartial);
            this.groupBox4.Controls.Add(this.radioButtonSimple);
            this.groupBox4.Location = new System.Drawing.Point(412, 121);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(117, 57);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Weapon Type";
            // 
            // radioButtonMartial
            // 
            this.radioButtonMartial.AutoSize = true;
            this.radioButtonMartial.Location = new System.Drawing.Point(6, 33);
            this.radioButtonMartial.Name = "radioButtonMartial";
            this.radioButtonMartial.Size = new System.Drawing.Size(56, 17);
            this.radioButtonMartial.TabIndex = 1;
            this.radioButtonMartial.TabStop = true;
            this.radioButtonMartial.Text = "Martial";
            this.radioButtonMartial.UseVisualStyleBackColor = true;
            this.radioButtonMartial.CheckedChanged += new System.EventHandler(this.radioButtonMartial_CheckedChanged);
            // 
            // radioButtonSimple
            // 
            this.radioButtonSimple.AutoSize = true;
            this.radioButtonSimple.Location = new System.Drawing.Point(6, 14);
            this.radioButtonSimple.Name = "radioButtonSimple";
            this.radioButtonSimple.Size = new System.Drawing.Size(56, 17);
            this.radioButtonSimple.TabIndex = 0;
            this.radioButtonSimple.TabStop = true;
            this.radioButtonSimple.Text = "Simple";
            this.radioButtonSimple.UseVisualStyleBackColor = true;
            this.radioButtonSimple.CheckedChanged += new System.EventHandler(this.radioButtonSimple_CheckedChanged);
            // 
            // textBoxReach
            // 
            this.textBoxReach.Location = new System.Drawing.Point(153, 82);
            this.textBoxReach.Name = "textBoxReach";
            this.textBoxReach.Size = new System.Drawing.Size(55, 20);
            this.textBoxReach.TabIndex = 8;
            this.textBoxReach.TextChanged += new System.EventHandler(this.textBoxReach_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reach (ft)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Base Damage";
            // 
            // textBoxBaseDamage
            // 
            this.textBoxBaseDamage.Location = new System.Drawing.Point(86, 17);
            this.textBoxBaseDamage.Name = "textBoxBaseDamage";
            this.textBoxBaseDamage.Size = new System.Drawing.Size(51, 20);
            this.textBoxBaseDamage.TabIndex = 1;
            this.textBoxBaseDamage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaseDamage_KeyPress);
            this.textBoxBaseDamage.Leave += new System.EventHandler(this.textBoxBaseDamage_Leave);
            // 
            // comboBoxBaseDamageType
            // 
            this.comboBoxBaseDamageType.FormattingEnabled = true;
            this.comboBoxBaseDamageType.Location = new System.Drawing.Point(180, 16);
            this.comboBoxBaseDamageType.Name = "comboBoxBaseDamageType";
            this.comboBoxBaseDamageType.Size = new System.Drawing.Size(91, 21);
            this.comboBoxBaseDamageType.TabIndex = 2;
            this.comboBoxBaseDamageType.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaseDamageType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Type";
            // 
            // comboBox2HDamage
            // 
            this.comboBox2HDamage.FormattingEnabled = true;
            this.comboBox2HDamage.Location = new System.Drawing.Point(180, 43);
            this.comboBox2HDamage.Name = "comboBox2HDamage";
            this.comboBox2HDamage.Size = new System.Drawing.Size(91, 21);
            this.comboBox2HDamage.TabIndex = 6;
            this.comboBox2HDamage.SelectedIndexChanged += new System.EventHandler(this.comboBox2HDamage_SelectedIndexChanged);
            // 
            // textBox2HDamage
            // 
            this.textBox2HDamage.Location = new System.Drawing.Point(86, 44);
            this.textBox2HDamage.Name = "textBox2HDamage";
            this.textBox2HDamage.Size = new System.Drawing.Size(51, 20);
            this.textBox2HDamage.TabIndex = 5;
            this.textBox2HDamage.TextChanged += new System.EventHandler(this.textBox2HDamage_TextChanged);
            this.textBox2HDamage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2HDamage_KeyPress);
            this.textBox2HDamage.Leave += new System.EventHandler(this.textBox2HDamage_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "2H Damage";
            // 
            // textBoxAmmoType
            // 
            this.textBoxAmmoType.Location = new System.Drawing.Point(185, 68);
            this.textBoxAmmoType.Name = "textBoxAmmoType";
            this.textBoxAmmoType.Size = new System.Drawing.Size(53, 20);
            this.textBoxAmmoType.TabIndex = 10;
            this.textBoxAmmoType.TextChanged += new System.EventHandler(this.textBoxAmmoType_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Ammo Type";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(87, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "(Bolts, Arrows etc)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(143, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Type";
            // 
            // comboBoxExtraDamage
            // 
            this.comboBoxExtraDamage.FormattingEnabled = true;
            this.comboBoxExtraDamage.Location = new System.Drawing.Point(180, 70);
            this.comboBoxExtraDamage.Name = "comboBoxExtraDamage";
            this.comboBoxExtraDamage.Size = new System.Drawing.Size(91, 21);
            this.comboBoxExtraDamage.TabIndex = 10;
            this.comboBoxExtraDamage.SelectedIndexChanged += new System.EventHandler(this.comboBoxExtraDamage_SelectedIndexChanged);
            // 
            // textBoxExtraDamage
            // 
            this.textBoxExtraDamage.Location = new System.Drawing.Point(86, 71);
            this.textBoxExtraDamage.Name = "textBoxExtraDamage";
            this.textBoxExtraDamage.Size = new System.Drawing.Size(51, 20);
            this.textBoxExtraDamage.TabIndex = 9;
            this.textBoxExtraDamage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxExtraDamage_KeyPress);
            this.textBoxExtraDamage.Leave += new System.EventHandler(this.textBoxExtraDamage_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 8;
            this.label11.Text = "Extra Damage";
            // 
            // checkBoxIsMagical
            // 
            this.checkBoxIsMagical.AutoSize = true;
            this.checkBoxIsMagical.Location = new System.Drawing.Point(6, 19);
            this.checkBoxIsMagical.Name = "checkBoxIsMagical";
            this.checkBoxIsMagical.Size = new System.Drawing.Size(107, 17);
            this.checkBoxIsMagical.TabIndex = 12;
            this.checkBoxIsMagical.Text = "Magical Weapon";
            this.checkBoxIsMagical.UseVisualStyleBackColor = true;
            this.checkBoxIsMagical.CheckedChanged += new System.EventHandler(this.checkBoxIsMagical_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.textBoxMagicalBonus);
            this.groupBox5.Controls.Add(this.checkBoxIsMagical);
            this.groupBox5.Location = new System.Drawing.Point(412, 177);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(117, 74);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Magical Properties";
            // 
            // textBoxMagicalBonus
            // 
            this.textBoxMagicalBonus.Location = new System.Drawing.Point(6, 42);
            this.textBoxMagicalBonus.Name = "textBoxMagicalBonus";
            this.textBoxMagicalBonus.Size = new System.Drawing.Size(44, 20);
            this.textBoxMagicalBonus.TabIndex = 13;
            this.textBoxMagicalBonus.TextChanged += new System.EventHandler(this.textBoxMagicalBonus_TextChanged);
            this.textBoxMagicalBonus.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMagicalBonus_KeyPress);
            this.textBoxMagicalBonus.Leave += new System.EventHandler(this.textBoxMagicalBonus_Leave);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(56, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Bonus";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "(+1, +2. +3)";
            // 
            // UserControlWeaponCustomizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlWeaponCustomizer";
            this.Size = new System.Drawing.Size(541, 263);
            this.groupBox1.ResumeLayout(false);
            this.groupBoxWeight.ResumeLayout(false);
            this.groupBoxWeight.PerformLayout();
            this.groupBoxRanged.ResumeLayout(false);
            this.groupBoxRanged.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxIsAmmunition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBoxWeight;
        private System.Windows.Forms.RadioButton radioButtonLight;
        private System.Windows.Forms.RadioButton radioButtonNormal;
        private System.Windows.Forms.RadioButton radioButtonHeavy;
        private System.Windows.Forms.CheckBox checkBoxIsFinesse;
        private System.Windows.Forms.GroupBox groupBoxRanged;
        private System.Windows.Forms.CheckBox checkBoxIsThrown;
        private System.Windows.Forms.CheckBox checkBoxLoading;
        private System.Windows.Forms.CheckBox checkBoxIsReach;
        private System.Windows.Forms.CheckBox checkBoxIsVersatile;
        private System.Windows.Forms.CheckBox checkBoxTwoHanded;
        private System.Windows.Forms.CheckBox checkBoxRanged;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNormalRange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLongRange;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radioButtonMartial;
        private System.Windows.Forms.RadioButton radioButtonSimple;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxReach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxBaseDamageType;
        private System.Windows.Forms.TextBox textBoxBaseDamage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox2HDamage;
        private System.Windows.Forms.TextBox textBox2HDamage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxExtraDamage;
        private System.Windows.Forms.TextBox textBoxExtraDamage;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAmmoType;
        private System.Windows.Forms.CheckBox checkBoxIsMagical;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxMagicalBonus;
        private System.Windows.Forms.Label label13;
    }
}
