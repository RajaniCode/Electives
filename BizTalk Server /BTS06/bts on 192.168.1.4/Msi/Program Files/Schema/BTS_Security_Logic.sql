--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 


--/============================================================/--
--/===== Create predefined SQL Roles for BizTalk database =====/--
--/============================================================/--

-- BTS_ADMIN_USERS role is to provide privileges for BizTalk Admin users to access BizTalk databases
-- from tools such as BizTalk Admin MMC, BizTalk Explorer, and BizTalk Deployment
if not exists (select * from sysusers where name = N'BTS_ADMIN_USERS' and issqlrole = 1)
	EXEC sp_addrole N'BTS_ADMIN_USERS'
	
-- BTS_HOST_USERS role is to provide privileges for BizTalk runtime service accounts to access the
-- BizTalk databases
if not exists (select * from sysusers where name = N'BTS_HOST_USERS' and issqlrole = 1)
	EXEC sp_addrole N'BTS_HOST_USERS'
GO	

-- BTS_OPERATORS role is to provide privileges for BizTalk Operator accounts to manage the BizTalk 
-- server, such as start/stop/enlist/unenlist services.
if not exists (select * from sysusers where name = N'BTS_OPERATORS' and issqlrole = 1)
	EXEC sp_addrole N'BTS_OPERATORS'
GO 


--/============================================================/--
--/===== Deleting existing stored procedure ded =====/--
--/============================================================/--

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_IsMemberOfRole]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_IsMemberOfRole]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_RemoveRole]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_RemoveRole]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_HasPermissionToPerform]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[adm_HasPermissionToPerform]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_FormatNTGroupName]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[adm_FormatNTGroupName]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_ChangeRolePrivForUser]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_ChangeRolePrivForUser]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_AddDbUserToRole]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_AddDbUserToRole]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_DropDbUserFromRole]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_DropDbUserFromRole]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_AddLoginUser]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_AddLoginUser]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_RemoveLoginUser]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_RemoveLoginUser]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_CreateBTSAdminLogin]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_CreateBTSAdminLogin]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_CreateBTSHostLogin]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_CreateBTSHostLogin]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_CreateBTSOperatorLogin]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_CreateBTSOperatorLogin]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_RemoveBTSHostLogin]') and objectproperty(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_RemoveBTSHostLogin]

GO

--/============================================================/--
--/===== Create predefined SQL Roles for BizTalk database =====/--
--/============================================================/--

-- This cannot be written as a stored function as it accesses temp table (see SQL documentation)
CREATE PROCEDURE [dbo].[adm_IsMemberOfRole]
@UserName sysname,
@RoleName sysname,
@IsMember int output
AS
BEGIN

	set @UserName = dbo.adm_FormatNTGroupName(@UserName)

	declare @RoleExist int
	select @RoleExist = count(*) from sysusers where UPPER(name) = UPPER(@RoleName)

	if ( @RoleExist = 0 )
	begin
		set @IsMember = 0
	end
	else
	begin
		create table #RoleMemberInfo
		(
			DbRole sysname,
			MemberName sysname,
			MemberSID varbinary(85)
		)

		insert into #RoleMemberInfo
		exec dbo.sp_helprolemember @RoleName

		select @IsMember = count(*)
		from #RoleMemberInfo
		where UPPER(MemberName) = UPPER(@UserName)

		drop table #RoleMemberInfo
	end
