USE [master]
GO
/****** Object:  Database [ElectronicDocumentArchiveManagement]    Script Date: 02.04.2023 15:58:49 ******/
CREATE DATABASE [ElectronicDocumentArchiveManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ElectronicDocumentArchiveManagement', FILENAME = N'/var/opt/mssql/data/ElectronicDocumentArchiveManagement.mdf' , SIZE = 663552KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ElectronicDocumentArchiveManagement_log', FILENAME = N'/var/opt/mssql/data/ElectronicDocumentArchiveManagement_log.ldf' , SIZE = 401408KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ElectronicDocumentArchiveManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET QUERY_STORE = OFF
GO
USE [ElectronicDocumentArchiveManagement]
GO
/****** Object:  Table [dbo].[FileInfo]    Script Date: 02.04.2023 15:58:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](400) NOT NULL,
	[Description] [nvarchar](400) NOT NULL,
	[Size] [decimal](10, 2) NOT NULL,
	[Created] [datetime2](7) NOT NULL,
	[Expression] [varbinary](max) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[AccessLevelId] [int] NOT NULL,
	[ShareLink] [nvarchar](150) NOT NULL,
	[IsPinned] [bit] NOT NULL,
 CONSTRAINT [PK_FileInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[GuestFileInfo]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[GuestFileInfo]
AS
SELECT        Id, Title, Description, Created, ShareLink, AccessLevelId, IsPinned
FROM            dbo.FileInfo
GO
/****** Object:  Table [dbo].[Category]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Description]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Description](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Information] [nvarchar](400) NOT NULL,
	[FileInfoId] [int] NOT NULL,
 CONSTRAINT [PK_Description] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FileAccessLevel]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FileAccessLevel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_FileAccessLevel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilterStorage]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilterStorage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileInfoId] [int] NOT NULL,
	[Keyword] [nvarchar](300) NOT NULL,
	[DescriptionId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[TextSearchingId] [int] NOT NULL,
	[IndexSearching] [int] NOT NULL,
 CONSTRAINT [PK_FilterStorage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TextSearching]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TextSearching](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](400) NOT NULL,
 CONSTRAINT [PK_TextSearching] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](150) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Registered] [datetime2](7) NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserFile]    Script Date: 02.04.2023 15:58:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FileInfoId] [int] NOT NULL,
	[DateUpload] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StorageHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Description]  WITH CHECK ADD  CONSTRAINT [FK_Description_FileInfo] FOREIGN KEY([FileInfoId])
REFERENCES [dbo].[FileInfo] ([Id])
GO
ALTER TABLE [dbo].[Description] CHECK CONSTRAINT [FK_Description_FileInfo]
GO
ALTER TABLE [dbo].[FileInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileInfo_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[FileInfo] CHECK CONSTRAINT [FK_FileInfo_Category]
GO
ALTER TABLE [dbo].[FileInfo]  WITH CHECK ADD  CONSTRAINT [FK_FileInfo_FileAccessLevel] FOREIGN KEY([AccessLevelId])
REFERENCES [dbo].[FileAccessLevel] ([Id])
GO
ALTER TABLE [dbo].[FileInfo] CHECK CONSTRAINT [FK_FileInfo_FileAccessLevel]
GO
ALTER TABLE [dbo].[FilterStorage]  WITH CHECK ADD  CONSTRAINT [FK_FilterStorage_Description] FOREIGN KEY([DescriptionId])
REFERENCES [dbo].[Description] ([Id])
GO
ALTER TABLE [dbo].[FilterStorage] CHECK CONSTRAINT [FK_FilterStorage_Description]
GO
ALTER TABLE [dbo].[FilterStorage]  WITH CHECK ADD  CONSTRAINT [FK_FilterStorage_FileInfo] FOREIGN KEY([FileInfoId])
REFERENCES [dbo].[FileInfo] ([Id])
GO
ALTER TABLE [dbo].[FilterStorage] CHECK CONSTRAINT [FK_FilterStorage_FileInfo]
GO
ALTER TABLE [dbo].[FilterStorage]  WITH CHECK ADD  CONSTRAINT [FK_FilterStorage_TextSearching] FOREIGN KEY([TextSearchingId])
REFERENCES [dbo].[TextSearching] ([Id])
GO
ALTER TABLE [dbo].[FilterStorage] CHECK CONSTRAINT [FK_FilterStorage_TextSearching]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[UserFile]  WITH CHECK ADD  CONSTRAINT [FK_StorageHistory_FileInfo] FOREIGN KEY([FileInfoId])
REFERENCES [dbo].[FileInfo] ([Id])
GO
ALTER TABLE [dbo].[UserFile] CHECK CONSTRAINT [FK_StorageHistory_FileInfo]
GO
ALTER TABLE [dbo].[UserFile]  WITH CHECK ADD  CONSTRAINT [FK_StorageHistory_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserFile] CHECK CONSTRAINT [FK_StorageHistory_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[34] 4[25] 2[7] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1[50] 2[25] 3) )"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "FileInfo"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 226
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 8865
         Width = 1500
         Width = 2535
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1815
         Alias = 900
         Table = 1170
         Output = 1350
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 855
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GuestFileInfo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'GuestFileInfo'
GO
USE [master]
GO
ALTER DATABASE [ElectronicDocumentArchiveManagement] SET  READ_WRITE 
GO
