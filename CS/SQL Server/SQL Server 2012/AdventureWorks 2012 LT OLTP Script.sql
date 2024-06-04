/*============================================================================
  File:     instawltdb.sql

  Summary:  Creates the AdventureWorksLT 2012 OLTP sample database.

  Date:     April 30, 2012

  SQL Server Version: 11.0.2100.60
------------------------------------------------------------------------------
  This file is part of the Microsoft SQL Server Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

  This source code is intended only as a supplement to Microsoft
  Development Tools and/or on-line documentation.  See these other
  materials for detailed information regarding Microsoft code samples.
  
  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
  PARTICULAR PURPOSE.
============================================================================*/
-->> NOTE: THIS SCRIPT MUST BE RUN IN SQLCMD MODE INSIDE SQL SERVER MANAGEMENT STUDIO. <<--
:on error exit


/*
 * In order to run this script manually, either set the environment variables,
 * or uncomment the setvar statements and provide the necessary values if
 * the defaults are not correct for your installation.
 */

:setvar SqlSamplesDatabasePath   "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\"
-- NOTE: Change this path if you copied the script source to another path
:setvar SqlSamplesSourceDataPath "C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\Tools\Samples\AdventureWorksLT 2012 OLTP Script\"


IF '$(SqlSamplesSourceDataPath)' IS NULL OR '$(SqlSamplesSourceDataPath)' = ''
BEGIN
	RAISERROR(N'The variable SqlSamplesSourceDataPath must be defined.', 16, 127) WITH NOWAIT
	RETURN
END

IF '$(SqlSamplesDatabasePath)' IS NULL OR '$(SqlSamplesDatabasePath)' = ''
BEGIN
	RAISERROR(N'The variable SqlSamplesDatabasePath must be defined.', 16, 127) WITH NOWAIT
	RETURN
END

SET NOCOUNT OFF;
GO

PRINT CONVERT(varchar(1000), @@VERSION);
GO

PRINT '';
PRINT 'Started - ' + CONVERT(varchar, GETDATE(), 121);
GO

USE [master];
GO


-- ****************************************
-- Drop Database
-- ****************************************
PRINT '';
PRINT '*** Dropping Database';
GO

IF EXISTS (SELECT [name] FROM [master].[sys].[databases] WHERE [name] = N'AdventureWorksLT2012')
    DROP DATABASE [AdventureWorksLT2012];

-- If the database has any other open connections close the network connection.
IF @@ERROR = 3702 
    RAISERROR('[AdventureWorksLT2012] database cannot be dropped because there are still other open connections', 127, 127) WITH NOWAIT, LOG;
GO


-- ****************************************
-- Create Database
-- ****************************************

PRINT '';
PRINT '*** Creating Database';
GO

DECLARE 
    @sql_path nvarchar(256);

SELECT @sql_path = SUBSTRING([physical_name], 1, CHARINDEX(N'master.mdf', LOWER([physical_name])) - 1)
FROM [master].[sys].[master_files] 
WHERE [database_id] = 1 
    AND [file_id] = 1;

EXECUTE (N'CREATE DATABASE [AdventureWorksLT2012] 
    ON (NAME = ''AdventureWorksLT2012_Data'', FILENAME = N''' + @sql_path + N'AdventureWorksLT2012_Data.mdf'', SIZE = 5, FILEGROWTH = 8) -- SIZE = 120, 
    LOG ON (NAME = ''AdventureWorksLT2012_Log'', FILENAME = N''' + @sql_path + N'AdventureWorksLT2012_Log.ldf'' , SIZE = 2, FILEGROWTH = 96);');
GO

ALTER DATABASE [AdventureWorksLT2012] 
SET RECOVERY SIMPLE, 
    ANSI_NULLS ON, 
    ANSI_PADDING ON, 
    ANSI_WARNINGS ON, 
    ARITHABORT ON, 
    CONCAT_NULL_YIELDS_NULL ON, 
    QUOTED_IDENTIFIER ON, 
    NUMERIC_ROUNDABORT OFF, 
    PAGE_VERIFY CHECKSUM, 
    ALLOW_SNAPSHOT_ISOLATION OFF;
GO

USE [AdventureWorksLT2012];
GO

-- ****************************************
-- Create Error Log objects
-- ****************************************
PRINT '';
PRINT '*** Creating Error Log objects';
GO

-- Create table to store error information
CREATE TABLE [dbo].[ErrorLog](
    [ErrorLogID] [int] IDENTITY (1, 1) NOT NULL,
    [ErrorTime] [datetime] NOT NULL CONSTRAINT [DF_ErrorLog_ErrorTime] DEFAULT (GETDATE()),
    [UserName] [sysname] NOT NULL, 
    [ErrorNumber] [int] NOT NULL, 
    [ErrorSeverity] [int] NULL, 
    [ErrorState] [int] NULL, 
    [ErrorProcedure] [nvarchar](126) NULL, 
    [ErrorLine] [int] NULL, 
    [ErrorMessage] [nvarchar](4000) NOT NULL
) ON [PRIMARY];
GO

ALTER TABLE [dbo].[ErrorLog] WITH CHECK ADD 
    CONSTRAINT [PK_ErrorLog_ErrorLogID] PRIMARY KEY CLUSTERED 
    (
        [ErrorLogID]
    )  ON [PRIMARY];
GO

-- uspPrintError prints error information about the error that caused 
-- execution to jump to the CATCH block of a TRY...CATCH construct. 
-- Should be executed from within the scope of a CATCH block otherwise 
-- it will return without printing any error information.
CREATE PROCEDURE [dbo].[uspPrintError] 
AS
BEGIN
    SET NOCOUNT ON;

    -- Print error information. 
    PRINT 'Error ' + CONVERT(varchar(50), ERROR_NUMBER()) +
          ', Severity ' + CONVERT(varchar(5), ERROR_SEVERITY()) +
          ', State ' + CONVERT(varchar(5), ERROR_STATE()) + 
          ', Procedure ' + ISNULL(ERROR_PROCEDURE(), '-') + 
          ', Line ' + CONVERT(varchar(5), ERROR_LINE());
    PRINT ERROR_MESSAGE();
END;
GO

-- uspLogError logs error information in the ErrorLog table about the 
-- error that caused execution to jump to the CATCH block of a 
-- TRY...CATCH construct. This should be executed from within the scope 
-- of a CATCH block otherwise it will return without inserting error 
-- information. 
CREATE PROCEDURE [dbo].[uspLogError] 
    @ErrorLogID [int] = 0 OUTPUT -- contains the ErrorLogID of the row inserted
AS                               -- by uspLogError in the ErrorLog table
BEGIN
    SET NOCOUNT ON;

    -- Output parameter value of 0 indicates that error 
    -- information was not logged
    SET @ErrorLogID = 0;

    BEGIN TRY
        -- Return if there is no error information to log
        IF ERROR_NUMBER() IS NULL
            RETURN;

        -- Return if inside an uncommittable transaction.
        -- Data insertion/modification is not allowed when 
        -- a transaction is in an uncommittable state.
        IF XACT_STATE() = -1
        BEGIN
            PRINT 'Cannot log error since the current transaction is in an uncommittable state. ' 
                + 'Rollback the transaction before executing uspLogError in order to successfully log error information.';
            RETURN;
        END

        INSERT [dbo].[ErrorLog] 
            (
            [UserName], 
            [ErrorNumber], 
            [ErrorSeverity], 
            [ErrorState], 
            [ErrorProcedure], 
            [ErrorLine], 
            [ErrorMessage]
            ) 
        VALUES 
            (
            CONVERT(sysname, CURRENT_USER), 
            ERROR_NUMBER(),
            ERROR_SEVERITY(),
            ERROR_STATE(),
            ERROR_PROCEDURE(),
            ERROR_LINE(),
            ERROR_MESSAGE()
            );

        -- Pass back the ErrorLogID of the row inserted
        SET @ErrorLogID = @@IDENTITY;

    END TRY
    BEGIN CATCH
        PRINT 'An error occurred in stored procedure uspLogError: ';
        EXECUTE [dbo].[uspPrintError];
        RETURN -1;
    END CATCH
END;
GO



-- ****************************************
-- Create Data Types
-- ****************************************
PRINT '';
PRINT '*** Creating Data Types';
GO

CREATE TYPE [AccountNumber] FROM nvarchar(15) NULL;
CREATE TYPE [Flag] FROM bit NOT NULL;
CREATE TYPE [NameStyle] FROM bit NOT NULL;
CREATE TYPE [Name] FROM nvarchar(50) NULL;
CREATE TYPE [OrderNumber] FROM nvarchar(25) NULL;
CREATE TYPE [Phone] FROM nvarchar(25) NULL;
GO




-- ******************************************************
-- Create database schemas
-- ******************************************************
PRINT '';
PRINT '*** Creating Database Schemas';
GO


CREATE SCHEMA [SalesLT] AUTHORIZATION [dbo];
GO


-- ****************************************
-- Create XML schemas
-- ****************************************
PRINT '';
PRINT '*** Creating XML Schemas';
GO



-- Create Product catalog description schema.
PRINT '';
PRINT 'Create Product catalog description schema';
GO

CREATE XML SCHEMA COLLECTION [SalesLT].[ProductDescriptionSchemaCollection] AS 
'<xsd:schema targetNamespace="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain"
    xmlns="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain" 
    elementFormDefault="qualified" 
    xmlns:xsd="http://www.w3.org/2001/XMLSchema" >
  
    <xsd:element name="Warranty"  >
        <xsd:complexType>
            <xsd:sequence>
                <xsd:element name="WarrantyPeriod" type="xsd:string"  />
                <xsd:element name="Description" type="xsd:string"  />
            </xsd:sequence>
        </xsd:complexType>
    </xsd:element>

    <xsd:element name="Maintenance"  >
        <xsd:complexType>
            <xsd:sequence>
                <xsd:element name="NoOfYears" type="xsd:string"  />
                <xsd:element name="Description" type="xsd:string"  />
            </xsd:sequence>
        </xsd:complexType>
    </xsd:element>
</xsd:schema>';

ALTER XML SCHEMA COLLECTION [SalesLT].[ProductDescriptionSchemaCollection] ADD 
'<?xml version="1.0" encoding="UTF-8"?>
<xs:schema targetNamespace="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription" 
    xmlns="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription" 
    elementFormDefault="qualified" 
    xmlns:mstns="http://tempuri.org/XMLSchema.xsd" 
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
    xmlns:wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain" >

    <xs:import 
        namespace="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain" />

    <xs:element name="ProductDescription" type="ProductDescription" />
        <xs:complexType name="ProductDescription">
            <xs:annotation>
                <xs:documentation>Product description has a summary blurb, if its manufactured elsewhere it 
                includes a link to the manufacturers site for this component.
                Then it has optional zero or more sequences of features, pictures, categories
                and technical specifications.
                </xs:documentation>
            </xs:annotation>
            <xs:sequence>
                <xs:element name="Summary" type="Summary" minOccurs="0" />
                <xs:element name="Manufacturer" type="Manufacturer" minOccurs="0" />
                <xs:element name="Features" type="Features" minOccurs="0" maxOccurs="unbounded" />
                <xs:element name="Picture" type="Picture" minOccurs="0" maxOccurs="unbounded" />
                <xs:element name="Category" type="Category" minOccurs="0" maxOccurs="unbounded" />
                <xs:element name="Specifications" type="Specifications" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
            <xs:attribute name="ProductModelID" type="xs:string" />
            <xs:attribute name="ProductModelName" type="xs:string" />
        </xs:complexType>
  
        <xs:complexType name="Summary" mixed="true" >
            <xs:sequence>
                <xs:any processContents="skip" namespace="http://www.w3.org/1999/xhtml" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
        </xs:complexType>
        
        <xs:complexType name="Manufacturer">
            <xs:sequence>
                <xs:element name="Name" type="xs:string" minOccurs="0" />
                <xs:element name="CopyrightURL" type="xs:string" minOccurs="0" />
                <xs:element name="Copyright" type="xs:string" minOccurs="0" />
                <xs:element name="ProductURL" type="xs:string" minOccurs="0" />
            </xs:sequence>
        </xs:complexType>
  
        <xs:complexType name="Picture">
            <xs:annotation>
                <xs:documentation>Pictures of the component, some standard sizes are "Large" for zoom in, "Small" for a normal web page and "Thumbnail" for product listing pages.</xs:documentation>
            </xs:annotation>
            <xs:sequence>
                <xs:element name="Name" type="xs:string" minOccurs="0" />
                <xs:element name="Angle" type="xs:string" minOccurs="0" />
                <xs:element name="Size" type="xs:string" minOccurs="0" />
                <xs:element name="ProductPhotoID" type="xs:integer" minOccurs="0" />
            </xs:sequence>
        </xs:complexType>

        <xs:annotation>
            <xs:documentation>Features of the component that are more "sales" oriented.</xs:documentation>
        </xs:annotation>

        <xs:complexType name="Features" mixed="true"  >
            <xs:sequence>
                <xs:element ref="wm:Warranty"  />
                <xs:element ref="wm:Maintenance"  />
                <xs:any processContents="skip"  namespace="##other" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
        </xs:complexType>

        <xs:complexType name="Specifications" mixed="true">
            <xs:annotation>
                <xs:documentation>A single technical aspect of the component.</xs:documentation>
            </xs:annotation>
            <xs:sequence>
                <xs:any processContents="skip" minOccurs="0" maxOccurs="unbounded" />
            </xs:sequence>
        </xs:complexType>

        <xs:complexType name="Category">
            <xs:annotation>
                <xs:documentation>A single categorization element that designates a classification taxonomy and a code within that classification type.  Optional description for default display if needed.</xs:documentation>
            </xs:annotation>
            <xs:sequence>
                <xs:element ref="Taxonomy" />
                <xs:element ref="Code" />
                <xs:element ref="Description" minOccurs="0" />
            </xs:sequence>
        </xs:complexType>

    <xs:element name="Taxonomy" type="xs:string" />
    <xs:element name="Code" type="xs:string" />
    <xs:element name="Description" type="xs:string" />
</xs:schema>';
GO



-- ******************************************************
-- Create tables
-- ******************************************************
PRINT '';
PRINT '*** Creating Tables';
GO

-- *** THIS TABLE IS INTENTIONALLY A HEAP - DO NOT ADD A PRIMARY KEY ***
CREATE TABLE [dbo].[BuildVersion](
    [SystemInformationID] [tinyint] IDENTITY (1, 1) NOT NULL,
    [Database Version] [nvarchar](25) NOT NULL, 
    [VersionDate] [datetime] NOT NULL, 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_BuildVersion_ModifiedDate] DEFAULT (GETDATE())
) ON [PRIMARY];
GO


