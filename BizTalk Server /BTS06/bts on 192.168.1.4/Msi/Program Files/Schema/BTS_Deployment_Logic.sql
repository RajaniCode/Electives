--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_InitializeConnection]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_InitializeConnection]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_DeleteAssembly]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_DeleteAssembly]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_ValidatePropertySchemas]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_ValidatePropertySchemas]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_fn_CountOrphanedProperties]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[dpl_fn_CountOrphanedProperties]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_DocumentSpec_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_DocumentSpec_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_EnumItems]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_EnumItems]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_EnumGroupApplication]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_EnumGroupApplication]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_EnumAssemblyVersions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_EnumAssemblyVersions]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_FlipAssemblyHiddenStatus]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_FlipAssemblyHiddenStatus]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetAssemblyDependencies]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetAssemblyDependencies]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetAssemblyInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetAssemblyInfo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetAssemblyGroupDeployedTo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetAssemblyGroupDeployedTo]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetAssemblyXML]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetAssemblyXML]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetUnboundSendPortNames]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetUnboundSendPortNames]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetUnboundSendPortGroupNames]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetUnboundSendPortGroupNames]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_GetUnboundReceivePortNames]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_GetUnboundReceivePortNames]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Group_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Group_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_Load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_Load]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_LoadLatest]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_LoadLatest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_UsedBy_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_UsedBy_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_Uses_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_Uses_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_IsSystemAssembly]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_IsSystemAssembly]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Assembly_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Assembly_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Pipeline_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Pipeline_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Pipeline_ReceiveLocation_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Pipeline_ReceiveLocation_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Pipeline_ReceivePort_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Pipeline_ReceivePort_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Pipeline_SendPort_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Pipeline_SendPort_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Pipelines_Unbind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Pipelines_Unbind]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_RecalculateAssemblyReferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_RecalculateAssemblyReferences]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_LoadItem]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_LoadItem]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveDocType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveDocType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveMap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveMap]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveReference]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveReference]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveSchemaProperty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveSchemaProperty]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_SaveSensitiveProperty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_SaveSensitiveProperty]
GO



if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Msgtype_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Msgtype_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Service_Msgtype_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Service_Msgtype_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Operation_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Operation_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_PortType_Operation_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_PortType_Operation_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Port_Activation_Operation_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Port_Activation_Operation_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Operation_MsgType_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Operation_MsgType_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Port_Enum]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Port_Enum]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_MessageType_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_MessageType_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_MessageType_Part_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_MessageType_Part_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_RoleLinkType_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_RoleLinkType_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_RoleLinkType_Save_Role]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_RoleLinkType_Save_Role]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_RoleLinkType_Save_Role_PortType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_RoleLinkType_Save_Role_PortType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_PortType_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_PortType_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Port_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Port_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_RoleLink_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_RoleLink_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Ports_Unbind]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Ports_Unbind]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Load]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Load]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_Orchestration_Invocation_Save]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_Orchestration_Invocation_Save]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_VerifyAssemblyReferences]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_VerifyAssemblyReferences]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dpl_VerifyReference]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dpl_VerifyReference]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_LoadPropertyInfoByNamespace]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_LoadPropertyInfoByNamespace]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_LoadPropertiesForDocSpec]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_LoadPropertiesForDocSpec]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_LoadDocSpecByType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_LoadDocSpecByType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_LoadDocSpecByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_LoadDocSpecByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_LoadDocSpecByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_LoadDocSpecByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_GetDocSpecInfoByMsgType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_GetDocSpecInfoByMsgType]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_GetDocSpecInfoByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_GetDocSpecInfoByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_GetDocSpecInfoByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_GetDocSpecInfoByName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bt_GetPipelineIdFromName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bt_GetPipelineIdFromName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[dta_LoadSystemPropId]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[dta_LoadSystemPropId]
GO

-- Begin -- Tables used in Cross-Referencing (XREF) Service
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_GetAppID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_GetAppID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_GetCommonID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_GetCommonID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_SetCommonID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_SetCommonID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_GetCommonValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_GetCommonValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_GetAppValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_GetAppValue]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_FormatMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_FormatMessage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_RemoveAppID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_RemoveAppID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[xref_Cleanup]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[xref_Cleanup]
GO
-- End -- Tables used in Cross-Referencing (XREF) Service

SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO



CREATE PROCEDURE [dbo].[dpl_InitializeConnection]

AS
set nocount on

SET DEADLOCK_PRIORITY LOW -- Prevent disrupting runtime (deployment can be always re-ran later, without data loss) 
						  -- by agreeing to be selected as default deadlock victim

-- DECLARE @asmID int
-- SELECT @asmID = (SELECT TOP 1 nID
--	FROM bts_assembly WITH (HOLDLOCK,TABLOCKX) -- Implement deployment DB semaphore (lessen the probability of deadlocks, this is first DB operation of Deployment)
--	WHERE nSystemAssembly <> 0)

-- SET TEXTSIZE 2000000000 -- enable support for large blobs (this is probably set by ADO.NET by default, but just to be sure)

RETURN
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_InitializeConnection] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE FUNCTION dpl_fn_CountOrphanedProperties()
RETURNS int

AS
BEGIN
		DECLARE @orphancount int
		SELECT @orphancount = COUNT(name) 
			FROM bt_Properties INNER JOIN bt_DocumentSpec ON bt_Properties.propSchemaID = bt_DocumentSpec.id
							   INNER JOIN bt_XMLShare ON bt_DocumentSpec.shareid = bt_XMLShare.id
			WHERE NOT EXISTS ( SELECT ds.shareid 
						FROM bt_DocumentSpec ds
							INNER JOIN bt_XMLShare ON ds.shareid = bt_XMLShare.id 
						WHERE bt_XMLShare.active = 1 AND
							ds.msgtype = bt_Properties.namespace + N'#' + bt_Properties.name
					)
				  AND
				   bt_XMLShare.active = 1
		RETURN @orphancount
END
GO

-- removes specified module and associated artifacts
CREATE PROCEDURE [dbo].[dpl_DeleteAssembly]
(
	@Guid nvarchar(256),
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int, 
	@PublicKeyToken nvarchar(256),
	@Culture nvarchar(256),
	@Type int
)

AS
set nocount on

DECLARE @ModuleId int
DECLARE @SystemAssembly int
SELECT @ModuleId = nID, @SystemAssembly = nSystemAssembly
FROM bts_assembly
WHERE
	(@Name = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision) and
	(@PublicKeyToken = nvcPublicKeyToken) and
	(@Type = nType) 
IF (@@ROWCOUNT > 0 and @SystemAssembly = 0)
	BEGIN
		DELETE FROM bt_Properties WHERE @ModuleId = nAssemblyID
		DELETE FROM bt_MapSpec WHERE @ModuleId = assemblyid

		-- Delete schemas; ref count to account for CLR type schemas

		DELETE FROM bts_libreference WHERE idapp = @ModuleId OR idlib = @ModuleId
		DELETE FROM bts_itemreference WHERE nReferringAssemblyID = @ModuleId

		DELETE bt_DocumentSpec 
			WHERE (assemblyid = @ModuleId)
		DELETE bt_DocumentSpec 
			WHERE (assemblyid NOT IN (SELECT idlib FROM bts_libreference))  AND itemid IN (SELECT id FROM bts_item WHERE SchemaType = 2)
			-- cleanup unreferenced XMLShare rows
		DELETE FROM bt_XMLShare WHERE NOT EXISTS (SELECT shareid from bt_DocumentSpec WHERE bt_XMLShare.id = shareid) AND
									  NOT EXISTS (SELECT shareid from bt_MapSpec WHERE bt_XMLShare.id = shareid)
									  
		DELETE FROM bts_item where SchemaType = 2 AND id NOT IN (SELECT itemid FROM bt_DocumentSpec) 
		
		DELETE FROM bts_assembly WHERE nID NOT IN (SELECT AssemblyId FROM bts_item) AND nSystemAssembly <> 0 -- cleanup phantom assembly rows if unreferenced anymore
									  
		-- Deactivate previous active schema version
		UPDATE bt_XMLShare
			SET active = 0
			WHERE id IN ( SELECT DISTINCT xs.id 
							FROM bt_XMLShare xs INNER JOIN bt_DocumentSpec ds ON xs.id = ds.shareid
												INNER JOIN bts_assembly md ON ds.assemblyid = md.nID
							WHERE md.nvcName = @Name AND
									xs.active = 1
						)

				
		---------------- delete pipelines -------------------
		DELETE FROM bts_component WHERE Id IN 
			(SELECT CompID FROM bts_stage_config sc
					    INNER JOIN bts_pipeline_config pc ON sc.StageID = pc.StageID
					    INNER JOIN bts_pipeline p ON pc.PipelineID = p.Id
				       WHERE p.nAssemblyID = @ModuleId )

		DELETE FROM bts_pipeline_stage WHERE Id IN 
			(SELECT sc.StageID FROM bts_stage_config sc
					    INNER JOIN bts_pipeline_config pc ON sc.StageID = pc.StageID
					    INNER JOIN bts_pipeline p ON pc.PipelineID = p.Id
				       WHERE p.nAssemblyID = @ModuleId )

		DELETE FROM bts_stage_config WHERE StageID IN 
			(SELECT StageID FROM bts_pipeline_config pc 
					    INNER JOIN bts_pipeline p ON pc.PipelineID = p.Id
				       WHERE p.nAssemblyID = @ModuleId )

		DELETE FROM bts_pipeline_config WHERE PipelineID IN 
			(SELECT Id FROM bts_pipeline p
				       WHERE p.nAssemblyID = @ModuleId )

		DELETE FROM bts_pipeline WHERE nAssemblyID = @ModuleId 
		-----------------------------------------------------
		---------------- delete services --------------------
		/* remove bts_orchestration_port rows
			handled by CASCADE DELETE constraint
		*/
		
		/* remove bts_rolelink rows
		handled by CASCADE DELETE constraint
		*/
		
		/* verify that there are no active bindings pointing to any service in this assembly */
		DECLARE @bindcount int
		SELECT @bindcount = COUNT(o.nID) 
		FROM bts_orchestration_port_binding opb
			INNER JOIN bts_orchestration_port op ON op.nID = opb.nOrcPortID
			INNER JOIN bts_orchestration o ON op.nOrchestrationID = o.nID
			INNER JOIN bts_assembly a ON a.nID = o.nAssemblyID
		WHERE a.nID = @ModuleId AND
			( opb.nReceivePortID IS NOT NULL OR
				opb.nSendPortID IS NOT NULL OR
				opb.nSpgID IS NOT NULL 
			)
		IF ( @bindcount > 0 )
			RETURN -3
		

--				DELETE FROM StaticTrackingInfo
--				WHERE uidServiceID IN (
--				 	SELECT map.uidOrchestrationType
--					FROM bts_assembly_orchestration_mapping map join bts_orchestration on (nOrchestrationID = nID)
--	
--			 	WHERE (map.nAssemblyID = @ModuleId)
--				) 
						
		-- remove service
		DELETE FROM bts_orchestration 
		WHERE nAssemblyID = @ModuleId
		-------------------------------------------------------------------------------------

		-------------------- Delete servicelinktypes and related subitems -------------------
		/* bts_role rows deletion handled by CASCADE DELETE constraint
		*/
		/* bts_role_porttype deletion handled by CASCADE DELETE constraint
		*/
		DELETE FROM bts_rolelink_type 
		WHERE nAssemblyID = @ModuleId
		-----------------------------------------------------------------------------

		--------------------------- Delete porttypes  ----------------------
		/* bts_porttype_operation rows deletion handled by CASCADE DELETE constraint
		*/
		DELETE FROM bts_porttype
		WHERE nAssemblyID = @ModuleId
		-----------------------------------------------------------------------------
					
		--------------------------- Delete messagetypes ----------------------
		/* bts_messagetype_part rows deletion handled by CASCADE DELETE constraint
		*/
		DELETE FROM bts_messagetype 
		WHERE nAssemblyID = @ModuleId
		-----------------------------------------------------------------------------


		DELETE FROM bts_item WHERE @ModuleId = AssemblyId
								
		/* finally, delete module row */
		
		DELETE FROM bts_assembly
			WHERE @ModuleId = nID 


		-- Assembly is gone - now activate all schemas coming from assembly with the highest version number
		UPDATE bt_XMLShare 
			SET active = 1
			FROM bt_XMLShare x INNER JOIN bt_DocumentSpec ds ON x.id = ds.shareid
			WHERE ds.id IN 
				( SELECT TOP 1 id FROM bt_DocumentSpec d
	  					INNER JOIN bts_assembly md ON ds.assemblyid = md.nID
					WHERE md.nvcName = @Name AND
						  d.msgtype = ds.msgtype
					ORDER BY md.nVersionMajor DESC, md.nVersionMinor DESC, md.nVersionBuild DESC, md.nVersionRevision DESC
				)

					
		-- Now verify and update references from bt_Properties to bt_DocumentSpec - no document property might be orphaned by 
		-- property schema downgrade
		DECLARE @orphancount int
		SELECT @orphancount = dbo.dpl_fn_CountOrphanedProperties()
		IF ( @orphancount > 0 )
			RETURN -2
		RETURN 1
	END
