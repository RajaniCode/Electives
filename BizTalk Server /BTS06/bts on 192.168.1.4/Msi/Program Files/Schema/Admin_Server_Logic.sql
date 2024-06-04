--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_LoadAppInstanceProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_LoadAppInstanceProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetGroupProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetGroupProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_LoadMsgBoxGroupProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_LoadMsgBoxGroupProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_LoadServiceProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_LoadServiceProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_ReceiveLocation_GetAllInApp]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_ReceiveLocation_GetAllInApp]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetSendPort]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetSendPort]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetSendPort_For_DL]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetSendPort_For_DL]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_ReceiveLocation_disable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_ReceiveLocation_disable]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_ReceivePortToPEP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_ReceivePortToPEP]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetSendPortAddress]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetSendPortAddress]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_SendPortToPEP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_SendPortToPEP]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_PartnerPortToPEP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_PartnerPortToPEP]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_Protocol_getOutboundProtocols]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_Protocol_getOutboundProtocols]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[adm_Protocol_getInboundProtocols]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_Protocol_getInboundProtocols]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetSendPortTransformAssemblyName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetSendPortTransformAssemblyName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetRecvPortTransformAssemblyName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetRecvPortTransformAssemblyName]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_GetInterceptors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_GetInterceptors]

-- static tracking info: insert and get
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_GetStaticTrackingInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_GetStaticTrackingInfo]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_GetServiceStaticTrackingInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_GetServiceStaticTrackingInfo]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetAppInstID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetAppInstID]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetLatestRelatedArtifactInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetLatestRelatedArtifactInfo]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_InsertStaticTrackingInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_InsertStaticTrackingInfo]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_InsertDefaultConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_InsertDefaultConfiguration]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_RemoveConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[bts_RemoveConfiguration]

-- Tracking Related Stored Procedures
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetSchemaRoots]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetSchemaRoots]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetPropertySchemaProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetPropertySchemaProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetSchemaRootProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetSchemaRootProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_SetSchemaRootTrackAllProperty]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_SetSchemaRootTrackAllProperty]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_SetSchemaRootTrackIndividualProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_SetSchemaRootTrackIndividualProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_LoadTrackingProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_LoadTrackingProperties]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetServices]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetServices]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admdta_GetTrackingProperties]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admdta_GetTrackingProperties]

-- SP for retrieving GroupSigningCert (used by BTSCache.dll - CertCache)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetGroupSigningCert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetGroupSigningCert]

-- SP for retrieving SourcePartyID (used by BTSCache.dll - CertCache)
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetPartyByCert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetPartyByCert]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetPartyBySID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetPartyBySID]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetPartyInfoFromPID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetPartyInfoFromPID]
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admsvr_GetDBIDByName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_GetDBIDByName]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_ApplicationInstance_get_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_ApplicationInstance_get_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_SendPort_get_subscription_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_SendPort_get_subscription_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_SendPortGroup_get_subscription_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_SendPortGroup_get_subscription_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_SendPort_get_subscription_spg_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_SendPort_get_subscription_spg_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_SendPortGroup_get_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_SendPortGroup_get_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_spgp_get_details]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_spgp_get_details]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_get_adapterinfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_get_adapterinfo]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_get_subscriptions_for_host]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_get_subscriptions_for_host]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_GetMSMQtTransportName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_GetMSMQtTransportName]

