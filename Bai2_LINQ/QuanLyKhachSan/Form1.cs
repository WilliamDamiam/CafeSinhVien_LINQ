using System;
using System.Windows.Forms;
using KhachSanThanhThanh_BUS;
using KhachSanThanhThanh_DTO;

namespace QuanLyKhachSan
{
    public partial class Form1 : Form
    {
        private KhachSanBUS bus = new KhachSanBUS();

        // Theo dõi trạng thái thanh toán
        private bool daThanhToan = false;
        private bool coThanhToanMoi = false;

        public Form1()
        {
            InitializeComponent();

            // Đăng ký các sự kiện
            this.Load -= Form1_Load;
            this.Load += Form1_Load;

            btnThanhToan.Click -= btnThanhToan_Click;
            btnThanhToan.Click += btnThanhToan_Click;

            btnNhapMoi.Click -= btnNhapMoi_Click;
            btnNhapMoi.Click += btnNhapMoi_Click;

            btnTongKet.Click -= btnTongKet_Click;
            btnTongKet.Click += btnTongKet_Click;

            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;

            txtSoNgayO.KeyPress -= txtSoNgayO_KeyPress;
            txtSoNgayO.KeyPress += txtSoNgayO_KeyPress;

            txtHoTen.TextChanged -= KiemTraThongTin;
            txtHoTen.TextChanged += KiemTraThongTin;

            txtDiaChi.TextChanged -= KiemTraThongTin;
            txtDiaChi.TextChanged += KiemTraThongTin;

            txtSoNgayO.TextChanged -= KiemTraThongTin;
            txtSoNgayO.TextChanged += KiemTraThongTin;

            radPhongDon.CheckedChanged -= KiemTraThongTin;
            radPhongDon.CheckedChanged += KiemTraThongTin;

            radPhongDoi.CheckedChanged -= KiemTraThongTin;
            radPhongDoi.CheckedChanged += KiemTraThongTin;

            radPhongBa.CheckedChanged -= KiemTraThongTin;
            radPhongBa.CheckedChanged += KiemTraThongTin;
        }

        // Thiết lập trạng thái ban đầu
        private void Form1_Load(object sender, EventArgs e)
        {
            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = false;

            lblSoTienThanhToan.Text = "0 VNĐ";
            lblGiaTriSoLuotNguoi.Text = "0";
            lblGiaTriTongSoTien.Text = "0 VNĐ";
        }

        // Chỉ cho nhập số ngày ở
        private void txtSoNgayO_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra thông tin trước khi thanh toán
        private void KiemTraThongTin(object sender, EventArgs e)
        {
            int soNgay;

            bool hopLe = txtHoTen.Text.Trim() != ""
                && txtDiaChi.Text.Trim() != ""
                && int.TryParse(txtSoNgayO.Text, out soNgay)
                && soNgay > 0
                && (radPhongDon.Checked || radPhongDoi.Checked || radPhongBa.Checked);

            btnThanhToan.Enabled = hopLe && !daThanhToan;
        }

        // Thanh toán tiền phòng
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (daThanhToan)
            {
                MessageBox.Show("Khách này đã thanh toán!");
                return;
            }

            // Kiểm tra thông tin khách hàng
            if (txtHoTen.Text.Trim() == "" || txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập họ tên và địa chỉ!");
                return;
            }

            if (txtHoTen.Text.Trim().Length > 100 || txtDiaChi.Text.Trim().Length > 200)
            {
                MessageBox.Show("Họ tên hoặc địa chỉ quá dài!");
                return;
            }

            int soNgay;

            if (!int.TryParse(txtSoNgayO.Text, out soNgay) || soNgay <= 0)
            {
                MessageBox.Show("Số ngày ở phải lớn hơn 0!");
                return;
            }

            // Xác định loại phòng
            string maPhong = "";

            if (radPhongDon.Checked) maPhong = "P_DON";
            else if (radPhongDoi.Checked) maPhong = "P_DOI";
            else if (radPhongBa.Checked) maPhong = "P_BA";

            if (maPhong == "")
            {
                MessageBox.Show("Vui lòng chọn loại phòng!");
                return;
            }

            // Lấy thông tin từ giao diện
            HoaDonDTO hd = new HoaDonDTO();

            hd.HoTen = txtHoTen.Text.Trim();
            hd.DiaChi = txtDiaChi.Text.Trim();
            hd.SoNgayO = soNgay;
            hd.MaLoaiPhong = maPhong;

            hd.CoTivi = chkTivi.Checked;
            hd.CoInternet = chkInternet.Checked;
            hd.CoMayNuocNong = chkMayNuocNong.Checked;
            hd.CoKaraoke = chkKaraoke.Checked;
            hd.CoAnSang = chkAnSang.Checked;

            try
            {
                // Gọi BUS để tính tiền và lưu hóa đơn
                int maThanhToan = bus.LuuThanhToan(hd);

                if (maThanhToan <= 0)
                {
                    MessageBox.Show("Thông tin thanh toán không hợp lệ!");
                    return;
                }

                // Hiển thị kết quả thanh toán
                lblSoTienThanhToan.Text = hd.ThanhTien.ToString("N0") + " VNĐ";

                daThanhToan = true;
                coThanhToanMoi = true;

                btnThanhToan.Enabled = false;
                btnNhapMoi.Enabled = true;
                btnTongKet.Enabled = true;

                MessageBox.Show("Thanh toán thành công!\nMã thanh toán: " + maThanhToan + "\nThành tiền: " + hd.ThanhTien.ToString("N0") + " VNĐ");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thanh toán: " + ex.Message);
            }
        }

        // Xóa thông tin để nhập khách mới
        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtDiaChi.Clear();
            txtSoNgayO.Clear();

            radPhongDon.Checked = false;
            radPhongDoi.Checked = false;
            radPhongBa.Checked = false;

            chkTivi.Checked = false;
            chkInternet.Checked = false;
            chkMayNuocNong.Checked = false;
            chkKaraoke.Checked = false;
            chkAnSang.Checked = false;

            lblSoTienThanhToan.Text = "0 VNĐ";

            daThanhToan = false;

            btnThanhToan.Enabled = false;
            btnNhapMoi.Enabled = false;
            btnTongKet.Enabled = coThanhToanMoi;

            txtHoTen.Focus();
        }

        // Tổng kết các hóa đơn mới
        private void btnTongKet_Click(object sender, EventArgs e)
        {
            if (!coThanhToanMoi)
            {
                MessageBox.Show("Chưa có thanh toán mới!");
                return;
            }

            try
            {
                // Lấy số lượt và tổng tiền từ BUS
                TongKetDTO ketQua = bus.TongKet();

                lblGiaTriSoLuotNguoi.Text = ketQua.TongLuot.ToString();
                lblGiaTriTongSoTien.Text = ketQua.TongTien.ToString("N0") + " VNĐ";

                coThanhToanMoi = false;
                btnTongKet.Enabled = false;

                MessageBox.Show("Tổng kết thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tổng kết: " + ex.Message);
            }
        }

        // Thoát chương trình
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traLoi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Các sự kiện đang liên kết với Designer
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblSoTienThanhToan_Click(object sender, EventArgs e)
        {

        }

        private void txtSoNgayO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
