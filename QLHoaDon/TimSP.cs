using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager
{
    public class TimSP
    {
        public static string checkTim(string tenSP)
        {
            if (tenSP.Length > 150) 
            {
                return "Tìm thành công";
            }
            else
            return "0";

        }
    }
}
