-- Overview
-- There are three distinct sections
--  0. Run prior Service Pack script (TODO)
--  1. Creating new tables/indexes that are new or not present in BTS 2004
--  2. Altering tables that have been modified in some way (columns renamed, etc)
--    In addition for these class of tables, we copy the data (if possible).
--    If it's not possible to migrate in SQL, we create sprocs we will invoke
--    from migration code (which we will later cleanup).
--  3. Deleting and cleaning up
--

-- ======================================================
-- Create new tables/indexes that didn't exist in BTS 2004
--
-- [bam_Metadata_Properties]
-- CI_ScopeAndPropName (clustered index for [bam_Metadata_Properties]
-- [bam_Metadata_ReferencedDatabases]
-- CIndex_ServerAndDatabaseNames (clustered index for [bam_Metadata_ReferencedDatabases] 
-- [bam_Metadata_Cubes]
-- CIndex_CubeName (clustered index for bam_Metadata_Cubes)
-- CIndex_CubeNameAndLastStartTime (clustered index for bam_Metadata_AnalysisTasks)
-- [bam_Metadata_TrackingProfiles] 
-- CIndex_ActivityNameAndVersion (clustered index for [bam_Metadata_TrackingProfiles])
-- [bam_Metadata_Annotations]
-- CIndex_ActivityNameAndVersion 
-- NCIndex_Component 
-- ======================================================
CREATE TABLE [dbo].[bam_Metadata_DatabaseVersion]
(
	MajorVersion	SMALLINT,
	MinorVersion	SMALLINT,
	BuildVersion	SMALLINT,
	RevisionVersion	SMALLINT,
	SKU             SMALLINT    -- 1: PE, 2: SE, 3: EE
)
GO

CREATE TABLE [dbo].[bam_Metadata_Properties]
(
	Scope       		SYSNAME,
	PropertyName		SYSNAME,
	PropertyValue       NTEXT
)
CREATE CLUSTERED INDEX CI_ScopeAndPropName ON dbo.bam_Metadata_Properties(Scope, PropertyName)
GO

CREATE TABLE [dbo].[bam_Metadata_ReferencedDatabases]
(
	ServerName      SYSNAME   NOT NULL,
	DatabaseName    SYSNAME   NOT NULL,
	AddedBy         NVARCHAR(256),
	AddedTime       DATETIME
)
CREATE CLUSTERED INDEX CIndex_ServerAndDatabaseNames ON dbo.bam_Metadata_ReferencedDatabases(ServerName, DatabaseName)
GO

CREATE TABLE [dbo].[bam_Metadata_Operations]
(
	OperationID 		    BIGINT IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
	UserLogin			    SYSNAME NOT NULL,
	OperationType		    NVARCHAR(10) NOT NULL,	-- Deploy, Remove or Update
	OriginalDefinitionXml   NTEXT,
	WorkingDefinitionXml    NTEXT,
	BamConfigurationXml	    NTEXT NOT NULL,
	BamDefinitionFileName	NVARCHAR(1024),
	StartTime			    DATETIME NOT NULL,
	EndTime				    DATETIME,               -- Non-null value indicates operation success
	BamManagerFileVersion	NVARCHAR(20)            -- BAM Management file version
)
GO

CREATE TABLE [dbo].[bam_Metadata_OperationEvents]
(
	OperationID	    BIGINT,			-- foreign key to bam_Metadata_Operations table
	ArtifactType	NVARCHAR(30),   -- Activity, View, Alert etc.
	StartTime		DATETIME NOT NULL,		
	EndTime			DATETIME		
)
CREATE CLUSTERED INDEX CIndex_OperationIDAndArtifactType ON dbo.bam_Metadata_OperationEvents(OperationID, ArtifactType)
GO

CREATE TABLE [dbo].[bam_Metadata_Cubes]
(
	CubeName    	    SYSNAME,
	ActivityViewName	SYSNAME,
	DefinitionXml       NTEXT,
	CreateOlapCube      BIT
)
CREATE CLUSTERED INDEX CIndex_CubeName ON dbo.bam_Metadata_Cubes(CubeName)
GO
CREATE TABLE [dbo].[bam_Metadata_AnalysisTasks]
(
	CubeName		SYSNAME NOT NULL,
	MinRecordID		BIGINT,
	MaxRecordID		BIGINT,
	LastStartTime	DATETIME DEFAULT(NULL),
	LastEndTime		DATETIME DEFAULT(NULL)
)
CREATE CLUSTERED INDEX CIndex_CubeNameAndLastStartTime ON dbo.bam_Metadata_AnalysisTasks(CubeName, LastStartTime)
GO

CREATE TABLE [dbo].[bam_Metadata_TrackingProfiles] (
    nId                 INT NOT NULL IDENTITY(1,1) ,
    ActivityName        SYSNAME NOT NULL ,
    VersionId           UNIQUEIDENTIFIER NOT NULL ,
    ProfileXml          NTEXT NULL
) ON [PRIMARY]
GO

CREATE UNIQUE CLUSTERED INDEX CIndex_ActivityNameAndVersion ON [dbo].[bam_Metadata_TrackingProfiles] (ActivityName, VersionId)
GO

CREATE TABLE [dbo].[bam_Metadata_Annotations]
(
    ActivityName		SYSNAME NOT NULL,
    Version			NVARCHAR(128) NOT NULL,
    Subject			NVARCHAR(256) NOT NULL,
    Component			NVARCHAR(256) NOT NULL,
    TrackPointId                INT NOT NULL,
    AnnotationXml		NTEXT NULL
)
CREATE CLUSTERED INDEX CIndex_ActivityNameAndVersion ON [dbo].[bam_Metadata_Annotations] (ActivityName, Version)
GO

CREATE NONCLUSTERED INDEX NCIndex_Component ON [dbo].[bam_Metadata_Annotations] (Component)
GO

-- ======================================================
-- Migrate [bam_Metadata_Configuration]
-- ======================================================
ALTER TABLE [dbo].[bam_Metadata_Configuration]
  ADD ConfigurationXml	NTEXT,
      LastUpdated	DATETIME,
      LastUpdatedBy	NVARCHAR(256)
GO

UPDATE [dbo].[bam_Metadata_Configuration]
SET ConfigurationXml=BamConfigurationXml, LastUpdated=CURRENT_TIMESTAMP, LastUpdatedBy=SYSTEM_USER 
-- ======================================================
-- bugbug: Test code
-- select * from [bam_Metadata_Configuration]
-- ======================================================
GO

ALTER TABLE [dbo].[bam_Metadata_Configuration]
  DROP COLUMN BamConfigurationXml
GO

-- ======================================================
-- Migrate [bam_Metadata_Transactions] => [bam_Metadata_Operations]
-- ======================================================
-- SET IDENTITY_INSERT to ON.
SET IDENTITY_INSERT [bam_Metadata_Operations] ON

INSERT  [bam_Metadata_Operations] (OperationID, UserLogin, OperationType, OriginalDefinitionXml, WorkingDefinitionXml,
      BamDefinitionFileName, BamConfigurationXml, StartTime, EndTime, BamManagerFileVersion)
SELECT CAST(TransactionID as BIGINT) as OperationID, UserName as UserLogin, OpType as OperationType, 
       BamDefinitionXml as OriginalDefinitionXml, ActionableDefXml as WorkingDefinitionXml, 
       BamDefFileName as BamDefinitionFileName, BamConfigurationXml as BamConfigurationXml, 
       StartTime as StartTime, EndTime as EndTime, AssemblyVersion as BamManagerFileVersion
 FROM [bam_Metadata_Transactions]

SET IDENTITY_INSERT [bam_Metadata_Operations] OFF

-- ======================================================
-- Migrate [bam_Metadata_TransactionEvents] => [bam_Metadata_OperationEvents]
-- ======================================================
INSERT  [bam_Metadata_OperationEvents] (OperationID, ArtifactType, StartTime, EndTime)
SELECT CAST(TransactionID as BIGINT) as OperationID, BamUnit as ArtifactType, 
       StartTime as StartTime, EndTime as EndTime
 FROM [bam_Metadata_TransactionEvents]


-- ======================================================
-- Migrate [bam_Metadata_Activities]
-- ======================================================
-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_ActivitiesTemp] FROM [dbo].[bam_Metadata_Activities] 
GO
DROP TABLE [dbo].[bam_Metadata_Activities]
GO
CREATE TABLE [dbo].[bam_Metadata_Activities]
( 
 ActivityName   SYSNAME PRIMARY KEY CLUSTERED,
 DefinitionXml         NTEXT,
 OnlineWindowTimeUnit CHAR(10)
     CHECK (OnlineWindowTimeUnit IN ('MONTH', 'DAY', 'HOUR', 'MINUTE')),
 OnlineWindowTimeLength INT
)
GO
INSERT  [bam_Metadata_Activities] (ActivityName, DefinitionXml, OnlineWindowTimeUnit, OnlineWindowTimeLength)
SELECT ActivityName, ActivityDefinitionXml as DefinitionXml, OnlineWindowTimeUnit, OnlineWindowTimeLength
 FROM [bam_Metadata_ActivitiesTemp]
GO
DROP TABLE [dbo].[bam_Metadata_ActivitiesTemp]
GO
-- ======================================================
-- Migrate [bam_Metadata_CustomIndexes]
-- ======================================================
-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_CustomIndexesTemp] FROM [dbo].[bam_Metadata_CustomIndexes] 
GO
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'PK_bam_Metadata_CustomIndexes')
  DROP INDEX [bam_Metadata_CustomIndexes].[PK_bam_Metadata_CustomIndexes]
