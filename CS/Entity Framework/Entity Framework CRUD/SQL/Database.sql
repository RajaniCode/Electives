--Check If Database, Table, Procedure Exists
USE [master];
Go

IF EXISTS(SELECT name FROM sys.databases WHERE name = N'CodeFirstExistingDatabase')
DROP DATABASE [CodeFirstExistingDatabase];
GO

-- OR

IF DB_ID (N'CodeFirstExistingDatabase') IS NOT NULL
DROP DATABASE [CodeFirstExistingDatabase];
GO

CREATE DATABASE [CodeFirstExistingDatabase];
GO

USE [CodeFirstExistingDatabase];
GO

