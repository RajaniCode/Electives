----- SSOX.sql
----- Schema definition for Enterprise SSO
----- Copyright(c) Microsoft Corporation. All rights reserved.

/*****

some common abbreviations (see spec)

 ntd = NT Domain
 ntu = NT User Id
 xa = External Application
 xu = External User Name
 xp = External Password (credentials)

*****/

/*****

FIX: bug # 59179:

SQL server has a runtime size limit on index length values of 900 bytes (450 Unicode characters).

*****/

-- drop tables in reverse order of FK dependencies

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AuditAppDelete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AuditAppDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AuditMappingDelete]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AuditMappingDelete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AuditNtpLookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AuditNtpLookup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AuditXpLookup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AuditXpLookup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AuditTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AuditTable]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_WindowsPassword]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_WindowsPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_ExternalCredentials]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_ExternalCredentials]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_IndividualMapping]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_IndividualMapping]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_FieldInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_FieldInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AppToAdapter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AppToAdapter]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AdapterQueue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AdapterQueue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_ApplicationInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_ApplicationInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_GlobalInfo]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_GlobalInfo]
GO

-- create tables in order of FK dependencies


-- global info - only one row allowed for this table


CREATE TABLE [dbo].[SSOX_GlobalInfo] (

	[gi_install_timestamp]			[datetime] NOT NULL,
	[gi_update_timestamp]			[datetime] NOT NULL,
	[gi_flags]						[int] NOT NULL,
	[gi_audit_app_delete_max]		[int] NOT NULL,
	[gi_audit_mapping_delete_max]	[int] NOT NULL,
	[gi_audit_ntp_lookup_max]		[int] NOT NULL,
	[gi_audit_xp_lookup_max]		[int] NOT NULL,
	[gi_ticket_timeout]				[int] NOT NULL,
	[gi_cred_cache_timeout]			[int] NOT NULL,
	
	-- these next 3 fields copied from SPS sso_schema.sql
	
	[gi_SecretServer]			[nvarchar] (256) NOT NULL,
	[gi_SSOAdminGroup]			[nvarchar] (1024) NOT NULL,
	[gi_AffiliateAppMgrGroup]	[nvarchar] (1024) NOT NULL,
	
	[gi_audit_id]				[uniqueidentifier] NOT NULL,
	
	CONSTRAINT global_info_pk			primary key(gi_update_timestamp),
	CONSTRAINT global_info_unique		unique(gi_audit_id),
)
GO


-- [ai_audit_id] can also be used as a unique id for this app, if required
-- [ai_num_fields] is the number of fields in the field info - it is not changeable
-- the number of fields retrieved from the field info must match this number

CREATE TABLE [dbo].[SSOX_ApplicationInfo] (

	[ai_app_name]				[nvarchar] (260) NOT NULL,
	[ai_timestamp]				[datetime] NOT NULL,
	[ai_description]			[nvarchar] (256) NOT NULL,
	[ai_contact_info]			[nvarchar] (256) NOT NULL,
	[ai_user_group_name]		[nvarchar] (1024) NOT NULL,
	[ai_admin_group_name]		[nvarchar] (1024) NOT NULL,
	[ai_flags]					[int] NOT NULL,
	[ai_num_fields]				[int] NOT NULL,
	[ai_purge_id]				[uniqueidentifier] NOT NULL,
	[ai_audit_id]				[uniqueidentifier] NOT NULL,

	CONSTRAINT application_info_unique		unique(ai_audit_id),
)
GO

CREATE UNIQUE CLUSTERED INDEX application_info_ci ON SSOX_ApplicationInfo(ai_app_name)
GO

CREATE TRIGGER trigger_ai_audit ON SSOX_ApplicationInfo FOR DELETE AS
BEGIN
	DELETE FROM SSOX_AuditTable WHERE at_audit_id IN (SELECT ai_audit_id FROM deleted)
END
GO

-- common audit table for all other tables


-- [audit_id] identifies the corresponding row in the source table
-- [audit_type], 0 = create audit, 1 = change audit (only audit last change)

