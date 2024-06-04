--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/ 

/******************************************************************************\
|||||||||||||||||||||||||||||| btf_receiver_insert |||||||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

/****** Object:  Stored Procedure [dbo].[btf_receiver_insert]    Script Date: 2/7/2003 10:10:15 AM ******/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_receiver_insert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_receiver_insert'
    DROP PROCEDURE [dbo].[btf_receiver_insert]
END
GO

CREATE PROCEDURE [dbo].[btf_receiver_insert]
@TIdentity    varchar(256),
@TLifespan    datetime,
@fSuccess	  int OUTPUT
AS
--------------------------------------------------------------------------------
-- file btf_message_logic.sql                         proc [btf_receiver_insert]
--------------------------------------------------------------------------------
--
-- Insert row into the receiver side btf pipeline component table. If one already exists in the table
-- our dupicate key constraint will fail and no rows will be inserted. Check the @@ROWCOUNT
-- varaible to see if a row was really inserted and return this inforamtion in the fSuccess OUTPUT parameter
-- Finding a row indicates the message with TIdentity <identity> has been sent a delivery
-- receipt before.
--
-- Input
-- 1)   TIdentity   Message's <identity> property value.
-- 2)   TLifespan   Row's expiration date/time
--
-- Output
--      1 if this is a new message and we have not received it before
--		0 if this message already exists in our table
--------------------------------------------------------------------------------
    SET NOCOUNT ON

    DECLARE @nodes AS INTEGER

    INSERT INTO [dbo].[btf_message_receiver]  ( [identity], [expires_at] )
									VALUES    ( @TIdentity, @TLifespan )

    set @fSuccess = @@ROWCOUNT
GO

GRANT EXEC ON [dbo].[btf_receiver_insert] TO BTS_HOST_USERS
GO

/******************************************************************************\
||||||||||||||||||||||||||||||| btf_acknowledged_check ||||||||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

/****** Object:  Stored Procedure [dbo].[btf_acknowledged_check]    Script Date: 2/7/2003 10:10:15 AM ******/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_acknowledged_check]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_acknowledged_check'
    DROP PROCEDURE [dbo].[btf_acknowledged_check]
END
GO

CREATE PROCEDURE [dbo].[btf_acknowledged_check]
@TIdentity    varchar(256),
@nCount		  int OUTPUT
AS
--------------------------------------------------------------------------------
-- file btf_message_logic.sql                           proc [btf_acknowledged_check]
--------------------------------------------------------------------------------
--
-- Insert row into the sender side btf pipeline component table only if no row
-- with speicifed <identity> exists.  
--
-- Input
-- 1)   TIdentity   Message's <identity> property value.
-- 2)   TLifespan   Row's expiration date/time
--
-- Output
-- 1) @nCount	count of rows which still need to be acknowledged. If this is a new row, it will be one
--				but if the row already existed, it could be zero.
--------------------------------------------------------------------------------
    SET NOCOUNT ON

--    INSERT INTO [dbo].[btf_message_sender]  ( [identity], [expires_at], [acknowledged] )
--									VALUES  ( @TIdentity, @TLifespan, 'n' )
									
	SELECT @nCount = COUNT(*) FROM [dbo].[btf_message_sender] WHERE [identity] = @TIdentity AND [acknowledged] = 'A'
GO

GRANT EXEC ON [dbo].[btf_acknowledged_check] TO BTS_HOST_USERS
GO

/******************************************************************************\
|||||||||||||||||||||||||| btf_receiver_expired_delete |||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

/****** Object:  Stored Procedure [dbo].[btf_receiver_expired_delete]    Script Date: 2/7/2003 10:10:15 AM ******/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_receiver_expired_delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_receiver_expired_delete'
    DROP PROCEDURE [dbo].[btf_receiver_expired_delete]
END
GO

CREATE PROCEDURE [dbo].[btf_receiver_expired_delete]
@TExpires 	datetime
AS
--------------------------------------------------------------------------------
-- file btf_message_logic.sql                 proc [btf_receiver_expired_delete]
--------------------------------------------------------------------------------
--
-- Delete expired rows of the receiver side btf pipeline component table.
-- Input
-- 1)   TExpires    Current date/time.  Delete all rows with expired_at before this
--                  date/time.
--
-- Output
--      none
--------------------------------------------------------------------------------
    SET NOCOUNT ON

    DELETE FROM [dbo].[btf_message_receiver]
    WHERE [expires_at] < @TExpires

GO

GRANT EXEC ON [dbo].[btf_receiver_expired_delete] TO BTS_HOST_USERS
GO

/******************************************************************************\
||||||||||||||||||||||||||| btf_sender_expired_delete ||||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

/****** Object:  Stored Procedure [dbo].[btf_sender_expired_delete]    Script Date: 2/7/2003 10:10:15 AM ******/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_sender_expired_delete]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_sender_expired_delete'
    DROP PROCEDURE [dbo].[btf_sender_expired_delete]
END
GO

CREATE PROCEDURE [dbo].[btf_sender_expired_delete]
@TExpires 	datetime
AS
--------------------------------------------------------------------------------
-- file btf_message_logic.sql                   proc [btf_sender_expired_delete]
--------------------------------------------------------------------------------
--
-- Delete expired rows of the sender side btf pipeline component table.
-- Input
-- 1)   TExpires    Current date/time.  Delete all rows with expired_at before this
--                  date/time.
--
-- Output
--      none
--------------------------------------------------------------------------------
    SET NOCOUNT ON

    DELETE FROM [dbo].[btf_message_sender]
    WHERE [expires_at] < @TExpires AND [acknowledged] = 'A'

GO

GRANT EXEC ON [dbo].[btf_sender_expired_delete] TO BTS_HOST_USERS
GO

