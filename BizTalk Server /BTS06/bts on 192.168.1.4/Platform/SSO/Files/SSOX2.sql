-- SSOX2.sql
----- Schema definition for Enterprise SSO
----- Copyright(c) Microsoft Corporation. All rights reserved.


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_WindowsPassword]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_WindowsPassword]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_ExternalCredentials]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_ExternalCredentials]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SSOX_IndividualMapping]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SSOX_IndividualMapping]
GO

-- individual mapping table

CREATE TABLE [dbo].[SSOX_IndividualMapping] (

	[im_ntd]				[nvarchar] (16) NOT NULL,
	[im_ntu]				[nvarchar] (256) NOT NULL,
	[im_xa]					[nvarchar] (260) NOT NULL,
	[im_xu]					[nvarchar] (256) NOT NULL,
	[im_flags]				[int] NOT NULL,
	[im_enabled]			[bit] NOT NULL,
	[im_audit_enabled]		[bit] NOT NULL,
	[im_audit_id]			[uniqueidentifier] NOT NULL,
	
	CONSTRAINT individual_mapping_unique		unique(im_xa, im_xu),
	CONSTRAINT individual_mapping_unique2		unique(im_audit_id),
	CONSTRAINT individual_mapping_fk			foreign key(im_xa) references [dbo].[SSOX_ApplicationInfo](ai_app_name) on delete cascade,
)
GO

CREATE UNIQUE CLUSTERED INDEX individual_mapping_ci ON SSOX_IndividualMapping(im_ntd, im_ntu, im_xa)
GO

CREATE TRIGGER trigger_im_delete ON SSOX_IndividualMapping FOR DELETE AS
BEGIN

	-- cleanup audit info
	
	DELETE FROM SSOX_AuditTable WHERE at_audit_id IN (SELECT im_audit_id FROM deleted)
	
	-- reference counting
	
	/*****
	
	-- FIX: bug # 22915
	
	DECLARE @ntd nvarchar(16)
	SET @ntd = (SELECT im_ntd FROM deleted)

	DECLARE @ntu nvarchar(256)
	SET @ntu = (SELECT im_ntu FROM deleted)

	UPDATE SSOX_WindowsPassword SET wp_refcount = wp_refcount - 1 WHERE wp_ntd = @ntd AND wp_ntu = @ntu
		
	DELETE FROM SSOX_WindowsPassword WHERE wp_refcount = 0
	*****/
END
GO

CREATE TRIGGER trigger_im_insert ON SSOX_IndividualMapping FOR INSERT AS
BEGIN

	-- reference counting
	
	DECLARE @ntd nvarchar(16)
	SET @ntd = (SELECT im_ntd FROM inserted)

	DECLARE @ntu nvarchar(256)
	SET @ntu = (SELECT im_ntu FROM inserted)

	UPDATE SSOX_WindowsPassword SET wp_refcount = wp_refcount + 1 WHERE wp_ntd = @ntd AND wp_ntu = @ntu
		
END
GO

-- external credentials table

-- [ec_pws_msid] and [ec_pns_msid] are the master secret ids used to encrypt the fields

create table [dbo].[SSOX_ExternalCredentials] (

	[ec_xa]						[nvarchar] (260) NOT NULL,
	[ec_xu]						[nvarchar] (256) NOT NULL,
	[ec_password_with_sync]		[image] NOT NULL,
	[ec_pws_msid]				[uniqueidentifier] NOT NULL,
	[ec_password_no_sync]		[image] NOT NULL,
	[ec_pns_msid]				[uniqueidentifier] NOT NULL,
	[ec_audit_id]				[uniqueidentifier] NOT NULL,
	[ec_timestamp]				[datetime] NOT NULL,

	CONSTRAINT external_credentials_fk2			foreign key(ec_xa, ec_xu) references [dbo].[SSOX_IndividualMapping](im_xa, im_xu) on delete cascade,
	CONSTRAINT external_credentials_unique		unique(ec_audit_id),
)
GO

