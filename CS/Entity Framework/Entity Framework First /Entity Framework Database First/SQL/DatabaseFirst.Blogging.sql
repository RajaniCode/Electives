USE [DatabaseFirst.Blogging];
GO

IF EXISTS(SELECT name FROM sys.tables WHERE name = N'Blogs')
DROP TABLE [dbo].[Blogs];
GO

-- OR

IF OBJECT_ID (N'Blogs', N'U') IS NOT NULL
DROP TABLE [dbo].[Blogs];
GO

CREATE TABLE [dbo].[Blogs] ( 
    [BlogId] INT IDENTITY (1, 1) NOT NULL, 
    [Name] NVARCHAR (200) NULL, 
    [Url]  NVARCHAR (200) NULL, 
    CONSTRAINT [PK_dbo.Blogs] PRIMARY KEY CLUSTERED ([BlogId] ASC) 
); 
GO

SELECT * FROM [dbo].[Blogs];
GO

IF EXISTS(SELECT name FROM sys.tables WHERE name = N'Posts')
DROP TABLE [dbo].[Posts];
GO

-- OR

IF OBJECT_ID (N'Posts', N'U') IS NOT NULL
DROP TABLE [dbo].[Posts];
GO

CREATE TABLE [dbo].[Posts] ( 
    [PostId] INT IDENTITY (1, 1) NOT NULL, 
    [Title] NVARCHAR (200) NULL, 
    [Content] NTEXT NULL, 
    [BlogId] INT NOT NULL, 
    CONSTRAINT [PK_dbo.Posts] PRIMARY KEY CLUSTERED ([PostId] ASC), 
    CONSTRAINT [FK_dbo.Posts_dbo.Blogs_BlogId] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blogs] ([BlogId]) ON DELETE CASCADE 
);
GO



SELECT * FROM [dbo].[Posts];
GO