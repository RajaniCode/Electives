USE [EF6CodeFirstExistingSQLServer2014];

IF OBJECT_ID ('Customer', N'U') IS NOT NULL
DROP TABLE dbo.Customer;

CREATE TABLE dbo.Customer
(
	CustomerId INT IDENTITY(1,1) NOT NULL,
	FirstName NVARCHAR(max),
	LastName NVARCHAR(max),
    Technology NVARCHAR(max),
    CONSTRAINT PK_custid PRIMARY KEY(CustomerId)
) 
ON [PRIMARY]
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Bill', 'Gates', 'Microsoft');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Larry', 'Page', 'Google');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Steve', 'Jobs', 'Apple');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Anders', 'Hejlsberg', 'C#');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Bjarne', 'Stroustrup', 'C++');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('James', 'Gosling', 'Java');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Scott', 'Guthrie', 'ASP.NET');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Don', 'Syme', 'F#');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Dennis', 'Ritchie', 'C');
GO

INSERT INTO dbo.Customer(FirstName, LastName, Technology)
VALUES('Hasso', 'Plattner', 'SAP');
GO

SELECT * FROM dbo.Customer