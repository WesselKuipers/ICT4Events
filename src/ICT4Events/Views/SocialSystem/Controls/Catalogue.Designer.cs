namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class Catalogue
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
            this.tbpLoadUcUpload = new System.Windows.Forms.TableLayoutPanel();
            this.trvCatalogue = new System.Windows.Forms.TreeView();
            this.picCatalogue = new System.Windows.Forms.PictureBox();
            this.tbpLoadUcUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCatalogue)).BeginInit();
            this.SuspendLayout();
            // 
            // tbpLoadUcUpload
            // 
            this.tbpLoadUcUpload.ColumnCount = 2;
            this.tbpLoadUcUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tbpLoadUcUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tbpLoadUcUpload.Controls.Add(this.trvCatalogue, 0, 0);
            this.tbpLoadUcUpload.Controls.Add(this.picCatalogue, 1, 0);
            this.tbpLoadUcUpload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpLoadUcUpload.Location = new System.Drawing.Point(0, 0);
            this.tbpLoadUcUpload.Name = "tbpLoadUcUpload";
            this.tbpLoadUcUpload.RowCount = 2;
            this.tbpLoadUcUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tbpLoadUcUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpLoadUcUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tbpLoadUcUpload.Size = new System.Drawing.Size(630, 380);
            this.tbpLoadUcUpload.TabIndex = 0;
            // 
            // trvCatalogue
            // 
            this.trvCatalogue.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvCatalogue.Location = new System.Drawing.Point(3, 3);
            this.trvCatalogue.Name = "trvCatalogue";
            this.tbpLoadUcUpload.SetRowSpan(this.trvCatalogue, 2);
            this.trvCatalogue.Size = new System.Drawing.Size(183, 374);
            this.trvCatalogue.TabIndex = 2;
            this.trvCatalogue.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvCatalogue_AfterSelect);
            // 
            // picCatalogue
            // 
            this.picCatalogue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCatalogue.Location = new System.Drawing.Point(192, 3);
            this.picCatalogue.Name = "picCatalogue";
            this.picCatalogue.Size = new System.Drawing.Size(435, 279);
            this.picCatalogue.TabIndex = 3;
            this.picCatalogue.TabStop = false;
            // 
            // Catalogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.tbpLoadUcUpload);
            this.Name = "Catalogue";
            this.Size = new System.Drawing.Size(630, 380);
            this.Load += new System.EventHandler(this.Catalogue_Load);
            this.tbpLoadUcUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCatalogue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbpLoadUcUpload;
        private System.Windows.Forms.TreeView trvCatalogue;
        private System.Windows.Forms.PictureBox picCatalogue;
    }
}
