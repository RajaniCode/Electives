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

		BEGIN TRANSACTION
		SET QUOTED_IDENTIFIER ON
		SET ARITHABORT ON
		SET NUMERIC_ROUNDABORT OFF
		SET CONCAT_NULL_YIELDS_NULL ON
		SET ANSI_NULLS ON
		SET ANSI_PADDING ON
		SET ANSI_WARNINGS ON
		COMMIT
		BEGIN TRANSACTION
		ALTER TABLE dbo.adpl_sat
			DROP CONSTRAINT FK_bts_application_adpl_sat

		COMMIT
		BEGIN TRANSACTION
		CREATE TABLE dbo.Tmp_adpl_sat
			(
			id int NOT NULL IDENTITY (1, 1),
			applicationId int NOT NULL,
			sdmType nvarchar(256) NULL,
			luid nvarchar(440) NULL,
			properties ntext NULL,
			files ntext NULL,
			cabContent image NULL
			)  ON [PRIMARY]
			 TEXTIMAGE_ON [PRIMARY]

		SET IDENTITY_INSERT dbo.Tmp_adpl_sat ON

		IF EXISTS(SELECT * FROM dbo.adpl_sat)
			 EXEC('INSERT INTO dbo.Tmp_adpl_sat (id, applicationId, sdmType, luid, properties, files, cabContent)
				SELECT id, applicationId, sdmType, luid, properties, files, cabContent FROM dbo.adpl_sat WITH (HOLDLOCK TABLOCKX)')

		SET IDENTITY_INSERT dbo.Tmp_adpl_sat OFF

		DROP TABLE dbo.adpl_sat

		EXECUTE sp_rename N'dbo.Tmp_adpl_sat', N'adpl_sat', 'OBJECT'

		DBCC FREEPROCCACHE
		
--- Moving assemblies to system app		
		DECLARE @SystemAppId int 
		SELECT @SystemAppId = nID 
			FROM bts_application
			WHERE isSystem = 1
		
		DECLARE proc_cursor CURSOR FOR
			SELECT id, applicationId, luid
				FROM adpl_sat 
			FOR UPDATE

		OPEN proc_cursor
		DECLARE @resId int
		DECLARE @appId int
		DECLARE @resLuid nvarchar(512)
		
		FETCH NEXT FROM proc_cursor INTO @resId,@appId,@resLuid
		WHILE (@@FETCH_STATUS = 0)
		BEGIN
			DECLARE @IsSystem int
			EXEC @IsSystem = dpl_IsSystemAssembly @Name = @resLuid
			
			IF( @IsSystem = 1 )
			BEGIN
				UPDATE adpl_sat
					SET applicationId = @SystemAppId
					WHERE CURRENT OF proc_cursor
				UPDATE bts_assembly 
					SET nApplicationID = @SystemAppId
					WHERE nvcFullName = @resLuid
			END
		   
			FETCH NEXT FROM proc_cursor INTO @resId,@appId,@resLuid
		END
		DEALLOCATE proc_cursor
--- Removing empty BAS orchestration
		DELETE FROM bts_orchestration 
			WHERE nvcFullName = N'Microsoft.BizTalk.KwTpm.BasRoleLinkType'
---Fix system flag for two remaining assemblies not marked so in Beta1		
		UPDATE bts_assembly
			SET nSystemAssembly = 1
			WHERE nvcFullName LIKE N'MQSeries,%PublicKeyToken=31bf3856ad364e35%' OR
				  nvcFullName LIKE N'Microsoft.BizTalk.Adapter.MSMQ.MsmqAdapterProperties,%PublicKeyToken=31bf3856ad364e35%'
		COMMIT
GO

GRANT SELECT ON [dbo].[adpl_sat] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[adpl_sat] TO BTS_HOST_USERS
GRANT SELECT ON [dbo].[adpl_sat] TO BTS_OPERATORS

GO


--////////////////////// TODO: ensure that direct table access is revoked by Admin during setup - only SProcs should be used
------------------------------- Indexes --------------------------------------------------
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'IX_adpl_sat')
   DROP INDEX [adpl_sat].[IX_adpl_sat]

CREATE NONCLUSTERED INDEX [IX_adpl_sat] ON [dbo].[adpl_sat]
	(
	    [applicationId]
	) ON [PRIMARY]

GO
------------------------------- Constraints definition -----------------------------------
ALTER TABLE [dbo].[adpl_sat] WITH NOCHECK ADD 
	CONSTRAINT [PK_adpl_sat] PRIMARY KEY NONCLUSTERED 
	(
		[id]
	)  ON [PRIMARY],

	CONSTRAINT [UQ_adpl_sat] UNIQUE CLUSTERED 
	(
		[luid]
	)  ON [PRIMARY],

	CONSTRAINT [FK_bts_application_adpl_sat] 
	FOREIGN KEY ([applicationId]) 
		REFERENCES [bts_application]([nID]) 
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Re-apply global constraints
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- 

