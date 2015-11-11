namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class UcUpload
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
            this.gbUpload = new System.Windows.Forms.GroupBox();
            this.btBestandUploaden = new System.Windows.Forms.Button();
            this.pbPreview = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.gbUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // gbUpload
            // 
            this.gbUpload.Controls.Add(this.btBestandUploaden);
            this.gbUpload.Controls.Add(this.pbPreview);
            this.gbUpload.Controls.Add(this.label2);
            this.gbUpload.Controls.Add(this.btnUpload);
            this.gbUpload.Location = new System.Drawing.Point(3, 3);
            this.gbUpload.Name = "gbUpload";
            this.gbUpload.Size = new System.Drawing.Size(482, 133);
            this.gbUpload.TabIndex = 8;
            this.gbUpload.TabStop = false;
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
            // pbPreview
            // 
            this.pbPreview.Location = new System.Drawing.Point(226, 11);
            this.pbPreview.Name = "pbPreview";
            this.pbPreview.Size = new System.Drawing.Size(204, 116);
            this.pbPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPreview.TabIndex = 5;
            this.pbPreview.TabStop = false;
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
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(19, 43);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(167, 23);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Selecteer een bestand...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // UcUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUpload);
            this.Name = "UcUpload";
            this.Size = new System.Drawing.Size(500, 148);
            this.gbUpload.ResumeLayout(false);
            this.gbUpload.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbUpload;
        private System.Windows.Forms.Button btBestandUploaden;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pbPreview;
        public System.Windows.Forms.Button btnUpload;
    }
}
