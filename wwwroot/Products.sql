USE [improweb2022]
GO

/****** Object:  Table [dbo].[Products]    Script Date: 02/08/2023 16:56:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products](
	[ProdID] [bigint] IDENTITY(1,1) NOT NULL,
	[OrgID] [bigint] NULL,
	[ProductCode] [nvarchar](50) NULL,
	[ManufID] [bigint] NULL,
	[ManufCode] [nvarchar](50) NULL,
	[Description] [nvarchar](1000) NULL,
	[LongDescription] [nvarchar](4000) NULL,
	[PurchasePrice] [money] NULL,
	[PriceExclVat1] [money] NULL,
	[MarkupUsed1] [float] NULL,
	[PriceExclVat2] [money] NULL,
	[MarkupUsed2] [float] NULL,
	[PriceExclVat3] [money] NULL,
	[MarkupUsed3] [float] NULL,
	[PriceExclVat4] [money] NULL,
	[MarkupUsed4] [float] NULL,
	[PriceExclVat5] [money] NULL,
	[MarkupUsed5] [float] NULL,
	[PriceExclVat6] [money] NULL,
	[MarkupUsed6] [float] NULL,
	[GroupName] [nvarchar](200) NULL,
	[UsualAvailability] [nvarchar](255) NULL,
	[Notes] [ntext] NULL,
	[URL] [nvarchar](250) NULL,
	[ImgURL] [nvarchar](250) NULL,
	[Status] [smallint] NULL,
	[Warranty] [int] NULL,
	[OrgSourceID] [bigint] NULL,
	[OutputMe] [bit] NULL,
	[Active] [bit] NULL,
	[StockQty] [float] NULL,
	[DiscQty] [float] NULL,
	[Unit] [nvarchar](20) NULL,
	[CreateDate] [datetime] NULL,
	[Length] [real] NULL,
	[Width] [real] NULL,
	[Height] [real] NULL,
	[Mass] [real] NULL,
	[DebitOrderFormId] [bigint] NULL,
	[DeliveryID] [bigint] NULL,
	[MasterProdID] [bigint] NULL,
	[AdwordExclude] [bit] NULL,
	[DataSource] [int] NULL,
	[ProductName] [nvarchar](200) NULL,
	[CategoryID] [bigint] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

