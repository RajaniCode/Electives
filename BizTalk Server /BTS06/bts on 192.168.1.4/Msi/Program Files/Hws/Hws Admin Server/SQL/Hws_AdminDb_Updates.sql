--/ Copyright (c) Microsoft Corporation. All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  

/*************************************************************************************************************************************

							PLEASE READ!

	The Product Version (DLL) value must be updated prior to running this script.  This value should be provide as part 
	of this process.  Please update this value in the adm_Register_BizTalkDB proc call at the end of this script.

*************************************************************************************************************************************/


IF NOT EXISTS ( SELECT 		1
		FROM 		syscolumns c
		INNER JOIN	sysobjects o
		ON		c.id = o.id
		WHERE 		c.name=N'IsRootStep' 
		AND		o.name=N'ActivityModelSteps' )
 BEGIN
	/*
		Define the column as null to start
	*/
	ALTER TABLE [dbo].[ActivityModelSteps]
		ADD IsRootStep bit NULL
 END
GO

/*
	Compute values for new column for all rows
*/
IF NOT EXISTS ( SELECT 		1
		FROM 		syscolumns c
		INNER JOIN	sysobjects o
		ON		c.id = o.id
		WHERE 		c.name=N'IsRootStep' 
		AND		o.name=N'ActivityModelSteps' )
 BEGIN
	RAISERROR( N'IsRootStep does not exist.  Cannot update column.', 16, -1 )
 END

/*
	If any columns have not null values this is a re-run
*/	
IF EXISTS ( SELECT 1 FROM [dbo].[ActivityModelSteps] WHERE IsRootStep IS NOT NULL )
	RETURN

DECLARE @count int, @Rowcount int

SELECT 	@count = count(*) FROM [dbo].[ActivityModelSteps]

/*
	Code to set IsRootStep.
*/
UPDATE [dbo].[ActivityModelSteps]
SET IsRootStep = 1
FROM [dbo].[ActivityModelSteps] steps
WHERE ActivityModelStepId IN
	(SELECT ParentStepId FROM [dbo].[ActivityModelStepRel] stepRel
	 WHERE stepRel.ActivityModelGuid = steps.ActivityModelGuid)
AND   ActivityModelStepId NOT IN
        (SELECT ChildStepId FROM [dbo].[ActivityModelStepRel] stepRel
	 WHERE stepRel.ActivityModelGuid = steps.ActivityModelGuid)   

SELECT @Rowcount = @@ROWCOUNT

UPDATE	[dbo].[ActivityModelSteps]
SET IsRootStep = 0
WHERE  IsRootStep IS NULL 

SELECT @Rowcount = @Rowcount + @@ROWCOUNT

IF @Rowcount <> @count OR EXISTS ( SELECT 1 FROM [dbo].[ActivityModelSteps] WHERE IsRootStep IS NULL )
 BEGIN
	--not localized
	RAISERROR( N'Count of updated records does not match the count of records in the [dbo].[ActivityModelSteps]. After determining cause please manually drop column [dbo].[ActivityModelSteps].[IsRootStep] and re-run.', 16, -1 )
 END
ELSE
 BEGIN
	/*
		Drop nullable attribute
	*/
	ALTER TABLE [dbo].[ActivityModelSteps]
		ALTER COLUMN IsRootStep bit NOT NULL
 END

GO

ALTER TABLE [dbo].[ActivityModelTargetXPaths]
	ALTER COLUMN [XPathFromParentStep] [Hws_Type_TargetXPath] NULL
GO


ALTER TABLE [dbo].[ActivityModelTaskMessageTypes]
	ALTER COLUMN [TaskMessageType] [Hws_Type_HwsTaskMessageType] NULL
GO

/*
	Update the Hws_service table
*/

IF OBJECT_ID( 'Hws_Service_Old' ) IS NOT NULL OR OBJECT_ID( 'Hws_Service_Bad' ) IS NOT NULL
 BEGIN
	RAISERROR( 'Please manually drop tables Hws_Service_Old and Hws_Service_Bad before re-running after a failure', 16, -1 )
 END
GO

IF OBJECT_ID('PK_Hws_Service') IS NOT NULL
	ALTER TABLE [dbo].[Hws_Service] DROP [PK_Hws_Service]
GO

IF OBJECT_ID('FK_Hws_Service_Hws_Core') IS NOT NULL
	ALTER TABLE [dbo].[Hws_Service] DROP CONSTRAINT [FK_Hws_Service_Hws_Core]
GO

DECLARE @Error int, @Ret int

exec @Ret = sp_rename 'Hws_Service', 'Hws_Service_Old'

