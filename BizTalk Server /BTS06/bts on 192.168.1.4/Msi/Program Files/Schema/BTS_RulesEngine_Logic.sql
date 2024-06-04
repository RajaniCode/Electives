--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

SET ANSI_PADDING ON		-- trailing spaces are important

-- drop any existing stored procedures

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_deleteruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_deleteruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_dropruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_dropruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_deletevocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_deletevocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_dropvocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_dropvocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getallrulesets]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getallrulesets]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getallrulesetversions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getallrulesetversions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getallvocabularies]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getallvocabularies]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getallvocabularyversions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getallvocabularyversions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getconfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getconfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getvocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getvocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_publishruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_publishruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_publishvocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_publishvocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_saveruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_saveruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_saverulesetpb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_saverulesetpb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_savevocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_savevocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_savevocabularypb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_savevocabularypb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_updateruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_updateruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_updatevocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_updatevocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_searchrulesetlargepb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_searchrulesetlargepb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_searchrulesetpb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_searchrulesetpb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_searchvocabularylargepb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_searchvocabularylargepb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_searchvocabularypb]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_searchvocabularypb]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_trimruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_trimruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_trimvocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_trimvocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_renameruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_renameruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_renamevocabulary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_renamevocabulary]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getversion]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[re_getversion]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_update_vocabulary_vocabulary_table]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_update_vocabulary_vocabulary_table]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_update_ruleset_vocabulary_table]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_update_ruleset_vocabulary_table]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_vocabulary_link]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_check_vocabulary_link]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_vocabulary_in_use]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_check_vocabulary_in_use]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_ruleset_uses]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_check_ruleset_uses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_vocabulary_uses]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_check_vocabulary_uses]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_deployruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_deployruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_undeployruleset]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_undeployruleset]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_isrulesetdeployed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_isrulesetdeployed]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_updaterulesettc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_updaterulesettc]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getrulesettc]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getrulesettc]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getrulesetsdeploymentconfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getrulesetsdeploymentconfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getrulesetversionsdeployed]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getrulesetversionsdeployed]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getdeploymenthistory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getdeploymenthistory]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getmaxdeploymenthistoryid]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getmaxdeploymenthistoryid]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getpublishedundeployedrulesets]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getpublishedundeployedrulesets]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_isjupiterinstall]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_isjupiterinstall]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_saveauthgroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_saveauthgroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_deleteauthgroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_deleteauthgroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getauthgroup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getauthgroup]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getallauthgroups]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getallauthgroups]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_addauthgroupuser]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_addauthgroupuser]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getauthgroupusers]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getauthgroupusers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_addauthgroupforartifact]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_addauthgroupforartifact]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_deleteauthgroupsforartifact]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_deleteauthgroupsforartifact]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getauthgroupsforartifact]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_getauthgroupsforartifact]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_artifact_access_allowed]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[re_artifact_access_allowed]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_identity]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[re_check_identity]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_check_artifact_access]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_check_artifact_access]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_getauthconfig]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[re_getauthconfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_setconfig]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_setconfig]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[re_cleanup_database]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[re_cleanup_database]
GO


-- create the SQL Roles for configuring access privileges on the stored procedures

if not exists (select * from dbo.sysusers where name = N'RE_ADMIN_USERS' and issqlrole = 1)
	EXEC dbo.sp_addrole N'RE_ADMIN_USERS'
GO

if not exists (select * from dbo.sysusers where name = N'RE_HOST_USERS' and issqlrole = 1)
	EXEC dbo.sp_addrole N'RE_HOST_USERS'
GO

if not exists (select * from dbo.sysusers where name = N'RE_OPERATORS' and issqlrole = 1)
	EXEC dbo.sp_addrole N'RE_OPERATORS'
GO

-- Make RE_ADMIN_USERS a member of RE_HOST_USERS
EXEC dbo.sp_addrolemember N'RE_HOST_USERS', N'RE_ADMIN_USERS'
GO

-- Make BTS_ADMIN_USERS a member of RE_ADMIN_USERS
if exists (select * from sysusers where name = N'BTS_ADMIN_USERS' and issqlrole = 1)
	EXEC dbo.sp_addrolemember N'RE_ADMIN_USERS', N'BTS_ADMIN_USERS'
GO

-- Make BTS_HOST_USERS a member of RE_HOST_USERS
if exists (select * from sysusers where name = N'BTS_HOST_USERS' and issqlrole = 1)
	EXEC dbo.sp_addrolemember N'RE_HOST_USERS', N'BTS_HOST_USERS'
GO

-- Make BTS_OPERATORS a member of RE_OPERATORS
if exists (select * from sysusers where name = N'BTS_OPERATORS' and issqlrole = 1)
	EXEC dbo.sp_addrolemember N'RE_OPERATORS', N'BTS_OPERATORS'
GO

-- Grant RE_HOST_USERS and RE_OPERATORS access to the stored proc to query the database version
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_Query_BizTalkDBVersion]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	GRANT EXECUTE ON [dbo].[adm_Query_BizTalkDBVersion] TO RE_HOST_USERS
	GRANT EXECUTE ON [dbo].[adm_Query_BizTalkDBVersion] TO RE_OPERATORS
END
GO


-- create the stored procedures

/*****
re_getconfig -- get config table value
	@name   - config table entry
RETURNS:  value from table, 0 if it doesn't exist
DATASET:  none
*****/
CREATE PROC [dbo].[re_getconfig]
	@name nvarchar(32)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @result int
SELECT @result = nConfigValue 
	FROM [dbo].[re_config]
	WHERE strConfigName = @name
RETURN ISNULL(@result, 0)
GO
GRANT EXECUTE ON [dbo].[re_getconfig] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getconfig] TO RE_OPERATORS
GO

/*****
re_setconfig -- set a config value
	@name - config table entry
	@value - config value
DATASET:  none
*****/
CREATE PROC [dbo].[re_setconfig]
	@name nvarchar(256),
	@value int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

UPDATE [dbo].[re_config] SET nConfigValue = @value WHERE strConfigName = @name
RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_setconfig] TO RE_ADMIN_USERS
GO

/*****
re_getauthconfig -- get the auth config value
RETURNS:  0 if auth is disabled
DATASET:  none
*****/
CREATE FUNCTION [dbo].[re_getauthconfig]()
RETURNS int
AS
BEGIN
DECLARE @result int
SELECT @result = nConfigValue 
	FROM [dbo].[re_config]
	WHERE strConfigName = N'authorization'
RETURN ISNULL(@result, 0)
END
GO
GRANT EXECUTE ON [dbo].[re_getauthconfig] TO RE_HOST_USERS
GO

/*****
re_getversion -- convert major/minor version pair into a single value
	@major  - major version
	@minor  - minor version
RETURNS:  combined version number
NOTE: this is needed in order to sort versions, as we need a single entity
      we rely on the fact that version numbers are .NET int32, so we can combine them into a bigint
*****/
CREATE FUNCTION [dbo].[re_getversion](@major bigint, @minor bigint)
RETURNS bigint
AS
BEGIN
	RETURN @major * 4294967296 + @minor
END
GO
GRANT EXECUTE ON [dbo].[re_getversion] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getversion] TO RE_OPERATORS
GO

/*****
re_getruleset -- fetch a ruleset by name, name+major, or name+major+minor
	@name     - ruleset name
	@major    - major version
	@minor    - minor version
RETURN: 0 - Success
       -1 - ruleset does not exist
       -2 - no priviledge to read ruleset
DATASET:  column 1:  major version
          column 2:  minor version
          column 3:  BRML data for ruleset
          (single row)
*****/
CREATE PROC [dbo].[re_getruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nRuleSetID as bigint

SELECT @nRuleSetID=nRuleSetID 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1

IF dbo.re_artifact_access_allowed(@nRuleSetID, 1, 1)=0
	RETURN -2

SELECT nMajor, nMinor, imBRML 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getruleset] TO RE_HOST_USERS
GO

/*****
re_getallrulesets -- fetch the list rulesets
	@filter   - 0 -- all
	            1 -- published only
	            2 -- latest
	            3 -- latest published
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
*****/
CREATE PROC [dbo].[re_getallrulesets]
	@filter int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

IF @filter = 3
BEGIN
	-- only want latest published rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_ruleset]
	WHERE nRuleSetID in (SELECT nRuleSetID FROM [dbo].[re_ruleset], 
		(SELECT x=strName, y=MAX(nVersion) FROM [dbo].[re_ruleset] 
			WHERE nStatus > 0 
			GROUP BY strName, DATALENGTH(strName)) A 
		WHERE A.x=strName AND DATALENGTH(A.x)=DATALENGTH(strName) AND A.y=nVersion)
			AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC
