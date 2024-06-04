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
-- 
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_removeconstraints
GO

------------------------------------------------------------------------

-- Delete Views
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btsv_VersionIndependentOrchestration]') and OBJECTPROPERTY(id, N'IsView') = 1) drop view [dbo].[btsv_VersionIndependentOrchestration]

-- Delete Tables
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_DocumentSpec]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_DocumentSpec]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_MapSpec]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_MapSpec]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_Properties]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_Properties]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_SensitiveProperties]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_SensitiveProperties]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_XMLShare]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_XMLShare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_XMLShareReferences]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bt_XMLShareReferences]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_itemreference]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_itemreference]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_item]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_item]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_libreference]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_libreference]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_assembly]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_assembly]
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_role]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
ALTER TABLE [dbo].[bts_rolelink] DROP CONSTRAINT [FK_bts_rolelink_bts_role]
ALTER TABLE [dbo].[bts_role_porttype] DROP CONSTRAINT [FK_bts_role_porttype_bts_role]
drop table [dbo].[bts_role]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_rolelink_type]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_rolelink_type]
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_porttype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
ALTER TABLE [dbo].[bts_orchestration_port] DROP CONSTRAINT [FK_bts_orchestration_port_bts_porttype]
ALTER TABLE [dbo].[bts_role_porttype] DROP CONSTRAINT [FK_bts_role_porttype_bts_porttype]
ALTER TABLE [dbo].[bts_porttype_operation] DROP CONSTRAINT [FK_bts_porttype_operation_bts_porttype]
drop table [dbo].[bts_porttype]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_role_porttype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_role_porttype]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_porttype_operation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
ALTER TABLE [dbo].[bts_operation_msgtype] DROP CONSTRAINT [FK_bts_operation_msgtype_bts_porttype_operation]
ALTER TABLE [dbo].[bts_port_activation_operation] DROP CONSTRAINT[FK_bts_port_activation_operation_bts_porttype_operation]
drop table [dbo].[bts_porttype_operation]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_messagetype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
ALTER TABLE [dbo].[bts_messagetype_part] DROP CONSTRAINT [FK_bts_msgtype_part_bts_messagetype]
drop table [dbo].[bts_messagetype]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_messagetype_part]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_messagetype_part]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_operation_msgtype]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_operation_msgtype]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_orchestration]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
ALTER TABLE [dbo].[bts_orchestration_port] DROP CONSTRAINT [FK_bts_orchestration_port_bts_orchestration]
ALTER TABLE [dbo].[bts_rolelink] DROP CONSTRAINT [FK_bts_rolelink_bts_orchestration]
ALTER TABLE [dbo].[bts_orchestration_invocation] DROP CONSTRAINT [FK_bts_orchestration_invocation_bts_orchestration]
ALTER TABLE [dbo].[bts_port_activation_operation] DROP CONSTRAINT [FK_bts_port_activation_operation_bts_orchestration]
drop table [dbo].[bts_orchestration]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_rolelink]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_rolelink]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_orchestration_port]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_orchestration_port]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_port_activation_operation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
begin
drop table [dbo].[bts_port_activation_operation]
end
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_orchestration_invocation]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_orchestration_invocation]
GO


--if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_transformservice_msg]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
--drop table [dbo].[bts_transformservice_msg]
--GO

-- Tables used in Cross-Referencing (XREF) service
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_AppType]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_AppType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_AppInstance]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_AppInstance]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_IDXRef]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_IDXRef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_IDXRefData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_IDXRefData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_ValueXRef]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_ValueXRef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_ValueXRefData]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_ValueXRefData]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_MessageArguments]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_MessageArgument]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_MessageDef]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_MessageDef]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_MessageText]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[xref_MessageText]
GO
-- End of -- Tables used in Cross-Referencing (XREF) service

