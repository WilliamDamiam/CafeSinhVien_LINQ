using System.Collections.Generic;
using QuanLyCaPheSinhVien_DAO;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_BUS
{
    public class HoaDonBUS
    {
        // Các đối tượng xử lý dữ liệu hóa đơn
        private HoaDonDAO hoaDonDAO = new HoaDonDAO();
        private ChiTietHoaDonDAO chiTietDAO = new ChiTietHoaDonDAO();
        private TinhTienBUS tinhTienBUS = new TinhTienBUS();

        // Lưu thông tin thanh toán
        public bool LuuHoaDon(HoaDonDTO hd, List<ChiTietHoaDonDTO> danhSachMon)
        {
            // Kiểm tra thông tin khách hàng
            if (hd == null || danhSachMon == null || danhSachMon.Count == 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(hd.TenKhachHang) || hd.SoKhach <= 0)
            {
                return false;
            }

            // Kiểm tra các món đã chọn
            foreach (ChiTietHoaDonDTO mon in danhSachMon)
            {
                if (mon.MaMon <= 0 || mon.SoLuong <= 0 || mon.DonGia < 0)
                {
                    return false;
                }
            }

            // Tính số tiền cần thanh toán
            decimal tongTien = tinhTienBUS.TinhTongTien(danhSachMon);
            hd.TongTien = tinhTienBUS.TinhTienThanhToan(tongTien, hd.LaSinhVien);

            // Thêm hóa đơn và lấy mã hóa đơn mới
            int maHoaDon = hoaDonDAO.ThemHoaDon(hd);

            // Lưu từng món vào chi tiết hóa đơn
            foreach (ChiTietHoaDonDTO mon in danhSachMon)
            {
                mon.MaHoaDon = maHoaDon;

                bool ketQua = chiTietDAO.ThemChiTietHoaDon(mon);

                if (ketQua == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
