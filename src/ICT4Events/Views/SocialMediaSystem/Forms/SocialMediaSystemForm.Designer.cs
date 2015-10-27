namespace ICT4Events.Views.SocialMediaSystem.Forms
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbTimeLine = new System.Windows.Forms.TabPage();
            this.tbMakePost = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbTimeLine);
            this.tabControl1.Controls.Add(this.tbMakePost);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 436);
            this.tabControl1.TabIndex = 0;
            // 
            // tbTimeLine
            // 
            this.tbTimeLine.Location = new System.Drawing.Point(4, 22);
            this.tbTimeLine.Name = "tbTimeLine";
            this.tbTimeLine.Padding = new System.Windows.Forms.Padding(3);
            this.tbTimeLine.Size = new System.Drawing.Size(801, 410);
            this.tbTimeLine.TabIndex = 0;
            this.tbTimeLine.Text = "Tijdlijn";
            this.tbTimeLine.UseVisualStyleBackColor = true;
            // 
            // tbMakePost
            // 
            this.tbMakePost.Location = new System.Drawing.Point(4, 22);
            this.tbMakePost.Name = "tbMakePost";
            this.tbMakePost.Padding = new System.Windows.Forms.Padding(3);
            this.tbMakePost.Size = new System.Drawing.Size(801, 410);
            this.tbMakePost.TabIndex = 1;
            this.tbMakePost.Text = "Post aanmaken";
            this.tbMakePost.UseVisualStyleBackColor = true;
            // 
            // SocialMediaSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "SocialMediaSystemForm";
            this.Text = "SocialMediaSystemFormcs";
            this.Load += new System.EventHandler(this.SocialMediaSystemForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbTimeLine;
        private System.Windows.Forms.TabPage tbMakePost;
    }
}