GO
DROP TABLE [dbo].[bam_Metadata_CustomIndexes]
GO
CREATE TABLE [dbo].[bam_Metadata_CustomIndexes]
(
 ActivityName    SYSNAME,
 IndexName       SYSNAME,
 ColumnsList     NVARCHAR(3000)
)
CREATE CLUSTERED INDEX CIndex_ActivityAndIndexName ON dbo.bam_Metadata_CustomIndexes(ActivityName, IndexName)
GO
INSERT  [bam_Metadata_CustomIndexes] (ActivityName, IndexName, ColumnsList)
SELECT ActivityName, IndexName, ColumnsList
 FROM [bam_Metadata_CustomIndexesTemp]
GO
DROP TABLE [dbo].[bam_Metadata_CustomIndexesTemp]
GO
-- ======================================================
-- Migrate [bam_Metadata_Partitions]
-- ======================================================
-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_PartitionsTemp] FROM [dbo].[bam_Metadata_Partitions]
GO
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'PK_bam_Partitions')
  DROP INDEX [bam_Metadata_Partitions].[PK_bam_Partitions]
GO
DROP TABLE [dbo].[bam_Metadata_Partitions]
GO
CREATE TABLE [dbo].[bam_Metadata_Partitions]
(
 ActivityName  SYSNAME,
 InstancesTable  SYSNAME,
 RelationshipsTable SYSNAME,
 CreationTime  DATETIME, -- The time partition is spawned
 MinRecordID   BIGINT,
 MaxRecordID   BIGINT,
 ArchivingInProgress BIT DEFAULT(0),
 ArchivedTime  DATETIME NULL DEFAULT(NULL)
)
CREATE CLUSTERED INDEX CIndex_ActivityAndInstanceTableName ON dbo.bam_Metadata_Partitions(ActivityName, InstancesTable)
GO
INSERT  [bam_Metadata_Partitions] (ActivityName, InstancesTable, RelationshipsTable, CreationTime, MaxRecordID,
 ArchivingInProgress, ArchivedTime)
