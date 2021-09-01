USE [Exam_ASPNet]
GO
/****** Object:  StoredProcedure [dbo].[sp_htUsers_Login]    Script Date: 9/1/2021 7:14:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_htUsers_Login]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_htUsers_Login]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_htUsers_Active]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[htUsers] DROP CONSTRAINT [DF_htUsers_Active]
END
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DF_htUsers_Admin]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[htUsers] DROP CONSTRAINT [DF_htUsers_Admin]
END
GO
/****** Object:  Table [dbo].[htUsers]    Script Date: 9/1/2021 7:14:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[htUsers]') AND type in (N'U'))
DROP TABLE [dbo].[htUsers]
GO
/****** Object:  Table [dbo].[examStudent]    Script Date: 9/1/2021 7:14:56 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[examStudent]') AND type in (N'U'))
DROP TABLE [dbo].[examStudent]
GO
/****** Object:  Table [dbo].[examStudent]    Script Date: 9/1/2021 7:14:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examStudent](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](20) NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[htUsers]    Script Date: 9/1/2021 7:14:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[htUsers](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[PassWord] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[Admin] [bit] NULL,
	[Active] [bit] NULL,
	[Email] [nvarchar](200) NULL,
 CONSTRAINT [PK_htUsers] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[htUsers] ADD  CONSTRAINT [DF_htUsers_Admin]  DEFAULT ((0)) FOR [Admin]
GO
ALTER TABLE [dbo].[htUsers] ADD  CONSTRAINT [DF_htUsers_Active]  DEFAULT ((1)) FOR [Active]
GO
/****** Object:  StoredProcedure [dbo].[sp_htUsers_Login]    Script Date: 9/1/2021 7:14:56 PM ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
---------------------------------------------------------------------------
CREATE PROCEDURE [dbo].[sp_htUsers_Login]
	@UserName	nvarchar(20),
	@PassWord	nvarchar(50)
AS
SELECT	*
FROM	htUsers
WHERE (UPPER(UserName) = UPPER(@UserName)) AND (PassWord=@PassWord) and Active=1

GO
