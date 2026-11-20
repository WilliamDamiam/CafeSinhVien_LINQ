using System;
using System.Collections.Generic;
using System.Linq;
using KhachSanThanhThanh_DTO;

namespace KhachSanThanhThanh_DAO
{
    public class KhachSanDAO
    {
        // Chuỗi kết nối SQL Server
        private string chuoiKetNoi = @"Data Source=.\SQLEXPRESS;Initial Catalog=KhachSanThanhThanh;Integrated Security=True;TrustServerCertificate=True;";

        // Lấy bảng giá phòng và dịch vụ
        public List<BangGiaDTO> LayBangGia()
        {
            List<BangGiaDTO> danhSach = new List<BangGiaDTO>();

            using (KhachSanDataDataContext db = new KhachSanDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lấy bảng giá
                var ketQua = db.usp_LayBangGia();

                // Đọc từng mục trong bảng giá
                foreach (var gia in ketQua)
                {
                    BangGiaDTO item = new BangGiaDTO();

                    item.MaMuc = gia.MaMuc;
                    item.TenMuc = gia.TenMuc;
                    item.DonGia = gia.DonGia;

                    danhSach.Add(item);
                }
            }

            return danhSach;
        }

        // Lưu thông tin thanh toán
        public int LuuThanhToan(HoaDonDTO hd)
        {
            using (KhachSanDataDataContext db = new KhachSanDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure lưu hóa đơn
                var ketQua = db.usp_LuuThanhToan(hd.HoTen, hd.DiaChi, hd.SoNgayO, hd.MaLoaiPhong, hd.CoTivi, hd.CoInternet, hd.CoMayNuocNong, hd.CoKaraoke, hd.CoAnSang, hd.ThanhTien).FirstOrDefault();

                // Kiểm tra kết quả
                if (ketQua == null)
                {
                    return 0;
                }

                // Trả về mã thanh toán vừa tạo
                return Convert.ToInt32(ketQua.MaThanhToan);
            }
        }

        // Tổng kết số lượt và doanh thu
        public TongKetDTO TongKet()
        {
            TongKetDTO tongKet = new TongKetDTO();

            using (KhachSanDataDataContext db = new KhachSanDataDataContext(chuoiKetNoi))
            {
                // Gọi Stored Procedure tổng kết
                var ketQua = db.usp_TongKet().FirstOrDefault();

                if (ketQua != null)
                {
                    tongKet.TongLuot = Convert.ToInt32(ketQua.TongLuot);
                    tongKet.TongTien = Convert.ToDecimal(ketQua.TongTien);
                }
            }

            return tongKet;
        }
    }
}
