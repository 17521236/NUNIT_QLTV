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
    class LoaiDocGiaDALTest
    {
        [Test]
        public void LoadLoaiDocGiaTest()
        {
            LoaiDocGiaDAL _instance = LoaiDocGiaDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADLOAIDOCGIA");
            Assert.AreEqual(data.Rows.Count, _instance.LoadLoaiDocGia().Count);
        }

        [Test]
        [TestCase("Test01", "Ten ldg Test01", true)]
        [TestCase("Test01", "Ten ldg Test01", false)]
        public void SaveLOAIDGTest(string Ma, string Ten, bool result)
        {
            bool res = false;
            try
            {
                res = LoaiDocGiaDAL.Instance.SaveLOAIDG(Ma, Ten);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("Test01", "Update Tên", true)]
        public void UpdateLoaiDGTest(string Ma, string Ten, bool result)
        {

            bool res = false;
            try
            {
                res = LoaiDocGiaDAL.Instance.UpdateLoaiDG(Ma, Ten);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("Test01", true)]
        [TestCase("LDG001", false)]
        public void DeleteLDGTest(string Ma,bool result)
        {
            bool res = false;
            try
            {
                res = LoaiDocGiaDAL.Instance.DeleteLDG(Ma);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }
    }
}