CREATE TABLE [dbo].[bt_DocumentSpec] (
	[id] [uniqueidentifier] NOT NULL ,
	[itemid] [int] NOT NULL ,
	[assemblyid] [int] NOT NULL ,
	[shareid] [uniqueidentifier] NULL ,
	[msgtype] [nvarchar] (2048) NOT NULL ,
	[date_modified] [datetime] NOT NULL ,
	[body_xpath] [nvarchar] (2421) NULL,
	[is_property_schema] [bit] NOT NULL,
	[is_multiroot] [bit] NOT NULL,
	[clr_namespace] [nvarchar] (256) NULL,
	[clr_typename] [nvarchar] (256) NULL,
	[clr_assemblyname] [nvarchar] (512) NULL,
	[schema_root_name] [nvarchar] (2000) NULL,
	[xsd_type] [nvarchar] (30) NULL,
	[is_tracked] [bit] NOT NULL,
	-- Computed fields follow
	[docspec_name] AS ( ( CASE WHEN [clr_namespace] <> N'' THEN ([clr_namespace] + N'.') ELSE N'' END ) + [clr_typename] ),
	[property_clr_class_fqn] AS CASE is_property_schema 
									WHEN 1 THEN ( CASE WHEN [clr_namespace] <> N'' THEN ([clr_namespace] + N'.') ELSE N'' END ) + 
												property_clr_class +
												N',' + [clr_assemblyname]
									ELSE N''
								END,
	[schema_root_clr_fqn] AS ( ( CASE WHEN [clr_namespace] <> N'' THEN ([clr_namespace] + N'.') ELSE N'' END ) + [clr_typename] ),
	[is_flat] [bit] NOT NULL,
	[property_clr_class] [nvarchar] (2000) NULL,
	[description] [nvarchar] (1024) NULL
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bt_DocumentSpec] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bt_DocumentSpec] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bt_DocumentSpec] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bt_MapSpec] (
	[id] [uniqueidentifier] NOT NULL ,
	[itemid] [int] NOT NULL ,
	[assemblyid] [int] NOT NULL ,
	[shareid] [uniqueidentifier] NULL ,
	[indoc_namespace] [nvarchar] (256) NULL ,
	[outdoc_namespace] [nvarchar] (256) NULL ,
	[indoc_docspec_name] [nvarchar] (256) NULL ,
	[outdoc_docspec_name] [nvarchar] (256) NULL ,
	[date_modified] [datetime] NOT NULL ,
	[description] [nvarchar] (1024) NULL 
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bt_MapSpec] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bt_MapSpec] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bt_MapSpec] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bt_Properties] (
	[id] [uniqueidentifier] NOT NULL ,
	[propSchemaID] [uniqueidentifier] NOT NULL, /* Points to property definition row in bt_DocumentSpec */
	[nAssemblyID] [int] NULL ,
	[msgtype] [nvarchar] (2048) NOT NULL ,
	[namespace] [nvarchar] (256) NOT NULL ,
	[name] [nvarchar] (2048) NOT NULL ,
	[xpath] [nvarchar] (3357) NULL,
	[is_tracked] [bit] NOT NULL,
	[itemid] [int] NOT NULL
) ON [PRIMARY]
GO
GRANT SELECT, UPDATE ON [dbo].[bt_Properties] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bt_Properties] TO BTS_OPERATORS
GO

CREATE TABLE dbo.[bt_SensitiveProperties]
	(
	id int IDENTITY (1, 1) NOT NULL ,
	msgtype char(2000) NULL,
	assemblyid int NOT NULL
	)  ON [PRIMARY]
GO
GRANT SELECT, UPDATE ON [dbo].[bt_SensitiveProperties] TO BTS_ADMIN_USERS
GO


CREATE TABLE [dbo].[bt_XMLShare] (
	[id] [uniqueidentifier] NOT NULL ,
	[active] [tinyint] NOT NULL,
	[target_namespace] [nvarchar] (256) NULL ,
	[date_modified] [datetime] NULL ,
	[content] [ntext] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GRANT SELECT ON [dbo].[bt_XMLShare] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bt_XMLShare] TO BTS_OPERATORS
GO

CREATE NONCLUSTERED INDEX IX_bt_XMLShare ON dbo.bt_XMLShare
	(
	id,
	active
	) ON [PRIMARY]

--// To avoid index scan
CREATE NONCLUSTERED INDEX IX_bt_XMLShare_target_namespace ON dbo.bt_XMLShare
	(
	target_namespace,
	active
	) ON [PRIMARY]

CREATE CLUSTERED INDEX [IX_bt_DocumentSpec_clr_namespace] ON [dbo].[bt_DocumentSpec]
	(
	[clr_namespace]
	) ON [PRIMARY]		

CREATE NONCLUSTERED INDEX [IX_bt_DocumentSpec_msgtype] ON [dbo].[bt_DocumentSpec] 
(
	[msgtype] ASC,
	[assemblyid] ASC,
	[shareid] ASC
)
GO

