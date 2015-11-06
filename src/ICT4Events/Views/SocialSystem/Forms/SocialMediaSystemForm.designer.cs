namespace ICT4Events.Views.SocialSystem.Forms
{
    partial class SocialMediaSystemForm
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
            this.tbControlSMSF = new System.Windows.Forms.TabControl();
            this.tbTimeLine = new System.Windows.Forms.TabPage();
            this.tbMakePost = new System.Windows.Forms.TabPage();
            this.tbControlSMSF.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbControlSMSF
            // 
            this.tbControlSMSF.Controls.Add(this.tbTimeLine);
            this.tbControlSMSF.Controls.Add(this.tbMakePost);
            this.tbControlSMSF.Location = new System.Drawing.Point(12, 12);
            this.tbControlSMSF.Name = "tbControlSMSF";
            this.tbControlSMSF.SelectedIndex = 0;
            this.tbControlSMSF.Size = new System.Drawing.Size(713, 659);
            this.tbControlSMSF.TabIndex = 0;
            // 
            // tbTimeLine
            // 
            this.tbTimeLine.Location = new System.Drawing.Point(4, 22);
            this.tbTimeLine.Name = "tbTimeLine";
            this.tbTimeLine.Padding = new System.Windows.Forms.Padding(3);
            this.tbTimeLine.Size = new System.Drawing.Size(705, 633);
            this.tbTimeLine.TabIndex = 0;
            this.tbTimeLine.Text = "Tijdlijn";
            this.tbTimeLine.UseVisualStyleBackColor = true;
            // 
            // tbMakePost
            // 
            this.tbMakePost.Location = new System.Drawing.Point(4, 22);
            this.tbMakePost.Name = "tbMakePost";
            this.tbMakePost.Padding = new System.Windows.Forms.Padding(3);
            this.tbMakePost.Size = new System.Drawing.Size(705, 633);
            this.tbMakePost.TabIndex = 1;
            this.tbMakePost.Text = "Post aanmaken";
            this.tbMakePost.UseVisualStyleBackColor = true;
            // 
            // SocialMediaSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 683);
            this.Controls.Add(this.tbControlSMSF);
            this.Name = "SocialMediaSystemForm";
            this.Text = "SocialMediaSystemFormcs";
            this.Load += new System.EventHandler(this.SocialMediaSystemForm_Load);
            this.tbControlSMSF.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbControlSMSF;
        private System.Windows.Forms.TabPage tbTimeLine;
        private System.Windows.Forms.TabPage tbMakePost;
    }
}