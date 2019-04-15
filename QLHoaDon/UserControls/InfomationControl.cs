using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager
{
    public partial class InfomationControl : UserControl
    {
        private int id;
        public InfomationControl()
        {
            InitializeComponent();
        }

        private void InfomationControl_Load(object sender, EventArgs e)
        {
            loadInfo();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFullName.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtPhoneNumber.ReadOnly = false;
            panel1.Enabled = true;
            btnCancel.Enabled = true;
            btnUpdate.Enabled = true;
        }

        private void loadInfo()
        {
            this.lblUsername.Text = Login.username;
            string query = string.Format("SELECT * FROM USERS WHERE USERNAME='{0}'", Login.username);
            DataTable data = DBManager.shared().ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                id = int.Parse(row["ID"].ToString());
                imgGender.InitialImage = null;
                txtFullName.Text = row["FULL_NAME"].ToString();
                txtPhoneNumber.Text = row["PHONE_NUMBER"].ToString();
                txtAddress.Text = row["ADDRESS"].ToString();
                if ((bool)row["GENDER"])
                {
                    imgGender.Image = Properties.Resources.male_20;
                    rbtnMale.Select();
                }
                else
                {
                    imgGender.Image = Properties.Resources.female_20;
                    rbtnFemale.Select();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool gender = rbtnMale.Checked ? true : false;
            string query = string.Format("UPDATE USERS SET FULL_NAME='{0}', gender='{1}', PHONE_NUMBER='{2}', ADDRESS='{3}' WHERE ID='{4}'", txtFullName.Text, gender, txtPhoneNumber.Text, txtAddress.Text, id);
            if (DBManager.shared().ExecuteNonQuery(query) > 0)
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
            loadInfo();

        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            DialogResult result;
            using (var form = new Forms.ChangePassword())
            {
                result = form.ShowDialog();
            }
        }
    }
}