ELSE
	BEGIN
		IF( @SystemAssembly = 0)
			RETURN -4
		ELSE
			RETURN -5
	END

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_DeleteAssembly] TO BTS_ADMIN_USERS
GO

/* private deployment */
CREATE PROCEDURE [dbo].[dpl_ValidatePropertySchemas]

AS

		-- Now verify and update references from bt_Properties to bt_DocumentSpec - no document property might be orphaned by 
		-- property schema downgrade
		DECLARE @orphancount int
		SELECT @orphancount =  dbo.dpl_fn_CountOrphanedProperties()
		IF ( @orphancount > 0 )
			RETURN -2

RETURN 1
GO
GRANT EXEC ON [dbo].[dpl_ValidatePropertySchemas] TO BTS_ADMIN_USERS
GO


-- Enumerates all document specs in specified module
CREATE PROCEDURE [dbo].[dpl_DocumentSpec_Enum]
(
	@ModuleId as int
)

AS
set nocount on

select
	[bt_DocumentSpec].[id] as [Guid],
	[msgtype] as [MsgType],
	[docspec_name] as [Name],
	[body_xpath] as [BodyXpath],
	[target_namespace] as [TargetNamespace],
	[content] as [Content]
from [bt_DocumentSpec] join [bt_XMLShare] on [shareid] = [bt_XMLShare].[id]
where ([assemblyid] = @ModuleId)
order by [docspec_name]
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_DocumentSpec_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

/* private deployment */
CREATE PROCEDURE [dbo].[dpl_SaveItem]
(
	@ModuleId int,
	@Namespace nvarchar(256)  = NULL,
	@Name nvarchar(256),
	@Type nvarchar(50),
	@IsPipeline tinyint,
	@Guid uniqueidentifier,
	@SchemaType tinyint,
	@phantomAssemblyName nvarchar(512) = NULL
)

AS

DECLARE @AssemblyId int
SELECT @AssemblyId = @ModuleId

DECLARE @SystemApplicationId int
SELECT @SystemApplicationId = nID FROM bts_application WHERE isSystem = 1

IF( @SchemaType = 2 ) -- CLRTypeSchema
BEGIN
	SELECT @AssemblyId = nID
		FROM bts_assembly a
		WHERE a.nvcFullName = @phantomAssemblyName
	IF( @@ROWCOUNT = 0 )
	BEGIN
		INSERT INTO bts_assembly
			(
				nvcName,
				nvcVersion,
				nvcCulture,
				nvcPublicKeyToken,
				nvcFullName,
				nVersionMajor,
				nVersionMinor,
				nVersionBuild,
				nVersionRevision,
				dtDateModified,
				nvcModifiedBy,
				nType,
				nGroupId,
				ntxtModuleXML,
				nSystemAssembly,
				nApplicationID
			)
			VALUES
			(
				@phantomAssemblyName, --@Name,
				N'1.0.0.0', --@Version,
				N'neutral', --@Culture,
				N'', --@PublicKeyToken,
				@phantomAssemblyName, --@FullName,
				1, --@VersionMajor,
				0, --@VersionMinor,
				0, --@VersionBuild,
				0, --@VersionRevision,
				GETUTCDATE(),
				SUSER_SNAME(),
				2, --@Type, 
				1, --@GroupId,
				N'', --@ModuleXml,
				1, -- @SystemAssembly
				@SystemApplicationId   -- BUGBUG: TODO: TBD: hard coded app ID
			)
		SELECT @AssemblyId = @@IDENTITY
	END
	INSERT	INTO bts_libreference(idapp,idlib,refName)
		VALUES( @ModuleId, @AssemblyId, @phantomAssemblyName ) -- This is needed for proper removal of phantom items (CLR generated schemas)
    INSERT INTO bts_itemreference (
		    nReferringAssemblyID,
		    nvcAssemblyName,
		    nvcVersionMajor,
		    nvcVersionMinor,
		    nvcVersionBuild,
		    nvcVersionRevision,
		    nvcCulture,
		    nvcPublicKeyToken,
		    nvcItemName
	    ) 
	    VALUES (
		    @ModuleId,
		    @phantomAssemblyName,
			1, --@VersionMajor,
			0, --@VersionMinor,
			0, --@VersionBuild,
			0, --@VersionRevision,
		    N'neutral',
		    N'',
		    N'DotNetSchema'
	    )
END

DECLARE @ItemId int
SELECT @ItemId = id 
	FROM bts_item 
	WHERE	AssemblyId = @AssemblyId AND
			Namespace = @Namespace AND
			Name = @Name AND
			SchemaType = 2 -- refcounting only for CLRSchemas
IF( @@ROWCOUNT = 0 )
BEGIN
	INSERT INTO bts_item ( 
			AssemblyId,
			Namespace,
			Name,
			Type,
			IsPipeline,
			Guid,
			SchemaType
		)
		VALUES (
			@AssemblyId,
			@Namespace,
			@Name,
			@Type,
			@IsPipeline,
			@Guid,
			@SchemaType
		)
	SELECT @ItemId = @@IDENTITY
END		
RETURN @ItemId
GO
GRANT EXEC ON [dbo].[dpl_SaveItem] TO BTS_ADMIN_USERS
GO

/* private deployment */
CREATE PROCEDURE [dbo].[dpl_LoadItem]
(
	@ArtifactId int,
	@ModuleId int OUTPUT,
	@Namespace nvarchar(256) OUTPUT,
	@Name nvarchar(256) OUTPUT,
	@Type nvarchar(50) OUTPUT,
	@IsPipeline tinyint OUTPUT,
	@Guid uniqueidentifier OUTPUT,
	@SchemaType tinyint OUTPUT
)

AS

SELECT @ModuleId = AssemblyId,
		@Namespace = Namespace,
		@Name = Name,
		@Type = Type,
		@IsPipeline = IsPipeline,
		@Guid = Guid,
		@SchemaType = SchemaType
	
FROM bts_item 
WHERE id = @ArtifactId

IF ( @ModuleId IS NULL )
	RETURN -1

RETURN 1
GO
GRANT EXEC ON [dbo].[dpl_LoadItem] TO BTS_ADMIN_USERS
GO

/* private deployment */
CREATE PROCEDURE [dbo].[dpl_EnumItems]
(
	@AssemblyId int,
	@ArtifactType nvarchar(256)
)

AS

SELECT id,FullName
FROM bts_item
WHERE
	AssemblyId = @AssemblyId and
	Type = @ArtifactType

GO
GRANT EXEC ON [dbo].[dpl_EnumItems] TO BTS_ADMIN_USERS
GO

/* private deployment */
CREATE PROCEDURE [dbo].[dpl_EnumAssemblyVersions]
(
	@Name nvarchar(256)
)

AS

DECLARE @emptyguid uniqueidentifier
SELECT @emptyguid = CONVERT(uniqueidentifier,N'{00000000-0000-0000-0000-000000000000}')
SELECT
	nID AS id,
	@emptyguid as ModuleGuid,
	nvcName as ModuleName,
	nVersionMajor as VersionMajor,
	nVersionMinor as VersionMinor,
	nVersionBuild as VersionBuild,
	nVersionRevision as VersionRevision,
	dtDateModified as DateModified,
	nvcModifiedBy as ModifiedBy
FROM bts_assembly
WHERE nvcName = @Name
-- Important - we need the latest versions to go first, to support correct copying of postdeployment settings 
-- on deployment (like property tracking flag) to the subsequent versions
ORDER BY nVersionMajor DESC, nVersionMinor DESC, nVersionBuild DESC, nVersionRevision DESC 

GO
GRANT EXEC ON [dbo].[dpl_EnumAssemblyVersions] TO BTS_ADMIN_USERS
GO


-- Used by DTA\WebPortalNew\Controls\WmiNet.cs
CREATE PROCEDURE [dbo].[dpl_EnumGroupApplication]
	@GroupName as nvarchar(256)

AS
SELECT adm_Host.Name as ApplicationName
FROM adm_Host JOIN adm_Group ON adm_Host.GroupId = adm_Group.Id
WHERE (adm_Group.Name = @GroupName)
ORDER BY adm_Host.Name


GO
GRANT EXEC ON [dbo].[dpl_EnumGroupApplication] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


CREATE PROCEDURE [dbo].[dpl_FlipAssemblyHiddenStatus]
(
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int,
	@Culture nvarchar(25),
	@PublicKeyToken nvarchar(256),
	@Type int
)

AS
UPDATE bts_assembly
SET nType = -nType
WHERE
	(@Name = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision) and
	(@PublicKeyToken = nvcPublicKeyToken) and
	(@Type = ABS(nType))
				
IF (@@ROWCOUNT = 0)
	RETURN -1
RETURN 0

GO
GRANT EXEC ON [dbo].[dpl_FlipAssemblyHiddenStatus] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_GetAssemblyDependencies]
(
	@ModuleId int
)

