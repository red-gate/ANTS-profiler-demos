CREATE TABLE [dbo].[aspnet_Paths]
(
[ApplicationId] [uniqueidentifier] NOT NULL,
[PathId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Pa__PathI__4222D4EF] DEFAULT (newid()),
[Path] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[LoweredPath] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Paths] ADD CONSTRAINT [PK__aspnet_P__CD67DC58403A8C7D] PRIMARY KEY NONCLUSTERED  ([PathId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Paths] ADD CONSTRAINT [FK__aspnet_Pa__Appli__151B244E] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
