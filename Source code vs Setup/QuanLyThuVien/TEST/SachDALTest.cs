using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QuanLyThuVien.DAL;
using static QuanLyThuVien.DAL.DatabaseAccess;

namespace QuanLyThuVien.TEST
{
    [TestFixture]
    class SachDALTest
    {
        [Test]
        public void LoadBooksTest()
        {
            SachDAL _instance = SachDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADBOOKS");
            Assert.AreEqual(data.Rows.Count, _instance.LoadBooks().Count);
        }

        [Test]
        [TestCase("Sach0", "sach0", "TL001", "TG001", "2019", "GD", "2/2/2019", "12000", "True", "Không có ảnh", true)]
        [TestCase("Sach0", "sach0", "TL001", "TG001", "2019", "GD", "2/2/2019", "12000", "True", "Không có ảnh", false)]
        public void SaveBookTest(string Ma, string Ten, string TL, string TG, string NamXB, string NXB
            , string NgayNhap, string TriGia, string TinhTrang, string AnhBia, bool result)
        {
            SachDAL _instance = SachDAL.Instance;
            bool res = false;
            try
            {
                res = _instance.SaveBook(Ma, Ten, TL, TG, NamXB, NXB, NgayNhap, TriGia, TinhTrang, AnhBia);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("Sach0", "sach1", "TL001", "TG001", "2019", "GD", "2/2/2019", "12000", "True", "Không có ảnh", true)]

        public void UpdateBookTest(string Ma, string Ten, string TL, string TG, string NamXB, string NXB
           , string NgayNhap, string TriGia, string TinhTrang, string AnhBia, bool result)
        {
            SachDAL _instance = SachDAL.Instance;

            Assert.AreEqual(result, _instance.UpdateBook(Ma, Ten, TL, TG, NamXB, NXB, NgayNhap, TriGia, TinhTrang, AnhBia), "Test Update");

        }

        [Test]
        [TestCase("Sach0", true)]
        public void DeleteBookTest(string Ma, bool result)
        {
            SachDAL _instance = SachDAL.Instance;
            Assert.AreEqual(result, _instance.DeleteBook(Ma));
        }

        [Test]
        [TestCase("S001", false)]
        [TestCase("S002", true)]
        public void GetTinhTrangSachByMaSachTest(string ma, bool tinhtrang)
        {
            Assert.AreEqual(tinhtrang, SachDAL.Instance.GetTinhTrangSachByMaSach(ma));
        }

        [Test]
        [TestCase("S003", true)]
        public void UpdateTinhTrangSachTraTest(string maSach, bool result)
        {
            Assert.AreEqual(result, SachDAL.Instance.UpdateTinhTrangSachTra(maSach));
        }
    }
}