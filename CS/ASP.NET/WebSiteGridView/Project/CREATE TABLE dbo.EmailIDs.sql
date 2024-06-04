USE [FBSWDSV2];
GO

IF OBJECT_ID('dbo.tblEmailAccounts', 'U') IS NOT NULL
DROP TABLE dbo.tblEmailAccounts;
GO

CREATE TABLE dbo.tblEmailAccounts
(
Id [int] IDENTITY(1,1) NOT NULL,
EmailId nvarchar(50) NOT NULL,
UserId nvarchar(50) NOT NULL
CONSTRAINT FK_UserId
FOREIGN KEY REFERENCES dbo.tblUsers(UserId),
CONSTRAINT PK_EmailId PRIMARY KEY(EmailId)    
);
GO

INSERT INTO dbo.tblEmailAccounts
VALUES
(
'srajani@fergusonbeauregard.com',
'srajani'
)

INSERT INTO dbo.tblEmailAccounts
VALUES
(
'rajani.net@gmail.com',
'rajani'
)
SELECT * FROM dbo.tblEmailAccounts









USE [FBSWDSV2]
GO
/****** Object:  Table [dbo].[tblUsers]    Script Date: 09/23/2008 14:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsers](
	[UserId] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[UserTypeId] [int] NOT NULL,
 CONSTRAINT [PK_tblUsers] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblUsers]  WITH CHECK ADD  CONSTRAINT [FK_tblUsers_tblUserTypes] FOREIGN KEY([UserTypeId])
REFERENCES [dbo].[tblUserTypes] ([Id])
GO
ALTER TABLE [dbo].[tblUsers] CHECK CONSTRAINT [FK_tblUsers_tblUserTypes]




INSERT INTO dbo.tblUsers
VALUES
(
'srajani',
'srajani',
1
)


INSERT INTO dbo.tblUsers
VALUES
(
'rajani',
'rajani',
2
)
SELECT * FROM dbo.tblUsers