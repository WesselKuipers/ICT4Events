namespace ICT4Events.Views.SocialSystem.Forms
{
    partial class ExtendedForm
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
            this.tbcExtendedForm = new System.Windows.Forms.TabControl();
            this.tbpPostWatch = new System.Windows.Forms.TabPage();
            this.tbcExtendedForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcExtendedForm
            // 
            this.tbcExtendedForm.Controls.Add(this.tbpPostWatch);
            this.tbcExtendedForm.Location = new System.Drawing.Point(12, 12);
            this.tbcExtendedForm.Name = "tbcExtendedForm";
            this.tbcExtendedForm.SelectedIndex = 0;
            this.tbcExtendedForm.Size = new System.Drawing.Size(736, 637);
            this.tbcExtendedForm.TabIndex = 0;
            // 
            // tbpPostWatch
            // 
            this.tbpPostWatch.Location = new System.Drawing.Point(4, 22);
            this.tbpPostWatch.Name = "tbpPostWatch";
            this.tbpPostWatch.Size = new System.Drawing.Size(728, 611);
            this.tbpPostWatch.TabIndex = 0;
            this.tbpPostWatch.Text = "Post bekijken";
            this.tbpPostWatch.UseVisualStyleBackColor = true;
            // 
            // ExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 661);
            this.Controls.Add(this.tbcExtendedForm);
            this.Name = "ExtendedForm";
            this.Text = "Bericht bekijken";
            this.tbcExtendedForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabControl tbcExtendedForm;
        public System.Windows.Forms.TabPage tbpPostWatch;
    }
}