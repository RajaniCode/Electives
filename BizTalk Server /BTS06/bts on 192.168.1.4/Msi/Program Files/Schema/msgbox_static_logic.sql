--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/   
------------------------------------------------------------------------------
-- static state info: insert and get
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_GetStaticStateInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_GetStaticStateInfo]
GO

-- Insert/Retrieve static service and tracking info
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_InsertStaticStateInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_InsertStaticStateInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_DeleteStaticInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_DeleteStaticStateInfo]
GO



CREATE PROCEDURE [dbo].[bts_InsertStaticStateInfo]
@uidServiceID uniqueidentifier,
@imgData image,
@imgSymbol image

AS

set transaction isolation level read committed
set nocount on

UPDATE	StaticStateInfo
SET		dtTimeStamp = GetUTCDate(),
		imgData = @imgData,
		imgSymbol = @imgSymbol
WHERE uidServiceID = @uidServiceID

IF (@@ROWCOUNT = 0)
BEGIN
	INSERT INTO StaticStateInfo (
			uidServiceID,
			dtTimeStamp,
			imgData,
			imgSymbol)
		VALUES (
			@uidServiceID,
			GetUTCDate(),
			@imgData,
			@imgSymbol
			)
END
GO
GRANT EXEC ON [dbo].[bts_InsertStaticStateInfo] TO BTS_HOST_USERS
GO


CREATE PROCEDURE [dbo].[bts_GetStaticStateInfo]
@uidServiceID uniqueidentifier

AS

set transaction isolation level read committed
set nocount on

SELECT dtTimeStamp, imgData, imgSymbol
FROM StaticStateInfo d
WHERE d.uidServiceID = @uidServiceID 
ORDER BY dtTimeStamp DESC

GO
GRANT EXEC ON [dbo].[bts_GetStaticStateInfo] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[bts_DeleteStaticStateInfo]
@uidServiceID uniqueidentifier
AS

set transaction isolation level read committed
set nocount on

DELETE FROM StaticStateInfo WHERE uidServiceID = @uidServiceID
GO
GRANT EXEC ON [dbo].[bts_DeleteStaticStateInfo] TO BTS_ADMIN_USERS
GO
