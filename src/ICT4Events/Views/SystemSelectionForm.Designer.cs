namespace ICT4Events.Views
{
    partial class SystemSelectionForm
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.tblSystemButtons = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(197, 227);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 2;
            this.btnLogOut.Text = "Uitloggen";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // tblSystemButtons
            // 
            this.tblSystemButtons.ColumnCount = 1;
            this.tblSystemButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblSystemButtons.Location = new System.Drawing.Point(42, 12);
            this.tblSystemButtons.Name = "tblSystemButtons";
            this.tblSystemButtons.RowCount = 5;
            this.tblSystemButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSystemButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSystemButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSystemButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSystemButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblSystemButtons.Size = new System.Drawing.Size(200, 162);
            this.tblSystemButtons.TabIndex = 4;
            // 
            // SystemSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tblSystemButtons);
            this.Controls.Add(this.btnLogOut);
            this.Name = "SystemSelectionForm";
            this.Text = "Selecteer systeem";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.TableLayoutPanel tblSystemButtons;
    }
}

