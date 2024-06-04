----- SSOX4.sql
----- Schema definition for Enterprise SSO PASSWORD SYNC
----- Copyright(c) Microsoft Corporation. All rights reserved.



-- APPLICATION TO ADAPTER TABLE
-- apps can only be mapped to one adapter
-- an adapter can have multiple apps mapped to it
-- adapters are a special kind of config store app
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AppToAdapter]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AppToAdapter]
GO

CREATE TABLE [dbo].[SSOX_AppToAdapter] (

	[aa_app_name]			[nvarchar] (260) NOT NULL,
	[aa_adapter_name]		[nvarchar] (260) NOT NULL,
	[aa_audit_id]			[uniqueidentifier] NOT NULL,		-- not used
	
	CONSTRAINT app_adapter_unique	unique(aa_app_name),
	CONSTRAINT app_adapter_unique2	unique(aa_audit_id),
	CONSTRAINT app_adapter_fk1		foreign key(aa_adapter_name) references [dbo].[SSOX_ApplicationInfo](ai_app_name) on delete cascade,
	CONSTRAINT app_adapter_fk2		foreign key(aa_app_name) references [dbo].[SSOX_ApplicationInfo](ai_app_name),
)
GO

CREATE UNIQUE CLUSTERED INDEX app_adapter_ci ON SSOX_AppToAdapter(aa_app_name, aa_adapter_name)
GO


-- CREATE (one app to adapter entry)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAppToAdapterCreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAppToAdapterCreate
GO

CREATE PROCEDURE dbo.ssox_spAppToAdapterCreate
@app_name nvarchar(260),
@adapter_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()
		
	INSERT INTO SSOX_AppToAdapter
	VALUES 
	(
		@app_name,
		@adapter_name,
		@audit_id
	 )
	 
END
GO

-- DELETE (one app to adapter entry, by app)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAppToAdapterDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAppToAdapterDelete
GO

CREATE PROCEDURE dbo.ssox_spAppToAdapterDelete
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @retval int
	
	DELETE FROM SSOX_AppToAdapter
	WHERE @app_name = aa_app_name
	 
	SET @retval = @@ROWCOUNT
	
	RETURN(@retval)
END
GO

-- LIST (all entries for one adapter, by adapter)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAppToAdapterList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAppToAdapterList
GO

CREATE PROCEDURE dbo.ssox_spAppToAdapterList
@adapter_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT *
	FROM SSOX_AppToAdapter
	WHERE @adapter_name = aa_adapter_name
	
END
GO


-- GetMappingsForAdapter -- get all mappings associated with this adapter
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetMappingsForAdapter]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetMappingsForAdapter
GO

CREATE PROCEDURE dbo.ssox_spGetMappingsForAdapter
@adapter_name nvarchar(260),
@xu nvarchar(256)

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	SELECT *
	FROM SSOX_IndividualMapping
	JOIN SSOX_AppToAdapter
	ON (SSOX_IndividualMapping.im_xa = SSOX_AppToAdapter.aa_app_name)
	WHERE SSOX_IndividualMapping.im_xu = @xu AND SSOX_AppToAdapter.aa_adapter_name = @adapter_name
END
GO

-- GetAdapterForApp
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetAdapterForApp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetAdapterForApp
GO

CREATE PROCEDURE dbo.ssox_spGetAdapterForApp
@app_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- only one row will be returned

	SELECT *
	FROM SSOX_AppToAdapter
	WHERE @app_name = aa_app_name
	
END
GO


-- LookupNtp (MOVED FROM SSOX2.sql and modified to change parameters)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spLookupNtp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spLookupNtp
GO

CREATE PROCEDURE dbo.ssox_spLookupNtp
@ntd nvarchar(16),
@ntu nvarchar(256),
-- audit info
@client_user nvarchar(256),
@client_machine nvarchar(256),
@tracking_id uniqueidentifier,
@server_user nvarchar(256),
@server_machine nvarchar(256),
-- outputs
@ntp varbinary(4096) OUTPUT,
@msid uniqueidentifier OUTPUT,
@timestamp_out datetime OUTPUT

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT 
		@ntp = wp_password, 
		@msid = wp_msid,
		@timestamp_out = wp_timestamp
	FROM SSOX_WindowsPassword WHERE wp_ntd = @ntd AND wp_ntu = @ntu
	
	RETURN(@@ROWCOUNT)
	
	-- CODEWORK: auditing
	
