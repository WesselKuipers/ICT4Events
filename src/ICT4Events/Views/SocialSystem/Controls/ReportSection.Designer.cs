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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbUnvisblePosts = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.lbReportsAbove5.Location = new System.Drawing.Point(372, 97);
            this.lbReportsAbove5.Name = "lbReportsAbove5";
            this.lbReportsAbove5.Size = new System.Drawing.Size(277, 173);
            this.lbReportsAbove5.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbReportsUnder5);
            this.groupBox1.Location = new System.Drawing.Point(3, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 310);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Post die gerapporteerd zijn minder dan 5 keer";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(339, 57);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 310);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Post die gerapporteerd zijn meer dan 5 keer";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Post verbergen";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbUnvisblePosts
            // 
            this.lbUnvisblePosts.FormattingEnabled = true;
            this.lbUnvisblePosts.Location = new System.Drawing.Point(33, 51);
            this.lbUnvisblePosts.Name = "lbUnvisblePosts";
            this.lbUnvisblePosts.Size = new System.Drawing.Size(277, 134);
            this.lbUnvisblePosts.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbUnvisblePosts);
            this.groupBox3.Location = new System.Drawing.Point(339, 383);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 211);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Niet-zichtbare posts";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Reports verwijderen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // ReportSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lbReportsAbove5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ReportSection";
            this.Size = new System.Drawing.Size(670, 606);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbReportsUnder5;
        private System.Windows.Forms.ListBox lbReportsAbove5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox lbUnvisblePosts;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
