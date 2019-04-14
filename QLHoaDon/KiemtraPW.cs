using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager
{
    public class KiemtraPW
    {
        
            public static string check_changepassword(string oldpass, string newpass, string confpass , string mainPass)
            {

                if (newpass.Length - 1 < 5) { return "Xác nhận mật khẩu không đúng"; }
                else if (newpass.Length - 1 > 30) { return "Mật khẩu mới quá dài"; }
                else if (newpass != confpass) { return "Xác nhận mật khẩu không đúng"; }
                else if (oldpass != mainPass) { return "Nhập sai mật khẩu cũ"; }
            return "Đổi mật khẩu thành công";
            }
    }

}

