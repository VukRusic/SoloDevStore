USE [master]
GO
/****** Object:  Database [Solo]    Script Date: 2/11/2021 10:30:53 AM ******/
CREATE DATABASE [Solo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Solo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.THINKPADSQL\MSSQL\DATA\Solo.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Solo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.THINKPADSQL\MSSQL\DATA\Solo_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Solo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Solo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Solo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Solo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Solo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Solo] SET ARITHABORT OFF 
GO
ALTER DATABASE [Solo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Solo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Solo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Solo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Solo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Solo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Solo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Solo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Solo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Solo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Solo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Solo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Solo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Solo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Solo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Solo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Solo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Solo] SET RECOVERY FULL 
GO
ALTER DATABASE [Solo] SET  MULTI_USER 
GO
ALTER DATABASE [Solo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Solo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Solo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Solo] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Solo] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Solo', N'ON'
GO
ALTER DATABASE [Solo] SET QUERY_STORE = OFF
GO
USE [Solo]
GO
/****** Object:  Table [dbo].[Developer]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Developer](
	[Id] [int] NOT NULL,
	[RacunID] [nvarchar](15) NULL,
 CONSTRAINT [PK_Developer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvidencijaProdaje]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvidencijaProdaje](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdKorisnika] [int] NOT NULL,
	[IdProizvoda] [int] NOT NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_EvidencijaProdaje] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[Id] [int] NOT NULL,
	[RacunID] [nvarchar](15) NULL,
 CONSTRAINT [PK_Korisnik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nalog]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nalog](
	[Id] [int] NOT NULL,
	[Ime] [nvarchar](30) NOT NULL,
	[Prezime] [nvarchar](30) NOT NULL,
	[JMBG] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Nalog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[Id] [nvarchar](15) NOT NULL,
	[Stanje] [nvarchar](6) NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Radnik]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Radnik](
	[Id] [int] NOT NULL,
 CONSTRAINT [PK_Radnik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recenzija]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recenzija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProizvoda] [int] NOT NULL,
	[IdKorisnika] [int] NOT NULL,
	[Komentar] [nvarchar](max) NULL,
	[Ocena] [int] NOT NULL,
	[Datum] [datetime] NULL,
 CONSTRAINT [PK_Recenzija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RegistrovanProizvod]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RegistrovanProizvod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdDevelopera] [int] NOT NULL,
	[Naziv] [nvarchar](50) NOT NULL,
	[Zanr] [nvarchar](20) NOT NULL,
	[BrojIgraca] [int] NOT NULL,
	[PrepStarDoba] [int] NOT NULL,
	[Cena] [money] NOT NULL,
	[Procenat] [int] NULL,
	[Opis] [nvarchar](max) NULL,
 CONSTRAINT [PK_RegistrovanProizvod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/11/2021 10:30:54 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](20) NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Vrsta] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Developer] ([Id], [RacunID]) VALUES (5, N'3344')
INSERT [dbo].[Developer] ([Id], [RacunID]) VALUES (6, N'2233')
INSERT [dbo].[Developer] ([Id], [RacunID]) VALUES (13, N'9911')
INSERT [dbo].[Developer] ([Id], [RacunID]) VALUES (14, N'54644')
INSERT [dbo].[Developer] ([Id], [RacunID]) VALUES (16, N'222')
SET IDENTITY_INSERT [dbo].[EvidencijaProdaje] ON 

INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (1, 8, 4, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (8, 10, 4, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (9, 10, 5, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (10, 11, 5, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (11, 11, 8, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (15, 4, 5, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (16, 4, 4, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (17, 4, 8, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (18, 10, 8, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (19, 11, 4, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (20, 12, 4, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (21, 12, 5, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (22, 12, 8, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (23, 8, 8, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (30, 8, 21, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (31, 15, 21, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (32, 4, 22, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (33, 18, 21, N'Placeno')
INSERT [dbo].[EvidencijaProdaje] ([Id], [IdKorisnika], [IdProizvoda], [Status]) VALUES (34, 20, 4, N'Placeno')
SET IDENTITY_INSERT [dbo].[EvidencijaProdaje] OFF
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (1, N'2131')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (4, N'3221')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (8, N'1234')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (10, N'6655')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (11, N'1111')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (12, N'1997')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (15, N'5444')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (17, N'54212')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (18, N'55664')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (19, N'12113')
INSERT [dbo].[Korisnik] ([Id], [RacunID]) VALUES (20, N'6678')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (1, N'Niko', N'Koki', N'321232')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (4, N'Milos', N'Milutin', N'434141')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (5, N'RockStar', N'North', N'1422345')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (6, N'MarkInc', N'Jojic', N'1234556')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (8, N'Bob', N'Medow', N'21314')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (9, N'Luka', N'Radulovic', N'123123')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (10, N'Nena', N'Blekic', N'123124')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (11, N'Bleckey', N'TheDog', N'213123')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (12, N'Tom', N'Brady', N'124124')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (13, N'Ubisoft', N'Europe', N'124124')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (14, N'Ubi', N'Soft', N'123123')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (15, N'IT', N'School', N'231231')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (16, N'sgasfg', N'gasfa', N'fasfaa')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (17, N'Bob', N'Miek', N'1')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (18, N'Rasa', N'Maric', N'231231')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (19, N'TTT', N'EEE', N'1231231')
INSERT [dbo].[Nalog] ([Id], [Ime], [Prezime], [JMBG]) VALUES (20, N'Testing', N'Proba', N'231231')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'1111', N'600')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'12113', N'8500')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'1234', N'1069')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'1997', N'800')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'2131', N'0')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'222', N'8500')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'2233', N'5000')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'3221', N'12350')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'3344', N'21200')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'54212', N'8500')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'5444', N'4980')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'54644', N'21100')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'55664', N'4980')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'6655', N'800')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'6678', N'5200')
INSERT [dbo].[Racun] ([Id], [Stanje]) VALUES (N'9911', N'10300')
INSERT [dbo].[Radnik] ([Id]) VALUES (9)
SET IDENTITY_INSERT [dbo].[Recenzija] ON 

INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (2, 4, 4, N'Kad izlazi 6. deo?', 4, NULL)
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (4, 5, 8, N'Nice', 3, CAST(N'2021-02-04T18:10:14.137' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (10, 5, 4, N'Boring ', 1, CAST(N'2021-02-04T22:01:13.807' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (12, 4, 1, N'Fine', 3, CAST(N'2021-02-04T22:07:49.983' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (14, 5, 1, N'Loving pixel art', 5, CAST(N'2021-02-04T22:13:01.997' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (15, 8, 1, N'Nostalgija', 5, CAST(N'2021-02-05T01:36:18.780' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (17, 4, 8, N'Very good', 3, CAST(N'2021-02-06T16:21:46.047' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (20, 5, 11, N'Bark bark', 3, CAST(N'2021-02-06T19:59:45.900' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (21, 4, 11, N'dfdfdf', 1, CAST(N'2021-02-06T20:03:52.033' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (22, 8, 8, N'Zanimljivo', 4, CAST(N'2021-02-07T23:43:58.523' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (23, 4, 12, N'Skupo', 2, CAST(N'2021-02-08T02:24:50.620' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (26, 21, 8, N'Isto kao serija', 4, CAST(N'2021-02-09T23:13:17.690' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (27, 21, 15, N'dosadno', 1, CAST(N'2021-02-09T23:19:28.610' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (28, 21, 18, N'Dobra', 3, CAST(N'2021-02-10T00:35:53.743' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (29, 18, 1, N'MHMm', 4, CAST(N'2021-02-10T13:20:23.077' AS DateTime))
INSERT [dbo].[Recenzija] ([Id], [IdProizvoda], [IdKorisnika], [Komentar], [Ocena], [Datum]) VALUES (30, 4, 20, N'asdasda', 4, CAST(N'2021-02-10T15:36:52.733' AS DateTime))
SET IDENTITY_INSERT [dbo].[Recenzija] OFF
SET IDENTITY_INSERT [dbo].[RegistrovanProizvod] ON 

INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (4, 5, N'GTA', N'Adventure', 15, 18, 3000.0000, 10, N'It is the first main entry in the Grand Theft Auto series since 2008''s Grand Theft Auto IV. Set within the fictional state of San Andreas, based on Southern California, the single-player story follows three protagonists—retired bank robber Michael De Santa, street gangster Franklin Clinton, and drug dealer and arms smuggler Trevor Philips—and their efforts to commit heists while under pressure from a corrupt government agency and powerful criminals. The open world design lets players freely roam San Andreas'' open countryside and the fictional city of Los Santos, based on Los Angeles.')
INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (5, 6, N'Mon', N'Adventure', 2, 8, 2400.0000, 5, N'Moon is set within a fictional role-playing game where "the hero" has wreaked destruction, killing hundreds of creatures and looting homes. The player takes on the role of a supporting character in this world, attempting to undo the damage done by the hero. Moon has been praised by critics for how it parodies the conventions and tropes of role-playing games.')
INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (8, 5, N'BULLY', N'RPG', 1, 16, 2300.0000, 8, N'The game is played from a third-person perspective and its open world is navigated on foot, skateboard, scooter, bicycle, or go-kart. Set in the fictional town of Bullworth, the single-player story follows juvenile delinquent student James "Jimmy" Hopkins, who is involuntarily enrolled at Bullworth Academy for a year, and his efforts to rise through the ranks of the school system in order to put a stop to bullying. Players control Jimmy as he attempts to become more popular among the school''s various "cliques", in addition to attending classes and completing various side missions...')
INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (18, 6, N'Stardew Valley', N'Simulation', 1, 8, 2500.0000, 10, N'Stardew Valley is a farming simulation game primarily inspired by the Harvest Moon video game series.[1] At the start of the game, players create their character, who becomes the recipient of a plot of land and a small house once owned by their grandfather in a small town called Pelican Town. Players may select from several different farm map types, each having benefits and drawbacks.[2] The farm plot is initially overrun with boulders, trees, stumps, and weeds, and players must work to clear them in order to restart the farm, tending to crops and livestock so as to generate revenue and further expand the farm''s buildings and facilities.')
INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (21, 14, N'Assassin''s Creed Valhalla', N'Role-Playing', 2, 16, 3200.0000, 10, N'Assassin''s Creed Valhalla is an open-world action-adventure game structured around several main story arcs and numerous optional side-missions, called "World Events". The player takes on the role of Eivor Varinsdottir (/ˈeɪvɔːr/),[5] a Viking raider, as they lead their fellow Vikings against the Anglo-Saxon kingdoms. The player has the choice of playing Eivor as either male (voiced by Magnus Bruun), female (voiced by Cecilie Stenspil),[6] or letting the game alternate between the two at key moments in the story (with "Male Eivor" representing the Isu Odin''s appearance due to the presence of his DNA within Eivor). The player is also able to customise Eivor''s hair, warpaint, clothing, armor, and tattoos.[7] The variety of weapons available to the player has been expanded to include weapons such as flails and greatswords. Combat has been changed to allow dual-wielding of almost any weapon, including shields,[4] and every piece of gear that the player collects is unique.')
INSERT [dbo].[RegistrovanProizvod] ([Id], [IdDevelopera], [Naziv], [Zanr], [BrojIgraca], [PrepStarDoba], [Cena], [Procenat], [Opis]) VALUES (22, 14, N'Assassin''s Creed Unity', N'Role-Playing', 4, 16, 3000.0000, 5, N'The plot is set in a fictional history of real world events and follows the centuries-old struggle between the Assassins, who fight for peace with free will, and the Templars, who desire peace through control. The story is set in Paris during the French Revolution; the single-player story follows Arno Victor Dorian in his efforts to expose the true powers behind the Revolution. The game retains the series'' third-person open world exploration as well as introducing a revamped combat, parkour and stealth system. The game also introduces cooperative multiplayer to the Assassin''s Creed series, letting up to four players engage in narrative-driven missions and explore the open world map.')
SET IDENTITY_INSERT [dbo].[RegistrovanProizvod] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (1, N'Bool1', N'123', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (2, N'Titi', N'111', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (3, N'Strumf', N'999', N'Radnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (4, N'Moli', N'111', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (5, N'RockStar', N'1555', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (6, N'Vuk99', N'1234', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (8, N'Wood', N'222', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (9, N'Admin', N'admin', N'Radnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (10, N'MalaNena', N'bleki1', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (11, N'Bleki', N'nena1', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (12, N'Tom', N'333', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (13, N'Ubisofttt', N'99', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (14, N'Ubisoft', N'333', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (15, N'ITS', N'123', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (16, N'Vuk9', N'1', N'Developer')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (17, N'Vukkkk', N'111', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (18, N'Student', N'222', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (19, N'test', N'111', N'Korisnik')
INSERT [dbo].[User] ([Id], [Username], [Password], [Vrsta]) VALUES (20, N'Testing', N'111', N'Korisnik')
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Developer]  WITH CHECK ADD  CONSTRAINT [FK_Developer_Nalog] FOREIGN KEY([Id])
REFERENCES [dbo].[Nalog] ([Id])
GO
ALTER TABLE [dbo].[Developer] CHECK CONSTRAINT [FK_Developer_Nalog]
GO
ALTER TABLE [dbo].[Developer]  WITH CHECK ADD  CONSTRAINT [FK_Developer_Racun] FOREIGN KEY([RacunID])
REFERENCES [dbo].[Racun] ([Id])
GO
ALTER TABLE [dbo].[Developer] CHECK CONSTRAINT [FK_Developer_Racun]
GO
ALTER TABLE [dbo].[EvidencijaProdaje]  WITH CHECK ADD  CONSTRAINT [FK_EvidencijaProdaje_Korisnik] FOREIGN KEY([IdKorisnika])
REFERENCES [dbo].[Korisnik] ([Id])
GO
ALTER TABLE [dbo].[EvidencijaProdaje] CHECK CONSTRAINT [FK_EvidencijaProdaje_Korisnik]
GO
ALTER TABLE [dbo].[EvidencijaProdaje]  WITH CHECK ADD  CONSTRAINT [FK_EvidencijaProdaje_RegistrovanProizvod] FOREIGN KEY([IdProizvoda])
REFERENCES [dbo].[RegistrovanProizvod] ([Id])
GO
ALTER TABLE [dbo].[EvidencijaProdaje] CHECK CONSTRAINT [FK_EvidencijaProdaje_RegistrovanProizvod]
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD  CONSTRAINT [FK_Korisnik_Nalog] FOREIGN KEY([Id])
REFERENCES [dbo].[Nalog] ([Id])
GO
ALTER TABLE [dbo].[Korisnik] CHECK CONSTRAINT [FK_Korisnik_Nalog]
GO
ALTER TABLE [dbo].[Korisnik]  WITH CHECK ADD  CONSTRAINT [FK_Korisnik_Racun] FOREIGN KEY([RacunID])
REFERENCES [dbo].[Racun] ([Id])
GO
ALTER TABLE [dbo].[Korisnik] CHECK CONSTRAINT [FK_Korisnik_Racun]
GO
ALTER TABLE [dbo].[Nalog]  WITH CHECK ADD  CONSTRAINT [FK_Nalog_User] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Nalog] CHECK CONSTRAINT [FK_Nalog_User]
GO
ALTER TABLE [dbo].[Radnik]  WITH CHECK ADD  CONSTRAINT [FK_Radnik_Nalog] FOREIGN KEY([Id])
REFERENCES [dbo].[Nalog] ([Id])
GO
ALTER TABLE [dbo].[Radnik] CHECK CONSTRAINT [FK_Radnik_Nalog]
GO
ALTER TABLE [dbo].[Recenzija]  WITH CHECK ADD  CONSTRAINT [FK_Recenzija_Korisnik] FOREIGN KEY([IdKorisnika])
REFERENCES [dbo].[Korisnik] ([Id])
GO
ALTER TABLE [dbo].[Recenzija] CHECK CONSTRAINT [FK_Recenzija_Korisnik]
GO
ALTER TABLE [dbo].[Recenzija]  WITH CHECK ADD  CONSTRAINT [FK_Recenzija_RegistrovanProizvod] FOREIGN KEY([IdProizvoda])
REFERENCES [dbo].[RegistrovanProizvod] ([Id])
GO
ALTER TABLE [dbo].[Recenzija] CHECK CONSTRAINT [FK_Recenzija_RegistrovanProizvod]
GO
ALTER TABLE [dbo].[RegistrovanProizvod]  WITH CHECK ADD  CONSTRAINT [FK_RegistrovanProizvod_Developer] FOREIGN KEY([IdDevelopera])
REFERENCES [dbo].[Developer] ([Id])
GO
ALTER TABLE [dbo].[RegistrovanProizvod] CHECK CONSTRAINT [FK_RegistrovanProizvod_Developer]
GO
USE [master]
GO
ALTER DATABASE [Solo] SET  READ_WRITE 
GO
