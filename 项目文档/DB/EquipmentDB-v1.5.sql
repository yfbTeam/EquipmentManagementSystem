USE [master]
GO

/****** Object:  Database [EquipmentDB]    Script Date: 2016/1/12 10:20:17 ******/
CREATE DATABASE [EquipmentDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EquipmentDB', FILENAME = N'C:\EquipmentDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EquipmentDB_log', FILENAME = N'C:\EquipmentDB_log.ldf' , SIZE = 768KB , MAXSIZE = UNLIMITED, FILEGROWTH = 10%)
GO

ALTER DATABASE [EquipmentDB] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EquipmentDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EquipmentDB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EquipmentDB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EquipmentDB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EquipmentDB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EquipmentDB] SET ARITHABORT OFF 
GO

ALTER DATABASE [EquipmentDB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EquipmentDB] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [EquipmentDB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EquipmentDB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EquipmentDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EquipmentDB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EquipmentDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EquipmentDB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EquipmentDB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EquipmentDB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EquipmentDB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EquipmentDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EquipmentDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EquipmentDB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EquipmentDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EquipmentDB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EquipmentDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EquipmentDB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EquipmentDB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EquipmentDB] SET  MULTI_USER 
GO

ALTER DATABASE [EquipmentDB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EquipmentDB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EquipmentDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EquipmentDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EquipmentDB] SET  READ_WRITE 
GO



USE [EquipmentDB]
GO

