using System.Data;
using QuanLyHangHoa.DAO;
using QuanLyHangHoa.DTO;

namespace QuanLyHangHoa.BUS
{
    public class HangHoaBUS
    {
        // Đối tượng truy cập dữ liệu
        private HangHoaDAO dao = new HangHoaDAO();

        // Lấy danh sách hàng hóa
        public DataTable LayHangHoa()
        {
            return dao.LayHangHoa();
        }

        // Lấy danh sách chất liệu
        public DataTable LayChatLieu()
        {
            return dao.LayChatLieu();
        }

        // Kiểm tra thông tin hàng hóa
        private bool KiemTraHangHoa(HangHoaDTO h)
        {
            if (h == null) return false;
            if (string.IsNullOrWhiteSpace(h.MaHang)) return false;
            if (string.IsNullOrWhiteSpace(h.TenHang)) return false;
            if (string.IsNullOrWhiteSpace(h.MaChatLieu)) return false;

            if (h.MaHang.Length > 10) return false;
            if (h.TenHang.Length > 100) return false;
            if (h.MaChatLieu.Length > 10) return false;

            if (h.SoLuong < 0) return false;
            if (h.DonGiaNhap < 0) return false;
            if (h.DonGiaBan < 0) return false;

            return true;
        }

        // Thêm hàng hóa
        public bool ThemHangHoa(HangHoaDTO h)
        {
            if (KiemTraHangHoa(h) == false) return false;

            return dao.ThemHangHoa(h);
        }

        // Sửa hàng hóa
        public bool SuaHangHoa(HangHoaDTO h)
        {
            if (KiemTraHangHoa(h) == false) return false;

            return dao.SuaHangHoa(h);
        }

        // Xóa hàng hóa
        public bool XoaHangHoa(string maHang)
        {
            if (string.IsNullOrWhiteSpace(maHang)) return false;

            return dao.XoaHangHoa(maHang);
        }

        // Tìm kiếm hàng hóa
        public DataTable TimHangHoa(string maHang, string tenHang, string maChatLieu)
        {
            return dao.TimHangHoa(maHang, tenHang, maChatLieu);
        }
    }
}
