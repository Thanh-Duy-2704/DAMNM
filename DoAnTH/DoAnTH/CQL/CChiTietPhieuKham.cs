using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace DoAnTH.CQL
{
    [Serializable]
    internal class CChiTietPhieuKham
    {
        private CThuoc m_thuoc;
        private string m_soluong;
        public CChiTietPhieuKham() { }

        public CChiTietPhieuKham(CThuoc thuoc, string soluong)
        {
            Thuoc = thuoc;
            SoLuong = soluong;
        }

        public CThuoc Thuoc { get => m_thuoc; set => m_thuoc = value; }

        public string MaThuoc { get => m_thuoc.MaThuoc; }
        public string TenThuoc { get => m_thuoc.TenThuoc; }
        public string TacDung { get => m_thuoc.TacDung; }
        public string LieuDung { get => m_thuoc.LieuDung; }
        public string CachDung { get => m_thuoc.CachDung; }
        public string SoLuong { get => m_soluong; set => m_soluong = value; }
    }
}