CREATE TABLE [dbo].[SSOX_AuditTable] (

	-- audit info - created/changed, when, who, where, why
	
	[at_audit_id]			[uniqueidentifier] NOT NULL,
	[at_audit_type]			[bit] NOT NULL,
	[at_timestamp]			[datetime] NOT NULL,
	[at_source_table]		[nvarchar] (256) NOT NULL,
	[at_client_user]		[nvarchar] (256) NOT NULL,
	[at_client_machine]		[nvarchar] (256) NOT NULL,
	[at_tracking_id]		[uniqueidentifier] NOT NULL,
	[at_server_user]		[nvarchar] (256) NOT NULL,
	[at_server_machine]		[nvarchar] (256) NOT NULL,
	[at_description]		[nvarchar] (256) NOT NULL,
)
GO

CREATE UNIQUE CLUSTERED INDEX audit_table_ci ON SSOX_AuditTable(at_audit_id, at_audit_type)
GO

-- audit table for app deletes


CREATE TABLE [dbo].[SSOX_AuditAppDelete] (

	[ad_app_name]			[nvarchar] (260) NOT NULL,
	[ad_timestamp]			[datetime] NOT NULL,
	[ad_client_user]		[nvarchar] (256) NOT NULL,
	[ad_client_machine]		[nvarchar] (256) NOT NULL,
	[ad_tracking_id]		[uniqueidentifier] NOT NULL,
	[ad_server_user]		[nvarchar] (256) NOT NULL,
	[ad_server_machine]		[nvarchar] (256) NOT NULL,
	[ad_identity]			[int] IDENTITY,

	CONSTRAINT audit_app_delete_table_pk		primary key(ad_identity),
)
GO


-- audit table for mapping deletes


CREATE TABLE [dbo].[SSOX_AuditMappingDelete] (

	[md_ntd]				[nvarchar] (16) NOT NULL,
	[md_ntu]				[nvarchar] (256) NOT NULL,
	[md_xa]					[nvarchar] (260) NOT NULL,
	[md_xu]					[nvarchar] (256) NOT NULL,
	[md_timestamp]			[datetime] NOT NULL,
	[md_client_user]		[nvarchar] (256) NOT NULL,
	[md_client_machine]		[nvarchar] (256) NOT NULL,
	[md_tracking_id]		[uniqueidentifier] NOT NULL,
	[md_server_user]		[nvarchar] (256) NOT NULL,
	[md_server_machine]		[nvarchar] (256) NOT NULL,
	[md_identity]			[int] IDENTITY,

	CONSTRAINT audit_mapping_delete_table_pk		primary key(md_identity),
)
GO


-- audit table for ntp lookups


CREATE TABLE [dbo].[SSOX_AuditNtpLookup] (

	[nl_ntd]				[nvarchar] (16) NOT NULL,
	[nl_ntu]				[nvarchar] (256) NOT NULL,
	[nl_xa]					[nvarchar] (260) NOT NULL,
	[nl_xu]					[nvarchar] (256) NOT NULL,
	[nl_timestamp]			[datetime] NOT NULL,
	[nl_client_user]		[nvarchar] (256) NOT NULL,
	[nl_client_machine]		[nvarchar] (256) NOT NULL,
	[nl_tracking_id]		[uniqueidentifier] NOT NULL,
	[nl_server_user]		[nvarchar] (256) NOT NULL,
	[nl_server_machine]		[nvarchar] (256) NOT NULL,
	[nl_identity]			[int] IDENTITY,

	CONSTRAINT audit_ntp_lookup_table_pk		primary key(nl_identity),
)
GO

 
-- audit table for xp lookups
-- NOTE: have separate tables for each way lookups to avoid hotspots


