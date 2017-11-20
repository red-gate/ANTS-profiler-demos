CREATE TABLE [dbo].[Books]
(
[BookId] [int] NOT NULL IDENTITY(1, 1),
[ISBN] [varchar] (20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Title] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Author] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Copies] [int] NOT NULL,
[Large] [bit] NOT NULL,
[PublishDate] [date] NOT NULL
) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [NonClusteredIndex_Isbn] ON [dbo].[Books] ([ISBN], [BookId]) INCLUDE ([Author], [Copies], [Large], [PublishDate], [Title]) ON [PRIMARY]

GO
