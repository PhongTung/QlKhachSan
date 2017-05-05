using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNhanSu.Controller;
using QLNhanSu.Model;

namespace QLNhanSu
{
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
        }
        ChucVuCtl cvctl = new ChucVuCtl();
        ChucVuObj cvobj = new ChucVuObj();
        int flag = 0;
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            dgvChucVu.DataSource = cvctl.GetData();
            dgvChucVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dis_en(false);
            LoadData();
        }
        public void dis_en(bool e)
        {
            txtMaCV.Enabled = e;
            txtTenCV.Enabled = e;
            btnHuy.Enabled = e;
            btnLuu.Enabled = e;
            btnThem.Enabled = !e;
            btnSua.Enabled = !e;
            btnXoa.Enabled = !e;
        }
        public void LoadData()
        {
            try
            {
                txtMaCV.Text = dgvChucVu.CurrentRow.Cells[0].Value.ToString();
                txtTenCV.Text = dgvChucVu.CurrentRow.Cells[1].Value.ToString();
            }
            catch { }

        }
        private void clean()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
        }

        private void GanDuLieu(ChucVuObj cv1obj)
        {
            cv1obj.MaCV = txtMaCV.Text.ToString().Trim();
            cv1obj.TenCV = txtTenCV.Text.ToString().Trim();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            clean();
            dis_en(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }

        private void dgvChucVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                try
                {
                    txtMaCV.Text = dgvChucVu.CurrentRow.Cells[0].Value.ToString();
                    txtTenCV.Text = dgvChucVu.CurrentRow.Cells[1].Value.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có thật sự muốn xóa ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            {
                if (dr == DialogResult.Yes)
                {
                    if (cvctl.DelChucVu(txtMaCV.Text.Trim()))
                    {
                        MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmChucVu_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóakhông thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            GanDuLieu(cvobj);
            if (flag == 0)   // thêm
            {
                if (cvctl.AddChucVu(cvobj))
                {
                    MessageBox.Show("Thêm thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChucVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else            // sửa
            {
                if (cvctl.UpdateChucVu(cvobj))
                {
                    MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmChucVu_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Sửa không thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmChucVu_Load(sender, e);
            dis_en(false);
        }
    }
}
