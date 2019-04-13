using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager.UserControls
{
    public partial class InvoiceControl : UserControl
    {
        private DataTable dataDetails;
        private string queryDetails = "";
        private StringBuilder temp;
        public InvoiceControl()
        {
            InitializeComponent();
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.RowCount != 0 && dataGridViewInvoices.CurrentCell.Selected)
            {
                panelDetail.Enabled = true;
                loadTextDetail();

            } else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
                panelDetail.Enabled = false;
            }
            
        }

        private void loadDataInvoices()
        {
            string query = string.Format("SELECT ID, DATE_VALUE as [Ngày], CUSTOMER_NAME as [Tên khách hàng], CUSTOMER_PHONE as [Số điện thoại], PRICE as [Tổng], STATUS as [Khóa] FROM INVOICES");
            dataGridViewInvoices.DataSource = DBManager.shared().ExecuteQuery(query);
        }

        private void loadDataDetail(string id)
        {
            string query = string.Format("SELECT DETAILS.ID, ITEMS.NAME as [Tên], ITEMS.price as [Giá], DETAILS.amount as [Số lượng], ITEMS.price*DETAILS.amount as [Thành tiền] FROM DETAILS,ITEMS WHERE ITEMS.id=DETAILS.item_id AND DETAILS.invoice_id={0}",id);
            dataDetails = DBManager.shared().ExecuteQuery(query);
            dataGridViewDetails.DataSource = dataDetails;
            dataGridViewDetails.Columns[0].Visible = false;
        }

        private void InvoiceControl_Load(object sender, EventArgs e)
        {
            loadDataInvoices();
        }

        private void btnAddInvoice_Click(object sender, EventArgs e)
        {
            panelDetail.Enabled = true;
            emptyPanelDetails(true);
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            using (Forms.DetailAdd detailForm = new Forms.DetailAdd())
            {
                detailForm.ShowDialog();
                if (detailForm.DialogResult == DialogResult.OK)
                {
                    string query = string.Format("SELECT * FROM ITEMS WHERE ID='{0}'",detailForm.getIdItem());
                    DataTable dataTemp = DBManager.shared().ExecuteQuery(query);
                    if (detailForm.getAmount() != 0) {
                        Dictionary<string, object> dic = checkExistInColumn(dataDetails, "Tên", detailForm.getNameItem());
                        if (bool.Parse(dic["isExist"].ToString()))
                        {
                            int index = int.Parse(dic["index"].ToString());
                            Console.Write(dataDetails.Rows[index]["Số lượng"]);
                            dataDetails.Rows[index]["Số lượng"] = decimal.Round(decimal.Parse(dataDetails.Rows[index]["Số lượng"].ToString()) + detailForm.getAmount(), 2);
                            dataDetails.Rows[index]["Thành tiền"] = decimal.Parse(dataDetails.Rows[index]["Số lượng"].ToString()) * decimal.Parse(dataDetails.Rows[index]["Giá"].ToString());
                        } else
                        {
                            DataRow dr = dataDetails.NewRow();
                            foreach (DataRow drTmp in dataTemp.Rows)
                            {
                                dr["Tên"] = drTmp["name"];
                                dr["Giá"] = drTmp["price"];
                            }
                            dr["Số lượng"] = detailForm.getAmount();
                            dr["Thành tiền"] = detailForm.getAmount() * decimal.Parse(dr["Giá"].ToString());
                            dataDetails.Rows.InsertAt(dr, dataDetails.Rows.Count);
                        }

                        dataGridViewDetails.DataSource = dataDetails;
                        showTotal();
                    }
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT ID, DATE_VALUE as [Ngày], CUSTOMER_NAME as [Tên khách hàng], CUSTOMER_PHONE as [Số điện thoại], PRICE as [Tổng], STATUS as [Khóa] FROM INVOICES WHERE CUSTOMER_NAME LIKE '%{0}%'", txtSearch.Text);
            dataGridViewInvoices.DataSource = DBManager.shared().ExecuteQuery(query);
        }

        private void dataGridViewInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.CurrentCell != null)
            {
                string id = dataGridViewInvoices.Rows[dataGridViewInvoices.CurrentCell.RowIndex].Cells[0].Value.ToString();
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn???", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string query = string.Format("DELETE FROM DETAILS WHERE INVOICE_ID={0};DELETE FROM INVOICES WHERE ID={1}", id, id);
                    DBManager.shared().ExecuteNonQuery(query);
                }
                loadDataInvoices();
                emptyPanelDetails(false);
            } else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.CurrentCell != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn khóa hóa đơn", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    string query = string.Format("UPDATE INVOICES SET STATUS='TRUE' WHERE ID='{0}'", dataGridViewInvoices.Rows[dataGridViewInvoices.CurrentCell.RowIndex].Cells[0]);
                    if (DBManager.shared().ExecuteNonQuery(query) > 0)
                    {
                        MessageBox.Show("Đã khóa hóa đơn, bạn không thể chỉnh sửa");
                    }
                }
            } else
            {
                MessageBox.Show("Vui lòng chọn hóa đơn");
            }
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (dataGridViewDetails.CurrentCell != null)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    Console.Write(dataDetails.Rows[dataGridViewDetails.CurrentCell.RowIndex]["ID"]);
                    if (!dataDetails.Rows[dataGridViewDetails.CurrentCell.RowIndex]["ID"].ToString().Equals(""))
                    {
                        queryDetails += string.Format("DELETE FROM DETAILS WHERE ID={0};", dataDetails.Rows[dataGridViewDetails.CurrentCell.RowIndex]["ID"]);
                    }
                    dataDetails.Rows.RemoveAt(dataGridViewDetails.CurrentCell.RowIndex);
                    dataGridViewDetails.DataSource = dataDetails;
                    showTotal();
                }
            } else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCustomerName.TextLength == 0)
            {
                MessageBox.Show("Chưa nhập tên khách hàng");
            } else if (dataGridViewDetails.RowCount == 0 && queryDetails.Equals(""))
            {
                MessageBox.Show("Chưa nhập sản phẩm");
            } else
            {
                getQuery();
                if (txtID.Text.Equals(""))
                {
                    //Random random = new Random();
                    //string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                    //StringBuilder temp = new StringBuilder(20);
                    //for (int i = 0; i < 20; i++)
                    //{
                    //    temp.Append(characters[random.Next(characters.Length)]);
                    //}
                    string query = string.Format("INSERT INTO INVOICES(DATE_VALUE, PRICE, CUSTOMER_NAME, CUSTOMER_PHONE, TEMP) VALUES('{0}', {1}, '{2}', '{3}', '{4}')", DateTime.Now.ToString("yyyy-MM-dd"), txtAmountTotal.Text, txtCustomerName.Text, txtCustomerPhone.Text, temp);
                    DBManager.shared().ExecuteNonQuery(query);
                    DBManager.shared().ExecuteNonQuery(queryDetails);
                    DBManager.shared().ExecuteNonQuery(string.Format("UPDATE INVOICES SET TEMP=NULL WHERE TEMP='{0}'", temp));
                } else
                {
                    DBManager.shared().ExecuteNonQuery(queryDetails);
                    if (dataGridViewDetails.RowCount == 0)
                    {
                        DBManager.shared().ExecuteNonQuery(string.Format("DELETE FROM INVOICES WHERE ID='{0}'", txtID.Text));
                    } else
                    {
                        string query = string.Format("UPDATE INVOICES SET PRICE={0}, CUSTOMER_NAME='{1}', CUSTOMER_PHONE='{2}' WHERE ID={3}", txtAmountTotal.Text, txtCustomerName.Text, txtCustomerPhone.Text, txtID.Text);
                        DBManager.shared().ExecuteNonQuery(query);
                    }
                }  
                loadDataInvoices();
                emptyPanelDetails(false);
                queryDetails = "";
                temp.Clear();
            }
        }

        private void loadTextDetail()
        {
            int indexRow = dataGridViewInvoices.CurrentCell.RowIndex;
            txtID.Text = dataGridViewInvoices.Rows[indexRow].Cells[0].Value.ToString();
            txtCustomerName.Text = dataGridViewInvoices.Rows[indexRow].Cells[2].Value.ToString();
            txtCustomerPhone.Text = dataGridViewInvoices.Rows[indexRow].Cells[3].Value.ToString();
            txtAmountTotal.Text = dataGridViewInvoices.Rows[indexRow].Cells[4].Value.ToString();
            loadDataDetail(txtID.Text);
        }

        private Dictionary<string, object> checkExistInColumn(DataTable dataTable, string rowName, string value)
        {
            Dictionary<string, object> resultList = new Dictionary<string, object>();
            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[rowName].Equals(value))
                {
                    resultList.Add("isExist", true);
                    resultList.Add("index", dataTable.Rows.IndexOf(dr));
                    return resultList;
                }
            }
            resultList.Add("isExist", false);
            resultList.Add("index", -1);
            return resultList;
        }

        private void showTotal()
        {
            if (dataDetails.Rows.Count == 0)
            {
                txtAmountTotal.Text = "0";
            } else
            {
                decimal total = 0;
                foreach (DataRow dr in dataDetails.Rows)
                {
                    total += decimal.Parse(dr["Thành tiền"].ToString());
                }
                txtAmountTotal.Text = total.ToString();
            }
            
        }

        private void getQuery()
        {
            temp = new StringBuilder(20);
            if (txtID.Text.Equals(""))
            {
                Random random = new Random();
                string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                for (int i = 0; i < 20; i++)
                {
                    temp.Append(characters[random.Next(characters.Length)]);
                }
            }
            foreach (DataRow dr in dataDetails.Rows)
            {
                if (dr["ID"].ToString().Equals(""))
                {
                    if (txtID.Text.Equals(""))
                    {
                        queryDetails += string.Format("INSERT INTO DETAILS(INVOICE_ID, ITEM_ID, AMOUNT) VALUES((SELECT ID FROM INVOICES WHERE TEMP='{0}'), (SELECT ID FROM ITEMS WHERE NAME=N'{1}'), {2});", temp, dr["Tên"], dr["Số lượng"]);
                    }
                    else
                    {
                        queryDetails += string.Format("INSERT INTO DETAILS(INVOICE_ID, ITEM_ID, AMOUNT) VALUES('{0}', (SELECT ID FROM ITEMS WHERE NAME=N'{1}'), {2});", txtID.Text, dr["Tên"], dr["Số lượng"]);
                    }
                } else
                {
                    if (txtID.Text.Equals(""))
                    {
                        queryDetails += string.Format("UPDATE DETAILS SET ITEM_ID=(SELECT ID FROM ITEMS WHERE NAME=N'{0}'), AMOUNT='{1}' WHERE TEMP='{2}';", dr["Tên"], dr["Số lượng"], temp);
                    }
                    else
                    {
                        queryDetails += string.Format("UPDATE DETAILS SET ITEM_ID=(SELECT ID FROM ITEMS WHERE NAME=N'{0}'), AMOUNT='{1}' WHERE ID='{2}';", dr["Tên"], dr["Số lượng"], dr["ID"]);
                    }
                }
            }
        }

        private void emptyPanelDetails(bool isEnable)
        {
            loadDataDetail("0");
            txtCustomerName.Text = "";
            txtCustomerPhone.Text = "";
            txtAmountTotal.Text = "0";
            txtID.Text = "";
            panelDetail.Enabled = isEnable;
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
