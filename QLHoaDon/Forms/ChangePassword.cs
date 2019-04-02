using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager.Forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtConfirmPassword.Text)
            {
                string query = string.Format("UPDATE USERS SET PASSWORD='{0}' WHERE USERNAME='{1}' AND PASSWORD='{2}'", txtNewPassword.Text, Login.username, txtOldPassword.Text);
                int result = DBManager.shared().ExecuteNonQuery(query);
                if (result == 0)
                {
                    MessageBox.Show("Nhập sai mật khẩu cũ");
                } else
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng");
            }
        }
    }
}