if exists (select * from sysobjects where id = object_id(N'[dbo].[adm_Protocol_getTransportAliases]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[adm_Protocol_getTransportAliases]

if exists (select * from sysobjects where id = object_id(N'[dbo].[admsvr_getMap]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admsvr_getMap]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MBOM_GetHosts]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MBOM_GetHosts]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MBOM_GetMessageBoxes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MBOM_GetMessageBoxes]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MBOM_GetOrchestrationTypes]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MBOM_GetOrchestrationTypes]

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MBOM_GetSendPortTransports]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MBOM_GetSendPortTransports]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[MBOM_GetReceiveTransports]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[MBOM_GetReceiveTransports]
GO

--// BAM Stored Procedures
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[admbam_RemoveOrchestrationInterceptorConfiguration]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[admbam_RemoveOrchestrationInterceptorConfiguration]
GO

--///////////////////////////////////////////////////////////////////////////
--// remove functions

if exists (select * from sysobjects where id = object_id(N'[dbo].[admsvr_CheckForMapOnReceivePort]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[admsvr_CheckForMapOnReceivePort]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[btsf_GetLatestInterceptorVersion]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[btsf_GetLatestInterceptorVersion]
GO

if exists (select * from sysobjects where id = object_id(N'[dbo].[admsvr_GetLastestDate]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)
drop function [dbo].[admsvr_GetLastestDate]
GO


CREATE PROCEDURE [dbo].[admsvr_LoadAppInstanceProperties]
@uidAppInstance uniqueidentifier,
@nvcAppName	nvarchar(256) OUTPUT,
@nvcMasterDBServer nvarchar(80) OUTPUT,
@nvcMasterDBName nvarchar(128) OUTPUT,
@nNumMsgboxServers int OUTPUT,
@nCacheRefreshInterval int OUTPUT

AS

declare @id int

set @nNumMsgboxServers = 0

SELECT @nvcAppName = AppType.Name,
	@nvcMasterDBServer = Grp.SubscriptionDBServerName,
	@nvcMasterDBName = Grp.SubscriptionDBName,
	@id = Grp.Id,
	@nCacheRefreshInterval = Grp.ConfigurationCacheRefreshInterval
FROM 	adm_HostInstance AS AppInst,
	adm_Server2HostMapping AS SAM,
	adm_Host AS AppType,
	adm_Group AS Grp	
WHERE AppInst.UniqueId = @uidAppInstance AND
	AppInst.Svr2HostMappingId = SAM.Id AND
	SAM.HostId = AppType.Id AND
	AppType.GroupId = Grp.Id

SELECT MsgBx.DBServerName, MsgBx.DBName, MsgBx.UniqueId, MsgBx.DisableNewMsgPublication, MsgBx.IsMasterMsgBox
FROM	 adm_MessageBox AS MsgBx
WHERE MsgBx.GroupId = @id

set @nNumMsgboxServers = @@ROWCOUNT

GO
GRANT EXEC ON [dbo].[admsvr_LoadAppInstanceProperties] TO BTS_HOST_USERS
GO


--
--// Engine:: Used for initializing Cache, and other thresholds.
--
CREATE PROCEDURE [dbo].[admsvr_GetGroupProperties]
	@nvcGroupName			nvarchar(256),
	@nvcHostName			nvarchar(256),
	@nCacheRefreshInterval	int OUTPUT,
	@nLMSFragmentSize		int	OUTPUT,
	@nLMSThreshold			int OUTPUT,
             @nThreadPoolSize			int OUTPUT
AS
	SELECT 
		@nCacheRefreshInterval	= adm_Group.ConfigurationCacheRefreshInterval,
		@nLMSFragmentSize		= adm_Group.LMSFragmentSize,
		@nLMSThreshold			= adm_Group.LMSThreshold
	FROM 
		adm_Group
	WHERE 
		adm_Group.Name = @nvcGroupName

-- we need to get the thread pool size as well. piggybacking on this stored proc call, instead of creating a new stored proc
        SELECT 
		@nThreadPoolSize = adm_Host.ThreadPoolSize
	FROM  
		adm_Host
	WHERE
		adm_Host.Name = @nvcHostName

GO
GRANT EXEC ON [dbo].[admsvr_GetGroupProperties] TO BTS_HOST_USERS
GO


CREATE PROCEDURE [dbo].[admsvr_LoadServiceProperties]
@uidServiceID	uniqueidentifier,
@nvcAppName		nvarchar(80)

AS

SELECT	LowWatermark, HighWatermark, BatchSize, MaxReceiveInterval, SingleDequeueSession, SerializeInstanceDelivery, GroupBatchByInstance, LowMemorymark, HighMemorymark, ThrottleFlag, LowSessionmark, HighSessionmark, CacheInstanceState, MaxDequeueThread,
		CAST(MessageDeliverySampleSpaceSize AS int), CAST(MessageDeliverySampleSpaceWindow AS int), CAST(MessageDeliveryOverdriveFactor AS int), CAST(MessageDeliveryMaximumDelay AS int), 
		CAST(MessagePublishSampleSpaceSize AS int), CAST(MessagePublishSampleSpaceWindow AS int), CAST(MessagePublishOverdriveFactor AS int), CAST(MessagePublishMaximumDelay AS int), 
		CAST(DeliveryQueueSize AS int), CAST(DBSessionThreshold AS int), CAST(GlobalMemoryThreshold AS int), CAST(ProcessMemoryThreshold  AS int), CAST(ThreadThreshold AS int), 
		CAST(DBQueueSizeThreshold AS int), CAST(InflightMessageThreshold AS int), 0
		FROM	adm_ServiceClass, adm_Host
		
WHERE	adm_ServiceClass.UniqueId = CAST( @uidServiceID AS NVARCHAR(256) ) AND adm_Host.Name = @nvcAppName

GO
GRANT EXEC ON [dbo].[admsvr_LoadServiceProperties] TO BTS_HOST_USERS
GRANT EXEC ON [dbo].[admsvr_LoadServiceProperties] TO BTS_OPERATORS
GO

--
--// Engine::Agent: Load the Messages Box details given a MsgBox Group Name //--
--

CREATE PROCEDURE [dbo].[admsvr_LoadMsgBoxGroupProperties]
@nvcGroupName nvarchar(256),
@nvcMasterDBServer nvarchar(80) OUTPUT,
@nvcMasterDBName nvarchar(128) OUTPUT,
@nNumMsgboxServers int OUTPUT,
@nCacheRefreshInterval int OUTPUT
AS
	set nocount on
	
	select TOP 1
		@nvcMasterDBServer = adm_Group.SubscriptionDBServerName,
		@nvcMasterDBName = adm_Group.SubscriptionDBName,
		@nCacheRefreshInterval = adm_Group.ConfigurationCacheRefreshInterval
	from
		adm_Group	

	select  
		adm_MessageBox.DBServerName, 
		adm_MessageBox.DBName, 
		adm_MessageBox.UniqueId,
		adm_MessageBox.DisableNewMsgPublication,
		adm_MessageBox.IsMasterMsgBox
	from
		adm_MessageBox WITH (REPEATABLEREAD),
		adm_Group 
	where	
		adm_MessageBox.GroupId = adm_Group.Id 	

	set @nNumMsgboxServers = @@ROWCOUNT
	
GO
GRANT EXEC ON [dbo].[admsvr_LoadMsgBoxGroupProperties] TO BTS_HOST_USERS
GRANT EXEC ON [dbo].[admsvr_LoadMsgBoxGroupProperties] TO BTS_OPERATORS
GO


--
--// Engine::EndpointManager: Get All Receive Locations For An Host Instance //--
--
CREATE procedure [dbo].[admsvr_ReceiveLocation_GetAllInApp]
@AppInstanceID uniqueidentifier
AS
set nocount on

SELECT 	rl.Name,
		dbo.admsvr_GetLastestDate(rl.DateModified,d.DateModified),
		dbo.adm_fnConvertLocalToUTCDate(rl.ActiveStartDT),
		dbo.adm_fnConvertLocalToUTCDate(rl.ActiveStopDT),
		rl.StartDTEnabled,
		dbo.adm_fnConvertLocalToUTCDate(rl.SrvWinStartDT),
		rl.StopDTEnabled,
		dbo.adm_fnConvertLocalToUTCDate(rl.SrvWinStopDT),
		rl.Disabled,
		rl.uidCustomCfgID,
		rl.bSSOMappingExists,
		rl.InboundTransportURL,
		rl.OperatingWindowEnabled,
		rl.ReceivePipelineData,		-- Custom Pipeline configuration data
		h.PipelineID,
		d.uidGUID,					-- Receive Port ID
		d.nvcName,                  -- Receive Port Name
		e.Name,		-- Protcol Name, e.g. FILE
		e.InboundEngineCLSID,
		i.PipelineID,
		d.bTwoWay,
		d.nAuthentication,
		d.nvcSendPipelineData,		-- Custom Pipeline config (req-resp)
		d.nTracking,
		b.uidReceiveLocationSSOAppID,
		rl.CustomCfg,
		dbo.admsvr_CheckForMapOnReceivePort(d.nID),
		j.PipelineID,
		rl.EncryptionCertThumbPrint,
		d.bRouteFailedMessage,
		CASE WHEN (bam.uidPortId) IS NULL THEN CAST(0 as int) ELSE CAST(1 as int) END AS IsBamEnabled

	FROM 	
		adm_ReceiveLocation rl
		INNER JOIN adm_ReceiveHandler b ON b.Id = rl.ReceiveHandlerId
		INNER JOIN adm_Adapter e ON b.AdapterId = e.Id
		INNER JOIN adm_Server2HostMapping f ON b.HostId = f.HostId
		INNER JOIN adm_HostInstance g ON g.Svr2HostMappingId = f.Id   
		INNER JOIN bts_pipeline h ON h.Id = rl.ReceivePipelineId
		INNER JOIN  bts_receiveport d ON d.nID = rl.ReceivePortId
		LEFT JOIN bts_pipeline i ON i.Id = d.nSendPipelineId
		LEFT JOIN bts_pipeline j on j.Id = rl.SendPipelineId
		LEFT JOIN (SELECT DISTINCT(uidPortId) FROM bam_TrackPoints) bam ON d.uidGUID = bam.uidPortId

	WHERE 	
		g.UniqueId = @AppInstanceID

		
set nocount off

GO
GRANT EXEC ON [dbo].[admsvr_ReceiveLocation_GetAllInApp] TO BTS_HOST_USERS
GO

-- Function to figure out if a receive port has a map configured on it
CREATE FUNCTION [dbo].[admsvr_CheckForMapOnReceivePort] (@receivePortID int)
RETURNS uniqueidentifier
AS
BEGIN
	return
		(SELECT TOP 1 uidTransformGUID
		FROM bts_receiveport_transform rptrans
		INNER JOIN bts_receiveport rp ON rp.nID = rptrans.nReceivePortID
		WHERE @receivePortID = rp.nID)
END
GO

-- Function to get the larger of two dates
CREATE FUNCTION [dbo].[admsvr_GetLastestDate] (@date1 datetime, @date2 datetime)
RETURNS datetime
AS

BEGIN
	declare @largestDate datetime

	IF ( @date1 > @date2 )
		set @largestDate = @date1
	ELSE
		set @largestDate = @date2

	RETURN @largestDate
END
GO


--
--// Engine::EndpointManager: Get Send Port //--
--
create procedure [dbo].[admsvr_GetSendPort]
@SendPortId uniqueidentifier

AS

set nocount on

declare @uidTransformGUID uniqueidentifier

SELECT @uidTransformGUID = sp_trans.uidTransformGUID
	FROM bts_sendport sp
	LEFT JOIN bts_sendport_transform sp_trans ON sp_trans.nSendPortID = sp.nID

	WHERE	sp.uidGUID = @SendPortId 

SELECT 	sp.nID,
		sp.nvcName,
		sp.nvcEncryptionCertHash,
		sp.nvcSendPipelineData,			-- Send pipe line custom config
		sp.nvcReceivePipelineData,		-- Receive pipe line customer config (solicit-response case)
		spt.nvcAddress,
		spt.nRetryCount,
		spt.nRetryInterval,
		spt.bIsServiceWindow,
		spt.dtFromTime,
		spt.dtToTime,
		spt.nTransportTypeId,
		spt.nvcTransportTypeData,
		spt.bIsPrimary,
		spt.bSSOMappingExists,
		pl.PipelineID,
		sp.bDynamic,
		sp.uidGUID,
		sp.DateModified,
		pro.Name,							-- Protcol Name, e.g. FILE
		pro.OutboundEngineCLSID,
		pro.OutboundAssemblyPath,
		pro.OutboundTypeName,
		pro.PropertyNameSpace,
		rcv_pl.PipelineID,					-- Receive pipeline for solicit-response
		sp.nTracking,
		sp.bTwoWay,
		spt.uidGUID,						-- Send Port Transport GUID
		@uidTransformGUID,
		sh.uidTransmitLocationSSOAppId,		-- Send Handler SSO Application Id
		spt.bOrderedDelivery, 
		sp.bStopSendingOnFailure, 
		sp.bRouteFailedMessage,
		CASE WHEN (bam.uidPortId) IS NULL THEN CAST(0 as int) ELSE CAST(1 as int) END AS IsBamEnabled
		

	FROM bts_sendport sp
	LEFT JOIN bts_sendport_transport spt ON spt.nSendPortID = sp.nID
	LEFT JOIN adm_Adapter pro ON pro.Id = spt.nTransportTypeId
	INNER JOIN bts_pipeline pl ON pl.Id = sp.nSendPipelineID
	LEFT JOIN bts_pipeline rcv_pl ON rcv_pl.Id = sp.nReceivePipelineID
	LEFT JOIN adm_SendHandler sh ON sh.Id = spt.nSendHandlerID
	LEFT JOIN (SELECT DISTINCT(uidPortId) FROM bam_TrackPoints) bam ON sp.uidGUID = bam.uidPortId

	WHERE	sp.uidGUID = @SendPortId AND 
			((sp.bDynamic = 0 AND spt.nTransportTypeId IS NOT NULL) OR (sp.bDynamic = 1))
	
	ORDER BY sp.nID, spt.bIsPrimary DESC		
	
set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetSendPort] TO BTS_HOST_USERS
GO

--
--// Engine: Get Send Port's For DL //--
--
create procedure [dbo].[admsvr_GetSendPort_For_DL]
@DLId int
AS

set nocount on

SELECT 	sp.nID,
		sp.nvcName,
		sp.nvcEncryptionCert,
		spt.nvcAddress,
		spt.nRetryCount,
		spt.nRetryInterval,
		spt.bIsServiceWindow,
		spt.dtFromTime,
		spt.dtToTime,
		spt.nTransportTypeId,
		spt.nvcTransportTypeData,
		spt.bIsPrimary,
		pl.PipelineID,
		sp.bDynamic,
		sp.uidGUID,
		sp.DateModified,
		pro.Name,							-- Protcol Name, e.g. FILE
		pro.InboundEngineCLSID,
		pro.InboundAssemblyPath,
		pro.InboundTypeName,
		pro.PropertyNameSpace,
		rcv_pl.PipelineID,					-- Receive pipeline for solicit-response
		sp.nTracking,
		sp.bTwoWay
		
	FROM bts_sendport sp
	INNER JOIN bts_spg_sendport e ON e.nSendPortID = sp.nID
	INNER JOIN bts_sendport_transport spt ON spt.nSendPortID = sp.nID
	INNER JOIN adm_Adapter pro ON pro.Id = spt.nTransportTypeId
	INNER JOIN bts_pipeline pl ON pl.Id = sp.nSendPipelineID
	LEFT JOIN bts_pipeline rcv_pl ON rcv_pl.Id = sp.nReceivePipelineID

	WHERE e.nSendPortGroupID = @DLId

	ORDER BY sp.nID, spt.bIsPrimary DESC					

set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetSendPort_For_DL] TO BTS_HOST_USERS
GO


--// Disable Receive Function //--
create procedure [dbo].[adm_ReceiveLocation_disable]
@InboundTransportLocation nvarchar(256),
@DisableIt int
as
set nocount on

declare @GroupName nvarchar(256)

begin tran

 --Timestamp table not yet present, add this later
 --select @GroupName = GroupName from adm_ReceiveService WITH (ROWLOCK) where InboundTransportURL = @InboundTransportLocation

UPDATE adm_ReceiveLocation SET Disabled = @DisableIt where InboundTransportURL = @InboundTransportLocation

 --Timestamp table not yet present, add this later
 --Update corresponding record in the TimeStamp table
 --update adm_TimeStamps set ReceiveServiceLastTimeStamp = getDate() where GroupName = @GroupName

commit tran

set nocount off
GO
GRANT EXEC ON [dbo].[adm_ReceiveLocation_disable] TO BTS_HOST_USERS
GO

--
--// Engine::EndpointManager: PEP Lookup API - admsvr_ReceivePortToPEP //--
--
create procedure [dbo].[admsvr_ReceivePortToPEP]
@service_port uniqueidentifier
AS

set nocount on

SELECT 		
		ad.Name,					-- InboundTransportType
		rl.InboundTransportURL,	-- InboundTransportLocation
		rl.InboundAddressableURL,-- InboundAddressableURL
		pl.PipelineID,			-- PipelineID
		ad.Capabilities			-- Capabilities, i.e. Receive, Send, SOAP, etc.


	FROM bts_orchestration_port op
	INNER JOIN bts_orchestration_port_binding opb ON  opb.nOrcPortID = op.nID	
	INNER JOIN adm_ReceiveLocation rl ON rl.ReceivePortId = opb.nReceivePortID
	INNER JOIN bts_pipeline pl ON pl.Id = rl.ReceivePipelineId
	LEFT JOIN adm_Adapter ad ON ad.Id = rl.AdapterId
	
		 
	WHERE	@service_port = op.uidGUID


set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_ReceivePortToPEP] TO BTS_HOST_USERS
GO

--
--// Engine::EndpointManager: PEP Lookup API - admsvr_GetSendPortAddress //--
--
create procedure [dbo].[admsvr_GetSendPortAddress]
@service_port uniqueidentifier
AS

set nocount on

SELECT 	f.Name,					-- InboundTransportType
		b.nvcAddress,			-- InboundTransportLocation
		e.PipelineID			-- PipelineID

	FROM bts_sendport sp, bts_sendport_transport b, bts_orchestration_port c, 
		 bts_orchestration_port_binding d, bts_pipeline e, adm_Adapter f
		 
	WHERE	@service_port = c.uidGUID			AND
			c.nID = d.nOrcPortID				AND
			d.nSendPortID = sp.nID				AND
			sp.nSendPipelineID = e.Id			AND
			b.nSendPortID = sp.nID				AND
			b.nTransportTypeId = f.Id

set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetSendPortAddress] TO BTS_HOST_USERS
GO



--
--// Engine::EndpointManager: PEP Lookup API - admsvr_SendPortToPEP //--
--
CREATE procedure [dbo].[admsvr_SendPortToPEP]
@service_port uniqueidentifier
AS
set nocount on
declare @nSendPortID int, @nSpgID as int

SELECT @nSendPortID = nSendPortID, @nSpgID = nSpgID
FROM bts_orchestration_port_binding spb
	INNER JOIN bts_orchestration_port srvp ON srvp.nID = spb.nOrcPortID
WHERE @service_port = srvp.uidGUID


IF (@@ROWCOUNT = 0) -- IF (@nSendPortID is null)
		return
IF (@nSendPortID = 0 AND @nSpgID = 0)
		return
	--	
	-- Distribution List Lookup
	--
	IF ( (@nSendPortID IS NULL) OR (@nSendPortID = 0) )
		BEGIN
			SELECT  NULL,
					NULL,
					NULL,
					uidGUID,					-- send port GUID
					NULL,						-- InboundTransportLocation
					NULL						-- Protcol Name, e.g. FILE
				FROM 	bts_sendportgroup
				WHERE nID = @nSpgID
		END
	ELSE IF ( (@nSpgID IS NULL) OR (@nSpgID = 0) )
		BEGIN
			SELECT  sp.uidGUID,
					spt.uidGUID,
					spt.bIsPrimary,
					@nSpgID,
					spt.nvcAddress,						-- InboundTransportLocation
					pro.Name							-- Protcol Name, e.g. FILE

				FROM bts_sendport sp

				LEFT JOIN bts_sendport_transport spt ON spt.nSendPortID = sp.nID
				INNER JOIN bts_pipeline pl ON pl.Id = sp.nSendPipelineID
				LEFT JOIN adm_Adapter pro ON pro.Id = spt.nTransportTypeId
				LEFT JOIN bts_pipeline rcv_pl ON rcv_pl.Id = sp.nReceivePipelineID

				WHERE sp.nID = @nSendPortID AND
					( sp.bDynamic = 1 OR spt.nTransportTypeId IS NOT NULL)

				ORDER BY sp.nID, spt.bIsPrimary DESC				
		END
set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_SendPortToPEP] TO BTS_HOST_USERS
GO


--
--// Engine::EndpointManager: PEP Lookup API - admsvr_PartnerPortToPEP //--
--
CREATE procedure [dbo].[admsvr_PartnerPortToPEP]
@bstrPartyValue nvarchar(256),
@bstrPartyQualifier nvarchar(64),
@bstrOperationName nvarchar(256),
@service_port uniqueidentifier,
@bstrPartyName nvarchar(256) OUTPUT			-- CHudnall - EBiz Suite PS Bug #19332
AS
set nocount on
declare @nPartyID int,
        @nRolePortTypeID int,
        @nPortTypeID int,
		@nRoleID int,
		@nOperationID int,
		@nSendPortID int

SELECT	@nPartyID = pa.nPartyID, 
		@bstrPartyName = p.nvcName 
FROM 	bts_party_alias pa
INNER JOIN bts_party p ON p.nID = pa.nPartyID
WHERE 	pa.nvcValue = @bstrPartyValue AND
     	pa.nvcQualifier = @bstrPartyQualifier

SELECT @nRolePortTypeID = bsp.nRolePortTypeID 
FROM bts_orchestration_port AS bsp
WHERE bsp.uidGUID = @service_port AND 
	bsp.nRolePortTypeID is not null

SELECT @nRoleID = brp.nRoleID, @nPortTypeID = brp.nPortTypeID 
FROM  bts_role_porttype AS brp
WHERE  brp.nID = @nRolePortTypeID

SELECT @nOperationID = bpo.nID
FROM bts_porttype_operation AS bpo
WHERE bpo.nvcName = @bstrOperationName AND
     bpo.nPortTypeID = @nPortTypeID

SELECT  @nSendPortID = pse.nSendPortID
FROM bts_enlistedparty_operation_mapping AS beom,
     bts_enlistedparty_port_mapping as bepm,
     bts_enlistedparty AS be,
     bts_party_sendport as pse
WHERE be.nRoleID = @nRoleID AND
      be.nPartyID = @nPartyID  AND
      be.nID = bepm.nEnlistedPartyID AND
      bepm.nRolePortTypeID = @nRolePortTypeID AND
      bepm.nID = beom.nPortMappingID AND
      beom.nOperationID =@nOperationID AND
      pse.nID = beom.nPartySendPortID

SELECT  spt.uidGUID,
        spt.bIsPrimary
        
    FROM bts_sendport sp
    INNER JOIN bts_sendport_transport spt ON spt.nSendPortID = sp.nID
    WHERE   sp.nID = @nSendPortID
    ORDER BY sp.nID, spt.bIsPrimary DESC
set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_PartnerPortToPEP] TO BTS_HOST_USERS
GO

