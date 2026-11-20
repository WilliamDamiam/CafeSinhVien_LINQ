using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_DAO
{
    public class ChiTietHoaDonDAO
    {
        // Chuỗi kết nối SQL Server
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCafeSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        // Thêm chi tiết hóa đơn
        public bool ThemChiTietHoaDon(ChiTietHoaDonDTO ct)
        {
            if (ct == null) return false;

            // Tạo đối tượng làm việc với database
            using (CafeDataDataContext db = new CafeDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lưu món đã chọn
                db.sp_ThemChiTietHoaDon(ct.MaHoaDon, ct.MaMon, ct.SoLuong, ct.DonGia);

                return true;
            }
        }
    }
}
