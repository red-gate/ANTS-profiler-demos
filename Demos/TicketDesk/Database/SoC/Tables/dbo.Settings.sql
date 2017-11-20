CREATE TABLE [dbo].[Settings]
(
[SettingName] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[SettingValue] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[DefaultValue] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL,
[SettingType] [nvarchar] (50) COLLATE Latin1_General_CI_AS NOT NULL CONSTRAINT [DF_Settings_SettingType] DEFAULT (N'SimpleString'),
[SettingDescription] [nvarchar] (max) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Settings] ADD CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED  ([SettingName]) ON [PRIMARY]
GO
