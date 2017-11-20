CREATE TABLE [dbo].[AdCachedUserProperties]
(
[UserName] [nvarchar] (150) COLLATE Latin1_General_CI_AS NOT NULL,
[PropertyName] [nvarchar] (100) COLLATE Latin1_General_CI_AS NOT NULL,
[PropertyValue] [nvarchar] (250) COLLATE Latin1_General_CI_AS NULL,
[LastRefreshed] [datetime] NULL,
[IsActiveInAd] [bit] NOT NULL CONSTRAINT [DF_AdCachedUserProperties_IsActiveInAd] DEFAULT ((1))
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdCachedUserProperties] ADD CONSTRAINT [PK_AdCachedUserProperties] PRIMARY KEY CLUSTERED  ([UserName], [PropertyName]) ON [PRIMARY]
GO
