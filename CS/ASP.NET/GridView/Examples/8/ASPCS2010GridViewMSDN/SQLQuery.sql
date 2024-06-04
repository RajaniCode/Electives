USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'EmployeesDB')
DROP DATABASE [EmployeesDB];
GO

-- OR

--IF DB_ID (N'EmployeesDB') IS NOT NULL
--DROP DATABASE [EmployeesDB];
--GO

CREATE DATABASE [EmployeesDB];
GO

USE [EmployeesDB];
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