END
ELSE IF @filter = 2
BEGIN
	-- only want latest rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_ruleset]
	WHERE nRuleSetID in (SELECT nRuleSetID FROM [dbo].[re_ruleset], 
		(SELECT x=strName, y=MAX(nVersion) FROM [dbo].[re_ruleset] 
			GROUP BY strName, DATALENGTH(strName)) A 
		WHERE A.x=strName AND DATALENGTH(A.x)=DATALENGTH(strName) AND A.y=nVersion AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1)
	ORDER BY strName ASC, DATALENGTH(strName) ASC
END
ELSE IF @filter = 1
BEGIN
	-- only want published rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_ruleset]
	WHERE nStatus > 0 AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC, nMajor DESC, nMinor DESC
END
ELSE
BEGIN
	-- want all rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_ruleset]
	WHERE dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC, nMajor DESC, nMinor DESC
END
GO
GRANT EXECUTE ON [dbo].[re_getallrulesets] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getallrulesets] TO RE_OPERATORS
GO

/*****
re_getallrulesetversions -- fetch the list of versions for a particular ruleset
	@name     - ruleset name
	@filter   - 0 -- all
	            1 -- published only
	            2 -- latest
	            3 -- latest published
DATASET:  column 1:  major version
          column 2:  minor version
          column 3:  description
          column 4:  modified by
          column 5:  modified time
          column 6:  status
*****/
CREATE PROC [dbo].[re_getallrulesetversions]
	@name nvarchar(256),
	@filter int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

IF @filter = 3
BEGIN
	-- only want latest published rulesets
	SELECT TOP 1 nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nStatus > 0 AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE IF @filter = 2
BEGIN
	-- only want latest rulesets
	SELECT TOP 1 nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE IF @filter = 1
BEGIN
	-- only want published rulesets
	SELECT nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nStatus > 0 AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE
BEGIN
	-- want all rulesets
	SELECT nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND dbo.re_artifact_access_allowed(nRuleSetID, 1, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
GO
GRANT EXECUTE ON [dbo].[re_getallrulesetversions] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getallrulesetversions] TO RE_OPERATORS
GO

/*****
re_getvocabulary -- fetch a vocabulary by name, name+major, or name+major+minor
	@name     - vocabulary name
	@major    - major version (<0 if not to be used)
	@minor    - minor version (<0 if not to be used)
RETURN: 0 - Success
       -1 - ruleset does not exist
       -2 - no priviledge to read ruleset
DATASET:  column 1:  major version
          column 2:  minor version
          column 3:  BRML data for vocabulary
          (single row)
*****/
CREATE PROC [dbo].[re_getvocabulary]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nVocabularyID as bigint

SELECT @nVocabularyID=nVocabularyID 
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

IF @@ROWCOUNT = 0
	RETURN -1

IF dbo.re_artifact_access_allowed(@nVocabularyID, 2, 1)=0
	RETURN -2

SELECT nMajor, nMinor, imBRML 
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getvocabulary] TO RE_HOST_USERS
GO

/*****
re_getallvocabularies -- fetch the list of vocabularies
	@filter   - 0 -- all
	            1 -- published only
	            2 -- latest
	            3 -- latest published
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
*****/
CREATE PROC [dbo].[re_getallvocabularies]
	@filter int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

IF @filter = 3
BEGIN
	-- only want latest published rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nVocabularyID in (SELECT nVocabularyID FROM [dbo].[re_vocabulary], 
		(SELECT x=strName, y=MAX(nVersion) FROM [dbo].[re_vocabulary] 
			WHERE nStatus > 0 
			GROUP BY strName, DATALENGTH(strName)) A 
		WHERE A.x=strName AND DATALENGTH(A.x)=DATALENGTH(strName) AND A.y=nVersion)
			AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC
END
ELSE IF @filter = 2
BEGIN
	-- only want latest rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nVocabularyID in (SELECT nVocabularyID FROM [dbo].[re_vocabulary], 
		(SELECT x=strName, y=MAX(nVersion) FROM [dbo].[re_vocabulary] 
			GROUP BY strName, DATALENGTH(strName)) A 
		WHERE A.x=strName AND DATALENGTH(A.x)=DATALENGTH(strName) AND A.y=nVersion)
			AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC
END
ELSE IF @filter = 1
BEGIN
	-- only want published rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nStatus > 0 AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC, nMajor DESC, nMinor DESC
END
ELSE
BEGIN
	-- want all rulesets
	SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
	ORDER BY strName ASC, DATALENGTH(strName) ASC, nMajor DESC, nMinor DESC
END
GO
GRANT EXECUTE ON [dbo].[re_getallvocabularies] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getallvocabularies] TO RE_OPERATORS
GO

/*****
re_getallvocabularyversions -- fetch the list of versions for a particular vocabulary
	@name     - vocabulary name
	@filter   - 0 -- all
	            1 -- published only
	            2 -- latest
	            3 -- latest published
DATASET:  column 1:  major version
          column 2:  minor version
          column 3:  description
          column 4:  modified by
          column 5:  modified time
          column 6:  status
*****/
CREATE PROC [dbo].[re_getallvocabularyversions]
	@name nvarchar(256),
	@filter int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

IF @filter = 3
BEGIN
	-- only want latest published rulesets
	SELECT TOP 1 nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nStatus > 0 AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE IF @filter = 2
BEGIN
	-- only want latest rulesets
	SELECT TOP 1 nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE IF @filter = 1
BEGIN
	-- only want published rulesets
	SELECT nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nStatus > 0 AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
ELSE
BEGIN
	-- want all rulesets
	SELECT nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND dbo.re_artifact_access_allowed(nVocabularyID, 2, 1)=1
		ORDER BY nMajor DESC, nMinor DESC
END
GO
GRANT EXECUTE ON [dbo].[re_getallvocabularyversions] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getallvocabularyversions] TO RE_OPERATORS
GO

/*****
re_update_vocabulary_vocabulary_table -- update the list of vocabulary to vocabulary links
	@key               - id of vocabulary making the reference
	@usedvocabularies  - list of ID's for used vocabularies
DATASET:  none
*****/
CREATE PROC [dbo].[re_update_vocabulary_vocabulary_table]
	@key bigint,
	@usedvocabularies ntext
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- remove any existing entries
DELETE FROM [dbo].[re_vocabulary_to_vocabulary_links]
	WHERE nReferingVocabulary = @key

-- load the list of ID's into a temporary table
DECLARE @idoc int
EXEC sp_xml_preparedocument @idoc OUTPUT, @usedvocabularies

DECLARE @vocab TABLE (v nvarchar(256) COLLATE Latin1_General_BIN)
INSERT INTO @vocab (v)
	SELECT v
	FROM OPENXML (@idoc, N'/ROOT/data', 1)
	WITH (v nvarchar(256) COLLATE Latin1_General_BIN)

INSERT INTO [dbo].[re_vocabulary_to_vocabulary_links] (nReferingVocabulary, nVocabularyID)
	SELECT @key, nVocabularyID FROM [dbo].[re_vocabulary], @vocab WHERE strID = v

-- cleanup
EXEC sp_xml_removedocument @idoc
GO
GRANT EXECUTE ON [dbo].[re_update_vocabulary_vocabulary_table] TO RE_HOST_USERS
GO

/*****
re_update_ruleset_vocabulary_table -- update the list of ruleset to vocabulary links
	@key               - id of ruleset making the reference
	@usedvocabularies  - list of ID's for used vocabularies
DATASET:  none
*****/
CREATE PROC [dbo].[re_update_ruleset_vocabulary_table]
	@key bigint,
	@usedvocabularies ntext
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- remove any existing entries
DELETE FROM [dbo].[re_ruleset_to_vocabulary_links]
	WHERE nReferingRuleset = @key

-- load the list of ID's into a temporary table
DECLARE @idoc int
EXEC sp_xml_preparedocument @idoc OUTPUT, @usedvocabularies

DECLARE @vocab TABLE (v nvarchar(256) COLLATE Latin1_General_BIN)
INSERT INTO @vocab (v)
	SELECT v
	FROM OPENXML (@idoc, N'/ROOT/data', 1)
	WITH (v nvarchar(256) COLLATE Latin1_General_BIN)

INSERT INTO [dbo].[re_ruleset_to_vocabulary_links] (nReferingRuleset, nVocabularyID)
	SELECT @key, nVocabularyID FROM [dbo].[re_vocabulary], @vocab WHERE strID = v

-- cleanup
EXEC sp_xml_removedocument @idoc
GO
GRANT EXECUTE ON [dbo].[re_update_ruleset_vocabulary_table] TO RE_HOST_USERS
GO

