/****** Object:  Database [BlueSkiesDB]    Script Date: 5/13/2023 5:27:36 PM ******/
CREATE DATABASE [BlueSkiesDB]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [BlueSkiesDB] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [BlueSkiesDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BlueSkiesDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BlueSkiesDB] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [BlueSkiesDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BlueSkiesDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BlueSkiesDB] SET  MULTI_USER 
GO
ALTER DATABASE [BlueSkiesDB] SET ENCRYPTION ON
GO
ALTER DATABASE [BlueSkiesDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [BlueSkiesDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Aircraft]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aircraft](
	[aircraft_id] [int] IDENTITY(1,1) NOT NULL,
	[aircraft_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Aircraft] PRIMARY KEY CLUSTERED 
(
	[aircraft_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DbUser]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbUser](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dropzone]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dropzone](
	[dropzone_id] [int] IDENTITY(1,1) NOT NULL,
	[dropzone_name] [nvarchar](50) NOT NULL,
	[dropzone_country] [nvarchar](100) NOT NULL,
	[dropzone_phone_number] [nvarchar](50) NOT NULL,
	[dropzone_email_address] [nvarchar](50) NULL,
	[dropzone_state] [nchar](10) NULL,
	[dropzone_city] [nchar](10) NULL,
	[dropzone_address] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Dropzone] PRIMARY KEY CLUSTERED 
(
	[dropzone_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[Equipment_id] [int] IDENTITY(1,1) NOT NULL,
	[Equipment_type] [nvarchar](50) NULL,
	[Equipment_Brand] [nvarchar](50) NULL,
	[Equipment_Model] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Equipment_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jump]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jump](
	[jump_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[weather_id] [int] NULL,
	[aircraft_id] [int] NULL,
	[equipment_id] [int] NULL,
	[dropzone_id] [int] NOT NULL,
	[jump_number] [int] NOT NULL,
	[jump_date] [datetime] NOT NULL,
	[Jump_type] [nvarchar](50) NOT NULL,
	[exit_altitude] [int] NOT NULL,
	[landing_pattern] [nvarchar](50) NOT NULL,
	[notes] [nvarchar](300) NULL,
	[total_jumpers] [int] NULL,
 CONSTRAINT [PK_Table_1_1] PRIMARY KEY CLUSTERED 
(
	[jump_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Weather]    Script Date: 5/13/2023 5:27:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Weather](
	[weather_id] [int] IDENTITY(1,1) NOT NULL,
	[ground_temperature] [nchar](10) NULL,
	[ground_wind_speed] [nchar](10) NULL,
	[additional_notes] [nvarchar](300) NULL,
	[ground_wind_direction_at_takeoff] [nchar](10) NULL,
	[ground_wind_direction_at_landing] [nchar](10) NULL,
	[temperature_at_jump_altitude] [nchar](10) NULL,
 CONSTRAINT [PK_Weather] PRIMARY KEY CLUSTERED 
(
	[weather_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Jump]  WITH CHECK ADD  CONSTRAINT [FK_Jump_Aircraft] FOREIGN KEY([aircraft_id])
REFERENCES [dbo].[Aircraft] ([aircraft_id])
GO
ALTER TABLE [dbo].[Jump] CHECK CONSTRAINT [FK_Jump_Aircraft]
GO
ALTER TABLE [dbo].[Jump]  WITH CHECK ADD  CONSTRAINT [FK_Jump_DbUser] FOREIGN KEY([user_id])
REFERENCES [dbo].[DbUser] ([user_id])
GO
ALTER TABLE [dbo].[Jump] CHECK CONSTRAINT [FK_Jump_DbUser]
GO
ALTER TABLE [dbo].[Jump]  WITH CHECK ADD  CONSTRAINT [FK_Jump_Dropzone] FOREIGN KEY([dropzone_id])
REFERENCES [dbo].[Dropzone] ([dropzone_id])
GO
ALTER TABLE [dbo].[Jump] CHECK CONSTRAINT [FK_Jump_Dropzone]
GO
ALTER TABLE [dbo].[Jump]  WITH CHECK ADD  CONSTRAINT [FK_Jump_Equipment] FOREIGN KEY([equipment_id])
REFERENCES [dbo].[Equipment] ([Equipment_id])
GO
ALTER TABLE [dbo].[Jump] CHECK CONSTRAINT [FK_Jump_Equipment]
GO
ALTER TABLE [dbo].[Jump]  WITH CHECK ADD  CONSTRAINT [FK_Jump_Weather] FOREIGN KEY([weather_id])
REFERENCES [dbo].[Weather] ([weather_id])
GO
ALTER TABLE [dbo].[Jump] CHECK CONSTRAINT [FK_Jump_Weather]
GO
ALTER DATABASE [BlueSkiesDB] SET  READ_WRITE 
GO
