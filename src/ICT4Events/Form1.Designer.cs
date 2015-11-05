namespace ICT4Events
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btSocial = new System.Windows.Forms.Button();
            this.btMaterial = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 16);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(249, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "open accountsysteem test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(49, 53);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(249, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "reserveringssysteem";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(263, 279);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(100, 28);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Uitloggen";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btSocial
            // 
            this.btSocial.Location = new System.Drawing.Point(49, 89);
            this.btSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSocial.Name = "btSocial";
            this.btSocial.Size = new System.Drawing.Size(249, 28);
            this.btSocial.TabIndex = 3;
            this.btSocial.Text = "socialMediaSysteem";
            this.btSocial.UseVisualStyleBackColor = true;
            this.btSocial.Click += new System.EventHandler(this.btSocial_Click);
            // 
            // btMaterial
            // 
            this.btMaterial.Location = new System.Drawing.Point(49, 125);
            this.btMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.btMaterial.Name = "btMaterial";
            this.btMaterial.Size = new System.Drawing.Size(249, 28);
            this.btMaterial.TabIndex = 4;
            this.btMaterial.Text = "Materiaal Verhuur Systeem";
            this.btMaterial.UseVisualStyleBackColor = true;
            this.btMaterial.Click += new System.EventHandler(this.btMaterial_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 322);
            this.Controls.Add(this.btMaterial);
            this.Controls.Add(this.btSocial);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btSocial;
        private System.Windows.Forms.Button btMaterial;
    }
}