--/------------------------------------------------------------------------------------------------------
--/ btsf_GetLatestInterceptorVersion
--/	Returns the interceptor id of the latest version that has been
--/	installed for the interceptor type that is passed a parameter.
--/------------------------------------------------------------------------------------------------------
CREATE FUNCTION [dbo].[btsf_GetLatestInterceptorVersion] (@uidRootInterceptorID uniqueidentifier)
RETURNS uniqueidentifier
AS
BEGIN
	RETURN
		(SELECT TOP 1 uidInterceptorID
		FROM TrackinginterceptorVersions
		WHERE @uidRootInterceptorID = uidRootInterceptorID
		ORDER BY dtDeploymentTime DESC)
END
GO
GRANT EXEC ON [dbo].[btsf_GetLatestInterceptorVersion] TO BTS_HOST_USERS
GO

--/------------------------------------------------------------------------------------------------------
--/ bts_GetInterceptors
--/	Returns the list of interceptors that were installed. The returned
--/	interceptor information belongs to the latest version of each interceptor
--/	type.
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bts_GetInterceptors]
AS

SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SET NOCOUNT ON

SELECT	tiv.uidInterceptorID, 
		ti.InterceptorType, 
		tiv.AssemblyName, 
		tiv.TypeName
FROM	TrackinginterceptorVersions tiv
INNER JOIN Trackinginterceptor ti ON tiv.uidRootInterceptorID = ti.uidInterceptorID
WHERE	tiv.uidInterceptorID = (SELECT dbo.btsf_GetLatestInterceptorVersion(tiv.uidRootInterceptorID))

GO
GRANT EXEC ON [dbo].[bts_GetInterceptors] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[bts_GetStaticTrackingInfo]
@uidServiceID uniqueidentifier,
@uidInterceptorID uniqueidentifier
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SET NOCOUNT ON

SELECT	d.dtDeploymentTime,
		d.imgData
FROM 	StaticTrackingInfo d
INNER JOIN adm_Group g ON g.GlobalTrackingOption <> 0
INNER JOIN TrackinginterceptorVersions tv ON tv.uidRootInterceptorID = @uidInterceptorID
WHERE 	d.uidServiceId = @uidServiceID AND 
		d.uidInterceptorId = tv.uidInterceptorID
ORDER BY d.dtDeploymentTime DESC
GO
GRANT EXEC ON [dbo].[bts_GetStaticTrackingInfo] TO BTS_HOST_USERS
GRANT EXEC ON [dbo].[bts_GetStaticTrackingInfo] TO BTS_OPERATORS
GO

--/------------------------------------------------------------------------------------------------------
--/ bts_GetServiceStaticTrackingInfo
--/	For a given service id the stored procedure returns all the information
--/	to create and execute the installed interceptors. For each interceptor
--/	type, the information about the latest version is retrieved.
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bts_GetServiceStaticTrackingInfo]
@uidServiceID uniqueidentifier
AS
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
SET NOCOUNT ON

SELECT	d.dtDeploymentTime, 
		t.InterceptorType, 
		tv.AssemblyName, 
		tv.TypeName,
		d.imgData, 
		d.uidInterceptorId, 
		d.ismsgBodyTrackingEnabled
