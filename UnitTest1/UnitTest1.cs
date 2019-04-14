using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using InvoiceManager;

namespace UnitTest1
{
    [TestClass]
    public class test_dangnhap
    {
        [TestMethod]
        public void Test_Nhap_Dung_Tai_Khoan()
        {
            string actual = Kiemtradangnhap.kt("admin", "123456");
            string expected = "0";
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_Nhap_Thieu_ID_and_Pass()
        {
            string actual = Kiemtradangnhap.kt("", "");
            string expected = "1";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Nhap_Thieu_ID()
        {
            string actual = Kiemtradangnhap.kt("", "123");
            string expected = "2";
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Nhap_Thieu_Pass()
        {
            string actual = Kiemtradangnhap.kt("an", "");
            string expected = "3";
            Assert.AreEqual(expected, actual);
        }
    }
}
