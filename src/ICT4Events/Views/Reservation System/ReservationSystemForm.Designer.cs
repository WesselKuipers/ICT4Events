namespace ICT4Events.Views.Reservation_System
{
    partial class ReservationSystemForm
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
            this.calEventDate = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEvents = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEventName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblEventCapacity = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblGuestStatus = new System.Windows.Forms.Label();
            this.btnRegisterForEvent = new System.Windows.Forms.Button();
            this.btnPayForEvent = new System.Windows.Forms.Button();
            this.picEventMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picEventMap)).BeginInit();
            this.SuspendLayout();
            // 
            // calEventDate
            // 
            this.calEventDate.Location = new System.Drawing.Point(15, 97);
            this.calEventDate.MaxSelectionCount = 30;
            this.calEventDate.Name = "calEventDate";
            this.calEventDate.ShowToday = false;
            this.calEventDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Datum evenement:";
            // 
            // cmbEvents
            // 
            this.cmbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvents.FormattingEnabled = true;
            this.cmbEvents.Location = new System.Drawing.Point(82, 12);
            this.cmbEvents.Name = "cmbEvents";
            this.cmbEvents.Size = new System.Drawing.Size(121, 21);
            this.cmbEvents.TabIndex = 2;
            this.cmbEvents.SelectedIndexChanged += new System.EventHandler(this.cmbEvents_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Evenement:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Naam evenement:";
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Location = new System.Drawing.Point(112, 52);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(72, 13);
            this.lblEventName.TabIndex = 5;
            this.lblEventName.Text = "<eventnaam>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Capaciteit:";
            // 
            // lblEventCapacity
            // 
            this.lblEventCapacity.AutoSize = true;
            this.lblEventCapacity.Location = new System.Drawing.Point(71, 268);
            this.lblEventCapacity.Name = "lblEventCapacity";
            this.lblEventCapacity.Size = new System.Drawing.Size(54, 13);
            this.lblEventCapacity.TabIndex = 7;
            this.lblEventCapacity.Text = "<0 / 100>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Status:";
            // 
            // lblGuestStatus
            // 
            this.lblGuestStatus.AutoSize = true;
            this.lblGuestStatus.Location = new System.Drawing.Point(244, 97);
            this.lblGuestStatus.Name = "lblGuestStatus";
            this.lblGuestStatus.Size = new System.Drawing.Size(105, 13);
            this.lblGuestStatus.TabIndex = 9;
            this.lblGuestStatus.Text = "<Niet ingeschreven>";
            // 
            // btnRegisterForEvent
            // 
            this.btnRegisterForEvent.Location = new System.Drawing.Point(201, 123);
            this.btnRegisterForEvent.Name = "btnRegisterForEvent";
            this.btnRegisterForEvent.Size = new System.Drawing.Size(148, 38);
            this.btnRegisterForEvent.TabIndex = 10;
            this.btnRegisterForEvent.Text = "Inschrijven";
            this.btnRegisterForEvent.UseVisualStyleBackColor = true;
            this.btnRegisterForEvent.Click += new System.EventHandler(this.btnRegisterForEvent_Click);
            // 
            // btnPayForEvent
            // 
            this.btnPayForEvent.Location = new System.Drawing.Point(201, 167);
            this.btnPayForEvent.Name = "btnPayForEvent";
            this.btnPayForEvent.Size = new System.Drawing.Size(148, 38);
            this.btnPayForEvent.TabIndex = 11;
            this.btnPayForEvent.Text = "Betalen";
            this.btnPayForEvent.UseVisualStyleBackColor = true;
            this.btnPayForEvent.Click += new System.EventHandler(this.btnPayForEvent_Click);
            // 
            // picEventMap
            // 
            this.picEventMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picEventMap.Location = new System.Drawing.Point(355, 123);
            this.picEventMap.Name = "picEventMap";
            this.picEventMap.Size = new System.Drawing.Size(255, 158);
            this.picEventMap.TabIndex = 12;
            this.picEventMap.TabStop = false;
            // 
            // ReservationSystemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 294);
            this.Controls.Add(this.picEventMap);
            this.Controls.Add(this.btnPayForEvent);
            this.Controls.Add(this.btnRegisterForEvent);
            this.Controls.Add(this.lblGuestStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblEventCapacity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbEvents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.calEventDate);
            this.Name = "ReservationSystemForm";
            this.Text = "ReservationSystemForm";
            ((System.ComponentModel.ISupportInitialize)(this.picEventMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar calEventDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEvents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblEventCapacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblGuestStatus;
        private System.Windows.Forms.Button btnRegisterForEvent;
        private System.Windows.Forms.Button btnPayForEvent;
        private System.Windows.Forms.PictureBox picEventMap;
    }
}