FROM	StaticTrackingInfo d
INNER JOIN TrackinginterceptorVersions tv ON d.uidInterceptorId = tv.uidInterceptorID
INNER JOIN Trackinginterceptor t ON tv.uidRootInterceptorID = t.uidInterceptorID 
INNER JOIN adm_Group g ON g.GlobalTrackingOption <> 0
WHERE	d.uidServiceId = @uidServiceID AND
		tv.uidRootInterceptorID = N'{1E83A7DC-435E-49DF-BA83-F09CA50DFBE7}' -- Health Monitoring Interceptor
UNION ALL
SELECT	d.dtDeploymentTime, 
		t.InterceptorType, 
		tv.AssemblyName, 
		tv.TypeName,
		d.imgData, 
		d.uidInterceptorId, 
		d.ismsgBodyTrackingEnabled
FROM	StaticTrackingInfo d
INNER JOIN TrackinginterceptorVersions tv ON d.uidInterceptorId = tv.uidInterceptorID
INNER JOIN Trackinginterceptor t ON tv.uidRootInterceptorID = t.uidInterceptorID 
WHERE	d.uidServiceId = @uidServiceID
		AND tv.uidRootInterceptorID <> N'{1E83A7DC-435E-49DF-BA83-F09CA50DFBE7}' -- All other interceptors
ORDER BY d.dtDeploymentTime DESC
GO
GRANT EXEC ON [dbo].[bts_GetServiceStaticTrackingInfo] TO BTS_HOST_USERS
GO

--/------------------------------------------------------------------------------------------------------
--/	admdta_GetLatestRelatedArtifactInfo
--/	This procedure returns the latest active related service id and its interceptor configuration
--/ for another service. Here is the scenario:
--/	S1 is deployed with Assembly1, Version1, PublicKey1, Culture1. Then S2 is deployed with
--/ Assembly1, *Version2*, PublicKey1, Culture1. If you pass S2 to this function, it will 
--/ return S1 back. If both S2 and S1 are deployed (S2 later), and then there is an S3 with
--/	Assembly1, *Version3*, PublicKey1, Culture1, when S3 is passed to this function, S2 is 
--/ returned. Undeployed services are not returned.
--/ If there are no related services, then a null value is returned for the service id, while
--/	the default tracking configuration that is in the adm_Group table is returned as the 
--/	interceptor configuration.
--/
--/	Parameters:
--/		uidServiceId = type id of the service
--/		uidInterceptorId = id of the interceptor that will use the returned interceptor configuration
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[admdta_GetLatestRelatedArtifactInfo] 
@uidServiceId		uniqueidentifier,
@uidInterceptorId	uniqueidentifier
AS
	SET NOCOUNT ON

	declare @retSvcId uniqueidentifier
	declare @MatchFound int
	set @MatchFound = 0;

	-- First check if artifact is of orchestration type
	IF (EXISTS (SELECT * FROM bts_orchestration WHERE uidGUID = @uidServiceId))
	BEGIN
		SELECT TOP 1 @retSvcId = sti.uidServiceId, @MatchFound=1
		FROM	StaticTrackingInfo sti
		INNER JOIN bts_orchestration o ON o.uidGUID = @uidServiceId
		INNER JOIN bts_assembly a ON a.nID = o.nAssemblyID
		INNER JOIN bts_assembly a2 ON a2.nvcName = a.nvcName AND a2.nvcCulture = a.nvcCulture AND a2.nvcPublicKeyToken = a.nvcPublicKeyToken
		INNER JOIN bts_orchestration o2 ON o2.nAssemblyID = a2.nID
		INNER JOIN TrackinginterceptorVersions tv ON (sti.uidInterceptorId = tv.uidInterceptorID)
		WHERE o2.nvcFullName = o.nvcFullName -- same name but from assembly with different version
				AND o2.uidGUID = sti.uidServiceId
				AND (sti.dtUndeploymentTime is null)
				AND (sti.uidServiceId <> @uidServiceId)
				AND (tv.uidRootInterceptorID = @uidInterceptorId)
		ORDER BY sti.dtDeploymentTime DESC
	END
	ELSE
	BEGIN
		-- if it is not an orchestration, then check if it is a pipeline
		IF (EXISTS (SELECT * FROM bts_item WHERE Guid = @uidServiceId AND IsPipeline = 1))
		BEGIN
			SELECT TOP 1 @retSvcId = sti.uidServiceId, @MatchFound=1

			FROM StaticTrackingInfo sti
			INNER JOIN bts_item i ON i.Guid = @uidServiceId
			INNER JOIN bts_assembly a ON a.nID = i.AssemblyId
			INNER JOIN bts_assembly a2 ON a2.nvcName = a.nvcName AND a2.nvcCulture = a.nvcCulture AND a2.nvcPublicKeyToken = a.nvcPublicKeyToken
			INNER JOIN bts_item i2 ON i2.AssemblyId = a2.nID AND i2.FullName = sti.strServiceName
			INNER JOIN bts_pipeline p ON p.PipelineID = i2.Guid
			INNER JOIN bts_pipeline p2 ON p2.PipelineID = i.Guid
			WHERE p2.Name = p.Name -- same name but from assembly with different version	
					AND i2.Guid = sti.uidServiceId
					AND (sti.dtUndeploymentTime is null)
					AND (sti.uidServiceId <> @uidServiceId)
					AND (sti.uidInterceptorId = @uidInterceptorId)
					AND (p.Category = p2.Category)
			ORDER BY sti.dtDeploymentTime DESC
		END
	END

	if(0 = @MatchFound)
	BEGIN
		-- If related artifact cannot be found, then get the interceptor 
		-- configuration from the group table. There is no service id to be returned, 
		-- so it will be null
		SELECT TOP 1 @uidServiceId, TrackingConfiguration
		FROM adm_Group
	END
	ELSE
	BEGIN
		SELECT	TOP 1 
				sti.uidServiceId, 
				sti.imgData
		FROM	StaticTrackingInfo sti
		INNER JOIN TrackinginterceptorVersions tv ON sti.uidInterceptorId = tv.uidInterceptorID
		WHERE	@retSvcId = sti.uidServiceId
			AND tv.uidRootInterceptorID = @uidInterceptorId
	END
GO

GRANT EXEC ON [dbo].[admdta_GetLatestRelatedArtifactInfo] TO BTS_ADMIN_USERS
GO


--/------------------------------------------------------------------------------------------------------
--/	bts_InsertStaticTrackingInfo
--/	Called by HAT Tracking Options or TPE. For the hat cases, it updates the existing health monitoring
--/	configuration. For KW cases, it either updates the existing BI configuration or inserts a new one if
--/	there is no existing one.
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bts_InsertStaticTrackingInfo]
@strServiceName nvarchar(256),
@uidServiceID uniqueidentifier,
@uidInterceptorID uniqueidentifier,
@dtTimeStamp datetime,
@ismsgBodyTrackingEnabled int,
@imgData image
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	SET NOCOUNT ON

	-- Today HAT only passes the Root Interceptor Id here, so we do not know which version of this
	-- interceptor will be used. Because of that, currently we are always defaulting to the latest one.
	UPDATE	StaticTrackingInfo
	SET		ismsgBodyTrackingEnabled = @ismsgBodyTrackingEnabled,
			imgData = @imgData
	FROM	StaticTrackingInfo sti, TrackinginterceptorVersions tv
	WHERE	sti.uidServiceId = @uidServiceID 
			AND sti.uidInterceptorId = tv.uidInterceptorID
			AND tv.uidRootInterceptorID = @uidInterceptorID

	IF ( @@ROWCOUNT = 0 )
	BEGIN
		-- If the deployment time is null, then check if this artifact has been
		-- deployed before. If yes, then get the deployment time
		IF (@dtTimeStamp IS NULL)
		BEGIN
			SET @dtTimeStamp = (SELECT MAX(dtDeploymentTime)
				FROM 	StaticTrackingInfo
				WHERE	uidServiceId = @uidServiceID)
		END
	
		-- If there is no deployment time anywhere, then get the current time
		IF (@dtTimeStamp IS NULL)
		BEGIN
			SET @dtTimeStamp = GETUTCDATE()
		END

		INSERT INTO StaticTrackingInfo (
			strServiceName,
			uidServiceId,
			uidInterceptorId,
			dtDeploymentTime,
			ismsgBodyTrackingEnabled,
			imgData)
		VALUES (
			@strServiceName,
			@uidServiceID,
			dbo.btsf_GetLatestInterceptorVersion(@uidInterceptorID),
			@dtTimeStamp,
			@ismsgBodyTrackingEnabled,
			@imgData
			)
	END
GO
GRANT EXEC ON [dbo].[bts_InsertStaticTrackingInfo] TO BTS_HOST_USERS
GO

--/------------------------------------------------------------------------------------------------------
--/	bts_InsertDefaultConfiguration
--/	Called by tracking deployment. This one does not touch the interceptor configuration 
--/	in case of a redeployment. Also, if a newer version of the pipeline/schedule
--/	is deployed, it rolls the interceptor configuration to the newer version
--/ Parameters:
--/		@strServiceName = Full Name (not strong) of the service
--/		@uidServiceId = Version Dependent Id of the service
--/		@uidInterceptorId = Interceptor that will use this configuration
--/		@nMsgBodyTracking = Message Body Tracking flags
--/		@imgConfiguration = Interceptor Configuration
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bts_InsertDefaultConfiguration]
@strServiceName		nvarchar(256),
@uidServiceID		uniqueidentifier,
@uidInterceptorID	uniqueidentifier,
@nMsgBodyTracking	int,
@imgConfiguration	image
AS
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	SET NOCOUNT ON

	declare	@dtTimeStamp datetime
	set @dtTimeStamp = GETUTCDATE()

	-- First try to see if this service was already deployed before
	-- If so, just update the deployment times
	--
	-- Today HAT only passes the Root Interceptor Id here, so we do not know which version of this
	-- interceptor will be used. Because of that, currently we are always defaulting to the latest one.
	UPDATE	StaticTrackingInfo
	SET 	dtDeploymentTime = @dtTimeStamp,
			dtUndeploymentTime = null,
			uidInterceptorId = dbo.btsf_GetLatestInterceptorVersion(@uidInterceptorID)
	FROM	StaticTrackingInfo sti, TrackinginterceptorVersions tv
	WHERE 	sti.uidServiceId = @uidServiceID 
			AND tv.uidRootInterceptorID = @uidInterceptorID
			AND sti.uidInterceptorId = tv.uidInterceptorID

	-- If this service was not there previously then insert a new one
	IF ( @@ROWCOUNT = 0 )
	BEGIN
		INSERT INTO StaticTrackingInfo 
		(
			strServiceName,
			uidServiceId,
			uidInterceptorId,
			dtDeploymentTime,
			ismsgBodyTrackingEnabled,
			imgData
		)
		VALUES
		(
			@strServiceName,
			@uidServiceID,
			dbo.btsf_GetLatestInterceptorVersion(@uidInterceptorID),
			@dtTimeStamp,
			@nMsgBodyTracking,
			@imgConfiguration
		)
	END
