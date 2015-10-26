namespace ICT4Events.Views.Reservation_System.Forms
{
    partial class GuestPaymentForm
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
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Totaalbedrag:";
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentAmount.Location = new System.Drawing.Point(12, 35);
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size(260, 85);
            this.lblPaymentAmount.TabIndex = 1;
            this.lblPaymentAmount.Text = "€ 50,-";
            this.lblPaymentAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPay
            // 
            this.btnPay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnPay.Location = new System.Drawing.Point(12, 123);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(260, 69);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Betalen";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // GuestPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 204);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblPaymentAmount);
            this.Controls.Add(this.label1);
            this.Name = "GuestPaymentForm";
            this.Text = "GuestPaymentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Button btnPay;
    }
}