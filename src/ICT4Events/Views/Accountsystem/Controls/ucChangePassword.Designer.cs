namespace ICT4Events.Views.Accountsystem.Controls
{
    partial class UcChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOld = new System.Windows.Forms.TextBox();
            this.txtNew1 = new System.Windows.Forms.TextBox();
            this.txtNew2 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Oud Wachtwoord";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Opnieuw";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nieuw Wachtwoord";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nieuw Wachtwoord";
            // 
            // txtOld
            // 
            this.txtOld.Location = new System.Drawing.Point(120, 15);
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '•';
            this.txtOld.Size = new System.Drawing.Size(182, 20);
            this.txtOld.TabIndex = 4;
            // 
            // txtNew1
            // 
            this.txtNew1.Location = new System.Drawing.Point(120, 63);
            this.txtNew1.Name = "txtNew1";
            this.txtNew1.PasswordChar = '•';
            this.txtNew1.Size = new System.Drawing.Size(182, 20);
            this.txtNew1.TabIndex = 5;
            // 
            // txtNew2
            // 
            this.txtNew2.Location = new System.Drawing.Point(120, 94);
            this.txtNew2.Name = "txtNew2";
            this.txtNew2.PasswordChar = '•';
            this.txtNew2.Size = new System.Drawing.Size(182, 20);
            this.txtNew2.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(209, 120);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Opslaan";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNew2);
            this.Controls.Add(this.txtNew1);
            this.Controls.Add(this.txtOld);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UcChangePassword";
            this.Size = new System.Drawing.Size(305, 152);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOld;
        private System.Windows.Forms.TextBox txtNew1;
        private System.Windows.Forms.TextBox txtNew2;
        private System.Windows.Forms.Button btnSave;
    }
}