CREATE TABLE [dbo].[bt_XMLShareReferences] (
	[shareid] [uniqueidentifier] NOT NULL ,
	[target_namespace] [nvarchar] (256) NOT NULL
) ON [PRIMARY] 
GO

CREATE CLUSTERED INDEX IX_bt_XMLShareReferences ON dbo.bt_XMLShareReferences
	(
	shareid
	) ON [PRIMARY]

CREATE TABLE [dbo].[bts_itemreference] (
	[nReferringAssemblyID] [int] NOT NULL ,
	[nvcAssemblyName] [nvarchar] (256) NOT NULL ,
	[nvcVersionMajor] [nvarchar] (12) NOT NULL ,
	[nvcVersionMinor] [nvarchar] (12) NOT NULL ,
	[nvcVersionBuild] [nvarchar] (12) NOT NULL ,
	[nvcVersionRevision] [nvarchar] (12) NOT NULL ,
	[nvcItemName] [nvarchar] (256) NOT NULL,
	[nvcCulture] [nvarchar] (25) NOT NULL ,
	[nvcPublicKeyToken] [nvarchar] (256) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_item] (
	[id] [int] IDENTITY (1, 1) NOT NULL ,
	[AssemblyId] [int] NOT NULL ,
	[Namespace] [nvarchar] (256) NULL ,
	[Name] [nvarchar] (256) NOT NULL ,
	[FullName] AS CASE  
						WHEN [Namespace] IS NULL THEN [Name]
						ELSE [Namespace] + N'.' + [Name]
					END ,
	[Type] [nvarchar] (50) NOT NULL ,
	[IsPipeline] [tinyint] NULL,
	[Guid] [uniqueidentifier] NULL,
	[SchemaType] [tinyint] NULL,
	[description] [nvarchar] (1024) NULL
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_item] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_item] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_item] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_libreference] (
	[idapp] [int] NOT NULL ,
	[idlib] [int] NOT NULL ,
	[refName] [nvarchar] (256) NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_assembly] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcVersion] [nvarchar] (256) NOT NULL ,
	[nvcCulture] [nvarchar] (256) NULL ,
	[nvcPublicKeyToken] [nvarchar] (256) NULL ,
	[nvcFullName] [nvarchar] (256) NOT NULL ,
	[nVersionMajor] [int] NOT NULL ,
	[nVersionMinor] [int] NOT NULL ,
	[nVersionBuild] [int] NOT NULL ,
	[nVersionRevision] [int] NOT NULL ,
	[dtDateModified] [datetime] NOT NULL ,
	[nvcModifiedBy] [nvarchar] (64) NOT NULL ,
	[nType] [int] NOT NULL ,
	[nGroupId] [int] NULL ,
	[nvcDescription] [nvarchar] (256) NULL ,
	[nvcIdentity] [nvarchar] (256) NULL ,
	[nvcType] [nvarchar] (256) NULL ,
	[nStrongName] [tinyint] NULL ,
	[ntxtModuleXML] [ntext] NULL ,
	[imgTrackingProfile] [image] NULL,
	[nSystemAssembly] [int] NOT NULL, -- Value of 1 here means assembly cannot be undeployed
	[nApplicationID] [int] NOT NULL,  -- temporary, used in development
	
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
GRANT SELECT, UPDATE ON [dbo].[bts_assembly] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_assembly] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_assembly] TO BTS_OPERATORS

GO


