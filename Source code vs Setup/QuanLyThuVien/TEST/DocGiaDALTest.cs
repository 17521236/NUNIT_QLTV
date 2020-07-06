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
    class DocGiaDALTest
    {
        [Test]
        public void LoadBooksTest()
        {
            DocGiaDAL _instance = DocGiaDAL.Instance;
            DatabaseAcess.Instance.OpenConnection();
            DataTable data = DatabaseAcess.Instance.ExcuteQuery("USP_LOADDOCGIA");
            Assert.AreEqual(data.Rows.Count, _instance.LoadDocGia().Count);
        }

        [Test]
        [TestCase("DG001", "08 / 01 / 2019")]
        public void GetNgayHetHanByMaDocGiaTest(string ma, DateTime ngayhethan)
        {
            DateTime x = Convert.ToDateTime(ngayhethan);
            Assert.AreEqual(x, DocGiaDAL.Instance.GetNgayHetHanByMaDocGia(ma));
        }

        [Test]
        [TestCase("DG002", "1123")]
        [TestCase("DG002", "-1123")]
        public void UpdateTongNoTest(string maDG, string tien)
        {
            double NoHienTai = DocGiaDAL.Instance.GetTongNo(maDG);
            DocGiaDAL.Instance.UpdateTongNo(maDG, Convert.ToDouble(tien));
            Assert.AreEqual(NoHienTai + Convert.ToDouble(tien), DocGiaDAL.Instance.GetTongNo(maDG));
        }

        [Test]
        [TestCase("DG004", "5555")]
        public void GetTongNoTest(string maDG, string no)
        {
            Assert.AreEqual(Convert.ToDouble(no), DocGiaDAL.Instance.GetTongNo(maDG));
        }


        [Test]
        [TestCase("DG0", "Name1", "LDG001", "2/2/1999", "B", "C", "2/2/2019", "8/2/1999", "True", "1000", true)]
        [TestCase("DG0", "Name1", "LDG001", "2/2/1999", "B", "C", "2/2/2019", "8/2/1999", "True", "1000", false)]

        public void SaveDocGiaTest(string Ma, string Ten, string LDG, string NS, string DiaChi, string Email, string NLT, string NHH, string TTT, string TN, bool result)
        {
            bool res = false;
            try
            {
                res = DocGiaDAL.Instance.SaveDocGia(Ma, Ten, LDG, NS, DiaChi, Email, NLT, NHH, TTT, TN);
            }
            catch (Exception e) { }
            Assert.AreEqual(result, res);
        }

        [Test]
        [TestCase("DG0", "Name2", "LDG001", "2/2/1999", "B", "C", "2/2/2019", "8/2/1999", "True", "1000")]

        public void UpdateDocGiaTest(string Ma, string Ten, string LDG, string NS, string DiaChi, string Email, string NLT, string NHH, string TTT, string TN)
        {
            Assert.AreEqual(true, DocGiaDAL.Instance.UpdateDocGia(Ma,Ten,LDG,NS,DiaChi,Email,NLT,NHH,TTT,TN));
        }

        [Test]
        [TestCase("DG0")]
        public void DeleteDocGiaTest(string Ma)
        {
            Assert.AreEqual(true, DocGiaDAL.Instance.DeleteDocGia(Ma));
        }
    }
}
