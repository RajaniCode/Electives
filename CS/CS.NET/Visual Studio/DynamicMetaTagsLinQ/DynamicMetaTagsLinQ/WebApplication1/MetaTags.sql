CREATE DATABASE MetaTags
GO

USE MetaTags
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Page]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Page](
	[PageId] [int] IDENTITY(1,1) NOT NULL,
	[PageName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Page] PRIMARY KEY CLUSTERED 
(
	[PageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MetaData]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MetaData](
	[MetaDataId] [int] IDENTITY(1,1) NOT NULL,
	[PageId] [int] NOT NULL,
	[KeyName] [varchar](25) NOT NULL,
	[Value] [varchar](100) NOT NULL,
 CONSTRAINT [PK_MetaData] PRIMARY KEY CLUSTERED 
(
	[MetaDataId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MetaData_Page]') AND parent_object_id = OBJECT_ID(N'[dbo].[MetaData]'))
ALTER TABLE [dbo].[MetaData]  WITH CHECK ADD  CONSTRAINT [FK_MetaData_Page] FOREIGN KEY([PageId])
REFERENCES [dbo].[Page] ([PageId])
GO
ALTER TABLE [dbo].[MetaData] CHECK CONSTRAINT [FK_MetaData_Page]