SELECT ActivityName, InstancesTable, RelationshipsTable,CreationTime, MaxRecordID,
 ArchivingInProgress, ArchivedTime
 FROM [bam_Metadata_PartitionsTemp]
GO
DROP TABLE [dbo].[bam_Metadata_PartitionsTemp]
GO

-- ======================================================
-- Migrate [bam_Metadata_AnalysisTasks] (NEW) from [bam_Metadata_DataAnalysisTasks] (OLD)
-- ======================================================
INSERT  [bam_Metadata_AnalysisTasks] (CubeName, MinRecordID, MaxRecordID, LastStartTime, LastEndTime)
SELECT A.CubeName, D.MinRecordID, D.MaxRecordID, D.LastStartTime, D.LastEndTime
 FROM [bam_Metadata_ActivityViews] AS A, [bam_Metadata_DataAnalysisTasks] AS D  WHERE
 (A.ViewName=D.ViewName AND A.ActivityName=D.ActivityName)
GO

-- ======================================================
-- Migrate [bam_Metadata_Views] 
-- ======================================================

-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_ViewsTemp] FROM [dbo].[bam_Metadata_Views] 
GO
DROP TABLE [dbo].[bam_Metadata_Views]
GO
CREATE TABLE [dbo].[bam_Metadata_Views]
(
 ViewName  SYSNAME PRIMARY KEY CLUSTERED,
 ViewID   SYSNAME,
 OperationID  INT, -- Foreign key to bam_Metadata_Operations table
 DefinitionXml NTEXT
)
GO
INSERT  [bam_Metadata_Views] (ViewName, ViewID, OperationID, DefinitionXml)
SELECT ViewName, '1', TransactionID, ViewDefinitionXml
 FROM [bam_Metadata_ViewsTemp]
GO
DROP TABLE [dbo].[bam_Metadata_ViewsTemp]
GO


-- ======================================================
-- Create [bam_Metadata_SetConfigurationXml] to for migration
-- ======================================================

