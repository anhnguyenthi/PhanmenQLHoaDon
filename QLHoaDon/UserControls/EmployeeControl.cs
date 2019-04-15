using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InvoiceManager.UserControls
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isValidateError())
            {

            } else
            {
                if (DBManager.shared().ExecuteScalar(string.Format("SELECT * FROM USERS WHERE USERNAME='{0}'", txtUsername.Text)) == null)
                {
                    string query = string.Format("INSERT INTO USERS(USERNAME, PASSWORD, FULL_NAME, GENDER, PHONE_NUMBER, ADDRESS, IS_ADMIN, IS_BLOCK) VALUES('{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', '{6}', '{7}')", txtUsername.Text, "123456", txtFullName.Text, rbtnMale.Checked, txtPhoneNumber.Text, txtAddress.Text, checkBoxAdmin.Checked, false);
                    if (DBManager.shared().ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công");
                        emptyText();
                        isEnable(false);
                        txtUsername.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới thất bại");
                    }
                }
                else
                {
                    string query = string.Format("UPDATE USERS SET FULL_NAME='{0}', GENDER='{1}', PHONE_NUMBER='{2}', ADDRESS='{3}', IS_ADMIN='{4}', IS_BLOCK='{5}' WHERE USERNAME='{6}'", txtFullName.Text, rbtnMale.Checked, txtPhoneNumber.Text, txtAddress.Text, checkBoxAdmin.Checked, false, txtUsername.Text);
                    if (DBManager.shared().ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        emptyText();
                        isEnable(false);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thất bại");
                    }
                }

                loadDataGird();
            }
            
        }

        private void EmployeeControl_Load(object sender, EventArgs e)
        {
            loadDataGird();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            isEnable(true);
            emptyText();
            txtUsername.Enabled = true;
        }

        private void isEnable(bool isEnable)
        {
            txtUsername.Enabled = false;
            txtFullName.Enabled = isEnable;
            txtAddress.Enabled = isEnable;
            txtPhoneNumber.Enabled = isEnable;
            panelGender.Enabled = isEnable;
            btnCancel.Enabled = isEnable;
            btnUpdate.Enabled = isEnable;
            checkBoxAdmin.Enabled = isEnable;
        }

        private void loadDataGird()
        {
            string query = string.Format("SELECT USERNAME as [Tên đăng nhập], FULL_NAME as [Tên hiển thị], GENDER as [Nam], PHONE_NUMBER as [Số điện thoại], ADDRESS as [Địa chỉ], IS_ADMIN as [Quản trị viên], IS_BLOCK FROM USERS");
            dataGridView1.DataSource = DBManager.shared().ExecuteQuery(query);
        }

        private void emptyText()
        {
            txtUsername.Text = "";
            txtAddress.Text = "";
            txtFullName.Text = "";
            txtPhoneNumber.Text = "";
            checkBoxAdmin.Checked = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell.Selected)
            {
                isEnable(true);
            } else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.Selected)
            {
                loadText();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadText();
        }

        private void loadText()
        {
            int indexRow = dataGridView1.CurrentCell.RowIndex;
            txtUsername.Text = dataGridView1.Rows[indexRow].Cells[0].Value.ToString();
            txtFullName.Text = dataGridView1.Rows[indexRow].Cells[1].Value.ToString();
            if ((bool)dataGridView1.Rows[indexRow].Cells[2].Value)
            {
                rbtnMale.Checked = true;
            }
            else
            {
                rbtnFemale.Checked = true;
            }
            txtPhoneNumber.Text = dataGridView1.Rows[indexRow].Cells[3].Value.ToString();
            txtAddress.Text = dataGridView1.Rows[indexRow].Cells[4].Value.ToString();
            if ((bool)dataGridView1.Rows[indexRow].Cells[5].Value)
            {
                checkBoxAdmin.Checked = true;
            } else
            {
                checkBoxAdmin.Checked = false;
            }
        }

        private void setBlock(bool isBlock)
        {
            if (dataGridView1.CurrentCell.Selected)
            {
                int indexRow = dataGridView1.CurrentCell.RowIndex;
                if (dataGridView1.Rows[indexRow].Cells[0].Value.ToString() == Login.username)
                {
                    MessageBox.Show("Không thể chọn nhân viên " + Login.username);
                } else
                {
                    string query = string.Format("UPDATE USERS SET IS_BLOCK='{0}' WHERE USERNAME='{1}'", isBlock, dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                    DBManager.shared().ExecuteNonQuery(query);
                    if (isBlock)
                    {
                        MessageBox.Show("Đã khóa nhân viên " + dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Đã mở khóa nhân viên " + dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                    }
                    loadDataGird();
                }
                
            } else
            {
                MessageBox.Show("Vui lòng chọn nhân viên");
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn khóa tài khoản này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                setBlock(true);
            }
        }

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            setBlock(false);
        }

        private bool isValidateError()
        {
            if (txtUsername.Text.Length == 0 || txtFullName.Text.Length == 0 || txtPhoneNumber.Text.Length == 0 || txtAddress.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                return true;
            }
            if (!Regex.IsMatch(txtPhoneNumber.Text, "^[0-9]*$"))
            {
                MessageBox.Show("Số điện thoại chỉ bao gồm số");
                return true;
            }
            if (txtPhoneNumber.Text.Length > 10)
            {
                MessageBox.Show("Số điện thoại tối đa 10 chữ số");
                return true;
            }
            
            return false;
        }
    }
}