/*****
re_check_vocabulary_link -- check the list of vocabulary links to make sure all exist
	@usedvocabularies  - list of ID's for used vocabularies
RETURNS:  0 - all OK
         -1 - missing vocabularies
DATASET:  none
*****/
CREATE PROC [dbo].[re_check_vocabulary_link]
	@usedvocabularies ntext
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- load the list of ID's into a temporary table
DECLARE @idoc int
EXEC sp_xml_preparedocument @idoc OUTPUT, @usedvocabularies

DECLARE @vocab TABLE (v nvarchar(256) COLLATE Latin1_General_BIN)
INSERT INTO @vocab (v)
	SELECT v
	FROM OPENXML (@idoc, N'/ROOT/data', 1)
	WITH (v nvarchar(256) COLLATE Latin1_General_BIN)

DECLARE @count int
SET @count = @@ROWCOUNT
DECLARE @result int
SET @result = -1

SELECT nVocabularyID 
	FROM [dbo].[re_vocabulary], @vocab 
	WHERE strID = v AND nStatus > 0
IF @@ROWCOUNT = @count
	BEGIN
		SET @result = 0
	END

-- cleanup
EXEC sp_xml_removedocument @idoc
RETURN @result

GO
GRANT EXECUTE ON [dbo].[re_check_vocabulary_link] TO RE_HOST_USERS
GO

/*****
re_check_vocabulary_in_use -- return list of rulesets and vocabularies that use this vocabulary
	@name         - vocabulary name
	@major        - major version
	@minor        - minor version
RETURNS: 
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
DATASET:  column 1:  vocabulary name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
*****/
CREATE PROC [dbo].[re_check_vocabulary_in_use]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @id bigint
SELECT @id = nVocabularyID 
	FROM [dbo].[re_vocabulary] 
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_ruleset]
	WHERE nRuleSetID IN 
		(SELECT nReferingRuleset FROM [dbo].[re_ruleset_to_vocabulary_links] WHERE nVocabularyID = @id)

SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nVocabularyID IN 
		(SELECT nReferingVocabulary FROM [dbo].[re_vocabulary_to_vocabulary_links] WHERE nVocabularyID = @id)
GO
GRANT EXECUTE ON [dbo].[re_check_vocabulary_in_use] TO RE_HOST_USERS
GO

/*****
re_check_ruleset_uses -- return list of vocabularies used by the specified ruleset
	@name         - ruleset name
	@major        - major version
	@minor        - minor version
RETURNS: 
DATASET:  column 1:  vocabulary name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
*****/
CREATE PROC [dbo].[re_check_ruleset_uses]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @id bigint
SELECT @id = nRuleSetID 
	FROM [dbo].[re_ruleset] 
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nVocabularyID IN 
		(SELECT nVocabularyID FROM [dbo].[re_ruleset_to_vocabulary_links] WHERE nReferingRuleset = @id)
GO
GRANT EXECUTE ON [dbo].[re_check_ruleset_uses] TO RE_HOST_USERS
Go

/*****
re_check_vocabulary_uses -- return list of vocabularies that the specified vocabulary uses
	@name         - vocabulary name
	@major        - major version
	@minor        - minor version
RETURNS: 
DATASET:  column 1:  vocabulary name
          column 2:  major version
          column 3:  minor version
          column 4:  description
          column 5:  modified by
          column 6:  modified time
          column 7:  status
*****/
CREATE PROC [dbo].[re_check_vocabulary_uses]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @id bigint
SELECT @id = nVocabularyID 
	FROM [dbo].[re_vocabulary] 
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

SELECT strName, nMajor, nMinor, strDescription, strModifiedBy, dtModifiedTime, nStatus
	FROM [dbo].[re_vocabulary]
	WHERE nVocabularyID IN 
		(SELECT nVocabularyID FROM [dbo].[re_vocabulary_to_vocabulary_links] WHERE nReferingVocabulary = @id)
GO
GRANT EXECUTE ON [dbo].[re_check_vocabulary_uses] TO RE_HOST_USERS
GO

/*****
re_saveruleset -- save a particular ruleset
	@name         - ruleset name
	@major        - major version of ruleset
	@minor        - minor version
	@description  - description
	@modifiedby   - modified name
	@modifiedtime - modified time
	@usedvocabularies - list of vocabularies used by this ruleset
	@brml         - BRML for the ruleset
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  >=0 - key for index
           -1 - version already published, not saved
           -2 - no priviledge to update ruleset
DATASET:  none
*****/
CREATE PROC [dbo].[re_saveruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@description nvarchar(2048),
	@modifiedby nvarchar(256),
	@modifiedtime datetime,
	@usedvocabularies ntext,
	@brml image,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nStatus tinyint
DECLARE @key bigint
DECLARE @idoc int
DECLARE @count int
DECLARE @res int

SELECT @nStatus = nStatus, @key = nRuleSetID
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

IF @@ROWCOUNT = 0
	BEGIN
		-- no row found, so insert away
		INSERT INTO [dbo].[re_ruleset] (strName, nMajor, nMinor, nStatus, strDescription, strModifiedBy, dtModifiedTime, imBRML)
			VALUES(@name, @major, @minor, 0, @description, @modifiedby, @modifiedtime, @brml)

		-- get back index for new entry
		SELECT @key = nRuleSetID
			FROM [dbo].[re_ruleset]
			WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

		-- keep track of the artifact creator
		INSERT INTO [dbo].[re_artifact_creator] (nArtifactID, nArtifactType, strCreator, dtTimeStamp)
			VALUES(@key, 1, SUSER_SNAME(),@modifiedtime)

		-- update the used vocabularies table
		EXEC [dbo].[re_update_ruleset_vocabulary_table] @key, @usedvocabularies

		-- log the action
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'save', @name, @major, @minor)
			END
		RETURN @key
	END

-- row found, see if published
IF @nStatus = 0
	BEGIN
		IF dbo.re_artifact_access_allowed(@key, 1, 2)=0
			BEGIN
				RETURN -2
			END
		-- not published, so we can update it
		UPDATE [dbo].[re_ruleset]
			SET imBRML = @brml,
				strDescription = @description,
				strModifiedBy = @modifiedby,
				dtModifiedTime = @modifiedtime
			WHERE nRuleSetID = @key

		-- update the used vocabularies table
		EXEC [dbo].[re_update_ruleset_vocabulary_table] @key, @usedvocabularies

		-- log the action
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'save', @name, @major, @minor)
			END
		RETURN @key
	END

-- must already be published, so complain
RETURN -1
GO
GRANT EXECUTE ON [dbo].[re_saveruleset] TO RE_HOST_USERS
GO

/*****
re_updateruleset -- update the BRML for a particular ruleset
	@name         - ruleset name
	@major        - major version of ruleset
	@minor        - minor version
	@brml         - BRML for the ruleset
RETURNS:  >=0 - key for index
           -1 - ruleset does not exist
           -2 - no priviledge to update ruleset
DATASET:  none
*****/
CREATE PROC [dbo].[re_updateruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@brml image
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @key bigint
SELECT @key = nRuleSetID
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1
IF dbo.re_artifact_access_allowed(@key, 1, 2)=0
	RETURN -2

UPDATE [dbo].[re_ruleset]
	SET imBRML = @brml
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
RETURN @key
GO
GRANT EXECUTE ON [dbo].[re_updateruleset] TO RE_HOST_USERS
GO

/*****
re_savevocabulary -- save a particular vocabulary
	@name         - vocabulary name
	@major        - major version of vocabulary
	@minor        - minor version
	@description  - description
	@modifiedby   - modified name
	@modifiedtime - modified time
	@id           - vocabulary identifier
	@usedvocabularies - list of vocabularies used by this vocabulary
	@brml         - BRML for the vocabulary
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  >=0 - key for index
           -1 - version already published, not saved
           -2 - no priviledge to update vocabulary
           -3 - cannot renumber version
DATASET:  none
*****/
CREATE PROC [dbo].[re_savevocabulary]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@description nvarchar(2048),
	@modifiedby nvarchar(256),
	@modifiedtime datetime,
	@id nvarchar(256),
	@usedvocabularies ntext,
	@brml image,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nStatus tinyint
DECLARE @key bigint
DECLARE @idoc int
DECLARE @count int
DECLARE @res int
DECLARE @keytoupdate bigint
DECLARE @oldmajor bigint
DECLARE @oldminor bigint

SET @keytoupdate = -1

-- see if this version already exists
SELECT @nStatus = nStatus, @key = nVocabularyID
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

IF @@ROWCOUNT > 0
	BEGIN
		-- vocabulary published?
		IF @nStatus > 0
			RETURN -1
		-- user allowed to change this vocabulary?
		IF dbo.re_artifact_access_allowed(@key, 2, 2) = 0
			RETURN -2		-- insufficient permissions
		-- found something to update, so remember it
		SET @keytoupdate = @key
	END
	
-- now check that GUID is not in use (added 7/24)
SELECT @nStatus = nStatus, @key = nVocabularyID, @oldmajor = nMajor, @oldminor = nMinor
	FROM [dbo].[re_vocabulary]
	WHERE strID = @id AND nVocabularyID <> @keytoupdate
IF @@ROWCOUNT > 0
	BEGIN
		-- vocabulary published
		IF @nStatus > 0
			RETURN -1
		-- user allowed to change this vocabulary?
		IF dbo.re_artifact_access_allowed(@key, 2, 2) = 0
			RETURN -2		-- insufficient permissions
		-- are there 2 existing rows?
		IF @keytoupdate >= 0
			RETURN -3
		-- found something to update, so remember it
		SET @keytoupdate = @key
	END
		
IF @keytoupdate = -1
	BEGIN
		-- no row found, so insert away

		INSERT INTO [dbo].[re_vocabulary] (strName, strID, nMajor, nMinor, nStatus, strDescription, strModifiedBy, dtModifiedTime, imBRML)
			VALUES(@name, @id, @major, @minor, 0, @description, @modifiedby, @modifiedtime, @brml)

		-- get back index for new entry
		SELECT @key = nVocabularyID
			FROM [dbo].[re_vocabulary]
			WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

		-- keep track of the artifact creator
		INSERT INTO [dbo].[re_artifact_creator] (nArtifactID, nArtifactType, strCreator, dtTimeStamp)
			VALUES(@key, 2, SUSER_SNAME(), @modifiedtime)

		-- update the used vocabularies table
		EXEC [dbo].[re_update_vocabulary_vocabulary_table] @key, @usedvocabularies

		-- log the action
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strVocabulary, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'save', @name, @major, @minor)
			END
		RETURN @key
	END
