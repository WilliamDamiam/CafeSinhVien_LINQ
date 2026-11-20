using System.Collections.Generic;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_BUS
{
    public class TinhTienBUS
    {
        // Tính tổng tiền các món đã chọn
        public decimal TinhTongTien(List<ChiTietHoaDonDTO> danhSachMon)
        {
            decimal tongTien = 0;

            foreach (ChiTietHoaDonDTO mon in danhSachMon)
            {
                tongTien += mon.SoLuong * mon.DonGia;
            }

            return tongTien;
        }

        // Tính tiền thanh toán sau giảm giá
        public decimal TinhTienThanhToan(decimal tongTien, bool laSinhVien)
        {
            if (laSinhVien)
            {
                tongTien = tongTien * 0.8m;
            }

            return tongTien;
        }
    }
}
