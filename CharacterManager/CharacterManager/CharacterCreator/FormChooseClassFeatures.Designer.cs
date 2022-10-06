namespace CharacterManager.CharacterCreator
{
    partial class FormChooseClassFeatures
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxClassAbilities = new System.Windows.Forms.GroupBox();
            this.groupBoxToolProficiencies = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(586, 441);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(667, 441);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxClassAbilities
            // 
            this.groupBoxClassAbilities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxClassAbilities.Location = new System.Drawing.Point(12, 12);
            this.groupBoxClassAbilities.Name = "groupBoxClassAbilities";
            this.groupBoxClassAbilities.Size = new System.Drawing.Size(527, 423);
            this.groupBoxClassAbilities.TabIndex = 2;
            this.groupBoxClassAbilities.TabStop = false;
            this.groupBoxClassAbilities.Text = "Class Abilities";
            // 
            // groupBoxToolProficiencies
            // 
            this.groupBoxToolProficiencies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxToolProficiencies.Location = new System.Drawing.Point(550, 12);
            this.groupBoxToolProficiencies.Name = "groupBoxToolProficiencies";
            this.groupBoxToolProficiencies.Size = new System.Drawing.Size(197, 216);
            this.groupBoxToolProficiencies.TabIndex = 3;
            this.groupBoxToolProficiencies.TabStop = false;
            this.groupBoxToolProficiencies.Text = "Tool Proficiencies";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(550, 234);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 201);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // FormChooseClassFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 476);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBoxToolProficiencies);
            this.Controls.Add(this.groupBoxClassAbilities);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "FormChooseClassFeatures";
            this.Text = "FormChooseClassFeatures";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxClassAbilities;
        private System.Windows.Forms.GroupBox groupBoxToolProficiencies;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}