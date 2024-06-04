--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Remove existing foreign key constaints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
--// Remove constraints created by BTS 2006 or BTS2004 (when this is executed by upgrade code) SQL scripts
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	exec bts_removeconstraints

	-- Remove system stored procedures
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
		drop procedure [dbo].[bts_removeconstraints]
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
		drop procedure [dbo].[bts_addconstraints]
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Create stored procedure for removing foreign key constaints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
CREATE PROCEDURE [dbo].[bts_removeconstraints]
AS

	-- Foreign key constraints from Admin
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ReceiveLocation_fk_ReceivePort]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[adm_ReceiveLocation] drop constraint adm_ReceiveLocation_fk_ReceivePort

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ReceiveLocation_fk_Pipeline]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[adm_ReceiveLocation] drop constraint adm_ReceiveLocation_fk_Pipeline

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ReceiveLocation_fk_SendPipeline]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[adm_ReceiveLocation] drop constraint adm_ReceiveLocation_fk_SendPipeline
	------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Foreign key constraints from Deployment
	--**********************************************************************************************************************
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bt_documentspec_bt_xmlshare]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bt_DocumentSpec] DROP CONSTRAINT [fk_bt_documentspec_bt_xmlshare]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bt_documentspec_bts_item]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bt_DocumentSpec] DROP CONSTRAINT [fk_bt_documentspec_bts_item]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bt_mapspec_bt_xmlshare]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bt_MapSpec] DROP CONSTRAINT [fk_bt_mapspec_bt_xmlshare]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bt_mapspec_bts_item]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bt_MapSpec] DROP CONSTRAINT [fk_bt_mapspec_bts_item]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bts_item_bts_assembly]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bts_item] DROP CONSTRAINT [fk_bts_item_bts_assembly]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bts_libreference_bts_assembly]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bts_libreference] DROP CONSTRAINT [fk_bts_libreference_bts_assembly]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bts_libreference_bts_assembly1]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bts_libreference] DROP CONSTRAINT [fk_bts_libreference_bts_assembly1]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[fk_bts_orchestration_bts_item]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
	ALTER TABLE [dbo].[bts_orchestration] DROP CONSTRAINT [fk_bts_orchestration_bts_item]


	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Foreign key constraints from PartnerMgmt
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_receiveport_foreign_sendpipelineid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_receiveport] drop constraint [bts_receiveport_foreign_sendpipelineid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_foreign_sendpipelineid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport] drop constraint [bts_sendport_foreign_sendpipelineid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_foreign_applicationtypeid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport] drop constraint [bts_sendport_foreign_applicationtypeid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_foreign_receivepipelineid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport] drop constraint [bts_sendport_foreign_receivepipelineid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_transport_foreign_transporttypeid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport_transport] drop constraint [bts_sendport_transport_foreign_transporttypeid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_transform_foreign_transformid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport_transform] drop constraint [bts_sendport_transform_foreign_transformid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_receiveport_transform_foreign_transformid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_receiveport_transform] drop constraint [bts_receiveport_transform_foreign_transformid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_orcport_binding_foreign_orcportid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_orchestration_port_binding] drop constraint [bts_orcport_binding_foreign_orcportid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_enlistedparty_foreign_roleid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_enlistedparty] drop constraint [bts_enlistedparty_foreign_roleid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_enlistedparty_port_mapping_foreign_roleporttypeid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_enlistedparty_port_mapping] drop constraint [bts_enlistedparty_port_mapping_foreign_roleporttypeid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_enlistedparty_operation_mapping_foreign_operationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_enlistedparty_operation_mapping] drop constraint [bts_enlistedparty_operation_mapping_foreign_operationid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_application_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_application_reference] drop constraint [bts_application_foreign_applicationid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_refapplication_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_application_reference] drop constraint [bts_refapplication_foreign_applicationid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendport_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendport] drop constraint [bts_sendport_foreign_applicationid]
		
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_sendportgroup_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_sendportgroup] drop constraint [bts_sendportgroup_foreign_applicationid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_receiveport_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_receiveport] drop constraint [bts_receiveport_foreign_applicationid]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_assembly_foreign_applicationid]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
		alter table [dbo].[bts_assembly] drop constraint [bts_assembly_foreign_applicationid]
		
	----------------------------------------------------------------------------------------------------------------------------------------------------------------------
	-- Application binding check constraints
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_adm_ReceiveLocation_sendpipeline]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[adm_ReceiveLocation] drop constraint [CK_applicationbinding_adm_ReceiveLocation_sendpipeline]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_adm_ReceiveLocation_receivepipeline]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[adm_ReceiveLocation] drop constraint [CK_applicationbinding_adm_ReceiveLocation_receivepipeline]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_orchestration_port_binding_sendportgroup]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_orchestration_port_binding] drop constraint [CK_applicationbinding_bts_orchestration_port_binding_sendportgroup]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_orchestration_port_binding_receiveport]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_orchestration_port_binding] drop constraint [CK_applicationbinding_bts_orchestration_port_binding_receiveport]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_orchestration_port_binding_sendport]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_orchestration_port_binding] drop constraint [CK_applicationbinding_bts_orchestration_port_binding_sendport]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_receiveport_transform_schema]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_receiveport_transform] drop constraint [CK_applicationbinding_bts_receiveport_transform_schema]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_spg_sendport]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_spg_sendport] drop constraint [CK_applicationbinding_bts_spg_sendport]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_sendport_transform_schema]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_sendport_transform] drop constraint [CK_applicationbinding_bts_sendport_transform_schema]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_sendport_sendpipeline]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_sendport] drop constraint [CK_applicationbinding_bts_sendport_sendpipeline]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_sendport_sendportgroup]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_sendport] drop constraint [CK_applicationbinding_bts_sendport_sendportgroup]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_sendportgroup_sendport]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_sendportgroup] drop constraint [CK_applicationbinding_bts_sendportgroup_sendport]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_bts_application_reference_cyclic]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_application_reference] drop constraint [CK_bts_application_reference_cyclic]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_applicationbinding_bts_enlistedparty_operation_mapping]') and OBJECTPROPERTY(id, N'IsCheckCnst') = 1)
		alter table [dbo].[bts_enlistedparty_operation_mapping] drop constraint [CK_applicationbinding_bts_enlistedparty_operation_mapping]