CREATE TABLE [dbo].[bts_rolelink_type] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nAssemblyID] [int] NOT NULL ,
	[nvcNamespace] [nvarchar] (256) NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] AS CASE  
						WHEN [nvcNamespace] IS NULL THEN [nvcName]
						ELSE [nvcNamespace] + N'.' + [nvcName]
					END 
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_rolelink_type] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_rolelink_type] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_rolelink_type] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_role] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] [nvarchar] (256) NULL ,
	[nRoleLinkTypeID] [int] NOT NULL ,
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_role] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_role] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_role] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_role_porttype] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nRoleID] [int] NOT NULL ,
	[nPortTypeID] [int] NOT NULL ,
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_role_porttype] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_role_porttype] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_role_porttype] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_porttype] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nAssemblyID] [int] NOT NULL ,
	[nvcNamespace] [nvarchar] (256) NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] AS CASE  
						WHEN [nvcNamespace] IS NULL THEN [nvcName]
						ELSE [nvcNamespace] + N'.' + [nvcName]
					END 
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_porttype] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_porttype] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_porttype] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_porttype_operation] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nPortTypeID] [int] NOT NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] [nvarchar] (256) NULL ,
	[nType] [int] NOT NULL -- One-Way or Request-Response
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_porttype_operation] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_porttype_operation] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_porttype_operation] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_messagetype] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nAssemblyID] [int] NOT NULL ,
	[nvcNamespace] [nvarchar] (256) NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] AS CASE  
						WHEN [nvcNamespace] IS NULL THEN [nvcName]
						ELSE [nvcNamespace] + N'.' + [nvcName]
					END 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_messagetype_part] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nMessageTypeID] [int] NOT NULL ,
	[nvcNamespace] [nvarchar] (256) NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] AS CASE  
						WHEN [nvcNamespace] IS NULL THEN [nvcName]
						ELSE [nvcNamespace] + N'.' + [nvcName]
					END ,
	[nvcSchemaURTNameSpace] [nvarchar] (256) NULL,
	[nvcSchemaURTTypeName] [nvarchar] (256) NULL,
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_operation_msgtype] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nOperationID] [int] NOT NULL ,
	[nMessageTypeID] [int] NOT NULL ,
	[nType] [int] NOT NULL -- Input, Output or Fault
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_orchestration] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[uidGUID] [uniqueidentifier] NULL ,
	[uidOrchestrationType] [uniqueidentifier] NULL ,
	[nAssemblyID] [int] NOT NULL ,
	[nItemID] [int] NULL ,
	[nvcNamespace] [nvarchar] (256) NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] AS CASE  
						WHEN [nvcNamespace] IS NULL THEN [nvcName]
						ELSE [nvcNamespace] + N'.' + [nvcName]
					END ,
	[nOrchestrationInfo] [int] NOT NULL ,
	[nOrchestrationStatus] [int] NOT NULL ,
	[nAdminHostID] [int] NULL ,
	[dtModified] datetime NOT NULL ,
	[nvcDescription] [nvarchar] (1024) NULL
) ON [PRIMARY]
GO
GRANT SELECT, UPDATE ON [dbo].[bts_orchestration] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_orchestration] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_orchestration] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_rolelink] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nvcFullName] [nvarchar] (256) NULL ,
	[nOrchestrationID] [int] NOT NULL , 
	[nRoleID] [int] NOT NULL  ,
	[bImplements] [bit] NOT NULL, -- Implements or Uses
	[nBindingType] [int] NOT NULL -- Static or Dynamic (applies only if bImplements = false)
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_rolelink] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_rolelink] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_rolelink] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_orchestration_port] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[uidGUID] [uniqueidentifier] NULL ,
	[nOrchestrationID] [int] NOT NULL ,
	[nPortTypeID] [int] NOT NULL ,
	[nvcName] [nvarchar] (256) NOT NULL ,
	[nPolarity] [int] NOT NULL ,
	[nBindingOption] [int] NOT NULL ,
	[nRolePortTypeID] [int] NULL ,
	[bLink] [bit] NOT NULL -- True for ports created from Uses Role porttypes, 
							-- indicating not to surface them in Explorer for service binding
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_orchestration_port] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_orchestration_port] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_orchestration_port] TO BTS_OPERATORS
GO



CREATE TABLE [dbo].[bts_port_activation_operation] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nOrchestrationID] [int] NOT NULL ,
	[nPortID] [int] NOT NULL ,
	[nOperationID] [int] 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[bts_orchestration_invocation] (
	[nID] [int] IDENTITY (1, 1) NOT NULL ,
	[nOrchestrationID] [int] NOT NULL ,
	[nInvokedOrchestrationID] [int] NOT NULL ,
	[nInvokeType] [tinyint] NOT NULL /* 0 - invalid, 1 - call, 2 - exec */
) ON [PRIMARY]
GO
GRANT SELECT ON [dbo].[bts_orchestration_invocation] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_orchestration_invocation] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[bts_orchestration_invocation] TO BTS_OPERATORS
GO

------------------------------- Constraints definition -----------------------------------


