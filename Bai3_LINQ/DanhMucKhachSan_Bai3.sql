-- 1. TẠO CƠ SỞ DỮ LIỆU
IF DB_ID('QLHangHoa_Bai3') IS NULL
BEGIN
    EXEC('CREATE DATABASE QLHangHoa_Bai3');
END
GO

USE QLHangHoa_Bai3;
GO

-- 2. TẠO BẢNG CHẤT LIỆU
IF OBJECT_ID('DMChatLieu', 'U') IS NULL
BEGIN
    CREATE TABLE DMChatLieu
    (
        MaChatLieu NVARCHAR(10) PRIMARY KEY,
        TenChatLieu NVARCHAR(100) NOT NULL
    );
END
GO

-- 3. TẠO BẢNG HÀNG HÓA
IF OBJECT_ID('DMHang', 'U') IS NULL
BEGIN
    CREATE TABLE DMHang
    (
        MaHang NVARCHAR(10) PRIMARY KEY,
        TenHang NVARCHAR(100) NOT NULL,
        MaChatLieu NVARCHAR(10) NOT NULL,
        SoLuong INT NOT NULL CHECK (SoLuong >= 0),
        DonGiaNhap DECIMAL(18,2) NOT NULL CHECK (DonGiaNhap >= 0),
        DonGiaBan DECIMAL(18,2) NOT NULL CHECK (DonGiaBan >= 0),
        Hinh NVARCHAR(255),
        GhiChu NVARCHAR(500),

        FOREIGN KEY (MaChatLieu) REFERENCES DMChatLieu(MaChatLieu)
    );
END
GO

-- 4. THÊM 10 CHẤT LIỆU MẪU
IF NOT EXISTS (SELECT * FROM DMChatLieu)
BEGIN
    INSERT INTO DMChatLieu (MaChatLieu, TenChatLieu)
    VALUES
    ('CL01', N'Cotton'),
    ('CL02', N'Denim'),
    ('CL03', N'Lụa'),
    ('CL04', N'Len'),
    ('CL05', N'Polyester'),
    ('CL06', N'Da'),
    ('CL07', N'Kaki'),
    ('CL08', N'Vải thun'),
    ('CL09', N'Vải nỉ'),
    ('CL10', N'Jean co giãn');
END
GO

-- 5. THÊM 25 HÀNG HÓA MẪU
IF NOT EXISTS (SELECT * FROM DMHang)
BEGIN
    INSERT INTO DMHang
    (MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Hinh, GhiChu)
    VALUES
    ('H001', N'Áo thun nam', 'CL01', 50, 80000, 120000, NULL, N'Áo thun cotton'),
    ('H002', N'Áo sơ mi trắng', 'CL01', 40, 120000, 180000, NULL, N'Sơ mi công sở'),
    ('H003', N'Quần jean nam', 'CL02', 35, 180000, 280000, NULL, N'Jean xanh'),
    ('H004', N'Quần jean nữ', 'CL02', 45, 170000, 260000, NULL, N'Jean nữ'),
    ('H005', N'Áo sơ mi lụa', 'CL03', 25, 200000, 320000, NULL, N'Lụa mềm'),
    ('H006', N'Áo len cổ lọ', 'CL04', 30, 150000, 240000, NULL, N'Áo len mùa đông'),
    ('H007', N'Áo khoác thể thao', 'CL05', 20, 250000, 390000, NULL, N'Áo khoác nam'),
    ('H008', N'Áo khoác da', 'CL06', 15, 500000, 750000, NULL, N'Áo khoác cao cấp'),
    ('H009', N'Quần kaki nam', 'CL07', 55, 160000, 250000, NULL, N'Kaki đen'),
    ('H010', N'Quần kaki nữ', 'CL07', 48, 150000, 230000, NULL, N'Kaki nữ'),
    ('H011', N'Áo polo', 'CL08', 60, 100000, 160000, NULL, N'Áo polo nam'),
    ('H012', N'Áo thun nữ', 'CL08', 70, 70000, 110000, NULL, N'Áo thun nữ'),
    ('H013', N'Áo hoodie', 'CL09', 35, 180000, 290000, NULL, N'Hoodie có mũ'),
    ('H014', N'Quần jogger', 'CL09', 42, 140000, 220000, NULL, N'Quần thể thao'),
    ('H015', N'Quần jean co giãn', 'CL10', 28, 190000, 310000, NULL, N'Jean co giãn'),
    ('H016', N'Váy công sở', 'CL03', 30, 220000, 350000, NULL, N'Váy nữ'),
    ('H017', N'Áo cardigan', 'CL04', 25, 170000, 270000, NULL, N'Áo khoác len'),
    ('H018', N'Áo gió chống nước', 'CL05', 38, 230000, 360000, NULL, N'Áo gió'),
    ('H019', N'Thắt lưng da', 'CL06', 65, 90000, 150000, NULL, N'Phụ kiện nam'),
    ('H020', N'Quần short kaki', 'CL07', 52, 85000, 140000, NULL, N'Quần short'),
    ('H021', N'Áo thể thao', 'CL08', 80, 75000, 130000, NULL, N'Áo tập gym'),
    ('H022', N'Bộ đồ ngủ', 'CL01', 32, 130000, 210000, NULL, N'Bộ mặc nhà'),
    ('H023', N'Áo sweater', 'CL09', 44, 160000, 260000, NULL, N'Sweater nam nữ'),
    ('H024', N'Chân váy jean', 'CL02', 37, 140000, 230000, NULL, N'Chân váy nữ'),
    ('H025', N'Quần jean slim fit', 'CL10', 29, 210000, 340000, NULL, N'Jean ôm dáng');
