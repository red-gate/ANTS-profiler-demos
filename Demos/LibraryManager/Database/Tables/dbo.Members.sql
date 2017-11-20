CREATE TABLE [dbo].[Members]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[FirstName] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[LastName] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Address1] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[Address2] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[Address3] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[City] [varchar] (50) COLLATE Latin1_General_CI_AS NOT NULL,
[County] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[Country] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[PostCode] [varchar] (10) COLLATE Latin1_General_CI_AS NULL,
[Phone1] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[Phone2] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[Email1] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[Email2] [varchar] (50) COLLATE Latin1_General_CI_AS NULL,
[JoinDate] [datetime] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Members] ADD 
CONSTRAINT [PK_Members_Id] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
