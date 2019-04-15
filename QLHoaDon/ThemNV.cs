using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager
{
    public class ThemNV
    {
       
            public static string themNV(string ten,string sdt,string dc)
            {
            if (ten.Length > 30)
            {
                return "Tên NV quá dài";
            }

            else if (sdt.Length > 11)
            { return "Số điện thoại quá dài"; }
            else if (dc == "")
            { return " Không được để trống địa chỉ "; }
                return "0";
            }
        
    }
}
