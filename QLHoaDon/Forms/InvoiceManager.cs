using InvoiceManager.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager
{
    public partial class InvoiceManager : Form
    {
        Login loginForm;
        bool isExit = true;

        public static object Properties { get; internal set; }

        public InvoiceManager()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            isExit = false;
            this.Close();
        }

        public Login getLoginForm()
        {
            return loginForm;
        }

        public void setLoginForm(Login loginForm)
        {
            this.loginForm = loginForm;
        }

        private void InvoiceManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isExit)
                Application.Exit();
        }

        private void addUserControl(Control userControl)
        {
            this.panelContent.Controls.Clear();
            this.panelContent.Controls.Add(userControl);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            this.addUserControl(new InfomationControl());
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "DANH MỤC SẢN PHẨM";
            this.addUserControl(new ProductControl());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "DANH SÁCH NHÂN VIÊN";
            this.addUserControl(new EmployeeControl());
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            this.lblTitle.Text = "DANH SÁCH HÓA ĐƠN";
            this.addUserControl(new InvoiceControl());
        }

        private void InvoiceManager_Load(object sender, EventArgs e)
        {
            string query = string.Format("SELECT IS_ADMIN FROM USERS WHERE USERNAME='{0}'",Login.username);
            DataTable data = DBManager.shared().ExecuteQuery(query);
            if ((bool)data.Rows[0]["IS_ADMIN"])
            {
                btnEmployee.Enabled = true;
            }
        }
    }
}
