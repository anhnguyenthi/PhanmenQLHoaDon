using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager
{
    public class ktrnhanvien
    {
                   public static string ktra(string Authorize, string tenNV,string diaChi, string sdt)
            {
                if (Authorize == "admin")
                {
                    if (tenNV.Length <= 0)
                    { return ("Không được để trống tên nhân viên"); }

                                        else
                                if (diaChi.Length - 1 <= 0)
                    { return ("Không được để trống địa chỉ"); }
                                       else
                    if (sdt.Length != 10)
                    { return ("Số điện thoại phải có 10 số"); }
                    return "0";
                }
                { return "Bạn không có quyền chỉnh sửa và xóa"; }
            }

            public static string ktra(string Authorize, string taikhoan)
            {
                if (Authorize != "admin")
                { return ("Không thể xóa tài khoản admin"); }
                else return "0";

            }

        }
    }
