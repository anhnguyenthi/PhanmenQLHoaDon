﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager
{
    public class Kiemtradangnhap
    {
        public static string kt(string id, string pass)
        {
            if ((id == "") && (pass == "")) { return ("1"); }
            else
            if (id == "") { return ("2"); }
            else
            if (pass == "") { return ("3"); }

            else return "0";

        }
    }
}
