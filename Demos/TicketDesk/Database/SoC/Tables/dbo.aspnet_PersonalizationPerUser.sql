CREATE TABLE [dbo].[aspnet_PersonalizationPerUser]
(
[Id] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Perso__Id__4D94879B] DEFAULT (newid()),
[PathId] [uniqueidentifier] NULL,
[UserId] [uniqueidentifier] NULL,
[PageSettings] [image] NOT NULL,
[LastUpdatedDate] [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [PK__aspnet_P__3214EC064BAC3F29] PRIMARY KEY NONCLUSTERED  ([Id]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [FK__aspnet_Pe__PathI__17036CC0] FOREIGN KEY ([PathId]) REFERENCES [dbo].[aspnet_Paths] ([PathId])
GO
ALTER TABLE [dbo].[aspnet_PersonalizationPerUser] ADD CONSTRAINT [FK__aspnet_Pe__UserI__17F790F9] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
