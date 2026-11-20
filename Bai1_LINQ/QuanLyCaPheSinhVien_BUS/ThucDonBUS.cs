using System.Collections.Generic;
using QuanLyCaPheSinhVien_DAO;
using QuanLyCaPheSinhVien_DTO;

namespace QuanLyCaPheSinhVien_BUS
{
    public class ThucDonBUS
    {
        // Đối tượng truy cập dữ liệu thực đơn
        private ThucDonDAO thucDonDAO = new ThucDonDAO();

        // Lấy danh sách thực đơn
        public List<ThucDonDTO> LayDanhSachThucDon()
        {
            return thucDonDAO.LayDanhSachThucDon();
        }
    }
}
