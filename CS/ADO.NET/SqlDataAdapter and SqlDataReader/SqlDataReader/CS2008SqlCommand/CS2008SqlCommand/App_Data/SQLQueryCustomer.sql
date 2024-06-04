USE [master];

IF OBJECT_ID ('Customer', N'U') IS NOT NULL
DROP TABLE dbo.Customer;

CREATE TABLE dbo.Customer
(
	CustomerID INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(max),
	LastName NVARCHAR(max),
    Country NVARCHAR(max),
    CONSTRAINT PK_custid PRIMARY KEY(CustomerID)
) 
ON [PRIMARY]
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Bill', 'Gates', 'USA');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Larry', 'Page', 'USA');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Barrack', 'Obama', 'USA');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Stephen', 'Harper', 'Canada');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Gordon', 'Brown', 'UK');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Kevin', 'Rudd', 'Autralia');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Angela', 'Merkel', 'Germany');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Nicolas', 'Sarkozy', 'France');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Silvio', 'Berlusconi', 'Italy');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Country)
VALUES('Yukio', 'Hatoyama', 'Japan');
GO

SELECT * FROM dbo.Customer