ELSE
	BEGIN
		-- row found, so we can update it
		UPDATE [dbo].[re_vocabulary]
			SET imBRML = @brml,
				strDescription = @description,
				strModifiedBy = @modifiedby,
				dtModifiedTime = @modifiedtime,
				nMajor = @major,
				nMinor = @minor
			WHERE nVocabularyID = @keytoupdate

		-- update the used vocabularies table
		EXEC [dbo].[re_update_vocabulary_vocabulary_table] @keytoupdate, @usedvocabularies

		-- log the action
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strVocabulary, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'save', @name, @major, @minor)
			END
		RETURN @keytoupdate
	END
GO
GRANT EXECUTE ON [dbo].[re_savevocabulary] TO RE_HOST_USERS
GO

/*****
re_updatevocabulary -- update the BRML for a particular vocabulary
	@name         - vocabulary name
	@major        - major version of vocabulary
	@minor        - minor version
	@brml         - BRML for the vocabulary
RETURNS:  >=0 - key for index
           -1 - vocabulary does not exist
           -2 - no priviledge to update vocabulary
DATASET:  none
*****/
CREATE PROC [dbo].[re_updatevocabulary]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@brml image
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @key bigint
SELECT @key = nVocabularyID
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1
IF dbo.re_artifact_access_allowed(@key, 2, 2)=0
	RETURN -2

UPDATE [dbo].[re_vocabulary]
	SET imBRML = @brml
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
RETURN @key
GO
GRANT EXECUTE ON [dbo].[re_updatevocabulary] TO RE_HOST_USERS
GO

/*****
re_deleteruleset -- delete a particular ruleset version
	@name         - ruleset name
	@major        - major version
	@minor        - minor version
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  number of versions deleted
          -1 - no priviledge to delete ruleset
          -2 - ruleset deployed
DATASET:  none
*****/
CREATE PROC [dbo].[re_deleteruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @key bigint
SELECT @key = nRuleSetID
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN 0
IF dbo.re_artifact_access_allowed(@key, 1, 2)=0
	RETURN -1

-- ruleset must not be deployed
IF EXISTS (SELECT * FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @key)
	RETURN -2

DELETE FROM [dbo].[re_tracking_id] WHERE (nRuleSetID = @key)
DELETE FROM [dbo].[re_artifact_creator] WHERE ((nArtifactID = @key) AND (nArtifactType = 1))
DELETE FROM [dbo].[re_artifact_authgroup_assoc] WHERE ((nArtifactID = @key) AND (nArtifactType = 1))
DELETE FROM [dbo].[re_ruleset_to_vocabulary_links] WHERE (nReferingRuleset = @key)
DECLARE @count int
DELETE FROM [dbo].[re_ruleset] WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
SET @count = @@ROWCOUNT

-- log the action
IF @count > 0
BEGIN
	DECLARE @res int
	EXEC @res = [dbo].[re_getconfig] N'audittrail'
	IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'delete', @name, @major, @minor)
	END
END
RETURN @count
GO
GRANT EXECUTE ON [dbo].[re_deleteruleset] TO RE_HOST_USERS
GO

/*****
re_deletevocabulary -- delete a particular vocabulary version
	@name         - vocabulary name
	@major        - major version
	@minor        - minor version
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  number of versions deleted
          -1 - no priviledge to delete vocabulary
          -2 - vocabulary has dependencies and can't be deleted
DATASET:  none
*****/
CREATE PROC [dbo].[re_deletevocabulary]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @key bigint
SELECT @key = nVocabularyID
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN 0
IF dbo.re_artifact_access_allowed(@key, 2, 2)=0
	RETURN -1

-- check for dependencies
IF EXISTS (SELECT * FROM [dbo].[re_ruleset_to_vocabulary_links] WHERE nVocabularyID = @key)
	RETURN -2
IF EXISTS (SELECT * FROM [dbo].[re_vocabulary_to_vocabulary_links] WHERE nVocabularyID = @key)
	RETURN -2

DELETE FROM [dbo].[re_artifact_creator] WHERE ((nArtifactID = @key) AND (nArtifactType = 2))
DELETE FROM [dbo].[re_artifact_authgroup_assoc] WHERE ((nArtifactID = @key) AND (nArtifactType = 2))
DELETE FROM [dbo].[re_vocabulary_to_vocabulary_links] WHERE (nReferingVocabulary = @key)

DECLARE @count int
DELETE FROM [dbo].[re_vocabulary] WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
SET @count = @@ROWCOUNT

-- log the action
IF @count > 0
BEGIN
	DECLARE @res int
	EXEC @res = [dbo].[re_getconfig] N'audittrail'
	IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strVocabulary, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'delete', @name, @major, @minor)
	END
END
RETURN @count
GO
GRANT EXECUTE ON [dbo].[re_deletevocabulary] TO RE_HOST_USERS
GO

/*****
re_publishruleset -- publish a particular ruleset
	@name         - ruleset name
	@major        - major version of ruleset
	@minor        - minor version
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  0 - published successfully
         -1 - version does not exist
         -2 - version already published
         -3 - no priviledge to update ruleset
DATASET:  none
*****/
CREATE PROC [dbo].[re_publishruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1		-- version does not exist

IF dbo.re_artifact_access_allowed(@nRuleSetID, 1, 2)=0
	RETURN -3		-- no priv to publish ruleset.

UPDATE [dbo].[re_ruleset] 
	SET nStatus = 1
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor AND nStatus = 0
IF @@ROWCOUNT = 0
	RETURN -2		-- version already published

INSERT INTO [dbo].[re_tracking_id] (nRuleSetID, uidServiceGUID)
	VALUES(@nRuleSetID, NewId())

-- log the action
DECLARE @res int
EXEC @res = [dbo].[re_getconfig] N'audittrail'
IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'publish', @name, @major, @minor)
	END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_publishruleset] TO RE_HOST_USERS
GO

/*****
re_publishvocabulary -- publish a particular vocabulary
	@name         - vocabulary name
	@major        - major version of vocabulary
	@minor        - minor version
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  0 - published successfully
         -1 - version does not exist
         -2 - version already published
         -3 - no priviledge to update vocabulary
DATASET:  none
*****/
CREATE PROC [dbo].[re_publishvocabulary]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nVocabularyID as bigint
SELECT @nVocabularyID = nVocabularyID 
	FROM [dbo].[re_vocabulary]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1		-- version does not exist

IF dbo.re_artifact_access_allowed(@nVocabularyID, 2, 2)=0
	RETURN -3		-- no priv to publish vocabulary.

UPDATE [dbo].[re_vocabulary] 
	SET nStatus = 1
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor AND nStatus = 0
IF @@ROWCOUNT = 0
	RETURN -2		-- version already published

-- log the action
DECLARE @res int
EXEC @res = [dbo].[re_getconfig] N'audittrail'
IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strVocabulary, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'publish', @name, @major, @minor)
	END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_publishvocabulary] TO RE_HOST_USERS
GO