END
GO

-- ADAPTER QUEUES

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_AdapterQueue]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_AdapterQueue]
GO

CREATE TABLE [dbo].[SSOX_AdapterQueue] (

	[aq_adapter]					[nvarchar] (260) NOT NULL,
	[aq_notification_id]			[uniqueidentifier] NOT NULL,
	[aq_timestamp]					[datetime] NOT NULL,
	[aq_type]						[int] NOT NULL,
	[aq_xu]							[nvarchar] (256) NOT NULL,
	[aq_ntd]						[nvarchar] (16) NOT NULL,
	[aq_ntu]						[nvarchar] (256) NOT NULL,
	[aq_retry_count]				[int] NOT NULL,
	[aq_flags]						[int] NOT NULL,
	[aq_tracking_id]				[uniqueidentifier] NOT NULL,
	
	CONSTRAINT aq_unique	unique(aq_notification_id),
	CONSTRAINT aq_fk		foreign key([aq_adapter]) references [dbo].[SSOX_ApplicationInfo](ai_app_name) on delete cascade,
)
GO

CREATE UNIQUE CLUSTERED INDEX aq_ci ON SSOX_AdapterQueue(aq_notification_id)
GO


-- AddNotification
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spAddNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spAddNotification
GO

CREATE PROCEDURE dbo.ssox_spAddNotification
@adapter_name nvarchar(260),
@notification_id uniqueidentifier,
@notification_timestamp datetime,
@notification_type int,
@xu nvarchar(256),
@ntd nvarchar(16),
@ntu nvarchar(256),
@retry_count int,
@flags int,
@tracking_id uniqueidentifier
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	-- clean out any old password change notifications for this account
		
	-- notification type 3 is SSO_NOTIFICATION_TYPE_PASSWORD_CHANGE

	IF @notification_type = 3
		DELETE FROM SSOX_AdapterQueue
		WHERE aq_type = 3
		AND aq_adapter = @adapter_name
		AND aq_ntd = @ntd 
		AND aq_ntu = @ntu 
		AND aq_xu = @xu 
		AND aq_timestamp <= @notification_timestamp

	-- now add the new notification
	
	INSERT INTO SSOX_AdapterQueue
	VALUES 
	(
		@adapter_name,
		@notification_id,
		@notification_timestamp,
		@notification_type,
		@xu,
		@ntd,
		@ntu,
		@retry_count,
		@flags,
		@tracking_id
	)

END
GO

-- DeleteNotification
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spDeleteNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spDeleteNotification
GO

CREATE PROCEDURE dbo.ssox_spDeleteNotification
@adapter_name nvarchar(260),
@notification_id uniqueidentifier
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @retval int
	
	DELETE FROM SSOX_AdapterQueue
	WHERE @notification_id = aq_notification_id
	 
	SET @retval = @@ROWCOUNT
		
END
GO

-- UpdateNotification
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spUpdateNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spUpdateNotification
GO

CREATE PROCEDURE dbo.ssox_spUpdateNotification
@adapter_name nvarchar(260),
@notification_id uniqueidentifier,
@notification_timestamp datetime,
@retry_count int,
@flags int
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	UPDATE SSOX_AdapterQueue
	SET
		aq_timestamp = @notification_timestamp,
		aq_retry_count = @retry_count,
		aq_flags = @flags
		
	WHERE @adapter_name = aq_adapter AND @notification_id = aq_notification_id
	
END
GO

-- GetNextNotification
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetNextNotification]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetNextNotification
GO

CREATE PROCEDURE dbo.ssox_spGetNextNotification
@adapter_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @current_time datetime
	SET @current_time = getdate()
	
	SELECT TOP 1 * FROM SSOX_AdapterQueue 
	WHERE aq_adapter = @adapter_name AND aq_timestamp < @current_time 
	ORDER BY aq_timestamp DESC
	
