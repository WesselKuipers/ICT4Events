namespace ICT4Events.Views.EventManagementSystem
{
    partial class EventManagementForm
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
            this.tclEventManagement = new System.Windows.Forms.TabControl();
            this.tabEditEvent = new System.Windows.Forms.TabPage();
            this.tabAddEvent = new System.Windows.Forms.TabPage();
            this.cmbEvents = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEditLocations = new System.Windows.Forms.TabPage();
            this.tclEventManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tclEventManagement
            // 
            this.tclEventManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tclEventManagement.Controls.Add(this.tabEditEvent);
            this.tclEventManagement.Controls.Add(this.tabAddEvent);
            this.tclEventManagement.Controls.Add(this.tabEditLocations);
            this.tclEventManagement.Location = new System.Drawing.Point(0, 35);
            this.tclEventManagement.Name = "tclEventManagement";
            this.tclEventManagement.SelectedIndex = 0;
            this.tclEventManagement.Size = new System.Drawing.Size(746, 423);
            this.tclEventManagement.TabIndex = 0;
            // 
            // tabEditEvent
            // 
            this.tabEditEvent.Location = new System.Drawing.Point(4, 22);
            this.tabEditEvent.Name = "tabEditEvent";
            this.tabEditEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditEvent.Size = new System.Drawing.Size(738, 397);
            this.tabEditEvent.TabIndex = 0;
            this.tabEditEvent.Text = "Aanpassen";
            this.tabEditEvent.UseVisualStyleBackColor = true;
            // 
            // tabAddEvent
            // 
            this.tabAddEvent.Location = new System.Drawing.Point(4, 22);
            this.tabAddEvent.Name = "tabAddEvent";
            this.tabAddEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabAddEvent.Size = new System.Drawing.Size(738, 397);
            this.tabAddEvent.TabIndex = 1;
            this.tabAddEvent.Text = "Aanmaken";
            this.tabAddEvent.UseVisualStyleBackColor = true;
            // 
            // cmbEvents
            // 
            this.cmbEvents.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvents.FormattingEnabled = true;
            this.cmbEvents.Location = new System.Drawing.Point(82, 6);
            this.cmbEvents.Name = "cmbEvents";
            this.cmbEvents.Size = new System.Drawing.Size(210, 21);
            this.cmbEvents.TabIndex = 1;
            this.cmbEvents.SelectedIndexChanged += new System.EventHandler(this.cmbEvents_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Evenement:";
            // 
            // tabEditLocations
            // 
            this.tabEditLocations.Location = new System.Drawing.Point(4, 22);
            this.tabEditLocations.Name = "tabEditLocations";
            this.tabEditLocations.Size = new System.Drawing.Size(738, 397);
            this.tabEditLocations.TabIndex = 2;
            this.tabEditLocations.Text = "Locaties bewerken";
            this.tabEditLocations.UseVisualStyleBackColor = true;
            // 
            // EventManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEvents);
            this.Controls.Add(this.tclEventManagement);
            this.Name = "EventManagementForm";
            this.Text = "Eventbeheer";
            this.tclEventManagement.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tclEventManagement;
        private System.Windows.Forms.TabPage tabEditEvent;
        private System.Windows.Forms.TabPage tabAddEvent;
        private System.Windows.Forms.ComboBox cmbEvents;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabEditLocations;
    }
}