CREATE PROCEDURE [dbo].[bam_Metadata_SetConfigurationXml]
(
	@configXml	NTEXT,
    @loginName  NVARCHAR(256)
)
AS
	INSERT [bam_Metadata_Configuration] (ConfigurationXml, LastUpdated, LastUpdatedBy) 
    VALUES (@configxml, GETUTCDATE(), @loginName)
GO

-- ======================================================
-- Create [bam_Metadata_UpsertProperty] to for migration
-- ======================================================

CREATE PROCEDURE [dbo].[bam_Metadata_UpsertProperty]
(
	@propertyName			SYSNAME,
	@propertyValue			ntext,
	@scope      			SYSNAME = N'Global'
)
AS
    BEGIN TRAN
        SELECT PropertyName FROM dbo.bam_Metadata_Properties
        WHERE (Scope = @scope AND PropertyName = @propertyName)
        
        IF @@ROWCOUNT = 0	
            INSERT dbo.bam_Metadata_Properties (Scope, PropertyName, PropertyValue)
            VALUES (@scope, @propertyName, @propertyValue)    
        ELSE
            UPDATE dbo.bam_Metadata_Properties
            SET PropertyValue = @propertyValue
            WHERE (Scope = @scope AND PropertyName = @propertyName)
	COMMIT TRAN           
GO


-- ======================================================
-- Migrate [bam_Metadata_RealTimeAggregations]
-- ======================================================
-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_RealTimeAggregationsTemp] FROM [dbo].[bam_Metadata_RealTimeAggregations]
GO
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'PK_bam_ActivityViews')
  DROP INDEX [bam_Metadata_RealTimeAggregations].[PK_bam_Metadata_RealTimeAggregations ]
GO
DROP TABLE [dbo].[bam_Metadata_RealTimeAggregations]
GO
CREATE TABLE [dbo].[bam_Metadata_RealTimeAggregations]
(
 CubeName   SYSNAME NOT NULL,
 RTAName    SYSNAME NOT NULL,
 RTAWindow   INT,
 Timeslice   INT,
 ConnectionString NVARCHAR(3600)
)
CREATE CLUSTERED INDEX CIndex_CubeAndRtaName ON [dbo].[bam_Metadata_RealTimeAggregations] (CubeName, RTAName)
GO
DROP TABLE [dbo].[bam_Metadata_RealTimeAggregationsTemp]
GO

-- ======================================================
-- Migrate [bam_Metadata_ActivityViews]
-- ======================================================
-- Clone the table
SELECT * INTO [dbo].[bam_Metadata_ActivityViewsTemp] FROM [dbo].[bam_Metadata_ActivityViews]
GO
IF EXISTS (SELECT name FROM sysindexes
         WHERE name = 'PK_bam_ActivityViews')
  DROP INDEX [bam_Metadata_ActivityViews].[PK_bam_ActivityViews]
GO
DROP TABLE [dbo].[bam_Metadata_ActivityViews]
GO
CREATE TABLE [dbo].[bam_Metadata_ActivityViews]
(
 ActivityViewName    SYSNAME,
 ViewName      SYSNAME,
 ActivityName     SYSNAME
)
CREATE CLUSTERED INDEX NCIndex_ViewAndActivityNames ON dbo.bam_Metadata_ActivityViews(ViewName, ActivityName)
GO
INSERT  [bam_Metadata_ActivityViews] (ActivityViewName, ViewName, ActivityName)
SELECT ActivityViewObjectName, ViewName, ActivityName
 FROM [bam_Metadata_ActivityViewsTemp]
GO
DROP TABLE [dbo].[bam_Metadata_ActivityViewsTemp]
GO
-- ======================================================
-- Cleanup tables we don't need
-- ======================================================
DROP TABLE [dbo].[bam_Metadata_ConfigVersion]
DROP TABLE [dbo].[bam_Metadata_DataAnalysisTasks]
DROP TABLE [dbo].[bam_Metadata_TransactionEvents]
DROP TABLE [dbo].[bam_Metadata_Transactions]
DROP TABLE [dbo].[bam_Metadata_Watermark]

-- BTS 2004 metadata sprocs
EXEC sp_stored_procedures 'bam_Metadata_ManageSecurity', 'dbo'
IF @@ROWCOUNT > 0 	DROP PROCEDURE [dbo].[bam_Metadata_ManageSecurity]

EXEC sp_stored_procedures 'bam_Metadata_GetViewPermissions', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetViewPermissions]

EXEC sp_stored_procedures 'bam_Metadata_GetViewDefinitionXml', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetViewDefinitionXml]

EXEC sp_stored_procedures 'bam_Metadata_GetRTAMutex', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetRTAMutex]

