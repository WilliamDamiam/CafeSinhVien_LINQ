using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyCaPheSinhVien_BUS;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCafeSinhVien
{
    public partial class FormQuanLyCaPheSinhVien : Form
    {
        // Các lớp xử lý nghiệp vụ
        private ThucDonBUS thucDonBUS = new ThucDonBUS();
        private TinhTienBUS tinhTienBUS = new TinhTienBUS();
        private HoaDonBUS hoaDonBUS = new HoaDonBUS();

        // Thông tin thanh toán
        private decimal tienTamTinh = 0;
        private int soKhachTamTinh = 0;
        private int tongSoKhach = 0;
        private decimal tongTienThanhToan = 0;

        private List<ChiTietHoaDonDTO> danhSachDaTinh = new List<ChiTietHoaDonDTO>();

        public FormQuanLyCaPheSinhVien()
        {
            InitializeComponent();

            // Đăng ký các sự kiện trên Form
            this.Load -= Form1_Load;
            this.Load += Form1_Load;

            btnTinhTien.Click -= btnTinhTien_Click;
            btnTinhTien.Click += btnTinhTien_Click;

            btnThanhToan.Click -= btnThanhToan_Click;
            btnThanhToan.Click += btnThanhToan_Click;

            btnNhapLai.Click -= btnNhapLai_Click;
            btnNhapLai.Click += btnNhapLai_Click;

            btnThoat.Click -= btnThoat_Click;
            btnThoat.Click += btnThoat_Click;

            txtSoKhachHang.KeyPress -= txtSoKhachHang_KeyPress;
            txtSoKhachHang.KeyPress += txtSoKhachHang_KeyPress;

            txtTenKhachHang.TextChanged -= KiemTraThongTin;
            txtTenKhachHang.TextChanged += KiemTraThongTin;

            txtSoKhachHang.TextChanged -= KiemTraThongTin;
            txtSoKhachHang.TextChanged += KiemTraThongTin;

            radCafeDen.CheckedChanged -= KiemTraThongTin;
            radCafeDen.CheckedChanged += KiemTraThongTin;
            radCafeDa.CheckedChanged -= KiemTraThongTin;
            radCafeDa.CheckedChanged += KiemTraThongTin;
            radCafeSua.CheckedChanged -= KiemTraThongTin;
            radCafeSua.CheckedChanged += KiemTraThongTin;
            radCafeSuaDa.CheckedChanged -= KiemTraThongTin;
            radCafeSuaDa.CheckedChanged += KiemTraThongTin;
            radCafeKem.CheckedChanged -= KiemTraThongTin;
            radCafeKem.CheckedChanged += KiemTraThongTin;

            chkBanhMyTrung.CheckedChanged -= KiemTraThongTin;
            chkBanhMyTrung.CheckedChanged += KiemTraThongTin;
            chkBanhMyCa.CheckedChanged -= KiemTraThongTin;
            chkBanhMyCa.CheckedChanged += KiemTraThongTin;
            chkMyTomTrung.CheckedChanged -= KiemTraThongTin;
            chkMyTomTrung.CheckedChanged += KiemTraThongTin;
            chkMyXaoBo.CheckedChanged -= KiemTraThongTin;
            chkMyXaoBo.CheckedChanged += KiemTraThongTin;
            chkMyCay.CheckedChanged -= KiemTraThongTin;
            chkMyCay.CheckedChanged += KiemTraThongTin;
            chkSinhVien.CheckedChanged -= KiemTraThongTin;
            chkSinhVien.CheckedChanged += KiemTraThongTin;
        }

        // Thiết lập trạng thái ban đầu
        private void Form1_Load(object sender, EventArgs e)
        {
            btnTinhTien.Enabled = false;
            btnThanhToan.Enabled = false;
            btnNhapLai.Enabled = false;

            lblSoKhachDaThanhToan.Text = "0";
            lblTienDaThanhToan.Text = "0 VNĐ";

            txtTenKhachHang.Focus();
        }

        // Chỉ cho nhập số khách bằng chữ số
        private void txtSoKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Kiểm tra thông tin khi người dùng thay đổi lựa chọn
        private void KiemTraThongTin(object sender, EventArgs e)
        {
            tienTamTinh = 0;
            soKhachTamTinh = 0;
            danhSachDaTinh.Clear();

            btnThanhToan.Enabled = false;
            btnTinhTien.Enabled = false;

            int soKhach;

            if (txtTenKhachHang.Text.Trim() == "") return;
            if (!int.TryParse(txtSoKhachHang.Text, out soKhach)) return;
            if (soKhach <= 0) return;

            if (radCafeDen.Checked || radCafeDa.Checked || radCafeSua.Checked || radCafeSuaDa.Checked || radCafeKem.Checked)
            {
                btnTinhTien.Enabled = true;
            }
        }

        // Lấy các món khách đã chọn
        private List<ChiTietHoaDonDTO> LayDanhSachMon(int soKhach)
        {
            List<string> tenMon = new List<string>();

            // Chọn loại cà phê
            if (radCafeDen.Checked) tenMon.Add("Cafe đen");
            else if (radCafeDa.Checked) tenMon.Add("Cafe đá");
            else if (radCafeSua.Checked) tenMon.Add("Cafe sữa");
            else if (radCafeSuaDa.Checked) tenMon.Add("Cafe sữa đá");
            else if (radCafeKem.Checked) tenMon.Add("Cafe kem");

            // Chọn thức ăn
            if (chkBanhMyTrung.Checked) tenMon.Add("Bánh mỳ trứng");
            if (chkBanhMyCa.Checked) tenMon.Add("Bánh mỳ cá");
            if (chkMyTomTrung.Checked) tenMon.Add("Mỳ tôm trứng");
            if (chkMyXaoBo.Checked) tenMon.Add("Mỳ xào bò");
            if (chkMyCay.Checked) tenMon.Add("Mỳ cay");

            // Lấy thực đơn từ cơ sở dữ liệu
            List<ThucDonDTO> thucDon = thucDonBUS.LayDanhSachThucDon();
            List<ChiTietHoaDonDTO> danhSach = new List<ChiTietHoaDonDTO>();

            foreach (string ten in tenMon)
            {
                ThucDonDTO monTimThay = null;

                // Tìm món theo tên
                foreach (ThucDonDTO mon in thucDon)
                {
                    if (mon.TenMon == ten)
                    {
                        monTimThay = mon;
                        break;
                    }
                }

                if (monTimThay == null)
                {
                    throw new Exception("Không tìm thấy món: " + ten);
                }

                // Lưu thông tin món đã chọn
                ChiTietHoaDonDTO ct = new ChiTietHoaDonDTO();
                ct.MaMon = monTimThay.MaMon;
                ct.DonGia = monTimThay.DonGia;

                if (monTimThay.LoaiMon == "Cà phê")
                {
                    ct.SoLuong = soKhach;
                }
                else
                {
                    ct.SoLuong = 1;
                }

                danhSach.Add(ct);
            }

            return danhSach;
        }

        // Tính tiền các món đã chọn
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            int soKhach;

            if (txtTenKhachHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng!");
                return;
            }

            if (!int.TryParse(txtSoKhachHang.Text, out soKhach) || soKhach <= 0)
            {
                MessageBox.Show("Số khách phải lớn hơn 0!");
                return;
            }

            try
            {
                // Lấy món và tính tổng tiền
                danhSachDaTinh = LayDanhSachMon(soKhach);

                decimal tongTien = tinhTienBUS.TinhTongTien(danhSachDaTinh);
                tienTamTinh = tinhTienBUS.TinhTienThanhToan(tongTien, chkSinhVien.Checked);

                if (tienTamTinh <= 0)
                {
                    MessageBox.Show("Không có món để tính tiền!");
                    return;
                }

                soKhachTamTinh = soKhach;

                MessageBox.Show("Tên khách hàng: " + txtTenKhachHang.Text.Trim()
                    + "\nSố khách: " + soKhach
                    + "\nTổng tiền: " + tienTamTinh.ToString("N0") + " VNĐ",
                    "KẾT QUẢ TÍNH TIỀN");

                btnThanhToan.Enabled = true;
                btnNhapLai.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tiền: " + ex.Message);
            }
        }

        // Lưu thông tin thanh toán vào SQL Server
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (soKhachTamTinh <= 0 || danhSachDaTinh.Count == 0)
            {
                MessageBox.Show("Vui lòng tính tiền trước!");
                return;
            }

            // Tạo thông tin hóa đơn
            HoaDonDTO hd = new HoaDonDTO();
            hd.TenKhachHang = txtTenKhachHang.Text.Trim();
            hd.SoKhach = soKhachTamTinh;
            hd.LaSinhVien = chkSinhVien.Checked;
            hd.TongTien = tienTamTinh;

            try
            {
                // Gọi BUS để lưu hóa đơn và chi tiết
                bool ketQua = hoaDonBUS.LuuHoaDon(hd, danhSachDaTinh);

                if (ketQua == true)
                {
                    tongSoKhach += soKhachTamTinh;
                    tongTienThanhToan += tienTamTinh;

                    lblSoKhachDaThanhToan.Text = tongSoKhach.ToString();
                    lblTienDaThanhToan.Text = tongTienThanhToan.ToString("N0") + " VNĐ";

                    MessageBox.Show("Thanh toán thành công!");

                    btnNhapLai_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Thông tin hóa đơn không hợp lệ!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thanh toán thất bại: " + ex.Message);
            }
        }

        // Xóa dữ liệu để nhập khách hàng mới
        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            txtTenKhachHang.Clear();
            txtSoKhachHang.Clear();

            radCafeDen.Checked = false;
            radCafeDa.Checked = false;
            radCafeSua.Checked = false;
            radCafeSuaDa.Checked = false;
            radCafeKem.Checked = false;

            chkBanhMyTrung.Checked = false;
            chkBanhMyCa.Checked = false;
            chkMyTomTrung.Checked = false;
            chkMyXaoBo.Checked = false;
            chkMyCay.Checked = false;
            chkSinhVien.Checked = false;

            tienTamTinh = 0;
            soKhachTamTinh = 0;
            danhSachDaTinh.Clear();

            btnTinhTien.Enabled = false;
            btnThanhToan.Enabled = false;
            btnNhapLai.Enabled = false;

            txtTenKhachHang.Focus();
        }

        // Xác nhận trước khi thoát
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (traLoi == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Các sự kiện có thể đang được Designer sử dụng
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
    }
}