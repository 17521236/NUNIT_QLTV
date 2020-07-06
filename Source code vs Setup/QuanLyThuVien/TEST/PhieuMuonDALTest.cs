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
    class PhieuMuonDALTest
    {
        [Test]
        public void LoadPhieuMuonTest()
        {
            PhieuMuonDAL _instance = PhieuMuonDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADPHIEUMUON");
            Assert.AreEqual(data.Rows.Count, _instance.LoadPhieuMuon().Count);
        }


        [Test]
        [TestCase("maPM", "DG001", "06/06/2020", "NV001", "02/07/2020", true)]
        [TestCase("maPM", "DG001", "15/06/2020", "NV001", "20/07/2020", false)]
        [TestCase("maPM1", "DG002", "01/01/2020", "NV001", "12/12/2019", false)]
        public void SavePhieuMuonTest(string maPM, string maDG, string ngayMuon, string maNV, string hanTra, bool result)
        {
            bool res = false;
            try
            {
                res = PhieuMuonDAL.Instance.SavePhieuMuon(maPM, maDG, ngayMuon, maNV, hanTra);
            }
            catch (Exception) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("maPM1", "S004", true)]
        [TestCase("maPM1", "S005", false)]
        public void SaveCTPhieuMuonTest(string maPM, string maSach, bool result)
        {
            bool res = false;
            try
            {
                res = PhieuMuonDAL.Instance.SaveCTPhieuMuon(maPM, maSach);
            }
            catch (Exception) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("DG002")]

        public void LoadAllPMByMaDGTest(string maDG)
        {
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_GETALLMAPMBYMADOCGIA @Ma", new object[] { maDG });
            Assert.AreEqual(data.Rows.Count, PhieuMuonDAL.Instance.LoadAllPMByMaDG(maDG).Count);
        }

        [Test]
        [TestCase("PM002")]

        public void LoadAllTinhTrangSachByMaPM(string maPM)
        {
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("GETALLTINHTRANGSACHBYMAPM @Ma", new object[] { maPM });
            Assert.AreEqual(data.Rows.Count, PhieuMuonDAL.Instance.LoadAllTinhTrangSachByMaPM(maPM).Count);
        }
    }
}
