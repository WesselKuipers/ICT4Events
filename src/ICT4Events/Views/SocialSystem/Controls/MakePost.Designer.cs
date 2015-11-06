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
            // MakePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
