CREATE TABLE [dbo].[Magazines]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Title] [varchar] (8000) COLLATE Latin1_General_CI_AS NOT NULL,
[Author] [varchar] (8000) COLLATE Latin1_General_CI_AS NOT NULL,
[ISBN] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Author] ON [dbo].[Magazines] ([Author]) INCLUDE ([Id], [ISBN], [Title]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [NonClusteredIndex_Title] ON [dbo].[Magazines] ([Title]) INCLUDE ([Author], [Id], [ISBN]) ON [PRIMARY]





GO
ALTER TABLE [dbo].[Magazines] ADD CONSTRAINT [PK_Magazines_Id] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