GO

--// Remove constraints created by BTS 2006 SQL scripts
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removeconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	exec bts_removeconstraints
GO

	--///////////////////////////////////////////////////////////////////////////
	--// Remove Application binding constraints related functions
	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetOrchestrationPortAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetOrchestrationPortAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetPipelineAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetPipelineAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetReceiveLocationAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetReceiveLocationAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetReceivePortAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetReceivePortAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetReferencesOfApp]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetReferencesOfApp]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetSchemaAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetSchemaAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetSendPortAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetSendPortAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetSendPortGroupAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetSendPortGroupAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetRolelinkTypeNonSystemAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetRolelinkTypeNonSystemAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_GetPartySendPortAppId]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_GetPartySendPortAppId]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_IsReferencedBy]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_IsReferencedBy]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_CanReferenceBeDeleted]') and xtype in (N'FN', N'IF', N'TF'))
		drop function [dbo].[adm_CanReferenceBeDeleted]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CK_application_reference_delete]') and OBJECTPROPERTY(id, N'IsTrigger') = 1)
		drop trigger [CK_application_reference_delete]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ValidateApplicationBinding_Sp]') and xtype in (N'FN', N'IF', N'TF'))
	drop function [dbo].[adm_ValidateApplicationBinding_Sp]

	if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ValidateApplicationBinding_Spg]') and xtype in (N'FN', N'IF', N'TF'))
	drop function [dbo].[adm_ValidateApplicationBinding_Spg]

GO

