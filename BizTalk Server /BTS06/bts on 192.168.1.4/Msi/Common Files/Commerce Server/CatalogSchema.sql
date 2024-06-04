/************************************************************/
/*
Microsoft Corp.
Commerce Server 4.0
March 27, 1999

CatalogSchema.SQL

	Defines SQL tables used to manage:
			CS Data Warehouse Schema Definitions
			BizData Schema Definitions (profiles, siteTerms, content).

Updates:
		4/6/99	Sync'd w/ catalogSchema_CCtlgObj.txt (generated oledb output)
		11/16/99  (donniep)  Added BDAO stored-procs.
		11/23/99  (donniep)  Added sp_GetProfileDomains for BDAO.

***************************************************************/


/****  DROP TABLES ******/
if exists (select * from sysobjects where id = object_id(N'CommerceServerCatalogs') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table CommerceServerCatalogs
GO
if exists (select * from sysobjects where id = object_id(N'TypeDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table TypeDef
GO
if exists (select * from sysobjects where id = object_id(N'LinkTableInfo') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table LinkTableInfo
GO
if exists (select * from sysobjects where id = object_id(N'ValTableInfo') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ValTableInfo
GO
if exists (select * from sysobjects where id = object_id(N'ColDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ColDef
GO
if exists (select * from sysobjects where id = object_id(N'TableDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table TableDef
GO
if exists (select * from sysobjects where id = object_id(N'ParitionPolicyDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ParitionPolicyDef
GO
if exists (select * from sysobjects where id = object_id(N'SourceDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table SourceDef
GO
if exists (select * from sysobjects where id = object_id(N'IndexDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table IndexDef
GO
if exists (select * from sysobjects where id = object_id(N'IndexMem') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table IndexMem
GO
if exists (select * from sysobjects where id = object_id(N'ViewMem') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ViewMem
GO
if exists (select * from sysobjects where id = object_id(N'GroupMem') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table GroupMem
GO
if exists (select * from sysobjects where id = object_id(N'ClassDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ClassDef
GO
if exists (select * from sysobjects where id = object_id(N'MemberDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table MemberDef
GO
if exists (select * from sysobjects where id = object_id(N'ViewDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ViewDef
GO
if exists (select * from sysobjects where id = object_id(N'RelDef') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table RelDef
GO
if exists (select * from sysobjects where id = object_id(N'ClsAttrib') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table ClsAttrib
GO
if exists (select * from sysobjects where id = object_id(N'MemAttrib') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table MemAttrib
GO
if exists (select * from sysobjects where id = object_id(N'SourceAttrib') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table SourceAttrib
GO


/****** CREATE TABLES *****/

/* Create new table -- CommerceServerCatalogs */
CREATE TABLE CommerceServerCatalogs
(
   [CatalogID]                [int]        NOT NULL                  /* CCtlgObj::_dwPersistentID                  */,
   [CatalogName]              [nvarchar]   (64) NULL                /* CCtlgObj::_pwszCatalogName                 */,
   [CreatedTime]              [datetime]   NULL DEFAULT GetDate()    /* CCtlgObj::_CreatedTime                     */,
   [ModifiedTime]             [datetime]   NULL DEFAULT GetDate()    /* CCtlgObj::_ModifiedTime                    */,
   [MajorVersion]             [int]        NULL DEFAULT 0                     /* CCtlgObj::_dwMajorVersion                  */,
   [MinorVersion]             [int]        NULL DEFAULT 0                     /* CCtlgObj::_dwMinorVersion                  */,
   [Status]					  [int]        NULL DEFAULT 0,
   [DisplayName]              [nvarchar]   (64) NULL                /* CCtlgObj::_pwszDisplayName                 */,
   [Description]              [nvarchar]   (64) NULL                /* CCtlgObj::_pwszDescription                 */,
   [StrTblName]               [nvarchar]   (64) NULL                /* CMbCatalog::_wszStrTblName                 */,
   [CtlgHistoryTblName]       [nvarchar]   (64) NULL                /* CMbCatalog::_wszCtlgHistoryTblName         */,
   [SourceDefTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszSourceDefTblName           */,
   [TypeDefTblName]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszTypeDefTblName             */,
   [ClsDefTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszClsDefTblName              */,
   [MemDefTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszMemDefTblName              */,
   [GroupMemTblName]          [nvarchar]   (64) NULL                /* CMbCatalog::_wszGroupMemTblName            */,
   [RelDefTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszRelDefTblName              */,
   [RelMemTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszRelMemTblName              */,
   [TblDefTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszTblDefTblName              */,
   [ColDefTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszColDefTblName              */,
   [ClsKeyDefTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszClsKeyDefTblName           */,
   [KeyMemTblName]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszKeyMemTblName              */,
   [IndexDefTblName]          [nvarchar]   (64) NULL                /* CMbCatalog::_wszIndexDefTblName            */,
   [IndexMemTblName]          [nvarchar]   (64) NULL                /* CMbCatalog::_wszIndexMemTblName            */,
   [PartitionDefTblName]      [nvarchar]   (64) NULL                /* CMbCatalog::_wszPartitionDefTblName        */,
   [PartitionPolicyDefTblName][nvarchar]   (64) NULL                /* CMbCatalog::_wszPartitionPolicyDefTblName  */,
   [IdentityCounterTblName]   [nvarchar]   (64) NULL                /* CMbCatalog::_wszIdentityCounterTblName     */,
   [ViewDefTblName]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszViewDefTblName             */,
   [ViewMemTblName]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszViewMemTblName             */,
   [AggrDefTblName]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszAggrDefTblName             */,
   [LinkTblInfoTblName]       [nvarchar]   (64) NULL                /* CMbCatalog::_wszLinkTblInfoTblName         */,
   [ValTblInfoTblName]        [nvarchar]   (64) NULL                /* CMbCatalog::_wszValTblInfoTblName          */,
   [ClsAttribTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszClsAttribTblName           */,
   [MemAttribTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszMemAttribTblName           */,
   [RelAttribTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszRelAttribTblName           */,
   [SrcAttribTblName]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszSrcAttribTblName           */,
   [OtherDefAttribsTblName]   [nvarchar]   (64) NULL                /* CMbCatalog::_wszOtherDefAttribsTblName     */,
   [SynthRelDefPrefix]        [nvarchar]   (64) NULL                /* CMbCatalog::_wszSynthRelDefPrefix          */,
   [ReferenceSuffix]          [nvarchar]   (64) NULL                /* CMbCatalog::_wszReferenceSuffix            */,
   [MemNmPrefix]              [nvarchar]   (64) NULL                /* CMbCatalog::_wszMemNmPrefix                */,
   [ColNmPrefix]              [nvarchar]   (64) NULL                /* CMbCatalog::_wszColNmPrefix                */,
   [ScopePrefix]              [nvarchar]   (64) NULL                /* CMbCatalog::_wszScopePrefix                */,
   [ClsNmPrefix]              [nvarchar]   (64) NULL                /* CMbCatalog::_wszClsNmPrefix                */,
   [DfltTblPrefix]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszDfltTblPrefix              */,
   [ClassKeySuffix]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszClassKeySuffix             */,

   [CategoryTbl]          	  [nvarchar]   (64) NULL                /* CMbCatalog::_wszCategoryTblName            */,
   [CalcTermTbl]              [nvarchar]   (64) NULL                /* CMbCatalog::_wszTermTblName                */,
   [CalcTermsTbl]             [nvarchar]   (64) NULL                /* CMbCatalog::_wszTermsTblName               */,
   [CalcFilterTbl]            [nvarchar]   (64) NULL                /* CMbCatalog::_wszFilterTblName              */,
   [CalcCalculatedMeasureTbl] [nvarchar]   (64) NULL                /* CMbCatalog::_wszCalculatedMeasureTblName   */,
   [CalcNonCalculatedMeasureTbl][nvarchar] (64) NULL                /* CMbCatalog::_wszNonCalculatedMeasureTblName */,
   [CalcMeasureTbl]           [nvarchar]   (64) NULL                /* CMbCatalog::_wszMeasureTblName             */,
   [CalcPropertyTbl]          [nvarchar]   (64) NULL                /* CMbCatalog::_wszPropertyTblName            */,
   [CalcDimensionTbl]         [nvarchar]   (64) NULL                /* CMbCatalog::_wszDimensionTblName           */,
   [CalcCalculationTbl]       [nvarchar]   (64) NULL                /* CMbCatalog::_wszCalculationTblName         */,
   [ReportTbl]                [nvarchar]   (64) NULL		    ,
   [ReportCalcTbl]            [nvarchar]   (64) NULL                ,
   [SiteReportTbl]            [nvarchar]   (64) NULL,
   [DestTimeZoneID]                [int]        NULL                      /* CMbCatalog::_DestTimeZoneID                */,
   [StartDayOfWeek]                [smallint]   NULL                      /* CMbCatalog::_StartDayOfWeek                */
)
GO

/* ClassDef - defines object classes (aka. logical profiles and physical class defs). */       
CREATE TABLE ClassDef /** UK= catalogName/className **/
(
   [ClassDefID][int] NOT NULL ,					/** unique class ID ***/
   [ClassDefName][nvarchar] (128) NOT NULL,		/** unique class name (within catalog) **/
   [CatalogName][nvarchar] (128) NOT NULL,		/** ID ref **/
   [CatalogID] int NOT NULL,					/** Name ref **/
   [DisplayName][nvarchar] (128) NULL,			/** UI display name **/
   [Description][nvarchar] (128) NULL,			/** site description **/
   [PartitionName][nvarchar] (128) NULL,		/** ref to partition/table (1) only for upm **/
   [PartitionID] [int] NULL,					/** ID ref - associate data source (only if class IsPersistent) **/
   [SourceDefName][nvarchar] (128) NULL,			/** Name ref --> Need TableRef?? **/
   [SourceID] [int] NULL,						/** ID ref **/
   [ClassGUID][binary] (16) NULL ,
   [IdSize][int] NULL DEFAULT 4,
   [IsActive][tinyint] NULL DEFAULT 1,			/** Disables class from usage **/
   [IsPersistent][tinyint] NULL DEFAULT 1,		/** If associated with DataSource/Table **/
   [IsReadOnly][tinyint] NULL DEFAULT 0,
   [IsAbstract][tinyint] NULL DEFAULT 0,		/** If associated with DataSource/Table ***/
   [IsProfile][tinyint] NULL DEFAULT 1,			/** This class represents a complete profile **/
   [DefaultParentURL] [nvarchar] (128) NULL,	/** upm support **/
   [DefaultTableName] [nvarchar] (128) NULL,  	/** added New, UPM may not need this */
   [ClassType] [smallint]   NULL DEFAULT 0,     /* CMbClsDef::_wClsType                       */
   [BaseClassName] [nvarchar] (128) NULL,
   [InstExclusionExpr] [nvarchar] (128) NULL,
   [PartCriteriaExpr] [nvarchar] (128) NULL,
   [PartViewName] [nvarchar] (128) NULL,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate(),
   [MajorVersion][int] NULL,
   [MinorVersion][int] NULL,
   [GenerateTableDef]         [tinyint]    NULL,                      /* new */
   [GeneratePartitionDef]     [tinyint]    NULL,                      /* new */
   [GenerateIdentity]         [tinyint]    NULL,                      /* new */
   [GenerateKeyDef]           [tinyint]    NULL DEFAULT 1,            /* new */
   [Status]					  [int]        NULL DEFAULT 0,
   [IsUIDeleteEnabled]        [tinyint]    NULL DEFAULT 0,          /* CMbClsDef::_fIsUIDeleteEnabled             */
   [IsTransactioned]          [tinyint]    NULL DEFAULT 0,          /* CMbClsDef::_fIsTransactioned               */
)
GO

/* RelDef - defines class inheritance */
CREATE TABLE RelDef /** UK = CatalogName/RelDefName **/
(
   [RelDefID][int] NOT NULL ,					/** unique ID **/
   [RelDefName][nvarchar] (128) NOT NULL,		/** unique Name (within catalog) **/
   [CatalogID][int] NOT NULL,					/** id ref **/
   [CatalogName][nvarchar] (128) NOT NULL,		/** name ref **/
   [DisplayName][nvarchar] (128) NULL,			/** display  **/
   [Description][nvarchar] (128) NULL,			/** site descr **/
   [ChildClassID] [int] NULL,					/** child class ID ref **/
   [ParentClassID] [int] NULL,					/** parent class ID ref **/
   [ChildClassName][nvarchar] (128) NULL,		/** child class Name ref **/
   [ParentClassName][nvarchar] (128) NULL,		/** parent class Name ref **/
   [ParentClassKey][nvarchar] (128) NULL,		/** ref to keydef... identifies key used to relate classes */
   [RelType][smallint] NULL DEFAULT 4,			/* default to inheritance relationship */
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [Status]					  [int]        NULL DEFAULT 0,
   [RefMemName]               [nvarchar]   (128) NULL        /* CMbRelDef::_wszRefMemName                  */
)
GO
 
/* memberDefs - aka properties */  
CREATE TABLE MemberDef /** UK = catalogName/className/memberDefName **/
(
   [MemberDefID][int] NOT NULL ,				/** unique ID **/
   [MemberDefName][nvarchar] (128) NOT NULL,	/** unique Name **/
   [ClassDefID] [int] NOT NULL,					/** cls id ref **/
   [ClassDefName][nvarchar] (128) NOT NULL,		/** cls name ref **/
   [CatalogID] [int] NOT NULL,					/** cat id ref **/
   [CatalogName][nvarchar] (128) NULL,			/** cat name ref **/
   [DisplayName][nvarchar] (128) NULL,			/** display **/
   [Description][nvarchar] (128) NULL,			/** descr**/
   [IsRequired][tinyint] NULL DEFAULT 0,					/** IsRequired **/
   [IsActive][tinyint] NULL DEFAULT 0,					/** Enabled? **/
   [IsSearchable][tinyint] NULL DEFAULT 0,				/** IsIndexed/Searchable **/
   [IsTextSearchable][tinyint] NULL DEFAULT 0,
   [IsIdentityMember][tinyint] NULL DEFAULT 0,			
   [IsDfltNull][tinyint] NULL DEFAULT 0,
   [IsMultiValued][tinyint] NOT NULL DEFAULT 0,					/** isMv **/
   [IsPersistent][tinyint] NULL DEFAULT 1,					/** isPersistent **/
   [ValTableName][nvarchar] (128) NULL,			/** multival table name explain?? **/
   [ValColumnName][nvarchar] (128) NULL,		/** multival table column name **/
   [LinkTableName][nvarchar] (128) NULL,
   [ColumnID] [int] NULL,						/** column reference **/
   [ColumnName][nvarchar] (128) NULL,			/** column reference Need source/table/column?  **/
   [MemberDefFullName][nvarchar] (128) NULL,		/** ?? **/
   [DefaultValueAsStr][nvarchar] (128) NULL,
   [ExpressionStr][nvarchar] (128) NULL,
   [TypeID] [int] NOT NULL,						/** type id ref **/
   [TypeName][nvarchar] (128) NULL,				/** type name ref **/
   [RelationName][nvarchar] (128) NULL,    
   [ReferenceString] [nvarchar] (256) NULL ,	/** site term or profile reference **/
   [IsExported] [int] NULL DEFAULT 0,					/** Is exported by ExportTask **/
   [IsCached] [int] NULL  DEFAULT 1,						/** Is cached by PS **/
   [IsPrimaryKey] [int] NULL DEFAULT 0,					/** Is class PK member **/
   [IsUniqueKey] [int] NULL DEFAULT 0,					/** Is class UQ member **/
   [IsJoinKey] [int] NULL DEFAULT 0,						/** Is class JK member **/
   [IsGroup] [tinyint] NULL DEFAULT 0,						/* used by BizAdmin object only */
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [GenerateColumnDef]	[tinyint]	NULL,	/* New */
   [IsPrivate] [tinyint] NULL DEFAULT 0,
   [IsHashingKey] [tinyint] NULL DEFAULT 0,
   [IsEncrypted] [tinyint] NULL DEFAULT 0,
   [IsRDNAttribute] [tinyint] NULL DEFAULT 0,
   [IsHidden] [tinyint] NULL DEFAULT 0,
   [IsMeasure] [tinyint] NULL DEFAULT 0,
   [IsDimension] [tinyint] NULL DEFAULT 0,
   [UseHashInSearch]  [tinyint] NULL DEFAULT 0,
   [IdxFileGroupPolicy] [int] NULL DEFAULT 0,
   [IsReadOnly][tinyint] NULL DEFAULT 0,	/** is product or System Generated? **/
   [IsUpdatable][tinyint] NULL DEFAULT 1,	/** is product or System Generated? **/
   [Status]					  [int]        NULL DEFAULT 0,
   [OrdinalPosInClass]        [int]        NULL DEFAULT 0,                     /* CMbMemDef::_dwOrdinalPosInClass            */
   [IsDateDeleteMember]       [tinyint]    NULL DEFAULT 0                      /* CMbMemDef::_fIsDateDeleteMember            */
  )
GO

/* GroupMem - supports member groups */      
CREATE TABLE GroupMem
(
   [GroupMemID][int] NOT NULL ,				/** unique ID **/
   /* KrishnaU 4/4/99 -- need group id, i.e., member of type group */
   [GroupContainerMemID][int] NOT NULL ,	/** unique ID **/
   [GroupName][nvarchar] (128) NOT NULL,		/** unique name **/
   [CatalogID] [int] NULL,					/** cat ref id **/
   [CatalogName][nvarchar] (128) NULL,		/** cat ref name **/
   [ClassID] [int] NULL,					/** cls ref id **/
   [ClassDefName][nvarchar] (128) NULL,		/** cls ref name **/
   [GroupMemDefID][int] NOT NULL ,				/** unique member ID **/
   [GroupMemDefName][nvarchar] (128) NULL,		/** ref member name **/
   [DisplayName][nvarchar] (128) NULL,		/** display **/
   [Description][nvarchar] (128) NULL,		/** descr **/
   [OrdinalPosInGroup][smallint] NULL ,		/** group order num **/
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [Status]					  [int]        NULL DEFAULT 0,
) 
GO

/* SourceDef - defines physical data source (i.e. Database, Directory Service, etc..) */      
CREATE TABLE SourceDef
(
   [SourceID][int] NOT NULL ,				/** unique id **/
   [SourceName][nvarchar] (128) NOT NULL,	/** unique name **/
   [SourceGroupName][nvarchar] (128) NULL,
   [ADDomainName][nvarchar] (255) NULL,
   [IsDefault] int NULL,
   [DisplayName][nvarchar] (128) NULL,		/** disp **/
   [Description][nvarchar] (128) NULL,		/** descr **/
   [CatalogID][int] NOT NULL ,				/** cat id ref **/
   [CatalogName][nvarchar] (128) NOT NULL,	/** cat name ref **/
   [ConnStr][nvarchar] (2048) NULL,			/** connection string (DSN) **/
   [DoesSQLBatch][tinyint] NULL ,
   [DoesSQLInsert][tinyint] NULL ,
   [DoesSQLDelete][tinyint] NULL ,
   [DoesSQLUpdate][tinyint] NULL ,
   [DoesSQLStoredProc][tinyint] NULL ,
   [DoesTransactions][tinyint] NULL ,		/** enable transactions **/
   [DoesDistributedTrans][tinyint] NULL ,
   [MaxTblNameSize][int] NULL ,
   [MaxColNameSize][int] NULL ,
   [DBCodePage][int] NULL ,
   [Type][int] NULL ,						/** CSSQL=1, DIRECTORY=2, DSDB3=3 **/
   [ClsComponentID][int] NULL ,				/** optional if in connect string **/
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [Status]					  [int]        NULL DEFAULT 0,
)
GO

/* Fix for PSS Support Case Number: SRX050308605185               */
/* A clustered index must be added to the SourceDef table so that */
/* the order of items is consistent when importing a cataog that  */
/* uses partitioning.  Not doing so could result in incorrect     */
/* assignment of partitions when importing a catalog for an       */
/* existing SQL / AD physical data source                         */
ALTER TABLE SourceDef ADD 
   CONSTRAINT [PK_SourceDef] PRIMARY KEY CLUSTERED ([SourceName])



/* TableDef - defines physical data object (i.e. sql table, ds class, etc..) */
CREATE TABLE TableDef
(
   [TableDefID][int] NOT NULL ,				/** unique id **/
   [TableDefName][nvarchar] (128) NOT NULL,		/** database derived name **/
   [CatalogID][int] NOT NULL,					/** cat id ref **/
   [CatalogName][nvarchar] (128) NOT NULL,		/** cat name ref **/
   [DisplayName][nvarchar] (128) NULL,		/** disp **/
   [Description][nvarchar] (128) NULL,		/** descr **/

   /* KrishnaU 4/4/99 -- sources and table defs are tied together using partitions: we may have to delete these as they are no more supported by CatalogSchema */
   [SourceDefID][int] NULL,					/* src id ref -  bizadmin object hint only*/
   [SourceDefName] [nvarchar] (128) NULL,		/* src name ref */
   

   [NbrOfColDefs][int] NULL ,
   [IsWorkTable][tinyint] NULL ,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,

   /* Added by UPM (AnilK) */
   [ClassDefID] [int] NULL,
   [Status]					  [int]        NULL DEFAULT 0,
)
GO
      
CREATE TABLE ColDef
(
   [ColDefID][int] NOT NULL ,			/** unique id*/
   [ColDefName][nvarchar] (128) NOT NULL,	/** database derived name **/
   [CatalogID][int] NOT NULL,				/** cat id ref **/
   [CatalogName][nvarchar] (128) NOT NULL,	/** cat name ref **/

   /* KrishnaU 4/4/99 -- sources and col defs are tied together using partitions */
   /* [SourceDefID][int] NULL,					 src id ref - bizadmin object hint only*/
   /* [SourceDefName] [nvarchar] (128) NULL,		 src name ref */

   [TableID] [int] NOT NULL,				/** tbl id ref **/
   [TblDefName][nvarchar] (128) NOT NULL,	/** tbl name ref **/
   [DisplayName][nvarchar] (128) NULL,
   [Description][nvarchar] (128) NULL,
   [DbType][int] NULL ,					/** database type (oledb type enum) **/
   [DbTypeName][nvarchar] (128) NULL,	/** database type name i.e. DBTYPE_WCHAR*/
   [TypeDefName] [nvarchar] (128) NULL,	/** ref to typeDef table name */
   [MaxSize][int] NULL ,				/** db derived */

   [IsPrimary][tinyint] NULL DEFAULT 0, /** this is primary key in the source **/
   [IsMultiValued][tinyint] NULL DEFAULT 0,
   [IsIdentity][tinyint] NULL DEFAULT 0,
   [IsPersistent][tinyint] NULL DEFAULT 1,
   [IsDfltNull][tinyint] NULL DEFAULT 0,
   [IsNullAllowed][tinyint] NULL DEFAULT 1,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,

    /* Added by UPM (AnilK), Later we need to get the following column by Joining with MemberDef, 
       but this may not work when we add new Column ? */
   [MemberDefID] [int] NULL,
   [Status]					  [int]        NULL DEFAULT 0,
)
GO

/** SourceAttrib - support dsoProvider/data source connect options (user, pass, connect params, etc..) **/
CREATE TABLE SourceAttrib 
(
   [SourceAttribID][int] NOT NULL ,
   [CatalogName][nvarchar] (128) NOT NULL,
   [SourceName][nvarchar] (128) NOT NULL,
   [AttribName][nvarchar] (128) NOT NULL,
   [AttribType][nvarchar] (128) NULL,
   [DisplayName][nvarchar] (128) NULL,
   [Description][nvarchar] (128) NULL,
   [ValSTR][nvarchar] (255) NULL,
   [ValNum][int] NULL ,
   [ValDateTime][datetime] NULL ,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [Status]					  [int]        NULL DEFAULT 0,
)   
GO
       
CREATE TABLE ClsAttrib
(
   [ClassAttribID][int] NOT NULL ,
   [CatalogName][nvarchar] (128) NOT NULL,
   [ClassDefName][nvarchar] (128) NOT NULL,
   [AttribName][nvarchar] (128) NOT NULL,
   [AttribType][nvarchar] (128) NULL,
   [DisplayName][nvarchar] (128) NULL,
   [Description][nvarchar] (128) NULL,
   [ValSTR][nvarchar] (255) NULL,
   [ValNum][int] NULL ,
   [ValDateTime][datetime] NULL ,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,
   [Status]					  [int]        NULL DEFAULT 0,
)
GO
       
CREATE TABLE MemAttrib
(
   [MemberAttribID][int] NOT NULL ,
   [CatalogName][nvarchar] (128) NOT NULL,
   [ClassDefName][nvarchar] (128) NOT NULL,
   [MemberName][nvarchar] (128) NOT NULL,
   [AttribName][nvarchar] (128) NOT NULL,
   [DisplayName][nvarchar] (128) NULL,
   [Description][nvarchar] (128) NULL,
   [AttribType][nvarchar] (128) NOT NULL,
   [ValSTR][nvarchar] (255) NULL,
   [ValNum][int] NULL ,
   [ValDateTime][datetime] NULL ,
   [CreatedTime][datetime] NULL DEFAULT GetDate(),
   [ModifiedTime][datetime] NULL DEFAULT GetDate() ,
   [MajorVersion][int] NULL ,
   [MinorVersion][int] NULL ,

/* Added by UPM (AnilK), Later we need to get the following column by Joining with MemberDef, but this may not work when we add new Column ? */
   [MemberDefID] [int] NULL,
   [Status]					  [int]        NULL DEFAULT 0,
)
GO

 
/*********** PRE-POPULATE some TABLES ******************/

/*** CATALOG ***/
INSERT INTO CommerceServerCatalogs  
(CatalogID, CatalogName, ClsDefTblName, SourceDefTblName, TypeDefTblName, MemDefTblName, GroupMemTblName, RelDefTblName, RelMemTblName, TblDefTblName, ColDefTblName, ClsKeyDefTblName, KeyMemTblName, MemAttribTblName, MemNmPrefix, ColNmPrefix, PartitionDefTblName, IdentityCounterTblName, ClsAttribTblName, SrcAttribTblName, LinkTblInfoTblName, ValTblInfoTblName, ReportTbl, ReportCalcTbl, SiteReportTbl)
VALUES 
(1, 'Profile Definitions', 'ClassDef', 'SourceDef', 'TypeDef', 'MemberDef', 'GroupMem', 'RelDef', 'RelMemDef', 'TableDef', 'ColDef', 'ClsKeyDef', 'KeyMem', 'MemAttrib', 'MemNmPrefix', 'ColNmPrefix', 'PartitionDef', 'IdentityCounterTblName', 'ClsAttrib', 'SourceAttrib', 'LinkTableInfo', 'ValTableInfo', 'ReportTbl', 'ReportCalcTbl', 'SiteReportTbl')
GO

/*********************************/
/*********************************/
/****  BDAO STORED-PROCEDURES ****/
/*********************************/
/*********************************/


IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfileCatalog'))
    DROP PROCEDURE sp_DelProfileCatalog
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfileHelper'))
    DROP PROCEDURE sp_DelProfileHelper
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfile'))
    DROP PROCEDURE sp_DelProfile
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfileGroup'))
    DROP PROCEDURE sp_DelProfileGroup
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfileGroupHelper'))
    DROP PROCEDURE sp_DelProfileGroupHelper
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfileProperty'))
    DROP PROCEDURE sp_DelProfileProperty
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelProfilePropHelper'))
    DROP PROCEDURE sp_DelProfilePropHelper
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetDataSourceDepends'))
    DROP PROCEDURE sp_GetDataSourceDepends
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelDataSource'))
    DROP PROCEDURE sp_DelDataSource
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelDataObject'))
    DROP PROCEDURE sp_DelDataObject
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_DelDataMember'))
    DROP PROCEDURE sp_DelDataMember
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileProps'))
    DROP PROCEDURE sp_GetProfileProps
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileInfo'))
    DROP PROCEDURE sp_GetProfileInfo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetDataSourceInfo'))
    DROP PROCEDURE sp_GetDataSourceInfo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileCatalogs'))
    DROP PROCEDURE sp_GetProfileCatalogs
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileCatalogInfo'))
    DROP PROCEDURE sp_GetProfileCatalogInfo
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileMember'))
    DROP PROCEDURE sp_GetProfileMember
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileMemAttrs'))
    DROP PROCEDURE sp_GetProfileMemAttrs
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileDomains'))
    DROP PROCEDURE sp_GetProfileDomains
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileSources'))
    DROP PROCEDURE sp_GetProfileSources
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GetProfileCustomProps'))
    DROP PROCEDURE sp_GetProfileCustomProps
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GrantPermissionForRole'))
    DROP PROCEDURE sp_GrantPermissionForRole
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_CreateProfileSchemaRoles'))
    DROP PROCEDURE sp_CreateProfileSchemaRoles
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GrantPermissions_ProfileSchemaManager'))
    DROP PROCEDURE sp_GrantPermissions_ProfileSchemaManager
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'sp_GrantPermissions_ProfileSchemaReader'))
    DROP PROCEDURE sp_GrantPermissions_ProfileSchemaReader
GO

-----------------------------------------------------------------------------
-- Retrieve all of the specified catalog's general info.  This procedure does
-- a bit of extra work by actually fetching two result-sets.  The first
-- result-set contains the catalog's general info, if a catalog exists by the
-- specified name.  The second result-set contains the names of all profiles
-- in the catalog.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileCatalogInfo
    @u_cat_name nvarchar(128)
AS
    SET NOCOUNT ON

    SELECT * FROM CommerceServerCatalogs
        WHERE CatalogName = @u_cat_name

    SELECT ClassDefName FROM ClassDef
        WHERE CatalogName = @u_cat_name AND NOT (IsAbstract = 1)

    SELECT DISTINCT SourceGroupName FROM SourceDef
        WHERE CatalogName = @u_cat_name
GO


-----------------------------------------------------------------------------
-- Retrieve all of the information necessary for constructing an XML document
-- of all the catalogs.  This is done with three SELECTs.  The first gets all
-- the catalogs in the BizDataStore.  The second gets all non-abstract
-- profiles.  The third gets all data-sources.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileCatalogs
AS
    SET NOCOUNT ON

    -- First result-set is catalog list.
    SELECT * FROM CommerceServerCatalogs

    -- Second result-set is all non-abstract profiles.
    SELECT * FROM ClassDef
        WHERE NOT (IsAbstract = 1)
	Order By ClassDefName

    -- Third result-set is all data-sources.
    SELECT * FROM SourceDef
        WHERE IsDefault = 1
GO


-----------------------------------------------------------------------------
-- Retrieve all of the specified profile's general info.  This includes two
-- result-sets; the first being the profile info itself, and the second being
-- the profile-attribute info.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileInfo
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    SELECT * FROM ClassDef
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name

    SELECT * FROM ClsAttrib
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name
GO


-----------------------------------------------------------------------------
-- Retrieve all of the specified data-source's info.  This procedure does a
-- bit of work to make sure it is fast to retrieve a complete data-source.
-- It returns four different result-sets:
--     > The first is the source's info from the SourceDef table.
--     > The second is the source-attributes for the data-source.
--     > The third is the tables in the data-source.
--     > The fourth is all columns in the data-source.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetDataSourceInfo
    @u_cat_name nvarchar(128),
    @u_src_name nvarchar(128)
AS
    SET NOCOUNT ON

    -- First rowset:  source info

    SELECT * FROM SourceDef
        WHERE CatalogName = @u_cat_name AND SourceGroupName = @u_src_name

    -- Second rowset:  source attributes

    SELECT * FROM SourceAttrib
        WHERE SourceName IN (
            SELECT SourceName FROM SourceDef
                WHERE CatalogName = @u_cat_name AND SourceGroupName = @u_src_name
        )

    -- Third rowset:  table info

    SELECT * FROM TableDef
        WHERE CatalogName = @u_cat_name AND SourceDefName = @u_src_name

    -- Fourth rowset:  column info

    SELECT * FROM ColDef
        WHERE TblDefName IN (
            SELECT TableDefName FROM TableDef
                WHERE CatalogName = @u_cat_name AND SourceDefName = @u_src_name
        ) AND CatalogName = @u_cat_name
GO


-----------------------------------------------------------------------------
-- Retrieve all of the specified profile's member info.  This procedure
-- returns three rowsets:
--
--   1)  The list of all members from both the profile and all parent
--       profiles.  This list doesn't contain group-members from parents.
--
--   2)  Grouping information for the profile, from the GroupMem table.
--
--   3)  All member attributes for the members
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileProps
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.  This loop takes
    -- one step up the hierarchy each iteration.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Remove the child class from the temp-list, to keep things easier.
    DELETE FROM #stack WHERE u_prof_name = @u_prof_name

    -- FIRST RESULT-SET:  ALL MEMBERS IN THE PROFILE
    -- Select all of the members that we're interested in.  This is somewhat
    -- tricky, because we want them as follows:
    --     All members AND groups from child profile.
    --     All members (NO groups) from parent profiles.

    SELECT MD.*, CD.SourceDefName, SD.SourceGroupName, CD.DefaultTableName
        FROM MemberDef AS MD
            INNER JOIN ClassDef AS CD ON (MD.ClassDefName = CD.ClassDefName 
		AND CD.CatalogName = @u_cat_name)
            LEFT OUTER JOIN SourceDef AS SD ON (CD.SourceDefName = SD.SourceName
		AND SD.CatalogName = @u_cat_name)
        WHERE MD.CatalogName = @u_cat_name AND
            ((MD.ClassDefName IN (SELECT u_prof_name FROM #stack) AND IsGroup = 0) OR
             (MD.ClassDefName = @u_prof_name))
	     ORDER BY OrdinalPosInClass ASC

    -- SECOND RESULT-SET:  GROUPING INFORMATION IN THE PROFILE
    -- This consists of hierarchy information for properties / groups.

    SELECT * FROM GroupMem
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name
        ORDER BY OrdinalPosInGroup ASC

    -- THIRD RESULT-SET:  MEMBER ATTRIBUTES INFORMATION IN THE PROFILE
    -- This consists of all member-attributes, and requires use of the parent
    -- profiles list.

    SELECT * FROM MemAttrib
        WHERE CatalogName = @u_cat_name AND
            (ClassDefName IN (SELECT u_prof_name FROM #stack) OR
             ClassDefName = @u_prof_name)
GO


-----------------------------------------------------------------------------
-- This is a helper procedure for sp_DelProfile.  It deletes a single
-- profile, without regard to hierarchy, etc.  IT SHOULD NOT BE CALLED
-- DIRECTLY; ONLY BY sp_DelProfile!!!
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelProfileHelper
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON
    DECLARE @sProfileFullName nvarchar (256)
 
    SET @sProfileFullName = @u_cat_name + '.' + @u_prof_name

    -- Remove all properties / groups (members) in the profile.

    DELETE FROM MemberDef
        WHERE CatalogName = @u_cat_name AND
              ClassDefName = @u_prof_name

    -- If any of the members were groups, clean up GroupMem table.

    DELETE FROM GroupMem
        WHERE CatalogName = @u_cat_name AND
              ClassDefName = @u_prof_name

    -- If any members had attributes, clean up MemAttrib table.

    DELETE FROM MemAttrib
        WHERE CatalogName = @u_cat_name AND
              ClassDefName = @u_prof_name

    -- If I'm a parent-class, delete parent / child relations.

    DELETE FROM RelDef
        WHERE CatalogName = @u_cat_name AND ParentClassName = @u_prof_name

    -- Remove entries from the class attribute table

    DELETE FROM ClsAttrib
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name

    -- Remove profile entry from class-definition table.

    DELETE FROM ClassDef
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name

    -- Remove any references to this profile
    DELETE MemAttrib FROM MemAttrib INNER JOIN MemberDef
        ON MemAttrib.MemberName = MemberDef.MemberDefName And
           MemAttrib.ClassDefName = MemberDef.ClassDefName  
        WHERE MemberDef.ReferenceString = @sProfileFullName

    Delete GroupMem 
        FROM GroupMem INNER JOIN MemberDef
            ON  GroupMem.CatalogName = MemberDef.CatalogName AND
                GroupMem.GroupMemDefName = MemberDef.MemberDefName
        WHERE MemberDef.ReferenceString = @sProfileFullName

    DELETE FROM MemberDef 
        WHERE ReferenceString = @sProfileFullName

GO


-----------------------------------------------------------------------------
-- Delete specified profile.  This includes the following:
--     For each parent class, delete the parent-class.
--         (This uses sp_DelProfileHelper iteratively.)
--     Delete all parent-class / child-class relations.
--     Delete all members for this class.
--     Delete all group / member relations for this class.
--     Delete all member-attributes for this class.
--
-- This is an optimized profile-delete operation.  It does bulk-deletion of
-- properties and groups.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelProfile
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_level int
    SELECT @i_level = 1

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    WHILE @i_level > 0 BEGIN
        IF EXISTS(SELECT * FROM #stack WHERE i_level = @i_level)
        BEGIN
            -- Choose a single item from the stack at the current level.
            SELECT @u_prof_name = u_prof_name FROM #stack
                WHERE i_level = @i_level

            -- Do something with this item.
            EXECUTE sp_DelProfileHelper @u_cat_name, @u_prof_name

            -- Remove the item from the stack.
            DELETE FROM #stack
                WHERE u_prof_name = @u_prof_name AND i_level = @i_level

            -- Add all the parents of this item into the stack.
            INSERT #stack
                SELECT ParentClassName, @i_level + 1 FROM RelDef
                WHERE CatalogName = @u_cat_name AND
                      ChildClassName = @u_prof_name

            IF @@ROWCOUNT > 0 BEGIN
                SELECT @i_level = @i_level + 1
            END
        END ELSE BEGIN
            SELECT @i_level = @i_level - 1
        END
    END
GO


-----------------------------------------------------------------------------
-- Delete specified data-member.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelDataMember
    @u_cat_name nvarchar(128),
    @u_tbl_name nvarchar(128),
    @u_col_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE   @parentcls    	nvarchar(128)
   
    
    DECLARE curs_parentcls CURSOR FOR
       SELECT ClassDefName FROM ClassDef WHERE 
              CatalogName = @u_cat_name AND DefaultTableName = @u_tbl_name

        
    -- Unmap the properties that use this data member
    OPEN curs_parentcls
    FETCH NEXT FROM curs_parentcls INTO @parentcls
    WHILE (@@FETCH_STATUS = 0) BEGIN
       -- Unmap custom attributes
       UPDATE MemAttrib SET
			ClassDefName = (SELECT ChildClassName FROM RelDef WHERE ParentClassName = @parentcls AND CatalogName = @u_cat_name)
			WHERE  ClassDefName = @parentcls AND CatalogName = @u_cat_name AND 
			MemberName = (SELECT MemberDefName FROM MemberDef WHERE ColumnName = @u_col_name AND ClassDefName = @parentcls AND CatalogName = @u_cat_name)

       -- If it is a join key then delete it, otherwise unmap it so it becomes an in-memory property
       IF (SELECT IsJoinKey FROM MemberDef WHERE ColumnName = @u_col_name AND ClassDefName = @parentcls AND CatalogName = @u_cat_name) = 1
	BEGIN
	      -- It's a join key so delete the entry
    	      DELETE FROM MemberDef WHERE ColumnName = @u_col_name AND ClassDefName = @parentcls AND CatalogName = @u_cat_name
	END
       ELSE
	BEGIN
      	       -- Not a join key so  unmap it
	       UPDATE MemberDef SET
		     ClassDefName = (SELECT ChildClassName FROM RelDef WHERE ParentClassName = @parentcls AND CatalogName = @u_cat_name),
		     IsPersistent = 0,
		     ValTableName = NULL,
		     ValColumnName = NULL,
		     LinkTableName = NULL,
		     ColumnName = NULL		
	       WHERE ColumnName = @u_col_name AND ClassDefName = @parentcls AND CatalogName = @u_cat_name
	END

       -- Clean up ClassDef and RelDef
            -- If no profiles are any longer mapped to the table that this data member is being deleted from 
            -- then we need to delete the Parent/Child relationship from RelDef and ClassDef
       IF NOT EXISTS (SELECT * FROM MemberDef WHERE 
			ClassDefName = @parentcls AND CatalogName = @u_cat_name)
       BEGIN
             DELETE FROM RelDef WHERE ParentClassName =  @parentcls AND CatalogName = @u_cat_name
             DELETE FROM ClassDef WHERE ClassDefName = @parentcls AND CatalogName = @u_cat_name
       END
       
    FETCH NEXT FROM curs_parentcls INTO @parentcls
    END

    CLOSE curs_parentcls
    DEALLOCATE curs_parentcls

    -- Remove the column row from the ColDef table.
    DELETE FROM ColDef
        WHERE CatalogName = @u_cat_name AND TblDefName = @u_tbl_name AND
              ColDefName = @u_col_name
GO


-----------------------------------------------------------------------------
-- Delete specified data object (table).  This includes the following:
--     For each member (column) in this table, delete the member.
--     Delete the entry in the object (table) table referring to this object.
--     Delete any entries in the partition table referring to this object.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelDataObject
    @u_cat_name nvarchar(128),
    @u_src_name nvarchar(128),
    @u_tbl_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE   @childmember   	nvarchar(128)
    
    DECLARE curs_childmembers CURSOR FOR
       SELECT ColDefName FROM ColDef WHERE 
              CatalogName = @u_cat_name AND TblDefName = @u_tbl_name

    -- Unmap the properties that use this data member
    OPEN curs_childmembers
    FETCH NEXT FROM curs_childmembers INTO @childmember
    WHILE (@@FETCH_STATUS = 0) BEGIN
         -- Call sp_DelDataObject to remove this child data member
         -- This wil also clean up any profiles that are currently mapped to this member
         EXECUTE sp_DelDataMember @u_cat_name, @u_tbl_name, @childmember
      
         FETCH NEXT FROM curs_childmembers INTO @childmember
    END

    CLOSE curs_childmembers
    DEALLOCATE curs_childmembers

    -- Delete the table entry.

    DELETE FROM TableDef
        WHERE CatalogName = @u_cat_name AND
              SourceDefName = @u_src_name AND
              TableDefName = @u_tbl_name
GO


-----------------------------------------------------------------------------
-- Retrieve the set of profile-definitions that depend on the passed-in data
-- source.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetDataSourceDepends
    @u_cat_name nvarchar(128),
    @u_srcgroup_name nvarchar(128)
AS
    SET NOCOUNT ON

    SELECT * FROM ClassDef
        WHERE CatalogName = @u_cat_name AND
              SourceDefName IN (
                  SELECT SourceName FROM SourceDef
                      WHERE CatalogName = @u_cat_name AND
                            SourceGroupName = @u_srcgroup_name
              )
GO

-----------------------------------------------------------------------------
-- Delete specified source.  This includes the following:
--     For each table in this source, delete the table.
--         (This is done with sp_DelDataObject.)
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelDataSource
    @u_cat_name nvarchar(128),
    @u_src_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @u_tbl_name nvarchar(128)

    -- This cursor is for all tables in the specified source.
    DECLARE curs_tables CURSOR FOR
        SELECT TableDefName FROM TableDef
        WHERE CatalogName = @u_cat_name AND SourceDefName = @u_src_name

    -- For each table, delete the table (and all its columns).

    OPEN curs_tables
    FETCH NEXT FROM curs_tables INTO @u_tbl_name
    WHILE (@@FETCH_STATUS = 0) BEGIN
        EXECUTE sp_DelDataObject @u_cat_name, @u_src_name, @u_tbl_name
        FETCH NEXT FROM curs_tables INTO @u_tbl_name
    END

    CLOSE curs_tables
    DEALLOCATE curs_tables

    -- Remove source-attributes from the SourceAttrib table.
    DELETE FROM SourceAttrib
        WHERE SourceName IN (
            SELECT SourceName FROM SourceDef
                WHERE CatalogName = @u_cat_name AND
                      SourceGroupName = @u_src_name
        )

    -- Remove the source row from the SourceDef table.

    DELETE FROM SourceDef
        WHERE CatalogName = @u_cat_name AND SourceGroupName = @u_src_name
GO


CREATE PROCEDURE sp_DelProfileCatalog
    @u_cat_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @u_cls_name nvarchar(128)
    DECLARE @u_src_name nvarchar(128)

    -- This cursor is for all classes in the specified catalog.
    DECLARE curs_classes CURSOR FOR
        SELECT ClassDefName FROM ClassDef
        WHERE CatalogName = @u_cat_name

    -- This cursor is for all sources in the specified catalog.
    DECLARE curs_sources CURSOR FOR
        SELECT SourceGroupName FROM SourceDef
        WHERE CatalogName = @u_cat_name

    -- Delete all classes.

    OPEN curs_classes
    FETCH NEXT FROM curs_classes INTO @u_cls_name
    WHILE (@@FETCH_STATUS = 0) BEGIN
        EXECUTE sp_DelProfile @u_cat_name, @u_cls_name

        FETCH NEXT FROM curs_classes INTO @u_cls_name
    END
    CLOSE curs_classes
    DEALLOCATE curs_classes

    -- Delete all sources.

    OPEN curs_sources
    FETCH NEXT FROM curs_sources INTO @u_src_name
    WHILE (@@FETCH_STATUS = 0) BEGIN
        EXECUTE sp_DelDataSource @u_cat_name, @u_src_name

        FETCH NEXT FROM curs_sources INTO @u_src_name
    END
    CLOSE curs_sources
    DEALLOCATE curs_sources

    -- Remove the entry in the catalog table.

    DELETE FROM CommerceServerCatalogs
        WHERE CatalogName = @u_cat_name
GO


-----------------------------------------------------------------------------
-- Helper-function to delete a profile-property.
--
-- This stored-procedure only deletes a profile-property when it is
-- deletable.  A property is not deletable if:
--   * It is a primary key.
--   * It is a hashing key.
--   * It is an RDN-attribute.
--
-- This is a helper procedure for sp_DelProfileProperty and
-- sp_DelProfileGroup.  IT SHOULD NOT BE CALLED DIRECTLY!!!
--
-- Return Values:
--   0 = Successfully deleted the property.
--   1 = Property is not deletable.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelProfilePropHelper
    @u_cat_name  nvarchar(128),
    @u_prof_name nvarchar(128),
    @u_prop_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_result int
    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #dppStack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #dppStack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.

    WHILE EXISTS(SELECT * FROM #dppStack WHERE i_level = @i_level) BEGIN

        INSERT #dppStack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #dppStack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Delete all entries in the MemberDef table for the property.  This will
    -- nail inherited properties as well.

    DELETE FROM MemberDef
        WHERE (ClassDefName IN (SELECT u_prof_name FROM #dppStack)) AND
              CatalogName = @u_cat_name AND MemberDefName = @u_prop_name

    -- Delete all attributes on this property.

    DELETE FROM MemAttrib
        WHERE (ClassDefName IN (SELECT u_prof_name FROM #dppStack)) AND
              CatalogName = @u_cat_name AND MemberName = @u_prop_name

    -- Remove the property from the group it's in.  We don't need to use the
    -- profile hierarchy list because groups aren't inherited.

    DELETE FROM GroupMem
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name AND
              GroupMemDefName = @u_prop_name

    

     -- Clean up ClassDef and RelDef
            -- If no profiles are any longer mapped to the table that this data member is being deleted from 
            -- then we need to delete the Parent/Child relationship from RelDef and ClassDef
       DECLARE @parentcls      nvarchar(256)
       DECLARE curs_parentcls CURSOR FOR SELECT u_prof_name FROM #dppStack WHERE i_level > 1
       OPEN curs_parentcls
       FETCH NEXT FROM curs_parentcls INTO @parentcls
       WHILE (@@FETCH_STATUS = 0) BEGIN
	IF NOT EXISTS (SELECT * FROM MemberDef WHERE 
	       ClassDefName =  @parentcls AND CatalogName = @u_cat_name)
       	BEGIN
	       DELETE FROM RelDef WHERE ParentClassName =  @parentcls AND CatalogName = @u_cat_name
 	       DELETE FROM ClassDef WHERE ClassDefName = @parentcls AND CatalogName = @u_cat_name
              END

 	FETCH NEXT FROM curs_parentcls INTO @parentcls
       END
       CLOSE curs_parentcls
       DEALLOCATE curs_parentcls



    -- Indicate success to the caller.
    SELECT @i_result = 0
 
    RETURN @i_result
GO



-----------------------------------------------------------------------------
-- This is a helper procedure for sp_DelProfileGroup.  It deletes a single
-- group, without regard to hierarchy, etc.  IT SHOULD NOT BE CALLED
-- DIRECTLY; ONLY BY sp_DelProfileGroup!!!
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelProfileGroupHelper
    @u_cat_name   nvarchar(128),
    @u_prof_name  nvarchar(128),
    @u_group_name nvarchar(128)
AS
    SET NOCOUNT ON

    -- Delete all entries in the MemberDef table for the group.

    DELETE FROM MemberDef
        WHERE ClassDefName = @u_prof_name AND CatalogName = @u_cat_name AND
              MemberDefName = @u_group_name

    -- Delete all attributes on this group.

    DELETE FROM MemAttrib
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name AND
              MemberName = @u_group_name

    -- Remove the group from the group it's in.

    DELETE FROM GroupMem
        WHERE CatalogName = @u_cat_name AND ClassDefName = @u_prof_name AND
              GroupMemDefName = @u_group_name
GO


CREATE PROCEDURE sp_DelProfileProperty
    @u_cat_name  nvarchar(128),
    @u_prof_name nvarchar(128),
    @u_prop_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_callRes int
    EXECUTE @i_callRes = sp_DelProfilePropHelper @u_cat_name, @u_prof_name,
        @u_prop_name
    SELECT status = @i_callRes
GO


-----------------------------------------------------------------------------
-- Delete specified profile group.  This includes the following:
--     Delete all contained properties and groups.
--         (This uses sp_DelProfileProperty and sp_DelProfileGroupHelper
--         iteratively.)
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_DelProfileGroup
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128),
    @u_group_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_callRes int
    DECLARE @u_member_name nvarchar(128)
    DECLARE @i_is_group tinyint
    DECLARE @i_level int
    SELECT @i_level = 1

    CREATE TABLE #dpgStack (u_name nvarchar(128), i_level int)
    INSERT INTO #dpgStack VALUES (@u_group_name, @i_level)

    WHILE @i_level > 0 BEGIN
        IF EXISTS(SELECT * FROM #dpgStack WHERE i_level = @i_level)
        BEGIN
            -- Choose a single item from the stack at the current level.
            SELECT @u_member_name = s.u_name, @i_is_group = MD.IsGroup
                FROM #dpgStack AS s
                JOIN MemberDef AS MD ON (MD.MemberDefName = s.u_name)
                WHERE i_level = @i_level

            -- Do something with this item.
            IF @i_is_group = 1 BEGIN
                EXECUTE sp_DelProfileGroupHelper @u_cat_name, @u_prof_name,
                    @u_member_name
            END ELSE BEGIN
                EXECUTE @i_callRes = sp_DelProfilePropHelper @u_cat_name,
                    @u_prof_name, @u_member_name
                -- If an error occurred while deleting the property, return
                -- it to my caller.
                IF @i_callRes != 0
                BEGIN
                    SELECT status = @i_callRes
                    RETURN(@i_callRes)
                END
            END

            -- Remove the item from the stack.
            DELETE FROM #dpgStack
                WHERE u_name = @u_member_name AND i_level = @i_level

            -- Add all the child members of this member into the stack.
            INSERT #dpgStack
                SELECT GroupMemDefName, @i_level + 1 FROM GroupMem
                WHERE CatalogName = @u_cat_name AND
                      ClassDefName = @u_prof_name AND
                      GroupName = @u_member_name

            IF @@ROWCOUNT > 0 BEGIN
                SELECT @i_level = @i_level + 1
            END
        END ELSE BEGIN
            SELECT @i_level = @i_level - 1
        END
    END

    -- SUCCESS.
    SELECT status = 0
GO


-----------------------------------------------------------------------------
-- sp_GetProfileMember
--
-- Description:
--     This stored-procedure retrieves two result-sets from the database.
--
--     The first result-set is the row from the ClassDef table for the
--     specified profile-definition.  It is used to determine whether the
--     profile/catalog actually exist in the database.
--
--     The second result-set contains all entries in the MemberDef table that
--     refer to the specified member.  (This includes all parent-class
--     declarations of the member as well.)
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileMember
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128),
    @u_prop_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Find out whether the class/catalog we're accessing actually exists.

    SELECT * FROM ClassDef
        WHERE ClassDefName = @u_prof_name AND CatalogName = @u_cat_name

    -- Retrieve all entries in the MemberDef table for the property.  This
    -- will get inherited properties as well.

    SELECT * FROM MemberDef
        WHERE (ClassDefName IN (SELECT u_prof_name FROM #stack)) AND
              CatalogName = @u_cat_name AND MemberDefName = @u_prop_name
GO


-----------------------------------------------------------------------------
-- sp_GetProfileMemAttrs
--
-- Description:
--     Retrieves all entries in the MemAttrib table that are for the
--     specified member.  (This includes all parent-class declarations of the
--     member as well.)
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileMemAttrs
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128),
    @u_prop_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Retrieve the name of one or more of the top-level parent-classes that
    -- is actually used by the member.  This is the name of the class that
    -- attributes should appear on.

    SELECT ClassDefName = u_prof_name FROM #stack
        WHERE u_prof_name IN (
            SELECT ClassDefName FROM MemberDef
                WHERE CatalogName = @u_cat_name AND MemberDefName = @u_prop_name
        )
        ORDER BY i_level DESC

    -- Retrieve all entries in the MemAttrib table for the attribute.  This
    -- will get inherited attributes as well.

    SELECT * FROM MemAttrib
        WHERE (ClassDefName IN (SELECT u_prof_name FROM #stack)) AND
              CatalogName = @u_cat_name AND MemberName = @u_prop_name

GO


-----------------------------------------------------------------------------
-- sp_GetProfileDomains
--
-- Description:
--     Retrieves all domain-names for a given profile from the BizDataStore.
--       - The result-set is empty if the profile uses no AD sources.
--       - The result-set contains only one domain-name if the AD source is
--         not partitioned.
--       - The result-set contains multiple domain-names, ordered
--         alphabetically by SourceName, if the AD source is partitioned.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileDomains
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @u_src_grp_name nvarchar(128)

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Retrieve all source-group-names such that the profile has a hash-key
    -- member mapped to a source in that source-group.
    SELECT @u_src_grp_name = SD.SourceGroupName
        FROM MemberDef AS MD
            INNER JOIN ClassDef AS CD ON (MD.ClassDefName = CD.ClassDefName AND
                                          MD.CatalogName  = CD.CatalogName)
            INNER JOIN SourceDef AS SD ON (CD.SourceDefName = SD.SourceName AND
                                           CD.CatalogName   = SD.CatalogName)
        WHERE MD.CatalogName = @u_cat_name AND				-- Correct catalog...
              MD.ClassDefName IN (SELECT u_prof_name FROM #stack) AND	-- Correct profile (or parents)...
              MD.IsHashingKey = 1 AND					-- Is a hashing-key...
              SD.Type = 8						-- Source is an LDAPv3 source...

    IF @@ROWCOUNT > 0 BEGIN
        -- This is a partitioned source.  Get all AD domain-names for the
        -- source-group, ordered by source-name.

        SELECT ADDomainName FROM SourceDef
            WHERE CatalogName = @u_cat_name AND
                  SourceGroupName = @u_src_grp_name
            ORDER BY ADDomainName ASC
    END ELSE BEGIN
        -- This is not a partitioned source.
        -- Retrieve all AD domain-names for the source such that the source

        SELECT SD.ADDomainName
            FROM SourceDef AS SD
            INNER JOIN ClassDef AS CD ON (SD.SourceName = CD.SourceDefName AND
                                          SD.CatalogName  = CD.CatalogName)
            WHERE CD.ClassDefName IN (SELECT u_prof_name FROM #stack) AND
                  SD.Type = 8
    END
GO


-----------------------------------------------------------------------------
-- sp_GetProfileSources
--
-- Description:
--     Retrieves a list of data sources used in this profile
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileSources
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @u_src_grp_name nvarchar(128)

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Retrieve all source rows related to classes in this profile
    SELECT * FROM SourceDef AS SD
            INNER JOIN ClassDef AS CD ON (CD.SourceDefName = SD.SourceName AND
                                         CD.CatalogName = SD.CatalogName)
         WHERE SD.CatalogName = @u_cat_name AND				-- Correct catalog...
              CD.ClassDefName IN (SELECT u_prof_name FROM #stack) -- Correct profile (or parents)...

    -- Retrieve all parent classes in this profile
    SELECT * FROM ClassDef
         WHERE CatalogName = @u_cat_name AND				-- Correct catalog...
              ClassDefName IN (SELECT u_prof_name FROM #stack) -- Correct profile (or parents)...
GO



-----------------------------------------------------------------------------
-- Retrieve all of the specified profile's member info.  This procedure
-- returns three rowsets:
--
--   1)  The list of all members from both the profile and all parent
--       profiles.  This list doesn't contain group-members from parents.
--
--   2)  Grouping information for the profile, from the GroupMem table.
--
--   3)  All member attributes for the members
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GetProfileCustomProps
    @u_cat_name nvarchar(128),
    @u_prof_name nvarchar(128)
AS
    SET NOCOUNT ON

    DECLARE @i_level int
    SELECT @i_level = 1

    -- Create a temp table, and put the specified profile-name into it.

    CREATE TABLE #stack (u_prof_name nvarchar(128), i_level int)
    INSERT INTO #stack VALUES (@u_prof_name, @i_level)

    -- Iteratively add the parent-profile-names to the list.  This loop takes
    -- one step up the hierarchy each iteration.

    WHILE EXISTS(SELECT * FROM #stack WHERE i_level = @i_level) BEGIN

        INSERT #stack
            SELECT ParentClassName, @i_level + 1 FROM RelDef
            WHERE CatalogName = @u_cat_name AND
                  ChildClassName IN (SELECT u_prof_name FROM #stack
                                     WHERE i_level = @i_level)

        SELECT @i_level = @i_level + 1
    END

    -- Remove the child class from the temp-list, to keep things easier.
    DELETE FROM #stack WHERE u_prof_name = @u_prof_name

    -- FIRST RESULT-SET:  ALL MEMBERS IN THE PROFILE
    -- Select all of the members that we're interested in.  This is somewhat
    -- tricky, because we want them as follows:
    --     All members AND groups from child profile.
    --     All members (NO groups) from parent profiles.

    -- THIRD RESULT-SET:  MEMBER ATTRIBUTES INFORMATION IN THE PROFILE
    -- This consists of all member-attributes, and requires use of the parent
    -- profiles list.

    SELECT * FROM MemAttrib
        WHERE CatalogName = @u_cat_name AND
            (ClassDefName IN (SELECT u_prof_name FROM #stack) OR
             ClassDefName = @u_prof_name)
GO


-----------------------------------------------------------------------------
-- Procedures to grant required permissions for each role
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GrantPermissionForRole
(
    @ObjectName    sysname,    -- object name
    @objectType    char(2),    -- type of the object
    @RoleName    sysname,    -- role name
    @Permissions    nvarchar(500)    -- permissions to grant.
)

AS
BEGIN
    SET NOCOUNT ON
    DECLARE @Query_tmp    nvarchar(4000)

    SET @ObjectName = LTRIM(RTRIM(@ObjectName ))
    IF SUBSTRING(@ObjectName,1,1) <> '['
    BEGIN
        SET @ObjectName = N'['+@ObjectName+']'
    END

    -- Check that an object with given name and type exist.
    IF (     ((@objectType = 'P') AND
            EXISTS (SELECT '*' FROM sysobjects WHERE id = object_id(@ObjectName) and OBJECTPROPERTY(id, N'IsProcedure') = 1)) OR
        ((@objectType = 'T') AND
            EXISTS (SELECT '*' FROM sysobjects WHERE id = object_id(@ObjectName) and OBJECTPROPERTY(id, N'IsUserTable') = 1)) OR
        ((@objectType = 'F') AND
            EXISTS (SELECT '*' FROM sysobjects WHERE id = object_id(@ObjectName) and OBJECTPROPERTY(id, N'IsScalarFunction') = 1)) OR
        ((@objectType = 'I') AND
            EXISTS (SELECT '*' FROM sysobjects WHERE id = object_id(@ObjectName) and OBJECTPROPERTY(id, N'IsInlineFunction') = 1)) OR
        ((@objectType = 'V') AND            EXISTS (SELECT '*' FROM sysobjects WHERE id = object_id(@ObjectName) and OBJECTPROPERTY(id, N'IsView') = 1))    )
    BEGIN
        -- Grant the specified premissions to the specified role for the specified object.
         EXEC (N'GRANT ' + @Permissions + N' ON dbo.' + @ObjectName + N' TO ' + @RoleName)
    END
END
GO


-----------------------------------------------------------------------------
-- Creates roles for the profile catalog
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_CreateProfileSchemaRoles
AS
BEGIN
    SET NOCOUNT ON
    IF NOT EXISTS (SELECT '*' FROM dbo.sysusers WHERE name = N'Profile_Schema_Manager' AND issqlrole = 1)
    BEGIN
         EXEC sp_addrole    N'Profile_Schema_Manager'
    END
    IF NOT EXISTS (SELECT '*' FROM dbo.sysusers WHERE name = N'Profile_Schema_Reader' AND issqlrole = 1)
    BEGIN
         EXEC sp_addrole    N'Profile_Schema_Reader'
    END
END
GO

-----------------------------------------------------------------------------
-- Profile_Schema_Manager role:
-- Granted permission to modify profile schema tables and execute all stored
-- procedures.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GrantPermissions_ProfileSchemaManager
AS
BEGIN
	SET NOCOUNT ON
	EXEC dbo.sp_GrantPermissionForRole N'CommerceServerCatalogs', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'CommerceServerCatalogs', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'CommerceServerCatalogs', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'CommerceServerCatalogs', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'ClassDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ClassDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'ClassDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'ClassDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'RelDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'RelDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'RelDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'RelDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'MemberDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'MemberDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'MemberDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'MemberDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'GroupMem', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'GroupMem', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'GroupMem', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'GroupMem', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'SourceDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'SourceDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'TableDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'TableDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'TableDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'TableDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'ColDef', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ColDef', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'ColDef', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'ColDef', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'SourceAttrib', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceAttrib', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceAttrib', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'SourceAttrib', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'ClsAttrib', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ClsAttrib', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'ClsAttrib', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'ClsAttrib', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'MemAttrib', N'T', N'Profile_Schema_Manager', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'MemAttrib', N'T', N'Profile_Schema_Manager', N'INSERT'
	EXEC dbo.sp_GrantPermissionForRole N'MemAttrib', N'T', N'Profile_Schema_Manager', N'UPDATE'
	EXEC dbo.sp_GrantPermissionForRole N'MemAttrib', N'T', N'Profile_Schema_Manager', N'DELETE'

	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCatalogInfo', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCatalogs', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileInfo', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileInfo', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetDataSourceInfo', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileProps', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfileHelper', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfile', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelDataMember', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelDataObject', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetDataSourceDepends', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelDataSource', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfileCatalog', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfilePropHelper', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfileGroupHelper', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfileProperty', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_DelProfileGroup', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileMember', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileMemAttrs', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileDomains', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileSources', N'P', N'Profile_Schema_Manager', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCustomProps', N'P', N'Profile_Schema_Manager', N'EXEC'

END
GO


-----------------------------------------------------------------------------
-- Profile_Schema_Reader role:
-- Granted permission to read profile schema tables and execute a subset of
-- stored procedures.
-----------------------------------------------------------------------------
CREATE PROCEDURE sp_GrantPermissions_ProfileSchemaReader
AS
BEGIN
	SET NOCOUNT ON
	EXEC dbo.sp_GrantPermissionForRole N'CommerceServerCatalogs', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ClassDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'RelDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'MemberDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'GroupMem', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'TableDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ColDef', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'SourceAttrib', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'ClsAttrib', N'T', N'Profile_Schema_Reader', N'SELECT'
	EXEC dbo.sp_GrantPermissionForRole N'MemAttrib', N'T', N'Profile_Schema_Reader', N'SELECT'

	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCatalogInfo', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCatalogs', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileInfo', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileInfo', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetDataSourceInfo', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileProps', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetDataSourceDepends', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileMember', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileMemAttrs', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileDomains', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileSources', N'P', N'Profile_Schema_Reader', N'EXEC'
	EXEC dbo.sp_GrantPermissionForRole N'sp_GetProfileCustomProps', N'P', N'Profile_Schema_Reader', N'EXEC'
END
GO


-----------------------------------------------------------------------------
-- Create roles
-----------------------------------------------------------------------------
EXEC sp_CreateProfileSchemaRoles
GO
EXEC sp_GrantPermissions_ProfileSchemaManager
GO
EXEC sp_GrantPermissions_ProfileSchemaReader
GO

