using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class frmQLTK : Form
    {
        public frmQLTK()
        {
            InitializeComponent();
        }

        private void frmQLTK_Load(object sender, EventArgs e)
        {
            lsvKhachHang.View = View.Details;

            lsvKhachHang.Columns.Add("Mã khách hàng", 125);
            lsvKhachHang.Columns.Add("Tên khách hàng", 130);
            lsvKhachHang.Columns.Add("Địa chỉ", 200);
            lsvKhachHang.Columns.Add("Số tiền", 130);

            txtTongTien.Text = "0";
        }

        private void Clear()
        {
            txtSoTK.Clear();
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoTien.Clear();
        }

        private void Sum()
        {
            double tt = 0;
            for (int i = 0; i < lsvKhachHang.Items.Count; i++)
            {
                if (lsvKhachHang.Items[i].SubItems[0].Text != null)
                {
                    tt += double.Parse(lsvKhachHang.Items[i].SubItems[3].Text);
                }
            }
            txtTongTien.Text = tt.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSoTK.Text == "" || txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSoTien.Text == "")
                    throw new Exception("Vui lòng nhập đủ thông tin!");
                if (lsvKhachHang.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = lsvKhachHang.SelectedItems[0];
                    lvi.SubItems[0].Text = txtSoTK.Text.Trim();
                    lvi.SubItems[1].Text = txtHoTen.Text.Trim();
                    lvi.SubItems[2].Text = txtDiaChi.Text.Trim();
                    lvi.SubItems[3].Text = txtSoTien.Text.Trim();
                    Sum();

                    MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK);
                    Clear();
                }
                else
                {
                    ListViewItem lvi = new ListViewItem(txtSoTK.Text.Trim());
                    lvi.SubItems.Add(txtHoTen.Text.Trim());
                    lvi.SubItems.Add(txtDiaChi.Text.Trim());
                    lvi.SubItems.Add(txtSoTien.Text.Trim());
                    lsvKhachHang.Items.Add(lvi);
                    Sum();
                    Clear();

                    MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void lsvKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvKhachHang.SelectedItems.Count>0)
            {
                ListViewItem lvi = lsvKhachHang.SelectedItems[0];

                txtSoTK.Text = lvi.SubItems[0].Text;
                txtHoTen.Text = lvi.SubItems[1].Text;
                txtDiaChi.Text = lvi.SubItems[2].Text;
                txtSoTien.Text = lvi.SubItems[3].Text;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvKhachHang.SelectedItems.Count > 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có muốn xóa thông tin này không?", "Warning!", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        lsvKhachHang.Items.RemoveAt(lsvKhachHang.SelectedItems[0].Index);
                        Sum();
                        MessageBox.Show("Xóa tài khoản thành công", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    throw new Exception("Không tìm thấy số tài khoản cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình không ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