ALTER TABLE [dbo].[bts_assembly] WITH NOCHECK ADD 
	CONSTRAINT [DF_bts_assembly_nvcCulture] DEFAULT (N'neutral') FOR [nvcCulture],
	CONSTRAINT [DF_bts_assembly_nvcPublicKeyToken] DEFAULT (N'') FOR [nvcPublicKeyToken],
	CONSTRAINT [DF_bts_assembly_nvcDescription] DEFAULT (N'') FOR [nvcDescription],
	CONSTRAINT [DF_bts_assembly_nvcIdentity] DEFAULT (N'') FOR [nvcIdentity],
	CONSTRAINT [DF_bts_assembly_nvcType] DEFAULT (N'Assembly') FOR [nvcType],
	CONSTRAINT [DF_bts_assembly_nStrongName] DEFAULT (1) FOR [nStrongName],
	CONSTRAINT [DF_bts_assembly_nSystemAssembly] DEFAULT (0) FOR [nSystemAssembly],
	CONSTRAINT [PK_bts_assembly] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] 
GO

CREATE NONCLUSTERED INDEX [IX_bts_assembly] ON [dbo].[bts_assembly] 
(
	[nvcName] ASC,
	[nVersionMajor] ASC,
	[nVersionMinor] ASC,
	[nVersionBuild] ASC,
	[nVersionRevision] ASC,
	[nID] ASC
)
GO

ALTER TABLE [dbo].[bts_item] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_item] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY], 
	CONSTRAINT [FK_bts_item_bts_assembly] 
	FOREIGN KEY ([AssemblyId]) 
		REFERENCES [bts_assembly]([nID]) 
GO


ALTER TABLE [dbo].[bts_orchestration] WITH NOCHECK ADD 
	CONSTRAINT [DF_bts_service_nOrchestrationInfo] DEFAULT (0) FOR [nOrchestrationInfo],
	CONSTRAINT [DF_bts_service_nOrchestrationStatus] DEFAULT (0) FOR [nOrchestrationStatus],
	CONSTRAINT [PK_bts_orchestration] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	) ON [PRIMARY] ,
	CONSTRAINT [IX_bts_orchestration_GUID] UNIQUE NONCLUSTERED 
	(
	uidGUID
	) ON [PRIMARY]

 
GO

ALTER TABLE [dbo].[bts_porttype] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_porttype] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY]
GO


ALTER TABLE [dbo].[bts_orchestration_port] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_orchestration_port] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_orchestration_port_bts_orchestration] 
	FOREIGN KEY ([nOrchestrationID]) 
		REFERENCES [bts_orchestration]([nID]) 
		ON DELETE CASCADE,
	CONSTRAINT [FK_bts_orchestration_port_bts_porttype] 
	FOREIGN KEY ([nPortTypeID]) 
		REFERENCES [bts_porttype]([nID]) ,
	CONSTRAINT [IX_bts_orchestration_port] UNIQUE NONCLUSTERED 
	(
	uidGUID
	) ON [PRIMARY]


GO

ALTER TABLE [dbo].[bts_orchestration_invocation] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_orchestration_invocation] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_orchestration_invocation_bts_orchestration] 
	FOREIGN KEY ([nOrchestrationID]) 
		REFERENCES [bts_orchestration]([nID]) 
		ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bts_rolelink_type] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_rolelink_type] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY]
GO


ALTER TABLE [dbo].[bts_role] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_role] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY],
	CONSTRAINT [FK_bts_role_bts_rolelink_type] 
	FOREIGN KEY ([nRoleLinkTypeID]) 
		REFERENCES [bts_rolelink_type]([nID]) 
		ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bts_role_porttype] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_role_porttype] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_role_porttype_bts_role] 
	FOREIGN KEY ([nRoleID]) 
		REFERENCES [bts_role]([nID]) 
		ON DELETE CASCADE,
	CONSTRAINT [FK_bts_role_porttype_bts_porttype] 
	FOREIGN KEY ([nPortTypeID]) 
		REFERENCES [bts_porttype]([nID]) 
GO


ALTER TABLE [dbo].[bts_porttype_operation] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_porttype_operation] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_porttype_operation_bts_porttype] 
	FOREIGN KEY ([nPortTypeID]) 
		REFERENCES [bts_porttype]([nID]) 
		ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bts_port_activation_operation] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_port_activation_operation] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_port_activation_operation_bts_orchestration] 
	FOREIGN KEY ([nOrchestrationID]) 
		REFERENCES [bts_orchestration]([nID]) 
		ON DELETE CASCADE,
	CONSTRAINT [FK_bts_port_activation_operation_bts_porttype_operation] 
	FOREIGN KEY ([nOperationID]) 
		REFERENCES [bts_porttype_operation]([nID]) 

