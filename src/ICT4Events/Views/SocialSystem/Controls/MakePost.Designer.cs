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
            this.btUploaden = new System.Windows.Forms.Button();
            this.btPostAanmaken = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.btBestandUploaden = new System.Windows.Forms.Button();
            this.gbUpload = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.gbUpload.SuspendLayout();
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
            this.tbBerichtPost.Location = new System.Drawing.Point(18, 26);
            this.tbBerichtPost.Multiline = true;
            this.tbBerichtPost.Name = "tbBerichtPost";
            this.tbBerichtPost.Size = new System.Drawing.Size(482, 166);
            this.tbBerichtPost.TabIndex = 1;
            this.tbBerichtPost.Text = "Wat wil je met ons delen? #think";
            // 
            // btUploaden
            // 
            this.btUploaden.Location = new System.Drawing.Point(19, 43);
            this.btUploaden.Name = "btUploaden";
            this.btUploaden.Size = new System.Drawing.Size(167, 23);
            this.btUploaden.TabIndex = 2;
            this.btUploaden.Text = "Selecteer een bestand...";
            this.btUploaden.UseVisualStyleBackColor = true;
            this.btUploaden.Click += new System.EventHandler(this.btUploaden_Click);
            // 
            // btPostAanmaken
            // 
            this.btPostAanmaken.Location = new System.Drawing.Point(181, 337);
            this.btPostAanmaken.Name = "btPostAanmaken";
            this.btPostAanmaken.Size = new System.Drawing.Size(112, 23);
            this.btPostAanmaken.TabIndex = 3;
            this.btPostAanmaken.Text = "Post aanmaken";
            this.btPostAanmaken.UseVisualStyleBackColor = true;
            this.btPostAanmaken.Click += new System.EventHandler(this.btPostAanmaken_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Foto of video uploaden?";
            // 
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(272, 11);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(204, 116);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
            // 
            // btBestandUploaden
            // 
            this.btBestandUploaden.Location = new System.Drawing.Point(19, 72);
            this.btBestandUploaden.Name = "btBestandUploaden";
            this.btBestandUploaden.Size = new System.Drawing.Size(107, 23);
            this.btBestandUploaden.TabIndex = 6;
            this.btBestandUploaden.Text = "Bestand uploaden";
            this.btBestandUploaden.UseVisualStyleBackColor = true;
            this.btBestandUploaden.Click += new System.EventHandler(this.btBestandUploaden_Click);
            // 
            // gbUpload
            // 
            this.gbUpload.Controls.Add(this.btBestandUploaden);
            this.gbUpload.Controls.Add(this.pbPreview);
            this.gbUpload.Controls.Add(this.label2);
            this.gbUpload.Controls.Add(this.btUploaden);
            this.gbUpload.Location = new System.Drawing.Point(18, 198);
            this.gbUpload.Name = "gbUpload";
            this.gbUpload.Size = new System.Drawing.Size(482, 133);
            this.gbUpload.TabIndex = 7;
            this.gbUpload.TabStop = false;
            // 
            // MakePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btPostAanmaken);
            this.Controls.Add(this.tbBerichtPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbUpload);
            this.Name = "MakePost";
            this.Size = new System.Drawing.Size(503, 385);
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.gbUpload.ResumeLayout(false);
            this.gbUpload.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBerichtPost;
        private System.Windows.Forms.Button btUploaden;
        private System.Windows.Forms.Button btPostAanmaken;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btBestandUploaden;
        private System.Windows.Forms.GroupBox gbUpload;
    }
}