END
GO
GRANT EXEC ON [dbo].[adm_IsMemberOfRole] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_RemoveRole]
@RoleName sysname
AS
BEGIN

	declare @RoleExist int
	select @RoleExist = count(*) from sysusers where UPPER(name) = UPPER(@RoleName)

	if ( @RoleExist = 1 )
	begin

		-- If the user don't have sufficient permission, then throw an error and return immediately
		if ( dbo.adm_HasPermissionToPerform('DbRoleTasks') = 0 )
			return 0xC0C025D3 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_INSUFFICIENT_PRIV

		create table #RoleMemberInfo
		(
			DbRole sysname,
			MemberName sysname,
			MemberSID varbinary(85)
		)

		insert into #RoleMemberInfo
		exec dbo.sp_helprolemember @RoleName

		-- Go through each role member and drop it from the role
		declare RoleMemberCursor cursor FOR
			SELECT MemberName
			FROM #RoleMemberInfo 
			
		declare @MemberName sysname

		open RoleMemberCursor
		FETCH NEXT FROM RoleMemberCursor INTO @MemberName
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			exec dbo.sp_droprolemember @RoleName, @MemberName

			FETCH NEXT FROM RoleMemberCursor INTO @MemberName
		END

		close RoleMemberCursor
		deallocate RoleMemberCursor
		
		drop table #RoleMemberInfo
		
		-- finally, drop the role itself
		exec dbo.sp_droprole @RoleName

	end
END
GO
GRANT EXEC ON [dbo].[adm_RemoveRole] TO BTS_ADMIN_USERS
GO


CREATE FUNCTION [dbo].[adm_FormatNTGroupName](@login sysname)
RETURNS sysname
AS
BEGIN
	-- If there is no '\' separator, assume this is a local NT group and expand it to '<machine name>\<local NT group>' format
	if ( charindex(N'\', @login) = 0 )
	begin
		set @login = convert(sysname, SERVERPROPERTY('MachineName')) + N'\' + @login
	end
	return @login
END
GO
GRANT EXEC ON [dbo].[adm_FormatNTGroupName] TO BTS_ADMIN_USERS
GO


CREATE FUNCTION [dbo].[adm_HasPermissionToPerform](@Tasks nvarchar(128))
RETURNS int
AS
BEGIN
	declare @rc as int
	set @rc = 0
	
	if ( @Tasks = N'LoginTasks' )
	begin
		if ( IS_SRVROLEMEMBER ('sysadmin') = 1 OR
			 IS_SRVROLEMEMBER ('securityadmin') = 1 )
		begin
			set @rc = 1
		end
	end
	else
	if ( @Tasks = N'DbAccessTasks' )
	begin
		if ( IS_SRVROLEMEMBER ('sysadmin') = 1 OR
			 IS_MEMBER ('db_owner') = 1 OR
			 IS_MEMBER ('db_accessadmin') = 1 )
		begin
			set @rc = 1
		end
	end
	else
	if ( @Tasks = N'DbRoleTasks' )
	begin
		if ( IS_SRVROLEMEMBER ('sysadmin') = 1 OR
			 IS_MEMBER ('db_owner') = 1 OR
			 IS_MEMBER ('db_securityadmin') = 1 )
		begin
			set @rc = 1
		end
	end
	else
	if ( @Tasks = N'DDLTasks' )
	begin
		if ( IS_SRVROLEMEMBER ('sysadmin') = 1 OR
			 IS_MEMBER ('db_owner') = 1 OR
			 IS_MEMBER ('db_ddladmin') = 1 )
		begin
			set @rc = 1
		end
	end
	
	return @rc
END
GO

	
-- This stored procedure reads definition of a SQL role and apply the associated
-- GRANT/DENY statements to the specified @UserName account.  The reason for
-- is to workaround the restriction that sp_addrolemember cannot be called
-- transactionally (but GRANT/REVOKE can).
CREATE PROCEDURE [dbo].[adm_ChangeRolePrivForUser]
@RoleName sysname,
@UserName sysname,
@ProtectType nvarchar(10) -- GRANT/DENY/REVOKE
AS
	set @UserName = dbo.adm_FormatNTGroupName(@UserName)

	if exists ( select * from sysusers where sid = suser_sid(@UserName) )
	begin

		-- If the user don't have sufficient permission, then throw an error and return immediately
		if ( dbo.adm_HasPermissionToPerform('DbRoleTasks') = 0 )
			return 0xC0C025D3 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_INSUFFICIENT_PRIV

		create table #RoleProtectionInfo
		(
			Owner sysname,
			Object sysname,
			Grantee sysname,
			Grantor sysname,
			ProtectType char(10),
			varAction varchar(20),
			snColumn sysname
		)

		insert into #RoleProtectionInfo
		exec dbo.sp_helprotect NULL, @RoleName

		declare RoleInfoCursor cursor FOR
		SELECT Object, varAction FROM #RoleProtectionInfo

		declare @Object sysname
		declare @Action varchar(20)

		open RoleInfoCursor
		FETCH NEXT FROM RoleInfoCursor INTO @Object, @Action
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			exec(@ProtectType + ' ' + @Action + ' ON ' + @Object + ' TO [' + @UserName + ']')
			FETCH NEXT FROM RoleInfoCursor INTO @Object, @Action
		END
			
		close RoleInfoCursor
		deallocate RoleInfoCursor

		drop table #RoleProtectionInfo
	end
GO
GRANT EXEC ON [dbo].[adm_ChangeRolePrivForUser] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_AddDbUserToRole]
@LoginName sysname,
@RoleToGrant sysname
AS
	set @LoginName = dbo.adm_FormatNTGroupName(@LoginName)

	declare @IsMember as int
	exec adm_IsMemberOfRole @LoginName, @RoleToGrant, @IsMember output
	
	if ( @IsMember = 0 )
	begin
		-- If the user don't have sufficient permission, then throw an error and return immediately
		if ( dbo.adm_HasPermissionToPerform('DbRoleTasks') = 0 )
			return 0xC0C025D3 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_INSUFFICIENT_PRIV

		-- If @LoginName is already dbo, skip the sp_addrolemember
		if ( suser_sid(@LoginName) <> (select sid from sysusers where name = 'dbo') )
			exec sp_addrolemember @RoleToGrant, @LoginName
	end
GO
GRANT EXEC ON [dbo].[adm_AddDbUserToRole] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_DropDbUserFromRole]
@LoginName sysname,
@RevokeFromRole sysname
AS
	set @LoginName = dbo.adm_FormatNTGroupName(@LoginName)

	declare @IsMember as int
	exec adm_IsMemberOfRole @LoginName, @RevokeFromRole, @IsMember output
	
	if ( @IsMember > 0 )
	begin
		-- If the user don't have sufficient permission, then throw an error and return immediately
		if ( dbo.adm_HasPermissionToPerform('DbRoleTasks') = 0 )
			return 0xC0C025D3 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_INSUFFICIENT_PRIV

		-- If @LoginName is already dbo, skip the sp_droprolemember
		if ( suser_sid(@LoginName) <> (select sid from sysusers where name = 'dbo') )
			exec sp_droprolemember @RevokeFromRole, @LoginName
	end
