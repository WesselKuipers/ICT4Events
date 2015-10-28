namespace ICT4Events.Views.SocialSystem.Controls
{
    partial class PostFeed
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
            this.lbReaction = new System.Windows.Forms.Label();
            this.pbMediaMessage = new System.Windows.Forms.PictureBox();
            this.lblPostMessage = new System.Windows.Forms.Label();
            this.lblAuteurNaam = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.lbPostBekijken = new System.Windows.Forms.Label();
            this.lbLike = new System.Windows.Forms.Label();
            this.lbReport = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaMessage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbReaction
            // 
            this.lbReaction.AutoSize = true;
            this.lbReaction.Location = new System.Drawing.Point(420, 103);
            this.lbReaction.Name = "lbReaction";
            this.lbReaction.Size = new System.Drawing.Size(54, 13);
            this.lbReaction.TabIndex = 0;
            this.lbReaction.Text = "Reageren";
            // 
            // pbMediaMessage
            // 
            this.pbMediaMessage.Location = new System.Drawing.Point(497, 16);
            this.pbMediaMessage.Name = "pbMediaMessage";
            this.pbMediaMessage.Size = new System.Drawing.Size(154, 87);
            this.pbMediaMessage.TabIndex = 5;
            this.pbMediaMessage.TabStop = false;
            this.pbMediaMessage.Tag = "";
            // 
            // lblPostMessage
            // 
            this.lblPostMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPostMessage.Location = new System.Drawing.Point(37, 16);
            this.lblPostMessage.Name = "lblPostMessage";
            this.lblPostMessage.Size = new System.Drawing.Size(454, 87);
            this.lblPostMessage.TabIndex = 4;
            this.lblPostMessage.Text = "Inhoud van het bericht met mogelijkheid voor meerdere regels. bla bla bla";
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
            this.lblDatum.Size = new System.Drawing.Size(35, 13);
            this.lblDatum.TabIndex = 6;
            this.lblDatum.Text = "label1";
            // 
            // lbPostBekijken
            // 
            this.lbPostBekijken.AutoSize = true;
            this.lbPostBekijken.Location = new System.Drawing.Point(274, 103);
            this.lbPostBekijken.Name = "lbPostBekijken";
            this.lbPostBekijken.Size = new System.Drawing.Size(72, 13);
            this.lbPostBekijken.TabIndex = 7;
            this.lbPostBekijken.Text = "Post Bekijken";
            // 
            // lbLike
            // 
            this.lbLike.AutoSize = true;
            this.lbLike.Location = new System.Drawing.Point(352, 103);
            this.lbLike.Name = "lbLike";
            this.lbLike.Size = new System.Drawing.Size(62, 13);
            this.lbLike.TabIndex = 8;
            this.lbLike.Text = "Vind ik leuk";
            // 
            // lbReport
            // 
            this.lbReport.AutoSize = true;
            this.lbReport.Location = new System.Drawing.Point(202, 103);
            this.lbReport.Name = "lbReport";
            this.lbReport.Size = new System.Drawing.Size(66, 13);
            this.lbReport.TabIndex = 9;
            this.lbReport.Text = "Rapporteren";
            // 
            // PostFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbReport);
            this.Controls.Add(this.lbLike);
            this.Controls.Add(this.lbPostBekijken);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.pbMediaMessage);
            this.Controls.Add(this.lblAuteurNaam);
            this.Controls.Add(this.lbReaction);
            this.Controls.Add(this.lblPostMessage);
            this.Name = "PostFeed";
            this.Size = new System.Drawing.Size(670, 130);
            this.Load += new System.EventHandler(this.PostFeed_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbMediaMessage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbReaction;
        private System.Windows.Forms.PictureBox pbMediaMessage;
        private System.Windows.Forms.Label lblPostMessage;
        private System.Windows.Forms.Label lblAuteurNaam;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Label lbPostBekijken;
        private System.Windows.Forms.Label lbLike;
        private System.Windows.Forms.Label lbReport;
    }
}
