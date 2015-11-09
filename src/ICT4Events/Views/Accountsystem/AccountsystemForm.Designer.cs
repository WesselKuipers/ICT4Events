namespace ICT4Events.Views.Accountsystem
{
    partial class AccountSystemForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tcAccountsystem = new System.Windows.Forms.TabControl();
            this.tabEditUser = new System.Windows.Forms.TabPage();
            this.tcAccountsystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcAccountsystem
            // 
            this.tcAccountsystem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAccountsystem.Controls.Add(this.tabEditUser);
            this.tcAccountsystem.Location = new System.Drawing.Point(12, 12);
            this.tcAccountsystem.Name = "tcAccountsystem";
            this.tcAccountsystem.SelectedIndex = 0;
            this.tcAccountsystem.Size = new System.Drawing.Size(582, 373);
            this.tcAccountsystem.TabIndex = 0;
            // 
            // tabEditUser
            // 
            this.tabEditUser.BackColor = System.Drawing.SystemColors.Control;
            this.tabEditUser.Location = new System.Drawing.Point(4, 22);
            this.tabEditUser.Name = "tabEditUser";
            this.tabEditUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditUser.Size = new System.Drawing.Size(574, 347);
            this.tabEditUser.TabIndex = 0;
            this.tabEditUser.Text = "Wijzig Account";
            // 
            // AccountSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 397);
            this.Controls.Add(this.tcAccountsystem);
            this.Name = "AccountSystemForm";
            this.Text = "Accountbeheer";
            this.Load += new System.EventHandler(this.Accountsystem_Load);
            this.tcAccountsystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcAccountsystem;
        private System.Windows.Forms.TabPage tabEditUser;
    }
}