/*****
re_renameruleset -- rename a ruleset
	@origname    - original name
	@newname     - name it should be changed to
	@major       - major version of new ruleset
	@minor       - minor version
	@user        - (logging) user name
	@altuser     - (logging) alternate crendentials name
	@machine     - (logging) request came from this machine
	@latestmajor - latest existing major version of newname
	@latestminor - latest existing minor version of newname
RETURNS:  1 - rename successful
          0 - rename not required
         -1 - rename not allowed as original has published versions
         -2 - rename not allowed as newname already in database
DATASET:  none
*****/
CREATE PROC [dbo].[re_renameruleset]
	@origname nvarchar(256) = null,
	@newname nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256),
	@latestmajor bigint OUTPUT,
	@latestminor bigint OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- see if the new name is in existance
SELECT @latestmajor = nMajor, @latestminor = nMinor
	FROM [dbo].[re_ruleset]
	WHERE strName = @newname AND DATALENGTH(strName) = DATALENGTH(@newname)
	ORDER BY nMajor DESC, nMinor DESC

IF @latestmajor is null
	BEGIN
		-- newname not in use, so see if origname exists
		IF @origname is null
			RETURN 0

		-- origname defined, so make sure no published versions of origname
		DECLARE @count bigint
		SELECT @count = COUNT(*)
			FROM [dbo].[re_ruleset]
			WHERE strName = @origname AND DATALENGTH(strName) = DATALENGTH(@origname)
			AND nStatus > 0
		IF @count > 0
			RETURN -1

		-- no published versions, so rename
		UPDATE [dbo].[re_ruleset]
			SET strName = @newname
			WHERE strName = @origname AND DATALENGTH(strName) = DATALENGTH(@origname)

		-- log the trimming
		DECLARE @res int
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, strVocabulary, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'renameruleset', @newname, @origname, 0, 0)
			END
		RETURN 1
	END

-- here newname already exists in the database
IF @origname is null
	RETURN 0

-- is a rename from origname to newname and newname exists, so fail
RETURN -2
GO
GRANT EXECUTE ON [dbo].[re_renameruleset] TO RE_ADMIN_USERS
GO

/*****
re_renamevocabulary -- rename a vocabulary
	@origname    - original name
	@newname     - name it should be changed to
	@major       - major version of new vocabulary
	@minor       - minor version
	@user        - (logging) user name
	@altuser     - (logging) alternate crendentials name
	@machine     - (logging) request came from this machine
	@latestmajor - latest existing major version of newname
	@latestminor - latest existing minor version of newname
RETURNS:  1 - rename successful
          0 - rename not required
         -1 - rename not allowed as original has published versions
         -2 - rename not allowed as newname already in database
DATASET:  none
*****/
CREATE PROC [dbo].[re_renamevocabulary]
	@origname nvarchar(256) = null,
	@newname nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256),
	@latestmajor bigint OUTPUT,
	@latestminor bigint OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- see if the new name is in existance
SELECT @latestmajor = nMajor, @latestminor = nMinor
	FROM [dbo].[re_vocabulary]
	WHERE strName = @newname AND DATALENGTH(strName) = DATALENGTH(@newname)
	ORDER BY nMajor DESC, nMinor DESC

IF @latestmajor is null
	BEGIN
		-- newname not in use, so see if origname exists
		IF @origname is null
			RETURN 0

		-- origname defined, so make sure no published versions of origname
		DECLARE @count bigint
		SELECT @count = COUNT(*)
			FROM [dbo].[re_vocabulary]
			WHERE strName = @origname AND DATALENGTH(strName) = DATALENGTH(@origname)
			AND nStatus > 0
		IF @count > 0
			RETURN -1

		-- no published versions, so rename
		UPDATE [dbo].[re_vocabulary]
			SET strName = @newname
			WHERE strName = @origname AND DATALENGTH(strName) = DATALENGTH(@origname)

		-- log the trimming
		DECLARE @res int
		EXEC @res = [dbo].[re_getconfig] N'audittrail'
		IF @res > 0
			BEGIN
				INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, strVocabulary, nMajor, nMinor)
					VALUES(@user, @altuser, @machine, N'renamevocabulary', @newname, @origname, 0, 0)
			END
		RETURN 1
	END

-- here newname already exists in the database
IF @origname is null
	RETURN 0

-- is a rename from origname to newname and newname exists, so fail
RETURN -2
GO
GRANT EXECUTE ON [dbo].[re_renamevocabulary] TO RE_ADMIN_USERS
GO

/******************************************************************************
Start: Deployment/Tracking related stored procedures.
*****************************************************************************/

/*****
re_deployruleset -- deploy a particular ruleset to a group
	@name             - ruleset name
	@major            - major version of vocabulary
	@minor            - minor version
	@tracking_config  - tracking config
	@user             - (logging) user name
	@altuser          - (logging) alternate crendentials name
	@machine          - (logging) request came from this machine
OUT	@service_guid     - version independent guid for the ruleset service
RETURNS:  0 - deployed successfully
         -1 - ruleset does not exist
         -2 - ruleset not yet published
         -4 - ruleset already deployed
DATASET:  none
*****/
CREATE PROC [dbo].[re_deployruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@tracking_config image,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256),
	@service_guid uniqueidentifier OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nStatus tinyint
DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID, @nStatus = nStatus 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1		-- ruleset does not exist

IF @nStatus = 0
	RETURN -2		-- ruleset has not yet been published

SELECT @service_guid = uidServiceGUID
	FROM [dbo].[re_tracking_id]
	WHERE nRuleSetID = @nRuleSetID

IF EXISTS (SELECT nRuleSetID FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @nRuleSetID)
	RETURN -4		-- ruleset was already deployed

DECLARE @currentTime datetime
SET @currentTime = GETUTCDATE()

INSERT INTO [dbo].[re_deployment_config] (nRuleSetID, imTrackingConfig, dtTimeStamp)
	VALUES(@nRuleSetID, @tracking_config, @currentTime)

INSERT INTO [dbo].[re_deployment_history] (strName, nMajor, nMinor, bDeployedInd, dtTimeStamp)
	VALUES(@name, @major, @minor, 1, @currentTime)

-- log the action
DECLARE @res int
EXEC @res = [dbo].[re_getconfig] N'audittrail'
IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'deploy', @name, @major, @minor)
	END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_deployruleset] TO RE_ADMIN_USERS
GO

/*****
re_undeployruleset -- undeploy a particular ruleset to a group
	@name         - ruleset name
	@major        - major version of vocabulary
	@minor        - minor version
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
OUT	@service_guid - version independent guid for the ruleset
RETURNS:  0 - undeployed successfully
         -1 - ruleset does not exist
         -2 - ruleset wasn't even published
         -5 - ruleset was never deployed
DATASET:  none
*****/
CREATE PROC [dbo].[re_undeployruleset]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256),
	@service_guid uniqueidentifier OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nStatus tinyint
DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID, @nStatus = nStatus 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

IF @@ROWCOUNT = 0		-- ruleset does not exist
	RETURN -1

IF @nStatus = 0			-- ruleset wasn't even published
	RETURN -2

DELETE FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @nRuleSetID

IF @@ROWCOUNT = 0		-- ruleset was never deployed
	RETURN -5

INSERT INTO [dbo].[re_deployment_history] (strName, nMajor, nMinor, bDeployedInd, dtTimeStamp)
	VALUES(@name, @major, @minor, 0, GETUTCDATE())

SELECT @service_guid = uidServiceGUID
	FROM [dbo].[re_tracking_id]
	WHERE nRuleSetID = @nRuleSetID

-- log the action
DECLARE @res int
EXEC @res = [dbo].[re_getconfig] N'audittrail'
IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'undeploy', @name, @major, @minor)
	END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_undeployruleset] TO RE_ADMIN_USERS
GO

/*****
re_isrulesetdeployed -- is a particular ruleset deployed
	@name             - ruleset name
	@major            - major version of vocabulary
	@minor            - minor version
RETURNS:  0 - ruleset is deployed
         -1 - ruleset does not exist
         -2 - ruleset not yet published
         -3 - ruleset not yet deployed
DATASET:  none
*****/
CREATE PROC [dbo].[re_isrulesetdeployed]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nStatus tinyint
DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID, @nStatus = nStatus 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1		-- ruleset does not exist

IF @nStatus = 0
	RETURN -2		-- ruleset has not yet been published

IF NOT EXISTS (SELECT nRuleSetID FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @nRuleSetID)
	RETURN -3		-- ruleset is not deployed
	
RETURN 0		-- ruleset is deployed
GO
GRANT EXECUTE ON [dbo].[re_isrulesetdeployed] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_isrulesetdeployed] TO RE_OPERATORS
GO