GO
GRANT EXEC ON [dbo].[bts_InsertDefaultConfiguration] TO BTS_ADMIN_USERS
GO


--/------------------------------------------------------------------------------------------------------
--/	bts_RemoveConfiguration
--/	Called by tracking deployment. This stored procedure does not actually 
--/	remove the interceptor configuration from the database, but marks 
--/	the undeployment time, so that the other stored procedures querying
--/	for this understands that this one is not active anymore. To make 
--/	an interceptor configuration active again, remove the undeployment 
--/	time.
--/	Parameters:
--/		strAssemblyFullName: Full Name of the assembly that contains the artifacts
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[bts_RemoveConfiguration]
@strAssemblyFullName	nvarchar(256)
AS
	declare @dtUndeploymentTime datetime
	set @dtUndeploymentTime = GETUTCDATE()

	-- mark all schedules that belong to this assembly
	UPDATE	StaticTrackingInfo
	SET		dtUndeploymentTime = @dtUndeploymentTime
	FROM 	bts_orchestration o, 
			bts_assembly a
	WHERE	o.nAssemblyID = a.nID
			AND o.uidGUID = uidServiceId
			AND a.nvcFullName = @strAssemblyFullName
	
	-- mark all pipelines that belong to this assembly
	UPDATE	StaticTrackingInfo
	SET		dtUndeploymentTime = @dtUndeploymentTime
	FROM 	bts_item i, 
			bts_assembly a
	WHERE	i.AssemblyId = a.nID
			AND i.Guid = uidServiceId
			AND a.nvcFullName = @strAssemblyFullName
GO
GRANT EXEC ON [dbo].[bts_RemoveConfiguration] TO BTS_ADMIN_USERS
GO

--
--// Engine::EndpointManager: Get App Instance ID //--
--
CREATE procedure [dbo].[admsvr_GetAppInstID]
@InboundURL nvarchar(1024),
@ServerName nvarchar(63),
@AppInstanceID uniqueidentifier OUTPUT,
@AppName nvarchar(256) OUTPUT,
@GroupName nvarchar(256) OUTPUT
AS
set nocount on
SELECT 	
	@AppInstanceID = appInst.UniqueId,
	@AppName = appType.Name,
	@GroupName = grp.Name
	FROM 	
		adm_ReceiveLocation recLoc, 
		adm_ReceiveHandler recHan, 
		adm_Server2HostMapping srv2Typ, 
		adm_HostInstance appInst,
		adm_Group grp, 
		adm_Host appType,
		adm_Server server
	WHERE	
		recLoc.InboundTransportURL = @InboundURL 		AND
		recLoc.ReceiveHandlerId = recHan.Id				AND
		recHan.HostId = srv2Typ.HostId					AND
		appInst.Svr2HostMappingId = srv2Typ.Id			AND
		srv2Typ.HostId = appType.Id						AND
		appType.GroupId = grp.Id						AND
		server.Name = @ServerName						AND
		srv2Typ.ServerId = server.Id					AND
		srv2Typ.HostId = appType.Id					

set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetAppInstID] TO BTS_HOST_USERS
GO

-- stored procs that are used by tracking
-- TO DO: Merge this with admsvr_LoadAppInstanceProperties
CREATE PROCEDURE [dbo].[admdta_LoadTrackingProperties]
@strAppInstance nvarchar(50)
AS
	SELECT	Grp.TrackingDBServerName,
			Grp.TrackingDBName
	FROM 	adm_HostInstance AS HostInst,
			adm_Server2HostMapping AS SAM,
			adm_Host AS AppType,
			adm_Group AS Grp	
	WHERE	HostInst.UniqueId = @strAppInstance AND
			HostInst.Svr2HostMappingId = SAM.Id AND
			SAM.HostId = AppType.Id AND
			AppType.GroupId = Grp.Id
GO
GRANT EXEC ON [dbo].[admdta_LoadTrackingProperties] TO BTS_HOST_USERS
GO

--/------------------------------------------------------------------------------------------------------
--/	admdta_GetServices
--/	This procedure returns all the services for a given service type (pipelines or orchestrations).
--/	
--/
--/	Parameters:
--/		uidServiceId = type id of the service
--/		uidInterceptorId = id of the interceptor that will use the returned interceptor configuration
--/------------------------------------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[admdta_GetServices]
@strGroupName	nvarchar(256),
@serviceType	int		--ServiceTypes.XLangs = 0, ServiceTypes.Pipeline = 1
AS
	-- We need the interceptor id because we do not want to show other interceptor
	-- configurations in HAT
	if(0 = @serviceType) 
		begin
			SELECT	o.uidGUID as ServiceId, 
			 		o.uidGUID as VersionIndependentId,
					sti.uidInterceptorId as InterceptorId,
					sti.strServiceName as ServiceName,
					0 as ServiceType, -- 0 stands for XLANGs services
					a.nvcName as AssemblyName,
					sti.imgData as InterceptorConfiguration,
					a.nvcDescription as N'Description',
					0 as ServiceSubType,	-- 0 meaning N/A for XLANGs services
					a.nvcPublicKeyToken as PublicKeyToken,
					a.nvcVersion as Version,
					a.nvcCulture as Culture,
					tv.uidRootInterceptorID as RootInterceptorId
			FROM	bts_orchestration o 
			INNER JOIN bts_assembly a ON a.nID = o.nAssemblyID
			INNER JOIN StaticTrackingInfo sti ON sti.uidServiceId = o.uidGUID
			INNER JOIN TrackinginterceptorVersions tv ON tv.uidRootInterceptorID = N'{1E83A7DC-435E-49DF-BA83-F09CA50DFBE7}' -- XLang/s native interceptor
			WHERE sti.uidInterceptorId = tv.uidInterceptorID
		end
	else
		begin
			SELECT	i.Guid as ServiceId,
					i.Guid as VersionIndependentId,
					sti.uidInterceptorId as InterceptorId,
					sti.strServiceName as ServiceName,
					1 as ServiceType, -- 1 stands for pipeline
					a.nvcName as AssemblyName,
					sti.imgData as InterceptorConfiguration,
					a.nvcDescription as N'Description',
					cast (p.Category as int) as ServiceSubType, -- 1 - Receive & 2 - Transmit pipelines
					a.nvcPublicKeyToken as PublicKeyToken,
					a.nvcVersion as Version,
					a.nvcCulture as Culture,
					sti.uidInterceptorId as RootInterceptorId
			FROM bts_item i
			INNER JOIN bts_assembly a ON a.nID = i.AssemblyId 
			INNER JOIN StaticTrackingInfo sti ON sti.uidServiceId = i.Guid
			INNER JOIN bts_pipeline p ON p.PipelineID = i.Guid
			WHERE	i.IsPipeline = 1
					AND sti.uidInterceptorId = N'{D90B63BA-3EEB-4E8A-A20E-7BE683319552}' -- Messaging Interceptor
		end
GO
GRANT EXEC ON [dbo].[admdta_GetServices] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[admdta_GetTrackingProperties]
AS
	-- Get the tracking database with the group name first, this is for schedule services
	-- Then get all the tracking databases for pipeline deployment or deployment to an org
	SELECT	TrackingDBServerName,
			TrackingDBName,
			TrackingConfiguration
	FROM	adm_Group
GO
GRANT EXEC ON [dbo].[admdta_GetTrackingProperties] TO BTS_HOST_USERS
GRANT EXEC ON [dbo].[admdta_GetTrackingProperties] TO BTS_OPERATORS
GO



CREATE PROCEDURE [dbo].[admdta_GetSchemaRoots]
AS 
	declare @nonlocalized_string_property_schema AS nvarchar(256)
	set @nonlocalized_string_property_schema  = N'@#%&<Property Schema>&%#@' -- this is hardcoded value that is replaced with localized value in the UI

	SELECT 	-- documents
		docs.docspec_name AS DocSpecName, 
		docs.schema_root_name AS SchemaRootName, 
		docs.msgtype AS MsgType,
		docs.assemblyid AS AssemblyID,
		docs.is_tracked AS TrackAll,
		docs.id	AS ID,
		asm.nvcFullName AS AssemblyFullName,
		docs.itemid as ItemId
	FROM 	dbo.bt_DocumentSpec docs
	INNER JOIN dbo.bt_XMLShare shares  ON docs.shareid = shares.id,
			dbo.bts_assembly asm
	WHERE	docs.is_property_schema = 0 AND
			asm.nID = docs.assemblyid

	UNION ALL

	SELECT 	-- property schemas
		docs.docspec_name AS DocSpecName, 
		@nonlocalized_string_property_schema AS SchemaRootName,
		shares.target_namespace AS MsgType,
		docs.assemblyid AS AssemblyID,
		CAST(0 as bit) as TrackAll,
		shares.id AS ID,
		asm.nvcFullName AS AssemblyFullName,
		MIN(docs.itemid) as ItemId -- It doesn't really matter which one we pick, they all the same
	FROM 	dbo.bt_DocumentSpec docs
		INNER JOIN dbo.bt_XMLShare shares  ON docs.shareid = shares.id,
		dbo.bts_assembly asm
	WHERE	docs.is_property_schema <> 0 AND
		asm.nID = docs.assemblyid
	GROUP BY docs.docspec_name, shares.target_namespace, docs.assemblyid, shares.id, asm.nvcFullName
	ORDER BY DocSpecName ASC, SchemaRootName ASC
