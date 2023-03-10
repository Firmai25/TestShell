USE [master]
GO
/****** Object:  Database [Cherepanov_Testing]    Script Date: 08.11.2022 14:43:06 ******/
CREATE DATABASE [Cherepanov_Testing]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cherepanov_Testing', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEM\MSSQL\DATA\Cherepanov_Testing.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cherepanov_Testing_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLDEM\MSSQL\DATA\Cherepanov_Testing_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cherepanov_Testing] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cherepanov_Testing].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cherepanov_Testing] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cherepanov_Testing] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cherepanov_Testing] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cherepanov_Testing] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cherepanov_Testing] SET  MULTI_USER 
GO
ALTER DATABASE [Cherepanov_Testing] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cherepanov_Testing] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cherepanov_Testing] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cherepanov_Testing] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cherepanov_Testing] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cherepanov_Testing] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cherepanov_Testing] SET QUERY_STORE = OFF
GO
USE [Cherepanov_Testing]
GO
/****** Object:  Table [dbo].[Answer]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text_Answer] [nvarchar](max) NULL,
	[Number] [int] NULL,
	[Correct] [int] NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Test] [int] NULL,
	[Text_question] [nvarchar](max) NULL,
	[id_type] [int] NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Question_Answer]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Question_Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_question] [int] NULL,
	[Id_Answer] [int] NULL,
 CONSTRAINT [PK_Question_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Point] [int] NULL,
 CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rating_Test]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rating_Test](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Rating] [int] NULL,
	[Id_Test] [int] NULL,
 CONSTRAINT [PK_Rating_Test] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Patronymic] [nvarchar](max) NULL,
	[Login] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[id_Teacher] [int] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type_question]    Script Date: 08.11.2022 14:43:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Type_question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Test] FOREIGN KEY([Id_Test])
REFERENCES [dbo].[Test] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Test]
GO
ALTER TABLE [dbo].[Question]  WITH CHECK ADD  CONSTRAINT [FK_Question_Type_question] FOREIGN KEY([id_type])
REFERENCES [dbo].[Type_question] ([Id])
GO
ALTER TABLE [dbo].[Question] CHECK CONSTRAINT [FK_Question_Type_question]
GO
ALTER TABLE [dbo].[Question_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer_Answer] FOREIGN KEY([Id_Answer])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[Question_Answer] CHECK CONSTRAINT [FK_Question_Answer_Answer]
GO
ALTER TABLE [dbo].[Question_Answer]  WITH CHECK ADD  CONSTRAINT [FK_Question_Answer_Question] FOREIGN KEY([Id_question])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[Question_Answer] CHECK CONSTRAINT [FK_Question_Answer_Question]
GO
ALTER TABLE [dbo].[Rating_Test]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Test_Rating1] FOREIGN KEY([Id_Rating])
REFERENCES [dbo].[Rating] ([Id])
GO
ALTER TABLE [dbo].[Rating_Test] CHECK CONSTRAINT [FK_Rating_Test_Rating1]
GO
ALTER TABLE [dbo].[Rating_Test]  WITH CHECK ADD  CONSTRAINT [FK_Rating_Test_Test] FOREIGN KEY([Id_Test])
REFERENCES [dbo].[Test] ([Id])
GO
ALTER TABLE [dbo].[Rating_Test] CHECK CONSTRAINT [FK_Rating_Test_Test]
GO
ALTER TABLE [dbo].[Test]  WITH CHECK ADD  CONSTRAINT [FK_Test_Teacher1] FOREIGN KEY([id_Teacher])
REFERENCES [dbo].[Teacher] ([Id])
GO
ALTER TABLE [dbo].[Test] CHECK CONSTRAINT [FK_Test_Teacher1]
GO
USE [master]
GO
ALTER DATABASE [Cherepanov_Testing] SET  READ_WRITE 
GO