/*****
re_updaterulesettc -- update ruleset tracking config
	@name         - ruleset name
	@major        - major version of vocabulary
	@minor        - minor version
	@tracking_config - tracking config
	@user         - (logging) user name
	@altuser      - (logging) alternate crendentials name
	@machine      - (logging) request came from this machine
RETURNS:  0 - updated successfully
         -1 - ruleset does not exist
         -2 - ruleset not yet published
DATASET:  none
*****/
CREATE PROC [dbo].[re_updaterulesettc]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@tracking_config bigint,
	@user nvarchar(256),
	@altuser nvarchar(256),
	@machine nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nStatus tinyint
DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor

IF @@ROWCOUNT = 0		-- ruleset does not exist
	RETURN -1

UPDATE [dbo].[re_tracking_id]
	SET nTrackingConfig = @tracking_config
	WHERE nRuleSetID = @nRuleSetID

IF @@ROWCOUNT = 0		-- ruleset has not yet been published
	RETURN -2

-- if the ruleset is deployed, tell everybody about the change
IF EXISTS (SELECT * FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @nRuleSetID)
BEGIN
	INSERT INTO [dbo].[re_deployment_history] (strName, nMajor, nMinor, bDeployedInd, dtTimeStamp)
		VALUES(@name, @major, @minor, 2, GETUTCDATE())
END

-- log the action
DECLARE @res int
EXEC @res = [dbo].[re_getconfig] N'audittrail'
IF @res > 0
	BEGIN
		INSERT INTO [dbo].[re_audittrail] (strUser, strCredentials, strMachine, strAction, strRuleSet, nMajor, nMinor)
			VALUES(@user, @altuser, @machine, N'updatetc', @name, @major, @minor)
	END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_updaterulesettc] TO RE_ADMIN_USERS
GO

/*****
re_getrulesettc -- get ruleset tracking config
	@name         - ruleset name
	@major        - major version of vocabulary
	@minor        - minor version
RETURNS:  0 - updated successfully
         -1 - ruleset does not exist
         -2 - ruleset not yet published
         -5 - ruleset not deployed
DATASET:  column 1:  tracking GUID
          column 2:  tracking_config (bigint)
          column 3:  tracking_config (image)
          (single row)
*****/
CREATE PROC [dbo].[re_getrulesettc]
	@name nvarchar(256),
	@major bigint,
	@minor bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nStatus tinyint
DECLARE	@nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID, @nStatus = nStatus 
	FROM [dbo].[re_ruleset]
	WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
IF @@ROWCOUNT = 0
	RETURN -1		-- ruleset does not exist

IF @nStatus = 0
	RETURN -2		-- ruleset has not yet been published

-- want to merge tables, but can't do that with image data
-- SELECT uidServiceGUID, nTrackingConfig, (SELECT imTrackingConfig from [dbo].[re_deployment_config] dc where tid.nRuleSetID = dc.nRuleSetID)
-- FROM [dbo].[re_tracking_id] tid
-- WHERE tid.nRuleSetID = @nRuleSetID

IF EXISTS (SELECT * FROM [dbo].[re_deployment_config] WHERE nRuleSetID = @nRuleSetID)
BEGIN
	SELECT uidServiceGUID, nTrackingConfig, imTrackingConfig
		FROM [dbo].[re_tracking_id] tid
		JOIN [dbo].[re_deployment_config] dc ON tid.nRuleSetID = dc.nRuleSetID
		WHERE dc.nRuleSetID = @nRuleSetID
	RETURN 0
END

-- ruleset not deployed, so make up image data
SELECT uidServiceGUID, nTrackingConfig, NULL
	FROM [dbo].[re_tracking_id]
	WHERE nRuleSetID = @nRuleSetID
IF @@ROWCOUNT = 0
	RETURN -2		-- ruleset has not yet been published

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getrulesettc] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getrulesettc] TO RE_OPERATORS
GO

/*****
re_getrulesetsdeploymentconfig -- get rulesets deployed with their config
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          column 4:  tracking config (bigint)
          column 5:  tracking config (image)
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getrulesetsdeploymentconfig]
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT strName, nMajor, nMinor, nTrackingConfig, imTrackingConfig
	FROM [dbo].[re_ruleset] rs
	JOIN [dbo].[re_tracking_id] tid ON rs.nRuleSetID = tid.nRuleSetID
	JOIN [dbo].[re_deployment_config] dc ON rs.nRuleSetID = dc.nRuleSetID

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getrulesetsdeploymentconfig] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getrulesetsdeploymentconfig] TO RE_OPERATORS
GO

/*****
re_getrulesetversionsdeployed -- get ruleset versions deployed
	@ruleset_name - ruleset name
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getrulesetversionsdeployed]
	@ruleset_name nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT strName, nMajor, nMinor
	FROM [dbo].[re_ruleset] rs
	JOIN [dbo].[re_deployment_config] dc ON rs.nRuleSetID = dc.nRuleSetID
	WHERE rs.strName = @ruleset_name AND DATALENGTH(strName) = DATALENGTH(@ruleset_name)
	ORDER BY nMajor DESC, nMinor DESC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getrulesetversionsdeployed] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getrulesetversionsdeployed] TO RE_OPERATORS
GO

/*****
re_getdeploymenthistory -- get deployment history since the specified history id
            @since_id     - since id
DATASET:  column 1:  history id
          column 2:  ruleset name
          column 3:  major ver
          column 4:  minor ver
          column 5:  deployment/undeployment ind
          column 6:  datetime
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getdeploymenthistory]
            @since_id   bigint
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT nHistoryID, strName, nMajor, nMinor, bDeployedInd, dtTimeStamp
	FROM [dbo].[re_deployment_history]
	WHERE nHistoryID > @since_id
GO
GRANT EXECUTE ON [dbo].[re_getdeploymenthistory] TO RE_HOST_USERS
GO

/*****
re_getmaxdeploymenthistoryid -- get max deployment history id
OUT      @max_history_id bigint
DATASET:  none
RETURNS:  0
*****/
CREATE PROC [dbo].[re_getmaxdeploymenthistoryid]
        @max_history_id bigint OUTPUT
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT @max_history_id = MAX(nHistoryID)
	FROM [dbo].[re_deployment_history]

if (@max_history_id is null)
BEGIN
	SET @max_history_id = 0 
END

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getmaxdeploymenthistoryid] TO RE_HOST_USERS
GO

/*****
re_getpublishedundeployedrulesets -- get published undeployed rulesets.
DATASET:  column 1:  ruleset name
          column 2:  major version
          column 3:  minor version
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getpublishedundeployedrulesets]
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT strName, nMajor, nMinor
	FROM [dbo].[re_ruleset]
	WHERE nRuleSetID NOT IN (SELECT nRuleSetID from [dbo].[re_deployment_config])
	AND nStatus > 0
	ORDER BY strName ASC, DATALENGTH(strName) ASC, nMajor DESC, nMinor DESC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getpublishedundeployedrulesets] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_getpublishedundeployedrulesets] TO RE_OPERATORS
GO

/****************************************************************************
End: Deployment/Tracking related stored procedures.
*****************************************************************************/

/******************************************************************************
Start: Authorization related stored procedures.
*****************************************************************************/

/*****
re_saveauthgroup -- get authorization group.
	@groupname	- group name
	@permissions	- permissions
	@modifiedtime	- modified time
RETURNS:  >=1 - key for index
DATASET:  none
*****/
CREATE PROC [dbo].[re_saveauthgroup]
	@groupname nvarchar(256),
	@permissions int,
	@modifiedtime datetime
AS
DECLARE @key bigint

SELECT @key = nAuthGroupID
	FROM [dbo].[re_authgroup]
	WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)

IF @@ROWCOUNT = 0
BEGIN
	-- no row found, so insert away
	INSERT INTO [dbo].[re_authgroup] (strName, nAccessPriv, dtTimeStamp)
		VALUES(@groupname, @permissions, @modifiedtime)

	-- get back index for new entry
	SELECT @key = nAuthGroupID
		FROM [dbo].[re_authgroup]
		WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)
	RETURN @key
END

-- row found, update it
UPDATE [dbo].[re_authgroup]
	SET nAccessPriv = @permissions,
		dtTimeStamp = @modifiedtime
	WHERE nAuthGroupID = @key

-- remove the authgroup users since we just changed it
DELETE FROM [dbo].[re_authgroup_user] WHERE nAuthGroupID = @key 

RETURN @key
GO
GRANT EXECUTE ON [dbo].[re_saveauthgroup] TO RE_ADMIN_USERS
GO

/*****
re_deleteauthgroup -- delete authorization group.
	@groupname	- group name
*****/
CREATE PROC [dbo].[re_deleteauthgroup]
	@groupname nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nAuthGroupID bigint

SELECT @nAuthGroupID = nAuthGroupID 
	FROM [dbo].[re_authgroup]
	WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)

