
namespace CharacterManager.UserControls
{
    partial class UserControlDieRollBonusValuesHandler
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
            this.components = new System.ComponentModel.Container();
            this.textBoxRollTotalResult = new System.Windows.Forms.TextBox();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.textBoxRollSituational = new System.Windows.Forms.TextBox();
            this.textBoxRollMods = new System.Windows.Forms.TextBox();
            this.labelControlName = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dieRollTextBoxTotalRoll = new CharacterManager.UserControls.DieRollTextBox();
            this.SuspendLayout();
            // 
            // textBoxRollTotalResult
            // 
            this.textBoxRollTotalResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRollTotalResult.Location = new System.Drawing.Point(624, 0);
            this.textBoxRollTotalResult.Name = "textBoxRollTotalResult";
            this.textBoxRollTotalResult.ReadOnly = true;
            this.textBoxRollTotalResult.Size = new System.Drawing.Size(128, 20);
            this.textBoxRollTotalResult.TabIndex = 18;
            this.textBoxRollTotalResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonRoll
            // 
            this.buttonRoll.Location = new System.Drawing.Point(543, 0);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(75, 23);
            this.buttonRoll.TabIndex = 17;
            this.buttonRoll.Text = "Roll";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // textBoxRollSituational
            // 
            this.textBoxRollSituational.Location = new System.Drawing.Point(282, 2);
            this.textBoxRollSituational.Name = "textBoxRollSituational";
            this.textBoxRollSituational.Size = new System.Drawing.Size(130, 20);
            this.textBoxRollSituational.TabIndex = 15;
            this.textBoxRollSituational.Text = "0";
            this.textBoxRollSituational.TextChanged += new System.EventHandler(this.textBoxRollSituational_TextChanged);
            this.textBoxRollSituational.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRollSituational_KeyDown);
            this.textBoxRollSituational.Leave += new System.EventHandler(this.textBoxRollSituational_Leave);
            // 
            // textBoxRollMods
            // 
            this.textBoxRollMods.Location = new System.Drawing.Point(129, 3);
            this.textBoxRollMods.Name = "textBoxRollMods";
            this.textBoxRollMods.ReadOnly = true;
            this.textBoxRollMods.Size = new System.Drawing.Size(147, 20);
            this.textBoxRollMods.TabIndex = 14;
            this.textBoxRollMods.Text = "1d20+3+2+1";
            this.toolTip1.SetToolTip(this.textBoxRollMods, "Hello World");
            // 
            // labelControlName
            // 
            this.labelControlName.AutoSize = true;
            this.labelControlName.BackColor = System.Drawing.Color.Transparent;
            this.labelControlName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControlName.Location = new System.Drawing.Point(11, 3);
            this.labelControlName.Name = "labelControlName";
            this.labelControlName.Size = new System.Drawing.Size(90, 20);
            this.labelControlName.TabIndex = 13;
            this.labelControlName.Text = "Attack Roll:";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 50;
            this.toolTip1.ReshowDelay = 40;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Modifiers";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // dieRollTextBoxTotalRoll
            // 
            this.dieRollTextBoxTotalRoll.DieRollObject = null;
            this.dieRollTextBoxTotalRoll.Location = new System.Drawing.Point(418, 2);
            this.dieRollTextBoxTotalRoll.Name = "dieRollTextBoxTotalRoll";
            this.dieRollTextBoxTotalRoll.Size = new System.Drawing.Size(119, 20);
            this.dieRollTextBoxTotalRoll.TabIndex = 19;
            // 
            // UserControlDieRollBonusValuesHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dieRollTextBoxTotalRoll);
            this.Controls.Add(this.textBoxRollTotalResult);
            this.Controls.Add(this.buttonRoll);
            this.Controls.Add(this.textBoxRollSituational);
            this.Controls.Add(this.textBoxRollMods);
            this.Controls.Add(this.labelControlName);
            this.Name = "UserControlDieRollBonusValuesHandler";
            this.Size = new System.Drawing.Size(813, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxRollTotalResult;
        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.TextBox textBoxRollSituational;
        private System.Windows.Forms.TextBox textBoxRollMods;
        private System.Windows.Forms.Label labelControlName;
        private System.Windows.Forms.ToolTip toolTip1;
        private DieRollTextBox dieRollTextBoxTotalRoll;
    }
}
