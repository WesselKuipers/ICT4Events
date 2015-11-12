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
            this.lsbUserMaterials = new System.Windows.Forms.ListBox();
            this.btnReserve = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.lsbReserved = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsbUserMaterials
            // 
            this.lsbUserMaterials.FormattingEnabled = true;
            this.lsbUserMaterials.Location = new System.Drawing.Point(9, 52);
            this.lsbUserMaterials.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsbUserMaterials.Name = "lsbUserMaterials";
            this.lsbUserMaterials.Size = new System.Drawing.Size(395, 498);
            this.lsbUserMaterials.TabIndex = 19;
            // 
            // btnReserve
            // 
            this.btnReserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReserve.Location = new System.Drawing.Point(292, 581);
            this.btnReserve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(110, 24);
            this.btnReserve.TabIndex = 21;
            this.btnReserve.Text = "Reserveer";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.reserveBtn_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(10, 11);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(276, 20);
            this.txtSearch.TabIndex = 22;
            this.txtSearch.TextChanged += new System.EventHandler(this.searchTb_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(290, 7);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 24);
            this.btnSearch.TabIndex = 23;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 557);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Datum:";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(250, 557);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(151, 20);
            this.dtpEnd.TabIndex = 31;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(86, 557);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(151, 20);
            this.dtpStart.TabIndex = 30;
            // 
            // lsbReserved
            // 
            this.lsbReserved.FormattingEnabled = true;
            this.lsbReserved.Location = new System.Drawing.Point(437, 52);
            this.lsbReserved.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lsbReserved.Name = "lsbReserved";
            this.lsbReserved.Size = new System.Drawing.Size(395, 498);
            this.lsbReserved.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Gereserveerde materialen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Beschikbare materialen:";
            // 
            // MaterialReservationSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 614);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbReserved);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.lsbUserMaterials);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MaterialReservationSystem";
            this.Text = "Materiaalverhuur";
            this.Load += new System.EventHandler(this.MaterialReservationSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lsbUserMaterials;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ListBox lsbReserved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}