END
GO

-- ==========================================
-- 6. STORED PROCEDURE LẤY DANH SÁCH HÀNG HÓA
-- ==========================================

CREATE OR ALTER PROC usp_LayHangHoa
AS
BEGIN
    -- Lấy hàng hóa kèm tên chất liệu
    SELECT h.MaHang, h.TenHang, h.MaChatLieu, c.TenChatLieu,
           h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh, h.GhiChu
    FROM DMHang h
    INNER JOIN DMChatLieu c ON h.MaChatLieu = c.MaChatLieu;
END
GO

-- ==========================================
-- 7. STORED PROCEDURE LẤY CHẤT LIỆU
-- ==========================================

CREATE OR ALTER PROC usp_LayChatLieu
AS
BEGIN
    -- Lấy danh sách chất liệu
    SELECT MaChatLieu, TenChatLieu
    FROM DMChatLieu;
END
GO

-- ==========================================
-- 8. STORED PROCEDURE THÊM HÀNG HÓA
-- ==========================================

CREATE OR ALTER PROC usp_ThemHangHoa
    @MaHang NVARCHAR(10),
    @TenHang NVARCHAR(100),
    @MaChatLieu NVARCHAR(10),
    @SoLuong INT,
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @Hinh NVARCHAR(255) = NULL,
    @GhiChu NVARCHAR(500) = NULL
AS
BEGIN
    -- Thêm hàng hóa mới
    INSERT INTO DMHang (MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, Hinh, GhiChu)
    VALUES (@MaHang, @TenHang, @MaChatLieu, @SoLuong, @DonGiaNhap, @DonGiaBan, @Hinh, @GhiChu);
END
GO

-- ==========================================
-- 9. STORED PROCEDURE SỬA HÀNG HÓA
-- ==========================================

CREATE OR ALTER PROC usp_SuaHangHoa
    @MaHang NVARCHAR(10),
    @TenHang NVARCHAR(100),
    @MaChatLieu NVARCHAR(10),
    @SoLuong INT,
    @DonGiaNhap DECIMAL(18,2),
    @DonGiaBan DECIMAL(18,2),
    @Hinh NVARCHAR(255) = NULL,
    @GhiChu NVARCHAR(500) = NULL
AS
BEGIN
    -- Sửa thông tin hàng hóa theo mã hàng
    UPDATE DMHang
    SET TenHang = @TenHang,
        MaChatLieu = @MaChatLieu,
        SoLuong = @SoLuong,
        DonGiaNhap = @DonGiaNhap,
        DonGiaBan = @DonGiaBan,
        Hinh = @Hinh,
        GhiChu = @GhiChu
    WHERE MaHang = @MaHang;
END
GO

-- ==========================================
-- 10. STORED PROCEDURE XÓA HÀNG HÓA
-- ==========================================

CREATE OR ALTER PROC usp_XoaHangHoa
    @MaHang NVARCHAR(10)
AS
BEGIN
    -- Xóa hàng hóa theo mã hàng
    DELETE FROM DMHang
    WHERE MaHang = @MaHang;
END
GO

-- ==========================================
-- 11. STORED PROCEDURE TÌM KIẾM HÀNG HÓA
-- ==========================================

CREATE OR ALTER PROC usp_TimHangHoa
    @MaHang NVARCHAR(10) = NULL,
    @TenHang NVARCHAR(100) = NULL,
    @MaChatLieu NVARCHAR(10) = NULL
AS
BEGIN
    -- Tìm theo mã hàng, tên hàng hoặc chất liệu
    SELECT h.MaHang, h.TenHang, h.MaChatLieu, c.TenChatLieu,
           h.SoLuong, h.DonGiaNhap, h.DonGiaBan, h.Hinh, h.GhiChu
    FROM DMHang h
    INNER JOIN DMChatLieu c ON h.MaChatLieu = c.MaChatLieu
    WHERE (@MaHang IS NULL OR h.MaHang LIKE N'%' + @MaHang + N'%')
      AND (@TenHang IS NULL OR h.TenHang LIKE N'%' + @TenHang + N'%')
      AND (@MaChatLieu IS NULL OR h.MaChatLieu = @MaChatLieu);
END
GO

-- ==========================================
-- 12. KIỂM TRA DỮ LIỆU SAU KHI TẠO
-- ==========================================

-- Kiểm tra 10 chất liệu
EXEC usp_LayChatLieu;

-- Kiểm tra 25 hàng hóa
EXEC usp_LayHangHoa;
GO
