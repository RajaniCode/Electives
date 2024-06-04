--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Enum_Type]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Enum_Type]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Enum_App_Id]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Enum_App_Id]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Enum_App_Name]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Enum_App_Name]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Enum_App_NameAndType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Enum_App_NameAndType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Load]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Load_App]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Load_App]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_assembly_load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_assembly_load]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Property_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Property_Update]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Delete]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Sat_Move]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Sat_Move]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adpl_Application_Load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adpl_Application_Load]
GO

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

------------------------------------ SAT support ------------------------------------------ 
-- Enumerate modules
CREATE PROCEDURE [dbo].[adpl_Sat_Enum]
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            [sdmType],
            [luid],
            [properties],
            [files],
            [cabContent] 
	FROM [adpl_sat]
	ORDER BY
	    [sdmType], [luid]
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adpl_Sat_Enum_Type]
(
	@ResourceType as [nvarchar] (256)
)
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            [sdmType],
            [luid],
            [properties],
            [files],
            [cabContent] 
	FROM [adpl_sat] sat
	WHERE 
	     [sdmType] = @ResourceType
	ORDER BY
	     [luid]
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Enum_Type] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adpl_Sat_Enum_App_Id]
(
	@ApplicationId as int
)
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            [sdmType],
            [luid],
            [properties],
            [files],
            [cabContent] 
	FROM [adpl_sat]
	WHERE 
	     [applicationId] = @ApplicationId
	ORDER BY
	    [sdmType], [luid]
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Enum_App_Id] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adpl_Sat_Enum_App_Name]
(
	@ApplicationName as [nvarchar] (256)
)
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            [sdmType],
            [luid],
            [properties],
            [files],
            [cabContent] 
	FROM [adpl_sat] sat
	JOIN [bts_application] bta ON sat.applicationId = bta.nID
	WHERE 
	     bta.nvcName = @ApplicationName
	ORDER BY
	    [sdmType], [luid]
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Enum_App_Name] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adpl_Sat_Enum_App_NameAndType]
(
	@ApplicationName as [nvarchar] (256),
	@ResourceType as [nvarchar] (256)
)
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            [sdmType],
            [luid],
            [properties],
            [files],
            [cabContent] 
	FROM [adpl_sat] sat
	JOIN [bts_application] bta ON sat.applicationId = bta.nID
	WHERE 
	     bta.nvcName = @ApplicationName AND [sdmType] = @ResourceType
	ORDER BY
	     [luid]
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Enum_App_NameAndType] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Saves specified module into adpl_sat table.
CREATE PROCEDURE [dbo].[adpl_Sat_Save]
(
	@ApplicationId [int] ,
	@SdmType [nvarchar] (256) ,
	@Luid [nvarchar] (440) ,
	@Properties [ntext],
	@Files [ntext],
	@CabContent [image] = NULL,
	@Update [Bit],
	@UpdateCab [Bit]
)
--WITH ENCRYPTION
AS
SET NOCOUNT ON
DECLARE @ErrCode AS int

DECLARE @IsSystem int
EXEC @IsSystem = dpl_IsSystemAssembly @Name = @Luid

DECLARE @AppId int 
SELECT @AppId = @ApplicationId 

IF ( @IsSystem = 1 )
BEGIN
	SELECT @AppId = nID 
		FROM bts_application
		WHERE isSystem = 1
END


IF (NOT EXISTS(select * from adpl_sat where [luid] = @Luid) OR (@Update = 0))
	BEGIN
		INSERT INTO adpl_sat
		(
		    [applicationId] ,
		    [sdmType],
		    [luid] ,
		    [properties],
		    [files]
		)
		VALUES
		(
		    @AppId,
		    @SdmType,
		    @Luid,
		    @Properties,
		    @Files
		)
	END
ELSE
	BEGIN
		UPDATE adpl_sat
		SET
			[properties] = @Properties,
			[files] = @Files
		WHERE	([luid]  = @Luid)
			AND	([applicationId] = @AppId) 
			AND	([sdmType]  = @SdmType)
	END
	SET @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
	
IF( @UpdateCab = 1 )
BEGIN
-- Now we're sure the row is already in the table, it was inserted or updated above
	UPDATE adpl_sat
		SET
			[cabContent] = @CabContent
		WHERE	([luid]  = @Luid)
			AND	([applicationId] = @AppId) 
			AND	([sdmType]  = @SdmType)
