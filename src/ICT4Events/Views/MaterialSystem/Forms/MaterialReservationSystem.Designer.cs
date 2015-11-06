namespace ICT4Events.Views.MaterialSystem.Forms
{
    partial class MaterialReservationSystem
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
            this.MaterialUserLB = new System.Windows.Forms.ListBox();
            this.reserveBtn = new System.Windows.Forms.Button();
            this.searchTb = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MaterialUserLB
            // 
            this.MaterialUserLB.FormattingEnabled = true;
            this.MaterialUserLB.ItemHeight = 16;
            this.MaterialUserLB.Location = new System.Drawing.Point(12, 48);
            this.MaterialUserLB.Name = "MaterialUserLB";
            this.MaterialUserLB.Size = new System.Drawing.Size(521, 628);
            this.MaterialUserLB.TabIndex = 19;
            // 
            // reserveBtn
            // 
            this.reserveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reserveBtn.Location = new System.Drawing.Point(386, 683);
            this.reserveBtn.Name = "reserveBtn";
            this.reserveBtn.Size = new System.Drawing.Size(147, 30);
            this.reserveBtn.TabIndex = 21;
            this.reserveBtn.Text = "Reserveer";
            this.reserveBtn.UseVisualStyleBackColor = true;
            this.reserveBtn.Click += new System.EventHandler(this.reserveBtn_Click);
            // 
            // searchTb
            // 
            this.searchTb.Location = new System.Drawing.Point(13, 13);
            this.searchTb.Name = "searchTb";
            this.searchTb.Size = new System.Drawing.Size(367, 22);
            this.searchTb.TabIndex = 22;
            this.searchTb.TextChanged += new System.EventHandler(this.searchTb_TextChanged);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(386, 9);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(147, 30);
            this.searchBtn.TabIndex = 23;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // MaterialReservationSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 725);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchTb);
            this.Controls.Add(this.reserveBtn);
            this.Controls.Add(this.MaterialUserLB);
            this.Name = "MaterialReservationSystem";
            this.Text = "MaterialReservationSystem";
            this.Load += new System.EventHandler(this.MaterialReservationSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox MaterialUserLB;
        private System.Windows.Forms.Button reserveBtn;
        private System.Windows.Forms.TextBox searchTb;
        private System.Windows.Forms.Button searchBtn;
    }
}