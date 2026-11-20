using System;
using System.IO;
using System.Windows.Forms;
using QuanLyHangHoa.BUS;
using QuanLyHangHoa.DTO;

namespace QuanLyHangHoa
{
    public partial class Form1 : Form
    {
        private HangHoaBUS bus = new HangHoaBUS();

        // Chế độ hiện tại: Thêm, Sửa hoặc bình thường
        private string cheDo = "";

        public Form1()
        {
            InitializeComponent();

            // Liên kết các sự kiện trên Form
            this.Load -= Form1_Load;
            this.Load += Form1_Load;

            dgvHangHoa.CellClick -= dgvHangHoa_CellClick;
            dgvHangHoa.CellClick += dgvHangHoa_CellClick;

            btnThem.Click -= btnThem_Click;
            btnThem.Click += btnThem_Click;

            btnSua.Click -= btnSua_Click;
            btnSua.Click += btnSua_Click;

            btnLuu.Click -= btnLuu_Click;
            btnLuu.Click += btnLuu_Click;

            btnXoa.Click -= btnXoa_Click;
            btnXoa.Click += btnXoa_Click;

            btnTimKiem.Click -= btnTimKiem_Click;
            btnTimKiem.Click += btnTimKiem_Click;

            btnMoAnh.Click -= btnMoAnh_Click;
            btnMoAnh.Click += btnMoAnh_Click;

            btnBoQua.Click -= btnBoQua_Click;
            btnBoQua.Click -= btnBoQua_Click_1;
            btnBoQua.Click += btnBoQua_Click;
        }

        // Hiển thị dữ liệu khi mở Form
        private void Form1_Load(object sender, EventArgs e)
        {
            TaiChatLieu();
            TaiHangHoa();
            XoaThongTin();
            CapNhatNut();

            dgvHangHoa.ReadOnly = true;
            dgvHangHoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHangHoa.AllowUserToAddRows = false;
        }

        // Hiển thị danh sách hàng hóa
        private void TaiHangHoa()
        {
            try
            {
                dgvHangHoa.DataSource = bus.LayHangHoa();
                dgvHangHoa.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải hàng hóa: " + ex.Message);
            }
        }

        // Đưa danh sách chất liệu vào ComboBox
        private void TaiChatLieu()
        {
            try
            {
                cboMaChatLieu.DisplayMember = "TenChatLieu";
                cboMaChatLieu.ValueMember = "MaChatLieu";
                cboMaChatLieu.DataSource = bus.LayChatLieu();
                cboMaChatLieu.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải chất liệu: " + ex.Message);
            }
        }

        // Hiển thị thông tin khi chọn một dòng
        private void dgvHangHoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow dong = dgvHangHoa.Rows[e.RowIndex];

            txtMaHang.Text = Convert.ToString(dong.Cells["MaHang"].Value);
            txtTenHang.Text = Convert.ToString(dong.Cells["TenHang"].Value);
            txtSoLuong.Text = Convert.ToString(dong.Cells["SoLuong"].Value);
            txtDonGiaNhap.Text = Convert.ToString(dong.Cells["DonGiaNhap"].Value);
            txtDonGiaBan.Text = Convert.ToString(dong.Cells["DonGiaBan"].Value);
            txtHinh.Text = Convert.ToString(dong.Cells["Hinh"].Value);
            txtGhiChu.Text = Convert.ToString(dong.Cells["GhiChu"].Value);
            cboMaChatLieu.SelectedValue = Convert.ToString(dong.Cells["MaChatLieu"].Value);

            HienThiAnh();
        }

        // Xóa thông tin đang nhập
        private void XoaThongTin()
        {
            txtMaHang.Clear();
            txtTenHang.Clear();
            txtSoLuong.Clear();
            txtDonGiaNhap.Clear();
            txtDonGiaBan.Clear();
            txtHinh.Clear();
            txtGhiChu.Clear();

            cboMaChatLieu.SelectedIndex = -1;
            picHangHoa.ImageLocation = null;
        }

        // Bật hoặc tắt nút theo chế độ
        private void CapNhatNut()
        {
            bool dangNhap = cheDo != "";

            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnTimKiem.Enabled = !dangNhap;

            btnLuu.Enabled = dangNhap;
            dgvHangHoa.Enabled = !dangNhap;
            txtMaHang.ReadOnly = cheDo == "Sua";
        }

        // Bắt đầu thêm hàng hóa
        private void btnThem_Click(object sender, EventArgs e)
        {
            cheDo = "Them";
            XoaThongTin();
            CapNhatNut();
            txtMaHang.Focus();
        }

