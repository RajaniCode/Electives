--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
------------------------------------------------------------------------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_CreatePipeline]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_CreatePipeline]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_DeletePipeline]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_DeletePipeline]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_LoadPipelineByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_LoadPipelineByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_LoadStageByID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_LoadStageByID]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_AddStage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_AddStage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_AddComponent]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_AddComponent]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[btm_GetPipelineDefinition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[btm_GetPipelineDefinition]
GO

CREATE PROCEDURE [dbo].[btm_CreatePipeline]
@PipelineID uniqueidentifier,
@Category smallint,
@Name nvarchar(256),
@FullyQualifiedName nvarchar(256),
@IsStreaming smallint,
@AssemblyID int,
@Release int,
@ID int OUTPUT
AS

set xact_abort on

INSERT INTO bts_pipeline(PipelineID, Category, Name, FullyQualifiedName, IsStreaming, nAssemblyID, Release)
		VALUES (@PipelineID, @Category, @Name, @FullyQualifiedName, @IsStreaming, @AssemblyID, @Release)
		
set @ID = @@IDENTITY
GO
GRANT EXEC ON [dbo].[btm_CreatePipeline] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[btm_DeletePipeline]
@PipelineID uniqueidentifier,
@fSuccess int OUTPUT
AS

set xact_abort on


DELETE bts_component FROM
   bts_component C INNER JOIN bts_stage_config SC ON SC.CompID=C.Id
   	INNER JOIN bts_pipeline_stage PS ON SC.StageID=PS.Id 
   	INNER JOIN bts_pipeline_config PC ON PS.Id=PC.StageID
   	INNER JOIN bts_pipeline P ON PC.PipelineID=P.Id
   WHERE P.PipelineID=@PipelineID

DELETE bts_stage_config FROM
   bts_stage_config SC INNER JOIN bts_pipeline_stage PS ON SC.StageID=PS.Id 
   	INNER JOIN bts_pipeline_config PC ON PS.Id=PC.StageID
   	INNER JOIN bts_pipeline P ON PC.PipelineID=P.Id
   WHERE P.PipelineID=@PipelineID

DELETE bts_pipeline_stage FROM
   	bts_pipeline_stage PS INNER JOIN bts_pipeline_config PC ON PS.Id=PC.StageID
   	INNER JOIN bts_pipeline P ON PC.PipelineID=P.Id
   WHERE P.PipelineID=@PipelineID

DELETE bts_pipeline_config FROM
   bts_pipeline_config PC INNER JOIN bts_pipeline P ON PC.PipelineID=P.Id
   WHERE P.PipelineID=@PipelineID 


-- DELETE StaticTrackingInfo WHERE StaticTrackingInfo.uidServiceId=@PipelineID
	
DELETE bts_pipeline
	WHERE bts_pipeline.PipelineID=@PipelineID
		
set @fSuccess = 1
GO
GRANT EXEC ON [dbo].[btm_DeletePipeline] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[btm_LoadPipelineByID]
@PipelineID uniqueidentifier,
@Category smallint OUTPUT,
@AssemblyID int OUTPUT,
@Name nvarchar(256) OUTPUT,
@IsStreaming smallint OUTPUT,
@Version int OUTPUT,
@StrongName nvarchar(256) OUTPUT,
@fSuccess int OUTPUT
AS

set nocount on

declare @ID int

SELECT TOP 1 
	@ID = Id,
	@Category = Category,
	@AssemblyID = nAssemblyID,
	@Name = Name,
	@IsStreaming = IsStreaming,
	@Version = Release,
	@StrongName = FullyQualifiedName
	
FROM bts_pipeline WITH (ROWLOCK)
WHERE PipelineID = @PipelineID

IF (@@ROWCOUNT = 1)
BEGIN
	SELECT pc.Sequence, ps.Id, ps.Category, ps.Name, ps.ExecOptions
	FROM  bts_pipeline_stage ps INNER JOIN bts_pipeline_config pc ON pc.StageID=ps.Id
	WHERE pc.PipelineID = @ID
	ORDER BY pc.Sequence

	set @fSuccess = 1
END
ELSE
BEGIN
	set @fSuccess = 0
END
GO
GRANT EXEC ON [dbo].[btm_LoadPipelineByID] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[btm_LoadStageByID]
@StageID int,
@fSuccess int OUTPUT
AS

set nocount on

SELECT s.Sequence, c.ClsID, c.TypeName, c.AssemblyPath, c.CustomData
FROM  bts_component AS c WITH (ROWLOCK),
	bts_stage_config AS s WITH (ROWLOCK)
WHERE s.StageID = @StageID and
	s.CompID = c.Id
ORDER BY s.Sequence

set @fSuccess = 1

GO
GRANT EXEC ON [dbo].[btm_LoadStageByID] TO BTS_HOST_USERS
GO

CREATE PROCEDURE [dbo].[btm_AddStage]
@pipelineID int,
@sequence int,
@Category uniqueidentifier,
@Name nvarchar(64),
@ExecOptions int,
@StageID int OUTPUT
AS
INSERT INTO bts_pipeline_stage (Category, Name, ExecOptions)
		 VALUES (@Category, @Name, @ExecOptions)

SELECT @StageID = @@IDENTITY
INSERT INTO bts_pipeline_config ( PipelineID, StageID, Sequence)
	   VALUES ( @pipelineID, @StageID, @sequence)

GO
GRANT EXEC ON [dbo].[btm_AddStage] TO BTS_ADMIN_USERS
GO

CREATE PROCEDURE [dbo].[btm_AddComponent]
@StageID int,
@Sequence int,
@Name nvarchar(64),
@Version nvarchar(10),
@ClsID uniqueidentifier=null,
@TypeName nvarchar(256),
@AssemblyPath nvarchar(256),
@Description nvarchar(256),
@CustomData image,
@CompID int OUTPUT
AS

INSERT INTO bts_component (Name, Version, ClsID, TypeName, AssemblyPath, Description, CustomData)
		 VALUES (@Name, @Version, @ClsID, @TypeName, @AssemblyPath, @Description, @CustomData)

select @CompID = @@IDENTITY

INSERT INTO bts_stage_config ( StageID, CompID, Sequence)
	   VALUES ( @StageID, @CompID, @Sequence)
GO
GRANT EXEC ON [dbo].[btm_AddComponent] TO BTS_ADMIN_USERS
GO


CREATE PROCEDURE [dbo].[btm_GetPipelineDefinition]
@PipelineFQN nvarchar(256)
AS

set nocount on

SELECT 
	s.Category, s.Name, c.TypeName, sc.Sequence, c.Name, c.CustomData, c.ClsID
FROM 
	bts_pipeline as p, 
	bts_pipeline_config as ps, 
	bts_pipeline_stage as s, 
	bts_component as c, 
	bts_stage_config as sc
WHERE 
	p.FullyQualifiedName = @PipelineFQN AND
	ps.PipelineID = p.Id AND
	ps.StageID = s.Id AND
	sc.StageID = s.Id AND 
	sc.CompID = c.Id
ORDER BY ps.Sequence, sc.Sequence

GO
GRANT EXEC ON [dbo].[btm_GetPipelineDefinition] TO BTS_ADMIN_USERS
GO
