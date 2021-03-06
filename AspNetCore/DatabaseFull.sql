USE [master]
GO
/****** Object:  Database [ConferenceRoomBooking ]    Script Date: 08-02-2019 17:15:07 ******/
CREATE DATABASE [ConferenceRoomBooking ] ON  PRIMARY 
( NAME = N'ConferenceRoomBooking', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ConferenceRoomBooking .mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ConferenceRoomBooking _log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\ConferenceRoomBooking _log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ConferenceRoomBooking ] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ConferenceRoomBooking ].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ARITHABORT OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET  MULTI_USER 
GO
ALTER DATABASE [ConferenceRoomBooking ] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ConferenceRoomBooking ] SET DB_CHAINING OFF 
GO
USE [ConferenceRoomBooking ]
GO
/****** Object:  Table [dbo].[BookingHistory]    Script Date: 08-02-2019 17:15:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingHistory](
	[BookingId] [bigint] IDENTITY(1,1) NOT NULL,
	[BookedByUserId] [bigint] NULL,
	[BookedRoomId] [bigint] NULL,
	[DurationFrom] [datetime] NOT NULL,
	[DurationTo] [datetime] NOT NULL,
	[BookedStatus] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[MeetinName] [nvarchar](500) NULL,
 CONSTRAINT [PK_BookingHistory] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 08-02-2019 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[RoomId] [bigint] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](100) NULL,
	[RoomStatus] [bigint] NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_Rooms] PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 08-02-2019 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[StatusId] [bigint] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](100) NULL,
	[StatusDetails] [nvarchar](1000) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 08-02-2019 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](500) NULL,
	[EmailId] [nvarchar](500) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookingHistory] ON 
GO
INSERT [dbo].[BookingHistory] ([BookingId], [BookedByUserId], [BookedRoomId], [DurationFrom], [DurationTo], [BookedStatus], [CreatedDate], [MeetinName]) VALUES (3, 1, 1, CAST(N'2019-02-08T09:30:00.000' AS DateTime), CAST(N'2019-02-08T10:30:00.000' AS DateTime), 4, CAST(N'2019-02-08T09:26:01.333' AS DateTime), N'Security Check')
GO
INSERT [dbo].[BookingHistory] ([BookingId], [BookedByUserId], [BookedRoomId], [DurationFrom], [DurationTo], [BookedStatus], [CreatedDate], [MeetinName]) VALUES (4, 2, 3, CAST(N'2019-02-08T10:00:00.000' AS DateTime), CAST(N'2019-02-08T10:30:00.000' AS DateTime), 4, CAST(N'2019-02-08T09:26:31.513' AS DateTime), N'Status Meeting')
GO
SET IDENTITY_INSERT [dbo].[BookingHistory] OFF
GO
SET IDENTITY_INSERT [dbo].[Rooms] ON 
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (1, N'Meeting Room 1', 1, CAST(N'2019-02-08T09:14:40.330' AS DateTime), NULL)
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (2, N'Meeting Room 2', 1, CAST(N'2019-02-08T09:14:44.853' AS DateTime), NULL)
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (3, N'Meeting Room 3', 1, CAST(N'2019-02-08T09:14:48.623' AS DateTime), NULL)
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (4, N'Meeting Room 4', 1, CAST(N'2019-02-08T09:14:51.933' AS DateTime), NULL)
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (5, N'Meeting Room 5', 1, CAST(N'2019-02-08T09:14:56.303' AS DateTime), NULL)
GO
INSERT [dbo].[Rooms] ([RoomId], [RoomName], [RoomStatus], [CreatedDate], [UpdatedDate]) VALUES (6, N'Meeting Room 6', 1, CAST(N'2019-02-08T09:15:02.160' AS DateTime), NULL)
GO
SET IDENTITY_INSERT [dbo].[Rooms] OFF
GO
SET IDENTITY_INSERT [dbo].[Status] ON 
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (1, N'Active', N'Active ')
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (2, N'Inactive', N'Inactive')
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (3, N'RoomAvailable', N'Room Free')
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (4, N'RoomBooked', N'Room Booked')
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (5, N'MeetingInprograss', N'Meeting Inprograss')
GO
INSERT [dbo].[Status] ([StatusId], [StatusName], [StatusDetails]) VALUES (6, N'Meeting End', N'Meeting End')
GO
SET IDENTITY_INSERT [dbo].[Status] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([UserId], [UserName], [EmailId], [Status], [CreatedDate]) VALUES (1, N'TestUser1', N'TestUser1@yopmail.com', 1, CAST(N'2019-02-08T08:47:13.597' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [UserName], [EmailId], [Status], [CreatedDate]) VALUES (2, N'TestUser2', N'TestUser2@yopmail.com', 1, CAST(N'2019-02-08T09:15:37.903' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [UserName], [EmailId], [Status], [CreatedDate]) VALUES (3, N'TestUser3', N'TestUser3@yopmail.com', 1, CAST(N'2019-02-08T09:16:25.747' AS DateTime))
GO
INSERT [dbo].[Users] ([UserId], [UserName], [EmailId], [Status], [CreatedDate]) VALUES (5, N'Test6', N'Test@yopmail.com', 1, CAST(N'2019-02-08T11:31:54.983' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[BookingHistory] ADD  CONSTRAINT [DF_BookingHistory_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Rooms] ADD  CONSTRAINT [DF_Rooms_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_Status]  DEFAULT ((1)) FOR [Status]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_CreatedDate]  DEFAULT (getutcdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[BookingHistory]  WITH CHECK ADD  CONSTRAINT [FK_BookingHistory_Rooms] FOREIGN KEY([BookedRoomId])
REFERENCES [dbo].[Rooms] ([RoomId])
GO
ALTER TABLE [dbo].[BookingHistory] CHECK CONSTRAINT [FK_BookingHistory_Rooms]
GO
ALTER TABLE [dbo].[BookingHistory]  WITH CHECK ADD  CONSTRAINT [FK_BookingHistory_Status] FOREIGN KEY([BookedStatus])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[BookingHistory] CHECK CONSTRAINT [FK_BookingHistory_Status]
GO
ALTER TABLE [dbo].[BookingHistory]  WITH CHECK ADD  CONSTRAINT [FK_BookingHistory_Users] FOREIGN KEY([BookedByUserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[BookingHistory] CHECK CONSTRAINT [FK_BookingHistory_Users]
GO
ALTER TABLE [dbo].[Rooms]  WITH CHECK ADD  CONSTRAINT [FK_Rooms_Status] FOREIGN KEY([RoomStatus])
REFERENCES [dbo].[Status] ([StatusId])
GO
ALTER TABLE [dbo].[Rooms] CHECK CONSTRAINT [FK_Rooms_Status]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckRoomAvialable]    Script Date: 08-02-2019 17:15:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_CheckRoomAvialable]
	-- Add the parameters for the stored procedure here
	@BookingTimeIn DateTime	,
	@BookingTimeOut DateTime	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON; 

	  SELECT  
			R.*
      FROM 
			[ConferenceRoomBooking ].[dbo].[BookingHistory] BH
			RIGHT JOIN Rooms R ON BH.[BookedRoomId]=R.RoomId
      WHERE
			 DurationFrom IS NULL OR 
		     ((@BookingTimeIn < DurationFrom OR @BookingTimeIn > DurationTo)
			   AND
		     (@BookingTimeOut <DurationFrom 	OR	@BookingTimeOut > DurationTo))
END
GO
USE [master]
GO
ALTER DATABASE [ConferenceRoomBooking ] SET  READ_WRITE 
GO
