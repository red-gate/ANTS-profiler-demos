CREATE TABLE [dbo].[aspnet_Membership]
(
[ApplicationId] [uniqueidentifier] NOT NULL,
[UserId] [uniqueidentifier] NOT NULL,
[Password] [nvarchar] (128) COLLATE Latin1_General_CI_AS NOT NULL,
[PasswordFormat] [int] NOT NULL CONSTRAINT [DF__aspnet_Me__Passw__5629CD9C] DEFAULT ((0)),
[PasswordSalt] [nvarchar] (128) COLLATE Latin1_General_CI_AS NOT NULL,
[MobilePIN] [nvarchar] (16) COLLATE Latin1_General_CI_AS NULL,
[Email] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[LoweredEmail] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[PasswordQuestion] [nvarchar] (256) COLLATE Latin1_General_CI_AS NULL,
[PasswordAnswer] [nvarchar] (128) COLLATE Latin1_General_CI_AS NULL,
[IsApproved] [bit] NOT NULL,
[IsLockedOut] [bit] NOT NULL,
[CreateDate] [datetime] NOT NULL,
[LastLoginDate] [datetime] NOT NULL,
[LastPasswordChangedDate] [datetime] NOT NULL,
[LastLockoutDate] [datetime] NOT NULL,
[FailedPasswordAttemptCount] [int] NOT NULL,
[FailedPasswordAttemptWindowStart] [datetime] NOT NULL,
[FailedPasswordAnswerAttemptCount] [int] NOT NULL,
[FailedPasswordAnswerAttemptWindowStart] [datetime] NOT NULL,
[Comment] [ntext] COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Membership] ADD CONSTRAINT [PK__aspnet_M__1788CC4D5441852A] PRIMARY KEY NONCLUSTERED  ([UserId]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[aspnet_Membership] ADD CONSTRAINT [FK__aspnet_Me__Appli__1332DBDC] FOREIGN KEY ([ApplicationId]) REFERENCES [dbo].[aspnet_Applications] ([ApplicationId])
GO
ALTER TABLE [dbo].[aspnet_Membership] ADD CONSTRAINT [FK__aspnet_Me__UserI__14270015] FOREIGN KEY ([UserId]) REFERENCES [dbo].[aspnet_Users] ([UserId])
GO
