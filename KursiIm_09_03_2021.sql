USE [master]
GO
/****** Object:  Database [KursiIm]    Script Date: 3/9/2021 1:18:05 AM ******/
CREATE DATABASE [KursiIm]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KursiIm', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\KursiIm.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KursiIm_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\KursiIm_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [KursiIm] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KursiIm].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KursiIm] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KursiIm] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KursiIm] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KursiIm] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KursiIm] SET ARITHABORT OFF 
GO
ALTER DATABASE [KursiIm] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KursiIm] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KursiIm] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KursiIm] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KursiIm] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KursiIm] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KursiIm] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KursiIm] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KursiIm] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KursiIm] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KursiIm] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KursiIm] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KursiIm] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KursiIm] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KursiIm] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KursiIm] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KursiIm] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KursiIm] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KursiIm] SET  MULTI_USER 
GO
ALTER DATABASE [KursiIm] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KursiIm] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KursiIm] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KursiIm] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [KursiIm] SET DELAYED_DURABILITY = DISABLED 
GO
USE [KursiIm]
GO
/****** Object:  Table [dbo].[LogDataChange]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogDataChange](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
	[Before] [varbinary](max) NOT NULL,
	[After] [varbinary](max) NOT NULL,
	[ComputerName] [nvarchar](250) NOT NULL,
	[IDAddress] [nvarchar](250) NOT NULL,
	[IDLogBrowserType] [int] NOT NULL,
	[IDLogOperatingSystemType] [int] NOT NULL,
	[IsMobileDevice] [bit] NOT NULL,
	[IDLogDataChangeStatus] [int] NOT NULL,
	[IDTable] [int] NOT NULL,
 CONSTRAINT [PK_LogDataChange] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogDataChangeStatus]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogDataChangeStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LogDataChangeStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogFailedAuthentication]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogFailedAuthentication](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Account] [varchar](250) NOT NULL,
	[ComputerName] [nvarchar](250) NOT NULL,
	[IPAddress] [varchar](250) NOT NULL,
	[IDLogOperationSystemType] [int] NOT NULL,
	[IDLogBrowserType] [int] NOT NULL,
	[IsMobileDevice] [bit] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
 CONSTRAINT [PK_LogFailedAuthentication] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogInternetBrowserType]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogInternetBrowserType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LogInternetBrowserType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogOperatingSystemType]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogOperatingSystemType](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [varchar](250) NOT NULL,
 CONSTRAINT [PK_LogOperatingSystemType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogUserActivity]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogUserActivity](
	[ID] [int] NOT NULL,
	[IDUser] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ComputerName] [nvarchar](250) NOT NULL,
	[IPAddress] [nvarchar](250) NOT NULL,
	[IDLogBrowserType] [int] NOT NULL,
	[IDLogOperatingSystemType] [int] NOT NULL,
	[IDModule] [int] NOT NULL,
	[URL] [nvarchar](500) NOT NULL,
	[IsPublic] [bit] NULL,
	[IsMobileDevice] [bit] NOT NULL,
	[IDLogUserActivityStatus] [int] IDENTITY(1,1) NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LogUserActivity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogUserActivityStatus]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogUserActivityStatus](
	[ID] [int] NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] IDENTITY(1,1) NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LogUserActivityStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LogUserAuthorization]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogUserAuthorization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDUser] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[ComputerName] [nvarchar](250) NOT NULL,
	[IPAddress] [nvarchar](50) NOT NULL,
	[IDLogBrowserType] [int] NOT NULL,
	[IDLogOperatingSystemType] [int] NOT NULL,
	[IsMobileDevice] [bit] NOT NULL,
	[IDLogUserAuthorizationStatus] [int] NOT NULL,
	[EntryUser] [varchar](150) NOT NULL,
 CONSTRAINT [PK_LogUserAuthorization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogUserAuthorizationStatus]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogUserAuthorizationStatus](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_LogUserAuthorizationStatus] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Module]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Module](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](150) NOT NULL,
	[IDParent] [int] NULL,
	[IsPublic] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](550) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](150) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IDUpdateUser] [int] NULL,
	[UpdateUser] [nvarchar](150) NULL,
	[WithPasswordPolicy] [bit] NOT NULL,
	[PasswordValidityDays] [bit] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleAuthorization]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAuthorization](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDRole] [int] NOT NULL,
	[IDRoleAuthorizationType] [int] NOT NULL,
	[IDModule] [int] NOT NULL,
	[EntryUser] [nvarchar](150) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[UpdateDate] [datetime] NULL,
	[IDUpdateUser] [int] NULL,
	[UpdateUser] [nvarchar](150) NULL,
 CONSTRAINT [PK_RoleAuthorization] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RoleAuthorizationType]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleAuthorizationType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](150) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_RoleAuthorizationType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tables]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tables](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
 CONSTRAINT [PK_Tables] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[First] [nvarchar](500) NOT NULL,
	[Last] [nvarchar](500) NOT NULL,
	[Account] [nvarchar](500) NOT NULL,
	[Password] [nvarchar](500) NOT NULL,
	[SaltedPassword] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ExpireDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[IDUpdateUser] [int] NULL,
	[UpdateUser] [nvarchar](100) NULL,
	[RefreshToken] [nvarchar](max) NULL,
	[ChangePasswordNeeded] [bit] NOT NULL,
	[LatestPasswordChangeDate] [datetime] NULL,
	[EmailAddress] [nvarchar](150) NOT NULL,
	[ResetPasswordToken] [uniqueidentifier] NULL,
	[ConfirmationNumber] [uniqueidentifier] NULL,
	[WasConfirm] [bit] NULL,
	[ConfirmationDate] [datetime] NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](100) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[UserDelete] [nvarchar](100) NULL,
	[DeleteDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[IDRole] [int] NULL,
	[IDDeleteUser] [int] NULL,
	[IDUserAuthorizationType] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserAuthorizationType]    Script Date: 3/9/2021 1:18:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserAuthorizationType](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[EntryDate] [datetime] NOT NULL,
	[IDEntryUser] [int] NOT NULL,
	[EntryUser] [nvarchar](150) NOT NULL,
 CONSTRAINT [PK_UserAuthorizationType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[LogDataChange] ON 

GO
INSERT [dbo].[LogDataChange] ([ID], [EntryDate], [IDEntryUser], [EntryUser], [Before], [After], [ComputerName], [IDAddress], [IDLogBrowserType], [IDLogOperatingSystemType], [IsMobileDevice], [IDLogDataChangeStatus], [IDTable]) VALUES (3, CAST(N'2021-03-09 01:10:59.053' AS DateTime), 1, N'admin', 0x7B224669727374223A2261646D696E222C224C617374223A2261646D696E222C224163636F756E74223A2261646D696E222C2250617373776F7264223A227869586663616533376D435A4B6A3779742F456A315974344E7551416837625A6950467A4E6D4F364479363442775651352B4E6A516F696D7A7661312F7452685232385939737A4763517868755A334A2F336535666C437579684C31646A4A6D2B72784739514155614149354D6C75576C632F572B575964305A4E446477644C4C4A505945702B4B494D45484D6876466A487364644B676F30726A59704B55756D6E6A7A492F41734B7A5430645847556F31662F63395045652B694833547A615439617A615145462F5667655459556E4A6D5848324554697A362F5074554538436A39655A346E6C6E715837596567314F712F50473341665A3231584132536B79435A6351432F445346336D70665A6966656756455666376F7138584C5A726B41314E2B6C70794953524C4743556D472B6C7949456175566E4B4B75336E675158784A6446566A65634C564849314A663942594779673D3D222C2253616C74656450617373776F7264223A22417A746F62755378775650747248396F706C514D4335634C6F676E6B334D336A774971324945614434456B3D222C224973416374697665223A747275652C2245787069726544617465223A22323032352D30332D30395430303A30353A35332E3633222C2255706461746544617465223A22323032312D30332D30395430313A30383A35322E3832222C22496475706461746555736572223A312C2255706461746555736572223A2261646D696E222C2252656672657368546F6B656E223A22666D3668347042524F707961364678345A7A57643461556A4E79704E75516C776E4353714472642B3454453D222C224368616E676550617373776F72644E6565646564223A66616C73652C224C617465737450617373776F72644368616E676544617465223A22323032312D30332D30395430313A30383A35322E3832222C22456D61696C41646472657373223A2261646D696E40676D61696C2E636F6D222C22526573657450617373776F7264546F6B656E223A6E756C6C2C22436F6E6669726D6174696F6E4E756D626572223A6E756C6C2C22576173436F6E6669726D223A6E756C6C2C22436F6E6669726D6174696F6E44617465223A6E756C6C2C224964656E74727955736572223A312C22456E74727955736572223A2231222C22456E74727944617465223A22323032302D30322D30325430303A30303A3030222C225573657244656C657465223A2231222C224964726F6C65223A312C22496475736572417574686F72697A6174696F6E54797065223A312C224964726F6C654E617669676174696F6E223A6E756C6C2C22496475736572417574686F72697A6174696F6E547970654E617669676174696F6E223A6E756C6C2C22497344656C65746564223A66616C73652C22496464656C65746555736572223A312C2244656C65746544617465223A22323032302D30322D30325430303A30303A3030222C224964223A317D, 0x7B224669727374223A2261646D696E222C224C617374223A2261646D696E222C224163636F756E74223A2261646D696E222C2250617373776F7264223A2262717046584134374454504B3068383557752B6F4A71505139697A51486D37354932784E7A77335A4351424D722B796D6B6D764F656545382B386C784958767A506B2F595A655977426C6D57645777674A504E534C732B6E3059754C57624147662B4C58797A4F34342B37744B66545A7461507A566B3778597A6F543057386C665A4C652B33774D5934363534706A41434944344A4B3762632F32306B646751734B3562675842773476363744414B51544A68705A645568484B4C4D76776E726261652F68514D63364350496A30495834727A76797A43356531635932465966336273537069654A4C366B3752454B595749745374735A72486F33515A336D325A626977576A6369674B395949485A616C4A715170306F6D62454E52744D5445347A69357A737871435A577236473836755366364F6B615472774E4A41342F796F4A714F4B4F48586F41544A76686D676C784E564C413D3D222C2253616C74656450617373776F7264223A227644627754695431506875763033755356474B756C6A374545532B4445622B586B536A4C657A79696D504D3D222C224973416374697665223A747275652C2245787069726544617465223A22323032352D30332D30395430303A30353A35332E3632395A222C2255706461746544617465223A22323032312D30332D30395430313A31303A34372E313032313235322B30313A3030222C22496475706461746555736572223A312C2255706461746555736572223A2261646D696E222C2252656672657368546F6B656E223A22666D3668347042524F707961364678345A7A57643461556A4E79704E75516C776E4353714472642B3454453D222C224368616E676550617373776F72644E6565646564223A66616C73652C224C617465737450617373776F72644368616E676544617465223A22323032312D30332D30395430313A31303A34372E3130323037372B30313A3030222C22456D61696C41646472657373223A2261646D696E40676D61696C2E636F6D222C22526573657450617373776F7264546F6B656E223A6E756C6C2C22436F6E6669726D6174696F6E4E756D626572223A6E756C6C2C22576173436F6E6669726D223A6E756C6C2C22436F6E6669726D6174696F6E44617465223A6E756C6C2C224964656E74727955736572223A312C22456E74727955736572223A2231222C22456E74727944617465223A22323032302D30322D30325430303A30303A3030222C225573657244656C657465223A2231222C224964726F6C65223A312C22496475736572417574686F72697A6174696F6E54797065223A312C224964726F6C654E617669676174696F6E223A6E756C6C2C22496475736572417574686F72697A6174696F6E547970654E617669676174696F6E223A6E756C6C2C22497344656C65746564223A66616C73652C22496464656C65746555736572223A312C2244656C65746544617465223A22323032302D30322D30325430303A30303A3030222C224964223A317D, N'LAPTOP-U57H54T6', N'::1', 1, 1, 0, 1, 1)
GO
INSERT [dbo].[LogDataChange] ([ID], [EntryDate], [IDEntryUser], [EntryUser], [Before], [After], [ComputerName], [IDAddress], [IDLogBrowserType], [IDLogOperatingSystemType], [IsMobileDevice], [IDLogDataChangeStatus], [IDTable]) VALUES (4, CAST(N'2021-03-09 01:14:17.937' AS DateTime), 1, N'admin', 0x7B224669727374223A2261646D696E222C224C617374223A2261646D696E222C224163636F756E74223A2261646D696E222C2250617373776F7264223A2262717046584134374454504B3068383557752B6F4A71505139697A51486D37354932784E7A77335A4351424D722B796D6B6D764F656545382B386C784958767A506B2F595A655977426C6D57645777674A504E534C732B6E3059754C57624147662B4C58797A4F34342B37744B66545A7461507A566B3778597A6F543057386C665A4C652B33774D5934363534706A41434944344A4B3762632F32306B646751734B3562675842773476363744414B51544A68705A645568484B4C4D76776E726261652F68514D63364350496A30495834727A76797A43356531635932465966336273537069654A4C366B3752454B595749745374735A72486F33515A336D325A626977576A6369674B395949485A616C4A715170306F6D62454E52744D5445347A69357A737871435A577236473836755366364F6B615472774E4A41342F796F4A714F4B4F48586F41544A76686D676C784E564C413D3D222C2253616C74656450617373776F7264223A227644627754695431506875763033755356474B756C6A374545532B4445622B586B536A4C657A79696D504D3D222C224973416374697665223A747275652C2245787069726544617465223A22323032352D30332D30395430303A30353A35332E3633222C2255706461746544617465223A22323032312D30332D30395430313A31303A34372E313033222C22496475706461746555736572223A312C2255706461746555736572223A2261646D696E222C2252656672657368546F6B656E223A22666D3668347042524F707961364678345A7A57643461556A4E79704E75516C776E4353714472642B3454453D222C224368616E676550617373776F72644E6565646564223A66616C73652C224C617465737450617373776F72644368616E676544617465223A22323032312D30332D30395430313A31303A34372E313033222C22456D61696C41646472657373223A2261646D696E40676D61696C2E636F6D222C22526573657450617373776F7264546F6B656E223A6E756C6C2C22436F6E6669726D6174696F6E4E756D626572223A6E756C6C2C22576173436F6E6669726D223A6E756C6C2C22436F6E6669726D6174696F6E44617465223A6E756C6C2C224964656E74727955736572223A312C22456E74727955736572223A2231222C22456E74727944617465223A22323032302D30322D30325430303A30303A3030222C225573657244656C657465223A2231222C224964726F6C65223A312C22496475736572417574686F72697A6174696F6E54797065223A312C224964726F6C654E617669676174696F6E223A6E756C6C2C22496475736572417574686F72697A6174696F6E547970654E617669676174696F6E223A6E756C6C2C22497344656C65746564223A66616C73652C22496464656C65746555736572223A312C2244656C65746544617465223A22323032302D30322D30325430303A30303A3030222C224964223A317D, 0x7B224669727374223A2261646D696E222C224C617374223A2261646D696E222C224163636F756E74223A2261646D696E222C2250617373776F7264223A2277715A32735A41594C3336357346727358433275544E6E753966584F5251534F4C7633562B78385147697165494A6B76766C78396D646B736A6F767445334E6767743155526279463541616A44414747376669414B7443597559704F6341375A345571785759554D55672F6D7A524B367463756337483838334F426A6171745147504C6F3332596F316B46505075434C6C4A5069524459485A537056747545384F5A4567453446562B386D623044757251614D7177714B4A635A3174424B30616443627868767673536C4439696D63365363646747796E4A2B37366C41713673674C77324F653149384F6579302F6B6F6B716269566E623543306268376D53746B3957363238503248792B39484362334C50716538626E43774C615A5862564E544F6F5A37713252636253484951624B55544B66527967725A714F665A4D754C536F4C31396A494D634C4874334E35363630506C7A513D3D222C2253616C74656450617373776F7264223A225056387266724142376274537044754C506B6D787A7441394D665748437568436B334E65474674676B56733D222C224973416374697665223A747275652C2245787069726544617465223A22323032352D30332D30395430303A30353A35332E3632395A222C2255706461746544617465223A22323032312D30332D30395430313A31343A31352E3337313134392B30313A3030222C22496475706461746555736572223A312C2255706461746555736572223A2261646D696E222C2252656672657368546F6B656E223A22666D3668347042524F707961364678345A7A57643461556A4E79704E75516C776E4353714472642B3454453D222C224368616E676550617373776F72644E6565646564223A66616C73652C224C617465737450617373776F72644368616E676544617465223A22323032312D30332D30395430313A31343A30392E363033343936332B30313A3030222C22456D61696C41646472657373223A2261646D696E40676D61696C2E636F6D222C22526573657450617373776F7264546F6B656E223A6E756C6C2C22436F6E6669726D6174696F6E4E756D626572223A6E756C6C2C22576173436F6E6669726D223A6E756C6C2C22436F6E6669726D6174696F6E44617465223A6E756C6C2C224964656E74727955736572223A312C22456E74727955736572223A2231222C22456E74727944617465223A22323032302D30322D30325430303A30303A3030222C225573657244656C657465223A2231222C224964726F6C65223A312C22496475736572417574686F72697A6174696F6E54797065223A312C224964726F6C654E617669676174696F6E223A6E756C6C2C22496475736572417574686F72697A6174696F6E547970654E617669676174696F6E223A6E756C6C2C22497344656C65746564223A66616C73652C22496464656C65746555736572223A312C2244656C65746544617465223A22323032302D30322D30325430303A30303A3030222C224964223A317D, N'LAPTOP-U57H54T6', N'::1', 1, 1, 0, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[LogDataChange] OFF
GO
SET IDENTITY_INSERT [dbo].[LogDataChangeStatus] ON 

GO
INSERT [dbo].[LogDataChangeStatus] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (1, N'CHANGE', N'CHANGE', CAST(N'2020-02-01 00:00:00.000' AS DateTime), 1, N'ADMIN')
GO
SET IDENTITY_INSERT [dbo].[LogDataChangeStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[LogInternetBrowserType] ON 

GO
INSERT [dbo].[LogInternetBrowserType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (1, N'Chrome', N'chrome', CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, N'admin')
GO
SET IDENTITY_INSERT [dbo].[LogInternetBrowserType] OFF
GO
INSERT [dbo].[LogOperatingSystemType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (1, N'Window', N'Operating System', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'David')
GO
INSERT [dbo].[LogOperatingSystemType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (2, N'Android', N'Operating System', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'David')
GO
INSERT [dbo].[LogOperatingSystemType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (3, N'IOS', N'Operating System', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'David')
GO
INSERT [dbo].[LogOperatingSystemType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (4, N'MacOS', N'Operating System', CAST(N'2020-03-03 00:00:00.000' AS DateTime), 1, N'David')
GO
INSERT [dbo].[LogOperatingSystemType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (5, N'Other', N'Unidentified System', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'David')
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

GO
INSERT [dbo].[Role] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser], [IsActive], [UpdateDate], [IDUpdateUser], [UpdateUser], [WithPasswordPolicy], [PasswordValidityDays]) VALUES (1, N'Role', N'role', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'admin', 1, CAST(N'2020-02-02 00:00:00.000' AS DateTime), 1, N'admin', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Tables] ON 

GO
INSERT [dbo].[Tables] ([ID], [Title]) VALUES (1, N'User')
GO
SET IDENTITY_INSERT [dbo].[Tables] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([ID], [First], [Last], [Account], [Password], [SaltedPassword], [IsActive], [ExpireDate], [UpdateDate], [IDUpdateUser], [UpdateUser], [RefreshToken], [ChangePasswordNeeded], [LatestPasswordChangeDate], [EmailAddress], [ResetPasswordToken], [ConfirmationNumber], [WasConfirm], [ConfirmationDate], [IDEntryUser], [EntryUser], [EntryDate], [UserDelete], [DeleteDate], [IsDeleted], [IDRole], [IDDeleteUser], [IDUserAuthorizationType]) VALUES (1, N'admin', N'admin', N'admin', N'wqZ2sZAYL365sFrsXC2uTNnu9fXORQSOLv3V+x8QGiqeIJkvvlx9mdksjovtE3Nggt1URbyF5AajDAGG7fiAKtCYuYpOcA7Z4UqxWYUMUg/mzRK6tcuc7H883OBjaqtQGPLo32Yo1kFPPuCLlJPiRDYHZSpVtuE8OZEgE4FV+8mb0DurQaMqwqKJcZ1tBK0adCbxhvvsSlD9imc6ScdgGynJ+76lAq6sgLw2Oe1I8Oey0/kokqbiVnb5C0bh7mStk9W628P2Hy+9HCb3LPqe8bnCwLaZXbVNTOoZ7q2RcbSHIQbKUTKfRygrZqOfZMuLSoL19jIMcLHt3N5660PlzQ==', N'PV8rfrAB7btSpDuLPkmxztA9MfWHCuhCk3NeGFtgkVs=', 1, CAST(N'2025-03-09 00:05:53.630' AS DateTime), CAST(N'2021-03-09 01:14:15.370' AS DateTime), 1, N'admin', N'fm6h4pBROpya6Fx4ZzWd4aUjNypNuQlwnCSqDrd+4TE=', 0, CAST(N'2021-03-09 01:14:09.603' AS DateTime), N'admin@gmail.com', NULL, NULL, NULL, NULL, 1, N'1', CAST(N'2020-02-02 00:00:00.000' AS DateTime), N'1', CAST(N'2020-02-02 00:00:00.000' AS DateTime), 0, 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserAuthorizationType] ON 

GO
INSERT [dbo].[UserAuthorizationType] ([ID], [Title], [Description], [EntryDate], [IDEntryUser], [EntryUser]) VALUES (1, N'Admin', N'1', CAST(N'2020-03-08 00:00:00.000' AS DateTime), 1, N'admin')
GO
SET IDENTITY_INSERT [dbo].[UserAuthorizationType] OFF
GO
ALTER TABLE [dbo].[LogDataChange]  WITH CHECK ADD  CONSTRAINT [FK_LogDataChange_LogDataChangeStatus] FOREIGN KEY([IDLogDataChangeStatus])
REFERENCES [dbo].[LogDataChangeStatus] ([ID])
GO
ALTER TABLE [dbo].[LogDataChange] CHECK CONSTRAINT [FK_LogDataChange_LogDataChangeStatus]
GO
ALTER TABLE [dbo].[LogDataChange]  WITH CHECK ADD  CONSTRAINT [FK_LogDataChange_LogInternetBrowserType] FOREIGN KEY([IDLogBrowserType])
REFERENCES [dbo].[LogInternetBrowserType] ([ID])
GO
ALTER TABLE [dbo].[LogDataChange] CHECK CONSTRAINT [FK_LogDataChange_LogInternetBrowserType]
GO
ALTER TABLE [dbo].[LogDataChange]  WITH CHECK ADD  CONSTRAINT [FK_LogDataChange_LogOperatingSystemType] FOREIGN KEY([IDLogOperatingSystemType])
REFERENCES [dbo].[LogOperatingSystemType] ([ID])
GO
ALTER TABLE [dbo].[LogDataChange] CHECK CONSTRAINT [FK_LogDataChange_LogOperatingSystemType]
GO
ALTER TABLE [dbo].[LogDataChange]  WITH CHECK ADD  CONSTRAINT [FK_LogDataChange_Tables] FOREIGN KEY([IDTable])
REFERENCES [dbo].[Tables] ([ID])
GO
ALTER TABLE [dbo].[LogDataChange] CHECK CONSTRAINT [FK_LogDataChange_Tables]
GO
ALTER TABLE [dbo].[LogFailedAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_LogFailedAuthentication_LogInternetBrowserType] FOREIGN KEY([IDLogBrowserType])
REFERENCES [dbo].[LogInternetBrowserType] ([ID])
GO
ALTER TABLE [dbo].[LogFailedAuthentication] CHECK CONSTRAINT [FK_LogFailedAuthentication_LogInternetBrowserType]
GO
ALTER TABLE [dbo].[LogFailedAuthentication]  WITH CHECK ADD  CONSTRAINT [FK_LogFailedAuthentication_LogOperatingSystemType] FOREIGN KEY([IDLogOperationSystemType])
REFERENCES [dbo].[LogOperatingSystemType] ([ID])
GO
ALTER TABLE [dbo].[LogFailedAuthentication] CHECK CONSTRAINT [FK_LogFailedAuthentication_LogOperatingSystemType]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_LogUserActivity_LogInternetBrowserType] FOREIGN KEY([IDLogBrowserType])
REFERENCES [dbo].[LogInternetBrowserType] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_LogUserActivity_LogInternetBrowserType]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_LogUserActivity_LogOperatingSystemType] FOREIGN KEY([IDLogOperatingSystemType])
REFERENCES [dbo].[LogOperatingSystemType] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_LogUserActivity_LogOperatingSystemType]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_LogUserActivity_LogUserActivityStatus] FOREIGN KEY([IDLogUserActivityStatus])
REFERENCES [dbo].[LogUserActivityStatus] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_LogUserActivity_LogUserActivityStatus]
GO
ALTER TABLE [dbo].[LogUserActivity]  WITH CHECK ADD  CONSTRAINT [FK_LogUserActivity_Module] FOREIGN KEY([IDModule])
REFERENCES [dbo].[Module] ([ID])
GO
ALTER TABLE [dbo].[LogUserActivity] CHECK CONSTRAINT [FK_LogUserActivity_Module]
GO
ALTER TABLE [dbo].[LogUserAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_LogUserAuthorization_LogInternetBrowserType] FOREIGN KEY([IDLogBrowserType])
REFERENCES [dbo].[LogInternetBrowserType] ([ID])
GO
ALTER TABLE [dbo].[LogUserAuthorization] CHECK CONSTRAINT [FK_LogUserAuthorization_LogInternetBrowserType]
GO
ALTER TABLE [dbo].[LogUserAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_LogUserAuthorization_LogOperatingSystemType] FOREIGN KEY([IDLogOperatingSystemType])
REFERENCES [dbo].[LogOperatingSystemType] ([ID])
GO
ALTER TABLE [dbo].[LogUserAuthorization] CHECK CONSTRAINT [FK_LogUserAuthorization_LogOperatingSystemType]
GO
ALTER TABLE [dbo].[LogUserAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_LogUserAuthorization_LogUserAuthorizationStatus] FOREIGN KEY([IDLogUserAuthorizationStatus])
REFERENCES [dbo].[LogUserAuthorizationStatus] ([ID])
GO
ALTER TABLE [dbo].[LogUserAuthorization] CHECK CONSTRAINT [FK_LogUserAuthorization_LogUserAuthorizationStatus]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_Module] FOREIGN KEY([IDModule])
REFERENCES [dbo].[Module] ([ID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_Module]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_Role]
GO
ALTER TABLE [dbo].[RoleAuthorization]  WITH CHECK ADD  CONSTRAINT [FK_RoleAuthorization_RoleAuthorizationType] FOREIGN KEY([IDRoleAuthorizationType])
REFERENCES [dbo].[RoleAuthorizationType] ([ID])
GO
ALTER TABLE [dbo].[RoleAuthorization] CHECK CONSTRAINT [FK_RoleAuthorization_RoleAuthorizationType]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([IDRole])
REFERENCES [dbo].[Role] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserAuthorizationType] FOREIGN KEY([IDUserAuthorizationType])
REFERENCES [dbo].[UserAuthorizationType] ([ID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserAuthorizationType]
GO
USE [master]
GO
ALTER DATABASE [KursiIm] SET  READ_WRITE 
GO
