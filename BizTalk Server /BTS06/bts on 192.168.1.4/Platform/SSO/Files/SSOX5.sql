----- SSOX5.sql
----- Schema definition for Enterprise SSO Version 3.0
----- Copyright(c) Microsoft Corporation. All rights reserved.

-- FIX: PF bug # 17907 moved BizTalk backup code to SSOX5.sql for correct upgrade

-- FIX: PF bug # 12952: update BizTalk backup code to latest revision

--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
--/---------------------------------------------------------------------------------------------------------------
--//
--// Backup_Setup_All_Procs.sql
--//
--// Description: Configuration file for BizTalk database backup
--//
--/---------------------------------------------------------------------------------------------------------------
--

/* Run this script in each database to be marked */

/**************************************************************************************************
	Create the BTS_BACKUP role
	This role will get exec permissions on all backup related procs
	No users are added to this role, this is a manual post install step
**************************************************************************************************/
declare @ret int, @Error int

if not exists( select 1 from [dbo].[sysusers] where name=N'BTS_BACKUP_USERS' and issqlrole=1 )
 begin

	exec @ret = sp_addrole N'BTS_BACKUP_USERS'

	select @Error = @@ERROR

	if @ret <> 0 or @Error <> 0
		raiserror( 'Failed adding the ''BTS_BACKUP_USERS'' role', 16, -1 )
 end
GO

/* Check for and drop the old proc */
if exists (select * from sysobjects where id = object_id(N'dbo.sp_SetMark') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_SetMark]
GO


/**************************************************************************************************
 Create the  SetMark sp  this procedure does not use the WITH MARK keyword
 It is used when the calling procedure has specified WITH MARK and resides on
 the same server

 Arguments: @name, a string used to specify the Mark to be written in the MarkLog               
**************************************************************************************************/
CREATE PROCEDURE [dbo].[sp_SetMark]
	@name nvarchar (128)
  AS
BEGIN
	BEGIN TRANSACTION @name 

		INSERT INTO [dbo].[MarkLog]([MarkName])
		VALUES(@name)

		IF @@Error <> 0
		 BEGIN
			GOTO FAILED
		 END

	COMMIT TRANSACTION @name

	return 0

FAILED:
	if @@trancount > 0
		rollback transaction @name

	return -1
END 
GO

grant execute on [dbo].[sp_SetMark] to BTS_BACKUP_USERS
GO

/* Check for and drop the old proc */
if exists (select * from sysobjects where id = object_id(N'dbo.sp_SetMarkRemote') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_SetMarkRemote]
GO


/**************************************************************************************************
 Create the  SetMarkRemote stored procedure.  This procedure uses the WITH MARK keyword
 It is used when the calling procedure has specified WITH MARK and resides on a different  
 server and this is the first procedure on the server.  All subsequent calls should use sp_SetMark 

 Arguments: @name, a string used to specify the Mark to be written in the MarkLog  
**************************************************************************************************/

CREATE PROCEDURE [dbo].[sp_SetMarkRemote]
	@name nvarchar (128)
  AS
BEGIN
	BEGIN TRANSACTION @name WITH MARK @name

		INSERT INTO [dbo].[MarkLog]([MarkName])
		VALUES(@name)

		IF @@Error <> 0
		 BEGIN
			GOTO FAILED
		 END

	COMMIT TRANSACTION @name

	RETURN 0

FAILED:
	if @@trancount > 0
		rollback transaction @name
  	
	return -1
END 
GO

grant execute on [dbo].[sp_SetMarkRemote] to BTS_BACKUP_USERS
GO