END
GO


-- WriteXPSync - only update the sync field
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spWriteXpSync]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spWriteXpSync
GO

CREATE PROCEDURE dbo.ssox_spWriteXpSync
@xa nvarchar(260),
@xu nvarchar(256),
@password_to_sync image,
@msid uniqueidentifier,
@timestamp_in datetime,
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

	DECLARE @ERROR_UPDATE_FAILED int
	SET @ERROR_UPDATE_FAILED = 0x9901

	DECLARE @ERROR_UPDATE_FAILED2 int
	SET @ERROR_UPDATE_FAILED2 = 0x9904

	DECLARE @RETURN_CODE int
	SET @RETURN_CODE = 0

	-- does mapping already exist?
		
	DECLARE @audit_id uniqueidentifier
	SET @audit_id = (SELECT ec_audit_id FROM SSOX_ExternalCredentials WHERE ec_xa = @xa AND ec_xu = @xu)
	
	IF (@audit_id IS NULL)
		BEGIN
			SET @RETURN_CODE = @ERROR_UPDATE_FAILED
		END
	ELSE
		BEGIN
			UPDATE SSOX_ExternalCredentials SET 
				ec_password_with_sync = @password_to_sync, 
				ec_pws_msid = @msid,
				ec_timestamp = @timestamp_in
			WHERE ec_xa = @xa AND ec_xu = @xu AND ec_timestamp < @timestamp_in

			IF @@ROWCOUNT = 0
				SET @RETURN_CODE = @ERROR_UPDATE_FAILED2
		END
		
	SET @audit_id = NEWID()
		
	EXEC ssox_spAuditCommon
		'SSOX_ExternalCredentials',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'WriteXPSync'	
		
	RETURN(@RETURN_CODE)	
	
END
GO


-- WriteXPNoSync - only update the no-sync field
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spWriteXpNoSync]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spWriteXpNoSync
GO

CREATE PROCEDURE dbo.ssox_spWriteXpNoSync
@xa nvarchar(260),
@xu nvarchar(256),
@password_to_sync image,
@msid uniqueidentifier,
@timestamp_in datetime,
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

	DECLARE @ERROR_UPDATE_FAILED int
	SET @ERROR_UPDATE_FAILED = 0x9901
	
	DECLARE @ERROR_UPDATE_FAILED2 int
	SET @ERROR_UPDATE_FAILED2 = 0x9904

	DECLARE @RETURN_CODE int
	SET @RETURN_CODE = 0

	-- does mapping already exist?
		
	DECLARE @audit_id uniqueidentifier
	SET @audit_id = (SELECT ec_audit_id FROM SSOX_ExternalCredentials WHERE ec_xa = @xa AND ec_xu = @xu)
	
	IF (@audit_id IS NULL)
		BEGIN
			SET @RETURN_CODE = @ERROR_UPDATE_FAILED
		END
	ELSE
		BEGIN

			UPDATE SSOX_ExternalCredentials SET 
				ec_password_no_sync = @password_to_sync, 
				ec_pns_msid = @msid,
				ec_timestamp = @timestamp_in
			WHERE ec_xa = @xa AND ec_xu = @xu AND ec_timestamp < @timestamp_in

			IF @@ROWCOUNT = 0
				SET @RETURN_CODE = @ERROR_UPDATE_FAILED2
		END
		
	SET @audit_id = NEWID()
		
	EXEC ssox_spAuditCommon
		'SSOX_ExternalCredentials',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'WriteXPNoSync'		
		
	RETURN(@RETURN_CODE)	

END
GO


-- DAMPING TABLE


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_DampingTable]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_DampingTable]
GO

CREATE TABLE [dbo].[SSOX_DampingTable] (

	[dt_adapter]					[nvarchar] (128) NOT NULL,
	[dt_account]					[nvarchar] (256) NOT NULL,
	[dt_hash]						[varbinary] (32) NOT NULL,
	[dt_timestamp]					[datetime] NOT NULL,
	[dt_hash1]						[uniqueidentifier] NOT NULL,
	[dt_hash2]						[uniqueidentifier] NOT NULL,

	CONSTRAINT dt_unique	unique(dt_adapter, dt_account),
)
GO

