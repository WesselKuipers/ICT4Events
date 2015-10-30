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
            this.tbPanelReplies = new System.Windows.Forms.TableLayoutPanel();
            this.tbReplyMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btReply = new System.Windows.Forms.Button();
            this.tbPanelMainPost = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPanelReplies
            // 
            this.tbPanelReplies.AutoScroll = true;
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
            // tbPanelMainPost
            // 
            this.tbPanelMainPost.AutoSize = true;
            this.tbPanelMainPost.BackColor = System.Drawing.SystemColors.Control;
            this.tbPanelMainPost.ColumnCount = 1;
            this.tbPanelMainPost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelMainPost.Location = new System.Drawing.Point(16, 3);
            this.tbPanelMainPost.Name = "tbPanelMainPost";
            this.tbPanelMainPost.RowCount = 1;
            this.tbPanelMainPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbPanelMainPost.Size = new System.Drawing.Size(643, 123);
            this.tbPanelMainPost.TabIndex = 29;
            // 
            // PostFeedExtended
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tbPanelMainPost);
            this.Controls.Add(this.tbPanelReplies);
            this.Controls.Add(this.groupBox1);
            this.Name = "PostFeedExtended";
            this.Size = new System.Drawing.Size(679, 649);
            this.Load += new System.EventHandler(this.PostFeedExtended_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tbPanelReplies;
        private System.Windows.Forms.TextBox tbReplyMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btReply;
        private System.Windows.Forms.TableLayoutPanel tbPanelMainPost;
    }
}
