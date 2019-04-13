using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceManager.Forms
{
    public partial class DetailAdd : Form
    {
        public string invoice_id;
        public DetailAdd()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void DetailAdd_Load(object sender, EventArgs e)
        {
            comboBoxProduct.ValueMember = "id";
            comboBoxProduct.DisplayMember = "name";
            comboBoxProduct.DataSource = DBManager.shared().ExecuteQuery("select id,name from items order by name asc");
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        public decimal getAmount()
        {
            if (txtAmount.Text == "" || txtAmount.Text == null)
            {
                return 0;
            }
            return decimal.Parse(txtAmount.Text);
        }

        public int getIdItem()
        {
            return int.Parse(comboBoxProduct.SelectedValue.ToString());
        }

        public string getNameItem()
        {
            return comboBoxProduct.Text;
        }
    }
}