AS
	/* SET NOCOUNT ON */
	
	IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[#dependencies]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	BEGIN
		DROP TABLE [dbo].[#dependencies]			
	END
	
	CREATE TABLE [dbo].#dependencies (
			[nReferredAssemblyID] [int] NOT NULL 
	)
	
	/* Insert direct dependencies */
	INSERT INTO #dependencies
	SELECT idlib 
		FROM bts_libreference 
		WHERE idapp = @ModuleId
		

	DECLARE @rowsadded int
	SELECT @rowsadded = 1 /* Let the loop run for the first time */
	
	/* Now repeat inserting all dependencies of modules already in dependencies
		until nothing more can be inserted
	 */	
	WHILE @rowsadded > 0
		BEGIN
			INSERT INTO #dependencies
			SELECT idlib 
				FROM bts_libreference 
				WHERE idapp IN ( SELECT nReferredAssemblyID FROM #dependencies )
					and idlib NOT IN ( SELECT nReferredAssemblyID FROM #dependencies )
			
			SELECT @rowsadded = @@ROWCOUNT
		END
	
		
	SELECT DISTINCT b.nId, b.nvcName, b.nVersionMajor, b.nVersionMinor, b.nVersionBuild, b.nVersionRevision
		 FROM #dependencies d 
			INNER JOIN bts_assembly b ON b.nId=d.nReferredAssemblyID
		 ORDER BY nvcName, nVersionMajor, nVersionMinor, nVersionBuild, nVersionRevision
	
	/* If module passed as a parameter showed up as its own dependency, this means it is the part 
		of the circular referencing loop
	 - in this case stored proc will return value > 0 */
	RETURN (SELECT COUNT(*) FROM #dependencies WHERE nReferredAssemblyID=@ModuleId)




GO
GRANT EXEC ON [dbo].[dpl_GetAssemblyDependencies] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO



CREATE PROCEDURE [dbo].[dpl_GetAssemblyInfo]
(
	@Guid nvarchar(256),
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int, 
	@Culture nvarchar(256),
	@PublicKeyToken nvarchar(256),
	@Type int
)

AS 
DECLARE @nId int
SELECT  @nId = nID
FROM bts_assembly
WHERE
	(@Name = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision) and
	(@Culture = nvcCulture) and
	(@PublicKeyToken = nvcPublicKeyToken) and
	(@Type = nType)

IF (@@ROWCOUNT > 0)
	BEGIN
		SELECT nvcName, nType, nVersionMajor, nVersionMinor, nVersionBuild, nVersionRevision, nvcCulture, nvcPublicKeyToken
		FROM bts_assembly 
			INNER JOIN bts_libreference ON bts_assembly.nID = bts_libreference.idapp
		WHERE bts_libreference.idlib = @nId AND bts_libreference.idapp <> @nId
		RETURN 1
	END
ELSE
	RETURN 0
RETURN 0

GO
GRANT EXEC ON [dbo].[dpl_GetAssemblyInfo] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[dpl_GetAssemblyGroupDeployedTo]
(
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int
)

AS 
DECLARE @nId int
SELECT  @nId = nGroupId
FROM bts_assembly
WHERE
	(@Name = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision)

IF (@@ROWCOUNT > 0)
	BEGIN
		SELECT Name
		FROM adm_Group 
		WHERE Id = @nId
		IF (@@ROWCOUNT > 0)
			RETURN 1
	END
RETURN -1




GO
GRANT EXEC ON [dbo].[dpl_GetAssemblyGroupDeployedTo] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


CREATE PROCEDURE [dbo].[dpl_GetAssemblyXML]
(
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int, 
	@Type int
)

AS 
SELECT ntxtModuleXML as ModuleXML
FROM bts_assembly
WHERE
	(@Name = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision) and
	(@Type = nType)


GO
GRANT EXEC ON [dbo].[dpl_GetAssemblyXML] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Get names of unbound send ports
CREATE PROCEDURE [dbo].[dpl_GetUnboundSendPortNames] 

AS
SELECT nvcName FROM bts_sendport WHERE nID not in
	(SELECT nSendPortID FROM bts_orchestration_port_binding WHERE (nSendPortID is not null))

GO
GRANT EXEC ON [dbo].[dpl_GetUnboundSendPortNames] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Get names of unbound send port groups
CREATE PROCEDURE [dbo].[dpl_GetUnboundSendPortGroupNames] 

AS
SELECT nvcName FROM bts_sendportgroup WHERE nID not in
	(SELECT nSpgID FROM bts_orchestration_port_binding WHERE (nSpgID is not null))

GO
GRANT EXEC ON [dbo].[dpl_GetUnboundSendPortGroupNames] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Get names of unbound receive ports
CREATE PROCEDURE [dbo].[dpl_GetUnboundReceivePortNames] 

AS
SELECT nvcName FROM bts_receiveport WHERE nID not in
	(SELECT nReceivePortID FROM bts_orchestration_port_binding WHERE (nReceivePortID is not null))

GO
GRANT EXEC ON [dbo].[dpl_GetUnboundReceivePortNames] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerate groups
CREATE PROCEDURE [dbo].[dpl_Group_Enum]
(
	@FilterName as nvarchar(256) = N'%' -- default: enum all groups
)

AS

set nocount on
SELECT
	[Id] as [Id],
	[Name] as [Name]
FROM [adm_Group]
WHERE [Name] LIKE @FilterName
ORDER BY [Name]
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Group_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerate modules
CREATE PROCEDURE [dbo].[dpl_Assembly_Enum]
(
	@GroupName as nvarchar(256) = null,
	@FilterName as nvarchar(256) = N'%' -- default: enum all modules
)

AS
set nocount on
if (@GroupName is NULL)
	begin
		SELECT
			[nID] as [Id],
			[nvcName] as [Name],
			[nVersionMajor] as [VersionMajor],
			[nVersionMinor] as [VersionMinor],
			[nVersionBuild] as [VersionBuild],
			[nVersionRevision] as [VersionRevision],
			[nvcCulture] as [Culture],
			[nvcPublicKeyToken] as [PublicKeyToken],
			[dtDateModified] as [DateModified],
			[nvcModifiedBy] as [ModifiedBy]
		FROM [bts_assembly]
		WHERE ([nvcName] LIKE @FilterName)
			AND ([nSystemAssembly] = 0) -- Do not enumerate system assemblies
		ORDER BY
			[nvcName],
			[nVersionMajor],
			[nVersionMinor],
			[nVersionBuild],
			[nVersionRevision]
	end
else
	begin
		SELECT
			[nID] as [Id],
			[nvcName] as [Name],
			[nVersionMajor] as [VersionMajor],
			[nVersionMinor] as [VersionMinor],
			[nVersionBuild] as [VersionBuild],
			[nVersionRevision] as [VersionRevision],
			[nvcCulture] as [Culture],
			[nvcPublicKeyToken] as [PublicKeyToken],
			[dtDateModified] as [DateModified],
			[nvcModifiedBy] as [ModifiedBy]
		FROM [bts_assembly]
		JOIN [adm_Group] ON ([bts_assembly].[nGroupId] =  [adm_Group].[Id])
		WHERE ([adm_Group].[Name] = @GroupName) 
			AND ([nvcName] LIKE @FilterName)
			AND ([nSystemAssembly] = 0) -- Do not enumerate system assemblies
		ORDER BY
			[nvcName],
			[nVersionMajor],
			[nVersionMinor],
			[nVersionBuild],
			[nVersionRevision]
	end
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Assembly_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Loads module with specified name and version
CREATE PROCEDURE [dbo].[dpl_Assembly_Load]
(
	@Name as nvarchar(256),
	@VersionMajor as int,
	@VersionMinor as int,
	@VersionBuild as int,
	@VersionRevision as int,
	@Culture AS nvarchar(256),
	@PublicKeyToken AS nvarchar(256)
)

AS
set nocount on
SELECT
	[nID] as [Id],
	[nvcName] as [Name],
	[nVersionMajor] as [VersionMajor],
	[nVersionMinor] as [VersionMinor],
	[nVersionBuild] as [VersionBuild],
	[nVersionRevision] as [VersionRevision],
	[nvcCulture] as [Culture],
	[nvcPublicKeyToken] as [PublicKeyToken],
	[dtDateModified] as [DateModified],
	[nvcModifiedBy] as [ModifiedBy]
FROM [bts_assembly] WITH (NOLOCK)
WHERE
	([nvcName]  = @Name) and
	([nVersionMajor] = @VersionMajor) and
	([nVersionMinor] = @VersionMinor) and
	([nVersionBuild] = @VersionBuild) and
	([nVersionRevision] = @VersionRevision) and
	([nvcCulture] = @Culture) and
	([nvcPublicKeyToken] = @PublicKeyToken)
ORDER BY
	[nvcName],
	[nvcPublicKeyToken],
	[nvcCulture],
	[nVersionMajor],
	[nVersionMinor],
	[nVersionBuild],
	[nVersionRevision]
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Assembly_Load] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Loads latest version of named module
CREATE PROCEDURE [dbo].[dpl_Assembly_LoadLatest]
(
	@Name as nvarchar(256)
)

AS
set nocount on
set xact_abort on
SELECT TOP 1
	[nID] as [Id],
	[nvcName] as [Name],
	[nVersionMajor] as [VersionMajor],
	[nVersionMinor] as [VersionMinor],
	[nVersionBuild] as [VersionBuild],
	[nVersionRevision] as [VersionRevision],
	[nvcCulture] as [Culture],
	[nvcPublicKeyToken] as [PublicKeyToken],
	[dtDateModified] as [DateModified],
	[nvcModifiedBy] as [ModifiedBy]
FROM [bts_assembly]
WHERE ([nvcName]  = @Name)
ORDER BY
	[nvcName],
	[nVersionMajor] DESC,
	[nVersionMinor] DESC,
	[nVersionBuild] DESC,
	[nVersionRevision] DESC
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Assembly_LoadLatest] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all modules that use specified module.
CREATE PROCEDURE [dbo].[dpl_Assembly_UsedBy_Enum]
(
	@ModuleId as int
)

AS

SELECT
	[nID] as [Id],
	[nvcName] as [Name],
	[nVersionMajor] as [VersionMajor],
	[nVersionMinor] as [VersionMinor],
	[nVersionBuild] as [VersionBuild],
	[nVersionRevision] as [VersionRevision],
	[nvcCulture] as [Culture],
	[nvcPublicKeyToken] as [PublicKeyToken],
	[dtDateModified] as [DateModified],
	[nvcModifiedBy] as [ModifiedBy]
FROM [bts_assembly] (NOLOCK) JOIN [bts_libreference] (NOLOCK) /* BUGBUG - remove NOLOCK after it's clear why two connections under same COM+ transaction lock up themselves - MBorsa */ 
			ON ([nID] = [idapp])
WHERE ([idlib] = @ModuleId)
ORDER BY
	[nvcName],
	[nVersionMajor],
	[nVersionMinor],
	[nVersionBuild],
	[nVersionRevision]

RETURN @@ROWCOUNT
GO
GRANT EXEC ON [dbo].[dpl_Assembly_UsedBy_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all modules used by specified module.
CREATE PROCEDURE [dbo].[dpl_Assembly_Uses_Enum]
(
	@ModuleId as int
)

AS

SELECT
	[nID] as [Id],
	[nvcName] as [Name],
	[nVersionMajor] as [VersionMajor],
	[nVersionMinor] as [VersionMinor],
	[nVersionBuild] as [VersionBuild],
	[nVersionRevision] as [VersionRevision],
	[nvcCulture] as [Culture],
	[nvcPublicKeyToken] as [PublicKeyToken],
	[dtDateModified] as [DateModified],
	[nvcModifiedBy] as [ModifiedBy]
FROM [bts_assembly] JOIN [bts_libreference] ON ([nID] = [idlib])
WHERE ([idapp] = @ModuleId)
ORDER BY
	[nvcName],
	[nVersionMajor],
	[nVersionMinor],
	[nVersionBuild],
	[nVersionRevision]

RETURN @@ROWCOUNT
GO
GRANT EXEC ON [dbo].[dpl_Assembly_Uses_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all pipelines in specified module
CREATE PROCEDURE [dbo].[dpl_Pipeline_Enum]
(
	@ModuleId as int
)

AS
set nocount on
set xact_abort on

select
	[bts_pipeline].[Id] as [Id],
	[bts_pipeline].[PipelineID] as [PipelineID],
	[bts_pipeline].[Category] as [Category],
	[bts_pipeline].[Name] as [Name],
	[bts_pipeline].[FullyQualifiedName] as [FullyQualifiedName]
from [bts_item] inner join [bts_pipeline] on ([Guid] = [PipelineID])
where
	([IsPipeline] = 1) and
	([AssemblyId] = @ModuleId)
order by [bts_pipeline].[FullyQualifiedName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Pipeline_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all receive locations bound to specified pipeline
CREATE PROCEDURE [dbo].[dpl_Pipeline_ReceiveLocation_Enum]
(
	@PipeId as int
)

AS
set nocount on
set xact_abort on

select * from [adm_ReceiveLocation]
where ([ReceivePipelineId] = @PipeId)
order by [Name]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Pipeline_ReceiveLocation_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all receive ports bound to specified pipeline
CREATE PROCEDURE [dbo].[dpl_Pipeline_ReceivePort_Enum]
(
	@PipeId as int
)

AS
set nocount on
set xact_abort on

select * from [bts_receiveport]
where ([nSendPipelineId] = @PipeId)
order by [nvcName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Pipeline_ReceivePort_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


-- Enumerates all send ports bound to specified pipeline
CREATE PROCEDURE [dbo].[dpl_Pipeline_SendPort_Enum]
(
	@PipeId as int
)

AS
set nocount on
set xact_abort on

select * from [bts_sendport]
where ([nSendPipelineID] = @PipeId) or ([nReceivePipelineID] = @PipeId)
order by [nvcName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Pipeline_SendPort_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

-- Unbinds all receive locations, receive ports, and send ports from pipelines in specified module.
CREATE PROCEDURE [dbo].[dpl_Pipelines_Unbind]
(
	@ModuleId as int
)

AS
set nocount on
set xact_abort on
begin tran

	-- TO DO: IDs of pipelines in module -- same query unnecessarily repeated; factor out using temp table?

	-- unbind send ports receive pipelines from pipelines in module
	update [bts_sendport]
	set [nReceivePipelineID] = null
	where [nReceivePipelineID] in
	(
		-- IDs of pipelines in module
		select [bts_pipeline].[Id]
		from [bts_pipeline] inner join [bts_item] on ([bts_item].[IsPipeline] = 1 and [bts_item].[Guid] = [bts_pipeline].[PipelineID])
		where ([bts_item].[AssemblyId] = @ModuleId)
	)

	-- unbind send ports transmit pipelines from pipelines in module
	update [bts_sendport]
	set [nSendPipelineID] = null
	where [nSendPipelineID] in
	(
		-- IDs of pipelines in module
		select [bts_pipeline].[Id]
		from [bts_pipeline] inner join [bts_item] on ([bts_item].[IsPipeline] = 1 and [bts_item].[Guid] = [bts_pipeline].[PipelineID])
		where ([bts_item].[AssemblyId] = @ModuleId)
	)

	-- unbind receive locations send pipelines from pipelines in module
	update [adm_ReceiveLocation]
	set [ReceivePipelineId] = null
	where [ReceivePipelineId] in
	(
		-- IDs of pipelines in module
		select [bts_pipeline].[Id]
		from [bts_pipeline] inner join [bts_item] on ([bts_item].[IsPipeline] = 1 and [bts_item].[Guid] = [bts_pipeline].[PipelineID])
		where ([bts_item].[AssemblyId] = @ModuleId)
	)

	-- unbind receive ports transmit pipelines from pipelines in module
	update [bts_receiveport]
	set [nSendPipelineId] = null
	where [nSendPipelineId] in
	(
		-- IDs of pipelines in module
		select [bts_pipeline].[Id]
		from [bts_pipeline] inner join [bts_item] on ([bts_item].[IsPipeline] = 1 and [bts_item].[Guid] = [bts_pipeline].[PipelineID])
		where ([bts_item].[AssemblyId] = @ModuleId)
	)

commit tran
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Pipelines_Unbind] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_RecalculateAssemblyReferences]

AS


DELETE FROM  bts_libreference

INSERT INTO bts_libreference(idapp,idlib,refName)
SELECT DISTINCT nReferringAssemblyID AS appId, 
	( SELECT nID 
		FROM bts_assembly bm
		WHERE	bm.nvcName = bar.nvcAssemblyName and 
	 			2 = bm.nType and
		 		bm.nVersionMajor = bar.nvcVersionMajor and 
				bm.nVersionMinor = bar.nvcVersionMinor and
				bm.nVersionBuild = bar.nvcVersionBuild and
				bm.nVersionRevision = bar.nvcVersionRevision and
				bm.nvcPublicKeyToken = bar.nvcPublicKeyToken 
	) AS libId, NULL
FROM bts_itemreference bar

UPDATE bts_libreference 
	SET refName = (SELECT nvcName+ '.btl' FROM bts_assembly mod WHERE mod.nID = /*bts_libreference.*/idlib )


RETURN 

GO
GRANT EXEC ON [dbo].[dpl_RecalculateAssemblyReferences] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_IsSystemAssembly]
(
	@Name nvarchar(256)
)
AS

DECLARE @SystemAssembly int

IF ( @Name LIKE N'Microsoft.BizTalk.DefaultPipelines,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.GlobalPropertySchemas,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.Hws.HwsPromotedProperties,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.Hws.HwsSchemas,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.KwTpm.RoleLinkTypes,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.KwTpm.StsDefaultPipelines,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'Microsoft.BizTalk.Adapter.MSMQ.MsmqAdapterProperties,%PublicKeyToken=31bf3856ad364e35%' OR
	 @Name LIKE N'MQSeries,%PublicKeyToken=31bf3856ad364e35%'	
   )
    SELECT @SystemAssembly = 1
ELSE
    SELECT @SystemAssembly = 0

RETURN @SystemAssembly

GO
GRANT EXEC ON [dbo].[dpl_IsSystemAssembly] TO BTS_ADMIN_USERS
GO


-- Saves specified module into bts_assembly table.
CREATE PROCEDURE [dbo].[dpl_Assembly_Save]
(
	@ApplicationName nvarchar(256),
	@Guid nvarchar(256),
	@Name nvarchar(256),
	@Version nvarchar(256),
	@Culture nvarchar(256),
	@PublicKeyToken nvarchar(256),
	@FullName nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int,
	@VersionRevision int,
	@Type int,
	@ModuleXml ntext = null
)

AS

DECLARE @GroupId int
SELECT @GroupId = ( SELECT TOP 1 [Id] -- Only one group, if nonexistent yet, so be it, NULL
FROM [adm_Group] )

DECLARE @SystemAssembly int
EXEC @SystemAssembly = dpl_IsSystemAssembly @Name = @FullName

DECLARE @ApplicationId int

IF( @SystemAssembly = 1 )
	BEGIN
	SELECT @ApplicationId = nID 
		FROM bts_application
		WHERE isSystem = 1
	END
ELSE
	BEGIN
		SELECT @ApplicationId = nID FROM bts_application WHERE [nvcName] = @ApplicationName
	END

 -- IF ( @@ROWCOUNT = 0 )  return error TODO: BUGBUG:

INSERT INTO bts_assembly
	(
		nvcName,
		nvcVersion,
		nvcCulture,
		nvcPublicKeyToken,
		nvcFullName,
		nVersionMajor,
		nVersionMinor,
		nVersionBuild,
		nVersionRevision,
		dtDateModified,
		nvcModifiedBy,
		nType,
		nGroupId,
		ntxtModuleXML,
		nSystemAssembly,
		nApplicationID
	)
	VALUES
	(
		@Name,
		@Version,
		@Culture,
		@PublicKeyToken,
		@FullName,
		@VersionMajor,
		@VersionMinor,
		@VersionBuild,
		@VersionRevision,
		GETUTCDATE(),
		SUSER_SNAME(),
		@Type,
		@GroupId,
		@ModuleXml,
		@SystemAssembly,
		@ApplicationId
	)
return @@IDENTITY -- AssemblyId

GO
GRANT EXEC ON [dbo].[dpl_Assembly_Save] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_SaveReference]
(
	@ReferringModuleId int,
	@AssemblyName nvarchar(256),
	@VersionMajor nvarchar(12),
	@VersionMinor nvarchar(12),
	@VersionBuild nvarchar(12),
	@VersionRevision nvarchar(12),
	@Culture nvarchar(25),
	@PublicKeyToken nvarchar(256),
	@ArtifactName nvarchar(256)
)

AS
INSERT INTO bts_itemreference (
		nReferringAssemblyID,
		nvcAssemblyName,
		nvcVersionMajor,
		nvcVersionMinor,
		nvcVersionBuild,
		nvcVersionRevision,
		nvcCulture,
		nvcPublicKeyToken,
		nvcItemName
	) 
	VALUES (
		@ReferringModuleId,
		@AssemblyName,
		@VersionMajor,
		@VersionMinor,
		@VersionBuild,
		@VersionRevision,
		@Culture,
		@PublicKeyToken,
		@ArtifactName
	)




GO
GRANT EXEC ON [dbo].[dpl_SaveReference] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_SaveDocType]
(
	@ArtifactId int,
	@ModuleId int,
	@Name nvarchar(2000),
	@uid uniqueidentifier = NULL,
	@MsgType nvarchar(2000),
	@isEnvelope bit,
	@isMultiroot bit,
	@isFlat bit,
	@body_xpath nvarchar(4000),
	@targetNamespace nvarchar(2000),
	@ArtifactXml ntext,
	@ImportList ntext,
	@isPropertySchema tinyint,
	@ArtifactClrNamespace nvarchar(256) = N'',
	@ArtifactClrTypeName nvarchar(256),
	@ArtifactAssemblyName nvarchar(512),
	@DocTypeElementName nvarchar(2000),
	@XsdType nvarchar(30),
	@PropertyCLRClass nvarchar(2000) = NULL,
	@ErrorCode int OUTPUT
)

AS
	DECLARE @shareid uniqueidentifier
	
	SELECT @ErrorCode = 0
	
    DECLARE @moduleName nvarchar(256)
	if (@uid IS NULL)
		set @uid = NewID()
	-- adjust ModuleId - 
	SELECT @ModuleId = AssemblyId FROM bts_item WHERE id = @ArtifactId
	SELECT @moduleName = nvcName
	FROM bts_assembly
	WHERE nID = @ModuleId
	
	DECLARE @isTracked int
	SELECT @isTracked = ds.is_tracked 
	FROM bt_DocumentSpec ds 
	INNER JOIN bt_XMLShare xs ON xs.id = ds.shareid
	INNER JOIN bts_assembly md ON ds.assemblyid = md.nID
	WHERE md.nvcName = @moduleName
		AND ds.clr_namespace = @ArtifactClrNamespace
		AND ds.clr_typename = @ArtifactClrTypeName
		AND xs.active = 1
	IF (@isTracked is null)
	BEGIN
		SET @isTracked = 0
	END
	-- Deactivate previous active schema version
	UPDATE bt_XMLShare 
		SET active = 0
		FROM bt_XMLShare x
		INNER JOIN bt_DocumentSpec ds
			INNER JOIN bts_assembly md
			ON md.nID = ds.assemblyid AND ds.msgtype = @MsgType AND md.nvcName = @moduleName
		ON x.id = ds.shareid
		WHERE x.active = 1

	SELECT TOP 1 @shareid = shareid 
		FROM bt_DocumentSpec
		WHERE @ArtifactId = itemid 
		
	IF ( @@ROWCOUNT = 0 )
		BEGIN		
			SELECT @shareid = newid()
			IF LEN( @targetNamespace ) = 0
				SELECT @targetNamespace = NULL
			INSERT INTO bt_XMLShare( id,
 						target_namespace,  
 						content, 
 						active 
 					)
 					VALUES( @shareid, 
 						@targetNamespace,  
 						@ArtifactXml,
 	 					0 -- doesn't matter here, will be overwritten below, need something NOT NULL
					)
			DECLARE @idoc int
			EXEC sp_xml_preparedocument @idoc OUTPUT, @ImportList
			INSERT INTO bt_XMLShareReferences
			SELECT DISTINCT  @shareid, targetNamespace
			FROM OPENXML (@idoc, N'/root/reference',2)
			WITH ( targetNamespace nvarchar(256) N'@targetNamespace' )
			
			EXEC sp_xml_removedocument @idoc
		END
	IF ( @isFlat = 0)
	BEGIN
		SELECT @ErrorCode = COUNT(ds.itemid) -- Check uniqueness of msgtype in DB (targetNamespace#rootelement needs to be unique)
						FROM  bt_DocumentSpec ds INNER JOIN bt_XMLShare xs ON ds.shareid = xs.id
						WHERE ds.msgtype = @MsgType 
		IF( @ErrorCode > 0 )
		BEGIN
			SELECT @ErrorCode = -1
		END
	END
	ELSE
	BEGIN
		SELECT @ErrorCode = COUNT(ds.itemid) -- Check uniqueness of docspec_name in DB (needs to be unique for flat files)
						FROM  bt_DocumentSpec ds INNER JOIN bt_XMLShare xs ON ds.shareid = xs.id
						WHERE ds.docspec_name = @ArtifactClrNamespace + N'.' +	@ArtifactClrTypeName AND
								xs.active = 1
		IF( @ErrorCode > 0 )
		BEGIN
			SELECT @ErrorCode = -2
		END
	END
	DECLARE @deps AS int
	SELECT @deps = COUNT(*) 
		FROM bt_DocumentSpec 
		WHERE id = @uid AND msgtype <> @MsgType
	IF ( @deps > 0  )
	BEGIN
			SELECT @ErrorCode = -3
	END
	-- property schema supplies a unique identifier
	IF NOT EXISTS (SELECT ds.id 
					FROM bt_DocumentSpec ds
						INNER JOIN bts_item it ON ds.itemid = it.id
					WHERE it.SchemaType = 2 AND it.id = @ArtifactId )
	BEGIN
		INSERT INTO bt_DocumentSpec (
				id,	
				itemid,
				assemblyid,
				msgtype,
				shareid,
				body_xpath,
				is_property_schema,
				is_multiroot,
				clr_namespace,
				clr_typename,
				clr_assemblyname,
				schema_root_name,
				xsd_type,
				is_flat,
				property_clr_class,
				is_tracked
			)
		VALUES (
			@uid,
			@ArtifactId,
			@ModuleId,
			@MsgType,
			@shareid,
			@body_xpath,
			@isPropertySchema,
			@isMultiroot,
			@ArtifactClrNamespace,
			@ArtifactClrTypeName,
			@ArtifactAssemblyName,
			@DocTypeElementName,
			@XsdType,
			@isFlat,
			@PropertyCLRClass,
			@isTracked
		)
	END
DECLARE @ret int
SELECT @ret = @@IDENTITY
			
-- Activate schema coming from assembly with the highest version number
			
UPDATE bt_XMLShare 
	SET active = 1
	FROM bt_XMLShare x
	INNER JOIN bt_DocumentSpec ds
		INNER JOIN ( SELECT TOP 1 md.nID FROM bts_assembly md
				WHERE md.nvcName = @moduleName
				ORDER BY md.nVersionMajor DESC, md.nVersionMinor DESC, md.nVersionBuild DESC, md.nVersionRevision DESC
			) as mdOuter
		ON mdOuter.nID = ds.assemblyid AND ds.msgtype = @MsgType
    ON x.id = ds.shareid
RETURN @ret

GO
GRANT EXEC ON [dbo].[dpl_SaveDocType] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_SaveMap] 
(
	@ArtifactId int,
	@AssemblyId int,
	@IndocDocSpecName nvarchar (256) ,
	@OutdocDocSpecName nvarchar (256) ,
	@ArtifactXml ntext
)

AS
	DECLARE @shareid  uniqueidentifier
	SELECT @shareid = newid()
	INSERT INTO bt_XMLShare( id,target_namespace, active, content )
			VALUES( @shareid, N'', 1, @ArtifactXml )
	INSERT INTO bt_MapSpec( 
					itemid, 
					assemblyid,
					shareid,
					indoc_docspec_name,
					outdoc_docspec_name
				)
		VALUES( @ArtifactId, @AssemblyId, @shareid, @IndocDocSpecName, @OutdocDocSpecName )
	RETURN 0
GO
GRANT EXEC ON [dbo].[dpl_SaveMap] TO BTS_ADMIN_USERS
GO



CREATE PROCEDURE [dbo].[dpl_SaveSchemaProperty]
(
	@ModuleId int,
	@ItemId int,
	@MsgType nvarchar(2000),
	@NameSpace nvarchar(2000),
	@KeyName nvarchar(2000),
	@XPath nvarchar(4000)
)

AS

DECLARE @propSchemaMsgtype nvarchar(4000)
SELECT @propSchemaMsgtype = @NameSpace + N'#' + @KeyName

DECLARE @guidDocSpecID uniqueidentifier
SELECT @guidDocSpecID = (SELECT TOP 1 bt_DocumentSpec.id 
							FROM bt_DocumentSpec INNER JOIN bts_assembly a ON a.nID = bt_DocumentSpec.assemblyid 
							WHERE bt_DocumentSpec.msgtype = @propSchemaMsgtype
							ORDER BY a.nVersionMajor DESC, a.nVersionMinor DESC, a.nVersionBuild DESC, a.nVersionRevision DESC -- get the newest
						)
IF (@guidDocSpecID IS NULL) 
BEGIN
	DECLARE @sensitivePropertyId int
	SELECT @sensitivePropertyId = (SELECT id FROM [bt_SensitiveProperties] WHERE msgtype =  @propSchemaMsgtype)
	IF( @sensitivePropertyId IS NULL )
		RETURN -1 -- property not found - fatal error
	RETURN -2 -- property cannot be promoted - it's security sensitive
END

DECLARE @aName nvarchar (4000)
SELECT @aName = nvcName FROM bts_assembly WHERE nID = @ModuleId

DECLARE @isTracked int
SELECT  @isTracked = is_tracked
	FROM bt_Properties p
		INNER JOIN bts_assembly a ON p.nAssemblyID = a.nID
	WHERE a.nID = ( SELECT TOP 1 nID
			 FROM bts_assembly a1 
			 WHERE a1.nvcName = @aName
				AND a1.nID <> @ModuleId
			 ORDER BY a1.nVersionMajor DESC,a1.nVersionMinor DESC,a1.nVersionBuild  DESC,a1.nVersionRevision DESC -- get the newest
			) AND
		   p.namespace = @NameSpace AND
		   p.name = @KeyName

IF ( @isTracked IS NULL )
	SELECT @isTracked = 0

INSERT INTO bt_Properties (
		nAssemblyID,
		propSchemaID,
		msgtype,
		namespace,
		name,
		xpath,
		is_tracked,
		itemid
	)
	VALUES (
		@ModuleId, 
		@guidDocSpecID,
		@MsgType,
		@NameSpace,
		@KeyName,
		@XPath,
		@isTracked,
		@ItemId
	)
RETURN 0 -- success

GO
GRANT EXEC ON [dbo].[dpl_SaveSchemaProperty] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_SaveSensitiveProperty]
(
	@ModuleId int,
	@MsgType nvarchar(4000)
)

AS


INSERT INTO bt_SensitiveProperties (
		assemblyid,
		msgtype
	)
	VALUES (
		@ModuleId, 
		@MsgType
	)
RETURN 0 -- success

GO
GRANT EXEC ON [dbo].[dpl_SaveSensitiveProperty] TO BTS_ADMIN_USERS
GO

-- Enumerates all services in specified module
CREATE PROCEDURE [dbo].[dpl_Orchestration_Enum]
(
	@ModuleId as int
)

AS
set nocount on
set xact_abort on
select distinct
	[nID] as [Id],
	[uidGUID] as [Guid],
	[nvcNamespace] as [Namespace],
	[nvcName] as [Name],
	[nvcFullName] as [FullName],
	[nOrchestrationStatus] as [ServiceStatus],
	[adm_Host].[Name] as [HostName]
from [bts_orchestration] 
	left outer join [adm_Host] on [nAdminHostID] = [adm_Host].[Id]
where ([bts_orchestration].[nAssemblyID] = @ModuleId) 
order by [nvcFullName]
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Enum] TO BTS_ADMIN_USERS
GO



