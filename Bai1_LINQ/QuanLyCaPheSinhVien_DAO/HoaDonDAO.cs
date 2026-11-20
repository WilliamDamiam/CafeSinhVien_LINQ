using System;
using System.Linq;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_DAO
{
    public class HoaDonDAO
    {
        // Chuỗi kết nối SQL Server
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCafeSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        // Thêm hóa đơn và lấy mã hóa đơn mới
        public int ThemHoaDon(HoaDonDTO hoaDon)
        {
            // Kết nối database bằng LINQ to SQL
            using (CafeDataDataContext db = new CafeDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure
                var ketQua = db.sp_ThemHoaDon(hoaDon.TenKhachHang, hoaDon.SoKhach, hoaDon.LaSinhVien, hoaDon.TongTien).FirstOrDefault();

                // Kiểm tra kết quả trả về
                if (ketQua == null)
                {
                    throw new Exception("Không lấy được mã hóa đơn!");
                }

                // Trả về mã hóa đơn vừa thêm
                return Convert.ToInt32(ketQua.MaHoaDon);
            }
        }
    }
}
