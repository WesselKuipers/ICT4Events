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
            this.SuspendLayout();
            // 
            // txtGuestPassId
            // 
            this.txtGuestPassId.Location = new System.Drawing.Point(113, 8);
            this.txtGuestPassId.Margin = new System.Windows.Forms.Padding(2);
            this.txtGuestPassId.Name = "txtGuestPassId";
            this.txtGuestPassId.Size = new System.Drawing.Size(206, 20);
            this.txtGuestPassId.TabIndex = 0;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(113, 32);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(206, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtMaterialName
            // 
            this.txtMaterialName.Location = new System.Drawing.Point(408, 158);
            this.txtMaterialName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialName.Name = "txtMaterialName";
            this.txtMaterialName.Size = new System.Drawing.Size(316, 20);
            this.txtMaterialName.TabIndex = 2;
            // 
            // txtMaterialID
            // 
            this.txtMaterialID.Location = new System.Drawing.Point(408, 136);
            this.txtMaterialID.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaterialID.Name = "txtMaterialID";
            this.txtMaterialID.Size = new System.Drawing.Size(316, 20);
            this.txtMaterialID.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gebruikersnummer:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gebruikersnaam:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 8);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Categorie:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(330, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Product:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 136);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Artikelnummer:";
            // 
            // btnRentMaterial
            // 
            this.btnRentMaterial.Location = new System.Drawing.Point(408, 181);
            this.btnRentMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.btnRentMaterial.Name = "btnRentMaterial";
            this.btnRentMaterial.Size = new System.Drawing.Size(148, 25);
            this.btnRentMaterial.TabIndex = 13;
            this.btnRentMaterial.Text = "Verhuur Product";
            this.btnRentMaterial.UseVisualStyleBackColor = true;
            this.btnRentMaterial.Click += new System.EventHandler(this.btnRentMaterial_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.Enabled = false;
            this.btnReturn.Location = new System.Drawing.Point(170, 133);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(148, 24);
            this.btnReturn.TabIndex = 14;
            this.btnReturn.Text = "Neem Terug";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lsbMaterialStorage
            // 
            this.lsbMaterialStorage.FormattingEnabled = true;
            this.lsbMaterialStorage.Location = new System.Drawing.Point(332, 32);
            this.lsbMaterialStorage.Margin = new System.Windows.Forms.Padding(2);
            this.lsbMaterialStorage.Name = "lsbMaterialStorage";
            this.lsbMaterialStorage.Size = new System.Drawing.Size(392, 95);
            this.lsbMaterialStorage.TabIndex = 15;
            this.lsbMaterialStorage.SelectedIndexChanged += new System.EventHandler(this.lsbMaterialStorage_SelectedIndexChanged);
            // 
            // lsbUserMaterial
            // 
            this.lsbUserMaterial.FormattingEnabled = true;
            this.lsbUserMaterial.Location = new System.Drawing.Point(11, 55);
            this.lsbUserMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.lsbUserMaterial.Name = "lsbUserMaterial";
            this.lsbUserMaterial.Size = new System.Drawing.Size(308, 69);
            this.lsbUserMaterial.TabIndex = 16;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Items.AddRange(new object[] {
            "Any"});
            this.cbCategory.Location = new System.Drawing.Point(390, 6);
            this.cbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(334, 21);
            this.cbCategory.TabIndex = 17;
            this.cbCategory.Text = "Any";
            this.cbCategory.SelectedIndexChanged += new System.EventHandler(this.cbCategory_SelectedIndexChanged);
            // 
            // btnRemoveMaterial
            // 
            this.btnRemoveMaterial.Location = new System.Drawing.Point(574, 181);
            this.btnRemoveMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveMaterial.Name = "btnRemoveMaterial";
            this.btnRemoveMaterial.Size = new System.Drawing.Size(148, 25);
            this.btnRemoveMaterial.TabIndex = 18;
            this.btnRemoveMaterial.Text = "Vewijder Product";
            this.btnRemoveMaterial.UseVisualStyleBackColor = true;
            this.btnRemoveMaterial.Click += new System.EventHandler(this.btnRemoveMaterial_Click);
            // 
            // btnMaterialAdd
            // 
            this.btnMaterialAdd.Location = new System.Drawing.Point(408, 259);
            this.btnMaterialAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaterialAdd.Name = "btnMaterialAdd";
            this.btnMaterialAdd.Size = new System.Drawing.Size(148, 25);
            this.btnMaterialAdd.TabIndex = 19;
            this.btnMaterialAdd.Text = "Product Toevoegen";
            this.btnMaterialAdd.UseVisualStyleBackColor = true;
            this.btnMaterialAdd.Click += new System.EventHandler(this.btnMaterialAdd_Click);
            // 
            // btnMaterialEdit
            // 
            this.btnMaterialEdit.Location = new System.Drawing.Point(574, 259);
            this.btnMaterialEdit.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaterialEdit.Name = "btnMaterialEdit";
            this.btnMaterialEdit.Size = new System.Drawing.Size(148, 25);
            this.btnMaterialEdit.TabIndex = 20;
            this.btnMaterialEdit.Text = "Product Wijzigen";
            this.btnMaterialEdit.UseVisualStyleBackColor = true;
            this.btnMaterialEdit.Click += new System.EventHandler(this.btnMaterialEdit_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Product:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 239);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Type:";
            // 
            // txtNewMaterialName
            // 
            this.txtNewMaterialName.Location = new System.Drawing.Point(408, 211);
            this.txtNewMaterialName.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewMaterialName.Name = "txtNewMaterialName";
            this.txtNewMaterialName.Size = new System.Drawing.Size(316, 20);
            this.txtNewMaterialName.TabIndex = 25;
            // 
            // txtNewMaterialType
            // 
            this.txtNewMaterialType.Location = new System.Drawing.Point(408, 236);
            this.txtNewMaterialType.Margin = new System.Windows.Forms.Padding(2);
            this.txtNewMaterialType.Name = "txtNewMaterialType";
            this.txtNewMaterialType.Size = new System.Drawing.Size(316, 20);
            this.txtNewMaterialType.TabIndex = 26;
            // 
            // MaterialSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 300);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MaterialSystem";
            this.Text = "MateriaalVerhuurSysteem";
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
    }
}