GO

ALTER TABLE [dbo].[bts_messagetype] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_messagetype] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY]
GO


ALTER TABLE [dbo].[bts_messagetype_part] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_messagetype_part] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_msgtype_part_bts_messagetype] 
		FOREIGN KEY ([nMessageTypeID]) 
			REFERENCES [bts_messagetype]([nID]) 
			ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bts_operation_msgtype] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_operation_msgtype] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_operation_msgtype_bts_porttype_operation] 
		FOREIGN KEY ([nOperationID]) 
			REFERENCES [bts_porttype_operation]([nID]) 
			ON DELETE CASCADE
	
GO

ALTER TABLE [dbo].[bts_rolelink] WITH NOCHECK ADD 
	CONSTRAINT [PK_bts_rolelink] PRIMARY KEY  CLUSTERED 
	(
		[nID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bts_rolelink_bts_orchestration] 
	FOREIGN KEY ([nOrchestrationID]) 
		REFERENCES [bts_orchestration]([nID]) 
		ON DELETE CASCADE,
	CONSTRAINT [FK_bts_rolelink_bts_role] 
	FOREIGN KEY ([nRoleID]) 
		REFERENCES [bts_role]([nID]) 
GO

----------------------------- XML schema/map related tables ---------------------------------

ALTER TABLE [dbo].[bt_XMLShare] WITH NOCHECK ADD 
	CONSTRAINT [DF_bt_XMLShare_id] DEFAULT (newid()) FOR [id],
	CONSTRAINT [DF_bt_XMLShare_date_modified] DEFAULT (getutcdate()) FOR [date_modified],
	CONSTRAINT [PK_bt_XMLShare] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[bt_XMLShareReferences] WITH NOCHECK ADD 
	CONSTRAINT [FK_bt_XMLShareReferences_bt_XMLShare] 
	FOREIGN KEY ([shareid]) 
		REFERENCES [bt_XMLShare]([id]) 
		ON DELETE CASCADE
	
GO

ALTER TABLE [dbo].[bt_DocumentSpec] WITH NOCHECK ADD 
	CONSTRAINT [DF_bt_DocumentSpec_id] DEFAULT (newid()) FOR [id],
	CONSTRAINT [DF_bt_DocumentSpec_is_tracked] DEFAULT (0) FOR [is_tracked],
	CONSTRAINT [DF_bt_DocumentSpec_is_multiroot] DEFAULT (0) FOR [is_multiroot],
	CONSTRAINT [DF_bt_DocumentSpec_is_property_schema] DEFAULT (0) FOR [is_property_schema],
	CONSTRAINT [DF_bt_DocumentSpec_is_flat] DEFAULT (0) FOR [is_flat],
	CONSTRAINT [DF_bt_DocumentSpec_date_modified] DEFAULT (getutcdate()) FOR [date_modified],
	CONSTRAINT [FK_bt_DocumentSpec_bt_XMLShare] 
	FOREIGN KEY ([shareid]) 
		REFERENCES [bt_XMLShare]([id]) ,
	CONSTRAINT [FK_bt_DocumentSpec_bts_item] 
	FOREIGN KEY ([itemid]) 
		REFERENCES [bts_item]([id]) ,
	CONSTRAINT [FK_bt_DocumentSpec_bts_assembly] 
	FOREIGN KEY ([assemblyid]) 
		REFERENCES [bts_assembly]([nID]) 
		ON DELETE CASCADE

--//QFE 1442
         CREATE  INDEX [IX_bt_DocumentSpec] ON [dbo].[bt_DocumentSpec]([id]) ON [PRIMARY]

--// Add missing index on shareid, for avoiding table scan when joining with bt_XMLShare
		
CREATE NONCLUSTERED INDEX [IX_bt_DocumentSpec_shareid] ON [dbo].[bt_DocumentSpec]
	(
	[shareid]
	) ON [PRIMARY]		
GO

ALTER TABLE [dbo].[bt_MapSpec] WITH NOCHECK ADD 
	CONSTRAINT [DF_bt_MapSpec_id] DEFAULT (newid()) FOR [id],
	CONSTRAINT [DF_bt_MapSpec_date_modified] DEFAULT (getutcdate()) FOR [date_modified],
	CONSTRAINT [PK_bt_MapSpec] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bt_MapSpec_bt_XMLShare] 
	FOREIGN KEY ([shareid]) 
		REFERENCES [bt_XMLShare]([id]) ,
	CONSTRAINT [FK_bt_MapSpec_bts_item] 
	FOREIGN KEY ([itemid]) 
		REFERENCES [bts_item]([id]) ,
	CONSTRAINT [FK_bt_MapSpec_bts_assembly] 
	FOREIGN KEY ([assemblyid]) 
		REFERENCES [bts_assembly]([nID]) 
		ON DELETE CASCADE
