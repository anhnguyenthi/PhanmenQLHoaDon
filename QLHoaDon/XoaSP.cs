using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace InvoiceManager
{
    public class XoaSP
    {
        public static string checkXoa(string tenSP)
        {
            if (tenSP.Length < 150)
            {
                return "Xóa thành công";
            }

            return "0";

        }
    }
}