/****** Object:  Table [dbo].[TeachingPlan]    Script Date: 2016/1/12 9:04:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TeachingPlan](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Contents] [nvarchar](500) NULL,
	[LearnYear] [int] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_TeachingPlan] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TeachingPlan] ADD  CONSTRAINT [DF_TeachingPlan_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[TeachingPlan] ADD  CONSTRAINT [DF_TeachingPlan_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'教学计划表', N'user', N'dbo', N'TABLE', N'TeachingPlan', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'Contents'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'学年学期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'LearnYear'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TeachingPlan', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

/****** Object:  Table [dbo].[PlanExperiment]    Script Date: 2016/1/12 9:15:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PlanExperiment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Contents] [nvarchar](500) NULL,
	[PlanId] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NULL,
 CONSTRAINT [PK_PlanExperiment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[PlanExperiment] ADD  CONSTRAINT [DF_PlanExperiment_Status]  DEFAULT ((0)) FOR [Status]
GO

ALTER TABLE [dbo].[PlanExperiment] ADD  CONSTRAINT [DF_PlanExperiment_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[PlanExperiment] ADD  CONSTRAINT [DF_PlanExperiment_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'教学计划实验表', N'user', N'dbo', N'TABLE', N'PlanExperiment', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实验内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Contents'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教学计划Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'PlanId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0 未生成订单;1 已生成订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PlanExperiment', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

/****** Object:  Table [dbo].[EquipList]    Script Date: 2016/1/12 9:21:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EquipList](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RelationID] [int] NOT NULL,
	[EquipKindId] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_EquipList] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EquipList] ADD  CONSTRAINT [DF_EquipList_Count]  DEFAULT ((0)) FOR [Count]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'设备清单表', N'user', N'dbo', N'TABLE', N'EquipList', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipList', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联表Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipList', @level2type=N'COLUMN',@level2name=N'RelationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipList', @level2type=N'COLUMN',@level2name=N'EquipKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipList', @level2type=N'COLUMN',@level2name=N'Count'
GO


/****** Object:  Table [dbo].[Honor]    Script Date: 2016/1/12 9:24:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Honor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[HonorLevel] [int] NOT NULL,
	[ExperimentId] [int] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_Honor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Honor] ADD  CONSTRAINT [DF_Honor_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Honor] ADD  CONSTRAINT [DF_Honor_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'荣誉表', N'user', N'dbo', N'TABLE', N'Honor', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'奖项名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'HonorLevel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教学计划实验Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'ExperimentId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Honor', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO


/****** Object:  Table [dbo].[OrderInfo]    Script Date: 2016/1/12 9:35:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderNo] [nvarchar](100) NOT NULL,
	[LoanName] [nvarchar](50) NOT NULL,
	[ExperimentId] [int] NOT NULL,
	[Attachment] [nvarchar](100) NULL,
	[Type] [tinyint] NOT NULL,
	[Status] [int] NOT NULL,
	[Remarks] [nvarchar](250) NULL,
	[LendTime] [datetime] NULL,
	[ReturnTime] [datetime] NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_OrderInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_Type]  DEFAULT ((0)) FOR [Type]
GO

ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_Status]  DEFAULT ((0)) FOR [Status]
GO

ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[OrderInfo] ADD  CONSTRAINT [DF_OrderInfo_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'订单表', N'user', N'dbo', N'TABLE', N'OrderInfo', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'OrderNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'借用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'LoanName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教学计划实验Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'ExperimentId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Attachment'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型 0 教学计划订单;1 外借订单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单状态 0 未借出;1 部分借出;2 已借出;3 部分归还 4 完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'借出日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'LendTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'归还日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'ReturnTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderInfo', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

/****** Object:  Table [dbo].[OrderEquipDetail]    Script Date: 2016/1/12 9:39:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrderEquipDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryKindId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
	[InstrumentEquip] [nvarchar](100) NOT NULL,
	[EquipDetailName] [nvarchar](100) NOT NULL,
	[EquipId] [nvarchar](100) NOT NULL,
	[LendTime] [datetime] NULL,
	[ReturnTime] [datetime] NULL,
	[Damage] [nvarchar](300) NULL,
	[Type] [tinyint] NOT NULL,
	[Remarks] [nvarchar](300) NULL,
	[Attachment] [nvarchar](100) NULL,
 CONSTRAINT [PK_OrderEquipDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[OrderEquipDetail] ADD  CONSTRAINT [DF_OrderEquipDetail_Type]  DEFAULT ((0)) FOR [Type]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'订单设备详情表', N'user', N'dbo', N'TABLE', N'OrderEquipDetail', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'InventoryKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'OrderId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'InstrumentEquip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'EquipDetailName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器设备资产' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'EquipId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'借出日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'LendTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'归还日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'ReturnTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'损坏情况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'Damage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 1.未归还；2.归还；3.未借出' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OrderEquipDetail', @level2type=N'COLUMN',@level2name=N'Attachment'
GO

/****** Object:  Table [dbo].[EquipInto]    Script Date: 2016/1/12 9:43:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EquipInto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[EquipKindId] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Creator] [nvarchar](100) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_EquipInto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EquipInto] ADD  CONSTRAINT [DF_EquipInto_Count]  DEFAULT ((0)) FOR [Count]
GO

ALTER TABLE [dbo].[EquipInto] ADD  CONSTRAINT [DF_EquipInto_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[EquipInto] ADD  CONSTRAINT [DF_EquipInto_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'设备入库表', N'user', N'dbo', N'TABLE', N'EquipInto', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'EquipKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipInto', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

/****** Object:  Table [dbo].[InstrumentEquip]    Script Date: 2016/1/12 9:48:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InstrumentEquip](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Number] [nvarchar](100) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Model] [nvarchar](100) NOT NULL,
	[Count] [int] NOT NULL,
	[Unit] [nvarchar](20) NOT NULL,
	[Type] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[Company] [nvarchar](100) NULL,
	[Remarks] [nvarchar](500) NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
	[UseStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_InstrumentEquip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InstrumentEquip] ADD  CONSTRAINT [DF_InstrumentEquip_Count]  DEFAULT ((0)) FOR [Count]
GO

ALTER TABLE [dbo].[InstrumentEquip] ADD  CONSTRAINT [DF_InstrumentEquip_Type]  DEFAULT ((0)) FOR [Type]
GO

ALTER TABLE [dbo].[InstrumentEquip] ADD  CONSTRAINT [DF_InstrumentEquip_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[InstrumentEquip] ADD  CONSTRAINT [DF_InstrumentEquip_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'仪器设备分类表', N'user', N'dbo', N'TABLE', N'InstrumentEquip', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Number'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Model'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Count'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Unit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型 0 非耗材 ;1 耗材' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Company'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用状态 0 启用;1 禁用;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InstrumentEquip', @level2type=N'COLUMN',@level2name=N'UseStatus'
GO

/****** Object:  Table [dbo].[EquipDetail]    Script Date: 2016/1/20 15:47:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EquipDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EquipKindId] [int] NOT NULL,
	[AssetNumber] [nvarchar](100) NOT NULL,
	[EquipIntoID] [int] NOT NULL,
	[EquipStatus] [int] NOT NULL,
	[Barcode] [nvarchar](100) NOT NULL,
	[ClassNumber] [nvarchar](50) NOT NULL,
	[AssetsClassName] [nvarchar](50) NOT NULL,
	[IntlClassCode] [nvarchar](50) NOT NULL,
	[IntlClassName] [nvarchar](50) NOT NULL,
	[AssetName] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[UsageStatus] [nvarchar](50) NOT NULL,
	[UsageDirection] [nvarchar](50) NOT NULL,
	[JYBBBSYFX] [nvarchar](50) NOT NULL,
	[AcquisitionMethod] [nvarchar](50) NOT NULL,
	[AcquisitionDate] [datetime] NOT NULL,
	[BrandStandardModel] [nvarchar](50) NOT NULL,
	[EquipmentUse] [nvarchar](50) NOT NULL,
	[UseDepartment] [nvarchar](50) NOT NULL,
	[UsePeople] [nvarchar](50) NOT NULL,
	[Factory] [nvarchar](50) NOT NULL,
	[StorageLocation] [nvarchar](50) NOT NULL,
	[WorthType] [nvarchar](50) NOT NULL,
	[UseNature] [nvarchar](50) NOT NULL,
	[Worth] [money] NOT NULL,
	[FinanceRecordType] [nvarchar](50) NOT NULL,
	[FiscalFunds] [money] NULL,
	[NonFiscalFunds] [money] NULL,
	[FinanceRecordDate] [datetime] NULL,
	[VoucherNumber] [nvarchar](50) NULL,
	[UseTime] [int] NULL,
	[ExpectedScrapDate] [datetime] NULL,
	[DepreciationState] [nvarchar](50) NULL,
	[NetWorth] [money] NULL,
	[OutFactoryNumber] [nvarchar](50) NULL,
	[Supplier] [nvarchar](50) NULL,
	[FundsSubject] [nvarchar](50) NOT NULL,
	[PurchaseModality] [nvarchar](50) NULL,
	[CountryCode] [nvarchar](50) NOT NULL,
	[Operator] [nvarchar](50) NOT NULL,
	[GuaranteeEndDate] [datetime] NULL,
	[EquipmentNumber] [nvarchar](50) NULL,
	[InvoiceNumber] [nvarchar](50) NULL,
	[CompactNumber] [nvarchar](50) NULL,
	[BasicFunds] [nvarchar](50) NULL,
	[ItemFunds1] [nvarchar](50) NULL,
	[ItemFunds2] [nvarchar](50) NULL,
	[ItemFunds3] [nvarchar](50) NULL,
	[ItemFunds4] [nvarchar](50) NULL,
	[ItemFundsMoney1] [money] NULL,
	[ItemFundsMoney2] [money] NULL,
	[ItemFundsMoney3] [money] NULL,
	[ItemFundsMoney4] [money] NULL,
	[Remarks] [nvarchar](500) NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_EquipDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[EquipDetail] ADD  CONSTRAINT [DF_EquipDetail_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[EquipDetail] ADD  CONSTRAINT [DF_EquipDetail_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'EquipKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'AssetNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备入库Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'EquipIntoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'EquipStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条形码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Barcode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ClassNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'AssetsClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国际分类代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'IntlClassCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国际分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'IntlClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资产名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'AssetName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计量单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Unit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用状况' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UsageStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用方向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UsageDirection'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教育部报表使用方向' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'JYBBBSYFX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取得方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'AcquisitionMethod'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取得日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'AcquisitionDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌及规格型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'BrandStandardModel'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备用途' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'EquipmentUse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用/管理部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UseDepartment'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UsePeople'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'厂家' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Factory'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存放地点' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'StorageLocation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价值类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'WorthType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用性质' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UseNature'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'价值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Worth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财务入账形式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'FinanceRecordType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财政性资金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'FiscalFunds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'非财政性资金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'NonFiscalFunds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'财政入账日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'FinanceRecordDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'凭证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'VoucherNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用年限（月）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UseTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预计报废时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ExpectedScrapDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'折旧状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'DepreciationState'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'净值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'NetWorth'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出厂号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'OutFactoryNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供货商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Supplier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经费科目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'FundsSubject'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购组织形式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'PurchaseModality'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'国别码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'CountryCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经手人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Operator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保修截止日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'GuaranteeEndDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'EquipmentNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发票号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'InvoiceNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'合同号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'CompactNumber'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基本经费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'BasicFunds'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFunds1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFunds2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFunds3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFunds4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费1金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFundsMoney1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费1金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFundsMoney2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费1金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFundsMoney3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'项目经费1金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'ItemFundsMoney4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器设备详情表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EquipDetail'
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 2016/1/12 9:58:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[InventoryNo] [nvarchar](200) NOT NULL,
	[InventoryTime] [datetime] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[Operator] [nvarchar](100) NOT NULL,
	[Status] [tinyint] NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF_Inventory_Status]  DEFAULT ((0)) FOR [Status]
GO

ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF_Inventory_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Inventory] ADD  CONSTRAINT [DF_Inventory_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'盘点单表', N'user', N'dbo', N'TABLE', N'Inventory', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'InventoryNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'InventoryTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'经办人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Operator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0 未盘点;1 已盘点；2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除 0 正常;1 删除;2归档' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Inventory', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

/****** Object:  Table [dbo].[InventoryEquipKind]    Script Date: 2016/1/12 10:01:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryEquipKind](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryId] [int] NOT NULL,
	[InventoryKindId] [int] NOT NULL,
	[InstrumentEquip] [nvarchar](100) NOT NULL,
	[Quantity] [int] NOT NULL,
	[RealQuantity] [int] NOT NULL,
	[BorrowQuantity] [int] NOT NULL,
	[LossQuantity] [int] NOT NULL,
 CONSTRAINT [PK_InventoryEquipKind] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InventoryEquipKind] ADD  CONSTRAINT [DF_InventoryEquipKind_Quantity]  DEFAULT ((0)) FOR [Quantity]
GO

ALTER TABLE [dbo].[InventoryEquipKind] ADD  CONSTRAINT [DF_InventoryEquipKind_RealQuantity]  DEFAULT ((0)) FOR [RealQuantity]
GO

ALTER TABLE [dbo].[InventoryEquipKind] ADD  CONSTRAINT [DF_InventoryEquipKind_BorrowQuantity]  DEFAULT ((0)) FOR [BorrowQuantity]
GO

ALTER TABLE [dbo].[InventoryEquipKind] ADD  CONSTRAINT [DF_InventoryEquipKind_LossQuantity]  DEFAULT ((0)) FOR [LossQuantity]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'盘点单设备统计表', N'user', N'dbo', N'TABLE', N'InventoryEquipKind', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点单Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'InventoryId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'InventoryKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'InstrumentEquip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账面数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'Quantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实盘数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'RealQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外借数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'BorrowQuantity'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺失数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipKind', @level2type=N'COLUMN',@level2name=N'LossQuantity'
GO


/****** Object:  Table [dbo].[InventoryEquipDetail]    Script Date: 2016/1/12 10:04:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[InventoryEquipDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[InventoryKindId] [int] NOT NULL,
	[InstrumentEquip] [nvarchar](100) NOT NULL,
	[EquipDetailName] [nvarchar](100) NOT NULL,
	[EquipId] [int] NOT NULL,
	[Status] [int] NOT NULL,
	[IsLoss] [bit] NOT NULL,
 CONSTRAINT [PK_InventoryEquipDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[InventoryEquipDetail] ADD  CONSTRAINT [DF_InventoryEquipDetail_Status]  DEFAULT ((0)) FOR [Status]
GO

ALTER TABLE [dbo].[InventoryEquipDetail] ADD  CONSTRAINT [DF_InventoryEquipDetail_IsLoss]  DEFAULT ((0)) FOR [IsLoss]
GO

EXECUTE sp_addextendedproperty N'MS_Description', N'盘点单设备详情表', N'user', N'dbo', N'TABLE', N'InventoryEquipDetail', NULL, NULL
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备分类Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'InventoryKindId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'InstrumentEquip'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设备名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'EquipDetailName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仪器设备Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'EquipId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'状态 0  未借出 ; 1 已借出;2 维修;3 停用;4 报废' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'Status'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否缺失 0 不缺失; 1 缺失' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InventoryEquipDetail', @level2type=N'COLUMN',@level2name=N'IsLoss'
GO

/****** Object:  Table [dbo].[Role]    Script Date: 2016/1/13 9:35:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Role] ADD  CONSTRAINT [DF_Role_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除(0 正常;1 删除;2归档)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Role'
GO


/****** Object:  Table [dbo].[RoleOfMenu]    Script Date: 2016/1/13 9:35:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleOfMenu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
 CONSTRAINT [PK_RoleOfMenu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfMenu', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfMenu', @level2type=N'COLUMN',@level2name=N'RoleId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfMenu', @level2type=N'COLUMN',@level2name=N'MenuId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色菜单关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfMenu'
GO

/****** Object:  Table [dbo].[RoleOfUser]    Script Date: 2016/1/13 9:34:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RoleOfUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_RoleOfUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfUser', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfUser', @level2type=N'COLUMN',@level2name=N'RoleId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfUser', @level2type=N'COLUMN',@level2name=N'LoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色用户关系表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'RoleOfUser'
GO


/****** Object:  Table [dbo].[MenuInfo]    Script Date: 2016/1/13 9:34:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MenuInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Pid] [int] NOT NULL,
	[Url] [nvarchar](200) NULL,
	[Description] [nvarchar](300) NULL,
	[isMeu] [bit] NOT NULL,
	[isShow] [tinyint] NOT NULL,
 CONSTRAINT [PK_MenuInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单父Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'Pid'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单Url' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'Url'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否菜单(0.非菜单；1.菜单)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'isMeu'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否显示菜单(0.不显示;1.显示导航;2.显示权限列表;3.都显示)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo', @level2type=N'COLUMN',@level2name=N'isShow'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'菜单信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MenuInfo'
GO

/****** Object:  Table [dbo].[Warehouse]    Script Date: 2016/1/13 9:31:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Warehouse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Remarks] [nvarchar](300) NULL,
	[PlaneGraph] [nvarchar](300) NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
	[UseStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF_Warehouse_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[Warehouse] ADD  CONSTRAINT [DF_Warehouse_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平面图' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'PlaneGraph'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除(0 正常;1 删除;2归档)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用状态 0 启用;1 禁用;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'UseStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse'
GO

/****** Object:  Table [dbo].[UserInfo]    Script Date: 2016/1/13 9:30:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](100) NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[IsDelete] [tinyint] NOT NULL,
	[Sex] [nchar](10) NULL,
	[KaNo] [nvarchar](100) NULL,
	[KaLv] [nchar](10) NULL,
	[UseStatus] [tinyint] NOT NULL,
 CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'LoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'PassWord'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否删除(0 正常;1 删除;2归档)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'IsDelete'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'Sex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'KaNo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'卡等级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'KaLv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用状态 0 启用;1 禁用;' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo', @level2type=N'COLUMN',@level2name=N'UseStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'UserInfo'
GO

/****** Object:  Table [dbo].[LogInfo]    Script Date: 2016/1/13 9:28:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LogInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [nvarchar](50) NOT NULL,
	[IP] [nvarchar](100) NOT NULL,
	[Module] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Operation] [nvarchar](200) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Remarks] [nvarchar](300) NULL,
 CONSTRAINT [PK_LogInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[LogInfo] ADD  CONSTRAINT [DF_LogInfo_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户登录名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'LoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当前IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'IP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'Module'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'Type'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'Operation'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LogInfo'
GO

/****** Object:  Table [dbo].[Dictionary]    Script Date: 2016/1/13 9:27:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Dictionary](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[PID] [int] NOT NULL,
	[Path] [nvarchar](50) NOT NULL,
	[Creator] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[Editor] [nvarchar](50) NULL,
	[UpdateTime] [datetime] NULL,
	[Remarks] [nvarchar](100) NULL,
 CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Dictionary] ADD  CONSTRAINT [DF_Dictionary_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Name'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'PID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Path'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Editor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary', @level2type=N'COLUMN',@level2name=N'Remarks'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字典表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Dictionary'
GO

