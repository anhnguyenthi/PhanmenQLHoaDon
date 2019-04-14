using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using InvoiceManager;

namespace UnitTest1
{
    //[TestClass]
    //public class test_dangnhap
    //{
    //    [TestMethod]
    //    public void Test_Nhap_Dung_Tai_Khoan()
    //    {
    //        string actual = Kiemtradangnhap.kt("admin", "123456");
    //        string expected = "0";
    //        Assert.AreEqual(expected, actual);

    //    }
    //    [TestMethod]
    //    public void Test_Nhap_Thieu_ID_and_Pass()
    //    {
    //        string actual = Kiemtradangnhap.kt("", "");
    //        string expected = "1";
    //        Assert.AreEqual(expected, actual);
    //    }
    //    [TestMethod]
    //    public void Test_Nhap_Thieu_ID()
    //    {
    //        string actual = Kiemtradangnhap.kt("", "123");
    //        string expected = "2";
    //        Assert.AreEqual(expected, actual);
    //    }
    //    [TestMethod]
    //    public void Test_Nhap_Thieu_Pass()
    //    {
    //        string actual = Kiemtradangnhap.kt("an", "");
    //        string expected = "3";
    //        Assert.AreEqual(expected, actual);
    //    }
    //}
    //[TestClass]
    //public class test_change_password
    //{
    //    [TestMethod]
    //    public void Test_Nhap_Dung()
    //    {

    //        string actual = KiemtraPW.check_changepassword("123456", "abcdef", "abcdef", "123456");
    //        string expected = "Đổi mật khẩu thành công";
    //        Assert.AreEqual(expected, actual);
    //    }
    //    [TestMethod]
    //    public void Test_Nhap_MK_Cu_Khong_Dung()
    //    {

    //        string actual = KiemtraPW.check_changepassword("123456", "abcdef", "abcdef", "1234567");
    //        string expected = "Nhập sai mật khẩu cũ";
    //        Assert.AreEqual(expected, actual);
    //    }
    //    //[TestMethod]
    //    ////public void Test_Nhap_MK_Moi_Ngan()
    //    ////{

    //    ////    string actual = KiemtraPW.check_changepassword("123456", "1", "1", "123456");
    //    ////    string expected = "Mật khẩu mới quá ngắn";
    //    ////    Assert.AreEqual(expected, actual);
    //    ////}
    //    ////[TestMethod]
    //    ////public void Test_Nhap_MK_Moi_Dai()
    //    ////{

    //    ////    string actual = KiemtraPW.check_changepassword("123456", "123456789123456789123456789123456789", "123456789123456789123456789123456789", "123456");
    //    ////    string expected = "Mật khẩu mới quá dài";
    //    ////    Assert.AreEqual(expected, actual);
    //    ////}
    //    [TestMethod]
    //    public void Test_Nhap_MK_Moi_Khong_Trung()
    //    {

    //        string actual = KiemtraPW.check_changepassword("123456", "abcdefg", "abcdef", "1234567");
    //        string expected = "Xác nhận mật khẩu không đúng";
    //        Assert.AreEqual(expected, actual);
    //    }

    //    [TestMethod]
    //    public void Test_Khong_nhap_lai_MK()
    //    {

    //        string actual = KiemtraPW.check_changepassword("123456", "abcdefg", "", "123456");
    //        string expected = "Xác nhận mật khẩu không đúng";
    //        Assert.AreEqual(expected, actual);
    //    }
    //    [TestMethod]
    //    public void Test_Khong_Nhap_MK_Moi()
    //    {

    //        string actual = KiemtraPW.check_changepassword("123456", "", "abcdefg", "123456");
    //        string expected = "Xác nhận mật khẩu không đúng";
    //        Assert.AreEqual(expected, actual);
    //    }

    //}
    [TestClass]
    public class kiemtranhanvien
    {
        [TestMethod]
        public void ktranv()
       {
            string expected = ktrnhanvien.ktra("admin", "Anh", "371 Nguyễn Kiệm","0123833999");
            string actual = "0";

            Assert.AreEqual(expected, actual);
        }

       
    }
}


   
