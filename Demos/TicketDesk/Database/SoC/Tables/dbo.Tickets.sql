CREATE TABLE [dbo].[Tickets]
(
[TicketId] [int] NOT NULL IDENTITY(1, 1),
[Type] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Category] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Title] [nvarchar] (500) COLLATE Latin1_General_CI_AS NOT NULL,
[Details] [ntext] COLLATE Latin1_General_CI_AS NOT NULL,
[IsHtml] [bit] NOT NULL CONSTRAINT [DF_Tickets_IsHtml] DEFAULT ((0)),
[TagList] [nvarchar] (100) COLLATE Latin1_General_CI_AS NULL,
[CreatedBy] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_Tickets_CreatedDate] DEFAULT (getdate()),
[Owner] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[AssignedTo] [nvarchar] (100) COLLATE Latin1_General_CI_AS NULL,
[CurrentStatus] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[CurrentStatusDate] [datetime] NOT NULL,
[CurrentStatusSetBy] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[LastUpdateBy] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[LastUpdateDate] [datetime] NOT NULL,
[Priority] [nvarchar] (25) COLLATE Latin1_General_CI_AS NULL,
[AffectsCustomer] [bit] NOT NULL CONSTRAINT [DF_Tickets_AffectsCustomer] DEFAULT ((0)),
[PublishedToKb] [bit] NOT NULL CONSTRAINT [DF_Tickets_PublishedToKb] DEFAULT ((0)),
[Version] [timestamp] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tickets] ADD CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED  ([TicketId]) ON [PRIMARY]
GO
