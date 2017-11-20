CREATE TABLE [dbo].[TicketEventNotifications]
(
[TicketId] [int] NOT NULL,
[CommentId] [int] NOT NULL,
[NotifyUser] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[NotifyUserDisplayName] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[NotifyEmail] [nvarchar] (255) COLLATE Latin1_General_CI_AS NOT NULL,
[NotifyUserReason] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[CreatedDate] [datetime] NOT NULL,
[DeliveryAttempts] [int] NOT NULL,
[LastDeliveryAttemptDate] [datetime] NULL,
[Status] [nvarchar] (20) COLLATE Latin1_General_CI_AS NOT NULL,
[NextDeliveryAttemptDate] [datetime] NULL,
[EventGeneratedByUser] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketEventNotifications] ADD CONSTRAINT [PK_TicketEventNotifications] PRIMARY KEY CLUSTERED  ([TicketId], [CommentId], [NotifyUser]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TicketEventNotifications] ADD CONSTRAINT [FK_TicketEventNotifications_TicketComments] FOREIGN KEY ([TicketId], [CommentId]) REFERENCES [dbo].[TicketComments] ([TicketId], [CommentId])
GO
