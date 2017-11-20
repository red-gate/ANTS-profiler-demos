CREATE TABLE [dbo].[aspnet_WebEvent_Events]
(
[EventId] [char] (32) COLLATE Latin1_General_CI_AS NOT NULL,
[EventTimeUtc] [datetime] NOT NULL,
[EventTime] [datetime] NOT NULL,
[EventType] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[EventSequence] [decimal] (19, 0) NOT NULL,
[EventOccurrence] [decimal] (19, 0) NOT NULL,
[EventCode] [int] NOT NULL,
[EventDetailCode] [int] NOT NULL,
[Message] [nvarchar] (1024) COLLATE Latin1_General_CI_AS NULL,
[ApplicationPath] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[ApplicationVirtualPath] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[MachineName] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[RequestUrl] [nvarchar] (1024) COLLATE Latin1_General_CI_AS NULL,
[ExceptionType] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[Details] [ntext] COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_WebEvent_Events] ADD CONSTRAINT [PK__aspnet_W__7944C8102B3F6F97] PRIMARY KEY CLUSTERED  ([EventId]) ON [PRIMARY]
GO