CREATE UNIQUE CLUSTERED INDEX external_credentials_ci ON SSOX_ExternalCredentials(ec_xa, ec_xu)
GO

CREATE TRIGGER trigger_ec_audit ON SSOX_ExternalCredentials FOR DELETE AS
BEGIN
	DELETE FROM SSOX_AuditTable WHERE at_audit_id IN (SELECT ec_audit_id FROM deleted)
END
GO

-- windows password table


CREATE TABLE [dbo].[SSOX_WindowsPassword] (

	[wp_ntd]				[nvarchar] (16) NOT NULL,
	[wp_ntu]				[nvarchar] (256) NOT NULL,
	[wp_password]			[varbinary] (4096) NOT NULL,
	[wp_msid]				[uniqueidentifier] NOT NULL,
	[wp_refcount]			[int] NOT NULL,
	[wp_audit_id]			[uniqueidentifier] NOT NULL,
	[wp_timestamp]			[datetime] NOT NULL,

	CONSTRAINT windows_password_unique		unique(wp_audit_id),
)
GO

CREATE UNIQUE CLUSTERED INDEX windows_password_ci ON SSOX_WindowsPassword(wp_ntd, wp_ntu)
GO

CREATE TRIGGER trigger_wp_audit ON SSOX_WindowsPassword FOR DELETE AS
BEGIN
	DELETE FROM SSOX_AuditTable WHERE at_audit_id IN (SELECT wp_audit_id FROM deleted)
END
GO

-- stored procedures

-- StoreNtp: CODEWORK: remove this sp - not used in either V1 or V2?
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spStoreNtp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spStoreNtp
GO

-- this procedure implements ref counting between SSOX_WindowsPassword and SSOX_IndividualMapping

CREATE PROCEDURE dbo.ssox_spStoreNtp
@ntd nvarchar(16),
@ntu nvarchar(256),
@password varbinary(4096),
@msid uniqueidentifier,
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
				@current_time
			)
			
			EXEC ssox_spAuditCommon
				'SSOX_WindowsPassword',
				0,
				@current_time,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'create new password entry for existing mapping'
				
		END  -- the password entry does not already exist
		
	ELSE
		
		BEGIN -- update existing password entry
		
			UPDATE SSOX_WindowsPassword SET 
				wp_password = @password, 
				wp_msid = @msid, 
				wp_timestamp = @current_time 
			WHERE wp_ntd = @ntd AND wp_ntu = @ntu
	
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
				'change existing password entry'
				
		END -- updated existing password entry
END
GO


-- set external credentials


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spStoreXp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spStoreXp
GO

CREATE PROCEDURE dbo.ssox_spStoreXp
@xa nvarchar(260),
@xu nvarchar(256),
@password_with_sync image,
@pws_msid uniqueidentifier,
@password_no_sync image,
@pns_msid uniqueidentifier,
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
				@current_time
			)
			
			EXEC ssox_spAuditCommon
				'SSOX_ExternalCredentials',
				0,
				@current_time,
				@audit_id,
				@client_user, 
				@client_machine, 
				@tracking_id, 
				@server_user, 
				@server_machine,
				'create new external credentials for existing mapping'
				
		END  -- the external credentials entry does not already exist
		
	ELSE
		
		BEGIN -- update existing external credentials entry
	
			UPDATE SSOX_ExternalCredentials SET 
				ec_password_with_sync = @password_with_sync, 
				ec_pws_msid = @pws_msid,
				ec_password_no_sync = @password_no_sync, 
				ec_pns_msid = @pns_msid,
				ec_timestamp = @current_time
			WHERE ec_xa = @xa AND ec_xu = @xu
	
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
				'change existing external credentials entry'
				
		END -- updated existing external credentials entry
END
GO


-- individual mapping create


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIndividualMappingCreate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIndividualMappingCreate
GO

