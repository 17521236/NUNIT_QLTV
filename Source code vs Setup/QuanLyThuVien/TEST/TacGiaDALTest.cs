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
    class TacGiaDALTest
    {
        [Test]
        public void LoadTacGiaTest()
        {
            TacGiaDAL _instance = TacGiaDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADTACGIA");
            Assert.AreEqual(data.Rows.Count, _instance.LoadTacGia().Count);
        }

        [Test]
        [TestCase("tg01", "tg01", true)]
        [TestCase("tg01", "tg01", false)]
        public void SaveTacGiaTest(string MaTG, string TenTG, bool result)
        {
            TacGiaDAL _instance = TacGiaDAL.Instance;
            bool res = false;
            try
            {
                res = _instance.SaveTacGia(MaTG, TenTG);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);

        }

        [Test]
        [TestCase("tg01", "tg01", true)]
        public void UpdateTacGia(string MaTG, string TenTG, bool result)
        {
            TacGiaDAL _instance = TacGiaDAL.Instance;
            Assert.AreEqual(result, _instance.UpdateTacGia(MaTG, TenTG), "Test Update ");
        }

        [Test]
        [TestCase("tg01", true)]
        [TestCase("TG001", false)]
        public void DeleteTacGiaTest(string MaTG, bool result)
        {
            TacGiaDAL _instance = TacGiaDAL.Instance;
            bool res = false;

            try
            {
                res = _instance.DeleteTacGia(MaTG);
            }
            catch (Exception e) { }
            
            Assert.AreEqual(result, res);

        }


    }
}
