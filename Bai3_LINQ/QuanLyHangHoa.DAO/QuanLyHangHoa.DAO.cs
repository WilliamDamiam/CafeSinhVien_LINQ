using System;
using System.Data;
using System.Linq;
using QuanLyHangHoa.DTO;

namespace QuanLyHangHoa.DAO
{
    public class HangHoaDAO
    {
        // Chuỗi kết nối SQL Server
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=QLHangHoa_Bai3;Integrated Security=True;TrustServerCertificate=True;";

        // Tạo bảng để hiển thị danh sách hàng hóa
        private DataTable TaoBangHangHoa()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaHang", typeof(string));
            dt.Columns.Add("TenHang", typeof(string));
            dt.Columns.Add("MaChatLieu", typeof(string));
            dt.Columns.Add("TenChatLieu", typeof(string));
            dt.Columns.Add("SoLuong", typeof(int));
            dt.Columns.Add("DonGiaNhap", typeof(decimal));
            dt.Columns.Add("DonGiaBan", typeof(decimal));
            dt.Columns.Add("Hinh", typeof(string));
            dt.Columns.Add("GhiChu", typeof(string));

            return dt;
        }

        // Lấy danh sách hàng hóa
        public DataTable LayHangHoa()
        {
            DataTable dt = TaoBangHangHoa();

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lấy hàng hóa
                var danhSach = db.usp_LayHangHoa();

                foreach (var h in danhSach)
                {
                    dt.Rows.Add(h.MaHang, h.TenHang, h.MaChatLieu, h.TenChatLieu, h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh, h.GhiChu);
                }
            }

            return dt;
        }

        // Lấy danh sách chất liệu
        public DataTable LayChatLieu()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MaChatLieu", typeof(string));
            dt.Columns.Add("TenChatLieu", typeof(string));

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lấy chất liệu
                var danhSach = db.usp_LayChatLieu();

                foreach (var cl in danhSach)
                {
                    dt.Rows.Add(cl.MaChatLieu, cl.TenChatLieu);
                }
            }

            return dt;
        }

        // Thêm hàng hóa
        public bool ThemHangHoa(HangHoaDTO h)
        {
            if (h == null) return false;

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Kiểm tra mã hàng đã tồn tại chưa
                var danhSach = db.usp_LayHangHoa();

                if (danhSach.Any(x => x.MaHang == h.MaHang))
                {
                    return false;
                }

                // Gọi Stored Procedure thêm hàng hóa
                db.usp_ThemHangHoa(h.MaHang, h.TenHang, h.MaChatLieu, h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh ?? "", h.GhiChu ?? "");

                return true;
            }
        }

        // Sửa thông tin hàng hóa
        public bool SuaHangHoa(HangHoaDTO h)
        {
            if (h == null) return false;

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Kiểm tra hàng hóa có tồn tại không
                var danhSach = db.usp_LayHangHoa();

                if (!danhSach.Any(x => x.MaHang == h.MaHang))
                {
                    return false;
                }

                // Gọi Stored Procedure sửa hàng hóa
                db.usp_SuaHangHoa(h.MaHang, h.TenHang, h.MaChatLieu, h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh ?? "", h.GhiChu ?? "");

                return true;
            }
        }

        // Xóa hàng hóa
        public bool XoaHangHoa(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang)) return false;

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Kiểm tra hàng hóa cần xóa
                var danhSach = db.usp_LayHangHoa();

                if (!danhSach.Any(x => x.MaHang == maHang))
                {
                    return false;
                }

                // Gọi Stored Procedure xóa hàng hóa
                db.usp_XoaHangHoa(maHang);

                return true;
            }
        }

        // Tìm kiếm hàng hóa
        public DataTable TimHangHoa(string maHang, string tenHang, string maChatLieu)
        {
            DataTable dt = TaoBangHangHoa();

            // Không nhập điều kiện thì không lọc
            if (string.IsNullOrWhiteSpace(maHang)) maHang = null;
            if (string.IsNullOrWhiteSpace(tenHang)) tenHang = null;
            if (string.IsNullOrWhiteSpace(maChatLieu)) maChatLieu = null;

            using (QuanLyHangHoaDataContext db = new QuanLyHangHoaDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure tìm kiếm
                var danhSach = db.usp_TimHangHoa(maHang, tenHang, maChatLieu);

                foreach (var h in danhSach)
                {
                    dt.Rows.Add(h.MaHang, h.TenHang, h.MaChatLieu, h.TenChatLieu, h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh, h.GhiChu);
                }
            }

            return dt;
        }
    }
}
