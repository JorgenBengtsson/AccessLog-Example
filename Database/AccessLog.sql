USE [AccessLog]
GO
/****** Object:  Table [dbo].[accesslog]    Script Date: 2019-09-21 08:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[accesslog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NOT NULL,
	[loggedin] [date] NOT NULL,
 CONSTRAINT [PK_accesslog] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2019-09-21 08:19:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NULL,
	[created] [date] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[accesslog] ADD  CONSTRAINT [DF_accesslog_loggedin]  DEFAULT (getdate()) FOR [loggedin]
GO
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_created]  DEFAULT (getdate()) FOR [created]
GO
ALTER TABLE [dbo].[accesslog]  WITH CHECK ADD  CONSTRAINT [FK_accesslog_user] FOREIGN KEY([userid])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[accesslog] CHECK CONSTRAINT [FK_accesslog_user]
GO
