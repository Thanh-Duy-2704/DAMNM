using DoAnTH.CQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTH.CXL
{
    internal class CXuLyCTPK : CXuly<CChiTietPhieuKham>
    {
        private List<CChiTietPhieuKham> dsCTPK;
        public CXuLyCTPK(CPhieuKham pk)
        {
            dsCTPK = pk.ChiTietPhieuKham;
        }
        public List<CChiTietPhieuKham> getALL()
        {
            return dsCTPK;
        }

        public CChiTietPhieuKham getMa(string Ma)
        {
            for (int i = 0; i < dsCTPK.Count; i++)
            {
                if (dsCTPK[i].Thuoc.MaThuoc == Ma)
                
                    return dsCTPK[i];
                
            }
            return null;
        }

        public List<CChiTietPhieuKham> getLike(string Ma)
        {
            throw new NotImplementedException();
        }

        public Boolean sua(CChiTietPhieuKham obj)
        {
            throw new NotImplementedException();
        }

        public Boolean them(CChiTietPhieuKham obj)
        {
            if (getMa(obj.Thuoc.MaThuoc) == null)
            {
                dsCTPK.Add(obj);
                return true;
            }
            else
            {
                MessageBox.Show(" Mã tồn tại!");
                return false;
            }
        }

        public Boolean xoa(CChiTietPhieuKham obj)
        {
            if (obj != null)
            {
                dsCTPK.Remove(obj);
                return true;
            }
            return false;
        }
    }
}
