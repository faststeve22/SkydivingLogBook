/****** Object:  Database [BlueSkiesDB]    Script Date: 5/26/2023 7:24:58 PM ******/
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
/****** Object:  Table [dbo].[Aircraft]    Script Date: 5/26/2023 7:24:58 PM ******/
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
/****** Object:  Table [dbo].[DbUser]    Script Date: 5/26/2023 7:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DbUser](
	[user_id] [int] NOT NULL,
	[username] [nvarchar](50) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[email_address] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__DbUser__B9BE370F7E391A09] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dropzone]    Script Date: 5/26/2023 7:24:58 PM ******/
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
	[dropzone_state] [nvarchar](50) NULL,
	[dropzone_city] [nvarchar](50) NULL,
	[dropzone_address] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Dropzone] PRIMARY KEY CLUSTERED 
(
	[dropzone_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipment]    Script Date: 5/26/2023 7:24:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipment](
	[equipment_id] [int] IDENTITY(1,1) NOT NULL,
	[equipment_type] [nvarchar](50) NULL,
	[equipment_brand] [nvarchar](50) NULL,
	[equipment_model] [nvarchar](50) NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[equipment_id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jump]    Script Date: 5/26/2023 7:24:58 PM ******/
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
/****** Object:  Table [dbo].[Weather]    Script Date: 5/26/2023 7:24:58 PM ******/
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
SET IDENTITY_INSERT [dbo].[Aircraft] ON 

INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (1, N'Cessna 182')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (2, N'Cessna 206')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (3, N'Cessna 208 Caravan')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (4, N'De Havilland Twin Otter')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (5, N'Pilatus Porter PC-6')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (6, N'Short SC.7 Skyvan')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (7, N'PAC P-750 XSTOL')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (8, N'Beechcraft King Air')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (9, N'Douglas DC-3')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (10, N'Britten-Norman BN-2 Islander')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (11, N'CASA C-212 Aviocar')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (12, N'GAF Nomad')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (13, N'Pilatus PC-9')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (14, N'Beechcraft Super King Air')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (15, N'Fairchild Swearingen Metroliner')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (16, N'Britten-Norman Trislander')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (17, N'Antonov An-2')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (18, N'Antonov An-28')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (19, N'Dornier Do 28')
INSERT [dbo].[Aircraft] ([aircraft_id], [aircraft_name]) VALUES (20, N'Let L-410 Turbolet')
SET IDENTITY_INSERT [dbo].[Aircraft] OFF
GO
INSERT [dbo].[DbUser] ([user_id], [username], [first_name], [last_name], [email_address]) VALUES (66, N'faststeve419', N'string', N'string', N'faststeve417@gmail.com')
GO
SET IDENTITY_INSERT [dbo].[Dropzone] ON 

INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (1, N'Skydive Arizona', N'United States', N'+1 520-466-3753', N'info@skydiveaz.com', N'Arizona', N'Eloy', N'4900 N Taylor St, Eloy, AZ 85131')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (3, N'Skydive Paris', N'United States', N'+1 951-657-3904', N'info@skydiveparis.com', N'California', N'Paris', N'2091 Goetz Rd, Perris, CA 92570')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (4, N'Skydive Chicago', N'United States', N'+1 815-433-0000', N'info@skydivechicago.com', N'Illinois', N'Ottawa', N'3215 E 1969th Rd, Ottawa, IL 61350')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (5, N'Skydive City', N'United States', N'+1 800-888-5867', N'info@skydivecity.com', N'Florida', N'Zephyrhills', N'4241 Sky Dive Ln, Zephyrhills, FL 33542')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (6, N'Skydive DeLand', N'United States', N'+1 386-738-3539', N'info@skydivedeland.com', N'Florida', N'DeLand', N'1600 Flightline Blvd, DeLand, FL 32724')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (7, N'Skydive Spaceland', N'United States', N'+1 281-369-3337', N'info@houston.skydivespaceland.com', N'Texas', N'Rosharon', N'16111 FM 521 Rd, Rosharon, TX 77583')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (10, N'Skydive Cross Keys', N'United States', N'+1 856-629-7553', N'info@skydivecrosskeys.com', N'New Jersey', N'Williamstown', N'300 Dahlia Ave, Williamstown, NJ 08094')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (11, N'Skydive Twin Cities', N'United States', N'+1 715-684-3416', N'info@skydivetwincities.com', N'Wisconsin', N'Baldwin', N'2026 County Rd J, Baldwin, WI 54002')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (12, N'Skydive Santa Barbara', N'United States', N'+1 805-740-9099', N'info@skydivesantabarbara.com', N'California', N'Lompoc', N'1801 N H St, Lompoc, CA 93436')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (13, N'Skydive San Diego', N'United States', N'+1 619-216-8416', N'info@skydivesandiego.com', N'California', N'Jamul', N'13531 Otay Lakes Rd, Jamul, CA 91935')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (16, N'Skydive Midwest', N'United States', N'+1 262-886-3480', N'info@skydivemidwest.com', N'Wisconsin', N'Sturtevant', N'13851 56th Rd, Sturtevant, WI 53177')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (17, N'Skydive Miami', N'United States', N'+1 305-759-3483', N'info@skydivemiami.com', N'Florida', N'Homestead', N'28730 SW 217th Ave, Homestead, FL 33030')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (19, N'Skydive Dallas', N'United States', N'+1 903-364-5103', N'info@skydivedallas.com', N'Texas', N'Whitewright', N'1039 Private Rd 438, Whitewright, TX 75491')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (21, N'Skydive Atlanta', N'United States', N'+1 770-614-3482', N'info@skydiveatlanta.com', N'Georgia', N'Thomaston', N'2333 Delray Rd, Thomaston, GA 30286')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (22, N'Skydive Pennsylvania', N'United States', N'+1 800-909-5867', N'info@skydivepa.com', N'Pennsylvania', N'Mercer', N'496 Glider Rd, Mercer, PA 16137')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (23, N'Skydive Snohomish', N'United States', N'+1 360-568-7703', N'info@skydivesnohomish.com', N'Washington', N'Snohomish', N'9900 Airport Way, Snohomish, WA 98296')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (24, N'Skydive Kapowsin', N'United States', N'+1 360-432-8000', N'info@skydivekapowsin.com', N'Washington', N'Shelton', N'141 W Airview Way, Shelton, WA 98584')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (25, N'Skydive Kentucky', N'United States', N'+1 270-723-3587', N'info@skydiveky.com', N'Kentucky', N'Elizabethtown', N'1824 Kitty Hawk Dr, Elizabethtown, KY 42701')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (26, N'Skydive Indianapolis', N'United States', N'+1 317-759-3483', N'info@skydiveindy.com', N'Indiana', N'Frankfort', N'3009 W State Rd 28, Frankfort, IN 46041')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (27, N'Skydive Hawaii', N'United States', N'+1 808-637-9700', N'info@skydivehawaii.com', N'Hawaii', N'Waialua', N'68-760 Farrington Hwy, Waialua, HI 96791')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (28, N'Skydive Danielson', N'United States', N'+1 860-774-5867', N'info@skydivedanielson.com', N'Connecticut', N'Danielson', N'Danielson Airport, 41 Airport Rd, Danielson, CT 06239')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (29, N'Skydive Carolina', N'United States', N'+1 803-581-5867', N'info@skydivecarolina.com', N'South Carolina', N'Chester', N'1903 King Air Dr, Chester, SC 29706')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (30, N'Skydive California', N'United States', N'+1 209-835-7474', N'info@skydivecal.com', N'California', N'Tracy', N'25001 Kasson Rd, Tracy, CA 95304')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (31, N'Skydive Spaceland Dallas', N'United States', N'+1 903-364-5103', N'info@dall.skydivespaceland.com', N'Texas', N'Whitewright', N'1039 Private Rd 438, Whitewright, TX 75491')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (33, N'Skydive Perris', N'United States', N'+1 951-657-3904', N'info@skydiveperris.com', N'California', N'Perris', N'2091 Goetz Rd, Perris, CA 92570')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (34, N'Skydive Orange', N'United States', N'+1 703-759-3483', N'info@skydiveorange.com', N'Virginia', N'Orange', N'11339 Bloomsbury Rd, Orange, VA 22960')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (36, N'Skydive City Zephyrhills', N'United States', N'+1 800-888-5867', N'info@skydivecity.com', N'Florida', N'Zephyrhills', N'4241 Sky Dive Ln, Zephyrhills, FL 33542')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (37, N'Skydive New England', N'United States', N'+1 207-339-1520', N'info@skydivenewengland.com', N'Maine', N'Lebanon', N'40 Skydive Ln, Lebanon, ME 04027')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (38, N'Skydive Sebastian', N'United States', N'+1 772-388-5672', N'info@skydiveseb.com', N'Florida', N'Sebastian', N'400 Airport Dr W, Sebastian, FL 32958')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (39, N'Skydive The Ranch', N'United States', N'+1 845-255-4033', N'info@skydivetheranch.com', N'New York', N'Gardiner', N'55 Sand Hill Rd, Gardiner, NY 12525')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (40, N'Skydive Pepperell', N'United States', N'+1 978-433-9222', N'info@skyjump.com', N'Massachusetts', N'Pepperell', N'165 Nashua Rd, Pepperell, MA 01463')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (41, N'Skydive Moab', N'United States', N'+1 435-259-5867', N'info@skydivemoab.com', N'Utah', N'Moab', N'1146 S Hwy 191, Moab, UT 84532')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (42, N'Skydive Elsinore', N'United States', N'+1 951-245-9939', N'info@skydiveelsinore.com', N'California', N'Lake Elsinore', N'20701 Cereal St, Lake Elsinore, CA 92530')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (44, N'Skydive Coastal Carolinas', N'United States', N'+1 910-457-1039', N'info@skydivecoastalcarolinas.com', N'North Carolina', N'Oak Island', N'4019 Long Beach Rd SE, Southport, NC 28461')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (46, N'Skydive Spaceland Atlanta', N'United States', N'+1 770-614-3482', N'info@atlanta.skydivespaceland.com', N'Georgia', N'Rockmart', N'1195 Grady Rd, Rockmart, GA 30153')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (47, N'Skydive Spaceland Houston', N'United States', N'+1 281-369-3337', N'info@houstonskydiving.com', N'Texas', N'Rosharon', N'16111 FM 521 Rd, Rosharon, TX 77583')
INSERT [dbo].[Dropzone] ([dropzone_id], [dropzone_name], [dropzone_country], [dropzone_phone_number], [dropzone_email_address], [dropzone_state], [dropzone_city], [dropzone_address]) VALUES (49, N'Skydive Oregon', N'United States', N'+1 503-829-3483', N'info@skydiveoregon.com', N'Oregon', N'Molalla', N'12150 OR-211, Molalla, OR 97038')
SET IDENTITY_INSERT [dbo].[Dropzone] OFF
GO
SET IDENTITY_INSERT [dbo].[Equipment] ON 

INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (1, N'Main Canopy', N'Performance Designs', N'Sabre2')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (2, N'Main Canopy', N'Performance Designs', N'Spectre')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (3, N'Main Canopy', N'Icarus Canopies', N'Safire 3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (4, N'Main Canopy', N'Icarus Canopies', N'Crossfire 3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (5, N'Reserve Canopy', N'Performance Designs', N'Optimum Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (6, N'Reserve Canopy', N'Performance Designs', N'PD Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (7, N'Reserve Canopy', N'Icarus Canopies', N'Nano Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (8, N'AAD', N'CYPRES', N'CYPRES 2')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (9, N'AAD', N'Vigil', N'Vigil Cuatro')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (10, N'AAD', N'Mars', N'M2 Multi')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (11, N'Container', N'Sun Path', N'Javelin Odyssey')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (12, N'Container', N'United Parachute Technologies', N'Vector 3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (13, N'Container', N'Mirage Systems', N'G4')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (15, N'Helmet', N'Tonfly', N'3X')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (16, N'Altimeter', N'Larsen & Brusgaard', N'Viso II+')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (17, N'Altimeter', N'Alti-2', N'Neptune N3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (18, N'Jumpsuit', N'Tonfly', N'Uno.630 Race')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (19, N'Jumpsuit', N'Phoenix-Fly', N'Power Tracking Suit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (20, N'Wingsuit', N'Squirrel', N'AURA 4')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (22, N'Main Canopy', N'Performance Designs', N'Katana')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (23, N'Main Canopy', N'NZ Aerosports', N'JPX Petra')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (24, N'Main Canopy', N'NZ Aerosports', N'Leia')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (25, N'Reserve Canopy', N'Icarus Canopies', N'Smart Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (26, N'Reserve Canopy', N'NZ Aerosports', N'NZA Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (27, N'AAD', N'Airtec', N'CYPRES 2 Wingsuit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (28, N'AAD', N'Vigil', N'Vigil 2+')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (29, N'Container', N'Infinity', N'I-45')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (30, N'Container', N'Rigging Innovations', N'Curv')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (31, N'Helmet', N'KISS', N'KISS Helmet')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (32, N'Helmet', N'Bonehead Composites', N'Rev2')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (33, N'Altimeter', N'Larsen & Brusgaard', N'Altitrack')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (34, N'Altimeter', N'Barigo', N'Paralog Altimeter')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (35, N'Jumpsuit', N'Vertical Suits', N'Viper Suit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (36, N'Jumpsuit', N'Bev Suits', N'Freefly Suit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (37, N'Wingsuit', N'Phoenix-Fly', N'Venom Power')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (38, N'Wingsuit', N'TonySuits', N'TonyWing 3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (39, N'Goggles', N'Kroop’s', N'Original Goggles')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (40, N'Gloves', N'Mechanix', N'Original Glove')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (41, N'Main Canopy', N'Paratec', N'Speed 2000')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (42, N'Main Canopy', N'Icarus Canopies', N'Crossfire 2')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (43, N'Main Canopy', N'NZ Aerosports', N'JPX Leia')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (44, N'Main Canopy', N'Performance Designs', N'Stiletto')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (45, N'Reserve Canopy', N'Performance Designs', N'PDR Reserve')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (46, N'Reserve Canopy', N'NZ Aerosports', N'NZA Decelerator')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (47, N'AAD', N'CYPRES', N'CYPRES 2 Student')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (48, N'AAD', N'Vigil', N'Vigil 2')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (49, N'Container', N'Wings', N'Wings Vision')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (50, N'Container', N'Parachute Systems', N'Vortex')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (51, N'Helmet', N'Parasport Italia', N'Z1 SL-14')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (52, N'Helmet', N'Sky Systems', N'Sky Tie')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (53, N'Altimeter', N'Larsen & Brusgaard', N'Ares II')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (54, N'Altimeter', N'Parasport Italia', N'Altitron Digital Altimeter')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (55, N'Jumpsuit', N'LiquidSky', N'Comet Suit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (56, N'Jumpsuit', N'Deem Flywear', N'Raptor Suit')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (57, N'Wingsuit', N'Birdman', N'Blade')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (58, N'Wingsuit', N'Fly Your Body', N'Freak 3')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (59, N'Goggles', N'Kroop’s', N'13-Five Goggles')
INSERT [dbo].[Equipment] ([equipment_id], [equipment_type], [equipment_brand], [equipment_model]) VALUES (60, N'Gloves', N'Blackhawk', N'S.O.L.A.G. Gloves')
SET IDENTITY_INSERT [dbo].[Equipment] OFF
GO
SET IDENTITY_INSERT [dbo].[Weather] ON 

INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (1, N'80        ', N'10        ', N'Clear sky, no significant weather patterns.', N'N         ', N'N         ', N'40        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (2, N'65        ', N'5         ', N'Overcast but no rain, good visibility.', N'NE        ', N'NE        ', N'25        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (3, N'90        ', N'15        ', N'Hot and sunny, possible thermal activity.', N'SW        ', N'S         ', N'50        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (4, N'70        ', N'20        ', N'Cloudy with good visibility, wind picking up.', N'E         ', N'E         ', N'30        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (5, N'85        ', N'8         ', N'Clear and calm, perfect jumping weather.', N'W         ', N'W         ', N'45        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (6, N'75        ', N'12        ', N'Slight haze, winds steady.', N'S         ', N'S         ', N'35        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (7, N'80        ', N'10        ', N'Scattered clouds, no significant turbulence.', N'NW        ', N'NW        ', N'40        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (8, N'95        ', N'5         ', N'Hot and sunny, remember to stay hydrated.', N'SE        ', N'SE        ', N'55        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (9, N'60        ', N'18        ', N'Cool and breezy, cloud base high.', N'N         ', N'N         ', N'20        ')
INSERT [dbo].[Weather] ([weather_id], [ground_temperature], [ground_wind_speed], [additional_notes], [ground_wind_direction_at_takeoff], [ground_wind_direction_at_landing], [temperature_at_jump_altitude]) VALUES (10, N'70        ', N'15        ', N'Cloudy with patches of blue, winds steady.', N'W         ', N'W         ', N'30        ')
SET IDENTITY_INSERT [dbo].[Weather] OFF
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
REFERENCES [dbo].[Equipment] ([equipment_id])
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
