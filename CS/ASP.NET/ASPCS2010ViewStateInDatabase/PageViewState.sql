USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'PageViewStatedb')
DROP DATABASE [PageViewStatedb];
GO

CREATE DATABASE [PageViewStatedb];
GO

USE [PageViewStatedb];
GO

SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
CREATE TABLE [dbo].[PageViewState]( 
        [ID] [uniqueidentifier] NOT NULL, 
        [Value] [text] NOT NULL, 
        [LastUpdatedOn] [datetime] NOT NULL, 
 CONSTRAINT [PK_PageViewState] PRIMARY KEY CLUSTERED  
( 
        [ID] ASC 
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY] 
GO 
 
SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
CREATE PROCEDURE [dbo].[GetByID]  
        @id uniqueidentifier  
AS 
BEGIN 
        SET NOCOUNT ON; 
         
        select Value 
        from PageViewState 
        where ID = @id 
 
END 
 
GO 
SET ANSI_NULLS ON 
GO 
SET QUOTED_IDENTIFIER ON 
GO 
CREATE PROCEDURE [dbo].[SaveViewState] 
        @id uniqueidentifier,  
        @value text 
AS 
BEGIN 
        SET NOCOUNT ON; 
         
        if (exists(select ID from PageViewState where ID = @id)) 
                update PageViewState 
                set Value = @value, LastUpdatedOn = getdate() 
                where ID = @id 
        else 
                insert into PageViewState 
                (ID, Value, LastUpdatedOn) 
                values (@id, @value, getdate()) 
 
END 


--Cleanup
--SELECT * FROM dbo.PageViewState

--DELETE FROM PageViewState 
--WHERE LastUpdatedOn < dateadd(minute, -240, current_timestamp) 

--SELECT * FROM dbo.PageViewState

--DROP PROCEDURE [dbo].[GetByID] 

--DROP PROCEDURE [dbo].[SaveViewState] 

--DROP TABLE [dbo].[PageViewState]

