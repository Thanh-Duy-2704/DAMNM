using DoAnTH.CQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTH.CXL
{
    [Serializable]
    internal class CXuLyPK : CXuly<CPhieuKham>
    {
        private List<CPhieuKham> dsPk;
        public CXuLyPK()
        {
            dsPk = CTruyCapDuLieu.khoiTao().DSPK;
        }
        public List<CPhieuKham> getALL()
        {
            return dsPk;
        }
        public CXuLyPK(CXuLyPK PK)
        {
            this.dsPk = PK.dsPk.ToList();
        }

        public CXuLyPK(List<CPhieuKham> dspk)
        {
            this.dsPk = dspk;
        }

        public CPhieuKham getMa(string Ma)
        {
            for (int i = 0; i < dsPk.Count; i++)
            {
                if (dsPk[i].MaPhieuKham == Ma)
                    return dsPk[i];
            }
            return null;
        }

        public List<CPhieuKham> getLike(string Ma)
        {
            List<CPhieuKham> pk = new List<CPhieuKham>();
            for (int i = 0; i < dsPk.Count; i++)
            {
                if (dsPk[i].MaPhieuKham.Contains(Ma))
                    pk.Add(dsPk[i]);
            }
            return pk;
        }

        public Boolean them(CPhieuKham obj)
        {
            if (getMa(obj.MaPhieuKham) == null)
            {
                dsPk.Add(obj);
                return true;
            }
            else
            {
                MessageBox.Show(" Mã tồn tại! ");
                return false;
            }
        }

        public Boolean xoa(CPhieuKham obj)
        {
            if (obj != null)
            {
                dsPk.Remove(obj);
                return true;
            }
            return false;
        }
        public Boolean sua(CPhieuKham obj)
        {
            CPhieuKham _obj = getMa(obj.MaPhieuKham);
            if (_obj != null)
            {
                _obj.BacSi = obj.BacSi;
                _obj.BenhNhan = obj.BenhNhan;
                _obj.Ngaykham = obj.Ngaykham;
                _obj.ChuanDoan = obj.ChuanDoan;
                _obj.ChiTietPhieuKham = obj.ChiTietPhieuKham;
                return true;
            }
            return false;
        }
    }
}
