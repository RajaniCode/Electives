USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'SampleDB')
DROP DATABASE [SampleDB];
GO

-- OR

IF DB_ID (N'SampleDB') IS NOT NULL
DROP DATABASE [SampleDB];
GO

CREATE DATABASE [SampleDB];
GO

USE [SampleDB];
GO

IF EXISTS(SELECT name FROM sys.tables WHERE name = N'UserInformation')
DROP TABLE [UserInformation];
GO

-- OR

IF OBJECT_ID (N'UserInformation', N'U') IS NOT NULL
DROP TABLE [UserInformation];
GO

CREATE TABLE dbo.UserInformation
(
	UserId INT IDENTITY(1,1),
	UserName VARCHAR(MAX), 
	LastName VARCHAR(MAX), 
	City VARCHAR(MAX),
	Location VARCHAR(MAX)
);
GO

SELECT * FROM dbo.UserInformation;
GO


INSERT INTO dbo.UserInformation
(UserName, LastName, City, Location)
VALUES
('Bill', 'Gates', 'LosAngeles', 'West'),
('Larry', 'Page', 'New York', 'East'),
('Sergey', 'Brin', 'Washington', 'West'),
('Anders', 'Heilsberg', 'Seattle', 'North'),
('Bjarne', 'Stroustrup', 'Austin', 'South'),
('James', 'Goosling', 'Santa Clara', 'West'),
('Herbert', 'Shildt', 'San Francisco', 'West'),
('Bill', 'Gates', 'LosAngeles', 'West'),
('Larry', 'Page', 'New York', 'East'),
('Sergey', 'Brin', 'Washington', 'West'),
('Anders', 'Heilsberg', 'Seattle', 'North'),
('Bjarne', 'Stroustrup', 'Austin', 'South'),
('James', 'Goosling', 'Santa Clara', 'West'),
('Herbert', 'Shildt', 'San Francisco', 'West'),
('Bill', 'Gates', 'LosAngeles', 'West'),
('Larry', 'Page', 'New York', 'East'),
('Sergey', 'Brin', 'Washington', 'West'),
('Anders', 'Heilsberg', 'Seattle', 'North'),
('Bjarne', 'Stroustrup', 'Austin', 'South'),
('James', 'Goosling', 'Santa Clara', 'West'),
('Herbert', 'Shildt', 'San Francisco', 'West'),
('Bill', 'Gates', 'LosAngeles', 'West'),
('Larry', 'Page', 'New York', 'East'),
('Sergey', 'Brin', 'Washington', 'West'),
('Anders', 'Heilsberg', 'Seattle', 'North'),
('Bjarne', 'Stroustrup', 'Austin', 'South'),
('James', 'Goosling', 'Santa Clara', 'West'),
('Herbert', 'Shildt', 'San Francisco', 'West');
GO

SELECT * FROM dbo.UserInformation;
GO