DELETE FROM [dbo].[re_authgroup_user] WHERE nAuthGroupID = @nAuthGroupID
DELETE FROM [dbo].[re_artifact_authgroup_assoc] WHERE nAuthGroupID = @nAuthGroupID
DELETE FROM [dbo].[re_authgroup] WHERE nAuthGroupID = @nAuthGroupID

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_deleteauthgroup] TO RE_ADMIN_USERS
GO

/*****
re_getauthgroup -- get authorization group.
	@groupname	- group name
DATASET:  column 1:  group name
          column 2:  permissions
          (none/single row)
*****/
CREATE PROC [dbo].[re_getauthgroup]
	@groupname nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT strName, nAccessPriv
	FROM [dbo].[re_authgroup]
	WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)
	ORDER BY strName ASC, DATALENGTH(strName) ASC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getauthgroup] TO RE_HOST_USERS
GO

/*****
re_getallauthgroups -- get all authorization groups.
DATASET:  column 1:  group name
          column 2:  permissions
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getallauthgroups]
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

SELECT strName, nAccessPriv
	FROM [dbo].[re_authgroup]
	ORDER BY strName ASC, DATALENGTH(strName) ASC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getallauthgroups] TO RE_HOST_USERS
GO

/*****
re_addauthgroupuser -- add authorization group user.
	@authgroupid	- auth group id
	@identity		- identity
	@identitytype	- 1 = win user/ 2 = sql user/ 3 = win group/ 4 = sql role
	@modifiedtime	- modified time
RETURNS: 0 - success
        -1 - invalid role/group
*****/
CREATE PROC [dbo].[re_addauthgroupuser]
	@authgroupid	bigint,
	@identity	nvarchar(256),
	@identitytype	int,
	@modifiedtime	datetime
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- check if win group/sql role exists
IF (@identitytype > 2)
BEGIN
	IF IS_MEMBER(@identity) IS NULL
		RETURN -1
END
INSERT INTO [dbo].[re_authgroup_user] (nAuthGroupID, strUserIdentity, nUserIdentityType, dtTimeStamp)
	VALUES (@authgroupid, @identity, @identitytype, @modifiedtime) 

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_addauthgroupuser] TO RE_ADMIN_USERS
GO

/*****
re_getauthgroupusers -- get authorization group users.
	@groupname - group name
DATASET:  column 1:  identity
          column 2:  identitytype (1 = win user/ 2 = sql user/ 3 = win group/ 4 = sql role)
          (multiple rows)
*****/
CREATE PROC [dbo].[re_getauthgroupusers]
	@groupname nvarchar(256)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nAuthGroupID bigint

SELECT @nAuthGroupID = nAuthGroupID 
	FROM [dbo].[re_authgroup]
	WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)

SELECT strUserIdentity, nUserIdentityType
	FROM [dbo].[re_authgroup_user]
	WHERE nAuthGroupID = @nAuthGroupID
	ORDER BY strUserIdentity ASC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getauthgroupusers] TO RE_HOST_USERS
GO

/*****
re_addauthgroupforartifact -- add authorization group for artifact.
	@groupname - group name
	@name	- artifact name
	@major	- major version
	@minor	- minor version
	@artifacttype	- artifact type
	@modifiedtime	- modified time
RETURNS:  0 - added successfully
         -1 - invalid artifact type
         -2 - artifact does not exist
         -3 - group does not exist
         -4 - no priviledge to access artifact
*****/
CREATE PROC [dbo].[re_addauthgroupforartifact]
	@groupname nvarchar(256),
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@artifacttype int,
	@modifiedtime datetime
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nArtifactID bigint

IF @artifacttype = 1
BEGIN
	SELECT @nArtifactID = nRuleSetID 
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
IF @artifacttype = 2
BEGIN
	SELECT @nArtifactID = nVocabularyID 
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
BEGIN
	-- invalid artifact type
	RETURN -1
END

IF @@ROWCOUNT = 0
	RETURN -2		-- artifact does not exist

DECLARE	@nAuthGroupID bigint
	
SELECT @nAuthGroupID = nAuthGroupID 
	FROM [dbo].[re_authgroup]
	WHERE strName = @groupname AND DATALENGTH(strName) = DATALENGTH(@groupname)

IF @@ROWCOUNT = 0
	RETURN -3		-- group does not exist

IF dbo.re_artifact_access_allowed(@nArtifactID, @artifacttype, 2)=0
	RETURN -4		-- not allowed

INSERT INTO [dbo].[re_artifact_authgroup_assoc] (nArtifactID, nArtifactType, nAuthGroupID, dtTimeStamp)
	VALUES (@nArtifactID, @artifacttype, @nAuthGroupID, @modifiedtime)

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_addauthgroupforartifact] TO RE_HOST_USERS
GO

/*****
re_deleteauthgroupsforartifact -- delete authorization groups for artifact.
	@name	- artifact name
	@major	- major version
	@minor	- minor version
	@artifacttype	- artifact type
RETURNS:  0 - deleted successfully
         -1 - invalid artifact type
         -2 - artifact does not exist
         -3 - no priviledge to access artifact
*****/
CREATE PROC [dbo].[re_deleteauthgroupsforartifact]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@artifacttype int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nArtifactID bigint

IF @artifacttype = 1
BEGIN
	SELECT @nArtifactID = nRuleSetID 
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
IF @artifacttype = 2
BEGIN
	SELECT @nArtifactID = nVocabularyID 
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
BEGIN
	-- invalid artifact type
	RETURN -1
END

IF @@ROWCOUNT = 0
	RETURN -2		-- artifact does not exist

IF dbo.re_artifact_access_allowed(@nArtifactID, @artifacttype, 2)=0
	RETURN -3		-- not allowed

DELETE FROM [dbo].[re_artifact_authgroup_assoc]
	WHERE nArtifactID = @nArtifactID AND nArtifactType = @artifacttype

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_deleteauthgroupsforartifact] TO RE_HOST_USERS
GO

/*****
re_getauthgroupsforartifact -- get authorization groups for artifact.
	@name	- artifact name
	@major	- major version
	@minor	- minor version
	@artifacttype	- artifact type
DATASET:  column 1:  group name
          column 2:  permissions
          (multiple rows)
RETURNS:  0 - added successfully
         -1 - invalid artifact type
         -2 - artifact does not exist
*****/
CREATE PROC [dbo].[re_getauthgroupsforartifact]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@artifacttype int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE	@nArtifactID bigint

IF @artifacttype = 1
BEGIN
	SELECT @nArtifactID = nRuleSetID 
		FROM [dbo].[re_ruleset]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
IF @artifacttype = 2
BEGIN
	SELECT @nArtifactID = nVocabularyID 
		FROM [dbo].[re_vocabulary]
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor
END
ELSE
BEGIN
	-- invalid artifact type
	RETURN -1
END

IF @@ROWCOUNT = 0	
	RETURN -2		-- artifact does not exist

SELECT strName, nAccessPriv
	FROM [dbo].[re_artifact_authgroup_assoc] aaga
	JOIN [dbo].[re_authgroup] ag ON ag.nAuthGroupID = aaga.nAuthGroupID
	WHERE aaga.nArtifactID = @nArtifactID AND aaga.nArtifactType = @artifacttype
	ORDER BY strName ASC, DATALENGTH(strName) ASC

RETURN 0
GO
GRANT EXECUTE ON [dbo].[re_getauthgroupsforartifact] TO RE_HOST_USERS
GO

/****
re_check_identity -- is the current user part of this authorization identity
	@identitytype	- 1 = win user/ 2 = sql user/ 3 = win group/ 4 = sql role
	@identity		- identity string
RETURN : 1 - yes
         0 - no
****/
CREATE FUNCTION [dbo].[re_check_identity](
	@useridentitytype	int,
	@useridentity		nvarchar(256))
RETURNS int
AS
BEGIN
-- is it a role or group?
IF (@useridentitytype = 3 OR @useridentitytype = 4)
	RETURN IS_MEMBER(@useridentity)

-- must be a sql or windows user
IF @useridentity = SUSER_SNAME()
	RETURN 1
	
RETURN 0 
END
GO
GRANT EXECUTE ON [dbo].[re_check_identity] TO RE_HOST_USERS
GO

/****
re_artifact_access_allowed -- are we allowed to read/execute the artifact
	@artifactid	- artifact id
	@artifacttype	- artifact type 1:RuleSet, 2:Vocabulary
	@accesstype	- access type 1:ReadExecute, 2:ModifyDelete
RETURN : 1 - if access allowed.
RETURN : 0 - if access not-allowed.
****/
CREATE  FUNCTION [dbo].[re_artifact_access_allowed](
	@artifactid	bigint,
	@artifacttype	int,
	@accesstype	int)
RETURNS int
AS
BEGIN

-- first check if authorization is configured as enabled
IF dbo.re_getauthconfig() = 0
	RETURN 1

