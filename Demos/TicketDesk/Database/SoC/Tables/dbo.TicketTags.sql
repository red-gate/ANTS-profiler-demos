CREATE TABLE [dbo].[TicketTags]
(
[TicketTagId] [int] NOT NULL IDENTITY(1, 1),
[TagName] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[TicketId] [int] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketTags] ADD CONSTRAINT [PK_TicketTags] PRIMARY KEY CLUSTERED  ([TicketTagId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketTags] ADD CONSTRAINT [FK_TicketTags_Tickets] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Tickets] ([TicketId]) ON DELETE CASCADE
GO