-- Enumerates all messages in specified operation
CREATE PROCEDURE [dbo].[dpl_Orchestration_Msgtype_Enum]
(
	@OperationId as int
)

AS
set nocount on
set xact_abort on

select
	[nID] as [Id],
	[nvcName] as [Name],
	[nMsgType] as [MsgType]
from [bts_service_msgtype]
where ([nOperationID] = @OperationId)
order by [nvcName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Msgtype_Enum] TO BTS_ADMIN_USERS
GO


-- Enumerates all operations in specified port
CREATE PROCEDURE [dbo].[dpl_Orchestration_Operation_Enum]
(
	@PortId as int
)

AS
set nocount on
set xact_abort on
select
	[bts_porttype_operation].[nID] as [Id],
	[bts_porttype_operation].[nvcName] as [Name],
	[bts_porttype_operation].[nType] as [OperationFlow]
from
	[bts_porttype_operation] join [bts_porttype] on ([bts_porttype_operation].[nPortTypeID] = [bts_porttype].[nID])
	join [bts_orchestration_port] on ([bts_porttype].[nID] = [bts_orchestration_port].[nPortTypeID])
where ([bts_orchestration_port].[nID] = @PortId)
order by [bts_porttype_operation].[nvcName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Operation_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO


CREATE PROCEDURE [dbo].[dpl_PortType_Operation_Save]
(
	@PortTypeID int,
	@Name nvarchar(256),
	@Type int
)

AS
set nocount on
set xact_abort on

INSERT INTO bts_porttype_operation
	( 
		nPortTypeID,
		nvcName, 
		nType 
	)
VALUES
	( 
		@PortTypeID, 
		@Name, 
		@Type
	)
RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_PortType_Operation_Save] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_Port_Activation_Operation_Save]
(
	@OrchestrationID int,
	@PortName nvarchar(256),
	@OperationName nvarchar(256)
)

