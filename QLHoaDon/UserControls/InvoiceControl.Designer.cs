namespace InvoiceManager.UserControls
{
    partial class InvoiceControl
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
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btnAddInvoice = new System.Windows.Forms.Button();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtAmountTotal = new System.Windows.Forms.TextBox();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.lblAmountTotal = new System.Windows.Forms.Label();
            this.dataGridViewDetails = new System.Windows.Forms.DataGridView();
            this.txtID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.AllowUserToAddRows = false;
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(3, 40);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.ReadOnly = true;
            this.dataGridViewInvoices.Size = new System.Drawing.Size(318, 324);
            this.dataGridViewInvoices.TabIndex = 0;
            this.dataGridViewInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInvoices_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(3, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(230, 20);
            this.txtSearch.TabIndex = 1;
            // 
            // btn_Search
            // 
            this.btn_Search.Location = new System.Drawing.Point(239, 11);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(82, 23);
            this.btn_Search.TabIndex = 2;
            this.btn_Search.Text = "Tìm";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Location = new System.Drawing.Point(3, 370);
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnAddInvoice.TabIndex = 3;
            this.btnAddInvoice.Text = "Thêm";
            this.btnAddInvoice.UseVisualStyleBackColor = true;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Location = new System.Drawing.Point(123, 370);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnEditInvoice.TabIndex = 4;
            this.btnEditInvoice.Text = "Chỉnh sửa";
            this.btnEditInvoice.UseVisualStyleBackColor = true;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Location = new System.Drawing.Point(246, 370);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteInvoice.TabIndex = 5;
            this.btnDeleteInvoice.Text = "Xóa";
            this.btnDeleteInvoice.UseVisualStyleBackColor = true;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.txtID);
            this.panelDetail.Controls.Add(this.btnSave);
            this.panelDetail.Controls.Add(this.btnLock);
            this.panelDetail.Controls.Add(this.label2);
            this.panelDetail.Controls.Add(this.label1);
            this.panelDetail.Controls.Add(this.txtCustomerPhone);
            this.panelDetail.Controls.Add(this.txtCustomerName);
            this.panelDetail.Controls.Add(this.txtAmountTotal);
            this.panelDetail.Controls.Add(this.btnDeleteDetail);
            this.panelDetail.Controls.Add(this.btnAddDetail);
            this.panelDetail.Controls.Add(this.lblAmountTotal);
            this.panelDetail.Controls.Add(this.dataGridViewDetails);
            this.panelDetail.Enabled = false;
            this.panelDetail.Location = new System.Drawing.Point(335, 3);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(440, 390);
            this.panelDetail.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(357, 205);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 75);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(357, 286);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 75);
            this.btnLock.TabIndex = 12;
            this.btnLock.Text = "Khóa";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Số điện thoại:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Tên khách hàng:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(233, 26);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(118, 20);
            this.txtCustomerPhone.TabIndex = 7;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(115, 0);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(236, 20);
            this.txtCustomerName.TabIndex = 6;
            // 
            // txtAmountTotal
            // 
            this.txtAmountTotal.Location = new System.Drawing.Point(76, 369);
            this.txtAmountTotal.Name = "txtAmountTotal";
            this.txtAmountTotal.ReadOnly = true;
            this.txtAmountTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtAmountTotal.Size = new System.Drawing.Size(275, 20);
            this.txtAmountTotal.TabIndex = 21;
            this.txtAmountTotal.Text = "0";
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.Location = new System.Drawing.Point(357, 81);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteDetail.TabIndex = 10;
            this.btnDeleteDetail.Text = "Xóa";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnAddDetail
            // 
            this.btnAddDetail.Location = new System.Drawing.Point(357, 52);
            this.btnAddDetail.Name = "btnAddDetail";
            this.btnAddDetail.Size = new System.Drawing.Size(75, 23);
            this.btnAddDetail.TabIndex = 8;
            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.UseVisualStyleBackColor = true;
            this.btnAddDetail.Click += new System.EventHandler(this.btnAddDetail_Click);
            // 
            // lblAmountTotal
            // 
            this.lblAmountTotal.Location = new System.Drawing.Point(9, 367);
            this.lblAmountTotal.Name = "lblAmountTotal";
            this.lblAmountTotal.Size = new System.Drawing.Size(100, 23);
            this.lblAmountTotal.TabIndex = 17;
            this.lblAmountTotal.Text = "Tổng tiền:";
            this.lblAmountTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewDetails
            // 
            this.dataGridViewDetails.AllowUserToAddRows = false;
            this.dataGridViewDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetails.Location = new System.Drawing.Point(12, 52);
            this.dataGridViewDetails.Name = "dataGridViewDetails";
            this.dataGridViewDetails.ReadOnly = true;
            this.dataGridViewDetails.Size = new System.Drawing.Size(339, 309);
            this.dataGridViewDetails.TabIndex = 16;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(357, 11);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(75, 20);
            this.txtID.TabIndex = 26;
            // 
            // InvoiceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnEditInvoice);
            this.Controls.Add(this.btnAddInvoice);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dataGridViewInvoices);
            this.Name = "InvoiceControl";
            this.Size = new System.Drawing.Size(778, 396);
            this.Load += new System.EventHandler(this.InvoiceControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.panelDetail.ResumeLayout(false);
            this.panelDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btnAddInvoice;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtAmountTotal;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Label lblAmountTotal;
        private System.Windows.Forms.DataGridView dataGridViewDetails;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtID;
    }
}