CREATE TABLE [dbo].[SSOX_AuditXpLookup] (

	[xl_ntd]				[nvarchar] (16) NOT NULL,
	[xl_ntu]				[nvarchar] (256) NOT NULL,
	[xl_xa]					[nvarchar] (260) NOT NULL,
	[xl_xu]					[nvarchar] (256) NOT NULL,
	[xl_timestamp]			[datetime] NOT NULL,
	[xl_client_user]		[nvarchar] (256) NOT NULL,
	[xl_client_machine]		[nvarchar] (256) NOT NULL,
	[xl_tracking_id]		[uniqueidentifier] NOT NULL,
	[xl_server_user]		[nvarchar] (256) NOT NULL,
	[xl_server_machine]		[nvarchar] (256) NOT NULL,
	[xl_identity]			[int] IDENTITY,

	CONSTRAINT audit_xp_lookup_table_pk		primary key(xl_identity),
)
GO


-- field info for the application


CREATE TABLE [dbo].[SSOX_FieldInfo] (

	-- field info

	[fi_app_name]			[nvarchar] (260) NOT NULL,
	[fi_label]				[nvarchar] (256) NOT NULL,
	[fi_ordinal]			[int] IDENTITY,
	[fi_flags]				[int] NOT NULL,
	[fi_audit_id]			[uniqueidentifier] NOT NULL,
	
	CONSTRAINT field_info_unique	unique(fi_app_name, fi_ordinal),
	CONSTRAINT field_info_unique2	unique(fi_audit_id),
	CONSTRAINT field_info_fk		foreign key(fi_app_name) references [dbo].[SSOX_ApplicationInfo](ai_app_name) on delete cascade,
)
GO

CREATE UNIQUE CLUSTERED INDEX field_info_ci ON SSOX_FieldInfo(fi_app_name, fi_label)
GO

CREATE TRIGGER trigger_fi_audit ON SSOX_FieldInfo FOR DELETE AS
BEGIN
	DELETE FROM SSOX_AuditTable WHERE at_audit_id IN (SELECT fi_audit_id FROM deleted)
END
GO

-- stored procedures

--

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAuditCommon]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAuditCommon
GO

CREATE PROCEDURE dbo.ssox_spAuditCommon
@source_table nvarchar(256),
@audit_type int,
@timestamp datetime,
@audit_id uniqueidentifier,
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256),
@description nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	IF @audit_type = 0

	BEGIN
	
		-- create record
		
		INSERT INTO SSOX_AuditTable
		VALUES 
		(
			@audit_id,
			0,
			@timestamp,
			@source_table,
			@client_user,
			@client_machine,
			@tracking_id,
			@server_user,
			@server_machine,
			@description
		)
		
		-- first change record
		
		INSERT INTO SSOX_AuditTable
		VALUES 
		(
			@audit_id,
			1,
			@timestamp,
			@source_table,
			@client_user,
			@client_machine,
			@tracking_id,
			@server_user,
			@server_machine,
			@description
		)

	END
	
	ELSE
	BEGIN
		UPDATE SSOX_AuditTable
		SET 
			at_timestamp = @timestamp,
			at_source_table = @source_table,
			at_client_user = @client_user,
			at_client_machine = @client_machine,
			at_tracking_id = @tracking_id,
			at_server_user = @server_user,
			at_server_machine = @server_machine,
			at_description = @description

		WHERE at_audit_id = @audit_id AND at_audit_type = 1
	END
END
GO
 
-- audit app delete

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAuditAppDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAuditAppDelete
GO

CREATE PROCEDURE dbo.ssox_spAuditAppDelete
@app_name nvarchar(260),
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	
	DECLARE @timestamp datetime
	SET @timestamp = getdate()
	
	INSERT INTO SSOX_AuditAppDelete
	VALUES 
	(
		@app_name,
		@timestamp,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
	)
		
	DECLARE @currentCount int
	SET @currentCount = (SELECT COUNT(*) FROM SSOX_AuditAppDelete)
	
	DECLARE @maxCount int
	SET @maxCount = (SELECT gi_audit_app_delete_max FROM SSOX_GlobalInfo)
	
	IF (@currentCount < @maxCount)
		RETURN(0)
	
	-- delete the oldest entry
		
	SET @timestamp = (SELECT TOP 1 ad_timestamp FROM SSOX_AuditAppDelete ORDER BY ad_timestamp DESC);
	
	DELETE FROM SSOX_AuditAppDelete WHERE ad_timestamp <= @timestamp
	
END
GO


-- audit mapping delete


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAuditMappingDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAuditMappingDelete
GO

