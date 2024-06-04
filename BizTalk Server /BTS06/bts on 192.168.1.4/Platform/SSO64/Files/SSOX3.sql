-- SSOX3.sql
----- Schema definition for Enterprise SSO
----- Copyright(c) Microsoft Corporation. All rights reserved.

-- FIX: PF bug # 17907 moved BizTalk backup code to SSOX5.sql for correct upgrade

-- procedures used by the secret server for reencrypting the database


-- stored procedures

-- FIX: bug # 86657: ssox_spWriteNtp moved to SSOX4.sql
-- FIX: bug # 86657: ssox_spWriteXp moved to SSOX4.sql
-- FIX: ssox_spReadNextNtp moved to SSOX4.sql

-- ReadNextXp
-- read next xp - return the next xp encrypted with this secret id
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ssox_spReadNextXp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].ssox_spReadNextXp
GO

CREATE PROCEDURE dbo.ssox_spReadNextXp
@msid uniqueidentifier

AS
SET NOCOUNT ON
SET XACT_ABORT OFF

BEGIN

	SELECT TOP 1 * 
	FROM SSOX_ExternalCredentials WHERE ec_pws_msid = @msid OR ec_pns_msid = @msid

END
GO
