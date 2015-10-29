namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class ReplyPost
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
            this.lbReport1 = new System.Windows.Forms.Label();
            this.lblAuteurNaam = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lbLike = new System.Windows.Forms.LinkLabel();
            this.lbReport = new System.Windows.Forms.LinkLabel();
            this.lblUnLike = new System.Windows.Forms.LinkLabel();
            this.lblCountLikes = new System.Windows.Forms.Label();
            this.lblDeletePost = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbReport1
            // 
            this.lbReport1.BackColor = System.Drawing.Color.White;
            this.lbReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbReport1.Location = new System.Drawing.Point(37, 16);
            this.lbReport1.Name = "lbReport1";
            this.lbReport1.Size = new System.Drawing.Size(617, 87);
            this.lbReport1.TabIndex = 4;
            this.lbReport1.Text = "Inhoud van het bericht met mogelijkheid voor meerdere regels. bla bla bla";
            // 
            // lblAuteurNaam
            // 
            this.lblAuteurNaam.AutoSize = true;
            this.lblAuteurNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuteurNaam.Location = new System.Drawing.Point(34, 0);
            this.lblAuteurNaam.Name = "lblAuteurNaam";
            this.lblAuteurNaam.Size = new System.Drawing.Size(163, 16);
            this.lblAuteurNaam.TabIndex = 3;
            this.lblAuteurNaam.Text = "Naam Plaatser Bericht";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(34, 103);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(73, 13);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Text = "Geplaatst op: ";
            // 
            // lbLike
            // 
            this.lbLike.AutoSize = true;
            this.lbLike.Location = new System.Drawing.Point(583, 103);
            this.lbLike.Name = "lbLike";
            this.lbLike.Size = new System.Drawing.Size(62, 13);
            this.lbLike.TabIndex = 12;
            this.lbLike.TabStop = true;
            this.lbLike.Text = "Vind ik leuk";
            this.lbLike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLike_LinkClicked);
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(500, 103);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(66, 13);
            this.lbReport.TabIndex = 13;
            this.lbReport.TabStop = true;
            this.lbReport.Text = "Rapporteren";
            this.lbReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReport_LinkClicked);
            // 
            // lblUnLike
            // 
            this.lblUnLike.AutoSize = true;
            this.lblUnLike.Location = new System.Drawing.Point(572, 103);
            this.lblUnLike.Name = "lblUnLike";
            this.lblUnLike.Size = new System.Drawing.Size(82, 13);
            this.lblUnLike.TabIndex = 14;
            this.lblUnLike.TabStop = true;
            this.lblUnLike.Text = "Vind ik niet leuk";
            this.lblUnLike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUnLike_LinkClicked);
            // 
            // lblCountLikes
            // 
            this.lblCountLikes.AutoSize = true;
            this.lblCountLikes.Location = new System.Drawing.Point(523, 3);
            this.lblCountLikes.Name = "lblCountLikes";
            this.lblCountLikes.Size = new System.Drawing.Size(131, 13);
            this.lblCountLikes.TabIndex = 15;
            this.lblCountLikes.Text = "0 mens(en) vinden dit leuk";
            // 
            // lblDeletePost
            // 
            this.lblDeletePost.AutoSize = true;
            this.lblDeletePost.Location = new System.Drawing.Point(504, 103);
            this.lblDeletePost.Name = "lblDeletePost";
            this.lblDeletePost.Size = new System.Drawing.Size(62, 13);
            this.lblDeletePost.TabIndex = 16;
            this.lblDeletePost.TabStop = true;
            this.lblDeletePost.Text = "Verwijderen";
            this.lblDeletePost.Visible = false;
            this.lblDeletePost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeletePost_LinkClicked);
            // 
            // ReplyPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblDeletePost);
            this.Controls.Add(this.lblCountLikes);
            this.Controls.Add(this.lblUnLike);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.lbLike);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.lblAuteurNaam);
            this.Controls.Add(this.lbReport1);
            this.Name = "ReplyPost";
            this.Size = new System.Drawing.Size(670, 130);
            this.Load += new System.EventHandler(this.ReplyPost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbReport1;
        private System.Windows.Forms.Label lblAuteurNaam;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.LinkLabel lbLike;
        private System.Windows.Forms.LinkLabel lbReport;
        private System.Windows.Forms.LinkLabel lblUnLike;
        private System.Windows.Forms.Label lblCountLikes;
        private System.Windows.Forms.LinkLabel lblDeletePost;
    }
}
