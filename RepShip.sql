USE [master]
GO
/****** Object:  Database [RepublicShipping]    Script Date: 26/2/2023 14:13:37 ******/
CREATE DATABASE [RepublicShipping]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RepublicShipping', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RepublicShipping.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'RepublicShipping_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\RepublicShipping_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [RepublicShipping] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RepublicShipping].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RepublicShipping] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RepublicShipping] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RepublicShipping] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RepublicShipping] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RepublicShipping] SET ARITHABORT OFF 
GO
ALTER DATABASE [RepublicShipping] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RepublicShipping] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RepublicShipping] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RepublicShipping] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RepublicShipping] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RepublicShipping] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RepublicShipping] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RepublicShipping] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RepublicShipping] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RepublicShipping] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RepublicShipping] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RepublicShipping] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RepublicShipping] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RepublicShipping] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RepublicShipping] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RepublicShipping] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RepublicShipping] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RepublicShipping] SET RECOVERY FULL 
GO
ALTER DATABASE [RepublicShipping] SET  MULTI_USER 
GO
ALTER DATABASE [RepublicShipping] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RepublicShipping] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RepublicShipping] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RepublicShipping] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [RepublicShipping] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [RepublicShipping] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'RepublicShipping', N'ON'
GO
ALTER DATABASE [RepublicShipping] SET QUERY_STORE = OFF
GO
USE [RepublicShipping]
GO
/****** Object:  Table [dbo].[Agente]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Agente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Agente] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Agente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carrier]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrier](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Carrier] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Carrier] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consigneer]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consigneer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Consigneer] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Consigneer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Incoterm]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incoterm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Incoterm] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Incoterm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pod]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pod](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pod] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pod] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pol]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pol](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Pol] [nvarchar](100) NULL,
	[FechaIngreso] [date] NULL,
	[EsActivo] [bit] NULL,
	[UsuarioRegistra] [nvarchar](50) NULL,
 CONSTRAINT [PK_Pol] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reporte]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reporte](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Agente] [nvarchar](50) NULL,
	[POL] [nvarchar](50) NULL,
	[POD] [nvarchar](50) NULL,
	[Carrier] [nvarchar](50) NOT NULL,
	[Consignee] [nvarchar](50) NOT NULL,
	[BK] [nvarchar](50) NOT NULL,
	[HBL] [nvarchar](50) NOT NULL,
	[MBL] [nvarchar](50) NOT NULL,
	[REF] [nvarchar](50) NOT NULL,
	[Size] [nvarchar](50) NOT NULL,
	[ETD] [date] NOT NULL,
	[ETA] [date] NOT NULL,
	[Descripción] [nvarchar](200) NOT NULL,
	[OF] [decimal](9, 2) NOT NULL,
	[PAgent] [decimal](9, 2) NOT NULL,
	[INCOTERM] [varchar](50) NOT NULL,
	[Quotation] [varchar](50) NOT NULL,
	[TOrigen] [decimal](9, 2) NOT NULL,
	[OM] [decimal](9, 2) NOT NULL,
	[INCTOMGA] [decimal](9, 2) NOT NULL,
	[THC] [decimal](9, 2) NOT NULL,
	[Dgastos] [nvarchar](150) NOT NULL,
	[CLocal] [decimal](9, 2) NOT NULL,
	[TLocal] [decimal](9, 2) NOT NULL,
	[Rebate] [decimal](9, 2) NOT NULL,
	[Reintegro] [decimal](9, 2) NOT NULL,
	[TEspecial] [decimal](9, 2) NOT NULL,
	[Otros] [decimal](9, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GuardarInfo]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GuardarInfo]
(@tabla nvarchar(50),
@data nvarchar(50)
)
AS
BEGIN
	IF @tabla = 'Consigneer'
	begin
		insert into Consigneer values(@data, getdate(), 1, SUSER_SNAME())
	end

	IF @tabla = 'Carrier'
	begin
		insert into Carrier values(@data, getdate(), 1, SUSER_SNAME())
	end

	IF @tabla = 'Agente'
	begin
		insert into Agente values(@data, getdate(), 1, SUSER_SNAME())
	end

	IF @tabla = 'Incoterm'
	begin
		insert into Incoterm values(@data, getdate(), 1, SUSER_SNAME())
	end

	IF @tabla = 'Pod'
	begin
		insert into Pod values(@data, getdate(), 1, SUSER_SNAME())
	end

	IF @tabla = 'Pol'
	begin
		insert into Pol values(@data, getdate(), 1, SUSER_SNAME())
	end
END
GO
/****** Object:  StoredProcedure [dbo].[GuardarReporte]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GuardarReporte]
(
	@Agente varchar(50),
    @POL varchar(50),
    @POD varchar(50),
    @Carrier varchar(50),
    @Consignee varchar(50),
    @BK varchar(50),
    @HBL varchar(50),
    @MBL varchar(50),
    @REF nvarchar(50),
    @Size nvarchar(50),
    @ETD date,
    @ETA date,
    @Descripción nvarchar(50),
    @OF decimal(9,2),
    @PAgent decimal(9,2),
    @INCOTERM varchar(50),
    @Quotation varchar(50),
    @TOrigen decimal(9,2),
    @OM decimal(9,2),
    @INCTOMGA decimal(9,2),
    @THC decimal(9,2),
    @Dgastos nvarchar(50),
    @CLocal decimal(9,2),
    @TLocal decimal(9,2),
    @Rebate decimal(9,2),
    @Reintegro decimal(9,2),
    @TEspecial decimal(9,2),
	@Otros decimal(9,2)
	)
AS
BEGIN
	
	INSERT INTO [dbo].[Reporte]
           ([Agente]
           ,[POL]
           ,[POD]
           ,[Carrier]
           ,[Consignee]
           ,[BK]
           ,[HBL]
           ,[MBL]
           ,[REF]
           ,[Size]
           ,[ETD]
           ,[ETA]
           ,[Descripción]
           ,[OF]
           ,[PAgent]
           ,[INCOTERM]
           ,[Quotation]
           ,[TOrigen]
           ,[OM]
           ,[INCTOMGA]
           ,[THC]
           ,[Dgastos]
           ,[CLocal]
           ,[TLocal]
           ,[Rebate]
           ,[Reintegro]
           ,[TEspecial]
		   ,[Otros])
		   
     VALUES(@Agente, @POL, @POD, @Carrier, @Consignee, @BK, @HBL, @MBL, @REF, @Size, @ETD, @ETA, @Descripción, @OF, @PAgent, @INCOTERM, @Quotation, @TOrigen,
			@OM, @INCTOMGA, @THC, @Dgastos, @CLocal, @TLocal, @Rebate, @Reintegro, @TEspecial, @Otros
			)
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarReporte]    Script Date: 26/2/2023 14:13:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[ModificarReporte]
(
	@Agente varchar(50),
    @POL varchar(50),
    @POD varchar(50),
    @Carrier varchar(50),
    @Consignee varchar(50),
    @BK varchar(50),
    @HBL varchar(50),
    @MBL varchar(50),
    @REF nvarchar(50),
    @Size nvarchar(50),
    @ETD date,
    @ETA date,
    @Descripción nvarchar(50),
    @OF decimal(9,2),
    @PAgent decimal(9,2),
    @INCOTERM varchar(50),
    @Quotation varchar(50),
    @TOrigen decimal(9,2),
    @OM decimal(9,2),
    @INCTOMGA decimal(9,2),
    @THC decimal(9,2),
    @Dgastos nvarchar(50),
    @CLocal decimal(9,2),
    @TLocal decimal(9,2),
    @Rebate decimal(9,2),
    @Reintegro decimal(9,2),
    @TEspecial decimal(9,2),
	@Otros decimal(9,2),
	@Id int
	)
AS
BEGIN
	
	update [dbo].[Reporte]
         
     set Agente = @Agente,
	 Pol = @POL,
	 Pod = @POD,
	 Carrier = @Carrier,
	 Consignee = @Consignee,
	 BK = @BK,
HBL =  @HBL,
MBL =  @MBL,
REF =  @REF,
Size =  @Size,
ETD =  @ETD,
ETA =  @ETA,
Descripción =  @Descripción,
[OF] =  @OF,
PAgent =  @PAgent,
INCOTERM =  @INCOTERM,
Quotation =  @Quotation,
TOrigen =  @TOrigen,
OM =  @OM,
INCTOMGA =  @INCTOMGA, 
THC =  @THC, 
Dgastos =  @Dgastos, 
CLocal =  @CLocal, 
TLocal =  @TLocal, 
Rebate =  @Rebate, 
Reintegro =  @Reintegro, 
TEspecial =  @TEspecial, 
Otros =  @Otros
where Id = @Id
			
END
GO
USE [master]
GO
ALTER DATABASE [RepublicShipping] SET  READ_WRITE 
GO
