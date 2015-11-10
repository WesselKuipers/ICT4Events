namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class MakePost
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
            this.tbBerichtPost = new System.Windows.Forms.TextBox();
            this.btPostAanmaken = new System.Windows.Forms.Button();
            this.tbpLoadUcUpload = new System.Windows.Forms.TableLayoutPanel();
            this.cmbOwnMedia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshOwnMediaList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bericht";
            // 
            // tbBerichtPost
            // 
            this.tbBerichtPost.Location = new System.Drawing.Point(3, 3);
            this.tbBerichtPost.Multiline = true;
            this.tbBerichtPost.Name = "tbBerichtPost";
            this.tbBerichtPost.Size = new System.Drawing.Size(622, 142);
            this.tbBerichtPost.TabIndex = 1;
            this.tbBerichtPost.Text = "Wat wil je met ons delen? #think";
            // 
            // btPostAanmaken
            // 
            this.btPostAanmaken.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btPostAanmaken.Location = new System.Drawing.Point(0, 344);
            this.btPostAanmaken.Name = "btPostAanmaken";
            this.btPostAanmaken.Size = new System.Drawing.Size(637, 41);
            this.btPostAanmaken.TabIndex = 3;
            this.btPostAanmaken.Text = "Post aanmaken";
            this.btPostAanmaken.UseVisualStyleBackColor = true;
            this.btPostAanmaken.Click += new System.EventHandler(this.btPostAanmaken_Click);
            // 
            // tbpLoadUcUpload
            // 
            this.tbpLoadUcUpload.ColumnCount = 1;
            this.tbpLoadUcUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbpLoadUcUpload.Location = new System.Drawing.Point(3, 151);
            this.tbpLoadUcUpload.Name = "tbpLoadUcUpload";
            this.tbpLoadUcUpload.RowCount = 1;
            this.tbpLoadUcUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbpLoadUcUpload.Size = new System.Drawing.Size(622, 148);
            this.tbpLoadUcUpload.TabIndex = 4;
            // 
            // cmbOwnMedia
            // 
            this.cmbOwnMedia.FormattingEnabled = true;
            this.cmbOwnMedia.Location = new System.Drawing.Point(18, 317);
            this.cmbOwnMedia.Name = "cmbOwnMedia";
            this.cmbOwnMedia.Size = new System.Drawing.Size(307, 21);
            this.cmbOwnMedia.TabIndex = 5;
            this.cmbOwnMedia.SelectionChangeCommitted += new System.EventHandler(this.cmbOwnMedia_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Je eigen media uploaden?";
            // 
            // btnRefreshOwnMediaList
            // 
            this.btnRefreshOwnMediaList.Location = new System.Drawing.Point(331, 317);
            this.btnRefreshOwnMediaList.Name = "btnRefreshOwnMediaList";
            this.btnRefreshOwnMediaList.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshOwnMediaList.TabIndex = 7;
            this.btnRefreshOwnMediaList.Text = "Herladen";
            this.btnRefreshOwnMediaList.UseVisualStyleBackColor = true;
            this.btnRefreshOwnMediaList.Click += new System.EventHandler(this.btnRefreshOwnMediaList_Click);
            // 
            // MakePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefreshOwnMediaList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbOwnMedia);
            this.Controls.Add(this.tbpLoadUcUpload);
            this.Controls.Add(this.btPostAanmaken);
            this.Controls.Add(this.tbBerichtPost);
            this.Controls.Add(this.label1);
            this.Name = "MakePost";
            this.Size = new System.Drawing.Size(637, 385);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBerichtPost;
        private System.Windows.Forms.Button btPostAanmaken;
        private System.Windows.Forms.TableLayoutPanel tbpLoadUcUpload;
        private System.Windows.Forms.ComboBox cmbOwnMedia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshOwnMediaList;
    }
}
