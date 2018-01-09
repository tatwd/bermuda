USE [master]
GO
/****** Object:  Database [bermuda]    Script Date: 2018/1/4 11:07:34 ******/
CREATE DATABASE [bermuda]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bermuda', FILENAME = N'E:\studiospace\Database\_msserver\bermuda\bermuda.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'bermuda_log', FILENAME = N'E:\studiospace\Database\_msserver\bermuda\bermuda_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [bermuda] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bermuda].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bermuda] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bermuda] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bermuda] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bermuda] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bermuda] SET ARITHABORT OFF 
GO
ALTER DATABASE [bermuda] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bermuda] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [bermuda] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bermuda] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bermuda] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bermuda] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bermuda] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bermuda] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bermuda] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bermuda] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bermuda] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bermuda] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bermuda] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bermuda] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bermuda] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bermuda] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bermuda] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bermuda] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bermuda] SET RECOVERY FULL 
GO
ALTER DATABASE [bermuda] SET  MULTI_USER 
GO
ALTER DATABASE [bermuda] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bermuda] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bermuda] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bermuda] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'bermuda', N'ON'
GO
USE [bermuda]
GO
/****** Object:  Table [dbo].[bmd_root]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bmd_root](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](40) NULL,
	[permission] [smallint] NULL,
	[phone_number] [varchar](11) NULL,
	[email] [varchar](200) NULL,
	[avatar] [varchar](200) NULL,
	[remark] [varchar](200) NULL,
 CONSTRAINT [pk_bmd_root] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bmd_user]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bmd_user](
	[id] [bigint] IDENTITY(10001,1) NOT NULL,
	[name] [varchar](40) NOT NULL,
	[phone_number] [varchar](11) NULL,
	[email] [varchar](200) NULL,
	[type] [varchar](20) NULL,
	[pwd] [varchar](16) NOT NULL,
	[avatar] [varchar](200) NULL CONSTRAINT [DF_bmd_user_avatar]  DEFAULT ('/assets/avatar-tmp.svg'),
	[rate] [int] NULL CONSTRAINT [DF_bmd_user_rate]  DEFAULT ((0)),
	[following_count] [bigint] NULL CONSTRAINT [DF_bmd_user_following_count]  DEFAULT ((0)),
	[follower_count] [bigint] NULL CONSTRAINT [DF_bmd_user_follower_count]  DEFAULT ((0)),
 CONSTRAINT [pk_bmd_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[current]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[current](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[title] [varchar](100) NULL,
	[contents] [text] NULL,
	[publish_date] [datetime] NULL,
	[cmnt_count] [bigint] NULL CONSTRAINT [DF_current_cmnt_count]  DEFAULT ((0)),
	[star_count] [bigint] NULL CONSTRAINT [DF_current_star_count]  DEFAULT ((0)),
	[praise_count] [bigint] NULL CONSTRAINT [DF_current_praise_count]  DEFAULT ((0)),
 CONSTRAINT [pk_current] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[current_cmnt]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[current_cmnt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[current_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[cmnt_date] [datetime] NULL,
	[praise_count] [bigint] NULL,
	[reply_count] [bigint] NULL,
 CONSTRAINT [PK_current_cmnt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[current_reply]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[current_reply](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[current_id] [bigint] NULL,
	[aims_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[reply_date] [datetime] NULL,
	[praise_count] [bigint] NULL,
 CONSTRAINT [pk_current_reply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[current_star]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[current_star](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[current_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[star_date] [datetime] NULL,
 CONSTRAINT [pk_current_star] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[follow]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[follow](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[following_id] [bigint] NULL,
 CONSTRAINT [PK_follow_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[goods]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goods](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[name] [varchar](100) NULL,
	[type] [varchar](10) NULL,
	[category] [varchar](20) NULL,
	[qty] [int] NULL,
	[img] [varchar](200) NULL,
	[detail] [varchar](200) NULL,
	[cmnt_count] [bigint] NULL,
	[praise_count] [bigint] NULL,
	[status] [char](4) NULL,
	[remark] [varchar](200) NULL,
 CONSTRAINT [pk_goods] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[goods_cmnt]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goods_cmnt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[goods_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[cmnt_date] [datetime] NULL,
	[praise_count] [bigint] NULL,
	[reply_count] [bigint] NULL,
 CONSTRAINT [pk_goods_cmnt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[goods_reply]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[goods_reply](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[cmnt_id] [bigint] NULL,
	[aims_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[reply_date] [datetime] NULL,
	[praise_count] [bigint] NULL,
 CONSTRAINT [pk_goods_reply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notice]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notice](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[user_id] [bigint] NULL,
	[species_id] [bigint] NULL,
	[type] [char](8) NULL,
	[title] [varchar](100) NULL,
	[place] [varchar](100) NULL,
	[location] [varchar](200) NULL,
	[lf_date] [varchar](100) NULL,
	[img] [varchar](200) NULL,
	[contact_way] [varchar](200) NULL,
	[detail] [varchar](280) NULL,
	[publish_date] [datetime] NULL,
	[cmnt_count] [bigint] NULL CONSTRAINT [DF_notice_cmnt_count]  DEFAULT ((0)),
	[trace_count] [bigint] NULL CONSTRAINT [DF_notice_trace_count]  DEFAULT ((0)),
	[status] [varchar](20) NULL,
 CONSTRAINT [pk_notice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notice_cmnt]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notice_cmnt](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[notice_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[cmnt_date] [datetime] NULL,
	[reply_count] [bigint] NULL CONSTRAINT [DF_notice_cmnt_reply_count]  DEFAULT ((0)),
	[praise_count] [bigint] NULL CONSTRAINT [DF_notice_cmnt_praise_count]  DEFAULT ((0)),
 CONSTRAINT [pk_notice_cmnt] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notice_reply]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[notice_reply](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[cmnt_id] [bigint] NULL,
	[aims_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[contents] [varchar](280) NULL,
	[reply_date] [datetime] NULL,
	[praise_count] [bigint] NULL CONSTRAINT [DF_notice_reply_praise_count]  DEFAULT ((0)),
 CONSTRAINT [pk_notice_reply] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[notice_trace]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[notice_trace](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[notice_id] [bigint] NULL,
	[user_id] [bigint] NULL,
	[trace_date] [datetime] NULL,
 CONSTRAINT [pk_notice_trace] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[species]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[species](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](20) NULL,
	[img] [varchar](200) NULL,
	[notice_count] [bigint] NULL CONSTRAINT [DF_species_notice_count]  DEFAULT ((0)),
 CONSTRAINT [pk_species] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[topic]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[topic](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[user_id] [bigint] NULL,
	[detail] [varchar](100) NULL,
	[join_count] [bigint] NULL CONSTRAINT [DF_topic_join_count]  DEFAULT ((0)),
	[create_date] [datetime] NULL,
	[img] [varchar](200) NULL,
	[is_passed] [tinyint] NULL CONSTRAINT [DF_topic_is_passed]  DEFAULT ((0)),
 CONSTRAINT [pk_topic] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[topic_join]    Script Date: 2018/1/4 11:07:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[topic_join](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[topic_id] [bigint] NULL,
	[current_id] [bigint] NULL,
 CONSTRAINT [pk_topic_join] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [bermuda] SET  READ_WRITE 
GO
