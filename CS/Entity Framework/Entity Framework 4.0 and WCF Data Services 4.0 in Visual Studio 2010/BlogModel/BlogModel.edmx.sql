
-- --------------------------------------------------
-- Date Created: 01/06/2010 11:36:44
-- Generated from EDMX file: C:\Users\elisaj\documents\visual studio 2010\Projects\BlogModel\BlogModel\BlogModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
SET ANSI_NULLS ON;
GO

USE [Blogs]
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]')
GO

-- --------------------------------------------------
-- Dropping existing FK constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Blogs'
CREATE TABLE [dbo].[Blogs] (
    [BlogID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Owner] nvarchar(max)  NOT NULL
);
GO
-- Creating table 'Posts'
CREATE TABLE [dbo].[Posts] (
    [PostID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedDate] datetime  NOT NULL,
    [PostContent] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [BlogBlogID] int  NOT NULL,
    [Public] bit  NOT NULL
);
GO
-- Creating table 'Tags'
CREATE TABLE [dbo].[Tags] (
    [TagID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO
-- Creating table 'PostTag'
CREATE TABLE [dbo].[PostTag] (
    [Posts_PostID] int  NOT NULL,
    [Tags_TagID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all Primary Key Constraints
-- --------------------------------------------------

-- Creating primary key on [BlogID] in table 'Blogs'
ALTER TABLE [dbo].[Blogs] WITH NOCHECK 
ADD CONSTRAINT [PK_Blogs]
    PRIMARY KEY CLUSTERED ([BlogID] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [PostID] in table 'Posts'
ALTER TABLE [dbo].[Posts] WITH NOCHECK 
ADD CONSTRAINT [PK_Posts]
    PRIMARY KEY CLUSTERED ([PostID] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [TagID] in table 'Tags'
ALTER TABLE [dbo].[Tags] WITH NOCHECK 
ADD CONSTRAINT [PK_Tags]
    PRIMARY KEY CLUSTERED ([TagID] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Posts_PostID], [Tags_TagID] in table 'PostTag'
ALTER TABLE [dbo].[PostTag] WITH NOCHECK 
ADD CONSTRAINT [PK_PostTag]
    PRIMARY KEY NONCLUSTERED ([Posts_PostID], [Tags_TagID] ASC)
    ON [PRIMARY]
GO

-- --------------------------------------------------
-- Creating all Foreign Key Constraints
-- --------------------------------------------------

-- Creating foreign key on [BlogBlogID] in table 'Posts'
ALTER TABLE [dbo].[Posts] WITH NOCHECK 
ADD CONSTRAINT [FK_BlogPost]
    FOREIGN KEY ([BlogBlogID])
    REFERENCES [dbo].[Blogs]
        ([BlogID])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Posts_PostID] in table 'PostTag'
ALTER TABLE [dbo].[PostTag] WITH NOCHECK 
ADD CONSTRAINT [FK_PostTag_Post]
    FOREIGN KEY ([Posts_PostID])
    REFERENCES [dbo].[Posts]
        ([PostID])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO
-- Creating foreign key on [Tags_TagID] in table 'PostTag'
ALTER TABLE [dbo].[PostTag] WITH NOCHECK 
ADD CONSTRAINT [FK_PostTag_Tag]
    FOREIGN KEY ([Tags_TagID])
    REFERENCES [dbo].[Tags]
        ([TagID])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------