CREATE TABLE [SalesLT].[Address](
    [AddressID] [int] IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [AddressLine1] [nvarchar](60) NOT NULL, 
    [AddressLine2] [nvarchar](60) NULL, 
    [City] [nvarchar](30) NOT NULL, 
    [StateProvince] [Name] NOT NULL,
	[CountryRegion] [Name] NOT NULL,
    [PostalCode] [nvarchar](15) NOT NULL, 
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Address_rowguid] DEFAULT (NEWID()),
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Address_ModifiedDate] DEFAULT (GETDATE())
) ON [PRIMARY];
GO



CREATE TABLE [SalesLT].[Customer](
    [CustomerID] [int] IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [NameStyle] [NameStyle] NOT NULL CONSTRAINT [DF_Customer_NameStyle] DEFAULT (0),
    [Title] [nvarchar](8) NULL, 
    [FirstName] [Name] NOT NULL,
    [MiddleName] [Name] NULL,
    [LastName] [Name] NOT NULL,
    [Suffix] [nvarchar](10) NULL, 
	[CompanyName] [nvarchar](128) NULL,
	[SalesPerson] [nvarchar](256),
    [EmailAddress] [nvarchar](50) NULL, 
    [Phone] [Phone] NULL, 
    [PasswordHash] [varchar](128) NOT NULL, 
    [PasswordSalt] [varchar](10) NOT NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Customer_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Customer_ModifiedDate] DEFAULT (GETDATE()), 
) ON [PRIMARY];
GO

CREATE TABLE [SalesLT].[CustomerAddress](
	[CustomerID] [int] NOT NULL,
	[AddressID] [int] NOT NULL,
	[AddressType] [Name] NOT NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_CustomerAddress_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_CustomerAddress_ModifiedDate] DEFAULT (GETDATE()), 
)	

CREATE TABLE [SalesLT].[Product](
    [ProductID] [int] IDENTITY (1, 1) NOT NULL,
    [Name] [Name] NOT NULL,
    [ProductNumber] [nvarchar](25) NOT NULL, 
    [Color] [nvarchar](15) NULL, 
    [StandardCost] [money] NOT NULL,
    [ListPrice] [money] NOT NULL,
    [Size] [nvarchar](5) NULL, 
    [Weight] [decimal](8, 2) NULL,
    [ProductCategoryID] [int] NULL,
    [ProductModelID] [int] NULL,
    [SellStartDate] [datetime] NOT NULL,
    [SellEndDate] [datetime] NULL,
    [DiscontinuedDate] [datetime] NULL,
    [ThumbNailPhoto] [varbinary](max) NULL,
    [ThumbnailPhotoFileName] [nvarchar](50) NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_Product_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_Product_ModifiedDate] DEFAULT (GETDATE()),
    CONSTRAINT [CK_Product_StandardCost] CHECK ([StandardCost] >= 0.00),
    CONSTRAINT [CK_Product_ListPrice] CHECK ([ListPrice] >= 0.00),
    CONSTRAINT [CK_Product_Weight] CHECK ([Weight] > 0.00),
    CONSTRAINT [CK_Product_SellEndDate] CHECK (([SellEndDate] >= [SellStartDate]) OR ([SellEndDate] IS NULL)),
) ON [PRIMARY];
GO

CREATE TABLE [SalesLT].[ProductCategory](
    [ProductCategoryID] [int] IDENTITY (1, 1) NOT NULL,
	[ParentProductCategoryID] [int] NULL,
    [Name] [Name] NOT NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ProductCategory_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_ProductCategory_ModifiedDate] DEFAULT (GETDATE()) 
) ON [PRIMARY];
GO


CREATE TABLE [SalesLT].[ProductDescription](
    [ProductDescriptionID] [int] IDENTITY (1, 1) NOT NULL,
    [Description] [nvarchar](400) NOT NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ProductDescription_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_ProductDescription_ModifiedDate] DEFAULT (GETDATE()) 
) ON [PRIMARY];
GO

CREATE TABLE [SalesLT].[ProductModel](
    [ProductModelID] [int] IDENTITY (1, 1) NOT NULL,
    [Name] [Name] NOT NULL,
    [CatalogDescription] [XML]([SalesLT].[ProductDescriptionSchemaCollection]) NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ProductModel_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_ProductModel_ModifiedDate] DEFAULT (GETDATE()) 
) ON [PRIMARY];
GO



