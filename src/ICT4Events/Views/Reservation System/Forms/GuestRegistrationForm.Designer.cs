namespace ICT4Events.Views.Reservation_System.Forms
{
    partial class GuestRegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocations = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocationCapacity = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtAdditionalGuest1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.calEventDate = new System.Windows.Forms.MonthCalendar();
            this.label4 = new System.Windows.Forms.Label();
            this.tblAdditionalGuests = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAdditionalGuest2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdditionalGuest3 = new System.Windows.Forms.TextBox();
            this.txtAdditionalGuest4 = new System.Windows.Forms.TextBox();
            this.txtAdditionalGuest5 = new System.Windows.Forms.TextBox();
            this.tblAdditionalGuests.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Evenement naam:";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(111, 9);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(75, 13);
            this.lblEventName.TabIndex = 1;
            this.lblEventName.Text = "<event name>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kampeerlocatie:";
            // 
            // cmbLocations
            // 
            this.cmbLocations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocations.FormattingEnabled = true;
            this.cmbLocations.Location = new System.Drawing.Point(114, 30);
            this.cmbLocations.Name = "cmbLocations";
            this.cmbLocations.Size = new System.Drawing.Size(121, 21);
            this.cmbLocations.TabIndex = 3;
            this.cmbLocations.SelectedIndexChanged += new System.EventHandler(this.cmbLocations_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Capaciteit locatie:";
            // 
            // lblLocationCapacity
            // 
            this.lblLocationCapacity.AutoSize = true;
            this.lblLocationCapacity.Location = new System.Drawing.Point(109, 67);
            this.lblLocationCapacity.Name = "lblLocationCapacity";
            this.lblLocationCapacity.Size = new System.Drawing.Size(54, 13);
            this.lblLocationCapacity.TabIndex = 5;
            this.lblLocationCapacity.Text = "< 0 / 50 >";
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(15, 304);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(220, 41);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "Inschrijven";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtAdditionalGuest1
            // 
            this.txtAdditionalGuest1.Location = new System.Drawing.Point(50, 3);
            this.txtAdditionalGuest1.Name = "txtAdditionalGuest1";
            this.txtAdditionalGuest1.Size = new System.Drawing.Size(193, 20);
            this.txtAdditionalGuest1.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(290, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Reserveer voor meerdere personen:";
            // 
            // calEventDate
            // 
            this.calEventDate.Location = new System.Drawing.Point(15, 130);
            this.calEventDate.Name = "calEventDate";
            this.calEventDate.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Selecteer een start- en einddatum:";
            // 
            // tblAdditionalGuests
            // 
            this.tblAdditionalGuests.ColumnCount = 2;
            this.tblAdditionalGuests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5F));
            this.tblAdditionalGuests.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.5F));
            this.tblAdditionalGuests.Controls.Add(this.txtAdditionalGuest2, 1, 1);
            this.tblAdditionalGuests.Controls.Add(this.txtAdditionalGuest1, 1, 0);
            this.tblAdditionalGuests.Controls.Add(this.label10, 0, 0);
            this.tblAdditionalGuests.Controls.Add(this.label5, 0, 1);
            this.tblAdditionalGuests.Controls.Add(this.label7, 0, 2);
            this.tblAdditionalGuests.Controls.Add(this.label8, 0, 3);
            this.tblAdditionalGuests.Controls.Add(this.label6, 0, 4);
            this.tblAdditionalGuests.Controls.Add(this.txtAdditionalGuest3, 1, 2);
            this.tblAdditionalGuests.Controls.Add(this.txtAdditionalGuest4, 1, 3);
            this.tblAdditionalGuests.Controls.Add(this.txtAdditionalGuest5, 1, 4);
            this.tblAdditionalGuests.Location = new System.Drawing.Point(293, 33);
            this.tblAdditionalGuests.Name = "tblAdditionalGuests";
            this.tblAdditionalGuests.RowCount = 5;
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAdditionalGuests.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblAdditionalGuests.Size = new System.Drawing.Size(246, 152);
            this.tblAdditionalGuests.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Email";
            // 
            // txtAdditionalGuest2
            // 
            this.txtAdditionalGuest2.Location = new System.Drawing.Point(50, 33);
            this.txtAdditionalGuest2.Name = "txtAdditionalGuest2";
            this.txtAdditionalGuest2.Size = new System.Drawing.Size(193, 20);
            this.txtAdditionalGuest2.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Email";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Email";
            // 
            // txtAdditionalGuest3
            // 
            this.txtAdditionalGuest3.Location = new System.Drawing.Point(50, 63);
            this.txtAdditionalGuest3.Name = "txtAdditionalGuest3";
            this.txtAdditionalGuest3.Size = new System.Drawing.Size(193, 20);
            this.txtAdditionalGuest3.TabIndex = 25;
            // 
            // txtAdditionalGuest4
            // 
            this.txtAdditionalGuest4.Location = new System.Drawing.Point(50, 93);
            this.txtAdditionalGuest4.Name = "txtAdditionalGuest4";
            this.txtAdditionalGuest4.Size = new System.Drawing.Size(193, 20);
            this.txtAdditionalGuest4.TabIndex = 25;
            // 
            // txtAdditionalGuest5
            // 
            this.txtAdditionalGuest5.Location = new System.Drawing.Point(50, 123);
            this.txtAdditionalGuest5.Name = "txtAdditionalGuest5";
            this.txtAdditionalGuest5.Size = new System.Drawing.Size(193, 20);
            this.txtAdditionalGuest5.TabIndex = 25;
            // 
            // GuestRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 357);
            this.Controls.Add(this.tblAdditionalGuests);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.calEventDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblLocationCapacity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLocations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.label1);
            this.Name = "GuestRegistrationForm";
            this.Text = "Registration for Event";
            this.tblAdditionalGuests.ResumeLayout(false);
            this.tblAdditionalGuests.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLocations;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocationCapacity;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtAdditionalGuest1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MonthCalendar calEventDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tblAdditionalGuests;
        private System.Windows.Forms.TextBox txtAdditionalGuest2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdditionalGuest3;
        private System.Windows.Forms.TextBox txtAdditionalGuest4;
        private System.Windows.Forms.TextBox txtAdditionalGuest5;
    }
}