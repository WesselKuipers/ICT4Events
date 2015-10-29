namespace ICT4Events.Views.EventManagementSystem.Controls
{
    partial class ucEventEdit
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
            this.btnUpdateEvent = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateEvent
            // 
            this.btnUpdateEvent.Location = new System.Drawing.Point(181, 155);
            this.btnUpdateEvent.Name = "btnUpdateEvent";
            this.btnUpdateEvent.Size = new System.Drawing.Size(140, 23);
            this.btnUpdateEvent.TabIndex = 44;
            this.btnUpdateEvent.Text = "Evenement wijzigen";
            this.btnUpdateEvent.UseVisualStyleBackColor = true;
            this.btnUpdateEvent.Click += new System.EventHandler(this.btnUpdateEvent_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(118, 35);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(203, 20);
            this.txtLocation.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 37;
            this.label7.Text = "Capaciteit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Einddatum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Startdatum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Locatie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Naam";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(118, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 20);
            this.txtName.TabIndex = 30;
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(118, 113);
            this.numCapacity.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(203, 20);
            this.numCapacity.TabIndex = 45;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(118, 87);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(203, 20);
            this.dtpEndDate.TabIndex = 46;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(118, 61);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(203, 20);
            this.dtpStartDate.TabIndex = 47;
            // 
            // ucEventEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.btnUpdateEvent);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Name = "ucEventEdit";
            this.Size = new System.Drawing.Size(335, 197);
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateEvent;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
    }
}
