CREATE TABLE [dbo].[BookInstances]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[BookId] [int] NOT NULL,
[Location] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[PricePaid] [money] NOT NULL CONSTRAINT [DF_BookInstances_PricePaid] DEFAULT ((0.00))
) ON [PRIMARY]
ALTER TABLE [dbo].[BookInstances] ADD 
CONSTRAINT [PK_BookInstances_Id] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
ALTER TABLE [dbo].[BookInstances] ADD
CONSTRAINT [FK_BookId] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id])
GO