CREATE TABLE [SalesLT].[ProductModelProductDescription](
    [ProductModelID] [int] NOT NULL,
    [ProductDescriptionID] [int] NOT NULL,
    [Culture] [nchar](6) NOT NULL, 
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_ProductModelProductDescription_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_ProductModelProductDescription_ModifiedDate] DEFAULT (GETDATE()) 
) ON [PRIMARY];
GO

CREATE TABLE [SalesLT].[SalesOrderDetail](
    [SalesOrderID] [int] NOT NULL,
    [SalesOrderDetailID] [int] IDENTITY (1, 1) NOT NULL,
    [OrderQty] [smallint] NOT NULL,
    [ProductID] [int] NOT NULL,
    [UnitPrice] [money] NOT NULL,
    [UnitPriceDiscount] [money] NOT NULL CONSTRAINT [DF_SalesOrderDetail_UnitPriceDiscount] DEFAULT (0.0),
    [LineTotal] AS ISNULL([UnitPrice] * (1.0 - [UnitPriceDiscount]) * [OrderQty], 0.0),
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_SalesOrderDetail_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_SalesOrderDetail_ModifiedDate] DEFAULT (GETDATE()), 
    CONSTRAINT [CK_SalesOrderDetail_OrderQty] CHECK ([OrderQty] > 0), 
    CONSTRAINT [CK_SalesOrderDetail_UnitPrice] CHECK ([UnitPrice] >= 0.00), 
    CONSTRAINT [CK_SalesOrderDetail_UnitPriceDiscount] CHECK ([UnitPriceDiscount] >= 0.00) 
) ON [PRIMARY];
GO

CREATE TABLE [SalesLT].[SalesOrderHeader](
    [SalesOrderID] [int] IDENTITY (1, 1) NOT FOR REPLICATION NOT NULL,
    [RevisionNumber] [tinyint] NOT NULL CONSTRAINT [DF_SalesOrderHeader_RevisionNumber] DEFAULT (0),
    [OrderDate] [datetime] NOT NULL CONSTRAINT [DF_SalesOrderHeader_OrderDate] DEFAULT (GETDATE()),
    [DueDate] [datetime] NOT NULL,
    [ShipDate] [datetime] NULL,
    [Status] [tinyint] NOT NULL CONSTRAINT [DF_SalesOrderHeader_Status] DEFAULT (1),
    [OnlineOrderFlag] [Flag] NOT NULL CONSTRAINT [DF_SalesOrderHeader_OnlineOrderFlag] DEFAULT (1),
    [SalesOrderNumber] AS ISNULL(N'SO' + CONVERT(nvarchar(23), [SalesOrderID]), N'*** ERROR ***'), 
    [PurchaseOrderNumber] [OrderNumber] NULL,
    [AccountNumber] [AccountNumber] NULL,
    [CustomerID] [int] NOT NULL,
	[ShipToAddressID] int,
	[BillToAddressID] int,
    [ShipMethod] [nvarchar](50) NOT NULL,
    [CreditCardApprovalCode] [varchar](15) NULL,    
    [SubTotal] [money] NOT NULL CONSTRAINT [DF_SalesOrderHeader_SubTotal] DEFAULT (0.00),
    [TaxAmt] [money] NOT NULL CONSTRAINT [DF_SalesOrderHeader_TaxAmt] DEFAULT (0.00),
    [Freight] [money] NOT NULL CONSTRAINT [DF_SalesOrderHeader_Freight] DEFAULT (0.00),
    [TotalDue] AS ISNULL([SubTotal] + [TaxAmt] + [Freight], 0),
    [Comment] [nvarchar](max) NULL,
    [rowguid] [uniqueidentifier] ROWGUIDCOL NOT NULL CONSTRAINT [DF_SalesOrderHeader_rowguid] DEFAULT (NEWID()), 
    [ModifiedDate] [datetime] NOT NULL CONSTRAINT [DF_SalesOrderHeader_ModifiedDate] DEFAULT (GETDATE()),
    CONSTRAINT [CK_SalesOrderHeader_Status] CHECK ([Status] BETWEEN 0 AND 8), 
    CONSTRAINT [CK_SalesOrderHeader_DueDate] CHECK ([DueDate] >= [OrderDate]), 
    CONSTRAINT [CK_SalesOrderHeader_ShipDate] CHECK (([ShipDate] >= [OrderDate]) OR ([ShipDate] IS NULL)), 
    CONSTRAINT [CK_SalesOrderHeader_SubTotal] CHECK ([SubTotal] >= 0.00), 
    CONSTRAINT [CK_SalesOrderHeader_TaxAmt] CHECK ([TaxAmt] >= 0.00), 
    CONSTRAINT [CK_SalesOrderHeader_Freight] CHECK ([Freight] >= 0.00) 
) ON [PRIMARY];
GO




-- ******************************************************
-- Load data
-- ******************************************************
PRINT '';
PRINT '*** Loading Data';
GO

USE [AdventureWorksLT2012];
GO


PRINT 'Loading [SalesLT].[Address]';
SET IDENTITY_INSERT [SalesLT].[Address] ON;

INSERT INTO [SalesLT].[Address] ([AddressID], [AddressLine1], [AddressLine2], [City], [StateProvince], [PostalCode],
	 [CountryRegion], [rowguid], [ModifiedDate])
	SELECT DISTINCT A.[AddressID], A.[AddressLine1], A.[AddressLine2], A.[City], 
		SPID.[Name] as StateProvince, A.[PostalCode],
		CR.[Name] as CountryRegion, A.[rowguid], A.[ModifiedDate]
	FROM [AdventureWorks2012].[Sales].[Store] AS S 
	JOIN [AdventureWorks2012].[Person].[BusinessEntityContact] AS BEC ON BEC.BusinessEntityID = S.BusinessEntityID
	JOIN [AdventureWorks2012].[Sales].[Customer] AS C ON C.[StoreID] = S.[BusinessEntityID]
	JOIN [AdventureWorks2012].[Person].[Person] AS P ON P.[BusinessEntityID] = BEC.[PersonID]
	JOIN [AdventureWorks2012].[Person].[BusinessEntityAddress] AS BEA 
		ON BEA.[BusinessEntityID] = S.[BusinessEntityID]
	JOIN [AdventureWorks2012].[Person].[Address] as A
		ON BEA.[AddressID] = A.[AddressID]
	JOIN [AdventureWorks2012].[Person].[StateProvince] AS SPID 
		ON A.[StateProvinceID] = SPID.[StateProvinceID]
	JOIN [AdventureWorks2012].[Person].[CountryRegion] AS CR
		ON SPID.[CountryRegionCode] = CR.[CountryRegionCode]
	-- Reduce the number of addresses to keep the database small
	WHERE BEC.PersonID
	 = (SELECT TOP 1 BEC2.PersonID FROM [AdventureWorks2012].[Person].[BusinessEntityContact] AS BEC2
							WHERE S.BusinessEntityID = BEC2.BusinessEntityID
							ORDER BY BEC2.PersonID)
		AND C.[StoreID] IS NOT NULL
		-- Reduce the number of customers to keep the database small
		AND C.[TerritoryID] IN (1, 3, 4, 6, 10);

SET IDENTITY_INSERT [SalesLT].[Address] OFF;

INSERT INTO [dbo].[BuildVersion] ([Database Version], [VersionDate], [ModifiedDate])
	SELECT [Database Version], [VersionDate], [ModifiedDate]
	FROM [AdventureWorks2012].[dbo].[AWBuildVersion];

PRINT 'Loading [SalesLT].[Customer]';
SET IDENTITY_INSERT [SalesLT].[Customer] ON;

INSERT INTO [SalesLT].[Customer] 
	([CustomerID], [NameStyle], [Title], [FirstName], [MiddleName], [LastName],
	 [Suffix], [CompanyName], [SalesPerson], [EmailAddress], [Phone], [PasswordHash], 
	 [PasswordSalt], [rowguid], [ModifiedDate])
	SELECT C.[CustomerID], P.[NameStyle], P.[Title], P.[FirstName], P.[MiddleName], P.[LastName],
		P.[Suffix], S.[Name] AS CompanyName, E.[LoginID] AS [SalesPerson], 
		EA.[EmailAddress], PP.[PhoneNumber], PW.[PasswordHash], 
		PW.[PasswordSalt], C.[rowguid], P.[ModifiedDate]
	FROM [AdventureWorks2012].[Sales].[Store] AS S 
	JOIN [AdventureWorks2012].[Person].[BusinessEntityContact] AS BEC ON BEC.BusinessEntityID = S.BusinessEntityID
	JOIN [AdventureWorks2012].[Sales].[Customer] AS C ON C.[StoreID] = S.[BusinessEntityID]
	JOIN [AdventureWorks2012].[Person].[Person] AS P ON P.[BusinessEntityID] = BEC.[PersonID]
	JOIN [AdventureWorks2012].[Person].[EmailAddress] AS EA ON EA.[BusinessEntityID] = P.[BusinessEntityID]
	JOIN [AdventureWorks2012].[Person].[PersonPhone] AS PP on PP.[BusinessEntityID] = P.[BusinessEntityID]
	LEFT OUTER JOIN [AdventureWorks2012].[Person].[Password] AS PW on PW.[BusinessEntityID] = P.[BusinessEntityID]
	LEFT OUTER JOIN [AdventureWorks2012].[HumanResources].[Employee] AS E ON S.SalesPersonID = E.BusinessEntityID
	LEFT OUTER JOIN [AdventureWorks2012].[Person].[Person] as SPP ON SPP.BusinessEntityID = E.BusinessEntityID
	WHERE BEC.PersonID = (SELECT TOP 1 BEC2.PersonID FROM [AdventureWorks2012].[Person].[BusinessEntityContact] AS BEC2
							WHERE S.BusinessEntityID = BEC2.BusinessEntityID
							ORDER BY BEC2.PersonID) AND
		  EA.[EmailAddress] = (SELECT TOP 1 EA2.EmailAddress FROM [AdventureWorks2012].[Person].[EmailAddress] AS EA2
							   WHERE EA2.BusinessEntityID = EA.BusinessEntityID
							   ORDER BY EA2.EmailAddress) AND
		  PP.[PhoneNumber] = (SELECT TOP 1 PP2.PhoneNumber FROM [AdventureWorks2012].[Person].[PersonPhone] AS PP2
							  WHERE PP2.BusinessEntityID = PP.BusinessEntityID
							  ORDER BY PP2.PhoneNumber) AND
		  C.[StoreID] IS NOT NULL
		-- Reduce the number of customers to keep the database small
		AND C.[TerritoryID] IN (1, 3, 4, 6, 10);