        // Bắt đầu sửa hàng hóa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn hàng cần sửa!");
                return;
            }

            cheDo = "Sua";
            CapNhatNut();
            txtTenHang.Focus();
        }

        // Lưu thông tin hàng hóa
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cheDo == "")
            {
                MessageBox.Show("Vui lòng chọn Thêm hoặc Sửa!");
                return;
            }

            // Kiểm tra mã hàng và tên hàng
            if (txtMaHang.Text.Trim() == "" || txtTenHang.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mã hàng và tên hàng!");
                return;
            }

            if (txtMaHang.Text.Trim().Length > 10 || txtTenHang.Text.Trim().Length > 100)
            {
                MessageBox.Show("Mã hàng hoặc tên hàng quá dài!");
                return;
            }

            // Kiểm tra chất liệu
            if (cboMaChatLieu.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn chất liệu!");
                return;
            }

            // Kiểm tra số lượng và đơn giá
            int soLuong;
            decimal giaNhap;
            decimal giaBan;

            if (!int.TryParse(txtSoLuong.Text, out soLuong) || !decimal.TryParse(txtDonGiaNhap.Text, out giaNhap) || !decimal.TryParse(txtDonGiaBan.Text, out giaBan))
            {
                MessageBox.Show("Số lượng và đơn giá phải là số!");
                return;
            }

            if (soLuong < 0 || giaNhap < 0 || giaBan < 0)
            {
                MessageBox.Show("Số lượng và đơn giá không được âm!");
                return;
            }

            if (txtHinh.Text.Length > 255 || txtGhiChu.Text.Length > 500)
            {
                MessageBox.Show("Đường dẫn hình hoặc ghi chú quá dài!");
                return;
            }

            // Lấy thông tin hàng hóa từ Form
            HangHoaDTO h = new HangHoaDTO();

            h.MaHang = txtMaHang.Text.Trim();
            h.TenHang = txtTenHang.Text.Trim();
            h.MaChatLieu = cboMaChatLieu.SelectedValue.ToString();
            h.SoLuong = soLuong;
            h.DonGiaNhap = giaNhap;
            h.DonGiaBan = giaBan;
            h.Hinh = txtHinh.Text.Trim();
            h.GhiChu = txtGhiChu.Text.Trim();

            try
            {
                bool ketQua = false;

                // Gọi BUS để thêm hoặc sửa
                if (cheDo == "Them")
                {
                    ketQua = bus.ThemHangHoa(h);
                }
                else if (cheDo == "Sua")
                {
                    ketQua = bus.SuaHangHoa(h);
                }

                if (ketQua == true)
                {
                    MessageBox.Show("Lưu hàng hóa thành công!");

                    cheDo = "";
                    XoaThongTin();
                    CapNhatNut();
                    TaiHangHoa();
                }
                else
                {
                    MessageBox.Show("Không lưu được hàng hóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu: " + ex.Message);
            }
        }

        // Xóa hàng hóa theo mã
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text.Trim();

            if (maHang == "")
            {
                MessageBox.Show("Vui lòng chọn hàng cần xóa!");
                return;
            }

            DialogResult traLoi = MessageBox.Show("Bạn có muốn xóa hàng này không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (traLoi == DialogResult.No) return;

            try
            {
                bool ketQua = bus.XoaHangHoa(maHang);

                if (ketQua == true)
                {
                    MessageBox.Show("Xóa thành công!");
                    XoaThongTin();
                    TaiHangHoa();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hàng cần xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa: " + ex.Message);
            }
        }

        // Tìm kiếm hàng hóa
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHang = txtMaHang.Text.Trim();
            string tenHang = txtTenHang.Text.Trim();
            string maChatLieu = "";

            if (cboMaChatLieu.SelectedIndex != -1)
            {
                maChatLieu = cboMaChatLieu.SelectedValue.ToString();
            }

            try
            {
                dgvHangHoa.DataSource = bus.TimHangHoa(maHang, tenHang, maChatLieu);
                dgvHangHoa.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        // Bỏ qua thao tác hiện tại
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            cheDo = "";
            XoaThongTin();
            CapNhatNut();
            TaiHangHoa();
        }

        // Sự kiện cũ đang liên kết với Designer
        private void btnBoQua_Click_1(object sender, EventArgs e)
        {
            btnBoQua_Click(sender, e);
        }

        // Chọn ảnh hàng hóa
        private void btnMoAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog chonAnh = new OpenFileDialog();
            chonAnh.Filter = "Hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";

            if (chonAnh.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Lưu ảnh vào thư mục HinhAnh
                string thuMuc = Path.Combine(Application.StartupPath, "HinhAnh");
                Directory.CreateDirectory(thuMuc);

                string tenAnh = Path.GetFileName(chonAnh.FileName);
                string duongDanMoi = Path.Combine(thuMuc, tenAnh);

                if (chonAnh.FileName != duongDanMoi)
                {
                    File.Copy(chonAnh.FileName, duongDanMoi, true);
                }

                txtHinh.Text = Path.Combine("HinhAnh", tenAnh);
                HienThiAnh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        // Hiển thị hình ảnh đã chọn
        private void HienThiAnh()
        {
            string duongDan = txtHinh.Text.Trim();

            if (duongDan == "")
            {
                picHangHoa.ImageLocation = null;
                return;
            }

            if (!Path.IsPathRooted(duongDan))
            {
                duongDan = Path.Combine(Application.StartupPath, duongDan);
            }

            if (File.Exists(duongDan))
            {
                picHangHoa.ImageLocation = duongDan;
                picHangHoa.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                picHangHoa.ImageLocation = null;
            }
        }

        // Đóng chương trình
        private void btnDong_Click(object sender, EventArgs e)
        {
            DialogResult traLoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận", MessageBoxButtons.YesNo);

            if (traLoi == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
