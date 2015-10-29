namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class PostFeedExtended
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
            this.lblDeletePost = new System.Windows.Forms.LinkLabel();
            this.lblCountLikes = new System.Windows.Forms.Label();
            this.lblUnLike = new System.Windows.Forms.LinkLabel();
            this.lblDownloadMedia = new System.Windows.Forms.LinkLabel();
            this.lblDatum = new System.Windows.Forms.Label();
            this.pbMediaMessage = new System.Windows.Forms.PictureBox();
            this.lblAuteurNaam = new System.Windows.Forms.Label();
            this.lbReport1 = new System.Windows.Forms.Label();
            this.lbLike = new System.Windows.Forms.LinkLabel();
            this.lbReport = new System.Windows.Forms.LinkLabel();
            this.tbPanelReplies = new System.Windows.Forms.TableLayoutPanel();
            this.tbReplyMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btReply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaMessage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDeletePost
            // 
            this.lblDeletePost.AutoSize = true;
            this.lblDeletePost.Location = new System.Drawing.Point(330, 112);
            this.lblDeletePost.Name = "lblDeletePost";
            this.lblDeletePost.Size = new System.Drawing.Size(62, 13);
            this.lblDeletePost.TabIndex = 25;
            this.lblDeletePost.TabStop = true;
            this.lblDeletePost.Text = "Verwijderen";
            this.lblDeletePost.Visible = false;
            this.lblDeletePost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDeletePost_LinkClicked);
            // 
            // lblCountLikes
            // 
            this.lblCountLikes.AutoSize = true;
            this.lblCountLikes.Location = new System.Drawing.Point(353, 8);
            this.lblCountLikes.Name = "lblCountLikes";
            this.lblCountLikes.Size = new System.Drawing.Size(131, 13);
            this.lblCountLikes.TabIndex = 24;
            this.lblCountLikes.Text = "0 mens(en) vinden dit leuk";
            // 
            // lblUnLike
            // 
            this.lblUnLike.AutoSize = true;
            this.lblUnLike.Location = new System.Drawing.Point(402, 112);
            this.lblUnLike.Name = "lblUnLike";
            this.lblUnLike.Size = new System.Drawing.Size(82, 13);
            this.lblUnLike.TabIndex = 23;
            this.lblUnLike.TabStop = true;
            this.lblUnLike.Text = "Vind ik niet leuk";
            this.lblUnLike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblUnLike_LinkClicked);
            // 
            // lblDownloadMedia
            // 
            this.lblDownloadMedia.AutoSize = true;
            this.lblDownloadMedia.Location = new System.Drawing.Point(577, 112);
            this.lblDownloadMedia.Name = "lblDownloadMedia";
            this.lblDownloadMedia.Size = new System.Drawing.Size(67, 13);
            this.lblDownloadMedia.TabIndex = 21;
            this.lblDownloadMedia.TabStop = true;
            this.lblDownloadMedia.Text = "Downloaden";
            this.lblDownloadMedia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDownloadMedia_LinkClicked);
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(27, 109);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(73, 13);
            this.lblDatum.TabIndex = 20;
            this.lblDatum.Text = "Geplaatst op: ";
            // 
            // pbMediaMessage
            // 
            this.pbMediaMessage.BackColor = System.Drawing.Color.White;
            this.pbMediaMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbMediaMessage.Location = new System.Drawing.Point(490, 22);
            this.pbMediaMessage.Name = "pbMediaMessage";
            this.pbMediaMessage.Size = new System.Drawing.Size(154, 87);
            this.pbMediaMessage.TabIndex = 19;
            this.pbMediaMessage.TabStop = false;
            this.pbMediaMessage.Tag = "";
            // 
            // lblAuteurNaam
            // 
            this.lblAuteurNaam.AutoSize = true;
            this.lblAuteurNaam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuteurNaam.Location = new System.Drawing.Point(27, 6);
            this.lblAuteurNaam.Name = "lblAuteurNaam";
            this.lblAuteurNaam.Size = new System.Drawing.Size(163, 16);
            this.lblAuteurNaam.TabIndex = 17;
            this.lblAuteurNaam.Text = "Naam Plaatser Bericht";
            // 
            // lbReport1
            // 
            this.lbReport1.BackColor = System.Drawing.Color.White;
            this.lbReport1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbReport1.Location = new System.Drawing.Point(30, 22);
            this.lbReport1.Name = "lbReport1";
            this.lbReport1.Size = new System.Drawing.Size(454, 87);
            this.lbReport1.TabIndex = 18;
            this.lbReport1.Text = "Inhoud van het bericht met mogelijkheid voor meerdere regels. bla bla bla";
            // 
            // lbLike
            // 
            this.lbLike.AutoSize = true;
            this.lbLike.Location = new System.Drawing.Point(412, 112);
            this.lbLike.Name = "lbLike";
            this.lbLike.Size = new System.Drawing.Size(62, 13);
            this.lbLike.TabIndex = 26;
            this.lbLike.TabStop = true;
            this.lbLike.Text = "Vind ik leuk";
            this.lbLike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbLike_LinkClicked);
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(330, 112);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(66, 13);
            this.lbReport.TabIndex = 27;
            this.lbReport.TabStop = true;
            this.lbReport.Text = "Rapporteren";
            this.lbReport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbReport_LinkClicked);
            // 
            // tbPanelReplies
            // 
            this.tbPanelReplies.AutoSize = true;
            this.tbPanelReplies.BackColor = System.Drawing.SystemColors.Control;
            this.tbPanelReplies.ColumnCount = 1;
            this.tbPanelReplies.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelReplies.Location = new System.Drawing.Point(16, 254);
            this.tbPanelReplies.Name = "tbPanelReplies";
            this.tbPanelReplies.RowCount = 1;
            this.tbPanelReplies.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelReplies.Size = new System.Drawing.Size(643, 130);
            this.tbPanelReplies.TabIndex = 28;
            // 
            // tbReplyMessage
            // 
            this.tbReplyMessage.Location = new System.Drawing.Point(14, 19);
            this.tbReplyMessage.Multiline = true;
            this.tbReplyMessage.Name = "tbReplyMessage";
            this.tbReplyMessage.Size = new System.Drawing.Size(614, 52);
            this.tbReplyMessage.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btReply);
            this.groupBox1.Controls.Add(this.tbReplyMessage);
            this.groupBox1.Location = new System.Drawing.Point(16, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 116);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // btReply
            // 
            this.btReply.Location = new System.Drawing.Point(498, 77);
            this.btReply.Name = "btReply";
            this.btReply.Size = new System.Drawing.Size(130, 23);
            this.btReply.TabIndex = 30;
            this.btReply.Text = "Reageren";
            this.btReply.UseVisualStyleBackColor = true;
            this.btReply.Click += new System.EventHandler(this.btReply_Click);
            // 
            // PostFeedExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tbPanelReplies);
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.lblDeletePost);
            this.Controls.Add(this.lblCountLikes);
            this.Controls.Add(this.lblUnLike);
            this.Controls.Add(this.lblDownloadMedia);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.pbMediaMessage);
            this.Controls.Add(this.lblAuteurNaam);
            this.Controls.Add(this.lbReport1);
            this.Controls.Add(this.lbLike);
            this.Controls.Add(this.groupBox1);
            this.Name = "PostFeedExtended";
            this.Size = new System.Drawing.Size(679, 588);
            this.Load += new System.EventHandler(this.PostFeedExtended_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaMessage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lblDeletePost;
        private System.Windows.Forms.Label lblCountLikes;
        private System.Windows.Forms.LinkLabel lblUnLike;
        private System.Windows.Forms.LinkLabel lblDownloadMedia;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.PictureBox pbMediaMessage;
        private System.Windows.Forms.Label lblAuteurNaam;
        private System.Windows.Forms.Label lbReport1;
        private System.Windows.Forms.LinkLabel lbLike;
        private System.Windows.Forms.LinkLabel lbReport;
        private System.Windows.Forms.TableLayoutPanel tbPanelReplies;
        private System.Windows.Forms.TextBox tbReplyMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btReply;
    }
}
