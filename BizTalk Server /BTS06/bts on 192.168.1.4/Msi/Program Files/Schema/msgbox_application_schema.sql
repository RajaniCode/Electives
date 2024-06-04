--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
------------------------------------------------------------------------------
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Applications]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_RemoveApplication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	BEGIN
		DECLARE @ApplicationName nvarchar(128)

		DECLARE curse CURSOR FOR
			SELECT nvcApplicationName FROM Applications

		OPEN curse

		FETCH NEXT FROM curse INTO @ApplicationName
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			exec bts_RemoveApplication @ApplicationName

			FETCH NEXT FROM curse INTO @ApplicationName
		END

		CLOSE curse
		DEALLOCATE curse
	END
	
	drop table [dbo].[Applications]
END

GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ApplicationProps]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[ApplicationProps]
GO

--*********************************************************************
--*
--CREATE TABLES
--*********************************************************************

CREATE TABLE [dbo].[Applications] (
	[nvcApplicationName] [nvarchar] (128) ,
	[uidAppID] [uniqueidentifier] NOT NULL
)
GO

CREATE TABLE [dbo].[ApplicationProps] (
	[nvcApplicationName] [nvarchar] (128) NOT NULL ,
	[uidPropID] [uniqueidentifier] NOT NULL,
	[vtPropValue] [sql_variant] NOT NULL ,
)
GO

--*********************************************************************
--*
--END CREATE TABLES
--*********************************************************************

--*********************************************************************
--*
--CREATE INDICES
--*********************************************************************

CREATE UNIQUE CLUSTERED INDEX [CIX_Applications] ON [dbo].[Applications]([nvcApplicationName])
GO

CREATE INDEX [IX_Applications] ON [dbo].[Applications]([uidAppID], [nvcApplicationName])
GO

CREATE UNIQUE INDEX [IX_ApplicationProps] ON [dbo].[ApplicationProps] ([nvcApplicationName], [uidPropID], [vtPropValue])
GO


GRANT SELECT ON [Applications] TO BTS_ADMIN_USERS
GRANT SELECT ON [Applications] TO BTS_OPERATORS 
GO


