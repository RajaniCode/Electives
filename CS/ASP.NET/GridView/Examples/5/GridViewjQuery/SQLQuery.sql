USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'SampleDatabase')
DROP DATABASE [SampleDatabase];
GO

-- OR

IF DB_ID (N'SampleDatabase') IS NOT NULL
DROP DATABASE [SampleDatabase];
GO

CREATE DATABASE [SampleDatabase];
GO

USE [SampleDatabase];
GO

IF EXISTS(SELECT name FROM sys.tables WHERE name = N'SampleForTutorials')
DROP TABLE [SampleForTutorials];
GO

-- OR

IF OBJECT_ID (N'SampleForTutorials', N'U') IS NOT NULL
DROP TABLE [SampleForTutorials];
GO

CREATE TABLE dbo.SampleForTutorials
(
	AutoId INT IDENTITY(1,1),
	Name VARCHAR(MAX), 
	[Address] VARCHAR(MAX), 
	City VARCHAR(MAX),
	Phone VARCHAR(MAX)
);
GO

SELECT * FROM dbo.SampleForTutorials;
GO

/*
CREATE TABLE [dbo].[SampleForTutorials]
( 
	[AutoId] [bigint] IDENTITY(1,1) NOT NULL, 
	[Name] [nvarchar](MAX) NULL, 
	[Address] [nvarchar](MAX) NULL, 
	[Phone] [nvarchar](MAX) NULL, 
	[City] [nvarchar](MAX) NULL, 
	CONSTRAINT [PK_SampleForTutorials] PRIMARY KEY CLUSTERED 
	( 
		[AutoId] ASC 
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] 
GO 
*/