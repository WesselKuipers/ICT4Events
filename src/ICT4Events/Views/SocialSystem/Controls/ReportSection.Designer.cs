namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class ReportSection
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
            this.lbReportsUnder5 = new System.Windows.Forms.ListBox();
            this.lbReportsAbove5 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btPostWatch1 = new System.Windows.Forms.Button();
            this.btHidePost = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btPostWatch2 = new System.Windows.Forms.Button();
            this.btRemoveReports = new System.Windows.Forms.Button();
            this.lbUnvisiblePosts = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btZichtbaarMaken = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btPostWatch3 = new System.Windows.Forms.Button();
            this.lblWelkom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbReportsUnder5
            // 
            this.lbReportsUnder5.FormattingEnabled = true;
            this.lbReportsUnder5.Location = new System.Drawing.Point(22, 40);
            this.lbReportsUnder5.Name = "lbReportsUnder5";
            this.lbReportsUnder5.Size = new System.Drawing.Size(277, 173);
            this.lbReportsUnder5.TabIndex = 0;
            // 
            // lbReportsAbove5
            // 
            this.lbReportsAbove5.FormattingEnabled = true;
            this.lbReportsAbove5.Location = new System.Drawing.Point(33, 40);
            this.lbReportsAbove5.Name = "lbReportsAbove5";
            this.lbReportsAbove5.Size = new System.Drawing.Size(277, 173);
            this.lbReportsAbove5.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btPostWatch1);
            this.groupBox1.Controls.Add(this.btHidePost);
            this.groupBox1.Controls.Add(this.lbReportsUnder5);
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Posts die gerapporteerd zijn tussen 1 en 4 keer";
            // 
            // btPostWatch1
            // 
            this.btPostWatch1.Location = new System.Drawing.Point(22, 248);
            this.btPostWatch1.Name = "btPostWatch1";
            this.btPostWatch1.Size = new System.Drawing.Size(277, 23);
            this.btPostWatch1.TabIndex = 2;
            this.btPostWatch1.Text = "Post bekijken";
            this.btPostWatch1.UseVisualStyleBackColor = true;
            this.btPostWatch1.Click += new System.EventHandler(this.btPostWatch1_Click);
            // 
            // btHidePost
            // 
            this.btHidePost.Location = new System.Drawing.Point(22, 219);
            this.btHidePost.Name = "btHidePost";
            this.btHidePost.Size = new System.Drawing.Size(277, 23);
            this.btHidePost.TabIndex = 1;
            this.btHidePost.Text = "Verbergen";
            this.btHidePost.UseVisualStyleBackColor = true;
            this.btHidePost.Click += new System.EventHandler(this.btHidePost_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbReportsAbove5);
            this.groupBox2.Controls.Add(this.btPostWatch2);
            this.groupBox2.Controls.Add(this.btRemoveReports);
            this.groupBox2.Location = new System.Drawing.Point(339, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 310);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Post die gerapporteerd zijn meer dan 5 keer";
            // 
            // btPostWatch2
            // 
            this.btPostWatch2.Location = new System.Drawing.Point(33, 248);
            this.btPostWatch2.Name = "btPostWatch2";
            this.btPostWatch2.Size = new System.Drawing.Size(277, 23);
            this.btPostWatch2.TabIndex = 3;
            this.btPostWatch2.Text = "Post bekijken";
            this.btPostWatch2.UseVisualStyleBackColor = true;
            this.btPostWatch2.Click += new System.EventHandler(this.btPostWatch2_Click);
            // 
            // btRemoveReports
            // 
            this.btRemoveReports.Location = new System.Drawing.Point(33, 219);
            this.btRemoveReports.Name = "btRemoveReports";
            this.btRemoveReports.Size = new System.Drawing.Size(277, 23);
            this.btRemoveReports.TabIndex = 2;
            this.btRemoveReports.Text = "Reports verwijderen en zichtbaar maken";
            this.btRemoveReports.UseVisualStyleBackColor = true;
            this.btRemoveReports.Click += new System.EventHandler(this.btRemoveReports_Click);
            // 
            // lbUnvisiblePosts
            // 
            this.lbUnvisiblePosts.FormattingEnabled = true;
            this.lbUnvisiblePosts.Location = new System.Drawing.Point(33, 31);
            this.lbUnvisiblePosts.Name = "lbUnvisiblePosts";
            this.lbUnvisiblePosts.Size = new System.Drawing.Size(277, 121);
            this.lbUnvisiblePosts.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btPostWatch3);
            this.groupBox3.Controls.Add(this.btZichtbaarMaken);
            this.groupBox3.Controls.Add(this.lbUnvisiblePosts);
            this.groupBox3.Location = new System.Drawing.Point(339, 373);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 224);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Posts die niet worden weergegeven";
            // 
            // btZichtbaarMaken
            // 
            this.btZichtbaarMaken.Location = new System.Drawing.Point(33, 158);
            this.btZichtbaarMaken.Name = "btZichtbaarMaken";
            this.btZichtbaarMaken.Size = new System.Drawing.Size(277, 23);
            this.btZichtbaarMaken.TabIndex = 5;
            this.btZichtbaarMaken.Text = "Zichtbaar maken";
            this.btZichtbaarMaken.UseVisualStyleBackColor = true;
            this.btZichtbaarMaken.Click += new System.EventHandler(this.btZichtbaarMaken_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(3, 373);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(320, 224);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Statistieken";
            // 
            // btPostWatch3
            // 
            this.btPostWatch3.Location = new System.Drawing.Point(33, 187);
            this.btPostWatch3.Name = "btPostWatch3";
            this.btPostWatch3.Size = new System.Drawing.Size(277, 23);
            this.btPostWatch3.TabIndex = 4;
            this.btPostWatch3.Text = "Post bekijken";
            this.btPostWatch3.UseVisualStyleBackColor = true;
            this.btPostWatch3.Click += new System.EventHandler(this.btPostWatch3_Click);
            // 
            // lblWelkom
            // 
            this.lblWelkom.AutoSize = true;
            this.lblWelkom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelkom.Location = new System.Drawing.Point(3, 25);
            this.lblWelkom.Name = "lblWelkom";
            this.lblWelkom.Size = new System.Drawing.Size(52, 13);
            this.lblWelkom.TabIndex = 7;
            this.lblWelkom.Text = "Welkom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Totaal aantal posts:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "NOT DONE";
            // 
            // ReportSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblWelkom);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Name = "ReportSection";
            this.Size = new System.Drawing.Size(670, 621);
            this.Load += new System.EventHandler(this.ReportSection_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbReportsUnder5;
        private System.Windows.Forms.ListBox lbReportsAbove5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btHidePost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btRemoveReports;
        private System.Windows.Forms.ListBox lbUnvisiblePosts;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btZichtbaarMaken;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btPostWatch1;
        private System.Windows.Forms.Button btPostWatch2;
        private System.Windows.Forms.Button btPostWatch3;
        private System.Windows.Forms.Label lblWelkom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
