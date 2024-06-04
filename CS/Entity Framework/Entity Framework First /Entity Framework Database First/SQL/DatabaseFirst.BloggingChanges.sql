USE [DatabaseFirst.Blogging];
GO

CREATE TABLE [dbo].[Users] 
( 
	[Username] NVARCHAR(50) NOT NULL PRIMARY KEY,  
	[DisplayName] NVARCHAR(MAX) NULL 
);
GO

SELECT * FROM [dbo].[Users];