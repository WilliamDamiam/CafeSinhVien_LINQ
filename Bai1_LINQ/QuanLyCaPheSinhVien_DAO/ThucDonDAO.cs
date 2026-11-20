using System.Collections.Generic;
using System.Linq;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_DAO
{
    public class ThucDonDAO
    {
        // Chuỗi kết nối SQL Server
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyCafeSinhVien;Integrated Security=True;TrustServerCertificate=True;";

        // Lấy danh sách thực đơn
        public List<ThucDonDTO> LayDanhSachThucDon()
        {
            // Tạo đối tượng làm việc với database
            using (CafeDataDataContext db = new CafeDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lấy thực đơn
                var ketQua = db.sp_LayDanhSachThucDon();

                // Chuyển kết quả sang danh sách DTO
                var danhSach = ketQua.Select(mon => new ThucDonDTO
                {
                    MaMon = mon.MaMon,
                    TenMon = mon.TenMon,
                    LoaiMon = mon.LoaiMon,
                    DonGia = mon.DonGia
                }).ToList();

                return danhSach;
            }
        }
    }
}
