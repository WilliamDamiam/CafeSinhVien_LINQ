using System;
using System.Collections.Generic;
using KhachSanThanhThanh_DAO;
using KhachSanThanhThanh_DTO;

namespace KhachSanThanhThanh_BUS
{
    public class KhachSanBUS
    {
        // Đối tượng truy cập cơ sở dữ liệu
        private KhachSanDAO dao = new KhachSanDAO();

        // Lấy bảng giá từ DAO
        public List<BangGiaDTO> LayBangGia()
        {
            return dao.LayBangGia();
        }

        // Tìm đơn giá theo mã phòng hoặc dịch vụ
        private decimal LayGia(List<BangGiaDTO> bangGia, string maMuc)
        {
            foreach (BangGiaDTO gia in bangGia)
            {
                if (gia.MaMuc == maMuc)
                {
                    return gia.DonGia;
                }
            }

            throw new Exception("Không tìm thấy giá: " + maMuc);
        }

        // Tính tiền thuê phòng và các dịch vụ
        public decimal TinhTien(HoaDonDTO hd)
        {
            if (hd == null || hd.SoNgayO <= 0) return 0;

            // Lấy bảng giá từ SQL Server
            List<BangGiaDTO> bangGia = dao.LayBangGia();

            // Tiền phòng tính theo số ngày ở
            decimal tongTien = LayGia(bangGia, hd.MaLoaiPhong) * hd.SoNgayO;

            // Cộng tiền tiện nghi
            if (hd.CoTivi) tongTien += LayGia(bangGia, "TN_TIVI");
            if (hd.CoInternet) tongTien += LayGia(bangGia, "TN_INTERNET");
            if (hd.CoMayNuocNong) tongTien += LayGia(bangGia, "TN_NUOCNONG");

            // Cộng tiền dịch vụ
            if (hd.CoKaraoke) tongTien += LayGia(bangGia, "DV_KARAOKE");
            if (hd.CoAnSang) tongTien += LayGia(bangGia, "DV_ANSANG") * hd.SoNgayO;

            return tongTien;
        }

        // Kiểm tra thông tin rồi lưu thanh toán
        public int LuuThanhToan(HoaDonDTO hd)
        {
            if (hd == null) return 0;
            if (string.IsNullOrWhiteSpace(hd.HoTen)) return 0;
            if (string.IsNullOrWhiteSpace(hd.DiaChi)) return 0;
            if (hd.SoNgayO <= 0) return 0;

            // Kiểm tra loại phòng hợp lệ
            if (hd.MaLoaiPhong != "P_DON" && hd.MaLoaiPhong != "P_DOI" && hd.MaLoaiPhong != "P_BA") return 0;

            // Tính tiền và lưu vào hóa đơn
            hd.ThanhTien = TinhTien(hd);

            return dao.LuuThanhToan(hd);
        }

        // Lấy kết quả tổng kết từ DAO
        public TongKetDTO TongKet()
        {
            return dao.TongKet();
        }
    }

}