CREATE UNIQUE CLUSTERED INDEX dt_ci ON SSOX_DampingTable(dt_adapter, dt_account)
GO


-- RemoveOldEntries
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spRemoveOldEntries]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spRemoveOldEntries
GO

CREATE PROCEDURE dbo.ssox_spRemoveOldEntries
@timestamp_in datetime
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DELETE FROM SSOX_DampingTable WHERE dt_timestamp < @timestamp_in
	
END
GO


-- GetHash
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetHash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetHash
GO

CREATE PROCEDURE dbo.ssox_spGetHash
@adapter nvarchar(128),
@account nvarchar(256),
-- outputs
@hash_out varbinary(32) OUTPUT,
@hash1 uniqueidentifier OUTPUT,
@hash2 uniqueidentifier OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT @hash_out = dt_hash, @hash1 = dt_hash1, @hash2 = dt_hash2 FROM SSOX_DampingTable WHERE dt_adapter = @adapter AND dt_account = @account
	 
	RETURN(@@ROWCOUNT)

END
GO


-- SetHash
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spSetHash]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spSetHash
GO

CREATE PROCEDURE dbo.ssox_spSetHash
@adapter nvarchar(128),
@account nvarchar(256),
@hash varbinary(32),
@hash1 uniqueidentifier,
@hash2 uniqueidentifier
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @current_time datetime
	SET @current_time = getdate()

	UPDATE SSOX_DampingTable
	SET
		dt_hash = @hash,
		dt_hash1 = @hash1,
		dt_hash2 = @hash2,
		dt_timestamp = @current_time
		
	WHERE @adapter = dt_adapter AND dt_account = @account

	IF @@ROWCOUNT = 0
	BEGIN

		INSERT INTO SSOX_DampingTable VALUES (@adapter, @account, @hash, @current_time, @hash1, @hash2)
	
	END
		 
END
GO


-- StoreNtp2
-- this sp is like StoreNtp except it accounts for the timestamp
-- (will not overwrite more recent Windows password changes)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spStoreNtp2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spStoreNtp2
GO

-- this procedure implements ref counting between SSOX_WindowsPassword and SSOX_IndividualMapping

CREATE PROCEDURE dbo.ssox_spStoreNtp2
@ntd nvarchar(16),
@ntu nvarchar(256),
@password varbinary(4096),
@msid uniqueidentifier,
@timestamp_in datetime,
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

	DECLARE @ERROR_UPDATE_FAILED2 int
	SET @ERROR_UPDATE_FAILED2 = 0x9904
	
	-- audit info

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = (SELECT wp_audit_id FROM SSOX_WindowsPassword WHERE wp_ntd = @ntd AND wp_ntu = @ntu)
	
	IF @audit_id IS NULL
	
		BEGIN -- the password entry does not already exist
			
			SET @audit_id = NEWID()
			
			DECLARE @refcount int
			SET @refcount = (SELECT COUNT(*) FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu)

			IF (@refcount = 0)
				
				BEGIN -- no such mapping
				
					DECLARE @ERROR_NO_SUCH_MAPPING int
					SET @ERROR_NO_SUCH_MAPPING = 0x9901
					
					RETURN(@ERROR_NO_SUCH_MAPPING)
					
				END -- no such mapping
				
			-- existing mapping, insert new row, with correct refcount
	
			INSERT INTO SSOX_WindowsPassword			
			VALUES 
			(
				@ntd,
				@ntu,
				@password,
				@msid,
				@refcount,
				@audit_id,
				@timestamp_in
			)
			
			EXEC ssox_spAuditCommon
				'SSOX_WindowsPassword',
				0,
				@timestamp_in,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'StoreNtp2: create new password entry for existing mapping'
				
		END  -- the password entry does not already exist
		
	ELSE
		
		BEGIN -- update existing password entry
		
			UPDATE SSOX_WindowsPassword SET 
				wp_password = @password, 
				wp_msid = @msid, 
				wp_timestamp = @timestamp_in 
			WHERE wp_ntd = @ntd AND wp_ntu = @ntu AND wp_timestamp < @timestamp_in
	
			IF @@ROWCOUNT = 0
				RETURN(@ERROR_UPDATE_FAILED2)

			EXEC ssox_spAuditCommon
				'SSOX_WindowsPassword',
				1,
				@timestamp_in,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'StoreNtp2: change existing password entry'
				
		END -- updated existing password entry