CREATE PROCEDURE dbo.ssox_spAuditMappingDelete
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@xu nvarchar(256),
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	
	DECLARE @timestamp datetime
	SET @timestamp = getdate()
	
	INSERT INTO SSOX_AuditMappingDelete
	VALUES 
	(
		@ntd,
		@ntu,
		@xa,
		@xu,
		@timestamp,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
	)
		
	DECLARE @currentCount int
	SET @currentCount = (SELECT COUNT(*) FROM SSOX_AuditMappingDelete)
	
	DECLARE @maxCount int
	SET @maxCount = (SELECT gi_audit_mapping_delete_max FROM SSOX_GlobalInfo)
	
	IF (@currentCount < @maxCount)
		RETURN(0)
	
	-- delete the oldest entry
		
	SET @timestamp = (SELECT TOP 1 md_timestamp FROM SSOX_AuditMappingDelete ORDER BY md_timestamp DESC);
	
	DELETE FROM SSOX_AuditMappingDelete WHERE md_timestamp <= @timestamp

END
GO


-- audit ntp lookup


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAuditNtpLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAuditNtpLookup
GO

CREATE PROCEDURE dbo.ssox_spAuditNtpLookup
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@xu nvarchar(256),
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	
	DECLARE @timestamp datetime
	SET @timestamp = getdate()
	
	INSERT INTO SSOX_AuditNtpLookup
	VALUES 
	(
		@ntd,
		@ntu,
		@xa,
		@xu,
		@timestamp,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
	)
		
	DECLARE @currentCount int
	SET @currentCount = (SELECT COUNT(*) FROM SSOX_AuditNtpLookup)
	
	DECLARE @maxCount int
	SET @maxCount = (SELECT gi_audit_ntp_lookup_max FROM SSOX_GlobalInfo)
	
	IF (@currentCount < @maxCount)
		RETURN(0)
	
	-- delete the oldest entry
		
	SET @timestamp = (SELECT TOP 1 nl_timestamp FROM SSOX_AuditNtpLookup ORDER BY nl_timestamp DESC);
	
	DELETE FROM SSOX_AuditNtpLookup WHERE nl_timestamp <= @timestamp

END
GO


-- audit xp lookup


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAuditXpLookup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAuditXpLookup
GO

CREATE PROCEDURE dbo.ssox_spAuditXpLookup
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@xu nvarchar(256),
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
	
	DECLARE @timestamp datetime
	SET @timestamp = getdate()
	
	INSERT INTO SSOX_AuditXpLookup
	VALUES 
	(
		@ntd,
		@ntu,
		@xa,
		@xu,
		@timestamp,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
	)
		
	DECLARE @currentCount int
	SET @currentCount = (SELECT COUNT(*) FROM SSOX_AuditXpLookup)
	
	DECLARE @maxCount int
	SET @maxCount = (SELECT gi_audit_xp_lookup_max FROM SSOX_GlobalInfo)
	
	IF (@currentCount < @maxCount)
		RETURN(0)
	
	-- delete the oldest entry
		
	SET @timestamp = (SELECT TOP 1 xl_timestamp FROM SSOX_AuditXpLookup ORDER BY xl_timestamp DESC);
	
	DELETE FROM SSOX_AuditXpLookup WHERE xl_timestamp <= @timestamp

END
GO


-- FIX: V3 bug # 154: per app ticket timeout
-- ssox_spApplicationInfoCreate moved to SSOX5.sql and updated


-- application delete


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spApplicationInfoDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spApplicationInfoDelete
GO

CREATE PROCEDURE dbo.ssox_spApplicationInfoDelete
@app_name nvarchar(260),
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

	-- main table
	
	DECLARE @retval int
	
	DELETE FROM SSOX_ApplicationInfo
	WHERE @app_name = ai_app_name
	 
	SET @retval = @@ROWCOUNT
	
	-- auditing
			
	EXEC ssox_spAuditAppDelete
		@app_name,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine

	RETURN(@retval)
END
GO

-- application change


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spApplicationInfoChange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spApplicationInfoChange
GO