/* Check for and drop the old proc */
if exists (select * from sysobjects where id = object_id(N'dbo.sp_BackupBizTalkLog') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[sp_BackupBizTalkLog]

GO

/**************************************************************************************************
Create the sp_BackupBizTalkLog proc.
This procedure is responsible for backing up the log of the local database to the specified path

Arguments: @seg - backup set/sequence name, @path - path to store the backup file, @BackupLocation - full path of the backup file (out)
**************************************************************************************************/

CREATE PROCEDURE [dbo].[sp_BackupBizTalkLog] @seq nvarchar (128), @path nvarchar (3000), @BackupLocation nvarchar(4000) OUTPUT
AS
begin
	declare @DBName nvarchar(128), @ServerName nvarchar(256)

	select @DBName = db_name(), @ServerName = replace( cast( isnull( serverproperty('servername'), '' ) as nvarchar ), '\', '_' ) /* this will be a file path */

	if right( @path, 1 ) = '\'
		SET @BackupLocation=@path + @ServerName + N'_' + @DBName + N'_Log_' + @seq + N'.bak'
	else	
		SET @BackupLocation=@path + N'\' + @ServerName + N'_' + @DBName + N'_Log_' + @seq + N'.bak'

	Backup LOG @DBName to DISK=@BackupLocation
	
	if @@ERROR <> 0
		goto FAILED

	return 0

FAILED:
	return -1

end
GO

grant execute on [dbo].[sp_BackupBizTalkLog] to BTS_BACKUP_USERS
GO


/* Check for and drop the old proc */
if exists (select * from sysobjects where id = object_id(N'[dbo].[sp_BackupBizTalkFull]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_BackupBizTalkFull]
GO

/**************************************************************************************************
Create the sp_BackupBizTalkFull proc.
This procedure is responsible for backing up the log of the local database to the specified path

Arguments: @seg - backup set/sequence name, @path - path to store the backup file, @BackupLocation - full path of the backup file (out)
**************************************************************************************************/

CREATE PROCEDURE [dbo].[sp_BackupBizTalkFull] @seq nvarchar (128), @path nvarchar (3000), @BackupLocation nvarchar(4000) OUTPUT
AS
begin
	declare @DBName nvarchar(128), @ServerName nvarchar(256)

	select @DBName = db_name(), @ServerName = replace( cast( isnull( serverproperty('servername'), '' ) as nvarchar ), '\', '_' ) /* this will be a file path */

	if right( @path, 1 ) = '\'
		SET @BackupLocation=@path + @ServerName + N'_' + @DBName + N'_Full_' + @seq + N'.bak'
	else
		SET @BackupLocation=@path + N'\' + @ServerName + N'_' + @DBName + N'_Full_' + @seq + N'.bak'

	Backup Database @DBName to DISK=@BackupLocation

	if @@ERROR <> 0
		goto FAILED

	return 0

FAILED:
	return -1

end
GO

grant execute on [dbo].[sp_BackupBizTalkFull] to BTS_BACKUP_USERS
GO


/* Check for and drop the old proc */
if exists (select * from sysobjects where id = object_id(N'[dbo].[sp_GetServerName]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[sp_GetServerName]
GO

/****************************************************************
Create the sp_GetServerName proc
This procedure is used to return the actual server name to avoid conflicts when two databases are
on the same server but the user uses different identifiers for the server with each database

Arguments: @name sysname -- output parameter returning the server name
**************************************************************/
CREATE PROCEDURE [dbo].[sp_GetServerName] @name sysname OUTPUT
AS
BEGIN
	set @name = CONVERT(sysname, SERVERPROPERTY('servername'))

	return 0
END
GO

grant execute on [dbo].[sp_GetServerName] to BTS_BACKUP_USERS
GO

-- FIX: PF bug # 12952: update BizTalk backup code to latest revision

--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
--/---------------------------------------------------------------------------------------------------------------
--//
--// Backup_Setup_All_Tables.sql
--//
--// Description: Configuration file for BizTalk database backup
--//
--/---------------------------------------------------------------------------------------------------------------
--			

/**************************************************************************************************
 Create the table to write the marking transaction to 
**************************************************************************************************/
if not exists (select * from sysobjects where id = object_id(N'dbo.MarkLog') AND 
	   OBJECTPROPERTY(id, N'IsTable') = 1)
	CREATE TABLE [dbo].[MarkLog] (
		[MarkName] [nvarchar] (128) 
	) ON [PRIMARY]
GO


--/---------------------------------------------------------------------------------------------------------------
-- Original SSOX5.sql starts here
--/---------------------------------------------------------------------------------------------------------------

-- FIX: V3 bug # 151: add new properties for config store apps
-- moved from SSOX.sql
-- get field info
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetFieldInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetFieldInfo
GO

CREATE PROCEDURE dbo.ssox_spGetFieldInfo
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- only return the original fields
	
	DECLARE @num_fields int
	SET @num_fields = (SELECT ai_num_fields FROM SSOX_ApplicationInfo WHERE @app_name = ai_app_name)

	SET ROWCOUNT @num_fields
	
	SELECT *
	FROM SSOX_FieldInfo
	WHERE @app_name = fi_app_name
	ORDER BY fi_ordinal
	
	SET ROWCOUNT 0
	
END
GO

-- FIX: V3 bug # 151: add new properties for config store apps
-- GetFieldInfo2
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetFieldInfo2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetFieldInfo2
GO

CREATE PROCEDURE dbo.ssox_spGetFieldInfo2
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- return all fields
	
	SELECT *
	FROM SSOX_FieldInfo
	WHERE @app_name = fi_app_name
	ORDER BY fi_ordinal
	
END
GO


-- FIX: V3 bug # 147: server discovery

-- servers table
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_Servers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_Servers]
GO

CREATE TABLE [dbo].[SSOX_Servers] (

	[srv_server_name]			[nvarchar] (260) NOT NULL,			-- long form, lower case
	[srv_expire_timestamp]		[datetime] NOT NULL,				-- expire time
	[srv_audit_id]				[uniqueidentifier] NOT NULL,		-- not used (yet)
	
	CONSTRAINT srv_name_unique	unique(srv_server_name),
	CONSTRAINT srv_row_unique	unique(srv_audit_id),
)
GO

CREATE UNIQUE CLUSTERED INDEX srv_ci ON SSOX_Servers(srv_server_name)
GO

-- set the server name in the table
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spSetServer]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spSetServer
GO

CREATE PROCEDURE dbo.ssox_spSetServer
@server_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @current_timestamp datetime
	DECLARE @expire_timestamp datetime
	DECLARE @audit_id uniqueidentifier
	
	SET @current_timestamp = getdate()
	
	-- expire time is 10 days from now
	SET @expire_timestamp = DATEADD(Day, 10, @current_timestamp);
	
	SET @audit_id = NEWID()
	
	-- remove the old name
	DELETE FROM SSOX_Servers WHERE srv_server_name = @server_name
	
	-- remove any old entries
	DELETE FROM	SSOX_Servers WHERE srv_expire_timestamp <= @current_timestamp
	
	INSERT INTO SSOX_Servers 
	VALUES 
	(
		@server_name,
		@expire_timestamp,
		@audit_id
	)
	
END
GO

-- get all the server names from the table
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetServers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetServers
GO

CREATE PROCEDURE dbo.ssox_spGetServers
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT srv_server_name FROM SSOX_Servers ORDER BY srv_server_name
		
END
GO


-- FIX: V3 bug # 156: multiple access account support
-- ssox_spGetApplicationInfo moved from SSOX.sql and modified


-- this function is used to return only the first account name in a semicolon separated string 
-- (the last index into the string - used with LEFT function - see below)
-- for V1/V2 compatibility with V3 databases
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_fnGetFirstAccountName]'))
drop function [dbo].ssox_fnGetFirstAccountName
GO

CREATE FUNCTION dbo.ssox_fnGetFirstAccountName
(@account_string nvarchar(1024))
RETURNS int
AS

BEGIN

DECLARE @SEMI int

SET @SEMI = CHARINDEX(';', @account_string)

IF (@SEMI = 0) RETURN LEN(@account_string)

RETURN (@SEMI - 1)
			
END
GO


-- get application info (modified for V3 compatibility)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetApplicationInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetApplicationInfo
GO

CREATE PROCEDURE dbo.ssox_spGetApplicationInfo
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT
		ai_app_name,
		ai_timestamp,
		ai_description,
		ai_contact_info,
		LEFT(ai_user_group_name, dbo.ssox_fnGetFirstAccountName(ai_user_group_name)),
		LEFT(ai_admin_group_name, dbo.ssox_fnGetFirstAccountName(ai_admin_group_name)),
		ai_flags,
		ai_num_fields,
		ai_purge_id,
		ai_audit_id
		
	FROM SSOX_ApplicationInfo
	WHERE @app_name = ai_app_name
	
END
GO


-- get application info (the original V1/V2 function renamed for V3)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetApplicationInfo2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetApplicationInfo2
GO

CREATE PROCEDURE dbo.ssox_spGetApplicationInfo2
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT *
	FROM SSOX_ApplicationInfo
	WHERE @app_name = ai_app_name
	
END
GO

-- FIX: V3 bug # 154: per app ticket timeout
-- add the new "ticket timeout" column to the app info table
-- FIX: V3 bug # 2322: support build-to-build upgrades
if not exists (select * from syscolumns where name = 'ai_ticket_timeout' and id = object_id('SSOX_ApplicationInfo'))
ALTER TABLE SSOX_ApplicationInfo ADD ai_ticket_timeout int DEFAULT 0 NOT NULL
GO

-- FIX: V3 bug # 154: per app ticket timeout
-- application change - copied from ssox_spApplicationInfoChange and modified for V3 
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spApplicationInfoChange2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spApplicationInfoChange2
GO

CREATE PROCEDURE dbo.ssox_spApplicationInfoChange2
@update_timestamp datetime,
@app_name nvarchar(260),
@description nvarchar(256),
@contact_info nvarchar(256),
@user_group_name nvarchar(1024),
@admin_group_name nvarchar(1024),
@flags int,
@purge_id uniqueidentifier,
@ticket_timeout int,
-- audit info
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- for auditing
	
	DECLARE @current_time datetime
	SET @current_time = getdate()

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = (SELECT ai_audit_id FROM SSOX_ApplicationInfo WHERE @app_name = ai_app_name)
		
	-- main table
	
	UPDATE SSOX_ApplicationInfo
	SET
		ai_timestamp = @current_time,
		ai_description = @description,
		ai_contact_info = @contact_info,
		ai_user_group_name = @user_group_name,
		ai_admin_group_name = @admin_group_name,
		ai_flags = @flags,
		ai_purge_id = @purge_id,
		ai_ticket_timeout = @ticket_timeout
		
	WHERE @app_name = ai_app_name AND ai_timestamp = @update_timestamp
 
	 -- auditing

	-- change record
		
	EXEC ssox_spAuditCommon
		'SSOX_ApplicationInfo2',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'change application info'
END
GO


-- FIX: V3 bug # 154: per app ticket timeout
-- application create - moved from SSOX.sql and modified for V3 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spApplicationInfoCreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spApplicationInfoCreate
GO

CREATE PROCEDURE dbo.ssox_spApplicationInfoCreate
@app_name nvarchar(260),
@description nvarchar(256),
@contact_info nvarchar(256),
@user_group_name nvarchar(1024),
@admin_group_name nvarchar(1024),
@flags int,
@num_fields int,
@purge_id uniqueidentifier,
-- audit info
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- audit info

	DECLARE @current_time datetime
	SET @current_time = getdate()

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()

	-- FIX: V3 bug # 154: per app ticket timeout
		
	DECLARE @app_ticket_timeout int
	SET @app_ticket_timeout = 0

	-- main table
	
	INSERT INTO SSOX_ApplicationInfo
	VALUES 
	(
		@app_name,
		@current_time,
		@description,
		@contact_info,
		@user_group_name,
		@admin_group_name,
		@flags,
		@num_fields,
		@purge_id,
		@audit_id,
		@app_ticket_timeout
	 )
	 
	 -- auditing
			
	EXEC ssox_spAuditCommon
		'SSOX_ApplicationInfo',
		0,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'create application info'
END
GO


-- FIX: V3 bug # 156: multiple access account support
-- ssox_spGetGlobalInfo moved from SSOX.sql and modified


-- get global info (modified for V3 compatibility)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetGlobalInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetGlobalInfo
GO

CREATE PROCEDURE dbo.ssox_spGetGlobalInfo
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT
		gi_install_timestamp,
		gi_update_timestamp,
		gi_flags,
		gi_audit_app_delete_max,
		gi_audit_mapping_delete_max,
		gi_audit_ntp_lookup_max,
		gi_audit_xp_lookup_max,
		gi_ticket_timeout,
		gi_cred_cache_timeout,
		gi_SecretServer,
		LEFT(gi_SSOAdminGroup, dbo.ssox_fnGetFirstAccountName(gi_SSOAdminGroup)),
		LEFT(gi_AffiliateAppMgrGroup, dbo.ssox_fnGetFirstAccountName(gi_AffiliateAppMgrGroup)),
		gi_audit_id
		
	FROM SSOX_GlobalInfo
	
END
GO

-- get global info (the original V1/V2 function renamed for V3)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetGlobalInfo2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetGlobalInfo2
GO

CREATE PROCEDURE dbo.ssox_spGetGlobalInfo2
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT * FROM SSOX_GlobalInfo
	
END
GO


-- FIX: V3 bug # 314: ssox_spCountCreds
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spCountCreds]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spCountCreds
GO

CREATE PROCEDURE dbo.ssox_spCountCreds
@ntp_count_out int OUTPUT,
@xp_count_out int OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT * FROM SSOX_WindowsPassword
	SET @ntp_count_out = @@ROWCOUNT
	SELECT * FROM SSOX_ExternalCredentials
	SET @xp_count_out = @@ROWCOUNT
	
END
GO


-- FIX: V3 - moved from SSOX.sql and updated for V3 (GUI/MMC)
-- order by app name - better for GUI/MMC

-- get all applications
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetApplications]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetApplications
GO

CREATE PROCEDURE dbo.ssox_spGetApplications

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT *
	FROM SSOX_ApplicationInfo
	ORDER BY ai_app_name
	
END
GO


-- FIX: V3 - moved from SSOX4.sql and updated for V3

-- get the version # for this database schema
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetDBVersion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetDBVersion
GO

CREATE PROCEDURE dbo.ssox_spGetDBVersion
@major int OUTPUT,
@minor int OUTPUT

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SET @major = 3

	-- FIX: V3 bug # 2322: support build-to-build upgrades
	-- NOTE: update this minor version for *any* schema changes! Sync with SSOSetupHook.cpp
	
	SET @minor = 1
		
END
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIsDBCompatible]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIsDBCompatible
GO

CREATE PROCEDURE dbo.ssox_spIsDBCompatible
@major int,
@minor int
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	IF (@major < 3 OR (@major = 3 AND @minor = 0))
		RETURN 1
	RETURN 0	
END
GO


-- NOTE: this function must be the last stored procedure created, as it is the first the SSO 
-- server calls, thus it checks for complete database creation
-- get the version # for this database schema


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetVersion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetVersion
GO

CREATE PROCEDURE dbo.ssox_spGetVersion
@major int OUTPUT,
@minor int OUTPUT

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SET @major = 0
	SET @minor = 0

	-- FIX: bug # 91371: binary collation support
	-- return minor = 1 if the database is case sensitive
	-- (this will prevent older servers without SP1 from running with case sensitive databases)
		
	DECLARE @CurrentCollation nvarchar(128)

	SELECT @CurrentCollation = CAST(DATABASEPROPERTYEX(DB_NAME(), 'Collation') AS nvarchar(128))

	SET @minor = CHARINDEX('_CS_', @CurrentCollation)
	SET @minor = @minor + CHARINDEX('_BIN', @CurrentCollation)

	IF @minor > 0 SET @minor = 1
			
END
GO