END
GO


-- StoreXp2
-- this sp is like StoreXp2 except it accounts for the timestamp
-- (will not overwrite more recent external password changes)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spStoreXp2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spStoreXp2
GO

CREATE PROCEDURE dbo.ssox_spStoreXp2
@xa nvarchar(260),
@xu nvarchar(256),
@password_with_sync image,
@pws_msid uniqueidentifier,
@password_no_sync image,
@pns_msid uniqueidentifier,
@timestamp_in datetime,
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

	DECLARE @ERROR_UPDATE_FAILED2 int
	SET @ERROR_UPDATE_FAILED2 = 0x9904

	-- audit info
	
	DECLARE @audit_id uniqueidentifier
	SET @audit_id = (SELECT ec_audit_id FROM SSOX_ExternalCredentials WHERE ec_xa = @xa AND ec_xu = @xu)
	
	IF (@audit_id IS NULL)
		
		BEGIN -- the external credentials entry does not already exist
		
			SET @audit_id = NEWID()
			
			INSERT INTO SSOX_ExternalCredentials			
			VALUES 
			(
				@xa,
				@xu,
				@password_with_sync,
				@pws_msid,
				@password_no_sync,
				@pns_msid,
				@audit_id,
				@timestamp_in
			)
			
			EXEC ssox_spAuditCommon
				'SSOX_ExternalCredentials',
				0,
				@timestamp_in,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'StoreXp2: create new external credentials for existing mapping'
				
		END  -- the external credentials entry does not already exist
		
	ELSE
		
		BEGIN -- update existing external credentials entry
	
			UPDATE SSOX_ExternalCredentials SET 
				ec_password_with_sync = @password_with_sync, 
				ec_pws_msid = @pws_msid,
				ec_password_no_sync = @password_no_sync, 
				ec_pns_msid = @pns_msid,
				ec_timestamp = @timestamp_in
			WHERE ec_xa = @xa AND ec_xu = @xu AND ec_timestamp < @timestamp_in
	
			IF @@ROWCOUNT = 0
				RETURN(@ERROR_UPDATE_FAILED2)
				
			EXEC ssox_spAuditCommon
				'SSOX_ExternalCredentials',
				1,
				@timestamp_in,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'StoreXp2: change existing external credentials entry'
				
		END -- updated existing external credentials entry
END
GO


-- NotificationTableCount
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spNotificationTableCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spNotificationTableCount
GO

CREATE PROCEDURE dbo.ssox_spNotificationTableCount
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT COUNT(*) FROM SSOX_AdapterQueue
	
END
GO


-- DampingTableCount
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spDampingTableCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spDampingTableCount
GO

CREATE PROCEDURE dbo.ssox_spDampingTableCount
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT COUNT(*) FROM SSOX_DampingTable
	
END
GO


-- ClearNotificationQueueForAdapter
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spClearNotificationQueueForAdapter]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spClearNotificationQueueForAdapter
GO

CREATE PROCEDURE dbo.ssox_spClearNotificationQueueForAdapter
@adapter_name nvarchar(260)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DELETE FROM SSOX_AdapterQueue WHERE aq_adapter = @adapter_name

END
GO


-- ClearAllNotificationQueues
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spClearAllNotificationQueues]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spClearAllNotificationQueues
GO

CREATE PROCEDURE dbo.ssox_spClearAllNotificationQueues
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DELETE FROM SSOX_AdapterQueue

END
GO


