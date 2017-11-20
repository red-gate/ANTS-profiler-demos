CREATE TABLE [dbo].[aspnet_Roles]
(
[ApplicationId] [uniqueidentifier] NOT NULL,
[RoleId] [uniqueidentifier] NOT NULL CONSTRAINT [DF__aspnet_Ro__RoleI__47DBAE45] DEFAULT (newid()),
[RoleName] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[LoweredRoleName] [nvarchar] (256) COLLATE Latin1_General_CI_AS NOT NULL,
[Description] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD CONSTRAINT [PK__aspnet_R__8AFACE1B45F365D3] PRIMARY KEY NONCLUSTERED  ([RoleId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Roles] ADD CONSTRAINT [FK__aspnet_Ro__Appli__19DFD96B] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
