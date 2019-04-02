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
    public partial class ProductControl : UserControl
    {
        public ProductControl()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtPrice.Text, "[0-9]"))
            {
                if (txtID.Text == "")
                {
                    string query = string.Format("INSERT INTO ITEMS(NAME, PRICE) VALUES(N'{0}', {1})", txtName.Text, txtPrice.Text);
                    if (DBManager.shared().ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Thêm mới thành công");
                    }
                }
                else
                {
                    string query = string.Format("UPDATE ITEMS SET NAME=N'{0}', PRICE={1} WHERE ID={2}", txtName.Text, txtPrice.Text, txtID.Text);
                    if (DBManager.shared().ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                    }
                }

                loadDataGrid();
            } else
            {
                MessageBox.Show("Sai định dạng (Giá chỉ là số)");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                int indexRow = dataGridView1.CurrentCell.RowIndex;

                string query = string.Format("DELETE FROM ITEMS WHERE ID='{0}'", dataGridView1.Rows[indexRow].Cells[0].Value.ToString());
                if (DBManager.shared().ExecuteNonQuery(query) > 0)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else
                {
                    MessageBox.Show("Chưa xóa");
                }
                loadDataGrid();
            }
        }

        private void ProductControl_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void loadDataGrid()
        {
            string query = string.Format("SELECT id as [ID], name as [Tên], price as [Giá] FROM ITEMS");
            dataGridView1.DataSource = DBManager.shared().ExecuteQuery(query);
        }

        private void emptyText()
        {
            txtName.Text = "";
            txtPrice.Text = "";
        }

        private void loadText()
        {
            int indexRow = dataGridView1.CurrentCell.RowIndex;
            txtID.Text = dataGridView1.Rows[indexRow].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.Rows[indexRow].Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.Rows[indexRow].Cells[2].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.Selected)
            {
                loadText();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT id as [ID], name as [Tên], price as [Giá] FROM ITEMS WHERE NAME LIKE '%{0}%'", txtSearch.Text);
            dataGridView1.DataSource = DBManager.shared().ExecuteQuery(query);
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
