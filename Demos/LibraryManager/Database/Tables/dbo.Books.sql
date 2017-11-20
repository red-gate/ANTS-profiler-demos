CREATE TABLE [dbo].[Books]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Author] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[ISBN] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Books] ADD 
CONSTRAINT [PK_Books_Id] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