SELECT @Error = @@ERROR

IF @Ret <> 0 OR @ERROR <> 0
 BEGIN
	RAISERROR( 'Failed renaming Hws_Service to Hws_Service_Old', 16, -1 )
 END
GO

CREATE TABLE [dbo].[Hws_Service] (
	[ServiceUrl] [nvarchar] (2048) NOT NULL ,
	[MachineName] [nvarchar] (256) NOT NULL ,
	[WebSiteID] [bigint] NOT NULL ,
	[HwsCoreID] [uniqueidentifier] NOT NULL 
) ON [PRIMARY]

GO

	
ALTER TABLE [dbo].[Hws_Service] ADD 
	CONSTRAINT [PK_Hws_Service] PRIMARY KEY  CLUSTERED 
	(
		[MachineName]
	)  ON [PRIMARY] 

GO

ALTER TABLE [dbo].[Hws_Service] ADD 
	CONSTRAINT [FK_Hws_Service_Hws_Core] FOREIGN KEY 
	(
		[HwsCoreID]
	) REFERENCES [dbo].[Hws_Core] (
		[ID]
	)

GO


DECLARE @Error int, @Ret int, @Count int, @Rowcount int

SELECT @Count = count(*) FROM [dbo].[Hws_Service_Old]

INSERT	[dbo].[Hws_Service] ( 
		[ServiceUrl], 
		[MachineName], 
		[WebSiteID], 
		[HwsCoreID] 
)
SELECT		[ServiceUrl],
		[MachineName],
		1,  -- EAP only allowed Hws service installation in the Default Website
		[HwsCoreID]
FROM	[dbo].[Hws_Service_Old]

SELECT @Rowcount = @@Rowcount

IF @Count <> @Rowcount
 BEGIN
	/*
		Bad news, row counts don't match
		Restore the old state so that the script can be re-run
	*/
	exec @Ret = sp_rename 'Hws_Service', 'Hws_Service_Bad'

	SELECT @Error = @@ERROR

	IF @Ret <> 0 OR @Error <> 0
	 BEGIN
		RAISERROR( 'Failed copying data from old table to new table.  Failed restoring previous state', 16 , -1 )
	 END

	exec @Ret = sp_rename 'Hws_Service_Old', 'Hws_Service'

	SELECT @Error = @@ERROR

	IF @Ret <> 0 OR @Error <> 0
	 BEGIN
		RAISERROR( 'Failed copying data from old table to new table.  Failed restoring previous state', 16 , -1 )
	 END

	RAISERROR( 'Failed copying data from old table to new table.', 16, -1 )
 END
ELSE
 BEGIN
	DROP TABLE [dbo].[Hws_Service_Old]

 END

GO
/*
	IMPORTANT!  Manually edit the Product Version (DLL) <version #> value
*/
exec adm_Register_BizTalkDB
       N'HWS Administration DB',	-- DB Name
       3, 1, 0, 0,          		-- Schema Version
       3, 0, <version #>, 0,		-- Product Version (DLL)
       1033,                		-- Language code
       N'RTM'               		-- Comment

GO
/*
	Update the activate and task response and interrupt url values
	This is only done if the EAP default values are still present
*/
set nocount on

declare @Activate nvarchar(256), @Interrupt nvarchar(256)

select 	@Activate = [ActivationMessageURL]
	,@Interrupt=[InterruptMessageURL]
from	[dbo].[Hws_Core]

if @@ERROR <> 0 
	or @Activate is null 
	or @Interrupt is null 
	or len( @Activate ) <= 39 
	or len( @Interrupt ) <= 40 
	or right( @Activate, 39 ) <> N'HwsMessages/Activate/BtsHttpReceive.dll' 
	or right( @Interrupt, 40 ) <> N'HwsMessages/Interrupt/BtsHttpReceive.dll'
 begin
	print N''
	print N'*****************************************************************************************************************************************************'
	print N'**'
	print N'** This script was unable to automatically update the URLs for Activate, Task Response and Interrupt messages.'
	print N'** Please use the Hws Administration console to update these values after configuration has been run.'
	print N'**'
	print N'*****************************************************************************************************************************************************'
	print N''
	return
 end

select	@Activate  = left( @Activate, len( @Activate ) - 39 ) + N'HwsMessages/BtsHttpReceive.dll?Activate'
	,@Interrupt= left( @Interrupt,len( @Interrupt) - 40 ) + N'HwsMessages/BtsHttpReceive.dll?InterruptAndResponse'


update	[dbo].[Hws_Core]
set	[ActivationMessageURL] = @Activate
	,[InterruptMessageURL] = @Interrupt

GO

 