GO
GRANT EXEC ON [dbo].[admdta_GetSchemaRoots] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[admdta_GetPropertySchemaProperties] 
@msgType nvarchar(256),
@itemid  int
AS
	SELECT 	
		docs.schema_root_name AS Name,
		docs.is_tracked AS IsTracked,
		docs.id
	FROM  	dbo.bt_DocumentSpec docs
	WHERE 	
		docs.itemid = @itemid
	ORDER BY Name ASC, is_tracked ASC
GO
GRANT EXEC ON [dbo].[admdta_GetPropertySchemaProperties] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[admdta_GetSchemaRootProperties] 
@msgType nvarchar(256),
@itemid  int
AS
			SELECT 
				name AS Name,
				is_tracked AS IsTracked,
				id
	
			FROM  	dbo.bt_Properties
			WHERE	itemid = @itemid AND msgtype=@msgType
			ORDER BY name ASC, is_tracked ASC
GO
GRANT EXEC ON [dbo].[admdta_GetSchemaRootProperties] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[admdta_SetSchemaRootTrackAllProperty]
@rootId uniqueidentifier,
@tracked bit
 AS 
	set nocount on
	declare @ErrCode as int
	select @ErrCode=0

	update 	dbo.bt_DocumentSpec 
		set 	is_tracked=@tracked
		where 	id=@rootId

	set @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
	
	set nocount off
	return @ErrCode
GO
GRANT EXEC ON [dbo].[admdta_SetSchemaRootTrackAllProperty] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[admdta_SetSchemaRootTrackIndividualProperties]
@propertyId uniqueidentifier,
@tracked bit
 AS 
	set nocount on
	declare @ErrCode as int
	select @ErrCode=0

	update 	dbo.bt_Properties
		set 	is_tracked=@tracked
		where 	id=@propertyId

	-- This is probably a property schema
	if (@@ROWCOUNT = 0)
	begin
		update 	dbo.bt_DocumentSpec
			set 	is_tracked=@tracked
			where 	id=@propertyId
	end

	set @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
	
	set nocount off
	return @ErrCode
GO
GRANT EXEC ON [dbo].[admdta_SetSchemaRootTrackIndividualProperties] TO BTS_ADMIN_USERS
GO


--
--// Engine::EndpointManager: Get All Outbound Protocols //--
--

create procedure [dbo].[adm_Protocol_getOutboundProtocols]
@AppName nvarchar(256)

AS

set nocount on

SELECT a.Name,
       a.DateModified,
       a.OutboundEngineCLSID,
       a.OutboundAssemblyPath,
       a.OutboundTypeName,
       a.PropertyNameSpace,
       b.uidCustomCfgID,
       a.Capabilities,
       b.CustomCfg AS DefaultTHCfg
	
FROM adm_Adapter a 
	INNER JOIN adm_SendHandler b ON a.Id = b.AdapterId
	INNER JOIN adm_Host host ON @AppName = host.Name


 WHERE 	b.HostId = host.Id

set nocount off
GO
GRANT EXEC ON [dbo].[adm_Protocol_getOutboundProtocols] TO BTS_HOST_USERS
GO


--
--// Engine::EndpointManager: Get All Inbound Protocols //--
--
create procedure [dbo].[adm_Protocol_getInboundProtocols]
@AppName nvarchar(256)

AS
set nocount on
SELECT a.Name,
       a.DateModified,
       a.InboundEngineCLSID,
       a.InboundAssemblyPath,
       a.InboundTypeName,
       a.PropertyNameSpace,
       b.uidCustomCfgID,
       a.Capabilities,
       b.CustomCfg AS DefaultRHCfg


  FROM 	adm_Adapter a 
  	INNER JOIN adm_ReceiveHandler b ON a.Id = b.AdapterId
	INNER JOIN adm_Host host ON @AppName = host.Name

 WHERE 	b.HostId = host.Id

set nocount off

GO
GRANT EXEC ON [dbo].[adm_Protocol_getInboundProtocols] TO BTS_HOST_USERS
GO


--
--// Engine::EndpointManager: Get All Transport Aliases //--
--
create procedure [dbo].[adm_Protocol_getTransportAliases]

AS

set nocount on

SELECT a.Name,
       b.AliasValue,
       a.OutboundEngineCLSID
	
FROM adm_Adapter a 
	INNER JOIN adm_AdapterAlias b ON a.Id = b.AdapterId

set nocount off
GO
GRANT EXEC ON [dbo].[adm_Protocol_getTransportAliases] TO BTS_HOST_USERS
GO


--
--// Engine::EndpointManager: Get Send Port Transform Assembly Name //--
--
create procedure [dbo].[admsvr_GetSendPortTransformAssemblyName]
@SendPortID uniqueidentifier,
@InMessageType nvarchar(256),
@IsReceive bit

AS

set nocount on

declare @nMapID uniqueidentifier

SELECT @nMapID = ms.id

FROM bt_MapSpec ms

	INNER JOIN bt_DocumentSpec ds ON ds.docspec_name = ms.indoc_docspec_name
	INNER JOIN bts_sendport_transform spt ON spt.uidTransformGUID = ms.id 
	INNER JOIN bts_sendport sp ON sp.nID = spt.nSendPortID

WHERE	ds.msgtype = @InMessageType AND
		sp.uidGUID = @SendPortID	AND
		spt.bReceive = @IsReceive

SELECT 	ba.nvcFullName,
		bi.FullName

FROM bts_assembly ba, bts_item bi, bt_MapSpec ms 
	
WHERE	@nMapID = ms.id AND
		ba.nID = ms.assemblyid AND
		bi.id = ms.itemid
	
set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetSendPortTransformAssemblyName] TO BTS_HOST_USERS
GO

--
--// Engine::EndpointManager: Get Receive Port Transform Assembly Name //--
--
create procedure [dbo].[admsvr_GetRecvPortTransformAssemblyName]
@RecvPortId uniqueidentifier,
@InMessageType nvarchar(256),
@IsTransmit bit

AS

set nocount on

declare @nMapID uniqueidentifier

SELECT @nMapID = ms.id

FROM bt_MapSpec ms

	INNER JOIN bt_DocumentSpec ds ON ds.docspec_name = ms.indoc_docspec_name
	INNER JOIN bts_receiveport_transform rpt ON rpt.uidTransformGUID = ms.id 
	INNER JOIN bts_receiveport rp ON rp.nID = rpt.nReceivePortID

WHERE	ds.msgtype = @InMessageType AND
		rp.uidGUID = @RecvPortId	AND
		rpt.bTransmit = @IsTransmit

SELECT 	ba.nvcFullName,
		bi.FullName

FROM bts_assembly ba, bts_item bi, bt_MapSpec ms 
	
WHERE	@nMapID = ms.id AND
		ba.nID = ms.assemblyid AND
		bi.id = ms.itemid
	
set nocount off
GO
GRANT EXEC ON [dbo].[admsvr_GetRecvPortTransformAssemblyName] TO BTS_HOST_USERS
GO

-- SP for retrieving GroupSigningCert (used by BTSCache.dll - CertCache)
CREATE  PROCEDURE [dbo].[admsvr_GetGroupSigningCert]
@nvcGroupName nvarchar(256),
@nvcHostName nvarchar(256),
@nvcGroupSignCertName nvarchar(256) OUTPUT,
@nvcHostSignCertName  nvarchar(256) OUTPUT

AS

SELECT @nvcGroupSignCertName = SignCertThumbprint
FROM 	adm_Group
WHERE Name = @nvcGroupName

SELECT @nvcHostSignCertName = N''

GO
GRANT EXEC ON [dbo].[admsvr_GetGroupSigningCert] TO BTS_HOST_USERS
GO

-- SP for retrieving SourcePartyID (used by BTSCache.dll - CertCache)
CREATE  PROCEDURE [dbo].[admsvr_GetPartyByCert]
@nvcSignatureHash nvarchar(256),
@nvcSID  nvarchar(256) OUTPUT,
@nvcName nvarchar(256) OUTPUT
AS
SELECT 	@nvcSID = bts_party.nvcSID,
	@nvcName = bts_party.nvcName
FROM 	bts_party
WHERE 	UPPER(bts_party.nvcSignatureCertHash) = UPPER(@nvcSignatureHash)
GO
GRANT EXEC ON [dbo].[admsvr_GetPartyByCert] TO BTS_HOST_USERS
GO

CREATE  PROCEDURE [dbo].[admsvr_GetPartyBySID]
@nvcDomainUser nvarchar(256),
@nvcSID nvarchar(256) OUTPUT,
@nvcName nvarchar(256) OUTPUT
AS
SELECT 	@nvcSID = bts_party.nvcSID,
	@nvcName = bts_party.nvcName
FROM 	bts_party, bts_party_alias
WHERE 	UPPER(bts_party_alias.nvcQualifier) = 'WINDOWSUSER' AND
 	UPPER(bts_party_alias.nvcValue) = UPPER(@nvcDomainUser)  AND
	bts_party_alias.nPartyID = bts_party.nID
GO
GRANT EXEC ON [dbo].[admsvr_GetPartyBySID] TO BTS_HOST_USERS
GO

-- SP for deriving partyName and qualifier from PID, used by XLANG via EPM

CREATE  PROCEDURE [dbo].[admsvr_GetPartyInfoFromPID]
@nvcSID nvarchar(256) ,
@nvcParty nvarchar(256) OUTPUT,
@nvcQualifier nvarchar(256) OUTPUT
AS

SELECT 	
	@nvcQualifier 	= bts_party_alias.nvcQualifier,
	@nvcParty	= bts_party_alias.nvcValue 

FROM bts_party_alias
	INNER JOIN  bts_party ON bts_party_alias.nPartyID = bts_party.nID  
WHERE
 	bts_party.nvcSID = @nvcSID AND
 	bts_party.nvcName = bts_party_alias.nvcValue