/******************************************************************************\
|||||||||||||||||||||||||||| btf_acknowledged_update |||||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

/****** Object:  Stored Procedure [dbo].[btf_acknowledged_update]    Script Date: 2/7/2003 10:10:15 AM ******/
IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_acknowledged_update]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_acknowledged_update'
    DROP PROCEDURE [dbo].[btf_acknowledged_update]
END
GO

CREATE PROCEDURE [dbo].[btf_acknowledged_update]
@TIdentity    varchar(256),
@dtExpires	  datetime
AS
--------------------------------------------------------------------------------
-- file btf_message_logic.sql                     proc [btf_acknowledged_update]
--------------------------------------------------------------------------------
--
-- Update row in the sender side btf pipeline component table to
-- mark the message as acknowledged.
--
-- Input
-- 1)   TIdentity   Message's <identity> property value.
--
-- Output
--      nodes       Number of acknowledged messages with <identity> TIdentity.
--                  A value > 0 indicates an acknowledged message, either one
--                  acknowledged here or on a previous procedure call.
--
--------------------------------------------------------------------------------
    SET NOCOUNT ON

    INSERT INTO [dbo].[btf_message_sender] ([identity], [expires_at], [acknowledged] )
									VALUES (@TIdentity, @dtExpires,   'A')

GO

GRANT EXEC ON [dbo].[btf_acknowledged_update] TO BTS_HOST_USERS
GO

/******************************************************************************\
||||||||||||||||||||||||||| btf_PurgeExpiredMessages |||||||||||||||||||||||||||
\******************************************************************************/

SET QUOTED_IDENTIFIER OFF
SET ANSI_NULLS ON
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[btf_PurgeExpiredMessages]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
    PRINT 'Dropping stored procedure btf_PurgeExpiredMessages'
    DROP PROCEDURE [dbo].[btf_PurgeExpiredMessages]
END
GO

CREATE PROCEDURE [dbo].[btf_PurgeExpiredMessages]
AS
    SET NOCOUNT ON

    DECLARE @currTime AS DATETIME

    SET @currTime = GetUtcDate();
    
    EXEC btf_sender_expired_delete @currTime 
    EXEC btf_receiver_expired_delete @currTime
    
GO

-- Create the BTF cleanup job that deleted the expired entried in the database.
BEGIN TRANSACTION            
  DECLARE @JobID BINARY(16)  
  DECLARE @ReturnCode INT    
  SELECT @ReturnCode = 0     

   declare @name sysname
   set @name = N'CleanupBTFExpiredEntriesJob_' + db_name()
 
IF (SELECT COUNT(*) FROM msdb.dbo.syscategories WHERE name = N'Database Maintenance') < 1 
  EXECUTE msdb.dbo.sp_add_category @name = N'Database Maintenance'

  -- Delete the job with the same name (if it exists)
  SELECT @JobID = job_id     
  FROM   msdb.dbo.sysjobs    
  WHERE (name = @name)       
  IF (@JobID IS NOT NULL)    
  BEGIN  
  -- Check if the job is a multi-server job  
  IF (EXISTS (SELECT  * 
              FROM    msdb.dbo.sysjobservers 
              WHERE   (job_id = @JobID) AND (server_id <> 0))) 
  BEGIN 
    -- There is, so abort the script 
    RAISERROR (N'Unable to import job ''CleanupBTFExpiredEntriesJob'' since there is already a multi-server job with this name.', 16, 1) 
    GOTO QuitWithRollback  
  END 
  ELSE 
    -- Delete the [local] job 
    EXECUTE msdb.dbo.sp_delete_job @job_name = @name 
    SELECT @JobID = NULL
  END 

BEGIN 

  -- Add the job
  declare @dbname sysname
  set @dbname = db_name()
  EXECUTE @ReturnCode = msdb.dbo.sp_add_job @job_id = @JobID OUTPUT , @job_name = @name, @description = N'cleanup expired btf entries', @category_name = N'Database Maintenance', @enabled = 1, @notify_level_email = 0, @notify_level_page = 0, @notify_level_netsend = 0, @notify_level_eventlog = 2, @delete_level= 0
  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 

  -- Add the job steps
  EXECUTE @ReturnCode = msdb.dbo.sp_add_jobstep @job_id = @JobID, @step_id = 1, @step_name = N'step1', @command = N'exec btf_PurgeExpiredMessages', @database_name = @dbname, @server = N'', @database_user_name = N'', @subsystem = N'TSQL', @cmdexec_success_code = 0, @flags = 0, @retry_attempts = 0, @retry_interval = 1, @output_file_name = N'', @on_success_step_id = 0, @on_success_action = 1, @on_fail_step_id = 0, @on_fail_action = 2
  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 
  EXECUTE @ReturnCode = msdb.dbo.sp_update_job @job_id = @JobID, @start_step_id = 1 

  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 

  -- Add the job schedules
  EXECUTE @ReturnCode = msdb.dbo.sp_add_jobschedule @job_id = @JobID, @name = N'sched', @enabled = 1, @freq_type = 4, @active_start_date = 19900101, @active_start_time = 0, @freq_interval = 1, @freq_subday_type = 8, @freq_subday_interval = 12, @freq_relative_interval = 0, @freq_recurrence_factor = 0, @active_end_date = 99991231, @active_end_time = 235959
  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 

  -- Add the Target Servers
  EXECUTE @ReturnCode = msdb.dbo.sp_add_jobserver @job_id = @JobID, @server_name = N'(local)' 
  IF (@@ERROR <> 0 OR @ReturnCode <> 0) GOTO QuitWithRollback 

END
COMMIT TRANSACTION          
 GOTO   EndSave              
QuitWithRollback:
  IF (@@TRANCOUNT > 0) ROLLBACK TRANSACTION 
EndSave: 

GO
