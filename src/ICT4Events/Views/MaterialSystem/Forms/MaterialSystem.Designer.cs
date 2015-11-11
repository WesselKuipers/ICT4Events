namespace ICT4Events.Views.MaterialSystem.Forms
{
    partial class MaterialSystem
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
            this.txtGuestPassId = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtMaterialName = new System.Windows.Forms.TextBox();
            this.txtMaterialID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRentMaterial = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lsbMaterialStorage = new System.Windows.Forms.ListBox();
            this.lsbUserMaterial = new System.Windows.Forms.ListBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnRemoveMaterial = new System.Windows.Forms.Button();
            this.btnMaterialAdd = new System.Windows.Forms.Button();
            this.btnMaterialEdit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNewMaterialName = new System.Windows.Forms.TextBox();
            this.txtNewMaterialType = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtGuestPassId
            // 
            this.txtGuestPassId.Location = new System.Drawing.Point(151, 10);
            this.txtGuestPassId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGuestPassId.Name = "txtGuestPassId";
            this.txtGuestPassId.Size = new System.Drawing.Size(273, 22);
            this.txtGuestPassId.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 39);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(273, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(544, 194);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(420, 22);
            this.txtMaterialName.TabIndex = 2;
            // 
            // txtMaterialID
            // 
            this.txtMaterialID.Location = new System.Drawing.Point(544, 167);
            this.txtMaterialID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaterialID.Name = "txtMaterialID";
            this.txtMaterialID.Size = new System.Drawing.Size(420, 22);
            this.txtMaterialID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gebruikersnummer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gebruikersnaam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(440, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Categorie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 198);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Product:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(440, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Artikelnummer:";
            // 
            // btnRentMaterial
            // 
            this.btnRentMaterial.Location = new System.Drawing.Point(544, 223);
            this.btnRentMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRentMaterial.Name = "btnRentMaterial";
            this.btnRentMaterial.Size = new System.Drawing.Size(197, 31);
            this.btnRentMaterial.TabIndex = 13;
            this.btnRentMaterial.Text = "Verhuur Product";
            this.btnRentMaterial.UseVisualStyleBackColor = true;
            this.btnRentMaterial.Click += new System.EventHandler(this.btnRentMaterial_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Location = new System.Drawing.Point(227, 164);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(197, 30);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Text = "Neem Terug";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lsbMaterialStorage
            // 
            this.lsbMaterialStorage.FormattingEnabled = true;
            this.lsbMaterialStorage.ItemHeight = 16;
            this.lsbMaterialStorage.Location = new System.Drawing.Point(443, 39);
            this.lsbMaterialStorage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsbMaterialStorage.Name = "lsbMaterialStorage";
            this.lsbMaterialStorage.Size = new System.Drawing.Size(521, 116);
            this.lsbMaterialStorage.TabIndex = 15;
            this.lsbMaterialStorage.SelectedIndexChanged += new System.EventHandler(this.lsbMaterialStorage_SelectedIndexChanged);
            // 
            // lsbUserMaterial
            // 
            this.lsbUserMaterial.FormattingEnabled = true;
            this.lsbUserMaterial.ItemHeight = 16;
            this.lsbUserMaterial.Location = new System.Drawing.Point(15, 68);
            this.lsbUserMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsbUserMaterial.Name = "lsbUserMaterial";
            this.lsbUserMaterial.Size = new System.Drawing.Size(409, 84);
            this.lsbUserMaterial.TabIndex = 16;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Any"});
            this.cbCategory.Location = new System.Drawing.Point(520, 7);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(444, 24);
            this.cbCategory.TabIndex = 17;
            this.cbCategory.Text = "Any";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // btnRemoveMaterial
            // 
            this.btnRemoveMaterial.Location = new System.Drawing.Point(765, 223);
            this.btnRemoveMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRemoveMaterial.Name = "btnRemoveMaterial";
            this.btnRemoveMaterial.Size = new System.Drawing.Size(197, 31);
            this.btnRemoveMaterial.TabIndex = 18;
            this.btnRemoveMaterial.Text = "Vewijder Product";
            this.btnRemoveMaterial.UseVisualStyleBackColor = true;
            this.btnRemoveMaterial.Click += new System.EventHandler(this.btnRemoveMaterial_Click);
            // 
            // btnMaterialAdd
            // 
            this.btnMaterialAdd.Location = new System.Drawing.Point(544, 319);
            this.btnMaterialAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMaterialAdd.Name = "btnMaterialAdd";
            this.btnMaterialAdd.Size = new System.Drawing.Size(197, 31);
            this.btnMaterialAdd.TabIndex = 19;
            this.btnMaterialAdd.Text = "Product Toevoegen";
            this.btnMaterialAdd.UseVisualStyleBackColor = true;
            this.btnMaterialAdd.Click += new System.EventHandler(this.btnMaterialAdd_Click);
            // 
            // btnMaterialEdit
            // 
            this.btnMaterialEdit.Location = new System.Drawing.Point(765, 319);
            this.btnMaterialEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMaterialEdit.Name = "btnMaterialEdit";
            this.btnMaterialEdit.Size = new System.Drawing.Size(197, 31);
            this.btnMaterialEdit.TabIndex = 20;
            this.btnMaterialEdit.Text = "Product Wijzigen";
            this.btnMaterialEdit.UseVisualStyleBackColor = true;
            this.btnMaterialEdit.Click += new System.EventHandler(this.btnMaterialEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(440, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Product:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(440, 294);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Type:";
            // 
            // txtNewMaterialName
            // 
            this.txtNewMaterialName.Location = new System.Drawing.Point(544, 260);
            this.txtNewMaterialName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewMaterialName.Name = "txtNewMaterialName";
            this.txtNewMaterialName.Size = new System.Drawing.Size(420, 22);
            this.txtNewMaterialName.TabIndex = 25;
            // 
            // txtNewMaterialType
            // 
            this.txtNewMaterialType.Location = new System.Drawing.Point(544, 290);
            this.txtNewMaterialType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewMaterialType.Name = "txtNewMaterialType";
            this.txtNewMaterialType.Size = new System.Drawing.Size(420, 22);
            this.txtNewMaterialType.TabIndex = 26;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(544, 365);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 22);
            this.dtpStart.TabIndex = 27;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(765, 365);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpEnd.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(443, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 17);
            this.label6.TabIndex = 29;
            this.label6.Text = "Datum:";
            // 
            // MaterialSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 409);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.txtNewMaterialType);
            this.Controls.Add(this.txtNewMaterialName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMaterialEdit);
            this.Controls.Add(this.btnMaterialAdd);
            this.Controls.Add(this.btnRemoveMaterial);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.lsbUserMaterial);
            this.Controls.Add(this.lsbMaterialStorage);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnRentMaterial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaterialID);
            this.Controls.Add(this.txtMaterialName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtGuestPassId);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MaterialSystem";
            this.Text = "Materiaalbeheer";
            this.Load += new System.EventHandler(this.MaterialSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGuestPassId;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtMaterialName;
        private System.Windows.Forms.TextBox txtMaterialID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRentMaterial;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.ListBox lsbMaterialStorage;
        private System.Windows.Forms.ListBox lsbUserMaterial;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.Button btnRemoveMaterial;
        private System.Windows.Forms.Button btnMaterialAdd;
        private System.Windows.Forms.Button btnMaterialEdit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNewMaterialName;
        private System.Windows.Forms.TextBox txtNewMaterialType;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label6;
    }
}