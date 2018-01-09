USE [master]
GO
/****** Object:  Database [bermuda]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[bmd_root]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[bmd_user]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[current]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[current_cmnt]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[current_reply]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[current_star]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[follow]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[goods]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[goods_cmnt]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[goods_reply]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[notice]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[notice_cmnt]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[notice_reply]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[notice_trace]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[species]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[topic]    Script Date: 2018/1/4 11:08:27 ******/
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
/****** Object:  Table [dbo].[topic_join]    Script Date: 2018/1/4 11:08:27 ******/
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
SET IDENTITY_INSERT [dbo].[bmd_user] ON 

INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10001, N'Bermuda', NULL, NULL, NULL, N'bmd123456', N'/assets/logo.svg', 9999, 0, 3)
INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10002, N'test', NULL, N'leoking9641@hotmail.com', NULL, N'123456', N'/assets/avatar-tmp.svg', 0, 1, 0)
INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10003, N'_ki', NULL, N'jaronking@163.com', NULL, N'123456', N'/assets/avatar-tmp.svg', 0, 1, 0)
INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10004, N'sam', NULL, N'1792696258@qq.com', NULL, N'123456', N'/assets/avatar-tmp.svg', 0, 0, 0)
INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10005, N'hnsn', NULL, N'773510678@qq.com', NULL, N'123456', N'/assets/avatar-tmp.svg', 0, 0, 0)
INSERT [dbo].[bmd_user] ([id], [name], [phone_number], [email], [type], [pwd], [avatar], [rate], [following_count], [follower_count]) VALUES (10006, N'fc', NULL, N'1255356602@qq.com', NULL, N'123456', N'/assets/avatar-tmp.svg', 0, 1, 0)
SET IDENTITY_INSERT [dbo].[bmd_user] OFF
SET IDENTITY_INSERT [dbo].[current] ON 

INSERT [dbo].[current] ([id], [user_id], [title], [contents], [publish_date], [cmnt_count], [star_count], [praise_count]) VALUES (1, 10002, N'这个活动有点意思', N'这个活动有点意思', CAST(N'2017-12-08 00:00:00.000' AS DateTime), 0, 0, 100)
INSERT [dbo].[current] ([id], [user_id], [title], [contents], [publish_date], [cmnt_count], [star_count], [praise_count]) VALUES (2, 10003, N'测试动态', N'<p>说实话，我也不知道有么有用。</p>', CAST(N'2018-01-02 15:09:01.837' AS DateTime), 0, 0, 0)
INSERT [dbo].[current] ([id], [user_id], [title], [contents], [publish_date], [cmnt_count], [star_count], [praise_count]) VALUES (3, 10003, N'再写一个测试动态', N'<p>看看能不能成功啊。。。<img src="http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/50/pcmoren_huaixiao_org.png" alt="[坏笑]" data-w-e="1"></p>', CAST(N'2018-01-03 15:11:56.433' AS DateTime), 0, 0, 0)
INSERT [dbo].[current] ([id], [user_id], [title], [contents], [publish_date], [cmnt_count], [star_count], [praise_count]) VALUES (4, 10002, N'最后一个测试动态啊', N'<p>希望是最后一个测试动态<img src="http://img.t.sinajs.cn/t4/appstyle/expression/ext/normal/2c/moren_yunbei_org.png" alt="[允悲]" data-w-e="1"></p>', CAST(N'2018-01-03 15:18:06.463' AS DateTime), 0, 0, 0)
INSERT [dbo].[current] ([id], [user_id], [title], [contents], [publish_date], [cmnt_count], [star_count], [praise_count]) VALUES (10005, 10002, N'山东黄金华发商都', N'<p>vzvxczv</p><p><br></p>', CAST(N'2018-01-04 08:46:50.400' AS DateTime), 0, 0, 0)
SET IDENTITY_INSERT [dbo].[current] OFF
SET IDENTITY_INSERT [dbo].[follow] ON 

INSERT [dbo].[follow] ([id], [user_id], [following_id]) VALUES (1, 10002, 10001)
INSERT [dbo].[follow] ([id], [user_id], [following_id]) VALUES (2, 10003, 10001)
INSERT [dbo].[follow] ([id], [user_id], [following_id]) VALUES (10002, 20005, 10001)
SET IDENTITY_INSERT [dbo].[follow] OFF
SET IDENTITY_INSERT [dbo].[notice] ON 

INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (1, 10002, 5, N'寻物启示', N'在三食堂丢失一个钱包', N'三食堂三楼', N'江西师范大学瑶湖校区', N'2017年12月5号上午', N'/assets/img/notice/wallet.jpg', N'18170826687', N'黑色钱包，内有身份证、校园卡，钱若干', CAST(N'2017-12-06 00:00:00.000' AS DateTime), 1, 3, N'未找回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (2, 10001, 4, N'招领启示', N'惟义楼W2312拾得一眼镜', N'惟义楼W2312', N'江西师范大学瑶湖校区', N'2017年12月6日下午', N'/assets/img/notice/glasses.jpg', N'18170826687', N'黑色边框眼镜，其上刻有“SUPER SUNG”等字样', CAST(N'2017-12-10 00:00:00.000' AS DateTime), 2, 3, N'已领回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (3, 10002, 7, N'寻物启示', N'在先骕楼X2407机房丢失一本书', N'先骕楼X2407机房', N'江西师范大学瑶湖校区', N'2017年12月24日晚', N'/assets/img/notice/book.jpg', N'18170826687', N'书名《西湖梦寻》，作者张岱，有图书馆标签，希望捡到的马上联系我。', CAST(N'2017-12-24 00:00:00.000' AS DateTime), 3, 2, N'未找回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (5, 10002, 9, N'寻物启示', N'This is a test notice', N'先骕楼X3522', NULL, N'2017.12.28 上午', N'/public/img/10002/2017122911003631-ubuntukylin.svg', N'QQ:1203953195', N'These are test details.', CAST(N'2017-12-29 11:00:36.317' AS DateTime), 1, 2, N'未找回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (6, 10003, 8, N'招领启示', N'我捡到了几个娃，有人丢了么？', N'正大广场', NULL, N'2017年12月31日 下午', N'/public/img/10003/2017123116010847-wawa.jpg', N'QQ:1203953195', N'说实话，头一次见人丢这么多东西，比我还健忘。如果是你的，请联系我。。。', CAST(N'2017-12-31 16:01:08.480' AS DateTime), 3, 2, N'已领回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (7, 10004, 4, N'寻物启示', N'我丢了熊猫挂件', N'惟义楼', NULL, N'12.1', N'/public/img/10004/2018010321404722-avatar.jpg', N'1792696258', N'啦啦啦啦啦', CAST(N'2018-01-03 21:40:47.227' AS DateTime), 1, 2, N'未找回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (8, 10003, 2, N'寻物启示', N'测试启示', N'先骕楼', NULL, N'2017年12月31日 下午', N'/public/img/10003/2018010321475303-avatar.jpg', N'18170826687', N'test notice', CAST(N'2018-01-03 21:47:53.050' AS DateTime), 3, 2, N'未找回')
INSERT [dbo].[notice] ([id], [user_id], [species_id], [type], [title], [place], [location], [lf_date], [img], [contact_way], [detail], [publish_date], [cmnt_count], [trace_count], [status]) VALUES (9, 10005, 6, N'招领启示', N'我捡到一本本子！', N'先骕楼3522工作室', NULL, N'2018-1-4', N'/public/img/20005/2018010409313398-20180104_092526.jpg', N'18970439630', N'本子里面有很多工作室笔记', CAST(N'2018-01-04 09:31:34.043' AS DateTime), 3, 2, N'未领回')
SET IDENTITY_INSERT [dbo].[notice] OFF
SET IDENTITY_INSERT [dbo].[notice_cmnt] ON 

INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (1, 2, 10002, N'如果我看到了，我会联系你的', CAST(N'2017-12-19 18:20:00.000' AS DateTime), 2, 1)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (2, 1, 10001, N'看到了会通知你的哦', CAST(N'2017-12-23 17:02:52.380' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (3, 2, 10002, N'被我同学捡到了', CAST(N'2017-12-23 17:10:22.780' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (4, 3, 10002, N'求求大家帮忙扩散一下。。。', CAST(N'2017-12-29 11:09:00.717' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (5, 6, 10002, N'可惜不是我的', CAST(N'2017-12-31 16:05:07.120' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (6, 6, 10002, N'test', CAST(N'2018-01-03 14:20:39.003' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (7, 6, 10003, N'test comments', CAST(N'2018-01-03 21:49:01.187' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (8, 8, 10002, N'dasd', CAST(N'2018-01-04 08:44:35.160' AS DateTime), 1, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (9, 8, 10002, N'dasduiuoiko', CAST(N'2018-01-04 08:44:56.687' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (10, 7, 10002, N'test', CAST(N'2018-01-04 09:17:05.267' AS DateTime), 3, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (11, 9, 10002, N'test comment', CAST(N'2018-01-04 10:31:51.037' AS DateTime), 5, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (12, 9, 10002, N'test comment', CAST(N'2018-01-04 10:31:53.643' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (13, 9, 10001, N'我有话说', CAST(N'2018-01-04 10:47:50.343' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (14, 8, 10001, N'我没看到', CAST(N'2018-01-04 10:52:12.060' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (15, 5, 10001, N'路过。。。', CAST(N'2018-01-04 10:53:55.420' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (16, 3, 10001, N'路过。。。', CAST(N'2018-01-04 11:00:14.457' AS DateTime), 0, 0)
INSERT [dbo].[notice_cmnt] ([id], [notice_id], [user_id], [contents], [cmnt_date], [reply_count], [praise_count]) VALUES (17, 3, 10001, N'再来一条', CAST(N'2018-01-04 11:01:55.057' AS DateTime), 0, 0)
SET IDENTITY_INSERT [dbo].[notice_cmnt] OFF
SET IDENTITY_INSERT [dbo].[notice_reply] ON 

INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (1, 1, NULL, 10001, N'十分感谢！', CAST(N'2017-12-19 18:30:00.000' AS DateTime), 1)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (2, 1, 1, 10002, N'不客气！', CAST(N'2017-12-20 00:00:00.000' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (7, 1, 2, 10001, N'test reply', CAST(N'2017-12-23 14:06:52.003' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (8, 2, NULL, 10002, N'谢谢', CAST(N'2017-12-23 17:03:51.003' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (9, 1, 7, 10002, N'。。。', CAST(N'2017-12-23 21:04:36.710' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (10, 3, NULL, 10002, N'test', CAST(N'2018-01-03 14:20:11.610' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (11, 3, 11, 10002, N'test', CAST(N'2018-01-03 14:20:25.510' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (12, 4, NULL, 10003, N'test', CAST(N'2018-01-03 21:49:19.120' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (13, 6, NULL, 10002, N'dshs', CAST(N'2018-01-04 08:45:34.463' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (14, 5, NULL, 10002, N'test', CAST(N'2018-01-04 09:28:01.307' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (15, 11, NULL, 10002, N'test reply 2018 1 4', CAST(N'2018-01-04 10:35:45.350' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (16, 11, 15, 10002, N'2nd repky', CAST(N'2018-01-04 10:36:59.760' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (17, 11, 16, 10002, N'3nd', CAST(N'2018-01-04 10:42:00.040' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (18, 11, 16, 10002, N'3nd', CAST(N'2018-01-04 10:42:02.493' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (19, 11, 16, 10002, N'3nd', CAST(N'2018-01-04 10:42:04.980' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (20, 10, NULL, 10002, N'test reply test user', CAST(N'2018-01-04 10:43:28.373' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (21, 10, 20, 10002, N'ok ok ?', CAST(N'2018-01-04 10:44:02.967' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (22, 10, 21, 10002, N'no no no', CAST(N'2018-01-04 10:45:41.670' AS DateTime), 0)
INSERT [dbo].[notice_reply] ([id], [cmnt_id], [aims_id], [user_id], [contents], [reply_date], [praise_count]) VALUES (23, 8, NULL, 10001, N'我没话说', CAST(N'2018-01-04 10:51:56.937' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[notice_reply] OFF
SET IDENTITY_INSERT [dbo].[notice_trace] ON 

INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (1, 1, 10002, CAST(N'2017-12-10 00:00:00.000' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (2, 2, 10002, CAST(N'2017-12-10 00:00:00.000' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (3, 1, 10001, CAST(N'2017-12-10 00:00:00.000' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (4, 2, 10001, CAST(N'2017-12-15 19:40:22.933' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (5, 6, 10002, CAST(N'2017-12-31 16:04:49.403' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (6, 5, 10002, CAST(N'2018-01-01 12:11:10.900' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (7, 3, 10002, CAST(N'2018-01-01 12:11:16.037' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (8, 5, 10003, CAST(N'2018-01-01 12:15:12.003' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (9, 2, 10003, CAST(N'2018-01-01 12:15:19.403' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (10, 1, 10003, CAST(N'2018-01-01 12:15:21.203' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (11, 6, 10003, CAST(N'2018-01-01 12:16:38.727' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (12, 7, 10003, CAST(N'2018-01-03 21:48:34.167' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (13, 8, 10003, CAST(N'2018-01-03 21:48:35.983' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (14, 7, 10002, CAST(N'2018-01-04 08:31:27.857' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (15, 8, 10002, CAST(N'2018-01-04 08:31:29.637' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (16, 6, 10003, CAST(N'2018-01-04 09:31:39.717' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (17, 9, 10003, CAST(N'2018-01-04 09:42:38.307' AS DateTime))
INSERT [dbo].[notice_trace] ([id], [notice_id], [user_id], [trace_date]) VALUES (18, 3, 10003, CAST(N'2018-01-04 09:48:18.180' AS DateTime))
SET IDENTITY_INSERT [dbo].[notice_trace] OFF
SET IDENTITY_INSERT [dbo].[species] ON 

INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (1, N'钱', N'assets/img/species/money.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (2, N'卡类', N'assets/img/species/card.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (3, N'证件', N'assets/img/species/cred.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (4, N'饰品', N'assets/img/species/acce.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (5, N'箱包', N'assets/img/species/bag.jpg', 1)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (6, N'文具', N'assets/img/species/stati.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (7, N'图书', N'assets/img/species/book.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (8, N'生活用具', N'assets/img/species/living.jpg', 0)
INSERT [dbo].[species] ([id], [name], [img], [notice_count]) VALUES (9, N'电子数码', N'assets/img/species/elect.jpg', 0)
SET IDENTITY_INSERT [dbo].[species] OFF
SET IDENTITY_INSERT [dbo].[topic] ON 

INSERT [dbo].[topic] ([id], [name], [user_id], [detail], [join_count], [create_date], [img], [is_passed]) VALUES (1, N'义卖进行中', 10002, N'义卖活动', 1, CAST(N'2017-12-06 00:00:00.000' AS DateTime), N'/assets/img/topic/bike.jpg', 1)
INSERT [dbo].[topic] ([id], [name], [user_id], [detail], [join_count], [create_date], [img], [is_passed]) VALUES (2, N'test topic', 10001, N'这是一个测试话题', 4, CAST(N'2018-01-02 00:00:00.000' AS DateTime), N'/assets/img/topic/help.jpg', 1)
INSERT [dbo].[topic] ([id], [name], [user_id], [detail], [join_count], [create_date], [img], [is_passed]) VALUES (3, N'测试话题', 10003, N'这是测试话题', 0, CAST(N'2018-01-03 21:15:57.013' AS DateTime), N'/public/img/10003/2018010321155701-avatar.jpg', 1)
SET IDENTITY_INSERT [dbo].[topic] OFF
SET IDENTITY_INSERT [dbo].[topic_join] ON 

INSERT [dbo].[topic_join] ([id], [topic_id], [current_id]) VALUES (1, 1, 1)
INSERT [dbo].[topic_join] ([id], [topic_id], [current_id]) VALUES (2, 2, 2)
INSERT [dbo].[topic_join] ([id], [topic_id], [current_id]) VALUES (3, 2, 3)
INSERT [dbo].[topic_join] ([id], [topic_id], [current_id]) VALUES (4, 2, 4)
INSERT [dbo].[topic_join] ([id], [topic_id], [current_id]) VALUES (10003, 2, 10005)
SET IDENTITY_INSERT [dbo].[topic_join] OFF
/****** Object:  Trigger [dbo].[insert_follow]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_follow] on [dbo].[follow]
for insert
as
begin
  update [bmd_user] set [bmd_user].following_count += 1
  from [bmd_user], inserted
  where [bmd_user].id = inserted.user_id

  update [bmd_user] set [bmd_user].follower_count += 1
  from [bmd_user], inserted
  where [bmd_user].id = inserted.following_id
end

GO
/****** Object:  Trigger [dbo].[insert_notice]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_notice] on [dbo].[notice]
for insert
as
begin 
  update notice
  set notice.status = '未找回'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like '寻物%'

  update notice
  set notice.status = '未领回'
  from notice, inserted
  where notice.id = inserted.id
    and notice.type like '招领%'
end

GO
/****** Object:  Trigger [dbo].[insert_notice_cmnt]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_notice_cmnt] on [dbo].[notice_cmnt]
for insert
as 
begin 
   update notice set cmnt_count += 1
   from notice, inserted
   where notice.id = inserted.notice_id
end

GO
/****** Object:  Trigger [dbo].[insert_notice_reply]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_notice_reply] on [dbo].[notice_reply]
for insert
as 
begin 
   update notice_cmnt set reply_count += 1
   from notice_cmnt, inserted
   where notice_cmnt.id = inserted.cmnt_id
end

GO
/****** Object:  Trigger [dbo].[delete_notice_trace]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[delete_notice_trace] on [dbo].[notice_trace]
for delete
as 
begin 
   update notice set trace_count -= 1
   from notice, deleted
   where notice.id = deleted.notice_id
end

GO
/****** Object:  Trigger [dbo].[insert_notice_trace]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_notice_trace] on [dbo].[notice_trace]
for insert
as 
begin 
   update notice set trace_count += 1
   from notice, inserted
   where notice.id = inserted.notice_id
end

GO
/****** Object:  Trigger [dbo].[insert_topic_join]    Script Date: 2018/1/4 11:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create trigger [dbo].[insert_topic_join] on [dbo].[topic_join]
for insert
as 
begin 
   update topic set join_count += 1
   from topic, inserted
   where topic.id = inserted.topic_id
end
GO
USE [master]
GO
ALTER DATABASE [bermuda] SET  READ_WRITE 
GO
