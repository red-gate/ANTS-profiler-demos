CREATE TABLE [dbo].[TicketAttachments]
(
[TicketId] [int] NULL,
[FileId] [int] NOT NULL IDENTITY(1, 1),
[FileName] [nvarchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
[FileSize] [int] NOT NULL,
[FileType] [nvarchar] (250) COLLATE Latin1_General_CI_AS NOT NULL,
[UploadedBy] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[UploadedDate] [datetime] NOT NULL,
[FileContents] [varbinary] (max) NOT NULL,
[FileDescription] [nvarchar] (500) COLLATE Latin1_General_CI_AS NULL,
[IsPending] [bit] NOT NULL CONSTRAINT [TicketAttachments_IsPending] DEFAULT ((0))
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketAttachments] ADD CONSTRAINT [PK_TicketAttachments] PRIMARY KEY CLUSTERED  ([FileId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketAttachments] ADD CONSTRAINT [FK_TicketAttachments_Tickets] FOREIGN KEY ([TicketId]) REFERENCES [dbo].[Tickets] ([TicketId])
GO