GO

ALTER TABLE [dbo].[bt_Properties] WITH NOCHECK ADD 
	CONSTRAINT [DF_bt_Properties_id] DEFAULT (newid()) FOR [id],
	CONSTRAINT [DF_bt_Properties_is_tracked] DEFAULT (0) FOR [is_tracked],
	CONSTRAINT [PK_bt_Properties] PRIMARY KEY  CLUSTERED 
	(
		[id]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_bt_Properties_bts_assembly] 
	FOREIGN KEY ([nAssemblyID]) 
		REFERENCES [bts_assembly]([nID]) 
		ON DELETE CASCADE
GO

ALTER TABLE dbo.[bt_SensitiveProperties] ADD CONSTRAINT
	PK_bt_SensitiveProperties PRIMARY KEY CLUSTERED 
	(
	id
	) ON [PRIMARY]

GO
ALTER TABLE dbo.[bt_SensitiveProperties] ADD CONSTRAINT
	FK_bt_SensitiveProperties_bts_assembly FOREIGN KEY
	(
	assemblyid
	) REFERENCES dbo.[bts_assembly]
	(
	nID
	) ON DELETE CASCADE
	
GO


-- ///////////////////////////////////////////////////////////////////////
-- This view is used by admin stored procedures.  It joins the bts_assembly
-- and bts_orchestration tables, but collapse the recordset so that the results
-- will be version independent.
-- ///////////////////////////////////////////////////////////////////////
CREATE VIEW [dbo].[btsv_VersionIndependentOrchestration] WITH SCHEMABINDING
AS
SELECT
	MAX(svc.nID) 'nOrchestrationID',
	MAX(svc.nvcFullName) 'nvcOrchestrationName',
	MAX(mod.nvcName) 'nvcAssemblyName',
	MAX(mod.nvcCulture) 'nvcAssemblyCulture',
	MAX(mod.nvcPublicKeyToken) 'nvcAssemblyPublicKeyToken',
	MAX(mod.nvcFullName) 'nvcAssemblyFullName',
	MAX(mod.dtDateModified) 'dtDateModified',
	MAX(mod.nGroupId) 'nAdminGroupId',
	MAX(svc.nAdminHostID) 'nAdminHostID',
	MAX(svc.nOrchestrationStatus) 'nOrchestrationStatus'
FROM
	[dbo].[bts_orchestration] svc,
	[dbo].[bts_assembly] mod
WHERE
	svc.nAssemblyID =  mod.nID
GROUP BY
	svc.nID
GO

