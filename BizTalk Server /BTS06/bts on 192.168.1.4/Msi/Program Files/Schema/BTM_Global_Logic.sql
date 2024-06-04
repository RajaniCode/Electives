--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

-- //////////////////////////////////////////////////////////////////////////////////////////////////
-- Remove existing functions
-- //////////////////////////////////////////////////////////////////////////////////////////////////
if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removescalarfunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) exec bts_removescalarfunctions
GO

CREATE PROCEDURE [dbo].[bts_removescalarfunctions]
AS
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_removescalarfunctions]') and OBJECTPROPERTY(id, N'IsProcedure') = 1) drop procedure [dbo].[bts_removescalarfunctions]
	
	if exists (select * from sysobjects where id = object_id(N'[dbo].[bts_OrchestrationBindingComplete]') and OBJECTPROPERTY(id, N'IsScalarFunction') = 1) drop function [dbo].[bts_OrchestrationBindingComplete]
	
GO


--/---------------------------------------------------------------------------------------------------------------
--
-- create functions
--
--/---------------------------------------------------------------------------------------------------------------


--/---------------------------------------------------------------------------------------------------------------
-- This function accepts the ServiceID as parameter and checks whether the Service is fully
-- bound and returns 0, if fully bound or else returns the number of ports yet to be bound
-- Direct Binding ports(nBindingType = 3) and used role ports(bLink = 0) are not considered
--/---------------------------------------------------------------------------------------------------------------
CREATE FUNCTION [dbo].[bts_OrchestrationBindingComplete](@nOrchestrationID int)
RETURNS int
AS
	BEGIN
		DECLARE @retval int
			select @retval = count(*) from bts_orchestration service
			right join bts_orchestration_port port on (port.nOrchestrationID = service.nID and port.nBindingOption <> 3 and port.bLink = 0)
			left join bts_orchestration_port_binding binding on binding.nOrcPortID = port.nID
			where service.nID = @nOrchestrationID and (binding.nSendPortID is null and binding.nReceivePortID is null and binding.nSpgID is null)
		RETURN(@retval)
	END
GO
--/---------------------------------------------------------------------------------------------------------------

