--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

--/--------------------------------------------------------------------------------------------------------
-- Remove Tables
--/--------------------------------------------------------------------------------------------------------
-- Remove health monitoring related tables
-- Remove rules engine related tables
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RulesFired]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RulesFired]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RulesAgendaUpdates]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RulesAgendaUpdates]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RulesConditionEvaluation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RulesConditionEvaluation]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RulesFactAttributes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RulesFactAttributes]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RulesFactActivity]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RulesFactActivity]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RuleSetEngineAssociation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RuleSetEngineAssociation]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_Rules]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_Rules]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RuleSets]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RuleSets]
-- Following just cleans up a pre-historic table.
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_RuleFactTypes]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[dta_RuleFactTypes]

GO

--/--------------------------------------------------------------------------------------------------------
--
--	Health monitoring related tables
--
--/--------------------------------------------------------------------------------------------------------

--/--
--	Rules Engine Related Tables
--/--

CREATE TABLE [dbo].[dta_RuleSets] (
	[nRuleSetID]			[bigint]			NOT NULL IDENTITY (1, 1),
	[uidRuleSetGUID] 		[uniqueidentifier] 		NOT NULL,
	[strName]			[nvarchar] (256)		NOT NULL,
	[nMajor]			[bigint]			NOT NULL ,
	[nMinor]			[bigint]			NOT NULL ,
	[dtDeploymentTime]  [datetime]          NOT NULL,
	[dtUnDeployTime]    [datetime]          NULL

	CONSTRAINT dta_RuleSets_unique_RuleSetID			primary key(nRuleSetID)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX dta_RuleSets_index_RuleSetGUID on dta_RuleSets(uidRuleSetGUID)
GO 

CREATE TABLE [dbo].[dta_Rules] (
	[nRuleID]			[bigint]			NOT NULL IDENTITY (1, 1),
	[nRuleSetID]			[bigint]			NOT NULL,
	[strName]			[nvarchar] (256)		NOT NULL,
	[strRule]			[ntext]				NOT NULL 

	CONSTRAINT dta_Rules_unique_RuleID		primary key(nRuleID),
	CONSTRAINT dta_Rules_foreign_RuleSetID		foreign key(nRuleSetID) references dta_RuleSets(nRuleSetID)
) ON [PRIMARY]
GO

CREATE INDEX dta_Rules_index_Rule_RuleSetID on dta_Rules(nRuleID, nRuleSetID)
GO

CREATE TABLE [dbo].[dta_RuleSetEngineAssociation] (
	[nRuleSetEngineAssociationID]	[bigint] 			NOT NULL IDENTITY (1, 1),
	[uidRuleSetEngineAssociationGUID] [uniqueidentifier] 		NOT NULL,
	[nRuleSetID]			[bigint]			NOT NULL,
	[uidRuleEngineID] 		[uniqueidentifier] 		NOT NULL,
	[uidApplicationID] 		[uniqueidentifier] 		NOT NULL,
	[dtTimeStamp] 			[datetime] 			NOT NULL,
	[dtInsertionTimeStamp] 		[datetime] 			NULL CONSTRAINT RuleSetEngineAssociation_InsertionTimeStamp_Dflt DEFAULT (GetUTCDate())	
	
	CONSTRAINT 	dta_RuleSetEngineAssociation_unique_RuleSetEngineAssociationID 	primary key(nRuleSetEngineAssociationID)
	CONSTRAINT	dta_RuleSetEngineAssociation_foreign_RuleSetID		foreign key(nRuleSetID) references dta_RuleSets(nRuleSetID)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX dta_RuleSetEngineAssociation_index_RuleSetEngineAssociationGUID on dta_RuleSetEngineAssociation(uidRuleSetEngineAssociationGUID)
GO 

CREATE INDEX dta_RuleSetEngineAssociation_index_ApplicationID on dta_RuleSetEngineAssociation(uidApplicationID)
GO

CREATE UNIQUE INDEX [IX_RuleSetEngineAssociation] ON [dta_RuleSetEngineAssociation](dtTimeStamp, dtInsertionTimeStamp, nRuleSetEngineAssociationID)
GO

CREATE TABLE [dbo].[dta_RulesFactActivity] (
	[nRulesFactActivityID]		[bigint] 			NOT NULL IDENTITY (1, 1),
	[uidRulesFactActivityGUID]	[uniqueidentifier] 		NOT NULL,
	[nRuleSetEngineAssociationID]	[bigint] 			NOT NULL,
	[strClassName] 			[nvarchar] (256) 		NOT NULL,
	[nClassInstanceID] 		[bigint]			NOT NULL,
	[nActivityType] 		[tinyint]			NOT NULL,
	[dtTimeStamp] 			[datetime] 			NOT NULL,
	[dtInsertionTimeStamp] 		[datetime] 			NULL CONSTRAINT RulesFactActivity_InsertionTimeStamp_Dflt DEFAULT (GetUTCDate())
	
	CONSTRAINT 	dta_RulesFactActivity_unique_RulesFactActivityID 	primary key(nRulesFactActivityID)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX dta_RulesFactActivity_index_RulesFactActivityGUID on dta_RulesFactActivity(uidRulesFactActivityGUID)
GO 

CREATE UNIQUE INDEX dta_RulesFactActivity_index_RuleSetEngineAssociationID on dta_RulesFactActivity(nRuleSetEngineAssociationID, nRulesFactActivityID)
GO 

CREATE UNIQUE INDEX [IX_RulesFactActivity] ON [dta_RulesFactActivity](dtTimeStamp, dtInsertionTimeStamp, nRulesFactActivityID)
GO

CREATE TABLE [dbo].[dta_RulesConditionEvaluation] (
	[nRulesConditionEvaluationID]	[bigint] 			NOT NULL IDENTITY (1, 1),
	[nRuleSetEngineAssociationID]	[bigint] 			NOT NULL,
	[strTextExpression] 		[nvarchar] (256) 		NOT NULL,
	[strLhsClassName] 		[nvarchar] (256) 		NOT NULL,
	[nLhsClassInstanceID] 		[bigint]	 		NOT NULL,
	[strLhsLiteralValue] 		[nvarchar] (256)		NOT NULL,
	[strRhsClassName] 		[nvarchar] (256) 		NOT NULL,
	[nRhsClassInstanceID] 		[bigint]	 		NOT NULL,
	[strRhsLiteralValue] 		[nvarchar] (256)		NOT NULL,
	[bResult] 			[bit]				NOT NULL,
	[dtTimeStamp] 			[datetime] 			NOT NULL,
	[dtInsertionTimeStamp] 		[datetime] 			NULL CONSTRAINT RulesConditionEvaluation_InsertionTimeStamp_Dflt DEFAULT (GetUTCDate())	
	
	CONSTRAINT 	dta_RulesConditionEvaluation_unique_RulesConditionEvaluationID 	primary key(nRulesConditionEvaluationID),
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX [IX_RulesConditionEvaluation] ON [dta_RulesConditionEvaluation](dtTimeStamp, dtInsertionTimeStamp, nRulesConditionEvaluationID)
GO

CREATE UNIQUE INDEX [IX2_RulesConditionEvaluation] ON [dta_RulesConditionEvaluation](nRuleSetEngineAssociationID, nRulesConditionEvaluationID)
GO

CREATE TABLE [dbo].[dta_RulesAgendaUpdates] (
	[nRulesAgendaUpdatesID]		[bigint] 			NOT NULL IDENTITY (1, 1),
	[nRuleSetEngineAssociationID]	[bigint] 			NOT NULL,
	[bAddIndicator] 		[bit]				NOT NULL,
	[nRuleID]			[bigint]			NOT NULL,
	[strConflictResolutionCriteria] [nvarchar] (256)		NOT NULL,
	[dtTimeStamp] 			[datetime] 			NOT NULL,
	[dtInsertionTimeStamp] 		[datetime] 			NULL CONSTRAINT RulesAgendaUpdates_InsertionTimeStamp_Dflt DEFAULT (GetUTCDate())	
	
	CONSTRAINT 	dta_RulesAgendaUpdates_unique_RulesAgendaUpdatesID 	primary key(nRulesAgendaUpdatesID),
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX [IX_RulesAgendaUpdates] ON [dta_RulesAgendaUpdates](dtTimeStamp, dtInsertionTimeStamp, nRulesAgendaUpdatesID)
GO

CREATE UNIQUE INDEX [IX2_RulesAgendaUpdates] ON [dta_RulesAgendaUpdates](nRuleSetEngineAssociationID, nRulesAgendaUpdatesID)
GO

CREATE TABLE [dbo].[dta_RulesFired] (
	[nRulesFiredID]			[bigint] 			NOT NULL IDENTITY (1, 1),
	[nRuleSetEngineAssociationID]	[bigint]			NOT NULL,
	[nRuleID]			[bigint]			NOT NULL,
	[dtTimeStamp] 			[datetime] 			NOT NULL,
	[dtInsertionTimeStamp] 		[datetime] 			NULL CONSTRAINT RulesFired_InsertionTimeStamp_Dflt DEFAULT (GetUTCDate())	
	
	CONSTRAINT 	dta_RulesFired_unique_RulesFiredID 		primary key(nRulesFiredID)
	CONSTRAINT	dta_RulesFired_foreign_RuleSetEngineAssociationID	foreign key(nRuleSetEngineAssociationID) references dta_RuleSetEngineAssociation(nRuleSetEngineAssociationID)
) ON [PRIMARY]
GO

CREATE UNIQUE INDEX [IX_RulesFired] ON [dta_RulesFired](dtTimeStamp, dtInsertionTimeStamp, nRulesFiredID)
GO

CREATE UNIQUE INDEX [IX2_RulesFired] ON [dta_RulesFired](nRuleSetEngineAssociationID, nRulesFiredID)
GO


