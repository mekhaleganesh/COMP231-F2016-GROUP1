USE [master]
GO
if exists (select * from sysdatabases where name='HexylogyDB')
		drop database HexylogyDB
/****** Object:  Database [HexylogyDB]    Script Date: 2016-10-28 오전 1:41:47 ******/
CREATE DATABASE [HexylogyDB]
ALTER DATABASE HexylogyDB MODIFY FILE
( NAME = N'HexylogyDB', SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
ALTER DATABASE HexylogyDB MODIFY FILE
( NAME = N'HexylogyDB_log', SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [HexylogyDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HexylogyDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HexylogyDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HexylogyDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HexylogyDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HexylogyDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HexylogyDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HexylogyDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HexylogyDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HexylogyDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HexylogyDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HexylogyDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HexylogyDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HexylogyDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HexylogyDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HexylogyDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HexylogyDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HexylogyDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HexylogyDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HexylogyDB] SET RECOVERY FULL 
GO
ALTER DATABASE [HexylogyDB] SET  MULTI_USER 
GO
ALTER DATABASE [HexylogyDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HexylogyDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HexylogyDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HexylogyDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HexylogyDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HexylogyDB]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NOT NULL,
	[UserAccountID] [int]  NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserAccount]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserAccount](
	[UserAccountID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[SecurityType] [int] NULL,
	[SecurityQuestion] [varchar](50) NULL,
	[SecurityAnswer] [varchar](50) NULL,
	[KPI] [varchar](50) NULL,
 CONSTRAINT [PK_UserAccount] PRIMARY KEY CLUSTERED 
(
	[UserAccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRecord]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserRecord](
	[RecordID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[UserPassword] [varchar](max) NULL,
	[Note] [varchar](50) NULL,
	[UserAccountID] [int] NULL,
 CONSTRAINT [PK_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserRecordCategories]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRecordCategories](
	[RecordID] [int] NOT NULL,
	[CategoryID] [int] NOT NULL,
 CONSTRAINT [PK_UserRecordCategories_UserRecord] PRIMARY KEY CLUSTERED 
(
	[RecordID] ASC,
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryID], [CategoryName],[UserAccountID]) VALUES (1, N'Centennial',1)
INSERT [dbo].[Categories] ([CategoryID], [CategoryName],[UserAccountID]) VALUES (2, N'Google',1)
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[UserAccount] ON 

INSERT [dbo].[UserAccount] ([UserAccountID], [Name], [Password], [SecurityType], [SecurityQuestion], [SecurityAnswer], [KPI]) VALUES (1, N'Hexalogy', N'admin', 0, N'Who is our master', N'Taera', N'')
SET IDENTITY_INSERT [dbo].[UserAccount] OFF
SET IDENTITY_INSERT [dbo].[UserRecord] ON 

INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (1, N'Westboro', N'PW1', N'Note 1', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (2, N'Ryan', N'PW2', N'Note 2', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (3, N'Giho', N'PW3', N'Note 3', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (4, N'Taera', N'PW4', N'Note 4', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (5, N'Dom', N'PW5', N'Note 5', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (6, N'Mekhal', N'PW6', N'Note 6', 1)
INSERT [dbo].[UserRecord] ([RecordID], [UserName], [UserPassword], [Note], [UserAccountID]) VALUES (7, N'Partik', N'PW7', N'Note 7', 1)
SET IDENTITY_INSERT [dbo].[UserRecord] OFF
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (1, 1)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (1, 2)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (2, 1)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (3, 1)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (3, 2)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (4, 2)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (5, 1)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (5, 2)
INSERT [dbo].[UserRecordCategories] ([RecordID], [CategoryID]) VALUES (7, 1)
ALTER TABLE [dbo].[Categories] WITH CHECK ADD CONSTRAINT [FK_Categories_UserAccount] FOREIGN KEY ([UserAccountID])
REFERENCES [dbo].[UserAccount] ([UserAccountID])
ALTER TABLE [dbo].[UserRecord]  WITH CHECK ADD  CONSTRAINT [FK_UserRecord_UserAccount] FOREIGN KEY([UserAccountID])
REFERENCES [dbo].[UserAccount] ([UserAccountID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRecord] CHECK CONSTRAINT [FK_UserRecord_UserAccount]
GO
ALTER TABLE [dbo].[UserRecordCategories]  WITH CHECK ADD  CONSTRAINT [FK_UserRecordCategories_Categories] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Categories] ([CategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRecordCategories] CHECK CONSTRAINT [FK_UserRecordCategories_Categories]
GO
ALTER TABLE [dbo].[UserRecordCategories]  WITH CHECK ADD  CONSTRAINT [FK_UserRecordCategories_UserRecord] FOREIGN KEY([RecordID])
REFERENCES [dbo].[UserRecord] ([RecordID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRecordCategories] CHECK CONSTRAINT [FK_UserRecordCategories_UserRecord]
GO
ALTER TABLE [dbo].[UserAccount]  WITH CHECK ADD  CONSTRAINT [SecurityType] CHECK  (([SecurityType]>=(0) AND [SecurityType]<=(1)))
GO
ALTER TABLE [dbo].[UserAccount] CHECK CONSTRAINT [SecurityType]
GO
/****** Object:  StoredProcedure [dbo].[AddNewCateogry]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<GihoKim>
-- Create date: <2016-10-25>
-- Description:	<Create category>
-- =============================================
CREATE PROCEDURE [dbo].[AddNewCateogry]
	@getCategoryName NVARCHAR(50)
AS
BEGIN
	INSERT INTO Categories(CategoryName) VALUES(@getCategoryName);
END

GO
/****** Object:  StoredProcedure [dbo].[AddRecord]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<GihoKim>
-- Create date: <2016-10-22>
-- Description:	<This query is to save records>
-- =============================================
CREATE PROCEDURE [dbo].[AddRecord]
	(
	@categoryName NVARCHAR(50),
	@id NVARCHAR(50),
	@pw NVARCHAR(50),
	@note NVARCHAR(50)
	)
AS
DECLARE @checkID int
EXEC createDataOnUserRecord @id,@pw,@note
INSERT INTO UserRecordCategories(RecordID,CategoryID) VALUES 
(
	(SELECT RecordID FROM UserRecord WHERE 
		RecordID = (SELECT RecordID FROM UserRecord 
			WHERE RecordID=
				(SELECT MAX(RecordID) FROM UserRecord))
	),
	(SELECT CategoryID FROM Categories WHERE CategoryName = @categoryName)
);
RETURN

GO
/****** Object:  StoredProcedure [dbo].[createDataOnUserRecord]    Script Date: 2016-10-28 오전 1:41:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<GihoKim>
-- Create date: <2016-10-25>
-- Description:	<Stroing Name,Password and Note>
-- =============================================
CREATE PROCEDURE [dbo].[createDataOnUserRecord]
	(
	@id NVARCHAR(50),
	@pw NVARCHAR(50),
	@note NVARCHAR(50)
	)
AS
IF (
	(SELECT COUNT(*) FROM UserRecord WHERE UserName = @id AND PWDCOMPARE(@pw, UserPassword) = 1) = 0 
	 AND 
	 (ISNULL(@id, '') != '' AND ISNULL(@pw, '') != '')
	)
BEGIN
INSERT INTO UserRecord(UserName,UserPassword,Note,UserAccountID) VALUES (@id, PWDENCRYPT(@pw),@note,1);
SELECT 'ADD SUCCESSFUL';
END
ELSE BEGIN
	SELECT 'ADD FAILED';
END
RETURN

GO
USE [master]
GO
ALTER DATABASE [HexylogyDB] SET  READ_WRITE 
GO
