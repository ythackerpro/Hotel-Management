USE [myHotel]
GO

/****** Object:  Table [dbo].[employee]    Script Date: 4/27/2024 11:54:45 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[employee]') AND type in (N'U'))
DROP TABLE [dbo].[employee]
GO

/****** Object:  Table [dbo].[employee]    Script Date: 4/27/2024 11:54:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[employee](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[ename] [varchar](250) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[emailid] [varchar](120) NOT NULL,
	[username] [varchar](150) NOT NULL,
	[pass] [varchar](150) NOT NULL,
	[type] [nvarchar](150) NOT NULL,
	
PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


