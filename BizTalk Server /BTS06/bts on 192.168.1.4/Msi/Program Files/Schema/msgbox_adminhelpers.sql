--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 
 
------------------------------------------------------------------------------
if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_GetTrackedDataCount]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_GetTrackedDataCount]

GO

--=======================================================================
-- Stored procedure for Admin to check msgbox removal constraint
--=======================================================================

CREATE PROCEDURE [dbo].[adm_GetTrackedDataCount]
AS
	set nocount on
	select count(*) from TrackingData
GO
GRANT EXEC ON [dbo].[adm_GetTrackedDataCount] TO BTS_ADMIN_USERS
GO


--/==================================/--
--/===== Security related setup =====/--
--/==================================/--

-- Make BTS_ADMIN_USERS a member of BTS_HOST_USERS in MsgboxDb
EXEC sp_addrolemember BTS_HOST_USERS, BTS_ADMIN_USERS
GO
