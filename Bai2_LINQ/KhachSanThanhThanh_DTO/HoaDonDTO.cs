using System;

namespace KhachSanThanhThanh_DTO
{
    public class HoaDonDTO
    {
        // Thông tin khách hàng
        public int MaThanhToan { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }

        // Thông tin thuê phòng
        public int SoNgayO { get; set; }
        public string MaLoaiPhong { get; set; }

        // Các tiện nghi sử dụng
        public bool CoTivi { get; set; }
        public bool CoInternet { get; set; }
        public bool CoMayNuocNong { get; set; }

        // Các dịch vụ sử dụng
        public bool CoKaraoke { get; set; }
        public bool CoAnSang { get; set; }

        // Thông tin thanh toán
        public decimal ThanhTien { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public bool DaTongKet { get; set; }
    }
}
