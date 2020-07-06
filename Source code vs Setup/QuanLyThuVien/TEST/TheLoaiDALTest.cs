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
    class TheLoaiDALTest
    {
        [Test]
        public void LoadTheLoaiTest()
        {
            TheLoaiDAL _instance = TheLoaiDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADTHELOAI");
            Assert.AreEqual(data.Rows.Count, _instance.LoadTheLoai().Count);
        }


        [Test]
        [TestCase("tlt01", "tlt01", true)]
        [TestCase("tlt01", "tlt01", false)]
        public void SaveTheLoaiTest(string MaTL, string TenTL, bool result)
        {
            TheLoaiDAL _instance = TheLoaiDAL.Instance;
            bool res = false;
            try
            {
                res = _instance.SaveTheLoai(MaTL, TenTL);
            }
            catch (Exception e) { }

            Assert.AreEqual(result, res);

        }

        [Test]
        [TestCase("tlt01", "tlt01")]

        public void UpdateTheLoaiTest(string MaTL, string TenTL)
        {
            TheLoaiDAL _instance = TheLoaiDAL.Instance;
            Assert.AreEqual(true, _instance.UpdateTheLoai(MaTL, TenTL));

        }

        [Test]
        [TestCase("tlt01", true)]
        [TestCase("TL001", false)]
        public void DeleteTheLoaiTest(string MaTL, bool result)
        {
            TheLoaiDAL _instance = TheLoaiDAL.Instance;
            bool res = false;
            try
            {
                res = _instance.DeleteTheLoai(MaTL);
            }
            catch (Exception e) { }
            
            Assert.AreEqual(result, res);
        }

        [Test]
        public void CountTLTest()
        {
            TheLoaiDAL _instance = TheLoaiDAL.Instance;
            Assert.AreEqual(_instance.LoadTheLoai().Count, _instance.CountTL());
        }
    }
}
