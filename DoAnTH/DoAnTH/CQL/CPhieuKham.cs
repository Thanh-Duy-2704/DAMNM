using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnTH.CQL
{
    [Serializable]
    internal class CPhieuKham
    {
        private string m_maphieukham;
        private CBacSi m_bacsi;
        private CBenhNhan m_benhnhan;
        private DateTime m_ngaykham;
        private string m_chuandoan;
        private List<CChiTietPhieuKham> m_chitietphieukham;

        public CPhieuKham(string maPhieuKham, CBacSi bacSi, CBenhNhan benhNhan, DateTime ngaykham, string chuanDoan, List<CChiTietPhieuKham> chiTietPhieuKham)
        {
            MaPhieuKham = maPhieuKham;
            BacSi = bacSi;
            BenhNhan = benhNhan;
            Ngaykham = ngaykham;
            ChuanDoan = chuanDoan;
            ChiTietPhieuKham = chiTietPhieuKham;
        }
        public CPhieuKham()
        {
            MaPhieuKham = "";
            BacSi = new CBacSi();
            BenhNhan = new CBenhNhan();
            ChuanDoan = "";
            Ngaykham = DateTime.Now;
            ChiTietPhieuKham = new List<CChiTietPhieuKham>();
        }
        public string MaPhieuKham { get => m_maphieukham; set => m_maphieukham = value; }
        public CBacSi BacSi { get => m_bacsi; set => m_bacsi = value; }
        public CBenhNhan BenhNhan { get => m_benhnhan; set => m_benhnhan = value; }
        public DateTime Ngaykham { get => m_ngaykham; set => m_ngaykham = value; }
        public string ChuanDoan { get => m_chuandoan; set => m_chuandoan = value; }
        public List<CChiTietPhieuKham> ChiTietPhieuKham { get => m_chitietphieukham; set => m_chitietphieukham = value; }
    }
}