AS
set nocount on
set xact_abort on

DECLARE @PortID int, @PortTypeID int ,@OperationID int

SELECT @PortID = nID, @PortTypeID = nPortTypeID FROM bts_orchestration_port
	WHERE nOrchestrationID = @OrchestrationID AND
		nvcName = @PortName 
		
SELECT @OperationID = nID FROM bts_porttype_operation
	WHERE nPortTypeID = @PortTypeID AND
		nvcName = @OperationName 
		

INSERT INTO bts_port_activation_operation
	( 
		nOrchestrationID,
		nPortID, 
		nOperationID 
	)
VALUES
	( 
		@OrchestrationID, 
		@PortID, 
		@OperationID
	)
RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Port_Activation_Operation_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_Operation_MsgType_Save]
(
	@OperationID int,
	@MsgTypeName nvarchar(256),
	@MsgTypeNamespace nvarchar(256),
	@MsgTypeAssemblyName nvarchar(256),
	@Type int
)

AS
set nocount on
set xact_abort on

DECLARE @MessageTypeID int
SELECT @MessageTypeID =  msgtype.nID FROM bts_messagetype msgtype
		INNER JOIN bts_assembly assembly ON msgtype.nAssemblyID = assembly.nID
	WHERE msgtype.nvcNamespace = @MsgTypeNamespace AND
		msgtype.nvcName = @MsgTypeName AND
		assembly.nvcFullName = @MsgTypeAssemblyName
		
IF ( @MessageTypeID IS NULL )
	RETURN -1

INSERT INTO bts_operation_msgtype
	( 
		nOperationID,
		nMessageTypeID, 
		nType 
	)
VALUES
	( 
		@OperationID, 
		@MessageTypeID, 
		@Type
	)
RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Operation_MsgType_Save] TO BTS_ADMIN_USERS
GO


-- Enumerates all service ports in specified service
CREATE PROCEDURE [dbo].[dpl_Orchestration_Port_Enum]
(
	@ServiceId as int
)

AS
set nocount on
set xact_abort on

select
	[nID] as [Id],
	[uidGUID] as [Guid],
	[nvcName] as [Name],
	[nPolarity] as [Polarity],
	[nBindingOption] as [BindingOption]
from [bts_orchestration_port]
where ([nOrchestrationID] = @ServiceId)
order by [nvcName]

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Port_Enum] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[dpl_MessageType_Save]
(
	@ModuleID as int,
	@ArtifactID as int,
	@Name as nvarchar(256),
	@Namespace as nvarchar(256)
)

AS
set nocount on
set xact_abort on

-- lookup porttype in latest version of named module

INSERT INTO bts_messagetype
	( 
		nAssemblyID,
		nvcName,
		nvcNamespace
	)
VALUES
	(
		@ModuleID,
		@Name,
		@Namespace
	)

RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_MessageType_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_MessageType_Part_Save]
(
	@MessageTypeID as int,
	@Name as nvarchar(256),
	@Namespace as nvarchar(256),
	@SchemaURTNamespace nvarchar(256),
	@SchemaURTTypename nvarchar(256)
)

AS
set nocount on
set xact_abort on

		INSERT INTO bts_messagetype_part
			( 
				nMessageTypeID,
				nvcName,
				nvcNamespace,
				nvcSchemaURTNameSpace,
				nvcSchemaURTTypeName
			)
		VALUES
			(
				@MessageTypeID,
				@Name,
				@Namespace,
				@SchemaURTNamespace,
				@SchemaURTTypename
			)

RETURN 0

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_MessageType_Part_Save] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_PortType_Save]
(
	@ModuleID as int,
	@ArtifactID as int,
	@Name as nvarchar(256),
	@Namespace as nvarchar(256)
)

AS
set nocount on
set xact_abort on

INSERT INTO bts_porttype
	( 
		nAssemblyID,
		nvcName,
		nvcNamespace
	)
VALUES
	(
		@ModuleID,
		@Name,
		@Namespace
	)

RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_PortType_Save] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_RoleLinkType_Save]
(
	@ModuleID as int,
	@ArtifactID as int,
	@Name as nvarchar(256),
	@Namespace as nvarchar(256)
)

AS
set nocount on
set xact_abort on

INSERT INTO bts_rolelink_type
	( 
		nAssemblyID,
		nvcName,
		nvcNamespace
	)
VALUES
	(
		@ModuleID,
		@Name,
		@Namespace
	)

RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_RoleLinkType_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_RoleLinkType_Save_Role]
(
	@ServiceLinkTypeID as int,
	@Name as nvarchar(256)
)

AS
set nocount on
set xact_abort on

		INSERT INTO bts_role
			( 
				nRoleLinkTypeID,
				nvcName
			)
		VALUES
			(
				@ServiceLinkTypeID,
				@Name
			)

RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_RoleLinkType_Save_Role] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_RoleLinkType_Save_Role_PortType]
(
	@RoleID as int,
	@PortTypeName as nvarchar(256),
	@PortTypeNamespace as nvarchar(256),
	@PortTypeAssemblyName nvarchar(256)
)

AS
	set nocount on
	set xact_abort on
	
	DECLARE @PortTypeID int
	SELECT @PortTypeID = porttype.nID FROM bts_porttype porttype
			INNER JOIN bts_assembly assembly ON porttype.nAssemblyID = assembly.nID
		WHERE porttype.nvcNamespace = @PortTypeNamespace AND
		      porttype.nvcName = @PortTypeName AND
		      assembly.nvcFullName = @PortTypeAssemblyName
	
	IF ( @PortTypeID IS NULL )
		RETURN -1
	
	INSERT INTO bts_role_porttype
		( 
			nRoleID,
			nPortTypeID
		)
	VALUES
		(
			@RoleID,
			@PortTypeID
		)
	
RETURN 1

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_RoleLinkType_Save_Role_PortType] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_Orchestration_Port_Save]
(
	@ServiceID as int,
	@PortGuid as nvarchar(256),
	@Name as nvarchar(256),
	@PortTypeName as nvarchar(256),
	@PortTypeNamespace as nvarchar(256),
	@PortTypeAssemblyName as nvarchar(256),
	@Polarity as int,
	@BindingOption as int,
	@IsLink as int,
	@RoleID as int 
)

AS
set nocount on
set xact_abort on

DECLARE @porttypeid AS INT
DECLARE @roleporttypeid AS INT

SELECT @porttypeid = porttype.nID 
	FROM bts_porttype porttype
		INNER JOIN bts_assembly assembly ON porttype.nAssemblyID = assembly.nID
	WHERE porttype.nvcNamespace = @PortTypeNamespace AND
	      porttype.nvcName = @PortTypeName AND
	      assembly.nvcFullName = @PortTypeAssemblyName

