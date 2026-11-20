IF DB_ID('KhachSanThanhThanh') IS NULL
BEGIN
    EXEC('CREATE DATABASE KhachSanThanhThanh');
END
GO

USE KhachSanThanhThanh;
GO

IF OBJECT_ID('dbo.BangGia', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.BangGia
    (
        MaMuc VARCHAR(20) PRIMARY KEY,
        TenMuc NVARCHAR(100) NOT NULL,
        DonGia DECIMAL(18,0) NOT NULL CHECK (DonGia >= 0)
    );
END
GO

IF OBJECT_ID('dbo.HoaDonTraPhong', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.HoaDonTraPhong
    (
        MaThanhToan INT IDENTITY(1,1) PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        DiaChi NVARCHAR(200) NOT NULL,
        SoNgayO INT NOT NULL CHECK (SoNgayO > 0),
        MaLoaiPhong VARCHAR(20) NOT NULL,
        CoTivi BIT NOT NULL DEFAULT 0,
        CoInternet BIT NOT NULL DEFAULT 0,
        CoMayNuocNong BIT NOT NULL DEFAULT 0,
        CoKaraoke BIT NOT NULL DEFAULT 0,
        CoAnSang BIT NOT NULL DEFAULT 0,
        ThanhTien DECIMAL(18,0) NOT NULL CHECK (ThanhTien >= 0),
        NgayThanhToan DATETIME NOT NULL DEFAULT GETDATE(),
        DaTongKet BIT NOT NULL DEFAULT 0,

        FOREIGN KEY (MaLoaiPhong)
            REFERENCES dbo.BangGia(MaMuc)
    );
END
GO

INSERT INTO dbo.BangGia (MaMuc, TenMuc, DonGia)
SELECT v.MaMuc, v.TenMuc, v.DonGia
FROM (VALUES
    ('P_DON', N'Phòng đơn', 300000),
    ('P_DOI', N'Phòng đôi', 350000),
    ('P_BA', N'Phòng ba', 400000),
    ('TN_TIVI', N'Ti vi', 10000),
    ('TN_INTERNET', N'Internet', 10000),
    ('TN_NUOCNONG', N'Máy nước nóng', 10000),
    ('DV_KARAOKE', N'Karaoke', 50000),
    ('DV_ANSANG', N'Ăn sáng (mỗi ngày)', 15000)
) AS v(MaMuc, TenMuc, DonGia)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.BangGia b
    WHERE b.MaMuc = v.MaMuc
);
GO

CREATE OR ALTER PROCEDURE dbo.usp_LayBangGia
AS
BEGIN
    SET NOCOUNT ON;

    SELECT MaMuc, TenMuc, DonGia
    FROM dbo.BangGia;
END
GO

CREATE OR ALTER PROCEDURE dbo.usp_LuuThanhToan
    @HoTen NVARCHAR(100),
    @DiaChi NVARCHAR(200),
    @SoNgayO INT,
    @MaLoaiPhong VARCHAR(20),
    @CoTivi BIT,
    @CoInternet BIT,
    @CoMayNuocNong BIT,
    @CoKaraoke BIT,
    @CoAnSang BIT,
    @ThanhTien DECIMAL(18,0)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.HoaDonTraPhong
    (
        HoTen, DiaChi, SoNgayO, MaLoaiPhong,
        CoTivi, CoInternet, CoMayNuocNong,
        CoKaraoke, CoAnSang, ThanhTien
    )
    OUTPUT INSERTED.MaThanhToan
    VALUES
    (
        @HoTen, @DiaChi, @SoNgayO, @MaLoaiPhong,
        @CoTivi, @CoInternet, @CoMayNuocNong,
        @CoKaraoke, @CoAnSang, @ThanhTien
    );
END
GO

CREATE OR ALTER PROCEDURE usp_TongKet
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @TongLuot INT;
    DECLARE @TongTien DECIMAL(18,0);

    SELECT
        @TongLuot = COUNT(*),
        @TongTien = ISNULL(SUM(ThanhTien), 0)
    FROM HoaDonTraPhong
    WHERE DaTongKet = 0;

    UPDATE HoaDonTraPhong
    SET DaTongKet = 1
    WHERE DaTongKet = 0;

    SELECT @TongLuot AS TongLuot, @TongTien AS TongTien;
END;
GO