END
	
RETURN @ErrCode

SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Sat_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[adpl_Sat_Property_Update]
(
      @Luid [nvarchar] (440) ,
      @Properties [ntext]
)
--WITH ENCRYPTION
AS
SET NOCOUNT ON
declare @ErrCode as int

UPDATE adpl_sat
SET [properties] = @Properties
WHERE ([luid]  = @Luid)

set @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
return @ErrCode

SET NOCOUNT OFF
GO

GRANT EXEC ON [dbo].[adpl_Sat_Property_Update] TO BTS_ADMIN_USERS
GO


-- Loads resource with given luid and type
CREATE PROCEDURE [dbo].[adpl_Sat_Load_App]
(
	@Luid [nvarchar] (440),
	@AppId as int
)
--WITH ENCRYPTION
AS
set nocount on
SELECT
	    [applicationId] ,
	    [luid],
	    [properties],
	    [files],
	    [cabContent],
	    [sdmType] 
FROM [adpl_sat] 
WHERE
	([luid]  = @Luid) AND
	([applicationId]  = @AppId)

set nocount off
GO
GRANT EXEC ON [dbo].[adpl_Sat_Load_App] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

-- Loads resource with given luid from bts assembly
CREATE PROCEDURE [dbo].[bts_assembly_load]
(
	@NvcFullName [nvarchar] (256)
)
--WITH ENCRYPTION
AS
set nocount on
SELECT
	    [nvcFullName] ,
	    [nSystemAssembly]
FROM [bts_assembly] 
WHERE
	([nvcFullName]  = @NvcFullName)

set nocount off
GO
GRANT EXEC ON [dbo].[bts_assembly_load] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Loads resource with given luid and type
CREATE PROCEDURE [dbo].[adpl_Sat_Load]
(
	@Luid [nvarchar] (440) 
)
--WITH ENCRYPTION
AS
set nocount on
SELECT
	    [applicationId] ,
	    [luid] ,
	    [properties],
	    [files],
	    [cabContent],
	    [sdmType] 
FROM [adpl_sat] 
WHERE
	([luid]  = @Luid)

set nocount off
GO
GRANT EXEC ON [dbo].[adpl_Sat_Load] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Loads resource with given luid
CREATE PROCEDURE [dbo].[adpl_Sat_Delete]
(
	@SdmType [nvarchar] (256),
	@Luid [nvarchar] (440) 
)
--WITH ENCRYPTION
AS
set nocount on
DELETE
	[adpl_sat] 
WHERE
	([sdmType]  = @SdmType) AND
	([luid]  = @Luid)

set nocount off
GO
GRANT EXEC ON [dbo].[adpl_Sat_Delete] TO BTS_ADMIN_USERS
GO

-- Moves resource to a new application
CREATE PROCEDURE [dbo].[adpl_Sat_Move]
(
	@Luid [nvarchar] (440),
	@SdmType [nvarchar] (256),
	@AppId [int],
	@NewLuid [nvarchar] (256)	 
)
--WITH ENCRYPTION
AS
set nocount on
UPDATE adpl_sat
SET
	[applicationId] = @AppId,
	[luid] = @NewLuid
WHERE	
	([sdmType]  = @SdmType) AND
	([luid]  = @Luid)

set nocount off
GO
GRANT EXEC ON [dbo].[adpl_Sat_Move] TO BTS_ADMIN_USERS
GO

------------------------------------ SAT support ------------------------------------------ 

------------------------------------ Application support ------------------------------------------ 
-- Enumerate modules
CREATE PROCEDURE [dbo].[adpl_Application_Load]
(
	@Name AS nvarchar(512),
	@Id AS int OUTPUT,
	@IsDefault AS int OUTPUT,
	@IsSystem AS int OUTPUT,
	@Description as nvarchar(1024) OUTPUT,
	@DateModified as datetime OUTPUT
)
-- WITH ENCRYPTION
AS
SET NOCOUNT ON
SELECT
            @Id = [nID],
            @IsDefault = [isDefault],
            @IsSystem = [isSystem],
            @Description = [nvcDescription],
            @DateModified = [DateModified] 
	FROM [bts_application]
	WHERE 
	     [nvcName] = @Name
	     
SET NOCOUNT OFF
GO
GRANT EXEC ON [dbo].[adpl_Application_Load] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

------------------------------------ Application support ------------------------------------------ 
