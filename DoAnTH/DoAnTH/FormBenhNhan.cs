using DoAnTH.CXL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnTH
{
    public partial class FormBenhNhan : Form
    {
        readonly CXuLyBN xuly = new CXuLyBN();
        CBenhNhan BN = new CBenhNhan();
        ErrorProvider erp = new ErrorProvider();
        public FormBenhNhan()
        {
            InitializeComponent();
            HienThi();
        }
        private bool IsValidData()
        {
            erp.SetError(txtMaBenhNhan, "");
            erp.SetError(txtHoTen, "");
            erp.SetError(txtDiaChi, "");
            erp.SetError(txtSoDienThoai, "");

            bool problem = false;
            if (string.IsNullOrWhiteSpace(txtMaBenhNhan.Text))
            {
                erp.SetError(txtMaBenhNhan, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                erp.SetError(txtHoTen, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                erp.SetError(txtSoDienThoai, "Không để trống!");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                erp.SetError(txtDiaChi, "Không để trống!");
                problem = true;
            }
            return !problem;
        }
        private CBenhNhan getBN()
        {
            CBenhNhan bn = new CBenhNhan();
            bn.MaBenhNhan = txtMaBenhNhan.Text;
            bn.TenBenhNhan = txtHoTen.Text;
            bn.NgaySinh = dtpNgaySinh.Value;
            if (rdbNam.Checked == true)
            {
                bn.GioiTinh = "Nam";
            }
            else
            {
                bn.GioiTinh = "Nữ";
            }
            bn.SoDienThoai = txtSoDienThoai.Text;
            bn.DiaChi = txtDiaChi.Text;
            return bn;
        }
        void clear()
        {
            txtMaBenhNhan.Text = " ";
            txtHoTen.Text = " ";
            dtpNgaySinh.Value = DateTime.Now;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            txtSoDienThoai.Text = " ";
            txtDiaChi.Text = " ";
        }
        private void HienThi()
        {
            dgvBenhNhan.DataSource = xuly.getALL().ToList();
            clear();
            dgvBenhNhan.ClearSelection();
        }
        private void txtMaBenhNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormBenhNhan_Load(object sender, EventArgs e)
        {
            rdbNam.Checked = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CBenhNhan bn = getBN();
                xuly.them(bn);
                HienThi();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CBenhNhan newbn = getBN();
                if (!xuly.sua(newbn))
                {
                    MessageBox.Show("Sửa thất bại!");
                }
                HienThi();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (!xuly.xoa(BN))
            {
                MessageBox.Show("Xóa thất bại!");
            }
            HienThi();
        }

        private void dgvBenhNhan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                BN = (CBenhNhan)dgvBenhNhan.Rows[e.RowIndex].DataBoundItem;
                txtMaBenhNhan.Text = BN.MaBenhNhan.ToString();
                txtHoTen.Text = BN.TenBenhNhan.ToString();
                dtpNgaySinh.Value = BN.NgaySinh.ToUniversalTime();
                if (BN.GioiTinh == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }
                txtSoDienThoai.Text = BN.SoDienThoai.ToString();
                txtDiaChi.Text = BN.DiaChi.ToString();
            }
        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTim.Text))
            {
                string Ma = txtTim.Text;
                List<CBenhNhan> bn = xuly.getLike(Ma);
                BindingSource bs = new BindingSource();
                bs.DataSource = bn;
                dgvBenhNhan.DataSource = bs;
            }
            else
            {
                HienThi();
            }
        }
    }
}
