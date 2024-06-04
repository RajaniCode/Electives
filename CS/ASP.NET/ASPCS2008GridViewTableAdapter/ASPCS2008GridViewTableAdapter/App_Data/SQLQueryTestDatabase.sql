USE [master]
GO

IF EXISTS (SELECT * FROM SYS.DATABASES WHERE NAME = N'TestDatabase')
DROP DATABASE [TestDatabase]
GO

CREATE DATABASE [TestDatabase]
GO

USE [TestDatabase]
GO

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE NAME = N'Contact')
DROP TABLE dbo.Contact
GO

CREATE TABLE dbo.Contact
(
Id INT IDENTITY(1,1) NOT NULL,
Name NVARCHAR(50),
Sex NVARCHAR(10),
Type INT,
IsActive BIT,
CONSTRAINT PK_Contact_Id PRIMARY KEY (Id)
)
GO

SELECT * FROM dbo.Contact

INSERT INTO dbo.Contact
VALUES
(
'Bill Gates',
'Male',
1,
1
)
GO

SELECT * FROM dbo.Contact

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE NAME = N'ContactType')
DROP TABLE dbo.ContactType
GO

CREATE TABLE dbo.ContactType
(
Id INT IDENTITY(1,1) NOT NULL,
TypeName NVARCHAR(50),
CONSTRAINT PK_ContactType_Id PRIMARY KEY (Id)
)
GO

SELECT * FROM dbo.ContactType

INSERT INTO dbo.ContactType
VALUES
(
'Philanthropy'
)
GO

INSERT INTO dbo.ContactType
VALUES
(
'Business'
)
GO

INSERT INTO dbo.ContactType
VALUES
(
'Freelance'
)
GO

INSERT INTO dbo.ContactType
VALUES
(
'Personal'
)
GO

SELECT * FROM dbo.ContactType