GO
GRANT EXEC ON [dbo].[adm_DropDbUserFromRole] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_AddLoginUser]
@LoginName sysname,
@RoleToGrant sysname
AS
	set @LoginName = dbo.adm_FormatNTGroupName(@LoginName)

	declare @NeedGrantLogin as int, @NeedGrantDbAccess as int, @NeedGrantDbRole as int, @IsMember as int
	select @NeedGrantLogin = 0, @NeedGrantDbAccess = 0, @NeedGrantDbRole = 0, @IsMember = 0
	
	-- Add SQL login if it doesn't already exist
	if not exists (select * from master.dbo.syslogins where sid = suser_sid(@LoginName))  
		set @NeedGrantLogin = 1
	
	-- Add database uesr if it doesn't already exist
	if not exists (select * from sysusers where sid = suser_sid(@LoginName) and hasdbaccess = 1)
		set @NeedGrantDbAccess = 1

	-- If the user don't have sufficient permission, then throw an error and return immediately
	if ( @NeedGrantLogin = 1 AND dbo.adm_HasPermissionToPerform('LoginTasks') = 0 )
		return 0xC0C025CF -- CIS_E_ADMIN_CORE_SQL_LOGIN_CREATION_INSUFFICIENT_PRIV

	if ( @NeedGrantDbAccess = 1 AND dbo.adm_HasPermissionToPerform('DbAccessTasks') = 0 )
		return 0xC0C025D2 -- CIS_E_ADMIN_CORE_SQL_DBACCESS_OPS_INSUFFICIENT_PRIV

	-- Create the SQL login
	if ( @NeedGrantLogin = 1 )
	begin
		if exists (select * from master.dbo.syslogins where name = @LoginName)
			return 0xC0C02600 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_STALE_ENTRY
			--exec sp_revokelogin @LoginName
		exec sp_grantlogin @LoginName
	end

	-- Grant database access
	if ( @NeedGrantDbAccess = 1 )
	begin
		if exists (select * from sysusers where name = @LoginName)
			return 0xC0C02600 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_STALE_ENTRY
			--exec sp_revokedbaccess @LoginName
		exec sp_grantdbaccess @LoginName
	end

	-- Grant role membership or not?
	if ( LEN(@RoleToGrant) > 0 )
	begin
		exec adm_IsMemberOfRole @LoginName, @RoleToGrant, @IsMember output
		if ( @IsMember = 0 )
			set @NeedGrantDbRole = 1
	end

	if ( @NeedGrantDbRole = 1 AND dbo.adm_HasPermissionToPerform('DbRoleTasks') = 0 )
		return 0xC0C025D3 -- CIS_E_ADMIN_CORE_SQL_DBROLE_OPS_INSUFFICIENT_PRIV
	
	-- Conditionally grant SQL role membership
	if ( @NeedGrantDbRole = 1 )
		exec adm_AddDbUserToRole @LoginName, @RoleToGrant