SET IDENTITY_INSERT [SalesLT].[Customer] OFF;

PRINT 'Loading [SalesLT].[CustomerAddress]';
INSERT INTO [SalesLT].[CustomerAddress]
	([CustomerID], [AddressID], [AddressType], [rowguid], [ModifiedDate])
  SELECT C.[CustomerID], BEA.[AddressID], AT.[Name] AS [AddressType], BEA.[rowguid], BEA.[ModifiedDate]
  FROM [AdventureWorks2012].[Person].[BusinessEntityAddress] AS BEA
  JOIN [AdventureWorks2012].[Sales].[Store] AS S ON S.[BusinessEntityID] = BEA.[BusinessEntityID]
  JOIN [AdventureWorks2012].[Sales].[Customer] AS C ON C.[StoreID] = BEA.[BusinessEntityID]
  JOIN [AdventureWorks2012].[Person].[AddressType] AS AT 
	ON AT.AddressTypeID = BEA.AddressTypeID
  -- Reduce the number of customer addresses to keep the database small
  WHERE C.[CustomerID] IN (SELECT C.CustomerID FROM [SalesLT].[Customer] AS C) AND
		BEA.[AddressID] IN (SELECT A.AddressID FROM [SalesLT].[Address] AS A) AND
		C.PersonID IS NOT NULL;



PRINT 'Loading [SalesLT].[Product]';
SET IDENTITY_INSERT [SalesLT].[Product] ON;

INSERT INTO [SalesLT].[Product] ([ProductID], [Name], [ProductNumber], [Color], [StandardCost], [ListPrice],
		[Size], [Weight], [ProductCategoryID], [ProductModelID], [SellStartDate], [SellEndDate],
		[DiscontinuedDate], [ThumbNailPhoto], [ThumbnailPhotoFileName], 
		[rowguid], [ModifiedDate])
	SELECT P.[ProductID], P.[Name], P.[ProductNumber], P.[Color], P.[StandardCost],
		
		P.[ListPrice], 
		--All non-null sizes are already in centimeters
		P.[Size], 
		--Convert pounds to grams
		CASE P.WeightUnitMeasureCode 
						WHEN 'LB' THEN P.[Weight]*453.59
						WHEN 'G' THEN P.[Weight]
						ELSE NULL
					END AS Weight,
	    P.[ProductSubcategoryID]+4, P.[ProductModelID], P.[SellStartDate],
		P.[SellEndDate], P.[DiscontinuedDate], 
		PP.[ThumbNailPhoto],
		PP.[ThumbnailPhotoFileName],
		P.[rowguid], P.[ModifiedDate]
	FROM [AdventureWorks2012].[Production].[Product] AS P
	JOIN [AdventureWorks2012].[Production].[ProductProductPhoto] AS PPP
		ON PPP.[ProductID] = P.[ProductID] AND PPP.[Primary] = 1
	JOIN [AdventureWorks2012].[Production].[ProductPhoto] AS PP 
		ON PPP.[ProductPhotoID] = PP.[ProductPhotoID]
	WHERE P.[FinishedGoodsFlag] = 1;

SET IDENTITY_INSERT [SalesLT].[Product] OFF;


PRINT 'Loading [SalesLT].[ProductCategory]';

SET IDENTITY_INSERT [SalesLT].[ProductCategory] ON;

INSERT INTO [SalesLT].[ProductCategory] ([ProductCategoryID], [ParentProductCategoryID], [Name], [rowguid], [ModifiedDate])
	SELECT [ProductCategoryID], NULL AS [ParentProductCategoryID], [Name], [rowguid], [ModifiedDate]
	FROM [AdventureWorks2012].[Production].[ProductCategory];

INSERT INTO [SalesLT].[ProductCategory] ([ProductCategoryID], [ParentProductCategoryID], [Name], [rowguid], [ModifiedDate])
	SELECT [ProductSubcategoryID]+4, ProductCategoryID AS [ParentProductCategoryID], [Name], [rowguid], [ModifiedDate]
	FROM [AdventureWorks2012].[Production].[ProductSubcategory];

SET IDENTITY_INSERT [SalesLT].[ProductCategory] OFF;


PRINT 'Loading [SalesLT].[ProductDescription]';

SET IDENTITY_INSERT [SalesLT].[ProductDescription] ON;

INSERT INTO [SalesLT].[ProductDescription] ([ProductDescriptionID], [Description], [rowguid], [ModifiedDate])
	SELECT [ProductDescriptionID], [Description], [rowguid], [ModifiedDate]
	FROM [AdventureWorks2012].[Production].[ProductDescription];

SET IDENTITY_INSERT [SalesLT].[ProductDescription] OFF;


PRINT 'Loading [SalesLT].[ProductModel]';
SET IDENTITY_INSERT [SalesLT].[ProductModel] ON;

INSERT INTO [SalesLT].[ProductModel] ([ProductModelID], [Name], [CatalogDescription], [rowguid], [ModifiedDate])
	SELECT [ProductModelID], [Name], CONVERT(nvarchar(max), [CatalogDescription]), [rowguid], [ModifiedDate]
	FROM [AdventureWorks2012].[Production].[ProductModel];

SET IDENTITY_INSERT [SalesLT].[ProductModel] OFF;

PRINT 'Loading [SalesLT].[ProductModelProductDescription]';
INSERT INTO [SalesLT].[ProductModelProductDescription] ([ProductModelID], [ProductDescriptionID], [Culture], 
		[ModifiedDate])
	SELECT [ProductModelID], [ProductDescriptionID], [CultureID] AS [Culture], 
		[ModifiedDate]
	FROM [AdventureWorks2012].[Production].[ProductModelProductDescriptionCulture] AS PMPDC;

PRINT 'Loading [SalesLT].[SalesOrderDetail]';
SET IDENTITY_INSERT [SalesLT].[SalesOrderDetail] ON;

INSERT INTO [SalesLT].[SalesOrderDetail] ([SalesOrderID], [SalesOrderDetailID], [OrderQty], [ProductID], 
		[UnitPrice], [UnitPriceDiscount], [rowguid], [ModifiedDate])
	SELECT [SalesOrderID], [SalesOrderDetailID], [OrderQty], [ProductID], 
		[UnitPrice], [UnitPriceDiscount], [rowguid], [ModifiedDate]
	FROM [AdventureWorks2012].[Sales].[SalesOrderDetail]
	WHERE SalesOrderID IN (SELECT SOH.SalesOrderID FROM AdventureWorks2012.Sales.SalesOrderHeader AS SOH
	-- limit the number of detail records to keep the database small.
						   WHERE SOH.SalesPersonID IN (276, 282) 
						   AND SOH.OrderDate > CONVERT(DATETIME, '20040531', 101));

SET IDENTITY_INSERT [SalesLT].[SalesOrderDetail] OFF;



PRINT 'Loading [SalesLT].[SalesOrderHeader]';
SET IDENTITY_INSERT [SalesLT].[SalesOrderHeader] ON;

INSERT INTO [SalesLT].[SalesOrderHeader] ([SalesOrderID], [RevisionNumber], [OrderDate], [DueDate], [ShipDate], 
		[Status], [OnlineOrderFlag], [PurchaseOrderNumber], 
		[AccountNumber], [CustomerID], [ShipToAddressID], [BillToAddressID], [ShipMethod], [SubTotal], [TaxAmt], [Freight], 
		[Comment], [rowguid], [ModifiedDate])
	SELECT SOH.[SalesOrderID], SOH.[RevisionNumber], SOH.[OrderDate], SOH.[DueDate], SOH.[ShipDate], 
		SOH.[Status], SOH.[OnlineOrderFlag], SOH.[PurchaseOrderNumber], 
		SOH.[AccountNumber], SOH.[CustomerID], SOH.[ShipToAddressID], SOH.[BillToAddressID], 
		SM.[Name] AS [ShipMethod], SOH.[SubTotal], SOH.[TaxAmt], SOH.[Freight], 
		SOH.[Comment], SOH.[rowguid], SOH.[ModifiedDate]
	FROM [AdventureWorks2012].[Sales].[SalesOrderHeader] AS SOH
	JOIN [AdventureWorks2012].[Purchasing].[ShipMethod] AS SM ON SOH.[ShipMethodID] = SM.[ShipMethodID]
	-- limit the number of header records to keep the database small.
	WHERE SOH.SalesPersonID IN (276, 282) AND SOH.OrderDate > CONVERT(DATETIME, '20040531', 101);

SET IDENTITY_INSERT [SalesLT].[SalesOrderHeader] OFF;


