if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Agents]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Agents]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Customers]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Customers]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Interest]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Interest]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[KeyGenerator]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[KeyGenerator]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Loans]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Loans]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Ratings]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Ratings]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Regions]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Regions]
GO

CREATE TABLE [dbo].[Agents] (
	[AgentID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL ,
	[RegionID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Customers] (
	[CustomerID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[StreetAddress] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[City] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[State] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Rating] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Interest] (
	[Rating] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[InterestRate] [real] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[KeyGenerator] (
	[incrementer] [int] NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Loans] (
	[LoanID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[CustomerID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[AgentID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[RequestAmt] [money] NOT NULL ,
	[Interest] [real] NOT NULL ,
	[Status] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Ratings] (
	[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[Rating] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Regions] (
	[RegionID] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL ,
	[State] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Agents] WITH NOCHECK ADD 
	CONSTRAINT [PK_Agents] PRIMARY KEY  CLUSTERED 
	(
		[AgentID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Customers] WITH NOCHECK ADD 
	CONSTRAINT [PK_Customers] PRIMARY KEY  CLUSTERED 
	(
		[CustomerID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Interest] WITH NOCHECK ADD 
	CONSTRAINT [PK_Interest] PRIMARY KEY  CLUSTERED 
	(
		[Rating]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Loans] WITH NOCHECK ADD 
	CONSTRAINT [PK_Loans] PRIMARY KEY  CLUSTERED 
	(
		[LoanID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Ratings] WITH NOCHECK ADD 
	CONSTRAINT [PK_Rating] PRIMARY KEY  CLUSTERED 
	(
		[FirstName],
		[LastName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Regions] WITH NOCHECK ADD 
	CONSTRAINT [PK_Regions] PRIMARY KEY  CLUSTERED 
	(
		[State]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Agents] ADD 
	CONSTRAINT [IX_Agents] UNIQUE  NONCLUSTERED 
	(
		[RegionID]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[Customers] ADD 
	CONSTRAINT [DF_Customers_Rating] DEFAULT (N'new') FOR [Rating],
	CONSTRAINT [IX_Customers] UNIQUE  NONCLUSTERED 
	(
		[FirstName],
		[LastName]
	)  ON [PRIMARY] 
GO

ALTER TABLE [dbo].[KeyGenerator] ADD 
	CONSTRAINT [DF_KeyGenerator_incrementer] DEFAULT (0) FOR [incrementer]
GO

ALTER TABLE [dbo].[Loans] ADD 
	CONSTRAINT [DF_Loans_AgentID] DEFAULT (N'blank') FOR [AgentID],
	CONSTRAINT [DF_Loans_Interest] DEFAULT (0) FOR [Interest],
	CONSTRAINT [DF_Loans_Status] DEFAULT (N'new') FOR [Status]
GO

 CREATE  INDEX [IX_Loans] ON [dbo].[Loans]([CustomerID]) ON [PRIMARY]
GO
