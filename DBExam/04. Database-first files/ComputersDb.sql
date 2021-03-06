USE [master]
GO
/****** Object:  Database [Computers]    Script Date: 11/8/2016 2:07:39 PM ******/
CREATE DATABASE [Computers]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Computers', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Computers.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Computers_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Computers_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Computers] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Computers].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Computers] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Computers] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Computers] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Computers] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Computers] SET ARITHABORT OFF 
GO
ALTER DATABASE [Computers] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Computers] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Computers] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Computers] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Computers] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Computers] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Computers] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Computers] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Computers] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Computers] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Computers] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Computers] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Computers] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Computers] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Computers] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Computers] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Computers] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Computers] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Computers] SET  MULTI_USER 
GO
ALTER DATABASE [Computers] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Computers] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Computers] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Computers] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Computers] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Computers]
GO
/****** Object:  Table [dbo].[Computers]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Computers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ComputerTypeId] [int] NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[CPUId] [int] NOT NULL,
	[Memory] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Computers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersGPU]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersGPU](
	[ComputerId] [int] NOT NULL,
	[GPUId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersGPU] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[GPUId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputersStorageDevices]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputersStorageDevices](
	[ComputerId] [int] NOT NULL,
	[StorageDeviceId] [int] NOT NULL,
 CONSTRAINT [PK_ComputersStorageDevices] PRIMARY KEY CLUSTERED 
(
	[ComputerId] ASC,
	[StorageDeviceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComputerTypes]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComputerTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ComputerTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CPU]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CPU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[NumberOfCores] [int] NOT NULL,
	[ClockCycles] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CPU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GPU]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPU](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[GPUTypeId] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Memory] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GPU] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GPUTypes]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GPUTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_GPUTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDevices]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDevices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Vendor] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[StorageDeviceTypeId] [int] NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageDevices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StorageDeviceTypes]    Script Date: 11/8/2016 2:07:39 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageDeviceTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_StorageDeviceTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_ComputerTypes] FOREIGN KEY([ComputerTypeId])
REFERENCES [dbo].[ComputerTypes] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_ComputerTypes]
GO
ALTER TABLE [dbo].[Computers]  WITH CHECK ADD  CONSTRAINT [FK_Computers_CPU] FOREIGN KEY([CPUId])
REFERENCES [dbo].[CPU] ([Id])
GO
ALTER TABLE [dbo].[Computers] CHECK CONSTRAINT [FK_Computers_CPU]
GO
ALTER TABLE [dbo].[ComputersGPU]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGPU_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersGPU] CHECK CONSTRAINT [FK_ComputersGPU_Computers]
GO
ALTER TABLE [dbo].[ComputersGPU]  WITH CHECK ADD  CONSTRAINT [FK_ComputersGPU_GPU] FOREIGN KEY([GPUId])
REFERENCES [dbo].[GPU] ([Id])
GO
ALTER TABLE [dbo].[ComputersGPU] CHECK CONSTRAINT [FK_ComputersGPU_GPU]
GO
ALTER TABLE [dbo].[ComputersStorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorageDevices_Computers] FOREIGN KEY([ComputerId])
REFERENCES [dbo].[Computers] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorageDevices] CHECK CONSTRAINT [FK_ComputersStorageDevices_Computers]
GO
ALTER TABLE [dbo].[ComputersStorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_ComputersStorageDevices_StorageDevices] FOREIGN KEY([StorageDeviceId])
REFERENCES [dbo].[StorageDevices] ([Id])
GO
ALTER TABLE [dbo].[ComputersStorageDevices] CHECK CONSTRAINT [FK_ComputersStorageDevices_StorageDevices]
GO
ALTER TABLE [dbo].[GPU]  WITH CHECK ADD  CONSTRAINT [FK_GPU_GPUTypes] FOREIGN KEY([GPUTypeId])
REFERENCES [dbo].[GPUTypes] ([Id])
GO
ALTER TABLE [dbo].[GPU] CHECK CONSTRAINT [FK_GPU_GPUTypes]
GO
ALTER TABLE [dbo].[StorageDevices]  WITH CHECK ADD  CONSTRAINT [FK_StorageDevices_StorageDeviceTypes] FOREIGN KEY([StorageDeviceTypeId])
REFERENCES [dbo].[StorageDeviceTypes] ([Id])
GO
ALTER TABLE [dbo].[StorageDevices] CHECK CONSTRAINT [FK_StorageDevices_StorageDeviceTypes]
GO
USE [master]
GO
ALTER DATABASE [Computers] SET  READ_WRITE 
GO
