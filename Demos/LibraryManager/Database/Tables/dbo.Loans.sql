CREATE TABLE [dbo].[Loans]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[MemberId] [int] NOT NULL,
[StartDate] [datetime] NOT NULL,
[DueDate] [datetime] NOT NULL,
[FineIncurred] [money] NULL,
[BookInstanceId] [int] NOT NULL,
[Returned] [tinyint] NOT NULL CONSTRAINT [DF_Loans_Returned] DEFAULT ((0)),
[FinePaid] [tinyint] NOT NULL CONSTRAINT [DF_Loans_FinePaid] DEFAULT ((0))
) ON [PRIMARY]
ALTER TABLE [dbo].[Loans] ADD 
CONSTRAINT [PK_Loans_Id] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
ALTER TABLE [dbo].[Loans] ADD
CONSTRAINT [FK_BookInstanceId] FOREIGN KEY ([BookInstanceId]) REFERENCES [dbo].[BookInstances] ([Id])
ALTER TABLE [dbo].[Loans] ADD
CONSTRAINT [FK_MemberId] FOREIGN KEY ([MemberId]) REFERENCES [dbo].[Members] ([Id])
GO