--// Create Application binding constraints related user defined functions //--
CREATE FUNCTION [dbo].[adm_GetOrchestrationPortAppId] (@orchestrationPortId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId=bts_assembly.nApplicationID 
		from bts_orchestration_port, bts_orchestration, bts_assembly
		where bts_orchestration_port.nID=@orchestrationPortId
		and bts_orchestration_port.nOrchestrationID=bts_orchestration.nID
		and bts_orchestration.nAssemblyID=bts_assembly.nID
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetPipelineAppId] (@pipelineId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = nApplicationID 
		from bts_pipeline, bts_assembly 
		where bts_pipeline.Id=@pipelineId 
		and bts_pipeline.nAssemblyID=bts_assembly.nID
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetReceivePortAppId] (@receivePortId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = nApplicationID 
		from bts_receiveport 
		where nID=@receivePortId
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetSchemaAppId] (@schemaId uniqueidentifier) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = bts_assembly.nApplicationID 
		from bt_MapSpec, bts_assembly 
		where bt_MapSpec.id=@schemaId 
		and bt_MapSpec.assemblyid=bts_assembly.nID
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetSendPortAppId] (@sendPortId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = nApplicationID from bts_sendport where nID=@sendPortId
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetSendPortGroupAppId] (@sendPortGroupId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = nApplicationID from bts_sendportgroup where nID=@sendPortGroupId
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetPartySendPortAppId] (@nPartySendPortID int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = bts_sendport.nApplicationID
		from bts_party_sendport,
			bts_sendport
		where bts_party_sendport.nID=@nPartySendPortID
			and bts_party_sendport.nSendPortID = bts_sendport.nID
		
	return @nAppId
END

GO

CREATE FUNCTION [dbo].[adm_GetRolelinkTypeNonSystemAppId] (@portMappingId int) RETURNS int
AS
BEGIN
	declare @nAppId as int
	select @nAppId = bts_assembly.nApplicationID 
		from
			bts_enlistedparty_port_mapping, 
			bts_role_porttype,
			bts_porttype,
			bts_assembly
		where
				bts_enlistedparty_port_mapping.nID = @portMappingId
			and bts_enlistedparty_port_mapping.nRolePortTypeID = bts_role_porttype.nID
			and bts_role_porttype.nPortTypeID = bts_porttype.nID
			and bts_porttype.nAssemblyID=bts_assembly.nID
		
	-- PF-26539 Return null for system app. This allows to bypass reference enforcement
	declare @nAppIdNoSystemApp as int
 	select @nAppIdNoSystemApp = bts_application.nID
 		from bts_application
 		where isSystem = 0 and nID = @nAppId

	return @nAppIdNoSystemApp
END

GO

CREATE FUNCTION [dbo].[adm_GetReferencesOfApp] (@thisAppId int ) 
RETURNS @references table (referenceId int)
AS
BEGIN
	insert @references
		select nReferencedApplicationID from bts_application_reference where nApplicationID = @thisAppId

	declare temp_Cursor cursor dynamic for 
		select referenceId from @references

	open temp_Cursor

	fetch next from temp_Cursor into @thisAppId
	while @@FETCH_STATUS = 0
	begin
		insert @references
			select nReferencedApplicationID from bts_application_reference where nApplicationID = @thisAppId
		fetch next from temp_Cursor into @thisAppId
	end

	close temp_Cursor
	deallocate temp_Cursor
	return
END

GO

CREATE FUNCTION [dbo].[adm_IsReferencedBy]
(
	@thisAppId int,
	@tobeAddedAppId int
) RETURNS bit
AS
BEGIN
	if(IsNull(@thisAppId, N'') = N'')
		return 1

	if(IsNull(@tobeAddedAppId, N'') = N'')
		return 1

	if @thisAppId = @tobeAddedAppId
		return 1

	-- Search references
	if exists( select referenceId from dbo.adm_GetReferencesOfApp(@thisAppId)
		where referenceId = @tobeAddedAppId )
	begin
		return 1
	end

	return 0
END

GO

CREATE FUNCTION [dbo].[adm_CanReferenceBeDeleted]
(
	@appId int,
	@referenceAppId int
) RETURNS bit
AS
BEGIN
	if(IsNull(@appId, N'') = N'')
		return 1

	if(IsNull(@referenceAppId, N'') = N'')
		return 1

	-- check if a receive location in appId refers to a send pipeline in referenceAppId
	if exists( select 1 from adm_ReceiveLocation, bts_receiveport, bts_pipeline, bts_assembly
		where adm_ReceiveLocation.ReceivePortId = bts_receiveport.nID
		and bts_receiveport.nApplicationID = @appId
		and adm_ReceiveLocation.SendPipelineId = bts_pipeline.Id
		and bts_pipeline.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @referenceAppId )
		return 0

	-- check if a receive location in appId refers to a receive pipeline in referenceAppId
	if exists( select 1 from adm_ReceiveLocation, bts_receiveport, bts_pipeline, bts_assembly
		where adm_ReceiveLocation.ReceivePortId = bts_receiveport.nID
		and bts_receiveport.nApplicationID = @appId
		and adm_ReceiveLocation.ReceivePipelineId = bts_pipeline.Id
		and bts_pipeline.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @referenceAppId )
		return 0

	-- check if an orchestration in appId refers to a sendportgroup in referenceAppId
	if exists( select 1 from bts_orchestration, bts_orchestration_port, bts_orchestration_port_binding, bts_assembly, bts_sendportgroup
		where bts_orchestration.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @appId
		and bts_orchestration.nID = bts_orchestration_port.nOrchestrationID
		and bts_orchestration_port.nID = bts_orchestration_port_binding.nOrcPortID
		and bts_orchestration_port_binding.nSpgID = bts_sendportgroup.nID
		and bts_sendportgroup.nApplicationID = @referenceAppId )
		return 0

	-- check if an orchestration in appId refers to a sendport in referenceAppId
	if exists( select 1 from bts_orchestration, bts_orchestration_port, bts_orchestration_port_binding, bts_assembly, bts_sendport
		where bts_orchestration.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @appId
		and bts_orchestration.nID = bts_orchestration_port.nOrchestrationID
		and bts_orchestration_port.nID = bts_orchestration_port_binding.nOrcPortID
		and bts_orchestration_port_binding.nSendPortID = bts_sendport.nID
		and bts_sendport.nApplicationID = @referenceAppId )
		return 0

	-- check if an orchestration in appId refers to a receiveport in referenceAppId
	if exists( select 1 from bts_orchestration, bts_orchestration_port, bts_orchestration_port_binding, bts_assembly, bts_receiveport
		where bts_orchestration.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @appId
		and bts_orchestration.nID = bts_orchestration_port.nOrchestrationID
		and bts_orchestration_port.nID = bts_orchestration_port_binding.nOrcPortID
		and bts_orchestration_port_binding.nReceivePortID = bts_receiveport.nID
		and bts_receiveport.nApplicationID = @referenceAppId )
		return 0

	-- check if a receive port in appId refers to a transform in referenceAppId
	if exists( select 1 from bts_receiveport, bts_receiveport_transform, bt_MapSpec, bts_assembly
		where bts_receiveport.nApplicationID = @appId
		and bts_receiveport.nID = bts_receiveport_transform.nReceivePortID
		and bts_receiveport_transform.uidTransformGUID = bt_MapSpec.id
		and bt_MapSpec.assemblyid = bts_assembly.nID
		and bts_assembly.nApplicationID = @referenceAppId )
		return 0

	-- check if a sendportgroup in appId refers to a sendport in referenceAppId
	if exists( select 1 from bts_sendportgroup, bts_spg_sendport, bts_sendport
		where bts_sendportgroup.nApplicationID = @appId
		and bts_sendportgroup.nID = bts_spg_sendport.nSendPortGroupID
		and bts_spg_sendport.nSendPortID = bts_sendport.nID
		and bts_sendport.nApplicationID = @referenceAppId )
		return 0

	-- check if an send port in appId refers to a transform in referenceAppId
	if exists( select 1 from bts_sendport, bts_sendport_transform, bt_MapSpec, bts_assembly
		where bts_sendport.nApplicationID = @appId
		and bts_sendport.nID = bts_sendport_transform.nSendPortID
		and bts_sendport_transform.uidTransformGUID = bt_MapSpec.id
		and bt_MapSpec.assemblyid = bts_assembly.nID
		and bts_assembly.nApplicationID = @referenceAppId )
		return 0

	-- check if a send port in appId refers to a send pipeline in referenceAppId
	if exists( select 1 from bts_sendport, bts_pipeline, bts_assembly
		where bts_sendport.nApplicationID = @appId
		and bts_sendport.nSendPipelineID = bts_pipeline.Id
		and bts_pipeline.nAssemblyID = bts_assembly.nID
		and bts_assembly.nApplicationID = @referenceAppId )
		return 0

	return 1
END

GO

CREATE TRIGGER CK_application_reference_delete
ON dbo.bts_application_reference
FOR DELETE
AS
BEGIN
	declare @nApplicationID as int
	declare @nReferencedApplicationID as int
	select @nApplicationID = nApplicationID, @nReferencedApplicationID = nReferencedApplicationID
		from deleted
	if (dbo.adm_CanReferenceBeDeleted(@nApplicationID, @nReferencedApplicationID) = 0)
		raiserror ('Error: Application reference cannot be deleted. CK_application_reference_delete', 16, 10)
END

GO

CREATE FUNCTION [dbo].[adm_ValidateApplicationBinding_Sp]
(
	@appId int,
	@spId int
) RETURNS bit
AS
BEGIN
	if exists (
		select * from bts_spg_sendport where  nSendPortID = @spId and 
			dbo.adm_IsReferencedBy(dbo.adm_GetSendPortGroupAppId(nSendPortGroupID), @appId) = 0
		)
		return 0
	return 1
END

GO

CREATE FUNCTION [dbo].[adm_ValidateApplicationBinding_Spg]
(
	@appId int,
	@spgId int
) RETURNS bit
AS
BEGIN
	if exists (
		select * from bts_spg_sendport where  nSendPortGroupID = @spgId and 
			dbo.adm_IsReferencedBy(@appId, dbo.adm_GetSendPortAppId(nSendPortID)) = 0
		)
		return 0
	return 1
END

GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Create stored procedure for adding foreign key constaints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
CREATE PROCEDURE [dbo].[bts_addconstraints]
AS

	-- Foreign key constraints from Admin
	alter table [dbo].[adm_ReceiveLocation] add constraint [adm_ReceiveLocation_fk_ReceivePort]
		foreign key (ReceivePortId) references [dbo].[bts_receiveport] (nID) on delete cascade

	alter table [dbo].[adm_ReceiveLocation] add constraint [adm_ReceiveLocation_fk_Pipeline]
		foreign key (ReceivePipelineId) references [dbo].[bts_pipeline] (Id)
	
	alter table [dbo].[adm_ReceiveLocation] add constraint [adm_ReceiveLocation_fk_SendPipeline]
		foreign key (SendPipelineId) references [dbo].[bts_pipeline] (Id)

	-- Foreign key constraints from PartnerMgmt
	alter table [dbo].[bts_receiveport] add constraint [bts_receiveport_foreign_sendpipelineid]
		foreign key(nSendPipelineId) references [dbo].[bts_pipeline](Id)

	alter table [dbo].[bts_sendport] add constraint [bts_sendport_foreign_sendpipelineid]
		foreign key(nSendPipelineID) references [dbo].[bts_pipeline](Id)

	alter table [dbo].[bts_sendport] add constraint [bts_sendport_foreign_receivepipelineid]
		foreign key(nReceivePipelineID) references [dbo].[bts_pipeline](Id)

	alter table [dbo].[bts_sendport_transport] add constraint [bts_sendport_transport_foreign_transporttypeid]
		foreign key(nTransportTypeId) references [dbo].[adm_Adapter](Id)

	alter table [dbo].[bts_sendport_transform] add constraint [bts_sendport_transform_foreign_transformid]
		foreign key(uidTransformGUID) references [dbo].[bt_MapSpec](id)

	alter table [dbo].[bts_receiveport_transform] add constraint [bts_receiveport_transform_foreign_transformid]
		foreign key(uidTransformGUID) references [dbo].[bt_MapSpec](id)

	alter table [dbo].[bts_orchestration_port_binding] add constraint [bts_orcport_binding_foreign_orcportid]
		foreign key(nOrcPortID) references [dbo].[bts_orchestration_port](nID) ON DELETE CASCADE

	alter table [dbo].[bts_enlistedparty] add constraint [bts_enlistedparty_foreign_roleid]
		foreign key(nRoleID) references [dbo].[bts_role](nID) ON DELETE CASCADE
		
	alter table [dbo].[bts_enlistedparty_port_mapping] add constraint [bts_enlistedparty_port_mapping_foreign_roleporttypeid]
		foreign key(nRolePortTypeID) references [dbo].[bts_role_porttype](nID)

	alter table [dbo].[bts_enlistedparty_operation_mapping] add constraint [bts_enlistedparty_operation_mapping_foreign_operationid]
		foreign key(nOperationID) references [dbo].[bts_porttype_operation](nID)

	alter table [dbo].[bts_application_reference] add constraint [bts_application_foreign_applicationid] foreign key(nApplicationID) references [dbo].[bts_application](nID)

	alter table [dbo].[bts_application_reference] add constraint bts_refapplication_foreign_applicationid	foreign key(nReferencedApplicationID) references [dbo].[bts_application](nID)

	alter table [dbo].[bts_sendport] add constraint [bts_sendport_foreign_applicationid] foreign key(nApplicationID) references [dbo].[bts_application](nID)

	alter table [dbo].[bts_sendportgroup] add constraint [bts_sendportgroup_foreign_applicationid] foreign key(nApplicationID) references [dbo].[bts_application](nID)
	
	alter table [dbo].[bts_receiveport] add constraint [bts_receiveport_foreign_applicationid] foreign key(nApplicationID) references [dbo].[bts_application](nID)

	alter table [dbo].[bts_assembly] add constraint [bts_assembly_foreign_applicationid] foreign key(nApplicationID) references [dbo].[bts_application](nID)

--	-------------------------------------------------------------------------------------------------------------------------
--	-- Foreign key constraints from Deployment


	ALTER TABLE [dbo].[bt_DocumentSpec] ADD CONSTRAINT [fk_bt_documentspec_bt_xmlshare] FOREIGN KEY 
		(
			[shareid]
		) REFERENCES [bt_XMLShare] (
			[id]
		)

	ALTER TABLE [dbo].[bt_DocumentSpec] ADD CONSTRAINT [fk_bt_documentspec_bts_item] FOREIGN KEY 
		(
			[itemid]
		) REFERENCES [bts_item] (
			[id]
		)

	ALTER TABLE [dbo].[bt_MapSpec] ADD CONSTRAINT [fk_bt_mapspec_bt_xmlshare] FOREIGN KEY 
		(
			[shareid]
		) REFERENCES [bt_XMLShare] (
			[id]
		)

	ALTER TABLE [dbo].[bt_MapSpec] ADD CONSTRAINT [fk_bt_mapspec_bts_item] FOREIGN KEY 
		(
			[itemid]
		) REFERENCES [bts_item] (
			[id]
		)

	ALTER TABLE [dbo].[bts_item] ADD CONSTRAINT [fk_bts_item_bts_assembly] FOREIGN KEY 
		(
			[AssemblyId]
		) REFERENCES [bts_assembly] (
			[nID]
		)

	ALTER TABLE [dbo].[bts_libreference] ADD CONSTRAINT [fk_bts_libreference_bts_assembly] FOREIGN KEY 
		(
			[idapp]
		) REFERENCES [bts_assembly] (
			[nID]
		)

	ALTER TABLE [dbo].[bts_libreference] ADD CONSTRAINT [fk_bts_libreference_bts_assembly1] FOREIGN KEY 
		(
			[idlib]
		) REFERENCES [bts_assembly] (
			[nID]
		)

	ALTER TABLE [dbo].[bts_orchestration] ADD CONSTRAINT [fk_bts_orchestration_bts_item] FOREIGN KEY 
		(
			[nItemID]
		) REFERENCES [bts_item] (
			[id]
		)

	-- Application binding check constraints
	alter table [dbo].[adm_ReceiveLocation] add constraint [CK_applicationbinding_adm_ReceiveLocation_sendpipeline]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetReceivePortAppId(ReceivePortId), dbo.adm_GetPipelineAppId(SendPipelineId)) = 1)

	alter table [dbo].[adm_ReceiveLocation] add constraint [CK_applicationbinding_adm_ReceiveLocation_receivepipeline]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetReceivePortAppId(ReceivePortId), dbo.adm_GetPipelineAppId(ReceivePipelineId)) = 1)

	alter table [dbo].[bts_orchestration_port_binding] add constraint [CK_applicationbinding_bts_orchestration_port_binding_sendportgroup]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetOrchestrationPortAppId(nOrcPortID), dbo.adm_GetSendPortGroupAppId(nSpgID)) = 1)

	alter table [dbo].[bts_orchestration_port_binding] add constraint [CK_applicationbinding_bts_orchestration_port_binding_receiveport]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetOrchestrationPortAppId(nOrcPortID), dbo.adm_GetReceivePortAppId(nReceivePortID)) = 1)

	alter table [dbo].[bts_orchestration_port_binding] add constraint [CK_applicationbinding_bts_orchestration_port_binding_sendport]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetOrchestrationPortAppId(nOrcPortID), dbo.adm_GetSendPortAppId(nSendPortID)) = 1)

	alter table [dbo].[bts_receiveport_transform] add constraint [CK_applicationbinding_bts_receiveport_transform_schema]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetReceivePortAppId(nReceivePortID), dbo.adm_GetSchemaAppId(uidTransformGUID)) = 1)

	alter table [dbo].[bts_spg_sendport] add constraint [CK_applicationbinding_bts_spg_sendport]
		check ([dbo].[adm_IsReferencedBy]([dbo].[adm_GetSendPortGroupAppId]([nSendPortGroupID]), [dbo].[adm_GetSendPortAppId]([nSendPortID])) = 1)

	alter table [dbo].[bts_sendport_transform] add constraint [CK_applicationbinding_bts_sendport_transform_schema]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetSendPortAppId(nSendPortID), dbo.adm_GetSchemaAppId(uidTransformGUID)) = 1)

	alter table [dbo].[bts_sendport] add constraint [CK_applicationbinding_bts_sendport_sendpipeline]
		check (dbo.adm_IsReferencedBy(nApplicationID, dbo.adm_GetPipelineAppId(nSendPipelineID)) = 1)

	alter table [dbo].[bts_sendport] add constraint [CK_applicationbinding_bts_sendport_sendportgroup]
		check ([dbo].[adm_ValidateApplicationBinding_Sp]([nApplicationID], [nID]) = 1)

	alter table [dbo].[bts_sendportgroup] add constraint [CK_applicationbinding_bts_sendportgroup_sendport]
		check ([dbo].[adm_ValidateApplicationBinding_Spg]([nApplicationID], [nID]) = 1)

	alter table [dbo].[bts_application_reference] add constraint [CK_bts_application_reference_cyclic]
		check (dbo.adm_IsReferencedBy(nReferencedApplicationID, nApplicationID) = 0)

	alter table [dbo].[bts_enlistedparty_operation_mapping] add constraint [CK_applicationbinding_bts_enlistedparty_operation_mapping]
		check (dbo.adm_IsReferencedBy(dbo.adm_GetRolelinkTypeNonSystemAppId(nPortMappingID), dbo.adm_GetPartySendPortAppId(nPartySendPortID)) = 1)

GO
--/---------------------------------------------------------------------------------------------------------------

-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Add the new foreign key constaints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	exec bts_addconstraints
GO