GO
GRANT EXEC ON [dbo].[adm_AddLoginUser] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_RemoveLoginUser]
@LoginName sysname
AS
	-- If the user don't have sufficient permission, then throw an error and return immediately
	if ( dbo.adm_HasPermissionToPerform('DbAccessTasks') = 0 )
		return 0xC0C025D2 -- CIS_E_ADMIN_CORE_SQL_DBACCESS_OPS_INSUFFICIENT_PRIV

	set @LoginName = dbo.adm_FormatNTGroupName(@LoginName)

	-- Remove database user access	
	if exists (select * from sysusers where sid = suser_sid(@LoginName) and hasdbaccess = 1)
		exec sp_revokedbaccess @LoginName
GO
GRANT EXEC ON [dbo].[adm_RemoveLoginUser] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[adm_CreateBTSAdminLogin]
@LoginName sysname
AS
	declare @rc as int
	exec @rc = adm_AddLoginUser @LoginName, N'BTS_ADMIN_USERS'
	
	return @rc
GO
GRANT EXEC ON [dbo].[adm_CreateBTSAdminLogin] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[adm_CreateBTSHostLogin]
@LoginName sysname
AS
	declare @rc as int
	exec @rc = adm_AddLoginUser @LoginName, N'BTS_HOST_USERS'
	
	return @rc
GO
GRANT EXEC ON [dbo].[adm_CreateBTSHostLogin] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[adm_RemoveBTSHostLogin]
@LoginName sysname
AS
	-- To handle the case when both BTS Admin NT Group and Host NT Group are the same,
	-- only remove the login from the BTS_HOST_USERS role
	declare @rc as int
	exec @rc = adm_DropDbUserFromRole @LoginName, N'BTS_HOST_USERS'
	
	return @rc
GO
GRANT EXEC ON [dbo].[adm_RemoveBTSHostLogin] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[adm_CreateBTSOperatorLogin]
@LoginName sysname
AS
	declare @rc as int
	exec @rc = adm_AddLoginUser @LoginName, N'BTS_OPERATORS'
	
	return @rc
GO
GRANT EXEC ON [dbo].[adm_CreateBTSOperatorLogin] TO BTS_ADMIN_USERS
GO
