using System;

namespace QuanLyHangHoa.DTO
{
    // Thông tin chất liệu
    public class ChatLieuDTO
    {
        public string MaChatLieu { get; set; }
        public string TenChatLieu { get; set; }
    }

    // Thông tin hàng hóa
    public class HangHoaDTO
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string MaChatLieu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaBan { get; set; }
        public string Hinh { get; set; }
        public string GhiChu { get; set; }
    }
}
