namespace ICT4Events.Views.EventManagementSystem.Controls
{
    partial class ucLocationEdit
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
            this.picMap = new System.Windows.Forms.PictureBox();
            this.lsbLocations = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numLocationCapacity = new System.Windows.Forms.NumericUpDown();
            this.numLocationPrice = new System.Windows.Forms.NumericUpDown();
            this.txtLocationName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteLocation = new System.Windows.Forms.Button();
            this.btnAddLocation = new System.Windows.Forms.Button();
            this.btnEditLocation = new System.Windows.Forms.Button();
            this.btnUploadMap = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLocationCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLocationPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // picMap
            // 
            this.picMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMap.InitialImage = global::ICT4Events.Properties.Resources.LoadingIcon;
            this.picMap.Location = new System.Drawing.Point(3, 29);
            this.picMap.Name = "picMap";
            this.picMap.Size = new System.Drawing.Size(469, 318);
            this.picMap.TabIndex = 0;
            this.picMap.TabStop = false;
            // 
            // lsbLocations
            // 
            this.lsbLocations.FormattingEnabled = true;
            this.lsbLocations.Location = new System.Drawing.Point(478, 32);
            this.lsbLocations.Name = "lsbLocations";
            this.lsbLocations.Size = new System.Drawing.Size(237, 225);
            this.lsbLocations.TabIndex = 1;
            this.lsbLocations.SelectedIndexChanged += new System.EventHandler(this.lsbLocations_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Locaties";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plattegrond";
            // 
            // numLocationCapacity
            // 
            this.numLocationCapacity.Location = new System.Drawing.Point(567, 316);
            this.numLocationCapacity.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numLocationCapacity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLocationCapacity.Name = "numLocationCapacity";
            this.numLocationCapacity.Size = new System.Drawing.Size(148, 20);
            this.numLocationCapacity.TabIndex = 4;
            this.numLocationCapacity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numLocationPrice
            // 
            this.numLocationPrice.DecimalPlaces = 2;
            this.numLocationPrice.Location = new System.Drawing.Point(567, 290);
            this.numLocationPrice.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numLocationPrice.Name = "numLocationPrice";
            this.numLocationPrice.Size = new System.Drawing.Size(148, 20);
            this.numLocationPrice.TabIndex = 5;
            // 
            // txtLocationName
            // 
            this.txtLocationName.Location = new System.Drawing.Point(567, 264);
            this.txtLocationName.Name = "txtLocationName";
            this.txtLocationName.Size = new System.Drawing.Size(148, 20);
            this.txtLocationName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Naam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(487, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Prijs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(487, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Capaciteit";
            // 
            // btnDeleteLocation
            // 
            this.btnDeleteLocation.Location = new System.Drawing.Point(640, 351);
            this.btnDeleteLocation.Name = "btnDeleteLocation";
            this.btnDeleteLocation.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteLocation.TabIndex = 10;
            this.btnDeleteLocation.Text = "Verwijderen";
            this.btnDeleteLocation.UseVisualStyleBackColor = true;
            this.btnDeleteLocation.Click += new System.EventHandler(this.btnDeleteLocation_Click);
            // 
            // btnAddLocation
            // 
            this.btnAddLocation.Location = new System.Drawing.Point(478, 351);
            this.btnAddLocation.Name = "btnAddLocation";
            this.btnAddLocation.Size = new System.Drawing.Size(75, 23);
            this.btnAddLocation.TabIndex = 11;
            this.btnAddLocation.Text = "Toevoegen";
            this.btnAddLocation.UseVisualStyleBackColor = true;
            this.btnAddLocation.Click += new System.EventHandler(this.btnAddLocation_Click);
            // 
            // btnEditLocation
            // 
            this.btnEditLocation.Location = new System.Drawing.Point(559, 351);
            this.btnEditLocation.Name = "btnEditLocation";
            this.btnEditLocation.Size = new System.Drawing.Size(75, 23);
            this.btnEditLocation.TabIndex = 12;
            this.btnEditLocation.Text = "Aanpassen";
            this.btnEditLocation.UseVisualStyleBackColor = true;
            this.btnEditLocation.Click += new System.EventHandler(this.btnEditLocation_Click);
            // 
            // btnUploadMap
            // 
            this.btnUploadMap.Location = new System.Drawing.Point(6, 351);
            this.btnUploadMap.Name = "btnUploadMap";
            this.btnUploadMap.Size = new System.Drawing.Size(118, 39);
            this.btnUploadMap.TabIndex = 13;
            this.btnUploadMap.Text = "Plattegrond uploaden";
            this.btnUploadMap.UseVisualStyleBackColor = true;
            this.btnUploadMap.Click += new System.EventHandler(this.btnUploadMap_Click);
            // 
            // ucLocationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnUploadMap);
            this.Controls.Add(this.btnEditLocation);
            this.Controls.Add(this.btnAddLocation);
            this.Controls.Add(this.btnDeleteLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLocationName);
            this.Controls.Add(this.numLocationPrice);
            this.Controls.Add(this.numLocationCapacity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsbLocations);
            this.Controls.Add(this.picMap);
            this.Name = "ucLocationEdit";
            this.Size = new System.Drawing.Size(727, 395);
            ((System.ComponentModel.ISupportInitialize)(this.picMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLocationCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLocationPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picMap;
        private System.Windows.Forms.ListBox lsbLocations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numLocationCapacity;
        private System.Windows.Forms.NumericUpDown numLocationPrice;
        private System.Windows.Forms.TextBox txtLocationName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteLocation;
        private System.Windows.Forms.Button btnAddLocation;
        private System.Windows.Forms.Button btnEditLocation;
        private System.Windows.Forms.Button btnUploadMap;
    }
}
