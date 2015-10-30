namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class SearchByTag
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTag = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panelPosts = new System.Windows.Forms.TableLayoutPanel();
            this.lblNoPostsFound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zoek naar posts met:  #";
            // 
            // txtTag
            // 
            this.txtTag.Location = new System.Drawing.Point(129, 6);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(197, 20);
            this.txtTag.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(332, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Zoeken";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panelPosts
            // 
            this.panelPosts.AutoSize = true;
            this.panelPosts.BackColor = System.Drawing.SystemColors.Control;
            this.panelPosts.ColumnCount = 1;
            this.panelPosts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPosts.Location = new System.Drawing.Point(5, 32);
            this.panelPosts.Name = "panelPosts";
            this.panelPosts.RowCount = 1;
            this.panelPosts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelPosts.Size = new System.Drawing.Size(670, 130);
            this.panelPosts.TabIndex = 3;
            // 
            // lblNoPostsFound
            // 
            this.lblNoPostsFound.AutoSize = true;
            this.lblNoPostsFound.ForeColor = System.Drawing.Color.Red;
            this.lblNoPostsFound.Location = new System.Drawing.Point(448, 9);
            this.lblNoPostsFound.Name = "lblNoPostsFound";
            this.lblNoPostsFound.Size = new System.Drawing.Size(205, 13);
            this.lblNoPostsFound.TabIndex = 4;
            this.lblNoPostsFound.Text = "Er zijn geen posts gevonden met deze tag";
            this.lblNoPostsFound.Visible = false;
            // 
            // SearchByTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoPostsFound);
            this.Controls.Add(this.panelPosts);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.label1);
            this.Name = "SearchByTag";
            this.Size = new System.Drawing.Size(680, 559);
            this.Load += new System.EventHandler(this.SearchByTag_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTag;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TableLayoutPanel panelPosts;
        private System.Windows.Forms.Label lblNoPostsFound;
    }
}
