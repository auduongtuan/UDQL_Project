USE [master]
GO
/****** Object:  Database [udql_inventory]    Script Date: 11/26/2023 1:31:20 PM ******/
CREATE DATABASE [udql_inventory]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'udql_inventory', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\udql_inventory.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'udql_inventory_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\udql_inventory_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [udql_inventory] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [udql_inventory].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [udql_inventory] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [udql_inventory] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [udql_inventory] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [udql_inventory] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [udql_inventory] SET ARITHABORT OFF 
GO
ALTER DATABASE [udql_inventory] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [udql_inventory] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [udql_inventory] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [udql_inventory] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [udql_inventory] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [udql_inventory] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [udql_inventory] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [udql_inventory] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [udql_inventory] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [udql_inventory] SET  DISABLE_BROKER 
GO
ALTER DATABASE [udql_inventory] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [udql_inventory] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [udql_inventory] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [udql_inventory] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [udql_inventory] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [udql_inventory] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [udql_inventory] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [udql_inventory] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [udql_inventory] SET  MULTI_USER 
GO
ALTER DATABASE [udql_inventory] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [udql_inventory] SET DB_CHAINING OFF 
GO
ALTER DATABASE [udql_inventory] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [udql_inventory] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [udql_inventory] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [udql_inventory] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [udql_inventory] SET QUERY_STORE = ON
GO
ALTER DATABASE [udql_inventory] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [udql_inventory]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](50) NULL,
	[Phone] [nvarchar](11) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manufacturer]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manufacturer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Manufacturer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerId] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ShippedDate] [datetime] NULL,
	[ReceiptAddress] [nvarchar](50) NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [float] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/26/2023 1:31:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Price] [float] NULL,
	[Image] [nvarchar](max) NULL,
	[ManufacturerId] [int] NULL,
	[CategoryId] [int] NULL,
	[Description] [text] NULL,
	[Quantity] [int] NULL,
	[Sold] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (1, N'Mobile phone', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-17T10:48:28.953' AS DateTime))
INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (2, N'Laptop', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-17T10:48:28.953' AS DateTime))
INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (3, N'Macbook', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-17T10:48:28.953' AS DateTime))
INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (4, N'Tablet', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-17T10:48:28.953' AS DateTime))
INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (5, N'Speaker', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-17T10:48:28.953' AS DateTime))
INSERT [dbo].[Category] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (17, N'Others', CAST(N'2023-11-17T10:48:28.957' AS DateTime), CAST(N'2023-11-21T10:29:41.193' AS DateTime))
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (1, N'Au Duong Tuan', N'89 Tran Quoc Toan, P.6, Q.3, TP. HCM', N'0948935300', CAST(N'2023-11-17T10:48:11.597' AS DateTime), CAST(N'2023-11-21T10:26:45.977' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (2, N'Nguyen Van An', N'82 Le Quy Don, P.4, Q.3, TP. HCM', N'0281920123', CAST(N'2023-11-17T10:48:11.597' AS DateTime), CAST(N'2023-11-21T10:27:36.723' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (4, N'Tran Van Binh', N'53 Nguyen Dinh Chieu, P.4, Q.1, TP. HCM', N'0913431341', CAST(N'2023-11-17T10:48:11.597' AS DateTime), CAST(N'2023-11-21T10:27:42.203' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (5, N'Ngo Thi Quynh Mai', N'53 Thao Dien, Q.2, TP. HCM', N'0948392156', CAST(N'2023-11-21T10:28:09.850' AS DateTime), CAST(N'2023-11-21T10:28:23.670' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (6, N'Bui Trung Quan', N'120 Nguyen Thi Minh, P.8, TP. HCM', N'0913493291', CAST(N'2023-11-21T22:13:32.830' AS DateTime), CAST(N'2023-11-21T22:13:32.830' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (7, N'Nguyen Hoang Ton', N'198 Cach Mang Thang Tam, Q.10, TP. HCM', N'0123456984', CAST(N'2023-11-21T22:19:21.283' AS DateTime), CAST(N'2023-11-21T22:19:21.283' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (8, N'Tran Duy Khang', N'151 Nguyen Khac Chan, Q.3, TP. HCM', N'0948932239', CAST(N'2023-11-21T22:37:43.993' AS DateTime), CAST(N'2023-11-21T22:37:43.993' AS DateTime))
INSERT [dbo].[Customer] ([Id], [Name], [Address], [Phone], [CreatedDate], [UpdatedDate]) VALUES (9, N'Nguyen Van Nguyen', N'56 Tran Quoc Thao, P.10, Q.3, TP. HCM', N'0123943923', CAST(N'2023-11-24T17:41:11.467' AS DateTime), CAST(N'2023-11-26T13:06:40.420' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customer] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (1, N'Apple', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (2, N'Samsung', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (3, N'Xiaomi', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (4, N'Oppo', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (5, N'Acer', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (6, N'Asus', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (7, N'HP', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (8, N'MSI', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (9, N'Lenovo', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (10, N'Rezo', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (11, N'JBL', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (12, N'Hurman Kardon', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-17T10:47:51.020' AS DateTime))
INSERT [dbo].[Manufacturer] ([Id], [Name], [CreatedDate], [UpdatedDate]) VALUES (13, N'B&O', CAST(N'2023-11-17T10:47:51.027' AS DateTime), CAST(N'2023-11-26T12:59:00.267' AS DateTime))
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (1, 1, CAST(N'2023-10-13T00:00:00.000' AS DateTime), CAST(N'2023-10-16T00:00:00.000' AS DateTime), N'', CAST(N'2023-11-21T22:11:19.913' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (2, 2, CAST(N'2023-11-14T00:00:00.000' AS DateTime), NULL, N'53/43 Tran Quoc Hoan, P.3, Q.3, TP. HCM', CAST(N'2023-11-21T14:49:06.820' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (4, 4, CAST(N'2023-11-14T15:06:08.663' AS DateTime), CAST(N'2023-11-15T00:00:00.000' AS DateTime), NULL, CAST(N'2023-11-17T10:46:58.780' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (5, 1, CAST(N'2023-11-18T00:02:22.760' AS DateTime), NULL, NULL, CAST(N'2023-11-18T00:02:22.760' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (6, 5, CAST(N'2023-11-21T22:03:00.160' AS DateTime), NULL, NULL, CAST(N'2023-11-21T22:03:00.157' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (7, 6, CAST(N'2023-11-21T22:14:51.203' AS DateTime), NULL, NULL, CAST(N'2023-11-21T22:14:51.203' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (8, 7, CAST(N'2023-11-21T22:19:52.083' AS DateTime), CAST(N'2023-09-30T00:00:00.000' AS DateTime), NULL, CAST(N'2023-11-21T22:19:52.083' AS DateTime))
INSERT [dbo].[Order] ([Id], [CustomerId], [CreatedDate], [ShippedDate], [ReceiptAddress], [UpdatedDate]) VALUES (9, 8, CAST(N'2023-09-21T00:00:00.000' AS DateTime), NULL, NULL, CAST(N'2023-11-21T22:38:50.793' AS DateTime))
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 2, 2, 16077000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (1, 64, 2, 11390000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (2, 6, 1, 8260000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 3, 1, 499000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (4, 6, 1, 8260000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (5, 1, 1, 27999000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (6, 22, 5, 39890000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (7, 26, 1, 20990000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (7, 38, 1, 79990000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (8, 10, 2, 500000)
INSERT [dbo].[OrderDetail] ([OrderId], [ProductId], [Quantity], [Price]) VALUES (9, 57, 1, 5690000)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (1, N'iPhone 14 Pro', 27999000, N'images/iphone-14-pro.png', 1, 1, NULL, 100, 1, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:54:58.793' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (2, N'iPhone 13', 16077000, N'images/iphone-13.png', 1, 1, NULL, 100, 2, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T14:23:28.303' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (3, N'iPhone 11', 499000, N'images/iphone-11.png', 1, 1, NULL, 100, 1, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:55:00.320' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (4, N'Galaxy Z Flip 5', 799000, N'images/galaxy-z-flip-5.png', 2, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (5, N'Galaxy S23 Ultra', 23990000, N'images/galaxy-s23-ultra.png', 2, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:47:21.093' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (6, N'Xiaomi Redmi Note 12 Pro 5G', 8260000, N'images/xiaomi-redmi-note-12-pro-5g.png', 3, 1, NULL, 100, 2, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:55:00.330' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (7, N'iPhone 15', 23299000, N'images/iphone-15.jpeg', 1, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:46:22.070' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (8, N'iPhone 15 Pro Max', 31699000, N'images/iphone-15-pro-max.png', 1, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:46:30.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (9, N'Galaxy Z Fold 4', 24299000, N'images/samsung-galaxy-z-fold4.png', 2, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:46:44.960' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (10, N'Xiaomi 13T 5G', 500000, N'images/xiaomi-13t-5g.png', 3, 1, N'TTe', 100, 2, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:55:00.347' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (11, N'Xiaomi Redmi 12 Pro 4G', 7600000, N'images/xiaomi-redmi-12-pro-4g.png', 3, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:48:00.083' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (13, N'Oppo A57', 6900000, N'images/oppo-a57.jpeg', 4, 1, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:47:41.367' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (17, N'Macbook Air 15 inch M2 2023 Midnight', 37990000, N'images/apple-macbook-air-15-inch-m2-2023-midnight.jpeg', 1, 3, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (18, N'Acer Nitro-5 an515-58 769j i7 nhqfhsv003', 24490000, N'images/acer-nitro-5-an515-58-769j-i7-nhqfhsv003.jpg', 5, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (21, N'MacBook Air 13 inch M2 2022 10-core GPU', 37690000, N'images/apple-macbook-air-m2-2022.jpeg', 1, 3, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (22, N'MacBook Pro 13 inch M2 2022 10-core GPU', 39890000, N'images/apple-macbook-pro-13-inch-m2-2022-xam.jpeg', 1, 3, NULL, 100, 5, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T21:40:19.743' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (24, N'MacBook Air 13 inch M1 2020 7-core GPU', 18990000, N'images/macbook-air-m1-2020-gray.jpeg', 1, 3, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (26, N'Asus TUF Gaming F15 FX506HE i7 11800H (HN378W)', 20990000, N'images/asus-tuf-gaming-f15-fx506he-i7-hn378w.jpeg', 6, 2, NULL, 100, 1, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:58:48.853' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (28, N'Asus Vivobook 15 X1504VA i5 1335U (NJ025W)      ', 14990000, N'images/asus-vivobook-15-x1504va-i5-nj025w.jpeg', 6, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (30, N'Asus Vivobook X415EA i3 1115G4 (EK2034W)', 8990000, N'images/asus-vivobook-x415ea-i3-ek2034w.jpeg', 6, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:49:58.873' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (32, N'HP 15s fq5229TU i3 1215U (8U237PA)', 10890000, N'images/hp-15s-fq5229tu-i3-8u237pa.png', 7, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (33, N'Lenovo Ideapad 3 15IAU7 i3 1215U (82RK001MVN)', 9490000, N'images/lenovo-ideapad-3-15itl6-i3-82h803sgvn.jpeg', 9, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-21T22:48:53.667' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (35, N'Lenovo Ideapad Gaming 3 15ACH6 R5 5500H (82K2027PVN)', 16990000, N'images/lenovo-ideapad-gaming-3-15ach6-r5-82k2027pvn.jpeg', 9, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (37, N'MSI Gaming GF63 Thin 12VE i5 12450H (460VN)', 20990000, N'images/msi-gaming-gf63-thin-12ve-i5-460vn.png', 8, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (38, N'MacBook Pro 14 inch M3 Max 2023 14-core CPU', 79990000, N'images/apple-macbook-pro-14-inch-m3-max-2023-14-core.jpeg', 1, 3, NULL, 100, 1, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:58:52.473' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (40, N'MacBook Air 15 inch M2 2023 10-core GPU', 36490000, N'images/apple-macbook-air-m2-2023-starlight.jpeg', 1, 3, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (41, N'MacBook Pro 16 inch M2 Pro 2023 19-core GPU', 58990000, N'images/macbook-pro-16-inch-m2-pro-gray.jpeg', 1, 3, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (42, N'MSI Gaming GF63 Thin 11UC i7 11800H (1228VN)', 18890000, N'images/msi-gaming-gf63-thin-11uc-i7-1228vn.jpeg', 8, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (43, N'HP Gaming VICTUS 16 e1105AX R5 6600H (7C0T0PA)', 19490000, N'images/hp-victus-16-e1105ax-r5-7c0t0pa.jpeg', 7, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (45, N'MSI Gaming Cyborg 15 A12VF i7 12650H (267VN)', 28590000, N'images/msi-gaming-cyborg-15-a12vf-i7-267vn.jpeg', 8, 2, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (46, N'Loa Bluetooth Rezo Pulse E20', 945000, N'images/loa-bluetooth-rezo-pulse-e20.jpeg', 10, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (49, N'Loa Bluetooth Rezo Home Series One', 595000, N'images/loa-bluetooth-rezo-home-series-one.jpeg', 10, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (50, N'Loa Bluetooth JBL Flip 6', 2390000, N'images/loa-bluetooth-jbl-flip-6-trang.jpeg', 11, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (52, N'Loa Bluetooth Harman Kardon SoundSticks 4', 6990000, N'images/bluetooth-harman-kardon-soundsticks-4.jpeg', 12, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (53, N'Loa Bluetooth JBL Pulse 5', 5780000, N'images/loa-bluetooth-jbl-pulse-5.jpeg', 11, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (54, N'Loa Bluetooth JBL Partybox On The Go', 5890000, N'images/jbl-partybox-on-the-go.jpeg', 11, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (55, N'Loa Bluetooth Rezo Home Series Bag', 650000, N'images/loa-bluetooth-rezo-home-series-bag.jpeg', 10, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (56, N'Loa Bluetooth Harman Kardon Aura Studio 4', 6990000, N'images/loa-bluetooth-harman-kardon-aura-studio-4.jpeg', 12, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (57, N'Loa Bluetooth JBL Xtreme 3', 5690000, N'images/loa-bluetooth-jbl-xtreme-3.jpeg', 11, 5, NULL, 100, 1, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T21:40:04.447' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (58, N'Loa Bluetooth Harman Kardon Go + Play mini', 4990000, N'images/bluetooth-harman-kardon-go-play-mini.jpeg', 12, 5, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (60, N'Samsung Galaxy Tab A9', 3990000, N'images/samsung-galaxy-tab-a9-den.jpeg', 2, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (61, N'iPad 9 Wifi', 7990000, N'images/ipad-9-wifi.jpeg', 1, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (62, N'Samsung Galaxy Tab A8', 5790000, N'images/samsung-galaxy-tab-a8.jpeg', 2, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (63, N'iPad Air 5 M1 Wifi 64GB', 14090000, N'images/ipad-air-5-wifi-grey.jpeg', 1, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (64, N'iPad 10 Wifi 64GB', 11390000, N'images/ipad-gen-10.jpeg', 1, 4, NULL, 100, 2, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-24T11:59:01.910' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (65, N'Samsung Galaxy Tab A7 Lite', 3490000, N'images/samsung-galaxy-tab-a7-lite-gray.jpg', 2, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (66, N'Lenovo Tab M9', 4390000, N'images/lenovo-tab-m8-xanh.jpeg', 9, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (67, N'Xiaomi Redmi Pad SE 4GB', 4490000, N'images/xiaomi-pad-se-xanh.jpeg', 3, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (68, N'Lenovo Tab M8 (Gen 4)', 2990000, N'images/lenovo-tab-m8-gen4.jpeg', 9, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (69, N'Oppo Pad 2', 13990000, N'images/oppo-pad-2.jpeg', 4, 4, NULL, 100, 0, CAST(N'2023-11-17T10:42:57.050' AS DateTime), CAST(N'2023-11-17T10:42:57.050' AS DateTime))
INSERT [dbo].[Product] ([Id], [Name], [Price], [Image], [ManufacturerId], [CategoryId], [Description], [Quantity], [Sold], [CreatedDate], [UpdatedDate]) VALUES (76, N'iPhone 14 Pro 128GB', 24000000, N'images/iphone-14-pro.png', 1, 1, N'Test', 90, 0, CAST(N'2023-11-25T10:52:23.517' AS DateTime), CAST(N'2023-11-26T12:58:28.873' AS DateTime))
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
ALTER TABLE [dbo].[OrderDetail] ADD  CONSTRAINT [DF_OrderDetail_Quantity]  DEFAULT ((1)) FOR [Quantity]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Customer] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Customer]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Order] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Manufacturer] FOREIGN KEY([ManufacturerId])
REFERENCES [dbo].[Manufacturer] ([Id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Manufacturer]
GO
USE [master]
GO
ALTER DATABASE [udql_inventory] SET  READ_WRITE 
GO
