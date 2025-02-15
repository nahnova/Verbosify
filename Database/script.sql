USE [master]
GO
/****** Object:  Database [Verbosify]    Script Date: 2-7-2023 20:59:21 ******/
CREATE DATABASE [Verbosify]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Verbosify', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Verbosify.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Verbosify_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Verbosify_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Verbosify] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Verbosify].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Verbosify] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Verbosify] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Verbosify] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Verbosify] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Verbosify] SET ARITHABORT OFF 
GO
ALTER DATABASE [Verbosify] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Verbosify] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Verbosify] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Verbosify] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Verbosify] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Verbosify] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Verbosify] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Verbosify] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Verbosify] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Verbosify] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Verbosify] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Verbosify] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Verbosify] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Verbosify] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Verbosify] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Verbosify] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Verbosify] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Verbosify] SET RECOVERY FULL 
GO
ALTER DATABASE [Verbosify] SET  MULTI_USER 
GO
ALTER DATABASE [Verbosify] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Verbosify] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Verbosify] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Verbosify] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Verbosify] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Verbosify] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Verbosify', N'ON'
GO
ALTER DATABASE [Verbosify] SET QUERY_STORE = OFF
GO
USE [Verbosify]
GO
/****** Object:  Table [dbo].[Badge]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Badge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](50) NULL,
	[image] [varchar](50) NULL,
 CONSTRAINT [PK_Badge] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teacherId] [int] NULL,
	[studentId] [int] NULL,
	[date] [date] NULL,
	[course] [varchar](50) NULL,
	[feedback] [varchar](max) NULL,
	[type] [varchar](50) NULL,
	[goalID] [int] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Goal]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Goal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentID] [int] NULL,
	[priority] [varchar](50) NULL,
	[goal] [varchar](max) NULL,
	[time] [float] NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_Goal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[gender] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[studentLevel] [int] NULL,
	[xpAmount] [int] NULL,
	[xpProgression] [int] NULL,
	[rank] [varchar](50) NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[studentBadge]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[studentBadge](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NULL,
	[badgeId] [int] NULL,
 CONSTRAINT [PK_studentBadge] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubGoal]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubGoal](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[goalId] [int] NULL,
	[subGoal] [varchar](50) NULL,
	[status] [varchar](50) NULL,
 CONSTRAINT [PK_subGoal] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[phone] [int] NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Team]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[teamName] [varchar](50) NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[teamStudent]    Script Date: 2-7-2023 20:59:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[teamStudent](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[studentId] [int] NULL,
	[teamId] [int] NULL,
 CONSTRAINT [PK_teamStudent] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([id], [teacherId], [studentId], [date], [course], [feedback], [type], [goalID]) VALUES (12, 1, 1, CAST(N'2023-04-16' AS Date), N'', N'Je kunt om c# beter te leren, kijken bij andere projecten en aan de hand daarvan zelf proberen iets te maken. ', N'doel', 4)
INSERT [dbo].[Feedback] ([id], [teacherId], [studentId], [date], [course], [feedback], [type], [goalID]) VALUES (13, 1, 1, CAST(N'2023-04-16' AS Date), N'', N'Je leert alleen maar door te doen niet door over te nemen.', N'doel', 4)
INSERT [dbo].[Feedback] ([id], [teacherId], [studentId], [date], [course], [feedback], [type], [goalID]) VALUES (14, 1, 1, CAST(N'2023-04-16' AS Date), N'c#', N'Je hebt dit blok laten zien dat je veel vooruit bent gegaan met c# beheersing.', N'SLB', 0)
INSERT [dbo].[Feedback] ([id], [teacherId], [studentId], [date], [course], [feedback], [type], [goalID]) VALUES (15, 1, 1, CAST(N'2023-04-16' AS Date), N'', N'beter leren', N'doel', 8)
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[Goal] ON 

INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (1, 1, N'high', N'beter leren samenwerken', 3, N'afgerond')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (2, 1, N'Laag', N'beter plannen', 3, N'afgerond')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (4, 1, N'Gemiddeld', N'nieuwe c# kennis opdoen', 0.5, N'afgerond')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (7, 6, N'Gemiddeld', N'nieuwe pagina''s maken voor feedback systeem', 5, N'bezig')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (8, 1, N'Gemiddeld', N'beter c# leren kennen', 2, N'afgerond')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (1008, 7, N'Urgent', N'nieuw document aan maken', 2, N'bezig')
INSERT [dbo].[Goal] ([id], [studentID], [priority], [goal], [time], [status]) VALUES (1009, 1, N'Laag', N'blabagsefwfesrghdgsf', 2, N'afgerond')
SET IDENTITY_INSERT [dbo].[Goal] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (1, N'Xavier', N'Prickaerts', N'x@prickaerts', N'male', N'wachtwoord', 3, 100, 20, N'Gold')
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (2, N'Renad', N'sh', N'rSh', N'male', N'rSh', NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (3, N'Aimane', N'bouga', N'a@gmail', N'male', N'aBouga', NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (4, N'jay', N'rein', N'j@solutions', N'male', N'jRein', NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (5, N'gabriel', N'lunesu', N'g@lunesu', N'male', N'gLunesu', NULL, NULL, NULL, NULL)
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (6, N'noa', N'heuts', N'n@heuts', N'male', N'noaHeuts', 2, 100, 30, N'Silver')
INSERT [dbo].[Student] ([id], [firstName], [lastName], [email], [gender], [password], [studentLevel], [xpAmount], [xpProgression], [rank]) VALUES (7, N'jay', N'leetje', N'jay123', N'Overig', N'piet', 5, 100, 40, N'Diamond')
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
SET IDENTITY_INSERT [dbo].[SubGoal] ON 

INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (1, 1, N'meer communiceren met docenten', N'afgerond')
INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (16, 2, N'planning duidelijker maken voor anderen', N'bezig')
INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (17, 4, N'studeren', N'bezig')
INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (18, 4, N'w3 schools doorzoeken voor informatie over c#', N'bezig')
INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (31, 8, N'kijken op w3school', N'te doen')
INSERT [dbo].[SubGoal] ([id], [goalId], [subGoal], [status]) VALUES (1031, 1008, N'goed met de neus erin duiken', N'te doen')
SET IDENTITY_INSERT [dbo].[SubGoal] OFF
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [email], [phone], [password]) VALUES (1, N'rick', N'warnecke', N'testmail@kpn', 612345643, N'wachtwoord')
INSERT [dbo].[Teacher] ([id], [firstName], [lastName], [email], [phone], [password]) VALUES (2, N'miel', N'noelanders', N'testmail@gmail', 61245653, N'wachtwoord2')
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Student]
GO
ALTER TABLE [dbo].[Feedback]  WITH CHECK ADD  CONSTRAINT [FK_Feedback_Teacher] FOREIGN KEY([teacherId])
REFERENCES [dbo].[Teacher] ([id])
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Teacher]
GO
ALTER TABLE [dbo].[Goal]  WITH CHECK ADD  CONSTRAINT [FK_Goal_Student] FOREIGN KEY([studentID])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[Goal] CHECK CONSTRAINT [FK_Goal_Student]
GO
ALTER TABLE [dbo].[studentBadge]  WITH CHECK ADD  CONSTRAINT [FK_studentBadge_Badge] FOREIGN KEY([badgeId])
REFERENCES [dbo].[Badge] ([id])
GO
ALTER TABLE [dbo].[studentBadge] CHECK CONSTRAINT [FK_studentBadge_Badge]
GO
ALTER TABLE [dbo].[studentBadge]  WITH CHECK ADD  CONSTRAINT [FK_studentBadge_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[studentBadge] CHECK CONSTRAINT [FK_studentBadge_Student]
GO
ALTER TABLE [dbo].[SubGoal]  WITH CHECK ADD  CONSTRAINT [FK_SubGoal_Goal] FOREIGN KEY([goalId])
REFERENCES [dbo].[Goal] ([id])
GO
ALTER TABLE [dbo].[SubGoal] CHECK CONSTRAINT [FK_SubGoal_Goal]
GO
ALTER TABLE [dbo].[teamStudent]  WITH CHECK ADD  CONSTRAINT [FK_teamStudent_Student] FOREIGN KEY([studentId])
REFERENCES [dbo].[Student] ([id])
GO
ALTER TABLE [dbo].[teamStudent] CHECK CONSTRAINT [FK_teamStudent_Student]
GO
ALTER TABLE [dbo].[teamStudent]  WITH CHECK ADD  CONSTRAINT [FK_teamStudent_Team] FOREIGN KEY([teamId])
REFERENCES [dbo].[Team] ([id])
GO
ALTER TABLE [dbo].[teamStudent] CHECK CONSTRAINT [FK_teamStudent_Team]
GO
USE [master]
GO
ALTER DATABASE [Verbosify] SET  READ_WRITE 
GO