IF ( @porttypeid IS NULL )
	RETURN -1

IF ( @IsLink > 0 )
BEGIN
	SELECT @roleporttypeid = nID 
		FROM bts_role_porttype
		WHERE nRoleID = @RoleID AND
			nPortTypeID = @porttypeid 

	IF ( @roleporttypeid IS NULL )
		RETURN -2
END

INSERT INTO bts_orchestration_port
	( 
		uidGUID,
		nOrchestrationID,
		nPortTypeID,
		nvcName,
		nPolarity,
		nBindingOption,
		nRolePortTypeID,
		bLink
	)
VALUES
	(
		convert(uniqueidentifier,@PortGuid),
		@ServiceID,
		@porttypeid,
		@Name, 
		@Polarity, -- 1 = inbound, 2 = outbound
		@BindingOption,
			-- 1 = Logical (default)
			-- 2 = Physical
			-- 3 = Direct (Not available for binding thru Explorer)
			-- 4 = Dynamic
			-- 5 = ServiceLinkType
		@roleporttypeid,
		@IsLink 
	)
RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Port_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_Orchestration_RoleLink_Save]
(
	@Name as nvarchar(256),
	@ServiceID as int,
	@ServiceLinkTypeName as nvarchar(256),
	@ServiceLinkTypeNamespace as nvarchar(256),
	@RoleName as nvarchar(256),
	@ALTAssemblyName as nvarchar(256),
	@Implements as int,
	@BindingType as int,
	@RoleID as int OUTPUT
)

AS
set nocount on
set xact_abort on


SELECT @RoleID = rl.nID 
	FROM bts_role rl
		INNER JOIN bts_rolelink_type slt ON rl.nRoleLinkTypeID = slt.nID
		INNER JOIN bts_assembly assembly ON slt.nAssemblyID = assembly.nID
	WHERE slt.nvcNamespace = @ServiceLinkTypeNamespace AND
	      slt.nvcName = @ServiceLinkTypeName AND
	      rl.nvcName = @RoleName AND
	      assembly.nvcFullName = @ALTAssemblyName

IF ( @RoleID IS NULL )
	RETURN -1


INSERT INTO bts_rolelink
	( 
		nvcName,
		nOrchestrationID,
		nRoleID,
		bImplements,
		nBindingType
	)
VALUES
	(
		@Name, 
		@ServiceID,
		@RoleID,
		@Implements,
		@BindingType
			-- 1 = Logical (default)
			-- 2 = Physical
			-- 3 = Direct (Not available for binding thru Explorer)
			-- 4 = Dynamic
	)
RETURN @@IDENTITY

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_RoleLink_Save] TO BTS_ADMIN_USERS
GO



-- Unbinds all service ports in specified module
CREATE PROCEDURE [dbo].[dpl_Orchestration_Ports_Unbind]
(
	@ModuleId as int
)

AS
set nocount on
set xact_abort on
begin tran

DELETE [bts_orchestration_port_binding]
FROM			
	[bts_orchestration_port_binding]
	INNER JOIN [bts_orchestration_port] ON ([bts_orchestration_port_binding].[nOrcPortID] = [bts_orchestration_port].[nID])
	INNER JOIN [bts_orchestration] ON ([bts_orchestration_port].[nOrchestrationID] = [bts_orchestration].[nID])
WHERE ([bts_orchestration].[nAssemblyID] = @ModuleId) 

commit tran
set nocount off

GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Ports_Unbind] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_Orchestration_Invocation_Save] 
(
	@InvokingServiceArtifactId as int,
	@InvokedServiceName as nvarchar(256),
	@InvokedServiceAssembly as nvarchar(256),
	@InvokeType as int,
	@VersionMajor as int,
	@VersionMinor as int ,
	@VersionBuild as int ,
	@VersionRevision as int
)

AS
set nocount on
set xact_abort on

DECLARE @Id int
SELECT @Id = nID
FROM bts_assembly
WHERE
	(@InvokedServiceAssembly = nvcName) and
	(@VersionMajor = nVersionMajor) and
	(@VersionMinor = nVersionMinor) and
	(@VersionBuild = nVersionBuild) and
	(@VersionRevision = nVersionRevision) and
	(2 = nType) /* Still needed - ignore hidden assemblies */

IF (@@ROWCOUNT = 0)
	RETURN -1
	
DECLARE @InvokedId int	
SELECT @InvokedId = nID 
	FROM bts_orchestration
	WHERE nAssemblyID = @Id AND 
 		 nvcName = @InvokedServiceName
												
IF (@@ROWCOUNT = 0)
	RETURN -2
	
DECLARE @InvokingServiceId int

SELECT @InvokingServiceId = nID FROM bts_orchestration WHERE nItemID = @InvokingServiceArtifactId
	
INSERT INTO bts_orchestration_invocation(
	nOrchestrationID ,
	nInvokedOrchestrationID ,
	nInvokeType /* 0 - invalid, 1 - call, 2 - exec */
	) VALUES (
		@InvokingServiceId,
		@InvokedId,
		@InvokeType
	)


RETURN 0	/* OK */

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Invocation_Save] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[dpl_Orchestration_Save] 
(
	@ModuleId as int,
	@ArtifactId as int,
	@ServiceGuid as nvarchar(256),
	@Namespace as nvarchar(256),
	@Name as nvarchar(256),
	@FullName as nvarchar(256),
	@ServiceTypeGuid as nvarchar(256),
	@OrchestrationInfo as int
)

AS
set nocount on
set xact_abort on

INSERT INTO [bts_orchestration]
	(
		uidGUID,
		nAssemblyID, 
		nItemID,
		nvcNamespace,
		nvcName,
		nOrchestrationInfo,
		nOrchestrationStatus,
		dtModified
	)
	VALUES
	(
		convert(uniqueidentifier,@ServiceGuid),
		@ModuleId,
		@ArtifactId,
		@Namespace,
		@Name,
		@OrchestrationInfo,
		1, -- 0=Invalid, 1=Unenlisted, 2=Enlisted, 3=Started; new service is always Unenlisted.
		GETUTCDATE()
	)

RETURN @@IDENTITY
	
set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Save] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_Orchestration_Load] 
(
	@ArtifactId as int,
	@Id as int OUTPUT,
	@ServiceGuid as nvarchar(256) OUTPUT
)

AS
set nocount on
set xact_abort on

SELECT @Id = [bts_orchestration].[nID], @ServiceGuid = [bts_orchestration].[uidGUID]
FROM [bts_orchestration] 
	INNER JOIN bts_item ON ( [bts_orchestration].[nItemID] = [bts_item].[id] )
WHERE ([bts_orchestration].[nItemID] = @ArtifactId) AND ([bts_orchestration].[nvcFullName] = [bts_item].[FullName])
		
IF (@ServiceGuid IS NULL)
	RETURN -1
RETURN 1
	

set nocount off
GO
GRANT EXEC ON [dbo].[dpl_Orchestration_Load] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[dpl_VerifyReference] 
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int, 
	@VersionRevision int, 
	@Culture nvarchar(25),
	@PublicKeyToken nvarchar(256),
	@Type int,
	@ArtifactName nvarchar(256),
	@ArtifactType nvarchar(256)

AS
DECLARE @Id int

SELECT @Id = (
	SELECT TOP 1 nID
	FROM bts_assembly
	WHERE (nvcName = @Name) AND 
		nType = 2 AND
		nVersionMajor = @VersionMajor AND
		nVersionMinor = @VersionMinor AND
		nVersionBuild = @VersionBuild AND
		nVersionRevision = @VersionRevision AND
		nvcPublicKeyToken = @PublicKeyToken
	ORDER BY nvcPublicKeyToken DESC, nVersionMajor DESC, nVersionMinor DESC, nVersionBuild DESC, nVersionRevision DESC
)
	
/*IF @@ROWCOUNT = 0*/
IF (@Id IS NULL)
	RETURN 2 /* Indicate nonexistent module */

RETURN 0 /* Success */
GO

GRANT EXEC ON [dbo].[dpl_VerifyReference] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[dpl_VerifyAssemblyReferences]
	@Name nvarchar(256),
	@VersionMajor int,
	@VersionMinor int,
	@VersionBuild int,
	@VersionRevision int,
	@Culture nvarchar(25),
	@PublicKeyToken nvarchar(256)

