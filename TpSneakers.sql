USE [master]
GO
/****** Object:  Database [SNEAKERS]    Script Date: 29/10/2022 20:10:29 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 29/10/2022 20:10:29 ******/
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
/****** Object:  Table [dbo].[Productos]    Script Date: 29/10/2022 20:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Foto] [varchar](200) NOT NULL,
	[FK_marca] [int] NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 29/10/2022 20:10:29 ******/
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
/****** Object:  Table [dbo].[UsuarioxProducto]    Script Date: 29/10/2022 20:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsuarioxProducto](
	[ID_USUARIO] [int] NULL,
	[ID_PRODUCTO] [int] NULL
) ON [PRIMARY]
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
GO
ALTER TABLE [dbo].[UsuarioxProducto] CHECK CONSTRAINT [FK_UsuarioxProducto_Productos]
GO
ALTER TABLE [dbo].[UsuarioxProducto]  WITH CHECK ADD  CONSTRAINT [FK_UsuarioxProducto_Usuario] FOREIGN KEY([ID_USUARIO])
REFERENCES [dbo].[Usuario] ([ID_USUARIO])
GO
ALTER TABLE [dbo].[UsuarioxProducto] CHECK CONSTRAINT [FK_UsuarioxProducto_Usuario]
GO
USE [master]
GO
ALTER DATABASE [SNEAKERS] SET  READ_WRITE 
GO