-- RE_ADMIN_USERS and database owners are always allowed
IF (IS_MEMBER ('RE_ADMIN_USERS') = 1 OR IS_MEMBER ('db_owner') = 1)
	RETURN 1

-- check if user is denied
IF EXISTS ( 
	SELECT TOP 1 c.strUserIdentity
	FROM [dbo].[re_artifact_authgroup_assoc] a
	JOIN [dbo].[re_authgroup] b ON a.nAuthGroupID = b.nAuthGroupID AND b.nAccessPriv = 0
	JOIN [dbo].[re_authgroup_user] c ON b.nAuthGroupID = c.nAuthGroupID AND 1 = dbo.re_check_identity(c.nUserIdentityType, c.strUserIdentity)
	WHERE  a.nArtifactID = @artifactid AND a.nArtifactType = @artifacttype
)
	RETURN 0

-- user not denied, see if user has necessary permissions
IF EXISTS ( 
	SELECT TOP 1 c.strUserIdentity
	FROM [dbo].[re_artifact_authgroup_assoc] a
	JOIN [dbo].[re_authgroup] b ON a.nAuthGroupID = b.nAuthGroupID AND ((b.nAccessPriv & @accesstype) > 0)
	JOIN [dbo].[re_authgroup_user] c ON b.nAuthGroupID = c.nAuthGroupID AND 1 = dbo.re_check_identity(c.nUserIdentityType, c.strUserIdentity)
	WHERE  a.nArtifactID = @artifactid AND a.nArtifactType = @artifacttype
)
	RETURN 1

-- no access allowed, but there may be no authorization groups associated with the artifact
-- if that is the case, creator has access
IF NOT EXISTS (
	SELECT TOP 1 nAuthGroupID
	FROM [dbo].[re_artifact_authgroup_assoc]
	WHERE nArtifactID = @artifactid AND nArtifactType = @artifacttype
)
BEGIN
	IF EXISTS (
		SELECT strCreator
		FROM [dbo].[re_artifact_creator]
		WHERE nArtifactID = @artifactid AND nArtifactType = @artifacttype AND strCreator = SUSER_SNAME()
	)
		RETURN 1
END

RETURN 0
END
GO
GRANT EXECUTE ON [dbo].[re_artifact_access_allowed] TO RE_HOST_USERS
GO

/****
re_check_artifact_access -- are we allowed to read/execute the artifact
	@name           - artifact id
	@major          - major revision
	@minor		- minor revision
	@artifacttype	- artifact type 1:RuleSet, 2:Vocabulary
	@accesstype	- access type 1:ReadExecute, 2:ModifyDelete
RETURN : 1 - if access allowed.
RETURN : 0 - if access not-allowed.
****/
CREATE PROC [dbo].[re_check_artifact_access]
	@name nvarchar(256),
	@major bigint,
	@minor bigint,
	@artifacttype int,
	@accesstype int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

DECLARE @nArtifactID as bigint
IF @artifacttype = 1
	SELECT @nArtifactID=nRuleSetID 
		FROM [dbo].[re_ruleset] 
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor 
ELSE
IF @artifacttype = 2
	SELECT @nArtifactID=nVocabularyID 
		FROM [dbo].[re_vocabulary] 
		WHERE strName = @name AND DATALENGTH(strName) = DATALENGTH(@name) AND nMajor = @major AND nMinor = @minor 
ELSE
	RETURN 0

IF @@ROWCOUNT = 0
	RETURN 0

DECLARE @accessenabled as int
SET @accessenabled = dbo.re_artifact_access_allowed( @nArtifactID, @artifacttype, @accesstype)
RETURN @accessenabled

GO
GRANT EXECUTE ON [dbo].[re_check_artifact_access] TO RE_HOST_USERS
GO

/****************************************************************************
End: Authorization related stored procedures.
*****************************************************************************/


/****************************************************************************
Start: Cleanup related stored procedures and job
*****************************************************************************/

/****
re_cleanup_database -- remove old data from database
****/
CREATE PROC [dbo].[re_cleanup_database]
AS
SET NOCOUNT ON
SET XACT_ABORT ON
SET ANSI_PADDING ON

-- should we clean out the history table?
DECLARE @hourstokeep int
EXEC @hourstokeep = [dbo].[re_getconfig] N'deploymenthistory'
IF @hourstokeep > 0
BEGIN
	-- need to delete old records, however make sure the latest one is kept
	DECLARE @latestrecord bigint
	SELECT @latestrecord = MAX(nHistoryID) 
		FROM [dbo].[re_deployment_history]
	DELETE FROM [dbo].[re_deployment_history]
		WHERE DATEDIFF(hour, dtTimeStamp, GETUTCDATE()) > @hourstokeep 
		AND nHistoryID != @latestrecord
END

-- should we cleanup the audit table?
DECLARE @daystokeep int
EXEC @daystokeep = [dbo].[re_getconfig] N'audithistory'
IF @daystokeep > 0
BEGIN
	DELETE FROM [dbo].[re_audittrail]
		WHERE DATEDIFF(day, dtTimeStamp, GETUTCDATE()) > @daystokeep
END
GO

GRANT EXECUTE ON [dbo].[re_cleanup_database] TO RE_HOST_USERS
GO
GRANT EXECUTE ON [dbo].[re_cleanup_database] TO RE_OPERATORS
GO

/****
create the job to do the database cleanup
****/
BEGIN TRANSACTION
DECLARE @JobID BINARY(16)
DECLARE @ReturnCode INT
SELECT @ReturnCode = 0
DECLARE @name nvarchar(256)
SET @name = N'Rules_Database_Cleanup_' + db_name()

IF (SELECT COUNT(*) FROM msdb.dbo.syscategories WHERE name = N'Database Maintenance') < 1
	EXECUTE msdb.dbo.sp_add_category @name = N'Database Maintenance'

-- Delete the job with the same name (if it exists)
SELECT @JobID = job_id FROM msdb.dbo.sysjobs WHERE (name = @name)
IF (@JobID IS NOT NULL)
BEGIN
	-- Check if the job is a multi-server job
	IF (EXISTS (SELECT * FROM msdb.dbo.sysjobservers WHERE (job_id = @JobID) AND (server_id <> 0)))
	BEGIN 
		-- There is, so abort the script
		RAISERROR (N'Unable to import job ''Rules_Database_Cleanup'' since there is already a multi-server job with this name.', 16, 1)
		GOTO QuitWithRollback
	END
	ELSE
		-- Delete the [local] job
		EXECUTE msdb.dbo.sp_delete_job @job_name = @name
	SELECT @JobID = NULL
END

BEGIN 
	-- Add the job
	EXECUTE @ReturnCode = msdb.dbo.sp_add_job 
		@job_id = @JobID OUTPUT,
		@job_name = @name,
		@description = N'Remove old audit and history data.',
		@category_name = N'Database Maintenance',
		@enabled = 1,
		@notify_level_email = 0,
		@notify_level_page = 0,
		@notify_level_netsend = 0,
		@notify_level_eventlog = 2,
		@delete_level= 0
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 

	-- Add the job steps
	DECLARE @dbname sysname
	SET @dbname = db_name()
	EXECUTE @ReturnCode = msdb.dbo.sp_add_jobstep 
		@job_id = @JobID,
		@step_id = 1,
		@step_name = N'Cleanup',
		@command = N'exec re_cleanup_database',
		@database_name = @dbname,
		@server = N'',
		@database_user_name = N'',
		@subsystem = N'TSQL',
		@cmdexec_success_code = 0,
		@flags = 0,
		@retry_attempts = 0,
		@retry_interval = 1,
		@output_file_name = N'',
		@on_success_step_id = 0,
		@on_success_action = 1,
		@on_fail_step_id = 0,
		@on_fail_action = 2
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	EXECUTE @ReturnCode = msdb.dbo.sp_update_job
		@job_id = @JobID,
		@start_step_id = 1
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Add the job schedules
	EXECUTE @ReturnCode = msdb.dbo.sp_add_jobschedule
		@job_id = @JobID,
		@name = N'Hourly',
		@enabled = 1,
		@freq_type = 4,
		@active_start_date = 20050624,
		@active_start_time = 0,
		@freq_interval = 1,
		@freq_subday_type = 8,
		@freq_subday_interval = 1,
		@freq_relative_interval = 0,
		@freq_recurrence_factor = 0,
		@active_end_date = 99991231,
		@active_end_time = 235959
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback

	-- Add the Target Servers
	EXECUTE @ReturnCode = msdb.dbo.sp_add_jobserver
		@job_id = @JobID,
		@server_name = N'(local)'
	IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback
END
COMMIT TRANSACTION
GOTO EndSave

QuitWithRollback:
IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION
EndSave:
GO

/****************************************************************************
End: Authorization related stored procedures and job
*****************************************************************************/
