USE [master]
GO
/****** Object:  Database [SNEAKERS]    Script Date: 6/11/2022 20:03:48 ******/
CREATE DATABASE [SNEAKERS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SNEAKERS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SNEAKERS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SNEAKERS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\SNEAKERS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SNEAKERS] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SNEAKERS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SNEAKERS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SNEAKERS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SNEAKERS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SNEAKERS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SNEAKERS] SET ARITHABORT OFF 
GO
ALTER DATABASE [SNEAKERS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SNEAKERS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SNEAKERS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SNEAKERS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SNEAKERS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SNEAKERS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SNEAKERS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SNEAKERS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SNEAKERS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SNEAKERS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SNEAKERS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SNEAKERS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SNEAKERS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SNEAKERS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SNEAKERS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SNEAKERS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SNEAKERS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SNEAKERS] SET RECOVERY FULL 
GO
ALTER DATABASE [SNEAKERS] SET  MULTI_USER 
GO
ALTER DATABASE [SNEAKERS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SNEAKERS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SNEAKERS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SNEAKERS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SNEAKERS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SNEAKERS] SET QUERY_STORE = OFF
GO
USE [SNEAKERS]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 6/11/2022 20:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[ID_MARCA] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[Fundadores] [varchar](50) NOT NULL,
	[FechaFundacion] [date] NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[ID_MARCA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 6/11/2022 20:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[FK_marca] [int] NOT NULL,
	[Precio] [float] NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 6/11/2022 20:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsuarioxProducto]    Script Date: 6/11/2022 20:03:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioxProducto](
	[ID_USUARIO] [int] NULL,
	[ID_PRODUCTO] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([ID_MARCA], [Nombre], [Foto], [Fundadores], [FechaFundacion]) VALUES (2, N'ADIDAS', N'https://upload.wikimedia.org/wikipedia/commons/e/ee/Logo_brand_Adidas.png', N'Adolf Dassler', CAST(N'1949-08-18' AS Date))
INSERT [dbo].[Marca] ([ID_MARCA], [Nombre], [Foto], [Fundadores], [FechaFundacion]) VALUES (3, N'NIKE', N'https://s3-symbol-logo.tradingview.com/nike--600.png', N' Phil Knight', CAST(N'1964-01-25' AS Date))
INSERT [dbo].[Marca] ([ID_MARCA], [Nombre], [Foto], [Fundadores], [FechaFundacion]) VALUES (6, N'New balance', N'https://i.pinimg.com/originals/c3/3b/6e/c33b6e5f7e412a03d85c0a8436bb6c5a.jpg', N'William J. Riley', CAST(N'1906-04-27' AS Date))
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Productos] ON 

INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (9, N'Adidas Forum low 84', N'https://assets.adidas.com/images/h_840,f_auto,q_auto,fl_lossy,c_fill,g_auto/32b77696a6ed419fa0e0ad510115c306_9366/Zapatillas_Forum_84_Low_Blanco_GX4536_01_standard.jpg', 2, 80)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (10, N'Nike Blazer Low 77 Jumbo', N'https://d3ugyf2ht6aenh.cloudfront.net/stores/001/075/480/products/zapatillas-nike-blazer-low-77-jumbo-dn2158-1011-aeb2fa0ac7739120e316541834537194-1024-1024.jpg', 3, 70)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (11, N'Nike Blazer Low 77 Jumbo Variant', N'https://d3ugyf2ht6aenh.cloudfront.net/stores/001/075/480/products/zapatillas-nike-blazer-low-77-jumbo-dn2158-101-11-cc3b91392aed69bdc716541834537953-1024-1024.jpg', 3, 61)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (12, N'Nike Blazer Low 77 Jumbo Stairway', N'https://static.nike.com/a/images/t_default/08397e35-adbe-4ee4-b00f-9f346af837e1/blazer-low-77-jumbo-womens-shoes-PdFBP1.png', 3, 12)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (13, N'Jordan Retro Low OG', N'https://images.stockx.com/images/Air-Jordan-1-Retro-Low-OG-Black-Dark-Powder-Blue-GS.jpg?fit=fill&bg=FFFFFF&w=576&h=384&fm=avif&auto=compress&dpr=1&trim=color&updated_at=1663002910&q=57', 3, 153)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (15, N'
Nike Air Force 1 Pixel Leopard', N'https://sneakerbardetroit.com/wp-content/uploads/2020/11/Nike-Air-Force-1-Pixel-Leopard-CV8481-100-Release-Date-1.jpg', 3, 135)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (16, N'Air Jordan Mid ', N'https://images.stockx.com/images/Air-Air-Jordan-1-Mid-Neutral-Grey-GS.jpg?fit=fill&bg=FFFFFF&w=576&h=384&fm=avif&auto=compress&dpr=1&trim=color&updated_at=1658909529&q=57', 3, 12)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (17, N'New Balance 550', N'https://www.thenextsole.com/storage/images/BB550HL1.png', 6, 150)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (18, N'New Balance 550 Cream/Black', N'https://image-cdn.hypb.st/https%3A%2F%2Fhypebeast.com%2Fwp-content%2Fblogs.dir%2F6%2Ffiles%2F2022%2F03%2Fnew-balance-550-white-black-BB550LWT-release-date-1.jpg?q=75&w=800&cbr=1&fit=max', 6, 130)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (19, N'New Balance 574', N'https://www.newbalance.com.ar/media/catalog/product/cache/4/image/700x538.46153846154/9df78eab33525d08d6e5fb8d27136e95/z/a/zapatillas-hombre-new-balance-574-ml574es2_nb_02_i_1.jpg', 6, 80)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (20, N'Adidas Ozweego', N'https://www.moov.com.ar/on/demandware.static/-/Sites-dabra-catalog/default/dw1a22bfb3/products/AD_EG6697/AD_EG6697-1.JPG', 2, 75)
INSERT [dbo].[Productos] ([ID_Producto], [Nombre], [Foto], [FK_marca], [Precio]) VALUES (21, N'Adidas Ozelia', N'https://newsport.vteximg.com.br/arquivos/ids/13386316-1000-1000/GX3254-A.jpg?v=637869231714330000', 2, 100)
SET IDENTITY_INSERT [dbo].[Productos] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID_USUARIO], [Nombre]) VALUES (1, N'BINKER')
INSERT [dbo].[Usuario] ([ID_USUARIO], [Nombre]) VALUES (2, N'doff')
INSERT [dbo].[Usuario] ([ID_USUARIO], [Nombre]) VALUES (4, N'lolo')
INSERT [dbo].[Usuario] ([ID_USUARIO], [Nombre]) VALUES (15, N'maceira')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[Productos]  WITH NOCHECK ADD  CONSTRAINT [FK_Productos_Marca] FOREIGN KEY([FK_marca])
REFERENCES [dbo].[Marca] ([ID_MARCA])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Productos] NOCHECK CONSTRAINT [FK_Productos_Marca]
GO
ALTER TABLE [dbo].[UsuarioxProducto]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioxProducto_Productos] FOREIGN KEY([ID_PRODUCTO])
REFERENCES [dbo].[Productos] ([ID_Producto])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioxProducto] CHECK CONSTRAINT [FK_UsuarioxProducto_Productos]
GO
ALTER TABLE [dbo].[UsuarioxProducto]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioxProducto_Usuario] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[Usuario] ([ID_USUARIO])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UsuarioxProducto] CHECK CONSTRAINT [FK_UsuarioxProducto_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SNEAKERS] SET  READ_WRITE 
GO
