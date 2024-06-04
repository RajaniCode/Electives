--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Remove existing global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_removeconstraints
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Remove existing Partner management schema
-- //////////////////////////////////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeschema]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_removeschema
GO

CREATE PROCEDURE [dbo].[bts_removeschema]
AS
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeschema]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[bts_removeschema]
	
	--/---------------------------------------------------------------------------------------------------------------
	--// Partner Management tables
	--/---------------------------------------------------------------------------------------------------------------
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_enlistedparty_operation_mapping]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_enlistedparty_operation_mapping]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_enlistedparty_port_mapping]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_enlistedparty_port_mapping]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_enlistedparty]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_enlistedparty]

	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_orchestration_port_binding]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_orchestration_port_binding]

	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_receiveport_transform]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_receiveport_transform]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_receiveport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_receiveport]
	
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_spg_sendport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_spg_sendport]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_sendportgroup]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_sendportgroup]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_dynamicport_subids]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_dynamicport_subids]
	
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_party_alias]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_party_alias]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_party_sendport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_party_sendport]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_party]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_party]

	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_sendport_transform]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_sendport_transform]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_sendport_transport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_sendport_transport]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_sendport]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_sendport]

	-- Tables to support the application feature
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_application_reference]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_application_reference]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_application]') and OBJECTPROPERTY(id, N'IsUserTable') = 1) drop table [dbo].[bts_application]
GO

--/---------------------------------------------------------------------------------------------------------------
--
-- create tables ordered by referential integrity
--
--/---------------------------------------------------------------------------------------------------------------

--/---------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[bts_application]
(
	nID int identity(1, 1),
	nvcName nvarchar(256) NOT NULL,
	isDefault bit NOT NULL,
	isSystem bit NOT NULL, 
	nvcDescription nvarchar(1024) NULL,
	DateModified datetime NOT NULL,

	CONSTRAINT bts_application_unique_key	primary key(nID),
	CONSTRAINT bts_application_unique_name	unique(nvcName),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_application] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_application] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_application] TO BTS_OPERATORS
GO

--/---------------------------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[bts_application_reference]
(
	nID int identity(1, 1),
	nApplicationID int,
	nReferencedApplicationID int,

	CONSTRAINT bts_applicationreference_unique_key	primary key(nID),
	CONSTRAINT bts_application_reference_unique	unique(nApplicationID, nReferencedApplicationID),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_application_reference] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_application_reference] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_application_reference] TO BTS_OPERATORS
GO

--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_sendport] 
(
	nID							int					NOT NULL IDENTITY (1, 1) ,
	nvcName						nvarchar(256)		NOT NULL ,
	nApplicationTypeId			int					NULL ,
	nvcApplicationTypeData		ntext				NULL ,
	nvcEncryptionCert			ntext				NULL ,
	nvcEncryptionCertHash		nvarchar(256)		NULL ,
	nSendPipelineID				int					NOT NULL ,
	nvcSendPipelineData			ntext				NULL ,
	bDynamic					bit					NOT NULL ,
	bTwoWay						bit					NOT NULL ,
	nReceivePipelineID			int					NULL ,
	nvcReceivePipelineData		ntext				NULL ,
	nTracking					int					NULL ,
	nPortStatus					int					NOT NULL  ,
	nvcFilter					ntext				NOT NULL  ,
	uidGUID						uniqueidentifier    NOT NULL ,
	nvcCustomData				ntext				NULL ,
	nPriority					int					NOT NULL ,
	DateModified				datetime			NOT NULL , 
	nApplicationID				int				NOT NULL,
	nvcDescription				nvarchar(1024)				NULL , 
	bStopSendingOnFailure			bit					NULL ,
	bRouteFailedMessage			bit					NULL ,

	
	CONSTRAINT bts_sendport_unique_key					primary key(nID),
	CONSTRAINT bts_sendport_unique_name					unique(nvcName),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_sendport] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_sendport] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_sendport] TO BTS_OPERATORS
GO

--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_dynamicport_subids]
(
	uidSendPortID uniqueidentifier NOT NULL,
	nSendHandlerID int NOT NULL,
	uidGUID uniqueidentifier NOT NULL DEFAULT NewID(),
	nvcHostName nvarchar(80) NULL
)
GO