CREATE PROCEDURE dbo.ssox_spApplicationInfoChange
@update_timestamp datetime,
@app_name nvarchar(260),
@description nvarchar(256),
@contact_info nvarchar(256),
@user_group_name nvarchar(1024),
@admin_group_name nvarchar(1024),
@flags int,
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
		ai_purge_id = @purge_id
		
	WHERE @app_name = ai_app_name AND ai_timestamp = @update_timestamp
 
	 -- auditing

	-- change record
		
	EXEC ssox_spAuditCommon
		'SSOX_ApplicationInfo',
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


-- FIX: V3: order by app name for GUI/MMC
-- ssox_spGetApplications moved to SSOX5.sql


-- FIX: V3 bug # 156: multiple access account support
-- ssox_spGetApplicationInfo moved to SSOX5.sql

-- field info create
-- NOTE: field info is deleted when app is deleted - field info cannot be changed

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spFieldInfoCreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spFieldInfoCreate
GO

CREATE PROCEDURE dbo.ssox_spFieldInfoCreate
@app_name nvarchar(260),
@label nvarchar(256),
@flags int,
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

	DECLARE @current_time datetime
	SET @current_time = getdate()

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()
		
	-- main table

	INSERT INTO SSOX_FieldInfo
	VALUES 
	(
		@app_name,
		@label,
		@flags,
		@audit_id
	 )
	 
	 -- auditing
			
	EXEC ssox_spAuditCommon
		'SSOX_FieldInfo',
		0,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'create field info'
END
GO

-- FIX: V3 bug # 151: add new properties for config store apps
-- ssox_spGetFieldInfo moved to SSOX5.sql and modified

-- FIX: V3 bug # 156: multiple access account support
-- ssox_spGetGlobalInfo moved to SSOX5.sql and modified


-- change global info


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGlobalInfoChange]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGlobalInfoChange
GO

CREATE PROCEDURE dbo.ssox_spGlobalInfoChange
@update_timestamp datetime,
@flags int,
@audit_app_delete_max int,
@audit_mapping_delete_max int,
@audit_ntp_lookup_max int,
@audit_xp_lookup_max int,
@ticket_timeout int,
@cred_cache_timeout int,
@SecretServer nvarchar(256),
@SSOAdminGroup nvarchar(1024),
@AffiliateAppMgrGroup nvarchar(1024),
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

	DECLARE @current_time datetime
	SET @current_time = getdate()

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = (SELECT gi_audit_id FROM SSOX_GlobalInfo)

	-- main table
	
	UPDATE SSOX_GlobalInfo
	SET
		gi_update_timestamp = @current_time,
		gi_flags = @flags,
		gi_audit_app_delete_max = @audit_app_delete_max,
		gi_audit_mapping_delete_max = @audit_mapping_delete_max,
		gi_audit_ntp_lookup_max = @audit_ntp_lookup_max,
		gi_audit_xp_lookup_max = @audit_xp_lookup_max,
		gi_ticket_timeout = @ticket_timeout,
		gi_cred_cache_timeout = @cred_cache_timeout,
		gi_SecretServer = @SecretServer,
		gi_SSOAdminGroup = @SSOAdminGroup,
		gi_AffiliateAppMgrGroup = @AffiliateAppMgrGroup,
		gi_audit_id = @audit_id
	 WHERE gi_update_timestamp = @update_timestamp
	  
	 -- auditing
			
	EXEC ssox_spAuditCommon
		'SSOX_GlobalInfo',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'change global info'
END
GO


-- get deleted mappings (for update of credential cache)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetDeletedMappings]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetDeletedMappings
GO

CREATE PROCEDURE dbo.ssox_spGetDeletedMappings
@timestamp_in datetime
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- get the mappings deleted since the last latest entry
	
	SELECT * FROM SSOX_AuditMappingDelete WHERE md_timestamp > @timestamp_in
	ORDER BY md_timestamp DESC
	
END
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetSQLTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetSQLTime
GO

CREATE PROCEDURE dbo.ssox_spGetSQLTime
@timestamp_out datetime OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SET @timestamp_out = getdate()
	
END
GO
