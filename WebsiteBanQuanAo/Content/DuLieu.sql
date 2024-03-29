USE [master]
GO
/****** Object:  Database [DatabaseBanQuanAo]    Script Date: 2020-06-03 5:06:16 PM ******/
CREATE DATABASE [DatabaseBanQuanAo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DatabaseBanQuanAo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DatabaseBanQuanAo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DatabaseBanQuanAo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DatabaseBanQuanAo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DatabaseBanQuanAo] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DatabaseBanQuanAo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET  MULTI_USER 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DatabaseBanQuanAo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DatabaseBanQuanAo] SET QUERY_STORE = OFF
GO
USE [DatabaseBanQuanAo]
GO
/****** Object:  Table [dbo].[tbDanhMuc]    Script Date: 2020-06-03 5:06:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbDanhMuc](
	[MaDanhMuc] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NULL,
	[GioiTinh] [bit] NULL,
	[AoOrQuan] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbNguoiDung]    Script Date: 2020-06-03 5:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbNguoiDung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoanNguoiDung] [varchar](50) NULL,
	[MatKhauNguoiDung] [nvarchar](50) NULL,
	[TenNguoiDung] [nvarchar](50) NULL,
	[DiaChiNguoiDung] [nvarchar](100) NULL,
	[SDTNguoiDung] [int] NULL,
	[GioiTinhNguoiDung] [nvarchar](10) NULL,
 CONSTRAINT [PK_tbNguoiDung] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbSanPham]    Script Date: 2020-06-03 5:06:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](100) NULL,
	[AnhMatTruoc] [varchar](max) NULL,
	[AnhMatSau] [varchar](max) NULL,
	[KichThuocSanPham] [varchar](15) NULL,
	[LuotXem] [int] NULL,
	[GiaSanPham] [money] NULL,
	[Sale] [bit] NULL,
	[GioiTinh] [int] NULL,
	[MoTaSanPham] [nvarchar](1000) NULL,
	[MaDanhMuc] [int] NULL,
	[NgayTao] [datetime] NULL,
	[GiaKhuyenMai] [money] NULL,
	[SanPhamMoiorCu] [nvarchar](10) NULL,
	[LuongMua] [int] NULL,
	[LoaiSanPham] [bit] NULL,
 CONSTRAINT [PK_tbSanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[tbDanhMuc] ON 

INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (1, N'Áo thun nữ', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (2, N'Áo thun nam', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (3, N'Áo khoác nữ', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (4, N'Áo hoodi nữ', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (5, N'Áo len nữ', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (6, N'Áo sơ mi nữ', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (7, N'Áo 2 dây', 0, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (8, N'Quần dài nữ', 0, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (9, N'Quần bó nữ', 0, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (10, N'Quần jeans nữ', 0, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (11, N'Quần short nữ', 0, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (12, N'Áo sơ mi nam', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (13, N'Áo khoác nam', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (14, N'Áo hoodi nam', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (15, N'Áo trùm đầu nam', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (16, N'Áo Polo', 1, 1)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (17, N'Quần jeans nam', 1, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (18, N'Quần dài nam', 1, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (19, N'Quần short nam', 1, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (20, N'Quần tây nam', 1, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (21, N'Quần bơi nam', 1, 0)
INSERT [dbo].[tbDanhMuc] ([MaDanhMuc], [TenDanhMuc], [GioiTinh], [AoOrQuan]) VALUES (22, N'Chân váy nữ', 0, 0)
SET IDENTITY_INSERT [dbo].[tbDanhMuc] OFF
SET IDENTITY_INSERT [dbo].[tbNguoiDung] ON 

INSERT [dbo].[tbNguoiDung] ([MaNguoiDung], [TaiKhoanNguoiDung], [MatKhauNguoiDung], [TenNguoiDung], [DiaChiNguoiDung], [SDTNguoiDung], [GioiTinhNguoiDung]) VALUES (12, N'cuonghoang@gmail.com', N'123', N'Cương Hoàng', N'bến cát', 258, N'Nam')
INSERT [dbo].[tbNguoiDung] ([MaNguoiDung], [TaiKhoanNguoiDung], [MatKhauNguoiDung], [TenNguoiDung], [DiaChiNguoiDung], [SDTNguoiDung], [GioiTinhNguoiDung]) VALUES (14, N'nu@gmail.com', N'123', N'nữ', N'bến cát', 2342, N'Nữ')
SET IDENTITY_INSERT [dbo].[tbNguoiDung] OFF
SET IDENTITY_INSERT [dbo].[tbSanPham] ON 

INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (1, N'Áo thun tay dài', N'p5.jpg', N'p6.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 700, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (2, N'Áo trắng ngắn', N'p7.jpg', N'p8.jpg', N'XL', 5, 100000.0000, 1, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 800, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (3, N'Áo thun tay dài', N'p9.jpg', N'p10.jpg', N'XL', 5, 100000.0000, 1, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 800, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (4, N'Áo trắng', N'p11.jpg', N'p12.jpg', N'XL', 5, 100000.0000, 0, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (5, N'Áo dài trắng đen', N'p13.jpg', N'p14.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (7, N'Áo sơ mi đen tay ngắn', N'p15.jpg', N'p16.jpg', N'XL', 5, 100000.0000, 0, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (8, N'Áo thun tay dài', N'p17.jpg', N'p18.jpg', N'XL', 5, 100000.0000, 0, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (9, N'Đồ bộ nữ', N'p19.jpg', N'p20.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (10, N'Đồ bộ nữ sọc', N'p21.jpg', N'p22.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 400, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (11, N'Áo khoác đen', N'p27.jpg', N'p28.jpg', N'XL', 5, 100000.0000, 0, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 500, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (12, N'Áo thun tay dài', N'p5.jpg', N'p6.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 600, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (13, N'Áo trắng ngắn', N'p7.jpg', N'p8.jpg', N'XL', 5, 100000.0000, 1, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', 700, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (14, N'Áo thun tay dài', N'p9.jpg', N'p10.jpg', N'XL', 5, 100000.0000, 0, 0, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (15, N'Áo dài trắng đen', N'p15.jpg', N'p16.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (16, N'Áo sơ mi đen tay ngắn', N'p15.jpg', N'p16.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (17, N'Áo thun tay dài', N'p17.jpg', N'p18.jpg', N'XL', 5, 100000.0000, 0, 1, N'jkashfsagjhsghowe', 1, CAST(N'2019-02-10T00:00:00.000' AS DateTime), 500000.0000, N'Mới', NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (18, N'Áo khoác nữ', N'AoKhoacNu1 (2).jpg', NULL, N'M', NULL, 100000.0000, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 500, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (19, N'Áo khoác nữ', N'AoKhoacNu1 (3).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 500, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (20, N'Áo khoác nữ', N'AoKhoacNu1 (4).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 500, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (21, N'Áo khoác nữ', N'AoKhoacNu1 (5).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 500, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (22, N'Áo khoác nữ', N'AoKhoacNu1 (6).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (23, N'Áo khoác nữ', N'AoKhoacNu1 (7).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 200, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (24, N'Áo khoác nữ', N'AoKhoacNu1 (8).jpg', NULL, N'M', NULL, NULL, 1, 1, NULL, 3, NULL, 500000.0000, N'Mới', 300, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (25, N'Áo khoác nữ', N'AoKhoacNu1 (9).jpg', NULL, N'M', NULL, NULL, NULL, 1, NULL, 3, NULL, 500000.0000, N'Cũ', 400, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (26, N'Áo khoác nữ', N'AoKhoacNu1 (10).jpg', NULL, N'M', NULL, NULL, NULL, 1, NULL, 3, NULL, 500000.0000, N'Cũ', 600, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (27, N'Áo khoác nữ', N'AoKhoacNu1 (11).jpg', NULL, N'M', NULL, NULL, NULL, 1, NULL, 3, NULL, 500000.0000, N'Cũ', 700, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (28, N'Áo khoác nữ', N'AoKhoacNu1 (12).jpg', NULL, N'M', NULL, NULL, NULL, 1, NULL, 3, NULL, NULL, N'Cũ', 800, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (29, N'Áo khoác nữ', N'AoKhoacNu1 (13).jpg', NULL, N'M', NULL, 100000.0000, NULL, 1, NULL, 3, NULL, 500000.0000, N'Cũ', 900, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (30, N'Áo khoác nữ', N'AoKhoacNu1 (14).jpg', NULL, N'M', NULL, 100000.0000, NULL, 1, NULL, 3, NULL, 500000.0000, N'Cũ', 900, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (31, N'Áo 2 dây nữ', N'Ao2DayNu1 (2).jpg', NULL, N'M', NULL, 100000.0000, NULL, 1, NULL, 7, NULL, 500000.0000, N'Cũ', 900, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (32, N'Áo 2 dây nữ', N'Ao2DayNu1 (3).jpg', NULL, N'L', NULL, 100000.0000, NULL, 1, NULL, 7, NULL, 500000.0000, N'Cũ', 900, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (33, N'Áo 2 dây nữ', N'Ao2DayNu1 (4).jpg', NULL, N'M', NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Cũ', 100, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (34, N'Áo 2 dây nữ', N'Ao2DayNu1 (5).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Cũ', 200, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (35, N'Áo 2 dây nữ', N'Ao2DayNu1 (6).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Cũ', 450, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (36, N'Áo 2 dây nữ', N'Ao2DayNu1 (7).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Cũ', 150, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (37, N'Áo 2 dây nữ', N'Ao2DayNu1 (8).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 400, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (38, N'Áo 2 dây nữ', N'Ao2DayNu1 (9).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 423, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (39, N'Áo 2 dây nữ', N'Ao2DayNu1 (10).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Mới', NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (40, N'Áo 2 dây nữ', N'Ao2DayNu1 (11).jpg', NULL, NULL, NULL, 100000.0000, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 245, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (41, N'Áo 2 dây nữ', N'Ao2DayNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 25, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (42, N'Áo 2 dây nữ', N'Ao2DayNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 25, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (43, N'Áo 2 dây nữ', N'Ao2DayNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 24, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (44, N'Áo 2 dây nữ', N'Ao2DayNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 15, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (45, N'Áo 2 dây nữ', N'Ao2DayNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 23, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (46, N'Áo 2 dây nữ', N'Ao2DayNu1 (17).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 7, NULL, NULL, N'Mới', 14, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (47, N'Áo len nữ', N'AoLenNu1 (2).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 14, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (48, N'Áo len nữ', N'AoLenNu1 (3).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 4546, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (49, N'Áo len nữ', N'AoLenNu1 (4).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 112, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (50, N'Áo len nữ', N'AoLenNu1 (5).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 78, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (51, N'Áo len nữ', N'AoLenNu1 (6).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 45, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (52, N'Áo len nữ', N'AoLenNu1 (7).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 12, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (53, N'Áo len nữ', N'AoLenNu1 (8).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, N'Mới', 12, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (54, N'Áo len nữ', N'AoLenNu1 (9).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, 46, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (55, N'Áo len nữ', N'AoLenNu1 (10).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (56, N'Áo len nữ', N'AoLenNu1 (11).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (57, N'Áo len nữ', N'AoLenNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (58, N'Áo len nữ', N'AoLenNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (59, N'Áo len nữ', N'AoLenNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (60, N'Áo len nữ', N'AoLenNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (61, N'Áo len nữ', N'AoLenNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (62, N'Áo len nữ', N'AoLenNu1 (17).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 5, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (63, N'Áo sơ mi nữ', N'AoSoMiNu1 (2).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (64, N'Áo sơ mi nữ', N'AoSoMiNu1 (3).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (65, N'Áo sơ mi nữ', N'AoSoMiNu1 (4).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (66, N'Áo sơ mi nữ', N'AoSoMiNu1 (5).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (67, N'Áo sơ mi nữ', N'AoSoMiNu1 (6).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (68, N'Áo sơ mi nữ', N'AoSoMiNu1 (7).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (69, N'Áo sơ mi nữ', N'AoSoMiNu1 (8).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (70, N'Áo sơ mi nữ', N'AoSoMiNu1 (9).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (71, N'Áo sơ mi nữ', N'AoSoMiNu1 (10).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (72, N'Áo sơ mi nữ', N'AoSoMiNu1 (11).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (73, N'Áo sơ mi nữ', N'AoSoMiNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (74, N'Áo sơ mi nữ', N'AoSoMiNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (75, N'Áo sơ mi nữ', N'AoSoMiNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (76, N'Áo sơ mi nữ', N'AoSoMiNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (77, N'Áo sơ mi nữ', N'AoSoMiNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (78, N'Áo sơ mi nữ', N'AoSoMiNu1 (17).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 6, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (79, N'Áo thun nữ', N'AoThunNu1 (2).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (80, N'Áo thun nữ', N'AoThunNu1 (3).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (81, N'Áo thun nữ', N'AoThunNu1 (4).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (82, N'Áo thun nữ', N'AoThunNu1 (5).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (83, N'Áo thun nữ', N'AoThunNu1 (6).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (84, N'Áo thun nữ', N'AoThunNu1 (7).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (85, N'Áo thun nữ', N'AoThunNu1 (8).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (86, N'Áo thun nữ', N'AoThunNu1 (9).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (87, N'Áo thun nữ', N'AoThunNu1 (10).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (88, N'Áo thun nữ', N'AoThunNu1 (11).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (89, N'Áo thun nữ', N'AoThunNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (90, N'Áo thun nữ', N'AoThunNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (91, N'Áo thun nữ', N'AoThunNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (92, N'Áo thun nữ', N'AoThunNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (93, N'Áo thun nữ', N'AoThunNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 1, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (94, N'Áo hoodi nữ', N'AoHoodiNu1 (2).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (95, N'Áo hoodi nữ', N'AoHoodiNu1 (3).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (96, N'Áo hoodi nữ', N'AoHoodiNu1 (4).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (97, N'Áo hoodi nữ', N'AoHoodiNu1 (5).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (98, N'Áo hoodi nữ', N'AoHoodiNu1 (6).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (99, N'Áo hoodi nữ', N'AoHoodiNu1 (7).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (100, N'Áo hoodi nữ', N'AoHoodiNu1 (8).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
GO
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (101, N'Áo hoodi nữ', N'AoHoodiNu1 (9).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (102, N'Áo hoodi nữ', N'AoHoodiNu1 (10).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (103, N'Áo hoodi nữ', N'AoHoodiNu1 (11).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (104, N'Áo hoodi nữ', N'AoHoodiNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (105, N'Áo hoodi nữ', N'AoHoodiNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (106, N'Áo hoodi nữ', N'AoHoodiNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (107, N'Áo hoodi nữ', N'AoHoodiNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (108, N'Áo hoodi nữ', N'AoHoodiNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 4, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (109, N'Chân váy nữ', N'ChanVayNu1 (2).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 100, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (110, N'Chân váy nữ', N'ChanVayNu1 (3).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 23, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (111, N'Chân váy nữ', N'ChanVayNu1 (4).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 456, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (112, N'Chân váy nữ', N'ChanVayNu1 (5).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 253, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (113, N'Chân váy nữ', N'ChanVayNu1 (6).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 258, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (114, N'Chân váy nữ', N'ChanVayNu1 (7).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 75, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (115, N'Chân váy nữ', N'ChanVayNu1 (8).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 452, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (116, N'Chân váy nữ', N'ChanVayNu1 (9).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 478, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (117, N'Chân váy nữ', N'ChanVayNu1 (10).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 32, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (118, N'Chân váy nữ', N'ChanVayNu1 (11).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 56, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (119, N'Chân váy nữ', N'ChanVayNu1 (12).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 785, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (120, N'Chân váy nữ', N'ChanVayNu1 (13).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 452, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (121, N'Chân váy nữ', N'ChanVayNu1 (14).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 754, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (122, N'Chân váy nữ', N'ChanVayNu1 (15).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, 145, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (123, N'Chân váy nữ', N'ChanVayNu1 (16).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (124, N'Chân váy nữ', N'ChanVayNu1 (17).jpg', NULL, NULL, NULL, NULL, NULL, 1, NULL, 22, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (125, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[tbSanPham] ([MaSanPham], [TenSanPham], [AnhMatTruoc], [AnhMatSau], [KichThuocSanPham], [LuotXem], [GiaSanPham], [Sale], [GioiTinh], [MoTaSanPham], [MaDanhMuc], [NgayTao], [GiaKhuyenMai], [SanPhamMoiorCu], [LuongMua], [LoaiSanPham]) VALUES (126, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbSanPham] OFF
USE [master]
GO
ALTER DATABASE [DatabaseBanQuanAo] SET  READ_WRITE 
GO