-- DeleteUnusedWindowsPasswords
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spDeleteUnusedWindowsPasswords]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spDeleteUnusedWindowsPasswords
GO

CREATE PROCEDURE dbo.ssox_spDeleteUnusedWindowsPasswords
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DELETE FROM SSOX_WindowsPassword
	WHERE wp_ntd + wp_ntu NOT IN
	(SELECT im_ntd + im_ntu
	FROM SSOX_IndividualMapping
	JOIN SSOX_AppToAdapter
	ON (SSOX_IndividualMapping.im_xa = SSOX_AppToAdapter.aa_app_name))

END
GO


-- original ReadNextNtp in SSOX3.sql was broken - replacement here
-- read next ntp - return the next ntp encrypted with this secret id
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spReadNextNtp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spReadNextNtp
GO

CREATE PROCEDURE dbo.ssox_spReadNextNtp
@msid uniqueidentifier

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT TOP 1 * 
	FROM SSOX_WindowsPassword WHERE wp_msid = @msid

END
GO


-- FIX: bug # 86657: don't change timestamp during re-encryption
-- WriteNtp - moved from SSOX3.sql and modified
-- update the ntp with the reencrypted password only if it has not been changed
-- no refcounting
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spWriteNtp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spWriteNtp
GO

CREATE PROCEDURE dbo.ssox_spWriteNtp
@ntd nvarchar(16),
@ntu nvarchar(256),
@password varbinary(4096),
@msid uniqueidentifier,
@timestamp_in datetime,
@refcount_in int,
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

	DECLARE @ERROR_UPDATE_FAILED int
	SET @ERROR_UPDATE_FAILED = 0x9901
	
	-- NOTE: we must verify also that the refcount has not changed
	
	UPDATE SSOX_WindowsPassword SET 
		wp_password = @password, 
		wp_msid = @msid
	WHERE wp_ntd = @ntd AND wp_ntu = @ntu AND wp_timestamp = @timestamp_in AND wp_refcount = @refcount_in

	IF @@ROWCOUNT = 0
		RETURN(@ERROR_UPDATE_FAILED)
		
	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()

	EXEC ssox_spAuditCommon
		'SSOX_WindowsPassword',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'WriteNtp (V2)'			
END
GO


-- FIX: bug # 86657: don't change timestamp during re-encryption
-- WriteXp - moved from SSOX3.sql and modified
-- update the xp with the reencrypted xp only if it has not been changed
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spWriteXp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spWriteXp
GO

CREATE PROCEDURE dbo.ssox_spWriteXp
@xa nvarchar(260),
@xu nvarchar(256),
@password_with_sync image,
@pws_msid uniqueidentifier,
@password_no_sync image,
@pns_msid uniqueidentifier,
@timestamp_in datetime,
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

	DECLARE @ERROR_UPDATE_FAILED int
	SET @ERROR_UPDATE_FAILED = 0x9901
	
	UPDATE SSOX_ExternalCredentials SET 
		ec_password_with_sync = @password_with_sync, 
		ec_pws_msid = @pws_msid,
		ec_password_no_sync = @password_no_sync, 
		ec_pns_msid = @pns_msid
	WHERE ec_xa = @xa AND ec_xu = @xu AND ec_timestamp = @timestamp_in

	IF @@ROWCOUNT = 0
		RETURN(@ERROR_UPDATE_FAILED)

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()
		
	EXEC ssox_spAuditCommon
		'SSOX_ExternalCredentials',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'WriteXp (V2)'		
END
GO


-- FIX: bug # 87758: DeleteNtp to prevent account lockout
-- DeleteNtp
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spDeleteNtp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spDeleteNtp
GO

CREATE PROCEDURE dbo.ssox_spDeleteNtp
@ntd nvarchar(16),
@ntu nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	DECLARE @retval int
	
	DELETE FROM SSOX_WindowsPassword
	WHERE @ntd = wp_ntd AND @ntu = wp_ntu
	 
	SET @retval = @@ROWCOUNT
	
	RETURN(@retval)
END
GO

-- FIX: V3 - moved GetDBVersion and IsDBCompatible to SSOX5.sql