GO


-- ******************************************************
-- Add Primary Keys
-- ******************************************************
PRINT '';
PRINT '*** Adding Primary Keys';
GO

SET QUOTED_IDENTIFIER ON;

ALTER TABLE [SalesLT].[Address] WITH CHECK ADD 
    CONSTRAINT [PK_Address_AddressID] PRIMARY KEY CLUSTERED 
    (
        [AddressID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[Customer] WITH CHECK ADD 
    CONSTRAINT [PK_Customer_CustomerID] PRIMARY KEY CLUSTERED 
    (
        [CustomerID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[CustomerAddress] WITH CHECK ADD 
    CONSTRAINT [PK_CustomerAddress_CustomerID_AddressID] PRIMARY KEY CLUSTERED 
    (
        [CustomerID],
		[AddressID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[Product] WITH CHECK ADD 
    CONSTRAINT [PK_Product_ProductID] PRIMARY KEY CLUSTERED 
    (
        [ProductID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductCategory] WITH CHECK ADD 
    CONSTRAINT [PK_ProductCategory_ProductCategoryID] PRIMARY KEY CLUSTERED 
    (
        [ProductCategoryID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductDescription] WITH CHECK ADD 
    CONSTRAINT [PK_ProductDescription_ProductDescriptionID] PRIMARY KEY CLUSTERED 
    (
        [ProductDescriptionID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductModel] WITH CHECK ADD 
    CONSTRAINT [PK_ProductModel_ProductModelID] PRIMARY KEY CLUSTERED 
    (
        [ProductModelID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductModelProductDescription] WITH CHECK ADD 
    CONSTRAINT [PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture] PRIMARY KEY CLUSTERED 
    (
        [ProductModelID],
        [ProductDescriptionID],
        [Culture]
    )  ON [PRIMARY];
GO


ALTER TABLE [SalesLT].[SalesOrderDetail] WITH CHECK ADD 
    CONSTRAINT [PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID] PRIMARY KEY CLUSTERED 
    (
        [SalesOrderID],
        [SalesOrderDetailID]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[SalesOrderHeader] WITH CHECK ADD 
    CONSTRAINT [PK_SalesOrderHeader_SalesOrderID] PRIMARY KEY CLUSTERED 
    (
        [SalesOrderID]
    )  ON [PRIMARY];
GO

-- ******************************************************

-- Add Unique Constraints
-- Adding the UNIQUE constraint also adds an index to enforce the constraint.
-- ******************************************************
PRINT '';
PRINT '*** Adding Unique Constraints';
GO

ALTER TABLE [SalesLT].[Address] WITH CHECK ADD 
    CONSTRAINT [AK_Address_rowguid] UNIQUE 
    (
        [rowguid]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[Customer] WITH CHECK ADD 
    CONSTRAINT [AK_Customer_rowguid] UNIQUE 
    (
        [rowguid]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[CustomerAddress] WITH CHECK ADD 
    CONSTRAINT [AK_CustomerAddress_rowguid] UNIQUE 
    (
        [rowguid]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[Product] WITH CHECK ADD 
    CONSTRAINT [AK_Product_ProductNumber] UNIQUE 
    (
        [ProductNumber]
    )  ON [PRIMARY],
	CONSTRAINT [AK_Product_Name] UNIQUE
	(
		[Name]
	) ON [PRIMARY],
	CONSTRAINT [AK_Product_rowguid] UNIQUE
	(
		[rowguid]
	) ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductCategory] WITH CHECK ADD 
    CONSTRAINT [AK_ProductCategory_Name] UNIQUE 
    (
        [Name]
    )  ON [PRIMARY],
	CONSTRAINT [AK_ProductCategory_rowguid] UNIQUE
	(
		[rowguid]
	) ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductDescription] WITH CHECK ADD 
    CONSTRAINT [AK_ProductDescription_rowguid] UNIQUE 
    (
        [rowguid]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductModel] WITH CHECK ADD 
    CONSTRAINT [AK_ProductModel_Name] UNIQUE 
    (
        [Name]
    )  ON [PRIMARY],
	CONSTRAINT [AK_ProductModel_rowguid] UNIQUE
	(
		[rowguid]
	) ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[ProductModelProductDescription] WITH CHECK ADD 
	CONSTRAINT [AK_ProductModelProductDescription_rowguid] UNIQUE
	(
		[rowguid]
	) ON [PRIMARY];
GO


ALTER TABLE [SalesLT].[SalesOrderDetail] WITH CHECK ADD 
    CONSTRAINT [AK_SalesOrderDetail_rowguid] UNIQUE 
    (
        [rowguid]
    )  ON [PRIMARY];
GO

ALTER TABLE [SalesLT].[SalesOrderHeader] WITH CHECK ADD 
    CONSTRAINT [AK_SalesOrderHeader_SalesOrderNumber] UNIQUE 
    (
        [SalesOrderNumber]
    )  ON [PRIMARY],
	CONSTRAINT [AK_SalesOrderHeader_rowguid] UNIQUE
	(
		[rowguid]
	) ON [PRIMARY];
GO

-- ******************************************************
-- Add Indexes
-- ******************************************************
PRINT '';
PRINT '*** Adding Indexes';
GO

CREATE INDEX [IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion] 
	ON [SalesLT].[Address] ([AddressLine1], [AddressLine2], [City], [StateProvince], 
		[PostalCode], [CountryRegion]) ON [PRIMARY];
CREATE INDEX [IX_Address_StateProvince] ON [SalesLT].[Address]([StateProvince]) ON [PRIMARY];
GO

CREATE INDEX [IX_Customer_EmailAddress] ON [SalesLT].[Customer]([EmailAddress]) ON [PRIMARY];
GO

CREATE INDEX [IX_SalesOrderDetail_ProductID] ON [SalesLT].[SalesOrderDetail]([ProductID]) ON [PRIMARY];
GO

CREATE INDEX [IX_SalesOrderHeader_CustomerID] ON [SalesLT].[SalesOrderHeader]([CustomerID]) ON [PRIMARY];
GO



-- ****************************************
-- Create XML index for each XML column
-- ****************************************
PRINT '';
PRINT '*** Creating an XML index for the XML column';
GO

SET ARITHABORT ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;

CREATE PRIMARY XML INDEX [PXML_ProductModel_CatalogDescription] ON [SalesLT].[ProductModel]([CatalogDescription]);
GO


-- ****************************************
-- Create Foreign key constraints
-- ****************************************
PRINT '';
PRINT '*** Creating Foreign Key Constraints';
GO

ALTER TABLE [SalesLT].[CustomerAddress] ADD 
    CONSTRAINT [FK_CustomerAddress_Customer_CustomerID] FOREIGN KEY 
    (
        [CustomerID]
    ) REFERENCES [SalesLT].[Customer](
        [CustomerID]
    ),
    CONSTRAINT [FK_CustomerAddress_Address_AddressID] FOREIGN KEY 
    (
        [AddressID]
    ) REFERENCES [SalesLT].[Address](
        [AddressID]
    );
GO

ALTER TABLE [SalesLT].[Product] ADD 
    CONSTRAINT [FK_Product_ProductModel_ProductModelID] FOREIGN KEY 
    (
        [ProductModelID]
    ) REFERENCES [SalesLT].[ProductModel](
        [ProductModelID]
    ),
    CONSTRAINT [FK_Product_ProductCategory_ProductCategoryID] FOREIGN KEY 
    (
        [ProductCategoryID]
    ) REFERENCES [SalesLT].[ProductCategory](
        [ProductCategoryID]
    );
GO

ALTER TABLE [SalesLT].[ProductCategory] ADD 
    CONSTRAINT [FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID] FOREIGN KEY 
    (
        [ParentProductCategoryID]
    ) REFERENCES [SalesLT].[ProductCategory](
        [ProductCategoryID]
    );
GO

ALTER TABLE [SalesLT].[ProductModelProductDescription] ADD 
    CONSTRAINT [FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID] FOREIGN KEY 
    (
        [ProductDescriptionID]
    ) REFERENCES [SalesLT].[ProductDescription](
        [ProductDescriptionID]
    ),
    CONSTRAINT [FK_ProductModelProductDescription_ProductModel_ProductModelID] FOREIGN KEY 
    (
        [ProductModelID]
    ) REFERENCES [SalesLT].[ProductModel](
        [ProductModelID]
    );
GO

ALTER TABLE [SalesLT].[SalesOrderDetail] ADD 
    CONSTRAINT [FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID] FOREIGN KEY 
    (
        [SalesOrderID]
    ) REFERENCES [SalesLT].[SalesOrderHeader](
        [SalesOrderID]
    ) ON DELETE CASCADE;

GO

ALTER TABLE [SalesLT].[SalesOrderDetail] ADD 
    CONSTRAINT [FK_SalesOrderDetail_Product_ProductID] FOREIGN KEY 
    (
        [ProductID]
    ) REFERENCES [SalesLT].[Product](
        [ProductID]
    );

GO

ALTER TABLE [SalesLT].[SalesOrderHeader] ADD 
    CONSTRAINT [FK_SalesOrderHeader_Customer_CustomerID] FOREIGN KEY 
    (
        [CustomerID]
    ) REFERENCES [SalesLT].[Customer](
        [CustomerID]
	),
    CONSTRAINT [FK_SalesOrderHeader_Address_ShipTo_AddressID] FOREIGN KEY 
    (
        [ShipToAddressID]
    ) REFERENCES [SalesLT].[Address](
        [AddressID]
    ),
    CONSTRAINT [FK_SalesOrderHeader_Address_BillTo_AddressID] FOREIGN KEY 
    (
        [BillToAddressID]
    ) REFERENCES [SalesLT].[Address](
        [AddressID]
    );
GO



-- ******************************************************
-- Add table triggers.
-- ******************************************************
PRINT '';
PRINT '*** Creating Table Triggers';
GO


CREATE TRIGGER [SalesLT].[iduSalesOrderDetail] ON [SalesLT].[SalesOrderDetail] 
AFTER INSERT, DELETE, UPDATE AS 
BEGIN
    DECLARE @Count int;

    SET @Count = @@ROWCOUNT;
    IF @Count = 0 
        RETURN;

    SET NOCOUNT ON;

    BEGIN TRY
        -- If inserting or updating these columns
        IF UPDATE([ProductID]) OR UPDATE([OrderQty]) OR UPDATE([UnitPrice]) OR UPDATE([UnitPriceDiscount]) 

        -- Update SubTotal in SalesOrderHeader record. Note that this causes the 
        -- SalesOrderHeader trigger to fire which will update the RevisionNumber.
        UPDATE [SalesLT].[SalesOrderHeader]
        SET [SalesLT].[SalesOrderHeader].[SubTotal] = 
            (SELECT SUM([SalesLT].[SalesOrderDetail].[LineTotal])
                FROM [SalesLT].[SalesOrderDetail]
                WHERE [SalesLT].[SalesOrderHeader].[SalesOrderID] = [SalesLT].[SalesOrderDetail].[SalesOrderID])
        WHERE [SalesLT].[SalesOrderHeader].[SalesOrderID] IN (SELECT inserted.[SalesOrderID] FROM inserted);

    END TRY
    BEGIN CATCH
        EXECUTE [dbo].[uspPrintError];

        -- Rollback any active or uncommittable transactions before
        -- inserting information in the ErrorLog
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        EXECUTE [dbo].[uspLogError];
    END CATCH;
END;
GO

CREATE TRIGGER [SalesLT].[uSalesOrderHeader] ON [SalesLT].[SalesOrderHeader] 
AFTER UPDATE AS 
BEGIN
    DECLARE @Count int;

    SET @Count = @@ROWCOUNT;
    IF @Count = 0 
        RETURN;

    SET NOCOUNT ON;

    BEGIN TRY
        -- Update RevisionNumber for modification of any field EXCEPT the Status.
        IF NOT (UPDATE([Status]) OR UPDATE([RevisionNumber]))
        BEGIN
            UPDATE [SalesLT].[SalesOrderHeader]
            SET [SalesLT].[SalesOrderHeader].[RevisionNumber] = 
                [SalesLT].[SalesOrderHeader].[RevisionNumber] + 1
            WHERE [SalesLT].[SalesOrderHeader].[SalesOrderID] IN 
                (SELECT inserted.[SalesOrderID] FROM inserted);
        END;
    END TRY
    BEGIN CATCH
        EXECUTE [dbo].[uspPrintError];

        -- Rollback any active or uncommittable transactions before
        -- inserting information in the ErrorLog
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        EXECUTE [dbo].[uspLogError];
    END CATCH;
END;
GO


-- ******************************************************
-- Add database views.
-- ******************************************************
PRINT '';
PRINT '*** Creating Table Views';
GO


CREATE VIEW [SalesLT].[vProductAndDescription] 
WITH SCHEMABINDING 
AS 
-- View (indexed or standard) to display products and product descriptions by language.
SELECT 
    p.[ProductID] 
    ,p.[Name] 
    ,pm.[Name] AS [ProductModel] 
    ,pmx.[Culture] 
    ,pd.[Description] 
FROM [SalesLT].[Product] p 
    INNER JOIN [SalesLT].[ProductModel] pm 
    ON p.[ProductModelID] = pm.[ProductModelID] 
    INNER JOIN [SalesLT].[ProductModelProductDescription] pmx 
    ON pm.[ProductModelID] = pmx.[ProductModelID] 
    INNER JOIN [SalesLT].[ProductDescription] pd 
    ON pmx.[ProductDescriptionID] = pd.[ProductDescriptionID];
GO

-- Index the vProductAndDescription view
CREATE UNIQUE CLUSTERED INDEX [IX_vProductAndDescription] ON [SalesLT].[vProductAndDescription]([Culture], [ProductID]);
GO

CREATE VIEW [SalesLT].[vProductModelCatalogDescription] 
AS 
SELECT 
    [ProductModelID] 
    ,[Name] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace html="http://www.w3.org/1999/xhtml"; 
        (/p1:ProductDescription/p1:Summary/html:p)[1]', 'nvarchar(max)') AS [Summary] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Manufacturer/p1:Name)[1]', 'nvarchar(max)') AS [Manufacturer] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Manufacturer/p1:Copyright)[1]', 'nvarchar(30)') AS [Copyright] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Manufacturer/p1:ProductURL)[1]', 'nvarchar(256)') AS [ProductURL] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain"; 
        (/p1:ProductDescription/p1:Features/wm:Warranty/wm:WarrantyPeriod)[1]', 'nvarchar(256)') AS [WarrantyPeriod] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain"; 
        (/p1:ProductDescription/p1:Features/wm:Warranty/wm:Description)[1]', 'nvarchar(256)') AS [WarrantyDescription] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain"; 
        (/p1:ProductDescription/p1:Features/wm:Maintenance/wm:NoOfYears)[1]', 'nvarchar(256)') AS [NoOfYears] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wm="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelWarrAndMain"; 
        (/p1:ProductDescription/p1:Features/wm:Maintenance/wm:Description)[1]', 'nvarchar(256)') AS [MaintenanceDescription] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wf="http://www.adventure-works.com/schemas/OtherFeatures"; 
        (/p1:ProductDescription/p1:Features/wf:wheel)[1]', 'nvarchar(256)') AS [Wheel] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wf="http://www.adventure-works.com/schemas/OtherFeatures"; 
        (/p1:ProductDescription/p1:Features/wf:saddle)[1]', 'nvarchar(256)') AS [Saddle] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wf="http://www.adventure-works.com/schemas/OtherFeatures"; 
        (/p1:ProductDescription/p1:Features/wf:pedal)[1]', 'nvarchar(256)') AS [Pedal] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wf="http://www.adventure-works.com/schemas/OtherFeatures"; 
        (/p1:ProductDescription/p1:Features/wf:BikeFrame)[1]', 'nvarchar(max)') AS [BikeFrame] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        declare namespace wf="http://www.adventure-works.com/schemas/OtherFeatures"; 
        (/p1:ProductDescription/p1:Features/wf:crankset)[1]', 'nvarchar(256)') AS [Crankset] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Picture/p1:Angle)[1]', 'nvarchar(256)') AS [PictureAngle] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Picture/p1:Size)[1]', 'nvarchar(256)') AS [PictureSize] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Picture/p1:ProductPhotoID)[1]', 'nvarchar(256)') AS [ProductPhotoID] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Specifications/Material)[1]', 'nvarchar(256)') AS [Material] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Specifications/Color)[1]', 'nvarchar(256)') AS [Color] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Specifications/ProductLine)[1]', 'nvarchar(256)') AS [ProductLine] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Specifications/Style)[1]', 'nvarchar(256)') AS [Style] 
    ,[CatalogDescription].value(N'declare namespace p1="http://schemas.microsoft.com/sqlserver/2004/07/adventure-works/ProductModelDescription"; 
        (/p1:ProductDescription/p1:Specifications/RiderExperience)[1]', 'nvarchar(1024)') AS [RiderExperience] 
    ,[rowguid] 
    ,[ModifiedDate]
FROM [SalesLT].[ProductModel] 
WHERE [CatalogDescription] IS NOT NULL;
GO

CREATE VIEW [SalesLT].[vGetAllCategories]
WITH SCHEMABINDING 
AS 
-- Returns the CustomerID, first name, and last name for the specified customer.

WITH CategoryCTE([ParentProductCategoryID], [ProductCategoryID], [Name]) AS 
(
	SELECT [ParentProductCategoryID], [ProductCategoryID], [Name]
	FROM SalesLT.ProductCategory
	WHERE ParentProductCategoryID IS NULL

UNION ALL

	SELECT C.[ParentProductCategoryID], C.[ProductCategoryID], C.[Name]
	FROM SalesLT.ProductCategory AS C
	INNER JOIN CategoryCTE AS BC ON BC.ProductCategoryID = C.ParentProductCategoryID
)

SELECT PC.[Name] AS [ParentProductCategoryName], CCTE.[Name] as [ProductCategoryName], CCTE.[ProductCategoryID]  
FROM CategoryCTE AS CCTE
JOIN SalesLT.ProductCategory AS PC 
ON PC.[ProductCategoryID] = CCTE.[ParentProductCategoryID]

GO


-- ******************************************************
-- Add database functions.
-- ******************************************************
PRINT '';
PRINT '*** Creating Database Functions';
GO

CREATE FUNCTION [dbo].[ufnGetCustomerInformation](@CustomerID int)
RETURNS TABLE 
AS 
-- Returns the CustomerID, first name, and last name for the specified customer.
RETURN (
    SELECT 
        CustomerID, 
        FirstName, 
        LastName
    FROM [SalesLT].[Customer] 
    WHERE [CustomerID] = @CustomerID
);
GO


CREATE FUNCTION [dbo].[ufnGetSalesOrderStatusText](@Status [tinyint])
RETURNS [nvarchar](15) 
AS 
-- Returns the sales order status text representation for the status value.
BEGIN
    DECLARE @ret [nvarchar](15);

    SET @ret = 
        CASE @Status
            WHEN 1 THEN 'In process'
            WHEN 2 THEN 'Approved'
            WHEN 3 THEN 'Backordered'
            WHEN 4 THEN 'Rejected'
            WHEN 5 THEN 'Shipped'
            WHEN 6 THEN 'Cancelled'
            ELSE '** Invalid **'
        END;
    
    RETURN @ret
END;
GO

-- DROP FUNCTION [dbo].[ufnGetAllCategories]

CREATE FUNCTION [dbo].[ufnGetAllCategories]()
RETURNS @retCategoryInformation TABLE 
(
    -- Columns returned by the function
    [ParentProductCategoryName] [nvarchar](50) NULL, 
    [ProductCategoryName] [nvarchar](50) NOT NULL,
	[ProductCategoryID] [int] NOT NULL
)
AS 
-- Returns the CustomerID, first name, and last name for the specified customer.
BEGIN
	WITH CategoryCTE([ParentProductCategoryID], [ProductCategoryID], [Name]) AS 
	(
		SELECT [ParentProductCategoryID], [ProductCategoryID], [Name]
		FROM SalesLT.ProductCategory
		WHERE ParentProductCategoryID IS NULL

	UNION ALL

		SELECT C.[ParentProductCategoryID], C.[ProductCategoryID], C.[Name]
		FROM SalesLT.ProductCategory AS C
		INNER JOIN CategoryCTE AS BC ON BC.ProductCategoryID = C.ParentProductCategoryID
	)

	INSERT INTO @retCategoryInformation
	SELECT PC.[Name] AS [ParentProductCategoryName], CCTE.[Name] as [ProductCategoryName], CCTE.[ProductCategoryID]  
	FROM CategoryCTE AS CCTE
	JOIN SalesLT.ProductCategory AS PC 
	ON PC.[ProductCategoryID] = CCTE.[ParentProductCategoryID];
	RETURN;
END;
GO


-- ******************************************************
-- Add Extended Properties
-- ******************************************************
PRINT '';
PRINT '*** Creating Extended Properties';
GO

SET NOCOUNT ON;
GO

PRINT '    Database';
GO

-- Database
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'AdventureWorksLT 2008 Sample OLTP Database', NULL, NULL, NULL, NULL;
GO

PRINT '    Files and Filegroups';
GO

-- Files and Filegroups
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary filegroup for the AdventureWorks sample database.', N'FILEGROUP', [PRIMARY];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary data file for the AdventureWorks sample database.', N'FILEGROUP', [PRIMARY], N'Logical File Name', [AdventureWorksLT2012_Data];
GO

PRINT '    Schemas';
GO

-- Schemas
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Contains objects related to products, customers, sales orders, and sales territories.', N'SCHEMA', [SalesLT], NULL, NULL, NULL, NULL;
GO

PRINT '    Tables and Columns';
GO

-- Tables and Columns
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Street address information for customers.', N'SCHEMA', [SalesLT], N'TABLE', [Address], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for Address records.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'First street address line.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [AddressLine1];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Second street address line.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [AddressLine2];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Name of the city.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [City];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Name of state or province.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [StateProvince];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Postal code for the street address.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [PostalCode];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Current version number of the AdventureWorksLT 2008 sample database. ', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for BuildVersion records.', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], N'COLUMN', [SystemInformationID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Version number of the database in 9.yy.mm.dd.00 format.', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], N'COLUMN', [Database Version];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], N'COLUMN', [VersionDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], N'COLUMN', [ModifiedDate];
GO


EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Customer information.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for Customer records.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'0 = The data in FirstName and LastName are stored in western style (first name, last name) order.  1 = Eastern style (last name, first name) order.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [NameStyle];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'A courtesy title. For example, Mr. or Ms.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [Title];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'First name of the person.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [FirstName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Middle name or middle initial of the person.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [MiddleName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Last name of the person.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [LastName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Surname suffix. For example, Sr. or Jr.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [Suffix];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The customer''s organization.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [CompanyName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The customer''s sales person, an employee of AdventureWorks Cycles.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [SalesPerson];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'E-mail address for the person.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [EmailAddress];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Phone number associated with the person.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [Phone];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Password for the e-mail account.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [PasswordHash];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Random value concatenated with the password string before the password is hashed.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [PasswordSalt];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Cross-reference table mapping customers to their address(es).', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. Foreign key to Customer.CustomerID.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'COLUMN', [CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. Foreign key to Address.AddressID.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'COLUMN', [AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The kind of Address. One of: Archive, Billing, Home, Main Office, Primary, Shipping', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'COLUMN', [AddressType];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Audit table tracking errors in the the AdventureWorks database that are caught by the CATCH block of a TRY...CATCH construct. Data is inserted by stored procedure dbo.uspLogError when it is executed from inside the CATCH block of a TRY...CATCH construct.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for ErrorLog records.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorLogID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The date and time at which the error occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorTime];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The user who executed the batch in which the error occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [UserName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The error number of the error that occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The severity of the error that occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorSeverity];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The state number of the error that occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorState];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The name of the stored procedure or trigger where the error occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorProcedure];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The line number at which the error occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorLine];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The message text of the error that occurred.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'COLUMN', [ErrorMessage];
GO


EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Products sold or used in the manfacturing of sold products.', N'SCHEMA', [SalesLT], N'TABLE', [Product], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for Product records.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ProductID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Name of the product.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [Name];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique product identification number.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ProductNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product color.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [Color];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Standard cost of the product.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [StandardCost];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Selling price.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ListPrice];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product size.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [Size];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product weight.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [Weight];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product is a member of this product category. Foreign key to ProductCategory.ProductCategoryID. ', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product is a member of this product model. Foreign key to ProductModel.ProductModelID.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ProductModelID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date the product was available for sale.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [SellStartDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date the product was no longer available for sale.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [SellEndDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date the product was discontinued.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [DiscontinuedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Small image of the product.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ThumbNailPhoto];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Small image file name.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ThumbnailPhotoFileName];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'High-level product categorization.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for ProductCategory records.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'COLUMN', [ProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product category identification number of immediate ancestor category. Foreign key to ProductCategory.ProductCategoryID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'COLUMN', [ParentProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Category description.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'COLUMN', [Name];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product descriptions in several languages.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key for ProductDescription records.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'COLUMN', [ProductDescriptionID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Description of the product.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'COLUMN', [Description];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Cross-reference table mapping product descriptions and the language the description is written in.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. Foreign key to ProductModel.ProductModelID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'COLUMN', [ProductModelID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. Foreign key to ProductDescription.ProductDescriptionID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'COLUMN', [ProductDescriptionID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The culture for which the description is written', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'COLUMN', [Culture];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Individual products associated with a specific sales order. See SalesOrderHeader.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. Foreign key to SalesOrderHeader.SalesOrderID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [SalesOrderID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key. One incremental unique number per product sold.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [SalesOrderDetailID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Quantity ordered per product.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [OrderQty];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product sold to customer. Foreign key to Product.ProductID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [ProductID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Selling price of a single product.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [UnitPrice];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Discount amount.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [UnitPriceDiscount];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Per product subtotal. Computed as UnitPrice * (1 - UnitPriceDiscount) * OrderQty.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [LineTotal];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'COLUMN', [ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'General sales order information.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [SalesOrderID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Incremental number to track changes to the sales order over time.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [RevisionNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Dates the sales order was created.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [OrderDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date the order is due to the customer.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [DueDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date the order was shipped to the customer.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [ShipDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Order current status. 1 = In process; 2 = Approved; 3 = Backordered; 4 = Rejected; 5 = Shipped; 6 = Cancelled', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [Status];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'0 = Order placed by sales person. 1 = Order placed online by customer.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [OnlineOrderFlag];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique sales order identification number.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [SalesOrderNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Customer purchase order number reference. ', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [PurchaseOrderNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Financial accounting number reference.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [AccountNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Customer identification number. Foreign key to Customer.CustomerID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The ID of the location to send goods.  Foreign key to the Address table.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [ShipToAddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'The ID of the location to send invoices.  Foreign key to the Address table.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [BillToAddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Shipping method. Foreign key to ShipMethod.ShipMethodID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [ShipMethod];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Approval code provided by the credit card company.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [CreditCardApprovalCode];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Sales subtotal. Computed as SUM(SalesOrderDetail.LineTotal)for the appropriate SalesOrderID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [SubTotal];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Tax amount.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [TaxAmt];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Shipping cost.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [Freight];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Total due from customer. Computed as Subtotal + TaxAmt + Freight.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [TotalDue];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Sales representative comments.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [Comment];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Date and time the record was last updated.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'COLUMN', [ModifiedDate];
GO


PRINT '    Triggers';
GO

-- Triggers
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'AFTER UPDATE trigger that updates the RevisionNumber and ModifiedDate columns in the SalesOrderHeader table.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'TRIGGER', [uSalesOrderHeader];
GO

PRINT '    Views';
GO

-- Views
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Product names and descriptions. Product descriptions are provided in multiple languages.', N'SCHEMA', [SalesLT], N'VIEW', [vProductAndDescription], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Displays the content from each element in the xml column CatalogDescription for each product in the Sales.ProductModel table that has catalog data.', N'SCHEMA', [SalesLT], N'VIEW', [vProductModelCatalogDescription], NULL, NULL;
GO

PRINT '    Unique constraints';
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'CONSTRAINT', [AK_Address_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'CONSTRAINT', [AK_Customer_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'CONSTRAINT', [AK_CustomerAddress_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [AK_Product_Name];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [AK_Product_ProductNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [AK_Product_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'CONSTRAINT', [AK_ProductDescription_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [AK_ProductCategory_Name];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [AK_ProductCategory_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'CONSTRAINT', [AK_ProductModel_Name];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'CONSTRAINT', [AK_ProductModel_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'CONSTRAINT', [AK_ProductModelProductDescription_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [AK_SalesOrderDetail_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint. Used to support replication samples.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [AK_SalesOrderHeader_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Unique nonclustered constraint.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [AK_SalesOrderHeader_SalesOrderNumber];

GO


PRINT '    Indexes';
GO

-- Indexes
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Nonclustered index.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'INDEX', [IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Nonclustered index.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'INDEX', [IX_Address_StateProvince];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'INDEX', [PK_Address_AddressID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Nonclustered index.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'INDEX', [IX_Customer_EmailAddress];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'INDEX', [PK_Customer_CustomerID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'INDEX', [PK_ErrorLog_ErrorLogID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'INDEX', [PK_Product_ProductID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'INDEX', [PK_ProductCategory_ProductCategoryID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'INDEX', [PK_ProductDescription_ProductDescriptionID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'INDEX', [PK_ProductModel_ProductModelID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'INDEX', [PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Nonclustered index.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'INDEX', [IX_SalesOrderDetail_ProductID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'INDEX', [PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Nonclustered index.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'INDEX', [IX_SalesOrderHeader_CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index created by a primary key constraint.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'INDEX', [PK_SalesOrderHeader_SalesOrderID];
GO



EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Clustered index on the view vProductAndDescription.', N'SCHEMA', [SalesLT], N'VIEW', [vProductAndDescription], N'INDEX', [IX_vProductAndDescription];
GO

PRINT '    Constraints - PK, FK, DF, CK';
GO

-- Constraints - PK, FK, DF, CK
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'CONSTRAINT', [PK_Address_AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'CONSTRAINT', [DF_Address_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [Address], N'CONSTRAINT', [DF_Address_rowguid];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [dbo], N'TABLE', [BuildVersion], N'CONSTRAINT', [DF_BuildVersion_ModifiedDate];
GO


EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'CONSTRAINT', [PK_Customer_CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'CONSTRAINT', [DF_Customer_NameStyle];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'CONSTRAINT', [DF_Customer_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [Customer], N'CONSTRAINT', [DF_Customer_rowguid];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'CONSTRAINT', [PK_CustomerAddress_CustomerID_AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'CONSTRAINT', [DF_CustomerAddress_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing Customer.CustomerID.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'CONSTRAINT', [FK_CustomerAddress_Customer_CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing Address.AddressID.', N'SCHEMA', [SalesLT], N'TABLE', [CustomerAddress], N'CONSTRAINT', [FK_CustomerAddress_Address_AddressID];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'CONSTRAINT', [PK_ErrorLog_ErrorLogID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [dbo], N'TABLE', [ErrorLog], N'CONSTRAINT', [DF_ErrorLog_ErrorTime];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [PK_Product_ProductID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing ProductModel.ProductModelID.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [FK_Product_ProductModel_ProductModelID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing ProductCategory.ProductCategoryID.', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [FK_Product_ProductCategory_ProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [DF_Product_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [DF_Product_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [ListPrice] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [CK_Product_ListPrice];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [Weight] > (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [CK_Product_Weight];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [SellEndDate] >= [SellStartDate] OR [SellEndDate] IS NULL', N'SCHEMA', [SalesLT], N'TABLE', [Product], N'CONSTRAINT', [CK_Product_SellEndDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [PK_ProductCategory_ProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing ProductCategory.ProductCategoryID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [DF_ProductCategory_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()()', N'SCHEMA', [SalesLT], N'TABLE', [ProductCategory], N'CONSTRAINT', [DF_ProductCategory_rowguid];
GO


EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'CONSTRAINT', [PK_ProductDescription_ProductDescriptionID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'CONSTRAINT', [DF_ProductDescription_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [ProductDescription], N'CONSTRAINT', [DF_ProductDescription_rowguid];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'CONSTRAINT', [PK_ProductModel_ProductModelID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'CONSTRAINT', [DF_ProductModel_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [ProductModel], N'CONSTRAINT', [DF_ProductModel_rowguid];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'CONSTRAINT', [PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing ProductDescription.ProductDescriptionID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'CONSTRAINT', [FK_ProductModelProductDescription_ProductDescription_ProductDescriptionID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing ProductModel.ProductModelID.', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'CONSTRAINT', [FK_ProductModelProductDescription_ProductModel_ProductModelID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [ProductModelProductDescription], N'CONSTRAINT', [DF_ProductModelProductDescription_ModifiedDate];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing SalesOrderHeader.SalesOrderID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0.0', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [DF_SalesOrderDetail_UnitPriceDiscount];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [DF_SalesOrderDetail_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [DF_SalesOrderDetail_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [OrderQty] > (0)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [CK_SalesOrderDetail_OrderQty];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [UnitPrice] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [CK_SalesOrderDetail_UnitPrice];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [UnitPriceDiscount] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderDetail], N'CONSTRAINT', [CK_SalesOrderDetail_UnitPriceDiscount];
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Primary key (clustered) constraint', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [PK_SalesOrderHeader_SalesOrderID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing Customer.CustomerID.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [FK_SalesOrderHeader_Customer_CustomerID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing Address.AddressID for ShipTo.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [FK_SalesOrderHeader_Address_ShipTo_AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Foreign key constraint referencing Address.AddressID for BillTo.', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [FK_SalesOrderHeader_Address_BillTo_AddressID];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_RevisionNumber];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0.0', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_Freight];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0.0', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_SubTotal];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 0.0', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_TaxAmt];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 1 (TRUE)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_OnlineOrderFlag];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of 1', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_Status];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_ModifiedDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of GETDATE()', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_OrderDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Default constraint value of NEWID()', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [DF_SalesOrderHeader_rowguid];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [Freight] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_Freight];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [SubTotal] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_SubTotal];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [TaxAmt] >= (0.00)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_TaxAmt];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [DueDate] >= [OrderDate]', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_DueDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [ShipDate] >= [OrderDate] OR [ShipDate] IS NULL', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_ShipDate];
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Check constraint [Status] BETWEEN (0) AND (8)', N'SCHEMA', [SalesLT], N'TABLE', [SalesOrderHeader], N'CONSTRAINT', [CK_SalesOrderHeader_Status];
GO


PRINT '    Functions';
GO

-- Functions

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Table value function returning the customer ID, first name, and last name for a given customer.', N'SCHEMA', [dbo], N'FUNCTION', [ufnGetCustomerInformation], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Table value function returning every product category and its parent, if applicable.', N'SCHEMA', [dbo], N'FUNCTION', [ufnGetAllCategories], NULL, NULL;

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Input parameter for the table value function ufnGetCustomerInformation. Enter a valid CustomerID from the Sales.Customer table.', N'SCHEMA', [dbo], N'FUNCTION', [ufnGetCustomerInformation], N'PARAMETER', '@CustomerID';
GO


EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Scalar function returning the text representation of the Status column in the SalesOrderHeader table.', N'SCHEMA', [dbo], N'FUNCTION', [ufnGetSalesOrderStatusText], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Input parameter for the scalar function ufnGetSalesOrderStatusText. Enter a valid integer.', N'SCHEMA', [dbo], N'FUNCTION', [ufnGetSalesOrderStatusText], N'PARAMETER', '@Status';
GO


PRINT '    Stored Procedures';
GO

-- Stored Procedures
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Logs error information in the ErrorLog table about the error that caused execution to jump to the CATCH block of a TRY...CATCH construct. Should be executed from within the scope of a CATCH block otherwise it will return without inserting error information.', N'SCHEMA', [dbo], N'PROCEDURE', [uspLogError], NULL, NULL;
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Output parameter for the stored procedure uspLogError. Contains the ErrorLogID value corresponding to the row inserted by uspLogError in the ErrorLog table.', N'SCHEMA', [dbo], N'PROCEDURE', [uspLogError], N'PARAMETER', '@ErrorLogID';
GO

EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Prints error information about the error that caused execution to jump to the CATCH block of a TRY...CATCH construct. Should be executed from within the scope of a CATCH block otherwise it will return without printing any error information.', N'SCHEMA', [dbo], N'PROCEDURE', [uspPrintError], NULL, NULL;
GO

PRINT '    XML Schemas';
GO

-- XML Schemas
EXECUTE [sys].[sp_addextendedproperty] N'MS_Description', N'Collection of XML schemas for the CatalogDescription column in the Sales.ProductModel table.', N'SCHEMA', [SalesLT], N'XML SCHEMA COLLECTION', [ProductDescriptionSchemaCollection], NULL, NULL;
GO

SET NOCOUNT OFF;
GO





-- ****************************************
-- Change File Growth Values for Database
-- ****************************************
PRINT '';
PRINT '*** Changing File Growth Values for Database';
GO

ALTER DATABASE [AdventureWorksLT2012] 
MODIFY FILE (NAME = 'AdventureWorksLT2012_Data', FILEGROWTH = 16);
GO

ALTER DATABASE [AdventureWorksLT2012] 
MODIFY FILE (NAME = 'AdventureWorksLT2012_Log', FILEGROWTH = 16);
GO


-- ****************************************
-- Shrink Database
-- ****************************************
PRINT '';
PRINT '*** Shrinking Database';
GO

DBCC SHRINKDATABASE ([AdventureWorksLT2012]);
GO


USE [master];
GO

PRINT 'Finished - ' + CONVERT(varchar, GETDATE(), 121);
GO