--/---------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_sendport_transport] 
(
	nID							int					NOT NULL IDENTITY (1, 1) ,
	nvcAddress					nvarchar(256)		NOT NULL ,
	nTransportTypeId			int					NULL ,
	nvcTransportTypeData		ntext				NULL ,
	bOrderedDelivery			bit					NOT NULL ,
	nDeliveryNotification		int					NOT NULL ,
	nRetryCount					int					NOT NULL ,
	nRetryInterval				int					NOT	NULL ,
	bIsServiceWindow			bit					NOT NULL ,
	dtFromTime					datetime			NOT NULL ,
	dtToTime					datetime			NOT NULL ,
	bIsPrimary					bit					NOT NULL ,
	bSSOMappingExists			bit					NOT NULL ,
	nSendPortID					int					NOT NULL ,
	uidGUID						uniqueidentifier	NULL ,
	DateModified				datetime			NOT NULL ,
	nSendHandlerID				int					NULL ,
	
	CONSTRAINT	bts_sendport_transport_unique_key				primary key(nID),
	CONSTRAINT	bts_sendport_transport_foreign_sendhandlerid	foreign key(nSendHandlerID) references [dbo].[adm_SendHandler](Id),
	CONSTRAINT  bts_sendport_transport_foreign_ownerid			foreign key(nSendPortID) references [dbo].[bts_sendport](nID) ON DELETE CASCADE ,)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_sendport_transport] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_sendport_transport] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_sendport_transport] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_sendport_transform]
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nSendPortID					int					NOT NULL ,
	uidTransformGUID			uniqueidentifier    NOT NULL ,
	bReceive					bit					NOT NULL ,
	nSequence					int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_sendport_transform_unique_key			primary key(nID),
	CONSTRAINT bts_sendport_transform_unique_key2			unique(nSendPortID, uidTransformGUID, bReceive),
	CONSTRAINT bts_sendport_transform_foreign_sendportid	foreign key(nSendPortID) references [dbo].[bts_sendport](nID) ON DELETE CASCADE,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_sendport_transform] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_sendport_transform] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_sendport_transform] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_party] 
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nvcName						nvarchar(256)		NOT NULL ,
	nvcSignatureCert			ntext				NULL ,
	nvcSignatureCertHash		nvarchar(256)		NULL ,
	nvcSID						nvarchar(256)		NOT NULL ,
	nvcCustomData				ntext				NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT	bts_party_unique_key				primary key(nID),
	CONSTRAINT	bts_party_unique_name				unique(nvcName),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_party] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_party] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_party] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_party_alias] 
(
	nID							int					NOT NULL IDENTITY (1, 1) ,
	nPartyID					int					NOT NULL ,
	nvcName						nvarchar(256)		NOT NULL ,
	nvcQualifier				nvarchar(64)		NOT NULL ,
	nvcValue					nvarchar(256)		NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_party_alias_unique_key				primary key(nID),
	CONSTRAINT bts_party_alias_unique_qualifiervalue	unique(nvcQualifier,nvcValue),
	CONSTRAINT bts_party_alias_foreign_ownerid			foreign key(nPartyID) references [dbo].[bts_party](nID) ON DELETE CASCADE ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_party_alias] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_party_alias] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_party_alias] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_party_sendport]
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nPartyID					int					NOT NULL ,
	nSendPortID					int					NOT NULL ,
	nSequence					int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_party_sendport_unique_key			primary key(nID),
	CONSTRAINT bts_party_sendport_unique_key2			unique(nPartyID, nSendPortID),
	CONSTRAINT bts_party_sendport_foreign_partyid		foreign key(nPartyID) references [dbo].[bts_party](nID) ON DELETE CASCADE,
	CONSTRAINT bts_party_sendport_foreign_sendportid	foreign key(nSendPortID) references [dbo].[bts_sendport](nID) ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_party_sendport] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_party_sendport] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_party_sendport] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_sendportgroup]
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nvcName						nvarchar(256)		NOT NULL ,
	nPortStatus					int					NOT NULL  ,
	nvcFilter					ntext				NOT NULL  ,
	uidGUID						uniqueidentifier    NOT NULL ,
	nvcCustomData				ntext				NULL ,
	DateModified				datetime			NOT NULL ,
	nApplicationID				int				NOT NULL,
	nvcDescription				nvarchar(1024)				NULL , 
	
	CONSTRAINT bts_spg_unique_key					primary key(nID),
	CONSTRAINT bts_spg_unique_name					unique(nvcName),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_sendportgroup] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_sendportgroup] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_sendportgroup] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_spg_sendport] 
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nSendPortGroupID			int					NOT NULL ,
	nSendPortID					int					NOT NULL ,
	uidPrimaryGUID				uniqueidentifier    NOT NULL ,
	uidSecondaryGUID			uniqueidentifier    NOT NULL ,
	nSequence					int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_spg_sendport_unique_key				primary key(nID),
	CONSTRAINT bts_spg_sendport_unique_key2				unique(nSendPortGroupID, nSendPortID),
	CONSTRAINT bts_spg_sendport_foreign_spgid			foreign key(nSendPortGroupID) references [dbo].[bts_sendportgroup](nID) ON DELETE CASCADE,
	CONSTRAINT bts_spg_sendport_foreign_sendportid		foreign key(nSendPortID) references [dbo].[bts_sendport](nID) ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_spg_sendport] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_spg_sendport] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_spg_sendport] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_receiveport] 
