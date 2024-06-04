--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Remove existing global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- 
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_removeconstraints
GO

------------------------------------------------------------------------
-- Create Tables
IF NOT exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_sat]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	BEGIN
		CREATE TABLE [dbo].[adpl_sat] (
			[id] [int] IDENTITY (1, 1) NOT NULL ,
			[applicationId] [int] NOT NULL ,
			[sdmType] [nvarchar] (256) NULL ,
			[luid] [nvarchar] (440) NULL ,
			[properties] [ntext],
			[files] [ntext],
			[cabContent] [image]
		) ON [PRIMARY]

	END
GO

GRANT SELECT ON [dbo].[adpl_sat] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[adpl_sat] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[adpl_sat] TO BTS_OPERATORS

GO


--////////////////////// TODO: ensure that direct table access is revoked by Admin during setup - only SProcs should be used
------------------------------- Indexes --------------------------------------------------
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'IX_adpl_sat')
   DROP INDEX [adpl_sat].[IX_adpl_sat]

CREATE NONCLUSTERED INDEX [IX_adpl_sat] ON [dbo].[adpl_sat]
	(
	    [applicationId]
	) ON [PRIMARY]

GO
------------------------------- Constraints definition -----------------------------------
ALTER TABLE [dbo].[adpl_sat] WITH NOCHECK ADD 
	CONSTRAINT [PK_adpl_sat] PRIMARY KEY NONCLUSTERED 
	(
		[id]
	)  ON [PRIMARY],

	CONSTRAINT [UQ_adpl_sat] UNIQUE CLUSTERED 
	(
		[luid]
	)  ON [PRIMARY],

	CONSTRAINT [FK_bts_application_adpl_sat] 
	FOREIGN KEY ([applicationId]) 
		REFERENCES [bts_application]([nID]) 
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Re-apply global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- 

if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_addconstraints
GO





