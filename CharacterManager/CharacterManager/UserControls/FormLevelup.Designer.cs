
namespace CharacterManager.UserControls
{
    partial class FormLevelup
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxHPResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dieRollHitPointsRoll = new CharacterManager.UserControls.DieRollTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelNewMaxHP = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Next Level : 2";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(16, 448);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelNewMaxHP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxHPResult);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.dieRollHitPointsRoll);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hit Points";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Roll HP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxHPResult
            // 
            this.textBoxHPResult.Location = new System.Drawing.Point(242, 23);
            this.textBoxHPResult.Name = "textBoxHPResult";
            this.textBoxHPResult.Size = new System.Drawing.Size(71, 20);
            this.textBoxHPResult.TabIndex = 2;
            this.textBoxHPResult.TextChanged += new System.EventHandler(this.textBoxHPResult_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Result:";
            // 
            // dieRollHitPointsRoll
            // 
            this.dieRollHitPointsRoll.DieRollObject = null;
            this.dieRollHitPointsRoll.Location = new System.Drawing.Point(72, 22);
            this.dieRollHitPointsRoll.Name = "dieRollHitPointsRoll";
            this.dieRollHitPointsRoll.ReadOnly = true;
            this.dieRollHitPointsRoll.Size = new System.Drawing.Size(100, 20);
            this.dieRollHitPointsRoll.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Max HP:";
            // 
            // labelNewMaxHP
            // 
            this.labelNewMaxHP.AutoSize = true;
            this.labelNewMaxHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewMaxHP.Location = new System.Drawing.Point(389, 22);
            this.labelNewMaxHP.Name = "labelNewMaxHP";
            this.labelNewMaxHP.Size = new System.Drawing.Size(27, 20);
            this.labelNewMaxHP.TabIndex = 5;
            this.labelNewMaxHP.Text = "10";
            // 
            // FormLevelup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 483);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Name = "FormLevelup";
            this.Text = "FormLevelup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private DieRollTextBox dieRollHitPointsRoll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHPResult;
        private System.Windows.Forms.Label labelNewMaxHP;
        private System.Windows.Forms.Label label3;
    }
}