CREATE PROCEDURE dbo.ssox_spIndividualMappingCreate
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@xu nvarchar(256),
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

	-- audit info

	DECLARE @current_time datetime
	SET @current_time = getdate()

	DECLARE @audit_id uniqueidentifier 
	SET @audit_id = NEWID()

	-- create as disabled

	INSERT INTO SSOX_IndividualMapping
	VALUES 
	(
		@ntd, 
		@ntu, 
		@xa, 
		@xu, 
		@flags,
		0,
		0,
		@audit_id
	)
	
	EXEC ssox_spAuditCommon
		'SSOX_IndividualMapping',
		0,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'create new individual mapping'
END
GO


-- individual mapping change (from NT)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIndividualMappingChangeNT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIndividualMappingChangeNT
GO

CREATE PROCEDURE dbo.ssox_spIndividualMappingChangeNT
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@flags int,
@enabled bit,
@audit_enabled bit,
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
	SET @audit_id = (SELECT im_audit_id FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa)

	IF @audit_id IS NULL
	BEGIN -- no such mapping
				
		DECLARE @ERROR_NO_SUCH_MAPPING int
		SET @ERROR_NO_SUCH_MAPPING = 0x9901
		
		RETURN(@ERROR_NO_SUCH_MAPPING)
					
	END -- no such mapping
				
	UPDATE SSOX_IndividualMapping
	SET 
		im_flags = @flags,
		im_enabled = @enabled,
		im_audit_enabled = @audit_enabled
	WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa
	
	EXEC ssox_spAuditCommon
		'SSOX_IndividualMapping',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'change individual mapping (from NT)'
		
	IF @enabled = 0
	BEGIN
	
		-- treat a disable as a delete so the cred cache can find it

		DECLARE @xu nvarchar(256)
		SET @xu = '<unknown - disabled>'
		
		EXEC ssox_spAuditMappingDelete
			@ntd,
			@ntu,
			@xa,
			@xu,
			@client_user,
			@client_machine,
			@tracking_id,
			@server_user,
			@server_machine
		
	END
END
GO


-- individual mapping change (from X)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIndividualMappingChangeX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIndividualMappingChangeX
GO

CREATE PROCEDURE dbo.ssox_spIndividualMappingChangeX
@xa nvarchar(260),
@xu nvarchar(256),
@flags int,
@enabled bit,
@audit_enabled bit,
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
	SET @audit_id = (SELECT im_audit_id FROM SSOX_IndividualMapping WHERE im_xa = @xa AND im_xu = @xu)

	UPDATE SSOX_IndividualMapping
	SET 
		im_flags = @flags,
		im_enabled = @enabled,
		im_audit_enabled = @audit_enabled
	WHERE im_xa = @xa AND im_xu = @xu
	
	EXEC ssox_spAuditCommon
		'SSOX_IndividualMapping',
		1,
		@current_time,
		@audit_id,
		@client_user, 
		@client_machine, 
		@tracking_id, 
		@server_user, 
		@server_machine,
		'change individual mapping (from X)'
END
GO


-- individual mapping delete (from NT)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIndividualMappingDeleteNT]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIndividualMappingDeleteNT
GO

CREATE PROCEDURE dbo.ssox_spIndividualMappingDeleteNT
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
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

	DECLARE @xu nvarchar(256)
	SET @xu = (SELECT im_xu FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa)

	DELETE FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa

	-- auditing	

	EXEC ssox_spAuditMappingDelete
		@ntd,
		@ntu,
		@xa,
		@xu,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
END
GO


-- individual mapping delete (from X)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spIndividualMappingDeleteX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spIndividualMappingDeleteX
GO

CREATE PROCEDURE dbo.ssox_spIndividualMappingDeleteX
@xa nvarchar(260),
@xu nvarchar(256),
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

	DECLARE @ntd nvarchar(16)
	SET @ntd = (SELECT im_ntd FROM SSOX_IndividualMapping WHERE im_xa = @xa AND im_xu = @xu)

	DECLARE @ntu nvarchar(256)
	SET @ntu = (SELECT im_ntu FROM SSOX_IndividualMapping WHERE im_xa = @xa AND im_xu = @xu)

	DELETE FROM SSOX_IndividualMapping WHERE im_xa = @xa AND im_xu = @xu
	
	-- auditing
		
	EXEC ssox_spAuditMappingDelete
		@ntd,
		@ntu,
		@xa,
		@xu,
		@client_user,
		@client_machine,
		@tracking_id,
		@server_user,
		@server_machine
	
