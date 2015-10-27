namespace ICT4Events.Views.Accountsystem.Controls
{
    partial class UcManagePermissions
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
            this.lbUsers = new System.Windows.Forms.ListBox();
            this.btnUpdatePermissions = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPermTypes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbUsers
            // 
            this.lbUsers.FormattingEnabled = true;
            this.lbUsers.Location = new System.Drawing.Point(3, 3);
            this.lbUsers.Name = "lbUsers";
            this.lbUsers.Size = new System.Drawing.Size(560, 277);
            this.lbUsers.TabIndex = 1;
            this.lbUsers.SelectedIndexChanged += new System.EventHandler(this.lbUsers_SelectedIndexChanged);
            // 
            // btnUpdatePermissions
            // 
            this.btnUpdatePermissions.Location = new System.Drawing.Point(447, 284);
            this.btnUpdatePermissions.Name = "btnUpdatePermissions";
            this.btnUpdatePermissions.Size = new System.Drawing.Size(116, 23);
            this.btnUpdatePermissions.TabIndex = 2;
            this.btnUpdatePermissions.Text = "Wijzig Permission";
            this.btnUpdatePermissions.UseVisualStyleBackColor = true;
            this.btnUpdatePermissions.Click += new System.EventHandler(this.btnUpdatePermissions_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(190, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Permissions";
            // 
            // cbPermTypes
            // 
            this.cbPermTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPermTypes.FormattingEnabled = true;
            this.cbPermTypes.Location = new System.Drawing.Point(258, 286);
            this.cbPermTypes.Name = "cbPermTypes";
            this.cbPermTypes.Size = new System.Drawing.Size(183, 21);
            this.cbPermTypes.TabIndex = 4;
            // 
            // UcManagePermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbPermTypes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUpdatePermissions);
            this.Controls.Add(this.lbUsers);
            this.Name = "UcManagePermissions";
            this.Size = new System.Drawing.Size(566, 314);
            this.Load += new System.EventHandler(this.ucManagePermissions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbUsers;
        private System.Windows.Forms.Button btnUpdatePermissions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPermTypes;
    }
}
