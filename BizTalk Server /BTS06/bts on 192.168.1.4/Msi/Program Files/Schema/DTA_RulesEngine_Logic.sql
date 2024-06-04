--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 
 
-- Stored procs for rules engine

IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertRuleSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertRuleSet]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REUnDeployRuleSet]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE dtasp_REUnDeployRuleSet
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertRule]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertRule]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertRuleSetEngineAssociation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertFactActivity]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertFactActivity]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertFactAttributes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertFactAttributes]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertConditionEvaluation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertConditionEvaluation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertAgendaUpdates]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertAgendaUpdates]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REInsertRuleFired]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REInsertRuleFired]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetRuleSetEngineAssociationCountForAppl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetRuleSetEngineAssociationCountForAppl]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetRuleSetEngineAssociationsForAppl]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetRuleSetEngineAssociationsForAppl]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetFactActivityForRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetFactActivityForRuleSetEngineAssociation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetFactAttributes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetFactAttributes]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetRulesFiredForRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetRulesFiredForRuleSetEngineAssociation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetRulesNotFiredForRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetRulesNotFiredForRuleSetEngineAssociation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetRuleDefn]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetRuleDefn]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation]
GO
IF exists (SELECT * FROM sysobjects WHERE id = object_id(N'[dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) DROP PROCEDURE [dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation]
GO

--========== stored procedures for rules engine ==========--

-------------------------------------------------------------------------------------
-- Rules Engine stored procs end here --
-------------------------------------------------------------------------------------

/*****
dtasp_REInsertRuleSet -- add ruleset definition
	@uid	-- tracking id for ruleset
	@name	-- ruleset name
	@major	-- major
	@minor	-- minor
OUT	@rows_inserted -- num of rows inserted
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertRuleSet
	@uid		uniqueidentifier,
	@name		nvarchar(256),
	@major		bigint,
	@minor		bigint,
	@rows_inserted	int OUTPUT
AS
set nocount on
set xact_abort on
SET @rows_inserted = 0
UPDATE dta_RuleSets SET dtDeploymentTime = GETUTCDATE(), dtUnDeployTime = NULL WHERE uidRuleSetGUID = @uid
IF @@ROWCOUNT = 0
BEGIN
	INSERT INTO dta_RuleSets (uidRuleSetGUID, strName, nMajor, nMinor, dtDeploymentTime, dtUnDeployTime)
	VALUES (@uid, @name, @major, @minor, GETUTCDATE(), NULL)
	SET @rows_inserted = @@ROWCOUNT
END
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertRuleSet TO BTS_ADMIN_USERS
GO

/*****
dtasp_REUnDeployRuleSet -- add ruleset definition
	@uid	-- tracking id for ruleset
RETURNS:  0 - updated successfully
DATASET:  none
*****/
CREATE PROC dtasp_REUnDeployRuleSet
	@uid		uniqueidentifier
AS
set nocount on
set xact_abort on

/*****
tracking id's are on a per ruleset basis - if the ruleset is deployed/undeployed
repeatedly, the same id will be in the database multiple times, so we only update
the rows that don't have the undeploy time set
****/
UPDATE dta_RuleSets 
SET dtUnDeployTime = GETUTCDATE() 
WHERE uidRuleSetGUID = @uid AND dtUnDeployTime IS NULL

RETURN 0
GO
GRANT EXEC ON dtasp_REUnDeployRuleSet TO BTS_ADMIN_USERS
GO

/*****
dtasp_REInsertRule -- add rule definition
	@uid	        -- tracking id for ruleset
	@name	        -- rule name
	@rule_string	-- rule string
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertRule
	@uid		uniqueidentifier,
	@name		nvarchar(256),
	@rule_string	ntext
AS
set nocount on
set xact_abort on
DECLARE @nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID
FROM dta_RuleSets
WHERE uidRuleSetGUID = @uid

INSERT INTO dta_Rules (nRuleSetID, strName, strRule)
VALUES (@nRuleSetID, @name, @rule_string)

RETURN 0
GO
GRANT EXEC ON dtasp_REInsertRule TO BTS_ADMIN_USERS
GO

/*****
dtasp_REInsertRuleSetEngineAssociation -- add rule-set engine association record
	@association_uid -- id for ruleset engine association
	@ruleset_uid	 -- id for ruleset
	@engine_uid	 -- id for engine instance
	@appl_uid	 -- id of consumer
	@dt_timestamp    -- time of association.
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertRuleSetEngineAssociation
	@association_uid uniqueidentifier,
	@ruleset_uid	 uniqueidentifier,
	@engine_uid	 uniqueidentifier,
	@appl_uid	 uniqueidentifier,
	@dt_timestamp	 datetime
AS
DECLARE @nRuleSetID bigint
SELECT @nRuleSetID = nRuleSetID
FROM dta_RuleSets
WHERE uidRuleSetGUID = @ruleset_uid
INSERT INTO dta_RuleSetEngineAssociation (uidRuleSetEngineAssociationGUID, nRuleSetID, uidRuleEngineID, uidApplicationID, dtTimeStamp)
VALUES (@association_uid, @nRuleSetID, @engine_uid, @appl_uid, @dt_timestamp)
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertRuleSetEngineAssociation TO HM_EVENT_WRITER
GO

/*****
dtasp_REInsertFactActivity -- add rule-set execution fact activity
	@activity_uid	 -- id for fact assertion/retraction
	@association_uid -- id for ruleset engine association
	@class_name	 -- name of class
	@class_id	 -- class instance id
	@activity_type	 -- fact asserted/updated/retracted
	@dt_timestamp    -- time fact asserted/retracted
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertFactActivity
	@activity_uid	 uniqueidentifier,
	@association_uid uniqueidentifier,
	@class_name	 nvarchar(256),
	@class_id	 bigint,
	@activity_type	 tinyint,
	@dt_timestamp	 datetime
AS
DECLARE @nRuleSetEngineAssociationID bigint
SELECT @nRuleSetEngineAssociationID = nRuleSetEngineAssociationID
FROM dta_RuleSetEngineAssociation
WHERE uidRuleSetEngineAssociationGUID = @association_uid
INSERT INTO dta_RulesFactActivity (uidRulesFactActivityGUID, nRuleSetEngineAssociationID, strClassName, nClassInstanceID, nActivityType, dtTimeStamp)
VALUES (@activity_uid, @nRuleSetEngineAssociationID, @class_name, @class_id, @activity_type, @dt_timestamp)
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertFactActivity TO HM_EVENT_WRITER
GO

/*****
dtasp_REInsertConditionEvaluation -- add rule-set condition evaluation events
	@association_uid	-- id for ruleset engine association
	@text_expression	-- condition evaluated
	@lhs_classname		-- lhs class name
	@lhs_classinstanceid	-- lhs indtance id
	@lhs_literalvalue	-- lhs literal value
	@rhs_classname		-- rhs class name
	@rhs_classinstanceid	-- rhs instance id
	@rhs_literalvalue	-- rhs literal value
	@result			-- boolean result
	@dt_timestamp		-- time condition evaluated
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertConditionEvaluation
	@association_uid	uniqueidentifier,
	@text_expression	nvarchar(256),
	@lhs_classname		nvarchar(256),
	@lhs_classinstanceid	bigint,
	@lhs_literalvalue	nvarchar(256),
	@rhs_classname		nvarchar(256),
	@rhs_classinstanceid	bigint,
	@rhs_literalvalue	nvarchar(256),
	@result			bit,
	@dt_timestamp		datetime
AS
DECLARE @nRuleSetEngineAssociationID bigint
SELECT @nRuleSetEngineAssociationID = nRuleSetEngineAssociationID
FROM dta_RuleSetEngineAssociation
WHERE uidRuleSetEngineAssociationGUID = @association_uid
INSERT INTO dta_RulesConditionEvaluation (nRuleSetEngineAssociationID, strTextExpression, strLhsClassName, nLhsClassInstanceID, strLhsLiteralValue, strRhsClassName, nRhsClassInstanceID, strRhsLiteralValue, bResult, dtTimeStamp)
VALUES (@nRuleSetEngineAssociationID, @text_expression, @lhs_classname, @lhs_classinstanceid, @lhs_literalvalue, @rhs_classname, @rhs_classinstanceid, @rhs_literalvalue, @result, @dt_timestamp)
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertConditionEvaluation TO HM_EVENT_WRITER
GO

/*****
dtasp_REInsertAgendaUpdates  -- log agenda updates
	@ruleset_uid	 -- id for ruleset
	@association_uid -- ruleset engine association id,
	@add_ind	 -- addition/removal from agenda
	@rule_name	 -- rule name
	@conflict_resolution_criteria	-- conflict resolution criteria
	@dt_timestamp    -- time the agenda was updated.
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertAgendaUpdates
	@ruleset_uid	 uniqueidentifier,
	@association_uid uniqueidentifier,
	@add_ind	 bit,
	@rule_name	 nvarchar(256),
	@conflict_resolution_criteria	nvarchar(256),
	@dt_timestamp	 datetime
AS
DECLARE @nRuleSetEngineAssociationID bigint
SELECT @nRuleSetEngineAssociationID = nRuleSetEngineAssociationID
FROM dta_RuleSetEngineAssociation
WHERE uidRuleSetEngineAssociationGUID = @association_uid
DECLARE @nRuleID bigint
SELECT @nRuleID = nRuleID
FROM dta_RuleSets rs, dta_Rules r
WHERE uidRuleSetGUID = @ruleset_uid AND r.strName = @rule_name AND rs.nRuleSetID = r.nRuleSetID
INSERT INTO dta_RulesAgendaUpdates (nRuleSetEngineAssociationID, bAddIndicator, nRuleID, strConflictResolutionCriteria, dtTimeStamp)
VALUES (@nRuleSetEngineAssociationID, @add_ind, @nRuleID, @conflict_resolution_criteria, @dt_timestamp)
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertAgendaUpdates TO HM_EVENT_WRITER
GO

/*****
dtasp_REInsertRuleFired  -- log rule firing
	@ruleset_uid	 -- id for ruleset
	@association_uid -- ruleset engine association id,
	@rule_name	 -- rule name
	@dt_timestamp    -- time the rule fired.
RETURNS:  0 - inserted successfully
DATASET:  none
*****/
CREATE PROC dtasp_REInsertRuleFired
	@ruleset_uid	 uniqueidentifier,
	@association_uid uniqueidentifier,
	@rule_name	 nvarchar(256),
	@dt_timestamp	 datetime
AS
DECLARE @nRuleSetEngineAssociationID bigint
SELECT @nRuleSetEngineAssociationID = nRuleSetEngineAssociationID
FROM dta_RuleSetEngineAssociation
WHERE uidRuleSetEngineAssociationGUID = @association_uid
DECLARE @nRuleID bigint
SELECT @nRuleID = nRuleID
FROM dta_RuleSets rs, dta_Rules r
WHERE uidRuleSetGUID = @ruleset_uid AND r.strName = @rule_name AND rs.nRuleSetID = r.nRuleSetID
INSERT INTO dta_RulesFired (nRuleSetEngineAssociationID, nRuleID, dtTimeStamp)
VALUES (@nRuleSetEngineAssociationID, @nRuleID, @dt_timestamp)
RETURN 0
GO
GRANT EXEC ON dtasp_REInsertRuleFired TO HM_EVENT_WRITER
GO

/*****
dtasp_REGetRuleSetEngineAssociationCountForAppl  -- get the ruleset engine association count for application
	@appl_uid	 -- id of consumer
out     @count bigint OUTPUT
RETURNS:  0 - success
*****/
CREATE PROC dtasp_REGetRuleSetEngineAssociationCountForAppl
	@appl_uid	 uniqueidentifier,
        @count           bigint OUTPUT
AS
set nocount on
set xact_abort on
SELECT @count = count(*)
FROM dta_RuleSetEngineAssociation
WHERE uidApplicationID = @appl_uid
RETURN 0
GO
GRANT EXEC ON dtasp_REGetRuleSetEngineAssociationCountForAppl TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetRuleSetEngineAssociationCountForAppl TO BTS_OPERATORS
GO

/*****
dtasp_REGetRuleSetEngineAssociationsForAppl  -- get the ruleset engine associations for application
	@appl_uid	 -- id of consumer
RETURNS:  0 - success
DATASET:  column 1:  ruleset engine association id.
          column 2:  ruleset name
          column 3:  major revision
          column 4:  minor revision
          column 5:  association time
          (multiple rows)
*****/
CREATE PROC dtasp_REGetRuleSetEngineAssociationsForAppl
	@appl_uid	 uniqueidentifier
AS
set nocount on
set xact_abort on
SELECT nRuleSetEngineAssociationID, strName, nMajor, nMinor, dtTimeStamp
FROM dta_RuleSetEngineAssociation rea, dta_RuleSets rs
WHERE rea.uidApplicationID = @appl_uid AND rea.nRuleSetID = rs.nRuleSetID
ORDER BY nRuleSetEngineAssociationID ASC
RETURN 0
GO
GRANT EXEC ON dtasp_REGetRuleSetEngineAssociationsForAppl TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetRuleSetEngineAssociationsForAppl TO BTS_OPERATORS
GO

/*****
dtasp_REGetFactActivityForRuleSetEngineAssociation  -- get the fact activity for a ruleset engine association
	@association_id	 -- id of ruleset engine association
RETURNS:  0 - success
DATASET:  column 1:  fact activity id.
          column 2:  class name
          column 3:  class instance
          column 4:  assertion/updation/retraction indicator
          column 5:  fact activity time
          (multiple rows)
*****/
CREATE PROC dtasp_REGetFactActivityForRuleSetEngineAssociation
	@association_id	 bigint
AS
set nocount on
set xact_abort on
SELECT nRulesFactActivityID, strClassName, nClassInstanceID, nActivityType, dtTimeStamp
FROM dta_RulesFactActivity
WHERE nRuleSetEngineAssociationID = @association_id
ORDER BY nRulesFactActivityID ASC
RETURN 0
GO
GRANT EXEC ON dtasp_REGetFactActivityForRuleSetEngineAssociation TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetFactActivityForRuleSetEngineAssociation TO BTS_OPERATORS
GO

/*****
dtasp_REGetRulesFiredForRuleSetEngineAssociation  -- get the rules that fired for a ruleset engine association.
	@association_id	 -- id of ruleset engine association
RETURNS:  0 - success
DATASET:  column 1:  rule id.
          column 2:  rule name
          column 2:  rule display string
          column 3:  rule firing time
          (multiple rows)
*****/
CREATE PROC dtasp_REGetRulesFiredForRuleSetEngineAssociation
	@association_id	 bigint
AS
set nocount on
set xact_abort on
SELECT rf.nRuleID, strName, strRule, dtTimeStamp
FROM dta_RulesFired rf, dta_Rules r
WHERE rf.nRuleSetEngineAssociationID = @association_id AND rf.nRuleID = r.nRuleID
RETURN 0
GO
GRANT EXEC ON dtasp_REGetRulesFiredForRuleSetEngineAssociation TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetRulesFiredForRuleSetEngineAssociation TO BTS_OPERATORS
GO

/*****
dtasp_REGetRulesNotFiredForRuleSetEngineAssociation  -- get the rules that did not fire for a ruleset engine association.
	@association_id	 -- id of ruleset engine association
RETURNS:  0 - success
DATASET:  column 1:  rule id.
          column 2:  rule name
          column 2:  rule display string
          (multiple rows)
*****/
CREATE PROC dtasp_REGetRulesNotFiredForRuleSetEngineAssociation
	@association_id	 bigint
AS
set nocount on
set xact_abort on
DECLARE @nRuleSetID bigint
SET @nRuleSetID = 0
SELECT @nRuleSetID=nRuleSetID
FROM dta_RuleSetEngineAssociation
WHERE nRuleSetEngineAssociationID = @association_id

SELECT nRuleID, strName, strRule
FROM dta_Rules
WHERE nRuleSetID = @nRuleSetID AND nRuleID NOT IN (SELECT nRuleID FROM dta_RulesFired WHERE nRuleSetEngineAssociationID = @association_id)
RETURN 0
GO
GRANT EXEC ON dtasp_REGetRulesNotFiredForRuleSetEngineAssociation TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetRulesNotFiredForRuleSetEngineAssociation TO BTS_OPERATORS
GO

/*****
dtasp_REGetRuleDefn  -- get the rule name and display string.
	@rule_id	 -- id of rule
RETURNS:  0 - success
DATASET:  column 1:  rule name
          column 2:  rule display string
          (single row)
*****/
CREATE PROC dtasp_REGetRuleDefn  
	@rule_id	 bigint
AS
set nocount on
set xact_abort on
SELECT strName, strRule
FROM dta_Rules
WHERE nRuleID = @rule_id
RETURN 0
GO
GRANT EXEC ON dtasp_REGetRuleDefn TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetRuleDefn TO BTS_OPERATORS
GO

/****
dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation -- get agenda update information from association id
RETURNS: 0 - success
DATASET: column 1: ID
		 column 2: rule name
		 column 3: rule id
		 column 4: add indictator
		 column 5: conflict resolution criteria
		 column 6: time stamp
****/
CREATE PROC dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation
	@association_id	 bigint
AS
set nocount on
set xact_abort on
SELECT ra.nRulesAgendaUpdatesID, strName, ra.nRuleID, bAddIndicator, strConflictResolutionCriteria, dtTimeStamp
FROM dta_RulesAgendaUpdates ra, dta_Rules r
WHERE ra.nRuleSetEngineAssociationID = @association_id AND ra.nRuleID = r.nRuleID
RETURN 0

GO
GRANT EXEC ON dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetAgendaUpdatesForRuleSetEngineAssociation TO BTS_OPERATORS
GO

/*********
dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation -- get condition evaluation information from association id
RETURN: 0 - success
DATASET: column 1: ID
		 column 2: text expression
		 column 3: lhs class name
		 column 4: lhs class instance
		 column 5: lhs literal value
		 column 6: rhs class name
		 column 7: rhs class instance
		 column 8: rhs literal value
		 column 9: result
		 column 10: timestamp 
**********/
Create PROC dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation
	@association_id	 bigint
AS
set nocount on
set xact_abort on
SELECT nRulesConditionEvaluationID, strTextExpression, 
	strLhsClassName,nLhsClassInstanceID, strLhsLiteralValue,
	strRhsClassName,nRhsClassInstanceID, strRhsLiteralValue,
	bResult, dtTimeStamp
FROM dta_RulesConditionEvaluation
WHERE nRuleSetEngineAssociationID = @association_id
RETURN 0

GO
GRANT EXEC ON dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation TO BTS_ADMIN_USERS
GO
GRANT EXEC ON dtasp_REGetConditionsEvaluatedForRuleSetEngineAssociation TO BTS_OPERATORS
GO

/*****
end of file.
******/
