
namespace CharacterManager.UserControls.Levelup
{
    partial class FormChooseCombatManeuvers
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.userControlManeuverChoiceAvailableManeuvers = new CharacterManager.UserControls.ChoiceList.UserControlManeuverChoice();
            this.userControlManeuverChoiceChosenManeuvers = new CharacterManager.UserControls.ChoiceList.UserControlManeuverChoice();
            this.buttonOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.userControlManeuverChoiceAvailableManeuvers);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 497);
            this.panel1.TabIndex = 2;
            // 
            // userControlManeuverChoiceAvailableManeuvers
            // 
            this.userControlManeuverChoiceAvailableManeuvers.IsAvailabilityCount = true;
            this.userControlManeuverChoiceAvailableManeuvers.IsBorder = true;
            this.userControlManeuverChoiceAvailableManeuvers.IsCheckBoxed = true;
            this.userControlManeuverChoiceAvailableManeuvers.Location = new System.Drawing.Point(3, 3);
            this.userControlManeuverChoiceAvailableManeuvers.MaximumAvailableChoices = 0;
            this.userControlManeuverChoiceAvailableManeuvers.Name = "userControlManeuverChoiceAvailableManeuvers";
            this.userControlManeuverChoiceAvailableManeuvers.Size = new System.Drawing.Size(285, 491);
            this.userControlManeuverChoiceAvailableManeuvers.TabIndex = 1;
            this.userControlManeuverChoiceAvailableManeuvers.TitleString = "Available Maneuvers";
            // 
            // userControlManeuverChoiceChosenManeuvers
            // 
            this.userControlManeuverChoiceChosenManeuvers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlManeuverChoiceChosenManeuvers.IsAvailabilityCount = false;
            this.userControlManeuverChoiceChosenManeuvers.IsBorder = true;
            this.userControlManeuverChoiceChosenManeuvers.IsCheckBoxed = false;
            this.userControlManeuverChoiceChosenManeuvers.Location = new System.Drawing.Point(310, 15);
            this.userControlManeuverChoiceChosenManeuvers.MaximumAvailableChoices = 0;
            this.userControlManeuverChoiceChosenManeuvers.Name = "userControlManeuverChoiceChosenManeuvers";
            this.userControlManeuverChoiceChosenManeuvers.Size = new System.Drawing.Size(319, 491);
            this.userControlManeuverChoiceChosenManeuvers.TabIndex = 0;
            this.userControlManeuverChoiceChosenManeuvers.TitleString = "Chosen Maneuvers";
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(12, 521);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 34);
            this.buttonOk.TabIndex = 3;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormChooseCombatManeuvers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 567);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.userControlManeuverChoiceChosenManeuvers);
            this.Name = "FormChooseCombatManeuvers";
            this.Text = "FormChooseCombatManeuvers";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ChoiceList.UserControlManeuverChoice userControlManeuverChoiceChosenManeuvers;
        private ChoiceList.UserControlManeuverChoice userControlManeuverChoiceAvailableManeuvers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonOk;
    }
}