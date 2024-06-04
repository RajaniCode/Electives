--/ Copyright (c) Microsoft Corporation.  All rights reserved. 
--/  
--/ THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
--/ WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
--/ WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
--/ THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
--/ AND INFORMATION REMAINS WITH THE USER. 
--/  
------------------------------------------------------------------------------

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_bts_stage_config_bts_component]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[bts_stage_config] DROP CONSTRAINT FK_bts_stage_config_bts_component
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_bts_pipeline_config_bts_pipeline]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[bts_pipeline_config] DROP CONSTRAINT FK_bts_pipeline_config_bts_pipeline
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_bts_pipeline_config_bts_pipeline_stage]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[bts_pipeline_config] DROP CONSTRAINT FK_bts_pipeline_config_bts_pipeline_stage
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_bts_stage_config_bts_pipeline_stage]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[bts_stage_config] DROP CONSTRAINT FK_bts_stage_config_bts_pipeline_stage
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_component]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_component]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_stage_config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_stage_config]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_pipeline_config]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_pipeline_config]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_pipeline_stage]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_pipeline_stage]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[bts_pipeline]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[bts_pipeline]
GO

CREATE TABLE [dbo].[bts_component] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [nvarchar] (64) NOT NULL ,
	[Version] [nvarchar] (10) NOT NULL ,
	[ClsID] [uniqueidentifier] NULL,
	[TypeName] [nvarchar] (256) NULL,
	[AssemblyPath] [nvarchar] (256) NULL,
	[Description] [nvarchar] (256) NULL ,
	[CustomData] [image] NULL ,
   CONSTRAINT bts_component_pk   primary key(Id),
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GRANT SELECT ON [dbo].[bts_component] TO BTS_HOST_USERS
GO

CREATE TABLE [dbo].[bts_stage_config] (
	[StageID] [int] NOT NULL ,
	[CompID] [int] NOT NULL ,
	[Sequence] [smallint] NOT NULL 
) ON [PRIMARY]

GRANT SELECT ON [dbo].[bts_stage_config] TO BTS_HOST_USERS
GO

CREATE TABLE [dbo].[bts_pipeline_stage] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[Category] [uniqueidentifier] NOT NULL ,
	[Name] [nvarchar] (64) NOT NULL ,
	[ExecOptions] [int] NOT NULL,
   CONSTRAINT bts_pipeline_stage_pk   primary key(Id),
) ON [PRIMARY]

GRANT SELECT ON [dbo].[bts_pipeline_stage] TO BTS_HOST_USERS
GO

CREATE TABLE [dbo].[bts_pipeline] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[PipelineID] [uniqueidentifier] NOT NULL UNIQUE,
	[Category] [smallint] NOT NULL,
	[Name] [nvarchar] (256) NOT NULL,
	[FullyQualifiedName] [nvarchar] (256) NOT NULL UNIQUE,
	[IsStreaming] [smallint] NOT NULL,
	[nAssemblyID] [int] NOT NULL,
	[nvcDescription] [nvarchar] (1024) NULL,
	[Release] [int] NOT NULL,
   CONSTRAINT bts_pipeline_pk primary key(Id),
) ON [PRIMARY]

GRANT SELECT ON [dbo].[bts_pipeline] TO BTS_HOST_USERS
GRANT SELECT, UPDATE ON [dbo].[bts_pipeline] TO BTS_ADMIN_USERS
GRANT SELECT ON [dbo].[bts_pipeline] TO BTS_OPERATORS
GO

CREATE TABLE [dbo].[bts_pipeline_config] (
	[PipelineID] [int] NOT NULL ,
	[StageID] [int] NOT NULL ,
	[Sequence] [smallint] NOT NULL 
) ON [PRIMARY]

GRANT SELECT ON [dbo].[bts_pipeline_config] TO BTS_HOST_USERS
GO


ALTER TABLE [dbo].[bts_pipeline] WITH NOCHECK ADD 
	CONSTRAINT [DF_bts_pieline_isstreaming] DEFAULT (0) FOR [IsStreaming]
GO

