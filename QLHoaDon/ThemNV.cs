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

            else if (ten == "" )
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
            else if (sdt == "")
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
            else if (dc == "")
            {
                return "Vui lòng điền đầy đủ thông tin";
            }
            return "0";
            }
        
    }
}
