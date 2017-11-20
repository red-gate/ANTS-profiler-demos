CREATE TABLE [dbo].[AdCachedRoleMembers]
(
[GroupName] [nvarchar] (150) COLLATE Latin1_General_CI_AS NOT NULL,
[MemberName] [nvarchar] (150) COLLATE Latin1_General_CI_AS NOT NULL,
[MemberDisplayName] [nvarchar] (150) COLLATE Latin1_General_CI_AS NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdCachedRoleMembers] ADD CONSTRAINT [PK_AdCachedRoleMembers] PRIMARY KEY CLUSTERED  ([GroupName], [MemberName]) ON [PRIMARY]
GO