-----------------------------Cross-Referencing Service (XREF)------------------------------
-- The following are tables used in XREF 
-------------------------------------------------------------------------------------------
CREATE TABLE [dbo].[xref_AppInstance] (
	[appInstanceID] [int] IDENTITY (1, 1) NOT NULL ,
	[appInstance] [nvarchar] (50) NOT NULL ,
	[appTypeID] [int] NOT NULL ,
	CONSTRAINT [PK_xref_appInstance] PRIMARY KEY  CLUSTERED 
	(
		[appInstanceID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO
CREATE INDEX [IX_AppInst1] ON [dbo].[xref_AppInstance] ([appInstance]) ON [PRIMARY]
GO


CREATE TABLE [dbo].[xref_AppType] (
	[appTypeID] [int] IDENTITY (1, 1) NOT NULL ,
	[appType] [nvarchar] (50) NOT NULL ,
	CONSTRAINT [PK_xref_AppType] PRIMARY KEY  CLUSTERED 
	(
		[appType]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[xref_IDXRef] (
	[idXRefID] [int] IDENTITY (1, 1) NOT NULL ,
	[idXRef] [nvarchar] (50) NOT NULL ,
	CONSTRAINT [PK_xref_IDXRef] PRIMARY KEY  CLUSTERED 
	(
		[idXRefID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO
CREATE INDEX [IX_xref_IDXRef_1] ON [dbo].[xref_IDXRef] ([idXRef]) ON [PRIMARY]
GO
INSERT INTO [dbo].[xref_IDXRef] (idXRef)
VALUES (N'')
GO


CREATE TABLE [dbo].[xref_IDXRefData] (
	[idXRefID] [int] NOT NULL ,
	[appInstanceID] [int] NOT NULL ,
	[appID] [nvarchar] (255) NOT NULL ,
	[commonID] [nvarchar] (50) NOT NULL 
) ON [PRIMARY]
GO

CREATE CLUSTERED INDEX [CIX_xref_IDXRefData] ON [dbo].[xref_IDXRefData]([idXRefID], [appInstanceID], [appID], [commonID]) ON [PRIMARY]
GO

ALTER TABLE [dbo].[xref_IDXRefData] ADD 
	CONSTRAINT [IX_xref_IDXRefData_appID] UNIQUE  NONCLUSTERED 
	(
		[appID],
		[idXRefID],
		[appInstanceID]
	)  ON [PRIMARY] ,
	CONSTRAINT [IX_xref_IDXRefData_commonID] UNIQUE  NONCLUSTERED 
	(
		[commonID],
		[idXRefID],
		[appInstanceID]
	)  ON [PRIMARY] 
GO

CREATE TABLE [dbo].[xref_MessageArgument] (
	[msgID] [int] NOT NULL ,
	[argSequenceNum] [tinyint] NOT NULL ,
	[argName] [nvarchar] (50) NOT NULL ,
	[argIDXRefID] [int] NULL ,
	[argValueXRefID] [int] NULL 
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [CX_xref_MessageArgument] ON [dbo].[xref_MessageArgument] ([msgID], [argSequenceNum]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[xref_MessageDef] (
	[msgID] [int] IDENTITY (1, 1) NOT NULL ,
	[msgCode] [nvarchar] (50) NOT NULL ,
	[description] [nvarchar] (1000) NULL ,
	CONSTRAINT [PK_uan_MessageDef] PRIMARY KEY  CLUSTERED 
	(
		[msgID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO
CREATE INDEX [IX_xref_MessageDef_1] ON [dbo].[xref_MessageDef] ([msgCode]) ON [PRIMARY]
GO


CREATE TABLE [dbo].[xref_MessageText] (
	[lang] [nvarchar] (10) NOT NULL ,
	[msgID] [int] NOT NULL ,
	[msgText] [nvarchar] (1000) NOT NULL 
) ON [PRIMARY]
GO
CREATE CLUSTERED INDEX [CX_xref_MessageText_1] ON [dbo].[xref_MessageText] ([lang], [msgID]) ON [PRIMARY]
GO

CREATE TABLE [dbo].[xref_ValueXRef] (
	[valueXRefID] [int] IDENTITY (1, 1) NOT NULL ,
	[valueXRefName] [nvarchar] (50) NOT NULL ,
	CONSTRAINT [PK_xref_ValueXRef] PRIMARY KEY  CLUSTERED 
	(
		[valueXRefID]
	)  ON [PRIMARY] 
) ON [PRIMARY]
GO
CREATE INDEX [IX_xref_ValueXRef_1] ON [dbo].[xref_ValueXRef] ([valueXRefName]) ON [PRIMARY]
GO
INSERT INTO [xref_ValueXRef] (valueXRefName)
VALUES (N'')
GO

CREATE TABLE [dbo].[xref_ValueXRefData] (
	[valueXRefID] [int] NOT NULL ,
	[appTypeID] [int] NOT NULL ,
	[appValue] [nvarchar] (50) NOT NULL ,
	[commonValue] [nvarchar] (50) NOT NULL 
) ON [PRIMARY]
GO

CREATE INDEX [IX_xref_ValueXRefData_1] ON [dbo].[xref_ValueXRefData] ([commonValue]) ON [PRIMARY]
CREATE INDEX [IX_xref_ValueXRefData_2] ON [dbo].[xref_ValueXRefData] ([appValue]) ON [PRIMARY]
GO
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Re-apply global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- 

if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_addconstraints
GO