(
	nID							int					NOT NULL IDENTITY (1, 1) ,
	nvcName						nvarchar (256)		NOT NULL ,
	bTwoWay						bit					NOT NULL ,
	nAuthentication				int					NOT NULL ,
	nSendPipelineId				int					NULL ,
	nvcSendPipelineData			ntext				NULL ,
	nTracking					int					NULL ,
	uidGUID						uniqueidentifier    NOT NULL ,
	nvcCustomData				ntext				NULL ,
	DateModified				datetime			NOT NULL ,
	nApplicationID				int				NOT NULL,
	nvcDescription				nvarchar(1024)				NULL , 
	bRouteFailedMessage			bit					NULL DEFAULT(0),
	
	CONSTRAINT bts_receiveport_unique_key					primary key(nID),
	CONSTRAINT bts_receiveport_unique_name					unique(nvcName),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_receiveport] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_receiveport] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_receiveport] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_receiveport_transform]
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nReceivePortID				int					NOT NULL ,
	uidTransformGUID			uniqueidentifier    NOT NULL ,
	bTransmit					bit					NOT NULL ,
	nSequence					int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_receiveport_transform_unique_key				primary key(nID),
	CONSTRAINT bts_receiveport_transform_unique_key2			unique(nReceivePortID, uidTransformGUID, bTransmit),
	CONSTRAINT bts_receiveport_transform_foreign_receiveportid	foreign key(nReceivePortID) references [dbo].[bts_receiveport](nID) ON DELETE CASCADE,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_receiveport_transform] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_receiveport_transform] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_receiveport_transform] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_orchestration_port_binding] 
(
	nID							int					NOT NULL IDENTITY (1, 1) ,
	nOrcPortID					int					NOT	NULL ,
	nReceivePortID				int					NULL ,
	nSendPortID					int					NULL ,
	nSpgID						int					NULL ,
	DateModified				datetime			NOT NULL , 
	
	CONSTRAINT bts_orchestration_port_unique_key					primary key(nID),
	CONSTRAINT bts_orchestration_port_foreign_receiveportid			foreign key(nReceivePortID) references [dbo].[bts_receiveport](nID) ,
	CONSTRAINT bts_orchestration_port_foreign_sendportid			foreign key(nSendPortID) references [dbo].[bts_sendport](nID) ,
	CONSTRAINT bts_orchestration_port_foreign_spgid					foreign key(nSpgID) references [dbo].[bts_sendportgroup](nID) ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_orchestration_port_binding] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_orchestration_port_binding] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_orchestration_port_binding] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_enlistedparty] 
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nRoleID						int					NOT NULL ,
	nPartyID					int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_enlistedparty_unique_key				primary key(nID),
	CONSTRAINT bts_enlistedparty_role_unique_key		unique(nRoleID, nPartyID),
	CONSTRAINT bts_enlistedparty_foreign_partyid		foreign key(nPartyID) references [dbo].[bts_party](nID),
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_enlistedparty] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_enlistedparty_port_mapping] 
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nRolePortTypeID				int					NOT NULL ,
	nEnlistedPartyID			int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_enlistedparty_port_mapping_unique_key		primary key(nID),
	CONSTRAINT bts_enlistedparty_portmapping_foreign_ownerid   	foreign key(nEnlistedPartyID) references [dbo].[bts_enlistedparty](nID) ON DELETE CASCADE ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_enlistedparty_port_mapping] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty_port_mapping] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty_port_mapping] TO BTS_OPERATORS
GO
--/---------------------------------------------------------------------------------------------------------------

CREATE TABLE [dbo].[bts_enlistedparty_operation_mapping] 
(
	nID							int					NOT NULL IDENTITY (1, 1),
	nOperationID				int					NOT NULL ,
	nPartySendPortID			int					NOT NULL ,
	nPortMappingID				int					NOT NULL ,
	DateModified				datetime			NOT NULL ,
	
	CONSTRAINT bts_enlistedparty_operation_mapping_unique_key			primary key(nID),
	CONSTRAINT bts_enlistedparty_mapping_foreign_party_sendportid		foreign key(nPartySendPortID) references [dbo].[bts_party_sendport](nID),
	CONSTRAINT bts_enlistedparty_mapping_foreign_portmappingid			foreign key(nPortMappingID) references [dbo].[bts_enlistedparty_port_mapping](nID) ON DELETE CASCADE ,
)
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON [dbo].[bts_enlistedparty_operation_mapping] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty_operation_mapping] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_enlistedparty_operation_mapping] TO BTS_OPERATORS
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Re-apply global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_addconstraints
GO


CREATE TRIGGER bts_removesubids on [dbo].[bts_sendport]
AFTER DELETE
AS
	SET NOCOUNT ON

	DELETE FROM bts_dynamicport_subids
	FROM bts_dynamicport_subids dps, deleted d
	WHERE d.uidGUID = dps.uidSendPortID
GO
