if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InsertLargeTableData]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[InsertLargeTableData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[LargeTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[LargeTable]
GO

CREATE TABLE [dbo].[LargeTable] (
	[PK] [uniqueidentifier] NOT NULL ,
	[Indexed] [varchar] (150) NOT NULL ,
	[NonIndexed] [varchar] (150) NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[LargeTable] WITH NOCHECK ADD 
	CONSTRAINT [PK_LargeTable] PRIMARY KEY  CLUSTERED 
	(
		[PK]
	)  ON [PRIMARY] 
GO

 CREATE  INDEX [IX_LargeTable] ON [dbo].[LargeTable]([Indexed]) ON [PRIMARY]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO

CREATE PROCEDURE InsertLargeTableData (
@NumberOfRows bigint
)
AS

SET NOCOUNT ON

DECLARE @cnt bigint
SET @cnt = 0

WHILE @cnt < @NumberOfRows
BEGIN
    INSERT INTO LargeTable 
    SELECT newid(), 
    CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36)),
    CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36)) + CAST(newid() AS VARCHAR(36))

    SET @cnt = @cnt + 1
END
GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