EXEC sp_stored_procedures 'bam_Metadata_GetRTAConnectionString', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetRTAConnectionString]

EXEC sp_stored_procedures 'bam_Metadata_BeginAnalysis', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_BeginAnalysis]

EXEC sp_stored_procedures 'bam_Metadata_EndAnalysis', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_EndAnalysis]

EXEC sp_stored_procedures 'bam_Metadata_CreatePartitionIndexes', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_CreatePartitionIndexes]

EXEC sp_stored_procedures 'bam_Metadata_RegenerateViews', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_RegenerateViews]

EXEC sp_stored_procedures 'bam_Metadata_RecreateRtaTriggerOnCompletedTable', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_RecreateRtaTriggerOnCompletedTable]

EXEC sp_stored_procedures 'bam_Metadata_SpawnPartition', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_SpawnPartition]

EXEC sp_stored_procedures 'bam_Metadata_BeginArchiving', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_BeginArchiving]

EXEC sp_stored_procedures 'bam_Metadata_EndArchiving', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_EndArchiving]

EXEC sp_stored_procedures 'bam_Metadata_BeginTransaction', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_BeginTransaction]

EXEC sp_stored_procedures 'bam_Metadata_EndTransaction', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_EndTransaction]

EXEC sp_stored_procedures 'bam_Metadata_BeginTransactionEvent', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_BeginTransactionEvent]

EXEC sp_stored_procedures 'bam_Metadata_EndTransactionEvent', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_EndTransactionEvent]

EXEC sp_stored_procedures 'bam_Metadata_GetTransactionEvents', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetTransactionEvents]

EXEC sp_stored_procedures 'bam_Metadata_GetBamConfigurationXml', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetBamConfigurationXml]

EXEC sp_stored_procedures 'bam_Metadata_SetBamConfigurationXml', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_SetBamConfigurationXml]

EXEC sp_stored_procedures 'bam_Metadata_GetRelatedOrchestrations', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetRelatedOrchestrations]
GO

-----------------------------
-- Database versioning
-----------------------------
EXEC sp_stored_procedures 'bam_Metadata_SetDatabaseVersion', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_SetDatabaseVersion]
GO

CREATE PROCEDURE [dbo].[bam_Metadata_SetDatabaseVersion]
(
	@majorVersion			SMALLINT,
	@minorVersion			SMALLINT,
	@buildVersion			SMALLINT,
	@revisionVersion		SMALLINT,
	@SKU			        SMALLINT
)
AS
    BEGIN TRAN
        TRUNCATE TABLE dbo.bam_Metadata_DatabaseVersion
        
        INSERT dbo.bam_Metadata_DatabaseVersion (MajorVersion, MinorVersion, BuildVersion, RevisionVersion, SKU)
        VALUES (@majorVersion, @minorVersion, @buildVersion, @revisionVersion, @SKU)
    COMMIT TRAN
GO


EXEC sp_stored_procedures 'bam_Metadata_GetDatabaseVersion', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_GetDatabaseVersion]
GO

CREATE PROCEDURE [dbo].[bam_Metadata_GetDatabaseVersion]
AS
        SELECT TOP 1 * FROM dbo.bam_Metadata_DatabaseVersion 
GO


EXEC sp_stored_procedures 'bam_Metadata_CheckSKU', 'dbo'
IF @@ROWCOUNT > 0	DROP PROCEDURE [dbo].[bam_Metadata_CheckSKU]
GO

CREATE PROCEDURE [dbo].[bam_Metadata_CheckSKU]
(
	@runTimeSKU     SMALLINT
)
AS
    /*  
        Licensing restriction:
        Only following combinations are allowed, all other throw error:
        1) runtimeSku is PE, database created by EE
        2) runtimeSku is SE, database created by SE or EE
        2) runtimeSku is EE, database created by SE or EE.
     */

    -- Retrieve database SKU
	DECLARE @@databaseSKU SMALLINT
	SELECT @@databaseSKU = SKU FROM [dbo].[bam_Metadata_DatabaseVersion]
    
    IF NOT(@runTimeSKU = 1 AND @@databaseSKU = 3)
       AND NOT (@runTimeSKU = 2 AND (@@databaseSKU = 2 OR @@databaseSKU = 3))
       AND NOT (@runTimeSKU = 3 AND (@@databaseSKU = 2 OR @@databaseSKU = 3))   
	BEGIN
		RAISERROR (N'<xsl:value-of select="Message[@ID=''DbVersion_LicencingViolation'']"/>', 16, 2)
		RETURN 255
	END
GO
