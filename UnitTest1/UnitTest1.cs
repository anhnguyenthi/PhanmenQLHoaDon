using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using InvoiceManager;

namespace UnitTest1
{
    
    //Chinh sua mot vai thong tin o day 
    [TestClass]
    public class test_dangnhap:Login
    {
        Login lg = new Login();
        [TestMethod]
        public void Nhapdungtaikhoan1()
        {////Pass nếu dăng nhap dc
            bool actual = lg.doLogin("admin", "123456");
          
            Assert.IsTrue( actual);

        }

        [TestMethod]
        public void Nhapthieu_mavapw()     
        {
            //Pass nếu ko dăng nhap dc
            bool actual = lg.doLogin("", "");

            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Nhapthieu_ma()
        {
            //Pass nếu ko dăng nhap dc
            bool actual = lg.doLogin("", "123");

            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Nhapthieu_pw()
        {
            //Pass nếu ko dăng nhap dc
            bool actual = lg.doLogin("admin", "");

            Assert.IsFalse(actual);
        }
    }
    [TestClass]
    public class test_change_password
    {
        [TestMethod]
        public void Test_Nhap_Dung()
        {

            string actual = KiemtraPW.check_changepassword("123456", "abcdef", "abcdef", "123456");
            string expected = "Đổi mật khẩu thành công";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Nhap_MK_Cu_Khong_Dung()
        {

            string actual = KiemtraPW.check_changepassword("123456", "abcdef", "abcdef", "1234567");
            string expected = "Nhập sai mật khẩu cũ";
            Assert.AreEqual(expected, actual);
        }
        //[TestMethod]
        ////public void Test_Nhap_MK_Moi_Ngan()
        ////{

        ////    string actual = KiemtraPW.check_changepassword("123456", "1", "1", "123456");
        ////    string expected = "Mật khẩu mới quá ngắn";
        ////    Assert.AreEqual(expected, actual);
        ////}
        ////[TestMethod]
        ////public void Test_Nhap_MK_Moi_Dai()
        ////{

        ////    string actual = KiemtraPW.check_changepassword("123456", "123456789123456789123456789123456789", "123456789123456789123456789123456789", "123456");
        ////    string expected = "Mật khẩu mới quá dài";
        ////    Assert.AreEqual(expected, actual);
        ////}
        [TestMethod]
        public void Test_Nhap_MK_Moi_Khong_Trung()
        {

            string actual = KiemtraPW.check_changepassword("123456", "abcdefg", "abcdef", "1234567");
            string expected = "Xác nhận mật khẩu không đúng";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Khong_nhap_lai_MK()
        {

            string actual = KiemtraPW.check_changepassword("123456", "abcdefg", "", "123456");
            string expected = "Xác nhận mật khẩu không đúng";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Khong_Nhap_MK_Moi()
        {

            string actual = KiemtraPW.check_changepassword("123456", "", "abcdefg", "123456");
            string expected = "Xác nhận mật khẩu không đúng";
            Assert.AreEqual(expected, actual);
        }

    }
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
        //Thêm mới
        [TestMethod]
        public void ktranv_detrongtennv()
        {
            string expected = ktrnhanvien.ktra("admin", "", "371 Nguyễn Kiệm ", "0123833999");
            string actual = "Không được để trống tên nhân viên";

            Assert.AreEqual(expected, actual);
        }
       
        [TestMethod]
        public void Themthanhcong()
        {
            //string actual = kh ("KH12","Anh","BC","43543","45335");
            //string expected = "0";
            //Assert.AreEqual(expected, actual);
            //KhachHang kh1 = new KhachHang("PH2", "Phan", "Go Vap", "Nam", "08389283882");
            //string actual = kh.Inser
            //Assert.IsTrue(actual);
            string actual = ThemNV.themNV("Anh","0392334527","Huỳnh Đình Hai");
            string expected = "0";
            Assert.AreEqual(expected, actual);
        }
        //Thêm nhân viên trường hợp tên NV bỏ trống
        [TestMethod]
        public void Them_thieutennhanvien()
        {
            string actual = ThemNV.themNV("", "0392334527", "Huỳnh Đình Hai");
            string expected = "0";
            Assert.AreEqual(expected, actual);
        }
        //Thiếu sđt nhân viên
        [TestMethod]
        public void Them_thieu_SDT_nhanvien()
        {
            string actual = ThemNV.themNV("Anh","", "Huỳnh Đình Hai");
            string expected = "0";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Them_thieu_DC_nhanvien()
        {
            string actual = ThemNV.themNV("Anh", "1234567891", "");
            string expected = "0";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Them_thieu_SDT_quadai()
        {
            string actual = ThemNV.themNV("Anh", "12345678901234", "Huỳnh Đình Hai");
            string expected = "0";
            Assert.AreEqual(expected, actual);
        }

    }
}


   