GO
GRANT EXEC ON [dbo].[admsvr_GetPartyInfoFromPID] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[admsvr_GetDBIDByName]
@nvcDBServerName nvarchar(80),
@nvcDBName nvarchar(128),
@uidDBID uniqueidentifier output
AS
   set @uidDBID = null

	select @uidDBID = UniqueId from adm_MessageBox 
	where DBServerName = @nvcDBServerName AND
		  DBName = @nvcDBName
GO
GRANT EXEC ON [dbo].[admsvr_GetDBIDByName] TO BTS_HOST_USERS
GO

--========== Engine store procs for adm_HostInstance ==========--
CREATE PROCEDURE [dbo].[adm_ApplicationInstance_get_details]
@InstId uniqueidentifier,
@AppInstDateModified datetime OUTPUT,
@AppTypeDateModified datetime OUTPUT,
@ConfigurationCacheRefreshInterval int OUTPUT,
@ConfigurationState int OUTPUT,
@DisableAppInstance int OUTPUT, 
@AppType int OUTPUT, -- TODO: AppType has to be removed
@AdminGroupName nvarchar(256) OUTPUT
AS
	set nocount on
	set xact_abort on

	declare @ErrCode as int, @AppTypeId as int, @MsmqtProtocolId as int, @MsmqtHandlers as int
	select @ErrCode = 0, @AppTypeId = 0, @MsmqtProtocolId = 0, @MsmqtHandlers = 0
	declare @subscriptionDbServer as nvarchar(80), @patternpos as int
	select @subscriptionDbServer = null, @patternpos = 0
	
	select
		@AppInstDateModified = adm_HostInstance.DateModified, 
		@AppTypeDateModified = adm_Host.DateModified,
		@ConfigurationCacheRefreshInterval = adm_Group.ConfigurationCacheRefreshInterval,
		@ConfigurationState = adm_HostInstance.ConfigurationState,
		@DisableAppInstance = adm_HostInstance.DisableHostInstance,
		@AppTypeId = adm_Host.Id,
		@AppType = 1, -- TODO: AppType has to be removed
		@AdminGroupName = BizTalkAdminGroup,
		@subscriptionDbServer = SubscriptionDBServerName
	from
		adm_HostInstance,
		adm_Host,
		adm_Server2HostMapping,
		adm_Group
	where
		adm_HostInstance.UniqueId = @InstId
		AND adm_Server2HostMapping.Id = adm_HostInstance.Svr2HostMappingId
		AND adm_Host.Id = adm_Server2HostMapping.HostId
		AND adm_Group.Id = adm_Host.GroupId

	set @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
	if ( @ErrCode <> 0 ) return @ErrCode
	
	select @patternpos =(charindex(N'\',@subscriptionDbServer))
	
	IF (@patternpos <> 0)
	BEGIN --- then it must of the format <machine_name>\<sql server instance>,
	      --- hence strip it down to machine name
	   select @subscriptionDbServer = substring(@subscriptionDbServer,1,@patternpos-1)
	END
	
    select @AdminGroupName = @subscriptionDbServer + N'\' + @AdminGroupName
	
	select 	@MsmqtProtocolId = Id from adm_Adapter where MgmtCLSID = N'{9A7B0162-2CD5-4F61-B7EB-C40A3442A5F8}'
	
	-- Per DCR 36007, MSMQT adapter is now optional
	--	set @ErrCode = dbo.adm_CheckRowCount(@@ROWCOUNT)
	--	if ( @ErrCode <> 0 ) return @ErrCode

	select @MsmqtHandlers = count(*)
	from adm_SendHandler
	where
		adm_SendHandler.AdapterId = @MsmqtProtocolId AND
		adm_SendHandler.HostId = @AppTypeId

	-- load list of subservices
	select
		adm_HostInstance_SubServices.Name,
		adm_HostInstance_SubServices.MonikerName,
		adm_HostInstance_SubServices.ContextParam,
		adm_HostInstance_SubServices.UniqueId
	from
		adm_HostInstance_SubServices,
		adm_HostInstance,
		adm_Host,
		adm_Server2HostMapping
	where
		adm_HostInstance.UniqueId = @InstId
		AND adm_Server2HostMapping.Id = adm_HostInstance.Svr2HostMappingId
		AND adm_Host.Id = adm_Server2HostMapping.HostId
		AND (adm_HostInstance_SubServices.Type = 0
			 OR ( (adm_HostInstance_SubServices.Type & 1) <> 0 AND adm_Host.HostTracking <> 0)
			 OR ( (adm_HostInstance_SubServices.Type & 16) <> 0 AND @MsmqtHandlers > 0 ))
	order by
		adm_HostInstance_SubServices.Id ASC

	set nocount off
GO
GRANT EXEC ON [dbo].[adm_ApplicationInstance_get_details] TO BTS_HOST_USERS
GO

--/====================
-- CBR / Subscription related stored procs
-- /========================
CREATE PROCEDURE [dbo].[adm_SendPort_get_subscription_details]
@uidSendPort uniqueidentifier
AS

set nocount on
set transaction isolation level read committed

declare @nSendPortID int,
	@fIsDynamic bit

SELECT @nSendPortID = nID, @fIsDynamic = bDynamic
FROM bts_sendport
WHERE uidGUID = @uidSendPort

if (@fIsDynamic = 0)
BEGIN
	SELECT sp.nvcName, sp.nvcFilter, sp.nPortStatus, CAST(sp.bDynamic as int) AS bDynamic, CAST(sp.bTwoWay as int) AS bTwoWay, CAST(spt.bIsPrimary as int) AS bIsPrimary, sp.nPriority, h.Name, g.Name, ad.Name, ad.OutboundEngineCLSID, spt.uidGUID, CAST (spt.bIsServiceWindow AS int) AS bIsServiceWindow, [dbo].[adm_fnConvertLocalToUTCDate](spt.dtFromTime), [dbo].[adm_fnConvertLocalToUTCDate](spt.dtToTime), spt.nvcAddress, CAST (spt.bOrderedDelivery AS int) AS bOrderedDelivery
	FROM bts_sendport sp
	JOIN bts_sendport_transport spt 
		LEFT JOIN adm_SendHandler sh 
			JOIN adm_Adapter ad ON sh.AdapterId = ad.Id
			JOIN adm_Host h ON sh.HostId = h.Id
			JOIN adm_Group g ON sh.GroupId = g.Id
		ON spt.nSendHandlerID = sh.Id
	ON sp.nID = spt.nSendPortID
	WHERE sp.uidGUID = @uidSendPort
	ORDER BY bIsPrimary DESC
		
END
ELSE
BEGIN
	--lets make sure that we have subscription ids for all necessary send handlers
	INSERT INTO bts_dynamicport_subids (uidSendPortID, nSendHandlerID)
	SELECT @uidSendPort, sh.Id 
	FROM adm_SendHandler sh
	WHERE sh.IsDefault != 0 AND sh.Id NOT IN (SELECT nSendHandlerID FROM bts_dynamicport_subids WHERE uidSendPortID = @uidSendPort)

	SELECT sp.nvcName, sp.nvcFilter, sp.nPortStatus, 1, CAST(sp.bTwoWay as int) AS bTwoWay, 1, sp.nPriority,
		CASE WHEN (h.Name) IS NULL THEN dps.nvcHostName ELSE h.Name END AS Name,
		g.Name, ad.Name, ad.OutboundEngineCLSID, dps.uidGUID, 0, 0, 0, NULL, 0
	FROM bts_sendport sp
	JOIN bts_dynamicport_subids dps ON dps.uidSendPortID = sp.uidGUID
	LEFT JOIN adm_SendHandler sh
		JOIN adm_Adapter ad ON ad.Id = sh.AdapterId
		JOIN adm_Host h ON sh.HostId = h.Id
		JOIN adm_Group g ON sh.GroupId = g.Id
	ON dps.nSendHandlerID = sh.Id
	WHERE sp.uidGUID = @uidSendPort
END
GO
GRANT EXECUTE ON [dbo].[adm_SendPort_get_subscription_details] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_SendPort_get_subscription_details] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_SendPort_get_subscription_spg_details]
@uidSendPort uniqueidentifier
AS

SELECT spg.nvcName, spg.uidGUID, spg.nPortStatus, sp.uidGUID, sp.nvcName, CAST(sp.bTwoWay as int) AS bTwoWay, sp.nPortStatus, sp.nPriority, h.Name, g.Name, ad.Name, ad.OutboundEngineCLSID, spgp.uidPrimaryGUID, spt.uidGUID, CAST (spt.bIsServiceWindow AS int) AS bIsServiceWindow, [dbo].[adm_fnConvertLocalToUTCDate](spt.dtFromTime), [dbo].[adm_fnConvertLocalToUTCDate](spt.dtToTime), spt.nvcAddress, CAST (spt.bOrderedDelivery AS int) AS bOrderedDelivery
	FROM bts_sendport sp
	JOIN bts_spg_sendport spgp
		JOIN bts_sendportgroup spg ON spgp.nSendPortGroupID = spg.nID
	ON sp.nID = spgp.nSendPortID
	JOIN bts_sendport_transport spt 
		LEFT JOIN adm_SendHandler sh 
			JOIN adm_Adapter ad ON ad.Id = sh.AdapterId
			JOIN adm_Host h ON sh.HostId = h.Id
			JOIN adm_Group g ON sh.GroupId = g.Id
		ON spt.nSendHandlerID = sh.Id
	ON sp.nID = spt.nSendPortID AND spt.bIsPrimary = 1
	WHERE sp.uidGUID = @uidSendPort

GO
GRANT EXECUTE ON [dbo].[adm_SendPort_get_subscription_spg_details] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_SendPort_get_subscription_spg_details] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_SendPortGroup_get_details]
@uidSendPortGroup uniqueidentifier
AS

set nocount on
set transaction isolation level read committed

SELECT TOP 1 spg.nvcName, spg.nvcFilter, h.Name, g.Name
FROM bts_sendportgroup spg, adm_Group g
JOIN adm_Host h ON g.DefaultHostId = h.Id
WHERE spg.uidGUID = @uidSendPortGroup