if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_addconstraints]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_addconstraints
GO


-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Fix default pipeline components custom data
-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- 

/*
select p.Name, pc.Sequence,c.Name,Convert(varchar(8000),Convert(binary(8000),c.CustomData))
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
*/
	
declare @xmlCustomData varchar(8000)
declare @binCustomData binary(8000)

select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AllowUnrecognizedMessage vt="11">0</AllowUnrecognizedMessage><DocumentSpecNames vt="8"></DocumentSpecNames><DocumentSpecTargetNamespaces vt="8"></DocumentSpecTargetNamespaces><EnvelopeSpecNames vt="8"></EnvelopeSpecNames><EnvelopeSpecTargetNamespaces vt="8"></EnvelopeSpecTargetNamespaces><HiddenProperties vt="8">EnvelopeSpecTargetNamespaces,DocumentSpecTargetNamespaces</HiddenProperties><RecoverableInterchangeProcessing vt="11">0</RecoverableInterchangeProcessing><ValidateDocument vt="11">0</ValidateDocument></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.DefaultPipelines.XMLReceive' AND pc.Sequence = 0

select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AllowByCertName vt="11">-1</AllowByCertName><AllowBySID vt="11">-1</AllowBySID></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.DefaultPipelines.XMLReceive' AND pc.Sequence = 1

select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AddXmlDeclaration vt="11">-1</AddXmlDeclaration><DocumentSpecNames vt="8"></DocumentSpecNames><DocumentSpecTargetNamespaces vt="8"></DocumentSpecTargetNamespaces><EnvelopeDocSpecNames vt="8"></EnvelopeDocSpecNames><EnvelopeSpecTargetNamespaces vt="8"></EnvelopeSpecTargetNamespaces><HiddenProperties vt="8">EnvelopeSpecTargetNamespaces,DocumentSpecTargetNamespaces</HiddenProperties><PreserveBom vt="11">-1</PreserveBom><ProcessingInstructionsOptions vt="3">0</ProcessingInstructionsOptions><ProcessingInstructionsScope vt="3">0</ProcessingInstructionsScope><TargetCharset vt="8"></TargetCharset><TargetCodePage vt="3">0</TargetCodePage><XmlAsmProcessingInstructions vt="0"></XmlAsmProcessingInstructions></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.DefaultPipelines.XMLTransmit' AND pc.Sequence = 0

select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AllowUnrecognizedMessage vt="11">0</AllowUnrecognizedMessage><DocumentSpecNames vt="8"></DocumentSpecNames><EnvelopeSpecNames vt="8"></EnvelopeSpecNames><SaveProcessingInstructions vt="11">0</SaveProcessingInstructions><ValidateDocument vt="11">0</ValidateDocument></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.KwTpm.StsDefaultPipelines.StsFileReceivePipeline' AND pc.Sequence = 0

-- 5
select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AllowUnrecognizedMessage vt="11">0</AllowUnrecognizedMessage><DocumentSpecNames vt="8"></DocumentSpecNames><EnvelopeSpecNames vt="8"></EnvelopeSpecNames><SaveProcessingInstructions vt="11">0</SaveProcessingInstructions><ValidateDocument vt="11">0</ValidateDocument></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.KwTpm.StsDefaultPipelines.StsReceivePipeline' AND pc.Sequence = 0

-- 6
select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AllowByCertName vt="11">0</AllowByCertName><AllowBySID vt="11">-1</AllowBySID></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.KwTpm.StsDefaultPipelines.StsReceivePipeline' AND pc.Sequence = 1

-- 7
select @xmlCustomData = '<PropertyBag clsid="{9D0E430A-4CCE-4536-83FA-4A5040674AD6}"><AddXmlDeclaration vt="11">0</AddXmlDeclaration><DocumentSpecNames vt="8"></DocumentSpecNames><EnvelopeDocSpecNames vt="8">Microsoft.BizTalk.KwTpm.StsDefaultPipelines.EnvSchema</EnvelopeDocSpecNames><XmlAsmProcessingInstructions vt="0"></XmlAsmProcessingInstructions></PropertyBag>'
update bts_component
	set CustomData = CONVERT(binary(8000),@xmlCustomData)
	from bts_component c 
	inner join bts_stage_config sc on sc.CompID=c.Id
	inner join bts_pipeline_config pc on pc.StageID=sc.StageID
	inner join bts_pipeline p on p.Id=pc.PipelineID
	where p.Name = N'Microsoft.BizTalk.KwTpm.StsDefaultPipelines.StsSendPipeline' AND pc.Sequence = 0

GO

--// Add missing index on shareid, for avoiding table scan when joining with bt_XMLShare
		
CREATE NONCLUSTERED INDEX [IX_bt_DocumentSpec_shareid] ON [dbo].[bt_DocumentSpec]
	(
	[shareid]
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


GO