AS
	DECLARE @ID int
	DECLARE @ret int

	DECLARE @rName nvarchar(256)
	DECLARE @rVersion nvarchar(12)
	DECLARE @rMinorVersion nvarchar(12)
	DECLARE @rBuildVersion nvarchar(12)
	DECLARE @rRevisionVersion nvarchar(12)
	DECLARE @rArtifactName nvarchar(256)
	DECLARE @rCulture nvarchar(256)
	DECLARE @rPublicKeyToken nvarchar(256)

	DECLARE @refName nvarchar(256)
	DECLARE @refType int
	DECLARE @refMajor int
	DECLARE @refMinor int
	DECLARE @refBuild int
	DECLARE @refRevision int
	DECLARE @refCulture nvarchar(256)
	DECLARE @refPublicKeyToken nvarchar(256)
	
	SELECT
		@ID = nID,
		@refName = nvcName,
		@refType = nType,
		@refMajor = nVersionMajor,
		@refMinor = nVersionMinor,
		@refBuild = nVersionBuild,
		@refRevision = nVersionRevision,
		@refCulture = nvcCulture,
		@refPublicKeyToken = nvcPublicKeyToken
	FROM bts_assembly
	WHERE
		(@Name = nvcName) and
		(@VersionMajor = nVersionMajor) and
		(@VersionMinor = nVersionMinor) and
		(@VersionBuild = nVersionBuild) and
		(@VersionRevision = nVersionRevision) and
		(@PublicKeyToken = nvcPublicKeyToken) and
		(nType > 0)
				
	IF @@ROWCOUNT = 0
		RETURN -1
				
	DECLARE refs_cur CURSOR LOCAL FAST_FORWARD FOR
	SELECT nvcAssemblyName, nvcVersionMajor, nvcVersionMinor, nvcVersionBuild, nvcVersionRevision, nvcItemName, nvcCulture, nvcPublicKeyToken
	FROM bts_itemreference
	WHERE (@ID = nReferringAssemblyID)
	OPEN refs_cur
	
	FETCH NEXT FROM refs_cur INTO @rName, @rVersion, @rMinorVersion, @rBuildVersion, @rRevisionVersion, @rArtifactName, @rCulture, @rPublicKeyToken 
	IF @@FETCH_STATUS <> 0 
		BEGIN
			CLOSE refs_cur
			DEALLOCATE refs_cur
			RETURN 0 /* OK, no references */
		END
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[#badreferences]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
	BEGIN
		DROP TABLE [dbo].[#badreferences]			
	END
	CREATE TABLE [dbo].[#badreferences] (
		[nReferringModuleID] [int] NOT NULL ,
		[nReferringModuleName] [nvarchar](256) NOT NULL ,
		[nReferringModuleType] [tinyint] NOT NULL ,
		[nReferringModuleMajor] [smallint] NOT NULL ,
		[nReferringModuleMinor] [smallint] NOT NULL ,
		[nReferringModuleBuild] [smallint] NOT NULL ,
		[nReferringModuleRevision] [smallint] NOT NULL ,
		[nErrorCode] [int] NOT NULL,
		[nvcModuleName] [nvarchar] (256) NOT NULL ,
		[nvcProductMajorVersion] [nvarchar] (10) NOT NULL ,
		[nvcProductMinorVersion] [nvarchar] (10) NOT NULL ,
		[nvcProductBuildVersion] [nvarchar] (10) NOT NULL ,
		[nvcProductRevisionVersion] [nvarchar] (10) NOT NULL ,
		[nvcArtifactName] [nvarchar] (256) NOT NULL 
	) 
	WHILE @@FETCH_STATUS = 0
	BEGIN
		-- forward reference: dbo.dpl_VerifyReference
		EXECUTE @ret = dbo.dpl_VerifyReference 	@Name = @rName ,
												@Type = '2' ,
												@VersionMajor = @rVersion ,
												@VersionMinor = @rMinorVersion ,
												@VersionBuild = @rBuildVersion,
												@VersionRevision = @rRevisionVersion,
												@ArtifactName = @rArtifactName ,
												@ArtifactType = '',
												@Culture = @rCulture,
												@PublicKeyToken = @rPublicKeyToken
		IF @ret <> 0
			INSERT INTO [#badreferences](	nReferringModuleID, 
											nReferringModuleName, 
											nReferringModuleType, 
											nReferringModuleMajor, 
											nReferringModuleMinor, 
											nReferringModuleBuild, 
											nReferringModuleRevision, 
											nErrorCode,
											nvcModuleName,
											nvcProductMajorVersion,
											nvcProductMinorVersion,
											nvcProductBuildVersion,
											nvcProductRevisionVersion,
											nvcArtifactName )
						VALUES( @ID,
								@refName,
								@refType,
								@refMajor,
								@refMinor,
								@refBuild,
								@refRevision,
								@ret,
								@rName,
								@rVersion,
								@rMinorVersion,
								@rBuildVersion,
								@rRevisionVersion,
								@rArtifactName )
		FETCH NEXT FROM refs_cur INTO @rName, @rVersion, @rMinorVersion, @rBuildVersion, @rRevisionVersion, @rArtifactName, @rCulture, @rPublicKeyToken 
	END
	
	CLOSE refs_cur
	DEALLOCATE refs_cur
	
	SELECT	nReferringModuleID,			--0
			nReferringModuleName,		--1
			nReferringModuleType,		--2
			nReferringModuleMajor,		--3
			nReferringModuleMinor,		--4
			nReferringModuleBuild,		--5
			nReferringModuleRevision,	--6
			nErrorCode,					--7
			nvcModuleName,				--8
			nvcProductMajorVersion,		--9
			nvcProductMinorVersion,		--10
			nvcProductBuildVersion,		--11
			nvcProductRevisionVersion,	--12
			nvcArtifactName				--13
			FROM [dbo].[#badreferences]
			

RETURN 0

GO
GRANT EXEC ON [dbo].[dpl_VerifyAssemblyReferences] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[bt_LoadPropertyInfoByNamespace]
@nvcNamespace nvarchar(256)

AS

set nocount on
set transaction isolation level read committed

declare @exists int
--Check to see if this is the xsd namespace. If not, assume it is the clr namespace
select @exists = count(*) FROM bt_XMLShare WHERE target_namespace = @nvcNamespace AND active = 1
if (@exists > 0)
BEGIN
	SELECT d.id, d.msgtype, d.property_clr_class_fqn, d.xsd_type
	FROM	bt_DocumentSpec d 
	    INNER JOIN bt_XMLShare x ON d.shareid=x.id
	    INNER JOIN bts_assembly a ON a.nID = d.assemblyid
	WHERE	x.target_namespace = @nvcNamespace 
	ORDER BY a.nvcName ASC, a.nvcPublicKeyToken ASC, a.nvcCulture ASC, a.nVersionMajor ASC, a.nVersionMinor ASC, a.nVersionRevision ASC, a.nVersionBuild ASC
END
ELSE
BEGIN
	SELECT d.id, d.msgtype, d.property_clr_class_fqn, d.xsd_type
	FROM	       bt_DocumentSpec d
        INNER JOIN bt_XMLShare x WITH (ROWLOCK) ON x.id = d.shareid
	    INNER JOIN bts_assembly a ON a.nID = d.assemblyid
	WHERE	d.clr_namespace = @nvcNamespace
	ORDER BY a.nvcName ASC, a.nvcPublicKeyToken ASC, a.nvcCulture ASC, a.nVersionMajor ASC, a.nVersionMinor ASC, a.nVersionRevision ASC, a.nVersionBuild ASC
END
		
GO
GRANT EXEC ON [dbo].[bt_LoadPropertyInfoByNamespace] TO BTS_HOST_USERS
GO

-----------------------------------------------------------------------------
--	Loads the properties for a schema by schema's strong name
--
--	Parameters:
--		@strongName: strong name of the schema
-----------------------------------------------------------------------------
CREATE procedure [dbo].[bt_LoadPropertiesForDocSpec]
@strongName nvarchar(1024)

AS
	set nocount on

	select	p.id, 
		p.name, 
		p.namespace, 
		p.xpath, 
		d.xsd_type, 
		p.is_tracked
	from	bt_Properties  p 
	inner join bt_DocumentSpec d on p.itemid = d.itemid -- join on item ids
	inner join bts_assembly a on a.nID = d.assemblyid
	where   d.schema_root_clr_fqn + ', ' + a.nvcFullName = @strongName 
		AND p.is_tracked <> 0 -- return only the tracked items	
		
	UNION
	
	select	
		docs.id,
		docs.schema_root_name, 
		shares.target_namespace,
		N'', -- xpath 
		docs.xsd_type, 
		docs.is_tracked
	FROM  	dbo.bt_DocumentSpec docs
	INNER JOIN dbo.bt_XMLShare shares  ON docs.shareid = shares.id
	WHERE	docs.is_property_schema <> 0
		AND docs.is_tracked <> 0 -- return only the tracked items

	set nocount off
GO
GRANT EXEC ON [dbo].[bt_LoadPropertiesForDocSpec] TO BTS_HOST_USERS
GO

-----------------------------------------------------------------------------
--	Loads the schema info by schema's strong name
--
--	Parameters:
--		@name: strong name of the schema
--		@nSame (output): internal check for DocSpec Interface
-----------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bt_LoadDocSpecByName]
@name nvarchar(1024),
@nSame int OUTPUT

AS
	set nocount on

	set @nSame = 0
	if	(@name = N'Unparsed Interchange')
		OR (@name = N'Serialized Interchange')
		OR (@name = N'http://schemas.microsoft.com/BizTalk/2003/Any#Root')
	begin
		select	cast (N'{00000000-0000-0000-0000-000000000001}' as uniqueidentifier),
				getutcdate(),
				@name,
				@name,
				N'Body_XPath',
				cast (N'{00000000-0000-0000-0000-000000000001}' as uniqueidentifier),
				@name,
				@name,
				null -- xs.content
	end
	else
	begin
		select	ds.id,
				ds.date_modified,
				ds.docspec_name,
				ds.msgtype,
				ds.body_xpath,
				xs.id,
				xs.target_namespace,
				@name,
				null -- xs.content
		from	bt_DocumentSpec ds
		inner join bt_XMLShare xs on xs.id = ds.shareid
		inner join bts_assembly a on a.nID = ds.assemblyid
		where   ds.schema_root_clr_fqn + ', ' + a.nvcFullName = @name 
	end

	set nocount off
GO
GRANT EXEC ON [dbo].[bt_LoadDocSpecByName] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[bt_LoadDocSpecByID]
@id uniqueidentifier,
@nUpdate int,
@mytime datetime,
@nSame int OUTPUT

AS
	set nocount on
	declare @dbtime datetime
	select @nSame = 0
	if ( (@nUpdate > 0) AND (@mytime > 0) ) 
	begin
		select top 1 @dbtime = d.date_modified
			from    bt_DocumentSpec d WITH (ROWLOCK)
			where   d.id = @id 
		if (DATEDIFF(second, @dbtime, @mytime) = 0)
		begin
		   select @nSame = 1        
		   return
		end     
	end


	DECLARE @sid uniqueidentifier
	SELECT @sid = xs.id 
		FROM bt_XMLShare xs 
		INNER JOIN bt_DocumentSpec ds ON ds.shareid = xs.id
		WHERE ds.id = @id 


	SELECT d.id, d.date_modified, d.docspec_name, d.msgtype doctype, d.body_xpath, x.id, 
		x.target_namespace, 
		d.schema_root_clr_fqn + ', ' + a.nvcFullName,
--		d.property_clr_class_fqn,
		NULL -- x.content 
	FROM    bt_DocumentSpec d WITH (ROWLOCK),
		bt_XMLShare x WITH (ROWLOCK),
		bts_assembly a WITH (ROWLOCK)
	WHERE    d.id = @id	
		AND d.assemblyid = a.nID
		AND ( x.id = d.shareid 
				OR 
				x.id IN ( SELECT id from bt_XMLShare xs1 WITH (ROWLOCK)
							WHERE xs1.target_namespace IN (
								SELECT target_namespace 
								FROM bt_XMLShareReferences xsr WITH (ROWLOCK)
								WHERE xsr.shareid = @sid 
							) AND
						xs1.active = 1
				)
			)

GO
GRANT EXEC ON [dbo].[bt_LoadDocSpecByID] TO BTS_HOST_USERS
GO

CREATE procedure [dbo].[bt_LoadDocSpecByType]
@doctype nvarchar(256),
@nUpdate int,
@mytime datetime,
@nSame int OUTPUT

AS
	set nocount on

	declare @dbtime datetime

	select @nSame = 0
	if ( (@nUpdate > 0) AND (@mytime > 0) ) 
	begin
		select top 1 @dbtime = d.date_modified
			from           bt_DocumentSpec d WITH (ROWLOCK)
		        INNER JOIN bt_XMLShare x WITH (ROWLOCK) ON x.id = d.shareid
			where   d.msgtype = @doctype AND x.active = 1 

		if (DATEDIFF(second, @dbtime, @mytime) = 0)
		begin
		   select @nSame = 1        
		   return
		end     
	end

                
	DECLARE @sid uniqueidentifier
	SELECT @sid = xs.id 
		FROM bt_XMLShare xs 
		INNER JOIN bt_DocumentSpec ds ON ds.shareid = xs.id
		WHERE ds.msgtype = @doctype	AND xs.active = 1 


	SELECT d.id, d.date_modified, d.docspec_name, d.msgtype doctype, d.body_xpath, x.id, 
		x.target_namespace, d.property_clr_class_fqn, x.content 
	FROM    bt_DocumentSpec d WITH (ROWLOCK),
		    bt_XMLShare x WITH (ROWLOCK)
	WHERE  d.msgtype = @doctype
			AND
			( x.id = d.shareid 
				OR 
				x.id IN ( SELECT id from bt_XMLShare xs1 WITH (ROWLOCK)
					WHERE xs1.target_namespace IN (
						SELECT target_namespace 
						FROM bt_XMLShareReferences xsr WITH (ROWLOCK)
						WHERE xsr.shareid = @sid 
					) AND
					xs1.active = 1
				)
			)
						AND
					x.active = 1 
                
GO
GRANT EXEC ON [dbo].[bt_LoadDocSpecByType] TO BTS_HOST_USERS
GO

CREATE procedure [dbo].[bt_GetDocSpecInfoByMsgType]
@nvcMsgtype nvarchar(256),
@iPipelineAssemblyId int,
@iFlag int OUTPUT -- 0: No schema matched, 1: 1 schema matched, n > 1: multiple schema matched (ambiguity)
AS

--
-- Search by MsgType only
--
DECLARE @count int
SELECT 	@count = COUNT(*)
FROM   	bt_DocumentSpec d WITH (ROWLOCK),
		bt_XMLShare x WITH (ROWLOCK)
WHERE	d.msgtype = @nvcMsgtype AND x.id = d.shareid AND
        x.active = 1

SET @iFlag = @count

IF (@count <= 1)
    -- At most one schema of the given msg type was found
	-- Thus, no duplicated schemas. 
	BEGIN

        SELECT 	d.id, d.msgtype, d.docspec_name, d.clr_assemblyname
		FROM   	bt_DocumentSpec d WITH (ROWLOCK),
		        bt_XMLShare x WITH (ROWLOCK)
		WHERE	d.msgtype = @nvcMsgtype AND x.id = d.shareid AND
                x.active = 1

		RETURN
	END
ELSE
	BEGIN
		--
		-- There are duplicated schemas
		-- 1. Pick the schema that's defined in the same assembly as the pipeline's
		-- 2. Otherwise, see if the schema is defined in an assembly with the
		-- 	same public key as the pipeline assembly's.
		--

        --
        -- Search by MsgType + AssemblyID
        --
        SELECT 	@count = COUNT(*)
        FROM   	bt_DocumentSpec d WITH (ROWLOCK),
		        bt_XMLShare x WITH (ROWLOCK)
        WHERE	d.msgtype = @nvcMsgtype AND x.id = d.shareid AND x.active = 1 AND d.assemblyid = @iPipelineAssemblyId 

		-- If there is 0 row returned, should not change the flag
		IF (@count <> 0)
			SET @iFlag = @count

        IF (@count = 1)
			BEGIN
				--
				-- Find the schema in the pipeline assembly
				-- No duplicated schemas can be defined in one assembly
				-- So ASSERT( @@ROWCOUNT == 1 ): This is THE one.							
				-- And, @iFlag is 1, which is the @count value
				--
				SELECT 	d.id, d.msgtype, d.docspec_name, d.clr_assemblyname
				FROM   	bt_DocumentSpec d WITH (ROWLOCK),
		                bt_XMLShare x WITH (ROWLOCK)
				WHERE	d.msgtype = @nvcMsgtype AND x.id = d.shareid AND x.active = 1 AND d.assemblyid = @iPipelineAssemblyId 

				RETURN
			END
		ELSE
			BEGIN
			    -- EAP Release Note: In EAP, same msgtype of different versions is not supported, thus TOP 1 and order by etc. are not implemented
			    -- BTS 2004 SP1 Release Note: Same msgtype of different versions should work (though not side by side, just highest version), 
			    -- based on examining bt_XMLShare.active flag
			    
				-- 
				-- Look for schema in assemblies signed with pipeline assembly's public key
				-- If multiple are found, use the highest version
				-- The highest version coincides with the highest assemblyid,
				-- so we will ORDER BY assemblyid, and pick the TOP 1
				--

				-- find the public key of the pipeline assembly
				-- multiple may be returned. the caller will check the rowcount.
				DECLARE @nvcPublicKeyToken nvarchar(256)
				SELECT @nvcPublicKeyToken = a0.nvcPublicKeyToken
				FROM bts_assembly a0
				WHERE a0.nID = @iPipelineAssemblyId
                
				SELECT d.id, d.msgtype, d.docspec_name, d.clr_assemblyname
				FROM   	bt_DocumentSpec d WITH (ROWLOCK)
				        INNER JOIN bt_XMLShare x WITH (ROWLOCK) ON x.id = d.shareid
						INNER JOIN bts_assembly a WITH (ROWLOCK) ON d.assemblyid = a.nID
				WHERE	d.msgtype = @nvcMsgtype AND
				        x.active = 1 AND
						a.nvcPublicKeyToken = @nvcPublicKeyToken
				
				-- If there is 0 row returned, should not change the flag
				SET @count = @@ROWCOUNT
				IF (@count <> 0)
					SET @iFlag = @count
				
				RETURN
			END
	END
GO
GRANT EXEC ON [dbo].[bt_GetDocSpecInfoByMsgType] TO BTS_HOST_USERS
GO

--
-- @name should be the weak name (.net type simple name) of the schema
--
CREATE PROCEDURE [dbo].[bt_GetDocSpecInfoByName]
@name nvarchar(256),
@iPipelineAssemblyId int    -- also the assembly that implements the schema
AS
	SELECT d.id, d.msgtype, d.docspec_name, d.clr_assemblyname
	FROM           bt_DocumentSpec d WITH (ROWLOCK) 
	    INNER JOIN bt_XMLShare x WITH (ROWLOCK) ON x.id = d.shareid
	WHERE    d.docspec_name = @name AND d.assemblyid = @iPipelineAssemblyId
GO
GRANT EXEC ON [dbo].[bt_GetDocSpecInfoByName] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[bt_GetDocSpecInfoByID]
@id uniqueidentifier
AS
	set nocount on
	
	SELECT d.id, d.msgtype, d.docspec_name, d.clr_assemblyname 
	FROM    bt_DocumentSpec d WITH (ROWLOCK) 
	WHERE    d.id = @id
GO
GRANT EXEC ON [dbo].[bt_GetDocSpecInfoByID] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[bt_GetPipelineIdFromName]
@nvcAssemblyName nvarchar(256),
@iId int OUTPUT
AS
	set nocount on
	
	SELECT @iId = nID
	FROM bts_assembly
	WHERE nvcFullName = @nvcAssemblyName

GO
GRANT EXEC ON [dbo].[bt_GetPipelineIdFromName] TO BTS_HOST_USERS
GO

  --/================================================/--
  --/========== Tracking Stored Procedures ==========/--
  --/================================================/--

CREATE PROCEDURE [dbo].[dta_LoadSystemPropId]
@nvcPropName1 nvarchar(256),
@nvcPropName2 nvarchar(256),
@nvcPropName3 nvarchar(256),
@nvcPropName4 nvarchar(256),
@nvcPropName5 nvarchar(256),
@uidPropId1 uniqueidentifier output,
@uidPropId2 uniqueidentifier output,
@uidPropId3 uniqueidentifier output,
@uidPropId4 uniqueidentifier output,
@uidPropId5 uniqueidentifier output

AS
	set nocount on
	
	select @uidPropId1 = id from bt_DocumentSpec where msgtype = @nvcPropName1
	select @uidPropId2 = id from bt_DocumentSpec where msgtype = @nvcPropName2
	select @uidPropId3 = id from bt_DocumentSpec where msgtype = @nvcPropName3
	select @uidPropId4 = id from bt_DocumentSpec where msgtype = @nvcPropName4
	select @uidPropId5 = id from bt_DocumentSpec where msgtype = @nvcPropName5
GO
GRANT EXEC ON [dbo].[dta_LoadSystemPropId] TO BTS_ADMIN_USERS, BTS_OPERATORS
GO

----------------------------------- Cross-Referencing (XREF)-------------------------------
CREATE PROC [dbo].[xref_GetAppID]
@idXRef 	nvarchar(50),
@appInstance 	nvarchar(50),
@commonID	nvarchar(50),
@appID		nvarchar(255) OUTPUT,
@idAndAppExist 	tinyint OUTPUT
AS
SET @idAndAppExist = 1

SELECT @appID = ird.appID  
FROM xref_IDXRefData ird 
    INNER JOIN xref_AppInstance ai ON ai.appInstanceID = ird.appInstanceID
	INNER JOIN xref_IDXRef ir ON ir.idXRefID = ird.idXRefID
WHERE ir.idXRef = @idXRef AND ai.appInstance = @appInstance AND ird.commonID = @commonID

IF @appID is NULL
	IF (NOT EXISTS (SELECT [idXRefID] FROM xref_IDXRef WHERE idXRef = @idXRef) OR
		NOT EXISTS (SELECT [appInstanceID] FROM xref_AppInstance WHERE appInstance = @appInstance))
		SET @idAndAppExist = 0
GO
GRANT EXEC ON [dbo].[xref_GetAppID] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_GetCommonID]
@idXRef 	nvarchar(50),
@appInstance 	nvarchar(50),
@appID		nvarchar(255),
@commonID	nvarchar(50) OUTPUT,
@idAndAppExist 	tinyint OUTPUT
AS
SET @idAndAppExist = 1
SELECT @commonID = ird.commonID
FROM xref_IDXRefData ird
    INNER JOIN xref_AppInstance ai ON ai.appInstanceID = ird.appInstanceID
	INNER JOIN xref_IDXRef ir ON ir.idXRefID = ird.idXRefID
WHERE ir.idXRef = @idXRef AND ai.appInstance = @appInstance AND ird.appID = @appID

IF @commonID is NULL
	IF (NOT EXISTS (SELECT [idXRefID] FROM xref_IDXRef WHERE idXRef = @idXRef) OR
		NOT EXISTS (SELECT [appInstanceID] FROM xref_AppInstance WHERE appInstance = @appInstance))
		SET @idAndAppExist = 0
GO
GRANT EXEC ON [dbo].[xref_GetCommonID] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_SetCommonID]
@idXRef 	nvarchar(50),
@appInstance 	nvarchar(50),
@appID		nvarchar(255),
@commonID	nvarchar(50) OUTPUT,
@idAndAppExist	tinyint OUTPUT
AS
DECLARE @idXRefID int
DECLARE @appInstanceID int