GO
GRANT EXECUTE ON [dbo].[adm_SendPortGroup_get_details] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_SendPortGroup_get_details] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_SendPortGroup_get_subscription_details]
@uidSendPortGroup uniqueidentifier
AS
	
set nocount on
set transaction isolation level read committed

declare @nSendPortGroupID int

SELECT @nSendPortGroupID = nID
FROM bts_sendportgroup
WHERE uidGUID = @uidSendPortGroup

SELECT spg.nvcName, spg.uidGUID, spg.nPortStatus, sp.uidGUID, sp.nvcName, CAST(sp.bTwoWay as int) AS bTwoWay, sp.nPortStatus, sp.nPriority, h.Name, g.Name, ad.Name, ad.OutboundEngineCLSID, spgp.uidPrimaryGUID, spt.uidGUID, CAST (spt.bIsServiceWindow AS int) AS bIsServiceWindow, [dbo].[adm_fnConvertLocalToUTCDate](spt.dtFromTime), [dbo].[adm_fnConvertLocalToUTCDate](spt.dtToTime), spt.nvcAddress, CAST (spt.bOrderedDelivery AS int) AS bOrderedDelivery
FROM bts_spg_sendport spgp
JOIN bts_sendport sp 
	JOIN bts_sendport_transport spt 
		LEFT JOIN adm_SendHandler sh 
			JOIN adm_Adapter ad ON ad.Id = sh.AdapterId
			JOIN adm_Host h ON sh.HostId = h.Id
			JOIN adm_Group g ON sh.GroupId = g.Id
		ON spt.nSendHandlerID = sh.Id
	ON sp.nID = spt.nSendPortID AND spt.bIsPrimary = 1
ON sp.nID = spgp.nSendPortID
JOIN  bts_sendportgroup spg ON spg.nID = spgp.nSendPortGroupID
WHERE spgp.nSendPortGroupID = @nSendPortGroupID 

GO
GRANT EXECUTE ON [dbo].[adm_SendPortGroup_get_subscription_details] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_SendPortGroup_get_subscription_details] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_spgp_get_details]
@uidSPGP uniqueidentifier
AS

SELECT spg.nvcName, spg.uidGUID, spg.nPortStatus, sp.uidGUID, sp.nvcName, CAST(sp.bTwoWay as int) AS bTwoWay, sp.nPortStatus, sp.nPriority, h.Name, g.Name, ad.Name, ad.OutboundEngineCLSID, spgp.uidPrimaryGUID, spt.uidGUID, CAST (spt.bIsServiceWindow AS int) AS bIsServiceWindow, [dbo].[adm_fnConvertLocalToUTCDate](spt.dtFromTime), [dbo].[adm_fnConvertLocalToUTCDate](spt.dtToTime), spt.nvcAddress, CAST (spt.bOrderedDelivery AS int) AS bOrderedDelivery
FROM bts_spg_sendport spgp 
JOIN bts_sendportgroup spg ON spgp.nSendPortGroupID = spg.nID
JOIN bts_sendport sp
	JOIN bts_sendport_transport spt 
		LEFT JOIN adm_SendHandler sh 
			JOIN adm_Adapter ad ON ad.Id = sh.AdapterId
			JOIN adm_Host h ON sh.HostId = h.Id
			JOIN adm_Group g ON sh.GroupId = g.Id
		ON spt.nSendHandlerID = sh.Id
	ON sp.nID = spt.nSendPortID AND spt.bIsPrimary = 1
ON sp.nID = spgp.nSendPortID
WHERE spgp.uidPrimaryGUID = @uidSPGP

GO
GRANT EXECUTE ON [dbo].[adm_spgp_get_details] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_spgp_get_details] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_get_adapterinfo]
@uidSendPortID uniqueidentifier,
@nvcGroupName nvarchar(256) OUTPUT,
@nvcHostName nvarchar(80) OUTPUT
AS

SELECT @nvcGroupName = g.Name, @nvcHostName = h.Name
FROM bts_sendport sp
JOIN bts_sendport_transport spt 
	JOIN adm_SendHandler sh
		JOIN adm_Host h ON sh.HostId = h.Id
		JOIN adm_Group g ON sh.GroupId = g.Id
	ON spt.nSendHandlerID = sh.Id
ON sp.nID = spt.nSendPortID AND spt.bIsPrimary = 1
WHERE sp.uidGUID = @uidSendPortID

GO
GRANT EXECUTE ON [dbo].[adm_get_adapterinfo] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_get_adapterinfo] TO BTS_OPERATORS
GO

CREATE PROCEDURE [dbo].[adm_get_subscriptions_for_host]
@nvcAdapterName nvarchar(256),
@nvcHostName nvarchar(80),
@bGetDynamicPorts bit,
@bGetStaticPorts bit,
@nvcGroupName nvarchar(256) OUTPUT,
@nCount int OUTPUT
AS
declare @nAdapterID int,
	@nSendHandlerID int

SELECT @nAdapterID = a.Id, @nSendHandlerID = sh.Id, @nvcGroupName = g.Name
FROM adm_Adapter a
JOIN adm_SendHandler sh
	JOIN adm_Group g ON sh.GroupId = g.Id
	JOIN adm_Host h ON sh.HostId = h.Id AND h.Name = @nvcHostName
  ON a.Id = sh.AdapterId
WHERE a.Name = @nvcAdapterName  
if (@@ROWCOUNT = 0)
BEGIN
	set @nCount = -1
	return
END

SELECT uidGUID 
FROM bts_sendport_transport spt
WHERE spt.nTransportTypeId = @nAdapterID AND @bGetStaticPorts = 1
UNION
SELECT spgs.uidPrimaryGUID as uidGUID
FROM bts_spg_sendport spgs
JOIN bts_sendport_transport spt ON spgs.nSendPortID = spt.nID AND spt.bIsPrimary = 1 AND spt.nTransportTypeId = @nAdapterID
WHERE @bGetStaticPorts = 1
UNION
SELECT dps.uidGUID 
FROM bts_dynamicport_subids dps
WHERE dps.nSendHandlerID = @nSendHandlerID AND @bGetDynamicPorts = 1

set @nCount = @@ROWCOUNT

GO
GRANT EXEC ON [dbo].[adm_get_subscriptions_for_host] TO BTS_ADMIN_USERS
GRANT EXECUTE ON [dbo].[adm_get_subscriptions_for_host] TO BTS_OPERATORS
GO

CREATE PRoCEDURE [dbo].[adm_GetMSMQtTransportName]
@nvcMSMQtTransport nvarchar(256) OUTPUT
AS

SELECT @nvcMSMQtTransport = Name FROM adm_Adapter WHERE OutboundEngineCLSID = N'{0EE2AEC3-F646-41A6-80A1-A1AF5ED4F02B}'
GO
GRANT EXEC ON [dbo].[adm_GetMSMQtTransportName] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[MBOM_GetHosts]
AS
	SET NOCOUNT ON
	
	select
		adm_Host.Name, 
		adm_Host.NTGroupName
	from
		adm_Host
		
	RETURN 

GO
GRANT EXECUTE ON [dbo].[MBOM_GetHosts] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[MBOM_GetMessageBoxes]
AS
	SET NOCOUNT ON
	select
		adm_MessageBox.DBServerName, 
		adm_MessageBox.DBName
	from
		adm_MessageBox
	RETURN 

GO
GRANT EXECUTE ON [dbo].[MBOM_GetMessageBoxes] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[MBOM_GetOrchestrationTypes]
AS
	SET NOCOUNT ON
	
	select distinct
		o.nvcName,
		o.uidGUID,
		a.nvcName,
		a.nvcVersion,
		a.nvcCulture,
		a.nvcPublicKeyToken,
		h.Name
	from
		bts_assembly a,
		bts_orchestration o left outer join adm_Host h on o.nAdminHostID = h.Id
	where
		o.nAssemblyID = a.nID
		
		
	RETURN 

GO
GRANT EXECUTE ON [dbo].[MBOM_GetOrchestrationTypes] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[MBOM_GetSendPortTransports]
AS
	SET NOCOUNT ON
	
	select st.uidGUID, sp.nvcName, a.Name, st.nvcAddress, sp.bDynamic, sp.bTwoWay, st.bOrderedDelivery, st.bIsPrimary, sp.uidGUID
	from 
		bts_sendport as sp
		left outer join bts_sendport_transport as st on (sp.nID = st.nSendPortID)
		left outer join adm_Adapter as a on (st.nTransportTypeId = a.Id)
	
	RETURN

GO
GRANT EXECUTE ON [dbo].[MBOM_GetSendPortTransports] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[MBOM_GetReceiveTransports]
AS
	SET NOCOUNT ON

	-- Special case: agent uses MSMQ ClassId for the service TypeId while InboundEngineCLSID is used for other transports
	declare @ServiceClassMSMQT as uniqueidentifier, @ServiceClassMessaging as uniqueidentifier
	select @ServiceClassMSMQT = N'{3D7A3F58-4BFB-4593-B99E-C2A5DC35A3B2}'
	
	select
			case
			when (adm_Adapter.MgmtCLSID = N'{9A7B0162-2CD5-4F61-B7EB-C40A3442A5F8}')
				then @ServiceClassMSMQT
				else adm_Adapter.InboundEngineCLSID
			end,
			Name
	from
		adm_Adapter
	where
		adm_Adapter.InboundEngineCLSID is not NULL -- skip protocols that don't support receive
	
	union all
	
	select
			uidGUID,
			nvcName
	from
		bts_receiveport

	RETURN

GO
GRANT EXECUTE ON [dbo].[MBOM_GetReceiveTransports] TO BTS_ADMIN_USERS
GO

--//
--// BAM Stored Procedures
--//

CREATE PROCEDURE [dbo].[admbam_RemoveOrchestrationInterceptorConfiguration]
@uidServiceId uniqueidentifier,
@uidInterceptorId uniqueidentifier
AS
	DELETE FROM StaticTrackingInfo
	WHERE uidServiceId = @uidServiceId
	    AND uidInterceptorId = @uidInterceptorId
GO

GRANT EXECUTE ON [dbo].[admbam_RemoveOrchestrationInterceptorConfiguration] TO BTS_ADMIN_USERS
GO
