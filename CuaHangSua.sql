USE [master]
GO
/****** Object:  Database [CuaHangSua]    Script Date: 6/11/2019 2:54:27 PM ******/
CREATE DATABASE [CuaHangSua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CuaHangSua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CuaHangSua.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'CuaHangSua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\CuaHangSua_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [CuaHangSua] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CuaHangSua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CuaHangSua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CuaHangSua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CuaHangSua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CuaHangSua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CuaHangSua] SET ARITHABORT OFF 
GO
ALTER DATABASE [CuaHangSua] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CuaHangSua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CuaHangSua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CuaHangSua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CuaHangSua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CuaHangSua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CuaHangSua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CuaHangSua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CuaHangSua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CuaHangSua] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CuaHangSua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CuaHangSua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CuaHangSua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CuaHangSua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CuaHangSua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CuaHangSua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CuaHangSua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CuaHangSua] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CuaHangSua] SET  MULTI_USER 
GO
ALTER DATABASE [CuaHangSua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CuaHangSua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CuaHangSua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CuaHangSua] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [CuaHangSua] SET DELAYED_DURABILITY = DISABLED 
GO
USE [CuaHangSua]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[HoaDonID] [int] NOT NULL,
	[SuaID] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC,
	[SuaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[HoaDonID] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NOT NULL,
	[DiaChiNhanHang] [nvarchar](max) NOT NULL,
	[KhachHangID] [int] NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[HoaDonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[KhachHangID] [int] NOT NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](20) NULL,
	[TenKhachHang] [nvarchar](50) NOT NULL,
	[SDT] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[GioiTinh] [tinyint] NOT NULL,
	[NgaySinh] [date] NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[KhachHangID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Lo]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lo](
	[LoID] [int] IDENTITY(1,1) NOT NULL,
	[NgaySanXuat] [date] NOT NULL,
	[HanSuDung] [date] NOT NULL,
	[NoiSanXuat] [nvarchar](50) NULL,
 CONSTRAINT [PK_Lo] PRIMARY KEY CLUSTERED 
(
	[LoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sua]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sua](
	[SuaID] [int] IDENTITY(1,1) NOT NULL,
	[TenSua] [nvarchar](50) NOT NULL,
	[ThuongHieuID] [int] NOT NULL,
	[CachSuDung] [nvarchar](max) NOT NULL,
	[BaoQuan] [nvarchar](max) NOT NULL,
	[ThanhPhan] [nvarchar](max) NOT NULL,
	[DonGia] [float] NOT NULL,
	[KhoiLuong] [float] NOT NULL,
	[DonViTInh] [nvarchar](10) NOT NULL,
	[LoID] [int] NULL,
	[Anh] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sua] PRIMARY KEY CLUSTERED 
(
	[SuaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 6/11/2019 2:54:28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[ThuongHieuID] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](50) NOT NULL,
	[XuatXu] [nvarchar](50) NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[ThuongHieuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Lo] ON 

INSERT [dbo].[Lo] ([LoID], [NgaySanXuat], [HanSuDung], [NoiSanXuat]) VALUES (1, CAST(N'2019-01-01' AS Date), CAST(N'2019-07-01' AS Date), N'Việt Nam')
INSERT [dbo].[Lo] ([LoID], [NgaySanXuat], [HanSuDung], [NoiSanXuat]) VALUES (4, CAST(N'2019-01-01' AS Date), CAST(N'2019-07-01' AS Date), NULL)
INSERT [dbo].[Lo] ([LoID], [NgaySanXuat], [HanSuDung], [NoiSanXuat]) VALUES (6, CAST(N'2019-01-01' AS Date), CAST(N'2019-01-01' AS Date), NULL)
SET IDENTITY_INSERT [dbo].[Lo] OFF
SET IDENTITY_INSERT [dbo].[Sua] ON 

INSERT [dbo].[Sua] ([SuaID], [TenSua], [ThuongHieuID], [CachSuDung], [BaoQuan], [ThanhPhan], [DonGia], [KhoiLuong], [DonViTInh], [LoID], [Anh]) VALUES (1, N'Prosure vani 380g', 1, N'Uống 2 ly 450ml/ngày từ 3 - 4 tuần để đạt được hiệu quả tối ưu.
    
Sử dụng theo hướng dẫn của bác sĩ.
    
Cho 100ml nước vào 75g bột (9 muỗng) khuấy kỹ, sau đó thêm 90ml nước nữa khuấy lại cho đều.', N'Bảo quản hộp chưa mở ở nơi khô mát, tránh ánh nắng trực tiếp. Khi đã mở phải đậy nắp kín, để nơi khô mát và dùng trong vòng 2 tuần. 
    
Khi đã pha phải để trong tủ lạnh và dùng trong vòng 24 giờ.', N'tp', 459000, 380, N'Hộp', 1, NULL)
INSERT [dbo].[Sua] ([SuaID], [TenSua], [ThuongHieuID], [CachSuDung], [BaoQuan], [ThanhPhan], [DonGia], [KhoiLuong], [DonViTInh], [LoID], [Anh]) VALUES (5, N'Glucerna 400g', 1, N'Cùng với chế độ ăn hợp lý có thể dùng từ 1 đến 3 ly sữa Glucena mỗi ngày.', N'Bảo quản hộp chưa mở ở nơi khô mát, tránh ánh nắng trực tiếp. Khi đã mở phải đậy nắp kín, để nơi khô mát và dùng trong vòng 2 tuần. 
    
Khi đã pha phải để trong tủ lạnh và dùng trong vòng 24 giờ.', N'tp', 333000, 400, N'Hộp', 4, NULL)
INSERT [dbo].[Sua] ([SuaID], [TenSua], [ThuongHieuID], [CachSuDung], [BaoQuan], [ThanhPhan], [DonGia], [KhoiLuong], [DonViTInh], [LoID], [Anh]) VALUES (7, N'Ensure Gold 400g', 1, N'Cứ 195ml nước pha với 6 thìa gạt ngang sữa thì được 230ml sữa, lưu ý pha với nước ở nhiệt độ khoảng 60 độ C (nếu pha nước nóng hơn sẽ làm mất đi chất dinh dưỡng trong sữa).', N'Sử dụng trong vòng 3 tuần tính từ ngày mở nắp.', N'tp', 329000, 400, N'dsa', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sua] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu], [XuatXu]) VALUES (1, N'Abbott', N'Hoa Kỳ')
INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu], [XuatXu]) VALUES (2, N'Physiolac', N'Pháp')
INSERT [dbo].[ThuongHieu] ([ThuongHieuID], [TenThuongHieu], [XuatXu]) VALUES (3, N'Nestle', N'Thụy Sỹ')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_HoaDon] FOREIGN KEY([HoaDonID])
REFERENCES [dbo].[HoaDon] ([HoaDonID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_HoaDon]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHoaDon_Sua] FOREIGN KEY([SuaID])
REFERENCES [dbo].[Sua] ([SuaID])
GO
ALTER TABLE [dbo].[ChiTietHoaDon] CHECK CONSTRAINT [FK_ChiTietHoaDon_Sua]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([KhachHangID])
REFERENCES [dbo].[KhachHang] ([KhachHangID])
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[Sua]  WITH CHECK ADD  CONSTRAINT [FK_Sua_Lo] FOREIGN KEY([LoID])
REFERENCES [dbo].[Lo] ([LoID])
GO
ALTER TABLE [dbo].[Sua] CHECK CONSTRAINT [FK_Sua_Lo]
GO
ALTER TABLE [dbo].[Sua]  WITH CHECK ADD  CONSTRAINT [FK_Sua_ThuongHieu] FOREIGN KEY([ThuongHieuID])
REFERENCES [dbo].[ThuongHieu] ([ThuongHieuID])
GO
ALTER TABLE [dbo].[Sua] CHECK CONSTRAINT [FK_Sua_ThuongHieu]
GO
USE [master]
GO
ALTER DATABASE [CuaHangSua] SET  READ_WRITE 
GO
