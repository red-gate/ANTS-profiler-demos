CREATE TABLE [dbo].[TicketComments]
(
[TicketId] [int] NOT NULL,
[CommentId] [int] NOT NULL IDENTITY(1, 1),
[CommentEvent] [nvarchar] (500) COLLATE Latin1_General_CI_AS NULL,
[Comment] [ntext] COLLATE Latin1_General_CI_AS NULL,
[IsHtml] [bit] NOT NULL CONSTRAINT [DF_TicketComments_IsHtml] DEFAULT ((0)),
[CommentedBy] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[CommentedDate] [datetime] NOT NULL CONSTRAINT [DF_TicketComments_CommentDate] DEFAULT (getdate()),
[Version] [timestamp] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketComments] ADD CONSTRAINT [PK_TicketComments] PRIMARY KEY CLUSTERED  ([TicketId], [CommentId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketComments] ADD CONSTRAINT [FK_TicketComments_Tickets] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Tickets] ([TicketId]) ON DELETE CASCADE
GO
