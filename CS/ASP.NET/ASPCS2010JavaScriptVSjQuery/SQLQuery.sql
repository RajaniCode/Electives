USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'CustomerTracker')
DROP DATABASE [CustomerTracker];
GO

-- OR
--IF DB_ID (N'CustomerTracker') IS NOT NULL
--DROP DATABASE [CustomerTracker];
--GO

CREATE DATABASE [CustomerTracker];
GO

USE [CustomerTracker];
GO

IF EXISTS(SELECT name FROM sys.tables WHERE name = N'Customer')
DROP TABLE [Customer];
GO

-- OR

IF OBJECT_ID (N'Customer', N'U') IS NOT NULL
DROP TABLE [Customer];
GO



CREATE TABLE [dbo].[Customer]
( 
	[ID] INT IDENTITY(1,1) NOT NULL, 
	[Name] NVARCHAR(MAX) NULL,
	[Country] NVARCHAR(MAX) NULL, 
	CONSTRAINT [PK_ID] PRIMARY KEY CLUSTERED 
	( 
		[ID] ASC 
	)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) 
ON [PRIMARY];
GO 


SELECT * FROM dbo.Customer;
GO


IF EXISTS(SELECT name FROM sys.tables WHERE name = N'Employees')
DROP TABLE [Employees];
GO

-- OR

--IF OBJECT_ID (N'Employees', N'U') IS NOT NULL
--DROP TABLE [Employees];
--GO

SELECT * INTO Employees FROM Northwind.dbo.Employees;

SELECT * FROM Employees;