END
GO


-- get mappings (NT2)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetMappingsNT2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetMappingsNT2
GO

CREATE PROCEDURE dbo.ssox_spGetMappingsNT2
@ntd nvarchar(16),
@ntu nvarchar(256)

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	SELECT * FROM SSOX_IndividualMapping WHERE  im_ntd = @ntd AND im_ntu = @ntu
END
GO


-- get mappings (NT3)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetMappingsNT3]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetMappingsNT3
GO

CREATE PROCEDURE dbo.ssox_spGetMappingsNT3
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa  nvarchar(260)

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	SELECT * FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa
END
GO


-- get mappings (X)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetMappingsX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetMappingsX
GO

CREATE PROCEDURE dbo.ssox_spGetMappingsX
@xa nvarchar(260),
@xu nvarchar(256)

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	SELECT * FROM SSOX_IndividualMapping WHERE im_xa = @xa AND im_xu = @xu
END
GO


-- get mappings (X2)


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spGetMappingsX2]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spGetMappingsX2
GO

CREATE PROCEDURE dbo.ssox_spGetMappingsX2
@xa nvarchar(260)

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN
	SELECT * FROM SSOX_IndividualMapping WHERE im_xa = @xa
END
GO


-- xp lookup


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spLookupXp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spLookupXp
GO

CREATE PROCEDURE dbo.ssox_spLookupXp
@ntd nvarchar(16),
@ntu nvarchar(256),
@xa nvarchar(260),
@read_modify_write bit,
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

	IF @read_modify_write = 1
		-- lower the transaction isolation level from serializable to repeatable read
		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	ELSE
		-- lower the transaction isolation level from serializable to read committed
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	
	DECLARE @enabled bit
	DECLARE @audit_enabled bit
	DECLARE @xu nvarchar(256)
	DECLARE @flags int
	
	SELECT 
		@xu = im_xu, 
		@flags = im_flags, 
		@enabled = im_enabled, 
		@audit_enabled = im_audit_enabled 
	FROM SSOX_IndividualMapping WHERE im_ntd = @ntd AND im_ntu = @ntu AND im_xa = @xa
		
	-- auditing
	
	if @audit_enabled = 1
	BEGIN		
		EXEC ssox_spAuditXpLookup
			@ntd,
			@ntu,
			@xa,
			@xu,
			@client_user,
			@client_machine,
			@tracking_id,
			@server_user,
			@server_machine
	END

	IF @read_modify_write = 1
		-- lower the transaction isolation level from serializable to repeatable read
		SET TRANSACTION ISOLATION LEVEL REPEATABLE READ
	ELSE
		-- lower the transaction isolation level from serializable to read committed
		SET TRANSACTION ISOLATION LEVEL READ COMMITTED
		
	SELECT @enabled, @flags, *
	FROM SSOX_ExternalCredentials WHERE ec_xa = @xa AND ec_xu = @xu
			
	-- set back to the default
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	
END
GO


-- initial values for the global info table

			
-- so we can run this script again
DELETE FROM SSOX_AuditTable
GO

DELETE FROM SSOX_GlobalInfo
GO


DECLARE @currentTime datetime
SET @currentTime = getdate()

DECLARE @audit_id uniqueidentifier
SET @audit_id = NEWID()

INSERT INTO SSOX_GlobalInfo
VALUES
(
	@currentTime,
	@currentTime,
	64,
	1000,
	1000,
	1000,
	1000,
	2,
	60,
	'-----',
	'-----',
	'-----',
	@audit_id
)

-- audit log entry for the above

EXEC ssox_spAuditCommon
	'SSOX_GlobalInfo',
	0,
	@currentTime,
	@audit_id,
	'client user',
	'client machine', 
	@audit_id, 
	'server user', 
	'server machine',
	'create global info'
GO
		