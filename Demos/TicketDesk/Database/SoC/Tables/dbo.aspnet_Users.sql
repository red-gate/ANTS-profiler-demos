CREATE TABLE [dbo].[aspnet_Users]
(
[ApplicationId] [uniqueidentifier] NOT NULL,
[UserId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Us__UserI__38996AB5] DEFAULT (newid()),
[UserName] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[LoweredUserName] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[MobileAlias] [nvarchar] (16) COLLATE Latin1_General_CI_AS NULL CONSTRAINT [DF__aspnet_Us__Mobil__398D8EEE] DEFAULT (NULL),
[IsAnonymous] [bit] NOT NULL CONSTRAINT [DF__aspnet_Us__IsAno__3A81B327] DEFAULT ((0)),
[LastActivityDate] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD CONSTRAINT [PK__aspnet_U__1788CC4D36B12243] PRIMARY KEY NONCLUSTERED  ([UserId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Users] ADD CONSTRAINT [FK__aspnet_Us__Appli__1AD3FDA4] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
