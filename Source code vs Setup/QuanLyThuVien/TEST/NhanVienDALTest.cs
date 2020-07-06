using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QuanLyThuVien.DAL;
using QuanLyThuVien.DTO;
using static QuanLyThuVien.DAL.DatabaseAccess;

namespace QuanLyThuVien.TEST
{
    [TestFixture]
    class NhanVienDALTest
    {
        [Test]
        public void LoadNhanVienTest()
        {
            NhanVienDAL _instance = NhanVienDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADNHANVIEN");
            Assert.AreEqual(data.Rows.Count, _instance.LoadNhanVien().Count);
        }

        [Test]
        [TestCase("abc", "NV001")]
        public void LoadNhanVienByTaikhoan(string taikhoan, string result)
        {
            Assert.AreEqual(result, NhanVienDAL.Instance.LoadNhanVienByTaikhoan(taikhoan).MaNV);
        }

        [Test]
        [TestCase("nvTest", "Ten Nv Test", 0, "tkTest", "mkTest", true)]
        [TestCase("nvTest", "", 1, "", "", false)]
        public void SaveNhanVienTest(string MaNV, string TenNV, int ChucVu, string TaiKhoan, string MatKhau, bool result)
        {
            bool res = false;
            try
            {
                res = NhanVienDAL.Instance.SaveNhanVien(MaNV, TenNV, ChucVu, TaiKhoan, MatKhau);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("nvTest", "update", 1, "tkTest", "mkTest", true)]

        public void UpdateNhanVienTest(string MaNV, string TenNV, int ChucVu, string TaiKhoan, string MatKhau, bool result)
        {
            bool res = false;
            try
            {
                res = NhanVienDAL.Instance.UpdateNhanVien(MaNV, TenNV, ChucVu, TaiKhoan, MatKhau);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }


        [Test]
        [TestCase("abc", "abc", "Đăng nhập thành công!")]
        [TestCase("a", "abc", "Tên tài khoản hoặc mật khẩu không đúng!")]
        [TestCase("abc", "a", "Tên tài khoản hoặc mật khẩu không đúng!")]
        public void CheckLoginTest(string taikhoan, string matkhau, string result)
        {
            Assert.AreEqual(result, NhanVienDAL.Instance.CheckLogin(taikhoan, matkhau));
        }


        [Test]
        [TestCase("nvTest", "mkNew", true)]
        [TestCase("false", "mkNew", false)]
        public void UpdateMatKhauTest(string manv, string matkhaumoi, bool result)
        {
            bool res = false;
            try
            {
                res = NhanVienDAL.Instance.UpdateMatKhau(manv, matkhaumoi);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }


        [Test]
        [TestCase("nvTest", true)]
        public void DeleteNhanVienTest(string MaNV, bool result)
        {
            bool res = false;
            try
            {
                res = NhanVienDAL.Instance.DeleteNhanVien(MaNV);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }
    }
}