SELECT @idXRefID = idXRefID FROM xref_IDXRef WHERE idXRef = @idXRef

SELECT @appInstanceID = appInstanceID FROM xref_AppInstance WHERE appInstance = @appInstance

IF @idXRefID IS NULL OR @appInstanceID IS NULL
BEGIN
	SET @idAndAppExist = 0
	RETURN
END

SET @idAndAppExist = 1
DECLARE @tempCommonID nvarchar(50)
SELECT @tempCommonID = commonID
	FROM xref_IDXRefData
	WHERE idXRefID = @idXRefID AND appInstanceID = @appInstanceID AND appID = @appID
IF @tempCommonID is NULL
INSERT xref_IDXRefData (idXRefID, appInstanceID, appID, commonID)
VALUES (@idXRefID, @appInstanceID, @appID, @commonID)
ELSE
SET @commonID = @tempCommonID
GO
GRANT EXEC ON [dbo].[xref_SetCommonID] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_RemoveAppID]
@idXRef 		nvarchar(50),
@appInstance 	nvarchar(50),
@appID			nvarchar(255),
@rowsDeleted    tinyint OUTPUT,
@idAndAppExist 	tinyint OUTPUT
AS
SET @idAndAppExist = 1

DELETE xref_IDXRefData
FROM xref_IDXRefData ird
     INNER JOIN xref_AppInstance ai ON ai.appInstanceID = ird.appInstanceID
	 INNER JOIN xref_IDXRef ir ON ir.idXRefID = ird.idXRefID
WHERE ir.idXRef = @idXRef AND ai.appInstance = @appInstance AND ird.appID = @appID

SET @rowsDeleted = @@ROWCOUNT

IF  @rowsDeleted = 0
	IF (NOT EXISTS (SELECT [idXRefID] FROM xref_IDXRef WHERE idXRef = @idXRef) OR
		NOT EXISTS (SELECT [appInstanceID] FROM xref_AppInstance WHERE appInstance = @appInstance))
		SET @idAndAppExist = 0
GO
GRANT EXEC ON [dbo].[xref_RemoveAppID] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_GetCommonValue]
@valueXRef 		nvarchar(50),
@appType 		nvarchar(50),
@appValue		nvarchar(50),
@commonValue		nvarchar(50) OUTPUT,
@valueAndAppExist	tinyint OUTPUT
AS
DECLARE @valueXRefID int
DECLARE @appTypeID int

SELECT @valueXRefID = valueXRefID FROM xref_ValueXRef WHERE valueXRefName = @valueXRef

SELECT @appTypeID = appTypeID FROM xref_AppType WHERE appType = @appType

IF @valueXRefID IS NULL OR @appTypeID IS NULL
BEGIN
	SET @valueAndAppExist = 0
	RETURN
END

SET @valueAndAppExist = 1

SELECT @commonValue = commonValue
FROM xref_ValueXRefData
WHERE valueXRefID = @valueXRefID AND appTypeID = @appTypeID AND appValue = @appValue
GO
GRANT EXEC ON [dbo].[xref_GetCommonValue] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_GetAppValue]
@valueXRef 		nvarchar(50),
@appType 		nvarchar(50),
@commonValue		nvarchar(50),
@appValue		nvarchar(50) OUTPUT,
@valueAndAppExist	tinyint OUTPUT
AS
DECLARE @valueXRefID int
DECLARE @appTypeID int

SELECT @valueXRefID = valueXRefID FROM xref_ValueXRef WHERE valueXRefName = @valueXRef

SELECT @appTypeID = appTypeID FROM xref_AppType WHERE appType = @appType

IF @valueXRefID IS NULL OR @appTypeID IS NULL
BEGIN
	SET @valueAndAppExist = 0
	RETURN
END
SET @valueAndAppExist = 1
SELECT @appValue = appValue
FROM xref_ValueXRefData
WHERE valueXRefID = @valueXRefID AND appTypeID = @appTypeID AND commonValue = @commonValue
GO
GRANT EXEC ON [dbo].[xref_GetAppValue] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_FormatMessage]
@code 		nvarchar(50),
@lang 		nvarchar(50)
AS
DECLARE @msgID int
SELECT @msgID = msgID
FROM xref_MessageDef
WHERE msgCode = @code
IF @msgID is NULL
BEGIN
	RETURN
END
-- get msgText
SELECT msgText
FROM xref_MessageText
WHERE msgID = @msgID AND lang = @lang
-- get msgArgs
SELECT ma.argName, id.idXRef, v.valueXRefName
FROM xref_MessageArgument ma
    INNER JOIN xref_IDXRef id ON ma.argIDXRefID = id.idXRefID
	INNER JOIN xref_ValueXRef v ON ma.argValueXRefID = v.valueXRefID
WHERE ma.msgID = @msgID
ORDER BY ma.argSequenceNum
GO
GRANT EXEC ON [dbo].[xref_FormatMessage] TO BTS_HOST_USERS
GO

CREATE PROC [dbo].[xref_Cleanup]
AS
TRUNCATE TABLE [dbo].[xref_AppInstance]
TRUNCATE TABLE [dbo].[xref_AppType]
TRUNCATE TABLE [dbo].[xref_IDXRef]
INSERT INTO [dbo].[xref_IDXRef] (idXRef)
VALUES (N'')
TRUNCATE TABLE [dbo].[xref_IDXRefData]
TRUNCATE TABLE [dbo].[xref_MessageArgument]
TRUNCATE TABLE [dbo].[xref_MessageDef]
TRUNCATE TABLE [dbo].[xref_MessageText]
TRUNCATE TABLE [dbo].[xref_ValueXRef]
INSERT INTO [xref_ValueXRef] (valueXRefName)
VALUES (N'')
TRUNCATE TABLE [dbo].[xref_ValueXRefData]
GO
GRANT EXEC on [dbo].[xref_Cleanup] to BTS_ADMIN_USERS
GO
