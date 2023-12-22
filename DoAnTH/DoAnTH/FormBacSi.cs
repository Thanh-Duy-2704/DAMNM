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
    public partial class FormBacSi : Form
    {
        readonly CXuLyBS xuly = new CXuLyBS();
        CBacSi BS = new CBacSi();
        ErrorProvider erp = new ErrorProvider();
        public FormBacSi()
        {
            InitializeComponent();
            HienThi();
        }
        void clear()
        {
            txtHoTen.Text = "";
            txtMaBacSi.Text = "";
            txtSDT.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
        }
        private void HienThi()
        {
            dgvBacSi.DataSource = xuly.getALL().ToList();
            clear();
            dgvBacSi.ClearSelection();
        }
        private bool IsValidData()
        {
            erp.SetError(txtMaBacSi, "");
            erp.SetError(txtHoTen, "");
            erp.SetError(txtSDT, "");
            bool problem = false;
            if (string.IsNullOrWhiteSpace(txtMaBacSi.Text))
            {
                erp.SetError(txtMaBacSi, "Không để trống !");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                erp.SetError(txtHoTen, "Không để trống !");
                problem = true;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                erp.SetError(txtSDT, "Không để trống !");
                problem = true;
            }
            return !problem;
        }
        private CBacSi getBS()
        {
            CBacSi bs = new CBacSi();
            bs.MaBacSi = txtMaBacSi.Text;
            bs.TenBacSi = txtHoTen.Text;
            bs.NgaySinh = dtpNgaySinh.Value;
            bs.SDT = txtSDT.Text;
            return bs;
        }

        private void FormBacSi_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CBacSi bs = getBS();
                xuly.them(bs);
                HienThi();
            }
        }

        private void dgvBacSi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                BS = (CBacSi)dgvBacSi.Rows[e.RowIndex].DataBoundItem;
                txtMaBacSi.Text = BS.MaBacSi.ToString();
                txtHoTen.Text = BS.TenBacSi.ToString();
                dtpNgaySinh.Value = BS.NgaySinh.ToUniversalTime();
                txtSDT.Text = BS.SDT.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                CBacSi newbs = getBS();
                if (!xuly.sua(newbs))
                {
                    MessageBox.Show("Sửa thất bại!");
                }
                HienThi();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (BS == null)
            {
                MessageBox.Show("Chọn thông tin cần xóa ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!xuly.xoa(BS))
            {
                MessageBox.Show("Xóa thất bại!");
            }
            HienThi();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtTim_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTim.Text))
            {
                string Ma = txtTim.Text;
                List<CBacSi> bacsi = xuly.getLike(Ma);
                BindingSource bs = new BindingSource();
                bs.DataSource = bacsi;
                dgvBacSi.DataSource = bs;
            }
            else
            {
                HienThi();
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
