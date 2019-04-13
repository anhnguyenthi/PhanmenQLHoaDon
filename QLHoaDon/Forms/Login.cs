using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InvoiceManager
{
    public partial class Login : Form
    {
        public static string username;
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            if (doLogin(txtUserName.Text, txtPassword.Text))
            {
                username = txtUserName.Text;
                this.Hide();
                var invoiceManagerForm = new InvoiceManager();
                invoiceManagerForm.setLoginForm(this);
                invoiceManagerForm.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu của bạn không đúng. Hãy nhập lại.");
            }
        }

        bool doLogin(string username, string password)
        {
            string query = string.Format("SELECT * FROM USERS WHERE USERNAME='{0}' AND PASSWORD='{1}' AND IS_BLOCK='False'", username, password);
            if (DBManager.shared().ExecuteScalar(query) == null)
            {
                return false;
            }
            return true;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
            {
                txtPassword.PasswordChar = '\0';
            } else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}
