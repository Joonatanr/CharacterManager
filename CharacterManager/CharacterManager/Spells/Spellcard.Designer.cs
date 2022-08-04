namespace CharacterManager.Spells
{
    partial class Spellcard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Spellcard));
            this.button1 = new System.Windows.Forms.Button();
            this.labelSpellName = new System.Windows.Forms.Label();
            this.labelSpellType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCastingTime = new System.Windows.Forms.Label();
            this.labelRange = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelComponents = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.richTextBoxDescription = new CharacterManager.Spells.CustomRTB();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(588, 448);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelSpellName
            // 
            this.labelSpellName.AutoSize = true;
            this.labelSpellName.BackColor = System.Drawing.Color.Transparent;
            this.labelSpellName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelSpellName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSpellName.Location = new System.Drawing.Point(12, 9);
            this.labelSpellName.Name = "labelSpellName";
            this.labelSpellName.Size = new System.Drawing.Size(105, 26);
            this.labelSpellName.TabIndex = 1;
            this.labelSpellName.Text = "Fire Bolt";
            // 
            // labelSpellType
            // 
            this.labelSpellType.AutoSize = true;
            this.labelSpellType.BackColor = System.Drawing.Color.Transparent;
            this.labelSpellType.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelSpellType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSpellType.Location = new System.Drawing.Point(11, 32);
            this.labelSpellType.Name = "labelSpellType";
            this.labelSpellType.Size = new System.Drawing.Size(122, 19);
            this.labelSpellType.TabIndex = 2;
            this.labelSpellType.Text = "cantrip evocation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Casting Time:";
            // 
            // labelCastingTime
            // 
            this.labelCastingTime.AutoSize = true;
            this.labelCastingTime.BackColor = System.Drawing.Color.Transparent;
            this.labelCastingTime.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelCastingTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelCastingTime.Location = new System.Drawing.Point(136, 74);
            this.labelCastingTime.Name = "labelCastingTime";
            this.labelCastingTime.Size = new System.Drawing.Size(57, 19);
            this.labelCastingTime.TabIndex = 4;
            this.labelCastingTime.Text = "1 action";
            // 
            // labelRange
            // 
            this.labelRange.AutoSize = true;
            this.labelRange.BackColor = System.Drawing.Color.Transparent;
            this.labelRange.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelRange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelRange.Location = new System.Drawing.Point(136, 94);
            this.labelRange.Name = "labelRange";
            this.labelRange.Size = new System.Drawing.Size(59, 19);
            this.labelRange.TabIndex = 6;
            this.labelRange.Text = "120 feet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(12, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Range:";
            // 
            // labelComponents
            // 
            this.labelComponents.AutoSize = true;
            this.labelComponents.BackColor = System.Drawing.Color.Transparent;
            this.labelComponents.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelComponents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelComponents.Location = new System.Drawing.Point(136, 114);
            this.labelComponents.Name = "labelComponents";
            this.labelComponents.Size = new System.Drawing.Size(33, 19);
            this.labelComponents.TabIndex = 8;
            this.labelComponents.Text = "V S";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(12, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 22);
            this.label8.TabIndex = 7;
            this.label8.Text = "Components:";
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.BackColor = System.Drawing.Color.Transparent;
            this.labelDuration.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.labelDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDuration.Location = new System.Drawing.Point(136, 134);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(91, 19);
            this.labelDuration.TabIndex = 10;
            this.labelDuration.Text = "Instantaneous";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(12, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 22);
            this.label10.TabIndex = 9;
            this.label10.Text = "Duration:";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDescription.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.richTextBoxDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBoxDescription.Location = new System.Drawing.Point(17, 169);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(646, 273);
            this.richTextBoxDescription.TabIndex = 11;
            this.richTextBoxDescription.Text = resources.GetString("richTextBoxDescription.Text");
            // 
            // Spellcard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CharacterManager.Properties.Resources.old_paper_texture;
            this.ClientSize = new System.Drawing.Size(675, 483);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelComponents);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelRange);
            this.Controls.Add(this.labelCastingTime);
            this.Controls.Add(this.labelSpellType);
            this.Controls.Add(this.labelSpellName);
            this.Controls.Add(this.button1);
            this.Name = "Spellcard";
            this.Text = "Spellcard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelSpellName;
        private System.Windows.Forms.Label labelSpellType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCastingTime;
        private System.Windows.Forms.Label labelRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelComponents;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.Label label10;
        private CustomRTB richTextBoxDescription;
    }
}